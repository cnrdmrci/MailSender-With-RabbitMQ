using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client;

namespace MailClientProject
{
    public class CreateExchange
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
                Console.WriteLine("Creating Exchange");

                // Create Exchange
                model.ExchangeDeclare("demoExchange", ExchangeType.Direct);
            }
        }
    }
}
