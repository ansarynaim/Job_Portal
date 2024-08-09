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
    public partial class JobSeeker_ApplyJobs : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["abc"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindJobProfile();
                BindJobPost();
            }
        }

        public void BindJobProfile()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_JobProfiles", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "show");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddljobprofile.DataValueField = "jpid";
            ddljobprofile.DataTextField = "jpname";
            ddljobprofile.DataSource = dt;
            ddljobprofile.DataBind();
            ddljobprofile.Items.Insert(0, new ListItem("--Select--", "0"));


        }
        public void BindJobPost()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_JobRecruiter_JobPost", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "JPSJoin");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            gvjobpostlist.DataSource = dt;
            gvjobpostlist.DataBind();


        }

        protected void btnserach_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_JobRecruiter_JobPost", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "JPSJoinSearch");
            cmd.Parameters.AddWithValue("@jpsjobprofile", ddljobprofile.SelectedValue);
            cmd.Parameters.AddWithValue("@jpsmaxsalary", txtsalary.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            gvjobpostlist.DataSource = dt;
            gvjobpostlist.DataBind();
        }

        protected void gvjobpostlist_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName=="app")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_JobSeeker_ApplyJobs", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "insert");
                cmd.Parameters.AddWithValue("@jsid", Session["JSID"]);
                cmd.Parameters.AddWithValue("@jpsid", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}