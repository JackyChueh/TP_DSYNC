using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_DSYNC.Models.DataDefine.ALERT
{
    public class ALERT_CONFIG
    {
        public int SID { get; set; }
        public string MODE { get; set; }
        public string DATA_TYPE { get; set; }
        public string LOCATION { get; set; }
        public string DEVICE_ID { get; set; }
        public string DATA_FIELD { get; set; }
        public Single MAX_VALUE { get; set; }
        public Single MIN_VALUE { get; set; }
        public int CHECK_INTERVAL { get; set; }
        public int ALERT_INTERVAL { get; set; }
        public Boolean SUN { get; set; }
        public TimeSpan SUN_STIME { get; set; }
        public TimeSpan SUN_ETIME { get; set; }
        public Boolean MON { get; set; }
        public TimeSpan MON_STIME { get; set; }
        public TimeSpan MON_ETIME { get; set; }
        public Boolean TUE { get; set; }
        public TimeSpan TUE_STIME { get; set; }
        public TimeSpan TUE_ETIME { get; set; }
        public Boolean WED { get; set; }
        public TimeSpan WED_STIME { get; set; }
        public TimeSpan WED_ETIME { get; set; }
        public Boolean THU { get; set; }
        public TimeSpan THU_STIME { get; set; }
        public TimeSpan THU_ETIME { get; set; }
        public Boolean FRI { get; set; }
        public TimeSpan FRI_STIME { get; set; }
        public TimeSpan FRI_ETIME { get; set; }
        public Boolean STA { get; set; }
        public TimeSpan STA_STIME { get; set; }
        public TimeSpan STA_ETIME { get; set; }
        public DateTime CHECK_DATE { get; set; }
        public DateTime ALERT_DATE { get; set; }
        public string MAIL_TO { get; set; }
        public Boolean CHECK_HR_CALENDAR { get; set; }
    }
}
