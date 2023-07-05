using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace test.StudentMasterPage
{
    public partial class StudentDashboard : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=SMS;Integrated Security=True");
            conn.Open();
            string query = "select  Semester  from Academic";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
            {
                while (sqlDataReader.Read())

                {
                    string semester = sqlDataReader.GetString(0);


                    DropDownListacadamy.Items.Add(semester);
                    



                }

            }
        }
         protected void savedata_Click(object sender, EventArgs e)
        {
             
        }
    }
}