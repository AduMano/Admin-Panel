Imports System.Net
Imports System.Net.Http
Imports System.Net.Mail
Imports System.Text
Imports System.Threading.Tasks
Imports Newtonsoft.Json

Public Class AuthService
    ''' <summary>
    ''' Verifies if the email exists in the database.
    ''' </summary>
    ''' <param name="email">The email to check.</param>
    ''' <param name="type">The user type ("admin" or "user").</param>
    ''' <returns>Returns True if email exists, otherwise False.</returns>
    Public Shared Async Function VerifyEmailExists(email As String, Optional type As String = "admin") As Task(Of Boolean)
        Try
            Dim apiUrl As String = Await ApiHelper.GetLatestApiUrl()
            Dim verifyUrl As String = $"{apiUrl}/Auth/VerifyEmail/{email}/{type}"

            Using client As New HttpClient()
                Dim response As HttpResponseMessage = Await client.GetAsync(verifyUrl)

                ' Read the response content as a string
                Dim responseString As String = Await response.Content.ReadAsStringAsync()

                ' Convert response to Boolean
                Dim emailExists As Boolean = False
                Boolean.TryParse(responseString.Trim(), emailExists) ' TryParse ensures no error

                Return emailExists
            End Using
        Catch ex As Exception
            Console.WriteLine("Error verifying email: " & ex.Message)
            Return False ' Assume False if there's an error
        End Try
    End Function

    Public Shared Async Function RequestVerificationCode(email As String) As Task(Of String)
        Try
            Dim apiUrl As String = Await ApiHelper.GetLatestApiUrl()
            Dim requestUrl As String = $"{apiUrl}/Auth/SendVerificationCode"

            Using client As New HttpClient()
                Dim content As New StringContent("""" & email & """", Encoding.UTF8, "application/json")
                Dim response As HttpResponseMessage = Await client.PostAsync(requestUrl, content)

                ' Read the verification code from response
                If response.IsSuccessStatusCode Then
                    Dim verificationCode As String = Await response.Content.ReadAsStringAsync()
                    Return verificationCode.Trim()
                Else
                    Return ""
                End If
            End Using
        Catch ex As Exception
            Console.WriteLine("Error requesting verification code: " & ex.Message)
            Return ""
        End Try
    End Function
    Public Shared Async Function VerifyResetCode(email As String, code As String) As Task(Of Boolean)
        Try
            Dim apiUrl As String = Await ApiHelper.GetLatestApiUrl()
            Dim requestUrl As String = $"{apiUrl}/Auth/VerifyCode"

            Dim jsonPayload As String = "{""email"":""" & email & """, ""code"":""" & code & """}"
            Dim content As New StringContent(jsonPayload, Encoding.UTF8, "application/json")

            Using client As New HttpClient()
                Dim response As HttpResponseMessage = Await client.PostAsync(requestUrl, content)

                ' Read the response content as a string
                Dim responseString As String = Await response.Content.ReadAsStringAsync()

                ' Convert response to Boolean
                Dim codeExists As Boolean = False
                Boolean.TryParse(responseString.Trim(), codeExists) ' TryParse ensures no error

                Return codeExists
            End Using
        Catch ex As Exception
            Console.WriteLine("Error verifying reset code: " & ex.Message)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Updates the user's password via API request.
    ''' </summary>
    ''' <param name="email">The email of the user.</param>
    ''' <param name="newPassword">The new password to set.</param>
    ''' <returns>Returns True if successful, otherwise False.</returns>
    Public Shared Async Function UpdatePasswordAsync(email As String, newPassword As String) As Task(Of Boolean)
        Try
            ' Fetch the latest API URL
            Dim apiUrl As String = Await ApiHelper.GetLatestApiUrl()
            Dim requestUrl As String = $"{apiUrl}/Auth/UpdatePassword"

            ' Create JSON payload
            Dim requestData As New Dictionary(Of String, String) From {
                {"email", email},
                {"password", newPassword}
            }
            Dim jsonPayload As String = JsonConvert.SerializeObject(requestData)
            Dim content As New StringContent(jsonPayload, Encoding.UTF8, "application/json")

            ' Send POST request
            Using client As New HttpClient()
                Dim response As HttpResponseMessage = Await client.PostAsync(requestUrl, content)

                ' Check if password update was successful
                If response.IsSuccessStatusCode Then
                    Return True
                Else
                    Dim errorResponse As String = Await response.Content.ReadAsStringAsync()
                    Console.WriteLine("Password update failed: " & errorResponse)
                    Return False
                End If
            End Using
        Catch ex As Exception
            Console.WriteLine("Error updating password: " & ex.Message)
            Return False
        End Try
    End Function

End Class
