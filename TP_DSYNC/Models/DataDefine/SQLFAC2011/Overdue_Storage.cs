using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_DSYNC.Models.DataDefine.SQLFAC2011
{
    public class Overdue_Storage
    {
        public string offno { get; set; }
        public string wano2 { get; set; }
        public string wano { get; set; }
        public int workno { get; set; }
        public string offna { get; set; }
        public string scolor { get; set; }
        public string dna { get; set; }
        public Nullable<int> status { get; set; }
        public string MsgStore { get; set; }
        public string MsgFAC { get; set; }
        public string date1 { get; set; }
        public string date2 { get; set; }
        public Nullable<int> BubbleStore { get; set; }
        public Nullable<int> BubbleFAC { get; set; }
        public string file_date { get; set; }
        public int onlyx { get; set; }
    }
}