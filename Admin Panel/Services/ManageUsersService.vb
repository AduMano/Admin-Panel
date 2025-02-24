Imports Admin_Panel.DashboardService
Imports Newtonsoft.Json
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Text
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel

Public Class ManageUsersService

    Public Class RegisterUserDto

        Public Property UserId As String
        Public Property FirstName As String = String.Empty
        Public Property MiddleName As String = String.Empty
        Public Property LastName As String = String.Empty
        Public Property Suffix As String = String.Empty
        Public Property BirthDate As DateTime
        Public Property Gender As String
        Public Property Address As String = String.Empty
        Public Property Email As String = String.Empty
        Public Property ContactNumber As String = String.Empty
        Public Property Username As String = String.Empty
        Public Property Password As String = String.Empty
        Public Property Role As String
        Public Property OperatorID As String
        Public Property UserType As String
        Public Property PhotoUrl As String

    End Class


    Public Class UserDetailsDto

        Public Property userId As String
        Public Property username As String
        Public Property firstName As String
        Public Property middleName As String
        Public Property lastName As String
        Public Property suffix As String

        ' Using Date? (nullable) in case the birthdate can be missing/null
        Public Property birthdate As Date?

        Public Property gender As String
        Public Property genderID As String

        Public Property address As String
        Public Property contactNumber As String
        Public Property email As String
        Public Property photoUrl As String

        Public Property isActive As Boolean

        Public Property roleName As String
        Public Property roleID As String

    End Class
    Public Shared Async Function GetAllAdminList() As Task(Of List(Of UserDetailsDto))
        Try
            Dim apiUrl As String = Await ApiHelper.GetLatestApiUrl()
            Dim requestUrl As String = $"{apiUrl}/Users/residentsList/Admin"

            Using client As New HttpClient()
                client.DefaultRequestHeaders.Accept.Clear()
                client.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue("*/*"))

                Dim response As HttpResponseMessage = Await client.GetAsync(requestUrl)
                response.EnsureSuccessStatusCode()

                ' Read the response content as a string.
                Dim responseString As String = Await response.Content.ReadAsStringAsync()

                ' Deserialize the JSON array into a List(Of ParcelLogSummaryDto)
                Dim users As List(Of UserDetailsDto) = JsonConvert.DeserializeObject(Of List(Of UserDetailsDto))(responseString)

                Return users
            End Using
        Catch ex As Exception
            Console.WriteLine("Error retrieving parcel logs summary: " & ex.Message)
            Return Nothing ' or return New List(Of ParcelLogSummaryDto) if you prefer an empty list
        End Try
    End Function

    Public Shared Async Function GetAllResidenceList() As Task(Of List(Of UserDetailsDto))
        Try
            Dim apiUrl As String = Await ApiHelper.GetLatestApiUrl()
            Dim requestUrl As String = $"{apiUrl}/Users/residentsList/Users"

            Using client As New HttpClient()
                client.DefaultRequestHeaders.Accept.Clear()
                client.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue("*/*"))

                Dim response As HttpResponseMessage = Await client.GetAsync(requestUrl)
                response.EnsureSuccessStatusCode()

                ' Read the response content as a string.
                Dim responseString As String = Await response.Content.ReadAsStringAsync()

                ' Deserialize the JSON array into a List(Of ParcelLogSummaryDto)
                Dim users As List(Of UserDetailsDto) = JsonConvert.DeserializeObject(Of List(Of UserDetailsDto))(responseString)

                Return users
            End Using
        Catch ex As Exception
            Console.WriteLine("Error retrieving parcel logs summary: " & ex.Message)
            Return Nothing ' or return New List(Of ParcelLogSummaryDto) if you prefer an empty list
        End Try
    End Function

    Public Shared Async Function CheckEmailIfExisting(email As String, Optional except As String = " ") As Task(Of Boolean)
        Try
            ' 2) Construct URLs
            Dim apiUrl As String = Await ApiHelper.GetLatestApiUrl()
            Dim requestUrlUsers As String = $"{apiUrl}/Auth/VerifyEmail/{email}/{except}/user"
            Dim requestUrlAdmin As String = $"{apiUrl}/Auth/VerifyEmail/{email}/{except}/admin"

            Using client As New HttpClient()
                client.DefaultRequestHeaders.Accept.Clear()
                client.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue("*/*"))

                ' 3) Make both requests
                Dim responseUser As HttpResponseMessage = Await client.GetAsync(requestUrlUsers)
                Dim responseAdmin As HttpResponseMessage = Await client.GetAsync(requestUrlAdmin)

                ' 4) Ensure success or throw an exception
                responseUser.EnsureSuccessStatusCode()
                responseAdmin.EnsureSuccessStatusCode()

                ' 5) Read boolean values from the responses
                Dim userContent As String = Await responseUser.Content.ReadAsStringAsync()
                Dim adminContent As String = Await responseAdmin.Content.ReadAsStringAsync()

                ' For example, if the API returns "true" or "false" in plain text or JSON
                Dim userExists As Boolean = False
                Dim adminExists As Boolean = False

                Boolean.TryParse(userContent, userExists)
                Boolean.TryParse(adminContent, adminExists)

                ' 6) Return True if EITHER is True; otherwise False
                Return (userExists Or adminExists)
            End Using

        Catch ex As Exception
            Console.WriteLine("Error retrieving email info: " & ex.Message)
            ' If there's an error, decide how to handle
            ' For now, return False so the caller knows it didn't find a match.
            Return False
        End Try
    End Function

    Public Shared Async Function CheckUsernameIfExisting(username As String, Optional except As String = "") As Task(Of Boolean)
        Try
            ' 2) Construct URLs
            Dim apiUrl As String = Await ApiHelper.GetLatestApiUrl()
            Dim requestUrlUsers As String = $"{apiUrl}/Users/UsernameCheck/{username}/{except}"

            Using client As New HttpClient()
                client.DefaultRequestHeaders.Accept.Clear()
                client.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue("*/*"))

                ' 3) Make both requests
                Dim responseUser As HttpResponseMessage = Await client.GetAsync(requestUrlUsers)

                ' 4) Ensure success or throw an exception
                responseUser.EnsureSuccessStatusCode()

                ' 5) Read boolean values from the responses
                Dim userContent As String = Await responseUser.Content.ReadAsStringAsync()

                ' For example, if the API returns "true" or "false" in plain text or JSON
                Dim userExists As Boolean = False

                Boolean.TryParse(userContent, userExists)

                ' 6) Return True if EITHER is True; otherwise False
                Return userExists
            End Using

        Catch ex As Exception
            Console.WriteLine("Error retrieving email info: " & ex.Message)
            ' If there's an error, decide how to handle
            ' For now, return False so the caller knows it didn't find a match.
            Return False
        End Try
    End Function

    Public Shared Async Function AddNewUserAsync(newUser As RegisterUserDto) As Task(Of String)
        ' Set the URL of your NewUser API endpoint.
        Dim apiUrl As String = Await ApiHelper.GetLatestApiUrl()
        Dim requestUrlUsers As String = $"{apiUrl}/Users/AddNewUser"

        Using client As New HttpClient()
            ' Set up the client to accept JSON.
            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue("application/json"))

            ' Serialize your newUser object into JSON.
            Dim jsonPayload As String = JsonConvert.SerializeObject(newUser)
            Dim content As New StringContent(jsonPayload, Encoding.UTF8, "application/json")

            ' Post the JSON payload to the API.
            Dim response As HttpResponseMessage = Await client.PostAsync(apiUrl, content)

            If response.IsSuccessStatusCode Then
                ' Success: The user was created.
                Dim userID As String = Await response.Content.ReadAsStringAsync()
                Return userID
            Else
                ' Optionally, read the error message returned from the API.
                Dim errorMessage As String = Await response.Content.ReadAsStringAsync()
                'MessageBox.Show("API call failed: " & errorMessage)
                Return "Failed"
            End If
        End Using
    End Function

    Public Shared Async Function UpdateUserAsync(updateUser As RegisterUserDto) As Task(Of Boolean)
        ' Get the base API URL
        Dim apiUrl As String = Await ApiHelper.GetLatestApiUrl()
        Dim requestUrlUsers As String = $"{apiUrl}/Users/UpdateUser"

        Using client As New HttpClient()
            ' Set up the client to accept JSON.
            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue("application/json"))

            ' Serialize the updateUser object into JSON.
            Dim jsonPayload As String = JsonConvert.SerializeObject(updateUser)
            Dim content As New StringContent(jsonPayload, Encoding.UTF8, "application/json")

            ' Send the PUT request with the JSON payload.
            Dim response As HttpResponseMessage = Await client.PutAsync(requestUrlUsers, content)
            Dim responseContent As String = Await response.Content.ReadAsStringAsync()

            ' Parse the response content as a Boolean.
            Dim result As Boolean = False
            Boolean.TryParse(responseContent, result)

            If result Then
                ' If true, the update was successful.
                Return True
            Else
                ' Optionally log or display the error message.
                ' Dim errorMessage As String = responseContent
                Return False
            End If
        End Using
    End Function

End Class
