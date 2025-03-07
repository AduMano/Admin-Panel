Public Class Register
    Private _selectedImage As Image = Nothing
    Private BioID As Int16


    Public Class StateDTO
        Public Property Id As Int16
        Public Property CurrentState As String
        Public Property BiometricsId As Int16?
        Public Property LastUpdate As DateTime
    End Class

    Private Sub Guna2PictureBox1_Click(sender As Object, e As EventArgs) Handles Guna2PictureBox1.Click
        Me.Close()
    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles cancelBtn.Click
        Me.Close()
    End Sub

    Private Sub Guna2Button3_Click_1(sender As Object, e As EventArgs) Handles backBtn.Click

        Guna2TabControl1.SelectedTab = TabPage1
    End Sub

    Private Async Sub nextBtn_Click(sender As Object, e As EventArgs) Handles nextBtn.Click
        OverlayHelper.ShowOverlay(Me)

        ' Gather form data
        Dim fname As String = fnameTxtbox.Text.Trim()
        Dim mname As String = mnameTxtbox.Text.Trim()
        Dim lname As String = lnameTxtbox.Text.Trim()
        Dim address As String = addressTxtbox.Text.Trim()
        Dim contact As String = contactTxtbox.Text.Trim()
        Dim email As String = emailTxtBox.Text.Trim()
        Dim gender As String = genderCombobox.Text.Trim()
        Dim birthday As Date = Birthdaytimepicker.Value

        ' If you store the photo in a PictureBox, do this:
        Dim photo As Image = PictureBox.Image

        ' Alternatively, if you use a class-level variable like `_selectedImage`:
        ' Dim photo As Image = _selectedImage

        ' Collect validation errors in a list
        Dim errors As New List(Of String)

        ' 1. Name fields
        If String.IsNullOrWhiteSpace(fname) Then errors.Add("⦿ First Name is required.")
        If String.IsNullOrWhiteSpace(mname) Then errors.Add("⦿ Middle Name is required.")
        If String.IsNullOrWhiteSpace(lname) Then errors.Add("⦿ Last Name is required.")

        ' 2. Address
        If String.IsNullOrWhiteSpace(address) Then errors.Add("⦿ Address is required.")

        ' 3. Contact
        If String.IsNullOrWhiteSpace(contact) Then
            errors.Add("⦿ Contact Number is required.")
        ElseIf Not System.Text.RegularExpressions.Regex.IsMatch(contact, "^09\d{9}$") Then
            errors.Add("⦿ Contact Number should be 11 Digits and must start with '09'")
        End If

        ' 4. Email
        If String.IsNullOrWhiteSpace(email) Then
            errors.Add("⦿ Email Address is required.")
        ElseIf Not System.Text.RegularExpressions.Regex.IsMatch(email, "^[^@\s]+@[^@\s]+\.[^@\s]+$") Then
            errors.Add("⦿ Please enter a valid email address.")
        ElseIf Await ManageUsersService.CheckEmailIfExisting(email, " ") Then
            errors.Add("⦿ The Email is already in use.")
        End If

        ' 5. Gender
        If genderCombobox.SelectedIndex = -1 Then
            errors.Add("⦿ Please select a gender.")
        End If

        ' 6. Birthday
        If birthday > Date.Today Then
            errors.Add("⦿ Birthday cannot be a future date.")
        End If

        ' 7. Photo
        If photo Is Nothing Then
            errors.Add("⦿ Please select a photo.")
        End If

        ' Check if any errors were collected
        If errors.Any() Then
            OverlayHelper.HideOverlay()

            ' Build your full error message
            Dim fullMessage As String = "Please fix the following errors:" & vbCrLf & vbCrLf &
                                String.Join(vbCrLf, errors)

            ' Display with Guna2MessageDialog
            Dim msgDialog As New Guna.UI2.WinForms.Guna2MessageDialog With {
                .Parent = Me,
                .Style = Guna.UI2.WinForms.MessageDialogStyle.Light,
                .Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning,
                .Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK,
                .Caption = "Validation Failed",
                .Text = fullMessage
            }
            msgDialog.Show()

            Exit Sub
        End If

        ' If we reach here, no errors - proceed
        OverlayHelper.HideOverlay()
        Guna2TabControl1.SelectedTab = TabPage2
        ' e.g., switch panel or do next steps:
        ' changepassword.Visible = True
        ' verification.Visible = False

    End Sub

    Private Sub contactTxtbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles contactTxtbox.KeyPress
        ' Allow control characters (like backspace) and digits only
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True ' Prevent the character from being entered
        End If
    End Sub

    Private Sub emailTxtBox_TextChanged(sender As Object, e As EventArgs) Handles emailTxtBox.TextChanged

    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        ' 1) Create the OpenFileDialog
        Using ofd As New OpenFileDialog()
            ' 2) Filter for image types
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All Files|*.*"
            ofd.FilterIndex = 1
            ofd.Title = "Select an Image to Upload"

            ' 3) Show the dialog
            If ofd.ShowDialog() = DialogResult.OK Then
                Try
                    ' 4) You now have a file path to the image
                    Dim filePath As String = ofd.FileName
                    _selectedImage = Image.FromFile(filePath)

                    ' 2) Display the image in our PictureBox for preview
                    PictureBox.SizeMode = PictureBoxSizeMode.Zoom
                    PictureBox.Image = _selectedImage

                    ' 5) Optionally, show a loading overlay or progress indicator

                    ' 6) Call your upload function
                    ' Await UploadImageToSupabaseAsync(filePath)

                    MessageBox.Show("Upload successful!", "Info",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show($"Error uploading image: {ex.Message}", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub

    Private Sub scanBtn_Click(sender As Object, e As EventArgs) Handles scanBtn.Click
        Timer1.Start()
        OverlayHelper.ShowOverlay(Me)

    End Sub

    Private Sub Register_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Timer1.Interval = 1000
    End Sub

    Private Async Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        ' This event fires every time the Timer 'ticks' (i.e. every Interval)
        Dim result = Await ManageUsersService.GetSystemStateAsync()

        If Not result.BiometricsId.HasValue OrElse result.BiometricsId.Value = 0 Then
            Debug.Print("Condition not met. Polling continues...")
        Else
            BioID = result.BiometricsId.Value
            OverlayHelper.HideOverlay()
            scanBtn.Enabled = False
            Timer1.Stop()
        End If
    End Sub
End Class