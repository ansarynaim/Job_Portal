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
    public partial class ManageCompanyType : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["abc"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        public void BindGrid()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_CompanyType", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "show");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            gvcompanytype.DataSource = dt;
            gvcompanytype.DataBind();
        }

        public void Clear()
        {
            txtname.Text = "";
            btnsubmit.Text = "Submit";

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (btnsubmit.Text == "Submit")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_CompanyType", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "insert");
                cmd.Parameters.AddWithValue("@ctname", txtname.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                BindGrid();
                Clear();
            }

            else if (btnsubmit.Text == "Update")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_CompanyType", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "update");
                cmd.Parameters.AddWithValue("@ctid", ViewState["ID"]);
                cmd.Parameters.AddWithValue("@ctname", txtname.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                BindGrid();
                Clear();
            }
        }

        protected void gvcompanytype_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "A")
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_CompanyType", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "delete");
                cmd.Parameters.AddWithValue("@ctid", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();
                BindGrid();
            }

            else if (e.CommandName == "B")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_CompanyType", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "edit");
                cmd.Parameters.AddWithValue("@ctid", e.CommandArgument);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                txtname.Text = dt.Rows[0]["ctname"].ToString();
                btnsubmit.Text = "Update";
                ViewState["ID"] = e.CommandArgument;


            }
        }
    }
}