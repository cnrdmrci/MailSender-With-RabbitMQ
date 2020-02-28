using System;
using System.Collections.Generic;
using System.Text;
using MailServerProject.Abstract;

namespace MailServerProject.Model
{
    public class MailBilgi
    {
        public string Kime { get; set; }
        public string Kimden { get; set; }
        public string Konu { get; set; }
        public string Icerik { get; set; }
        public List<string> EkDosya { get; set; }
    }
}
