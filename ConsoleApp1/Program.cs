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
            //var timer = new System.Timers.Timer();
            //timer.Interval = 2000; // 60 seconds  
            //timer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimer);
            //timer.Start();
            SensorData.Read();

            Console.ReadLine();
        }

        protected static void OnTimer(object sender, System.Timers.ElapsedEventArgs args)
        {
            Thread thread = new Thread(SensorData.Read);
            thread.Start();
        }
    }
}
