﻿using System.Net.Mail;

namespace MailSender.Abstract
{
    internal interface ISmtpAyarlayan
    {
        SmtpClient SmtpClientBilgiGetir();
    }
}
