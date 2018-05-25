using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weiz.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderProcessMessage order = new OrderProcessMessage();
            MQ.MessageInfo msg = new MQ.MessageInfo();
            msg.MessageID = "1";
            msg.MessageRouter = "order.notice.lisi";

            MQ.MQHelper.Subscribe(msg, order);

            Console.WriteLine("Listening for messages.");

        }
    }
}
