using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client;

namespace MailClientProject
{
    public class CreateQueue
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
                Console.WriteLine("Creating Queue");

                // Create Queue
                model.QueueDeclare("demoqueue", true, false, false, null);
            }
        }
    }
}
