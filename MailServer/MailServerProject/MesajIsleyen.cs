using System;
using System.Collections.Generic;
using System.Text;
using MailSender.Concrete;
using MailSender.Model;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace MailServerProject
{
    public class MesajIsleyen : DefaultBasicConsumer
    {
        private readonly IModel _channel;

        public MesajIsleyen(IModel channel)
        {
            _channel = channel;
        }

        public override void HandleBasicDeliver(string consumerTag, ulong deliveryTag, bool redelivered, string exchange, string routingKey, IBasicProperties properties, byte[] body)
        {
            //Console.WriteLine($"Consuming Message");
            //Console.WriteLine(string.Concat("Message received from the exchange ", exchange));
            //Console.WriteLine(string.Concat("Consumer tag: ", consumerTag));
            //Console.WriteLine(string.Concat("Delivery tag: ", deliveryTag));
            //Console.WriteLine(string.Concat("Routing tag: ", routingKey));
            //Console.WriteLine(string.Concat("Message: ", Encoding.UTF8.GetString(body)));

            string message = Encoding.UTF8.GetString(body);
            Console.Write("Mail gönderiliyor----\t");

            MailMotoru mailMotoru = new MailMotoru();

            MailBilgi mailBilgi = JsonConvert.DeserializeObject<MailBilgi>(message);

            MailGonderimSonuc mailGonderimSonuc = mailMotoru.MailGonder(mailBilgi);

            if(mailGonderimSonuc.Basarili)
                Console.WriteLine("----Mail gönderildi.");
            else
                Console.WriteLine("----Mail gönderimi başarısız.");

            _channel.BasicAck(deliveryTag, false);

        }
    }
}
