using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using RestaurantSystem.Interfaces;

namespace RestaurantSystem.Services;

internal class EmailService(string password) : IEmailService
{
    public void SendEmail(string to, string subject, string body)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("Restaurant", "haroldas.zalg@gmail.com"));
        message.To.Add(new MailboxAddress("", to));
        message.Subject = subject;
        message.Body = new TextPart("plain")
        {
            Text = body
        };

        SendEmail(message);
    }

    private void SendEmail(MimeMessage message)
    {
        using (var client = new SmtpClient())
        {
            client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            client.Authenticate("haroldas.zalg@gmail.com", password);
            client.Send(message);
            client.Disconnect(true);
        }
    }

}