using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace test
{
    public partial class UpdateAdmin : System.Web.UI.Page
    {
        public string ID;
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            ID = Request.QueryString["Reffno"];
            if (!IsPostBack)
            {
                ReadData();
            }

        }

        void ReadData()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("select * from AdminTb where ID='" + ID + "' ", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        adminfullname.Text = dr.GetValue(1).ToString();
                        ausername.Text = dr.GetValue(2).ToString();
                        AdminGender.Text = dr.GetValue(3).ToString();
                        aemail.Text = dr.GetValue(4).ToString();
                        anumber.Text = dr.GetValue(5).ToString();
                        apaasord.Text = dr.GetValue(6).ToString();
                        adate.Text = dr.GetValue(7).ToString();
 
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void EdiNew()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("update AdminTb set AdminNmae='" + adminfullname.Text + "', AdminUser ='" + ausername.Text + "' , Gender ='" + AdminGender.Text + "', Email ='" + aemail.Text + "' , Number ='" + anumber.Text + "', Adminpassword ='" + apaasord.Text + "' , Date ='" + adate.Text + "' where ID='" + ID + "' ", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Admin was updated Successfully');</script>");

                string message = "Your details have been saved successfully.";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);



            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
   

        protected void Updatedata_Click(object sender, EventArgs e)
        {
            EdiNew();
            Response.Redirect("Admin.aspx");

        }
    }
}



 
 