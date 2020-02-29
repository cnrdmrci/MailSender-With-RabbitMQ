using MailSender.Model;

namespace MailSender.Abstract
{
    public interface IMailKontrolcu
    {
        bool MailAdresiKontrolEt(MailBilgi mailBilgi);
    }
}
