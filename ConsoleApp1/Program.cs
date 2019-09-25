using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using TP_DSYNC.Task;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //bool onTime = true;
            //while (onTime)
            //{
            //    if (DateTime.Now.Millisecond == 0 && DateTime.Now.Second == 29)
            //    {
            //        break;
            //    }
            //}

            var timer = new System.Timers.Timer();
            timer.Interval = 1000; // 60 seconds  
            timer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimer);
            timer.Start();

            //new SensorData().ProcessData();   //單次測試用

            Console.ReadLine();
        }

        protected static void OnTimer(object sender, System.Timers.ElapsedEventArgs args)
        {
            //Thread thread = new Thread(new SensorData().ProcessData);
            //thread.Start();
            var t = new Task(new SensorData(DateTime.Now).ProcessData);
            t.Start();
        }

    }
}
