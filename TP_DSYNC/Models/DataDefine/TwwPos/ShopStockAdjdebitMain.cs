using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_DSYNC.Models.DataDefine.TwwPos
{
    public class ShopStockAdjdebitMain
    {
        public int sno { get; set; }
        public string AdjMDesc { get; set; }
        public System.DateTime UpdateTime { get; set; }
        public string UserId { get; set; }
        public Nullable<int> OrderId { get; set; }
    }
}