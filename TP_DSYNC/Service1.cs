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
            try
            {
                Logs.Write(this.ServiceName + " on Start");
                EventLogs.Write(this.ServiceName + " on Start", (int)EventLogEnum.START_OR_STOP, System.Diagnostics.EventLogEntryType.Information);
                int.TryParse(ConfigurationManager.AppSettings["StartTimerAtSecond"], out int startTimerAtSecond);
                while (true)
                {
                    if (DateTime.Now.Second == startTimerAtSecond)
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
            catch(Exception ex)
            {
                Logs.Write("OnStart Error="+ ex.Message + ex.StackTrace);
            }
        }

        protected void OnTimer(object sender, ElapsedEventArgs args)
        {
            try
            {
                //Thread thread = new Thread(new SensorData(DateTime.Now).ProcessData);
                //thread.Start();
                var t1 = new Task(new SensorData(DateTime.Now).ProcessData);
                var t2 = new Task(new AlertData(DateTime.Now).ProcessData);
                t1.Start();
                t2.Start();
            }
            catch (Exception ex)
            {
                Logs.Write("OnTimer Error=" + ex.Message + ex.StackTrace);
            }
        }

        protected override void OnStop()
        {
            try
            {
                Logs.Write(this.ServiceName + " on Stop");
                EventLogs.Write(this.ServiceName + " on Stop", (int)EventLogEnum.START_OR_STOP, System.Diagnostics.EventLogEntryType.Error);
            }
            catch (Exception ex)
            {
                Logs.Write("OnStop Error=" + ex.Message + ex.StackTrace);
            }
            
        }
    }
}
