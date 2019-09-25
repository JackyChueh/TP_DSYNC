using System;
using TP_DSYNC.Models.Implement;
using TP_DSYNC.Models.DataDefine.B3;
using Newtonsoft.Json;

namespace TP_DSYNC.Task
{
    public class SensorData : BaseTask
    {
        public SensorData(DateTime now) : base(now) { }
        public void ProcessData()
        {
            bool buffer;
            int affected;

            ReadImplement ReadImplement = new ReadImplement("TP_B3");
            BufferImplement BufferImplement = new BufferImplement("TP_B3_BUFFER");
            WriteImplement WriteImplement = new WriteImplement("TP_B3_BUFFER", "TP_DSCCR");

            //AHU_004F
            try
            {
                Log("{0} [{1}]: {2}", "AHU_004F", TaskId, "Read");
                AHU_004F AHU_004F = ReadImplement.ReadDataFromAHU_004F();
                Log("{0} [{1}]: {2}", "AHU_004F", TaskId, "Data=" + JsonConvert.SerializeObject(AHU_004F));
                if (AHU_004F != null)
                {
                    Log("{0} [{1}]: {2}", "AHU_004F", TaskId, "Buffer");
                    buffer = (BufferImplement.WriteBufferForAHU_004F(AHU_004F));
                    //Log("{0} [{1}]: {2}", "AHU_004F", ManagedThreadId, "Buffer=" + buffer);
                    if (buffer)
                    {
                        Log("{0} [{1}]: {2}", "AHU_004F", TaskId, "Write");
                        affected = WriteImplement.WriteDataForAHU_004F(AHU_004F);
                    }
                }
                Log("{0} [{1}]: {2}", "AHU_004F", TaskId, "Done");

            }
            catch (Exception ex)
            {
                Log("{0} [{1}]: {2}", "AHU_004F", TaskId, "Error=" + ex.Message + ex.StackTrace);

            }
            //AHU_0B1F
            try
            {
                Log("{0} [{1}]: {2}", "AHU_0B1F", TaskId, "Read");
                AHU_0B1F AHU_0B1F = ReadImplement.ReadDataFromAHU_0B1F();
                Log("{0} [{1}]: {2}", "AHU_0B1F", TaskId, "Data=" + JsonConvert.SerializeObject(AHU_0B1F));
                if (AHU_0B1F != null)
                {
                    Log("{0} [{1}]: {2}", "AHU_0B1F", TaskId, "Buffer");
                    buffer = (BufferImplement.WriteBufferForAHU_0B1F(AHU_0B1F));
                    //Log("{0} [{1}]: {2}", "AHU_0B1F", ManagedThreadId, "Buffer=" + buffer);
                    if (buffer)
                    {
                        Log("{0} [{1}]: {2}", "AHU_0B1F", TaskId, "Write");
                        affected = WriteImplement.WriteDataForAHU_0B1F(AHU_0B1F);
                    }
                }
                Log("{0} [{1}]: {2}", "AHU_0B1F", TaskId, "Done");

            }
            catch (Exception ex)
            {
                Log("{0} [{1}]: {2}", "AHU_0B1F", TaskId, "Error=" + ex.Message + ex.StackTrace);

            }
            //AHU_00RF
            try
            {
                Log("{0} [{1}]: {2}", "AHU_00RF", TaskId, "Read");
                AHU_00RF AHU_00RF = ReadImplement.ReadDataFromAHU_00RF();
                Log("{0} [{1}]: {2}", "AHU_00RF", TaskId, "Data=" + JsonConvert.SerializeObject(AHU_00RF));
                if (AHU_00RF != null)
                {
                    Log("{0} [{1}]: {2}", "AHU_00RF", TaskId, "Buffer");
                    buffer = (BufferImplement.WriteBufferForAHU_00RF(AHU_00RF));
                    //Log("{0} [{1}]: {2}", "AHU_00RF", ManagedThreadId, "Buffer=" + buffer);
                    if (buffer)
                    {
                        Log("{0} [{1}]: {2}", "AHU_00RF", TaskId, "Write");
                        affected = WriteImplement.WriteDataForAHU_00RF(AHU_00RF);
                    }
                }
                Log("{0} [{1}]: {2}", "AHU_00RF", TaskId, "Done");

            }
            catch (Exception ex)
            {
                Log("{0} [{1}]: {2}", "AHU_00RF", TaskId, "Error=" + ex.Message + ex.StackTrace);

            }
            //AHU_014F
            try
            {
                Log("{0} [{1}]: {2}", "AHU_014F", TaskId, "Read");
                AHU_014F AHU_014F = ReadImplement.ReadDataFromAHU_014F();
                Log("{0} [{1}]: {2}", "AHU_014F", TaskId, "Data=" + JsonConvert.SerializeObject(AHU_014F));
                if (AHU_014F != null)
                {
                    Log("{0} [{1}]: {2}", "AHU_014F", TaskId, "Buffer");
                    buffer = (BufferImplement.WriteBufferForAHU_014F(AHU_014F));
                    //Log("{0} [{1}]: {2}", "AHU_014F", ManagedThreadId, "Buffer=" + buffer);
                    if (buffer)
                    {
                        Log("{0} [{1}]: {2}", "AHU_014F", TaskId, "Write");
                        affected = WriteImplement.WriteDataForAHU_014F(AHU_014F);
                    }
                }
                Log("{0} [{1}]: {2}", "AHU_014F", TaskId, "Done");

            }
            catch (Exception ex)
            {
                Log("{0} [{1}]: {2}", "AHU_014F", TaskId, "Error=" + ex.Message + ex.StackTrace);

            }
            //AHU_S03F
            try
            {
                Log("{0} [{1}]: {2}", "AHU_S03F", TaskId, "Read");
                AHU_S03F AHU_S03F = ReadImplement.ReadDataFromAHU_S03F();
                Log("{0} [{1}]: {2}", "AHU_S03F", TaskId, "Data=" + JsonConvert.SerializeObject(AHU_S03F));
                if (AHU_S03F != null)
                {
                    Log("{0} [{1}]: {2}", "AHU_S03F", TaskId, "Buffer");
                    buffer = (BufferImplement.WriteBufferForAHU_S03F(AHU_S03F));
                    //Log("{0} [{1}]: {2}", "AHU_S03F", ManagedThreadId, "Buffer=" + buffer);
                    if (buffer)
                    {
                        Log("{0} [{1}]: {2}", "AHU_S03F", TaskId, "Write");
                        affected = WriteImplement.WriteDataForAHU_S03F(AHU_S03F);
                    }
                }
                Log("{0} [{1}]: {2}", "AHU_S03F", TaskId, "Done");

            }
            catch (Exception ex)
            {
                Log("{0} [{1}]: {2}", "AHU_S03F", TaskId, "Error=" + ex.Message + ex.StackTrace);

            }
            //AHU_SB1F
            try
            {
                Log("{0} [{1}]: {2}", "AHU_SB1F", TaskId, "Read");
                AHU_SB1F AHU_SB1F = ReadImplement.ReadDataFromAHU_SB1F();
                Log("{0} [{1}]: {2}", "AHU_SB1F", TaskId, "Data=" + JsonConvert.SerializeObject(AHU_SB1F));
                if (AHU_SB1F != null)
                {
                    Log("{0} [{1}]: {2}", "AHU_SB1F", TaskId, "Buffer");
                    buffer = (BufferImplement.WriteBufferForAHU_SB1F(AHU_SB1F));
                    //Log("{0} [{1}]: {2}", "AHU_SB1F", ManagedThreadId, "Buffer=" + buffer);
                    if (buffer)
                    {
                        Log("{0} [{1}]: {2}", "AHU_SB1F", TaskId, "Write");
                        affected = WriteImplement.WriteDataForAHU_SB1F(AHU_SB1F);
                    }
                }
                Log("{0} [{1}]: {2}", "AHU_SB1F", TaskId, "Done");

            }
            catch (Exception ex)
            {
                Log("{0} [{1}]: {2}", "AHU_SB1F", TaskId, "Error=" + ex.Message + ex.StackTrace);

            }

            //Chiller
            try
            {
                Log("{0} [{1}]: {2}", "Chiller", TaskId, "Read");
                Chiller Chiller = ReadImplement.ReadDataFromChiller();
                Log("{0} [{1}]: {2}", "Chiller", TaskId, "Data=" + JsonConvert.SerializeObject(Chiller));
                if (Chiller != null)
                {
                    Log("{0} [{1}]: {2}", "Chiller", TaskId, "Buffer");
                    buffer = (BufferImplement.WriteBufferForChiller(Chiller));
                    //Log("{0} [{1}]: {2}", "Chiller", ManagedThreadId, "Buffer=" + buffer);
                    if (buffer)
                    {
                        Log("{0} [{1}]: {2}", "Chiller", TaskId, "Write");
                        affected = WriteImplement.WriteDataForChiller(Chiller);
                    }
                }
                Log("{0} [{1}]: {2}", "Chiller", TaskId, "Done");

            }
            catch (Exception ex)
            {
                Log("{0} [{1}]: {2}", "Chiller", TaskId, "Error=" + ex.Message + ex.StackTrace);

            }

            //COP
            try
            {
                Log("{0} [{1}]: {2}", "COP", TaskId, "Read");
                COP COP = ReadImplement.ReadDataFromCOP();
                Log("{0} [{1}]: {2}", "COP", TaskId, "Data=" + JsonConvert.SerializeObject(COP));
                if (COP != null)
                {
                    Log("{0} [{1}]: {2}", "COP", TaskId, "Buffer");
                    buffer = (BufferImplement.WriteBufferForCOP(COP));
                    //Log("{0} [{1}]: {2}", "COP", ManagedThreadId, "Buffer=" + buffer);
                    if (buffer)
                    {
                        Log("{0} [{1}]: {2}", "COP", TaskId, "Write");
                        affected = WriteImplement.WriteDataForCOP(COP);
                    }
                }
                Log("{0} [{1}]: {2}", "COP", TaskId, "Done");

            }
            catch (Exception ex)
            {
                Log("{0} [{1}]: {2}", "COP", TaskId, "Error=" + ex.Message + ex.StackTrace);

            }

            //CP
            try
            {
                Log("{0} [{1}]: {2}", "CP", TaskId, "Read");
                CP CP = ReadImplement.ReadDataFromCP();
                Log("{0} [{1}]: {2}", "CP", TaskId, "Data=" + JsonConvert.SerializeObject(CP));
                if (CP != null)
                {
                    Log("{0} [{1}]: {2}", "CP", TaskId, "Buffer");
                    buffer = (BufferImplement.WriteBufferForCP(CP));
                    //Log("{0} [{1}]: {2}", "CP", ManagedThreadId, "Buffer=" + buffer);
                    if (buffer)
                    {
                        Log("{0} [{1}]: {2}", "CP", TaskId, "Write");
                        affected = WriteImplement.WriteDataForCP(CP);
                    }
                }
                Log("{0} [{1}]: {2}", "CP", TaskId, "Done");

            }
            catch (Exception ex)
            {
                Log("{0} [{1}]: {2}", "CP", TaskId, "Error=" + ex.Message + ex.StackTrace);

            }

            //Log.Write(Thread.CurrentThread.ManagedThreadId.ToString());
            //System.Threading.Thread.Sleep(5000);
            //Log.Write(Thread.CurrentThread.ManagedThreadId.ToString()+ "*");

        }
    }
}