using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_DSYNC.Models.DataDefine.TwwPos
{
    public class ShopOrder
    {
        public int sno { get; set; }
        public string OrderNum { get; set; }
        public System.DateTime OrderDate { get; set; }
        public string OrderShopId { get; set; }
        public int OrderTotal { get; set; }
        public string OrderShopNote { get; set; }
        public string OrderCtoSNote { get; set; }
        public string OrderAdminNote { get; set; }
        public int OrderStatus { get; set; }
        public int OrderRefound { get; set; }
        public System.DateTime LastUpdate { get; set; }
        public System.DateTime LastModify { get; set; }
        public Nullable<System.DateTime> CompeleteDate { get; set; }
        public string OrderRefoundType { get; set; }
        public string DeliveryNum { get; set; }
    }
}