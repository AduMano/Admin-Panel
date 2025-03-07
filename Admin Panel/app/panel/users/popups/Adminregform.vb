Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Admin_Panel.ManageUsersService
Imports Org.BouncyCastle.Asn1.Ocsp

Public Class Adminregform
    Private ADMIN_ID As String = "01B02728-7D4F-4263-AA83-85512CCF929D"
    Private USER_ID As String = "6F889697-611E-4611-9121-DA9F73444CD8"
    Private FORM_TYPE As String
    Private FORM_DATA As RegisterUserDto
    Private PARENT As ManageUsers
    Private FORM_READONLY As Boolean

    Public Sub New(form As ManageUsers, type As String, Optional formReadOnly As Boolean = False, Optional data As RegisterUserDto = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        FORM_TYPE = type
        FORM_DATA = data
        FORM_READONLY = formReadOnly
        PARENT = form
    End Sub

    Private Sub Guna2PictureBox2_Click(sender As Object, e As EventArgs) Handles Guna2PictureBox2.Click
        Me.Close()
    End Sub

    Private Async Function addBtn_ClickAsync(sender As Object, e As EventArgs) As Task Handles addBtn.Click

        If FORM_TYPE.Contains("VIEW") Then
            Me.Close()
            Exit Function
        End If

        OverlayHelper.ShowOverlay(Me)

        ' Gather form data – ensure you are using the correct textboxes!
        Dim fname As String = fnametxtbox.Text.Trim()           ' was: contacttxtbox.Text.Trim()
        Dim mname As String = mnametxtbox.Text.Trim()
        Dim lname As String = lnametxtbox.Text.Trim()            ' was: emailtxtbox.Text.Trim()
        Dim address As String = addressTxtbox.Text.Trim()
        Dim contact As String = contacttxtbox.Text.Trim()
        Dim email As String = emailtxtbox.Text.Trim()
        Dim gender As String = genderCombobox.SelectedValue.ToString().Trim()
        Dim birthday As Date = Birthdaytimepicker.Value
        Dim password As String = passwordTxtbox.Text.Trim()
        Dim username As String = UsernameTxtbox.Text.Trim()

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
            errors.Add("⦿ Contact Number should be 11 digits and must start with '09'.")
        End If

        ' 4. Email
        If String.IsNullOrWhiteSpace(email) Then
            errors.Add("⦿ Email Address is required.")
        ElseIf Not System.Text.RegularExpressions.Regex.IsMatch(email, "^[^@\s]+@[^@\s]+\.[^@\s]+$") Then
            errors.Add("⦿ Please enter a valid email address.")
        ElseIf Await ManageUsersService.CheckEmailIfExisting(email, If(FORM_DATA Is Nothing, " ", FORM_DATA.Email)) Then
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

        ' 7. Username
        If String.IsNullOrWhiteSpace(username) Then
            errors.Add("⦿ Username is required.")
        ElseIf Await ManageUsersService.CheckUsernameIfExisting(username, If(FORM_DATA Is Nothing, " ", FORM_DATA.Username)) Then
            errors.Add("⦿ The Username is already in use.")
        End If

        If FORM_TYPE.Contains("ADD") Then
            ' 8. Password
            If password.Length < 8 Then
                errors.Add("⦿ Password must be at least 8 characters.")
            End If
        End If

        ' Check if any errors were collected
        If errors.Any() Then
            OverlayHelper.HideOverlay()

            Dim fullMessage As String = "Please fix the following errors:" & vbCrLf & vbCrLf & String.Join(vbCrLf, errors)

            Dim msgDialog As New Guna.UI2.WinForms.Guna2MessageDialog With {
            .Parent = Me,
            .Style = Guna.UI2.WinForms.MessageDialogStyle.Light,
            .Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning,
            .Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK,
            .Caption = "Validation Failed",
            .Text = fullMessage
        }
            msgDialog.Show()
            Exit Function
        End If

        ' Proceed to create a new user if validations pass.
        If FORM_TYPE.Contains("ADD") Then

            Dim newUser As New RegisterUserDto With {
                .FirstName = fname,
                .MiddleName = mname,
                .LastName = lname,
                .Address = address,
                .ContactNumber = contact,
                .Email = email,
                .BirthDate = birthday,
                .Gender = gender,
                .Username = username,
                .Password = password,
                .Role = ADMIN_ID,   ' ADMIN_ID should be a string representing the role ID
                .Suffix = suffixtxtbox.Text.Trim(),
                .OperatorID = PARENT.parent.userID,
                .UserType = "Admin",
                .PhotoUrl = ""
            }

            Dim isAdded As String = Await ManageUsersService.AddNewUserAsync(newUser)

            OverlayHelper.HideOverlay() ' Hide overlay after API call

            If isAdded IsNot "Failed" Then
                Dim msgDialog As New Guna.UI2.WinForms.Guna2MessageDialog With {
                .Parent = Me,
                .Style = Guna.UI2.WinForms.MessageDialogStyle.Light,
                .Icon = Guna.UI2.WinForms.MessageDialogIcon.Information,
                .Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK,
                .Caption = "Success",
                .Text = "Successfully Added new Admin!"
            }
                msgDialog.Show()
                Me.Close()
                PARENT.Reload_Data()
                Exit Function
            Else
                Dim msgDialog As New Guna.UI2.WinForms.Guna2MessageDialog With {
                .Parent = Me,
                .Style = Guna.UI2.WinForms.MessageDialogStyle.Light,
                .Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning,
                .Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK,
                .Caption = "Failed",
                .Text = "Creation Failed! Something went wrong."
            }
                msgDialog.Show()
            End If
        ElseIf FORM_TYPE.Contains("UPDATE") Then
            Dim updateUser As New RegisterUserDto With {
                .UserId = FORM_DATA.UserId,
                .FirstName = fname,
                .MiddleName = mname,
                .LastName = lname,
                .Address = address,
                .ContactNumber = contact,
                .Email = email,
                .BirthDate = birthday,
                .Gender = gender,
                .Username = username,
                .Password = "",
                .Role = If(FORM_TYPE.Contains("ADMIN"), ADMIN_ID, USER_ID),   ' ADMIN_ID should be a string representing the role ID
                .Suffix = suffixtxtbox.Text.Trim(),
                .OperatorID = PARENT.parent.userID,
                .UserType = If(FORM_TYPE.Contains("ADMIN"), "Admin", "User"),
                .PhotoUrl = ""
            }

            Dim isUpdated As Boolean = Await ManageUsersService.UpdateUserAsync(updateUser)

            OverlayHelper.HideOverlay() ' Hide overlay after API call

            If isUpdated Then
                Dim msgDialog As New Guna.UI2.WinForms.Guna2MessageDialog With {
                .Parent = Me,
                .Style = Guna.UI2.WinForms.MessageDialogStyle.Light,
                .Icon = Guna.UI2.WinForms.MessageDialogIcon.Information,
                .Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK,
                .Caption = "Success",
                .Text = "Successfully Updated!"
            }
                msgDialog.Show()
                Me.Close()
                PARENT.Reload_Data()
                Exit Function
            Else
                Dim msgDialog As New Guna.UI2.WinForms.Guna2MessageDialog With {
                .Parent = Me,
                .Style = Guna.UI2.WinForms.MessageDialogStyle.Light,
                .Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning,
                .Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK,
                .Caption = "Failed",
                .Text = "Creation Failed! Something went wrong."
            }
                msgDialog.Show()
            End If
        End If
    End Function


    Private Sub Adminregform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        OverlayHelper.ShowOverlay(Me)

        Dim items As New List(Of ComboBoxItem)
        items.Add(New ComboBoxItem("Male", "4141E9AD-2EB9-4626-B65F-D5464E8830D0"))
        items.Add(New ComboBoxItem("Female", "4A3C010E-432D-4BC8-8F26-3D6AB9679190"))

        genderCombobox.DataSource = items
        genderCombobox.DisplayMember = "Text"    ' What the user sees
        genderCombobox.ValueMember = "Value"      ' The underlying value

        If FORM_READONLY Then
            ' Make All Inputs disabled  
            fnametxtbox.ReadOnly = True
            mnametxtbox.ReadOnly = True
            lnametxtbox.ReadOnly = True
            addressTxtbox.ReadOnly = True
            contacttxtbox.ReadOnly = True
            emailtxtbox.ReadOnly = True
            passwordTxtbox.ReadOnly = True
            UsernameTxtbox.ReadOnly = True
            suffixtxtbox.ReadOnly = True

            fnametxtbox.Enabled = False
            mnametxtbox.Enabled = False
            lnametxtbox.Enabled = False
            addressTxtbox.Enabled = False
            contacttxtbox.Enabled = False
            emailtxtbox.Enabled = False
            passwordTxtbox.Enabled = False
            UsernameTxtbox.Enabled = False
            genderCombobox.Enabled = False
            Birthdaytimepicker.Enabled = False
            suffixtxtbox.Enabled = False
        End If

        If FORM_DATA IsNot Nothing Then
            fnametxtbox.Text = FORM_DATA.FirstName
            mnametxtbox.Text = FORM_DATA.MiddleName
            lnametxtbox.Text = FORM_DATA.LastName
            addressTxtbox.Text = FORM_DATA.Address
            contacttxtbox.Text = FORM_DATA.ContactNumber
            emailtxtbox.Text = FORM_DATA.Email
            UsernameTxtbox.Text = FORM_DATA.Username
            suffixtxtbox.Text = FORM_DATA.Suffix
            Birthdaytimepicker.Value = FORM_DATA.BirthDate
            genderCombobox.SelectedText = FORM_DATA.Gender
        End If

        If FORM_TYPE.Contains("VIEW") Then
            passwordTxtbox.Visible = False
            Label14.Visible = False
            cancelBtn.Visible = False
            addBtn.Text = "Close"
        End If

        If FORM_TYPE.Contains("UPDATE") Then
            passwordTxtbox.Visible = False
            Label14.Visible = False
            addBtn.Text = "Update"
        End If

        OverlayHelper.HideOverlay()

    End Sub

    Private Sub cancelBtn_Click(sender As Object, e As EventArgs) Handles cancelBtn.Click
        Me.Close()
    End Sub
End Class

Public Class ComboBoxItem
    Public Property Text As String
    Public Property Value As String

    Public Sub New(text As String, value As String)
        Me.Text = text
        Me.Value = value
    End Sub
End Class