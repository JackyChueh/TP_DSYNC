using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_DSYNC.Models.Help;
using System.Threading;
using TP_DSYNC.Models.Implement;
using TP_DSYNC.Models.DataDefine.B3;

namespace TP_DSYNC.Task
{
    public class SensorData
    {
        public static void Read()
        {
            int affected;

            AHU_0B1F AHU_0B1 = new AHU_0B1FImplement("TP_B3").ReadData();
            affected = new AHU_0B1FImplement("TP_DSCCR").WriteDate(AHU_0B1);

            AHU_014F AHU_014F = new AHU_014FImplement("TP_B3").ReadData();
            affected = new AHU_014FImplement("TP_DSCCR").WriteDate(AHU_014F);

            //Log.Write(Thread.CurrentThread.ManagedThreadId.ToString());
            //System.Threading.Thread.Sleep(5000);
            //Log.Write(Thread.CurrentThread.ManagedThreadId.ToString()+ "*");

        }
    }
}
