Public Class SecondPage

    Private Render As App

    ' Constructor accepting MainForm reference
    Public Sub New(app As App)
        InitializeComponent()
        Render = app
    End Sub

    Private Sub backBtn_Click(sender As Object, e As EventArgs) Handles backBtn.Click
        Render.View(New DemoPage(Render))
    End Sub
End Class