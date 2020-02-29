using MailSender.Model;

namespace MailSender.Abstract
{
    internal interface IMailKontrolcu
    {
        bool MailAdresiKontrolEt(MailBilgi mailBilgi);
    }
}
