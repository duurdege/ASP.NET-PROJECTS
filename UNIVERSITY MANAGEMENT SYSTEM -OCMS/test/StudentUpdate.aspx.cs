using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace test
{
    public partial class StudentUpdate : System.Web.UI.Page
    {
        public string ID;
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=SMS;Integrated Security=True");
            conn.Open();
            string query = "select  Faculty, Department, Class  from ClassTB";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
            {
                while (sqlDataReader.Read())

                {
                    string Faculty = sqlDataReader.GetString(0);
                    string Department = sqlDataReader.GetString(1);
                    string Class = sqlDataReader.GetString(2);

                    DropDownListStudentFaculty.Items.Add(Faculty);
                    DropDownListStudentDepartment.Items.Add(Department);
                    DropDownListStudentClass.Items.Add(Class);


                }

            }


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
                SqlCommand cmd = new SqlCommand("select * from student where ID='" + ID + "' ", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        StudentFullnametext.Text = dr.GetValue(1).ToString();
                        StudentID.Text = dr.GetValue(2).ToString();
                        StudentGender.Text = dr.GetValue(3).ToString();
                        Semail.Text = dr.GetValue(4).ToString();
                        SAdressTextBox.Text = dr.GetValue(5).ToString();
                        Snumber.Text = dr.GetValue(6).ToString();
                        Spaasord.Text = dr.GetValue(7).ToString();
                        Sdate.Text = dr.GetValue(8).ToString();
                        DropDownListStudentFaculty.Text = dr.GetValue(9).ToString();
                        DropDownListStudentDepartment.Text = dr.GetValue(10).ToString();
                        DropDownListStudentClass.Text = dr.GetValue(11).ToString();
                        TextBoxStudentSemester.Text = dr.GetValue(12).ToString();
                         


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

                SqlCommand cmd = new SqlCommand("update student set FullName='" + StudentFullnametext.Text + "', StudentID ='" + StudentID.Text + "' , Number ='" + Snumber.Text + "', Email ='" + Semail.Text + "', Address ='" + SAdressTextBox.Text + "'  , Gender ='" + StudentGender.Text + "', Password ='" + Spaasord.Text + "' , Date ='" + Sdate.Text + "', Faculty ='" + DropDownListStudentFaculty.Text + "' , Department ='" + DropDownListStudentDepartment.Text + "' , Clas ='" + DropDownListStudentClass.Text + "' , Semester ='" + TextBoxStudentSemester.Text + "'   where ID='" + ID + "' ", con);
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

        protected void savedata_Click(object sender, EventArgs e)
        {
            EdiNew();
            Response.Redirect("Student.aspx");
        }
    }
}