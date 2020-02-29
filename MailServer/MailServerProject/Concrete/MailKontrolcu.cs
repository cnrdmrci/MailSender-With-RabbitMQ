using System;
using System.Collections.Generic;
using System.Text;
using MailServerProject.Abstract;
using MailServerProject.Model;

namespace MailServerProject.Concrete
{
    public class MailKontrolcu : IMailKontrolcu
    {
        public bool MailAdresiKontrolEt(MailBilgi mailBilgi)
        {
            return true; //mail gecerli var sayalim. kontroller eklenecek.
        }
    }
}
