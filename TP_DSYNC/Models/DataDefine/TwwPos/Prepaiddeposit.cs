using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_DSYNC.Models.DataDefine.TwwPos
{
    public class Prepaiddeposit
    {
        public int id { get; set; }
        public string store_id { get; set; }
        public int prepaid_amount { get; set; }
        public int prepaid_coupons { get; set; }
    }
}