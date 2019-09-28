using System;
using System.Timers;
using System.Threading.Tasks;
using TP_DSYNC.Tasks;
using System.Configuration;

namespace ConsoleApp1
{
    class Program
    {
        public static string EventLogSource = "TP_DSYNC";
        static void Main(string[] args)
        {
            //int.TryParse(ConfigurationManager.AppSettings["StartTimerAtSecond"], out int startTimerAtSecond);
            //while (true)
            //{
            //    if (DateTime.Now.Millisecond == 0 && DateTime.Now.Second == startTimerAtSecond)
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

        protected static void OnTimer(object sender, ElapsedEventArgs args)
        {
            //Thread thread = new Thread(new SensorData().ProcessData);
            //thread.Start();
            var t = new Task(new SensorData(DateTime.Now).ProcessData);
            t.Start();
        }

    }
}
