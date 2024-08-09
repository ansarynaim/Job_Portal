using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Xml.Linq;


namespace JobPortal.JobRecruitersModule
{
    public partial class JobRecruiter_JobPost : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["abc"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindJobProfile();
                if(Request.QueryString["idd"] !=null && Request.QueryString["idd"].ToString() !="")
                {
                    EditData();
                }
                
            }
        }

        public void EditData()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_JobRecruiter_JobPost", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "edit");
            cmd.Parameters.AddWithValue("@jpsid", Request.QueryString["idd"].ToString());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddljobprofile.SelectedValue = dt.Rows[0]["jpsjobprofile"].ToString();
            rblgender.SelectedValue = dt.Rows[0]["jpsgender"].ToString();
            ddlminexp.SelectedValue = dt.Rows[0]["jpsminexp"].ToString();
            ddlmaxexp.SelectedValue = dt.Rows[0]["jpsmaxexp"].ToString();
            txtminsalary.Text = dt.Rows[0]["jpsminsalary"].ToString();
            txtmaxsalary.Text = dt.Rows[0]["jpsmaxsalary"].ToString();
            txtcomments.Text = dt.Rows[0]["jpscomments"].ToString();
            btnjobpost.Text = "Update";
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

        protected void btnjobpost_Click(object sender, EventArgs e)
        {
            if (btnjobpost.Text == "Job Post")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_JobRecruiter_JobPost", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "insert");
                cmd.Parameters.AddWithValue("@jrid", Session["JRID"]);
                cmd.Parameters.AddWithValue("@jpsjobprofile", ddljobprofile.SelectedValue);
                cmd.Parameters.AddWithValue("@jpsgender", rblgender.SelectedValue);
                cmd.Parameters.AddWithValue("@jpsminexp", ddlminexp.SelectedValue);
                cmd.Parameters.AddWithValue("@jpsmaxexp", ddlmaxexp.SelectedValue);
                cmd.Parameters.AddWithValue("@jpsminsalary", txtminsalary.Text);
                cmd.Parameters.AddWithValue("@jpsmaxsalary", txtmaxsalary.Text);
                cmd.Parameters.AddWithValue("@jpscomments", txtcomments.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("JobRecruiter_JobPostList.aspx");
            }

            else
            if (btnjobpost.Text == "Update")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_JobRecruiter_JobPost", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "update");
                cmd.Parameters.AddWithValue("@jpsid", Request.QueryString["idd"].ToString());
                cmd.Parameters.AddWithValue("@jrid", Session["JRID"]);
                cmd.Parameters.AddWithValue("@jpsjobprofile", ddljobprofile.SelectedValue);
                cmd.Parameters.AddWithValue("@jpsgender", rblgender.SelectedValue);
                cmd.Parameters.AddWithValue("@jpsminexp", ddlminexp.SelectedValue);
                cmd.Parameters.AddWithValue("@jpsmaxexp", ddlmaxexp.SelectedValue);
                cmd.Parameters.AddWithValue("@jpsminsalary", txtminsalary.Text);
                cmd.Parameters.AddWithValue("@jpsmaxsalary", txtmaxsalary.Text);
                cmd.Parameters.AddWithValue("@jpscomments", txtcomments.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("JobRecruiter_JobPostList.aspx");
            }
        }
    }
}