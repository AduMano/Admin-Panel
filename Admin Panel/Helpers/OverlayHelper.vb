Public Class OverlayHelper
    Private Shared overlay As LoadingScreen

    ''' <summary>
    ''' Shows the loading overlay on the specified form.
    ''' </summary>
    ''' <param name="parentForm">The form where the overlay should appear.</param>
    Public Shared Sub ShowOverlay(parentForm As Form)
        If overlay Is Nothing OrElse overlay.IsDisposed Then
            overlay = New LoadingScreen(parentForm)
        End If

        overlay.Size = parentForm.Size
        overlay.Location = parentForm.Location
        overlay.Show()
        overlay.BringToFront()
        Application.DoEvents() ' Allow UI updates
    End Sub

    ''' <summary>
    ''' Hides the loading overlay.
    ''' </summary>
    Public Shared Sub HideOverlay()
        If overlay IsNot Nothing AndAlso Not overlay.IsDisposed Then
            overlay.Close()
        End If
    End Sub
End Class
