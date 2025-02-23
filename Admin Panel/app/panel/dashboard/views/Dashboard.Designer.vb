<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Dashboard
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Dashboard))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.parcelpointPnl = New Guna.UI2.WinForms.Guna2Panel()
        Me.logoutBtn = New Guna.UI2.WinForms.Guna2Button()
        Me.utilitiesBtn = New Guna.UI2.WinForms.Guna2Button()
        Me.manageuserBtn = New Guna.UI2.WinForms.Guna2Button()
        Me.dashboardBtn = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2Panel3 = New Guna.UI2.WinForms.Guna2Panel()
        Me.Guna2PictureBox2 = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.Guna2PictureBox1 = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.dashboardPnl = New Guna.UI2.WinForms.Guna2Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Guna2Panel5 = New Guna.UI2.WinForms.Guna2Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dailyCount = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NotificationPanel = New Guna.UI2.WinForms.Guna2Panel()
        Me.NotifPanel = New System.Windows.Forms.Panel()
        Me.ParcelLogsTbl = New Guna.UI2.WinForms.Guna2DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Guna2BorderlessForm1 = New Guna.UI2.WinForms.Guna2BorderlessForm(Me.components)
        Me.Guna2Panel6 = New Guna.UI2.WinForms.Guna2Panel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.Guna2Panel2 = New Guna.UI2.WinForms.Guna2Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.weeklyCount = New System.Windows.Forms.Label()
        Me.Guna2Panel4 = New Guna.UI2.WinForms.Guna2Panel()
        Me.Guna2Panel7 = New Guna.UI2.WinForms.Guna2Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.monthlyCount = New System.Windows.Forms.Label()
        Me.Guna2Panel8 = New Guna.UI2.WinForms.Guna2Panel()
        Me.Guna2Panel9 = New Guna.UI2.WinForms.Guna2Panel()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.anuallyCount = New System.Windows.Forms.Label()
        Me.refreshBtn = New Guna.UI2.WinForms.Guna2Button()
        Me.parcelpointPnl.SuspendLayout()
        Me.Guna2Panel3.SuspendLayout()
        CType(Me.Guna2PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Guna2PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.dashboardPnl.SuspendLayout()
        Me.Guna2Panel5.SuspendLayout()
        Me.NotificationPanel.SuspendLayout()
        CType(Me.ParcelLogsTbl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Guna2Panel6.SuspendLayout()
        Me.Guna2Panel1.SuspendLayout()
        Me.Guna2Panel2.SuspendLayout()
        Me.Guna2Panel4.SuspendLayout()
        Me.Guna2Panel7.SuspendLayout()
        Me.Guna2Panel8.SuspendLayout()
        Me.Guna2Panel9.SuspendLayout()
        Me.SuspendLayout()
        '
        'parcelpointPnl
        '
        Me.parcelpointPnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.parcelpointPnl.Controls.Add(Me.logoutBtn)
        Me.parcelpointPnl.Controls.Add(Me.utilitiesBtn)
        Me.parcelpointPnl.Controls.Add(Me.manageuserBtn)
        Me.parcelpointPnl.Controls.Add(Me.dashboardBtn)
        Me.parcelpointPnl.Controls.Add(Me.Guna2Panel3)
        Me.parcelpointPnl.Dock = System.Windows.Forms.DockStyle.Left
        Me.parcelpointPnl.Location = New System.Drawing.Point(0, 0)
        Me.parcelpointPnl.Margin = New System.Windows.Forms.Padding(4)
        Me.parcelpointPnl.Name = "parcelpointPnl"
        Me.parcelpointPnl.Size = New System.Drawing.Size(391, 975)
        Me.parcelpointPnl.TabIndex = 0
        '
        'logoutBtn
        '
        Me.logoutBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.logoutBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.logoutBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.logoutBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.logoutBtn.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.logoutBtn.FillColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.logoutBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.logoutBtn.ForeColor = System.Drawing.Color.White
        Me.logoutBtn.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.logoutBtn.HoverState.ForeColor = System.Drawing.Color.Black
        Me.logoutBtn.HoverState.Image = Global.Admin_Panel.My.Resources.Resources.logouticonhover
        Me.logoutBtn.Image = Global.Admin_Panel.My.Resources.Resources.logouticon
        Me.logoutBtn.ImageOffset = New System.Drawing.Point(-12, 0)
        Me.logoutBtn.ImageSize = New System.Drawing.Size(30, 30)
        Me.logoutBtn.Location = New System.Drawing.Point(0, 884)
        Me.logoutBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.logoutBtn.Name = "logoutBtn"
        Me.logoutBtn.Size = New System.Drawing.Size(391, 91)
        Me.logoutBtn.TabIndex = 5
        Me.logoutBtn.Text = "Log Out"
        Me.logoutBtn.TextOffset = New System.Drawing.Point(-6, 0)
        '
        'utilitiesBtn
        '
        Me.utilitiesBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.utilitiesBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.utilitiesBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.utilitiesBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.utilitiesBtn.Dock = System.Windows.Forms.DockStyle.Top
        Me.utilitiesBtn.FillColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.utilitiesBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.utilitiesBtn.ForeColor = System.Drawing.Color.White
        Me.utilitiesBtn.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.utilitiesBtn.HoverState.ForeColor = System.Drawing.Color.Black
        Me.utilitiesBtn.HoverState.Image = Global.Admin_Panel.My.Resources.Resources.UtilitiesIconHover
        Me.utilitiesBtn.Image = Global.Admin_Panel.My.Resources.Resources.UtilitiesIcon
        Me.utilitiesBtn.ImageOffset = New System.Drawing.Point(-20, 0)
        Me.utilitiesBtn.ImageSize = New System.Drawing.Size(30, 30)
        Me.utilitiesBtn.Location = New System.Drawing.Point(0, 411)
        Me.utilitiesBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.utilitiesBtn.Name = "utilitiesBtn"
        Me.utilitiesBtn.Size = New System.Drawing.Size(391, 91)
        Me.utilitiesBtn.TabIndex = 4
        Me.utilitiesBtn.Text = "Utilities"
        Me.utilitiesBtn.TextOffset = New System.Drawing.Point(-15, 0)
        '
        'manageuserBtn
        '
        Me.manageuserBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.manageuserBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.manageuserBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.manageuserBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.manageuserBtn.Dock = System.Windows.Forms.DockStyle.Top
        Me.manageuserBtn.FillColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.manageuserBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.manageuserBtn.ForeColor = System.Drawing.Color.White
        Me.manageuserBtn.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.manageuserBtn.HoverState.ForeColor = System.Drawing.Color.Black
        Me.manageuserBtn.HoverState.Image = Global.Admin_Panel.My.Resources.Resources.UsersIconHover
        Me.manageuserBtn.Image = Global.Admin_Panel.My.Resources.Resources.UsersIcon
        Me.manageuserBtn.ImageOffset = New System.Drawing.Point(-6, 0)
        Me.manageuserBtn.ImageSize = New System.Drawing.Size(30, 30)
        Me.manageuserBtn.Location = New System.Drawing.Point(0, 320)
        Me.manageuserBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.manageuserBtn.Name = "manageuserBtn"
        Me.manageuserBtn.Size = New System.Drawing.Size(391, 91)
        Me.manageuserBtn.TabIndex = 3
        Me.manageuserBtn.Text = "Manage User"
        '
        'dashboardBtn
        '
        Me.dashboardBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.dashboardBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.dashboardBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.dashboardBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.dashboardBtn.Dock = System.Windows.Forms.DockStyle.Top
        Me.dashboardBtn.FillColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.dashboardBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.dashboardBtn.ForeColor = System.Drawing.Color.White
        Me.dashboardBtn.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.dashboardBtn.HoverState.ForeColor = System.Drawing.Color.Black
        Me.dashboardBtn.HoverState.Image = Global.Admin_Panel.My.Resources.Resources.DashBoardIconHover
        Me.dashboardBtn.Image = Global.Admin_Panel.My.Resources.Resources.DashBoardIcon
        Me.dashboardBtn.ImageOffset = New System.Drawing.Point(-12, 0)
        Me.dashboardBtn.ImageSize = New System.Drawing.Size(30, 30)
        Me.dashboardBtn.Location = New System.Drawing.Point(0, 229)
        Me.dashboardBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.dashboardBtn.Name = "dashboardBtn"
        Me.dashboardBtn.Size = New System.Drawing.Size(391, 91)
        Me.dashboardBtn.TabIndex = 2
        Me.dashboardBtn.Text = "Dashboard"
        Me.dashboardBtn.TextOffset = New System.Drawing.Point(-6, 0)
        '
        'Guna2Panel3
        '
        Me.Guna2Panel3.Controls.Add(Me.Guna2PictureBox2)
        Me.Guna2Panel3.Controls.Add(Me.Guna2PictureBox1)
        Me.Guna2Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Guna2Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Guna2Panel3.Margin = New System.Windows.Forms.Padding(4)
        Me.Guna2Panel3.Name = "Guna2Panel3"
        Me.Guna2Panel3.Size = New System.Drawing.Size(391, 229)
        Me.Guna2Panel3.TabIndex = 0
        '
        'Guna2PictureBox2
        '
        Me.Guna2PictureBox2.Image = Global.Admin_Panel.My.Resources.Resources.PARCELPOINT
        Me.Guna2PictureBox2.ImageRotate = 0!
        Me.Guna2PictureBox2.Location = New System.Drawing.Point(133, 100)
        Me.Guna2PictureBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.Guna2PictureBox2.Name = "Guna2PictureBox2"
        Me.Guna2PictureBox2.Size = New System.Drawing.Size(201, 18)
        Me.Guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Guna2PictureBox2.TabIndex = 1
        Me.Guna2PictureBox2.TabStop = False
        '
        'Guna2PictureBox1
        '
        Me.Guna2PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2PictureBox1.Image = CType(resources.GetObject("Guna2PictureBox1.Image"), System.Drawing.Image)
        Me.Guna2PictureBox1.ImageRotate = 0!
        Me.Guna2PictureBox1.Location = New System.Drawing.Point(41, 60)
        Me.Guna2PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.Guna2PictureBox1.Name = "Guna2PictureBox1"
        Me.Guna2PictureBox1.Size = New System.Drawing.Size(100, 96)
        Me.Guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Guna2PictureBox1.TabIndex = 0
        Me.Guna2PictureBox1.TabStop = False
        Me.Guna2PictureBox1.UseTransparentBackground = True
        '
        'dashboardPnl
        '
        Me.dashboardPnl.Controls.Add(Me.refreshBtn)
        Me.dashboardPnl.Controls.Add(Me.Guna2Panel8)
        Me.dashboardPnl.Controls.Add(Me.Guna2Panel4)
        Me.dashboardPnl.Controls.Add(Me.Guna2Panel1)
        Me.dashboardPnl.Controls.Add(Me.Label7)
        Me.dashboardPnl.Controls.Add(Me.Guna2Panel5)
        Me.dashboardPnl.Controls.Add(Me.Label4)
        Me.dashboardPnl.Controls.Add(Me.Label3)
        Me.dashboardPnl.Controls.Add(Me.LinkLabel1)
        Me.dashboardPnl.Controls.Add(Me.Label2)
        Me.dashboardPnl.Controls.Add(Me.Label1)
        Me.dashboardPnl.Controls.Add(Me.NotificationPanel)
        Me.dashboardPnl.Controls.Add(Me.ParcelLogsTbl)
        Me.dashboardPnl.FillColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.dashboardPnl.Location = New System.Drawing.Point(399, 15)
        Me.dashboardPnl.Margin = New System.Windows.Forms.Padding(4)
        Me.dashboardPnl.Name = "dashboardPnl"
        Me.dashboardPnl.Size = New System.Drawing.Size(1505, 1231)
        Me.dashboardPnl.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(45, 148)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(169, 39)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Summary"
        '
        'Guna2Panel5
        '
        Me.Guna2Panel5.BackColor = System.Drawing.Color.White
        Me.Guna2Panel5.BorderColor = System.Drawing.Color.White
        Me.Guna2Panel5.BorderRadius = 15
        Me.Guna2Panel5.Controls.Add(Me.Guna2Panel6)
        Me.Guna2Panel5.Controls.Add(Me.Label6)
        Me.Guna2Panel5.Controls.Add(Me.dailyCount)
        Me.Guna2Panel5.FillColor = System.Drawing.Color.White
        Me.Guna2Panel5.Location = New System.Drawing.Point(53, 204)
        Me.Guna2Panel5.Margin = New System.Windows.Forms.Padding(4)
        Me.Guna2Panel5.Name = "Guna2Panel5"
        Me.Guna2Panel5.Size = New System.Drawing.Size(274, 123)
        Me.Guna2Panel5.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.White
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(29, 10)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(180, 29)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Daily Deliveries"
        '
        'dailyCount
        '
        Me.dailyCount.BackColor = System.Drawing.Color.White
        Me.dailyCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dailyCount.ForeColor = System.Drawing.Color.Black
        Me.dailyCount.Location = New System.Drawing.Point(22, 40)
        Me.dailyCount.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.dailyCount.Name = "dailyCount"
        Me.dailyCount.Size = New System.Drawing.Size(232, 76)
        Me.dailyCount.TabIndex = 8
        Me.dailyCount.Text = "--"
        Me.dailyCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(47, 96)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(439, 31)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Welcome to your Admin Dashboard"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(45, 46)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(207, 39)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Hello, User!"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.LinkLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel1.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.Location = New System.Drawing.Point(888, 366)
        Me.LinkLabel1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(110, 31)
        Me.LinkLabel1.TabIndex = 4
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "View All"
        Me.LinkLabel1.UseMnemonic = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(1050, 357)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(216, 39)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Notifications"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(45, 358)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(332, 39)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Recent Parcel Logs"
        '
        'NotificationPanel
        '
        Me.NotificationPanel.AutoScroll = True
        Me.NotificationPanel.BackColor = System.Drawing.Color.White
        Me.NotificationPanel.BorderColor = System.Drawing.Color.Black
        Me.NotificationPanel.BorderThickness = 1
        Me.NotificationPanel.Controls.Add(Me.NotifPanel)
        Me.NotificationPanel.Location = New System.Drawing.Point(1057, 412)
        Me.NotificationPanel.Margin = New System.Windows.Forms.Padding(4)
        Me.NotificationPanel.Name = "NotificationPanel"
        Me.NotificationPanel.Size = New System.Drawing.Size(397, 437)
        Me.NotificationPanel.TabIndex = 1
        '
        'NotifPanel
        '
        Me.NotifPanel.Location = New System.Drawing.Point(0, 0)
        Me.NotifPanel.Name = "NotifPanel"
        Me.NotifPanel.Size = New System.Drawing.Size(397, 437)
        Me.NotifPanel.TabIndex = 11
        '
        'ParcelLogsTbl
        '
        Me.ParcelLogsTbl.AllowUserToDeleteRows = False
        Me.ParcelLogsTbl.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.ParcelLogsTbl.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.ParcelLogsTbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ParcelLogsTbl.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ParcelLogsTbl.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.ParcelLogsTbl.ColumnHeadersHeight = 50
        Me.ParcelLogsTbl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        Me.ParcelLogsTbl.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ParcelLogsTbl.DefaultCellStyle = DataGridViewCellStyle3
        Me.ParcelLogsTbl.GridColor = System.Drawing.Color.WhiteSmoke
        Me.ParcelLogsTbl.Location = New System.Drawing.Point(52, 414)
        Me.ParcelLogsTbl.Margin = New System.Windows.Forms.Padding(4)
        Me.ParcelLogsTbl.Name = "ParcelLogsTbl"
        Me.ParcelLogsTbl.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(56, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ParcelLogsTbl.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.ParcelLogsTbl.RowHeadersVisible = False
        Me.ParcelLogsTbl.RowHeadersWidth = 51
        Me.ParcelLogsTbl.Size = New System.Drawing.Size(946, 516)
        Me.ParcelLogsTbl.TabIndex = 0
        Me.ParcelLogsTbl.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Dark
        Me.ParcelLogsTbl.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.ParcelLogsTbl.ThemeStyle.AlternatingRowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ParcelLogsTbl.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black
        Me.ParcelLogsTbl.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.ParcelLogsTbl.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.ParcelLogsTbl.ThemeStyle.BackColor = System.Drawing.Color.White
        Me.ParcelLogsTbl.ThemeStyle.GridColor = System.Drawing.Color.WhiteSmoke
        Me.ParcelLogsTbl.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.Black
        Me.ParcelLogsTbl.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised
        Me.ParcelLogsTbl.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ParcelLogsTbl.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.ParcelLogsTbl.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        Me.ParcelLogsTbl.ThemeStyle.HeaderStyle.Height = 50
        Me.ParcelLogsTbl.ThemeStyle.ReadOnly = True
        Me.ParcelLogsTbl.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.ParcelLogsTbl.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.ParcelLogsTbl.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ParcelLogsTbl.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black
        Me.ParcelLogsTbl.ThemeStyle.RowsStyle.Height = 22
        Me.ParcelLogsTbl.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.LightGray
        Me.ParcelLogsTbl.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black
        '
        'Column1
        '
        Me.Column1.HeaderText = "Parcel ID"
        Me.Column1.MinimumWidth = 6
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Parcel Name"
        Me.Column2.MinimumWidth = 6
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "Recipient"
        Me.Column3.MinimumWidth = 6
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "Locker Number"
        Me.Column4.MinimumWidth = 6
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.HeaderText = "Date-Time"
        Me.Column5.MinimumWidth = 6
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Guna2BorderlessForm1
        '
        Me.Guna2BorderlessForm1.ContainerControl = Me
        Me.Guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6R
        Me.Guna2BorderlessForm1.TransparentWhileDrag = True
        '
        'Guna2Panel6
        '
        Me.Guna2Panel6.BackColor = System.Drawing.Color.White
        Me.Guna2Panel6.BorderColor = System.Drawing.Color.White
        Me.Guna2Panel6.Controls.Add(Me.Label14)
        Me.Guna2Panel6.Controls.Add(Me.Label15)
        Me.Guna2Panel6.CustomizableEdges.TopLeft = False
        Me.Guna2Panel6.CustomizableEdges.TopRight = False
        Me.Guna2Panel6.FillColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.Guna2Panel6.Location = New System.Drawing.Point(-7, 0)
        Me.Guna2Panel6.Margin = New System.Windows.Forms.Padding(4)
        Me.Guna2Panel6.Name = "Guna2Panel6"
        Me.Guna2Panel6.Size = New System.Drawing.Size(27, 123)
        Me.Guna2Panel6.TabIndex = 9
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(54, 10)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(180, 29)
        Me.Label14.TabIndex = 8
        Me.Label14.Text = "Daily Deliveries"
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(22, 40)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(232, 76)
        Me.Label15.TabIndex = 8
        Me.Label15.Text = "10"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.BackColor = System.Drawing.Color.White
        Me.Guna2Panel1.BorderColor = System.Drawing.Color.White
        Me.Guna2Panel1.BorderRadius = 15
        Me.Guna2Panel1.Controls.Add(Me.Guna2Panel2)
        Me.Guna2Panel1.Controls.Add(Me.Label10)
        Me.Guna2Panel1.Controls.Add(Me.weeklyCount)
        Me.Guna2Panel1.FillColor = System.Drawing.Color.White
        Me.Guna2Panel1.Location = New System.Drawing.Point(363, 204)
        Me.Guna2Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.Size = New System.Drawing.Size(274, 123)
        Me.Guna2Panel1.TabIndex = 10
        '
        'Guna2Panel2
        '
        Me.Guna2Panel2.BackColor = System.Drawing.Color.White
        Me.Guna2Panel2.BorderColor = System.Drawing.Color.White
        Me.Guna2Panel2.Controls.Add(Me.Label8)
        Me.Guna2Panel2.Controls.Add(Me.Label9)
        Me.Guna2Panel2.CustomizableEdges.TopLeft = False
        Me.Guna2Panel2.CustomizableEdges.TopRight = False
        Me.Guna2Panel2.FillColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.Guna2Panel2.Location = New System.Drawing.Point(-7, 0)
        Me.Guna2Panel2.Margin = New System.Windows.Forms.Padding(4)
        Me.Guna2Panel2.Name = "Guna2Panel2"
        Me.Guna2Panel2.Size = New System.Drawing.Size(27, 123)
        Me.Guna2Panel2.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(54, 10)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(180, 29)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Daily Deliveries"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(22, 40)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(232, 76)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "10"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.White
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(29, 10)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(206, 29)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "Weekly Deliveries"
        '
        'weeklyCount
        '
        Me.weeklyCount.BackColor = System.Drawing.Color.White
        Me.weeklyCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.weeklyCount.ForeColor = System.Drawing.Color.Black
        Me.weeklyCount.Location = New System.Drawing.Point(22, 40)
        Me.weeklyCount.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.weeklyCount.Name = "weeklyCount"
        Me.weeklyCount.Size = New System.Drawing.Size(232, 76)
        Me.weeklyCount.TabIndex = 8
        Me.weeklyCount.Text = "--"
        Me.weeklyCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Guna2Panel4
        '
        Me.Guna2Panel4.BackColor = System.Drawing.Color.White
        Me.Guna2Panel4.BorderColor = System.Drawing.Color.White
        Me.Guna2Panel4.BorderRadius = 15
        Me.Guna2Panel4.Controls.Add(Me.Guna2Panel7)
        Me.Guna2Panel4.Controls.Add(Me.Label16)
        Me.Guna2Panel4.Controls.Add(Me.monthlyCount)
        Me.Guna2Panel4.FillColor = System.Drawing.Color.White
        Me.Guna2Panel4.Location = New System.Drawing.Point(675, 204)
        Me.Guna2Panel4.Margin = New System.Windows.Forms.Padding(4)
        Me.Guna2Panel4.Name = "Guna2Panel4"
        Me.Guna2Panel4.Size = New System.Drawing.Size(274, 123)
        Me.Guna2Panel4.TabIndex = 11
        '
        'Guna2Panel7
        '
        Me.Guna2Panel7.BackColor = System.Drawing.Color.White
        Me.Guna2Panel7.BorderColor = System.Drawing.Color.White
        Me.Guna2Panel7.Controls.Add(Me.Label12)
        Me.Guna2Panel7.Controls.Add(Me.Label13)
        Me.Guna2Panel7.CustomizableEdges.TopLeft = False
        Me.Guna2Panel7.CustomizableEdges.TopRight = False
        Me.Guna2Panel7.FillColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.Guna2Panel7.Location = New System.Drawing.Point(-7, 0)
        Me.Guna2Panel7.Margin = New System.Windows.Forms.Padding(4)
        Me.Guna2Panel7.Name = "Guna2Panel7"
        Me.Guna2Panel7.Size = New System.Drawing.Size(27, 123)
        Me.Guna2Panel7.TabIndex = 9
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(54, 10)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(180, 29)
        Me.Label12.TabIndex = 8
        Me.Label12.Text = "Daily Deliveries"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(22, 40)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(232, 76)
        Me.Label13.TabIndex = 8
        Me.Label13.Text = "10"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.White
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(29, 10)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(210, 29)
        Me.Label16.TabIndex = 8
        Me.Label16.Text = "Monthly Deliveries"
        '
        'monthlyCount
        '
        Me.monthlyCount.BackColor = System.Drawing.Color.White
        Me.monthlyCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.monthlyCount.ForeColor = System.Drawing.Color.Black
        Me.monthlyCount.Location = New System.Drawing.Point(22, 40)
        Me.monthlyCount.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.monthlyCount.Name = "monthlyCount"
        Me.monthlyCount.Size = New System.Drawing.Size(232, 76)
        Me.monthlyCount.TabIndex = 8
        Me.monthlyCount.Text = "--"
        Me.monthlyCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Guna2Panel8
        '
        Me.Guna2Panel8.BackColor = System.Drawing.Color.White
        Me.Guna2Panel8.BorderColor = System.Drawing.Color.White
        Me.Guna2Panel8.BorderRadius = 20
        Me.Guna2Panel8.BorderThickness = 5
        Me.Guna2Panel8.Controls.Add(Me.Guna2Panel9)
        Me.Guna2Panel8.Controls.Add(Me.Label20)
        Me.Guna2Panel8.Controls.Add(Me.anuallyCount)
        Me.Guna2Panel8.FillColor = System.Drawing.Color.White
        Me.Guna2Panel8.Location = New System.Drawing.Point(992, 204)
        Me.Guna2Panel8.Margin = New System.Windows.Forms.Padding(4)
        Me.Guna2Panel8.Name = "Guna2Panel8"
        Me.Guna2Panel8.Size = New System.Drawing.Size(274, 123)
        Me.Guna2Panel8.TabIndex = 12
        '
        'Guna2Panel9
        '
        Me.Guna2Panel9.BackColor = System.Drawing.Color.White
        Me.Guna2Panel9.BorderColor = System.Drawing.Color.White
        Me.Guna2Panel9.Controls.Add(Me.Label18)
        Me.Guna2Panel9.Controls.Add(Me.Label19)
        Me.Guna2Panel9.CustomizableEdges.TopLeft = False
        Me.Guna2Panel9.CustomizableEdges.TopRight = False
        Me.Guna2Panel9.FillColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.Guna2Panel9.Location = New System.Drawing.Point(-7, 0)
        Me.Guna2Panel9.Margin = New System.Windows.Forms.Padding(4)
        Me.Guna2Panel9.Name = "Guna2Panel9"
        Me.Guna2Panel9.Size = New System.Drawing.Size(27, 123)
        Me.Guna2Panel9.TabIndex = 9
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(54, 10)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(180, 29)
        Me.Label18.TabIndex = 8
        Me.Label18.Text = "Daily Deliveries"
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(22, 40)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(232, 76)
        Me.Label19.TabIndex = 8
        Me.Label19.Text = "10"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.White
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(29, 10)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(204, 29)
        Me.Label20.TabIndex = 8
        Me.Label20.Text = "Anually Deliveries"
        '
        'anuallyCount
        '
        Me.anuallyCount.BackColor = System.Drawing.Color.White
        Me.anuallyCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.anuallyCount.ForeColor = System.Drawing.Color.Black
        Me.anuallyCount.Location = New System.Drawing.Point(22, 40)
        Me.anuallyCount.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.anuallyCount.Name = "anuallyCount"
        Me.anuallyCount.Size = New System.Drawing.Size(232, 76)
        Me.anuallyCount.TabIndex = 8
        Me.anuallyCount.Text = "--"
        Me.anuallyCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'refreshBtn
        '
        Me.refreshBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.refreshBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.refreshBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.refreshBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.refreshBtn.FillColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.refreshBtn.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.refreshBtn.ForeColor = System.Drawing.Color.Black
        Me.refreshBtn.Location = New System.Drawing.Point(1137, 869)
        Me.refreshBtn.Name = "refreshBtn"
        Me.refreshBtn.Size = New System.Drawing.Size(260, 61)
        Me.refreshBtn.TabIndex = 13
        Me.refreshBtn.Text = "Refresh"
        '
        'Dashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1905, 975)
        Me.Controls.Add(Me.dashboardPnl)
        Me.Controls.Add(Me.parcelpointPnl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Dashboard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Dashboard"
        Me.parcelpointPnl.ResumeLayout(False)
        Me.Guna2Panel3.ResumeLayout(False)
        CType(Me.Guna2PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Guna2PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.dashboardPnl.ResumeLayout(False)
        Me.dashboardPnl.PerformLayout()
        Me.Guna2Panel5.ResumeLayout(False)
        Me.Guna2Panel5.PerformLayout()
        Me.NotificationPanel.ResumeLayout(False)
        CType(Me.ParcelLogsTbl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Guna2Panel6.ResumeLayout(False)
        Me.Guna2Panel6.PerformLayout()
        Me.Guna2Panel1.ResumeLayout(False)
        Me.Guna2Panel1.PerformLayout()
        Me.Guna2Panel2.ResumeLayout(False)
        Me.Guna2Panel2.PerformLayout()
        Me.Guna2Panel4.ResumeLayout(False)
        Me.Guna2Panel4.PerformLayout()
        Me.Guna2Panel7.ResumeLayout(False)
        Me.Guna2Panel7.PerformLayout()
        Me.Guna2Panel8.ResumeLayout(False)
        Me.Guna2Panel8.PerformLayout()
        Me.Guna2Panel9.ResumeLayout(False)
        Me.Guna2Panel9.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents parcelpointPnl As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents dashboardPnl As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Guna2Panel3 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Guna2PictureBox1 As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents Guna2PictureBox2 As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents dashboardBtn As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents utilitiesBtn As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents manageuserBtn As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents logoutBtn As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents NotificationPanel As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents ParcelLogsTbl As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Guna2Panel5 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents dailyCount As Label
    Friend WithEvents Guna2BorderlessForm1 As Guna.UI2.WinForms.Guna2BorderlessForm
    Friend WithEvents Label6 As Label
    Friend WithEvents NotifPanel As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents Guna2Panel6 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Guna2Panel8 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Guna2Panel9 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents anuallyCount As Label
    Friend WithEvents Guna2Panel4 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Guna2Panel7 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents monthlyCount As Label
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Guna2Panel2 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents weeklyCount As Label
    Friend WithEvents refreshBtn As Guna.UI2.WinForms.Guna2Button
End Class
