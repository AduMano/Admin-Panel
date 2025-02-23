Imports System.Web.UI.WebControls
Imports Guna.UI2.WinForms

Public Class verification
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

    End Sub

    Private Async Sub nextBtn_Click(sender As Object, e As EventArgs) Handles nextBtn.Click

        'Generate condition for validateCode
        Dim errorMsg As String = InputValidator.ValidateInput(codeTxtbox.Text.Trim(), "Verification Code", minLength:=6, maxLength:=6, validationType:="numbersonly")

        If Not String.IsNullOrEmpty(errorMsg) Then
            ShowDialog("Validation Error", errorMsg, MessageDialogIcon.Warning)
            Exit Sub
        End If

        OverlayHelper.ShowOverlay(ParentForm)

        Dim ifCodeExists As Boolean = Await AuthService.VerifyResetCode(userEmail, codeTxtbox.Text.Trim())

        If Not ifCodeExists Then
            OverlayHelper.HideOverlay()
            ShowDialog("Invalid Code", "The code you entered is invalid. Please make sure its correct.", MessageDialogIcon.Warning)
            Exit Sub
        Else
            OverlayHelper.HideOverlay()
            Me.Enabled = False ' Disable parent temporarily
            Dim ChangePassword As changepassword = New changepassword(userEmail, ParentForm)
            With ChangePassword
                .TopLevel = False
                Me.Hide()
                Me.Close()
                ParentForm.forgetPnl.Controls.Add(ChangePassword)
                .BringToFront()
                .Show()
            End With

        End If
    End Sub

    Private Sub ShowDialog(title As String, message As String, icon As MessageDialogIcon)
        Dim dialog As New Guna2MessageDialog With {
            .Parent = ParentForm,
            .Style = MessageDialogStyle.Dark,
            .Icon = icon,
            .Buttons = MessageDialogButtons.OK,
            .Caption = title,
            .Text = message
        }
        dialog.Show()
    End Sub

    Private Async Sub verification_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        messageDesc.Text = "Please check your email (" & userEmail & ") for the verification code."
        CenterLabel(messageDesc)
    End Sub

    Private Sub CenterLabel(lbl)
        ' Get the form width and label width
        Dim formWidth As Integer = Me.ClientSize.Width
        Dim labelWidth As Integer = lbl.Width

        ' Set the horizontal position (X) to center it
        lbl.Left = (formWidth - labelWidth) \ 2
    End Sub
End Class