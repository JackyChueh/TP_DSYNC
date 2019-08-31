using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP_DSYNC.Models.DataDefine.TwwPos;
using TP_DSYNC.Models.Enums;
using TP_DSYNC.Models.Help;
using TWW_API.ViewModels.Clothes;
using TWW_API.ViewModels.ShopAll;
using TWW_API.ViewModels.ShopFrontSys;

namespace TP_DSYNC.Models.Implement
{
    public class PosFrontSysImplement:BaseImplement
    {
        #region 使用者
        //登入驗證
        public StoreQueryRes checkUser(StoreQueryReq UVM)
        {
            StoreQueryRes SQR = new StoreQueryRes();

                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "select  B.store_id,B.store_name ,a.name, A.password,A.add_service_role  from tww_employee as A inner join tww_store as B on  A.name=B.store_id  " +
                                          "where A.name=@Aname and A.password=@Apassword and B.store_id=@Bstore_id";

                    command.Parameters.AddWithValue("@Aname", UVM.EmpId);
                    command.Parameters.AddWithValue("@Apassword", UVM.EmpPwd);
                    command.Parameters.AddWithValue("@Bstore_id", UVM.HostId);

                    SqlDataReader reader = command.ExecuteReader();
                
                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            SQR.tww_Store.store_id = GetNullableStringField(reader, 0);
                            SQR.tww_Store.store_name = GetNullableStringField(reader, 1);
                        SQR.tww_Employee.name= GetNullableStringField(reader, 2);
                        SQR.tww_Employee.password = GetNullableStringField(reader, 3);
                        SQR.tww_Employee.id = Convert.ToInt32(UVM.EmpId);
                            SQR.tww_Employee.add_service_role = GetNullableStringField(reader, 4);
                            
                        }

                    }

                }
           
            return SQR;
        }
        public void changePassword(StoreQueryReq UVM)
        {
            

                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();
                    command.CommandText = @"Update tww_employee set password=@password where name=@name  and tww_store_id=(select id from tww_store where store_id=@hostId)";

                    command.Parameters.AddWithValue("@password", UVM.EmpPwd);
                    command.Parameters.AddWithValue("@name", UVM.EmpId);
                    command.Parameters.AddWithValue("@hostId", UVM.HostId);
                    int cnt = command.ExecuteNonQuery();
                
                    connection.Close();
                }
          

        }
        #endregion
        #region MenuBar
        public List<MenuQueryRes> MenuQuery(string per)
        {
            List<MenuQueryRes> ret = new List<MenuQueryRes>();
            string[] permission = { };
            if (per != null && per != "")
                permission = per.Split(',');
         
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "select * from FrontMenu where parent='F'";
                    SqlDataReader reader = command.ExecuteReader();

                    int i = 0;
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            MenuQueryRes res = new MenuQueryRes();
                            res.frontMenu.MenuDesc = GetNullableStringField(reader, 0);
                            res.frontMenu.MenuCode = GetNullableStringField(reader, 1);
                            res.frontMenu.Parent = GetNullableStringField(reader, 2);
                            res.frontMenu.Path = GetNullableStringField(reader, 3);
                            res.Child = ReadMenu2(res.frontMenu.MenuCode, permission);
                        res.Result.State = ResultEnum.SUCCESS;
                            ret.Add(res);

                            i++;
                        }
                    }
                }
            
         
           
            return ret;

        }
        private List<MenuQueryRes> ReadMenu2(string ID, string[] permission)
        {

            List<MenuQueryRes> ret = new List<MenuQueryRes>();
       
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "select * from FrontMenu where parent='" + ID + "'";
                    SqlDataReader reader = command.ExecuteReader();

                    int i = 0;
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {



                            MenuQueryRes res = new MenuQueryRes();
                            res.frontMenu.MenuDesc = GetNullableStringField(reader, 0);
                            res.frontMenu.MenuCode = GetNullableStringField(reader, 1);
                            res.frontMenu.Parent = GetNullableStringField(reader, 2);
                            res.frontMenu.Path = GetNullableStringField(reader, 3);
                            res.Child = ReadMenu3(res.frontMenu.MenuCode, permission);
                            ret.Add(res);

                        }

                    }
                }
          
            return ret;
        }
        private List<MenuQueryRes> ReadMenu3(string ID, string[] permission)
        {

            List<MenuQueryRes> ret = new List<MenuQueryRes>();
           
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "select * from FrontMenu where parent='" + ID + "'";
                    SqlDataReader reader = command.ExecuteReader();

                    int i = 0;
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {



                            MenuQueryRes res = new MenuQueryRes();
                            res.frontMenu.MenuDesc = GetNullableStringField(reader, 0);
                            res.frontMenu.MenuCode = GetNullableStringField(reader, 1);
                            res.frontMenu.Parent = GetNullableStringField(reader, 2);
                            res.frontMenu.Path = GetNullableStringField(reader, 3);

                            ret.Add(res);

                        }

                    }
                }
           
            return ret;
        }
        #endregion
        #region 下拉選單
        public List<SelectListItem> QueryShopItemTaxonomy(int parent)
        {
            List<SelectListItem> ShopItemTaxonomyList = new List<SelectListItem>();
            //List<ApplyType> EventTypeList = new List<ApplyType>();
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();
                    command.CommandText = "Select sno, TaxonomyName FROM ShopTaxonomy where parent = " + parent;
                    SqlDataReader reader = command.ExecuteReader();
                    int i = 0;
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            SelectListItem EventType = new SelectListItem
                            {

                                Text = GetNullableStringField(reader, 1).Trim(),
                                Value = reader.GetInt32(0).ToString()
                            };
                            ShopItemTaxonomyList.Add(EventType);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Log("Err=" + ex.Message);
            }
            return ShopItemTaxonomyList;
        }
        public List<string> TaxonomyFilter(TaxonomyFilterReq req)
        {
            List<string> snos = new List<string>();
            List<string> snoArr = new List<string>();
            if (req.T1 != "" && req.T1 != null && (req.T2 == "" || req.T2 == null))
            {
                snoArr.Add(req.T1);
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();
                    command.CommandText = "select sno from ShopTaxonomy where parent=" + req.T1;
                    SqlDataReader reader = command.ExecuteReader();
                    int i = 0;
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string a = reader.GetInt32(0).ToString();
                            snos.Add(a);

                        }

                    }
                    reader.Close();
                    for (int j = 0; j < snos.Count; j++)
                    {
                        command.CommandText = "select sno from ShopTaxonomy where parent=" + snos[j];
                        SqlDataReader reader2 = command.ExecuteReader();
                        if (reader2.HasRows)
                        {
                            while (reader2.Read())
                            {
                                snoArr.Add(reader.GetInt32(0).ToString());
                            }
                        }
                        reader2.Close();
                    }
                }

            }

            else if (req.T2 != "" && req.T2 != null && (req.T3 == "" || req.T3 == null))
            {
                snoArr.Add(req.T2);
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();
                    command.CommandText = "select sno from ShopTaxonomy where parent=" + req.T2;
                    SqlDataReader reader = command.ExecuteReader();
                    int i = 0;
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string a = reader.GetInt32(0).ToString();
                            snoArr.Add(a);
                        }
                    }
                    reader.Close();
                }
            }
            else if (req.T3 != "" && req.T3 != null)
            {
                snoArr.Add(req.T3);
            }
            return snoArr;
        }
        public List<SelectListItem> QueryOrderStatus()
        {
            List<SelectListItem> ShopItemTaxonomyList = new List<SelectListItem>();
            //List<ApplyType> EventTypeList = new List<ApplyType>();
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();
                    command.CommandText = "Select sno, OrderStatusName FROM ShopOrderStatus";
                    SqlDataReader reader = command.ExecuteReader();
                    int i = 0;
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            SelectListItem EventType = new SelectListItem
                            {

                                Text = GetNullableStringField(reader, 1).Trim(),
                                Value = reader.GetInt32(0).ToString()
                            };
                            ShopItemTaxonomyList.Add(EventType);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Log("Err=" + ex.Message);
            }
            return ShopItemTaxonomyList;
        }
        #endregion
        #region 門市設定
        //0222 設定模組-入庫位
        public TwwclothesInsiteQueryRes QueryTwwclothesInsite(TwwclothesInsiteQueryReq aModel)
        {
            TwwclothesInsiteQueryRes res = new TwwclothesInsiteQueryRes();

            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();

                /*command.CommandText = @"SELECT PD.sort_index, PD.dno as dno, PD.dna as dna, PD.insiteno as insiteno, PDi.insitena as insitena
                                        FROM (SELECT dno,dna,insiteno,sort_index FROM gdataf Where store_id = @store_id) PD LEFT JOIN 
                                        (SELECT dno,dna,insitena FROM gdataf INNER JOIN insite on gdataf.insiteno = insite.insiteno
                                        Where insite.store_id = @store_id and gdataf.store_id =@store_id) PDi on PD.dna = PDi.dna Order by PD.sort_index ASC";*/

                command.CommandText = @"SELECT Distinct PD.sort_index, PD.dno as dno, PD.dna as dna, PD.insiteno as insiteno, PDi.insitena as insitena
                                            FROM (SELECT dno,dna,insiteno,sort_index FROM gdataf_new Where store_id = @store_id) PD LEFT JOIN 
                                            (SELECT dno,dna,insitena FROM gdataf_new INNER JOIN insite on gdataf_new.insiteno = insite.insiteno
                                            Where insite.store_id = @store_id and gdataf_new.store_id =@store_id) PDi on PD.dna = PDi.dna Order by PD.sort_index ASC";

                command.Parameters.AddWithValue("@store_id", aModel.storeId);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var ClothInsiteList = new ClothesInsiteViewModel();

                        ClothInsiteList.Clothes.sort_index = reader.GetInt32(0);
                        ClothInsiteList.Clothes.dno = GetNullableStringField(reader, 1);
                        ClothInsiteList.Clothes.dna = GetNullableStringField(reader, 2);
                        ClothInsiteList.StoragePlace.insiteno = GetNullableStringField(reader, 3);
                        ClothInsiteList.StoragePlace.insitena = GetNullableStringField(reader, 4);


                        res.ClothesInsiteList.Add(ClothInsiteList);
                    }
                }
            }
            return res;
        }
        public void DelClothesMapStoragePlace(gdataf_new req)
        {


            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();

                command.CommandText = "DELETE FROM gdataf_new WHERE dno = @dno and dna = @dna and sort_index = @sort_index and store_id = @store_id";

                command.Parameters.AddWithValue("@dno", req.dno);
                command.Parameters.AddWithValue("@dna", req.dna);
                command.Parameters.AddWithValue("@sort_index", req.sort_index);
                command.Parameters.AddWithValue("@store_id", req.store_id);

                command.ExecuteNonQuery();
            }

        }
        public void AddClothesMapStoragePlace(gdataf_new req)
        {
            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();

                command.CommandText = "INSERT INTO gdataf_new (dno, dna, sort_index, store_id,insiteno) VALUES (@dno, @dna, @sort_index ,@store_id,@insiteno);";

                command.Parameters.AddWithValue("@dno", req.dno);
                command.Parameters.AddWithValue("@dna", req.dna);
                command.Parameters.AddWithValue("@sort_index", req.sort_index);
                command.Parameters.AddWithValue("@store_id", req.store_id);
                command.Parameters.AddWithValue("@insiteno", req.insiteno);
                command.ExecuteNonQuery();
            }

        }
        public void UpdateClothesMapStoragePlace(gdataf_new req)
        {
            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();
                command.CommandText = "Update gdataf_new set dna = @dna, insiteno = @insiteno, sort_index = @sort_index Where dno = @dno and store_id = @store_id";
                command.Parameters.AddWithValue("@dna", req.dna);
                command.Parameters.AddWithNullableValue("@insiteno", req.insiteno);
                command.Parameters.AddWithValue("@sort_index", req.sort_index);
                command.Parameters.AddWithValue("@store_id", req.store_id);
                command.Parameters.AddWithValue("@dno", req.dno);
                command.ExecuteNonQuery();
            }
        }
        //入庫位
        public List<insite> QueryStoragePlaces(string storeId)
        {
            List<insite> aModelList = new List<insite>();
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "select insiteno, insitena from insite where store_id=@store_id";

                    command.Parameters.AddWithValue("@store_id", storeId);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var aModel =
                                new insite
                                {
                                    insiteno = GetNullableStringField(reader, 0),
                                    insitena = GetNullableStringField(reader, 1)
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

        public void DelStoragePlace(insite aModel)
        {
            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();

                command.CommandText = "DELETE FROM insite WHERE insiteno = @insiteno and insitena = @insitena and store_id = @store_id";

                command.Parameters.AddWithValue("@insiteno", aModel.insiteno);
                command.Parameters.AddWithValue("@insitena", aModel.insitena);
                command.Parameters.AddWithValue("@store_id", aModel.store_id);

                command.ExecuteNonQuery();
            }
        }
        public void AddStoragePlace(insite aModel)
        {

            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();

                command.CommandText = "INSERT INTO insite (insiteno, insitena, store_id) VALUES (@insiteno, @insitena, @store_id);";

                command.Parameters.AddWithValue("@insiteno", aModel.insiteno);
                command.Parameters.AddWithValue("@insitena", aModel.insitena);
                command.Parameters.AddWithValue("@store_id", aModel.store_id);
                command.ExecuteNonQuery();
            }

        }
        public void UpdateStoragePlace(insite aModel)
        {

            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();

                command.CommandText = "Update insite Set insitena = @insitena Where store_id = @store_id and insiteno = @insiteno";

                command.Parameters.AddWithValue("@insitena", aModel.insitena);
                command.Parameters.AddWithValue("@store_id", aModel.store_id);
                command.Parameters.AddWithValue("@insiteno", aModel.insiteno);

                command.ExecuteNonQuery();
            }
        }
        public void UpdatePosHostConfigureModel(tww_store req)
        {
            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();

                command.CommandText = "Update tww_store set store_address=@store_address, current_invoice_number=@current_invoice_number, store_phone=@store_phone, normal_delivery=@normal_delivery, express_delivery=@express_delivery, winter_delivery=@winter_delivery, store_announcement=@store_announcement where store_id=@store_id";
                command.Parameters.AddWithNullableValue("@store_address", req.store_address);
                command.Parameters.AddWithNullableValue("@store_phone", req.store_phone);
                if (req.current_invoice_number == null)
                {
                    command.Parameters.AddWithNullableValue("@current_invoice_number", "");
                }
                else
                {
                    command.Parameters.AddWithNullableValue("@current_invoice_number", req.current_invoice_number);
                }
                command.Parameters.AddWithNullableValue("@normal_delivery", req.normal_delivery);
                command.Parameters.AddWithNullableValue("@express_delivery", req.express_delivery);
                command.Parameters.AddWithNullableValue("@winter_delivery", req.winter_delivery);
                command.Parameters.AddWithNullableValue("@store_announcement", req.store_announcement);

                command.Parameters.AddWithValue("@store_id", req.store_id);
                command.ExecuteNonQuery();
            }
        }
        //0820 - 重新計算顧客年消 reCalcThisYearTotalbyOffid
        public void ReCalcThisYearTotalbyOffid(string storeId)
        {
            int ThisYearTotal = 0;
            string[] stringArray = new string[2000];
            int i = 0;
            int maxstringarray = 0;



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
                    command.CommandText = "select manno, offno from adata where offno=@hostid";
                    command.Parameters.AddWithValue("@hostid", storeId);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            stringArray[i] = reader.GetString(0);
                            i++;

                        }
                    }
                    reader.Close();
                    for (int j = 0; j < 2000; j++)
                    {
                        if (stringArray[j] != "" && stringArray[j] != null)
                        {
                            maxstringarray = j;
                        }
                    }

                    for (int j = 0; j < maxstringarray; j++)
                    {
                        if (stringArray[j] != "" && stringArray[j] != null)
                        {

                            //從歷史收取件紀錄中計算年消

                            DateTime todaysDate = DateTime.Now.Date;
                            int thisyear = todaysDate.Year;



                            command.CommandText = "select branch_id, customer_id, sum(final_price_sum) as thisyeartotal from tww_salesorder_history where event_type in('收件','修改') and event_time > @thisyear_s and event_time < @thisyear_e and branch_id=@hostid2 and customer_id=@customer_id group by branch_id,customer_id";

                            command.Parameters.AddWithValue("@thisyear_s", thisyear + "-01-01 00:00:00");
                            command.Parameters.AddWithValue("@thisyear_e", thisyear + "-12-31 23:59:59");
                            command.Parameters.AddWithValue("@hostid2", storeId);
                            command.Parameters.AddWithValue("@customer_id", stringArray[j]);
                            Console.WriteLine("j=" + j + "  customer_id=" + stringArray[j]);
                            SqlDataReader reader2 = command.ExecuteReader();

                            if (reader2.HasRows)
                            {
                                while (reader2.Read())
                                {
                                    ThisYearTotal = reader2.GetInt32(2);
                                }
                            }
                            reader2.Close();
                            //更新年消至客戶基本資料中
                            command.CommandText = "Update adata set money1=@money where manno=@manno and offno=@offno";
                            command.Parameters.AddWithValue("@money", ThisYearTotal);
                            command.Parameters.AddWithValue("@manno", stringArray[j]);
                            command.Parameters.AddWithValue("@offno", storeId);
                            command.ExecuteNonQuery();
                            command.Parameters.Clear();
                        }
                        else
                        {
                            break;
                        }
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

        public TwwEmployeeQueryRes QueryTwwEmployee(TwwEmployeeQueryReq req)
        {
            TwwEmployeeQueryRes res = new TwwEmployeeQueryRes();
            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();

                command.CommandText = "select tww_employee.id, tww_employee.tww_store_id, tww_employee.name, tww_employee.password, " +
                                      "tww_employee.title, tww_employee.employee_name, tww_employee.is_manager, " +
                                      "tww_employee.address, tww_employee.birthday, tww_employee.identity_card, tww_employee.home_phone, tww_employee.mobile_phone " +
                                      "from tww_employee inner join tww_store on tww_employee.tww_store_id = tww_store.id  where tww_store.store_id = @store_id";

                command.Parameters.AddWithValue("@store_id", req.storeId);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        tww_employee anEmployeeModel = new tww_employee();

                        anEmployeeModel.id = reader.GetInt32(0);
                        anEmployeeModel.tww_store_id = reader.GetInt32(1);
                        anEmployeeModel.name = GetNullableStringField(reader, 2);
                        anEmployeeModel.password = GetNullableStringField(reader, 3);
                        anEmployeeModel.title = GetNullableStringField(reader, 4);
                        anEmployeeModel.employee_name = GetNullableStringField(reader, 5);
                        anEmployeeModel.is_manager = reader.GetBoolean(6);

                        anEmployeeModel.address = GetNullableStringField(reader, 7);
                        anEmployeeModel.birthday = GetNullableStringField(reader, 8);
                        anEmployeeModel.identity_card = GetNullableStringField(reader, 9);
                        anEmployeeModel.home_phone = GetNullableStringField(reader, 10);
                        anEmployeeModel.mobile_phone = GetNullableStringField(reader, 11);

                        res.EmployeeList.Add(anEmployeeModel);
                    }
                }
            }
            return res;
        }
        public void AddTwwEmployee(tww_employee aModel)
        {
            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();
                command.CommandText = @"INSERT INTO tww_employee (tww_store_id, name, password, title, employee_name, is_manager, address, birthday, identity_card, home_phone,mobile_phone)
VALUES (@tww_store_id, @name, @password, @title, @employee_name, @is_manager, @address, @birthday, @identity_card, @home_phone, @mobile_phone)";

                command.Parameters.AddWithValue("@tww_store_id", aModel.tww_store_id);
                command.Parameters.AddWithValue("@name", aModel.name);
                command.Parameters.AddWithValue("@password", aModel.password);
                command.Parameters.AddWithValue("@title", "店員");
                command.Parameters.AddWithValue("@employee_name", aModel.employee_name);
                command.Parameters.AddWithValue("@is_manager", 0);
                command.Parameters.AddWithNullableValue("@address", aModel.address);
                command.Parameters.AddWithNullableValue("@birthday", aModel.birthday);
                command.Parameters.AddWithNullableValue("@identity_card", aModel.identity_card);
                command.Parameters.AddWithNullableValue("@home_phone", aModel.home_phone);
                command.Parameters.AddWithNullableValue("@mobile_phone", aModel.mobile_phone);

                command.ExecuteNonQuery();
            }

        }
        public void UpdateTwwEmployee(tww_employee aModel)
        {
            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();
                command.CommandText = @"UPDATE tww_employee Set password=@password, employee_name=@employee_name, address=@address, birthday=@birthday, 
                                            identity_card=@identity_card, home_phone=@home_phone, mobile_phone=@mobile_phone
                                            Where tww_store_id=@tww_store_id and name =@name";

                command.Parameters.AddWithNullableValue("@password", aModel.password);
                command.Parameters.AddWithNullableValue("@employee_name", aModel.employee_name);
                command.Parameters.AddWithNullableValue("@address", aModel.address);
                command.Parameters.AddWithNullableValue("@birthday", aModel.birthday);
                command.Parameters.AddWithNullableValue("@identity_card", aModel.identity_card);
                command.Parameters.AddWithNullableValue("@home_phone", aModel.home_phone);
                command.Parameters.AddWithNullableValue("@mobile_phone", aModel.mobile_phone);
                command.Parameters.AddWithValue("@name", aModel.name);
                command.Parameters.AddWithValue("@tww_store_id", aModel.tww_store_id);

                command.ExecuteNonQuery();

            }

        }
        public void DelTwwEmployee(tww_employee aModel)
        {

            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();
                command.CommandText = @"DELETE tww_employee WHERE Id=@Id and name=@name and employee_name=@employee_name and password=@password";

                command.Parameters.AddWithValue("@Id", aModel.id);
                command.Parameters.AddWithValue("@name", aModel.name);
                command.Parameters.AddWithValue("@employee_name", aModel.employee_name);
                command.Parameters.AddWithValue("@password", aModel.password);

                command.ExecuteNonQuery();
            }

        }

        #endregion
        #region 讀取資訊
        public PosMainMenuStatisticsQueryRes QueryPosMainMenuStatistics(PosMainMenuStatisticsQueryReq aModel)
        {
            PosMainMenuStatisticsQueryRes res = new PosMainMenuStatisticsQueryRes();
            aModel.oneDay = DateTime.Today;
            QueryTotalPricesOfOneday(aModel, res.TodayStatistics);
            QueryFirstBarcodeOfOneday(aModel, res.TodayStatistics);
            QueryLastBarcodeOfOneday(aModel, res.TodayStatistics);

            QueryTotalCashInOfOneday(aModel, res.TodayStatistics);

            QueryDailyCustomerDeliveryService(aModel, res.DailyCustomerDeliveryService);
            aModel.oneDay = DateTime.Today.AddDays(-1);
            QueryTotalPricesOfOneday(aModel, res.LastWorkDayStatistics);
            QueryFirstBarcodeOfOneday(aModel, res.LastWorkDayStatistics);
            QueryLastBarcodeOfOneday(aModel, res.LastWorkDayStatistics);

            QueryTotalCashInOfOneday(aModel, res.LastWorkDayStatistics);
            return res;
        }
        private void QueryFirstBarcodeOfOneday(PosMainMenuStatisticsQueryReq req, ClothesOneDayStaticsQuery res)
        {


                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "select TOP 1 barcode_id " +
                                          "from tww_salesorder_history inner join tww_salesorder_history_details on tww_salesorder_history.id = tww_salesorder_history_details.tww_salesorder_history_id " +
                                          "where tww_salesorder_history.branch_id=@branch_id and tww_salesorder_history.event_type='收件' and tww_salesorder_history.event_time between @dayStart and @dayEnd " +
                                          "order by event_time, barcode_id";

                    command.Parameters.AddWithValue("@branch_id", req.storeId);
                    command.Parameters.AddWithValue("@dayStart", req.oneDay);
                    command.Parameters.AddWithValue("@dayEnd", req.oneDay.AddDays(1));
                    Log("SQL=" + command.CommandText);
                    Log("QueryFirstBarcodeOfOneday-Para=branch_id:" + req.storeId + " , dayStart:" + req.oneDay + " , dayEnd:" + req.oneDay.AddDays(1) + " \n");
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            res.FirstBarcode = GetNullableStringField(reader, 0);

                        }
                    }
                }
           

        }
        private void QueryLastBarcodeOfOneday(PosMainMenuStatisticsQueryReq req, ClothesOneDayStaticsQuery res)
        {

         
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "select TOP 1 barcode_id " +
                                          "from tww_salesorder_history inner join tww_salesorder_history_details on tww_salesorder_history.id = tww_salesorder_history_details.tww_salesorder_history_id " +
                                          "where tww_salesorder_history.branch_id=@branch_id and tww_salesorder_history.event_type='收件' and tww_salesorder_history.event_time between @dayStart and @dayEnd " +
                                          "order by event_time desc, barcode_id desc";

                    command.Parameters.AddWithValue("@branch_id", req.storeId);
                    command.Parameters.AddWithValue("@dayStart", req.oneDay);
                    command.Parameters.AddWithValue("@dayEnd", req.oneDay.AddDays(1));

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            res.LastBarcode = GetNullableStringField(reader, 0);

                        }
                    }
                }
          

        }

        private void QueryTotalPricesOfOneday(PosMainMenuStatisticsQueryReq req, ClothesOneDayStaticsQuery res)
        {

            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();

                /*command.CommandText = "select sum(final_price_sum), sum(processing_fee_sum), sum(receiving_number) " +
                                      "from tww_salesorder_history " +
                                      "where branch_id=@branch_id and event_type in ('收件', '修改') and event_time between @dayStart and @dayEnd ";*/

                command.CommandText = @"SELECT final_price_sum, processing_fee_sum, receiving_number  FROM (
                                          SELECT date1 AS sales_day, sum(wct) AS receiving_number, sum(gct) AS retriving_number_sum, revising_number_sum=0,
                                            sum(money) AS normal_price_summary, sum(money3) AS discount_amount_summary, sum(money2) AS additional_fee_summary, sum(money4) AS final_price_sum, sum(money5) AS processing_fee_sum,
                                            sum(money9) AS retriving_summary, sum(money6) AS cashing_in_sum
                                          FROM kdata  WHERE date1 >= @OldDateStart AND date1 < @OldDateEnd AND offno=@branch_id
                                          GROUP BY date1
                                          UNION ALL
	                                        SELECT convert(nvarchar(MAX), dateadd(DAY,0, datediff(day,0, event_time)), 112) AS sales_day, sum(receiving_number) AS receiving_number_sum, sum(retriving_number) AS retriving_number_sum, sum(revising_number) AS revising_number_sum,
		                                        sum(normal_price_sum) AS normal_price_summary, sum(discount_amount_sum) AS discount_amount_summary, sum(additional_fee_sum) AS additional_fee_summary, sum(final_price) AS final_price_sum, sum(processing_fee) AS processing_fee_sum,
		                                        sum(retriving_sum) AS retriving_summary, sum(cashing_in) AS cashing_in_sum FROM
	                                        (
		                                        SELECT event_type, receiving_number, retriving_number, revising_number, normal_price_sum, discount_amount_sum, additional_fee_sum, final_price_sum AS final_price, processing_fee_sum AS processing_fee, retriving_sum=0, cashing_in, convert(nvarchar(MAX), event_time, 24) AS event_time_string, event_time
		                                        FROM tww_salesorder_history
		                                        WHERE event_type IN ('收件', '付款', '修改', '現金折讓', '預卡優惠') AND event_time>@dayStart AND event_time <= @dayEnd AND tww_salesorder_history.branch_id = @branch_id

		                                        UNION ALL

		                                        SELECT event_type, receiving_number, retriving_number, revising_number, -normal_price_sum AS normal_price_sum, -discount_amount_sum AS discount_amount_sum, -additional_fee_sum AS additional_fee_sum, -final_price_sum AS final_price, -processing_fee_sum AS processing_fee, retriving_sum=0, -cashing_in AS cashing_in, convert(nvarchar(MAX), event_time, 24) AS event_time_string, event_time
		                                        FROM tww_salesorder_history
		                                        WHERE event_type IN ('付款(發票)作廢') AND event_time>@dayStart AND event_time <= @dayEnd AND tww_salesorder_history.branch_id = @branch_id

		                                        UNION ALL

		                                        SELECT event_type, receiving_number, retriving_number, revising_number, normal_price_sum=0, discount_amount_sum=0, additional_fee_sum=0, final_price=0, processing_fee=0, (final_price_sum+processing_fee_sum) AS retriving_sum, cashing_in, convert(nvarchar(MAX), event_time, 24) AS event_time_string, event_time
		                                        FROM tww_salesorder_history
		                                        WHERE event_type IN ('取件') AND event_time>@dayStart AND event_time <= @dayEnd AND tww_salesorder_history.branch_id = @branch_id
	                                        ) results
	                                        group by dateadd(DAY,0, datediff(day,0, event_time))
                                          ) CombineResults
                                          ORDER BY sales_day";

                command.Parameters.AddWithValue("@OldDateStart", req.oneDay.ToString("yyyyMMdd"));
                command.Parameters.AddWithValue("@OldDateEnd", req.oneDay.ToString("yyyyMMdd"));
                command.Parameters.AddWithValue("@branch_id", req.storeId);
                command.Parameters.AddWithValue("@dayStart", req.oneDay);
                command.Parameters.AddWithValue("@dayEnd", req.oneDay.AddDays(1));

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (!Convert.IsDBNull(reader[0]))
                        {
                            //onedayStatistics.TotalFinalPrice = reader.GetInt32(0);
                            res.TotalFinalPrice = Convert.ToInt32(reader.GetValue(0));
                        }

                        if (!Convert.IsDBNull(reader[1]))
                        {
                            //onedayStatistics.TotalProcessingFee = reader.GetInt32(1);
                            res.TotalProcessingFee = Convert.ToInt32(reader.GetValue(1));
                        }

                        if (!Convert.IsDBNull(reader[2]))
                        {
                            //onedayStatistics.TotalReceivingNumber = reader.GetInt32(2);
                            res.TotalReceivingNumber = Convert.ToInt32(reader.GetValue(2));
                        }

                        if (res.TotalReceivingNumber > 0)
                        {
                            res.AveragePrice = Convert.ToInt32((res.TotalFinalPrice + res.TotalProcessingFee) / res.TotalReceivingNumber);
                        }
                        else
                        {
                            res.AveragePrice = 0;
                        }
                    }
                }
            }
            
        }

        private void QueryTotalCashInOfOneday(PosMainMenuStatisticsQueryReq req, ClothesOneDayStaticsQuery res)
        {



            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();

                /*command.CommandText = "select sum(cashing_in) " +
                                      "from tww_salesorder_history " +
                                      "where branch_id=@branch_id and event_type in ('付款') and event_time between @dayStart and @dayEnd ";*/
                //0313 改成和報表一樣
                command.CommandText = @"SELECT sum(cashing_in) FROM 
	(
		SELECT cashing_in
		FROM tww_salesorder_history
		INNER JOIN adata ON adata.offno=tww_salesorder_history.branch_id AND adata.manno=tww_salesorder_history.customer_id
		WHERE event_type IN ('收件', '付款', '修改', '現金折讓', '預卡優惠') AND event_time> @dayStart  AND event_time <=@dayEnd AND tww_salesorder_history.branch_id = @branch_id

		UNION ALL

		SELECT  -cashing_in AS cashing_in
		FROM tww_salesorder_history
		INNER JOIN adata ON adata.offno=tww_salesorder_history.branch_id AND adata.manno=tww_salesorder_history.customer_id
		WHERE event_type IN ('付款(發票)作廢') AND event_time> @dayStart  AND event_time <=@dayEnd AND tww_salesorder_history.branch_id = @branch_id

		UNION ALL

		SELECT cashing_in
		FROM tww_salesorder_history
		INNER JOIN adata ON adata.offno=tww_salesorder_history.branch_id AND adata.manno=tww_salesorder_history.customer_id
		WHERE event_type IN ('取件') AND event_time> @dayStart  AND event_time <=@dayEnd AND tww_salesorder_history.branch_id = @branch_id
	) results";

                command.Parameters.AddWithValue("@branch_id", req.storeId);
                command.Parameters.AddWithValue("@dayStart", req.oneDay);
                command.Parameters.AddWithValue("@dayEnd", req.oneDay.AddDays(1));

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (!Convert.IsDBNull(reader[0]))
                        {
                            res.TotalCashIn = reader.GetInt32(0);
                        }
                    }
                }
            }
        }

        private void QueryDailyCustomerDeliveryService(PosMainMenuStatisticsQueryReq req, DailyCustomerDeliveryService res)
        {
            
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText =
                        "SELECT count(*) FROM " +
                        "(SELECT DISTINCT gdata.manno FROM gdata WHERE gdata.indoor='t' AND gdata.getw='f' AND gdata.delwano2 ='f') AS A " +
                        "INNER JOIN adata ON A.manno = adata.manno WHERE adata.offno=@branch_id AND adata.mantype='2' AND adata.company LIKE '%' + @today + '%'";


                    command.Parameters.AddWithValue("@branch_id", req.storeId);

                    int dayOfWeek = (int)req.oneDay.DayOfWeek;
                    command.Parameters.AddWithValue("@today", dayOfWeek.ToString());

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            res.TotalNumber = reader.GetInt32(0);
                        }
                    }
                }
            
        }
        public List<ClothesOverdueQuery> QueryTodayOverdueDispatchReport(PosMainMenuStatisticsQueryReq req)
        {
            List<ClothesOverdueQuery> aModel = new List<ClothesOverdueQuery>();
            string Today = DateTime.Now.ToString("yyyyMMdd");
            
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();
                    command.CommandText = @"SELECT adata.manno, adata.manna, adata.tel, wano, wano2, gdataf.dna, color, fknd, 
	                                    gdatae.wna, gdata.date1, gdata.date2, adata.money, gdata.note
	                                    FROM gdata
	                                    INNER JOIN adata ON (gdata.manno=adata.manno AND gdata.offno=adata.offno)
	                                    INNER JOIN gdataf ON gdata.dno=gdataf.dno
	                                    INNER JOIN gdatae ON gdata.wno=gdatae.wno
	                                    WHERE gdata.indoor='f' AND gdata.getw='f' AND gdata.date2 = @QueryDate AND gdata.offno=@BranchId AND gdata.typeno=2
	                                    ORDER BY gdata.date1";

                    command.Parameters.AddWithValue("@BranchId", req.storeId);
                    command.Parameters.AddWithValue("@QueryDate", Today);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ClothesOverdueQuery cModel = new ClothesOverdueQuery();

                            cModel.adata.manno = GetNullableStringField(reader, 0);
                            cModel.adata.manna = GetNullableStringField(reader, 1);
                            cModel.adata.tel = GetNullableStringField(reader, 2);
                            cModel.gdata.wano = GetNullableStringField(reader, 3);
                            cModel.gdata.wano2 = GetNullableStringField(reader, 4);
                            cModel.gdataf.dna = GetNullableStringField(reader, 5);
                            cModel.gdata.color = GetNullableStringField(reader, 6);
                            cModel.gdata.fknd = GetNullableStringField(reader, 7);
                            cModel.gdatae.wna = GetNullableStringField(reader, 8);
                            cModel.gdata.date1 = GetNullableStringField(reader, 9);
                            cModel.gdata.date2 = GetNullableStringField(reader, 10);
                            cModel.gdata.note = GetNullableStringField(reader, 12);
                            aModel.Add(cModel);
                        }
                    }
                }
       
            return aModel;
        }


        #endregion
        #region 抓取店家設定
        public StoreQueryRes QueryTwwStore(StoreQueryReq aModel)
        {
            StoreQueryRes res = new StoreQueryRes();
            
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "select store_name, store_address, store_phone, company, printer_name, invoice_printer_name, current_invoice_number, is_prepaid_allowed, prepaid_amount, prepaid_coupons, store_announcement, marque_announcement, normal_delivery, express_delivery, winter_delivery " +
                                          "from tww_store where store_id=@store_id";

                    command.Parameters.AddWithValue("@store_id", aModel.HostId);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            res.tww_Store.store_name = GetNullableStringField(reader, 0);
                            res.tww_Store.store_address = GetNullableStringField(reader, 1);
                            res.tww_Store.store_phone = GetNullableStringField(reader, 2);
                            res.tww_Store.company = GetNullableStringField(reader, 3);
                            res.tww_Store.printer_name = GetNullableStringField(reader, 4);
                            res.tww_Store.invoice_printer_name = GetNullableStringField(reader, 5);
                            res.tww_Store.current_invoice_number = GetNullableStringField(reader, 6);
                            res.tww_Store.is_prepaid_allowed = reader.GetBoolean(7);
                            res.tww_Store.prepaid_amount = reader.GetInt32(8);
                            res.tww_Store.prepaid_coupons = reader.GetInt32(9);
                            res.tww_Store.store_announcement = GetNullableStringField(reader, 10);
                            res.tww_Store.marque_announcement = GetNullableStringField(reader, 11);

                            if (!Convert.IsDBNull(reader[12]))
                                res.tww_Store.normal_delivery = reader.GetInt32(12);

                            if (!Convert.IsDBNull(reader[13]))
                                res.tww_Store.express_delivery = reader.GetInt32(13);

                            if (!Convert.IsDBNull(reader[14]))
                                res.tww_Store.winter_delivery = reader.GetInt32(14);

                        }

                        res.Result.State = ResultEnum.SUCCESS;
                    }
                }

           
            return res;
        }
        #endregion

        #region Tww_BackEnd
        public CompanyQueryRes CompanyQuery()
        {

            CompanyQueryRes Sres = new CompanyQueryRes();
            string sql = "";

            sql = @"Select comp_id,comp_name from os_company";

            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();
                command.CommandText = sql;


                
                SelectListItem DropLst1 = new SelectListItem
                {
                    Text = "請選擇公司別",
                    Value =""
                };
                Sres.CompanyList.Add(DropLst1);
                SqlDataReader reader = command.ExecuteReader();
               
                if (reader.HasRows)
                {
                
                   
                    while (reader.Read())
                    {

                        SelectListItem DropLst = new SelectListItem
                        {
                            Text = reader.GetString(1),
                            Value = reader.GetString(0)
                        };
                        Sres.CompanyList.Add(DropLst);
                    }
                }
                connection.Close();
                connection.Dispose();
            }
            return Sres;
        }
        public ChangeBackPasswordRes ChangeBackPassword(ChangeBackPasswordReq UVM)
        {
            ChangeBackPasswordRes SQR = new ChangeBackPasswordRes();

            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();
                command.CommandText = @"Update os_user set password=@password where user_id=@user_id  and comp_id=@comp_id";

                command.Parameters.AddWithValue("@password", UVM.newPassword1);
                command.Parameters.AddWithValue("@user_id", UVM.user_id);
                command.Parameters.AddWithValue("@comp_id", UVM.comp_id);
                int cnt = command.ExecuteNonQuery();
                connection.Close();
            }
            return SQR;
        }
        
        #endregion
    }
}