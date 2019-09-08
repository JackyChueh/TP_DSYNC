using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TP_DSYNC.Models.Help
{
    public  class Logging
    {
        //public Logging()
        //{
        //}

        //private static readonly object locker = new object();
        //private static string _LogPath = System.AppDomain.CurrentDomain.BaseDirectory + "log\\";
        public void Write(string message)
        {
            string _LogPath = System.AppDomain.CurrentDomain.BaseDirectory + "log\\";
            //lock (locker)
            {
                StreamWriter SW;
                SW = File.AppendText(_LogPath+"Log.txt");
                SW.WriteLine(message);
                SW.Close();
            }
        }
    }
}
