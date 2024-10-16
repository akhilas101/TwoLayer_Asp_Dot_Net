using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
namespace TwoLayerExample
{
    public partial class Pofile : System.Web.UI.Page
    {
        ConnectionClass objcls = new ConnectionClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            string sel = "select Name,Age,Address,Photo from Twolayer where Id=" + Session["uid"] + "";
            SqlDataReader dr = objcls.Fun_exeReader(sel);
            while(dr.Read())
            {
                Label1.Text = dr["Name"].ToString();
                Label2.Text = dr["Age"].ToString();
                Label3.Text = dr["Address"].ToString();
                Image1.ImageUrl = dr["Photo"].ToString();
            }
            DataSet ds = objcls.Fun_exeAdapter(sel);
            GridView1.DataSource = ds;
            GridView1.DataBind();

            DataTable dt = objcls.Fun_Exedatatable(sel);
            DataList1.DataSource = dt;
            DataList1.DataBind();
        }

        protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}