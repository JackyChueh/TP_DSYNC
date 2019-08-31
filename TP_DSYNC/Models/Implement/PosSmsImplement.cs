using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using TP_DSYNC.Models.DataDefine.WEB711DATA;
using TP_DSYNC.Models.Help;
using TWW_API.ViewModels.Customer;
using TWW_API.ViewModels.ShopFrontSys;

namespace TP_DSYNC.Models.Implement
{
    public class PosSmsImplement: BaseImplement
    {
        //搜尋客戶資料
        public CustomerMgtEntityQueryRes QueryCustomerByPhone(CustomerMgtEntityQueryReq aModel)
        {
            CustomerMgtEntityQueryRes res = new CustomerMgtEntityQueryRes();
            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();

                command.CommandText = "SELECT manno, manna, tel, handtel, addr, money, note1 FROM adata WHERE offno=@branch_id ";

                command.Parameters.AddWithValue("@branch_id", aModel.LoginCmdModel.tww_Store.store_id);
                if (aModel.SearchPhone != null && aModel.SearchPhone != "")
                {
                    command.CommandText += "AND (  handtel LIKE @tel )";
                    command.Parameters.Add("@tel", SqlDbType.NVarChar).Value = "%" + aModel.SearchPhone + "%";
                }
                if (aModel.CustStart != null && aModel.CustStart != "")
                {
                    command.CommandText += "AND (  manno >= @CustStart )";
                    command.Parameters.Add("@CustStart", SqlDbType.Int).Value = aModel.CustStart;
                }
                if (aModel.CustEnd != null && aModel.CustEnd != "")
                {
                    command.CommandText += "AND (  manno <= @CustEnd )";
                    command.Parameters.Add("@CustEnd", SqlDbType.Int).Value = aModel.CustEnd;
                }
                command.CommandText += " order by manno";
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        CustomerMgtEntityViewModel anEntityModel = new CustomerMgtEntityViewModel();

                        anEntityModel.custdata.manno = GetNullableStringField(reader, 0);
                        anEntityModel.custdata.manna = GetNullableStringField(reader, 1);
                        anEntityModel.custdata.tel = GetNullableStringField(reader, 2);
                        anEntityModel.custdata.handtel = GetNullableStringField(reader, 3);
                        anEntityModel.custdata.addr = GetNullableStringField(reader, 4);
                        anEntityModel.custdata.note1 = GetNullableStringField(reader, 6);


                        if (!Convert.IsDBNull(reader[5]))
                        {
                            var recevible = reader.GetSqlDouble(5);
                            anEntityModel.custdata.money = (int)recevible;
                        }

                        res.CustomerMgtEntityModelAllList.Add(anEntityModel);
                    }
                }

            }
            return res;
        }

        //簡訊通知 - 查詢範圍內的簡訊通數
        public SMSRangeCountQueryRes QuerySMSRangeCount(SMSRangeCountQueryReq req)
        {

            string smsmsg;
            double smscount = 0;
            int smstotal = 0;
            SMSRangeCountQueryRes res = new SMSRangeCountQueryRes();

            using (SqlConnection connection = new SqlConnection(Config.Item("WEB711DATA")))
            using (SqlCommand command = new SqlCommand("", connection))
            {

                connection.Open();
                if (req.strDateStart == "" & req.strDateEnd == "")
                {
                    command.CommandText = @"Select SmsLog.content FROM [WEB711DATA].[dbo].[SmsLog]
                                                Where SmsLog.source = @hostid and SmsLog.time >= dateadd(month,datediff(month,0,getdate()),0) and 
                                                SmsLog.time <= dateadd(day,-1,dateadd(month,datediff(month,-1,getdate()),0))";

                }
                else
                {

                    command.CommandText = @"Select SmsLog.content FROM [WEB711DATA].[dbo].[SmsLog]
                                                Where SmsLog.source = @hostid and SmsLog.time >= @StartDay and SmsLog.time <= @EndDay";
                    command.Parameters.AddWithValue("@StartDay", req.strDateStart);
                    command.Parameters.AddWithValue("@EndDay", req.strDateEnd);
                }


                command.Parameters.AddWithValue("@hostid", req.storeId);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        smsmsg = reader.GetString(0);
                        smscount = (int)Math.Ceiling(((float)smsmsg.Length / 70));
                        if (smscount == 0)
                        {
                            smscount = 1;
                        }
                        smstotal += Convert.ToInt32(smscount);

                    }
                }
                connection.Close();
                connection.Dispose();
                res.smstotal = smstotal;
                return res;
            }
        }


        //簡訊通知 - 儲存至簡訊系統
        public void sendSMStoWEB711DATA(SmsSaveReq req)
        {


            using (SqlConnection connection = new SqlConnection(Config.Item("WEB711DATA")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                int res = 0;
                connection.Open();
                SqlTransaction transaction;
                transaction = connection.BeginTransaction();
                command.Connection = connection;
                command.Transaction = transaction;

                foreach (var smslog in req.smsLogs)
                {

                    //發送時間:立即發送 getdate()
                    command.CommandText = "INSERT INTO [WEB711DATA].[dbo].[SmsLog] (phone, content, send, time, source ) " +
                                          "output INSERTED.id VALUES ( '" + smslog.phone + "','" + smslog.content + "', 'N', GETDATE(), '" + smslog.source + "' )";
                    res += command.ExecuteNonQuery();
                }
                if (res != 0)
                    transaction.Commit();
                else
                    transaction.Rollback();

                connection.Close();
                connection.Dispose();
            }



        }


        //簡訊通知 - 查詢簡訊歷史發送紀錄
        public SMSHistroyReportQueryRes querySMSHistroyReport(SMSHistroyReportQueryReq req)
        {
            SMSHistroyReportQueryRes res = new SMSHistroyReportQueryRes();
            string strDateStart = "";
            string strDateEnd = "";
            string smsmsg;
            int rowCount = 0;
            double smscount = 0.0;

            if (req.StartDay == null && req.EndDay == null)
            {
                string thisyear = DateTime.Now.ToString("yyyy");
                strDateStart = thisyear + "-01-01 00:00:00";
                strDateEnd = thisyear + "-12-31 23:59:59";

            }
            else
            {
                CultureInfo enUS = new CultureInfo("en-US");
                DateTime dateStart, dateEnd;
                DateTime.TryParseExact(req.StartDay, "yyyyMMdd", enUS, DateTimeStyles.None, out dateStart);
                DateTime.TryParseExact(req.EndDay, "yyyyMMdd", enUS, DateTimeStyles.None, out dateEnd);

                strDateStart = dateStart.ToString("yyyy-MM-dd 00:00:00");
                strDateEnd = dateEnd.ToString("yyyy-MM-dd 23:59:59");
            }

         
                using (SqlConnection connection = new SqlConnection(Config.Item("WEB711DATA")))
                using (SqlCommand command = new SqlCommand("", connection))
                {

                    connection.Open();
                    command.CommandText = @"Select SmsLog.phone, SmsLog.content, SmsLog.send , SmsLog.time
                                            FROM [WEB711DATA].[dbo].[SmsLog]
                                            Where SmsLog.source = @hostid and SmsLog.time >= @StartDay and
                                                  SmsLog.time <= @EndDay Order by SmsLog.time Desc";
                    command.Parameters.AddWithValue("@hostid", req.storeId);
                    command.Parameters.AddWithValue("@StartDay", strDateStart);
                    command.Parameters.AddWithValue("@EndDay", strDateEnd);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            SmsLog anItemModel = new SmsLog();

                            smsmsg = reader.GetString(1);
                            smscount = (int)Math.Ceiling(((float)smsmsg.Length / 70));
                            if (smscount == 0)
                            {
                                smscount = 1;
                            }
                            anItemModel.phone = reader.GetString(0).Trim();
                            anItemModel.content = reader.GetString(1).Trim();
                            anItemModel.smscount = Convert.ToInt32(smscount);
                            anItemModel.time = reader.GetDateTime(3).ToString("yyyy-MM-dd hh:mm:ss");
                            anItemModel.send = GetNullableStringField(reader, 2);
                            res.SMSHistroyReport.Add(anItemModel);

                        }
                    }
                    connection.Close();
                    connection.Dispose();
                }
            SMSRangeCountQueryReq rangeReq = new SMSRangeCountQueryReq();
            rangeReq.storeId = req.storeId;
            rangeReq.strDateStart = strDateStart;
            rangeReq.strDateEnd = strDateEnd;
            //呼叫計算簡訊寄送總數
            res.smsmonthcount = QuerySMSRangeCount(rangeReq).smstotal;
                //計算手機號碼總數
                using (SqlConnection connection = new SqlConnection(Config.Item("WEB711DATA")))
                using (SqlCommand command = new SqlCommand("", connection))
                {

                    connection.Open();
                    command.CommandText = @"Select DISTINCT Smslog.phone FROM [WEB711DATA].[dbo].[SmsLog] 
                                            Where Smslog.time >= @StartDay and Smslog.time <= @EndDay and source=@hostid";
                    command.Parameters.AddWithValue("@hostid", req.storeId);
                    command.Parameters.AddWithValue("@StartDay", strDateStart);
                    command.Parameters.AddWithValue("@EndDay", strDateEnd);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            rowCount++;

                        }
                    }
                    res.smsphonecount = rowCount;
                    connection.Close();
                    connection.Dispose();
                }

            return res;
        }
    }
}