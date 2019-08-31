using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_DSYNC.Models.DataDefine.TwwPos
{
    public class AddValueAttentionNote
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string ContentText { get; set; }
        public System.DateTime CreateDate { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public string OperUser { get; set; }
    }
}