using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using MailServerProject.Abstract;
using MailServerProject.Model;

namespace MailServerProject.Concrete
{
    public class SmtpAyarlayan :ISmtpAyarlayan
    {
        private SmtpAyar smtpAyarGetir()
        {
            //Veritabanindan al.
            //Singleton olarak tasarla.
            SmtpAyar smtpAyar = new SmtpAyar();
            smtpAyar.Host = "";
            smtpAyar.Port = 0;
            smtpAyar.KullaniciAdi = "";
            smtpAyar.Sifre = "";
            smtpAyar.SslKullan = true;

            return smtpAyar;
        }


        public SmtpClient SmtpClientBilgiGetir()
        {
            SmtpAyar smtpAyar = smtpAyarGetir();
            
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = smtpAyar.Host;
            smtpClient.Port = smtpAyar.Port;
            smtpClient.EnableSsl = smtpAyar.SslKullan;
            smtpClient.Credentials = new NetworkCredential(smtpAyar.KullaniciAdi,smtpAyar.Sifre);

            return smtpClient;
        }
    }
}
