using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TP_DSYNC.Models.DataDefine.TwwPos;
using TP_DSYNC.Models.Help;
using TWW_API.ViewModels.ApplyPhone;

namespace TP_DSYNC.Models.Implement
{
    public class PosApplyPhoneImplement:BaseImplement
    {
        public ApplyPhoneNoServiceQueryRes QueryApplyPhoneNoService(ApplyPhoneNoServiceQueryReq req)
        {
            ApplyPhoneNoServiceQueryRes res = new ApplyPhoneNoServiceQueryRes();

                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = @"Select Top 50 ApplyPhoneNo.CreateDateTime, ApplyPhoneNo.PhoneName, ApplyPhoneNo.Phone, PhoneType.ApplyTypeName, ApplyPhoneNo.Commission, ApplyPhoneNo.CommiDate, PhoneEventType.TypeName, ApplyPhoneNo.EventDateTime 
                                            FROM ApplyPhoneNo Inner Join PhoneType on ApplyPhoneNo.ApplyType = PhoneType.ApplyTypeId Inner Join PhoneEventType on ApplyPhoneNo.EventStatus = PhoneEventType.TypeId
                                            Where ApplyPhoneNo.StoreId = @StoreId Order by ApplyPhoneNo.CreateDateTime Desc";

                    command.Parameters.AddWithValue("@StoreId", req.storeId);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            CustomerApplyPhoneViewModel anEntityModel = new CustomerApplyPhoneViewModel();

                            //ApplyName = GetNullableStringField(reader, 1);
                            //ApplyPhone = GetNullableStringField(reader, 2);
                            //ApplyType = GetNullableStringField(reader, 3);
                            //    Commission = reader.GetInt16(4);
                            //    EventStatus = GetNullableStringField(reader, 6)
                            anEntityModel.applyPhoneNo.PhoneName = GetNullableStringField(reader, 1);
                            anEntityModel.applyPhoneNo.Phone = GetNullableStringField(reader, 2);
                            anEntityModel.ApplyTypeList.ApplyTypeName = GetNullableStringField(reader, 3);
                            anEntityModel.applyPhoneNo.Commission = reader.GetInt16(4);
                            anEntityModel.phoneEventType.TypeName = GetNullableStringField(reader, 6);

                            var ApplyDate = reader.GetDateTime(0);
                            anEntityModel.applyPhoneNo.CreateDateTime = ApplyDate.ToString("yyyy-MM-dd");

                            if (!Convert.IsDBNull(reader[5]))
                            {
                                anEntityModel.applyPhoneNo.CommiDate = GetNullableStringField(reader, 5);
                            }

                            if (!Convert.IsDBNull(reader[7]))
                            {
                                var EventDateTime = reader.GetDateTime(7);
                                anEntityModel.applyPhoneNo.EventDateTime = EventDateTime.ToString("yyyy-MM-dd");
                            }

                        res.QueryApplyPhoneNoList.Add(anEntityModel);
                        }
                    }
                    connection.Close();
                    connection.Dispose();
                }
            return res;
        }

        //CustomerNote
        public ApplyPhoneNoCustomerNoteQueryRes QueryApplyPhoneNoCustomerNote()
        {
         
            ApplyPhoneNoCustomerNoteQueryRes Res = new ApplyPhoneNoCustomerNoteQueryRes();
           
           
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = "SELECT ContentText FROM AddValueCustomerNote Where Type = '1'";
                
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Res.addValueCustomerNote.ContentText = HttpUtility.HtmlDecode(GetNullableStringField(reader, 0));
                        }
                    }
                    connection.Close();
                    connection.Dispose();
                }
            return Res;
        }

        //PromotionAd
        public ApplyPhonePromotionAdQueryRes QueryApplyPhonePromotionAd()
        {
            ApplyPhonePromotionAdQueryRes Res = new ApplyPhonePromotionAdQueryRes();
          
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();
                    command.CommandText = "SELECT Top 1 ContentText FROM AddValueServiceAD Where Type = '1' Order by CreateDate Desc";
                 
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Res.addValueServiceAD.ContentText = HttpUtility.HtmlDecode(GetNullableStringField(reader, 0));
                        }
                    }
                    connection.Close();
                    connection.Dispose();
                }
            return Res;
        }
        //Attention
        public ApplyPhoneAttentionNoteQueryRes QueryApplyPhoneAttentionNote()
        {
        
            ApplyPhoneAttentionNoteQueryRes res = new ApplyPhoneAttentionNoteQueryRes();
         
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();
                    command.CommandText = "SELECT Top 1 ContentText FROM AddValueAttentionNote Where Type = '1' Order by CreateDate Desc";
                  
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            res.addValueAttentionNote.ContentText = HttpUtility.HtmlDecode(GetNullableStringField(reader, 0));
                        }
                    }
                    connection.Close();
                    connection.Dispose();
                }
            return res;
        }
        public ApplyTypeQueryRes ApplyType()
        {
            ApplyTypeQueryRes res = new ApplyTypeQueryRes();
          
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();
                    command.CommandText = "SELECT ApplyTypeId, ApplyTypeName FROM PhoneType";
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            PhoneType aTypeModel = new PhoneType
                            {
                                ApplyTypeId = reader.GetByte(0),
                                ApplyTypeName = GetNullableStringField(reader, 1)
                            };
                            res.ApplyTypeModelList.Add(aTypeModel);
                        }
                    }
                    connection.Close();
                    connection.Dispose();
                }
            return res;
        }
        public ApplyPhoneNoServiceByPhoneQueryRes QueryApplyPhoneNoServiceCondition(ApplyPhoneNoServiceByPhoneQueryReq req)
        {
            ApplyPhoneNoServiceByPhoneQueryRes res = new ApplyPhoneNoServiceByPhoneQueryRes();
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();

                    command.CommandText = @"Select Top 50 ApplyPhoneNo.CreateDateTime, ApplyPhoneNo.PhoneName, ApplyPhoneNo.Phone, PhoneType.ApplyTypeName, ApplyPhoneNo.Commission, ApplyPhoneNo.CommiDate, PhoneEventType.TypeName, ApplyPhoneNo.EventDateTime  
                                            FROM ApplyPhoneNo Inner Join PhoneType on ApplyPhoneNo.ApplyType = PhoneType.ApplyTypeId Inner Join PhoneEventType on ApplyPhoneNo.EventStatus = PhoneEventType.TypeId
                                            ";
                  
                    command.Parameters.AddWithValue("@StoreId", req.storeId);
                if (req.QueryType == "1") {
                    command.CommandText += "Where ApplyPhoneNo.StoreId = @StoreId and ApplyPhoneNo.Phone  Like '%' +  @Phone + '%' Order by ApplyPhoneNo.CreateDateTime Desc";
                    command.Parameters.AddWithValue("@Phone", req.QueryKeyWord);
                }
                if (req.QueryType == "2")
                {
                    command.CommandText += "Where ApplyPhoneNo.StoreId = @StoreId and ApplyPhoneNo.PhoneName Like '%' + @Name + '%' Order by ApplyPhoneNo.CreateDateTime Desc";
                    command.Parameters.AddWithValue("@Name", req.QueryKeyWord);
                }
               
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            CustomerApplyPhoneViewModel anEntityModel = new CustomerApplyPhoneViewModel();
                            //{
                            //    ApplyName = GetNullableStringField(reader, 1),
                            //    ApplyPhone = GetNullableStringField(reader, 2),
                            //    ApplyType = GetNullableStringField(reader, 3),
                            //    Commission = reader.GetInt16(4),
                            //    EventStatus = GetNullableStringField(reader, 6)
                            //};
                            anEntityModel.applyPhoneNo.PhoneName = GetNullableStringField(reader, 1);
                            anEntityModel.applyPhoneNo.Phone = GetNullableStringField(reader, 2);
                            anEntityModel.ApplyTypeList.ApplyTypeName = GetNullableStringField(reader, 3);
                            anEntityModel.applyPhoneNo.Commission = reader.GetInt16(4);
                            anEntityModel.phoneEventType.TypeName = GetNullableStringField(reader, 6);
                            var ApplyDate = reader.GetDateTime(0);
                            anEntityModel.applyPhoneNo.CreateDateTime = ApplyDate.ToString("yyyy-MM-dd");

                            if (!Convert.IsDBNull(reader[5]))
                            {
                                anEntityModel.applyPhoneNo.CommiDate = GetNullableStringField(reader, 5);
                            }

                            if (!Convert.IsDBNull(reader[7]))
                            {
                                var EventDateTime = reader.GetDateTime(7);
                                anEntityModel.applyPhoneNo.EventDateTime = EventDateTime.ToString("yyyy-MM-dd");
                            }

                        res.QueryApplyPhoneNoList.Add(anEntityModel);
                        }
                    }
                    connection.Close();
                    connection.Dispose();
                }
            return res;
        }

        public void InsertApplyPhoneNoService(ApplyPhoneNo req)
        {
            DateTime CreateDateTime = Convert.ToDateTime(DateTime.Now.ToString());
            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();

                command.CommandText = @"INSERT INTO ApplyPhoneNo(CreateDateTime, StoreId, PhoneName, Phone, ApplyType, EventStatus)
                                            VALUES (@CreateDateTime, @StoreId, @PhoneName, @Phone, @ApplyType, @EventStatus)";
                command.Parameters.AddWithValue("@CreateDateTime", req.CreateDateTime);
                command.Parameters.AddWithValue("@StoreId", req.StoreId);
                command.Parameters.AddWithValue("@PhoneName", req.PhoneName);
                command.Parameters.AddWithValue("@Phone", req.Phone);
                command.Parameters.AddWithValue("@ApplyType", req.ApplyType);
                command.Parameters.AddWithValue("@EventStatus", "0");   //新開立

                command.ExecuteNonQuery();
            }
        }
        public void InsertApplyPhonePicture(tww_applyphone_picture req)
        {
            
                using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();
                    command.CommandText = "INSERT INTO tww_applyphone_picture (store_id, applyphone, file_name) " +
                                          "VALUES (@store_id, @applyphone, @file_name)";

                    command.Parameters.AddWithValue("@store_id", req.store_id);
                    command.Parameters.AddWithValue("@applyphone", req.applyphone);
                    command.Parameters.AddWithValue("@file_name", req.file_name);

                    command.ExecuteNonQuery();
                }
     
        }
        public PhonePicturesQueryRes GetPicturesOfApplyPhone(PhonePicturesQueryReq req)
        {
            bool result = false;
            PhonePicturesQueryRes res = new PhonePicturesQueryRes();

            using (SqlConnection connection = new SqlConnection(Config.Item("TwwPos")))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();

                command.CommandText = "select file_name from tww_applyphone_picture where store_id=@store_id and applyphone=@applyphone order by create_date DESC";
                command.Parameters.AddWithValue("@store_id", req.store_id);
                command.Parameters.AddWithValue("@applyphone", req.applyphone);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    result = true;

                    while (reader.Read())
                    {
                        tww_applyphone_picture pic = new tww_applyphone_picture();
                        pic.file_name = GetNullableStringField(reader, 0);
                        res.PhonePicturesList.Add(pic);
                    }
                }
            }
            return res;
        }

    }

}