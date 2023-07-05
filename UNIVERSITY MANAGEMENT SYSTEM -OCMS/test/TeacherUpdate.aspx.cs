using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace test
{
    public partial class TeacherUpdate : System.Web.UI.Page
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
                SqlCommand cmd = new SqlCommand("select * from TeacherTB where ID='" + ID + "' ", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        TeacherFullnametext.Text = dr.GetValue(1).ToString();
                        TeacherID.Text = dr.GetValue(2).ToString();
                        TeacherGender.Text = dr.GetValue(3).ToString();
                        Temail.Text = dr.GetValue(4).ToString();
                        TAdressTextBox.Text = dr.GetValue(5).ToString();
                        Tnumber.Text = dr.GetValue(6).ToString();
                        Tpaasord.Text = dr.GetValue(7).ToString();
                        Tdate.Text = dr.GetValue(8).ToString();

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

                SqlCommand cmd = new SqlCommand("update TeacherTB set TeacherName='" + TeacherFullnametext.Text + "', TeacherID ='" + TeacherID.Text + "' , TGender ='" + TeacherGender.Text + "', TEmail ='" + Temail.Text + "', Tadress ='" + TAdressTextBox.Text + "'  , TNumber ='" + Tnumber.Text + "', Teacherpassword ='" + Tpaasord.Text + "' , Date ='" + Tdate.Text + "' where ID='" + ID + "' ", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Teacher was updated Successfully');</script>");

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

        protected void Updateedata_Click(object sender, EventArgs e)
        {
            EdiNew();
            Response.Redirect("Teacher.aspx");
        }
    }
}