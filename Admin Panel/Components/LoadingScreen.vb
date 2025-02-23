Public Class LoadingScreen
    Public Sub New(parentForm As Form)
        InitializeComponent()

        ' Set size and position to match the parent form
        Me.Size = parentForm.Size
        Me.Location = parentForm.Location

        ' Ensure it appears above the parent form
        Me.TopMost = True

        loadingIndicator.Location = New Point((Me.Width - loadingIndicator.Width) \ 2,
                                              (Me.Height - loadingIndicator.Height) \ 2)
    End Sub
End Class
