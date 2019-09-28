using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TP_DSYNC.Models.Enums
{
    public enum EventLogEnum : int
    {
        [Description("服務啟動或停止")]
        START_OR_STOP = 0,
        [Description("執行時間大於警戒值")]
        EXECUTE_ALERT_SECOND = 1,
        [Description("例外事件")]
        EXCEPTION = 2
    }

}
