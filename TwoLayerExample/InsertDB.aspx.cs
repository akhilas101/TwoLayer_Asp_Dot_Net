using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace TwoLayerExample
{
    public partial class InsertDB : System.Web.UI.Page
    {
        ConnectionClass objcls = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string path = "~/PHS/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(path));
            string strinsert = "insert into Twolayer values('" + TextBox1.Text + "'," + TextBox2.Text + ",'" + TextBox6.Text + "','" + path + "','" + TextBox5.Text + "','" + TextBox7.Text + "')";
            int i = objcls.Fun_exenonquery(strinsert);
            if(i==1)
            {
                Label7.Text = "Inserted";
            }

        }
    }
}