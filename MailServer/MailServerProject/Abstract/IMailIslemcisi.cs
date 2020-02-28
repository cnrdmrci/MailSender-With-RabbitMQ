using System;
using System.Collections.Generic;
using System.Text;
using MailServerProject.Model;

namespace MailServerProject.Abstract
{
    public interface IMailIslemcisi
    {
        bool MailGonderimiYap(MailBilgi mailBilgi);
    }
}
