using System.Collections.Generic;
using System.Linq;

namespace MailSender.Model
{
    public class MailGonderimSonuc
    {
        public bool Basarili { get; set; }
        public List<string> Hatalar { get; set; }

        public string HatalarStr
        {
            get { return Hatalar.Aggregate((x,y)=>x+"\r\n"+y); }
            private set { }
        }
    }
}
