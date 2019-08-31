using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_DSYNC.Models.DataDefine.TwwPos
{
    public class ShopStock
    {
        public int sno { get; set; }
        public int ItemMapid { get; set; }
        public int Stock { get; set; }
        public int ViewStock { get; set; }
        public Nullable<System.DateTime> Vaildate { get; set; }
        public string BatchCode { get; set; }
        public string StorageLocation { get; set; }
        public int ItemSoucre { get; set; }
        public System.DateTime UpdateTime { get; set; }
    }
}