using System.Collections.Generic;

namespace MailSender.Model
{
    public class MailBilgi
    {
        public string Kimden { get; set; }
        public string KimdenUnvan { get; set; }
        public List<string> GonderilecekEpostaAdresleri { get; set; }
        public List<string> CcEpostaAdresleri { get; set; }     //Bilgilendirilecek e-posta adresleri
        public List<string> BccEpostaAdresleri { get; set; }    //Gizli olarak eklenecek e-posta adresleri
        public string Konu { get; set; }
        public string Icerik { get; set; }
        public List<string> EklenecekDosyaAdresleri { get; set; }
    }
}
