using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace test
{
    public partial class ClassRegister : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        void addNew()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                //String ID = GenerateAutoID();
                 
                SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[ClassTB]
           ([Faculty]
           ,[Department]
           ,[Class]
           ,[ClassCode]
           ,[Date])
            VALUES        
                                    ('"
                    + Facultytext.Text + "','" + Departmenttext.Text + "','" + Classtextbox.Text + "','" + classcodetext.Text + "', '" + Classdate.Text + "' )", con);



                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('New Class was added Successfully');</script>");

                 

            }



            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void savedata_Click(object sender, EventArgs e)
        {
            addNew();
            //Response.Redirect("Class.aspx");
        }
    }
}