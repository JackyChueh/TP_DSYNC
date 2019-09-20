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
        protected string ThreadId;
        public BaseTask()
        {
            ClassName = this.GetType().Name;
            //MethodName = MethodBase.GetCurrentMethod().Name;
            ThreadId = Thread.CurrentThread.ManagedThreadId.ToString();
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
