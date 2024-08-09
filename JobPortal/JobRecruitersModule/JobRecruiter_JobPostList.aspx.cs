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
    public partial class JobRecruiter_JobPostList : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["abc"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindJobPost();
            }
        }

        public void BindJobPost()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_JobRecruiter_JobPost", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "JPSJoinByRecruiter");
            cmd.Parameters.AddWithValue("@jrid", Session["JRID"]);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            gvjobpostlist.DataSource= dt;
            gvjobpostlist.DataBind();


        }

        protected void gvjobpostlist_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "A")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_JobRecruiter_JobPost", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "changestatus");
                cmd.Parameters.AddWithValue("@jpsid", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();
                BindJobPost();
            }

            else if (e.CommandName == "B")
            {
                Response.Redirect("JobRecruiter_JobPost.aspx?idd=" +e.CommandArgument);

            }
        }
    }
}