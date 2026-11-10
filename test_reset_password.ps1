# test_reset_password.ps1 - Automated verification of Password Reset for Admin and Workers
$ErrorActionPreference = "Stop"

Write-Host "========================================="
Write-Host " PASSWORD RESET SYSTEM VERIFICATION      "
Write-Host "========================================="

$binDir = "c:\Users\Dell\source\repos\FloatWise\bin\Debug"
$exePath = Join-Path $binDir "FloatWise.exe"
$sqliteDll = Join-Path $binDir "System.Data.SQLite.dll"

[System.Reflection.Assembly]::LoadFrom($sqliteDll) | Out-Null
$floatwiseAsm = [System.Reflection.Assembly]::LoadFrom($exePath)

$dbModule = $floatwiseAsm.GetType("FloatWise.Database")
$dbModule.GetMethod("InitDatabase").Invoke($null, @())

$authModule = $floatwiseAsm.GetType("FloatWise.AuthStore")
$authModule.GetMethod("LoadUsers").Invoke($null, @())

$createMethod = $authModule.GetMethod("CreateUser")
$authMethod = $authModule.GetMethod("Authenticate")
$resetMethod = $authModule.GetMethod("ResetPassword")
$adminResetMethod = $authModule.GetMethod("AdminResetWorkerPassword")

$rnd = Get-Random -Minimum 1000 -Maximum 9999
$adminUser = "admin_rst_$rnd"
$adminName = "Akwasi Admin"
$workerUser = "worker_rst_$rnd"
$workerName = "Ama Worker"

Write-Host "[1/5] Creating Test Accounts..."
$res1 = $createMethod.Invoke($null, @($adminName, $adminUser, "InitialPass1", "InitialPass1", "Admin"))
if ($res1 -ne "") { throw "Failed to create admin: $res1" }

$res2 = $createMethod.Invoke($null, @($workerName, $workerUser, "InitialPass1", "InitialPass1", "Worker"))
if ($res2 -ne "") { throw "Failed to create worker: $res2" }
Write-Host " -> Created Admin '$adminUser' and Worker '$workerUser'"

Write-Host "[2/5] Testing Admin Password Reset (Identity Verification)..."
# Mismatched name should fail
$badReset = $resetMethod.Invoke($null, @($adminUser, "Wrong Name", "NewAdminPass2", "NewAdminPass2", "Admin"))
if ($badReset -eq "") { throw "Expected full name mismatch error, but succeeded" }
Write-Host " -> Correctly rejected mismatched name: '$badReset'"

# Valid reset should succeed
$okReset = $resetMethod.Invoke($null, @($adminUser, $adminName, "NewAdminPass2", "NewAdminPass2", "Admin"))
if ($okReset -ne "") { throw "Admin reset failed: $okReset" }

# Old password must fail
$oldAuth = $authMethod.Invoke($null, @($adminUser, "InitialPass1", "Admin"))
if ($oldAuth -ne $null) { throw "Old admin password still authenticated!" }

# New password must succeed
$newAuth = $authMethod.Invoke($null, @($adminUser, "NewAdminPass2", "Admin"))
if ($newAuth -eq $null) { throw "New admin password failed to authenticate!" }
Write-Host " -> Admin password reset successfully verified!"

Write-Host "[3/5] Testing Worker Password Reset (Identity Verification)..."
# Valid worker self-reset
$okWorkerReset = $resetMethod.Invoke($null, @($workerUser, $workerName, "NewWorkerPass2", "NewWorkerPass2", "Worker"))
if ($okWorkerReset -ne "") { throw "Worker reset failed: $okWorkerReset" }

# New worker password must succeed
$newWorkerAuth = $authMethod.Invoke($null, @($workerUser, "NewWorkerPass2", "Worker"))
if ($newWorkerAuth -eq $null) { throw "New worker password failed to authenticate!" }
Write-Host " -> Worker password reset successfully verified!"

Write-Host "[4/5] Testing Admin Direct Password Override for Worker..."
$admOverride = $adminResetMethod.Invoke($null, @($adminUser, $workerUser, "AdminSetPass3"))
if ($admOverride -ne "") { throw "Admin override failed: $admOverride" }

$overriddenAuth = $authMethod.Invoke($null, @($workerUser, "AdminSetPass3", "Worker"))
if ($overriddenAuth -eq $null) { throw "Overridden worker password failed to authenticate!" }
Write-Host " -> Admin direct password override for worker verified!"

Write-Host "[5/5] Testing Form Designer Instantiation..."
$loginForm = [Activator]::CreateInstance($floatwiseAsm.GetType("FloatWise.frmLogin"))
if ($loginForm -eq $null) { throw "frmLogin failed to instantiate" }
$mainForm = [Activator]::CreateInstance($floatwiseAsm.GetType("FloatWise.frmMain"))
if ($mainForm -eq $null) { throw "frmMain failed to instantiate" }
$loginForm.Dispose()
$mainForm.Dispose()
Write-Host " -> Windows Forms Designer instantiation clean with zero errors!"

Write-Host ""
Write-Host "ALL PASSWORD RESET TESTS PASSED EMPIRICALLY WITH 100% SUCCESS!"
