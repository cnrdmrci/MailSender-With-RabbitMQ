using System;
using System.Collections.Generic;
using System.Text;
using MailServerProject.Model;

namespace MailServerProject.Abstract
{
    public interface ISmtpAyarlayan
    {
        SmtpAyar SmtpAyarGetir();
    }
}
