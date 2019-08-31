using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_DSYNC.Models.DataDefine.TwwPos
{
    public class AddValueServiceAD
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Subject { get; set; }
        public string ContentText { get; set; }
        public bool IsPublish { get; set; }
        public System.DateTime CreateDate { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public string OperUser { get; set; }
    }
}