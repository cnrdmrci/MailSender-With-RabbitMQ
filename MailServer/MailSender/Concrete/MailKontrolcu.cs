using MailSender.Abstract;
using MailSender.Model;

namespace MailSender.Concrete
{
    internal class MailKontrolcu : IMailKontrolcu
    {
        public bool MailAdresiKontrolEt(MailBilgi mailBilgi)
        {
            return true; //mail gecerli var sayalim. kontroller eklenecek.
        }
    }
}
