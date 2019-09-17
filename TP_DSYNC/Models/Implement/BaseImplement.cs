using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace TP_DSYNC.Models.Implement
{
    public class BaseImplement
    {
        public void Log(string text)
        {
            var stackTrace = new StackTrace();
            var methodBase = stackTrace.GetFrame(1).GetMethod();
            var Class = methodBase.ReflectedType;
            //var Namespace = Class.Namespace;         //Added finding the namespace

            TP_DSYNC.Models.Help.Log.Write(Class.Name + "\\" + methodBase.Name + "\\", text);

        }
    }
}