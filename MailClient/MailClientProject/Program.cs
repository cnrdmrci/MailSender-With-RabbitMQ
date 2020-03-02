using System;
using System.Collections.Generic;
using MailClientProject.Model;

namespace MailClientProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating queue");
            CreateQueue.Run();

            Console.WriteLine("Creating exchange");
            CreateExchange.Run();

            Console.WriteLine("Create binding");
            CreateBinding.Run();

            MailBilgi mailBilgi = new MailBilgi();
            mailBilgi.GonderilecekEpostaAdresleri = new List<string>() {"mailadresi@"};
            mailBilgi.Konu = "Bu bir test mesajıdır.";
            mailBilgi.Icerik = "Test mesajı içeriğidir.";

            PublishMessage.Run(mailBilgi);
        }
    }
}
