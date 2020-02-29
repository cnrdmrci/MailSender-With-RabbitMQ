using MailSender.Abstract;
using MailSender.Model;

namespace MailSender.Concrete
{
    internal class VeritabaniIletisimcisi : IVeritabaniIslemcisi
    {
        public void BasariliGonderimKaydet(MailBilgi mailBilgi)
        {
            //throw new NotImplementedException();
        }

        public void HataliGonderimKaydet(MailBilgi mailBilgi, string mesaj)
        {
            //throw new NotImplementedException();
        }
    }
}
