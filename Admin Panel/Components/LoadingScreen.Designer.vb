<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LoadingScreen
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
        Me.loadingIndicator = New Guna.UI2.WinForms.Guna2ProgressIndicator()
        Me.SuspendLayout()
        '
        'loadingIndicator
        '
        Me.loadingIndicator.AutoStart = True
        Me.loadingIndicator.BackColor = System.Drawing.Color.Transparent
        Me.loadingIndicator.Location = New System.Drawing.Point(485, 199)
        Me.loadingIndicator.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.loadingIndicator.Name = "loadingIndicator"
        Me.loadingIndicator.ProgressColor = System.Drawing.Color.Gold
        Me.loadingIndicator.Size = New System.Drawing.Size(120, 111)
        Me.loadingIndicator.TabIndex = 1
        Me.loadingIndicator.UseTransparentBackground = True
        '
        'LoadingScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1067, 554)
        Me.Controls.Add(Me.loadingIndicator)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "LoadingScreen"
        Me.Opacity = 0.5R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LoadingScreen"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents loadingIndicator As Guna.UI2.WinForms.Guna2ProgressIndicator
End Class
