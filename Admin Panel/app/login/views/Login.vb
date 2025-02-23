Imports System.Net
Imports System.Net.Http
Imports System.Text
Imports System.Text.RegularExpressions
Imports Newtonsoft.Json

Public Class Login

    ' Define a class to hold the login response
    Public Class LoginResponse
        Public Property userId As String
        Public Property username As String
    End Class

    Private Async Function LoginUser(apiUrl As String, username As String, password As String) As Task(Of String)
        Try
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            ServicePointManager.ServerCertificateValidationCallback = Function(sender, certificate, chain, sslPolicyErrors) True

            Dim loginUrl As String = apiUrl & "/Auth/login"

            ' Create HttpClient
            Using client As New HttpClient()
                client.DefaultRequestHeaders.Accept.Clear()
                client.DefaultRequestHeaders.Add("accept", "*/*") ' Matches cURL header

                ' Debugging: Print API URL
                Debug.WriteLine("Login URL: " & loginUrl)

                ' Ensure Content-Type is application/json
                Dim requestData As String = "{""username"":""" & username & """, ""password"":""" & password & """, ""type"":""admin""}"

                ' Debugging: Print the JSON payload
                Debug.WriteLine("Request JSON: " & requestData)

                ' Prepare content with JSON and UTF-8 encoding
                Dim content As New StringContent(requestData, Encoding.UTF8, "application/json")

                ' Send POST request
                Dim response As HttpResponseMessage = Await client.PostAsync(loginUrl, content)

                ' Read response content
                Dim responseString As String = Await response.Content.ReadAsStringAsync()

                ' Debugging: Print API response
                Debug.WriteLine("Response Status Code: " & response.StatusCode.ToString())
                Debug.WriteLine("Response Content: " & responseString)

                ' Check if login was successful (HTTP 200 OK)
                If response.IsSuccessStatusCode Then
                    ' Deserialize response JSON
                    Dim loginData As LoginResponse = JsonConvert.DeserializeObject(Of LoginResponse)(responseString)
                    If loginData IsNot Nothing Then
                        Return responseString ' Return success response
                    Else
                        Return "Invalid response format."
                    End If
                Else
                    ' Return API error message instead of showing pop-up
                    Return responseString
                End If
            End Using

        Catch ex As Exception
            ' Return error message instead of showing pop-up
            Debug.WriteLine(ex.Message)
            Return "An error occurred: " & ex.Message
        End Try
    End Function


    Private Async Sub LoginBtn_Click(sender As Object, e As EventArgs) Handles LoginBtn.Click
        Dim username As String = TxtboxEmail.Text.Trim()
        Dim password As String = TxtboxPassword.Text.Trim()
        Dim passwordPattern As String = "^.{8,}$"
        Dim errorMsg As String = ""

        ' Create and show overlay on top of Login form
        OverlayHelper.ShowOverlay(Me)

        ' 🟢 Step 1: Validation Checks (Single Dialog)
        If String.IsNullOrWhiteSpace(username) Then
            errorMsg &= "⦿ Username is required." & vbCrLf
        End If
        If String.IsNullOrWhiteSpace(password) Then
            errorMsg &= "⦿ Password is required." & vbCrLf
        ElseIf Not Regex.IsMatch(password, passwordPattern) Then
            errorMsg &= "⦿ Password must be at least **8 characters long**" & vbCrLf
        End If

        ' If validation fails, show a single pop-up and exit
        If errorMsg <> "" Then
            OverlayHelper.HideOverlay()
            Dim msgDialog As New Guna.UI2.WinForms.Guna2MessageDialog With {
            .Parent = Me,
            .Style = Guna.UI2.WinForms.MessageDialogStyle.Light,
            .Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning,
            .Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK,
            .Caption = "Login Validation Failed",
            .Text = "Please fix the following errors:" & vbCrLf & vbCrLf & errorMsg
        }
            msgDialog.Show()
            Exit Sub
        End If

        ' 🟢 Step 2: Fetch API URL from Supabase
        Dim apiUrl As String = Await ApiHelper.GetLatestApiUrl()
        If String.IsNullOrEmpty(apiUrl) Then
            OverlayHelper.HideOverlay()
            Dim apiErrorDialog As New Guna.UI2.WinForms.Guna2MessageDialog With {
            .Parent = Me,
            .Style = Guna.UI2.WinForms.MessageDialogStyle.Dark,
            .Icon = Guna.UI2.WinForms.MessageDialogIcon.Error,
            .Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK,
            .Caption = "API Error",
            .Text = "Failed to retrieve API URL! Please try again later."
        }
            apiErrorDialog.Show()
            Exit Sub
        End If

        ' 🟢 Step 3: Call login function
        Dim loginResponse As String = Await LoginUser(apiUrl, username, password)

        ' Close overlay before showing any pop-up
        OverlayHelper.HideOverlay()

        ' 🟢 Step 4: Handle API Response
        If loginResponse.StartsWith("{") Then
            ' If the response starts with `{`, assume it's a successful login JSON
            Dim loginData As LoginResponse = JsonConvert.DeserializeObject(Of LoginResponse)(loginResponse)

            Dim successDialog As New Guna.UI2.WinForms.Guna2MessageDialog With {
            .Parent = Me,
            .Style = Guna.UI2.WinForms.MessageDialogStyle.Light,
            .Icon = Guna.UI2.WinForms.MessageDialogIcon.Information,
            .Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK,
            .Caption = "Login Successful",
            .Text = "Welcome " & loginData.username & "!"
        }

            ' Open dashboard only after clicking OK
            If successDialog.Show() = DialogResult.OK Then
                Dim dashboard As New Dashboard(loginData.username, loginData.userId)
                dashboard.Show()
                Me.Hide()
            End If
        Else
            ' 🟢 Single Error Message (Prevents Two Popups)
            Dim errorDialog As New Guna.UI2.WinForms.Guna2MessageDialog With {
            .Parent = Me,
            .Style = Guna.UI2.WinForms.MessageDialogStyle.Dark,
            .Icon = Guna.UI2.WinForms.MessageDialogIcon.Error,
            .Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK,
            .Caption = "Login Failed",
            .Text = loginResponse ' Displays the API error message
        }
            errorDialog.Show()
        End If
    End Sub


    ' Open Forgot Password Form
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim forgetPassForm As New Forgetpass()
        Me.Hide()
        forgetPassForm.Show()
    End Sub

    ' Show/Hide Password Toggle
    Private Sub TxtboxPassword_IconRightClick(sender As Object, e As EventArgs) Handles TxtboxPassword.IconRightClick
        If TxtboxPassword.UseSystemPasswordChar Then
            TxtboxPassword.UseSystemPasswordChar = False
            TxtboxPassword.PasswordChar = ControlChars.NullChar
            TxtboxPassword.IconRight = My.Resources.EyeOn ' Change to "eye open" icon
        Else
            TxtboxPassword.UseSystemPasswordChar = True
            TxtboxPassword.PasswordChar = "*"
            TxtboxPassword.IconRight = My.Resources.Eye ' Change to "eye closed" icon
        End If
    End Sub

    ' Exit Confirmation Dialog
    Private Sub Login_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim exitDialog As New Guna.UI2.WinForms.Guna2MessageDialog With {
            .Parent = Me,
            .Style = Guna.UI2.WinForms.MessageDialogStyle.Dark,
            .Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning,
            .Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo,
            .Caption = "Exit Confirmation",
            .Text = "⚠ Are you sure you want to exit?"
        }

        If exitDialog.Show() = DialogResult.No Then
            e.Cancel = True
        Else
            Environment.Exit(0)
        End If
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
