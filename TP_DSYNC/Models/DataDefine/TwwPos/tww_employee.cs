using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_DSYNC.Models.DataDefine.TwwPos
{
    public class tww_employee
    {
        public int id { get; set; }
        public int tww_store_id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string title { get; set; }
        public string employee_name { get; set; }
        public bool is_manager { get; set; }
        public string address { get; set; }
        public string birthday { get; set; }
        public string identity_card { get; set; }
        public string home_phone { get; set; }
        public string mobile_phone { get; set; }
        public string add_service_role { get; set; }
    }
}