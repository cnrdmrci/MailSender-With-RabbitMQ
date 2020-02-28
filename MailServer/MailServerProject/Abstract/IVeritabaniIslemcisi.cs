using System;
using System.Collections.Generic;
using System.Text;
using MailServerProject.Model;

namespace MailServerProject.Abstract
{
    public interface IVeritabaniIslemcisi
    {
        void BasariliGonderimKaydet(MailBilgi mailBilgi);
        void HataliGonderimKaydet(MailBilgi mailBilgi,string mesaj);
    }
}
