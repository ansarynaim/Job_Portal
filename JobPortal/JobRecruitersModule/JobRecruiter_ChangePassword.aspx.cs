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
    public partial class JobRecruiter_ChangePassword : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["abc"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnchangepassword_Click(object sender, EventArgs e)
        {
            if (txtnewpassword.Text == txtconfirmnewpassword.Text)
            {
                if (txtnewpassword.Text != txtcurrentpassword.Text)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Proc_Recruiter_Registration", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@action", "ChangePassword");
                    cmd.Parameters.AddWithValue("@jrid", Session["JRID"]);
                    cmd.Parameters.AddWithValue("@newpassword", txtnewpassword.Text);
                    cmd.Parameters.AddWithValue("@currentpassword", txtcurrentpassword.Text);
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    if (i == 0)
                    {
                        lblmsg.Text = "Your Current Password is not matched!!";
                    }

                    else
                    {
                        lblmsg.Text = "Your Password has been changed successfully!!";
                    }

                }

                else
                {
                        lblmsg.Text = "Your Current Password cannot be your new password!!";
                }

               
            }
            else
            {
                lblmsg.Text = "Password Do not match!!";
            }
        }
    }
}