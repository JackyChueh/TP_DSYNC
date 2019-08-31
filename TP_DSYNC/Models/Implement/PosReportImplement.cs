using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using TP_DSYNC.Models.DataDefine.TwwPos;
using TP_DSYNC.Models.Enums;
using TP_DSYNC.Models.Help;
using TWW_API.ViewModels.PosReport;

namespace TP_DSYNC.Models.Implement
{
   
    public class PosReportImplement: BaseImplement
    {
        #region 加值服務報表
        //查詢門號申請報表 0515
        public List<PhoneReportQueryRes> QueryApplyPhoneNoReport(PhoneReportQueryReq req)
        {

            List<PhoneReportQueryRes> PhoneReport = new List<PhoneReportQueryRes>();
            CultureInfo enUS = new CultureInfo("en-US");
            DateTime dateStart;
            DateTime dateEnd;

            DateTime.TryParseExact(req.StartDate, "yyyyMMdd", enUS, DateTimeStyles.None, out dateStart);
            DateTime.TryParseExact(req.EndDate, "yyyyMMdd", enUS, DateTimeStyles.None, out dateEnd);

            string strDateStart = dateStart.ToString("yyyy-MM-dd 00:00:00");
            string strDateEnd = dateEnd.ToString("yyyy-MM-dd 23:59:59");

            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();
                    command.CommandText = @"Select AP.CreateDateTime,AP.PhoneName,AP.Phone,PT.ApplyTypeName,AP.MvpnSC,AP.Commission,AP.CommiDate,PE.TypeName,AP.Note FROM ApplyPhoneNo AP 
                                            Left Join PhoneType PT on AP.ApplyType = PT.ApplyTypeId 
                                            Left Join PhoneEventType PE on AP.EventStatus = PE.TypeId
                                            Where StoreId = @StoreId  ";
                    if (req.StartDate != "")
                    {
                        command.CommandText += "and CreateDateTime >= @StartDay";
                        command.Parameters.AddWithValue("@StartDay", strDateStart);
                    }
                    if (req.EndDate != "")
                    {
                        command.CommandText += " and CreateDateTime <= @EndDay";
                        command.Parameters.AddWithValue("@EndDay", strDateEnd);
                    }
                    command.Parameters.AddWithValue("@StoreId", req.Editor);


                    Log("SQL=" + command.CommandText);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            PhoneReportQueryRes aReportModel = new PhoneReportQueryRes();

                            aReportModel.applyPhoneNo.CreateDateTime = reader.GetDateTime(0).ToString("yyyy-MM-dd");
                            aReportModel.applyPhoneNo.PhoneName = GetNullableStringField(reader, 1);
                            aReportModel.applyPhoneNo.Phone = GetNullableStringField(reader, 2);
                            aReportModel.phoneType.ApplyTypeName = GetNullableStringField(reader, 3);
                            aReportModel.applyPhoneNo.MvpnSC = GetNullableStringField(reader, 4);
                            aReportModel.applyPhoneNo.Commission = reader.GetInt16(5);
                            aReportModel.applyPhoneNo.CommiDate = GetNullableStringField(reader, 6);
                            aReportModel.phoneEventType.TypeName = GetNullableStringField(reader, 7);
                            aReportModel.applyPhoneNo.Note = GetNullableStringField(reader, 8);



                            PhoneReport.Add(aReportModel);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                PhoneReportQueryRes aReportModel = new PhoneReportQueryRes();
                aReportModel.Result.State = ResultEnum.FAIL;
                PhoneReport.Add(aReportModel);
                Log("Err=" + ex.Message);
            }
            return PhoneReport;
        }

        #endregion

        #region 門市洗衣服務/客戶報表

        //門市衣服交件明細資料日報表
        public string QueryRetrivingDailyReport(SPQueryReq req)
        {
            try
            {
                DataTable table = new DataTable();
                using (var con = new SqlConnection(Config.Item("TwwPos")))
                using (var cmd = new SqlCommand("getDailyRetrivingClothes", con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@BranchId", req.LoginCmdModel.tww_Store.store_id);
                    cmd.Parameters.AddWithValue("@QueryDate", req.StartDay);

                    da.Fill(table);
                }
                return JsonConvert.SerializeObject(table);
            }
            catch (Exception ex)
            {
                Log("Err=" + ex.Message);

                //ignore
            }
            return "";
        }

        //門市衣服收件日明細報表
        public string QueryReceivingDailyReport(SPQueryReq req)
        {
            CultureInfo enUS = new CultureInfo("en-US");
            DateTime dateStartMonth;

            if (DateTime.TryParseExact(req.StartDay, "yyyyMMdd", enUS, DateTimeStyles.None, out dateStartMonth))
            {
                string strDateStart = dateStartMonth.ToString("yyyy-MM-dd");
                string strDateEnd = dateStartMonth.AddDays(1).ToString("yyyy-MM-dd");

             
                    DataTable table = new DataTable();
                    using (var con = new SqlConnection(Config.Item("TwwPos")))
                    using (var cmd = new SqlCommand("getDailyReceivingClothes", con))
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@BranchId", req.LoginCmdModel.tww_Store.store_id);
                        cmd.Parameters.AddWithValue("@QueryDate", strDateStart);
                        cmd.Parameters.AddWithValue("@QueryDateEnd", strDateEnd);

                        da.Fill(table);
                    }
                    return JsonConvert.SerializeObject(table);
              
            }
            return "";
        }
        //門市現金收入日報表
        public string QueryDailyCashingInReport(SPQueryReq req)
        {
            CultureInfo enUS = new CultureInfo("en-US");
            DateTime dateStartMonth;

            if (DateTime.TryParseExact(req.StartDay, "yyyyMMdd", enUS, DateTimeStyles.None, out dateStartMonth))
            {
                string strDateStart = dateStartMonth.ToString("yyyy-MM-dd");
                string strDateEnd = dateStartMonth.AddDays(1).ToString("yyyy-MM-dd");

             
                    DataTable table = new DataTable();
                    using (var con = new SqlConnection(Config.Item("TwwPos")))
                    using (var cmd = new SqlCommand("getDailyCashingInReport", con))
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@BranchId", req.LoginCmdModel.tww_Store.store_id);
                        cmd.Parameters.AddWithValue("@QueryDateStart", strDateStart);
                        cmd.Parameters.AddWithValue("@QueryDateEnd", strDateEnd);

                        da.Fill(table);
                    }
                    return JsonConvert.SerializeObject(table);
              
            
            }

            return "";
        }

        //門市衣服加工明細資料報表
        public string QueryClothesProcessingFeeReport(SPQueryReq req)
        {
           
                CultureInfo enUS = new CultureInfo("en-US");
                DateTime dateStart;
                DateTime dateEnd;

                DateTime.TryParseExact(req.StartDay, "yyyyMMdd", enUS, DateTimeStyles.None, out dateStart);
                DateTime.TryParseExact(req.EndDay, "yyyyMMdd", enUS, DateTimeStyles.None, out dateEnd);

                string strDateStart = dateStart.ToString("yyyy-MM-dd");
                string strDateEnd = dateEnd.AddDays(1).ToString("yyyy-MM-dd");

                DataTable table = new DataTable();
                using (var con = new SqlConnection(Config.Item("TwwPos")))
                using (var cmd = new SqlCommand("getClothesProcessingFeeReport", con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@BranchId", req.LoginCmdModel.tww_Store.store_id);
                    cmd.Parameters.AddWithValue("@QueryDateStart", strDateStart);
                    cmd.Parameters.AddWithValue("@QueryDateEnd", strDateEnd);

                    da.Fill(table);
                }
                return JsonConvert.SerializeObject(table);
         

            return "";
        }

        //門市衣服逾期未入庫資料報表
        public string QueryOverdueIntoWarehouseReport(SPQueryReq req)
        {
            string strDateStart = DateTime.Now.ToString("yyyyMMdd");

           
                DataTable table = new DataTable();
                using (var con = new SqlConnection(Config.Item("TwwPos")))
                using (var cmd = new SqlCommand("getOverdueIntoWarehouseReport", con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@BranchId", req.LoginCmdModel.tww_Store.store_id);
                    cmd.Parameters.AddWithValue("@QueryDateToday", strDateStart);

                    da.Fill(table);
                }
                return JsonConvert.SerializeObject(table);
          
         
        }

        //門市衣服逾期未領資料報表
        public string QueryOverdueRetrivingReport(SPQueryReq req)
        {
            string strDateStart = DateTime.Now.AddDays(-Convert.ToInt32(req.DueDayNumber)).ToString("yyyyMMdd");

            
                DataTable table = new DataTable();
                using (var con = new SqlConnection(Config.Item("TwwPos")))
                using (var cmd = new SqlCommand("getOverdueRetrivingReport", con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@BranchId", req.LoginCmdModel.tww_Store.store_id);
                    cmd.Parameters.AddWithValue("@QueryDateToday", strDateStart);

                    da.Fill(table);
                }
                return JsonConvert.SerializeObject(table);
           
            return "";
        }

        //門市客戶對帳單明細報表
        public string QueryCustomerAccountStatementReport(SPQueryReq req)
        {
            
                CultureInfo enUS = new CultureInfo("en-US");
                DateTime dateStart;
                DateTime dateEnd;

                DateTime.TryParseExact(req.StartDay, "yyyyMMdd", enUS, DateTimeStyles.None, out dateStart);
                DateTime.TryParseExact(req.EndDay, "yyyyMMdd", enUS, DateTimeStyles.None, out dateEnd);

                string strDateStart = dateStart.ToString("yyyy-MM-dd");
                string strDateEnd = dateEnd.AddDays(1).ToString("yyyy-MM-dd");

                string strOldDateStart = dateStart.ToString("yyyyMMdd");
                string strOldDateEnd = dateEnd.AddDays(1).ToString("yyyyMMdd");

                DataTable table = new DataTable();
                using (var con = new SqlConnection(Config.Item("TwwPos")))
                using (var cmd = new SqlCommand("getCustomerAccountStatementReport", con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@BranchId", req.LoginCmdModel.tww_Store.store_id);
                    cmd.Parameters.AddWithValue("@CustomerId", req.CustomerId);
                    cmd.Parameters.AddWithValue("@OldDateStart", strOldDateStart);
                    cmd.Parameters.AddWithValue("@OldDateEnd", strOldDateEnd);

                    da.Fill(table);
                }
                return JsonConvert.SerializeObject(table);
       
        }

        //客戶基本資料表
        public string QueryCustomerDetailsReport(SPQueryReq req)
        {


          
                DataTable table = new DataTable();
                using (var con = new SqlConnection(Config.Item("TwwPos")))
                using (var cmd = new SqlCommand("getCustomerDetailsReport", con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@BranchId", req.LoginCmdModel.tww_Store.store_id);
                    cmd.Parameters.AddWithValue("@CustomerIdStart", req.CustomerId);
                    cmd.Parameters.AddWithValue("@CustomerIdEnd", req.CustomerIdEnd);

                    da.Fill(table);
                }
                return JsonConvert.SerializeObject(table);
           
        }

        //門市客戶交易排行資料報表
        public string QueryCustomerMaxSalesReport(string storeId)
        {


           
                DataTable table = new DataTable();
                using (var con = new SqlConnection(Config.Item("TwwPos")))
                using (var cmd = new SqlCommand("getCustomerMaxSalesReport", con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@BranchId", storeId);

                    da.Fill(table);
                }
                return JsonConvert.SerializeObject(table);
         
        }

        //門市營業收入統計報表
        public string QueryAnMonthDailyOperatingStatisticsReport(SPQueryReq req)
        {


           
                CultureInfo enUS = new CultureInfo("en-US");
                DateTime dateStart;
                DateTime dateEnd;

                DateTime.TryParseExact(req.StartDay, "yyyyMMdd", enUS, DateTimeStyles.None, out dateStart);
                DateTime.TryParseExact(req.EndDay, "yyyyMMdd", enUS, DateTimeStyles.None, out dateEnd);

                string strDateStart = dateStart.ToString("yyyy-MM-dd");
                string strDateEnd = dateEnd.AddDays(1).ToString("yyyy-MM-dd");

                string strOldDateStart = dateStart.ToString("yyyyMMdd");
                string strOldDateEnd = dateEnd.AddDays(1).ToString("yyyyMMdd");


                DataTable table = new DataTable();

                using (var con = new SqlConnection(Config.Item("TwwPos")))
                using (var cmd = new SqlCommand("getAnMonthDailyOperatingStatisticsReport", con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@BranchId", req.LoginCmdModel.tww_Store.store_id);
                    cmd.Parameters.AddWithValue("@QueryDateStart", strDateStart);
                    cmd.Parameters.AddWithValue("@QueryDateEnd", strDateEnd);
                    cmd.Parameters.AddWithValue("@OldDateStart", strOldDateStart);
                    cmd.Parameters.AddWithValue("@OldDateEnd", strOldDateEnd);
                    Log("SQL=getAnMonthDailyOperatingStatisticsReport");

                    da.Fill(table);
                }
                return JsonConvert.SerializeObject(table);
          

        
        }
        //客戶今日預約衣物資料報表
        public string QueryCustomerScheduledDeliveryReport(SPQueryReq req)
        {
         
                DataTable table = new DataTable();
                using (var con = new SqlConnection(Config.Item("TwwPos")))
                using (var cmd = new SqlCommand("getCustomerScheduledDeliveryReport", con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@BranchId", req.LoginCmdModel.tww_Store.store_id);
                    cmd.Parameters.AddWithValue("@ScheduledDay", req.DueDayNumber);

                    da.Fill(table);
                }
                return JsonConvert.SerializeObject(table);
         
        }
        //查詢客戶預收報表//0320
        public CustomerPrepadReportQueryRes QueryCustomerPrepaiddReport(CustomerPrepadReportQueryReq aModelList)
        {
            CustomerPrepadReportQueryRes res = new CustomerPrepadReportQueryRes();
         
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "Select manno, manna, money, tel, day FROM adata Where money like '-%' and money != 0 and offno=@offno order by manno";

                    command.Parameters.AddWithValue("@offno", aModelList.LoginCmdModel.tww_Store.store_id);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var aModel = new adata
                            {
                                manno = GetNullableStringField(reader, 0),
                                manna = GetNullableStringField(reader, 1),
                                tel = GetNullableStringField(reader, 3),
                                day = GetNullableStringField(reader, 4)
                            };

                            if (!Convert.IsDBNull(reader[2]))
                                aModel.money = -1 * (int)reader.GetSqlDouble(2);

                            res.CustomerPrepadList.Add(aModel);
                        }
                    }
                }
            return res;
        }

        //門市衣物狀態查詢報表
        public string QueryClothesStatusReport(SPQueryReq req)
        {
            DataTable table = new DataTable();
           
                using (var con = new SqlConnection(Config.Item("TwwPos")))
                using (var cmd = new SqlCommand("getClothesStatusDetail", con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@offno", req.LoginCmdModel.tww_Store.store_id);
                    cmd.Parameters.AddWithValue("@QueryStartDate", req.StartDay);
                    cmd.Parameters.AddWithValue("@QueryEndDate", req.EndDay);
                cmd.Parameters.AddWithValue("@ClothesName", "%" + req.Keyword == null ? "" : req.Keyword + "%");
                //cmd.Parameters.AddWithValue("@ClothesName", "%%");
                Log("SQL=getClothesStatusDetail");

                    da.Fill(table);
                }
          
            return JsonConvert.SerializeObject(table);
        }
        //門市急件衣服未返回資料報表
        public string QueryOverdueDispatchReport(SPQueryReq req)
        {
            string strDateTomorrow = DateTime.Now.AddDays(1).ToString("yyyyMMdd");
            string strDatePreSevenDay = DateTime.Now.AddDays(-7).ToString("yyyyMMdd");

         
                DataTable table = new DataTable();
                using (var con = new SqlConnection(Config.Item("TwwPos")))
                using (var cmd = new SqlCommand("getOverdueDispatchReport", con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@BranchId", req.LoginCmdModel.tww_Store.store_id);
                    cmd.Parameters.AddWithValue("@QueryDateTomorrow", strDateTomorrow);
                    cmd.Parameters.AddWithValue("@QueryDatePreSevenDay", strDatePreSevenDay);

                    da.Fill(table);
                }
                return JsonConvert.SerializeObject(table);
          
        
        }

        #endregion
    }
}