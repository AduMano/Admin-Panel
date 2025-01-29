Public Class Dashboard


    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles logoutBtn.Click
        ' Create a styled Guna2MessageDialog for logout confirmation
        Dim logoutDialog As New Guna.UI2.WinForms.Guna2MessageDialog With {
        .Parent = Me, ' Centers the dialog on the form
        .Style = Guna.UI2.WinForms.MessageDialogStyle.Dark, ' Matches the dark theme used in other dialogs
        .Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning, ' Warning icon to maintain consistency
        .Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo, ' Yes and No buttons
        .Caption = "Confirm Logout",
        .Text = "⚠ Are you sure you want to log out?"
    }

        ' Show dialog and check the response
        If logoutDialog.Show() = DialogResult.Yes Then
            ' Show the login form again (Replace "Login" with the actual name of your login form)
            Dim loginForm As New Login()
            loginForm.Show()

            ' Close the current form (Main Form)
            Me.Close()
        End If
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles dashboardBtn.Click
        With ManageUsers
            .TopLevel = False
            dashboardPnl.Controls.Add(ManageUsers)
            .BringToFront()
            .Hide()
        End With

        With Utilities
            .TopLevel = False
            dashboardPnl.Controls.Add(Utilities)
            .BringToFront()
            .Hide()
        End With

    End Sub


    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles utilitiesBtn.Click
        With Utilities
            .TopLevel = False
            dashboardPnl.Controls.Add(Utilities)
            .BringToFront()
            .Show()
        End With




    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles manageuserBtn.Click
        With ManageUsers
            .TopLevel = False
            dashboardPnl.Controls.Add(ManageUsers)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub parcelpointPnl_Paint(sender As Object, e As PaintEventArgs) Handles parcelpointPnl.Paint

    End Sub

    Private Sub Guna2Panel2_Paint(sender As Object, e As PaintEventArgs) Handles dashboardPnl.Paint

    End Sub
End Class