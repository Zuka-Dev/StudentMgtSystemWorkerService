using Models;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Services.Helper
{
    public class EmailService : IEmailService
    {
        public async Task SendEmail(string from, Student student)
        {
            //Get Template
            var mail = new MailMessage(from, student.Email);
            mail.Subject = "Sample Subject - Thank you";
            mail.IsBodyHtml = true;
            var body = await File.ReadAllTextAsync("template.html");
            body = body.Replace("[FirstName]", student.FirstName);
            body = body.Replace("[RegistrationNumber]", student.RegistrationNumber);
            mail.Body = body;

           
            using var smtp = new SmtpClient(host:"" , port: 587);
            smtp.Credentials = new NetworkCredential(userName: "", password:"");
            smtp.EnableSsl = true;
            await smtp.SendMailAsync(mail);

        }
    }
}
