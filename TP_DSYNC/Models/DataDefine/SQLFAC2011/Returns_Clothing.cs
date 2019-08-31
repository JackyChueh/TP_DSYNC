using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_DSYNC.Models.DataDefine.SQLFAC2011
{
    public class Returns_Clothing
    {
        public int onlyxFAC003 { get; set; }
        public Nullable<int> status { get; set; }
        public string Msg { get; set; }
        public Nullable<System.DateTime> date1 { get; set; }
        public Nullable<int> Bubble { get; set; }
    }
}