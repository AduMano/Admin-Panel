﻿Public Class DemoPage

    Private Render As App

    ' Constructor accepting MainForm reference
    Public Sub New(app As App)
        InitializeComponent()
        Render = app
        Dim age = 4
        Dim name = "Aldwin"
    End Sub

    Private Sub navBtn_Click(sender As Object, e As EventArgs) Handles navBtn.Click
        Render.View(New HelloWorld(Render))
    End Sub
End Class