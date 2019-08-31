using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_DSYNC.Models.DataDefine.TwwPos
{
    public class ShopItem
    {
        public int sno { get; set; }
        public string ItemSku { get; set; }
        public string ItemTansen { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public int Taxonomy { get; set; }
        public Nullable<int> ItemParent { get; set; }
        public string ItemSpec { get; set; }
        public string ItemUnit { get; set; }
        public int ItemSource { get; set; }
        public int ItemStatusType { get; set; }
        public string SalesStart { get; set; }
        public string SalesEnd { get; set; }
        public int MaxQty { get; set; }
        public int MinQty { get; set; }
        public int WashCommission { get; set; }
        public int StoreCommission { get; set; }
        public int ItemCost { get; set; }
        public int Price1 { get; set; }
        public int Price2 { get; set; }
        public string ItemNote { get; set; }
        public System.DateTime CreateTime { get; set; }
        public System.DateTime LastUpdate { get; set; }
        public Nullable<int> ItemOrder { get; set; }
        public int IsNotModify { get; set; }
        public string IsNotAllowRefound { get; set; }
        public int WashCost { get; set; }
        public string IsAllowRefund { get; set; }
        public int Qty { get; set; }
    }
}