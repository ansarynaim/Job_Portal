using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace JobPortal.JobRecruitersModule
{
    public partial class JobRecruiterHome : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["abc"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowJobRecruiterData();
            }
        }

        public void ShowJobRecruiterData()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_Recruiter_Registration", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "JRJoinOne");
            cmd.Parameters.AddWithValue("@jrid", Session["JRID"]);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            lbljobrecruitername.Text = dt.Rows[0]["jrname"].ToString();
            lbljobrecruiteremail.Text = dt.Rows[0]["jremail"].ToString();
            lbljobrecruiterpassword.Text = dt.Rows[0]["jrpassword"].ToString();

        }
    }
}