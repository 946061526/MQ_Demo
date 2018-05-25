using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyRabbitMQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Send();


            Recieve();

        }

        private static string GetMessage(string[] args)
        {
            return ((args.Length > 0) ? string.Join(" ", args) : "Hello World!");
        }

        static void Send()
        {
            var factory = new ConnectionFactory();
            factory.HostName = "localhost";
            factory.UserName = "zhouwenchao";
            factory.Password = "zhouwenchao";

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {

                    bool durable = true;//消息队列即使在RabbitMQ Server重启之后，保证RabbitMQ不会丢失队列
                    channel.QueueDeclare("task_queue", durable, false, false, null);

                    string message = GetMessage(new string[] { "test", "1" });
                    var properties = channel.CreateBasicProperties();
                    properties.Persistent = true;//消息队列即使在RabbitMQ Server重启之后，队列也不会丢失。 然后需要保证消息也是持久化的


                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish("", "task_queue", properties, body);
                    Console.WriteLine(" set {0}", message);
                }
            }

        }

        static void Recieve()
        {
            var factory = new ConnectionFactory();
            factory.HostName = "localhost";
            factory.UserName = "zhouwenchao";
            factory.Password = "zhouwenchao";

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    bool durable = true;
                    channel.QueueDeclare("task_queue", durable, false, false, null);
                    channel.BasicQos(0, 1, false);//公平分发，在一个工作者还在处理消息，并且没有响应消息之前，不要给他分发新的消息。相反，将这条新的消息发送给下一个不那么忙碌的工作者

                    //var consumer = new QueueingBasicConsumer(channel);
                    var consumer = new QueueingBasicConsumer(channel);
                    channel.BasicConsume("task_queue", false, consumer);

                    while (true)
                    {
                        var ea = (BasicDeliverEventArgs)consumer.Queue.Dequeue();

                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);

                        int dots = message.Split('.').Length - 1;
                        Thread.Sleep(dots * 1000);

                        Console.WriteLine("Received {0}", message);
                        Console.WriteLine("Done");

                        channel.BasicAck(ea.DeliveryTag, false);
                    }
                }
            }
        }
    }
}
