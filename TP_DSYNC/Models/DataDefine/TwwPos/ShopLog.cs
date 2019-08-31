using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_DSYNC.Models.DataDefine.TwwPos
{
    public class ShopLog
    {
        public int sno { get; set; }
        public string Type { get; set; }
        public int Itemsno { get; set; }
        public string LogDesc { get; set; }
        public System.DateTime Time { get; set; }
        public string UserId { get; set; }
    }
}