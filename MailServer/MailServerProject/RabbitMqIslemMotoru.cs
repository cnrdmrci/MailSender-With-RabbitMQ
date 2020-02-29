using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client;

namespace MailServerProject
{
    public class RabbitMqIslemMotoru
    {
        private IConnection _connection;
        private IModel _channel;

        public RabbitMqIslemMotoru()
        {
            kanalOlustur();
        }

        ~RabbitMqIslemMotoru()
        {
            _channel.Dispose();
            _connection.Dispose();
        }

        public static RabbitMqIslemMotoru YeniObjeOlustur() => new RabbitMqIslemMotoru();
        public void KuyruktanMesajIslemeBaslat()
        {
            MesajIsleyen mesajIsleyen = new MesajIsleyen(_channel);
            _channel.BasicConsume("demoqueue", false, mesajIsleyen);
        }
        private void kanalOlustur()
        {
            _connection = baglantiBilgileriGetir().CreateConnection();
            _channel = _connection.CreateModel();
            _channel.BasicQos(0, 1, false);
        }
        private ConnectionFactory baglantiBilgileriGetir()
        {
            ConnectionFactory connectionFactory = new ConnectionFactory
            {

                HostName = "localhost",
                UserName = "rabbitmq",
                Password = "rabbitmq"
            };

            return connectionFactory;
        }
    }
}
