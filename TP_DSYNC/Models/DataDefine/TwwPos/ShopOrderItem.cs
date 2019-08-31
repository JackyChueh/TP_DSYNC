using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_DSYNC.Models.DataDefine.TwwPos
{
    public class ShopOrderItem
    {
        public int sno { get; set; }
        public int ItemOrderId { get; set; }
        public int ItemId { get; set; }
        public int ItemrId { get; set; }
        public string ItemSku { get; set; }
        public string ItemTansen { get; set; }
        public string ItemName { get; set; }
        public string ItemSpec { get; set; }
        public string ItemUnit { get; set; }
        public int ItemSource { get; set; }
        public int ItemMapBatchId { get; set; }
        public string ItemBatchId { get; set; }
        public int ItemCost { get; set; }
        public int ItemPrice1 { get; set; }
        public int ItemPrice2 { get; set; }
        public int WashCommission { get; set; }
        public int StoreCommission { get; set; }
        public int Qty { get; set; }
        public int ItemRefund { get; set; }
        public string ItemRefundReason { get; set; }
        public int WashCost { get; set; }
    }
}