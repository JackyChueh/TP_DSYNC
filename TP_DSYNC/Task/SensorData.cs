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
    public class SensorData : BaseTask
    {
        public void ProcessData()
        {
            bool buffer;
            int affected;
          
                ReadImplement ReadImplement = new ReadImplement("TP_B3");
                BufferImplement BufferImplement = new BufferImplement("TP_B3_BUFFER");
                WriteImplement WriteImplement = new WriteImplement("TP_B3_BUFFER", "TP_DSCCR");

            //AHU_004F AHU_004F = ReadImplement.ReadDataFromAHU_004F();
            //AHU_0B1F AHU_0B1F = ReadImplement.ReadDataFromAHU_0B1F();
            //AHU_00RF AHU_00RF = ReadImplement.ReadDataFromAHU_00RF();
            //AHU_014F AHU_014F = ReadImplement.ReadDataFromAHU_014F();
            //AHU_S03F AHU_S03F = ReadImplement.ReadDataFromAHU_S03F();
            //AHU_SB1F AHU_SB1F = ReadImplement.ReadDataFromAHU_SB1F();



            //buffer = (BufferImplement.WriteBufferForAHU_004F(AHU_004F));
            //buffer = (BufferImplement.WriteBufferForAHU_0B1F(AHU_0B1F));
            //buffer = (BufferImplement.WriteBufferForAHU_00RF(AHU_00RF));
            //buffer = (BufferImplement.WriteBufferForAHU_014F(AHU_014F));
            //buffer = (BufferImplement.WriteBufferForAHU_S03F(AHU_S03F));
            //buffer = (BufferImplement.WriteBufferForAHU_SB1F(AHU_SB1F));

            //affected = WriteImplement.WriteDataForAHU_004F(AHU_004F);
            //affected = WriteImplement.WriteDataForAHU_0B1F(AHU_0B1F);
            //affected = WriteImplement.WriteDataForAHU_00RF(AHU_00RF);
            //affected = WriteImplement.WriteDataForAHU_014F(AHU_014F);
            //affected = WriteImplement.WriteDataForAHU_S03F(AHU_S03F);
            //affected = WriteImplement.WriteDataForAHU_SB1F(AHU_SB1F);


            //Chiller Chiller = ReadImplement.ReadDataFromChiller();
            //if (Chiller != null)
            //{
            //    buffer = (BufferImplement.WriteBufferForChiller(Chiller));
            //    if (buffer)
            //    {
            //        affected = WriteImplement.WriteDataForChiller(Chiller);
            //    }
            //}

            //COP COP = ReadImplement.ReadDataFromCOP();
            //if (COP != null)
            //{
            //    buffer = (BufferImplement.WriteBufferForCOP(COP));
            //    if (buffer)
            //    {
            //        affected = WriteImplement.WriteDataForCOP(COP);
            //    }
            //}
            try
            {
                CP CP = ReadImplement.ReadDataFromCP();
                if (CP != null)
                {
                    buffer = (BufferImplement.WriteBufferForCP(CP));
                    if (buffer)
                    {
                        affected = WriteImplement.WriteDataForCP(CP);
                    }
                }

            }
            catch (Exception ex)
            {

                Log("{0} [{1}]: {2}", "CP", ManagedThreadId, ex.Message);
            }
            
            //Log.Write(Thread.CurrentThread.ManagedThreadId.ToString());
            //System.Threading.Thread.Sleep(5000);
            //Log.Write(Thread.CurrentThread.ManagedThreadId.ToString()+ "*");

        }
    }
}