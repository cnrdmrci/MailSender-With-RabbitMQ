using System;
using System.Collections.Generic;
using System.Text;

namespace MailClientProject.Model
{
    public class MailBilgi
    {
        public List<string> GonderilecekEpostaAdresleri { get; set; }
        public List<string> CcEpostaAdresleri { get; set; }     
        public List<string> BccEpostaAdresleri { get; set; }    
        public string Konu { get; set; }
        public string Icerik { get; set; }
        public List<string> EklenecekDosyaAdresleri { get; set; }
    }
}
