using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_DSYNC.Models.DataDefine.TwwPos
{
    public class tww_clothes_in_factory_status
    {
        public int id { get; set; }
        public string store_id { get; set; }
        public string barcode_id { get; set; }
        public string sales_order_id { get; set; }
        public string processing_status { get; set; }
        public System.DateTime processing_time { get; set; }
    }
}