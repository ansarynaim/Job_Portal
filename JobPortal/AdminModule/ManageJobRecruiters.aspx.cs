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
    public partial class ManageJobRecruiters : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["abc"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView();
            }
        }


        public void GridView()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_Recruiter_Registration", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "JRJoin");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            gvjobrecruiters.DataSource = dt;
            gvjobrecruiters.DataBind();
        }

        protected void gvjobrecruiters_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName=="A")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_Recruiter_Registration", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "delete");
                cmd.Parameters.AddWithValue("@jrid", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close() ;
                GridView();
            }
        }
    }
}