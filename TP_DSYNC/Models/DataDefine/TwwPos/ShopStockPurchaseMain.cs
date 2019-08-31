using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_DSYNC.Models.DataDefine.TwwPos
{
    public class ShopStockPurchaseMain
    {
        public int sno { get; set; }
        public string PceMDesc { get; set; }
        public System.DateTime UpdateTime { get; set; }
        public string UserId { get; set; }
        public Nullable<int> OrderId { get; set; }
    }
}