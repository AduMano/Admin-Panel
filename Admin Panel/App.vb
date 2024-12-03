Public Class App

#Region "DONT TOUCH!"
    Public Sub View(form As Form)
        LoadFormInPanel(form)
    End Sub

    Private Sub LoadFormInPanel(form As Form)

        ' Clear any existing controls in the panel
        canvas.Controls.Clear()

        ' Set the form's properties to make it dock inside the panel
        form.TopLevel = False
        form.FormBorderStyle = FormBorderStyle.None

        ' Adjust the size of the MainForm to match the size of the new form
        Me.Size = New Size(form.Width + (Me.Width - canvas.Width),
                           form.Height + (Me.Height - canvas.Height))
        ' Adjust the size of the Panel to match the size of the new form
        canvas.Size = New Size(form.Width + (Me.Width - canvas.Width),
                           form.Height + (Me.Height - canvas.Height))

        ' Add the form to the panel and display it
        canvas.Controls.Add(form)
        form.Show()
    End Sub
#End Region

#Region "WORK HERE"
    Private Sub App_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' LoadFormInPanel(New LoginPage(Me))
        View(New DemoPage(Me))
    End Sub
#End Region
End Class