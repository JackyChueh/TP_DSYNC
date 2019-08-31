using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_DSYNC.Models.DataDefine.WEB711DATA
{
    public class ALLMEMBER
    {
        public int sno { get; set; }
        public string phone { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public int? sex { get; set; }
        public DateTime? birthday { get; set; }
        public string city { get; set; }
        public string area { get; set; }
        public string zip { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public int? member_class { get; set; }
        public string member_pro { get; set; }
        public int? totalx { get; set; }
        public string point { get; set; }
        public DateTime? date { get; set; }
        public string code { get; set; }
        public int? pass { get; set; }
        public string Nickname { get; set; }
        public string registerId { get; set; }
        public int? phoneType { get; set; }
        public string CardToken { get; set; }
        public int send { get; set; }
    }
}