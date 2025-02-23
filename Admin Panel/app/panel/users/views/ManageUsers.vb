Public Class ManageUsers
    Private Sub Guna2Button2_Click_1(sender As Object, e As EventArgs) Handles RegUserBtn.Click
        Register.Show()
    End Sub

    Private Sub registerBtn_Click(sender As Object, e As EventArgs) Handles AddAdminBtn.Click
        Adminregform.Show()
    End Sub

    Private Sub ManageUsers_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.AutoScaleMode = AutoScaleMode.None ' Prevents automatic scaling
    End Sub
End Class