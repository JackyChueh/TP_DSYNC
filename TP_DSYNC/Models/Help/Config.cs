using System;
using System.Collections;
using System.Configuration;

namespace TP_DSYNC.Models.Help
{
    public static class Config
    {
        private static Hashtable _Item;
        /// <summary>
        /// 載入全部系統設定值
        /// </summary>
        public static void Load()
        {
            try
            {
                

                _Item = new Hashtable();
                foreach (ConnectionStringSettings c in ConfigurationManager.ConnectionStrings)
                {
                    _Item.Add(c.Name, c.ConnectionString);
                }
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        /// <summary>
        /// 取出指定系統設定值
        /// </summary>
        public static string Item(Object obj)
        {
            try
            {
                if (_Item.ContainsKey(obj))
                    return _Item[obj].ToString();
                else
                    return "";
            }
            catch
            {
                throw;
            }
            finally
            {
            }
        }
    }

}