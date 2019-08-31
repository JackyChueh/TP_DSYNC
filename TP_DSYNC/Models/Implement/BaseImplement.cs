using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace TP_DSYNC.Models.Implement
{
    public class BaseImplement
    {
        public void Log(string text)
        {
            var stackTrace = new StackTrace();
            var methodBase = stackTrace.GetFrame(1).GetMethod();
            var Class = methodBase.ReflectedType;
            //var Namespace = Class.Namespace;         //Added finding the namespace

            TP_DSYNC.Models.Help.Log.Write(Class.Name + "\\" + methodBase.Name + "\\", text);

        }
        public string GetNullableStringField(SqlDataReader reader, int index)
        {
            if (!Convert.IsDBNull(reader[index]))
            {
                return reader.GetString(index).Trim();
            }
            else
            {
                return "";
            }
        }

        public string GetNullableStringField(SqlDataReader reader, string columnName)
        {
            if (!Convert.IsDBNull(reader[columnName]))
            {
                return reader[columnName] as string;
            }
            else
            {
                return "";
            }
        }

        public int GetNullableIntField(SqlDataReader reader, string columnName)
        {
            if (!Convert.IsDBNull(reader[columnName]))
            {
                return Convert.ToInt32(reader[columnName]);
            }
            else
            {
                return 0;
            }
        }

        public DateTime GetNullableDateTimeField(SqlDataReader reader, string columnName)
        {
            if (!Convert.IsDBNull(reader[columnName]))
            {
                return Convert.ToDateTime(reader[columnName]);
            }
            else
            {
                return new DateTime();
            }
        }
    }
}