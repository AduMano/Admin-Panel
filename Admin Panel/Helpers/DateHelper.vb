Public Class DateHelper
    ''' <summary>
    ''' Converts a string to a date object.
    ''' </summary>
    ''' <param name="dateString">The date string to convert.</param>
    ''' <param name="format">The format of the date string.</param>
    ''' <returns>A date object if successful; otherwise, Nothing.</returns>
    Public Shared Function Convert(dateString As String) As String
        Dim dt As DateTime = DateTime.Parse(dateString)

        ' Format the date as "February 13, 2025 - 11:28 PM"
        Dim formattedString As String = dt.ToString("hh:mm tt - MMMM dd, yyyy")
        Return formattedString
    End Function

    Public Shared Function Convert_String_to_Date(dateString As String) As String
        ' Passing string date in here that converts to 02/23/2025 : 08:33 AM
        Dim dt As DateTime = DateTime.Parse(dateString)

        ' Format the date as "02/23/2025 : 08:33 AM"
        Dim formattedString As String = dt.ToString("MM/dd/yyyy : hh:mm tt")
        Return formattedString
    End Function
End Class
