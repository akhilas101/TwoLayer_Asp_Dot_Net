using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace TwoLayerExample
{

    public class ConnectionClass
    {
        SqlConnection con;
        SqlCommand cmd;

        public ConnectionClass()
        {
            con = new SqlConnection(@"server=DESKTOP-KAI9EEB\SQLEXPRESS; database=TwoLayer;Integrated security=true");
        }

        public int Fun_exenonquery(string sqlquery)// insert, delete,update
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            cmd = new SqlCommand(sqlquery, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        // scalar

        public string Fun_exescalar(string sqlquery)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            cmd = new SqlCommand(sqlquery, con);
            con.Open();
            String s = cmd.ExecuteScalar().ToString();
            con.Close();
            return s;
        }

        // Reader
        public SqlDataReader Fun_exeReader(string sqlquery)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            cmd = new SqlCommand(sqlquery, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        // Dataset
        public DataSet Fun_exeAdapter(string sqlquery)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            SqlDataAdapter da = new SqlDataAdapter(sqlquery, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataTable Fun_Exedatatable(string sqlquery)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            SqlDataAdapter da = new SqlDataAdapter(sqlquery, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt; 
        }


    }

}