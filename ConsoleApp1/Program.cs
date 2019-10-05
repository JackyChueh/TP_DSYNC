using System;
using System.Timers;
using System.Threading.Tasks;
using TP_DSYNC.Tasks;
using System.Configuration;
using TP_DSYNC.Models.Help;
using TP_DSYNC.Models.Enums;

namespace ConsoleApp1
{
    class Program
    {
        public static string EventLogSource = "TP_DSYNC";
        static void Main(string[] args)
        {
            try
            {
                //Logs.Write(Program.EventLogSource + " on Start");
                //EventLogs.Write(Program.EventLogSource + " on Start", (int)EventLogEnum.START_OR_STOP, System.Diagnostics.EventLogEntryType.Information);
                //int.TryParse(ConfigurationManager.AppSettings["StartTimerAtSecond"], out int startTimerAtSecond);
                //while (true)
                //{
                //    if (DateTime.Now.Second == startTimerAtSecond)
                //    {
                //        break;
                //    }
                //}

                //int.TryParse(ConfigurationManager.AppSettings["ProcessDataTiming"], out int processDataTiming);
                //if (processDataTiming == 0)
                //    processDataTiming = 60000;   // 60 seconds  
                //var timer = new Timer();
                //timer.Interval = processDataTiming;
                //timer.Elapsed += new ElapsedEventHandler(OnTimer);
                //timer.Start();

                new SensorData(DateTime.Now).ProcessData();   //單次測試用

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Logs.Write("OnStart Error=" + ex.Message + ex.StackTrace);
            }
        }

        protected static void OnTimer(object sender, ElapsedEventArgs args)
        {
            //Thread thread = new Thread(new SensorData().ProcessData);
            //thread.Start();
            var t = new Task(new SensorData(DateTime.Now).ProcessData);
            t.Start();
        }

    }
}
