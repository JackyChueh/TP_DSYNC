using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_DSYNC.Models.DataDefine.WEB711DATA
{
    public class SmsLog
    {
        public int id { get; set; }
        public string phone { get; set; }
        public string content { get; set; }
        public string send { get; set; }
        public string time { get; set; }
        public string sendtime { get; set; }
        public string source { get; set; }
        public int smscount { get; set; } //另外加的-內容寄成幾封信
       
    }
}