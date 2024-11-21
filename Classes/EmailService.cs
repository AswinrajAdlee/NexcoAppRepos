using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NexcoApp.Classes;
using MimeKit;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;

namespace NexcoApp.Classes
{
    public class EmailService
    {
        public string ?email;
        public async Task sendEmail(string userEmail, string verificationToken)
        {
            try
            {
                // Create a unique verification URL
                string verificationUrl = $"https://yourdomain.com/verify-email?token={verificationToken}";

                // Set up the SMTP client (Gmail example)
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("NexcoNetTest@gmail.com", "iiix vdwv yysk qqkh"), // Use environment variables or secure storage for credentials
                    EnableSsl = true,
                };

                // Create the email message
                var mailMessage = new MailMessage
                {
                    From = new MailAddress("your-email@gmail.com"),
                    Subject = "Nexco Networks Email Verification",
                    Body = $"Your six characer verification code is: {verificationToken}",
                    IsBodyHtml = false
                };

                mailMessage.To.Add(userEmail);

                // Send the email asynchronously
                await smtpClient.SendMailAsync(mailMessage);

                Console.WriteLine("Verification email sent successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to send verification email: {ex.Message}");
            }
        }

        public void verifyEmail (string userEmail)
        {

        }

        public string generateEmailVerificationToken(int length = 6)
        {
            const string validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            char[] token = new char[length];

            for (int i = 0; i < length; i++)
            {
                token[i] = validChars[random.Next(validChars.Length)];
            }

            return new string(token);
        }
        

    }
}
