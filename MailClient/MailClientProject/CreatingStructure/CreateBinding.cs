using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client;

namespace MailClientProject
{
    public class CreateBinding
    {
        public static void Run()
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
                // Create Exchange
                //model.ExchangeDeclare("demoExchange", ExchangeType.Direct);
                //Console.WriteLine("Creating Exchange");

                // Create Queue
                //model.QueueDeclare("demoqueue", true, false, false, null);
                //Console.WriteLine("Creating Queue");

                // Bind Queue to Exchange
                model.QueueBind("demoqueue", "demoExchange", "directexchange_key");
            }
        }
    }
}
