using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;

namespace JobPortal.JobSeekersModule
{
    public partial class JobSeeker_Registration : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["abc"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindJobProfile();
                BindQualification();
                BindCountry();

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

        public void BindQualification()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_Qualifications", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "show");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddlqualification.DataValueField = "qid";
            ddlqualification.DataTextField = "qname";
            ddlqualification.DataSource = dt;
            ddlqualification.DataBind();
            ddlqualification.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        public void BindCountry()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_Countries", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "show");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddlcountry.DataValueField = "cid";
            ddlcountry.DataTextField = "cname";
            ddlcountry.DataSource = dt;
            ddlcountry.DataBind();
            ddlcountry.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        public void BindState()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_States", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "GetStateByCountry");
            cmd.Parameters.AddWithValue("@cid", ddlcountry.SelectedValue);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddlstate.DataValueField = "sid";
            ddlstate.DataTextField = "sname";
            ddlstate.DataSource = dt;
            ddlstate.DataBind();
            ddlstate.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        public void BindCity()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_Cities", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "GetCityByState");
            cmd.Parameters.AddWithValue("@sid", ddlstate.SelectedValue);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddlcity.DataValueField = "cityid";
            ddlcity.DataTextField = "cityname";
            ddlcity.DataSource = dt;
            ddlcity.DataBind();
            ddlcity.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindState();
        }

        protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindCity();
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            string JSPHOTO = Path.GetFileName(fuphoto.PostedFile.FileName);
            fuphoto.SaveAs(Server.MapPath("../JS_PHOTOS" + "//" + JSPHOTO));


            string JSRESUME = Path.GetFileName(furesume.PostedFile.FileName);
            furesume.SaveAs(Server.MapPath("../JS_RESUMES" + "//" + JSRESUME));

            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_tblJobSeeker_Registration", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "insert");
            cmd.Parameters.AddWithValue("@jsname", txtname.Text);
            cmd.Parameters.AddWithValue("@jsemail", txtemail.Text);
            cmd.Parameters.AddWithValue("@jspassword", txtpassword.Text);
            cmd.Parameters.AddWithValue("@jsjobprofile", ddljobprofile.SelectedValue);
            cmd.Parameters.AddWithValue("@jsexp", ddlexp.SelectedValue);
            cmd.Parameters.AddWithValue("@jsqualification", ddlqualification.SelectedValue);
            cmd.Parameters.AddWithValue("@jscountry", ddlcountry.SelectedValue);
            cmd.Parameters.AddWithValue("@jsstate", ddlstate.SelectedValue);
            cmd.Parameters.AddWithValue("@jscity", ddlcity.SelectedValue);
            cmd.Parameters.AddWithValue("@jsphoto", JSPHOTO);
            cmd.Parameters.AddWithValue("@jsresume", JSRESUME);
            cmd.Parameters.AddWithValue("@jscomments", txtcomments.Text); 
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}