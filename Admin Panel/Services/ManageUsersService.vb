Imports Admin_Panel.DashboardService
Imports Newtonsoft.Json
Imports System.Net.Http
Imports System.Net.Http.Headers

Public Class ManageUsersService

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

End Class
