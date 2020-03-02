using System.Net.Mail;
using MailSender.Abstract;
using MailSender.Model;

namespace MailSender.Concrete
{
    internal class MailIslemcisi : IMailIslemcisi
    {
        public void MailGonderimiYap(MailBilgi mailBilgi, ISmtpAyarlayan smtpAyarlayan)
        {
            SmtpClient smtpClient = smtpAyarlayan.SmtpClientBilgiGetir();
            MailMessage ePosta = new MailMessage();

            //mail gonderecek hesap.
            ePosta.From = new MailAddress(smtpAyarlayan.GonderenMailBilgisiGetir(),smtpAyarlayan.GonderenUnvanBilgisiGetir()); 

            //mail gonderilecek e-posta adresleri.
            mailBilgi.GonderilecekEpostaAdresleri.ForEach(x =>{ePosta.To.Add(x);});

            //Bilgilendirme olarak eklenecek mail adresleri.
            mailBilgi.CcEpostaAdresleri?.ForEach(x =>{ePosta.CC.Add(x);});

            //Gizli olarak eklenecek mail adresleri.
            mailBilgi.BccEpostaAdresleri?.ForEach(x =>{ePosta.Bcc.Add(x);});

            //mailin konusu.
            ePosta.Subject = mailBilgi.Konu;

            //mail icerigi html olarak gonderilsin.
            ePosta.IsBodyHtml = true;

            //mail icerigi.
            ePosta.Body = mailBilgi.Icerik;
            // ekleri temizledik.
            ePosta.Attachments.Clear();

            //mail ek dosyalari eklendi.
            mailBilgi.EklenecekDosyaAdresleri?.ForEach(x =>{ePosta.Attachments.Add(new Attachment(x));});

            //Mail gonderiliyor.
            smtpClient.Send(ePosta);
        }
    }
}
