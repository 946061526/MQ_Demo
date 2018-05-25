using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weiz.MQ
{
    /// <summary>
    /// 用于消息传递、处理
    /// </summary>
    public interface IProcessMessage
    {
        void ProcessMsg(MessageInfo msg);
    }
}
