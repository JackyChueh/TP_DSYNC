using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_DSYNC.Models.DataDefine.TwwPos
{
    public class ApplyPhoneNo
    {
        public int Id { get; set; }
        public string CreateDateTime { get; set; }
        public string StoreId { get; set; }
        public string PhoneName { get; set; }
        public string Phone { get; set; }
        public byte ApplyType { get; set; }
        public string ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string MvpnSC { get; set; }
        public short Commission { get; set; }
        public string CommiDate { get; set; }
        public byte EventStatus { get; set; }
        public string EventDateTime { get; set; }
        public string Note { get; set; }
    }
}