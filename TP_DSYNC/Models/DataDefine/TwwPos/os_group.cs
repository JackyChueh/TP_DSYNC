﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_DSYNC.Models.DataDefine.TwwPos
{
    public class os_group
    {
        public string comp_id { get; set; }
        public string group_id { get; set; }
        public string group_name { get; set; }
        public DateTime? cdate { get; set; }
        public DateTime? mdate { get; set; }
    }
}