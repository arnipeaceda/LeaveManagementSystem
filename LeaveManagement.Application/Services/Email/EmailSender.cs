using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Net.Mail;
using System.Text.Encodings.Web;

namespace LeaveManagementSystem.Services.Email
{
    public class EmailSender(IConfiguration _configuration, IWebHostEnvironment _hostEnvironment)
        : IEmailSender<ApplicationUser>
    {
        public Task SendConfirmationLinkAsync(ApplicationUser user, string email, string confirmationLink)
        {
            var messageContent = $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(confirmationLink)}'>clicking here</a>.";
            var body = BuildEmailBody(user, messageContent);
            return SendEmailAsync(email, "Confirm your email", body);
        }

        public Task SendPasswordResetLinkAsync(ApplicationUser user, string email, string resetLink)
        {
            var messageContent = $"Please reset your password by <a href='{HtmlEncoder.Default.Encode(resetLink)}'>clicking here</a>.";
            var body = BuildEmailBody(user, messageContent);
            return SendEmailAsync(email, "Reset your password", body);
        }

        public Task SendPasswordResetCodeAsync(ApplicationUser user, string email, string resetCode)
        {
            var messageContent = $"Your password reset code is: {resetCode}";
            var body = BuildEmailBody(user, messageContent);
            return SendEmailAsync(email, "Reset your password", body);
        }

        private string BuildEmailBody(ApplicationUser user, string messageContent)
        {
            var emailTemplatePath = Path.Combine(_hostEnvironment.WebRootPath, "templates", "email_layout.html");
            var template = File.ReadAllText(emailTemplatePath);

            return template
                .Replace("{UserName}", $"{user.FirstName} {user.LastName}")
                .Replace("{MessageContent}", messageContent);
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var fromAddress = _configuration["EmailSettings:DefaultEmailAddress"]
                ?? throw new InvalidOperationException("EmailSettings:DefaultEmailAddress is not configured.");
            var smtpServer = _configuration["EmailSettings:Server"];
            var smtpPort = Convert.ToInt32(_configuration["EmailSettings:Port"]);
            var message = new MailMessage
            {
                From = new MailAddress(fromAddress),
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true
            };

            message.To.Add(new MailAddress(email));

            using var client = new SmtpClient(smtpServer, smtpPort);
            await client.SendMailAsync(message);
        }
    }
}