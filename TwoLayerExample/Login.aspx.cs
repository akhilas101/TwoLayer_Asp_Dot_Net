using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace TwoLayerExample
{
    public partial class Login : System.Web.UI.Page
    {
        ConnectionClass objcls = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string s= "select count(Id) from Twolayer where Username='"+TextBox1.Text+ "' and Password ='" + TextBox2.Text + "'";
            string cid = objcls.Fun_exescalar(s);
            if(cid=="1")
            {
                int id1 = 0;
                string str = "select Id from Twolayer where Username='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'";
                SqlDataReader dr = objcls.Fun_exeReader(str);
                while(dr.Read())
                {
                    id1 = Convert.ToInt32(dr["Id"].ToString());
                }
                Session["uid"] = id1;
                Response.Redirect("Pofile.aspx");
            }
        }
    }
}