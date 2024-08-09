using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace JobPortal.JobSeekersModule
{
    public partial class JobSeekerHome : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["abc"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowJobSeekerData();
            }
        }

        public void ShowJobSeekerData()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_tblJobSeeker_Registration", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "JSJoinOne");
            cmd.Parameters.AddWithValue("@jsid", Session["JSID"]);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            lbljobseekername.Text = dt.Rows[0]["jsname"].ToString();
            lbljobseekeremail.Text = dt.Rows[0]["jsemail"].ToString();
            lbljobseekerpassword.Text = dt.Rows[0]["jspassword"].ToString();

        }
    }
}