using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_DSYNC.Models.DataDefine.TwwPos
{
    public class ShopStockSellDetail
    {
        public int sno { get; set; }
        public int SellDMapMId { get; set; }
        public int SellDMapId { get; set; }
        public int Qty { get; set; }
        public System.DateTime UpdateTime { get; set; }
        public string UserId { get; set; }
        public int Type { get; set; }
        public string Note { get; set; }
    }
}