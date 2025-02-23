Imports Admin_Panel.UtilitiesService

Public Class Utilities
    Private Sub Utilities_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.AutoScaleMode = AutoScaleMode.None ' Prevents automatic scaling(

        Reload_Info()
    End Sub

    Private Function Reload_Info() As Task
        LoadParcelLogsIntoGridAsync()
        LoadActivitylLogsIntoGridAsync()
    End Function

    Private Async Function LoadParcelLogsIntoGridAsync() As Task
        Try
            ' Loading
            OverlayHelper.ShowOverlay(Me)

            ' Retrieve the full list from your API/service method.
            Dim logs As List(Of ParcelLogSummaryDto) = Await UtilitiesService.GetParcelLogs()

            ' Select only the first 10 records and project only the fields needed for the grid.
            Dim displayLogs = logs.
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

    Private Async Function LoadActivitylLogsIntoGridAsync() As Task
        Try
            ' Loading
            OverlayHelper.ShowOverlay(Me)

            ' 0) Clear the DataGridView
            dgvUserLogs.DataSource = Nothing
            dgvUserLogs.Rows.Clear()
            dgvUserLogs.Columns.Clear()

            ' Retrieve the full list from your API/service method.
            Dim logs As List(Of ActivityLogDto) = Await UtilitiesService.GetActivityLogs()

            ' Select only the first 10 records and project only the fields needed for the grid.
            Dim displayLogs = logs.
                Select(Function(x) New With {
                    .Action = x.ActionTitle,
                    .Context = x.ActionContext,  ' or x.userName, depending on your property name
                    .DateTime = DateHelper.Convert(x.CreatedAt)       ' e.g., "Picked Up" or "Not Picked Up"
                }).
                ToList()

            ' Optionally clear existing columns/rows (if needed).
            ' 1) Unbind the grid first
            dgvUserLogs.AutoGenerateColumns = True
            dgvUserLogs.DataSource = Nothing
            dgvUserLogs.Rows.Clear()

            ' Set the DataGridView to fill columns proportionally.
            dgvUserLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgvUserLogs.RowTemplate.Height = 40

            ' Set the DataSource of the Guna DataGridView to the selected records.
            dgvUserLogs.DataSource = displayLogs
            OverlayHelper.HideOverlay()
        Catch ex As Exception
            OverlayHelper.HideOverlay()
            MessageBox.Show("Error loading parcel logs: " & ex.Message)
        End Try
    End Function
End Class