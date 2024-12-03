<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DemoPage
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DemoPage))
        Me.container = New System.Windows.Forms.FlowLayoutPanel()
        Me.leftContainer = New System.Windows.Forms.Panel()
        Me.btnDemo = New System.Windows.Forms.Button()
        Me.description = New System.Windows.Forms.Label()
        Me.titlePhoto = New System.Windows.Forms.Label()
        Me.photoPicture = New System.Windows.Forms.PictureBox()
        Me.rightContainer = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tabPanel = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.addItemBtn = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.itemField = New System.Windows.Forms.TextBox()
        Me.listBox = New System.Windows.Forms.ListBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.navBtn = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.container.SuspendLayout()
        Me.leftContainer.SuspendLayout()
        CType(Me.photoPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rightContainer.SuspendLayout()
        Me.tabPanel.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'container
        '
        Me.container.Controls.Add(Me.leftContainer)
        Me.container.Controls.Add(Me.rightContainer)
        Me.container.Dock = System.Windows.Forms.DockStyle.Fill
        Me.container.Location = New System.Drawing.Point(0, 0)
        Me.container.Name = "container"
        Me.container.Size = New System.Drawing.Size(1105, 591)
        Me.container.TabIndex = 0
        '
        'leftContainer
        '
        Me.leftContainer.BackColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.leftContainer.Controls.Add(Me.btnDemo)
        Me.leftContainer.Controls.Add(Me.description)
        Me.leftContainer.Controls.Add(Me.titlePhoto)
        Me.leftContainer.Controls.Add(Me.photoPicture)
        Me.leftContainer.Location = New System.Drawing.Point(3, 3)
        Me.leftContainer.Name = "leftContainer"
        Me.leftContainer.Size = New System.Drawing.Size(351, 585)
        Me.leftContainer.TabIndex = 0
        '
        'btnDemo
        '
        Me.btnDemo.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.btnDemo.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDemo.Location = New System.Drawing.Point(86, 499)
        Me.btnDemo.Name = "btnDemo"
        Me.btnDemo.Size = New System.Drawing.Size(172, 57)
        Me.btnDemo.TabIndex = 3
        Me.btnDemo.Text = "CLICK ME FOR POP UP"
        Me.btnDemo.UseVisualStyleBackColor = False
        '
        'description
        '
        Me.description.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.description.ForeColor = System.Drawing.Color.White
        Me.description.Location = New System.Drawing.Point(33, 362)
        Me.description.Name = "description"
        Me.description.Size = New System.Drawing.Size(278, 139)
        Me.description.TabIndex = 2
        Me.description.Text = "Accordingly, all bees in the hive tirelessly work to ensure their colony thrives " &
    "and honey flows."
        Me.description.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'titlePhoto
        '
        Me.titlePhoto.AutoSize = True
        Me.titlePhoto.Font = New System.Drawing.Font("Arial Narrow", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.titlePhoto.ForeColor = System.Drawing.Color.White
        Me.titlePhoto.Location = New System.Drawing.Point(76, 332)
        Me.titlePhoto.Name = "titlePhoto"
        Me.titlePhoto.Size = New System.Drawing.Size(193, 33)
        Me.titlePhoto.TabIndex = 1
        Me.titlePhoto.Text = "THE BEE MOVIE"
        Me.titlePhoto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'photoPicture
        '
        Me.photoPicture.Image = CType(resources.GetObject("photoPicture.Image"), System.Drawing.Image)
        Me.photoPicture.Location = New System.Drawing.Point(33, 32)
        Me.photoPicture.Name = "photoPicture"
        Me.photoPicture.Size = New System.Drawing.Size(278, 265)
        Me.photoPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.photoPicture.TabIndex = 0
        Me.photoPicture.TabStop = False
        '
        'rightContainer
        '
        Me.rightContainer.Controls.Add(Me.Label2)
        Me.rightContainer.Controls.Add(Me.tabPanel)
        Me.rightContainer.Location = New System.Drawing.Point(357, 0)
        Me.rightContainer.Margin = New System.Windows.Forms.Padding(0)
        Me.rightContainer.Name = "rightContainer"
        Me.rightContainer.Size = New System.Drawing.Size(748, 591)
        Me.rightContainer.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(16, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(193, 33)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "THE BEE MOVIE"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tabPanel
        '
        Me.tabPanel.Controls.Add(Me.TabPage1)
        Me.tabPanel.Controls.Add(Me.TabPage2)
        Me.tabPanel.Location = New System.Drawing.Point(18, 80)
        Me.tabPanel.Name = "tabPanel"
        Me.tabPanel.SelectedIndex = 0
        Me.tabPanel.Size = New System.Drawing.Size(718, 487)
        Me.tabPanel.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.addItemBtn)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.itemField)
        Me.TabPage1.Controls.Add(Me.listBox)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(710, 458)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "PAGE 1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'addItemBtn
        '
        Me.addItemBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.addItemBtn.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.addItemBtn.Location = New System.Drawing.Point(535, 389)
        Me.addItemBtn.Name = "addItemBtn"
        Me.addItemBtn.Size = New System.Drawing.Size(154, 41)
        Me.addItemBtn.TabIndex = 4
        Me.addItemBtn.Text = "ADD ITEM"
        Me.addItemBtn.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(236, 324)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "ITEM NAME:"
        '
        'itemField
        '
        Me.itemField.Font = New System.Drawing.Font("Arial", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.itemField.Location = New System.Drawing.Point(239, 344)
        Me.itemField.Name = "itemField"
        Me.itemField.Size = New System.Drawing.Size(450, 39)
        Me.itemField.TabIndex = 1
        Me.itemField.Text = "ITEM"
        '
        'listBox
        '
        Me.listBox.FormattingEnabled = True
        Me.listBox.ItemHeight = 16
        Me.listBox.Items.AddRange(New Object() {"BAHALA", "NA", "ITO", "DI", "KO", "NA", "ALAM", "HAHAHA"})
        Me.listBox.Location = New System.Drawing.Point(27, 26)
        Me.listBox.Name = "listBox"
        Me.listBox.Size = New System.Drawing.Size(193, 404)
        Me.listBox.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.navBtn)
        Me.TabPage2.Controls.Add(Me.PictureBox2)
        Me.TabPage2.Controls.Add(Me.PictureBox1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(710, 458)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "PAGE 2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'navBtn
        '
        Me.navBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.navBtn.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.navBtn.Location = New System.Drawing.Point(464, 55)
        Me.navBtn.Name = "navBtn"
        Me.navBtn.Size = New System.Drawing.Size(154, 46)
        Me.navBtn.TabIndex = 6
        Me.navBtn.Text = "GO NEW PAGE"
        Me.navBtn.UseVisualStyleBackColor = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(402, 164)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(278, 265)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 5
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(34, 27)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(278, 265)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'DemoPage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1105, 591)
        Me.Controls.Add(Me.container)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "DemoPage"
        Me.Text = "DemoPage"
        Me.container.ResumeLayout(False)
        Me.leftContainer.ResumeLayout(False)
        Me.leftContainer.PerformLayout()
        CType(Me.photoPicture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rightContainer.ResumeLayout(False)
        Me.rightContainer.PerformLayout()
        Me.tabPanel.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents container As FlowLayoutPanel
    Friend WithEvents leftContainer As Panel
    Friend WithEvents titlePhoto As Label
    Friend WithEvents photoPicture As PictureBox
    Friend WithEvents description As Label
    Friend WithEvents rightContainer As Panel
    Friend WithEvents btnDemo As Button
    Friend WithEvents tabPanel As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents itemField As TextBox
    Friend WithEvents listBox As ListBox
    Friend WithEvents addItemBtn As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents navBtn As Button
End Class
