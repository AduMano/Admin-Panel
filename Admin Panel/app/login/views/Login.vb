Imports System.Text.RegularExpressions
Public Class Login

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles LoginBtn.Click
        Dim email As String = TxtboxEmail.Text.Trim() ' Email textbox
        Dim password As String = TxtboxPassword.Text.Trim() ' Password textbox
        Dim emailPattern As String = "^[a-zA-Z0-9._%+-]+@gmail\.com$"
        Dim passwordPattern As String = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,}$"
        Dim errorMsg As String = ""

        ' Email Validation
        If String.IsNullOrWhiteSpace(email) Then
            errorMsg &= "⦿ Email is required." & vbCrLf
        ElseIf Not Regex.IsMatch(email, emailPattern) Then
            errorMsg &= "⦿ Invalid email format. Please enter a valid email address." & vbCrLf
        End If

        ' Password Validation
        If String.IsNullOrWhiteSpace(password) Then
            errorMsg &= "⦿ Password is required." & vbCrLf
        ElseIf Not Regex.IsMatch(password, passwordPattern) Then
            errorMsg &= "⦿ Password must be at least **6 characters long** and include:
        - ✅ One uppercase letter
        - ✅ One lowercase letter
        - ✅ One number" & vbCrLf
        End If

        ' Show error message in a styled Guna2MessageDialog
        If errorMsg <> "" Then
            Dim msgDialog As New Guna.UI2.WinForms.Guna2MessageDialog With {
            .Parent = Me, ' Centers the message box
            .Style = Guna.UI2.WinForms.MessageDialogStyle.Light, ' Light mode (change to Dark if needed)
            .Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning, ' Warning icon
            .Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK, ' OK button
            .Caption = "Login Validation Failed",
            .Text = "Please fix the following errors:" & vbCrLf & vbCrLf & errorMsg
        }
            msgDialog.Show()
            Exit Sub
        End If

        ' If all validations pass, show success message and proceed
        Dim successDialog As New Guna.UI2.WinForms.Guna2MessageDialog With {
        .Parent = Me,
        .Style = Guna.UI2.WinForms.MessageDialogStyle.Light,
        .Icon = Guna.UI2.WinForms.MessageDialogIcon.Information,
        .Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK,
        .Caption = "Login Successful",
        .Text = "Welcome back! Redirecting to the dashboard..."
    }
        successDialog.Show()

        ' Hide the current login form
        Me.Hide()

        ' Open the main form (Replace 'Dashboard' with your actual main form name)
        Dim mainForm As New Dashboard()
        mainForm.Show()
    End Sub


    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim forgetPassForm As New Forgetpass()
        Me.Hide()
        forgetPassForm.Show()
    End Sub


    Private Sub TxtboxPassword_IconRightClick(sender As Object, e As EventArgs) Handles TxtboxPassword.IconRightClick
        If TxtboxPassword.UseSystemPasswordChar Then
            TxtboxPassword.UseSystemPasswordChar = False ' Show password
            TxtboxPassword.PasswordChar = ControlChars.NullChar ' Ensure password is visible
            TxtboxPassword.IconRight = My.Resources.EyeOn ' Change to "eye open" icon
        Else
            TxtboxPassword.UseSystemPasswordChar = True ' Hide password
            TxtboxPassword.PasswordChar = "*" ' Mask password
            TxtboxPassword.IconRight = My.Resources.Eye ' Change to "eye closed" icon
        End If
    End Sub

    Private Sub Login_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' Create a styled Guna2MessageDialog for exit confirmation
        Dim exitDialog As New Guna.UI2.WinForms.Guna2MessageDialog With {
        .Parent = Me, ' Ensures the dialog is centered on the form
        .Style = Guna.UI2.WinForms.MessageDialogStyle.Dark, ' Match validation style (Dark Theme)
        .Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning, ' Warning icon to match other dialogs
        .Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo, ' Yes and No buttons
        .Caption = "Exit Confirmation",
        .Text = "⚠ Are you sure you want to exit?"
    }

        ' Show dialog and check the response
        If exitDialog.Show() = DialogResult.No Then
            e.Cancel = True ' Cancel the closing event if the user selects "No"
        End If
    End Sub

    Private Sub TxtboxEmail_TextChanged(sender As Object, e As EventArgs) Handles TxtboxEmail.TextChanged

    End Sub

    Private Sub TxtboxPassword_TextChanged(sender As Object, e As EventArgs) Handles TxtboxPassword.TextChanged

    End Sub

    Private Sub Guna2Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel1.Paint

    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class