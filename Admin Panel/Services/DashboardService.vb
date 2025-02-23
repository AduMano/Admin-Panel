Imports Newtonsoft.Json
Imports System.Net.Http
Imports System.Net.Http.Headers

Public Class DashboardService
    Public Class ParcelLogSummaryDto
        Public Property ParcelId As Guid
        Public Property ParcelName As String
        Public Property LockerNumber As String
        Public Property Status As String
        Public Property Action As String
        Public Property LogDate As DateTime?
        Public Property RetrievedAt As DateTime?
        Public Property LogType As String
        Public Property UserId As Guid
        Public Property userName As String
    End Class

    Public Class ActivityLogDto
        Public Property Id As Guid
        Public Property ActionTitle As String
        Public Property ActionContext As String
        Public Property [Module] As String
        Public Property SubModule As String
        Public Property CreatedAt As DateTime?
        Public Property CreatedBy As Guid?
    End Class

    Public Class ActivityLogCountDto
        Public Property daily As Int32
        Public Property weekly As Int32
        Public Property monthly As Int32
        Public Property annually As Int32
    End Class


    Public Shared Async Function GetParcelLogsSummary() As Task(Of List(Of ParcelLogSummaryDto))
        Try
            Dim apiUrl As String = Await ApiHelper.GetLatestApiUrl()
            Dim requestUrl As String = $"{apiUrl}/ParcelLogs/GetParcelLogsSummary"

            Using client As New HttpClient()
                client.DefaultRequestHeaders.Accept.Clear()
                client.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue("*/*"))

                Dim response As HttpResponseMessage = Await client.GetAsync(requestUrl)
                response.EnsureSuccessStatusCode()

                ' Read the response content as a string.
                Dim responseString As String = Await response.Content.ReadAsStringAsync()

                ' Deserialize the JSON array into a List(Of ParcelLogSummaryDto)
                Dim parcelLogs As List(Of ParcelLogSummaryDto) = JsonConvert.DeserializeObject(Of List(Of ParcelLogSummaryDto))(responseString)

                Return parcelLogs
            End Using
        Catch ex As Exception
            Console.WriteLine("Error retrieving parcel logs summary: " & ex.Message)
            Return Nothing ' or return New List(Of ParcelLogSummaryDto) if you prefer an empty list
        End Try
    End Function

    Public Shared Async Function GetActivityLogs() As Task(Of List(Of ActivityLogDto))
        Try
            Dim apiUrl As String = Await ApiHelper.GetLatestApiUrl()
            Dim requestUrl As String = $"{apiUrl}/ActivityLogs/GetActivityLogs"

            Using client As New HttpClient()
                client.DefaultRequestHeaders.Accept.Clear()
                client.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue("*/*"))

                Dim response As HttpResponseMessage = Await client.GetAsync(requestUrl)
                response.EnsureSuccessStatusCode()

                ' Read the response content as a string.
                Dim responseString As String = Await response.Content.ReadAsStringAsync()

                ' Deserialize the JSON array into a List(Of ActivityLogDto)
                Dim activityLogs As List(Of ActivityLogDto) = JsonConvert.DeserializeObject(Of List(Of ActivityLogDto))(responseString)

                Return activityLogs
            End Using
        Catch ex As Exception
            Console.WriteLine("Error retrieving activity logs: " & ex.Message)
            Return Nothing ' or return New List(Of ActivityLogDto) if you prefer an empty list
        End Try
    End Function

    Public Shared Async Function GetActivityLogsCount() As Task(Of ActivityLogCountDto)
        Try
            Dim apiUrl As String = Await ApiHelper.GetLatestApiUrl()
            Dim requestUrl As String = $"{apiUrl}/ParcelLogs/GetParcelLogsCount"

            Using client As New HttpClient()
                client.DefaultRequestHeaders.Accept.Clear()
                client.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue("*/*"))

                Dim response As HttpResponseMessage = Await client.GetAsync(requestUrl)
                response.EnsureSuccessStatusCode()

                ' Read the response content as a string.
                Dim responseString As String = Await response.Content.ReadAsStringAsync()

                ' Deserialize the JSON object into an ActivityLogCountDto
                Dim activityLogCount As ActivityLogCountDto = JsonConvert.DeserializeObject(Of ActivityLogCountDto)(responseString)

                Return activityLogCount
            End Using
        Catch ex As Exception
            Console.WriteLine("Error retrieving activity logs count: " & ex.Message)
            Return Nothing ' or return New ActivityLogCountDto if you prefer an empty object
        End Try
    End Function
End Class
