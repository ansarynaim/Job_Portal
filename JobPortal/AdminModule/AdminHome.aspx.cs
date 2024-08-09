using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace JobPortal.AdminModule
{
    public partial class AdminHome : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["abc"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ShowAdminData();
            }
        }

        public void ShowAdminData()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblAdmin where adminid='" + Session["AID"] +"'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            lbladminname.Text= dt.Rows[0]["adminname"].ToString();
            lbladminemail.Text = dt.Rows[0]["adminemail"].ToString();
            lbladminpassword.Text = dt.Rows[0]["adminpassword"].ToString();
        }
    }
}