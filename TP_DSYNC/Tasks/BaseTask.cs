using System;
using System.Threading;
using System.Reflection;
using System.Diagnostics;
using TP_DSYNC.Models.Help;
using TP_DSYNC.Models.Enums;

namespace TP_DSYNC.Tasks
{
    public class BaseTask
    {
        protected string ClassName;
        protected string MethodName;
        protected string CallerMethodName;
        protected string TaskId;
        protected DateTime CurrentNow;

        public BaseTask(DateTime now)
        {
            ClassName = this.GetType().Name;
            //MethodName = MethodBase.GetCurrentMethod().Name;
            int seconds = now.Hour * 3600 + now.Minute * 60 + now.Second;
            TaskId = Convert.ToString(seconds, 16);

            CurrentNow = now;
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


        public void EventLog(EventLogEnum EventLogEnum, EventLogEntryType EventLogEntryType, string Message)
        {
            EventLog((int)EventLogEnum, EventLogEntryType, Message);
        }
        public void EventLog(EventLogEnum EventLogEnum, EventLogEntryType EventLogEntryType, string Format, params object[] args)
        {
            EventLog((int)EventLogEnum, EventLogEntryType, string.Format(Format, args));
        }
        public void EventLog(int EventId, EventLogEntryType EventLogEntryType, string Message)
        {
            EventLogs.Write(Message, EventId, EventLogEntryType);
        }
    }
}