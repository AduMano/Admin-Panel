Public Class Register

    Private Sub Guna2PictureBox1_Click(sender As Object, e As EventArgs) Handles Guna2PictureBox1.Click
        Me.Close()
    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles cancelBtn.Click
        Me.Close()
    End Sub

    Private Sub Guna2TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Guna2TabControl1.SelectedIndexChanged

    End Sub

    Private Sub Guna2Button3_Click_1(sender As Object, e As EventArgs) Handles backBtn.Click

        Guna2TabControl1.SelectedTab = TabPage1
    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub

    Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Click

    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles registerBtn.Click

    End Sub

    Private Sub TxtboxPass_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub nextBtn_Click(sender As Object, e As EventArgs) Handles nextBtn.Click

        Dim fname As String = fnameTxtbox.Text.Trim()
        Dim mname As String = mnameTxtbox.Text.Trim()
        Dim lname As String = lnameTxtbox.Text.Trim()
        Dim address As String = addressTxtbox.Text.Trim()
        Dim contact As String = contactTxtbox.Text.Trim()
        Dim email As String = emailTxtBox.Text.Trim()
        Dim gender As String = genderCombobox.Text.Trim()
        Dim birthday As Date = Birthdaytimepicker.Value ' Get DateTime value

        Dim errorMsg As String = ""

        ' Collect validation errors
        If String.IsNullOrWhiteSpace(fname) Then
            errorMsg &= "⦿ First Name is required." & vbCrLf
        End If

        If String.IsNullOrWhiteSpace(mname) Then
            errorMsg &= "⦿ Middle Name is required." & vbCrLf
        End If

        If String.IsNullOrWhiteSpace(lname) Then
            errorMsg &= "⦿ Last Name is required." & vbCrLf
        End If

        If String.IsNullOrWhiteSpace(address) Then
            errorMsg &= "⦿ Address is required." & vbCrLf
        End If

        If String.IsNullOrWhiteSpace(contact) Then
            errorMsg &= "⦿ Contact Number is required." & vbCrLf
        ElseIf Not System.Text.RegularExpressions.Regex.IsMatch(contact, "^\d{10,}$") Then
            errorMsg &= "⦿ Contact Number must contain only numbers and be at least 10 digits." & vbCrLf
        End If

        If String.IsNullOrWhiteSpace(email) Then
            errorMsg &= "⦿ Email Address is required." & vbCrLf
        ElseIf Not System.Text.RegularExpressions.Regex.IsMatch(email, "^[^@\s]+@[^@\s]+\.[^@\s]+$") Then
            errorMsg &= "⦿ Please enter a valid email address." & vbCrLf
        End If

        ' Gender Validation (Ensure a selection is made)
        If genderCombobox.SelectedIndex = -1 Then
            errorMsg &= "⦿ Please select a gender." & vbCrLf
        End If

        ' Birthday Validation (Ensure it's not a future date)
        If birthday > Date.Today Then
            errorMsg &= "⦿ Birthday cannot be a future date." & vbCrLf
        End If

        ' Show all errors at once if there are any
        If errorMsg <> "" Then
            Dim msgDialog As New Guna.UI2.WinForms.Guna2MessageDialog With {
            .Parent = Me, ' Ensures it is centered on the form
            .Style = Guna.UI2.WinForms.MessageDialogStyle.Light, ' Use Light or Dark
            .Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning,
            .Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK,
            .Caption = "Validation Failed",
            .Text = "Please fix the following errors:" & vbCrLf & vbCrLf & errorMsg
        }

            msgDialog.Show()
            Exit Sub
        End If

        ' If everything is valid, proceed to the next tab
        changepassword.Visible = True ' Make the change password panel visible
        verification.Visible = False ' Optionally hide the current panel if necessary


    End Sub

    Private Sub Guna2Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel1.Paint

    End Sub

    Private Sub Guna2DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles Birthdaytimepicker.ValueChanged

    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub TxtboxPassword_TextChanged(sender As Object, e As EventArgs) Handles TxtboxPassword.TextChanged

    End Sub

    Private Sub contactTxtbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles contactTxtbox.KeyPress
        ' Allow control characters (like backspace) and digits only
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True ' Prevent the character from being entered
        End If
    End Sub

    Private Sub emailTxtBox_TextChanged(sender As Object, e As EventArgs) Handles emailTxtBox.TextChanged

    End Sub
End Class