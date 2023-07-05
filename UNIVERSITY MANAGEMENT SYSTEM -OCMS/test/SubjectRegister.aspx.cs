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
    public partial class SubjectRegister : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=SMS;Integrated Security=True");
            conn.Open();
            string query = "select   Class  from ClassTB";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
            {
                while (sqlDataReader.Read())

                {
                    string Class = sqlDataReader.GetString(0);
                   
                    DropDownListClass.Items.Add(Class);
                     

                }

            }

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

                SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[SubjectTB]
           ([ClassName]
           ,[Subject]
           ,[subCode]
           ,[Date])
             VALUES        
                                    ('"
                    + DropDownListClass.Text + "','" + subjecttext.Text + "','" + subcode.Text + "','" + Subdate.Text + "')", con);



                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('New Subject was added Successfully');</script>");



            }



            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void savedata_Click(object sender, EventArgs e)
        {
            addNew();
            Response.Redirect("Subject.aspx");
        }
    }
}