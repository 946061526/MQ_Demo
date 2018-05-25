using System;
using System.Configuration;
using EasyNetQ;

namespace Weiz.MQ
{
    /// <summary>
    /// �ܵ������࣬��Ҫ��������Rabbitmq����Ϣ��������������
    /// </summary>
    public class BusBuilder
    {
        public static IBus CreateMessageBus()
        {
            // ��Ϣ�����������ַ���
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