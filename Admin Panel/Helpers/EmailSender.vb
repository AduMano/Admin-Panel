Imports System.Net
Imports System.Net.Mail
Imports System.Text

Public Class EmailSender
    ''' <summary>
    ''' Sends a password reset verification code to the admin.
    ''' </summary>
    ''' <param name="adminEmail">Admin's email address.</param>
    ''' <param name="verificationCode">The 6-digit verification code.</param>
    ''' <param name="adminName">Admin's name (optional, default is "Admin").</param>
    Public Shared Sub SendAdminResetEmail(adminEmail As String, verificationCode As String, Optional adminName As String = "Admin")
        Try
            ' Load credentials (Replace these with secure environment variables)
            Dim emailAddress As String = "ums.grp5@gmail.com"
            Dim emailPassword As String = "jwzq kaez hynp ejta"

            ' Setup SMTP Client
            Dim client As New SmtpClient("smtp.gmail.com", 587)
            client.EnableSsl = True
            client.UseDefaultCredentials = False
            client.Credentials = New NetworkCredential(emailAddress, emailPassword)

            ' Create email message
            Dim mailMessage As New MailMessage()
            mailMessage.From = New MailAddress(emailAddress)
            mailMessage.To.Add(adminEmail)
            mailMessage.Subject = "Password Reset Request - Verification Code"
            mailMessage.IsBodyHtml = True

            ' Construct email body for password reset
            Dim mailBody As New StringBuilder()
            mailBody.AppendFormat("
            <div style='font-family: Arial, sans-serif; max-width: 600px; margin: auto; padding: 20px; border: 1px solid #ddd; border-radius: 10px; background-color: #f9f9f9;'>
                <h2 style='color: #2C3E50; text-align: center;'>Admin Password Reset</h2>
                <p style='font-size: 16px; color: #555;'>Hello, {0}!</p>
                <p style='font-size: 16px; color: #555;'>We received a request to reset your password.</p>

                <p style='font-size: 16px; color: #555;'>Here is your 6-digit verification code:</p>

                <div style='text-align: center; font-size: 24px; font-weight: bold; color: #E74C3C; padding: 10px; background: #FFF3CD; border-radius: 5px;'>
                    {1}
                </div>

                <p style='font-size: 16px; color: #555;'>Please enter this code within <strong>10 minutes</strong> to reset your password.</p>
                <p style='font-size: 16px; color: #555;'>If you did <strong>not</strong> request a password reset, please ignore this email.</p>
                <p style='font-size: 16px; color: #555;'>Best regards,</p>
                <p style='font-size: 16px; color: #555;'><strong>LOCKBOX INNOVATORS</strong></p>

                <p style='text-align: center; font-size: 14px; color: #888;'>This is an automated message. Please do not reply.</p>
            </div>", adminName, verificationCode)

            mailMessage.Body = mailBody.ToString()

            ' Send the email
            client.Send(mailMessage)
            Console.WriteLine("Password reset email sent successfully to admin: " & adminEmail)

        Catch ex As Exception
            Console.WriteLine("Error sending email: " & ex.Message)
        End Try
    End Sub
End Class
