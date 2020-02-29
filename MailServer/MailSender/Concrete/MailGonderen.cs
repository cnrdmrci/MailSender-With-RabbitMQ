using System;
using System.Collections.Generic;
using MailSender.Abstract;
using MailSender.Model;

namespace MailSender.Concrete
{
    internal class MailGonderen
    {
        private IMailIslemcisi _mailIslemcisi;
        private ISmtpAyarlayan _smtpAyarlayan;
        private IVeritabaniIslemcisi _veritabaniIslemcisi;
        private IMailKontrolcu _mailKontrolcu;
        internal MailGonderen(IMailIslemcisi mailIslemcisi, ISmtpAyarlayan smtpAyarlayan, IVeritabaniIslemcisi veritabaniIslemcisi, IMailKontrolcu mailKontrolcu)
        {
            _mailIslemcisi = mailIslemcisi;
            _smtpAyarlayan = smtpAyarlayan;
            _veritabaniIslemcisi = veritabaniIslemcisi;
            _mailKontrolcu = mailKontrolcu;
        }

        public MailGonderimSonuc Gonder(MailBilgi mailBilgi)
        {
            MailGonderimSonuc mailGonderimSonuc = new MailGonderimSonuc();
            mailGonderimSonuc.Hatalar = new List<string>();
            try
            {
                //Bilgi kontrol et hataliysa logla ve basarisiz don.
                mailGonderimSonuc = bilgiKontroluYap(mailBilgi, mailGonderimSonuc);
                if (!mailGonderimSonuc.Basarili)
                    return mailGonderimSonuc;

                //mail gonderimi yap. exception alinmazsa basarilidir.
                _mailIslemcisi.MailGonderimiYap(mailBilgi,_smtpAyarlayan);

                //Gönderim başarılı
                mailGonderimSonuc.Basarili = true;
                _veritabaniIslemcisi.BasariliGonderimKaydet(mailBilgi);
                return mailGonderimSonuc;

            }
            catch (Exception ex)
            {
                mailGonderimSonuc.Hatalar.Add(ex.Message);
                _veritabaniIslemcisi.HataliGonderimKaydet(mailBilgi,mailGonderimSonuc.HatalarStr);
                mailGonderimSonuc.Basarili = false;
                return mailGonderimSonuc;
            }

        }

        private MailGonderimSonuc bilgiKontroluYap(MailBilgi mailBilgi,MailGonderimSonuc mailGonderimSonuc)
        {
            if (!_mailKontrolcu.MailAdresiKontrolEt(mailBilgi))
            {
                mailGonderimSonuc.Hatalar.Add("Mail adresi hatalı, lütfen kontrol edin.");
                _veritabaniIslemcisi.HataliGonderimKaydet(mailBilgi, "Mail adresi hatalı, lütfen kontrol edin.");
                mailGonderimSonuc.Basarili = false;
            }

            return mailGonderimSonuc;
        }
    }
}
