using System;
using System.Collections.Generic;
using System.Text;
using MailServerProject.Abstract;

namespace MailServerProject.Concrete
{
    public class MailGonderen
    {
        private IMailIslemcisi _mailIslemcisi;
        private ISmtpAyarlayan _smtpAyarlayan;
        private IVeritabaniIslemcisi _veritabaniIslemcisi;
        private IMailKontrolcu _mailKontrolcu;
        public MailGonderen(IMailIslemcisi mailIslemcisi, ISmtpAyarlayan smtpAyarlayan, IVeritabaniIslemcisi veritabaniIslemcisi, IMailKontrolcu mailKontrolcu)
        {
            _mailIslemcisi = mailIslemcisi;
            _smtpAyarlayan = smtpAyarlayan;
            _veritabaniIslemcisi = veritabaniIslemcisi;
            _mailKontrolcu = mailKontrolcu;
        }
    }
}
