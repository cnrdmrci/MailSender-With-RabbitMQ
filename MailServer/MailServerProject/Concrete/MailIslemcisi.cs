using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using MailServerProject.Abstract;
using MailServerProject.Model;

namespace MailServerProject.Concrete
{
    public class MailIslemcisi : IMailIslemcisi
    {
        public void MailGonderimiYap(MailBilgi mailBilgi, ISmtpAyarlayan smtpAyarlayan)
        {
            SmtpClient smtpClient = smtpAyarlayan.SmtpClientBilgiGetir();

            MailMessage ePosta = new MailMessage();
            ePosta.From = new MailAddress(mailBilgi.Kimden,mailBilgi.KimdenUnvan); //mail gonderecek hesap.
            ePosta.To.Add(mailBilgi.Kime); //mail gonderilecek adres.
            //ePosta.CC.Add(""); //Bilgi olarak eklenecek mail adreslerini tutar.
            //ePosta.Bcc.Add(""); //Gizli olarak eklenecek mail adreslerini turar.
            ePosta.Subject = mailBilgi.Konu; //mailin konusu.
            ePosta.IsBodyHtml = true; //mail icerigi html olarak gonderilsin.
            ePosta.Body = mailBilgi.Icerik; //mail icerigi.
            ePosta.Attachments.Clear(); // ekleri temizledik.
            //ePosta.Attachments.Add(new Attachment("")); // mail ek dosya ekledik.

            smtpClient.Send(ePosta);
        }
    }
}
