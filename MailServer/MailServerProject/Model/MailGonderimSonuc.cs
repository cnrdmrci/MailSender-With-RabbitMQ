using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MailServerProject.Model
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
