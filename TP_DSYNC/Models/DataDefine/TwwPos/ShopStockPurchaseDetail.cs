using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_DSYNC.Models.DataDefine.TwwPos
{
    public class ShopStockPurchaseDetail
    {
        public int sno { get; set; }
        public int PceDMapMId { get; set; }
        public int PceDMapId { get; set; }
        public int Qty { get; set; }
        public System.DateTime Updatetime { get; set; }
        public string UserId { get; set; }
        public int Type { get; set; }
        public string Note { get; set; }
    }
}