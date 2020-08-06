using System;
using System.Collections.Generic;
using TP_DSYNC.Models.Implement;
using TP_DSYNC.Models.DataDefine.B3;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Configuration;
using TP_DSYNC.Models.Enums;
using TP_DSYNC.Models.DataDefine.ALERT;

namespace TP_DSYNC.Tasks
{
    public class AlertData : BaseTask
    {
        public AlertData(DateTime now) : base(now) { }

        public void ProcessData()
        {
            Log("[{1}] {0} : {2}", "ProcessData", TaskId, "Begin " + new string('*', 66));

            bool buffer;
            int affected;
            Stopwatch total = new Stopwatch();
            Stopwatch unit = new Stopwatch();
            AlertImplement AlertImplement = new AlertImplement();
            //ReadImplement ReadImplement = new ReadImplement("TP_B3");
            //BufferImplement BufferImplement = new BufferImplement("TP_B3_BUFFER");
            //WriteImplement WriteImplement = new WriteImplement("TP_B3_BUFFER", "TP_DSCCR");
            int.TryParse(ConfigurationManager.AppSettings["ExecuteAlertSecond"], out int executeAlertSecond);

            //ReadConfig
            try
            {
                Log("[{1}] {0} : {2}", "AHU_004F", TaskId, "Start");
                total.Restart();

                unit.Restart();
                List<ALERT_CONFIG> config = AlertImplement.ReadAlertConfig();
                unit.Stop();
                Log("[{1}] {0} : {2}", "ReadConfig", TaskId, "Read Time=" + unit.Elapsed.TotalMilliseconds.ToString() + "ms");
                //Log("[{1}] {0} : {2}", "AHU_004F", TaskId, "Data=" + JsonConvert.SerializeObject(AHU_004F));
                if (config.Count>0)
                {
                    unit.Restart();
                    //buffer = (BufferImplement.WriteBufferForAHU_004F(AHU_004F));
                    AlertImplement.CheckConfig(config);
                    unit.Stop();
                    Log("[{1}] {0} : {2}", "AHU_004F", TaskId, "Buffer Time=" + unit.Elapsed.TotalMilliseconds.ToString() + "ms");
                }
                total.Stop();
                string alert = "";
                if (total.Elapsed.Seconds > executeAlertSecond)
                {
                    alert = total.Elapsed.Seconds > executeAlertSecond ? " > " + executeAlertSecond.ToString() : "";
                    EventLog(EventLogEnum.EXECUTE_ALERT_SECOND, EventLogEntryType.Warning, "[{1}] {0} : {2}", "AHU_004F", TaskId, "End Time=" + total.Elapsed.Seconds.ToString() + "seconds" + alert);
                }
                Log("[{1}] {0} : {2}", "AHU_004F", TaskId, "End Time=" + total.Elapsed.Seconds.ToString() + "seconds" + alert);
            }
            catch (Exception ex)
            {
                Log("[{1}] {0} : {2}", "AHU_004F", TaskId, "Error=" + ex.Message + ex.StackTrace);
                EventLog(EventLogEnum.EXCEPTION, EventLogEntryType.Error, "[{1}] {0} : {2}", "AHU_004F", TaskId, "Error=" + ex.Message + ex.StackTrace);
            }

            //End
            Log("[{1}] {0} : {2}", "ProcessData", TaskId, "Done");
        }
    }
}
