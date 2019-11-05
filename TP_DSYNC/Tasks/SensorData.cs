﻿using System;
using TP_DSYNC.Models.Implement;
using TP_DSYNC.Models.DataDefine.B3;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Configuration;
using TP_DSYNC.Models.Enums;

namespace TP_DSYNC.Tasks
{
    public class SensorData : BaseTask
    {
        public SensorData(DateTime now) : base(now) { }
        public void ProcessData()
        {
            Log("[{1}] {0} : {2}", "ProcessData", TaskId, "Begin " + new string('*', 66));

            bool buffer;
            int affected;
            Stopwatch total = new Stopwatch();
            Stopwatch unit = new Stopwatch();
            ReadImplement ReadImplement = new ReadImplement("TP_B3");
            BufferImplement BufferImplement = new BufferImplement("TP_B3_BUFFER");
            WriteImplement WriteImplement = new WriteImplement("TP_B3_BUFFER", "TP_DSCCR");
            int.TryParse(ConfigurationManager.AppSettings["ExecuteAlertSecond"], out int executeAlertSecond);

            //AHU_004F
            try
            {
                Log("[{1}] {0} : {2}", "AHU_004F", TaskId, "Start");
                total.Restart();

                unit.Restart();
                AHU_004F AHU_004F = ReadImplement.ReadDataFromAHU_004F();
                unit.Stop();
                Log("[{1}] {0} : {2}", "AHU_004F", TaskId, "Read Time=" + unit.Elapsed.TotalMilliseconds.ToString() + "ms");
                Log("[{1}] {0} : {2}", "AHU_004F", TaskId, "Data=" + JsonConvert.SerializeObject(AHU_004F));
                if (AHU_004F != null)
                {
                    unit.Restart();
                    buffer = (BufferImplement.WriteBufferForAHU_004F(AHU_004F));
                    unit.Stop();
                    Log("[{1}] {0} : {2}", "AHU_004F", TaskId, "Buffer Time=" + unit.Elapsed.TotalMilliseconds.ToString() + "ms");
                    if (buffer)
                    {
                        unit.Restart();
                        affected = WriteImplement.WriteDataForAHU_004F(AHU_004F);
                        unit.Stop();
                        Log("[{1}] {0} : {2}", "AHU_004F", TaskId, "Write Time=" + unit.Elapsed.TotalMilliseconds.ToString() + "ms");
                    }
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

            //AHU_0B1F
            try
            {
                Log("[{1}] {0} : {2}", "AHU_0B1F", TaskId, "Start");
                total.Restart();

                unit.Restart();
                AHU_0B1F AHU_0B1F = ReadImplement.ReadDataFromAHU_0B1F();
                unit.Stop();
                Log("[{1}] {0} : {2}", "AHU_0B1F", TaskId, "Read Time=" + unit.Elapsed.TotalMilliseconds.ToString() + "ms");
                Log("[{1}] {0} : {2}", "AHU_0B1F", TaskId, "Data=" + JsonConvert.SerializeObject(AHU_0B1F));
                if (AHU_0B1F != null)
                {
                    unit.Restart();
                    buffer = (BufferImplement.WriteBufferForAHU_0B1F(AHU_0B1F));
                    unit.Stop();
                    Log("[{1}] {0} : {2}", "AHU_0B1F", TaskId, "Buffer Time=" + unit.Elapsed.TotalMilliseconds.ToString() + "ms");
                    if (buffer)
                    {
                        unit.Restart();
                        affected = WriteImplement.WriteDataForAHU_0B1F(AHU_0B1F);
                        unit.Stop();
                        Log("[{1}] {0} : {2}", "AHU_0B1F", TaskId, "Write Time=" + unit.Elapsed.TotalMilliseconds.ToString() + "ms");
                    }
                }
                total.Stop();
                string alert = "";
                if (total.Elapsed.Seconds > executeAlertSecond)
                {
                    alert = total.Elapsed.Seconds > executeAlertSecond ? " > " + executeAlertSecond.ToString() : "";
                    EventLog(EventLogEnum.EXECUTE_ALERT_SECOND, EventLogEntryType.Warning, "[{1}] {0} : {2}", "AHU_0B1F", TaskId, "End Time=" + total.Elapsed.Seconds.ToString() + "seconds" + alert);
                }
                Log("[{1}] {0} : {2}", "AHU_0B1F", TaskId, "End Time=" + total.Elapsed.Seconds.ToString() + "seconds" + alert);
            }
            catch (Exception ex)
            {
                Log("[{1}] {0} : {2}", "AHU_0B1F", TaskId, "Error=" + ex.Message + ex.StackTrace);
                EventLog(EventLogEnum.EXCEPTION, EventLogEntryType.Error, "[{1}] {0} : {2}", "AHU_0B1F", TaskId, "Error=" + ex.Message + ex.StackTrace);
            }

            //AHU_00RF
            try
            {
                Log("[{1}] {0} : {2}", "AHU_00RF", TaskId, "Start");
                total.Restart();

                unit.Restart();
                AHU_00RF AHU_00RF = ReadImplement.ReadDataFromAHU_00RF();
                unit.Stop();
                Log("[{1}] {0} : {2}", "AHU_00RF", TaskId, "Read Time=" + unit.Elapsed.TotalMilliseconds.ToString() + "ms");
                Log("[{1}] {0} : {2}", "AHU_00RF", TaskId, "Data=" + JsonConvert.SerializeObject(AHU_00RF));
                if (AHU_00RF != null)
                {
                    unit.Restart();
                    buffer = (BufferImplement.WriteBufferForAHU_00RF(AHU_00RF));
                    unit.Stop();
                    Log("[{1}] {0} : {2}", "AHU_00RF", TaskId, "Buffer Time=" + unit.Elapsed.TotalMilliseconds.ToString() + "ms");
                    if (buffer)
                    {
                        unit.Restart();
                        affected = WriteImplement.WriteDataForAHU_00RF(AHU_00RF);
                        unit.Stop();
                        Log("[{1}] {0} : {2}", "AHU_00RF", TaskId, "Write Time=" + unit.Elapsed.TotalMilliseconds.ToString() + "ms");
                    }
                }
                total.Stop();
                string alert = "";
                if (total.Elapsed.Seconds > executeAlertSecond)
                {
                    alert = total.Elapsed.Seconds > executeAlertSecond ? " > " + executeAlertSecond.ToString() : "";
                    EventLog(EventLogEnum.EXECUTE_ALERT_SECOND, EventLogEntryType.Warning, "[{1}] {0} : {2}", "AHU_00RF", TaskId, "End Time=" + total.Elapsed.Seconds.ToString() + "seconds" + alert);
                }
                Log("[{1}] {0} : {2}", "AHU_00RF", TaskId, "End Time=" + total.Elapsed.Seconds.ToString() + "seconds" + alert);
            }
            catch (Exception ex)
            {
                Log("[{1}] {0} : {2}", "AHU_00RF", TaskId, "Error=" + ex.Message + ex.StackTrace);
                EventLog(EventLogEnum.EXCEPTION, EventLogEntryType.Error, "[{1}] {0} : {2}", "AHU_00RF", TaskId, "Error=" + ex.Message + ex.StackTrace);
            }

            //AHU_014F
            try
            {
                Log("[{1}] {0} : {2}", "AHU_014F", TaskId, "Start");
                total.Restart();

                unit.Restart();
                AHU_014F AHU_014F = ReadImplement.ReadDataFromAHU_014F();
                unit.Stop();
                Log("[{1}] {0} : {2}", "AHU_014F", TaskId, "Read Time=" + unit.Elapsed.TotalMilliseconds.ToString() + "ms");
                Log("[{1}] {0} : {2}", "AHU_014F", TaskId, "Data=" + JsonConvert.SerializeObject(AHU_014F));
                if (AHU_014F != null)
                {
                    unit.Restart();
                    buffer = (BufferImplement.WriteBufferForAHU_014F(AHU_014F));
                    unit.Stop();
                    Log("[{1}] {0} : {2}", "AHU_014F", TaskId, "Buffer Time=" + unit.Elapsed.TotalMilliseconds.ToString() + "ms");
                    if (buffer)
                    {
                        unit.Restart();
                        affected = WriteImplement.WriteDataForAHU_014F(AHU_014F);
                        unit.Stop();
                        Log("[{1}] {0} : {2}", "AHU_014F", TaskId, "Write Time=" + unit.Elapsed.TotalMilliseconds.ToString() + "ms");
                    }
                }
                total.Stop();
                string alert = "";
                if (total.Elapsed.Seconds > executeAlertSecond)
                {
                    alert = total.Elapsed.Seconds > executeAlertSecond ? " > " + executeAlertSecond.ToString() : "";
                    EventLog(EventLogEnum.EXECUTE_ALERT_SECOND, EventLogEntryType.Warning, "[{1}] {0} : {2}", "AHU_014F", TaskId, "End Time=" + total.Elapsed.Seconds.ToString() + "seconds" + alert);
                }
                Log("[{1}] {0} : {2}", "AHU_014F", TaskId, "End Time=" + total.Elapsed.Seconds.ToString() + "seconds" + alert);
            }
            catch (Exception ex)
            {
                Log("[{1}] {0} : {2}", "AHU_014F", TaskId, "Error=" + ex.Message + ex.StackTrace);
                EventLog(EventLogEnum.EXCEPTION, EventLogEntryType.Error, "[{1}] {0} : {2}", "AHU_014F", TaskId, "Error=" + ex.Message + ex.StackTrace);
            }

            //AHU_S03F
            try
            {
                Log("[{1}] {0} : {2}", "AHU_S03F", TaskId, "Start");
                total.Restart();

                unit.Restart();
                AHU_S03F AHU_S03F = ReadImplement.ReadDataFromAHU_S03F();
                unit.Stop();
                Log("[{1}] {0} : {2}", "AHU_S03F", TaskId, "Read Time=" + unit.Elapsed.TotalMilliseconds.ToString() + "ms");
                Log("[{1}] {0} : {2}", "AHU_S03F", TaskId, "Data=" + JsonConvert.SerializeObject(AHU_S03F));
                if (AHU_S03F != null)
                {
                    unit.Restart();
                    buffer = (BufferImplement.WriteBufferForAHU_S03F(AHU_S03F));
                    unit.Stop();
                    Log("[{1}] {0} : {2}", "AHU_S03F", TaskId, "Buffer Time=" + unit.Elapsed.TotalMilliseconds.ToString() + "ms");
                    if (buffer)
                    {
                        unit.Restart();
                        affected = WriteImplement.WriteDataForAHU_S03F(AHU_S03F);
                        unit.Stop();
                        Log("[{1}] {0} : {2}", "AHU_S03F", TaskId, "Write Time=" + unit.Elapsed.TotalMilliseconds.ToString() + "ms");
                    }
                }
                total.Stop();
                string alert = "";
                if (total.Elapsed.Seconds > executeAlertSecond)
                {
                    alert = total.Elapsed.Seconds > executeAlertSecond ? " > " + executeAlertSecond.ToString() : "";
                    EventLog(EventLogEnum.EXECUTE_ALERT_SECOND, EventLogEntryType.Warning, "[{1}] {0} : {2}", "AHU_S03F", TaskId, "End Time=" + total.Elapsed.Seconds.ToString() + "seconds" + alert);
                }
                Log("[{1}] {0} : {2}", "AHU_S03F", TaskId, "End Time=" + total.Elapsed.Seconds.ToString() + "seconds" + alert);
            }
            catch (Exception ex)
            {
                Log("[{1}] {0} : {2}", "AHU_S03F", TaskId, "Error=" + ex.Message + ex.StackTrace);
                EventLog(EventLogEnum.EXCEPTION, EventLogEntryType.Error, "[{1}] {0} : {2}", "AHU_S03F", TaskId, "Error=" + ex.Message + ex.StackTrace);
            }

            //AHU_SB1F
            try
            {
                Log("[{1}] {0} : {2}", "AHU_SB1F", TaskId, "Start");
                total.Restart();

                unit.Restart();
                AHU_SB1F AHU_SB1F = ReadImplement.ReadDataFromAHU_SB1F();
                unit.Stop();
                Log("[{1}] {0} : {2}", "AHU_SB1F", TaskId, "Read Time=" + unit.Elapsed.TotalMilliseconds.ToString() + "ms");
                Log("[{1}] {0} : {2}", "AHU_SB1F", TaskId, "Data=" + JsonConvert.SerializeObject(AHU_SB1F));
                if (AHU_SB1F != null)
                {
                    unit.Restart();
                    buffer = (BufferImplement.WriteBufferForAHU_SB1F(AHU_SB1F));
                    unit.Stop();
                    Log("[{1}] {0} : {2}", "AHU_SB1F", TaskId, "Buffer Time=" + unit.Elapsed.TotalMilliseconds.ToString() + "ms");
                    if (buffer)
                    {
                        unit.Restart();
                        affected = WriteImplement.WriteDataForAHU_SB1F(AHU_SB1F);
                        unit.Stop();
                        Log("[{1}] {0} : {2}", "AHU_SB1F", TaskId, "Write Time=" + unit.Elapsed.TotalMilliseconds.ToString() + "ms");
                    }
                }
                total.Stop();
                string alert = "";
                if (total.Elapsed.Seconds > executeAlertSecond)
                {
                    alert = total.Elapsed.Seconds > executeAlertSecond ? " > " + executeAlertSecond.ToString() : "";
                    EventLog(EventLogEnum.EXECUTE_ALERT_SECOND, EventLogEntryType.Warning, "[{1}] {0} : {2}", "AHU_SB1F", TaskId, "End Time=" + total.Elapsed.Seconds.ToString() + "seconds" + alert);
                }
                Log("[{1}] {0} : {2}", "AHU_SB1F", TaskId, "End Time=" + total.Elapsed.Seconds.ToString() + "seconds" + alert);
            }
            catch (Exception ex)
            {
                Log("[{1}] {0} : {2}", "AHU_SB1F", TaskId, "Error=" + ex.Message + ex.StackTrace);
                EventLog(EventLogEnum.EXCEPTION, EventLogEntryType.Error, "[{1}] {0} : {2}", "AHU_SB1F", TaskId, "Error=" + ex.Message + ex.StackTrace);
            }

            //Chiller
            try
            {
                Log("[{1}] {0} : {2}", "Chiller", TaskId, "Start");
                total.Restart();

                unit.Restart();
                Chiller Chiller = ReadImplement.ReadDataFromChiller();
                unit.Stop();
                Log("[{1}] {0} : {2}", "Chiller", TaskId, "Read Time=" + unit.Elapsed.TotalMilliseconds.ToString() + "ms");
                Log("[{1}] {0} : {2}", "Chiller", TaskId, "Data=" + JsonConvert.SerializeObject(Chiller));
                if (Chiller != null)
                {
                    unit.Restart();
                    buffer = (BufferImplement.WriteBufferForChiller(Chiller));
                    unit.Stop();
                    Log("[{1}] {0} : {2}", "Chiller", TaskId, "Buffer Time=" + unit.Elapsed.TotalMilliseconds.ToString() + "ms");
                    if (buffer)
                    {
                        unit.Restart();
                        affected = WriteImplement.WriteDataForChiller(Chiller);
                        unit.Stop();
                        Log("[{1}] {0} : {2}", "Chiller", TaskId, "Write Time=" + unit.Elapsed.TotalMilliseconds.ToString() + "ms");
                    }
                }
                total.Stop();
                string alert = "";
                if (total.Elapsed.Seconds > executeAlertSecond)
                {
                    alert = total.Elapsed.Seconds > executeAlertSecond ? " > " + executeAlertSecond.ToString() : "";
                    EventLog(EventLogEnum.EXECUTE_ALERT_SECOND, EventLogEntryType.Warning, "[{1}] {0} : {2}", "Chiller", TaskId, "End Time=" + total.Elapsed.Seconds.ToString() + "seconds" + alert);
                }
                Log("[{1}] {0} : {2}", "Chiller", TaskId, "End Time=" + total.Elapsed.Seconds.ToString() + "seconds" + alert);
            }
            catch (Exception ex)
            {
                Log("[{1}] {0} : {2}", "Chiller", TaskId, "Error=" + ex.Message + ex.StackTrace);
                EventLog(EventLogEnum.EXCEPTION, EventLogEntryType.Error, "[{1}] {0} : {2}", "Chiller", TaskId, "Error=" + ex.Message + ex.StackTrace);
            }

            //COP
            try
            {
                Log("[{1}] {0} : {2}", "COP", TaskId, "Start");
                total.Restart();

                unit.Restart();
                COP COP = ReadImplement.ReadDataFromCOP();
                unit.Stop();
                Log("[{1}] {0} : {2}", "COP", TaskId, "Read Time=" + unit.Elapsed.TotalMilliseconds.ToString() + "ms");
                Log("[{1}] {0} : {2}", "COP", TaskId, "Data=" + JsonConvert.SerializeObject(COP));
                if (COP != null)
                {
                    unit.Restart();
                    buffer = (BufferImplement.WriteBufferForCOP(COP));
                    unit.Stop();
                    Log("[{1}] {0} : {2}", "COP", TaskId, "Buffer Time=" + unit.Elapsed.TotalMilliseconds.ToString() + "ms");
                    if (buffer)
                    {
                        unit.Restart();
                        affected = WriteImplement.WriteDataForCOP(COP);
                        unit.Stop();
                        Log("[{1}] {0} : {2}", "COP", TaskId, "Write Time=" + unit.Elapsed.TotalMilliseconds.ToString() + "ms");
                    }
                }
                total.Stop();
                string alert = "";
                if (total.Elapsed.Seconds > executeAlertSecond)
                {
                    alert = total.Elapsed.Seconds > executeAlertSecond ? " > " + executeAlertSecond.ToString() : "";
                    EventLog(EventLogEnum.EXECUTE_ALERT_SECOND, EventLogEntryType.Warning, "[{1}] {0} : {2}", "COP", TaskId, "End Time=" + total.Elapsed.Seconds.ToString() + "seconds" + alert);
                }
                Log("[{1}] {0} : {2}", "COP", TaskId, "End Time=" + total.Elapsed.Seconds.ToString() + "seconds" + alert);
            }
            catch (Exception ex)
            {
                Log("[{1}] {0} : {2}", "COP", TaskId, "Error=" + ex.Message + ex.StackTrace);
                EventLog(EventLogEnum.EXCEPTION, EventLogEntryType.Error, "[{1}] {0} : {2}", "COP", TaskId, "Error=" + ex.Message + ex.StackTrace);
            }

            //CP
            try
            {
                Log("[{1}] {0} : {2}", "CP", TaskId, "Start");
                total.Restart();

                unit.Restart();
                CP CP = ReadImplement.ReadDataFromCP();
                unit.Stop();
                Log("[{1}] {0} : {2}", "CP", TaskId, "Read Time=" + unit.Elapsed.TotalMilliseconds.ToString() + "ms");
                Log("[{1}] {0} : {2}", "CP", TaskId, "Data=" + JsonConvert.SerializeObject(CP));
                if (CP != null)
                {
                    unit.Restart();
                    buffer = (BufferImplement.WriteBufferForCP(CP));
                    unit.Stop();
                    Log("[{1}] {0} : {2}", "CP", TaskId, "Buffer Time=" + unit.Elapsed.TotalMilliseconds.ToString() + "ms");
                    if (buffer)
                    {
                        unit.Restart();
                        affected = WriteImplement.WriteDataForCP(CP);
                        unit.Stop();
                        Log("[{1}] {0} : {2}", "CP", TaskId, "Write Time=" + unit.Elapsed.TotalMilliseconds.ToString() + "ms");
                    }
                }
                total.Stop();
                string alert = "";
                if (total.Elapsed.Seconds > executeAlertSecond)
                {
                    alert = total.Elapsed.Seconds > executeAlertSecond ? " > " + executeAlertSecond.ToString() : "";
                    EventLog(EventLogEnum.EXECUTE_ALERT_SECOND, EventLogEntryType.Warning, "[{1}] {0} : {2}", "CP", TaskId, "End Time=" + total.Elapsed.Seconds.ToString() + "seconds" + alert);
                }
                Log("[{1}] {0} : {2}", "CP", TaskId, "End Time=" + total.Elapsed.Seconds.ToString() + "seconds" + alert);
            }
            catch (Exception ex)
            {
                Log("[{1}] {0} : {2}", "CP", TaskId, "Error=" + ex.Message + ex.StackTrace);
                EventLog(EventLogEnum.EXCEPTION, EventLogEntryType.Error, "[{1}] {0} : {2}", "CP", TaskId, "Error=" + ex.Message + ex.StackTrace);
            }

            //CT
            try
            {
                Log("[{1}] {0} : {2}", "CT", TaskId, "Start");
                total.Restart();

                unit.Restart();
                CT CT = ReadImplement.ReadDataFromCT();
                unit.Stop();
                Log("[{1}] {0} : {2}", "CT", TaskId, "Read Time=" + unit.Elapsed.TotalMilliseconds.ToString() + "ms");
                Log("[{1}] {0} : {2}", "CT", TaskId, "Data=" + JsonConvert.SerializeObject(CT));
                if (CT != null)
                {
                    unit.Restart();
                    buffer = (BufferImplement.WriteBufferForCT(CT));
                    unit.Stop();
                    Log("[{1}] {0} : {2}", "CT", TaskId, "Buffer Time=" + unit.Elapsed.TotalMilliseconds.ToString() + "ms");
                    if (buffer)
                    {
                        unit.Restart();
                        affected = WriteImplement.WriteDataForCT(CT);
                        unit.Stop();
                        Log("[{1}] {0} : {2}", "CT", TaskId, "Write Time=" + unit.Elapsed.TotalMilliseconds.ToString() + "ms");
                    }
                }
                total.Stop();
                string alert = "";
                if (total.Elapsed.Seconds > executeAlertSecond)
                {
                    alert = total.Elapsed.Seconds > executeAlertSecond ? " > " + executeAlertSecond.ToString() : "";
                    EventLog(EventLogEnum.EXECUTE_ALERT_SECOND, EventLogEntryType.Warning, "[{1}] {0} : {2}", "CT", TaskId, "End Time=" + total.Elapsed.Seconds.ToString() + "seconds" + alert);
                }
                Log("[{1}] {0} : {2}", "CT", TaskId, "End Time=" + total.Elapsed.Seconds.ToString() + "seconds" + alert);
            }
            catch (Exception ex)
            {
                Log("[{1}] {0} : {2}", "CT", TaskId, "Error=" + ex.Message + ex.StackTrace);
                EventLog(EventLogEnum.EXCEPTION, EventLogEntryType.Error, "[{1}] {0} : {2}", "CT", TaskId, "Error=" + ex.Message + ex.StackTrace);
            }

            //ZP
            try
            {
                Log("[{1}] {0} : {2}", "ZP", TaskId, "Start");
                total.Restart();

                unit.Restart();
                ZP ZP = ReadImplement.ReadDataFromZP();
                unit.Stop();
                Log("[{1}] {0} : {2}", "ZP", TaskId, "Read Time=" + unit.Elapsed.TotalMilliseconds.ToString() + "ms");
                Log("[{1}] {0} : {2}", "ZP", TaskId, "Data=" + JsonConvert.SerializeObject(ZP));
                if (ZP != null)
                {
                    unit.Restart();
                    buffer = (BufferImplement.WriteBufferForZP(ZP));
                    unit.Stop();
                    Log("[{1}] {0} : {2}", "ZP", TaskId, "Buffer Time=" + unit.Elapsed.TotalMilliseconds.ToString() + "ms");
                    if (buffer)
                    {
                        unit.Restart();
                        affected = WriteImplement.WriteDataForZP(ZP);
                        unit.Stop();
                        Log("[{1}] {0} : {2}", "ZP", TaskId, "Write Time=" + unit.Elapsed.TotalMilliseconds.ToString() + "ms");
                    }
                }
                total.Stop();
                string alert = "";
                if (total.Elapsed.Seconds > executeAlertSecond)
                {
                    alert = total.Elapsed.Seconds > executeAlertSecond ? " > " + executeAlertSecond.ToString() : "";
                    EventLog(EventLogEnum.EXECUTE_ALERT_SECOND, EventLogEntryType.Warning, "[{1}] {0} : {2}", "ZP", TaskId, "End Time=" + total.Elapsed.Seconds.ToString() + "seconds" + alert);
                }
                Log("[{1}] {0} : {2}", "ZP", TaskId, "End Time=" + total.Elapsed.Seconds.ToString() + "seconds" + alert);
            }
            catch (Exception ex)
            {
                Log("[{1}] {0} : {2}", "ZP", TaskId, "Error=" + ex.Message + ex.StackTrace);
                EventLog(EventLogEnum.EXCEPTION, EventLogEntryType.Error, "[{1}] {0} : {2}", "ZP", TaskId, "Error=" + ex.Message + ex.StackTrace);
            }

            //RRS_VFLH
            try
            {
                Log("[{1}] {0} : {2}", "RRS_VFLH", TaskId, "Start");
                total.Restart();

                unit.Restart();
                RRS_VFLH RRS_VFLH = ReadImplement.ReadDataFromRRS_VFLH();
                unit.Stop();
                Log("[{1}] {0} : {2}", "RRS_VFLH", TaskId, "Read Time=" + unit.Elapsed.TotalMilliseconds.ToString() + "ms");
                Log("[{1}] {0} : {2}", "RRS_VFLH", TaskId, "Data=" + JsonConvert.SerializeObject(RRS_VFLH));
                if (RRS_VFLH != null)
                {
                    unit.Restart();
                    buffer = (BufferImplement.WriteBufferForRRS_VFLH(RRS_VFLH));
                    unit.Stop();
                    Log("[{1}] {0} : {2}", "RRS_VFLH", TaskId, "Buffer Time=" + unit.Elapsed.TotalMilliseconds.ToString() + "ms");
                    if (buffer)
                    {
                        unit.Restart();
                        affected = WriteImplement.WriteDataForRRS_VFLH(RRS_VFLH);
                        unit.Stop();
                        Log("[{1}] {0} : {2}", "RRS_VFLH", TaskId, "Write Time=" + unit.Elapsed.TotalMilliseconds.ToString() + "ms");
                    }
                }
                total.Stop();
                string alert = "";
                if (total.Elapsed.Seconds > executeAlertSecond)
                {
                    alert = total.Elapsed.Seconds > executeAlertSecond ? " > " + executeAlertSecond.ToString() : "";
                    EventLog(EventLogEnum.EXECUTE_ALERT_SECOND, EventLogEntryType.Warning, "[{1}] {0} : {2}", "RRS_VFLH", TaskId, "End Time=" + total.Elapsed.Seconds.ToString() + "seconds" + alert);
                }
                Log("[{1}] {0} : {2}", "RRS_VFLH", TaskId, "End Time=" + total.Elapsed.Seconds.ToString() + "seconds" + alert);
            }
            catch (Exception ex)
            {
                Log("[{1}] {0} : {2}", "RRS_VFLH", TaskId, "Error=" + ex.Message + ex.StackTrace);
                EventLog(EventLogEnum.EXCEPTION, EventLogEntryType.Error, "[{1}] {0} : {2}", "RRS_VFLH", TaskId, "Error=" + ex.Message + ex.StackTrace);
            }

            //RRS_PVOI
            try
            {
                Log("[{1}] {0} : {2}", "RRS_PVOI", TaskId, "Start");
                total.Restart();

                unit.Restart();
                RRS_PVOI RRS_PVOI = ReadImplement.ReadDataFromRRS_PVOI();
                unit.Stop();
                Log("[{1}] {0} : {2}", "RRS_PVOI", TaskId, "Read Time=" + unit.Elapsed.TotalMilliseconds.ToString() + "ms");
                Log("[{1}] {0} : {2}", "RRS_PVOI", TaskId, "Data=" + JsonConvert.SerializeObject(RRS_PVOI));
                if (RRS_PVOI != null)
                {
                    unit.Restart();
                    buffer = (BufferImplement.WriteBufferForRRS_PVOI(RRS_PVOI));
                    unit.Stop();
                    Log("[{1}] {0} : {2}", "RRS_PVOI", TaskId, "Buffer Time=" + unit.Elapsed.TotalMilliseconds.ToString() + "ms");
                    if (buffer)
                    {
                        unit.Restart();
                        affected = WriteImplement.WriteDataForRRS_PVOI(RRS_PVOI);
                        unit.Stop();
                        Log("[{1}] {0} : {2}", "RRS_PVOI", TaskId, "Write Time=" + unit.Elapsed.TotalMilliseconds.ToString() + "ms");
                    }
                }
                total.Stop();
                string alert = "";
                if (total.Elapsed.Seconds > executeAlertSecond)
                {
                    alert = total.Elapsed.Seconds > executeAlertSecond ? " > " + executeAlertSecond.ToString() : "";
                    EventLog(EventLogEnum.EXECUTE_ALERT_SECOND, EventLogEntryType.Warning, "[{1}] {0} : {2}", "RRS_PVOI", TaskId, "End Time=" + total.Elapsed.Seconds.ToString() + "seconds" + alert);
                }
                Log("[{1}] {0} : {2}", "RRS_PVOI", TaskId, "End Time=" + total.Elapsed.Seconds.ToString() + "seconds" + alert);
            }
            catch (Exception ex)
            {
                Log("[{1}] {0} : {2}", "RRS_PVOI", TaskId, "Error=" + ex.Message + ex.StackTrace);
                EventLog(EventLogEnum.EXCEPTION, EventLogEntryType.Error, "[{1}] {0} : {2}", "RRS_PVOI", TaskId, "Error=" + ex.Message + ex.StackTrace);
            }

            //RRS_PWLS
            try
            {
                Log("[{1}] {0} : {2}", "RRS_PWLS", TaskId, "Start");
                total.Restart();

                unit.Restart();
                RRS_PWLS RRS_PWLS = ReadImplement.ReadDataFromRRS_PWLS();
                unit.Stop();
                Log("[{1}] {0} : {2}", "RRS_PWLS", TaskId, "Read Time=" + unit.Elapsed.TotalMilliseconds.ToString() + "ms");
                Log("[{1}] {0} : {2}", "RRS_PWLS", TaskId, "Data=" + JsonConvert.SerializeObject(RRS_PWLS));
                if (RRS_PWLS != null)
                {
                    unit.Restart();
                    buffer = (BufferImplement.WriteBufferForRRS_PWLS(RRS_PWLS));
                    unit.Stop();
                    Log("[{1}] {0} : {2}", "RRS_PWLS", TaskId, "Buffer Time=" + unit.Elapsed.TotalMilliseconds.ToString() + "ms");
                    if (buffer)
                    {
                        unit.Restart();
                        affected = WriteImplement.WriteDataForRRS_PWLS(RRS_PWLS);
                        unit.Stop();
                        Log("[{1}] {0} : {2}", "RRS_PWLS", TaskId, "Write Time=" + unit.Elapsed.TotalMilliseconds.ToString() + "ms");
                    }
                }
                total.Stop();
                string alert = "";
                if (total.Elapsed.Seconds > executeAlertSecond)
                {
                    alert = total.Elapsed.Seconds > executeAlertSecond ? " > " + executeAlertSecond.ToString() : "";
                    EventLog(EventLogEnum.EXECUTE_ALERT_SECOND, EventLogEntryType.Warning, "[{1}] {0} : {2}", "RRS_PWLS", TaskId, "End Time=" + total.Elapsed.Seconds.ToString() + "seconds" + alert);
                }
                Log("[{1}] {0} : {2}", "RRS_PWLS", TaskId, "End Time=" + total.Elapsed.Seconds.ToString() + "seconds" + alert);
            }
            catch (Exception ex)
            {
                Log("[{1}] {0} : {2}", "RRS_PWLS", TaskId, "Error=" + ex.Message + ex.StackTrace);
                EventLog(EventLogEnum.EXCEPTION, EventLogEntryType.Error, "[{1}] {0} : {2}", "RRS_PWLS", TaskId, "Error=" + ex.Message + ex.StackTrace);
            }

            //WSDS_PVOI
            try
            {
                Log("[{1}] {0} : {2}", "WSDS_PVOI", TaskId, "Start");
                total.Restart();

                unit.Restart();
                WSDS_PVOI WSDS_PVOI = ReadImplement.ReadDataFromWSDS_PVOI();
                unit.Stop();
                Log("[{1}] {0} : {2}", "WSDS_PVOI", TaskId, "Read Time=" + unit.Elapsed.TotalMilliseconds.ToString() + "ms");
                Log("[{1}] {0} : {2}", "WSDS_PVOI", TaskId, "Data=" + JsonConvert.SerializeObject(WSDS_PVOI));
                if (WSDS_PVOI != null)
                {
                    unit.Restart();
                    buffer = (BufferImplement.WriteBufferForWSDS_PVOI(WSDS_PVOI));
                    unit.Stop();
                    Log("[{1}] {0} : {2}", "WSDS_PVOI", TaskId, "Buffer Time=" + unit.Elapsed.TotalMilliseconds.ToString() + "ms");
                    if (buffer)
                    {
                        unit.Restart();
                        affected = WriteImplement.WriteDataForWSDS_PVOI(WSDS_PVOI);
                        unit.Stop();
                        Log("[{1}] {0} : {2}", "WSDS_PVOI", TaskId, "Write Time=" + unit.Elapsed.TotalMilliseconds.ToString() + "ms");
                    }
                }
                total.Stop();
                string alert = "";
                if (total.Elapsed.Seconds > executeAlertSecond)
                {
                    alert = total.Elapsed.Seconds > executeAlertSecond ? " > " + executeAlertSecond.ToString() : "";
                    EventLog(EventLogEnum.EXECUTE_ALERT_SECOND, EventLogEntryType.Warning, "[{1}] {0} : {2}", "WSDS_PVOI", TaskId, "End Time=" + total.Elapsed.Seconds.ToString() + "seconds" + alert);
                }
                Log("[{1}] {0} : {2}", "WSDS_PVOI", TaskId, "End Time=" + total.Elapsed.Seconds.ToString() + "seconds" + alert);
            }
            catch (Exception ex)
            {
                Log("[{1}] {0} : {2}", "WSDS_PVOI", TaskId, "Error=" + ex.Message + ex.StackTrace);
                EventLog(EventLogEnum.EXCEPTION, EventLogEntryType.Error, "[{1}] {0} : {2}", "WSDS_PVOI", TaskId, "Error=" + ex.Message + ex.StackTrace);
            }

            //WSDS_PWLS
            try
            {
                Log("[{1}] {0} : {2}", "WSDS_PWLS", TaskId, "Start");
                total.Restart();

                unit.Restart();
                WSDS_PWLS WSDS_PWLS = ReadImplement.ReadDataFromWSDS_PWLS();
                unit.Stop();
                Log("[{1}] {0} : {2}", "WSDS_PWLS", TaskId, "Read Time=" + unit.Elapsed.TotalMilliseconds.ToString() + "ms");
                Log("[{1}] {0} : {2}", "WSDS_PWLS", TaskId, "Data=" + JsonConvert.SerializeObject(WSDS_PWLS));
                if (WSDS_PWLS != null)
                {
                    unit.Restart();
                    buffer = (BufferImplement.WriteBufferForWSDS_PWLS(WSDS_PWLS));
                    unit.Stop();
                    Log("[{1}] {0} : {2}", "WSDS_PWLS", TaskId, "Buffer Time=" + unit.Elapsed.TotalMilliseconds.ToString() + "ms");
                    if (buffer)
                    {
                        unit.Restart();
                        affected = WriteImplement.WriteDataForWSDS_PWLS(WSDS_PWLS);
                        unit.Stop();
                        Log("[{1}] {0} : {2}", "WSDS_PWLS", TaskId, "Write Time=" + unit.Elapsed.TotalMilliseconds.ToString() + "ms");
                    }
                }
                total.Stop();
                string alert = "";
                if (total.Elapsed.Seconds > executeAlertSecond)
                {
                    alert = total.Elapsed.Seconds > executeAlertSecond ? " > " + executeAlertSecond.ToString() : "";
                    EventLog(EventLogEnum.EXECUTE_ALERT_SECOND, EventLogEntryType.Warning, "[{1}] {0} : {2}", "WSDS_PWLS", TaskId, "End Time=" + total.Elapsed.Seconds.ToString() + "seconds" + alert);
                }
                Log("[{1}] {0} : {2}", "WSDS_PWLS", TaskId, "End Time=" + total.Elapsed.Seconds.ToString() + "seconds" + alert);
            }
            catch (Exception ex)
            {
                Log("[{1}] {0} : {2}", "WSDS_PWLS", TaskId, "Error=" + ex.Message + ex.StackTrace);
                EventLog(EventLogEnum.EXCEPTION, EventLogEntryType.Error, "[{1}] {0} : {2}", "WSDS_PWLS", TaskId, "Error=" + ex.Message + ex.StackTrace);
            }

            //End
            Log("[{1}] {0} : {2}", "ProcessData", TaskId, "Done");
        }
    }
}
