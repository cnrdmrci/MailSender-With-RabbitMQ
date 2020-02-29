using MailSender.Model;

namespace MailSender.Abstract
{
    public interface IVeritabaniIslemcisi
    {
        void BasariliGonderimKaydet(MailBilgi mailBilgi);
        void HataliGonderimKaydet(MailBilgi mailBilgi,string mesaj);
    }
}
