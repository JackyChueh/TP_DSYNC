using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TWW_API.ViewModels.OutsourcingSys;
using System.Data;
using System.Data.SqlClient;
using TP_DSYNC.Models.Help;
using TP_DSYNC.Models.DataDefine.TwwPos;

namespace TP_DSYNC.Models.Implement
{
    public class OutsouringSysImplement : BaseImplement
    {
        public UserLoginRes UserLogin(UserLoginReq req)
        {
            UserLoginRes res = new UserLoginRes();

            List<SqlParameter> paras = new List<SqlParameter>();
            string sql = @"
SELECT  A.[comp_id],A.[user_id],A.[user_name],B.[group_id]
  FROM [TwwPos].[dbo].[os_user] A INNER JOIN [TwwPos].[dbo].[os_group_user] B ON A.[comp_id]=B.[comp_id] AND A.[user_id]=B.[user_id]
  WHERE  A.[comp_id]=@comp_id AND A.[user_id]=@user_id AND A.[password]=@password
";
            paras.Add(new SqlParameter("@comp_id", req.comp_id)); 
            paras.Add(new SqlParameter("@user_id", req.user_id));
            paras.Add(new SqlParameter("@password", req.password));

            using (SqlConnection conn = new SqlConnection(Config.Item("TwwPos")))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddRange(paras.ToArray());
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        res.LoginChecked = true;

                        os_user user = new os_user()
                        {
                            comp_id = req.comp_id,
                            user_id = req.user_id,
                            user_name = reader["user_name"] as string
                        };
                        res.os_user = user;

                        os_group_user gu = new os_group_user()
                        {
                            group_id = reader["group_id"] as string
                        };
                        res.os_group_user = gu;
                    }
                }
            }

            return res;
        }
    }
}