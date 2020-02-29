using MailSender.Abstract;
using MailSender.Model;

namespace MailSender.Concrete
{
    public class VeritabaniIletisimcisi : IVeritabaniIslemcisi
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
