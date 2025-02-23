Imports System.Text.RegularExpressions

Public Class InputValidator
    ''' <summary>
    ''' Validates a text input based on the provided rules.
    ''' </summary>
    ''' <param name="textBox">The TextBox control containing user input.</param>
    ''' <param name="fieldName">The name of the field (for error messages).</param>
    ''' <param name="minLength">Minimum length allowed (0 to ignore).</param>
    ''' <param name="maxLength">Maximum length allowed (0 to ignore).</param>
    ''' <param name="allowEmpty">Whether empty input is allowed.</param>
    ''' <param name="validationType">Type of validation (e.g., "LettersOnly", "NumbersOnly", "Alphanumeric", "Email", "Custom").</param>
    ''' <param name="customRegex">Optional regex pattern for custom validation.</param>
    ''' <returns>An error message if validation fails; otherwise, an empty string.</returns>
    Public Shared Function ValidateInput(value As String, fieldName As String,
                                         Optional minLength As Integer = 0,
                                         Optional maxLength As Integer = 0,
                                         Optional allowEmpty As Boolean = False,
                                         Optional validationType As String = "None",
                                         Optional customRegex As String = "") As String
        Dim input As String = value.Trim() ' Trim whitespace

        ' 🛑 Rule 1: Empty Check
        If String.IsNullOrWhiteSpace(input) Then
            If Not allowEmpty Then
                Return $"{fieldName} cannot be empty."
            End If
            Return "" ' Skip further validation if empty is allowed
        End If

        ' 🛑 Rule 2: Length Validation
        If minLength > 0 AndAlso input.Length < minLength Then
            Return $"{fieldName} must be at least {minLength} characters long."
        End If
        If maxLength > 0 AndAlso input.Length > maxLength Then
            Return $"{fieldName} must not exceed {maxLength} characters."
        End If

        ' 🛑 Rule 3: Type Validation
        Select Case validationType.ToLower()
            Case "lettersonly"
                If Not Regex.IsMatch(input, "^[A-Za-z\s]+$") Then
                    Return $"{fieldName} must contain only letters."
                End If

            Case "numbersonly"
                If Not Regex.IsMatch(input, "^\d+$") Then
                    Return $"{fieldName} must contain only numbers."
                End If

            Case "alphanumeric"
                If Not Regex.IsMatch(input, "^[A-Za-z0-9\s]+$") Then
                    Return $"{fieldName} must contain only letters and numbers."
                End If

            Case "email"
                Dim emailPattern As String = "^[^@\s]+@[^@\s]+\.[^@\s]+$"
                If Not Regex.IsMatch(input, emailPattern) Then
                    Return $"{fieldName} must be a valid email address."
                End If

            Case "custom"
                If Not String.IsNullOrEmpty(customRegex) AndAlso Not Regex.IsMatch(input, customRegex) Then
                    Return $"{fieldName} is not in the correct format."
                End If
        End Select

        ' ✅ If everything is valid, return an empty string (no errors)
        Return ""
    End Function
End Class
