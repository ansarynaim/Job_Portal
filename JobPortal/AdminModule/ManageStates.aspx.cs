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



namespace JobPortal.AdminModule
{
    public partial class ManageStates : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["abc"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCountry();
                BindGrid();
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

        public void BindGrid()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_States", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "show");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            gvstates.DataSource = dt;
            gvstates.DataBind();
        }

        public void Clear()
        {
            ddlcountry.SelectedValue = "0";
            txtsname.Text = "";
            btnsubmit.Text = "Submit";

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (btnsubmit.Text == "Submit")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_States", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "insert");
                cmd.Parameters.AddWithValue("@cid", ddlcountry.SelectedValue);
                cmd.Parameters.AddWithValue("@sname", txtsname.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                BindGrid();
                Clear();
            }

            else if (btnsubmit.Text == "Update")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_States", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "update");
                cmd.Parameters.AddWithValue("@sid", ViewState["ID"]);
                cmd.Parameters.AddWithValue("@cid", ddlcountry.SelectedValue);
                cmd.Parameters.AddWithValue("@sname", txtsname.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                BindGrid();
                Clear();
            }
        }

        protected void gvstates_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "A")
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_States", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "delete");
                cmd.Parameters.AddWithValue("@sid", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();
                BindGrid();
            }

            else if (e.CommandName == "B")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_States", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "edit");
                cmd.Parameters.AddWithValue("@sid", e.CommandArgument);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                ddlcountry.SelectedValue = dt.Rows[0]["cid"].ToString();
                txtsname.Text = dt.Rows[0]["sname"].ToString();
                btnsubmit.Text = "Update";
                ViewState["ID"] = e.CommandArgument;


            }
        }
    }
}