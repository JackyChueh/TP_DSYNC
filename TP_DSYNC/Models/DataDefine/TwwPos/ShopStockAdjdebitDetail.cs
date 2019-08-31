using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_DSYNC.Models.DataDefine.TwwPos
{
    public class ShopStockAdjdebitDetail
    {
        public int sno { get; set; }
        public int AdjDMapMId { get; set; }
        public int AdjDMapId { get; set; }
        public int Qty { get; set; }
        public System.DateTime Updatetime { get; set; }
        public string UserId { get; set; }
        public int Type { get; set; }
        public string Note { get; set; }
    }
}