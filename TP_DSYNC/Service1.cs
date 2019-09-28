using System;
using System.ServiceProcess;
using System.Timers;
using System.Threading.Tasks;
using TP_DSYNC.Tasks;
using System.Configuration;
using TP_DSYNC.Models.Help;
using TP_DSYNC.Models.Enums;
namespace TP_DSYNC
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            EventLogs.Write(this.ServiceName + " on Start", (int)EventLogEnum.START_OR_STOP, System.Diagnostics.EventLogEntryType.Information);
            int.TryParse(ConfigurationManager.AppSettings["StartTimerAtSecond"], out int startTimerAtSecond);
            while (true)
            {
                if (DateTime.Now.Millisecond == 0 && DateTime.Now.Second == startTimerAtSecond)
                {
                    break;
                }
            }

            int.TryParse(ConfigurationManager.AppSettings["ProcessDataTiming"], out int processDataTiming);
            if (processDataTiming == 0)
                processDataTiming = 60000;   // 60 seconds  
            var timer = new Timer();
            timer.Interval = processDataTiming;
            timer.Elapsed += new ElapsedEventHandler(OnTimer);
            timer.Start();
        }

        protected void OnTimer(object sender, ElapsedEventArgs args)
        {
            //Thread thread = new Thread(new SensorData(DateTime.Now).ProcessData);
            //thread.Start();
            var t = new Task(new SensorData(DateTime.Now).ProcessData);
            t.Start();
        }

        protected override void OnStop()
        {
            EventLogs.Write(this.ServiceName + " on Stop", (int)EventLogEnum.START_OR_STOP, System.Diagnostics.EventLogEntryType.Error);
        }
    }
}
