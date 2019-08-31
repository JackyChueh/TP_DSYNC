using System;
using System.Data.SqlClient;
using TP_DSYNC.Models.Help;
using TP_DSYNC.Models.DataDefine.WEB711DATA;

namespace TP_DSYNC.Models.Implement
{
    public class MemberImplement
    {

        public ALLMEMBER MemberQuery(int sno)
        {
            ALLMEMBER allmember = null;

            string sql = @"
SELECT sno,phone,password,name,sex,birthday,city,area,zip,address,email,member_class,member_pro,totalx,point,date,code,pass,Nickname,registerId,phoneType,CardToken
	FROM ALLMEMBER
    WHERE sno=@sno
";
            SqlConnection conn = new SqlConnection(Config.Item("WEB711DATA"));
            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.Add(new SqlParameter("@sno", sno));
            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                allmember = new ALLMEMBER
                {
                    sno = (int)reader["sno"],
                    phone = reader["phone"] as string,
                    password = reader["password"] as string,
                    name = reader["name"] as string,
                    sex = reader["sex"] as int? ?? null,
                    birthday = reader["birthday"] as DateTime? ?? null,
                    city = reader["city"] as string,
                    area = reader["area"] as string,
                    zip = reader["zip"] as string,
                    address = reader["address"] as string,
                    email = reader["email"] as string,
                    member_class = reader["member_class"] as int? ?? null,
                    member_pro = reader["member_pro"] as string,
                    totalx = reader["totalx"] as int? ?? null,
                    point = reader["point"] as string,
                    date = reader["date"] as DateTime? ?? null,
                    code = reader["code"] as string,
                    pass = reader["pass"] as int? ?? null,
                    Nickname = reader["Nickname"] as string,
                    registerId = reader["registerId"] as string,
                    phoneType = reader["phoneType"] as int? ?? null,
                    CardToken = reader["CardToken"] as string
                    //send = (int)reader["send"]
                };
            }
            reader.Close();
            return allmember;
        }

    }
}