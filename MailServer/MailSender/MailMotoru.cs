using MailSender.Model;

namespace MailSender.Concrete
{
    public class MailMotoru
    {
        public MailGonderimSonuc MailGonder(MailBilgi mailgBilgi)
        {
            MailGonderen mailGonderen = new MailGonderen(new MailIslemcisi(), new SmtpAyarlayan(), new VeritabaniIletisimcisi(), new MailKontrolcu());
            return mailGonderen.Gonder(mailgBilgi);
        }
    }
}
