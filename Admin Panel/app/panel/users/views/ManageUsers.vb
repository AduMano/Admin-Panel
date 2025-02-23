Imports Admin_Panel.DashboardService
Imports Admin_Panel.ManageUsersService

Public Class ManageUsers
    Private parent As Dashboard
    Private _allResidents As List(Of UserDetailsDto) = Nothing
    Private _allAdmin As List(Of UserDetailsDto) = Nothing

    Public Sub New(form As Dashboard)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        parent = form
    End Sub
    Private Sub Guna2Button2_Click_1(sender As Object, e As EventArgs) Handles RegUserBtn.Click
        Register.Show()
    End Sub

    Private Sub registerBtn_Click(sender As Object, e As EventArgs) Handles AddAdminBtn.Click
        Adminregform.Show()
    End Sub

    Private Sub ManageUsers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.AutoScaleMode = AutoScaleMode.None ' Prevents automatic scaling

        Reload_Data()
    End Sub

    Private Async Sub LoadAllResidence()
        Try
            OverlayHelper.ShowOverlay(parent)

            ' 0) Clear the DataGridView
            dgvUsers.DataSource = Nothing
            dgvUsers.Rows.Clear()
            dgvUsers.Columns.Clear()

            ' 1) Fetch data from your service.
            Dim users As List(Of UserDetailsDto) = Await ManageUsersService.GetAllResidenceList()
            _allResidents = users

            ' 2) Project the fields into an anonymous type for the grid.
            '    (No .Take(10), so it will take all).
            Dim displayLogs = users.Select(Function(x)
                                               Dim middleInitial As String = If(String.IsNullOrEmpty(x.middleName), "", x.middleName(0) & ". ")
                                               Return New With {
                                               .Username = x.username,
                                               .FullName = x.firstName & " " & middleInitial & x.lastName & " " & x.suffix,
                                               .Gender = x.gender,
                                               .Status = If(x.isActive, "Active", "Inactive")
                                           }
                                           End Function).ToList()

            ' 3) Let the DataGridView auto-generate columns for Username, FullName, Gender, and Status.
            dgvUsers.AutoGenerateColumns = True

            ' Clear only if you need to remove any leftover data
            dgvUsers.DataSource = Nothing
            dgvUsers.Rows.Clear()
            ' IMPORTANT: Do NOT call dgvUsers.Columns.Clear() here if you want appended columns.

            ' 4) Set the new DataSource
            dgvUsers.DataSource = displayLogs

            ' 5) Check if the "Action" column already exists. If not, create it now:
            If dgvUsers.Columns.Contains("Action") = False Then
                Dim actionCol As New DataGridViewTextBoxColumn With {
                .Name = "Action",
                .HeaderText = "Action"
            }
                dgvUsers.Columns.Add(actionCol)

                ' 6) (Optional) Hook up CellPainting / CellClick if you haven't yet
                AddHandler dgvUsers.CellPainting, AddressOf dgvUsers_CellPainting
                AddHandler dgvUsers.CellClick, AddressOf dgvUsers_CellClick
            End If
        Catch ex As Exception
            MessageBox.Show($"Error loading users: {ex.Message}",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error)
        Finally
            OverlayHelper.HideOverlay()
        End Try
    End Sub

    Private Async Sub LoadAllAdmin()
        Try
            OverlayHelper.ShowOverlay(parent)

            ' 0) Clear the DataGridView
            dgvAdmins.DataSource = Nothing
            dgvAdmins.Rows.Clear()
            dgvAdmins.Columns.Clear()

            ' 1) Fetch data from your service.
            Dim users As List(Of UserDetailsDto) = Await ManageUsersService.GetAllAdminList()
            Debug.WriteLine(users)
            _allAdmin = users

            ' 2) Project the fields into an anonymous type for the grid.
            '    (No .Take(10), so it will take all).
            Dim displayLogs = _allAdmin.Select(Function(x)
                                                   Dim middleInitial As String = If(String.IsNullOrEmpty(x.middleName), "", x.middleName(0) & ". ")
                                                   Return New With {
                                               .Username = x.username,
                                               .FullName = x.firstName & " " & middleInitial & x.lastName & " " & x.suffix,
                                               .Gender = x.gender,
                                               .Status = If(x.isActive, "Active", "Inactive")
                                           }
                                               End Function).ToList()

            ' 3) Let the DataGridView auto-generate columns for Username, FullName, Gender, and Status.
            dgvAdmins.AutoGenerateColumns = True

            ' Clear only if you need to remove any leftover data
            dgvAdmins.DataSource = Nothing
            dgvAdmins.Rows.Clear()
            ' IMPORTANT: Do NOT call dgvUsers.Columns.Clear() here if you want appended columns.

            ' 4) Set the new DataSource
            dgvAdmins.DataSource = displayLogs

            ' 5) Check if the "Action" column already exists. If not, create it now:
            If dgvAdmins.Columns.Contains("Action") = False Then
                Dim actionCol As New DataGridViewTextBoxColumn With {
                .Name = "Action",
                .HeaderText = "Action"
            }
                dgvAdmins.Columns.Add(actionCol)

                ' 6) (Optional) Hook up CellPainting / CellClick if you haven't yet
                AddHandler dgvAdmins.CellPainting, AddressOf dgvAdmin_CellPainting
                AddHandler dgvAdmins.CellClick, AddressOf dgvAdmin_CellClick
            End If
        Catch ex As Exception
            MessageBox.Show($"Error loading users: {ex.Message}",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error)
        Finally
            OverlayHelper.HideOverlay()
        End Try
    End Sub

    Private Sub FilterByUsernameResidents(searchTerm As String)
        ' If we haven't fetched any users yet, do nothing
        If _allResidents Is Nothing OrElse _allResidents.Count = 0 Then
            Return
        End If

        ' Filter by Username, ignoring case. If searchTerm is empty, show all.
        Dim filteredList As List(Of UserDetailsDto)

        If String.IsNullOrWhiteSpace(searchTerm) Then
            ' Show everything if there's no search text
            filteredList = _allResidents
        Else
            filteredList = _allResidents.
            Where(Function(u)
                      Return u.username IsNot Nothing AndAlso
                             u.username.ToLower().Contains(searchTerm.ToLower())
                  End Function).
            ToList()
        End If

        ' Project or shape the data for display again
        Dim displayData = filteredList.Select(Function(x)
                                                  Dim middleInitial As String = If(String.IsNullOrEmpty(x.middleName), "", x.middleName(0) & ". ")
                                                  Return New With {
                                                  .Username = x.username,
                                                  .FullName = x.firstName & " " & middleInitial & x.lastName & " " & x.suffix,
                                                  .Gender = x.gender,
                                                  .Status = If(x.isActive, "Active", "Inactive")
                                              }
                                              End Function).ToList()

        ' Re-bind to DataGridView
        dgvUsers.DataSource = Nothing
        dgvUsers.Rows.Clear()
        dgvUsers.Columns.Clear()

        dgvUsers.AutoGenerateColumns = True
        dgvUsers.DataSource = displayData

        ' Re-add or check for the Action column if needed
        If Not dgvUsers.Columns.Contains("Action") Then
            Dim actionColumn As New DataGridViewTextBoxColumn() With {.Name = "Action", .HeaderText = "Action"}
            dgvUsers.Columns.Add(actionColumn)
            dgvUsers.Columns("Action").DisplayIndex = dgvUsers.Columns.Count - 1

            ' If you have custom painting for that column:
            AddHandler dgvUsers.CellPainting, AddressOf dgvUsers_CellPainting
            AddHandler dgvUsers.CellClick, AddressOf dgvUsers_CellClick
        End If
    End Sub

    Private Sub FilterByUsernameAdmin(searchTerm As String)
        ' If we haven't fetched any users yet, do nothing
        If _allAdmin Is Nothing OrElse _allAdmin.Count = 0 Then
            Return
        End If

        ' Filter by Username, ignoring case. If searchTerm is empty, show all.
        Dim filteredList As List(Of UserDetailsDto)

        If String.IsNullOrWhiteSpace(searchTerm) Then
            ' Show everything if there's no search text
            filteredList = _allAdmin
        Else
            filteredList = _allAdmin.
            Where(Function(u)
                      Return u.username IsNot Nothing AndAlso
                             u.username.ToLower().Contains(searchTerm.ToLower())
                  End Function).
            ToList()
        End If

        ' Project or shape the data for display again
        Dim displayData = filteredList.Select(Function(x)
                                                  Dim middleInitial As String = If(String.IsNullOrEmpty(x.middleName), "", x.middleName(0) & ". ")
                                                  Return New With {
                                                  .Username = x.username,
                                                  .FullName = x.firstName & " " & middleInitial & x.lastName & " " & x.suffix,
                                                  .Gender = x.gender,
                                                  .Status = If(x.isActive, "Active", "Inactive")
                                              }
                                              End Function).ToList()

        ' Re-bind to DataGridView
        dgvAdmins.DataSource = Nothing
        dgvAdmins.Rows.Clear()
        dgvAdmins.Columns.Clear()

        dgvAdmins.AutoGenerateColumns = True
        dgvAdmins.DataSource = displayData

        ' Re-add or check for the Action column if needed
        If Not dgvAdmins.Columns.Contains("Action") Then
            Dim actionColumn As New DataGridViewTextBoxColumn() With {.Name = "Action", .HeaderText = "Action"}
            dgvAdmins.Columns.Add(actionColumn)
            dgvAdmins.Columns("Action").DisplayIndex = dgvAdmins.Columns.Count - 1

            ' If you have custom painting for that column:
            AddHandler dgvAdmins.CellPainting, AddressOf dgvAdmin_CellPainting
            AddHandler dgvAdmins.CellClick, AddressOf dgvAdmin_CellClick
        End If
    End Sub

    ' This goes in the same form that has dgvUsers.
    ' The "Handles dgvUsers.CellPainting" part automatically associates this method with dgvUsers' CellPainting event.
    Private Sub dgvUsers_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) _
    Handles dgvUsers.CellPainting

        ' Only draw custom buttons if it's a valid cell and in our "Action" column
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 AndAlso
       dgvUsers.Columns(e.ColumnIndex).Name = "Action" Then

            ' Paint the default cell background (so grid lines or cell bg remain consistent)
            e.PaintBackground(e.CellBounds, True)

            Dim cellRect As Rectangle = e.CellBounds

            ' Divide the cell roughly in half for each button
            Dim halfWidth As Integer = CInt(cellRect.Width / 2)
            Dim buttonWidth As Integer = halfWidth - 4
            Dim buttonHeight As Integer = cellRect.Height - 4

            ' The "View" button (on the left)
            Dim viewRect As New Rectangle(cellRect.X + 2, cellRect.Y + 2, buttonWidth, buttonHeight)
            ' The "Update" button (on the right)
            Dim updateRect As New Rectangle(viewRect.Right + 2, cellRect.Y + 2, buttonWidth, buttonHeight)

            '
            ' 1) Draw the "View" button
            '
            Using brushView As New SolidBrush(Color.FromArgb(74, 158, 255))
                e.Graphics.FillRectangle(brushView, viewRect)
            End Using
            ' Optional: draw a black outline around the button
            e.Graphics.DrawRectangle(Pens.Black, viewRect)

            ' Center the text within the button, respecting a 10px horizontal, 6px vertical padding
            Dim textView As String = "View"
            Dim padHoriz As Integer = 10
            Dim padVert As Integer = 6

            Dim textAreaView As New RectangleF(
            viewRect.X + padHoriz,
            viewRect.Y + padVert,
            viewRect.Width - 2 * padHoriz,
            viewRect.Height - 2 * padVert
        )

            ' Instead of Using f As Font = Me.Font, do this:
            Using f As New Font("Segoe UI", 10, FontStyle.Regular)
                Dim textSize As SizeF = e.Graphics.MeasureString(textView, f)
                Dim textX As Single = textAreaView.X + (textAreaView.Width - textSize.Width) / 2
                Dim textY As Single = textAreaView.Y + (textAreaView.Height - textSize.Height) / 2

                Using textBrush As New SolidBrush(Color.White)
                    e.Graphics.DrawString(textView, f, textBrush, textX, textY)
                End Using
            End Using

            '
            ' 2) Draw the "Update" button
            '
            Using brushUpdate As New SolidBrush(Color.FromArgb(255, 175, 71))
                e.Graphics.FillRectangle(brushUpdate, updateRect)
            End Using

            e.Graphics.DrawRectangle(Pens.Black, updateRect)

            Dim textUpdate As String = "Update"

            Dim textAreaUpdate As New RectangleF(
            updateRect.X + padHoriz,
            updateRect.Y + padVert,
            updateRect.Width - 2 * padHoriz,
            updateRect.Height - 2 * padVert
        )

            ' Instead of Using f As Font = Me.Font, do this:
            Using f As New Font("Segoe UI", 10, FontStyle.Regular)
                Dim textSize As SizeF = e.Graphics.MeasureString(textUpdate, f)
                Dim textX As Single = textAreaUpdate.X + (textAreaUpdate.Width - textSize.Width) / 2
                Dim textY As Single = textAreaUpdate.Y + (textAreaUpdate.Height - textSize.Height) / 2

                Using textBrush As New SolidBrush(Color.Black)
                    e.Graphics.DrawString(textUpdate, f, textBrush, textX, textY)
                End Using
            End Using

            ' Indicate we did our own custom painting for this cell
            e.Handled = True
        End If
    End Sub

    Private Sub dgvAdmin_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) _
    Handles dgvAdmins.CellPainting

        ' Only draw custom buttons if it's a valid cell and in our "Action" column
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 AndAlso
       dgvAdmins.Columns(e.ColumnIndex).Name = "Action" Then

            ' Paint the default cell background (so grid lines or cell bg remain consistent)
            e.PaintBackground(e.CellBounds, True)

            Dim cellRect As Rectangle = e.CellBounds

            ' Divide the cell roughly in half for each button
            Dim halfWidth As Integer = CInt(cellRect.Width / 2)
            Dim buttonWidth As Integer = halfWidth - 4
            Dim buttonHeight As Integer = cellRect.Height - 4

            ' The "View" button (on the left)
            Dim viewRect As New Rectangle(cellRect.X + 2, cellRect.Y + 2, buttonWidth, buttonHeight)
            ' The "Update" button (on the right)
            Dim updateRect As New Rectangle(viewRect.Right + 2, cellRect.Y + 2, buttonWidth, buttonHeight)

            '
            ' 1) Draw the "View" button
            '
            Using brushView As New SolidBrush(Color.FromArgb(74, 158, 255))
                e.Graphics.FillRectangle(brushView, viewRect)
            End Using
            ' Optional: draw a black outline around the button
            e.Graphics.DrawRectangle(Pens.Black, viewRect)

            ' Center the text within the button, respecting a 10px horizontal, 6px vertical padding
            Dim textView As String = "View"
            Dim padHoriz As Integer = 10
            Dim padVert As Integer = 6

            Dim textAreaView As New RectangleF(
            viewRect.X + padHoriz,
            viewRect.Y + padVert,
            viewRect.Width - 2 * padHoriz,
            viewRect.Height - 2 * padVert
        )

            ' Instead of Using f As Font = Me.Font, do this:
            Using f As New Font("Segoe UI", 10, FontStyle.Regular)
                Dim textSize As SizeF = e.Graphics.MeasureString(textView, f)
                Dim textX As Single = textAreaView.X + (textAreaView.Width - textSize.Width) / 2
                Dim textY As Single = textAreaView.Y + (textAreaView.Height - textSize.Height) / 2

                Using textBrush As New SolidBrush(Color.White)
                    e.Graphics.DrawString(textView, f, textBrush, textX, textY)
                End Using
            End Using

            '
            ' 2) Draw the "Update" button
            '
            Using brushUpdate As New SolidBrush(Color.FromArgb(255, 175, 71))
                e.Graphics.FillRectangle(brushUpdate, updateRect)
            End Using

            e.Graphics.DrawRectangle(Pens.Black, updateRect)

            Dim textUpdate As String = "Update"

            Dim textAreaUpdate As New RectangleF(
            updateRect.X + padHoriz,
            updateRect.Y + padVert,
            updateRect.Width - 2 * padHoriz,
            updateRect.Height - 2 * padVert
        )

            ' Instead of Using f As Font = Me.Font, do this:
            Using f As New Font("Segoe UI", 10, FontStyle.Regular)
                Dim textSize As SizeF = e.Graphics.MeasureString(textUpdate, f)
                Dim textX As Single = textAreaUpdate.X + (textAreaUpdate.Width - textSize.Width) / 2
                Dim textY As Single = textAreaUpdate.Y + (textAreaUpdate.Height - textSize.Height) / 2

                Using textBrush As New SolidBrush(Color.Black)
                    e.Graphics.DrawString(textUpdate, f, textBrush, textX, textY)
                End Using
            End Using

            ' Indicate we did our own custom painting for this cell
            e.Handled = True
        End If
    End Sub

    Private Sub dgvAdmin_CellClick(sender As Object, e As DataGridViewCellEventArgs)


        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            If dgvAdmins.Columns(e.ColumnIndex).Name = "Action" Then
                ' Get the bounding rectangle of the clicked cell.
                Dim cellRect As Rectangle = dgvAdmins.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, False)
                Dim halfWidth As Integer = CInt(cellRect.Width / 2)
                Dim buttonWidth As Integer = halfWidth - 4
                Dim buttonHeight As Integer = cellRect.Height - 6

                ' Recreate the same rectangles from CellPainting
                Dim viewRect As New Rectangle(cellRect.X + 2, cellRect.Y + 2, buttonWidth, buttonHeight)
                Dim updateRect As New Rectangle(cellRect.X + 2 + buttonWidth + 2, cellRect.Y + 2, buttonWidth, buttonHeight)

                ' Convert the mouse position to DataGridView coordinates
                Dim clickPoint As Point = dgvAdmins.PointToClient(Cursor.Position)

                ' Check if the user clicked inside the "View" button
                If viewRect.Contains(clickPoint) Then
                    ' TODO: Your "View" logic (open details form, etc.)
                    MessageBox.Show($"View clicked on row {e.RowIndex}.")

                    ' Check if the user clicked inside the "Update" button
                ElseIf updateRect.Contains(clickPoint) Then
                    ' TODO: Your "Update" logic (open edit form, etc.)
                    MessageBox.Show($"Update clicked on row {e.RowIndex}.")
                End If
            End If
        End If
    End Sub

    Private Sub dgvUsers_CellClick(sender As Object, e As DataGridViewCellEventArgs)


        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            If dgvUsers.Columns(e.ColumnIndex).Name = "Action" Then
                ' Get the bounding rectangle of the clicked cell.
                Dim cellRect As Rectangle = dgvUsers.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, False)
                Dim halfWidth As Integer = CInt(cellRect.Width / 2)
                Dim buttonWidth As Integer = halfWidth - 4
                Dim buttonHeight As Integer = cellRect.Height - 6

                ' Recreate the same rectangles from CellPainting
                Dim viewRect As New Rectangle(cellRect.X + 2, cellRect.Y + 2, buttonWidth, buttonHeight)
                Dim updateRect As New Rectangle(cellRect.X + 2 + buttonWidth + 2, cellRect.Y + 2, buttonWidth, buttonHeight)

                ' Convert the mouse position to DataGridView coordinates
                Dim clickPoint As Point = dgvUsers.PointToClient(Cursor.Position)

                ' Check if the user clicked inside the "View" button
                If viewRect.Contains(clickPoint) Then
                    ' TODO: Your "View" logic (open details form, etc.)
                    MessageBox.Show($"View clicked on row {e.RowIndex}.")

                    ' Check if the user clicked inside the "Update" button
                ElseIf updateRect.Contains(clickPoint) Then
                    ' TODO: Your "Update" logic (open edit form, etc.)
                    MessageBox.Show($"Update clicked on row {e.RowIndex}.")
                End If
            End If
        End If
    End Sub

    Private Sub Reload_Data()
        LoadAllResidence()
        LoadAllAdmin()
    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        FilterByUsernameResidents(searchResident.Text.Trim())
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        FilterByUsernameResidents("")
    End Sub

    Private Sub searchBtn_Click(sender As Object, e As EventArgs) Handles searchBtn.Click
        FilterByUsernameAdmin(searchAdmin.Text.Trim())
    End Sub

    Private Sub clearBtn_Click(sender As Object, e As EventArgs) Handles clearBtn.Click
        FilterByUsernameAdmin("")
    End Sub
End Class