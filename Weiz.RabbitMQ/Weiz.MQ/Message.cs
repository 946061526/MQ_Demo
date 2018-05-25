using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weiz.MQ
{
    /// <summary>
    /// 消息传递的实体
    /// </summary>
    public class MessageInfo
    {
        public string MessageID { get; set; }
        
        public string MessageTitle { get; set; }

        public string MessageBody { get; set; }

        public string MessageRouter { get; set; }
    }
}
