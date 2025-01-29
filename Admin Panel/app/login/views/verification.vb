Imports Guna.UI2.WinForms

Public Class verification
    Friend WithEvents forgetPnl As Guna.UI2.WinForms.Guna2Panel

    Private Sub backBtn_Click(sender As Object, e As EventArgs) Handles backBtn.Click
        Me.Hide()

    End Sub

    Private Sub nextBtn_Click(sender As Object, e As EventArgs) Handles nextBtn.Click
        With changepassword
            .TopLevel = False
            Me.Controls.Add(changepassword)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub verification_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class