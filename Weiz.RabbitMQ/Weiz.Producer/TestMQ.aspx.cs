using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Weiz.Consumer;
using Weiz.MQ;

namespace Weiz.Producer
{
    public partial class TestMQ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MessageInfo msg = new MessageInfo();
            msg.MessageID = "1";
            msg.MessageBody = "Msg " + DateTime.Now.ToString();
            msg.MessageTitle = "1";
            msg.MessageRouter = "order.notice.lisi";

            MQHelper.Publish(msg);

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            OrderProcessMessage order = new OrderProcessMessage();
            MessageInfo msg = new MessageInfo();
            msg.MessageID = "1";
            msg.MessageRouter = "pcm.notice.zhangsan";

            MQ.MQHelper.Subscribe(msg, order);

        }
    }
}