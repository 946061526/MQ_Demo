using System;
using System.Configuration;
using EasyNetQ;

namespace Weiz.MQ
{
    /// <summary>
    /// 管道创建类，主要负责链接Rabbitmq（消息服务器连接器）
    /// </summary>
    public class BusBuilder
    {
        public static IBus CreateMessageBus()
        {
            // 消息服务器连接字符串
            // var connectionString = ConfigurationManager.ConnectionStrings["RabbitMQ"];
            string connString = "host=127.0.0.1:5672;virtualHost=vTest;username=zhouwenchao;password=zhouwenchao";
            if (string.IsNullOrEmpty(connString))
            {
                throw new Exception("messageserver connection string is missing or empty");
            }

            return RabbitHutch.CreateBus(connString);
        }


    }

}