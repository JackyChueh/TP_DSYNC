using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Threading;
using TP_DSYNC.Task;

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
            var timer = new System.Timers.Timer();
            timer.Interval = 60000; // 60 seconds  
            timer.Elapsed += new System.Timers.ElapsedEventHandler(this.OnTimer);
            timer.Start();
        }

        protected void OnTimer(object sender, System.Timers.ElapsedEventArgs args)
        {
            Thread thread = new Thread(new SensorData().ProcessData);
            thread.Start();
        }

        protected override void OnStop()
        {
        }
    }
}
