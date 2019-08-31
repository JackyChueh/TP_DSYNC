using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_DSYNC.Models.DataDefine.TwwPos
{
    public class ShopTaxonomy
    {
        public int sno { get; set; }
        public string TaxonomyName { get; set; }
        public string Description { get; set; }
        public int Parent { get; set; }
        public int count { get; set; }
    }
}