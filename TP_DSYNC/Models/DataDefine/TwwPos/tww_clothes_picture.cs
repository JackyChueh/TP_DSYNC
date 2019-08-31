using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_DSYNC.Models.DataDefine.TwwPos
{
    public class tww_clothes_picture
    {
        public int id { get; set; }
        public string store_id { get; set; }
        public string barcode_id { get; set; }
        public string file_name { get; set; }
        public DateTime create_date { get; set; }
    }
}