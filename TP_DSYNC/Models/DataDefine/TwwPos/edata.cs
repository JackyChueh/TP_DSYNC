using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_DSYNC.Models.DataDefine.TwwPos
{
    public class edata
    {
        public string dno { get; set; }
        public string wno { get; set; }
        public Nullable<double> money { get; set; }
        public Nullable<double> money1 { get; set; }
        public Nullable<double> m21 { get; set; }
        public Nullable<double> m22 { get; set; }
        public Nullable<double> m31 { get; set; }
        public Nullable<double> m32 { get; set; }
        public Nullable<double> ma { get; set; }
        public Nullable<double> mb { get; set; }
        public Nullable<double> mc { get; set; }
        public Nullable<double> md { get; set; }
        public Nullable<double> me { get; set; }
        public Nullable<double> mf { get; set; }
        public string store_id { get; set; }
        public bool free { get; set; }
        public int free_money { get; set; }
    }
}