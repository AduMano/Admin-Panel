Imports System.Net.Http
Imports System.Text
Imports Admin_Panel.DashboardService
Imports Guna.UI2.WinForms

Public Class Dashboard
    Public Username As String
    Public userID As String
    Private ManageUsersPage As New ManageUsers(Me)
    Private UtilitiesPage As New Utilities(Me)

    Public Sub New(username As String, userID As String)
        InitializeComponent()
        Me.Username = username
        Me.userID = userID
        Me.AutoScaleMode = AutoScaleMode.None ' Prevents automatic scaling

        Label3.Text = "Hello, " & Me.Username
    End Sub

    Public Async Function LogoutProcess(apiUrl As String) As Task(Of Boolean)
        Try
            Dim logoutUrl As String = apiUrl & "/Auth/LogoutUser"

            ' Create HttpClient
            Using client As New HttpClient()
                client.DefaultRequestHeaders.Accept.Clear()
                client.DefaultRequestHeaders.Add("Accept", "*/*")

                ' Send POST request
                Dim requestData As String = """" & Me.userID.ToString() & """"

                ' Convert requestData to HttpContent
                Debug.WriteLine("Request Data: " & requestData)
                Dim content As New StringContent(requestData, Encoding.UTF8, "application/json")

                Dim response As HttpResponseMessage = Await client.PostAsync(logoutUrl, content)

                ' Debugging: Print API response
                Debug.WriteLine("Logout URL: " & logoutUrl)
                Debug.WriteLine("Response Status Code: " & response.StatusCode.ToString())

                ' If the request was successful (HTTP 200)
                Return response.IsSuccessStatusCode
            End Using
        Catch ex As Exception
            Debug.WriteLine("Logout Error: " & ex.Message)
            Return False
        End Try
    End Function

    Private Async Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles logoutBtn.Click
        ' Show Logout Confirmation Dialog
        Dim logoutDialog As New Guna.UI2.WinForms.Guna2MessageDialog With {
            .Parent = Me,
            .Style = Guna.UI2.WinForms.MessageDialogStyle.Dark,
            .Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning,
            .Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo,
            .Caption = "Confirm Logout",
            .Text = "⚠ Are you sure you want to log out?"
        }

        ' If user selects "No", exit the function
        If logoutDialog.Show() <> DialogResult.Yes Then
            Exit Sub
        End If

        OverlayHelper.ShowOverlay(Me)

        ' 🟢 Step 1: Fetch API URL
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

        ' 🟢 Step 3: Call the existing Logout Process
        Dim isLoggedOut As Boolean = Await LogoutProcess(apiUrl)

        ' 🟢 Step 4: Handle API Response
        If isLoggedOut Then
            OverlayHelper.HideOverlay()

            Dim successDialog As New Guna.UI2.WinForms.Guna2MessageDialog With {
            .Parent = Me,
            .Style = Guna.UI2.WinForms.MessageDialogStyle.Dark,
            .Icon = Guna.UI2.WinForms.MessageDialogIcon.Information,
            .Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK,
            .Caption = "Logout Successful",
            .Text = "You have been successfully logged out!"
        }
            successDialog.Show()

            ' 🟢 Step 5: Redirect to Login Form
            Dim loginForm As New Login()
            loginForm.Show()
            Me.Close()
        Else
            OverlayHelper.HideOverlay()

            Dim errorDialog As New Guna.UI2.WinForms.Guna2MessageDialog With {
            .Parent = Me,
            .Style = Guna.UI2.WinForms.MessageDialogStyle.Dark,
            .Icon = Guna.UI2.WinForms.MessageDialogIcon.Error,
            .Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK,
            .Caption = "Logout Failed",
            .Text = "Logout request failed! Please try again."
        }
            errorDialog.Show()
        End If
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles dashboardBtn.Click
        With ManageUsersPage
            .TopLevel = False
            .Size = dashboardPnl.Size
            .Dock = DockStyle.Fill
            dashboardPnl.Controls.Add(ManageUsersPage)
            .BringToFront()
            .Hide()
        End With

        With UtilitiesPage
            .TopLevel = False
            .Size = dashboardPnl.Size
            .Dock = DockStyle.Fill
            dashboardPnl.Controls.Add(UtilitiesPage)
            .BringToFront()
            .Hide()
        End With

    End Sub


    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles utilitiesBtn.Click
        With UtilitiesPage
            .TopLevel = False
            .Size = dashboardPnl.Size
            .Dock = DockStyle.Fill
            dashboardPnl.Controls.Add(UtilitiesPage)
            .BringToFront()
            .Show()
        End With

    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles manageuserBtn.Click
        With ManageUsersPage
            .TopLevel = False
            .Size = dashboardPnl.Size
            .Dock = DockStyle.Fill
            dashboardPnl.Controls.Add(ManageUsersPage)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub AddListItem(panel As Panel, title As String, description As String, moduleName As String, subModule As String)
        ' Calculate available width (subtracting a bit for padding)
        Dim availableWidth As Integer = panel.ClientSize.Width - 20

        ' Create the notification label
        Dim lblItem As New Label With {
        .AutoSize = False,
        .Width = availableWidth,      ' Use full available width
        .Height = 80,
        .Padding = New Padding(5),
        .ForeColor = Color.Black,
        .BackColor = Color.White,
        .Font = New Font("Arial", 10, FontStyle.Regular),
        .Cursor = Cursors.Hand,
        .TextAlign = ContentAlignment.MiddleLeft
    }
        ' Set the text (title and description)
        lblItem.Text = $"{title}{Environment.NewLine}{description}"

        ' Center the label horizontally within the panel
        lblItem.Left = (panel.ClientSize.Width - lblItem.Width) \ 2

        ' Determine the vertical position:
        Dim topPos As Integer = 10 ' default margin if no items exist
        If panel.Controls.Count > 0 Then
            ' Get the bottom of the last control in the panel and add spacing
            Dim lastControl As Control = panel.Controls(panel.Controls.Count - 1)
            topPos = lastControl.Bottom + 10
        End If
        lblItem.Top = topPos

        ' Add a click event for navigation
        AddHandler lblItem.Click, Sub(sender As Object, e As EventArgs)
                                      MessageBox.Show($"Redirecting to: {moduleName} > {subModule}", "Navigation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                  End Sub

        ' Create a bottom border (separator)
        Dim borderBottom As New Panel With {
        .Width = lblItem.Width,
        .Height = 2,
        .BackColor = Color.DarkGray
    }
        borderBottom.Left = lblItem.Left
        borderBottom.Top = lblItem.Bottom

        ' Add the label and border to the panel
        panel.Controls.Add(lblItem)
        panel.Controls.Add(borderBottom)

        ' Update the panel's AutoScrollMinSize to ensure scrolling works properly
        panel.AutoScrollMinSize = New Size(0, borderBottom.Bottom + 10)

        ' Optionally, update all existing items' width so that if the scrollbar appears, all items remain full width.
        For Each ctrl As Control In panel.Controls
            ctrl.Width = panel.ClientSize.Width - 20
        Next
    End Sub


    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Add formatted, clickable list items
        Me.Size = New Size(1431, 800)
        Me.CenterToScreen()

        ' Clear previous items to avoid duplication
        NotifPanel.Controls.Clear()

        ' Ensure the panel exists before adding items
        If NotifPanel Is Nothing Then
            MessageBox.Show("Panel is not initialized!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        loadDashboard()
    End Sub

    Private Function loadDashboard() As Task
        LoadParcelLogsIntoGridAsync()
        LoadActivityLogsIntoPanel()
        GetActivityLogsCountIntoCards()
    End Function

    Private Async Function GetActivityLogsCountIntoCards() As Task
        Try
            ' Loading
            OverlayHelper.ShowOverlay(Me)

            ' Retrieve the full list from your API/service method.
            Dim logs As ActivityLogCountDto = Await DashboardService.GetActivityLogsCount()

            Debug.WriteLine(logs)

            dailyCount.Text = logs.daily.ToString()
            weeklyCount.Text = logs.weekly.ToString()
            monthlyCount.Text = logs.monthly.ToString()
            anuallyCount.Text = logs.annually.ToString()

            OverlayHelper.HideOverlay()
        Catch ex As Exception

        End Try
    End Function

    Private Async Function LoadActivityLogsIntoPanel() As Task
        Try
            ' Loading
            OverlayHelper.ShowOverlay(Me)

            ' Retrieve the full list from your API/service method.
            Dim logs As List(Of ActivityLogDto) = Await DashboardService.GetActivityLogs()

            ' Select only the first 10 records and project only the fields needed for the grid.
            Dim displayLogs = logs.
                Take(15).
                Select(Function(x) New With {
                    .Title = x.ActionTitle,
                    .Description = x.ActionContext,
                    .ModuleName = x.Module,
                    .SubModule = x.SubModule,
                    .Created = x.CreatedAt
                }).ToList()

            ' Clear previous items to avoid duplication
            NotifPanel.Controls.Clear()

            ' Add formatted, clickable list items
            For Each log In displayLogs
                Dim logTitle = log.Title & Environment.NewLine & "(" & DateHelper.Convert_String_to_Date(log.Created) & ")"
                Debug.WriteLine("Log Title : " & logTitle)
                AddListItem(NotifPanel, logTitle, log.Description, log.ModuleName, log.SubModule)
            Next

            OverlayHelper.HideOverlay()
        Catch ex As Exception

        End Try
    End Function

    Private Async Function LoadParcelLogsIntoGridAsync() As Task
        Try
            ' Loading
            OverlayHelper.ShowOverlay(Me)

            ' Retrieve the full list from your API/service method.
            Dim logs As List(Of ParcelLogSummaryDto) = Await DashboardService.GetParcelLogsSummary()

            ' Select only the first 10 records and project only the fields needed for the grid.
            Dim displayLogs = logs.
                Take(20).
                Select(Function(x) New With {
                    .ParcelName = x.ParcelName & x.ParcelId.ToString().Substring(0, 5),
                    .Recipient = x.userName,  ' or x.userName, depending on your property name
                    .LockerNumber = x.LockerNumber,
                    .[Date] = If(x.Status = "Picked Up", DateHelper.Convert(x.RetrievedAt), DateHelper.Convert(x.LogDate)),
                    .Status = x.Status        ' e.g., "Picked Up" or "Not Picked Up"
                }).
                ToList()

            ' Optionally clear existing columns/rows (if needed).
            ' 1) Unbind the grid first
            ParcelLogsTbl.DataSource = Nothing
            ParcelLogsTbl.Columns.Clear()
            ParcelLogsTbl.Rows.Clear()

            ' Set the DataGridView to fill columns proportionally.
            ParcelLogsTbl.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            ParcelLogsTbl.RowTemplate.Height = 40

            ' Create and add the "Parcel Name" column
            Dim colParcelName As New DataGridViewTextBoxColumn() With {
                .DataPropertyName = "ParcelName",
                .HeaderText = "Parcel Name",
                .FillWeight = 20
            }
            ParcelLogsTbl.Columns.Add(colParcelName)

            ' Create and add the "Recipient" column (e.g., 25% of available width)
            Dim colRecipient As New DataGridViewTextBoxColumn() With {
                .DataPropertyName = "Recipient",
                .HeaderText = "Recipient",
                .FillWeight = 15
            }
            ParcelLogsTbl.Columns.Add(colRecipient)

            ' Create and add the "Locker #" column (e.g., 20% of available width)
            Dim colLockerNumber As New DataGridViewTextBoxColumn() With {
                .DataPropertyName = "LockerNumber",
                .HeaderText = "Locker #",
                .FillWeight = 10
            }
            ParcelLogsTbl.Columns.Add(colLockerNumber)

            ' Create and add the "Date" column (e.g., 30% of available width)
            Dim colDate As New DataGridViewTextBoxColumn() With {
                .DataPropertyName = "Date",
                .HeaderText = "Date",
                .FillWeight = 35
            }
            ParcelLogsTbl.Columns.Add(colDate)

            ' Create and add the "Status" column (e.g., 25% of available width)
            Dim colStatus As New DataGridViewTextBoxColumn() With {
                .DataPropertyName = "Status",
                .HeaderText = "Status",
                .FillWeight = 20
            }
            ParcelLogsTbl.Columns.Add(colStatus)


            ' Set the DataSource of the Guna DataGridView to the selected records.
            ParcelLogsTbl.DataSource = displayLogs
            OverlayHelper.HideOverlay()
        Catch ex As Exception
            OverlayHelper.HideOverlay()
            MessageBox.Show("Error loading parcel logs: " & ex.Message)
        End Try
    End Function

    Private Sub refreshBtn_Click(sender As Object, e As EventArgs) Handles refreshBtn.Click
        loadDashboard()
    End Sub
End Class