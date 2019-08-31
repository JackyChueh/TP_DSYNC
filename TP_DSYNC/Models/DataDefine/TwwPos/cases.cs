using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_DSYNC.Models.DataDefine.TwwPos
{
    public class cases
    {
        public string caseno { get; set; }
        public string casena { get; set; }
        public string sdate { get; set; }
        public string edate { get; set; }
        public string uses { get; set; }
        public int cts { get; set; }
        public int pers { get; set; }
        public int moneys { get; set; }
        public string offno { get; set; }
        public string store_id { get; set; }
        public bool free { get; set; }
    }
}