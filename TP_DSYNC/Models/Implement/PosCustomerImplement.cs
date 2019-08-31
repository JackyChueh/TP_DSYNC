using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TP_DSYNC.Models.DataDefine.TwwPos;
using TP_DSYNC.Models.Enums;
using TP_DSYNC.Models.Help;
using TWW_API.ViewModels;
using TWW_API.ViewModels.ApplyPhone;
using TWW_API.ViewModels.Clothes;
using TWW_API.ViewModels.Customer;
using TWW_API.ViewModels.ShopFrontSys;

namespace TP_DSYNC.Models.Implement
{
    public class PosCustomerImplement : BaseImplement
    {
        //取得該店所有客戶資料
        public CustomerMgtEntityQueryRes QueryCustomerMgtEntityAll(CustomerMgtEntityQueryReq req)    //CustomerMgtEntityModel
        {
            CustomerMgtEntityQueryRes aModel = new CustomerMgtEntityQueryRes();
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    int currentpge = req.Currentpage * 500;

                    command.CommandText = "select top 500 manno, manna, tel, handtel, addr, money, money1, money2,day, day1, inday, note1, mail, mantype, sex, birday, company, local, tax,tel2 from [TwwPos].[dbo].[adata] where manno not in (select top " + currentpge + " manno from [TwwPos].[dbo].[adata] " +
                                          "where offno=@offno) and offno=@offno order by manno";

                    command.Parameters.AddWithValue("@offno", req.LoginCmdModel.tww_Store.store_id);
                    Log("SQLTxt=" + command.CommandText);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            CustomerMgtEntityViewModel CustomerList = new CustomerMgtEntityViewModel();

                            CustomerList.custdata.manno = GetNullableStringField(reader, 0);
                            CustomerList.custdata.manna = GetNullableStringField(reader, 1);
                            CustomerList.custdata.tel = GetNullableStringField(reader, 2);
                            CustomerList.custdata.handtel = GetNullableStringField(reader, 3);
                            CustomerList.custdata.addr = GetNullableStringField(reader, 4);

                            if (!Convert.IsDBNull(reader[5]))
                            {
                                var money = reader.GetSqlDouble(5);
                                CustomerList.custdata.money = (int)money;
                            }

                            if (!Convert.IsDBNull(reader[6]))
                                CustomerList.custdata.money1 = (int)reader.GetSqlDouble(6);
                            if (!Convert.IsDBNull(reader[7]))
                                CustomerList.custdata.money2 = (int)reader.GetSqlDouble(7);

                            CustomerList.custdata.day = GetNullableStringField(reader, 8);
                            CustomerList.custdata.day1 = GetNullableStringField(reader, 9);
                            CustomerList.custdata.inday = GetNullableStringField(reader, 10);
                            CustomerList.custdata.note1 = GetNullableStringField(reader, 11);
                            CustomerList.custdata.mail = GetNullableStringField(reader, 12);

                            var customerServiceNote = GetNullableStringField(reader, 13);
                            if (!String.IsNullOrEmpty(customerServiceNote))
                            {
                                switch (customerServiceNote)
                                {
                                    case "1":
                                        CustomerList.CustumerServiceNote.mantypeno = "1";
                                        CustomerList.CustumerServiceNote.mantypena = "自送";
                                        break;
                                    case "2":
                                        CustomerList.CustumerServiceNote.mantypeno = "2";
                                        CustomerList.CustumerServiceNote.mantypena = "外收送";
                                        break;
                                }
                            }

                            var customerGender = GetNullableStringField(reader, 14);
                            if (!String.IsNullOrEmpty(customerGender))
                            {
                                switch (customerGender)
                                {
                                    case "1":
                                        CustomerList.CustumerGender.sexno = "1";
                                        CustomerList.CustumerGender.sexna = "男";
                                        break;
                                    case "2":
                                        CustomerList.CustumerGender.sexno = "2";
                                        CustomerList.CustumerGender.sexna = "女";
                                        break;
                                }
                            }

                            CustomerList.custdata.birday = GetNullableStringField(reader, 15);
                            CustomerList.custdata.company = GetNullableStringField(reader, 16);
                            CustomerList.custdata.local = GetNullableStringField(reader, 17);
                            CustomerList.custdata.tax = GetNullableStringField(reader, 18);
                            CustomerList.custdata.tel2 = GetNullableStringField(reader, 19);
                            aModel.CustomerMgtEntityModelAllList.Add(CustomerList);
                        }
                    }
                    connection.Close();
                    connection.Dispose();
                }
                aModel.Result.State = ResultEnum.SUCCESS;
            }
            catch (Exception ex)
            {
                Log("Err=" + ex.Message);
                aModel.Result.State = ResultEnum.FAIL;
            }
            return aModel;
        }

        //搜尋單筆客戶資料
        public CustomerMgtEntityViewModel QueryCustomerMgtEntityById(CustomerMgtEntityQueryReq req)
        {
            CustomerMgtEntityViewModel aModel = new CustomerMgtEntityViewModel();
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "select manno, manna, tel, handtel, addr, money, money1, money2, per," +
                                          "day, day1, inday, note1, mail, mantype, sex, birday, company, local, tax " +
                                          "from adata where offno=@offno and manno=@manno";
                    command.Parameters.AddWithValue("@offno", req.LoginCmdModel.tww_Store.store_id);
                    command.Parameters.AddWithValue("@manno", req.Id);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {


                        while (reader.Read())
                        {
                            aModel.custdata.manno = GetNullableStringField(reader, 0);
                            aModel.custdata.manna = GetNullableStringField(reader, 1);
                            aModel.custdata.tel = GetNullableStringField(reader, 2);
                            aModel.custdata.handtel = GetNullableStringField(reader, 3);
                            aModel.custdata.addr = GetNullableStringField(reader, 4);

                            if (!Convert.IsDBNull(reader[5]))
                            {
                                var recevible = reader.GetSqlDouble(5);
                                aModel.custdata.money = (int)recevible;
                            }


                            if (!Convert.IsDBNull(reader[6]))
                                aModel.custdata.money1 = (int)reader.GetSqlDouble(6);

                            if (!Convert.IsDBNull(reader[7]))
                                aModel.custdata.money2 = (int)reader.GetSqlDouble(7);

                            if (!Convert.IsDBNull(reader[8]))
                                aModel.custdata.per = (int)reader.GetSqlDouble(8);

                            aModel.custdata.day = GetNullableStringField(reader, 9);

                            aModel.custdata.day1 = GetNullableStringField(reader, 10);

                            aModel.custdata.inday = GetNullableStringField(reader, 11);

                            aModel.custdata.note1 = GetNullableStringField(reader, 12);

                            aModel.custdata.mail = GetNullableStringField(reader, 13);

                            var customerServiceNote = GetNullableStringField(reader, 14);
                            if (!String.IsNullOrEmpty(customerServiceNote))
                            {
                                switch (customerServiceNote)
                                {
                                    case "1":
                                        aModel.CustumerServiceNote.mantypeno = "1";
                                        aModel.CustumerServiceNote.mantypena = "自送";
                                        break;
                                    case "2":
                                        aModel.CustumerServiceNote.mantypeno = "2";
                                        aModel.CustumerServiceNote.mantypena = "外收送";
                                        break;
                                }
                            }

                            var customerGender = GetNullableStringField(reader, 15);
                            if (!String.IsNullOrEmpty(customerGender))
                            {
                                switch (customerGender)
                                {
                                    case "1":
                                        aModel.CustumerGender.sexno = "1";
                                        aModel.CustumerGender.sexna = "男";
                                        break;
                                    case "2":
                                        aModel.CustumerGender.sexno = "2";
                                        aModel.CustumerGender.sexna = "女";
                                        break;
                                }
                            }

                            aModel.custdata.birday = GetNullableStringField(reader, 16);

                            aModel.custdata.company = GetNullableStringField(reader, 17);

                            aModel.custdata.local = GetNullableStringField(reader, 18);
                            aModel.custdata.tax = GetNullableStringField(reader, 19);
                        }

                    }
                    connection.Close();
                    connection.Dispose();
                }
            }
            catch (Exception ex)
            {
                Log("Err=" + ex.Message);
                //return false;
            }
            return aModel;
        }
        public IsCorrectResponse QueryCustomerMgtEntityByPhone(CustomerMgtEntityQueryReq aModel)
        {
            IsCorrectResponse res = new IsCorrectResponse();
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    //command.CommandText = "select TOP 1 manno from adata where offno=@offno and (tel Like '%'+@tel+'%' or handtel Like '%'+@tel+'%') order by inday DESC";
                    command.CommandText = "select * from " +
                                          "(select manno, ROW_NUMBER() OVER (ORDER BY inday DESC) AS RowNum " +
                                          "from adata where offno=@offno and (tel Like '%'+@tel+'%' or handtel Like '%'+@tel+'%')) sub where RowNum = @row ";

                    command.Parameters.AddWithValue("@offno", aModel.LoginCmdModel.tww_Store.store_id);
                    command.Parameters.AddWithValue("@tel", aModel.SearchPhone);
                    command.Parameters.AddWithValue("@row", aModel.RowNumber);
                    Log("SQLTxt=" + command.CommandText);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        res.isCorrect = true;
                        while (reader.Read())
                        {
                            res.Id = GetNullableStringField(reader, 0);
                        }
                    }
                    connection.Close();
                    connection.Dispose();
                }
                return res;
            }
            catch (Exception ex)
            {
                Log("Err=" + ex.Message);
                return res;
            }

        }
        public IsCorrectResponse QueryCustomerMgtEntityByName(CustomerMgtEntityQueryReq aModel)
        {
            IsCorrectResponse res = new IsCorrectResponse();


            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "select * from " +
                                          "(select manno, ROW_NUMBER() OVER (ORDER BY inday DESC) AS RowNum " +
                                          "from adata where offno=@offno and (manna Like '%'+@manna+'%')) sub where RowNum = @row ";

                    command.Parameters.AddWithValue("@offno", aModel.LoginCmdModel.tww_Store.store_id);
                    command.Parameters.AddWithValue("@manna", aModel.SearchName);
                    command.Parameters.AddWithValue("@row", aModel.RowNumber);
                    Log("SQLTxt=" + command.CommandText);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        res.isCorrect = true;
                        while (reader.Read())
                        {
                            res.Id = GetNullableStringField(reader, 0);
                        }
                    }
                    connection.Close();
                    connection.Dispose();
                }
                return res;
            }
            catch (Exception ex)
            {
                Log("Err=" + ex.Message);
                return res;
            }

        }
        public IsCorrectResponse QueryCustomerMgtEntityByAddress(CustomerMgtEntityQueryReq aModel)
        {
            IsCorrectResponse res = new IsCorrectResponse();
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "select * from " +
                                          "(select manno, ROW_NUMBER() OVER (ORDER BY inday DESC) AS RowNum " +
                                          "from adata where offno=@offno and (addr Like '%'+@addr+'%')) sub where RowNum = @row ";

                    command.Parameters.AddWithValue("@offno", aModel.LoginCmdModel.tww_Store.store_id);
                    command.Parameters.AddWithValue("@addr", aModel.SearchAddress);
                    command.Parameters.AddWithValue("@row", aModel.RowNumber);
                    Log("SQLTxt=" + command.CommandText);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        res.isCorrect = true;
                        while (reader.Read())
                        {
                            res.Id = GetNullableStringField(reader, 0);
                        }
                    }
                    connection.Close();
                    connection.Dispose();
                }
                return res;
            }
            catch (Exception ex)
            {
                Log("Err=" + ex.Message + "\n");
                return res;
            }
        }

        //取得部份客戶資料
        public CustomerMgtEntityQueryRes QueryCustomerMgtEntityAllLikeById(CustomerMgtEntityQueryReq req)
        {
            CustomerMgtEntityQueryRes aModel = new CustomerMgtEntityQueryRes();
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "select manno, manna, tel, handtel, addr, money, money1, money2, " +
                                          "day, day1, inday, note1, mail, mantype, sex, birday, company, local, tax,tel2 " +
                                          "from adata where offno=@offno and manno Like '%' + @manno + '%' order by manno";
                    command.Parameters.AddWithValue("@offno", req.LoginCmdModel.tww_Store.store_id);
                    command.Parameters.AddWithValue("@manno", req.Id);
                    Log("SQLTxt=" + command.CommandText + "\n");
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            CustomerMgtEntityViewModel CustomerList = new CustomerMgtEntityViewModel();

                            CustomerList.custdata.manno = GetNullableStringField(reader, 0);
                            CustomerList.custdata.manna = GetNullableStringField(reader, 1);
                            CustomerList.custdata.tel = GetNullableStringField(reader, 2);
                            CustomerList.custdata.handtel = GetNullableStringField(reader, 3);
                            CustomerList.custdata.addr = GetNullableStringField(reader, 4);

                            if (!Convert.IsDBNull(reader[5]))
                            {
                                var recevible = reader.GetSqlDouble(5);
                                CustomerList.custdata.money = (int)recevible;
                            }

                            if (!Convert.IsDBNull(reader[6]))
                                CustomerList.custdata.money1 = (int)reader.GetSqlDouble(6);
                            if (!Convert.IsDBNull(reader[7]))
                                CustomerList.custdata.money2 = (int)reader.GetSqlDouble(7);

                            CustomerList.custdata.day = GetNullableStringField(reader, 8);
                            CustomerList.custdata.day1 = GetNullableStringField(reader, 9);
                            CustomerList.custdata.inday = GetNullableStringField(reader, 10);
                            CustomerList.custdata.note1 = GetNullableStringField(reader, 11);
                            CustomerList.custdata.mail = GetNullableStringField(reader, 12);

                            var customerServiceNote = GetNullableStringField(reader, 13);
                            if (!String.IsNullOrEmpty(customerServiceNote))
                            {
                                switch (customerServiceNote)
                                {
                                    case "1":
                                        CustomerList.CustumerServiceNote.mantypeno = "1";
                                        CustomerList.CustumerServiceNote.mantypena = "自送";
                                        break;
                                    case "2":
                                        CustomerList.CustumerServiceNote.mantypeno = "2";
                                        CustomerList.CustumerServiceNote.mantypena = "外收送";
                                        break;
                                }
                            }

                            var customerGender = GetNullableStringField(reader, 14);
                            if (!String.IsNullOrEmpty(customerGender))
                            {
                                switch (customerGender)
                                {
                                    case "1":
                                        CustomerList.CustumerGender.sexno = "1";
                                        CustomerList.CustumerGender.sexna = "男";
                                        break;
                                    case "2":
                                        CustomerList.CustumerGender.sexno = "2";
                                        CustomerList.CustumerGender.sexna = "女";
                                        break;
                                }
                            }

                            CustomerList.custdata.birday = GetNullableStringField(reader, 15);
                            CustomerList.custdata.company = GetNullableStringField(reader, 16);
                            CustomerList.custdata.local = GetNullableStringField(reader, 17);
                            CustomerList.custdata.tax = GetNullableStringField(reader, 18);
                            CustomerList.custdata.tel2 = GetNullableStringField(reader, 19);

                            aModel.CustomerMgtEntityModelAllList.Add(CustomerList);
                        }
                    }
                    connection.Close();
                    connection.Dispose();
                }
            }
            catch (Exception ex)
            {
                Log("Err=" + ex.Message);
            }
            return aModel;
        }

        public CustomerMgtEntityQueryRes QueryCustomerMgtEntityAllLikeByPhone(CustomerMgtEntityQueryReq req)
        {
            CustomerMgtEntityQueryRes aModel = new CustomerMgtEntityQueryRes();
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "select manno, manna, tel, handtel, addr, money, money1, money2, " +
                                          "day, day1, inday, note1, mail, mantype, sex, birday, company, local, tax ,tel2 " +
                                          "from adata where offno=@offno and (tel Like '%'+@tel+'%' or handtel Like '%'+@tel+'%'  or tel2 Like '%'+@tel+'%') order by manno";
                    Log("SQLTxt=" + command.CommandText);
                    command.Parameters.AddWithValue("@offno", req.LoginCmdModel.tww_Store.store_id);
                    command.Parameters.AddWithValue("@tel", req.SearchPhone);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            CustomerMgtEntityViewModel CustomerList = new CustomerMgtEntityViewModel();

                            CustomerList.custdata.manno = GetNullableStringField(reader, 0);
                            CustomerList.custdata.manna = GetNullableStringField(reader, 1);
                            CustomerList.custdata.tel = GetNullableStringField(reader, 2);
                            CustomerList.custdata.handtel = GetNullableStringField(reader, 3);
                            CustomerList.custdata.addr = GetNullableStringField(reader, 4);

                            if (!Convert.IsDBNull(reader[5]))
                            {
                                var recevible = reader.GetSqlDouble(5);
                                CustomerList.custdata.money = (int)recevible;
                            }

                            if (!Convert.IsDBNull(reader[6]))
                                CustomerList.custdata.money1 = (int)reader.GetSqlDouble(6);
                            if (!Convert.IsDBNull(reader[7]))
                                CustomerList.custdata.money2 = (int)reader.GetSqlDouble(7);

                            CustomerList.custdata.day = GetNullableStringField(reader, 8);
                            CustomerList.custdata.day1 = GetNullableStringField(reader, 9);
                            CustomerList.custdata.inday = GetNullableStringField(reader, 10);
                            CustomerList.custdata.note1 = GetNullableStringField(reader, 11);
                            CustomerList.custdata.mail = GetNullableStringField(reader, 12);

                            var customerServiceNote = GetNullableStringField(reader, 13);
                            if (!String.IsNullOrEmpty(customerServiceNote))
                            {
                                switch (customerServiceNote)
                                {
                                    case "1":
                                        CustomerList.CustumerServiceNote.mantypeno = "1";
                                        CustomerList.CustumerServiceNote.mantypena = "自送";
                                        break;
                                    case "2":
                                        CustomerList.CustumerServiceNote.mantypeno = "2";
                                        CustomerList.CustumerServiceNote.mantypena = "外收送";
                                        break;
                                }
                            }

                            var customerGender = GetNullableStringField(reader, 14);
                            if (!String.IsNullOrEmpty(customerGender))
                            {
                                switch (customerGender)
                                {
                                    case "1":
                                        CustomerList.CustumerGender.sexno = "1";
                                        CustomerList.CustumerGender.sexna = "男";
                                        break;
                                    case "2":
                                        CustomerList.CustumerGender.sexno = "2";
                                        CustomerList.CustumerGender.sexna = "女";
                                        break;
                                }
                            }

                            CustomerList.custdata.birday = GetNullableStringField(reader, 15);
                            CustomerList.custdata.company = GetNullableStringField(reader, 16);
                            CustomerList.custdata.local = GetNullableStringField(reader, 17);
                            CustomerList.custdata.tax = GetNullableStringField(reader, 18);
                            CustomerList.custdata.tel2 = GetNullableStringField(reader, 19);

                            aModel.CustomerMgtEntityModelAllList.Add(CustomerList);
                        }
                    }
                    connection.Close();
                    connection.Dispose();
                }
            }
            catch (Exception ex)
            {
                Log("Err=" + ex.Message);
            }
            return aModel;
        }
        //搜尋客戶資料
        public CustomerMgtEntityQueryRes QueryCustomerSearchList(CustomerMgtEntityQueryReq aModel)
        {
            CustomerMgtEntityQueryRes res = new CustomerMgtEntityQueryRes();
            if (!String.IsNullOrEmpty(aModel.SearchPhone))
            {
                res = QueryCustomerSearchListByPhone(aModel);
            }
            else if (!String.IsNullOrEmpty(aModel.SearchName))
            {
                res = QueryCustomerSearchListByName(aModel);
            }
            return res;
        }
        //以電話搜尋客戶資料
        private CustomerMgtEntityQueryRes QueryCustomerSearchListByPhone(CustomerMgtEntityQueryReq aModel)
        {
            CustomerMgtEntityQueryRes res = new CustomerMgtEntityQueryRes();
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "SELECT manno, manna, tel, handtel, addr, money, note1 FROM adata WHERE offno=@branch_id AND ( tel LIKE @tel or handtel LIKE @tel )";
                    Log("SQLTxt=" + command.CommandText + " \n" + "branch_id=" + aModel.LoginCmdModel.tww_Store.store_id + ",tel=" + aModel.SearchPhone);
                    command.Parameters.AddWithValue("@branch_id", aModel.LoginCmdModel.tww_Store.store_id);
                    command.Parameters.Add("@tel", SqlDbType.NVarChar).Value = "%" + aModel.SearchPhone;

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            CustomerMgtEntityViewModel anEntityModel = new CustomerMgtEntityViewModel();


                            anEntityModel.custdata.manno = reader.GetString(0);
                            anEntityModel.custdata.manna = reader.GetString(1);
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
                    Log("DataCount=" + res.CustomerMgtEntityModelAllList.Count + " \n");
                }
                res.Result.State = ResultEnum.SUCCESS;
            }
            catch (Exception ex)
            {
                Log("Err=" + ex.Message + " \n");
                res.Result.State = ResultEnum.FAIL;
            }
            return res;
        }
        //以名字搜尋客戶資料
        private CustomerMgtEntityQueryRes QueryCustomerSearchListByName(CustomerMgtEntityQueryReq aModel)
        {
            CustomerMgtEntityQueryRes res = new CustomerMgtEntityQueryRes();
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "SELECT manno, manna, tel, handtel, addr, money, note1 FROM adata WHERE offno=@branch_id AND manna LIKE '%' + @manna + '%'";
                    Log("SQLTxt=" + command.CommandText + "\n" + "branch_id=" + aModel.LoginCmdModel.tww_Store.store_id + ",manna=" + aModel.SearchName);
                    command.Parameters.AddWithValue("@branch_id", aModel.LoginCmdModel.tww_Store.store_id);
                    command.Parameters.AddWithValue("@manna", aModel.SearchName);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            CustomerMgtEntityViewModel anEntityModel = new CustomerMgtEntityViewModel();


                            anEntityModel.custdata.manno = reader.GetString(0);
                            anEntityModel.custdata.manna = reader.GetString(1);
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
                    Log("DataCount=" + res.CustomerMgtEntityModelAllList.Count + " \n");

                    connection.Close();
                    connection.Dispose();
                }
                res.Result.State = ResultEnum.SUCCESS;
            }
            catch (Exception ex)
            {
                Log("Err=" + ex.Message + " \n");
                res.Result.State = ResultEnum.FAIL;
            }
            return res;
        }
        #region 客資維護
        public BaseResponse UpdateCustomerMgtEntityById(CustomerMgtEntityViewModel aModel)
        {
            BaseResponse res = new BaseResponse();
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "Update adata set manna=@manna, mantype=@mantype, sex=@sex, tel=@tel, birday=@birday, company=@company, local=@local, " +
                                          "handtel=@handtel, addr=@addr, note1=@note1, mail=@mail, tax=@tax where manno=@manno and offno=@offno";

                    Log("SQLTxt=" + command.CommandText);
                    command.Parameters.AddWithValue("@manna", aModel.custdata.manna);
                    command.Parameters.AddWithNullableValue("@tel", aModel.custdata.tel);

                    command.Parameters.AddWithNullableValue("@mantype", aModel.CustumerServiceNote.mantypeno);
                    command.Parameters.AddWithNullableValue("@company", aModel.custdata.company);

                    command.Parameters.AddWithNullableValue("@sex", aModel.CustumerGender.sexno);

                    command.Parameters.AddWithNullableValue("@handtel", aModel.custdata.handtel);
                    command.Parameters.AddWithNullableValue("@addr", aModel.custdata.addr);
                    command.Parameters.AddWithNullableValue("@note1", aModel.custdata.note1);
                    command.Parameters.AddWithNullableValue("@mail", aModel.custdata.mail);
                    command.Parameters.AddWithNullableValue("@tax", aModel.custdata.tax);

                    if (!String.IsNullOrEmpty(aModel.custdata.birday))
                    {
                        if (aModel.custdata.birday.Length > 8)
                        {
                            aModel.custdata.birday = aModel.custdata.birday.Substring(0, 8);
                        }
                    }

                    command.Parameters.AddWithNullableValue("@birday", aModel.custdata.birday);

                    command.Parameters.AddWithNullableValue("@local", aModel.custdata.local);

                    command.Parameters.AddWithValue("@manno", aModel.custdata.manno);
                    command.Parameters.AddWithValue("@offno", aModel.LoginCmdModel.tww_Store.store_id);

                    command.ExecuteNonQuery();
                    connection.Close();
                    connection.Dispose();
                }
                res.Result.State = ResultEnum.SUCCESS;
            }
            catch (Exception ex)
            {
                Log("Err=" + ex.Message);
                res.Result.State = ResultEnum.FAIL;
            }
            return res;
        }
        public BaseResponse checkCustomer(CustomerMgtEntityViewModel aModel)
        {
            BaseResponse res = new BaseResponse();
            var strToday = DateTime.Now.ToString("yyyyMMdd");

            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();
                    command.CommandText = "select * from adata where offno='" + aModel.LoginCmdModel.tww_Store.store_id + "' and (";
                    if (aModel.custdata.tel != "" && aModel.custdata.tel != null)
                    {
                        command.CommandText += "(tel=@tel or tel2=@tel or handtel=@tel) or ";
                        command.Parameters.AddWithNullableValue("@tel", aModel.custdata.tel);
                    }
                    if (aModel.custdata.tel2 != "" && aModel.custdata.tel2 != null)
                    {
                        command.CommandText += "  (tel=@tel2 or tel2=@tel2 or handtel=@tel2) or ";
                        command.Parameters.AddWithNullableValue("@tel2", aModel.custdata.tel2);
                    }
                    if (aModel.custdata.handtel != "" && aModel.custdata.handtel != null)
                    {
                        command.CommandText += "  (tel=@tel3 or tel2=@tel3 or handtel=@tel3) or ";
                        command.Parameters.AddWithNullableValue("@tel3", aModel.custdata.handtel);
                    }
                    command.CommandText = command.CommandText.Substring(0, command.CommandText.Length - 3) + ")";
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        res.Result.State = ResultEnum.DUPLICATED_DATA;
                    }
                    else
                    {
                        res.Result.State = ResultEnum.SUCCESS;
                    }
                }
            }
            catch (Exception ex)
            {
                Log("Err=" + ex.Message);
                res.Result.State = ResultEnum.FAIL;
            }
            return res;
        }
        public BaseResponse InsertCustomerMgtEntityById(CustomerMgtEntityViewModel aModel)
        {
            var strToday = DateTime.Now.ToString("yyyyMMdd");
            BaseResponse res = new BaseResponse();
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();
                    command.CommandText = "INSERT INTO adata (manno, offno, manna, tel, tel2, handtel, addr, note1, mail, inday, mantype, sex, birday, company, local) " +
                                          "VALUES ( @manno, @offno, @manna, @tel, @tel2, @handtel, @addr, @note1, @mail, @inday, @mantype, @sex, @birday, @company, @local)";

                    Log("SQLTxt=" + command.CommandText);
                    command.Parameters.AddWithValue("@manno", aModel.custdata.manno);
                    command.Parameters.AddWithValue("@offno", aModel.LoginCmdModel.tww_Store.store_id);
                    command.Parameters.AddWithValue("@manna", aModel.custdata.manna);
                    command.Parameters.AddWithValue("@tel", aModel.custdata.tel == null ? "" : aModel.custdata.tel);
                    command.Parameters.AddWithValue("@tel2", aModel.custdata.tel2 == null ? "" : aModel.custdata.tel2);
                    command.Parameters.AddWithNullableValue("@handtel", aModel.custdata.handtel == null ? "" : aModel.custdata.handtel);
                    command.Parameters.AddWithNullableValue("@addr", aModel.custdata.addr);
                    command.Parameters.AddWithNullableValue("@note1", aModel.custdata.note1);
                    command.Parameters.AddWithNullableValue("@mail", aModel.custdata.mail);
                    command.Parameters.AddWithNullableValue("@inday", strToday);
                    command.Parameters.AddWithNullableValue("@mantype", aModel.CustumerServiceNote.mantypeno);
                    command.Parameters.AddWithNullableValue("@sex", aModel.CustumerGender.sexno);

                    if (!String.IsNullOrEmpty(aModel.custdata.birday))
                    {
                        if (aModel.custdata.birday.Length > 8)
                        {
                            aModel.custdata.birday = aModel.custdata.birday.Substring(0, 8);
                        }
                    }

                    command.Parameters.AddWithNullableValue("@birday", aModel.custdata.birday);

                    command.Parameters.AddWithNullableValue("@company", aModel.custdata.company);

                    command.Parameters.AddWithNullableValue("@local", aModel.custdata.local);

                    command.ExecuteNonQuery();
                    connection.Close();
                    connection.Dispose();
                }
                res.Result.State = ResultEnum.SUCCESS;
            }
            catch (Exception ex)
            {
                Log("Err=" + ex.Message);
                res.Result.State = ResultEnum.FAIL;
            }
            return res;
        }
        //0326 存檔記錄
        public BaseResponse InsertSaveHistoryLogRecord(SaveHistoryLogViewModel req)
        {
            BaseResponse res = new BaseResponse();
            DateTime DateTimeNow = Convert.ToDateTime(DateTime.Now.ToString());
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "INSERT INTO SaveHistoryLog (store_id, manno, eventime, eventtype) values (@store_id, @manno, @eventime, @eventtype)";
                    Log("存檔紀錄-SQLTxt=" + command.CommandText + "\n");
                    Log("存檔紀錄-store_id=" + req.store_id + ", manno=" + req.manno + ", eventtype=" + req.eventtype + "\n");
                    command.Parameters.AddWithValue("@store_id", req.store_id);
                    command.Parameters.AddWithValue("@manno", req.manno);
                    command.Parameters.AddWithValue("@eventime", DateTimeNow);
                    command.Parameters.AddWithValue("@eventtype", req.eventtype);

                    command.ExecuteNonQuery();
                    res.Result.State = ResultEnum.SUCCESS;
                }
            }
            catch (Exception ex)
            {
                Log("存檔紀錄-Err=" + ex.Message + "\n");
                res.Result.State = ResultEnum.FAIL;
            }
            return res;
        }
        #endregion
        #region 收取件客戶資料
        public ReceivingOrdersSettingQueryRes QueryReceivingOrdersSetting(string aStoreId)
        {
            ReceivingOrdersSettingQueryRes res = new ReceivingOrdersSettingQueryRes();
            try
            {
                //if the store is first initialized...
                //aModel.PreSalesOrderId = "000000";
                //aModel.PreBarcodeId = "0000";
                //aModel.PreCustomerId = "000000";
                res.PreCustomer.wano = "000000";
                res.PreCustomer.wano2 = "0000";
                res.PreCustomer.manno = "000000";
                //....................................

                string currentStoreBarcodeId = GetCurrentStoreBarcodeId(aStoreId);
                res.PreCustomer.wano2 = (Convert.ToInt32(currentStoreBarcodeId) - 1).ToString("D4");

                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "select TOP 1 wano, manno from gdata where offno=@offno order by date1 DESC, wano DESC";

                    command.Parameters.AddWithValue("@offno", aStoreId);
                    Log("SQLTxt=" + command.CommandText + "\n offno=" + aStoreId);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            res.PreCustomer.wano = GetNullableStringField(reader, 0);
                            res.PreCustomer.manno = GetNullableStringField(reader, 1);
                        }
                    }
                }
                res.Result.State = ResultEnum.SUCCESS;
            }
            catch (Exception ex)
            {
                Log("Err=" + ex.ToString());
                res.Result.State = ResultEnum.FAIL;
            }
            return res;
        }

        public string GetCurrentStoreBarcodeId(string storeId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "SELECT current_barcode_id FROM tww_store WHERE store_id=@store_id";

                    command.Parameters.AddWithValue("@store_id", storeId);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            return GetNullableStringField(reader, 0);
                        }
                    }
                    connection.Close();
                    connection.Dispose();
                }
                return "";
            }
            catch (Exception ex)
            {

                Log("Err=" + ex.Message);
                return "";
            }
        }
        //最後活動客戶(歷史)
        public ReceivingOrdersSettingQueryRes QueryHistoryCustomerId(string aStoreId)
        {
            ReceivingOrdersSettingQueryRes res = new ReceivingOrdersSettingQueryRes();
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();
                    command.CommandText = "SELECT Top 1 manno FROM SaveHistoryLog where store_id = @store_id Order by eventime Desc ";
                    command.Parameters.AddWithValue("@store_id", aStoreId);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            res.PreHistoryCustomer.manno = GetNullableStringField(reader, 0);
                        }
                    }
                }
                res.Result.State = ResultEnum.SUCCESS;
            }
            catch (Exception ex)
            {
                Log("Err=" + ex.ToString());
                res.Result.State = ResultEnum.FAIL;
            }
            return res;
        }
        public ReceivingOrdersSettingQueryRes QueryLastInvoiceNumber(string aStoreId)
        {
            ReceivingOrdersSettingQueryRes res = new ReceivingOrdersSettingQueryRes();
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "select current_invoice_number, is_using_tax_printer from tww_store where store_id=@store_id";

                    command.Parameters.AddWithValue("@store_id", aStoreId);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            res.LastInvoice.current_invoice_number = GetNullableStringField(reader, 0);
                            res.LastInvoice.is_using_tax_printer = reader.GetBoolean(1);
                        }
                    }
                }
                res.Result.State = ResultEnum.SUCCESS;
            }
            catch (Exception ex)
            {
                Log("Err=" + ex.ToString());
                res.Result.State = ResultEnum.FAIL;
            }
            return res;
        }
        public ReceivingOrdersSettingQueryRes QueryLastCustomerId(string aStoreId)
        {
            ReceivingOrdersSettingQueryRes res = new ReceivingOrdersSettingQueryRes();
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "select TOP 1 manno from adata where offno=@offno order by manno DESC";

                    command.Parameters.AddWithValue("@offno", aStoreId);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            res.LastCustomer.manno = GetNullableStringField(reader, 0);
                        }
                    }
                }
                res.Result.State = ResultEnum.SUCCESS;
            }
            catch (Exception ex)
            {
                Log("Err=" + ex.ToString());
                res.Result.State = ResultEnum.FAIL;
            }
            return res;
        }

        public CustomerQueryRes QueryFreePrices(string storeId)
        {
            CustomerQueryRes res = new CustomerQueryRes();
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "select dno, wno, free_money from edata where store_id=@store_id and free=1";
                    command.Parameters.AddWithValue("@store_id", storeId);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var aPriceModel = new edata
                            {
                                dno = GetNullableStringField(reader, 0),
                                wno = GetNullableStringField(reader, 1)
                            };

                            if (!Convert.IsDBNull(reader[2]))
                            {
                                var price = reader.GetSqlDouble(2);
                                aPriceModel.free_money = (int)price;
                            }
                            res.FreePrices.Add(aPriceModel);
                        }
                    }
                }
                res.Result.State = ResultEnum.SUCCESS;
            }
            catch (Exception ex)
            {
                Log("Err" + ex.ToString());
                res.Result.State = ResultEnum.FAIL;
            }
            return res;
        }


        public CustomerQueryRes QueryCustomerById(CustomerQueryReq aModel)
        {
            CustomerQueryRes custdata = new CustomerQueryRes();
            bool result = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "select manno, manna, tel, handtel, addr, money, money1, money2, day, day1, inday, note1, mail, company, per, tax,tel2 from adata where offno=@offno and manno=@manno";

                    Log("SQLTxt=" + command.CommandText + "\n");
                    command.Parameters.AddWithValue("@offno", aModel.storeId);
                    command.Parameters.AddWithValue("@manno", aModel.manno);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        result = true;

                        while (reader.Read())
                        {
                            custdata.custdata.manno = GetNullableStringField(reader, 0);
                            custdata.custdata.manna = GetNullableStringField(reader, 1);
                            custdata.custdata.tel = GetNullableStringField(reader, 2);
                            custdata.custdata.handtel = GetNullableStringField(reader, 3);
                            custdata.custdata.addr = GetNullableStringField(reader, 4);

                            if (!Convert.IsDBNull(reader[5]))
                            {
                                var recevible = reader.GetSqlDouble(5);
                                custdata.custdata.money = (int)recevible;
                            }


                            if (!Convert.IsDBNull(reader[6]))
                                custdata.custdata.money1 = (int)reader.GetSqlDouble(6);

                            if (!Convert.IsDBNull(reader[7]))
                                custdata.custdata.money2 = (int)reader.GetSqlDouble(7);

                            custdata.custdata.day = GetNullableStringField(reader, 8);

                            custdata.custdata.day1 = GetNullableStringField(reader, 9);

                            custdata.custdata.inday = GetNullableStringField(reader, 10);

                            custdata.custdata.note1 = GetNullableStringField(reader, 11);

                            custdata.custdata.mail = GetNullableStringField(reader, 12);

                            custdata.custdata.company = GetNullableStringField(reader, 13);

                            if (!Convert.IsDBNull(reader[14]))
                            {
                                var per = reader.GetSqlDouble(14);
                                custdata.custdata.per = (int)per;
                            }
                            custdata.custdata.tax = GetNullableStringField(reader, 15);
                            custdata.custdata.tel2 = GetNullableStringField(reader, 16);
                        }
                    }
                    connection.Close();
                    connection.Dispose();
                }
                custdata.Result.State = ResultEnum.SUCCESS;
            }
            catch (Exception ex)
            {
                Log("Err=" + ex.Message + "\n");
            }
            return custdata;
        }
        public CustomerClothesQueryRes QueryCustomerConditions(CustomerClothesQueryReq aModel)
        {
            CustomerClothesQueryRes res = new CustomerClothesQueryRes();
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "select TOP 1 manno from gdata where offno=@offno ";
                    switch (aModel.QueryType)
                    {

                        case 3:
                            {
                                command.CommandText = "select TOP 1 manno from gdata where offno=@offno and wano2=@wano2 ";
                                command.Parameters.AddWithValue("@wano2", aModel.SearchBarcodeId);
                                break;
                            }
                        case 4:
                            {
                                command.CommandText = "select TOP 1 manno from gdata where offno=@offno and wano=@wano  ";
                                command.Parameters.AddWithValue("@wano", aModel.SearchOrderId);
                                break;
                            }
                        case 5:
                            {
                                command.CommandText = "select TOP 1 manno from adata where offno=@offno and (tel=@tel or handtel=@tel) ";
                                command.Parameters.AddWithValue("@wano", aModel.SearchPhone);
                                break;
                            }
                        case 6:
                            {
                                command.CommandText += "select TOP 1 manno from adata where offno=@offno and manna=@manna  ";
                                command.Parameters.AddWithValue("@wano", aModel.SearchName);
                                break;
                            }

                    }
                    command.CommandText += " order by date1 DESC";
                    Log("SQLTxt=" + command.CommandText + "\n");
                    command.Parameters.AddWithValue("@offno", aModel.storeId);


                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            res.clothesdata.manno = GetNullableStringField(reader, 0);

                        }
                    }
                    connection.Close();
                    connection.Dispose();
                    res.Result.State = ResultEnum.SUCCESS;
                }

            }
            catch (Exception ex)
            {
                Log("Err=" + ex.ToString() + "\n");
                res.Result.State = ResultEnum.FAIL;

            }
            return res;
        }
        public CustomerSalesOrderQueryRes QueryCustomerSalesOrder(CustomerSalesOrderQueryReq req)
        {
            CustomerSalesOrderQueryRes res = new CustomerSalesOrderQueryRes();
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "select wano, wano2, dno, wno, typeno, addno, color, fknd, date1, date2, insiteno, money0, money2, money3, money4, money5, note, caseno, IncomingShippmentFlag, Revicion_Note " +
                                          "from gdata where offno=@offno and manno=@manno and getw=@getw and indoor=@indoor and delwano2=@delwano2 order by wano2,wano";
                    Log("SQLTxt=" + command.CommandText + "\n");
                    command.Parameters.AddWithValue("@offno", req.offno);
                    command.Parameters.AddWithValue("@manno", req.manno);
                    command.Parameters.AddWithValue("@getw", "f");

                    command.Parameters.AddWithValue("@indoor", req.isReadySaleOrders ? "t" : "f");

                    command.Parameters.AddWithValue("@delwano2", "f");

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ClothesSaleOrderItem anItemModel = new ClothesSaleOrderItem();

                            anItemModel.gdata.wano = GetNullableStringField(reader, 0);
                            anItemModel.gdata.wano2 = GetNullableStringField(reader, 1);
                            anItemModel.Clothes.dno = GetNullableStringField(reader, 2);

                            anItemModel.Material.wno = GetNullableStringField(reader, 3);
                            anItemModel.HandleType.typeno = GetNullableStringField(reader, 4);
                            anItemModel.ProcessingType.addno = GetNullableStringField(reader, 5);

                            anItemModel.gdata.color = GetNullableStringField(reader, 6);
                            anItemModel.gdata.fknd = GetNullableStringField(reader, 7);
                            anItemModel.gdata.date1 = GetNullableStringField(reader, 8);
                            anItemModel.gdata.date2 = GetNullableStringField(reader, 9);
                            anItemModel.StoragePlace.insiteno = GetNullableStringField(reader, 10);
                            anItemModel.gdata.indoor = req.isReadySaleOrders ? "True" : "False";

                            if (!Convert.IsDBNull(reader[11]))
                            {
                                var price = reader.GetSqlDouble(11);
                                anItemModel.gdata.money0 = (int)price;
                            }

                            if (!Convert.IsDBNull(reader[12]))
                            {
                                var additionalFee = reader.GetSqlDouble(12);
                                anItemModel.gdata.money2 = (int)additionalFee;
                            }

                            if (!Convert.IsDBNull(reader[13]))
                            {
                                var discountAmount = reader.GetSqlDouble(13);
                                anItemModel.gdata.money3 = (int)discountAmount;
                            }

                            if (!Convert.IsDBNull(reader[14]))
                            {
                                var finalPrice = reader.GetSqlDouble(14);
                                anItemModel.gdata.money4 = (int)finalPrice;
                            }

                            if (!Convert.IsDBNull(reader[15]))
                            {
                                var processingFee = reader.GetSqlDouble(15);
                                anItemModel.gdata.money5 = (int)processingFee;
                            }

                            anItemModel.gdata.note = GetNullableStringField(reader, 16);

                            anItemModel.gdata.caseno = GetNullableStringField(reader, 17);

                            anItemModel.gdata.IncomingShippmentFlag = reader.GetBoolean(18);

                            anItemModel.gdata.Revicion_Note = GetNullableStringField(reader, 19);

                            res.ReadySalesOrderModelList.Add(anItemModel);
                        }
                    }
                    connection.Close();
                    connection.Dispose();
                }
                res.Result.State = ResultEnum.SUCCESS;
            }
            catch (Exception ex)
            {
                Log("Err=" + ex.Message + "\n");
                res.Result.State = ResultEnum.FAIL;
            }
            return res;
        }

        public HistoryItemQueryRes QueryCustomerSalesOrderHistory(HistoryItemQueryReq req)
        {
            HistoryItemQueryRes res = new HistoryItemQueryRes();
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "select TOP 200 date1, wano, money, money1, money2, money3, money4, money5, money6, money7, money8, money9, money10, wct, gct from kdata where offno=@offno and manno=@manno order by date1 desc";
                    Log("SQLTxt=" + command.CommandText + "\n");
                    command.Parameters.AddWithValue("@offno", req.StoreId);
                    command.Parameters.AddWithValue("@manno", req.Id);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            kdata anItemModel = new kdata();

                            anItemModel.date1 = GetNullableStringField(reader, 0);

                            anItemModel.wano = GetNullableStringField(reader, 1);


                            if (!Convert.IsDBNull(reader[2]))
                            {
                                var price = reader.GetSqlDouble(2);
                                anItemModel.money = (int)price;
                            }

                            if (!Convert.IsDBNull(reader[3]))
                            {
                                var price = reader.GetSqlDouble(3);
                                anItemModel.money1 = (int)price;
                            }

                            if (!Convert.IsDBNull(reader[4]))
                            {
                                var price = reader.GetSqlDouble(4);
                                anItemModel.money2 = (int)price;
                            }

                            if (!Convert.IsDBNull(reader[5]))
                            {
                                var price = reader.GetSqlDouble(5);
                                anItemModel.money3 = (int)price;
                            }

                            if (!Convert.IsDBNull(reader[6]))
                            {
                                var price = reader.GetSqlDouble(6);
                                anItemModel.money4 = (int)price;
                            }

                            if (!Convert.IsDBNull(reader[7]))
                            {
                                var price = reader.GetSqlDouble(7);
                                anItemModel.money5 = (int)price;
                            }
                            if (!Convert.IsDBNull(reader[8]))
                            {
                                var price = reader.GetSqlDouble(8);
                                anItemModel.money6 = (int)price;
                            }

                            if (!Convert.IsDBNull(reader[9]))
                            {
                                var price = reader.GetSqlDouble(9);
                                anItemModel.money7 = (int)price;
                            }

                            if (!Convert.IsDBNull(reader[10]))
                            {
                                var price = reader.GetSqlDouble(10);
                                anItemModel.money8 = (int)price;
                            }

                            if (!Convert.IsDBNull(reader[11]))
                            {
                                var price = reader.GetSqlDouble(11);
                                anItemModel.money9 = (int)price;
                            }

                            if (!Convert.IsDBNull(reader[12]))
                            {
                                var price = reader.GetSqlDouble(12);
                                anItemModel.money10 = (int)price;
                            }

                            if (!Convert.IsDBNull(reader[13]))
                            {
                                var price = reader.GetSqlDouble(13);
                                anItemModel.wct = (int)price;
                            }

                            if (!Convert.IsDBNull(reader[14]))
                            {
                                var price = reader.GetSqlDouble(14);
                                anItemModel.gct = (int)price;
                            }

                            res.HistorySalesOrderList.Add(anItemModel);
                        }
                    }
                    connection.Close();
                    connection.Dispose();
                }
            }
            catch (Exception ex)
            {
                Log("Err=" + ex.Message + "\n");
            }
            return res;
        }

        public HistoryItemQueryRes QueryCustomerNewSalesOrderHistory(HistoryItemQueryReq req)
        {
            HistoryItemQueryRes res = new HistoryItemQueryRes();
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "select id, event_time, event_type, receiving_number, retriving_number, revising_number, cashing_in, " +
                                          "normal_price_sum, discount_amount_sum, additional_fee_sum, final_price_sum, processing_fee_sum, customer_recevible, " +
                                          "edit_id, invoice_number, is_payment_cancelled, remark " +
                                          "from tww_salesorder_history where customer_id=@customer_id and branch_id=@branch_id order by event_time desc";
                    Log("SQLTxt=" + command.CommandText + "\n");
                    command.Parameters.AddWithValue("@customer_id", req.Id);
                    command.Parameters.AddWithValue("@branch_id", req.StoreId);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            tww_salesorder_history anItemModel = new tww_salesorder_history();

                            anItemModel.id = reader.GetInt32(0);
                            var aTime = reader.GetDateTime(1);
                            anItemModel.event_time = aTime.ToString("yyyy/MM/dd HH:mm");
                            anItemModel.event_type = GetNullableStringField(reader, 2);

                            anItemModel.receiving_number = reader.GetInt32(3);
                            anItemModel.retriving_number = reader.GetInt32(4);
                            anItemModel.revising_number = reader.GetInt32(5);
                            anItemModel.cashing_in = reader.GetInt32(6);

                            anItemModel.normal_price_sum = reader.GetInt32(7);
                            anItemModel.discount_amount_sum = reader.GetInt32(8);
                            anItemModel.additional_fee_sum = reader.GetInt32(9);
                            anItemModel.final_price_sum = reader.GetInt32(10);
                            anItemModel.processing_fee_sum = reader.GetInt32(11);

                            anItemModel.customer_recevible = reader.GetInt32(12);

                            anItemModel.edit_id = GetNullableStringField(reader, 13);
                            anItemModel.invoice_number = GetNullableStringField(reader, 14);

                            anItemModel.is_payment_cancelled = reader.GetBoolean(15);

                            anItemModel.remark = GetNullableStringField(reader, 16);

                            res.NewHistorySalesOrderList.Add(anItemModel);
                        }
                    }
                    connection.Close();
                    connection.Dispose();
                }
            }
            catch (Exception ex)
            {
                Log("Err=" + ex.Message + "\n");
            }
            return res;
        }
        public SalesOrderCampaignQueryRes QuerySalesOrderCampaigns(SalesOrderCampaignQueryReq req)
        {
            var strToday = req.recvDate;
            SalesOrderCampaignQueryRes res = new SalesOrderCampaignQueryRes();
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "select caseno, casena, sdate, edate, uses, pers, moneys from cases where (@today > sdate) and (@today < edate) and store_id=@store_id ";

                    command.Parameters.AddWithValue("@today", strToday);
                    command.Parameters.AddWithValue("@store_id", req.storeId);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var aModel =
                                new cases
                                {
                                    caseno = GetNullableStringField(reader, 0),
                                    casena = GetNullableStringField(reader, 1),
                                    sdate = GetNullableStringField(reader, 2),
                                    edate = GetNullableStringField(reader, 3),
                                    uses = GetNullableStringField(reader, 4)
                                };

                            if (!Convert.IsDBNull(reader[5]))
                                aModel.pers = (int)reader.GetInt16(5);

                            if (!Convert.IsDBNull(reader[6]))
                                aModel.moneys = (int)reader.GetSqlDouble(6);

                            res.RevisingCampaignModelList.Add(aModel);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log("Err=" + ex.ToString());
            }
            return res;
        }


        public HistorySalesOrderQueryRes QueryNewHistorySalesOrders(HistorySalesOrderQueryReq aModel)
        {
            HistorySalesOrderQueryRes res = new HistorySalesOrderQueryRes();

            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();

                command.CommandText = "select salesorder_id, barcode_id, clothes_type_id, material_id, handle_type_id, processing_type_id, " +
                                      "color, accessory, deliver_date, " +
                                      "normal_price, additional_fee, discount_amount, final_price, processing_fee, notes, is_disposed,salesorder_id " +
                                      "from tww_salesorder_history_details where tww_salesorder_history_id=@tww_salesorder_history_id " +
                                      "order by id desc";

                command.Parameters.AddWithValue("@tww_salesorder_history_id", aModel.SearchId);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ClothesSaleOrderItem anItemModel = new ClothesSaleOrderItem();
                        res.NewHistoryItemList.tww_salesorder_history_id = aModel.SearchId;
                        anItemModel.gdata.wano = GetNullableStringField(reader, 0);
                        anItemModel.gdata.wano2 = GetNullableStringField(reader, 1);
                        anItemModel.Clothes.dno = GetNullableStringField(reader, 2);

                        anItemModel.Material.wno = GetNullableStringField(reader, 3);
                        anItemModel.HandleType.typeno = GetNullableStringField(reader, 4);
                        anItemModel.ProcessingType.addno = GetNullableStringField(reader, 5);

                        anItemModel.gdata.color = GetNullableStringField(reader, 6);
                        anItemModel.gdata.fknd = GetNullableStringField(reader, 7);

                        anItemModel.gdata.date2 = GetNullableStringField(reader, 8);

                        if (!Convert.IsDBNull(reader[9]))
                        {
                            anItemModel.tww_Salesorder_History_Details.normal_price = reader.GetInt32(9);
                        }

                        if (!Convert.IsDBNull(reader[10]))
                        {
                            anItemModel.tww_Salesorder_History_Details.additional_fee = reader.GetInt32(10);
                        }

                        if (!Convert.IsDBNull(reader[11]))
                        {
                            anItemModel.tww_Salesorder_History_Details.discount_amount = reader.GetInt32(11);
                        }

                        if (!Convert.IsDBNull(reader[12]))
                        {
                            anItemModel.tww_Salesorder_History_Details.final_price = reader.GetInt32(12);
                        }

                        if (!Convert.IsDBNull(reader[13]))
                        {
                            anItemModel.tww_Salesorder_History_Details.processing_fee = reader.GetInt32(13);
                        }

                        anItemModel.tww_Salesorder_History_Details.notes = GetNullableStringField(reader, 14);

                        anItemModel.tww_Salesorder_History_Details.is_disposed = reader.GetBoolean(15);


                        //anItemModel.CampaignId = GetNullableStringField(reader, 17);

                        res.SalesOrderList.Add(anItemModel);
                    }
                }
                connection.Close();
                connection.Dispose();
            }
            return res;
        }
        public HistorySalesOrderQueryRes QueryHistorySalesOrders(HistorySalesOrderQueryReq req)
        {
            HistorySalesOrderQueryRes res = new HistorySalesOrderQueryRes();

            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();

                command.CommandText = "select wano, wano2, dno, wno, typeno, addno, color, fknd, date1, date2, insiteno, money0, money2, money3, money4, money5, note, caseno, delwano2 from gdata " +
                                       "where offno=@offno and wano=@wano";


                command.Parameters.AddWithValue("@offno", req.LoginCmdModel.tww_Store.store_id);
                command.Parameters.AddWithValue("@wano", req.SaleOrderId);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ClothesSaleOrderItem anItemModel = new ClothesSaleOrderItem();

                        anItemModel.gdata.wano = GetNullableStringField(reader, 0);
                        anItemModel.gdata.wano2 = GetNullableStringField(reader, 1);
                        anItemModel.Clothes.dno = GetNullableStringField(reader, 2);

                        anItemModel.Material.wno = GetNullableStringField(reader, 3);
                        anItemModel.HandleType.typeno = GetNullableStringField(reader, 4);
                        anItemModel.ProcessingType.addno = GetNullableStringField(reader, 5);

                        anItemModel.gdata.color = GetNullableStringField(reader, 6);
                        anItemModel.gdata.fknd = GetNullableStringField(reader, 7);
                        anItemModel.gdata.date1 = GetNullableStringField(reader, 8);
                        anItemModel.gdata.date2 = GetNullableStringField(reader, 9);
                        anItemModel.StoragePlace.insiteno = GetNullableStringField(reader, 10);


                        if (!Convert.IsDBNull(reader[11]))
                        {
                            var price = reader.GetSqlDouble(11);
                            anItemModel.gdata.money0 = (int)price;
                        }

                        if (!Convert.IsDBNull(reader[12]))
                        {
                            var additionalFee = reader.GetSqlDouble(12);
                            anItemModel.gdata.money2 = (int)additionalFee;
                        }

                        if (!Convert.IsDBNull(reader[13]))
                        {
                            var discountAmount = reader.GetSqlDouble(13);
                            anItemModel.gdata.money3 = (int)discountAmount;
                        }

                        if (!Convert.IsDBNull(reader[14]))
                        {
                            var finalPrice = reader.GetSqlDouble(14);
                            anItemModel.gdata.money4 = (int)finalPrice;
                        }

                        if (!Convert.IsDBNull(reader[15]))
                        {
                            var processingFee = reader.GetSqlDouble(15);
                            anItemModel.gdata.money5 = (int)processingFee;
                        }

                        anItemModel.gdata.note = GetNullableStringField(reader, 16);

                        anItemModel.gdata.caseno = GetNullableStringField(reader, 17);

                        res.SalesOrderList.Add(anItemModel);
                    }
                }
                connection.Close();
                connection.Dispose();
            }

            return res;
        }

        //查詢歷史單號單一實收金額
        public HistorySalesOrderQueryRes QueryHistorySalesOrderCashingIn(HistorySalesOrderQueryReq aModel)
        {
            HistorySalesOrderQueryRes res = new HistorySalesOrderQueryRes();
            TwwPosViewModel aTwwPosModel = new TwwPosViewModel();

          //  aTwwPosModel = new PosClothesImplement().GetTwwPosModel(aTwwPosModel, aModel.LoginCmdModel.tww_Store.store_id);

     
            int CashingIn = 0;
      
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "select cashing_in from [tww_salesorder_history] " +
                                           "where id=@SearchId and event_type='付款' ";
                   
                    command.Parameters.AddWithValue("@SearchId", aModel.SearchId);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            res.tww_Salesorder_History.cashing_in = reader.GetInt32(0);

                        }

                    }
                    connection.Close();
                    connection.Dispose();
                }
       
            return res;
        }

        //以整編搜尋客戶資料
        public CustomerSearchFromHistoryBarcodeQueryRes QueryCustomerSearchListByBarcode(CustomerSearchFromHistoryBarcodeQueryReq aModel)
        {
            CustomerSearchFromHistoryBarcodeQueryRes res = new CustomerSearchFromHistoryBarcodeQueryRes();

                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "SELECT adata.manno, adata.manna, adata.tel, adata.handtel, adata.addr, adata.money, adata.note1, gdataf_new.dna, gdata.date1, gdata.date3, gdata.color, gdata.fknd " +
                                          "FROM adata INNER JOIN gdata ON adata.manno=gdata.manno AND adata.offno=gdata.offno " +
                                          "INNER JOIN gdataf_new ON gdata.dno=gdataf_new.dno " +
                                          "INNER JOIN gdatae ON gdata.wno=gdatae.wno " +
                                          "WHERE adata.offno=@branch_id AND gdataf_new.store_id=@store_id AND wano2=@wano2 order by gdata.date1 DESC";


                    command.Parameters.AddWithValue("@branch_id", aModel.branch_id);
                    command.Parameters.AddWithValue("@store_id", aModel.store_id);
                    command.Parameters.AddWithValue("@wano2", aModel.wano2);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            CustomerEntityVsHistoryBarcodeViewModel anEntityModel = new CustomerEntityVsHistoryBarcodeViewModel();

                            anEntityModel.adata.manno = reader.GetString(0);
                            anEntityModel.adata.manna = reader.GetString(1);
                            anEntityModel.adata.tel = GetNullableStringField(reader, 2);
                            anEntityModel.adata.handtel = GetNullableStringField(reader, 3);
                            anEntityModel.adata.addr = GetNullableStringField(reader, 4);
                            anEntityModel.adata.note1 = GetNullableStringField(reader, 6);
                            anEntityModel.gdataf_New.dna = GetNullableStringField(reader, 7);
                            anEntityModel.gdata.date1 = GetNullableStringField(reader, 8);
                            anEntityModel.gdata.date2 = GetNullableStringField(reader, 9);
                            anEntityModel.gdata.color = GetNullableStringField(reader, 10);
                            anEntityModel.gdata.fknd = GetNullableStringField(reader, 11);


                            if (!Convert.IsDBNull(reader[5]))
                            {
                                var recevible = reader.GetSqlDouble(5);
                                anEntityModel.adata.money = (int)recevible;
                            }

                        res.CustomerList.Add(anEntityModel);
                        }
                    }
                 

                    connection.Close();
                    connection.Dispose();
                }
            return res;
        }


        #endregion

        #region 收取件存檔
        public void SetCurrentStoreBarcodeId(tww_store req)
        {

            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();

                command.CommandText = "UPDATE tww_store SET current_barcode_id=@current_barcode_id  WHERE store_id=@store_id";

                command.Parameters.AddWithValue("@current_barcode_id", req.current_barcode_id);
                command.Parameters.AddWithValue("@store_id", req.store_id);

                command.ExecuteNonQuery();

                connection.Close();
                connection.Dispose();
            }


        }

        public void InsertReceivingSalesOrderItem(gdata gdata)
        {

            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();

                command.CommandText = "INSERT INTO gdata ( date1, date2, wano2, wano, manno, offno, dno, wno, typeno, addno, color, fknd, note, money0, money, money1, money2, money3, money4, money5, caseno, per, crman, indoor, getw, delwano2, IncomingShippmentFlag, create_time) " +
                                      "VALUES ( @date1, @date2, @wano2, @wano, @manno, @offno, @dno, @wno, @typeno, @addno, @color, @fknd, @note, @money0, @money, @money1, @money2, @money3, @money4, @money5, @caseno, @per, @crman, @indoor, @getw, @delwano2, @IncomingShippmentFlag, @create_time)";

                command.Parameters.AddWithNullableValue("@date1", gdata.date1);
                command.Parameters.AddWithNullableValue("@date2", gdata.date2);
                command.Parameters.AddWithNullableValue("@wano2", gdata.wano2);
                command.Parameters.AddWithNullableValue("@wano", gdata.wano);
                command.Parameters.AddWithNullableValue("@manno", gdata.manno);
                command.Parameters.AddWithNullableValue("@offno", gdata.offno);

                command.Parameters.AddWithNullableValue("@dno", gdata.dno);
                command.Parameters.AddWithNullableValue("@wno", gdata.wno);
                command.Parameters.AddWithNullableValue("@typeno", gdata.typeno);
                command.Parameters.AddWithNullableValue("@addno", gdata.addno);
                command.Parameters.AddWithNullableValue("@color", gdata.color);
                command.Parameters.AddWithNullableValue("@fknd", gdata.fknd);
                command.Parameters.AddWithNullableValue("@note", gdata.note);
                command.Parameters.AddWithNullableValue("@money0", gdata.money0);
                command.Parameters.AddWithNullableValue("@money", gdata.money);
                command.Parameters.AddWithNullableValue("@money1", 0);
                command.Parameters.AddWithNullableValue("@money2", gdata.money2);
                command.Parameters.AddWithNullableValue("@money3", gdata.money3);
                command.Parameters.AddWithNullableValue("@money4", gdata.money4);
                command.Parameters.AddWithNullableValue("@money5", gdata.money5);

                command.Parameters.AddWithNullableValue("@caseno", gdata.caseno);
                command.Parameters.AddWithNullableValue("@per", gdata.per);

                command.Parameters.AddWithNullableValue("@crman", gdata.crman);

                command.Parameters.AddWithValue("@indoor", "f");
                command.Parameters.AddWithValue("@getw", "f");
                command.Parameters.AddWithValue("@delwano2", "f");

                command.Parameters.AddWithValue("@IncomingShippmentFlag", false);

                command.Parameters.AddWithValue("@create_time", DateTime.Now);

                command.ExecuteNonQuery();

            }

        }
        public void UpdateRetrivingSalesOrderItem(gdata gdata)
        {


            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();

                command.CommandText = "Update gdata set getw=@getw, date3=@date3 where date1=@date1 and wano=@wano and wano2=@wano2 and manno=@manno and offno=@offno";

                command.Parameters.AddWithValue("@getw", "t");
                command.Parameters.AddWithValue("@date3", gdata.date3);

                command.Parameters.AddWithValue("@date1", gdata.date1);
                command.Parameters.AddWithValue("@wano", gdata.wano);
                command.Parameters.AddWithValue("@wano2", gdata.wano2);
                command.Parameters.AddWithValue("@manno", gdata.manno);
                command.Parameters.AddWithValue("@offno", gdata.offno);
                command.ExecuteNonQuery();
            }

        }

        public void UpdateRetrivingSalesOrderItemForOutgoingShippment(tww_outgoing_shippment tww_Outgoing_Shippment)
        {
            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();

                command.CommandText = "Update tww_outgoing_shippment set is_retrieved=@is_retrieved where store_id=@store_id and barcode_id=@barcode_id and orderno = @orderno";

                command.Parameters.AddWithValue("@is_retrieved", true);
                command.Parameters.AddWithValue("@store_id", tww_Outgoing_Shippment.store_id);
                command.Parameters.AddWithValue("@barcode_id", tww_Outgoing_Shippment.barcode_id);

                //加入洗衣單號才不會重覆更新
                command.Parameters.AddWithValue("@orderno", tww_Outgoing_Shippment.orderno);

                command.ExecuteNonQuery();
            }

        }

        public void UpdateRewashingSalesOrderItem(gdata gdata)
        {


            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();

                command.CommandText = "Update gdata set indoor=@indoor, getw=@getw, IncomingShippmentFlag=@IncomingShippmentFlag, note=@note " +
                                      "where date1=@date1 and wano=@wano and wano2=@wano2 and manno=@manno and offno=@offno";

                command.Parameters.AddWithValue("@indoor", "f");
                command.Parameters.AddWithValue("@getw", "f");
                command.Parameters.AddWithValue("@IncomingShippmentFlag", false);

                command.Parameters.AddWithNullableValue("@note", gdata.note);

                command.Parameters.AddWithValue("@date1", gdata.date1);
                command.Parameters.AddWithValue("@wano", gdata.wano);
                command.Parameters.AddWithValue("@wano2", gdata.wano2);
                command.Parameters.AddWithValue("@manno", gdata.manno);
                command.Parameters.AddWithValue("@offno", gdata.offno);

                command.ExecuteNonQuery();
            }
        }

        public void UpdateRetrivingSalesOrderItemInDoor(gdata gdata)
        {

            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();

                command.CommandText = "Update gdata set indoor=@indoor, insiteno=@insiteno, indate=@indate where date1=@date1 and wano=@wano and wano2=@wano2 and manno=@manno and offno=@offno";

                command.Parameters.AddWithValue("@indoor", "t");
                command.Parameters.AddWithValue("@insiteno", gdata.insiteno);
                command.Parameters.AddWithValue("@indate", gdata.indate);

                command.Parameters.AddWithValue("@date1", gdata.date1);
                command.Parameters.AddWithValue("@wano", gdata.wano);
                command.Parameters.AddWithValue("@wano2", gdata.wano2);
                command.Parameters.AddWithValue("@manno", gdata.manno);
                command.Parameters.AddWithValue("@offno", gdata.offno);
                command.ExecuteNonQuery();
            }


        }

        public void UpdateCustomerRecevibleForReceivingAndContinueWashing(adata adata)
        {
            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();

                if (adata.day1 != null)
                {
                    command.CommandText = "Update adata set money=@money, day=@day, day1=@day1 where manno=@manno and offno=@offno";
                    command.Parameters.AddWithValue("@day1", adata.day1);
                }
                else
                {
                    command.CommandText = "Update adata set money=@money, day=@day where manno=@manno and offno=@offno";


                }
                command.Parameters.AddWithValue("@day", adata.day);
                command.Parameters.AddWithValue("@money", adata.money);


                command.Parameters.AddWithValue("@manno", adata.manno);
                command.Parameters.AddWithValue("@offno", adata.offno);
                command.ExecuteNonQuery();
            }

        }

        public void UpdateInvoiceNumberForReceiving(tww_store tww_Store)
        {

            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();

                command.CommandText = "Update tww_store set current_invoice_number=@current_invoice_number where store_id=@store_id";
                command.Parameters.AddWithValue("@current_invoice_number", tww_Store.current_invoice_number);
                command.Parameters.AddWithValue("@store_id", tww_Store.store_id);
                command.ExecuteNonQuery();
            }

        }
        public int InsertSalesOrderHistoryReceiving(tww_salesorder_history tww_Salesorder_History)
        {

            int id;
            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();

                command.CommandText = "INSERT INTO tww_salesorder_history ( event_time, branch_id, customer_id, event_type, receiving_number, " +
                                      "normal_price_sum, discount_amount_sum, additional_fee_sum, final_price_sum, processing_fee_sum, customer_recevible, edit_id ) " +
                                      "output INSERTED.id " +
                                      "VALUES ( @event_time, @branch_id, @customer_id, @event_type, @receiving_number, " +
                                      "@normal_price_sum, @discount_amount_sum, @additional_fee_sum, @final_price_sum, @processing_fee_sum, @customer_recevible, @edit_id )";

                command.Parameters.AddWithValue("@event_time", tww_Salesorder_History.event_time);
                command.Parameters.AddWithValue("@branch_id", tww_Salesorder_History.branch_id);
                command.Parameters.AddWithValue("@customer_id", tww_Salesorder_History.customer_id);
                command.Parameters.AddWithValue("@event_type", "收件");

                command.Parameters.AddWithValue("@receiving_number", tww_Salesorder_History.receiving_number);

                command.Parameters.AddWithValue("@normal_price_sum", tww_Salesorder_History.normal_price_sum);
                command.Parameters.AddWithValue("@discount_amount_sum", tww_Salesorder_History.discount_amount_sum);
                command.Parameters.AddWithValue("@additional_fee_sum", tww_Salesorder_History.additional_fee_sum);
                command.Parameters.AddWithValue("@final_price_sum", tww_Salesorder_History.final_price_sum);
                command.Parameters.AddWithValue("@processing_fee_sum", tww_Salesorder_History.processing_fee_sum);

                command.Parameters.AddWithValue("@customer_recevible", tww_Salesorder_History.customer_recevible);

                command.Parameters.AddWithValue("@edit_id", tww_Salesorder_History.edit_id);

                id = (int)command.ExecuteScalar();
            }


            return id;

        }

        public void InsertSalesOrderHistoryReceivingDetails(InsertSalesOrderHistoryDetailsReq req)
        {

            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();

                command.CommandText = "INSERT INTO tww_salesorder_history_details ( tww_salesorder_history_id, salesorder_id, barcode_id, clothes_type_id, material_id, handle_type_id, processing_type_id, " +
                                      "color, accessory, notes, normal_price, discount_amount, additional_fee, final_price, processing_fee, deliver_date ) " +
                                      "VALUES ( @tww_salesorder_history_id, @salesorder_id, @barcode_id, @clothes_type_id, @material_id, @handle_type_id, @processing_type_id, " +
                                      "@color, @accessory, @notes, @normal_price, @discount_amount, @additional_fee, @final_price, @processing_fee, @deliver_date )";

                command.Parameters.AddWithValue("@tww_salesorder_history_id", req.aSalesOrderHistoryId);

                command.Parameters.Add("@salesorder_id", SqlDbType.NVarChar);
                command.Parameters.Add("@barcode_id", SqlDbType.NVarChar);

                command.Parameters.Add("@clothes_type_id", SqlDbType.NVarChar);
                command.Parameters.Add("@material_id", SqlDbType.NVarChar);
                command.Parameters.Add("@handle_type_id", SqlDbType.NVarChar);
                command.Parameters.Add("@processing_type_id", SqlDbType.NVarChar);

                command.Parameters.Add("@color", SqlDbType.NVarChar);
                command.Parameters.Add("@accessory", SqlDbType.NVarChar);
                command.Parameters.Add("@notes", SqlDbType.NVarChar);

                command.Parameters.Add("@normal_price", SqlDbType.Int);
                command.Parameters.Add("@discount_amount", SqlDbType.Int);
                command.Parameters.Add("@additional_fee", SqlDbType.Int);
                command.Parameters.Add("@final_price", SqlDbType.Int);
                command.Parameters.Add("@processing_fee", SqlDbType.Int);

                command.Parameters.Add("@deliver_date", SqlDbType.NVarChar);

                foreach (var salesOrderItem in req.ReceivingSalesOrderItemList)
                {
                    command.Parameters["@salesorder_id"].Value = req.salesorder_id;
                    command.Parameters["@barcode_id"].Value = salesOrderItem.gdata.wano2;

                    command.Parameters["@clothes_type_id"].Value = salesOrderItem.gdata.dno;
                    command.Parameters["@material_id"].Value = salesOrderItem.gdata.wno;
                    command.Parameters["@handle_type_id"].Value = salesOrderItem.gdata.typeno;
                    command.Parameters["@processing_type_id"].Value = string.IsNullOrEmpty(salesOrderItem.gdata.addno) ? (object)DBNull.Value : salesOrderItem.gdata.addno;
                    command.Parameters["@processing_type_id"].IsNullable = true;

                    command.Parameters["@color"].Value = salesOrderItem.gdata.color;

                    command.Parameters["@accessory"].Value = string.IsNullOrEmpty(salesOrderItem.gdata.fknd) ? (object)DBNull.Value : salesOrderItem.gdata.fknd;
                    command.Parameters["@accessory"].IsNullable = true;

                    command.Parameters["@notes"].Value = string.IsNullOrEmpty(salesOrderItem.gdata.note) ? (object)DBNull.Value : salesOrderItem.gdata.note;
                    command.Parameters["@notes"].IsNullable = true;

                    command.Parameters["@normal_price"].Value = salesOrderItem.gdata.money0;
                    command.Parameters["@discount_amount"].Value = salesOrderItem.gdata.money3;
                    command.Parameters["@additional_fee"].Value = salesOrderItem.gdata.money2;
                    command.Parameters["@final_price"].Value = salesOrderItem.gdata.money4;
                    command.Parameters["@processing_fee"].Value = salesOrderItem.gdata.money5;
                    //20190219 歷史資料應交件日
                    //command.Parameters["@deliver_date"].Value = currentTime.AddDays(salesOrderItem.DaysNeededForDelivery).ToString("yyyyMMdd");
                    command.Parameters["@deliver_date"].Value = req.currentTime.AddDays(salesOrderItem.DaysNeededForDelivery).DayOfWeek.ToString() == "Sunday" ? req.currentTime.AddDays(salesOrderItem.DaysNeededForDelivery + 1).ToString("yyyyMMdd") : req.currentTime.AddDays(salesOrderItem.DaysNeededForDelivery).ToString("yyyyMMdd");
                    command.ExecuteNonQuery();
                }
            }

        }

        public int InsertSalesOrderHistoryRetriving(tww_salesorder_history tww_Salesorder_History)
        {

            int Id;

            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();

                command.CommandText = "INSERT INTO tww_salesorder_history ( event_time, branch_id, customer_id, event_type, retriving_number, " +
                                      "normal_price_sum, discount_amount_sum, additional_fee_sum, final_price_sum, processing_fee_sum, customer_recevible, edit_id ) " +
                                      "output INSERTED.id " +
                                      "VALUES ( @event_time, @branch_id, @customer_id, @event_type, @retriving_number, " +
                                      "@normal_price_sum, @discount_amount_sum, @additional_fee_sum, @final_price_sum, @processing_fee_sum, @customer_recevible, @edit_id )";

                command.Parameters.AddWithValue("@event_time", tww_Salesorder_History.event_time);
                command.Parameters.AddWithValue("@branch_id", tww_Salesorder_History.branch_id);
                command.Parameters.AddWithValue("@customer_id", tww_Salesorder_History.customer_id);
                command.Parameters.AddWithValue("@event_type", "取件");

                command.Parameters.AddWithValue("@retriving_number", tww_Salesorder_History.retriving_number);

                command.Parameters.AddWithValue("@normal_price_sum", tww_Salesorder_History.normal_price_sum);
                command.Parameters.AddWithValue("@discount_amount_sum", tww_Salesorder_History.discount_amount_sum);
                command.Parameters.AddWithValue("@additional_fee_sum", tww_Salesorder_History.additional_fee_sum);
                command.Parameters.AddWithValue("@final_price_sum", tww_Salesorder_History.final_price_sum);
                command.Parameters.AddWithValue("@processing_fee_sum", tww_Salesorder_History.processing_fee_sum);

                command.Parameters.AddWithValue("@customer_recevible", tww_Salesorder_History.customer_recevible);

                command.Parameters.AddWithValue("@edit_id", tww_Salesorder_History.edit_id);

                Id = (int)command.ExecuteScalar();
            }
            return Id;
        }


        public void InsertSalesOrderHistoryRetrivingOrRewashingDetails(InsertSalesOrderHistoryDetailsReq req)
        {
            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();

                command.CommandText = "INSERT INTO tww_salesorder_history_details ( tww_salesorder_history_id, salesorder_id, barcode_id, clothes_type_id, material_id, handle_type_id, processing_type_id, " +
                                      "color, accessory, notes, normal_price, discount_amount, additional_fee, final_price, processing_fee, deliver_date ) " +
                                      "VALUES ( @tww_salesorder_history_id, @salesorder_id, @barcode_id, @clothes_type_id, @material_id, @handle_type_id, @processing_type_id, " +
                                      "@color, @accessory, @notes, @normal_price, @discount_amount, @additional_fee, @final_price, @processing_fee, @deliver_date )";

                command.Parameters.AddWithValue("@tww_salesorder_history_id", req.aSalesOrderHistoryId);

                command.Parameters.Add("@salesorder_id", SqlDbType.NVarChar);
                command.Parameters.Add("@barcode_id", SqlDbType.NVarChar);

                command.Parameters.Add("@clothes_type_id", SqlDbType.NVarChar);
                command.Parameters.Add("@material_id", SqlDbType.NVarChar);
                command.Parameters.Add("@handle_type_id", SqlDbType.NVarChar);
                command.Parameters.Add("@processing_type_id", SqlDbType.NVarChar);

                command.Parameters.Add("@color", SqlDbType.NVarChar);
                command.Parameters.Add("@accessory", SqlDbType.NVarChar);
                command.Parameters.Add("@notes", SqlDbType.NVarChar);

                command.Parameters.Add("@normal_price", SqlDbType.Int);
                command.Parameters.Add("@discount_amount", SqlDbType.Int);
                command.Parameters.Add("@additional_fee", SqlDbType.Int);
                command.Parameters.Add("@final_price", SqlDbType.Int);
                command.Parameters.Add("@processing_fee", SqlDbType.Int);

                command.Parameters.Add("@deliver_date", SqlDbType.NVarChar);

                foreach (var salesOrderItem in req.ReceivingSalesOrderItemList)
                {
                    if (salesOrderItem.IsRetrived || salesOrderItem.IsReturnForReWashing || salesOrderItem.IsContinueWashing)
                    {
                        command.Parameters["@salesorder_id"].Value = salesOrderItem.gdata.wano;
                        command.Parameters["@barcode_id"].Value = salesOrderItem.gdata.wano2;

                        command.Parameters["@clothes_type_id"].Value = salesOrderItem.Clothes.dno;
                        command.Parameters["@material_id"].Value = salesOrderItem.Material.wno;
                        command.Parameters["@handle_type_id"].Value = salesOrderItem.HandleType.typeno;
                        command.Parameters["@processing_type_id"].Value = string.IsNullOrEmpty(salesOrderItem.ProcessingType.addno) ? (object)DBNull.Value : salesOrderItem.ProcessingType.addno;
                        command.Parameters["@processing_type_id"].IsNullable = true;

                        command.Parameters["@color"].Value = salesOrderItem.gdata.color;

                        command.Parameters["@accessory"].Value = string.IsNullOrEmpty(salesOrderItem.gdata.fknd) ? (object)DBNull.Value : salesOrderItem.gdata.fknd;
                        command.Parameters["@accessory"].IsNullable = true;

                        if ((salesOrderItem.gdata.money4 < 0) || (salesOrderItem.gdata.money5 < 0))
                        {
                            salesOrderItem.gdata.note += "(廠回不洗)";
                        }
                        command.Parameters["@notes"].Value = string.IsNullOrEmpty(salesOrderItem.gdata.note) ? (object)DBNull.Value : salesOrderItem.gdata.note;
                        command.Parameters["@notes"].IsNullable = true;

                        if ((salesOrderItem.gdata.money4 < 0) || (salesOrderItem.gdata.money5 < 0))
                        {
                            command.Parameters["@normal_price"].Value = 0;
                            command.Parameters["@discount_amount"].Value = 0;
                            command.Parameters["@additional_fee"].Value = 0;
                            command.Parameters["@final_price"].Value = 0;
                            command.Parameters["@processing_fee"].Value = 0;
                        }
                        else
                        {
                            command.Parameters["@normal_price"].Value = salesOrderItem.gdata.money0;
                            command.Parameters["@discount_amount"].Value = salesOrderItem.gdata.money3;
                            command.Parameters["@additional_fee"].Value = salesOrderItem.gdata.money2;
                            command.Parameters["@final_price"].Value = salesOrderItem.gdata.money4;
                            command.Parameters["@processing_fee"].Value = salesOrderItem.gdata.money5;
                        }

                        command.Parameters["@deliver_date"].Value = salesOrderItem.gdata.date1;

                        command.ExecuteNonQuery();
                    }
                }

                foreach (var salesOrderItem in req.ReceivingSalesOrderItemList2)
                {
                    if (salesOrderItem.IsRetrived || salesOrderItem.IsReturnForReWashing || salesOrderItem.IsContinueWashing)
                    {
                        command.Parameters["@salesorder_id"].Value = req.salesorder_id;
                        command.Parameters["@barcode_id"].Value = salesOrderItem.gdata.wano2;

                        command.Parameters["@clothes_type_id"].Value = salesOrderItem.Clothes.dno;
                        command.Parameters["@material_id"].Value = salesOrderItem.Material.wno;
                        command.Parameters["@handle_type_id"].Value = salesOrderItem.HandleType.typeno;
                        command.Parameters["@processing_type_id"].Value = string.IsNullOrEmpty(salesOrderItem.ProcessingType.addno) ? (object)DBNull.Value : salesOrderItem.ProcessingType.addno;
                        command.Parameters["@processing_type_id"].IsNullable = true;

                        command.Parameters["@color"].Value = salesOrderItem.gdata.color;

                        command.Parameters["@accessory"].Value = string.IsNullOrEmpty(salesOrderItem.gdata.fknd) ? (object)DBNull.Value : salesOrderItem.gdata.fknd;
                        command.Parameters["@accessory"].IsNullable = true;

                        if (salesOrderItem.IsContinueWashing)
                        {
                            salesOrderItem.gdata.note += "(廠回續洗)";
                        }
                        else if ((salesOrderItem.gdata.money4 < 0) || (salesOrderItem.gdata.money5 < 0))
                        {
                            salesOrderItem.gdata.note += "(廠回不洗)";
                        }
                        command.Parameters["@notes"].Value = string.IsNullOrEmpty(salesOrderItem.gdata.note) ? (object)DBNull.Value : salesOrderItem.gdata.note;
                        command.Parameters["@notes"].IsNullable = true;

                        if ((salesOrderItem.gdata.money4 < 0) || (salesOrderItem.gdata.money5 < 0))
                        {
                            command.Parameters["@normal_price"].Value = 0;
                            command.Parameters["@discount_amount"].Value = 0;
                            command.Parameters["@additional_fee"].Value = 0;
                            command.Parameters["@final_price"].Value = 0;
                            command.Parameters["@processing_fee"].Value = 0;
                        }
                        else
                        {
                            command.Parameters["@normal_price"].Value = salesOrderItem.gdata.money0;
                            command.Parameters["@discount_amount"].Value = salesOrderItem.gdata.money3;
                            command.Parameters["@additional_fee"].Value = salesOrderItem.gdata.money2;
                            command.Parameters["@final_price"].Value = salesOrderItem.gdata.money4;
                            command.Parameters["@processing_fee"].Value = salesOrderItem.gdata.money5;
                        }
                        //20190219修改應交件日
                        //command.Parameters["@deliver_date"].Value = currentTime.AddDays(salesOrderItem.DaysNeededForDelivery).ToString("yyyyMMdd");
                        command.Parameters["@deliver_date"].Value = req.currentTime.AddDays(salesOrderItem.DaysNeededForDelivery).DayOfWeek.ToString() == "Sunday" ? req.currentTime.AddDays(salesOrderItem.DaysNeededForDelivery + 1).ToString("yyyyMMdd") : req.currentTime.AddDays(salesOrderItem.DaysNeededForDelivery).ToString("yyyyMMdd");

                        command.ExecuteNonQuery();
                    }
                }
            }

        }

        public int InsertSalesOrderHistoryRewashing(tww_salesorder_history req)
        {

            int Id = 0;
            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();

                command.CommandText = "INSERT INTO tww_salesorder_history ( event_time, branch_id, customer_id, event_type, retriving_number, " +
                                      "normal_price_sum, discount_amount_sum, additional_fee_sum, final_price_sum, processing_fee_sum, customer_recevible, edit_id ) " +
                                      "output INSERTED.id " +
                                      "VALUES ( @event_time, @branch_id, @customer_id, @event_type, @retriving_number, " +
                                      "@normal_price_sum, @discount_amount_sum, @additional_fee_sum, @final_price_sum, @processing_fee_sum, @customer_recevible, @edit_id )";

                command.Parameters.AddWithValue("@event_time", req.event_time);
                command.Parameters.AddWithValue("@branch_id", req.branch_id);
                command.Parameters.AddWithValue("@customer_id", req.customer_id);
                command.Parameters.AddWithValue("@event_type", "回洗回燙");

                command.Parameters.AddWithValue("@retriving_number", req.retriving_number);

                command.Parameters.AddWithValue("@normal_price_sum", req.normal_price_sum);
                command.Parameters.AddWithValue("@discount_amount_sum", req.discount_amount_sum);
                command.Parameters.AddWithValue("@additional_fee_sum", req.additional_fee_sum);
                command.Parameters.AddWithValue("@final_price_sum", req.final_price_sum);
                command.Parameters.AddWithValue("@processing_fee_sum", req.processing_fee_sum);

                command.Parameters.AddWithValue("@customer_recevible", req.customer_recevible);

                command.Parameters.AddWithValue("@edit_id", req.edit_id);

                Id = (int)command.ExecuteScalar();
            }
            return Id;
        }

        public int InsertSalesOrderHistoryContinuewashing(tww_salesorder_history tww_Salesorder_History)
        {

            int Id = 0;

            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();

                command.CommandText = "INSERT INTO tww_salesorder_history ( event_time, branch_id, customer_id, event_type, retriving_number, " +
                                      "normal_price_sum, discount_amount_sum, additional_fee_sum, final_price_sum, processing_fee_sum, customer_recevible, edit_id ) " +
                                      "output INSERTED.id " +
                                      "VALUES ( @event_time, @branch_id, @customer_id, @event_type, @retriving_number, " +
                                      "@normal_price_sum, @discount_amount_sum, @additional_fee_sum, @final_price_sum, @processing_fee_sum, @customer_recevible, @edit_id )";

                command.Parameters.AddWithValue("@event_time", tww_Salesorder_History.event_time);
                command.Parameters.AddWithValue("@branch_id", tww_Salesorder_History.branch_id);
                command.Parameters.AddWithValue("@customer_id", tww_Salesorder_History.customer_id);
                command.Parameters.AddWithValue("@event_type", "廠回續洗");

                command.Parameters.AddWithValue("@retriving_number", tww_Salesorder_History.retriving_number);

                command.Parameters.AddWithValue("@normal_price_sum", tww_Salesorder_History.normal_price_sum);
                command.Parameters.AddWithValue("@discount_amount_sum", tww_Salesorder_History.discount_amount_sum);
                command.Parameters.AddWithValue("@additional_fee_sum", tww_Salesorder_History.additional_fee_sum);
                command.Parameters.AddWithValue("@final_price_sum", tww_Salesorder_History.final_price_sum);
                command.Parameters.AddWithValue("@processing_fee_sum", tww_Salesorder_History.processing_fee_sum);

                command.Parameters.AddWithValue("@customer_recevible", tww_Salesorder_History.customer_recevible);

                command.Parameters.AddWithValue("@edit_id", tww_Salesorder_History.edit_id);

                Id = (int)command.ExecuteScalar();
            }



            return Id;


        }
        public int InsertSalesOrderHistoryPrepaidCash(tww_salesorder_history tww_Salesorder_History)
        {
            int Id = 0;

            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();

                /*command.CommandText = "INSERT INTO tww_salesorder_history ( event_time, branch_id, customer_id, event_type, cashing_in, " +
                                      "customer_recevible, edit_id, invoice_number, uniform_number ) " +
                                      "output INSERTED.id " +
                                      "VALUES ( @event_time, @branch_id, @customer_id, @event_type, @cashing_in, " +
                                      "@customer_recevible, @edit_id, @invoice_number, @uniform_number )";*/

                //0313 新增預收贈送金額欄位
                command.CommandText = "INSERT INTO tww_salesorder_history ( event_time, branch_id, customer_id, event_type, cashing_in, " +
                                      "customer_recevible, edit_id, invoice_number, uniform_number,prepaid_cash_discount ) " +
                                      "output INSERTED.id " +
                                      "VALUES ( @event_time, @branch_id, @customer_id, @event_type, @cashing_in, " +
                                      "@customer_recevible, @edit_id, @invoice_number, @uniform_number ,@prepaid_cash_discount)";

                command.Parameters.AddWithValue("@event_time", tww_Salesorder_History.event_time);
                command.Parameters.AddWithValue("@branch_id", tww_Salesorder_History.branch_id);
                command.Parameters.AddWithValue("@customer_id", tww_Salesorder_History.customer_id);
                command.Parameters.AddWithValue("@event_type", "預卡優惠");

                command.Parameters.AddWithValue("@cashing_in", tww_Salesorder_History.cashing_in);

                command.Parameters.AddWithValue("@customer_recevible", tww_Salesorder_History.customer_recevible);

                command.Parameters.AddWithValue("@edit_id", tww_Salesorder_History.edit_id);

                if (tww_Salesorder_History.invoice_number != null || tww_Salesorder_History.invoice_number != "")
                {
                    command.Parameters.AddWithNullableValue("@invoice_number", tww_Salesorder_History.invoice_number);
                    command.Parameters.AddWithNullableValue("@uniform_number", tww_Salesorder_History.uniform_number);
                }
                else
                {
                    command.Parameters.AddWithNullableValue("@invoice_number", DBNull.Value);
                    command.Parameters.AddWithNullableValue("@uniform_number", DBNull.Value);
                }

                command.Parameters.AddWithValue("@prepaid_cash_discount", tww_Salesorder_History.prepaid_cash_discount);

                Id = (int)command.ExecuteScalar();
            }
            return Id;

        }
        public int InsertSalesOrderHistoryCashing(tww_salesorder_history tww_Salesorder_History)
        {


            int Id;

            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();

                command.CommandText = "INSERT INTO tww_salesorder_history ( event_time, branch_id, customer_id, event_type, cashing_in, " +
                                      "customer_recevible, edit_id, invoice_number, uniform_number ) " +
                                      "output INSERTED.id " +
                                      "VALUES ( @event_time, @branch_id, @customer_id, @event_type, @cashing_in, " +
                                      "@customer_recevible, @edit_id, @invoice_number, @uniform_number )";

                command.Parameters.AddWithValue("@event_time", tww_Salesorder_History.event_time);
                command.Parameters.AddWithValue("@branch_id", tww_Salesorder_History.branch_id);
                command.Parameters.AddWithValue("@customer_id", tww_Salesorder_History.customer_id);
                command.Parameters.AddWithValue("@event_type", "付款");

                command.Parameters.AddWithValue("@cashing_in", tww_Salesorder_History.cashing_in);

                command.Parameters.AddWithValue("@customer_recevible", tww_Salesorder_History.customer_recevible);

                command.Parameters.AddWithValue("@edit_id", tww_Salesorder_History.edit_id);

                if (tww_Salesorder_History.invoice_number != null)
                {

                    command.Parameters.AddWithNullableValue("@invoice_number", tww_Salesorder_History.invoice_number);



                }
                else
                {
                    command.Parameters.AddWithNullableValue("@invoice_number", DBNull.Value);
                   
                }
                if (tww_Salesorder_History.uniform_number != null)
                {
                    command.Parameters.AddWithNullableValue("@uniform_number", tww_Salesorder_History.uniform_number);
                }
                else
                {
                    command.Parameters.AddWithNullableValue("@uniform_number", DBNull.Value);
                }
                Id = (int)command.ExecuteScalar();
            }
            return Id;

        }

        public int InsertSalesOrderHistoryIncreaseArrears(tww_salesorder_history tww_Salesorder_History)
        {

            int Id;

            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();

                command.CommandText = "INSERT INTO tww_salesorder_history ( event_time, branch_id, customer_id, event_type, cashing_in, " +
                                      "customer_recevible, edit_id, remark ) " +
                                      "output INSERTED.id " +
                                      "VALUES ( @event_time, @branch_id, @customer_id, @event_type, @cashing_in, " +
                                      "@customer_recevible, @edit_id, @remark )";

                command.Parameters.AddWithValue("@event_time", tww_Salesorder_History.event_time);
                command.Parameters.AddWithValue("@branch_id", tww_Salesorder_History.branch_id);
                command.Parameters.AddWithValue("@customer_id", tww_Salesorder_History.customer_id);


                command.Parameters.AddWithValue("@event_type", tww_Salesorder_History.event_type);


                command.Parameters.AddWithValue("@cashing_in", tww_Salesorder_History.cashing_in);

                command.Parameters.AddWithValue("@customer_recevible", tww_Salesorder_History.customer_recevible);

                command.Parameters.AddWithValue("@edit_id", tww_Salesorder_History.edit_id);

                command.Parameters.AddWithNullableValue("@remark", tww_Salesorder_History.remark);

                Id = (int)command.ExecuteScalar();
            }
            return Id;


        }

        public int InsertSalesOrderHistoryDebitCash(tww_salesorder_history tww_Salesorder_History)
        {

            int Id;

            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();

                command.CommandText = "INSERT INTO tww_salesorder_history ( event_time, branch_id, customer_id, event_type, cashing_in, " +
                                      "customer_recevible, edit_id, remark ) " +
                                      "output INSERTED.id " +
                                      "VALUES ( @event_time, @branch_id, @customer_id, @event_type, @cashing_in, " +
                                      "@customer_recevible, @edit_id, @remark )";

                command.Parameters.AddWithValue("@event_time", tww_Salesorder_History.event_time);
                command.Parameters.AddWithValue("@branch_id", tww_Salesorder_History.branch_id);
                command.Parameters.AddWithValue("@customer_id", tww_Salesorder_History.customer_id);


                command.Parameters.AddWithValue("@event_type", tww_Salesorder_History.event_type);



                command.Parameters.AddWithValue("@cashing_in", tww_Salesorder_History.cashing_in);

                command.Parameters.AddWithValue("@customer_recevible", tww_Salesorder_History.customer_recevible);

                command.Parameters.AddWithValue("@edit_id", tww_Salesorder_History.edit_id);

                command.Parameters.AddWithNullableValue("@remark", tww_Salesorder_History.remark);

                Id = (int)command.ExecuteScalar();
            }
            return Id;

        }
        public void UpdateRevisingSalesOrderItem(gdata gdata)
        {

            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();

                command.CommandText = "Update gdata set date2=@date2, dno=@dno, wno=@wno, typeno=@typeno, addno=@addno, color=@color, fknd=@fknd, note=@note, " +
                                      "money=@money, money0=@money0, money1=@money1, money2=@money2, money3=@money3, money4=@money4, money5=@money5, " +
                                      "caseno=@caseno, per=@per, Revicion_Note=@Revicion_Note, delwano2=@delwano2 " +
                                      "where wano=@wano and wano2=@wano2 and manno=@manno and offno=@offno";


                command.Parameters.AddWithValue("@date2", gdata.date2);

                command.Parameters.AddWithValue("@dno", gdata.dno);
                command.Parameters.AddWithValue("@wno", gdata.wno);
                command.Parameters.AddWithValue("@typeno", gdata.typeno);
                command.Parameters.AddWithNullableValue("@addno", gdata.addno);



                command.Parameters.AddWithNullableValue("@color", gdata.color);

                command.Parameters.AddWithNullableValue("@fknd", gdata.fknd);

                command.Parameters.AddWithNullableValue("@note", gdata.note);

                command.Parameters.AddWithValue("@money", gdata.money0);
                command.Parameters.AddWithValue("@money0", gdata.money0);
                command.Parameters.AddWithValue("@money1", 0);
                command.Parameters.AddWithValue("@money2", gdata.money2);
                command.Parameters.AddWithValue("@money3", gdata.money3);
                command.Parameters.AddWithValue("@money4", gdata.money4);
                command.Parameters.AddWithValue("@money5", gdata.money5);

                command.Parameters.AddWithNullableValue("@caseno", gdata.caseno);
                command.Parameters.AddWithNullableValue("@per", gdata.per);
                command.Parameters.AddWithNullableValue("@Revicion_Note", gdata.Revicion_Note);

                command.Parameters.AddWithValue("@wano", gdata.wano);
                command.Parameters.AddWithValue("@wano2", gdata.wano2);
                command.Parameters.AddWithValue("@manno", gdata.manno);
                command.Parameters.AddWithValue("@offno", gdata.offno);

                command.Parameters.AddWithValue("@delwano2", gdata.delwano2 ? "t" : "f");

                command.ExecuteNonQuery();

            }

        }

        public void UpdateCustomerRecevibleForRevising(adata adata)
        {


            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();

                command.CommandText = "Update adata set money=@money, day=@day where manno=@manno and offno=@offno";

                command.Parameters.AddWithValue("@money", adata.money);
                command.Parameters.AddWithValue("@day", adata.day);

                command.Parameters.AddWithValue("@manno", adata.manno);
                command.Parameters.AddWithValue("@offno", adata.offno);
                command.ExecuteNonQuery();
            }

        }

        public int InsertSalesOrderHistoryRevising(tww_salesorder_history tww_Salesorder_History)
        {

            int Id;

            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();

                command.CommandText = "INSERT INTO tww_salesorder_history ( event_time, branch_id, customer_id, event_type, revising_number, " +
                                      "normal_price_sum, discount_amount_sum, additional_fee_sum, final_price_sum, processing_fee_sum, customer_recevible, edit_id ) " +
                                      "output INSERTED.id " +
                                      "VALUES ( @event_time, @branch_id, @customer_id, @event_type, @revising_number, " +
                                      "@normal_price_sum, @discount_amount_sum, @additional_fee_sum, @final_price_sum, @processing_fee_sum, @customer_recevible, @edit_id )";

                command.Parameters.AddWithValue("@event_time", tww_Salesorder_History.event_time);
                command.Parameters.AddWithValue("@branch_id", tww_Salesorder_History.branch_id);
                command.Parameters.AddWithValue("@customer_id", tww_Salesorder_History.customer_id);
                command.Parameters.AddWithValue("@event_type", "修改");

                command.Parameters.AddWithValue("@revising_number", tww_Salesorder_History.revising_number);

                command.Parameters.AddWithValue("@normal_price_sum", tww_Salesorder_History.normal_price_sum);
                command.Parameters.AddWithValue("@discount_amount_sum", tww_Salesorder_History.discount_amount_sum);
                command.Parameters.AddWithValue("@additional_fee_sum", tww_Salesorder_History.additional_fee_sum);
                command.Parameters.AddWithValue("@final_price_sum", tww_Salesorder_History.final_price_sum);
                command.Parameters.AddWithValue("@processing_fee_sum", tww_Salesorder_History.processing_fee_sum);

                command.Parameters.AddWithValue("@customer_recevible", tww_Salesorder_History.customer_recevible);

                command.Parameters.AddWithValue("@edit_id", tww_Salesorder_History.edit_id);

                Id = (int)command.ExecuteScalar();
            }

            return Id;

        }
        public void InsertSalesOrderHistoryRevisingDetails(InsertSalesOrderHistoryDetailsReq req)
        {
            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();

                command.CommandText =
                    "INSERT INTO tww_salesorder_history_details ( tww_salesorder_history_id, salesorder_id, barcode_id, clothes_type_id, material_id, handle_type_id, processing_type_id, " +
                    "color, accessory, notes, normal_price, discount_amount, additional_fee, final_price, processing_fee, deliver_date, is_disposed) " +
                    "VALUES ( @tww_salesorder_history_id, @salesorder_id, @barcode_id, @clothes_type_id, @material_id, @handle_type_id, @processing_type_id, " +
                    "@color, @accessory, @notes, @normal_price, @discount_amount, @additional_fee, @final_price, @processing_fee, @deliver_date, @is_disposed )";

                command.Parameters.AddWithValue("@tww_salesorder_history_id", req.aSalesOrderHistoryId);

                command.Parameters.Add("@salesorder_id", SqlDbType.NVarChar);
                command.Parameters.Add("@barcode_id", SqlDbType.NVarChar);

                command.Parameters.Add("@clothes_type_id", SqlDbType.NVarChar);
                command.Parameters.Add("@material_id", SqlDbType.NVarChar);
                command.Parameters.Add("@handle_type_id", SqlDbType.NVarChar);
                command.Parameters.Add("@processing_type_id", SqlDbType.NVarChar);

                command.Parameters.Add("@color", SqlDbType.NVarChar);
                command.Parameters.Add("@accessory", SqlDbType.NVarChar);
                command.Parameters.Add("@notes", SqlDbType.NVarChar);

                command.Parameters.Add("@normal_price", SqlDbType.Int);
                command.Parameters.Add("@discount_amount", SqlDbType.Int);
                command.Parameters.Add("@additional_fee", SqlDbType.Int);
                command.Parameters.Add("@final_price", SqlDbType.Int);
                command.Parameters.Add("@processing_fee", SqlDbType.Int);

                command.Parameters.Add("@deliver_date", SqlDbType.NVarChar);

                command.Parameters.Add("@is_disposed", SqlDbType.Bit);

                //0806 比對detail
                ClothesSaleOrderItem salesOrderItem;
                for (int i = 0; i < req.ReceivingSalesOrderItemList.Count; i++)
                {
                    string strColor = "";
                    string strAccessory = "";

                    if (!JsonCompare(req.ReceivingSalesOrderItemList[i], req.ReceivingSalesOrderItemList2[i]))
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            if (j == 0)
                            {
                                salesOrderItem = req.ReceivingSalesOrderItemList2[i];
                                command.Parameters["@color"].Value = salesOrderItem.gdata.color;

                                command.Parameters["@accessory"].Value = string.IsNullOrEmpty(salesOrderItem.gdata.fknd) ? (object)DBNull.Value : salesOrderItem.gdata.fknd;
                                command.Parameters["@accessory"].IsNullable = true;
                            }
                            else
                            {
                                salesOrderItem = req.ReceivingSalesOrderItemList[i];

                                //0806 顏色
                                if (req.ReceivingSalesOrderItemList[i].ColorList.Any())
                                {
                                    foreach (var color in req.ReceivingSalesOrderItemList[i].ColorList)
                                    {
                                        strColor += color.colorna;
                                    }
                                }
                                command.Parameters["@color"].Value = strColor;

                                //0806 配件
                                if (req.ReceivingSalesOrderItemList[i].AccessoryList.Any())
                                {
                                    foreach (var accessory in req.ReceivingSalesOrderItemList[i].AccessoryList)
                                    {
                                        strAccessory += accessory.fkndna;
                                    }
                                }
                                command.Parameters["@accessory"].Value = string.IsNullOrEmpty(strAccessory) ? (object)DBNull.Value : strAccessory;
                                command.Parameters["@accessory"].IsNullable = true;
                            }



                            command.Parameters["@salesorder_id"].Value = salesOrderItem.gdata.wano;
                            command.Parameters["@barcode_id"].Value = salesOrderItem.gdata.wano2;

                            command.Parameters["@clothes_type_id"].Value = salesOrderItem.Clothes.dno;
                            command.Parameters["@material_id"].Value = salesOrderItem.Material.wno;
                            command.Parameters["@handle_type_id"].Value = salesOrderItem.HandleType.typeno;
                            command.Parameters["@processing_type_id"].Value = string.IsNullOrEmpty(salesOrderItem.ProcessingType.addno) ? (object)DBNull.Value : salesOrderItem.ProcessingType.addno;
                            command.Parameters["@processing_type_id"].IsNullable = true;

                            //command.Parameters["@color"].Value = salesOrderItem.Color;

                            //command.Parameters["@accessory"].Value = string.IsNullOrEmpty(salesOrderItem.Accessory) ? (object)DBNull.Value : salesOrderItem.Accessory;
                            //command.Parameters["@accessory"].IsNullable = true;

                            command.Parameters["@notes"].Value = string.IsNullOrEmpty(salesOrderItem.gdata.note) ? (object)DBNull.Value : salesOrderItem.gdata.note;
                            command.Parameters["@notes"].IsNullable = true;

                            command.Parameters["@normal_price"].Value = salesOrderItem.gdata.money0;
                            command.Parameters["@discount_amount"].Value = salesOrderItem.gdata.money3;
                            command.Parameters["@additional_fee"].Value = salesOrderItem.gdata.money2;
                            command.Parameters["@final_price"].Value = salesOrderItem.gdata.money4;
                            command.Parameters["@processing_fee"].Value = salesOrderItem.gdata.money5;

                            command.Parameters["@deliver_date"].Value = salesOrderItem.gdata.date1;

                            command.Parameters["@is_disposed"].Value = salesOrderItem.tww_Salesorder_History_Details.is_disposed;

                            command.ExecuteNonQuery();
                        }
                    }
                }
            }

        }
        public void UpdateCustomerThisYearTotal(adata adata)
        {
            int ThisYearTotal = 0;
            //從歷史收取件紀錄中計算年消
            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                DateTime todaysDate = DateTime.Now.Date;
                int thisyear = todaysDate.Year;

                connection.Open();
                command.CommandText = "select branch_id, customer_id, sum(final_price_sum) as thisyeartotal from tww_salesorder_history where event_type in('收件','修改') and event_time > @thisyear_s and event_time < @thisyear_e and branch_id=@hostid and customer_id=@customer_id group by branch_id,customer_id";

                command.Parameters.AddWithValue("@thisyear_s", thisyear + "-01-01 00:00:00");
                command.Parameters.AddWithValue("@thisyear_e", thisyear + "-12-31 23:59:59");

                command.Parameters.AddWithValue("@hostid", adata.offno);
                command.Parameters.AddWithValue("@customer_id", adata.manno);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ThisYearTotal = reader.GetInt32(2);
                    }
                }
            }
            //更新年消至客戶基本資料中
            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {

                connection.Open();
                command.CommandText = "Update adata set money1=@money where manno=@manno and offno=@offno";
                command.Parameters.AddWithValue("@money", ThisYearTotal);
                command.Parameters.AddWithValue("@manno", adata.offno);
                command.Parameters.AddWithValue("@offno", adata.manno);
                command.ExecuteNonQuery();

            }
        }

        public void UpdateNewHistorySalesOrder(tww_salesorder_history tww_Salesorder_History)
        {
            int Receivible = 0;
            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                SqlTransaction transaction;

                // Start a local transaction.
                transaction = connection.BeginTransaction("SampleTransaction");

                // Must assign both transaction object and connection
                // to Command object for a pending local transaction
                command.Connection = connection;
                command.Transaction = transaction;
                try
                {
                    command.CommandText = "Update tww_salesorder_history set is_payment_cancelled=@is_payment_cancelled where id=@id";

                    command.Parameters.AddWithValue("@id", tww_Salesorder_History.id);
                    command.Parameters.AddWithValue("@is_payment_cancelled", true);

                    command.ExecuteNonQuery();
                    command.CommandText = "select event_type, cashing_in, branch_id, customer_id, invoice_number, prepaid_cash_discount " +
                                          "from tww_salesorder_history where id=@id";

                    //  command.Parameters.AddWithValue("@id", tww_Salesorder_History.id);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            tww_Salesorder_History.event_type = GetNullableStringField(reader, 0);
                            tww_Salesorder_History.cashing_in = reader.GetInt32(1);
                            tww_Salesorder_History.branch_id = reader.GetString(2);
                            tww_Salesorder_History.customer_id = reader.GetString(3);

                            if (!Convert.IsDBNull(reader[4]))
                            {
                                tww_Salesorder_History.invoice_number = reader.GetString(4);
                            }

                            tww_Salesorder_History.prepaid_cash_discount = reader.GetInt32(5);

                        }
                    }
                    reader.Close();

                    command.CommandText = "Update adata set money=(money+@money) where manno=@manno and offno=@offno";

                    //預卡優惠判斷
                    if (tww_Salesorder_History.event_type == "預卡優惠")
                    {
                        command.Parameters.AddWithValue("@money", tww_Salesorder_History.cashing_in + tww_Salesorder_History.prepaid_cash_discount);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@money", tww_Salesorder_History.cashing_in);
                    }

                    command.Parameters.AddWithValue("@manno", tww_Salesorder_History.customer_id);
                    command.Parameters.AddWithValue("@offno", tww_Salesorder_History.branch_id);
                    command.ExecuteNonQuery();

                    command.CommandText = "select money from adata where manno=@manno and offno=@offno";

                    // command.Parameters.AddWithValue("@manno", tww_Salesorder_History.customer_id);
                    // command.Parameters.AddWithValue("@offno", tww_Salesorder_History.branch_id);

                    SqlDataReader reader2 = command.ExecuteReader();

                    if (reader2.HasRows)
                    {
                        while (reader2.Read())
                        {
                            Receivible = Convert.ToInt32(reader2.GetDouble(0));
                        }
                    }
                    reader2.Close();
                    command.CommandText = "INSERT INTO tww_salesorder_history ( event_time, branch_id, customer_id, event_type, cashing_in, " +
                                              "customer_recevible, edit_id, invoice_number ) " +
                                              "output INSERTED.id " +
                                              "VALUES ( @event_time, @branch_id, @customer_id, @event_type, @cashing_in, " +
                                              "@customer_recevible, @edit_id, @invoice_number )";


                    command.Parameters.AddWithValue("@event_time", DateTime.Now);
                    command.Parameters.AddWithValue("@branch_id", tww_Salesorder_History.branch_id);
                    command.Parameters.AddWithValue("@customer_id", tww_Salesorder_History.customer_id);
                    command.Parameters.AddWithValue("@event_type", "付款(發票)作廢");

                    command.Parameters.AddWithValue("@cashing_in", tww_Salesorder_History.cashing_in);
                    command.Parameters.AddWithValue("@customer_recevible", Receivible);

                    command.Parameters.AddWithValue("@edit_id", tww_Salesorder_History.branch_id);

                    command.Parameters.AddWithNullableValue("@invoice_number", tww_Salesorder_History.invoice_number);

                    command.ExecuteScalar();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    try
                    {
                        transaction.Rollback();
                        throw;
                    }
                    catch (Exception ex2)
                    {
                        throw;
                    }
                }
                connection.Close();
                connection.Dispose();
            }
        }
        public void UpdateNewHistorySalesOrderCancel(CustomerOrdersUpdateReq req)
        {
            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                SqlTransaction transaction;

                // Start a local transaction.
                transaction = connection.BeginTransaction("SampleTransaction");

                // Must assign both transaction object and connection
                // to Command object for a pending local transaction
                command.Connection = connection;
                command.Transaction = transaction;
                try
                {

                  
                    foreach (var aSalesModel in req.SalesOrderList)
                    {
                        command.Parameters.Clear();
                        //取消取件
                        command.CommandText = "Update gdata set getw=@getw, date3=@date3 where wano=@wano and wano2=@wano2 and offno=@offno";

                        command.Parameters.AddWithValue("@getw", "f");
                        command.Parameters.AddWithNullableValue("@date3", null);
                        command.Parameters.AddWithValue("@wano", aSalesModel.gdata.wano);
                        command.Parameters.AddWithValue("@wano2", aSalesModel.gdata.wano2);
                        //command.Parameters.AddWithValue("@manno", customerId);
                        command.Parameters.AddWithValue("@offno", req.LoginCmdModel.tww_Store.store_id);
                        command.ExecuteNonQuery();
                        bool result = false;
                        command.CommandText = "select Id,barcode_id,outgoing_shippment_id,is_retrieved,is_nonwashing_return,is_nonwashing_return,orderno " +
                                              "from tww_outgoing_shippment where store_id=@store_id and barcode_id = @barcode_id and orderno = @orderno ";
                        command.Parameters.AddWithValue("@store_id", req.LoginCmdModel.tww_Store.store_id);
                        command.Parameters.AddWithValue("@barcode_id", aSalesModel.gdata.wano2);
                        command.Parameters.AddWithValue("@orderno", aSalesModel.gdata.wano);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            result = true;
                        }
                        reader.Close();
                      
                        if (result)
                        {
                            command.CommandText = "Update tww_outgoing_shippment set is_retrieved=@is_retrieved where store_id=@store_id and barcode_id=@barcode_id and orderno = @orderno";

                            command.Parameters.AddWithValue("@is_retrieved", false);
                            command.Parameters.AddWithValue("@store_id", req.LoginCmdModel.tww_Store.store_id);
                            command.Parameters.AddWithValue("@barcode_id", aSalesModel.gdata.wano2);

                            //加入洗衣單號才不會重覆更新
                            command.Parameters.AddWithValue("@orderno", aSalesModel.gdata.wano);

                            command.ExecuteNonQuery();
                        }
                    }
                    command.Parameters.Clear();
                    tww_salesorder_history tww_Salesorder_History = new tww_salesorder_history();
                    //新增歷程
                    //Step1. 查詢、新增該筆曆程
                    command.CommandText = "select id, event_time, event_type, receiving_number, retriving_number, revising_number, cashing_in, " +
                                          "normal_price_sum, discount_amount_sum, additional_fee_sum, final_price_sum, processing_fee_sum, customer_recevible, " +
                                          "edit_id, invoice_number, is_payment_cancelled, remark, customer_id " +
                                          "from tww_salesorder_history where id=@id and branch_id=@branch_id order by event_time desc";

                    command.Parameters.AddWithValue("@id", req.SearchId);
                    command.Parameters.AddWithValue("@branch_id", req.LoginCmdModel.tww_Store.store_id);

                    SqlDataReader reader2 = command.ExecuteReader();

                    if (reader2.HasRows)
                    {
                        while (reader2.Read())
                        {
                            tww_Salesorder_History.id = reader2.GetInt32(0);
                            var aTime = reader2.GetDateTime(1);
                            tww_Salesorder_History.event_time = aTime.ToString("yyyy/MM/dd HH:mm");
                            tww_Salesorder_History.event_type = GetNullableStringField(reader2, 2);

                            tww_Salesorder_History.receiving_number = reader2.GetInt32(3);
                            tww_Salesorder_History.retriving_number = reader2.GetInt32(4);
                            tww_Salesorder_History.revising_number = reader2.GetInt32(5);
                            tww_Salesorder_History.cashing_in = reader2.GetInt32(6);

                            tww_Salesorder_History.normal_price_sum = reader2.GetInt32(7);
                            tww_Salesorder_History.discount_amount_sum = reader2.GetInt32(8);
                            tww_Salesorder_History.additional_fee_sum = reader2.GetInt32(9);
                            tww_Salesorder_History.final_price_sum = reader2.GetInt32(10);
                            tww_Salesorder_History.processing_fee_sum = reader2.GetInt32(11);

                            tww_Salesorder_History.customer_recevible = reader2.GetInt32(12);

                            tww_Salesorder_History.edit_id = GetNullableStringField(reader2, 13);
                            tww_Salesorder_History.invoice_number = GetNullableStringField(reader2, 14);

                            tww_Salesorder_History.is_payment_cancelled = reader2.GetBoolean(15);

                            tww_Salesorder_History.remark = GetNullableStringField(reader2, 16);
                            tww_Salesorder_History.customer_id = GetNullableStringField(reader2, 17);


                        }
                    }
                    reader2.Close();
                    command.Parameters.Clear();
                    command.CommandText = @" INSERT INTO tww_salesorder_history (event_time, branch_id, customer_id ,event_type, receiving_number, retriving_number, revising_number, 
                                             cashing_in, normal_price_sum, discount_amount_sum, additional_fee_sum, final_price_sum, processing_fee_sum, customer_recevible, edit_id)
                                             output INSERTED.id 
                                             VALUES(@event_time, @branch_id, @customer_id, @event_type, @receiving_number, @retriving_number, @revising_number, @cashing_in, @normal_price_sum,
                                             @discount_amount_sum, @additional_fee_sum, @final_price_sum, @processing_fee_sum, @customer_recevible, @edit_id)";
                    DateTime currentTime = DateTime.Now;
                    command.Parameters.AddWithValue("@event_time", currentTime);
                    command.Parameters.AddWithValue("@branch_id", req.LoginCmdModel.tww_Store.store_id);
                    command.Parameters.AddWithValue("@customer_id", tww_Salesorder_History.customer_id);
                    command.Parameters.AddWithValue("@event_type", "取消取件");

                    command.Parameters.AddWithValue("@revising_number", tww_Salesorder_History.revising_number);
                    command.Parameters.AddWithValue("@receiving_number", tww_Salesorder_History.receiving_number);
                    command.Parameters.AddWithValue("@retriving_number", tww_Salesorder_History.retriving_number);
                    command.Parameters.AddWithValue("@cashing_in", tww_Salesorder_History.cashing_in);
                    command.Parameters.AddWithValue("@normal_price_sum", tww_Salesorder_History.normal_price_sum);
                    command.Parameters.AddWithValue("@discount_amount_sum", tww_Salesorder_History.discount_amount_sum);
                    command.Parameters.AddWithValue("@additional_fee_sum", tww_Salesorder_History.additional_fee_sum);
                    command.Parameters.AddWithValue("@final_price_sum", tww_Salesorder_History.final_price_sum);
                    command.Parameters.AddWithValue("@processing_fee_sum", tww_Salesorder_History.processing_fee_sum);

                    command.Parameters.AddWithValue("@customer_recevible", tww_Salesorder_History.customer_recevible);

                    command.Parameters.AddWithValue("@edit_id", req.LoginCmdModel.tww_Store.store_id + req.LoginCmdModel.tww_Employee.name);
                    int id = 0;
                    id = (int)command.ExecuteScalar();
                    //Step2. 寫入明細
                    command.CommandText = "INSERT INTO tww_salesorder_history_details ( tww_salesorder_history_id, salesorder_id, barcode_id, clothes_type_id, material_id, handle_type_id, processing_type_id, " +
                                          "color, accessory, notes, normal_price, discount_amount, additional_fee, final_price, processing_fee, deliver_date ) " +
                                          "VALUES ( @tww_salesorder_history_id, @salesorder_id, @barcode_id, @clothes_type_id, @material_id, @handle_type_id, @processing_type_id, " +
                                          "@color, @accessory, @notes, @normal_price, @discount_amount, @additional_fee, @final_price, @processing_fee, @deliver_date )";

                    command.Parameters.AddWithValue("@tww_salesorder_history_id", id);

                    command.Parameters.Add("@salesorder_id", SqlDbType.NVarChar);
                    command.Parameters.Add("@barcode_id", SqlDbType.NVarChar);

                    command.Parameters.Add("@clothes_type_id", SqlDbType.NVarChar);
                    command.Parameters.Add("@material_id", SqlDbType.NVarChar);
                    command.Parameters.Add("@handle_type_id", SqlDbType.NVarChar);
                    command.Parameters.Add("@processing_type_id", SqlDbType.NVarChar);

                    command.Parameters.Add("@color", SqlDbType.NVarChar);
                    command.Parameters.Add("@accessory", SqlDbType.NVarChar);
                    command.Parameters.Add("@notes", SqlDbType.NVarChar);

                    command.Parameters.Add("@normal_price", SqlDbType.Int);
                    command.Parameters.Add("@discount_amount", SqlDbType.Int);
                    command.Parameters.Add("@additional_fee", SqlDbType.Int);
                    command.Parameters.Add("@final_price", SqlDbType.Int);
                    command.Parameters.Add("@processing_fee", SqlDbType.Int);

                    command.Parameters.Add("@deliver_date", SqlDbType.NVarChar);

                    foreach (var salesOrderItem in req.SalesOrderList)
                    {
                        command.Parameters["@salesorder_id"].Value = salesOrderItem.gdata.wano;
                        command.Parameters["@barcode_id"].Value = salesOrderItem.gdata.wano2;

                        command.Parameters["@clothes_type_id"].Value = salesOrderItem.Clothes.dno;
                        command.Parameters["@material_id"].Value = salesOrderItem.Material.wno;
                        command.Parameters["@handle_type_id"].Value = salesOrderItem.HandleType.typeno;
                        command.Parameters["@processing_type_id"].Value = string.IsNullOrEmpty(salesOrderItem.ProcessingType.addno) ? (object)DBNull.Value : salesOrderItem.ProcessingType.addno;
                        command.Parameters["@processing_type_id"].IsNullable = true;

                        command.Parameters["@color"].Value = salesOrderItem.gdata.color;

                        command.Parameters["@accessory"].Value = string.IsNullOrEmpty(salesOrderItem.gdata.fknd) ? (object)DBNull.Value : salesOrderItem.gdata.fknd;
                        command.Parameters["@accessory"].IsNullable = true;

                        command.Parameters["@notes"].Value = string.IsNullOrEmpty(salesOrderItem.gdata.note) ? (object)DBNull.Value : salesOrderItem.gdata.note;
                        command.Parameters["@notes"].IsNullable = true;

                        command.Parameters["@normal_price"].Value = salesOrderItem.tww_Salesorder_History_Details.normal_price;
                        command.Parameters["@discount_amount"].Value = salesOrderItem.tww_Salesorder_History_Details.discount_amount;
                        command.Parameters["@additional_fee"].Value = salesOrderItem.tww_Salesorder_History_Details.additional_fee;
                        command.Parameters["@final_price"].Value = salesOrderItem.tww_Salesorder_History_Details.final_price;
                        command.Parameters["@processing_fee"].Value = salesOrderItem.tww_Salesorder_History_Details.processing_fee;

                        //command.Parameters["@deliver_date"].Value = currentTime.AddDays(salesOrderItem.DaysNeededForDelivery).ToString("yyyyMMdd");
                        command.Parameters["@deliver_date"].Value = salesOrderItem.gdata.date2;

                        command.ExecuteNonQuery();
                    }
                    transaction.Commit();

                }

                catch (Exception ex)
                {
                    try
                    {
                        transaction.Rollback();
                        throw;
                    }
                    catch (Exception ex2)
                    {
                        throw;
                    }

                }
            }
        }


        #endregion

        #region 照片
        public void InsertPicture(tww_clothes_picture req)
        {
            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();
                command.CommandText = "INSERT INTO tww_clothes_picture (store_id, barcode_id, file_name) " +
                                      "VALUES (@store_id, @barcode_id, @file_name)";

                command.Parameters.AddWithValue("@store_id", req.store_id);
                command.Parameters.AddWithValue("@barcode_id", req.barcode_id);
                command.Parameters.AddWithValue("@file_name", req.file_name);

                command.ExecuteNonQuery();
            }
        }

        #endregion
        private static bool JsonCompare(object obj, object another)
        {
            if (ReferenceEquals(obj, another)) return true;
            if ((obj == null) || (another == null)) return false;
            if (obj.GetType() != another.GetType()) return false;

            var objJson = JsonConvert.SerializeObject(obj);
            var anotherJson = JsonConvert.SerializeObject(another);

            return objJson == anotherJson;
        }
    }
}