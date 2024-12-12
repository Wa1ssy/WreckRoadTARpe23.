﻿using Microsoft.Extensions.Configuration;
using MimeKit;
using MailKit.Net.Smtp;
using System.Net.Mail;
using WreckRoad.Core.Dto;
using WreckRoad.Core.ServiceInterface;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace WreckRoad.ApplicationServices.Services
{
    public class EmailsServices : IEmailsServices
    {
        private readonly IConfiguration _configuration;

        public EmailsServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public void SendEmail(EmailDto dto)
        {
            var email = new MimeMessage();

            _configuration.GetSection("EmailUserName").Value = "allanlond23";
            _configuration.GetSection("EmailHost").Value = "smtp.gmail.com";
            _configuration.GetSection("EmailPassword").Value = "rake nlmk outz dbqh";


            email.From.Add(MailboxAddress.Parse(_configuration.GetSection("EmailUserName").Value));
            email.To.Add(MailboxAddress.Parse(dto.To));
            email.Subject = dto.Subject;
            var builder = new BodyBuilder
            {
                HtmlBody = dto.Body,
            };

            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(_configuration.GetSection("EmailHost").Value, 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(_configuration.GetSection("EmailUserName").Value, _configuration.GetSection("EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
        public void SendEmailToken(EmailTokenDto dto, string token)
        {
            dto.Token = token;
            var email = new MimeMessage();
            _configuration.GetSection("EmailUserName").Value = "allanlond23";
            _configuration.GetSection("EmailHost").Value = "smtp.gmail.com";
            _configuration.GetSection("EmailPassword").Value = "rake nlmk outz dbqh";
            email.From.Add(MailboxAddress.Parse(_configuration.GetSection("EmailUserName").Value));
            email.To.Add(MailboxAddress.Parse(dto.To));
            email.Subject = dto.Subject;
            var builder = new BodyBuilder
            {
                HtmlBody = dto.Body += dto.Token,
            };
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(_configuration.GetSection("EmailHost").Value, 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(_configuration.GetSection("EmailUserName").Value, _configuration.GetSection("EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
