using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_DSYNC.Models.DataDefine.TwwPos
{
    public class tww_outgoing_shippment
    {
        public int id { get; set; }
        public string store_id { get; set; }
        public string barcode_id { get; set; }
        public string outgoing_shippment_id { get; set; }
        public int is_retrieved { get; set; }
        public int is_nonwashing_return { get; set; }
        public int is_nonwashing_return_processed { get; set; }
        public string pre_barcode_id { get; set; }
        public int onlyxfac003 { get; set; }
        public string orderno { get; set; }
        public string prndate { get; set; }
    }
}