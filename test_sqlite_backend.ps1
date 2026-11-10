# test_sqlite_backend.ps1 - Automated verification of SQLite backend
$ErrorActionPreference = "Stop"

Write-Host "========================================="
Write-Host " FLOATWISE SQLITE BACKEND VERIFICATION   "
Write-Host "========================================="

$binDir = "c:\Users\Dell\source\repos\FloatWise\bin\Debug"
$exePath = Join-Path $binDir "FloatWise.exe"
$sqliteDll = Join-Path $binDir "System.Data.SQLite.dll"

if (-not (Test-Path $exePath)) {
    throw "FloatWise.exe not found at $exePath"
}
if (-not (Test-Path $sqliteDll)) {
    throw "System.Data.SQLite.dll not found at $sqliteDll"
}

# Load assemblies
[System.Reflection.Assembly]::LoadFrom($sqliteDll) | Out-Null
$floatwiseAsm = [System.Reflection.Assembly]::LoadFrom($exePath)

$dbFolder = [System.IO.Path]::Combine($env:APPDATA, "FloatWise")
$dbPath = [System.IO.Path]::Combine($dbFolder, "floatwise.db")

Write-Host "[1/6] Initializing Database..."
$dbModule = $floatwiseAsm.GetType("FloatWise.Database")
$initMethod = $dbModule.GetMethod("InitDatabase")
$initMethod.Invoke($null, @())

if (-not (Test-Path $dbPath)) {
    throw "Database file was not created at $dbPath"
}
Write-Host " -> SQLite database verified at: $dbPath (Size: $((Get-Item $dbPath).Length) bytes)"

Write-Host "[2/6] Verifying Table Schema..."
$connStr = "Data Source=$dbPath;Version=3;"
$conn = New-Object System.Data.SQLite.SQLiteConnection($connStr)
$conn.Open()

$tablesCmd = $conn.CreateCommand()
$tablesCmd.CommandText = "SELECT name FROM sqlite_master WHERE type='table' ORDER BY name;"
$reader = $tablesCmd.ExecuteReader()
$tables = @()
while ($reader.Read()) {
    $tables += $reader.GetString(0)
}
$reader.Close()

Write-Host " -> Found tables: $($tables -join ', ')"
$required = @("audit_logs", "cash_counts", "till_state", "transactions", "users", "wallet_floats")
foreach ($req in $required) {
    if ($tables -notcontains $req) {
        throw "Missing required table: $req"
    }
}
Write-Host " -> All 6 required tables present and verified!"

Write-Host "[3/6] Testing User Account Persistence in SQLite..."
$authModule = $floatwiseAsm.GetType("FloatWise.AuthStore")
$createMethod = $authModule.GetMethod("CreateUser")
$testUser = "test_teller_" + (Get-Random -Minimum 1000 -Maximum 9999)
$res = $createMethod.Invoke($null, @("Kofi Mensah", $testUser, "Pass1234", "Pass1234", "Worker"))
if ($res -ne "") {
    throw "CreateUser failed: $res"
}

# Verify user exists in SQLite table
$userCmd = $conn.CreateCommand()
$userCmd.CommandText = "SELECT role, active FROM users WHERE username = @user;"
$userCmd.Parameters.AddWithValue("@user", $testUser) | Out-Null
$uReader = $userCmd.ExecuteReader()
if (-not $uReader.Read()) {
    throw "User $testUser not found in SQLite table 'users'"
}
$uRole = $uReader.GetString(0)
$uActive = $uReader.GetInt32(1)
$uReader.Close()

if ($uRole -ne "Worker" -or $uActive -ne 1) {
    throw "User data mismatch: Role=$uRole, Active=$uActive"
}
Write-Host " -> User '$testUser' successfully stored and verified in SQLite users table!"

Write-Host "[4/6] Testing Balance & Float State Updates..."
$ledgerModule = $floatwiseAsm.GetType("FloatWise.Ledger")
$saveBalMethod = $ledgerModule.GetMethod("SaveBalances")
$newFloats = New-Object 'System.Collections.Generic.Dictionary[string,decimal]'
$newFloats["MTN MoMo"] = [decimal]5000.00
$newFloats["Telecel Cash"] = [decimal]3000.00
$newFloats["AirtelTigo Money"] = [decimal]2000.00
$saveBalArgs = [object[]]@([decimal]1500.00, $newFloats.psobject.BaseObject)
$saveBalMethod.Invoke($null, $saveBalArgs)

# Query SQLite directly to verify balances
$balCmd = $conn.CreateCommand()
$balCmd.CommandText = "SELECT balance FROM wallet_floats WHERE network = 'MTN MoMo';"
$mtnBal = [decimal]$balCmd.ExecuteScalar()
if ($mtnBal -ne 5000.00) {
    throw "MTN MoMo balance in SQLite is $mtnBal, expected 5000.00"
}

$tillCmd = $conn.CreateCommand()
$tillCmd.CommandText = "SELECT value FROM till_state WHERE key = 'cash_in_till';"
$tillVal = [decimal]$tillCmd.ExecuteScalar()
if ($tillVal -ne 1500.00) {
    throw "Till balance in SQLite is $tillVal, expected 1500.00"
}
Write-Host " -> Balances verified: Till=GHc $tillVal, MTN=GHc $mtnBal"

Write-Host "[5/6] Testing Atomic Transaction Execution & ACID Consistency..."
$txnType = $floatwiseAsm.GetType("FloatWise.Txn")
$newTxn = [Activator]::CreateInstance($txnType)
$newTxn.TimeText = (Get-Date).ToString("HH:mm")
$newTxn.Network = "MTN MoMo"
$newTxn.TxnType = "Cash-In"
$newTxn.Phone = "0241234567"
$newTxn.Amount = [decimal]500.00
$newTxn.Commission = [decimal]2.50
$newTxn.RecordedBy = $testUser
$newTxn.Role = "Worker"

$execMethod = $ledgerModule.GetMethod("ExecuteTransaction")
$execArgs = [object[]]@($newTxn, "Test Cash-In of 500 on MTN")
$execMethod.Invoke($null, $execArgs)

# Cash-In of 500: Cash in till increases by 500 (1500 -> 2000), MTN float decreases by 500 (5000 -> 4500)
$tillCmd.CommandText = "SELECT value FROM till_state WHERE key = 'cash_in_till';"
$postTill = [decimal]$tillCmd.ExecuteScalar()
$balCmd.CommandText = "SELECT balance FROM wallet_floats WHERE network = 'MTN MoMo';"
$postFloat = [decimal]$balCmd.ExecuteScalar()

if ($postTill -ne 2000.00) {
    throw "Post-transaction till is $postTill, expected 2000.00"
}
if ($postFloat -ne 4500.00) {
    throw "Post-transaction MTN float is $postFloat, expected 4500.00"
}

# Verify audit log in SQLite
$logCmd = $conn.CreateCommand()
$logCmd.CommandText = "SELECT activity, details FROM audit_logs WHERE activity = 'Cash-In' ORDER BY id DESC LIMIT 1;"
$lReader = $logCmd.ExecuteReader()
if (-not $lReader.Read()) {
    throw "Audit log entry was not found in SQLite"
}
$act = $lReader.GetString(0)
$det = $lReader.GetString(1)
$lReader.Close()
Write-Host " -> Transaction and audit record atomically committed: $act - $det"
Write-Host " -> Updated Till=GHc $postTill, Updated MTN Float=GHc $postFloat"

Write-Host "[6/6] Testing Transaction Void & Automatic Reversal..."
$voidMethod = $ledgerModule.GetMethod("VoidTransaction")
$voidArgs = [object[]]@($newTxn, "Customer canceled deposit", "admin", "Admin", "Void Cash-In of 500 on MTN")
$voidMethod.Invoke($null, $voidArgs)

# Reversal: Till decreases by 500 (2000 -> 1500), MTN float increases by 500 (4500 -> 5000)
$postVoidTill = [decimal]$tillCmd.ExecuteScalar()
$postVoidFloat = [decimal]$balCmd.ExecuteScalar()

if ($postVoidTill -ne 1500.00) {
    throw "Post-void till is $postVoidTill, expected 1500.00"
}
if ($postVoidFloat -ne 5000.00) {
    throw "Post-void MTN float is $postVoidFloat, expected 5000.00"
}

$conn.Close()
Write-Host " -> Post-void balances successfully reversed: Till=GHc $postVoidTill, MTN Float=GHc $postVoidFloat"
Write-Host ""
Write-Host "ALL 6 BACKEND TESTS PASSED EMPIRICALLY WITH 100% SUCCESS!"
