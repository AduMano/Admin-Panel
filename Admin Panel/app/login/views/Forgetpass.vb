Imports System.Text.RegularExpressions
Imports Guna.UI2.WinForms

Public Class Forgetpass

    Private Async Sub nextBtn_Click(sender As Object, e As EventArgs) Handles nextBtn.Click
        Dim emailPattern As String = "^[a-zA-Z0-9._%+-]+@gmail\.com$"

        ' Check if the email field is empty
        If String.IsNullOrEmpty(TxtboxEmail.Text) Then
            ShowDialog("Validation Error", "Please enter your email address.", MessageDialogIcon.Warning)
        ElseIf Not Regex.IsMatch(TxtboxEmail.Text, emailPattern) Then
            ' If email format is invalid, show error
            ShowDialog("Validation Error", "Invalid email format. Please enter a valid email address.", MessageDialogIcon.Warning)
        Else
            ' Create a new instance of the verification form
            OverlayHelper.ShowOverlay(Me)

            ' Check Email if existing
            Dim emailExists As Boolean = Await AuthService.VerifyEmailExists(TxtboxEmail.Text, "admin")
            If Not emailExists Then
                OverlayHelper.HideOverlay()
                ShowDialog("Invalid E-mail", "Invalid email. Please enter a valid email address.", MessageDialogIcon.Warning)
                Exit Sub
            Else
                ' Send Verificaiton Code
                Dim verificationCode As String = Await AuthService.RequestVerificationCode(TxtboxEmail.Text.Trim())

                If Not String.IsNullOrEmpty(verificationCode) Then
                    OverlayHelper.HideOverlay()
                End If

                ' If email is valid, show success message and open the next form
                Dim successDialog As New Guna2MessageDialog With {
                    .Parent = Me,
                    .Style = MessageDialogStyle.Dark,
                    .Icon = MessageDialogIcon.Information,
                    .Buttons = MessageDialogButtons.OK,
                    .Caption = "E-mail valid!",
                    .Text = "Click ok to proceed"
                }

                ' Show dialog and proceed to the next form after user clicks OK
                If successDialog.Show() = DialogResult.OK Then
                    Dim verificationForm As New verification(TxtboxEmail.Text, Me)

                    With verificationForm
                        .TopLevel = False  ' Ensure it's not a top-level form
                        forgetPnl.Controls.Add(verificationForm)  ' Add the form to the panel (forgetPnl)
                        .BringToFront()  ' Ensure it appears in front of the other controls inside the panel
                        .Show()
                    End With
                End If
            End If
        End If
    End Sub

    ' Function to show Guna2MessageDialog
    Private Sub ShowDialog(title As String, message As String, icon As MessageDialogIcon)
        Dim dialog As New Guna2MessageDialog With {
            .Parent = Me,
            .Style = MessageDialogStyle.Dark,
            .Icon = icon,
            .Buttons = MessageDialogButtons.OK,
            .Caption = title,
            .Text = message
        }
        dialog.Show()
    End Sub



    Private Sub backBtn_Click(sender As Object, e As EventArgs) Handles backBtn.Click
        Dim loginForm As New Login()
        Me.Close()
        loginForm.Show()
    End Sub

    Private Sub Guna2PictureBox3_Click(sender As Object, e As EventArgs) Handles Guna2PictureBox3.Click
        Login.Show()
        Me.Close()
    End Sub
End Class