﻿using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using MailServerProject.Model;

namespace MailServerProject.Abstract
{
    public interface ISmtpAyarlayan
    {
        SmtpClient SmtpClientBilgiGetir();
    }
}
