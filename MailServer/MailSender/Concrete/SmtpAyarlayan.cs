using System.Net;
using System.Net.Mail;
using MailSender.Abstract;
using MailSender.Model;

namespace MailSender.Concrete
{
    internal class SmtpAyarlayan :ISmtpAyarlayan
    {
        private SmtpAyar _smtpAyar;
        private SmtpAyar smtpAyarGetir()
        {
            //Veritabanindan al.
            //Singleton olarak tasarla.
            _smtpAyar = new SmtpAyar();
            _smtpAyar.Host = "smtp.gmail.com";
            _smtpAyar.Port = 587;
            _smtpAyar.KullaniciAdi = "";
            _smtpAyar.Sifre = "";
            _smtpAyar.SslKullan = true;
            _smtpAyar.Unvan = "test unvan";

            return _smtpAyar;
        }



        public SmtpClient SmtpClientBilgiGetir()
        {
            SmtpAyar smtpAyar = smtpAyarGetir();
            
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = smtpAyar.Host;
            smtpClient.Port = smtpAyar.Port;
            smtpClient.EnableSsl = smtpAyar.SslKullan;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(smtpAyar.KullaniciAdi,smtpAyar.Sifre);
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            //smtpClient.Timeout = 3000;

            return smtpClient;
        }

        public string GonderenMailBilgisiGetir()
        {
            return _smtpAyar.KullaniciAdi;
        }

        public string GonderenUnvanBilgisiGetir()
        {
            return _smtpAyar.Unvan;
        }
    }
}
