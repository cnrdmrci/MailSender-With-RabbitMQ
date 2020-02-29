using MailSender.Model;

namespace MailSender.Abstract
{
    public interface IMailIslemcisi
    {
        void MailGonderimiYap(MailBilgi mailBilgi,ISmtpAyarlayan smtpAyarlayan);
    }
}
