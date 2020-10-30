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

            //bool buffer;
            //int affected;
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
                Log("[{1}] {0} : {2}", "Alert", TaskId, "Start");
                total.Restart();
                unit.Restart();
                List<ALERT_CONFIG> config = AlertImplement.ReadAlertConfig();
                unit.Stop();
                Log("[{1}] {0} : {2}", "ReadAlertConfig", TaskId, "Read Time=" + unit.Elapsed.TotalMilliseconds.ToString() + "ms");
                //Log("[{1}] {0} : {2}", "AHU_004F", TaskId, "Data=" + JsonConvert.SerializeObject(AHU_004F));
                if (config.Count > 0)
                {
                    unit.Restart();
                    string dateType = AlertImplement.GetDateType(this.CurrentNow);

                    foreach (ALERT_CONFIG c in config)
                    {
                        try
                        {
                            if (AlertImplement.CheckDayOfWeek(c, dateType)) //是否為檢查日
                            {
                                if (c.CHECK_DATE.AddMinutes(c.CHECK_INTERVAL) < this.CurrentNow)    //檢查的週期
                                {
                                    Single? value = AlertImplement.ReadFieldValue(c);
                                    if (value == null || value > c.MAX_VALUE || value < c.MIN_VALUE)    //檢查值是否正常
                                    {
                                        //AlertImplement.WriteAlertInfo(c, this.CurrentNow);  //寫入異常記錄
                                        string[] to = c.MAIL_TO.Split(';');
                                        if (to.Length > 0)
                                        {
                                            if (c.ALERT_DATE.AddMinutes(c.CHECK_INTERVAL) < this.CurrentNow)    //寄送通知的週期
                                            {
                                                AlertImplement.WriteAlertInfo(c, value, this.CurrentNow);  //寫入異常記錄
                                                AlertImplement.SendAlertMessage(c, value, this.CurrentNow);
                                                AlertImplement.UpdateAlertDate(c, this.CurrentNow);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        catch(Exception ex)
                        {
                            Log("[{1}] {0} : {2}", "RowOfConfig", TaskId, "Error=" + ex.Message + ex.StackTrace);
                        }
                    }
                    //AlertImplement.CheckConfig(config);

                    unit.Stop();
                    Log("[{1}] {0} : {2}", "CheckAlertConfig", TaskId, "Check Time=" + unit.Elapsed.TotalMilliseconds.ToString() + "ms");
                }
                total.Stop();
                string alert = "";
                if (total.Elapsed.Seconds > executeAlertSecond)
                {
                    alert = total.Elapsed.Seconds > executeAlertSecond ? " > " + executeAlertSecond.ToString() : "";
                    EventLog(EventLogEnum.EXECUTE_ALERT_SECOND, EventLogEntryType.Warning, "[{1}] {0} : {2}", "Alert", TaskId, "End Time=" + total.Elapsed.Seconds.ToString() + "seconds" + alert);
                }
                Log("[{1}] {0} : {2}", "Alert", TaskId, "End Time=" + total.Elapsed.Seconds.ToString() + "seconds" + alert);
            }
            catch (Exception ex)
            {
                Log("[{1}] {0} : {2}", "Alert", TaskId, "Error=" + ex.Message + ex.StackTrace);
                EventLog(EventLogEnum.EXCEPTION, EventLogEntryType.Error, "[{1}] {0} : {2}", "Alert", TaskId, "Error=" + ex.Message + ex.StackTrace);
            }

            //End
            Log("[{1}] {0} : {2}", "ProcessData", TaskId, "Done");
        }
    }
}
