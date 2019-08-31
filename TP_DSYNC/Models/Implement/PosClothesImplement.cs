using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP_DSYNC.Models.DataDefine.SQLFAC2011;
using TP_DSYNC.Models.DataDefine.TwwPos;
using TP_DSYNC.Models.Enums;
using TP_DSYNC.Models.Help;
using TWW_API.ViewModels.Clothes;
using TWW_API.ViewModels.PosReport;
using TWW_API.ViewModels.ShopAll;
using TWW_API.ViewModels.ShopFrontSys;

namespace TP_DSYNC.Models.Implement
{
    public static class DataAccessExtensions
    {
        public static SqlParameter AddWithNullableValue(
            this SqlParameterCollection collection,
            string parameterName,
            object value)
        {
            if (value == null)
                return collection.AddWithValue(parameterName, DBNull.Value);
            else
                return collection.AddWithValue(parameterName, value);
        }
    }
    public class PosClothesImplement : BaseImplement
    {


        #region 讀工廠資料表的
        //工廠退件
        public IdentifyingClothesQueryRes QueryRemindReturnClothes(IdentifyingClothesQueryReq req)
        {
            IdentifyingClothesQueryRes res = new IdentifyingClothesQueryRes();

            using (SqlConnection connection = new SqlConnection(Config.Item("SQLFAC2011")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();

                command.CommandText = @"select a.onlyxfac003,substring(c.wano2, 3, 4) as 'barcode'
                                        ,c.orderno,d.kind2na,c.scolor,a.status,f.statusna,c.NOTE1,a.msg from ( SELECT * FROM [Returns_Clothing] where status = 1 and Bubble = 1 ) as a
                                         left join(select * from FAC003) as c on a.onlyxfac003 = c.onlyx left join(select * from EbjKind2) as d on c.kind2 = d.kind2no
                                         left join(select * from FAC001) as e on c.offno = e.offno left join(select * from Returns_Clothing_Status) as f on a.status = f.status
                                        where e.offno = @offno order by a.date1 desc";

                command.Parameters.AddWithValue("@offno", req.storeId);
                Log("SQL=" + command.CommandText + "\n@offno=" + req.storeId);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var aModel = new ReturnClothesQuery();
                        aModel.returns_Clothing.onlyxFAC003 = reader.GetInt32(0);
                        aModel.fAC003.wano2 = GetNullableStringField(reader, 1);
                        aModel.fAC003.ORDERNO = GetNullableStringField(reader, 2);
                        aModel.ebjKind2.kind2na = GetNullableStringField(reader, 3);
                        aModel.fAC003.scolor = GetNullableStringField(reader, 4);
                        aModel.returns_Clothing.status = reader.GetInt32(5);
                        aModel.returns_Clothing_Status.statusna = GetNullableStringField(reader, 6);
                        aModel.fAC003.NOTE1 = GetNullableStringField(reader, 7);
                        aModel.returns_Clothing.Msg = GetNullableStringField(reader, 8);

                        res.ReturnClothesList.Add(aModel);
                    }
                }
            }

            return res;
        }
        public void UpdateRemind(IdentifyingClothesQueryRes aIdentifyingClothesModel)
        {
            using (SqlConnection connection = new SqlConnection(Config.Item("SQLFAC2011")))
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
                    foreach (var ReturnClothesList in aIdentifyingClothesModel.ReturnClothesList)
                    {
                        command.Parameters.Clear();

                        command.CommandText = "Update Returns_Clothing Set Bubble = 0 Where onlyxFAC003 = @onlyxFAC003";


                        command.Parameters.AddWithValue("@onlyxFAC003", ReturnClothesList.returns_Clothing.onlyxFAC003);

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
        

        //20181107逾期未入庫提醒清單
        public IdentifyingClothesQueryRes QueryOverdueClothesAlert(IdentifyingClothesQueryReq aIdentifyingClothesModel)
        {
            IdentifyingClothesQueryRes res = new IdentifyingClothesQueryRes();
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("SQLFAC2011")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = @"select * from Overdue_Storage as a inner join Overdue_Storage_Status as b on a.status=b.status where a.offno=@offno and a.BubbleStore='1'
                                                            Update Overdue_Storage set BubbleStore='0' where offno=@offno;";

                    command.Parameters.AddWithValue("@offno", aIdentifyingClothesModel.storeId);
                    Log("SQL=" + command.CommandText);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var aModel = new ClothesOverdueStorageQuery();

                            aModel.overdue_Storage.offno = GetNullableStringField(reader, 0);

                            aModel.overdue_Storage.wano2 = GetNullableStringField(reader, 1);

                            aModel.overdue_Storage.wano = GetNullableStringField(reader, 2);
                            if (!Convert.IsDBNull(reader[3]))
                                aModel.overdue_Storage.workno = reader.GetInt32(3);
                            aModel.overdue_Storage.offna = GetNullableStringField(reader, 4);
                            aModel.overdue_Storage.scolor = GetNullableStringField(reader, 5);
                            aModel.overdue_Storage.dna = GetNullableStringField(reader, 6);
                            if (!Convert.IsDBNull(reader[7]))
                                aModel.overdue_Storage.status = reader.GetInt32(7);
                            aModel.overdue_Storage.MsgStore = GetNullableStringField(reader, 8);
                            aModel.overdue_Storage.date1 = GetNullableStringField(reader, 10);
                            aModel.overdue_Storage.date2 = GetNullableStringField(reader, 11);
                            if (!Convert.IsDBNull(reader[12]))
                                aModel.overdue_Storage.BubbleStore = reader.GetInt32(12);
                            aModel.overdue_Storage.file_date = reader.GetDateTime(14).ToString("yyyy-MM-dd");
                            aModel.overdue_Storage.onlyx = reader.GetInt32(15);
                            aModel.overdue_Storage_Status.statusna = GetNullableStringField(reader, 17);
                            res.OverdueStorageList.Add(aModel);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log("Err=" + ex.Message);

                //ignore
            }
            return res;
        }

        //逾期未入庫清單
        public IdentifyingClothesQueryRes QueryOverdueClothes(IdentifyingClothesQueryReq aIdentifyingClothesModel)
        {
            IdentifyingClothesQueryRes res = new IdentifyingClothesQueryRes();
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("SQLFAC2011")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = @"select * from Overdue_Storage as a inner join Overdue_Storage_Status as b on a.status=b.status where a.offno=@offno ";

                    command.Parameters.AddWithValue("@offno", aIdentifyingClothesModel.storeId);

                    if (aIdentifyingClothesModel.Wano2 != null && aIdentifyingClothesModel.Wano2 != "")
                    {
                        command.CommandText += " and a.wano2=@wano2 ";
                        command.Parameters.AddWithValue("@wano2", aIdentifyingClothesModel.Wano2);
                    }
                    if (aIdentifyingClothesModel.Wano != null && aIdentifyingClothesModel.Wano != "")
                    {
                        command.CommandText += " and a.wano=@wano ";
                        command.Parameters.AddWithValue("@wano", aIdentifyingClothesModel.Wano);
                    }
                    if (aIdentifyingClothesModel.Status != 0)
                    {
                        command.CommandText += " and a.status=@status ";
                        command.Parameters.AddWithValue("@status", aIdentifyingClothesModel.Status);
                    }
                    if (aIdentifyingClothesModel.Date1S != "" && aIdentifyingClothesModel.Date1S != null)
                    {
                        command.CommandText += " and a.date1>=@Date1S ";
                        command.Parameters.AddWithValue("@Date1S", aIdentifyingClothesModel.Date1S);
                    }
                    if (aIdentifyingClothesModel.Date1E != "" && aIdentifyingClothesModel.Date1E != null)
                    {
                        command.CommandText += " and a.date1<=@Date1E ";
                        command.Parameters.AddWithValue("@Date1E", aIdentifyingClothesModel.Date1E);
                    }
                    if (aIdentifyingClothesModel.Date2S != "" && aIdentifyingClothesModel.Date2S != null)
                    {
                        command.CommandText += " and a.date2>=@Date2S ";
                        command.Parameters.AddWithValue("@Date2S", aIdentifyingClothesModel.Date2S);
                    }
                    if (aIdentifyingClothesModel.Date2E != "" && aIdentifyingClothesModel.Date2E != null)
                    {
                        command.CommandText += " and a.date2<=@Date2E ";
                        command.Parameters.AddWithValue("@Date2E", aIdentifyingClothesModel.Date2E);
                    }
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var aModel = new ClothesOverdueStorageQuery();

                            aModel.overdue_Storage.offno = GetNullableStringField(reader, 0);

                            aModel.overdue_Storage.wano2 = GetNullableStringField(reader, 1);

                            aModel.overdue_Storage.wano = GetNullableStringField(reader, 2);
                            if (!Convert.IsDBNull(reader[3]))
                                aModel.overdue_Storage.workno = reader.GetInt32(3);
                            aModel.overdue_Storage.offna = GetNullableStringField(reader, 4);
                            aModel.overdue_Storage.scolor = GetNullableStringField(reader, 5);
                            aModel.overdue_Storage.dna = GetNullableStringField(reader, 6);
                            if (!Convert.IsDBNull(reader[7]))
                                aModel.overdue_Storage.status = reader.GetInt32(7);
                            aModel.overdue_Storage.MsgStore = GetNullableStringField(reader, 8);
                            aModel.overdue_Storage.date1 = GetNullableStringField(reader, 10);
                            aModel.overdue_Storage.date2 = GetNullableStringField(reader, 11);
                            if (!Convert.IsDBNull(reader[12]))
                                aModel.overdue_Storage.BubbleStore = reader.GetInt32(12);
                            aModel.overdue_Storage.file_date = reader.GetDateTime(14).ToString("yyyy-MM-dd");
                            aModel.overdue_Storage.onlyx = reader.GetInt32(15);
                            aModel.overdue_Storage_Status.statusna = GetNullableStringField(reader, 17);
                            res.OverdueStorageList.Add(aModel);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log("Err=" + ex.Message);
                //ignore
            }
            return res;
        }

        //逾期入庫
        public int UpdateOrverdueStorage(ClothesOverdueStorageQuery OModel)
        {
            DateTime now = DateTime.Now;


            using (SqlConnection connection = new SqlConnection(Config.Item("SQLFAC2011")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();

                command.CommandText = "Update Overdue_Storage Set status = '8',MsgStore=@MsgStore,date2=@date2 Where onlyx = @onlyx";

                command.Parameters.AddWithNullableValue("@onlyx", OModel.overdue_Storage.onlyx);
                command.Parameters.AddWithNullableValue("@MsgStore", OModel.overdue_Storage.MsgStore);
                command.Parameters.AddWithNullableValue("@date2", DateTime.Today.ToString("yyyyMMdd"));


                return command.ExecuteNonQuery();
            }
        }

        //工廠退件回應
        public void UpdateReturnClothesModel(Returns_Clothing req)
        {
            IdentifyingClothesQueryRes res = new IdentifyingClothesQueryRes();
            DateTime now = DateTime.Now;
            using (SqlConnection connection = new SqlConnection(Config.Item("SQLFAC2011")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "Update Returns_Clothing Set status = @status, date1 = @date1, Bubble = 2 Where onlyxFAC003 = @onlyxFAC003";

                    if (req.status == 0)
                    {
                        command.Parameters.AddWithValue("@status", 2);  //要洗
                    }
                    else if (req.status == 1)
                    {
                        command.Parameters.AddWithValue("@status", 3);  //不洗
                    }
                    command.Parameters.AddWithValue("@date1", now);
                    command.Parameters.AddWithNullableValue("@onlyxFAC003", req.onlyxFAC003);

                    Log("SQL=" + command.CommandText);
                    command.ExecuteNonQuery();
                }
         
        }

        //------------------------------------------
        public void UpdateReturnClothesModelFAC(Returns_Clothing req)
        {
            DateTime now = DateTime.Now;
            using (SqlConnection connection = new SqlConnection(Config.Item("SQLFAC2011")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();

                command.CommandText = "Update FAC003 Set NOWASH = @NOWASH Where onlyx = @onlyx";

                if (req.status == 0)
                {
                    command.Parameters.AddWithValue("@NOWASH", 0);  //要洗
                }
                else if (req.status == 1)
                {
                    command.Parameters.AddWithValue("@NOWASH", 1);  //不洗
                }
                command.Parameters.AddWithNullableValue("@onlyx", req.onlyxFAC003);
                Log("SQL=" + command.CommandText);

                command.ExecuteNonQuery();
            }
        }
        public void InsertReturnClothesLog(Returns_Clothing req)
        {
            DateTime now = DateTime.Now;

            using (SqlConnection connection = new SqlConnection(Config.Item("SQLFAC2011")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();
                command.CommandText = "INSERT INTO Returns_Clothing_Log (onlyxFAC003,status,date1) Values (@onlyxFAC003,@status,@date1)";

                if (req.status == 0)
                {
                    command.Parameters.AddWithValue("@status", 2);  //要洗
                }
                else if (req.status == 1)
                {
                    command.Parameters.AddWithValue("@status", 3);  //不洗
                }
                command.Parameters.AddWithValue("@date1", now);
                command.Parameters.AddWithNullableValue("@onlyxFAC003", req.onlyxFAC003);
                Log("SQL=" + command.CommandText);

                command.ExecuteNonQuery();
            }
        }
        public IdentifyingClothesQueryRes QueryIdentifyingClothes(IdentifyingClothesQueryRes aModel)
        {
            if (aModel.QueryType == "1")
            {
                //default
                aModel = QueryIdentifyingClothesModel(aModel);

            }
            else if (aModel.QueryType == "2")
            {
                aModel = QueryIdentifyingClothesModelByName(aModel);
            }
            int x = 0;
            foreach (var clothesToBeIdentified in aModel.ClothesToBeIdentifiedList)
            {
                aModel.ClothesToBeIdentifiedList[x].PictureList = QueryIdentifyingClothesPictures(clothesToBeIdentified);
                x++;
            }

            aModel = QueryShopIdentifyingClothesModel(aModel);
            int k = 0;
            foreach (var clothesToBeIdentified in aModel.ShopIdentifyingList)
            {
                aModel.ShopIdentifyingList[k].PictureList = QueryIdentifyingClothesPictures(clothesToBeIdentified);
                k++;
            }

            //0510 工廠退件衣物
            aModel = QueryReturnClothesModel(aModel);
            int i = 0;
            foreach (var ReturnClothesIdentified in aModel.ReturnClothesList)
            {
                QueryReturnClothesPictures(ReturnClothesIdentified);
                i++;
            }
            return aModel;
        }
        public IdentifyingClothesQueryRes QueryIdentifyingClothesForBackEnd(IdentifyingClothesQueryRes aModel)
        {
            if (aModel.QueryType == "1")
            {
                //default
                aModel = QueryIdentifyingClothesModel(aModel);

            }
            else if (aModel.QueryType == "2")
            {
                aModel = QueryIdentifyingClothesModelByName(aModel);
            }
            //int x = 0;
            //foreach (var clothesToBeIdentified in aModel.ClothesToBeIdentifiedList)
            //{
            //    aModel.ClothesToBeIdentifiedList[x].PictureList = QueryIdentifyingClothesPictures(clothesToBeIdentified);
            //    x++;
            //}

            //aModel = QueryShopIdentifyingClothesModel(aModel);
            //int k = 0;
            //foreach (var clothesToBeIdentified in aModel.ShopIdentifyingList)
            //{
            //    aModel.ShopIdentifyingList[k].PictureList = QueryIdentifyingClothesPictures(clothesToBeIdentified);
            //    k++;
            //}

            ////0510 工廠退件衣物
            //aModel = QueryReturnClothesModel(aModel);
            //int i = 0;
            //foreach (var ReturnClothesIdentified in aModel.ReturnClothesList)
            //{
            //    aModel.ReturnClothesList[i] = QueryReturnClothesPictures(ReturnClothesIdentified);
            //    i++;
            //}
            return aModel;
        }

        public IdentifyingClothesPicsQueryRes QueryIdentifyingClothesPicsForBackEnd(IdentifyingClothesPicsQueryReq req)
        {
            IdentifyingClothesPicsQueryRes res = new IdentifyingClothesPicsQueryRes();
            using (SqlConnection connection = new SqlConnection(Config.Item("SQLFAC2011")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();

                command.CommandText = "SELECT ID " +
                                      "FROM FAC_Sent_To_PIC WHERE num1=@num1";

                command.Parameters.AddWithValue("@num1", req.num1);
                Log("SQL=" + command.CommandText);


                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (!Convert.IsDBNull(reader[0]))
                        {
                            FAC_Sent_To_PIC pic = new FAC_Sent_To_PIC();
                            pic.ID = reader.GetInt32(0);

                            res.PicList.Add(pic);
                        }
                    }
                }
            }

            return res;
        }

        private IdentifyingClothesQueryRes QueryIdentifyingClothesModel(IdentifyingClothesQueryRes aIdentifyingClothesModel)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("SQLFAC2011")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "SELECT num1, dna, Brand, color, FAC_Sent_To.status, FAC_Sent_To_Status.statusna, FAC_Sent_To.date1 " +
                                          "FROM FAC_Sent_To INNER JOIN FAC_Sent_To_Status ON FAC_Sent_To.status = FAC_Sent_To_Status.status " +
                                          "Where FAC_Sent_To.status != '5' " +
                                          "ORDER BY num1 DESC";
                    Log("SQL=" + command.CommandText);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var aModel = new ClothesToBeIdentifiedViewModel();

                            aModel.fAC_Sent_To.num1 = GetNullableStringField(reader, 0);

                            aModel.fAC_Sent_To.dna = GetNullableStringField(reader, 1);

                            aModel.fAC_Sent_To.Brand = GetNullableStringField(reader, 2);

                            aModel.fAC_Sent_To.color = GetNullableStringField(reader, 3);

                            if (!Convert.IsDBNull(reader[4]))
                                aModel.fAC_Sent_To.status = reader.GetInt32(4);

                            aModel.fAC_Sent_To_Status.statusna = GetNullableStringField(reader, 5);
                            aModel.fAC_Sent_To.date1 = reader.GetDateTime(6).ToString("yyyy-MM-dd");

                            aIdentifyingClothesModel.ClothesToBeIdentifiedList.Add(aModel);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log("Err=" + ex.Message);
                //ignore
            }
            return aIdentifyingClothesModel;
        }
        private IdentifyingClothesQueryRes QueryIdentifyingClothesModelByName(IdentifyingClothesQueryRes req)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("SQLFAC2011")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "SELECT num1, dna, Brand, color, FAC_Sent_To.status, FAC_Sent_To_Status.statusna, FAC_Sent_To.date1 " +
                                          "FROM FAC_Sent_To INNER JOIN FAC_Sent_To_Status ON FAC_Sent_To.status = FAC_Sent_To_Status.status " +
                                          "Where FAC_Sent_To.status != '5' and dna like '%' + @dna + '%'" +
                                          "ORDER BY num1 DESC";

                    command.Parameters.AddWithNullableValue("@dna", req.Keyword);
                    Log("SQL=" + command.CommandText);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var aModel = new ClothesToBeIdentifiedViewModel();

                            aModel.fAC_Sent_To.num1 = GetNullableStringField(reader, 0);

                            aModel.fAC_Sent_To.dna = GetNullableStringField(reader, 1);

                            aModel.fAC_Sent_To.Brand = GetNullableStringField(reader, 2);

                            aModel.fAC_Sent_To.color = GetNullableStringField(reader, 3);

                            if (!Convert.IsDBNull(reader[4]))
                                aModel.fAC_Sent_To.status = reader.GetInt32(4);

                            aModel.fAC_Sent_To_Status.statusna = GetNullableStringField(reader, 5);
                            aModel.fAC_Sent_To.date1 = reader.GetDateTime(6).ToString("yyyy-MM-dd");

                            req.ClothesToBeIdentifiedList.Add(aModel);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log("Err=" + ex.Message);

                //ignore
            }
            return req;
        }
        private List<FAC_Sent_To_PIC> QueryIdentifyingClothesPictures(ClothesToBeIdentifiedViewModel aClothesToBeIdentifiedModel)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("SQLFAC2011")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "SELECT ID " +
                                          "FROM FAC_Sent_To_PIC WHERE num1=@num1";

                    command.Parameters.AddWithValue("@num1", aClothesToBeIdentifiedModel.fAC_Sent_To.num1);
                    Log("SQL=" + command.CommandText);


                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (!Convert.IsDBNull(reader[0]))
                            {
                                FAC_Sent_To_PIC pic = new FAC_Sent_To_PIC();
                                pic.ID = reader.GetInt32(0);

                                aClothesToBeIdentifiedModel.PictureList.Add(pic);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log("Err=" + ex.Message);

                //ignore
            }
            return aClothesToBeIdentifiedModel.PictureList;
        }

        public void QueryReturnClothesPictures(ReturnClothesQuery aReturnClothesModel)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("SQLFAC2011")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "SELECT ID " +
                                          "FROM Returns_Clothing_PIC WHERE onlyxFAC003 = @onlyxFAC003";

                    command.Parameters.AddWithValue("@onlyxFAC003", aReturnClothesModel.returns_Clothing.onlyxFAC003);

                    Log("SQL=" + command.CommandText);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (!Convert.IsDBNull(reader[0]))
                            {
                                int id = reader.GetInt32(0);
                                aReturnClothesModel.PictureList.Add(id);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log("Err=" + ex.Message);

                //ignore
            }
          
        }
        private IdentifyingClothesQueryRes QueryShopIdentifyingClothesModel(IdentifyingClothesQueryRes res)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("SQLFAC2011")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "SELECT num1, dna, Brand, color, FAC_Sent_To.status, FAC_Sent_To_Status.statusna, FAC_Sent_To.date1 " +
                                          "FROM FAC_Sent_To INNER JOIN FAC_Sent_To_Status ON FAC_Sent_To.status = FAC_Sent_To_Status.status " +
                                          "WHERE offno=@offno ORDER BY num1";

                    command.Parameters.AddWithValue("@offno", res.LoginCmdModel.tww_Store.store_id);
                    Log("SQL=" + command.CommandText);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var aModel = new ClothesToBeIdentifiedViewModel();

                            aModel.fAC_Sent_To.num1 = GetNullableStringField(reader, 0);

                            aModel.fAC_Sent_To.dna = GetNullableStringField(reader, 1);

                            aModel.fAC_Sent_To.Brand = GetNullableStringField(reader, 2);

                            aModel.fAC_Sent_To.color = GetNullableStringField(reader, 3);

                            if (!Convert.IsDBNull(reader[4]))
                                aModel.fAC_Sent_To.status = reader.GetInt32(4);

                            aModel.fAC_Sent_To_Status.statusna = GetNullableStringField(reader, 5);
                            aModel.fAC_Sent_To.date1 = reader.GetDateTime(6).ToString("yyyy-MM-dd");

                            res.ShopIdentifyingList.Add(aModel);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log("Err=" + ex.Message);

                //ignore
            }
            return res;
        }
        public IdentifyingClothesQueryRes QueryReturnClothesModel(IdentifyingClothesQueryRes aIdentifyingClothesModel)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("SQLFAC2011")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = @"select a.onlyxfac003,substring(c.wano2, 3, 4) as 'barcode'
                                        ,c.orderno,d.kind2na,c.scolor,a.status,f.statusna,c.NOTE1,a.msg
                                         from ( SELECT * FROM [Returns_Clothing] where status = 1 ) as a
                                         left join(select * from FAC003) as c on a.onlyxfac003 = c.onlyx
                                         left join(select * from EbjKind2) as d on c.kind2 = d.kind2no
                                         left join(select * from FAC001) as e on c.offno = e.offno 
                                         left join(select * from Returns_Clothing_Status) as f on a.status = f.status
                                        where e.offno = @offno order by a.date1 desc";

                    command.Parameters.AddWithValue("@offno", aIdentifyingClothesModel.LoginCmdModel.tww_Store.store_id);
                    Log("SQL=" + command.CommandText);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var aModel = new ReturnClothesQuery();
                            aModel.returns_Clothing.onlyxFAC003 = reader.GetInt32(0);
                            aModel.fAC003.wano2 = GetNullableStringField(reader, 1);
                            aModel.fAC003.ORDERNO = GetNullableStringField(reader, 2);
                            aModel.ebjKind2.kind2na = GetNullableStringField(reader, 3);
                            aModel.fAC003.scolor = GetNullableStringField(reader, 4);
                            aModel.returns_Clothing.status = reader.GetInt32(5);
                            aModel.returns_Clothing_Status.statusna = GetNullableStringField(reader, 6);
                            aModel.fAC003.NOTE1 = GetNullableStringField(reader, 7);
                            aModel.returns_Clothing.Msg = GetNullableStringField(reader, 8);

                            aIdentifyingClothesModel.ReturnClothesList.Add(aModel);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log("Err=" + ex.Message);

                //ignore
            }
            return aIdentifyingClothesModel;
        }


        public WarehouseInConfirmRes ConfirmIdentifyingClothes(WarehouseInConfirmReq req, WarehouseInConfirmRes res)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("SQLFAC2011")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "UPDATE FAC_Sent_To set status=@status, offno=@offno, wano2=@wano2 WHERE num1=@num1";

                    command.Parameters.AddWithNullableValue("@num1", req.fAC_Sent_To.num1);

                    command.Parameters.AddWithValue("@status", 5);
                    command.Parameters.AddWithNullableValue("@offno", req.LoginCmdModel.tww_Store.store_id);
                    command.Parameters.AddWithNullableValue("@wano2", req.fAC_Sent_To.wano2);
                    Log("SQL=" + command.CommandText);
                    command.ExecuteNonQuery();
                    res.Result.State = ResultEnum.SUCCESS;
                }
            }
            catch (Exception ex)
            {
                res.Result.State = ResultEnum.FAIL;
                Log("Err=" + ex.Message);

                // ignored
            }

            InsertIdentifyingClothesLog(req, 5);
            return res;
        }

        //回工廠
        public void ConfirmReturnIdentifyingClothes(WarehouseInConfirmReq req, WarehouseInConfirmRes res)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("SQLFAC2011")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "UPDATE FAC_Sent_To set status=@status, offno=@offno, wano2=@wano2 WHERE num1=@num1";

                    command.Parameters.AddWithNullableValue("@num1", req.fAC_Sent_To.num1);

                    command.Parameters.AddWithValue("@status", 6);
                    command.Parameters.AddWithNullableValue("@offno", req.LoginCmdModel.tww_Store.store_id);
                    command.Parameters.AddWithNullableValue("@wano2", req.fAC_Sent_To.wano2);

                    command.ExecuteNonQuery();
                    res.Result.State = ResultEnum.SUCCESS;
                }
            }
            catch (Exception ex)
            {
                res.Result.State = ResultEnum.FAIL;
                Log("Err=" + ex.Message);
                // ignored
            }

            InsertIdentifyingClothesLog(req, 6);
        }

        //店家指認((目前沒用到
        public void UpdateIdentifyingClothes(WarehouseInConfirmReq req, WarehouseInConfirmRes res)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("SQLFAC2011")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "UPDATE FAC_Sent_To set status=@status, offno=@offno WHERE num1=@num1";

                    command.Parameters.AddWithNullableValue("@num1", req.fAC_Sent_To.num1);

                    command.Parameters.AddWithValue("@status", 2);
                    command.Parameters.AddWithNullableValue("@offno", req.LoginCmdModel.tww_Store.store_id);

                    command.ExecuteNonQuery();
                    res.Result.State = ResultEnum.SUCCESS;
                }
            }
            catch (Exception ex)
            {
                res.Result.State = ResultEnum.FAIL;
                Log("Err=" + ex.Message);
                // ignored
            }

            InsertIdentifyingClothesLog(req, 2);
        }

        //店家確認收到衣服
        public void ConfirmReceivedIdentifyingClothes(WarehouseInConfirmReq req, WarehouseInConfirmRes res)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("SQLFAC2011")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "UPDATE FAC_Sent_To set status=@status, offno=@offno, wano2=@wano2 WHERE num1=@num1";

                    command.Parameters.AddWithNullableValue("@num1", req.fAC_Sent_To.num1);

                    command.Parameters.AddWithValue("@status", 4);
                    command.Parameters.AddWithNullableValue("@offno", req.LoginCmdModel.tww_Store.store_id);
                    command.Parameters.AddWithNullableValue("@wano2", req.fAC_Sent_To.wano2);

                    command.ExecuteNonQuery();
                    res.Result.State = ResultEnum.SUCCESS;
                }
            }
            catch (Exception ex)
            {
                res.Result.State = ResultEnum.FAIL;
                Log("Err=" + ex.Message);
                // ignored
            }

            InsertIdentifyingClothesLog(req, 4);
        }
        private void InsertIdentifyingClothesLog(WarehouseInConfirmReq req, int status)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("SQLFAC2011")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "INSERT INTO FAC_Sent_To_Log (num1, status, offno, date1) VALUES(@num1, @status, @offno, CURRENT_TIMESTAMP)";

                    command.Parameters.AddWithNullableValue("@num1", req.fAC_Sent_To.num1);
                    command.Parameters.AddWithValue("@status", status);
                    command.Parameters.AddWithNullableValue("@offno", req.LoginCmdModel.tww_Store.store_id);
                    Log("SQL=" + command.CommandText);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Log("Err=" + ex.Message);

                // ignored
            }
        }


        #endregion

        #region 讀POS資料表TwwPOS

        //工廠預計出貨衣物
        public string QueryFactoryExpectedToShipReport(SPQueryReq req)
        {
            //將西元年變成民國年
            var New_year = int.Parse(req.Keyword.Substring(0, 4)) - 1911;
            string NewQueryDay = New_year.ToString() + req.Keyword.Substring(4, 4);
            try
            {

                DataTable table = new DataTable();
                using (var con = new SqlConnection(Config.Item("TwwPos")))
                using (var cmd = new SqlCommand("getFactoryExpectedToShipReport", con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@offno", req.LoginCmdModel.tww_Store.store_id);
                    cmd.Parameters.AddWithValue("@QueryDay", NewQueryDay);
                    Log("SQL=" + "getFactoryExpectedToShipReport");

                    da.Fill(table);
                }
                return JsonConvert.SerializeObject(table);
            }
            catch (Exception ex)
            {
                Log("Err=" + ex.Message);
            }
            return "";
        }

        //送洗衣物於工廠狀態
        public string QueryClothesInFactoryStatusReport(SPQueryReq req)
        {
            try
            {
                DataTable table = new DataTable();
                using (var con = new SqlConnection(Config.Item("TwwPos")))
                using (var cmd = new SqlCommand("getClothesInFactoryStatusReport", con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BranchId", req.LoginCmdModel.tww_Store.store_id);

                    if (String.IsNullOrEmpty(req.Keyword))
                    {
                        cmd.Parameters.AddWithValue("@Barcode", DBNull.Value);
                    }
                    else
                    {
                        if (req.Keyword.Length == 4)
                        {
                            cmd.Parameters.AddWithValue("@Barcode", req.Keyword);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Barcode", DBNull.Value);
                        }
                    }
                    Log("SQL=" + "getClothesInFactoryStatusReport");

                    da.Fill(table);
                }
                return JsonConvert.SerializeObject(table);
            }
            catch (Exception ex)
            {
                Log("Err=" + ex.Message);
            }
            return "";
        }

        //0328 加入公告查詢
        public void QueryAnnouncementPost(IdentifyingClothesQueryRes aIdentifyingClothesModel)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();
                    command.CommandText = "Select postno, postdate, readpost, mainnote, detailnote FROM post_new Where storeid = @storeid Order by postno DESC";
                    command.Parameters.AddWithValue("@storeid", aIdentifyingClothesModel.LoginCmdModel.tww_Store.store_id);
                    SqlDataReader reader = command.ExecuteReader();
                    Log("SQL=" + command.CommandText);

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var aModel = new post_new
                            {
                                postno = GetNullableStringField(reader, 0),
                                postdate = reader.GetDateTime(1).ToString("yyyy-MM-dd"),
                                readpost = GetNullableStringField(reader, 2),
                                mainnote = GetNullableStringField(reader, 3),
                                detailnote = GetNullableStringField(reader, 4)
                            };
                            aIdentifyingClothesModel.AnnouncementPostList.Add(aModel);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log("Err=" + ex.Message);
                // ignored
            }
        }
        //0328 更新公告狀態
        public void UpdateAnnouncementPost(IdentifyingClothesQueryRes aModel)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();
                    command.CommandText = "Update post_new Set readpost = 't' Where postno = @postno and storeid = @storeid";
                    command.Parameters.AddWithValue("@postno", aModel.AnnouncementPostList[0].postno);
                    command.Parameters.AddWithValue("@storeid", aModel.LoginCmdModel.tww_Store.store_id);
                    Log("SQL=" + command.CommandText);

                    command.ExecuteNonQuery();
                }
                aModel.Result.State = ResultEnum.SUCCESS;
            }
            catch (Exception ex)
            {
                Log("Err=" + ex.Message);
                aModel.Result.State = ResultEnum.FAIL;
            }
        }

        //查詢掉號衣服
        public void QueryLostNumberClothes(WarehouseInConfirmReq aModel, WarehouseInConfirmRes res)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();
                    command.CommandText = @"Select wano FROM gdata Where offno = @offno  and indoor='f' and getw='f' and wano2 = @wano2 ";
                    command.Parameters.AddWithValue("@offno", aModel.LoginCmdModel.tww_Store.store_id);
                    command.Parameters.AddWithValue("@wano2", aModel.tww_Outgoing_Shippment.barcode_id);
                    Log("SQLT=" + command.CommandText);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            aModel.gdata.wano = GetNullableStringField(reader, 0);
                        }
                    }
                }
                res.Result.State = ResultEnum.SUCCESS;

            }
            catch (Exception ex)
            {
                res.Result.State = ResultEnum.FAIL;

                Log("Err=" + ex.Message);

            }
        }
        //新增入庫資料
        public void InsertWarehouseInClothes(WarehouseInConfirmReq aModel, WarehouseInConfirmRes res)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();
                    command.CommandText = @"INSERT INTO tww_outgoing_shippment ( store_id, barcode_id, outgoing_shippment_id, is_retrieved, 
                                            is_nonwashing_return, is_nonwashing_return_processed, pre_barcode_id, onlyxfac003, orderno, prndate) 
                                            VALUES ( @store_id, @barcode_id, @outgoing_shippment_id, @is_retrieved, 
                                            @is_nonwashing_return, @is_nonwashing_return_processed, @pre_barcode_id, @onlyxfac003, @orderno, @prndate) ";
                    Log("SQL=" + command.CommandText);

                    command.Parameters.AddWithValue("@store_id", aModel.LoginCmdModel.tww_Store.store_id);
                    command.Parameters.AddWithValue("@barcode_id", aModel.tww_Outgoing_Shippment.barcode_id);
                    command.Parameters.AddWithValue("@outgoing_shippment_id", aModel.tww_Outgoing_Shippment.outgoing_shippment_id);
                    command.Parameters.AddWithValue("@is_retrieved", aModel.tww_Outgoing_Shippment.is_retrieved);
                    command.Parameters.AddWithValue("@is_nonwashing_return", aModel.tww_Outgoing_Shippment.is_nonwashing_return);
                    command.Parameters.AddWithValue("@is_nonwashing_return_processed", aModel.tww_Outgoing_Shippment.is_nonwashing_return_processed);
                    command.Parameters.AddWithValue("@pre_barcode_id", aModel.LoginCmdModel.tww_Store.store_id);
                    command.Parameters.AddWithValue("@onlyxfac003", aModel.tww_Outgoing_Shippment.onlyxfac003);
                    command.Parameters.AddWithValue("@orderno", aModel.gdata.wano);
                    command.Parameters.AddWithValue("@prndate", DBNull.Value);    //aModel.PrnDate

                    command.ExecuteNonQuery();
                    res.Result.State = ResultEnum.SUCCESS;
                }
            }
            catch (Exception ex)
            {
                res.Result.State = ResultEnum.FAIL;

                Log("Err=" + ex.Message);
            }
        }


        #endregion
        #region 目前好像沒用到
        public OperatingReportQueryRes QueryMonthlyOperatingReport(OperatingReportQueryReq aMonthlyOperatingReporModel)
        {
            OperatingReportQueryRes res = new OperatingReportQueryRes();
            try
            {
                CultureInfo enUS = new CultureInfo("en-US");
                DateTime dateStartMonth;
                DateTime dateEndtMonth;

                DateTime.TryParseExact(aMonthlyOperatingReporModel.StartDate, "yyyyMM", enUS, DateTimeStyles.None, out dateStartMonth);
                DateTime.TryParseExact(aMonthlyOperatingReporModel.EndDate, "yyyyMM", enUS, DateTimeStyles.None, out dateEndtMonth);

                for (DateTime x = dateStartMonth; x < dateEndtMonth; x = x.AddMonths(1))
                {
                    OperatingReportViewModel aModel = new OperatingReportViewModel();
                    aModel = QueryOldMonthyOperatingReport(aMonthlyOperatingReporModel.LoginCmdModel.tww_Store.store_id, x.ToString("yyyyMMdd"), x.AddMonths(1).ToString("yyyyMMdd"));
                    aModel.Date = x.ToString("yyyyMM");
                    res.OperatingReportList.Add(aModel);
                }
                res.Result.State = ResultEnum.SUCCESS;
            }
            catch (Exception ex)
            {
                Log("Err=" + ex.Message);
                res.Result.State = ResultEnum.FAIL;
                //return false;
            }
            return res;
        }

        private OperatingReportViewModel QueryOldMonthyOperatingReport(string storeId, string startDate, string endDate)
        {
            OperatingReportViewModel aModel = new OperatingReportViewModel();
            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();

                command.CommandText = "SELECT sum(money4), sum(money5), sum(money4 + money5), sum(money6), sum(wct)  " +
                                      "from kdata where date1 > @startDate and date1 < @endDate ";

                command.Parameters.AddWithValue("@store_id", storeId);
                command.Parameters.AddWithValue("@startDate", startDate);
                command.Parameters.AddWithValue("@endDate", endDate);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (!Convert.IsDBNull(reader[0]))
                            aModel.FinalPrices = (int)reader.GetDouble(0);

                        if (!Convert.IsDBNull(reader[1]))
                            aModel.ProcessingFee = (int)reader.GetDouble(1);

                        if (!Convert.IsDBNull(reader[2]))
                            aModel.TotalPrice = (int)reader.GetDouble(2);

                        if (!Convert.IsDBNull(reader[3]))
                            aModel.TotalCash = (int)reader.GetDouble(3);

                        if (!Convert.IsDBNull(reader[4]))
                            aModel.TotalRecvNumber = (int)reader.GetDouble(4);
                    }
                }
            }
            return aModel;
        }

        public OperatingReportQueryRes QueryMonthDailyOperatingReport(OperatingReportQueryReq aMonthDailyOperatingReport)
        {
            OperatingReportQueryRes res = new OperatingReportQueryRes();
            try
            {

                CultureInfo enUS = new CultureInfo("en-US");
                DateTime dateStartMonth;

                DateTime.TryParseExact(aMonthDailyOperatingReport.StartDate, "yyyyMM", enUS, DateTimeStyles.None, out dateStartMonth);

                for (DateTime x = dateStartMonth; x < dateStartMonth.AddMonths(1); x = x.AddDays(1))
                {
                    OperatingReportViewModel aModel = new OperatingReportViewModel();
                    aModel = QueryOldMonthDailyOperatingReport(aModel, aMonthDailyOperatingReport.LoginCmdModel.tww_Store.store_id, x.ToString("yyyyMMdd"));
                    aModel.Date = x.ToString("MM/dd");
                    res.OperatingReportList.Add(aModel);
                }
            }
            catch (Exception ex)
            {
                Log("Err=" + ex.Message);
                res.Result.State = ResultEnum.FAIL;
                //return false;
            }
            return res;
        }

        private OperatingReportViewModel QueryOldMonthDailyOperatingReport(OperatingReportViewModel aModel, string storeId, string startDate)
        {

            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();

                command.CommandText = "SELECT sum(money4), sum(money5), sum(money4 + money5), sum(money6), sum(wct) " +
                                      "from kdata  GROUP BY date1 HAVING date1 = @startDate";

                command.Parameters.AddWithValue("@store_id", storeId);
                command.Parameters.AddWithValue("@startDate", startDate);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (!Convert.IsDBNull(reader[0]))
                            aModel.FinalPrices = (int)reader.GetDouble(0);

                        if (!Convert.IsDBNull(reader[1]))
                            aModel.ProcessingFee = (int)reader.GetDouble(1);

                        if (!Convert.IsDBNull(reader[2]))
                            aModel.TotalPrice = (int)reader.GetDouble(2);

                        if (!Convert.IsDBNull(reader[3]))
                            aModel.TotalCash = (int)reader.GetDouble(3);

                        if (!Convert.IsDBNull(reader[4]))
                            aModel.TotalRecvNumber = (int)reader.GetDouble(4);
                    }
                }
            }
            return aModel;

        }
        public OperatingReportQueryRes QueryOnedayOperatingReport(OperatingReportQueryReq aDailyOperatingReport)
        {
            OperatingReportQueryRes res = new OperatingReportQueryRes();

            CultureInfo enUS = new CultureInfo("en-US");
            DateTime dateStartMonth;
            res.LoginCmdModel = aDailyOperatingReport.LoginCmdModel;
            if (DateTime.TryParseExact(aDailyOperatingReport.StartDate, "yyyyMMdd", enUS, DateTimeStyles.None, out dateStartMonth))
            {
                TwwPosViewModel aTwwPosModel = new TwwPosViewModel();

                aTwwPosModel = GetTwwPosModel(res.LoginCmdModel.tww_Store.store_id);

                res.DailySalesOrderList = QueryDailySalesOrder(aDailyOperatingReport.StartDate, aDailyOperatingReport.LoginCmdModel.tww_Store.store_id);
                foreach (var salesOrderItem in res.DailySalesOrderList)
                {
                    PrepareModelFromStringToJsonObjects(salesOrderItem, aTwwPosModel);
                }

            }
            return res;
        }

        public List<ClothesSaleOrderItem> QueryDailySalesOrder(string oneDay, string storeId)
        {
            List<ClothesSaleOrderItem> aModelList = new List<ClothesSaleOrderItem>();
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "select wano, wano2, dno, wno, typeno, addno, color, fknd, " +
                                          "date1, date2, insiteno, money0, money2, money3, money4, money5, " +
                                          "note, caseno, manno from gdata where offno=@offno and date1=@date1";

                    command.Parameters.AddWithValue("@offno", storeId);
                    command.Parameters.AddWithValue("@date1", oneDay);

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

                            anItemModel.gdata.manno = GetNullableStringField(reader, 18);

                            aModelList.Add(anItemModel);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log("Err=" + ex.Message);
                // ignored
            }
            return aModelList;
        }

        public OperatingReportQueryRes QueryOnedayCashOperatingReport(OperatingReportQueryReq aDailyCashOperatingReport)
        {
            OperatingReportQueryRes res = new OperatingReportQueryRes();
            CultureInfo enUS = new CultureInfo("en-US");
            DateTime oneDay;

            if (DateTime.TryParseExact(aDailyCashOperatingReport.StartDate, "yyyyMMdd", enUS, DateTimeStyles.None, out oneDay))
            {
                QueryDailyCashing(aDailyCashOperatingReport.LoginCmdModel.tww_Store.store_id, oneDay, res.DailyCashingList);
            }
            return res;
        }

        private void QueryDailyCashing(string storeId, DateTime oneDay, List<NewHistoryItemViewModel> aModelList)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "select id, event_time, event_type, receiving_number, retriving_number, revising_number, cashing_in, " +
                                          "normal_price_sum, discount_amount_sum, additional_fee_sum, final_price_sum, processing_fee_sum, customer_recevible, " +
                                          "edit_id, invoice_number, is_payment_cancelled, customer_id, adata.manna " +
                                          "from tww_salesorder_history inner join adata on tww_salesorder_history.customer_id = adata.manno " +
                                          "where branch_id=@branch_id and event_time between @dayStart and @dayEnd " +
                                          "order by event_time";

                    command.Parameters.AddWithValue("@branch_id", storeId);
                    command.Parameters.AddWithValue("@dayStart", oneDay);
                    command.Parameters.AddWithValue("@dayEnd", oneDay.AddDays(1));

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            NewHistoryItemViewModel anItemModel = new NewHistoryItemViewModel();

                            anItemModel.tww_Salesorder_History.id = reader.GetInt32(0);
                            var aTime = reader.GetDateTime(1);
                            anItemModel.tww_Salesorder_History.event_time = aTime.ToString("MM/dd HH:mm");
                            anItemModel.tww_Salesorder_History.event_type = GetNullableStringField(reader, 2);

                            anItemModel.tww_Salesorder_History.receiving_number = reader.GetInt32(3);
                            anItemModel.tww_Salesorder_History.retriving_number = reader.GetInt32(4);
                            anItemModel.tww_Salesorder_History.revising_number = reader.GetInt32(5);
                            anItemModel.tww_Salesorder_History.cashing_in = reader.GetInt32(6);

                            anItemModel.tww_Salesorder_History.normal_price_sum = reader.GetInt32(7);
                            anItemModel.tww_Salesorder_History.discount_amount_sum = reader.GetInt32(8);
                            anItemModel.tww_Salesorder_History.additional_fee_sum = reader.GetInt32(9);
                            anItemModel.tww_Salesorder_History.final_price_sum = reader.GetInt32(10);
                            anItemModel.tww_Salesorder_History.processing_fee_sum = reader.GetInt32(11);

                            anItemModel.tww_Salesorder_History.customer_recevible = reader.GetInt32(12);

                            anItemModel.tww_Salesorder_History.edit_id = GetNullableStringField(reader, 13);
                            anItemModel.tww_Salesorder_History.invoice_number = GetNullableStringField(reader, 14);

                            anItemModel.tww_Salesorder_History.is_payment_cancelled = reader.GetBoolean(15);

                            anItemModel.tww_Salesorder_History.customer_id = GetNullableStringField(reader, 16);
                            anItemModel.adata.manna = GetNullableStringField(reader, 17);

                            aModelList.Add(anItemModel);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log("Err=" + ex.Message);
                // ignored
            }
        }
        #endregion


        #region 讀取衣物資訊、設定 (TwwPos)

        public TwwPosViewModel GetTwwPosModel(string storeId)
        {
            TwwPosViewModel aTwwPosModel = new TwwPosViewModel();
            aTwwPosModel.ProductModelList = QueryProducts(storeId);
            aTwwPosModel.ClothesMaterialModelList = QueryClothesMaterials();
            aTwwPosModel.HandleTypeModelList = QueryHandleTypes();
            aTwwPosModel.ClothesColorModelList = QueryClothesColors();
            aTwwPosModel.AccessoryModelList = QueryAccessories();
            aTwwPosModel.ProcessingTypeModelList = QueryProcessingTypes();
            aTwwPosModel.ClothesNoteModelList = QueryClothesNotes();
            aTwwPosModel.CustumerServiceNoteModelList = QueryCustumerServiceNotes();
            aTwwPosModel.CustumerGenderModelList = QueryCustumerGenders();
            aTwwPosModel.PriceModelList = QueryPrices(storeId);
            aTwwPosModel.FreePriceModelList = QueryFreePrices(storeId);//針對單店活動金額設定
            aTwwPosModel.CampaignModelList = QueryCampaigns(storeId);
            aTwwPosModel.StoragePlaceModelList = new PosFrontSysImplement().QueryStoragePlaces(storeId);
            aTwwPosModel.ClothesStorageMappingList = QueryClothesStorageMappings(storeId);
            aTwwPosModel.PrepaidDepositList = QueryPrepaidDeposit(storeId);
            return aTwwPosModel;
        }
        public List<gdataf_new> QueryProducts(string storeId)
        {
            List<gdataf_new> aModelList = new List<gdataf_new>();
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "select dno, dna from gdataf_new where store_Id = @store_Id order by sort_index";
                    command.Parameters.AddWithValue("@store_Id", storeId);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            gdataf_new aProductModel = new gdataf_new();

                            aProductModel.dno = GetNullableStringField(reader, 0);
                            aProductModel.dna = GetNullableStringField(reader, 1);

                            aModelList.Add(aProductModel);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log("Err=" + ex.Message);
            }
            return aModelList;
        }
        public List<gdatae> QueryClothesMaterials()
        {
            List<gdatae> aModelList = new List<gdatae>();
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "select wno, wna from gdatae";
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var aClothesMaterialModel =
                                new gdatae
                                {
                                    wno = GetNullableStringField(reader, 0),
                                    wna = GetNullableStringField(reader, 1)
                                };

                            aModelList.Add(aClothesMaterialModel);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log("Err=" + ex.Message);
                // ignored
            }
            return aModelList;
        }

        public List<gdatab> QueryHandleTypes()
        {
            List<gdatab> aModelList = new List<gdatab>();
            try
            {
                using (var connection = new SqlConnection(Config.Item("TwwPos")))
                using (var command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "select typeno, typena from gdatab";
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var aHandleTypeModel =
                                new gdatab
                                {
                                    typeno = GetNullableStringField(reader, 0),
                                    typena = GetNullableStringField(reader, 1)
                                };


                            aModelList.Add(aHandleTypeModel);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log("Err=" + ex.Message);
                // ignored
            }
            return aModelList;
        }

        public List<gdatac> QueryClothesColors()
        {
            List<gdatac> aModelList = new List<gdatac>();
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "select colorno, colorna from gdatac order by sort_index";
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var aClothesColorModel =
                                new gdatac
                                {
                                    colorno = GetNullableStringField(reader, 0),
                                    colorna = GetNullableStringField(reader, 1)
                                };


                            aModelList.Add(aClothesColorModel);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log("Err=" + ex.Message);
                // ignored
            }
            return aModelList;
        }

        public List<gdatad> QueryAccessories()
        {
            List<gdatad> aModelList = new List<gdatad>();
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "select fkndno, fkndna from gdatad order by sort_index";
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var aAccessoryModel =
                                new gdatad
                                {
                                    fkndno = GetNullableStringField(reader, 0),
                                    fkndna = GetNullableStringField(reader, 1)
                                };


                            aModelList.Add(aAccessoryModel);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log("Err=" + ex.Message);
            }
            return aModelList;
        }


        public List<addworkb> QueryProcessingTypes()
        {
            List<addworkb> aModelList = new List<addworkb>();
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "select addno, addna from addworkb";
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var aModel =
                                new addworkb
                                {
                                    addno = GetNullableStringField(reader, 0),
                                    addna = GetNullableStringField(reader, 1)
                                };

                            aModelList.Add(aModel);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log("Err=" + ex.Message);
            }
            return aModelList;
        }

        public List<gdatag> QueryClothesNotes()
        {
            List<gdatag> aModelList = new List<gdatag>();
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "select noteno, notena from gdatag ORDER BY cast (noteno as integer)";
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var aModel =
                                new gdatag
                                {
                                    noteno = GetNullableStringField(reader, 0),
                                    notena = GetNullableStringField(reader, 1)
                                };


                            aModelList.Add(aModel);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log("Err=" + ex.Message);
                // ignored
            }
            return aModelList;
        }

        public List<mantype> QueryCustumerServiceNotes()
        {
            List<mantype> aModelList = new List<mantype>();
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "select mantypeno, mantypena from mantype";
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var aModel =
                                new mantype
                                {
                                    mantypeno = GetNullableStringField(reader, 0),
                                    mantypena = GetNullableStringField(reader, 1)
                                };


                            aModelList.Add(aModel);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log("Err=" + ex.Message);
                // ignored
            }
            return aModelList;
        }

        public List<adatae> QueryCustumerGenders()
        {
            List<adatae> aModelList = new List<adatae>();
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "select sexno, sexna from adatae";
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var aModel =
                                new adatae
                                {
                                    sexno = GetNullableStringField(reader, 0),
                                    sexna = GetNullableStringField(reader, 1)
                                };


                            aModelList.Add(aModel);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log("Err=" + ex.Message);
                // ignored
            }
            return aModelList;
        }

        public List<edata> QueryPrices(string storeId)
        {
            List<edata> aModelList = new List<edata>();
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "select dno, wno, money from edata where store_id=@store_id";
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
                                aPriceModel.money = (int)price;
                            }
                            aModelList.Add(aPriceModel);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log("Err=" + ex.Message);
                // ignored
            }
            return aModelList;
        }

        //針對單店活動金額設定
        public List<edata> QueryFreePrices(string storeId)
        {
            List<edata> aModelList = new List<edata>();
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
                            aModelList.Add(aPriceModel);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log("Err=" + ex.ToString());
            }
            return aModelList;
        }


        public List<cases> QueryCampaigns(string storeId)
        {
            List<cases> aModelList = new List<cases>();
            var strToday = DateTime.Now.ToString("yyyyMMdd");

            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "select caseno, casena, sdate, edate, uses, pers, moneys ,free from cases where (@today >= sdate) and (@today <= edate) and store_id=@store_id ";

                    command.Parameters.AddWithValue("@today", strToday);
                    command.Parameters.AddWithValue("@store_id", storeId);

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
                                    uses = GetNullableStringField(reader, 4),
                                };

                            if (!Convert.IsDBNull(reader[5]))
                                aModel.pers = (int)reader.GetInt16(5);

                            if (!Convert.IsDBNull(reader[6]))
                                aModel.moneys = (int)reader.GetSqlDouble(6);

                            if (!Convert.IsDBNull(reader[7]))
                                aModel.free = reader.GetBoolean(7);

                            aModelList.Add(aModel);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Log("Err=" + ex.Message);
            }
            return aModelList;
        }

        
        public List<gdataf_new> QueryClothesStorageMappings(string storeId)
        {
            List<gdataf_new> aModelList = new List<gdataf_new>();
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "select dno, insiteno from gdataf_new where store_Id = @store_Id ";
                    command.Parameters.AddWithValue("@store_Id", storeId);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var aModel =
                                new gdataf_new
                                {
                                    dno = GetNullableStringField(reader, 0),
                                    insiteno = GetNullableStringField(reader, 1)
                                };


                            aModelList.Add(aModel);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log("Err=" + ex.Message);
                // ignored
            }
            return aModelList;
        }

        public List<Prepaiddeposit> QueryPrepaidDeposit(string storeId)
        {
            List<Prepaiddeposit> aModelList = new List<Prepaiddeposit>();
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "Select prepaid_amount,prepaid_coupons from Prepaiddeposit where store_id = @store_id order by id";

                    command.Parameters.AddWithValue("@store_id", storeId);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var aModel = new Prepaiddeposit
                            {
                                prepaid_amount = reader.GetInt32(0),
                                prepaid_coupons = reader.GetInt32(1)
                            };

                            aModelList.Add(aModel);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log("Err=" + ex.Message);
            }
            return aModelList;
        }

        private void PrepareModelFromStringToJsonObjects(ClothesSaleOrderItem aModel, TwwPosViewModel aTwwPosModel)
        {
            foreach (var productModel in aTwwPosModel.ProductModelList)
            {
                if (aModel.Clothes.dno == productModel.dno)
                {
                    aModel.Clothes.dna = productModel.dna;
                }
            }

            foreach (var clothesMaterialModel in aTwwPosModel.ClothesMaterialModelList)
            {
                if (aModel.Material.wno == clothesMaterialModel.wno)
                {
                    aModel.Material.wna = clothesMaterialModel.wna;
                }
            }

            foreach (var handleTypeModel in aTwwPosModel.HandleTypeModelList)
            {
                if (aModel.HandleType.typeno == handleTypeModel.typeno)
                {
                    aModel.HandleType.typena = handleTypeModel.typena;
                }
            }

            foreach (var processingTypeModel in aTwwPosModel.ProcessingTypeModelList)
            {
                if (aModel.ProcessingType.addno == processingTypeModel.addno)
                {
                    aModel.ProcessingType.addna = processingTypeModel.addna;
                }
            }

            string color = aModel.gdata.color;

            //20190125花色修改代值
            // 修正 - 原先修改收單並儲存後因ColorList是依 某Color是否在 ClothesColorModelList中,按順序加入 
            List<string> newColors = color.Split(',').ToList();
            List<string> colortmp = newColors;
            if (color != "")
                foreach (string newColor in newColors)
                {
                    ////foreach (var clothesColorModel in aTwwPosModel.ClothesColorModelList)
                    ////{
                    var clothesColors = aTwwPosModel.ClothesColorModelList.FirstOrDefault(x => x.colorna == newColor);
                    if (clothesColors != null)
                    {
                        gdatac aColor = new gdatac
                        {
                            colorna = clothesColors.colorna,
                            colorno = clothesColors.colorno
                        };
                        aModel.ColorList.Add(aColor);
                        //  color = color.Replace(clothesColors.Name, "");
                        colortmp = colortmp.Where(x => x != clothesColors.colorna).ToList();
                        if (colortmp.Count == 0)
                        {
                            break;
                        }
                    }
                    else
                    {
                        if (newColor != "")
                        {
                            gdatac aColor = new gdatac
                            {
                                colorno = "999",
                                colorna = newColor
                            };
                            aModel.ColorList.Add(aColor);
                            //color = color.Replace(newColor, "");
                            colortmp = colortmp.Where(x => x != newColor).ToList();
                            if (colortmp.Count == 0)
                            {
                                break;
                            }
                        }
                    }
                    //}

                }

            //20190125配件修改代值
            string accessory = aModel.gdata.fknd;
            if (accessory != "")
            {
                List<string> accessorys = accessory.Split(',').ToList();
                List<string> accessorytmp = accessorys;
                foreach (var item in accessorys)
                {
                    var asm = aTwwPosModel.AccessoryModelList.FirstOrDefault(x => x.fkndna == item);
                    if (asm != null)
                    {
                        gdatad anAccessory = new gdatad
                        {
                            fkndna = asm.fkndna,
                            fkndno = asm.fkndno
                        };
                        aModel.AccessoryList.Add(anAccessory);
                        // accessory = accessory.Replace(asm.Name, "");
                        accessorytmp = accessorytmp.Where(x => x != asm.fkndna).ToList();
                        if (accessorytmp.Count == 0)
                        {
                            break;
                        }
                    }
                    else
                    {
                        gdatad anAccessory = new gdatad
                        {
                            fkndno = "999",
                            fkndna = item
                        };
                        aModel.AccessoryList.Add(anAccessory);
                        //accessory = accessory.Replace(item, "");
                        accessorytmp = accessorytmp.Where(x => x != item).ToList();
                        if (accessorytmp.Count == 0)
                        {
                            break;
                        }
                    }
                }
            }


            if ((aModel.gdata.date1.Length == 8) && (aModel.gdata.date2.Length == 8))
            {
                DateTime recvDate = DateTime.ParseExact(aModel.gdata.date1, "yyyyMMdd", null);
                DateTime deliverDate = DateTime.ParseExact(aModel.gdata.date2, "yyyyMMdd", null);

                aModel.DaysNeededForDelivery = deliverDate.Subtract(recvDate).Days;
            }

            foreach (var storagePlaceModel in aTwwPosModel.StoragePlaceModelList)
            {
                if (aModel.StoragePlace.insiteno == storagePlaceModel.insiteno)
                {
                    aModel.StoragePlace.insitena = storagePlaceModel.insitena;
                }
            }
        }



        #endregion
        #region 客戶的
        public void QueryShipToShopsSalesOrders(List<string> aBarcodeList, List<string> aShippmentIdList, string aStoreId, List<string> nonwashingBarcodeList, List<tww_outgoing_shippment> InwarehouseCheckList)
        {
            List<tww_outgoing_shippment> nonprocessedNonwashingList = new List<tww_outgoing_shippment>();

            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();

                command.CommandText = "select barcode_id, outgoing_shippment_id, is_nonwashing_return, is_nonwashing_return_processed, id, orderno from tww_outgoing_shippment where store_id=@store_id and is_retrieved=@is_retrieved";
                Log("-SQLTxt=" + command.CommandText + "\n");
                command.Parameters.AddWithValue("@store_id", aStoreId);
                command.Parameters.AddWithValue("@is_retrieved", false);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string barcodeId = GetNullableStringField(reader, 0);
                        string shippmentId = GetNullableStringField(reader, 1);
                        var isNonwashingReturn = reader.GetBoolean(2);
                        var isNonwashingReturnProcessed = reader.GetBoolean(3);
                        string orderId = GetNullableStringField(reader, 5);

                        aBarcodeList.Add(barcodeId);
                        aShippmentIdList.Add(shippmentId);

                        var Inwarehouse = new tww_outgoing_shippment
                        {
                            barcode_id = barcodeId,
                            orderno = orderId
                        };
                        InwarehouseCheckList.Add(Inwarehouse);


                        if (isNonwashingReturn)
                        {
                            nonwashingBarcodeList.Add(barcodeId);
                        }

                        if (isNonwashingReturn && !isNonwashingReturnProcessed)
                        {
                            var anItem = new tww_outgoing_shippment
                            {
                                id = reader.GetInt32(4),
                                barcode_id = barcodeId
                            };
                            nonprocessedNonwashingList.Add(anItem);
                        }
                    }
                }
                connection.Close();
                connection.Dispose();
            }

            if (nonprocessedNonwashingList.Count > 0)
            {
                AddNonwashingReturnListToRecords(aStoreId, nonprocessedNonwashingList);
            }

        }
        private void AddNonwashingReturnListToRecords(string storeId, List<tww_outgoing_shippment> nonprocessedNonwashingList)
        {
            List<ClothesSaleOrderItem> salesOrderList = new List<ClothesSaleOrderItem>();

            foreach (var item in nonprocessedNonwashingList)
            {
                QuerySpecificSalesOrder(salesOrderList, 1, item.barcode_id, 1, storeId);
                //UpdateNonwashingReturnItemForOutgoingShippment(item.Barcode, storeId);
                UpdateNonwashingReturnItemForOutgoingShippment(item, storeId);
            }

            foreach (var salesOrder in salesOrderList)
            {
                //0322 廠回續洗不用金額故註解並設0 customerRecevible = 0
                //var customerRecevible = UpdateCustomerRecevibleForNonwashingReturn(salesOrder, storeId);
                var customerRecevible = SelectCustomerRecevibleForNonwashingReturn(salesOrder, storeId);
                var id = InsertSalesOrderHistoryForNonwashingReturn(salesOrder, storeId, customerRecevible);
                if (id > 0)
                {
                    InsertSalesOrderHistoryDetailsForNonwashingReturn(id, salesOrder, storeId);
                }
            }
        }
        //20181005
        private void QuerySpecificSalesOrder(List<ClothesSaleOrderItem> SalesOrderList, int searchType, string searchId, int inWarehouseType, string storeId)
        {
            string strSelect = "select wano, wano2, dno, wno, typeno, addno, color, fknd, date1, date2, " +
                               "insiteno, money0, money2, money3, money4, money5, note, caseno, manno, indate, indoor, " +
                               "IncomingShippmentFlag, IncomingShippmentNote, Revicion_Note from gdata where offno=@offno and delwano2=@delwano2 and ";
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    if (searchType == 1)//Barcode
                    {
                        if (inWarehouseType == 1)
                        {
                            command.CommandText = strSelect + "wano2=@wano2 and getw=@getw and indoor=@indoor";
                            command.Parameters.AddWithValue("@wano2", searchId);
                            command.Parameters.AddWithValue("@getw", "f");
                            command.Parameters.AddWithValue("@indoor", "f");
                        }
                        else if (inWarehouseType == 2)
                        {
                            command.CommandText = strSelect + "wano2=@wano2 and getw=@getw";
                            command.Parameters.AddWithValue("@wano2", searchId);
                            command.Parameters.AddWithValue("@getw", "f");
                        }
                        else
                        {
                            command.CommandText = strSelect + "wano2=@wano2 and getw=@getw and indoor=@indoor";
                            command.Parameters.AddWithValue("@wano2", searchId);
                            command.Parameters.AddWithValue("@getw", "f");
                            command.Parameters.AddWithValue("@indoor", "t");
                        }
                    }

                    if (searchType == 2) //CustomerId
                    {
                        if (inWarehouseType == 1)
                        {
                            command.CommandText = strSelect + "manno=@manno and getw=@getw and indoor=@indoor";
                            command.Parameters.AddWithValue("@manno", searchId);
                            command.Parameters.AddWithValue("@getw", "f");
                            command.Parameters.AddWithValue("@indoor", "f");
                        }
                        else if (inWarehouseType == 2)
                        {
                            command.CommandText = strSelect + "manno=@manno and getw=@getw";
                            command.Parameters.AddWithValue("@manno", searchId);
                            command.Parameters.AddWithValue("@getw", "f");
                        }
                        else
                        {
                            command.CommandText = strSelect + "manno=@manno and getw=@getw and indoor=@indoor";
                            command.Parameters.AddWithValue("@manno", searchId);
                            command.Parameters.AddWithValue("@getw", "f");
                            command.Parameters.AddWithValue("@indoor", "t");
                        }
                    }

                    if (searchType == 3) //InDate
                    {
                        if (inWarehouseType == 1)
                        {
                            command.CommandText = strSelect + "indate=@indate and getw=@getw and indoor=@indoor";
                            command.Parameters.AddWithValue("@indate", searchId);
                            command.Parameters.AddWithValue("@getw", "f");
                            command.Parameters.AddWithValue("@indoor", "f");
                        }
                        else if (inWarehouseType == 2)
                        {
                            command.CommandText = strSelect + "indate=@indate and getw=@getw";
                            command.Parameters.AddWithValue("@indate", searchId);
                            command.Parameters.AddWithValue("@getw", "f");
                        }
                        else
                        {
                            command.CommandText = strSelect + "indate=@indate and getw=@getw and indoor=@indoor";
                            command.Parameters.AddWithValue("@indate", searchId);
                            command.Parameters.AddWithValue("@getw", "f");
                            command.Parameters.AddWithValue("@indoor", "t");
                        }
                    }

                    if (searchType == 4) //Receiving Date
                    {
                        if (inWarehouseType == 1)
                        {
                            command.CommandText = strSelect + "date1=@date1 and getw=@getw and indoor=@indoor";
                            command.Parameters.AddWithValue("@date1", searchId);
                            command.Parameters.AddWithValue("@getw", "f");
                            command.Parameters.AddWithValue("@indoor", "f");
                        }
                        else if (inWarehouseType == 2)
                        {
                            command.CommandText = strSelect + "date1=@date1 and getw=@getw";
                            command.Parameters.AddWithValue("@date1", searchId);
                            command.Parameters.AddWithValue("@getw", "f");
                        }
                        else
                        {
                            command.CommandText = strSelect + "date1=@date1 and getw=@getw and indoor=@indoor";
                            command.Parameters.AddWithValue("@date1", searchId);
                            command.Parameters.AddWithValue("@getw", "f");
                            command.Parameters.AddWithValue("@indoor", "t");
                        }
                    }

                    if (searchType == 5) //Incoming Shippment
                    {
                        if (inWarehouseType == 1)
                        {
                            command.CommandText = strSelect + "getw=@getw and indoor=@indoor and IncomingShippmentFlag=@IncomingShippmentFlag";
                            command.Parameters.AddWithValue("@getw", "f");
                            command.Parameters.AddWithValue("@indoor", "f");
                            command.Parameters.AddWithValue("@IncomingShippmentFlag", false);
                        }
                        else if (inWarehouseType == 2)//search by barcode
                        {
                            command.CommandText = strSelect + "getw=@getw and indoor=@indoor and wano2=@wano2";
                            command.Parameters.AddWithValue("@getw", "f");
                            command.Parameters.AddWithValue("@indoor", "f");
                            command.Parameters.AddWithValue("@wano2", searchId);
                        }
                        else if (inWarehouseType == 3)//search by shippment id
                        {
                            command.CommandText = strSelect + "getw=@getw and indoor=@indoor and IncomingShippmentSerial=@IncomingShippmentSerial";
                            command.Parameters.AddWithValue("@getw", "f");
                            command.Parameters.AddWithValue("@indoor", "f");
                            command.Parameters.AddWithValue("@IncomingShippmentSerial", searchId);
                        }
                        else
                        {
                            command.CommandText = strSelect + "getw=@getw and indoor=@indoor";
                            command.Parameters.AddWithValue("@getw", "f");
                            command.Parameters.AddWithValue("@indoor", "t");
                        }
                    }

                    command.Parameters.AddWithValue("@offno", storeId);
                    command.Parameters.AddWithValue("@delwano2", "f");

                    command.CommandText += " order by wano";

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ClothesSaleOrderItem anItemModel = new ClothesSaleOrderItem();

                            anItemModel.gdata.wano = GetNullableStringField(reader, 0);
                            anItemModel.gdata.wano2 = GetNullableStringField(reader, 1);
                            anItemModel.Clothes.dna = GetNullableStringField(reader, 2);

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

                            anItemModel.gdata.manno = GetNullableStringField(reader, 18);

                            anItemModel.gdata.indate = GetNullableStringField(reader, 19);

                            var isInWarehouse = GetNullableStringField(reader, 20);

                            if (isInWarehouse == "f")
                            {
                                anItemModel.gdata.indoor = "False";
                            }
                            else
                            {
                                anItemModel.gdata.indoor = "True";
                            }

                            anItemModel.gdata.IncomingShippmentFlag = (bool)reader.GetSqlBoolean(21);
                            anItemModel.gdata.IncomingShippmentNote = GetNullableStringField(reader, 22);

                            anItemModel.gdata.Revicion_Note = GetNullableStringField(reader, 23);

                            SalesOrderList.Add(anItemModel);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log("Err=" + ex.Message + "\n");
            }
        }
        private void UpdateNonwashingReturnItemForOutgoingShippment(tww_outgoing_shippment aModel, string storeId)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "Update tww_outgoing_shippment set is_nonwashing_return_processed=@is_nonwashing_return_processed " +
                                          "where store_id=@store_id and barcode_id=@barcode_id and id=@id";
                    Log("SQLTxt=" + command.CommandText + "\n");
                    command.Parameters.AddWithValue("@is_nonwashing_return_processed", true);
                    command.Parameters.AddWithValue("@store_id", storeId);
                    command.Parameters.AddWithValue("@barcode_id", aModel.barcode_id);
                    command.Parameters.AddWithValue("@id", aModel.id);

                    command.ExecuteNonQuery();

                    connection.Close();
                    connection.Dispose();
                }
            }
            catch (Exception ex)
            {
                Log("Err=" + ex.Message + "\n");
            }
        }

        public void CancelRetrivingSalesOrderItemForOutgoingShippment(tww_outgoing_shippment req)
        {
            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();

                command.CommandText = "Update tww_outgoing_shippment set is_retrieved=@is_retrieved where store_id=@store_id and barcode_id=@barcode_id and orderno = @orderno";

                command.Parameters.AddWithValue("@is_retrieved", false);
                command.Parameters.AddWithValue("@store_id", req.store_id);
                command.Parameters.AddWithValue("@barcode_id", req.barcode_id);

                //加入洗衣單號才不會重覆更新
                command.Parameters.AddWithValue("@orderno", req.orderno);

                command.ExecuteNonQuery();
            }

        }
        private int SelectCustomerRecevibleForNonwashingReturn(ClothesSaleOrderItem aModel, string storeId)
        {
            int recevible = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();
                    command.CommandText = "select money from adata where manno=@manno and offno=@offno";
                    Log("SQLTxt=" + command.CommandText + "\n");
                    command.Parameters.AddWithValue("@manno", aModel.gdata.manno);
                    command.Parameters.AddWithValue("@offno", storeId);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            recevible = Convert.ToInt32(reader.GetDouble(0));
                        }
                    }
                    connection.Close();
                    connection.Dispose();
                }
                return recevible;
            }
            catch (Exception ex)
            {
                Log("Err=" + ex.Message + "\n");
                return 0;
            }
        }
        private int InsertSalesOrderHistoryForNonwashingReturn(ClothesSaleOrderItem aModel, string storeId, int customerRecevible)
        {
            DateTime currentTime = DateTime.Now;

            try
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
                    Log("SQLTxt=" + command.CommandText + "\n");
                    command.Parameters.AddWithValue("@event_time", currentTime);
                    command.Parameters.AddWithValue("@branch_id", storeId);
                    command.Parameters.AddWithValue("@customer_id", aModel.gdata.manno);
                    command.Parameters.AddWithValue("@event_type", "廠回不洗");

                    command.Parameters.AddWithValue("@retriving_number", 0);

                    command.Parameters.AddWithValue("@normal_price_sum", aModel.gdata.money0);
                    command.Parameters.AddWithValue("@discount_amount_sum", aModel.gdata.money3);
                    command.Parameters.AddWithValue("@additional_fee_sum", aModel.gdata.money2);
                    command.Parameters.AddWithValue("@final_price_sum", aModel.gdata.money4);
                    command.Parameters.AddWithValue("@processing_fee_sum", aModel.gdata.money5);

                    command.Parameters.AddWithValue("@customer_recevible", customerRecevible);

                    command.Parameters.AddWithValue("@edit_id", "system");

                    Id = (int)command.ExecuteScalar();

                    connection.Close();
                    connection.Dispose();
                }
                return Id;

            }
            catch (Exception ex)
            {
                Log("Err=" + ex.Message + "\n");
                return 0;
            }
        }
        private void InsertSalesOrderHistoryDetailsForNonwashingReturn(int id, ClothesSaleOrderItem salesOrderItem, string storeId)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "INSERT INTO tww_salesorder_history_details ( tww_salesorder_history_id, salesorder_id, barcode_id, clothes_type_id, material_id, handle_type_id, processing_type_id, " +
                                          "color, accessory, notes, normal_price, discount_amount, additional_fee, final_price, processing_fee, deliver_date ) " +
                                          "VALUES ( @tww_salesorder_history_id, @salesorder_id, @barcode_id, @clothes_type_id, @material_id, @handle_type_id, @processing_type_id, " +
                                          "@color, @accessory, @notes, @normal_price, @discount_amount, @additional_fee, @final_price, @processing_fee, @deliver_date )";
                    Log("SQLTxt=" + command.CommandText + "\n");
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

                    command.Parameters["@salesorder_id"].Value = salesOrderItem.gdata.wano;
                    command.Parameters["@barcode_id"].Value = salesOrderItem.gdata.wano2;

                    command.Parameters["@clothes_type_id"].Value = salesOrderItem.Clothes.dno;
                    command.Parameters["@material_id"].Value = salesOrderItem.Material.wno;
                    command.Parameters["@handle_type_id"].Value = salesOrderItem.HandleType.typeno;
                    command.Parameters["@processing_type_id"].Value = string.IsNullOrEmpty(salesOrderItem.ProcessingType.addno) ? (object)DBNull.Value : salesOrderItem.ProcessingType.addno;
                    command.Parameters["@processing_type_id"].IsNullable = true;

                    command.Parameters["@color"].Value = string.IsNullOrEmpty(salesOrderItem.gdata.color) ? (object)DBNull.Value : salesOrderItem.gdata.color;
                    command.Parameters["@color"].IsNullable = true;

                    command.Parameters["@accessory"].Value = string.IsNullOrEmpty(salesOrderItem.gdata.fknd) ? (object)DBNull.Value : salesOrderItem.gdata.fknd;
                    command.Parameters["@accessory"].IsNullable = true;

                    command.Parameters["@notes"].Value = string.IsNullOrEmpty(salesOrderItem.gdata.note) ? (object)DBNull.Value : salesOrderItem.gdata.note;
                    command.Parameters["@notes"].IsNullable = true;

                    command.Parameters["@normal_price"].Value = salesOrderItem.gdata.money0;
                    command.Parameters["@discount_amount"].Value = salesOrderItem.gdata.money3;
                    command.Parameters["@additional_fee"].Value = salesOrderItem.gdata.money2;
                    command.Parameters["@final_price"].Value = salesOrderItem.gdata.money4;
                    command.Parameters["@processing_fee"].Value = salesOrderItem.gdata.money5;

                    command.Parameters["@deliver_date"].Value = salesOrderItem.gdata.date2;

                    command.ExecuteNonQuery();

                    connection.Close();
                    connection.Dispose();
                }
            }
            catch (Exception ex)
            {
                Log("Err=" + ex.Message + "\n");
            }
        }

        //搜尋客戶的衣物

        public CustomerClothesQueryRes QueryCustomerByOrderId(CustomerClothesQueryReq aModel)
        {
            CustomerClothesQueryRes res = new CustomerClothesQueryRes();
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "select TOP 1 manno from gdata where offno=@offno and wano=@wano order by date1 DESC";
                    Log("SQLTxt=" + command.CommandText + "\n");
                    command.Parameters.AddWithValue("@offno", aModel.storeId);
                    command.Parameters.AddWithValue("@wano", aModel.SearchOrderId);

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
        public CustomerClothesQueryRes QueryCustomerByPhone(CustomerClothesQueryReq aModel)
        {
            CustomerClothesQueryRes res = new CustomerClothesQueryRes();
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "select TOP 1 manno from adata where offno=@offno and (tel=@tel or handtel=@tel) order by inday DESC";
                    Log("SQLTxt=" + command.CommandText + "\n");
                    command.Parameters.AddWithValue("@offno", aModel.storeId);
                    command.Parameters.AddWithValue("@tel", aModel.SearchPhone);

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

        #endregion

        #region 出入庫
        public SpecificSalesOrderRes QuerySpecificSalesOrder(SpecificSalesOrderReq req)
        {
            SpecificSalesOrderRes res = new SpecificSalesOrderRes();


            string strSelect = "select wano, wano2, dno, wno, typeno, addno, color, fknd, date1, date2, " +
                               "insiteno, money0, money2, money3, money4, money5, note, caseno, manno, indate, indoor, " +
                               "IncomingShippmentFlag, IncomingShippmentNote, Revicion_Note from gdata where offno=@offno and delwano2=@delwano2 and ";
            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();

                if (req.searchType == 1)//Barcode
                {
                    if (req.inWarehouseType == 1)
                    {
                        command.CommandText = strSelect + "wano2=@wano2 and getw=@getw and indoor=@indoor";
                        command.Parameters.AddWithValue("@wano2", req.searchId);
                        command.Parameters.AddWithValue("@getw", "f");
                        command.Parameters.AddWithValue("@indoor", "f");
                    }
                    else if (req.inWarehouseType == 2)
                    {
                        command.CommandText = strSelect + "wano2=@wano2 and getw=@getw";
                        command.Parameters.AddWithValue("@wano2", req.searchId);
                        command.Parameters.AddWithValue("@getw", "f");
                    }
                    else
                    {
                        command.CommandText = strSelect + "wano2=@wano2 and getw=@getw and indoor=@indoor";
                        command.Parameters.AddWithValue("@wano2", req.searchId);
                        command.Parameters.AddWithValue("@getw", "f");
                        command.Parameters.AddWithValue("@indoor", "t");
                    }
                }

                if (req.searchType == 2) //CustomerId
                {
                    if (req.inWarehouseType == 1)
                    {
                        command.CommandText = strSelect + "manno=@manno and getw=@getw and indoor=@indoor";
                        command.Parameters.AddWithValue("@manno", req.searchId);
                        command.Parameters.AddWithValue("@getw", "f");
                        command.Parameters.AddWithValue("@indoor", "f");
                    }
                    else if (req.inWarehouseType == 2)
                    {
                        command.CommandText = strSelect + "manno=@manno and getw=@getw";
                        command.Parameters.AddWithValue("@manno", req.searchId);
                        command.Parameters.AddWithValue("@getw", "f");
                    }
                    else
                    {
                        command.CommandText = strSelect + "manno=@manno and getw=@getw and indoor=@indoor";
                        command.Parameters.AddWithValue("@manno", req.searchId);
                        command.Parameters.AddWithValue("@getw", "f");
                        command.Parameters.AddWithValue("@indoor", "t");
                    }
                }

                if (req.searchType == 3) //InDate
                {
                    if (req.inWarehouseType == 1)
                    {
                        command.CommandText = strSelect + "indate=@indate and getw=@getw and indoor=@indoor";
                        command.Parameters.AddWithValue("@indate", req.searchId);
                        command.Parameters.AddWithValue("@getw", "f");
                        command.Parameters.AddWithValue("@indoor", "f");
                    }
                    else if (req.inWarehouseType == 2)
                    {
                        command.CommandText = strSelect + "indate=@indate and getw=@getw";
                        command.Parameters.AddWithValue("@indate", req.searchId);
                        command.Parameters.AddWithValue("@getw", "f");
                    }
                    else
                    {
                        command.CommandText = strSelect + "indate=@indate and getw=@getw and indoor=@indoor";
                        command.Parameters.AddWithValue("@indate", req.searchId);
                        command.Parameters.AddWithValue("@getw", "f");
                        command.Parameters.AddWithValue("@indoor", "t");
                    }
                }

                if (req.searchType == 4) //Receiving Date
                {
                    if (req.inWarehouseType == 1)
                    {
                        command.CommandText = strSelect + "date1=@date1 and getw=@getw and indoor=@indoor";
                        command.Parameters.AddWithValue("@date1", req.searchId);
                        command.Parameters.AddWithValue("@getw", "f");
                        command.Parameters.AddWithValue("@indoor", "f");
                    }
                    else if (req.inWarehouseType == 2)
                    {
                        command.CommandText = strSelect + "date1=@date1 and getw=@getw";
                        command.Parameters.AddWithValue("@date1", req.searchId);
                        command.Parameters.AddWithValue("@getw", "f");
                    }
                    else
                    {
                        command.CommandText = strSelect + "date1=@date1 and getw=@getw and indoor=@indoor";
                        command.Parameters.AddWithValue("@date1", req.searchId);
                        command.Parameters.AddWithValue("@getw", "f");
                        command.Parameters.AddWithValue("@indoor", "t");
                    }
                }

                if (req.searchType == 5) //Incoming Shippment
                {
                    if (req.inWarehouseType == 1)
                    {
                        command.CommandText = strSelect + "getw=@getw and indoor=@indoor and IncomingShippmentFlag=@IncomingShippmentFlag";
                        command.Parameters.AddWithValue("@getw", "f");
                        command.Parameters.AddWithValue("@indoor", "f");
                        command.Parameters.AddWithValue("@IncomingShippmentFlag", false);
                    }
                    else if (req.inWarehouseType == 2)//search by barcode
                    {
                        command.CommandText = strSelect + "getw=@getw and indoor=@indoor and wano2=@wano2";
                        command.Parameters.AddWithValue("@getw", "f");
                        command.Parameters.AddWithValue("@indoor", "f");
                        command.Parameters.AddWithValue("@wano2", req.searchId);
                    }
                    else if (req.inWarehouseType == 3)//search by shippment id
                    {
                        command.CommandText = strSelect + "getw=@getw and indoor=@indoor and IncomingShippmentSerial=@IncomingShippmentSerial";
                        command.Parameters.AddWithValue("@getw", "f");
                        command.Parameters.AddWithValue("@indoor", "f");
                        command.Parameters.AddWithValue("@IncomingShippmentSerial", req.searchId);
                    }
                    else
                    {
                        command.CommandText = strSelect + "getw=@getw and indoor=@indoor";
                        command.Parameters.AddWithValue("@getw", "f");
                        command.Parameters.AddWithValue("@indoor", "t");
                    }
                }

                command.Parameters.AddWithValue("@offno", req.storeId);
                command.Parameters.AddWithValue("@delwano2", "f");

                command.CommandText += " order by wano";

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
                        }//0

                        if (!Convert.IsDBNull(reader[12]))
                        {
                            var additionalFee = reader.GetSqlDouble(12);
                            anItemModel.gdata.money2 = (int)additionalFee;
                        }//2

                        if (!Convert.IsDBNull(reader[13]))
                        {
                            var discountAmount = reader.GetSqlDouble(13);
                            anItemModel.gdata.money3 = (int)discountAmount;
                        }//3

                        if (!Convert.IsDBNull(reader[14]))
                        {
                            var finalPrice = reader.GetSqlDouble(14);
                            anItemModel.gdata.money4 = (int)finalPrice;
                        }//4

                        if (!Convert.IsDBNull(reader[15]))
                        {
                            var processingFee = reader.GetSqlDouble(15);
                            anItemModel.gdata.money5 = (int)processingFee;
                        }//5

                        anItemModel.gdata.note = GetNullableStringField(reader, 16);

                        anItemModel.gdata.caseno = GetNullableStringField(reader, 17);

                        anItemModel.gdata.manno = GetNullableStringField(reader, 18);

                        anItemModel.gdata.indate = GetNullableStringField(reader, 19);

                        var isInWarehouse = GetNullableStringField(reader, 20);

                        if (isInWarehouse == "f")
                        {
                            anItemModel.gdata.indoor = "False";
                        }
                        else
                        {
                            anItemModel.gdata.indoor = "True";
                        }

                        anItemModel.gdata.IncomingShippmentFlag = (bool)reader.GetSqlBoolean(21);
                        anItemModel.gdata.IncomingShippmentNote = GetNullableStringField(reader, 22);

                        anItemModel.gdata.Revicion_Note = GetNullableStringField(reader, 23);

                        res.SalesOrderList.Add(anItemModel);
                    }
                }
            }

            return res;
        }

        public void UpdateSalesOrderItemForWarehouseIn(UpdateWarehouseInReq req)
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
                    foreach (var item in req.SalesOrderList)
                    {
                        command.CommandText = "Update gdata set indoor=@indoor, insiteno=@insiteno, indate=@indate where manno=@manno and offno=@offno and wano=@wano and wano2=@wano2";
                        command.Parameters.Clear();


                        command.Parameters.AddWithValue("@indoor", item.gdata.indoor == "True" ? "t" : "f");
                        if (item.gdata.indoor == "True")
                        {
                            command.Parameters.AddWithValue("@indate", req.currentSalesOrderDate);
                            command.Parameters.AddWithNullableValue("@insiteno", item.StoragePlace.insiteno);

                        }
                        else
                        {
                            command.Parameters.AddWithValue("@indate", "");
                            command.Parameters.AddWithNullableValue("@insiteno", "");
                        }

                        command.Parameters.AddWithValue("@manno", item.gdata.manno);
                        command.Parameters.AddWithValue("@offno", req.LoginCmdModel.tww_Store.store_id);
                        command.Parameters.AddWithValue("@wano", item.gdata.wano);
                        command.Parameters.AddWithValue("@wano2", item.gdata.wano2);
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
        public void UpdateSalesOrderItemForIncomingShippment(UpdateIncomingShippmentReq req)
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
                    foreach (var anItemModel in req.SalesOrderList)
                    {
                        command.Parameters.Clear();
                        command.CommandText = "Update gdata set IncomingShippmentFlag=@IncomingShippmentFlag, IncomingShippmentNote=@IncomingShippmentNote, IncomingShippmentSerial=@IncomingShippmentSerial " +
                                          "where manno=@manno and offno=@offno and wano=@wano and wano2=@wano2";

                        command.Parameters.AddWithValue("@IncomingShippmentFlag", anItemModel.gdata.IncomingShippmentFlag);
                        command.Parameters.AddWithNullableValue("@IncomingShippmentNote", anItemModel.gdata.IncomingShippmentNote);
                        if (anItemModel.gdata.IncomingShippmentFlag)
                        {
                            command.Parameters.AddWithNullableValue("@IncomingShippmentSerial", req.aIncomingShippmentId);
                        }
                        else
                        {
                            command.Parameters.AddWithNullableValue("@IncomingShippmentSerial", "");
                        }

                        command.Parameters.AddWithValue("@manno", anItemModel.gdata.manno);
                        command.Parameters.AddWithValue("@offno", req.StoreId);
                        command.Parameters.AddWithValue("@wano", anItemModel.gdata.wano);
                        command.Parameters.AddWithValue("@wano2", anItemModel.gdata.wano2);
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

        public SpecificSalesOrderRes QueryIntoWarehouseSalesOrders(SpecificSalesOrderReq req)
        {
            SpecificSalesOrderRes res = new SpecificSalesOrderRes();
            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();

                /*command.CommandText = "select wano, wano2, dno, wno, typeno, addno, color, fknd, date1, date2, " +
                                      "insiteno, money0, money2, money3, money4, money5, note, caseno, manno, indate, indoor, " +
                                      "IncomingShippmentFlag, IncomingShippmentNote, Revicion_Note "+
                                      "from gdata inner join tww_outgoing_shippment on gdata.wano2=tww_outgoing_shippment.barcode_id and gdata.offno=tww_outgoing_shippment.store_id " +
                                      "where offno=@offno and delwano2=@delwano2 and " +
                                      "getw=@getw and indoor=@indoor and is_retrieved=@is_retrieved " +
                                      "order by wano";*/

                command.CommandText = "select wano, wano2, dno, wno, typeno, addno, color, fknd, date1, date2, " +
                                      "insiteno, money0, money2, money3, money4, money5, note, caseno, manno, indate, indoor, " +
                                      "IncomingShippmentFlag, IncomingShippmentNote, Revicion_Note " +
                                      "from gdata inner join tww_outgoing_shippment on gdata.wano2=tww_outgoing_shippment.barcode_id and gdata.offno=tww_outgoing_shippment.store_id and gdata.wano = tww_outgoing_shippment.orderno " +
                                      "where offno=@offno and delwano2=@delwano2 and " +
                                      "getw=@getw and indoor=@indoor and is_retrieved=@is_retrieved " +
                                      "order by wano,wano2";

                //                  command.Parameters.AddWithValue("@wano2", searchId);
                command.Parameters.AddWithValue("@getw", "f");
                command.Parameters.AddWithValue("@indoor", "f");

                command.Parameters.AddWithValue("@offno", req.storeId);
                command.Parameters.AddWithValue("@delwano2", "f");

                command.Parameters.AddWithValue("@is_retrieved", false);

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

                        anItemModel.gdata.manno = GetNullableStringField(reader, 18);

                        anItemModel.gdata.indate = GetNullableStringField(reader, 19);

                        var isInWarehouse = GetNullableStringField(reader, 20);

                        if (isInWarehouse == "f")
                        {
                            anItemModel.gdata.indoor = "False";
                        }
                        else
                        {
                            anItemModel.gdata.indoor = "True";
                        }

                        anItemModel.gdata.IncomingShippmentFlag = (bool)reader.GetSqlBoolean(21);
                        anItemModel.gdata.IncomingShippmentNote = GetNullableStringField(reader, 22);

                        anItemModel.gdata.Revicion_Note = GetNullableStringField(reader, 23);

                        res.SalesOrderList.Add(anItemModel);
                    }
                }
                connection.Close();
                connection.Dispose();
            }
            return res;
        }
        public LastIncomingShippmentSerialQueryRes QueryLastIncomingShippmentSerial(LastIncomingShippmentSerialQueryReq req)
        {
            LastIncomingShippmentSerialQueryRes res = new LastIncomingShippmentSerialQueryRes();

            string preId = "0";

            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();

                command.CommandText = "select TOP 1 IncomingShippmentSerial from gdata where offno=@offno and delwano2=@delwano2 and IncomingShippmentFlag=@IncomingShippmentFlag order by IncomingShippmentSerial DESC";

                command.Parameters.AddWithValue("@offno", req.aStoreId);
                command.Parameters.AddWithValue("@delwano2", "f");

                command.Parameters.AddWithValue("@IncomingShippmentFlag", true);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        res.gdata.IncomingShippmentSerial = GetNullableStringField(reader, 0);
                    }
                }
            }
            return res;

        }

        public ClothesPicturesQueryRes GetPicturesOfClothes(ClothesPicturesQueryReq aModel)
        {
            bool result = false;
            ClothesPicturesQueryRes res = new ClothesPicturesQueryRes();
            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();

                command.CommandText = "select file_name from tww_clothes_picture where store_id=@store_id and barcode_id=@barcode_id order by create_date DESC";
                command.Parameters.AddWithValue("@store_id", aModel.store_Id);
                command.Parameters.AddWithValue("@barcode_id", aModel.BarcodeId);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    result = true;

                    while (reader.Read())
                    {
                        tww_clothes_picture pic = new tww_clothes_picture();
                        pic.file_name = GetNullableStringField(reader, 0);

                        res.ClothesPicturesList.Add(pic);
                    }
                }
            }
            return res;
        }

        public ClothesWashProgressQueryRes ClothesWashProgressQuery(ClothesWashProgressQueryReq req)
        {
            ClothesWashProgressQueryRes res = new ClothesWashProgressQueryRes();

            List<SqlParameter> paras = new List<SqlParameter>();
            //            string sql = @"
            //SELECT offno,manno, wano, wano2, C.dna, D.wna, color, fknd, money, money1, money2, money3, money4, money5, 
            //    per, caseno, crman, note, B.processing_status, B.processing_time
            //	FROM gdata A
            //	INNER JOIN tww_clothes_in_factory_status B ON A.offno=B.store_id AND A.wano2=B.barcode_id AND A.wano=B.sales_order_id
            //	INNER JOIN gdataf_new C ON A.dno=C.dno and A.offno=C.store_id
            //	INNER JOIN gdatae D ON A.wno=D.wno
            //    WHERE A.offno IN (SELECT [store_id] FROM [TwwPos].[dbo].[os_grant] WHERE [comp_id]=@comp_id AND [group_id]=@group_id)
            //";
            string sql = @"
SELECT  A.[store_id],A.[barcode_id],A.[sales_order_id],A.[processing_status],A.[processing_time]
	,B.[manno],B.[color],B.[fknd],B.[money],B.[money1],B.[money2],B.[money3],B.[money4],B.[money5],B.[per],B.[caseno],B.[crman],B.[note]
	,C.[dna],D.[wna]
FROM (
	SELECT  [id],[store_id],[barcode_id],[sales_order_id],[processing_status],[processing_time]
		FROM (SELECT [id],[store_id],[barcode_id],[sales_order_id],[processing_status],[processing_time]
			,RANK() OVER (PARTITION BY [store_id],[barcode_id],[sales_order_id] ORDER BY [processing_time] DESC,[id] DESC) AS rank_no 
			FROM [TwwPos].[dbo].[tww_clothes_in_factory_status] 
              WHERE [store_id] IN (SELECT [store_id] FROM [TwwPos].[dbo].[os_grant] WHERE [comp_id]=@comp_id AND [group_id]=@group_id){0}
			) X
		WHERE rank_no=1
		) A
	LEFT JOIN [TwwPos].[dbo].[gdata] B ON A.[sales_order_id]=B.[wano] AND A.[barcode_id]=B.[wano2] AND A.[store_id]=B.[offno]  
	LEFT JOIN [TwwPos].[dbo].[gdataf_new] C ON B.[dno]=C.[dno] and B.[offno]=C.[store_id]
	LEFT JOIN [TwwPos].[dbo].[gdatae] D ON B.[wno]=D.[wno]
";
            paras.Add(new SqlParameter("@comp_id", req.comp_id));
            paras.Add(new SqlParameter("@group_id", req.group_id));

            string and = "";
            if (!string.IsNullOrEmpty(req.wano2))
            {
                and += " AND [barcode_id]=@barcode_id";
                paras.Add(new SqlParameter("@barcode_id", req.wano2));
            }
            if (!string.IsNullOrEmpty(req.store_id))
            {
                and += " AND [store_id]=@store_id";
                paras.Add(new SqlParameter("@store_id", req.store_id));
            }
            if (!string.IsNullOrEmpty(req.processing_status))
            {
                and += " AND [processing_status]=@processing_status";
                paras.Add(new SqlParameter("@processing_status", req.processing_status));
            }


            if (!string.IsNullOrEmpty(req.start_date))
            {
                DateTime sd;
                if (DateTime.TryParse(req.start_date, out sd))
                {
                    and += " AND [processing_time]>=@start_date";
                    paras.Add(new SqlParameter("@start_date", sd.ToString("yyyy/MM/dd")));
                }
            }
            if (!string.IsNullOrEmpty(req.end_date))
            {
                DateTime sd;
                if (DateTime.TryParse(req.end_date, out sd))
                {
                    and += " AND [processing_time]<@end_date";
                    paras.Add(new SqlParameter("@end_date", sd.AddDays(1).ToString("yyyy/MM/dd")));
                }
            }

            sql = string.Format(sql, and);
            using (SqlConnection conn = new SqlConnection(Config.Item("TwwPos")))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddRange(paras.ToArray());
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ClothesWashProgressQueryData data = new ClothesWashProgressQueryData();

                        data.gdata = new gdata();
                        data.gdata.offno = GetNullableStringField(reader, "store_id");
                        data.gdata.manno = GetNullableStringField(reader, "manno");
                        data.gdata.wano = GetNullableStringField(reader, "sales_order_id");
                        data.gdata.wano2 = GetNullableStringField(reader, "barcode_id");
                        data.gdata.color = GetNullableStringField(reader, "color");
                        data.gdata.fknd = GetNullableStringField(reader, "fknd");

                        data.gdata.money = GetNullableIntField(reader, "money");
                        data.gdata.money1 = GetNullableIntField(reader, "money1");
                        data.gdata.money2 = GetNullableIntField(reader, "money2");
                        data.gdata.money3 = GetNullableIntField(reader, "money3");
                        data.gdata.money4 = GetNullableIntField(reader, "money4");
                        data.gdata.money5 = GetNullableIntField(reader, "money5");
                        data.gdata.per = GetNullableIntField(reader, "per");
                        data.gdata.caseno = GetNullableStringField(reader, "caseno");
                        data.gdata.crman = GetNullableStringField(reader, "crman");
                        data.gdata.note = GetNullableStringField(reader, "note");

                        data.gdataf_new = new gdataf_new();
                        data.gdataf_new.dna = GetNullableStringField(reader, "dna");

                        data.gdatae = new gdatae();
                        data.gdatae.wna = GetNullableStringField(reader, "wna");

                        data.tww_clothes_in_factory_status = new tww_clothes_in_factory_status();
                        data.tww_clothes_in_factory_status.processing_status = GetNullableStringField(reader, "processing_status");
                        data.tww_clothes_in_factory_status.processing_time = GetNullableDateTimeField(reader, "processing_time");

                        res.Data.Add(data);
                    }
                }
            }

            return res;
        }


        public ProcessingStatusQueryRes ProcessingStatusQuery()
        {
            ProcessingStatusQueryRes res = new ProcessingStatusQueryRes();
            string sql = "";

            sql = @"
SELECT [processing_status]
FROM (
	SELECT [processing_status], CASE [processing_status] WHEN '已進廠' THEN 1  WHEN '洗衣站' THEN 2 WHEN '燙衣' THEN 3 WHEN '燙衣站' THEN 4 WHEN '出廠站' THEN 5 WHEN '後端' THEN 6 WHEN '已出廠' THEN 7 ELSE 8 END AS show_index 
		FROM (
		SELECT [processing_status]
			FROM [TwwPos].[dbo].[tww_clothes_in_factory_status] (NOLOCK)
			GROUP BY [processing_status]
			) A
		WHERE ISNULL([processing_status],'')<>''
	) B
	ORDER BY show_index
";

            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();
                command.CommandText = sql;

                SqlDataReader reader = command.ExecuteReader();
                //SelectListItem DropLst1 = new SelectListItem
                //{
                //    Text = "請選擇",
                //    Value = ""
                //};
                //res.ProcessingStatus.Add(DropLst1);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SelectListItem DropLst = new SelectListItem
                        {
                            Text = reader.GetString(0),
                            Value = reader.GetString(0)
                        };
                        res.ProcessingStatus.Add(DropLst);
                    }
                }
            }
            return res;
        }
    }
}
   
