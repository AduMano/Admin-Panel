Imports System.Net.Http
Imports Newtonsoft.Json
Imports System.Text

Public Class ApiHelper
    Private Shared ReadOnly supabaseUrl As String = "https://nlljvmwgxlnhdinvkofd.supabase.co"
    Private Shared ReadOnly supabaseKey As String = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6Im5sbGp2bXdneGxuaGRpbnZrb2ZkIiwicm9sZSI6ImFub24iLCJpYXQiOjE3MzkzODE4NzUsImV4cCI6MjA1NDk1Nzg3NX0.O30PoY_iunkPTTWVltheYHfaKBoOxL3iAN3Ktw1lwsk"

    ' Fetch latest API URL from Supabase table
    Public Shared Async Function GetLatestApiUrl() As Task(Of String)
        Try
            Using client As New HttpClient()
                client.DefaultRequestHeaders.Add("apikey", supabaseKey)
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " & supabaseKey)

                ' Fetch from Supabase table where latest URL is stored
                Dim requestUrl As String = supabaseUrl & "/rest/v1/TBL_URL?id=eq.1"
                Dim response As HttpResponseMessage = Await client.GetAsync(requestUrl)

                If response.IsSuccessStatusCode Then
                    Dim jsonResponse As String = Await response.Content.ReadAsStringAsync()
                    Dim apiUrls = JsonConvert.DeserializeObject(Of List(Of Dictionary(Of String, String)))(jsonResponse)

                    ' Return the latest API URL
                    If apiUrls IsNot Nothing AndAlso apiUrls.Count > 0 Then
                        Return apiUrls(0)("url") ' Assuming column name is "url"
                    End If
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error retrieving API URL: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return String.Empty ' Return empty if failed
    End Function
End Class
