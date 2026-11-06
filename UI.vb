Imports System.Drawing
Imports System.Globalization
Imports System.Windows.Forms

' =====================================================================
'  UI.vb - colours and small helper functions used by every screen.
'  Every feature has its OWN colour so users can find things quickly.
' =====================================================================
Public Module UI

    Public ReadOnly CediSign As String = "GH" & ChrW(&H20B5) & " "

    Public Function Col(code As String) As Color
        Return ColorTranslator.FromHtml(code)
    End Function

    ' ---- base ----
    Public ReadOnly PageBg As Color = Col("#F3F5F4")
    Public ReadOnly Ink As Color = Col("#1F2933")
    Public ReadOnly Muted As Color = Col("#5B6770")
    Public ReadOnly LineColor As Color = Col("#D5DCD8")
    Public ReadOnly BrandGreen As Color = Col("#0B5D3B")

    ' ---- one colour per button / feature ----
    Public ReadOnly SaveGreen As Color = Col("#15803D")      ' Save Transaction
    Public ReadOnly ClearGrey As Color = Col("#64748B")      ' Clear / Reset
    Public ReadOnly ReportTeal As Color = Col("#0D9488")     ' Daily Report
    Public ReadOnly LimitPurple As Color = Col("#7C3AED")    ' Set Float Limit
    Public ReadOnly BalanceCyan As Color = Col("#0891B2")    ' Set Balances
    Public ReadOnly BackupIndigo As Color = Col("#4338CA")   ' Save Backup
    Public ReadOnly VoidRed As Color = Col("#B91C1C")        ' Void / Delete
    Public ReadOnly LogoutSlate As Color = Col("#334155")    ' Log out
    Public ReadOnly ExitMaroon As Color = Col("#7F1D1D")     ' Exit / Clear all
    Public ReadOnly PrintOrange As Color = Col("#EA580C")    ' Print
    Public ReadOnly PreviewSky As Color = Col("#0284C7")     ' Print preview
    Public ReadOnly RefreshLime As Color = Col("#65A30D")    ' Refresh
    Public ReadOnly ExportOlive As Color = Col("#A16207")    ' Export log

    ' ---- one colour per tab ----
    Public ReadOnly CashAmber As Color = Col("#D97706")      ' Physical Cash
    Public ReadOnly ECashNavy As Color = Col("#1E3A8A")      ' E-Cash
    Public ReadOnly LogBrown As Color = Col("#92400E")       ' Activity Log
    Public ReadOnly UserPink As Color = Col("#DB2777")       ' Users

    ' ---- login ----
    Public ReadOnly AdminPurple As Color = Col("#6D28D9")
    Public ReadOnly WorkerTeal As Color = Col("#0F766E")

    ' ---- one colour per network ----
    Public ReadOnly MtnYellow As Color = Col("#FFCB05")
    Public ReadOnly TelecelRed As Color = Col("#E30613")
    Public ReadOnly AirtelBlue As Color = Col("#2563EB")

    ' ---- summary tiles and alerts ----
    Public ReadOnly TileSky As Color = Col("#0EA5E9")
    Public ReadOnly TileGold As Color = Col("#F59E0B")
    Public ReadOnly TileMint As Color = Col("#10B981")
    Public ReadOnly AlertOrange As Color = Col("#C2410C")
    Public ReadOnly AlertTint As Color = Col("#FFEDD5")
    Public ReadOnly OkTint As Color = Col("#EAF3EC")

    Public Function Money(value As Decimal) As String
        Return CediSign & value.ToString("N2", CultureInfo.InvariantCulture)
    End Function

    ' ---------- control factories ----------
    Public Function MakeLabel(text As String, x As Integer, y As Integer, Optional size As Single = 10.5F, Optional bold As Boolean = False, Optional fore As Color = Nothing) As Label
        Dim l As New Label()
        l.Text = text
        l.AutoSize = True
        l.Location = New Point(x, y)
        l.Font = New Font("Segoe UI", size, If(bold, FontStyle.Bold, FontStyle.Regular))
        l.ForeColor = If(fore.IsEmpty, Muted, fore)
        l.BackColor = Color.Transparent
        Return l
    End Function

    Public Function MakeTextBox(x As Integer, y As Integer, w As Integer) As TextBox
        Dim t As New TextBox()
        t.Location = New Point(x, y)
        t.Size = New Size(w, 29)
        t.Font = New Font("Segoe UI", 11.0F)
        t.ForeColor = Ink
        t.BackColor = Color.White
        Return t
    End Function

    Public Function MakeCombo(x As Integer, y As Integer, w As Integer) As ComboBox
        Dim c As New ComboBox()
        c.Location = New Point(x, y)
        c.Size = New Size(w, 29)
        c.DropDownStyle = ComboBoxStyle.DropDownList
        c.Font = New Font("Segoe UI", 11.0F)
        c.ForeColor = Ink
        c.BackColor = Color.White
        Return c
    End Function

    Public Function MakeButton(text As String, back As Color, x As Integer, y As Integer, w As Integer, h As Integer, Optional fore As Color = Nothing) As Button
        Dim b As New Button()
        b.Text = text
        b.Location = New Point(x, y)
        b.Size = New Size(w, h)
        b.FlatStyle = FlatStyle.Flat
        b.FlatAppearance.BorderSize = 0
        b.UseVisualStyleBackColor = False
        b.BackColor = back
        b.ForeColor = If(fore.IsEmpty, Color.White, fore)
        b.Font = New Font("Segoe UI", 10.5F, FontStyle.Bold)
        b.Cursor = Cursors.Hand
        Return b
    End Function

    Public Function MakePanel(x As Integer, y As Integer, w As Integer, h As Integer, back As Color) As Panel
        Dim p As New Panel()
        p.Location = New Point(x, y)
        p.Size = New Size(w, h)
        p.BackColor = back
        Return p
    End Function

    Public Function MakeGroup(title As String, x As Integer, y As Integer, w As Integer, h As Integer, accent As Color) As GroupBox
        Dim g As New GroupBox()
        g.Text = title
        g.Location = New Point(x, y)
        g.Size = New Size(w, h)
        g.Font = New Font("Segoe UI", 11.5F, FontStyle.Bold)
        g.ForeColor = accent
        Return g
    End Function

    ''' <summary>A white summary tile with a coloured stripe on the left.</summary>
    Public Function MakeTile(caption As String, accent As Color, x As Integer, y As Integer, w As Integer, h As Integer, ByRef valueLabel As Label) As Panel
        Dim p As Panel = MakePanel(x, y, w, h, Color.White)
        p.Controls.Add(MakePanel(0, 0, 7, h, accent))
        p.Controls.Add(MakeLabel(caption, 18, 9, 10.0F, True, Muted))
        valueLabel = MakeLabel("", 16, 34, 17.0F, True, Ink)
        p.Controls.Add(valueLabel)
        Return p
    End Function

    ' ---------- data grid helpers ----------
    Public Sub StyleGrid(g As DataGridView, headerColor As Color)
        g.AutoGenerateColumns = False
        g.AllowUserToAddRows = False
        g.AllowUserToDeleteRows = False
        g.AllowUserToResizeRows = False
        g.ReadOnly = True
        g.MultiSelect = False
        g.RowHeadersVisible = False
        g.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        g.BackgroundColor = Color.White
        g.BorderStyle = BorderStyle.None
        g.GridColor = LineColor
        g.Font = New Font("Segoe UI", 10.5F)
        g.RowTemplate.Height = 30
        g.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        g.ColumnHeadersHeight = 34
        g.EnableHeadersVisualStyles = False
        g.ColumnHeadersDefaultCellStyle.BackColor = headerColor
        g.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        g.ColumnHeadersDefaultCellStyle.SelectionBackColor = headerColor
        g.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10.5F, FontStyle.Bold)
        g.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(246, 248, 247)
        g.DefaultCellStyle.ForeColor = Ink
        g.DefaultCellStyle.SelectionBackColor = ControlPaint.Light(headerColor, 0.75F)
        g.DefaultCellStyle.SelectionForeColor = Ink
    End Sub

    Public Sub AddGridColumn(g As DataGridView, prop As String, header As String, Optional isMoney As Boolean = False, Optional weight As Single = 100.0F)
        Dim c As New DataGridViewTextBoxColumn()
        c.DataPropertyName = prop
        c.HeaderText = header
        c.FillWeight = weight
        If isMoney Then
            c.DefaultCellStyle.Format = "N2"
            c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            c.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        End If
        g.Columns.Add(c)
    End Sub

End Module
