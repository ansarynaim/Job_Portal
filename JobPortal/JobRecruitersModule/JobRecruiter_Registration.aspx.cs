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
    public partial class JobRecruiter_Registration : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["abc"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCompanyType();
            }
        }

        public void BindCompanyType()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_CompanyType", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "show");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddlcompanytype.DataValueField = "ctid";
            ddlcompanytype.DataTextField = "ctname";
            ddlcompanytype.DataSource = dt;
            ddlcompanytype.DataBind();
            ddlcompanytype.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_Recruiter_Registration", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "insert");
            cmd.Parameters.AddWithValue("@jrcompanytype", ddlcompanytype.SelectedValue);
            cmd.Parameters.AddWithValue("@jrname", txtname.Text);
            cmd.Parameters.AddWithValue("@jremail", txtemail.Text);
            cmd.Parameters.AddWithValue("@jrpassword", txtpassword.Text);
            cmd.Parameters.AddWithValue("@jrcontactperson", txtcontactperson.Text);
            cmd.Parameters.AddWithValue("@jrcontactnumber", txtcontactnumber.Text);
            cmd.Parameters.AddWithValue("@jrcomments", txtcomments.Text);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}