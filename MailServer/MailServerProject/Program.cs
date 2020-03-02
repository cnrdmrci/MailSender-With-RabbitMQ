using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using MailSender.Abstract;
using MailSender.Concrete;
using MailSender.Model;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MailServerProject
{
    class Program
    {
        static void Main(string[] args)
        {

            RabbitMqIslemMotoru.YeniObjeOlustur().KuyruktanMesajIslemeBaslat();

            Console.WriteLine("Kuyruktan mesaj işleme başlatıldı.");
            Console.WriteLine("Durdurmak için bir tuşa basın.");
            Console.ReadLine();

            Console.WriteLine("Durduruldu.");
            Environment.Exit(0);

        }
    }
}

