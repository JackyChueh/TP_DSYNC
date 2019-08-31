using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_DSYNC.Models.DataDefine.TwwPos
{
    public class tww_salesorder_history_details
    {
        public int id { get; set; }
        public Nullable<int> tww_salesorder_history_id { get; set; }
        public string salesorder_id { get; set; }
        public string barcode_id { get; set; }
        public string clothes_type_id { get; set; }
        public string material_id { get; set; }
        public string handle_type_id { get; set; }
        public string processing_type_id { get; set; }
        public string color { get; set; }
        public string accessory { get; set; }
        public string notes { get; set; }
        public int normal_price { get; set; }
        public int discount_amount { get; set; }
        public int additional_fee { get; set; }
        public int final_price { get; set; }
        public int processing_fee { get; set; }
        public string deliver_date { get; set; }
        public System.DateTime insert_time { get; set; }
        public bool is_disposed { get; set; }
    }
}