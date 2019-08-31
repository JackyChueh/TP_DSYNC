using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_DSYNC.Models.DataDefine.TwwPos
{
    public class SaveHistoryLog
    {
        public int id { get; set; }
        public string store_id { get; set; }
        public string manno { get; set; }
        public System.DateTime eventime { get; set; }
        public string eventtype { get; set; }
    }
}