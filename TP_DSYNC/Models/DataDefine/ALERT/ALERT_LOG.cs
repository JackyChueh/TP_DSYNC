using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_DSYNC.Models.DataDefine.ALERT
{
    public class ALERT_LOG
    {
        public Int64? SID { get; set; }
        public string DATA_TYPE { get; set; }
        public string LOCATION { get; set; }
        public string DEVICE_ID { get; set; }
        public string DATA_FIELD { get; set; }
        public string MAX_VALUE { get; set; }
        public string MIN_VALUE { get; set; }
        public string ALERT_VALUE { get; set; }
        public DateTime? CHECK_DATE { get; set; }
    }
}
