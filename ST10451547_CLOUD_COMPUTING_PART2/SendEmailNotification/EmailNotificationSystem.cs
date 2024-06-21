using ST10451547_CLOUD_COMPUTING_PART2.Data.Entities;
using System.Net.Mail;

namespace ST10451547_CLOUD_COMPUTING_PART2.SendEmailNotification
{
    public static class EmailNotificationSystem
    {
        // Static configuration fields
        private static readonly int smtp_port = 465;
        private static readonly string smtp_host = "mail.iehoringsecurity.co.za";
        private static readonly string smtp_username = "gaven@iehoringsecurity.co.za"; // Replace with your Gmail address
        private static readonly string smtp_password = "Kutlwano_23#"; // Replace with your App Password
        private static readonly string smtp_from_email = "gaven@iehoringsecurity.co.za"; // Replace with your Gmail address
        private static readonly bool smtp_enable_ssl = true;

        // Static method to send test email
        public static bool SendOrderTest(Order order)
        {
            // Initialize result flag
            bool success = true;

            // Loop through each user in the list
        
                try
                {
                    // Configure the SMTP client
                    using (SmtpClient smtpClient = new SmtpClient())
                    {
                        smtpClient.Port = smtp_port;
                        smtpClient.Host = smtp_host;
                        smtpClient.Credentials = new System.Net.NetworkCredential(smtp_username, smtp_password);
                        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtpClient.EnableSsl = smtp_enable_ssl;
                        smtpClient.Timeout = 15000;

                        // Create the mail message
                        MailMessage mail = new MailMessage
                        {
                            Subject = "Test email from PayMarker",
                            IsBodyHtml = true,
                            From = new MailAddress(smtp_from_email),
                            Body = $"<b>Dear {order.UserFriendlyOrderCode},</b><br>Note that our products have been updated."
                        };

                        // Add the user's email address
                        mail.To.Add(new MailAddress(smtp_from_email));

                        // Delivery notifications
                        mail.DeliveryNotificationOptions =
                          DeliveryNotificationOptions.OnFailure |
                          DeliveryNotificationOptions.OnSuccess |
                          DeliveryNotificationOptions.Delay;

                        mail.Headers.Add("Disposition-Notification-To", "gavenomojahi@gmail.com");

                        // Send the email
                        smtpClient.Send(mail);
                    }
                }
                catch (Exception ex)
                {
                    // Handle exception (log error)
                    // Log the error message or handle it appropriately
                    Console.WriteLine($"Failed to send email to {smtp_from_email}. Error: {ex.Message}");

                    // Update success flag
                    success = false;
                }
        

            // Return overall success status
            return success;
        }



        public static bool SendToAllUsers(List<User> users)
        {
            // Initialize result flag
            bool success = true;

            // Loop through each user in the list
            foreach (var user in users)
            {
                try
                {
                    // Configure the SMTP client
                    using (SmtpClient smtpClient = new SmtpClient())
                    {
                        smtpClient.Port = smtp_port;
                        smtpClient.Host = smtp_host;
                        smtpClient.Credentials = new System.Net.NetworkCredential(smtp_username, smtp_password);
                        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtpClient.EnableSsl = smtp_enable_ssl;
                        smtpClient.Timeout = 15000;

                        // Create the mail message
                        MailMessage mail = new MailMessage
                        {
                            Subject = "Test email from PayMarker",
                            IsBodyHtml = true,
                            From = new MailAddress(smtp_from_email),
                            Body = $"<b>Dear {user.Lastname},</b><br>Note that your product has been updated."
                        };

                        // Add the user's email address
                        mail.To.Add(new MailAddress(user.EmailAddress));

                        // Delivery notifications
                        mail.DeliveryNotificationOptions =
                          DeliveryNotificationOptions.OnFailure |
                          DeliveryNotificationOptions.OnSuccess |
                          DeliveryNotificationOptions.Delay;

                        mail.Headers.Add("Disposition-Notification-To", "gavenomojahi@gmail.com");

                        // Send the email
                        smtpClient.Send(mail);
                    }
                }
                catch (Exception ex)
                {
                    // Handle exception (log error)
                    // Log the error message or handle it appropriately
                    Console.WriteLine($"Failed to send email to {user.EmailAddress}. Error: {ex.Message}");

                    // Update success flag
                    success = false;
                }
            }

            // Return overall success status
            return success;
        }

    }

}
