Imports Admin_Panel.UtilitiesService

''' <summary>
''' The Utilities form/class handles displaying and filtering of Parcel Logs and User Activity Logs.
''' </summary>
Public Class Utilities

    ''' <summary>
    ''' A reference to the parent Dashboard form (if needed).
    ''' </summary>
    Private parent As Dashboard

    ''' <summary>
    ''' Holds all User Activity Logs that have been fetched, for filtering.
    ''' </summary>
    Private _allUserLogs As List(Of ActivityLogDto) = Nothing

    ''' <summary>
    ''' Holds all Parcel Logs that have been fetched, for filtering.
    ''' </summary>
    Private _allParcelLogs As List(Of ParcelLogSummaryDto) = Nothing

    ''' <summary>
    ''' The parameterless constructor. The designer relies on this to initialize the form.
    ''' </summary>
    Public Sub New(form As Dashboard)
        ' This call is required by the designer.
        InitializeComponent()

        parent = form
    End Sub

    ''' <summary>
    ''' Occurs when the Utilities form loads. Disables automatic scaling and calls Reload_Info().
    ''' </summary>
    Private Sub Utilities_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.AutoScaleMode = AutoScaleMode.None ' Prevents automatic scaling
        Reload_Info()
    End Sub

    ''' <summary>
    ''' Reloads all relevant information displayed by this form, i.e., Parcel Logs and User Logs.
    ''' </summary>
    ''' <returns>A Task representing the async calls made.</returns>
    Private Function Reload_Info() As Task
        LoadParcelLogsIntoGridAsync()
        LoadActivitylLogsIntoGridAsync()
    End Function

    ''' <summary>
    ''' Asynchronously fetches and displays the Parcel Logs in ParcelLogsTbl (DataGridView).
    ''' This includes creating the columns manually and binding a display-friendly object list.
    ''' </summary>
    ''' <returns>A Task for the async operation.</returns>
    Private Async Function LoadParcelLogsIntoGridAsync() As Task
        Try
            ' Show a loading overlay on this form
            OverlayHelper.ShowOverlay(parent)

            ' 1) Retrieve the Parcel Logs from the UtilitiesService
            Dim logs As List(Of ParcelLogSummaryDto) = Await UtilitiesService.GetParcelLogs()
            _allParcelLogs = logs  ' store them for future filtering

            ' 2) Project each log into an anonymous type suitable for display
            Dim displayLogs = logs.
                Select(Function(x) New With {
                    .ParcelName = x.ParcelName & x.ParcelId.ToString().Substring(0, 5),
                    .Recipient = x.userName,
                    .LockerNumber = x.LockerNumber,
                    .[Date] = If(x.Status = "Picked Up",
                                 DateHelper.Convert(x.RetrievedAt),
                                 DateHelper.Convert(x.LogDate)),
                    .Status = x.Status
                }).
                ToList()

            ' 3) Clear the ParcelLogsTbl before binding
            ParcelLogsTbl.DataSource = Nothing
            ParcelLogsTbl.Columns.Clear()
            ParcelLogsTbl.Rows.Clear()

            ' 4) Configure DataGridView appearance
            ParcelLogsTbl.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            ParcelLogsTbl.RowTemplate.Height = 40

            ' 5) Manually create columns to control their display
            Dim colParcelName As New DataGridViewTextBoxColumn() With {
                .DataPropertyName = "ParcelName",
                .HeaderText = "Parcel Name",
                .FillWeight = 20
            }
            ParcelLogsTbl.Columns.Add(colParcelName)

            Dim colRecipient As New DataGridViewTextBoxColumn() With {
                .DataPropertyName = "Recipient",
                .HeaderText = "Recipient",
                .FillWeight = 15
            }
            ParcelLogsTbl.Columns.Add(colRecipient)

            Dim colLockerNumber As New DataGridViewTextBoxColumn() With {
                .DataPropertyName = "LockerNumber",
                .HeaderText = "Locker #",
                .FillWeight = 10
            }
            ParcelLogsTbl.Columns.Add(colLockerNumber)

            Dim colDate As New DataGridViewTextBoxColumn() With {
                .DataPropertyName = "Date",
                .HeaderText = "Date",
                .FillWeight = 35
            }
            ParcelLogsTbl.Columns.Add(colDate)

            Dim colStatus As New DataGridViewTextBoxColumn() With {
                .DataPropertyName = "Status",
                .HeaderText = "Status",
                .FillWeight = 20
            }
            ParcelLogsTbl.Columns.Add(colStatus)

            ' 6) Finally, bind the data to the grid
            ParcelLogsTbl.DataSource = displayLogs

            ' Remove the loading overlay
            OverlayHelper.HideOverlay()

        Catch ex As Exception
            OverlayHelper.HideOverlay()
            MessageBox.Show("Error loading parcel logs: " & ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Asynchronously fetches and displays the User Activity Logs in dgvUserLogs (DataGridView).
    ''' </summary>
    ''' <returns>A Task for the async operation.</returns>
    Private Async Function LoadActivitylLogsIntoGridAsync() As Task
        Try
            ' Show a loading overlay
            OverlayHelper.ShowOverlay(parent)

            ' 1) Clear the DataGridView
            dgvUserLogs.DataSource = Nothing
            dgvUserLogs.Rows.Clear()
            dgvUserLogs.Columns.Clear()

            ' 2) Retrieve Activity Logs from the UtilitiesService
            Dim logs As List(Of ActivityLogDto) = Await UtilitiesService.GetActivityLogs()
            _allUserLogs = logs  ' Store for filtering

            ' 3) Project logs into an anonymous type with the minimal fields needed
            Dim displayLogs = logs.
                Select(Function(x) New With {
                    .Action = x.ActionTitle,
                    .Context = x.ActionContext,
                    .DateTime = DateHelper.Convert(x.CreatedAt)
                }).
                ToList()

            ' 4) Configure the DataGridView
            dgvUserLogs.AutoGenerateColumns = True
            dgvUserLogs.DataSource = Nothing
            dgvUserLogs.Rows.Clear()
            dgvUserLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgvUserLogs.RowTemplate.Height = 40

            ' 5) Bind the logs to the grid
            dgvUserLogs.DataSource = displayLogs

            ' Hide the loading overlay
            OverlayHelper.HideOverlay()

        Catch ex As Exception
            OverlayHelper.HideOverlay()
            MessageBox.Show("Error loading parcel logs: " & ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Filters the Parcel Logs (stored in _allParcelLogs) based on the user's search text.
    ''' Matches partial text in ParcelName+ID substring, userName, or the converted date string.
    ''' Re-binds ParcelLogsTbl with the filtered results.
    ''' </summary>
    ''' <param name="searchText">Search term typed by the user.</param>
    Private Sub FilterParcelLogs(searchText As String)
        ' Guard clause if no data is loaded
        If _allParcelLogs Is Nothing OrElse _allParcelLogs.Count = 0 Then
            Return
        End If

        Dim lowerSearch As String = searchText.ToLower().Trim()
        Dim filtered As List(Of ParcelLogSummaryDto)

        ' If search text is blank, show all logs
        If String.IsNullOrEmpty(lowerSearch) Then
            filtered = _allParcelLogs
        Else
            ' Otherwise, we filter based on the partial matches
            filtered = _allParcelLogs.Where(Function(x)
                                                Dim dateStr As String = If(x.Status = "Picked Up",
                                                                           DateHelper.Convert(x.RetrievedAt),
                                                                           DateHelper.Convert(x.LogDate))

                                                Dim parcelNameStr As String = x.ParcelName & x.ParcelId.ToString().Substring(0, 5)

                                                Return parcelNameStr.ToLower().Contains(lowerSearch) _
                                                    OrElse (x.userName IsNot Nothing AndAlso x.userName.ToLower().Contains(lowerSearch)) _
                                                    OrElse (dateStr IsNot Nothing AndAlso dateStr.ToLower().Contains(lowerSearch))
                                            End Function).ToList()
        End If

        ' Re-project into the same shape used by the DataGridView
        Dim displayLogs = filtered.
            Select(Function(x) New With {
                .ParcelName = x.ParcelName & x.ParcelId.ToString().Substring(0, 5),
                .Recipient = x.userName,
                .LockerNumber = x.LockerNumber,
                .[Date] = If(x.Status = "Picked Up",
                             DateHelper.Convert(x.RetrievedAt),
                             DateHelper.Convert(x.LogDate)),
                .Status = x.Status
            }).
            ToList()

        ' Re-bind the DataGridView

        ParcelLogsTbl.DataSource = Nothing
        ParcelLogsTbl.Rows.Clear()
        ParcelLogsTbl.Columns.Clear()

        ParcelLogsTbl.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        ParcelLogsTbl.RowTemplate.Height = 40

        ' Recreate columns (same approach as in LoadParcelLogsIntoGridAsync)
        Dim colParcelName As New DataGridViewTextBoxColumn() With {
            .DataPropertyName = "ParcelName",
            .HeaderText = "Parcel Name",
            .FillWeight = 20
        }
        ParcelLogsTbl.Columns.Add(colParcelName)

        Dim colRecipient As New DataGridViewTextBoxColumn() With {
            .DataPropertyName = "Recipient",
            .HeaderText = "Recipient",
            .FillWeight = 15
        }
        ParcelLogsTbl.Columns.Add(colRecipient)

        Dim colLockerNumber As New DataGridViewTextBoxColumn() With {
            .DataPropertyName = "LockerNumber",
            .HeaderText = "Locker #",
            .FillWeight = 10
        }
        ParcelLogsTbl.Columns.Add(colLockerNumber)

        Dim colDate As New DataGridViewTextBoxColumn() With {
            .DataPropertyName = "Date",
            .HeaderText = "Date",
            .FillWeight = 35
        }
        ParcelLogsTbl.Columns.Add(colDate)

        Dim colStatus As New DataGridViewTextBoxColumn() With {
            .DataPropertyName = "Status",
            .HeaderText = "Status",
            .FillWeight = 20
        }
        ParcelLogsTbl.Columns.Add(colStatus)

        ParcelLogsTbl.DataSource = displayLogs
    End Sub

    ''' <summary>
    ''' Filters the User Activity Logs (stored in _allUserLogs) based on the user's search text.
    ''' Compares partial text in ActionTitle, ActionContext, or the string of CreatedAt.
    ''' </summary>
    ''' <param name="searchText">The user-typed search text to match.</param>
    Private Sub FilterUserLogs(searchText As String)
        If _allUserLogs Is Nothing OrElse _allUserLogs.Count = 0 Then
            ' No logs to filter
            Return
        End If

        Dim lowerSearch As String = searchText.ToLower()
        Dim filtered As List(Of ActivityLogDto)

        ' If no search text, show all logs
        If String.IsNullOrWhiteSpace(searchText) Then
            filtered = _allUserLogs
        Else
            ' Partial match in Title, Context, or the date string
            filtered = _allUserLogs.Where(Function(x)
                                              Dim dateStr As String = DateHelper.Convert(x.CreatedAt).ToLower()
                                              Return (x.ActionTitle IsNot Nothing AndAlso x.ActionTitle.ToLower().Contains(lowerSearch)) _
                                                  OrElse (x.ActionContext IsNot Nothing AndAlso x.ActionContext.ToLower().Contains(lowerSearch)) _
                                                  OrElse dateStr.Contains(lowerSearch)
                                          End Function).ToList()
        End If

        ' Re-project for display
        Dim displayLogs = filtered.
            Select(Function(x) New With {
                .Action = x.ActionTitle,
                .Context = x.ActionContext,
                .DateTime = DateHelper.Convert(x.CreatedAt)
            }).
            ToList()

        ' Clear & re-bind the DataGridView
        dgvUserLogs.DataSource = Nothing
        dgvUserLogs.Rows.Clear()
        dgvUserLogs.Columns.Clear()

        dgvUserLogs.AutoGenerateColumns = True
        dgvUserLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvUserLogs.RowTemplate.Height = 40

        dgvUserLogs.DataSource = displayLogs
    End Sub

    Private Sub searchBtn2_Click(sender As Object, e As EventArgs) Handles searchBtn2.Click
        FilterParcelLogs(parcelLogsSearch.Text.Trim())
    End Sub

    Private Sub clearBtn2_Click(sender As Object, e As EventArgs) Handles clearBtn2.Click
        FilterParcelLogs("")
    End Sub

    Private Sub searchBtn3_Click(sender As Object, e As EventArgs) Handles searchBtn3.Click
        FilterUserLogs(userLogsSearch.Text.Trim())
    End Sub

    Private Sub clearBtn3_Click(sender As Object, e As EventArgs) Handles clearBtn3.Click
        FilterUserLogs("")
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Reload_Info()
    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click
        Reload_Info()
    End Sub

    Private Sub refreshBtn_Click(sender As Object, e As EventArgs) Handles refreshBtn.Click
        Reload_Info()
    End Sub
End Class
