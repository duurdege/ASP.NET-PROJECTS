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
    public partial class ClassUpdate : System.Web.UI.Page
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
                SqlCommand cmd = new SqlCommand("select * from ClassTB where ID='" + ID + "' ", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        Facultytext.Text = dr.GetValue(1).ToString();
                        Departmenttext.Text = dr.GetValue(2).ToString();
                        Classtextbox.Text = dr.GetValue(3).ToString();
                        classcodetext.Text = dr.GetValue(4).ToString();
                        Classdate.Text = dr.GetValue(5).ToString();
          

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

                SqlCommand cmd = new SqlCommand("update ClassTB set Faculty='" + Facultytext.Text + "', Department ='" + Departmenttext.Text + "' , Class ='" + Classtextbox.Text + "', ClassCode ='" + classcodetext.Text + "' , Date ='" + Classdate.Text + "' where ID='" + ID + "' ", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Class was updated Successfully');</script>");

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

        protected void Updateclass_Click(object sender, EventArgs e)
        {

        }

        protected void Updateclass_Click1(object sender, EventArgs e)
        {
            EdiNew();
            Response.Redirect("Class.aspx");
        }
    }
}