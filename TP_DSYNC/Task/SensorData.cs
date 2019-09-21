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
    public class SensorData: BaseTask
    {
        public static void AHU()
        {
            bool temp;
            int affected;
            AHU_ReadImplement AHU_ReadImplement = new AHU_ReadImplement("TP_B3");
            AHU_BufferImplement AHU_BufferImplement = new AHU_BufferImplement("TP_B3_BUFFER");
            AHU_WriteImplement AHU_WriteImplement = new AHU_WriteImplement("TP_B3_BUFFER", "TP_DSCCR");

            AHU_004F AHU_004F = AHU_ReadImplement.ReadDataFromAHU_004F();
            AHU_0B1F AHU_0B1F = AHU_ReadImplement.ReadDataFromAHU_0B1F();
            AHU_00RF AHU_00RF = AHU_ReadImplement.ReadDataFromAHU_00RF();
            AHU_014F AHU_014F = AHU_ReadImplement.ReadDataFromAHU_014F();
            AHU_S03F AHU_S03F = AHU_ReadImplement.ReadDataFromAHU_S03F();
            AHU_SB1F AHU_SB1F = AHU_ReadImplement.ReadDataFromAHU_SB1F();

            temp = (AHU_BufferImplement.WriteBufferForAHU_004F(AHU_004F));
            temp = (AHU_BufferImplement.WriteBufferForAHU_0B1F(AHU_0B1F));
            temp = (AHU_BufferImplement.WriteBufferForAHU_00RF(AHU_00RF));
            temp = (AHU_BufferImplement.WriteBufferForAHU_014F(AHU_014F));
            temp = (AHU_BufferImplement.WriteBufferForAHU_S03F(AHU_S03F));
            temp = (AHU_BufferImplement.WriteBufferForAHU_SB1F(AHU_SB1F));

            affected = AHU_WriteImplement.WriteDataForAHU_004F(AHU_004F);
            affected = AHU_WriteImplement.WriteDataForAHU_0B1F(AHU_0B1F);
            affected = AHU_WriteImplement.WriteDataForAHU_00RF(AHU_00RF);
            affected = AHU_WriteImplement.WriteDataForAHU_014F(AHU_014F);
            affected = AHU_WriteImplement.WriteDataForAHU_S03F(AHU_S03F);
            affected = AHU_WriteImplement.WriteDataForAHU_SB1F(AHU_SB1F);

            //Log.Write(Thread.CurrentThread.ManagedThreadId.ToString());
            //System.Threading.Thread.Sleep(5000);
            //Log.Write(Thread.CurrentThread.ManagedThreadId.ToString()+ "*");

        }
    }
}
