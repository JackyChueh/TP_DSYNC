using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_DSYNC.Models.DataDefine.TwwPos
{
    public class ShopItemImg
    {
        public int sno { get; set; }
        public int ImgMapid { get; set; }
        public string ImgName { get; set; }
        public string ImgUrl { get; set; }
        public int ImgMain { get; set; }
        public Nullable<int> ImgOrder { get; set; }
    }
}