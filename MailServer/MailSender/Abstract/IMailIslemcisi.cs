using MailSender.Model;

namespace MailSender.Abstract
{
    internal interface IMailIslemcisi
    {
        void MailGonderimiYap(MailBilgi mailBilgi,ISmtpAyarlayan smtpAyarlayan);
    }
}
