Imports Guna.UI2.WinForms

Public Class changepassword
    Friend WithEvents forgetPnl As Guna.UI2.WinForms.Guna2Panel
    Private userEmail As String
    Private ParentForm As Forgetpass

    ' Constructor to receive the email
    Public Sub New(email As String, form As Forgetpass)
        InitializeComponent()
        userEmail = email
        ParentForm = form
    End Sub

    Private Sub backBtn_Click(sender As Object, e As EventArgs) Handles backBtn.Click
        Me.Hide()

        Dim verificationForm As New verification(userEmail, ParentForm)

        With verificationForm
            .TopLevel = False  ' Ensure it's not a top-level form
            ParentForm.forgetPnl.Controls.Add(verificationForm)  ' Add the form to the panel (forgetPnl)
            .BringToFront()  ' Ensure it appears in front of the other controls inside the panel
            .Show()
        End With
    End Sub

    Private Async Sub nextBtn_Click(sender As Object, e As EventArgs) Handles nextBtn.Click
        ' Check if Current and Confirm is 8 Characters
        Dim newPassValidator As String = InputValidator.ValidateInput(currentpwTxtbox.Text, "New Password", minLength:=8)
        If Not String.IsNullOrEmpty(newPassValidator) Then
            ShowDialog("Validation Error", newPassValidator, MessageDialogIcon.Warning)
            Exit Sub
        End If

        Dim confirmPassValidator As String = InputValidator.ValidateInput(currentpwTxtbox2.Text, "Confirm Password", minLength:=8)
        If Not String.IsNullOrEmpty(confirmPassValidator) Then
            ShowDialog("Validation Error", confirmPassValidator, MessageDialogIcon.Warning)
            Exit Sub
        End If

        ' Check if they aren't equal or the same
        If currentpwTxtbox.Text <> currentpwTxtbox2.Text Then
            ShowDialog("Validation Error", "Passwords do not match. Please try again.", MessageDialogIcon.Warning)
            Exit Sub
        End If

        ' Completed
        OverlayHelper.ShowOverlay(ParentForm)
        Dim isUpdated As Boolean = Await AuthService.UpdatePasswordAsync(userEmail, currentpwTxtbox.Text.Trim())

        If isUpdated Then
            OverlayHelper.HideOverlay()
            ShowDialog("Success", "Your password has been updated successfully!", MessageDialogIcon.Information)

            Me.Close()
            ParentForm.Close()
            Dim loginForm As New Login()
            loginForm.Show()
        Else

            OverlayHelper.HideOverlay()
            ShowDialog("Error", "Failed to update password. Please try again.", MessageDialogIcon.Error)
        End If
    End Sub
    Private Sub ShowDialog(title As String, message As String, icon As MessageDialogIcon)
        Dim msgDialog As New Guna.UI2.WinForms.Guna2MessageDialog With {
            .Parent = ParentForm,
            .Style = Guna.UI2.WinForms.MessageDialogStyle.Dark,
            .Icon = icon,
            .Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK,
            .Caption = title,
            .Text = message
        }

        ' Show the dialog
        msgDialog.Show()
    End Sub
End Class