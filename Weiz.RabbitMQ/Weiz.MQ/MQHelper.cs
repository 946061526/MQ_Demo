using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

using EasyNetQ;

namespace Weiz.MQ
{
    /// <summary>
    /// 用于发送/接收消息
    /// </summary>
    public class MQHelper
    {
        /// <summary>
        /// 发送消息
        /// </summary>
        public static void Publish(MessageInfo msg)
        {
            //// 创建消息bus
            IBus bus = BusBuilder.CreateMessageBus();

            try
            {
                //bus.Publish(msg, x => x.WithTopic(msg.MessageRouter));
                bus.Publish(msg);
            }
            catch (EasyNetQException ex)
            {
                //处理连接消息服务器异常 
            }

            bus.Dispose();//与数据库connection类似，使用后记得销毁bus对象
        }

        /// <summary>
        /// 接收消息
        /// </summary>
        /// <param name="msg"></param>
        public static void Subscribe(MessageInfo msg, IProcessMessage ipro)
        {
            //// 创建消息bus
            IBus bus = BusBuilder.CreateMessageBus();

            try
            {
                //bus.Subscribe<MessageInfo>(msg.MessageRouter, message => ipro.ProcessMsg(message), x => x.WithTopic(msg.MessageRouter));
                bus.Subscribe<MessageInfo>(msg.MessageRouter, message => ipro.ProcessMsg(message));
            }
            catch (EasyNetQException ex)
            {
                //处理连接消息服务器异常 
            }
        }

    }
}
