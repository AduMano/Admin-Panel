Public Class DemoPage

    Private Render As App

    ' Constructor accepting MainForm reference
    Public Sub New(app As App)
        InitializeComponent()
        Render = app
    End Sub

    Private Sub navBtn_Click(sender As Object, e As EventArgs) Handles navBtn.Click
        ' Render.View(New Page2())
    End Sub
End Class