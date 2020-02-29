using MailSender.Model;

namespace MailSender.Abstract
{
    internal interface IVeritabaniIslemcisi
    {
        void BasariliGonderimKaydet(MailBilgi mailBilgi);
        void HataliGonderimKaydet(MailBilgi mailBilgi,string mesaj);
    }
}
