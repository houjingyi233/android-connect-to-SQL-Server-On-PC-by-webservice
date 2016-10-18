using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;

namespace StockManageWebservice
{
    public class DBOperation:IDisposable
    {
        public static SqlConnection sqlCon; 
     
        //将下面的引号之间的内容换成数据库的属性中的连接字符串
        private String ConServerStr = "Data Source=2013-20160523DL;Initial Catalog=test;User ID=houjingyi;Password=123456";
     
        public DBOperation()
        {
            if (sqlCon == null)
            {
                sqlCon = new SqlConnection();
                sqlCon.ConnectionString = ConServerStr;
                sqlCon.Open();
            }
        }

        public void Dispose()
        {
            if (sqlCon != null)
            {
                sqlCon.Close();
                sqlCon = null;
            }
        }
  
        //获取所有物品的信息
        public List<string> selectAllCargoInfor()
        {
            List<string> list = new List<string>();
            try
            {
                if(sqlCon.State==System.Data.ConnectionState.Closed)
                {
                    sqlCon.Open();
                }
                string sql = "select * from C";
                SqlCommand cmd = new SqlCommand(sql,sqlCon);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(reader[0].ToString());
                    list.Add(reader[1].ToString());
                    list.Add(reader[2].ToString());

                }
                reader.Close();
                cmd.Dispose();
            }
            catch(Exception)
            {
                     
            }
            return list;
        }

        //增加一条物品信息
        public bool insertCargoInfo(string Cname, int Cnum)
        {
            try
            {
                if(sqlCon.State==System.Data.ConnectionState.Closed)
                {
                    sqlCon.Open();
                }
                string sql = "insert into C (Cname,Cnum) values ('" + Cname + "'," + Cnum + ")";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //删除一条物品信息
        public bool deleteCargoInfo(string Cno)
        {
            try
            {
                if(sqlCon.State==System.Data.ConnectionState.Closed)
                {
                    sqlCon.Open();
                }
                string sql = "delete from C where Cno=" + Cno;
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}