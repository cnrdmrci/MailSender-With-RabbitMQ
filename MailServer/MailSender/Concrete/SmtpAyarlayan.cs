using System.Net;
using System.Net.Mail;
using MailSender.Abstract;
using MailSender.Model;

namespace MailSender.Concrete
{
    public class SmtpAyarlayan :ISmtpAyarlayan
    {
        private SmtpAyar smtpAyarGetir()
        {
            //Veritabanindan al.
            //Singleton olarak tasarla.
            SmtpAyar smtpAyar = new SmtpAyar();
            smtpAyar.Host = "smtp.gmail.com";
            smtpAyar.Port = 587;
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
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(smtpAyar.KullaniciAdi,smtpAyar.Sifre);
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            //smtpClient.Timeout = 3000;

            return smtpClient;
        }
    }
}
