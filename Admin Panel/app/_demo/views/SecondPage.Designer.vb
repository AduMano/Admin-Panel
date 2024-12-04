<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SecondPage
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
        Me.backBtn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'backBtn
        '
        Me.backBtn.Font = New System.Drawing.Font("Arial Narrow", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.backBtn.Location = New System.Drawing.Point(269, 164)
        Me.backBtn.Name = "backBtn"
        Me.backBtn.Size = New System.Drawing.Size(258, 96)
        Me.backBtn.TabIndex = 0
        Me.backBtn.Text = "GO BACK"
        Me.backBtn.UseVisualStyleBackColor = True
        '
        'SecondPage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.backBtn)
        Me.Name = "SecondPage"
        Me.Text = "SecondPage"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents backBtn As Button
End Class
