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
    public partial class ManageCities : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["abc"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCountry();
                
            }
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


        public void BindGrid()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_Cities", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "show");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            gvcities.DataSource = dt;
            gvcities.DataBind();
        }

        public void Clear()
        {
            ddlcountry.SelectedValue = "0";
            ddlstate.SelectedValue = "0";
            txtcityname.Text = "";
            btnsubmit.Text = "Submit";

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (btnsubmit.Text == "Submit")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_Cities", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "insert");
                cmd.Parameters.AddWithValue("@cid", ddlcountry.SelectedValue);
                cmd.Parameters.AddWithValue("@sid", ddlstate.SelectedValue);
                cmd.Parameters.AddWithValue("@cityname", txtcityname.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                BindGrid();
                Clear();
            }

            else if (btnsubmit.Text == "Update")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_Cities", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "update");
                cmd.Parameters.AddWithValue("@cityid", ViewState["ID"]);
                cmd.Parameters.AddWithValue("@cid", ddlcountry.SelectedValue);
                cmd.Parameters.AddWithValue("@sid", ddlstate.SelectedValue);
                cmd.Parameters.AddWithValue("@cityname", txtcityname.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                BindGrid();
                Clear();
            }
        }

        protected void gvcities_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "A")
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_Cities", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "delete");
                cmd.Parameters.AddWithValue("@cityid", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();
                BindGrid();
            }

            else if (e.CommandName == "B")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_Cities", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "edit");
                cmd.Parameters.AddWithValue("@cityid", e.CommandArgument);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                ddlcountry.SelectedValue = dt.Rows[0]["cid"].ToString();
                BindState();
                ddlstate.SelectedValue = dt.Rows[0]["sid"].ToString();
                txtcityname.Text = dt.Rows[0]["cityname"].ToString();
                btnsubmit.Text = "Update";
                ViewState["ID"] = e.CommandArgument;


            }
        }

        protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindState();
        }
    }
}