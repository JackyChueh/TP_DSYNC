using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using TP_DSYNC.Models.DataDefine.TwwPos;
using TP_DSYNC.Models.Enums;
using TP_DSYNC.Models.Help;
using TWW_API.ViewModels.ShopAll;

namespace TP_DSYNC.Models.Implement
{
    public class ShopStockImplement: BaseImplement
    {
        #region 抓取商品列表/明細
        public List<ShopItemQueryRes> getItemList(ShopItemQueryReq shopItemQueryReq)
        {
            List<ShopItemQueryRes> SIQSLst = new List<ShopItemQueryRes>();
            
                 TaxonomyFilterReq TFR = new TaxonomyFilterReq();
            TFR.T1 = shopItemQueryReq.T1;
            TFR.T2 = shopItemQueryReq.T2;
            TFR.T3 = shopItemQueryReq.T3;
            PosFrontSysImplement SFSI = new PosFrontSysImplement();
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();
                    command.CommandText = @"Select 
                                            ShopItem.sno, ShopItem.ItemName, ShopItem.Taxonomy, ShopTaxonomy.TaxonomyName,
                                            ShopItem.ItemParent, ShopItem.ItemStatusType,ShopItem.SalesStart, ShopItem.SalesEnd,
                                            ShopItem.ItemCost, ShopItem.Price1, ShopItem.Price2, ShopStock.ViewStock, 
                                            ShopItem.ItemOrder,ShopItemImg.ImgUrl,ShopItem.CreateTime
                                            FROM ShopItem Left Join ShopItemStatusType on ShopItem.ItemStatusType = ShopItemStatusType.sno
                                                          Left Join ShopTaxonomy on ShopItem.Taxonomy = ShopTaxonomy.sno 
                                                          Left Join ShopSource on ShopItem.ItemSource = ShopSource.sno 
                                                          Left Join ShopStock on ShopItem.sno = ShopStock.ItemMapid 
                                                          Left Join ShopItemImg on ShopItem.sno = ShopItemImg.ImgMapid 
                                            Where ShopItem.ItemStatusType = 2 and  ShopItemImg.ImgMain = '1'  ";
                    List<string> snoArr = SFSI.TaxonomyFilter(TFR);
                    if (snoArr.Count > 0)
                        command.CommandText += " and  ShopItem.Taxonomy in(" + string.Join(",", snoArr) + ")";
                    if (shopItemQueryReq.keyword != "" && shopItemQueryReq.keyword != null)
                    {
                        command.CommandText += " and  (ShopItem.ItemName like '%" + shopItemQueryReq.keyword + "%' or ShopItem.ItemTansen like  '%" + shopItemQueryReq.keyword + "%')";
                    }
                    command.CommandText += " Order by  ShopItem.ItemOrder DESC";
                    Log("SQL=" + command.CommandText);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ShopItemQueryRes SIQS = new ShopItemQueryRes();
                            SIQS.shopItem.sno = reader.GetInt32(0);
                            SIQS.shopItem.ItemName = GetNullableStringField(reader, 1);
                            SIQS.shopItem.Taxonomy = reader.GetInt32(2);
                            SIQS.shopTaxonomy.TaxonomyName = GetNullableStringField(reader, 3);
                            SIQS.shopItem.ItemParent = reader.GetInt32(4);
                            SIQS.shopItem.ItemStatusType = reader.GetInt32(5);
                            SIQS.shopItem.ItemCost = reader.GetInt32(8);
                            SIQS.shopItem.Price1 = reader.GetInt32(9);
                            SIQS.shopItem.Price2 = reader.GetInt32(10);
                            SIQS.shopStock.ViewStock = reader.GetInt32(11);
                            SIQS.shopItem.ItemOrder = reader.GetInt32(12);
                            SIQS.shopItemImg.ImgUrl = GetNullableStringField(reader, 13);
                            SIQS.shopItem.CreateTime = reader.GetDateTime(14);
                            SIQS.shopItem.SalesStart = reader.GetDateTime(6).ToString("yyyy/MM/dd");
                            SIQS.shopItem.SalesEnd = reader.GetDateTime(7).ToString("yyyy/MM/dd");
                            SIQSLst.Add(SIQS);


                        }
                 
                    }
                }
            }
            catch (Exception ex)
            {
                Log("Err=" + ex.Message);
            }

            return SIQSLst;
        }

        public ShopItemQueryRes getItemDetail(ShopItemQueryReq req)
        {
           ShopItemQueryRes SIQR = new ShopItemQueryRes();
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = @"Select ShopItem.sno, ShopItem.ItemSku, ShopItem.ItemTansen, ShopItem.ItemName, ShopItem.Description, ShopItem.Taxonomy, ShopTaxonomy.TaxonomyName,
                                            ShopItem.ItemParent, ShopItem.ItemSpec, ShopItem.ItemUnit, ShopItem.ItemSource, ShopSource.SourceName, ShopItem.ItemStatusType, ShopItemStatusType.StatusName, 
                                            ShopItem.SalesStart, ShopItem.SalesEnd, ShopItem.MaxQty, ShopItem.MinQty, ShopItem.WashCost, ShopItem.StoreCommission,
                                            ShopItem.ItemCost, ShopItem.Price1, ShopItem.Price2, ShopStock.ViewStock, ShopItem.CreateTime, ShopItem.LastUpdate, ShopItem.ItemOrder, ShopStock.Vaildate,
                                            ShopItemImg.ImgUrl
                                            FROM ShopItem Left Join ShopItemStatusType on ShopItem.ItemStatusType = ShopItemStatusType.sno
                                                          Left Join ShopTaxonomy on ShopItem.Taxonomy = ShopTaxonomy.sno 
                                                          Left Join ShopSource on ShopItem.ItemSource = ShopSource.sno 
                                                          Left Join ShopStock on ShopItem.sno = ShopStock.ItemMapid 
                                                          Left Join ShopItemImg on ShopItem.sno = ShopItemImg.ImgMapid 
                                            Where ShopItem.ItemStatusType = 2 and ShopItem.sno =@sno and ShopStock.ViewStock > 0 and  ShopItemImg.ImgMain='1' Order by ShopItem.ItemOrder Asc";
                    Log("SQL=" + command.CommandText);

                    command.Parameters.AddWithValue("@sno", req.sno);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            SIQR.shopItem.sno = reader.GetInt32(0);
                            SIQR.shopItem.ItemSku = GetNullableStringField(reader, 1);
                            SIQR.shopItem.ItemTansen = GetNullableStringField(reader, 2);
                            SIQR.shopItem.ItemName = GetNullableStringField(reader, 3);
                            SIQR.shopItem.Description = HttpUtility.HtmlDecode(GetNullableStringField(reader, 4));
                            SIQR.shopItem.Taxonomy = reader.GetInt32(5);
                            SIQR.shopTaxonomy.TaxonomyName = GetNullableStringField(reader, 6);
                            SIQR.shopItem.ItemParent = reader.GetInt32(7);
                            SIQR.shopItem.ItemSpec = GetNullableStringField(reader, 8);
                            SIQR.shopItem.ItemUnit = GetNullableStringField(reader, 9);
                            SIQR.shopItem.ItemSource = reader.GetInt32(10);
                            SIQR.shopSource.SourceName = GetNullableStringField(reader, 11);
                            SIQR.shopItem.ItemStatusType = reader.GetInt32(12);
                            SIQR.shopItemStatusType.StatusName = GetNullableStringField(reader, 13);
                            SIQR.shopItem.MinQty = reader.GetInt32(17);
                            SIQR.shopItem.WashCost = reader.GetInt32(18);
                            SIQR.shopItem.StoreCommission = reader.GetInt32(19);
                            SIQR.shopItem.ItemCost = reader.GetInt32(20);
                            SIQR.shopItem.Price1 = reader.GetInt32(21);
                            SIQR.shopItem.Price2 = reader.GetInt32(22);
                            SIQR.shopStock.ViewStock = reader.GetInt32(23);
                            SIQR.shopItem.ItemOrder = reader.GetInt32(26);
                            SIQR.shopItemImg.ImgUrl = GetNullableStringField(reader, 28);
                            SIQR.shopItem.Qty = req.qty;
                            if (reader.GetInt32(16) == 0)
                            {
                                SIQR.shopItem.MaxQty = reader.GetInt32(23);
                            }
                            else
                            {
                                SIQR.shopItem.MaxQty = reader.GetInt32(16);
                            }

                            if (DateTime.Parse(reader.GetDateTime(14).ToString()).ToString("yyyy/MM/dd") == "1900/01/01")
                            {
                                SIQR.shopItem.SalesStart =null;
                            }
                            else
                            {
                                SIQR.shopItem.SalesStart = reader.GetDateTime(14).ToString("yyyy/MM/dd");
                            }

                            if (DateTime.Parse(reader.GetDateTime(15).ToString()).ToString("yyyy/MM/dd") == "1900/01/01")
                            {
                                SIQR.shopItem.SalesEnd = null;
                            }
                            else
                            {
                                SIQR.shopItem.SalesEnd = reader.GetDateTime(15).ToString("yyyy/MM/dd");
                            }

                            SIQR.shopItem.CreateTime = reader.GetDateTime(24);
                            SIQR.shopItem.LastUpdate = reader.GetDateTime(25);

                            if (reader.GetDateTime(27).ToString("yyyy/MM/dd") == "1900/01/01")
                            {
                                SIQR.shopStock.Vaildate = null;
                            }
                            else
                            {
                                SIQR.shopStock.Vaildate = reader.GetDateTime(27);
                            }
                          
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
            return SIQR;
        }
        //商品圖列表
        public ShopItemQueryRes QueryItemImageList(ShopItemQueryReq req)
        {
            ShopItemQueryRes res = new ShopItemQueryRes();
           

            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = @"Select sno,ImgUrl
                                            FROM ShopItemImg
                                            Where ShopItemImg.ImgMapid = @sno and ImgMain !='1' ";

                    command.Parameters.AddWithValue("@sno", req.sno);
                    SqlDataReader reader = command.ExecuteReader();

                   
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ShopItemImg shopItemImg = new ShopItemImg();
                            shopItemImg.ImgUrl= GetNullableStringField(reader, 1);
                            res.shopItemImgs.Add(shopItemImg);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // ignored
            }
          
            return res;
        }
        #endregion


        #region 送出訂單
     

        //確認訂購
        public ShopConfirmOrderReq ConfirmOrder(ShopConfirmOrderReq req)
        {
            int Org_ViewStock = 0;
            MailSender MS = new MailSender();


            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();

                ////////////////////////////////
                SqlTransaction transaction;
                transaction = connection.BeginTransaction();
                command.Connection = connection;
                command.Transaction = transaction;
                ///////////////////////////////
                for (int i = 0; i < req.aModel.Count; i++)
                {
                    try
                    {
                        command.Parameters.Clear();
                        //檢查: 1.上架中 2.帳面庫存大於0 3.扣除購買後帳面庫存不小於0
                        command.CommandText = @"Select ShopStock.ViewStock FROM ShopItem 
                                                Left Join ShopStock on ShopItem.sno = ShopStock.ItemMapid 
                                                Where ShopItem.ItemStatusType = '2' and ViewStock > 0 and ShopItem.sno=@sno";
                        command.Parameters.AddWithValue("@sno", req.aModel[i].shopItem.sno);
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            reader.Read();
                            Org_ViewStock = reader.GetInt32(0);
                            if ((Org_ViewStock - req.aModel[i].shopItem.Qty) < 0)
                            {
                                req.aModel[i].Result.State = ResultEnum.FAIL;
                                break;
                            }

                        }
                        else
                        {
                            req.aModel[i].Result.State = ResultEnum.FAIL;
                            break;
                        }

                        reader.Close();
                        //帳面庫存扣除
                        command.CommandText = @"Update  ShopStock set ViewStock=@ViewStock Where ItemMapid=@sno";
                        command.Parameters.AddWithValue("@ViewStock", Org_ViewStock - req.aModel[i].shopItem.Qty);
                        command.ExecuteScalar();


                        //主訂單
                        command.CommandText = @"INSERT INTO ShopOrder( OrderDate, OrderShopId, OrderTotal, OrderShopNote,OrderStatus,OrderRefound,LastUpdate,LastModify)
                                            output INSERTED.sno
                                            VALUES ( @OrderDate, @OrderShopId, @OrderTotal, @OrderShopNote, @OrderStatus, @OrderRefound, @LastUpdate, @LastModify)";

                        command.Parameters.AddWithValue("@OrderDate", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                        command.Parameters.AddWithValue("@OrderShopId", req.Editor);
                        command.Parameters.AddWithValue("@OrderTotal", req.aModel[i].shopItem.ItemCost * req.aModel[i].shopItem.Qty);
                        command.Parameters.AddWithValue("@OrderShopNote", req.CustNote==null?"": req.CustNote);
                        command.Parameters.AddWithValue("@OrderStatus", "1");
                        command.Parameters.AddWithValue("@OrderRefound", "0");
                        command.Parameters.AddWithValue("@LastUpdate", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                        command.Parameters.AddWithValue("@LastModify", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                        int Id = (int)command.ExecuteScalar();

                        //更新主訂單OrderNumber
                        string OrderNumNow = "00000";
                        command.CommandText = @"Select OrderNumNow FROM ShopOrderNumGen Where sno = '1'";
                        reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                OrderNumNow = GetNullableStringField(reader, 0);
                            }
                        }

                        reader.Close();

                        string NewNum = (int.Parse(OrderNumNow) + 1).ToString();
                        string NewOrderNum = "";
                        if (int.Parse(NewNum) + 1 > 9999)
                        {
                            NewNum = "00000";
                        }
                        NewOrderNum = DateTime.Now.ToString("yyyyMMdd") + NewNum.PadLeft(5, '0');
                        command.CommandText = @"Update  ShopOrder set OrderNum=@OrderNum Where sno=@snoid";
                        command.Parameters.AddWithValue("@snoid", Id);
                        command.Parameters.AddWithValue("@OrderNum", NewOrderNum);
                        command.ExecuteScalar();

                        command.CommandText = @"Update  ShopOrderNumGen set OrderNumNow=@OrderNumNow Where sno='1'";
                        command.Parameters.AddWithValue("@OrderNumNow", NewNum.PadLeft(5, '0'));
                        command.ExecuteScalar();

                        //副訂單
                        command.CommandText = @"INSERT INTO ShopOrderItem(ItemOrderId,ItemId,ItemrId,ItemSku,ItemTansen,ItemName,ItemSpec,ItemUnit,ItemSource,ItemMapBatchId,ItemBatchId,
                                            ItemCost,ItemPrice1,ItemPrice2,WashCost,StoreCommission,Qty,ItemRefund,ItemRefundReason)
                                            output INSERTED.sno
                                            VALUES (@ItemOrderId,@ItemId,@ItemrId,@ItemSku,@ItemTansen,@ItemName,@ItemSpec,@ItemUnit,@ItemSource,@ItemMapBatchId,@ItemBatchId,@ItemCost,@ItemPrice1,@ItemPrice2,@WashCost,@StoreCommission,@Qty,@ItemRefund,@ItemRefundReason)";
                        Log("SQL=" + command.CommandText);
                        command.Parameters.AddWithValue("@ItemOrderId", Id);
                        command.Parameters.AddWithValue("@ItemId", req.aModel[i].shopItem.sno);
                        command.Parameters.AddWithValue("@ItemrId", req.aModel[i].shopItem.sno);
                        command.Parameters.AddWithValue("@ItemSku", req.aModel[i].shopItem.ItemSku == null ? "" : req.aModel[i].shopItem.ItemSku);
                        command.Parameters.AddWithValue("@ItemTansen", req.aModel[i].shopItem.ItemTansen);
                        command.Parameters.AddWithValue("@ItemName", req.aModel[i].shopItem.ItemName);
                        command.Parameters.AddWithValue("@ItemSpec", req.aModel[i].shopItem.ItemSpec);
                        command.Parameters.AddWithValue("@ItemUnit", req.aModel[i].shopItem.ItemUnit);
                        command.Parameters.AddWithValue("@ItemSource", req.aModel[i].shopItem.ItemSource);
                        command.Parameters.AddWithValue("@ItemMapBatchId", "");
                        command.Parameters.AddWithValue("@ItemBatchId", "");
                        command.Parameters.AddWithValue("@ItemCost", req.aModel[i].shopItem.ItemCost);
                        command.Parameters.AddWithValue("@ItemPrice1", req.aModel[i].shopItem.Price1);
                        command.Parameters.AddWithValue("@ItemPrice2", req.aModel[i].shopItem.Price2);
                        command.Parameters.AddWithValue("@WashCost", req.aModel[i].shopItem.WashCost);
                        command.Parameters.AddWithValue("@StoreCommission", req.aModel[i].shopItem.StoreCommission);
                        command.Parameters.AddWithValue("@Qty", req.aModel[i].shopItem.Qty);
                        command.Parameters.AddWithValue("@ItemRefund", "0");
                        command.Parameters.AddWithValue("@ItemRefundReason", "");
                        int mId = (int)command.ExecuteScalar();

                        Log("SQL=" + command.CommandText);

                        //銷貨主單 ShopStockSellMain
                        command.CommandText = @"INSERT INTO ShopStockSellMain(SellMDesc, UpdateTime, UserId, OrderId)
                                            output INSERTED.sno
                                            VALUES (@SellMDesc, @UpdateTime, @UserId, @OrderId)";

                        command.Parameters.AddWithValue("@SellMDesc", "");
                        command.Parameters.AddWithValue("@UpdateTime", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                        command.Parameters.AddWithValue("@UserId", req.Editor);
                        command.Parameters.AddWithValue("@OrderId", Id);
                        int sId = (int)command.ExecuteScalar();

                        //銷貨明細單 ShopStockSellDetail
                        command.CommandText = @"INSERT INTO ShopStockSellDetail(SellDMapMId, SellDMapId, Qty, UpdateTime,UserId,[Type],Note)
                                            output INSERTED.sno
                                            VALUES (@SellDMapMId, @SellDMapId, @Qty2, @UpdateTime2,@UserId2,@Type2,@Note2)";

                        command.Parameters.AddWithValue("@SellDMapMId", sId);
                        command.Parameters.AddWithValue("@SellDMapId", "");
                        command.Parameters.AddWithValue("@Qty2", req.aModel[i].shopItem.Qty);
                        command.Parameters.AddWithValue("@UpdateTime2", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                        command.Parameters.AddWithValue("@UserId2", req.Editor);
                        command.Parameters.AddWithValue("@Type2", "1");
                        command.Parameters.AddWithValue("@Note2", "");
                        int smId = (int)command.ExecuteScalar();

                        reader.Close();

                        //取得訂單成立收件者列表
                        string EsEMailList = "";
                        command.CommandText = @"Select EsEMailList FROM ShopEmailSetting Where sno = '1'";
                        Log("SQL=" + command.CommandText);

                        reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                EsEMailList = GetNullableStringField(reader, 0);
                            }
                        }

                        reader.Close();

                        ////////////////////////////////
                        if (Id > 0 && mId > 0 && sId > 0 && smId > 0)
                        {
                            

                            //寄發信件
                            command.CommandText = @"Select SourceMailList FROM ShopSource Where ShopSource.sno=@OrderItemSource";
                            command.Parameters.AddWithValue("@OrderItemSource", req.aModel[i].shopItem.ItemSource);
                            Log("SQL=" + command.CommandText);

                            reader = command.ExecuteReader();

                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    EsEMailList += "," + GetNullableStringField(reader, 0);
                                }
                            }
                            reader.Close();
                            string[] EsEMailListArray = EsEMailList.Split(',');
                            MS.Mail_Send("twwpos_service@taiwantaxi.com.tw", EsEMailListArray, "[台灣大洗衣POS-商品銷售訂單成立通知]", "您好:<br>已收到一筆新成立訂單，編號:" + NewOrderNum + "，請至<a href='https://posadmin.tww.com.tw'>POSAdmin</a>確認！", true);
                            req.aModel[i].Result.State = ResultEnum.SUCCESS;
                        }
                        else
                        {
                            transaction.Rollback();
                        }


                        ////////////////////////////////

                       
                    }

                    catch (Exception ex)
                    {
                        req.aModel[i].Result.State = ResultEnum.FAIL;
                        transaction.Rollback();
                        throw;
                    }
                   
                }
                transaction.Commit();
                connection.Close();
                connection.Dispose();
            }
              

            
            return req;
        }


        #endregion

        #region 訂單


        //訂單狀態下拉式選單
        public ShopOrderStatusQueryRes QueryShopOrderStatus()
        {

            ShopOrderStatusQueryRes Sres = new ShopOrderStatusQueryRes();
            string sql = "";

            sql = @"Select * from ShopOrderStatus";
    
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();
                    command.CommandText = sql;

                  
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        List<ShopOrderStatus> OrderStatus = new List<ShopOrderStatus>();
                        ShopOrderStatus DropLst1 = new ShopOrderStatus
                        {
                            OrderStatusName = "全選",
                            sno = 99
                        };
                    Sres.ShopOrderStatus.Add(DropLst1);
                        while (reader.Read())
                        {

                            ShopOrderStatus DropLst = new ShopOrderStatus
                            {
                                OrderStatusName = reader.GetString(1),
                                sno = reader.GetInt32(0)
                            };
                        Sres.ShopOrderStatus.Add(DropLst);



                        }
                    }
                    connection.Close();
                    connection.Dispose();
                }
            return Sres;
        }
        //訂單列表
        public List<ShopOrderQueryRes> QueryShopOrderList(ShopOrderQueryReq aModel)
        {
            string strDateStart = "";
            string strDateEnd = "";
            string thisyearms = "";
            string thisyearme = "";
            string sql = "";

            sql = @"Select ShopOrder.sno, ShopOrder.OrderNum, ShopOrder.OrderDate, ShopOrder.OrderShopId, ShopOrder.OrderShopNote, ShopOrder.OrderCtoSNote, ShopOrder.OrderStatus, ShopOrderStatus.OrderStatusName, ShopOrder.OrderTotal,
                           ShopOrderItem.sno, ShopOrderItem.ItemOrderId, ShopOrderItem.ItemId, ShopOrderItem.ItemrId, ShopOrderItem.ItemSku, ShopOrderItem.ItemTansen, ShopOrderItem.ItemName, ShopOrderItem.ItemSpec, ShopOrderItem.ItemUnit,
                           ShopOrderItem.ItemSource, ShopOrderItem.ItemMapBatchId, ShopOrderItem.ItemBatchId, ShopOrderItem.ItemCost, ShopOrderItem.ItemPrice1, ShopOrderItem.ItemPrice2, ShopOrderItem.WashCommission, ShopOrderItem.StoreCommission, 
                           ShopOrderItem.Qty, ShopOrderItem.ItemRefund, ShopOrderItem.ItemRefundReason,IIF((ShopOrder.OrderStatus='7' and ShopOrder.CompeleteDate+7>GETDATE() and ShopItem.isAllowRefund='T'),'true','false') as isAllowRefund ,DeliveryNum 
                           FROM ShopOrder Left Join ShopOrderStatus on ShopOrder.OrderStatus = ShopOrderStatus.sno  Left Join ShopOrderItem on ShopOrder.sno = ShopOrderItem.ItemOrderId Left Join ShopItem on ShopOrderItem.ItemId=ShopItem.sno
                           Where OrderShopId = @hostid ";


            List<ShopOrderQueryRes> res = new List<ShopOrderQueryRes>();
            //查詢(關鍵字、日期區間)
            if (aModel.Keyrange == "0")
            {

                CultureInfo enUS = new CultureInfo("en-US");
                DateTime dateStart, dateEnd;
                DateTime.TryParseExact(aModel.StartDay, "yyyyMMdd", enUS, DateTimeStyles.None, out dateStart);
                DateTime.TryParseExact(aModel.EndDay, "yyyyMMdd", enUS, DateTimeStyles.None, out dateEnd);


                if (aModel.StartDay != null && aModel.StartDay != "")
                {
                    strDateStart = dateStart.ToString("yyyy-MM-dd 00:00:00");

                    sql += @" and ShopOrder.OrderDate >= @StartDay ";
                }

                if (aModel.EndDay != null && aModel.EndDay != "")
                {
                    strDateEnd = dateEnd.ToString("yyyy-MM-dd 23:59:59");
                    sql += @"  and ShopOrder.OrderDate <= @EndDay";
                }
                if (aModel.Keyword != null && aModel.Keyword != "")
                {
                    sql += @" and (ShopOrderItem.ItemName like '%" + aModel.Keyword + "%' or ShopOrder.OrderNum like '%" + aModel.Keyword + "%' ) ";
                }

                if (aModel.OrderStatus != "" && aModel.OrderStatus != null && aModel.OrderStatus != "111" && aModel.OrderStatus != "222" && aModel.OrderStatus != "99")
                {
                    sql += " and ShopOrder.OrderStatus='" + aModel.OrderStatus + "'";
                }
                if (aModel.OrderRefound != "" && aModel.OrderRefound != null && aModel.OrderRefound != "2" && aModel.OrderRefound != "99")
                {
                    sql += " and ShopOrder.OrderRefound='" + aModel.OrderRefound + "'";
                }
            }
            //按鈕
            else
            {
                //全部
                if (aModel.Keyrange == "1")
                {
                    thisyearms = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd");
                }
                else if (aModel.Keyrange == "3")
                {
                    thisyearms = DateTime.Now.AddMonths(-3).ToString("yyyy-MM-dd");
                }
                else if (aModel.Keyrange == "6")
                {
                    thisyearms = DateTime.Now.AddMonths(-6).ToString("yyyy-MM-dd");
                }
                else if (aModel.Keyrange == "12")
                {
                    thisyearms = DateTime.Now.AddMonths(-12).ToString("yyyy-MM-dd");
                }

                if (aModel.Keyrange == "99")
                {
                    strDateStart = "";
                    strDateEnd = "";
                }
                else
                {
                    thisyearme = DateTime.Now.ToString("yyyy-MM-dd");
                    strDateStart = thisyearms + " 00:00:00";
                    strDateEnd = thisyearme + " 23:59:59";
                    sql += @" and ShopOrder.OrderDate >= @StartDay and ShopOrder.OrderDate <= @EndDay";
                }

            }

            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    if (strDateStart != "")
                    {
                        command.Parameters.AddWithValue("@StartDay", strDateStart);
                    }
                    if (strDateEnd != "")
                    {
                        command.Parameters.AddWithValue("@EndDay", strDateEnd);
                    }
                    command.CommandText = sql + " Order by ShopOrder.sno Desc";

                    Log("SQL=" + command.CommandText);
                    command.Parameters.AddWithValue("@hostid", aModel.LoginCmdModel.tww_Store.store_id);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            ShopOrderQueryRes anEntityModel = new ShopOrderQueryRes();

                            anEntityModel.shopOrder.sno = reader.GetInt32(0);
                            anEntityModel.shopOrder.OrderNum = GetNullableStringField(reader, 1);
                            anEntityModel.shopOrder.OrderShopId = GetNullableStringField(reader, 3);
                            anEntityModel.shopOrder.OrderShopNote = GetNullableStringField(reader, 4);
                            anEntityModel.shopOrder.OrderCtoSNote = GetNullableStringField(reader, 5);
                            anEntityModel.shopOrder.OrderStatus = reader.GetInt32(6);
                            anEntityModel.shopOrderStatus.OrderStatusName = GetNullableStringField(reader, 7);
                            anEntityModel.shopOrder.OrderTotal = reader.GetInt32(8);
                            anEntityModel.shopOrderItem.sno = reader.GetInt32(9);
                            anEntityModel.shopOrderItem.ItemOrderId = reader.GetInt32(10);
                            anEntityModel.shopOrderItem.ItemId = reader.GetInt32(11);
                            anEntityModel.shopOrderItem.ItemrId = reader.GetInt32(12);
                            anEntityModel.shopOrderItem.ItemSku = GetNullableStringField(reader, 13);
                            anEntityModel.shopOrderItem.ItemTansen = GetNullableStringField(reader, 14);
                            anEntityModel.shopOrderItem.ItemName = GetNullableStringField(reader, 15);
                            anEntityModel.shopOrderItem.ItemSpec = GetNullableStringField(reader, 16);
                            anEntityModel.shopOrderItem.ItemUnit = GetNullableStringField(reader, 17);
                            anEntityModel.shopOrderItem.ItemSource = reader.GetInt32(18);
                            anEntityModel.shopOrderItem.ItemMapBatchId = reader.GetInt32(19);
                            anEntityModel.shopOrderItem.ItemBatchId = GetNullableStringField(reader, 20);
                            anEntityModel.shopOrderItem.ItemCost = reader.GetInt32(21);
                            anEntityModel.shopOrderItem.ItemPrice1 = reader.GetInt32(22);
                            anEntityModel.shopOrderItem.ItemPrice2 = reader.GetInt32(23);
                           // anEntityModel.shopOrderItem.WashCommission = reader.GetInt32(24);
                            anEntityModel.shopOrderItem.StoreCommission = reader.GetInt32(25);
                            anEntityModel.shopOrderItem.Qty = reader.GetInt32(26);
                            anEntityModel.shopOrderItem.ItemRefund = reader.GetInt32(27);
                            anEntityModel.shopOrderItem.ItemRefundReason = GetNullableStringField(reader, 28);
                            anEntityModel.isAllowRefund = Convert.ToBoolean(GetNullableStringField(reader, 29));
                            anEntityModel.shopOrder.DeliveryNum = GetNullableStringField(reader, 30);
                            

                            var dt = reader.GetDateTime(2);
                            anEntityModel.shopOrder.OrderDate = dt;
                            anEntityModel.OrderDate = dt.ToString("yyyy/MM/dd");
                            anEntityModel.Result.State = ResultEnum.SUCCESS;
                            res.Add(anEntityModel);
                        }
                    }
                    connection.Close();
                    connection.Dispose();
                }
            }
            catch (Exception ex)
            {
                ShopOrderQueryRes errm = new ShopOrderQueryRes();
                errm.Result.State = ResultEnum.FAIL;
                res.Add(errm);
                Log("Err=" + ex.Message);
            }
            return res;
        }


        //取消訂單
        public ShopOrderQueryRes CancelOrder(ShopOrderQueryRes aModel)
        {
            int Org_ViewStock = 0;
            int mId = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    ////////////////////////////////
                    SqlTransaction transaction;
                    transaction = connection.BeginTransaction();
                    command.Connection = connection;
                    command.Transaction = transaction;
                    ///////////////////////////////

                    //檢查: 訂單狀態為1 訂單成立才可以取消訂單
                    command.CommandText = @"Select ShopOrder.sno FROM ShopOrder
                                            Where ShopOrder.OrderStatus = '1' and ShopOrder.sno=@sno";
                    command.Parameters.AddWithValue("@sno", aModel.shopOrder.sno);
                    SqlDataReader reader = command.ExecuteReader();

                    if (!reader.HasRows)
                    {
                        aModel.Result.State = ResultEnum.FAIL;
                        return aModel;
                    }

                    reader.Close();

                    //更新為取消訂單
                    command.CommandText = @"Update ShopOrder set OrderStatus=@OrderStatus Where ShopOrder.sno=@sno";
                    command.Parameters.AddWithValue("@OrderStatus", "3");
                    int Id = (int)command.ExecuteNonQuery();

                    //復原ViewStock庫存
                    command.CommandText = @"Select ShopStock.ViewStock FROM ShopItem 
                                                Left Join ShopStock on ShopItem.sno = ShopStock.ItemMapid 
                                                Where ShopItem.ItemStatusType != '4' and ViewStock > 0 and ShopStock.ItemMapid=@ItemMapid";
                    command.Parameters.AddWithValue("@ItemMapid", aModel.shopOrderItem.ItemId);
                    reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        Org_ViewStock = reader.GetInt32(0);
                        reader.Close();

                        //帳面庫存扣除
                        command.CommandText = @"Update  ShopStock set ViewStock=@ViewStock Where ItemMapid=@ItemMapid";
                        command.Parameters.AddWithValue("@ViewStock", Org_ViewStock + aModel.shopOrderItem.Qty);
                        mId = (int)command.ExecuteNonQuery();
                    }
                    else
                    {
                        //商品是已下架狀態不更動庫存
                        mId = 1;
                    }

                    ////////////////////////////////
                    if (Id > 0 & mId > 0)
                    {
                        transaction.Commit();
                      //  aModel.RunStatus = true;
                    }
                    else
                    {
                        transaction.Rollback();
                     //   aModel.RunStatus = false;
                    }
                    ////////////////////////////////

                    connection.Close();
                    connection.Dispose();
                }
                aModel.Result.State = ResultEnum.SUCCESS;
            }
            catch (Exception ex)
            {
                aModel.Result.State = ResultEnum.FAIL;
                Log("Err=" + ex.Message);
            }
            return aModel;
        }


        //商品銷售 - 獲取最大商品數量
        public int getMaxQty(String ItemId)
        {
            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                int MaxQty = 0;
                try
                {
                    connection.Open();
                    command.CommandText = @"select MaxQty FROM ShopItem Where sno='" + ItemId + "'";

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            MaxQty = reader.GetInt32(0);

                        }
                    }
                    reader.Close();
                    reader.Dispose();

                    connection.Close();
                    connection.Dispose();
                }
                catch (Exception ex)
                {

                }
                return MaxQty;
            }
        }
        //商品銷售-獲取最小購買數量
        public int getMinQty(String ItemId)
        {
            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                int MinQty = 0;
                try
                {
                    connection.Open();
                    command.CommandText = @"select MinQty FROM ShopItem Where sno='" + ItemId + "'";

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            MinQty = reader.GetInt32(0);

                        }
                    }
                    reader.Close();
                    reader.Dispose();

                    connection.Close();
                    connection.Dispose();
                }
                catch (Exception ex)
                {

                }
                return MinQty;
            }
        }

        //商品銷售 - 修改訂單商品數量
        public ShopOrderQueryRes ShopItemQtyUpdate(ShopOrderQueryRes aModel)
        {
            int res = 0;
            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                try
                {
                    connection.Open();
                    command.CommandText = @"select ShopStock.ViewStock,ShopStockSellDetail.Qty FROM ShopStock,ShopStockSellDetail Where ShopStock.ItemMapid = @ItemMapid and ShopStockSellDetail.SellDMapMId=@sno";
                    command.Parameters.AddWithValue("@ItemMapid", aModel.shopOrderItem.ItemId);
                    command.Parameters.AddWithValue("@sno", aModel.shopOrder.sno);

                    SqlDataReader reader = command.ExecuteReader();
                    int nowvstock = 0;
                    int oriQty = 0;
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            nowvstock = reader.GetInt32(0);
                            oriQty = reader.GetInt32(1);

                        }
                    }
                    reader.Close();
                    reader.Dispose();
                    if ((nowvstock - (aModel.shopOrderItem.Qty - oriQty)) < 0)
                    {
                        aModel.Result.State = ResultEnum.OrderError1;
                        return aModel;
                    }
                    command.CommandText = @"Update ShopOrder set OrderTotal=@OrderTotal,LastUpdate=getdate() where sno=@sno;
                                            Update ShopStockSellDetail set Qty=@Qty from ShopStockSellMain as b where SellDMapMId=b.sno and b.OrderId=@sno and [Type]='1';;
                                            Update ShopStock set ViewStock=@ViewStock,UpdateTime=getdate()  where ItemMapid=@ItemId;
                                            Update ShopOrderItem set Qty=@Qty where ItemOrderId=@sno;";
                    command.Parameters.AddWithValue("@hostid", aModel.UserId);
                    command.Parameters.AddWithValue("@OrderTotal", aModel.shopOrder.OrderTotal);
                    command.Parameters.AddWithValue("@OrderNum", aModel.shopOrder.OrderNum);
                    int newqty = nowvstock - (aModel.shopOrderItem.Qty - oriQty);
                    command.Parameters.AddWithValue("@Qty", aModel.shopOrderItem.Qty);
                    command.Parameters.AddWithValue("@ViewStock", newqty);

                    command.Parameters.AddWithValue("@ItemId", aModel.shopOrderItem.ItemId);



                    Log("SQL=" + command.CommandText);

                    command.ExecuteNonQuery();
                    connection.Close();
                    connection.Dispose();
                    aModel.Result.State = ResultEnum.SUCCESS;
                }
                catch (Exception ex)
                {
                    aModel.Result.State = ResultEnum.OrderError2;
                    Log("Err=" + ex.Message);
                }
                return aModel;
            }
        }
        //商品銷售 - 退貨功能
        public ShopOrderQueryRes ShopOrderRefund(ShopOrderQueryRes aModel)
        {
          
            string refundOrderNum = aModel.shopOrder.OrderNum + "r";
            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                try
                {
                    string MailAddrs = "";
                    connection.Open();
                    command.CommandText = @"insert into ShopOrder (OrderNum,OrderDate,OrderShopId,OrderTotal,OrderStatus,OrderRefound,LastUpdate,LastModify) OUTPUT  inserted.sno select
                                @NewOrderNum,GETDATE(),@hostid,@OrderTotal,'9','1',GETDATE(),GETDATE() from ShopOrder where OrderNum=@OrderNum; ";

                    command.Parameters.AddWithValue("@NewOrderNum", refundOrderNum);
                    command.Parameters.AddWithValue("@hostid", aModel.UserId);
                    command.Parameters.AddWithValue("@OrderTotal", aModel.shopOrder.OrderTotal);
                    command.Parameters.AddWithValue("@OrderNum", aModel.shopOrder.OrderNum);

                    SqlDataReader reader = command.ExecuteReader();
                    int sno = 0;
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            sno = reader.GetInt32(0);
                        }
                    }


                    reader.Close();
                    reader.Dispose();
                    command.CommandText = @"
                                insert into ShopOrderItem 
                                (ItemOrderId,ItemId,ItemrId,ItemSku,ItemTansen,ItemName,ItemSpec,ItemUnit,ItemSource,ItemMapBatchId,ItemBatchId,ItemCost,ItemPrice1,ItemPrice2,WashCommission,StoreCommission,Qty,ItemRefund,ItemRefundReason)select
                                     a.sno,b.sno,b.sno,b.ItemSku,b.ItemTansen,b.ItemName,b.ItemSpec,b.ItemUnit,b.ItemSource ,0,'',b.ItemCost,b.Price1,b.Price2 ,b.WashCommission,b.StoreCommission,@Qty,1 ,@RefundReason from ShopOrder as a ,ShopItem as b where a.sno=@sno and b.sno=@bsno
                                ";
                    Log("SQL=" + command.CommandText);

                    command.Parameters.AddWithValue("@sno", sno);
                    command.Parameters.AddWithValue("@bsno", aModel.shopOrderItem.ItemId);

                    command.Parameters.AddWithValue("@Qty", aModel.shopOrderItem.Qty);
                    command.Parameters.AddWithValue("@RefundReason", aModel.shopOrderItem.ItemRefundReason == null ? "" : aModel.shopOrderItem.ItemRefundReason);

                    command.ExecuteNonQuery();
                    command.CommandText = @"Select a.SourceMailList,c.EsEMailList FROM ShopSource as a join ShopItem as b on a.sno=b.ItemSource left join ShopEmailSetting as c on c.EsMapStatusId='9' Where b.ItemTansen=@ItemTansen";

                    command.Parameters.AddWithValue("@ItemTansen", aModel.shopOrderItem.ItemTansen);
                    reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            MailAddrs = GetNullableStringField(reader, 0);
                            MailAddrs += "," + GetNullableStringField(reader, 1);
                        }
                    }

                    connection.Close();
                    connection.Dispose();

                    string[] MailAddresses = MailAddrs.Split(',');
                    MailSender MS = new MailSender();
                    MS.Mail_Send("twwpos_service@taiwantaxi.com.tw", MailAddresses, "[台灣大洗衣POS-商品銷售退貨通知]", "您好:<br>已收到一筆新退貨，編號:" + refundOrderNum + "，請至請至<a href='https://posadmin.tww.com.tw'>POSAdmin</a>確認！", true);
                    aModel.Result.State = ResultEnum.SUCCESS;
                }
                catch (Exception ex)
                {
                    aModel.Result.State = ResultEnum.FAIL;
                    Log("Err=" + ex.Message);
                }
                return aModel;
            }
        }
        public ShopConfirmOrderReq checkStock(ShopConfirmOrderReq req)
        {

            int Org_ViewStock = 0;
            string orderid = "";

            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();

                ////////////////////////////////
                SqlTransaction transaction;
                transaction = connection.BeginTransaction();
                command.Connection = connection;
                command.Transaction = transaction;
                try
                {

                  
                    ///////////////////////////////
                    for (int i = 0; i < req.aModel.Count; i++)
                    {
                        //檢查: 1.上架中 2.帳面庫存大於0 3.扣除購買後帳面庫存不小於0
                        command.CommandText = @"Select ShopStock.ViewStock FROM ShopItem 
                                                Left Join ShopStock on ShopItem.sno = ShopStock.ItemMapid 
                                                Where ShopItem.ItemStatusType = '2' and ViewStock > 0 and ShopItem.sno=@sno";
                        command.Parameters.AddWithValue("@sno", req.aModel[i].shopItem.sno);
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            reader.Read();
                            Org_ViewStock = reader.GetInt32(0);
                            if ((Org_ViewStock - req.aModel[i].shopItem.Qty) < 0)
                            {
                                req.aModel[i].Result.State = ResultEnum.OrderError1;
                                // break;
                            }
                            else
                            {
                                req.aModel[i].Result.State = ResultEnum.SUCCESS;
                            }
                        }
                        else
                        {
                            req.aModel[i].Result.State = ResultEnum.OrderError1;
                        }
                    }
                }

                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;

                }
            }
            return req;
        }
        #endregion



    }
}