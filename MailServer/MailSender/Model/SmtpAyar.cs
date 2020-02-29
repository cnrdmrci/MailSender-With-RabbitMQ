namespace MailSender.Model
{
    public class SmtpAyar
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public bool SslKullan { get; set; }
    }
}
