using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_DSYNC.Models.DataDefine.TwwPos
{
    public class tww_salesorder_history
    {
        public int id { get; set; }
        public string event_time { get; set; }
        public string branch_id { get; set; }
        public string customer_id { get; set; }
        public string event_type { get; set; }
        public int receiving_number { get; set; }
        public int retriving_number { get; set; }
        public int revising_number { get; set; }
        public int cashing_in { get; set; }
        public int normal_price_sum { get; set; }
        public int discount_amount_sum { get; set; }
        public int additional_fee_sum { get; set; }
        public int final_price_sum { get; set; }
        public int processing_fee_sum { get; set; }
        public int customer_recevible { get; set; }
        public string edit_id { get; set; }
        public string invoice_number { get; set; }
        public string uniform_number { get; set; }
        public bool is_payment_cancelled { get; set; }
        public string remark { get; set; }
        public int prepaid_cash_discount { get; set; }
    }
}