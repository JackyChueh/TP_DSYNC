using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_DSYNC.Models.Enums;

namespace TP_DSYNC.Models.DataDefine
{
    public class Result
    {
        private ResultEnum _state = ResultEnum.FAIL;

        public ResultEnum State
        {
            get
            {
                return this._state;
            }
            set
            {
                this._state = value;
                this.Msg = EnumEx.GetDescription(_state);
                //this.Msg = EnumEx.GetDescription((ResultEnum)value);
            }
        }

        public string Msg { get; set; }
    }
}