using System.Net;
using System.Net.Mail;

namespace Application.Services;

public class EmailService
{
    private const string SmtpServer = "smtp.your-email-provider.com"; // SMTP-сервер (например, smtp.gmail.com)
    private const int SmtpPort = 587; // 587 (TLS) или 465 (SSL)
    private const string SenderEmail = "your-email@example.com"; // Почта, с которой отправляем
    private const string SenderPassword = "your-email-password"; // Пароль (или App Password, если это Gmail)
    
    public async Task<string> SendVerificationCodeAsync(string recipientEmail)
    {
        string token = GenerateToken();
        string subject = "Ваш код подтверждения";
        string body = $"Ваш код подтверждения: {token}\n\nВведите его в приложении для завершения верификации.";

        using (var client = new SmtpClient(SmtpServer, SmtpPort))
        {
            client.Credentials = new NetworkCredential(SenderEmail, SenderPassword);
            client.EnableSsl = true; // Используем SSL

            var message = new MailMessage(SenderEmail, recipientEmail, subject, body);
            await client.SendMailAsync(message);
        }

        Console.WriteLine($"Код {token} отправлен на {recipientEmail}");
        return token;
    }

    private string GenerateToken()
    {
        Random rnd = new Random();
        return rnd.Next(100000, 999999).ToString();
    }
}