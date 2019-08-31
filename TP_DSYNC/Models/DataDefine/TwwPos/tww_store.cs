using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_DSYNC.Models.DataDefine.TwwPos
{
    public class tww_store
    {
        public int id { get; set; }
        public string store_name { get; set; }
        public string store_id { get; set; }
        public string store_address { get; set; }
        public string current_invoice_number { get; set; }
        public bool is_using_tax_printer { get; set; }
        public string store_phone { get; set; }
        public string company { get; set; }
        public string printer_name { get; set; }
        public string invoice_printer_name { get; set; }
        public string current_barcode_id { get; set; }
        public bool is_prepaid_allowed { get; set; }
        public int prepaid_amount { get; set; }
        public int prepaid_coupons { get; set; }
        public string store_announcement { get; set; }
        public string marque_announcement { get; set; }
        public int normal_delivery { get; set; }
        public int express_delivery { get; set; }
        public int winter_delivery { get; set; }
        public string Area { get; set; }

    }
}