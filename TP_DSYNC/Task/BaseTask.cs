using System;
using System.Threading;
using System.Reflection;
using System.Diagnostics;
using TP_DSYNC.Models.Help;

namespace TP_DSYNC.Task
{
    public class BaseTask
    {
        protected string ClassName;
        protected string MethodName;
        protected string CallerMethodName;
        protected string TaskId;
        public BaseTask(DateTime now)
        {
            ClassName = this.GetType().Name;
            //MethodName = MethodBase.GetCurrentMethod().Name;
            int seconds = now.Hour * 60 + now.Minute * 60 + now.Second;
            TaskId = Convert.ToString(seconds, 16);
        }

        private void Log(string Folder, string Text)
        {
            Logs.Write(Folder, Text);
        }

        public void Log(string Text)
        {
            StackTrace stackTrace = new StackTrace();
            CallerMethodName = stackTrace.GetFrame(1).GetMethod().Name;
            Log(ClassName + "\\" + CallerMethodName, Text);
        }

        public void Log(string Format, params object[] args)
        {
            StackTrace stackTrace = new StackTrace();
            CallerMethodName = stackTrace.GetFrame(1).GetMethod().Name;
            Log(ClassName + "\\" + CallerMethodName, string.Format(Format, args));
        }
    }
}
