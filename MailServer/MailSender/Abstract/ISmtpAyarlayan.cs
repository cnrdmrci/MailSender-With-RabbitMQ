﻿using System.Net.Mail;

namespace MailSender.Abstract
{
    public interface ISmtpAyarlayan
    {
        SmtpClient SmtpClientBilgiGetir();
        string GonderenMailBilgisiGetir();
        string GonderenUnvanBilgisiGetir();
    }
}
