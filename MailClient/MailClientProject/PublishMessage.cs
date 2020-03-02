using System;
using System.Text;
using MailClientProject.Model;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace MailClientProject
{
    public class PublishMessage
    {
        public static void Run(MailBilgi mailBilgi)
        {
            string UserName = "rabbitmq";
            string Password = "rabbitmq";
            string HostName = "localhost";

            var connectionFactory = new ConnectionFactory()
            {
                UserName = UserName,
                Password = Password,
                HostName = HostName
            };

            using (var connection = connectionFactory.CreateConnection())
            using (var model = connection.CreateModel())
            {
                var properties = model.CreateBasicProperties();
                properties.Persistent = false;

                string message = JsonConvert.SerializeObject(mailBilgi);
                byte[] messagebuffer = Encoding.Default.GetBytes(message);

                model.BasicPublish(
                    "demoExchange", 
                    "directexchange_key", 
                    properties, 
                    messagebuffer);

                Console.WriteLine("Message Sent");
            }
        }
    }
}
