<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HelloWorld
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.navBtn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'navBtn
        '
        Me.navBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.navBtn.Location = New System.Drawing.Point(251, 164)
        Me.navBtn.Name = "navBtn"
        Me.navBtn.Size = New System.Drawing.Size(262, 84)
        Me.navBtn.TabIndex = 0
        Me.navBtn.Text = "GO BACK"
        Me.navBtn.UseVisualStyleBackColor = True
        '
        'HelloWorld
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.navBtn)
        Me.Name = "HelloWorld"
        Me.Text = "HelloWorld"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents navBtn As Button
End Class
