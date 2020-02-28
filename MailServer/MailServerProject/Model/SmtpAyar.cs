using System;
using System.Collections.Generic;
using System.Text;

namespace MailServerProject.Model
{
    public class SmtpAyar
    {
        public string Host { get; set; }
        public string Port { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public bool SslKullan { get; set; }
    }
}
