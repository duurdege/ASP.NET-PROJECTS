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
    public partial class ResultRegister : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        public static string Lecturer_name = "";
        public static string course_name = "";
        public static string class_name = "";
        public static string Student_Name = "";
        public static string Student_Class = "";
        public static string Student_Department = "";
        public static string Student_Semester = "";
     
        public static string midterm = "";
        public static string Final = "";
        public static string Activity = "";
        public int Total;

        protected void Page_Load(object sender, EventArgs e)
        {
            Read_EMPID();
            Read_Course();
            Read_StudentID();
        }

        void Read_EMPID()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=SMS;Integrated Security=True");
            conn.Open();
            string query2 = "select TeacherID from TeacherTB ";
            SqlCommand sqlCommand2 = new SqlCommand(query2, conn);
            using (SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader())
            {
                while (sqlDataReader2.Read())

                {

                    string EMPID = sqlDataReader2.GetString(0);

                    DropDownListEMPID.Items.Add(EMPID);


                }

            }


        }

        private void lECTURER()
        {
            if (DropDownListEMPID.SelectedIndex == -1)
            {
                Response.Write("<script>alert('slect ID ');</script>");
            }

            if (DropDownListEMPID.SelectedIndex <= DropDownListEMPID.Items.Count)
            {

                SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=SMS;Integrated Security=True");
                String strcommand = ("select * from TeacherTB where TeacherID = '" + DropDownListEMPID.Text + "'");
                conn.Open();
                SqlCommand cmd = new SqlCommand(strcommand, conn);
                SqlDataReader dataReader;
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    Lecturer_name = dataReader["TeacherName"].ToString();

                }
                dataReader.Close();
                conn.Close();
            }
        }


        private void COURSE()
        {
            if (DropDownListEMPID.SelectedIndex == -1)
            {
                Response.Write("<script>alert('Select Course Code');</script>");

            }

            if (DropDownListEMPID.SelectedIndex <= DropDownListEMPID.Items.Count)
            {

                SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=SMS;Integrated Security=True");
                String strcommand = ("select  * from SubjectTB where subCode = '" + CourseCode.Text + "'");
                conn.Open();
                SqlCommand cmd = new SqlCommand(strcommand, conn);
                SqlDataReader dataReader;
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    course_name = dataReader["Subject"].ToString();
                  
             

                }
                dataReader.Close();
                conn.Close();
            }
        }



        void Read_Course()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=SMS;Integrated Security=True");
            conn.Open();
            string query = "select   subCode, Subject  from SubjectTB";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
            {
                while (sqlDataReader.Read())

                {
                    string Code = sqlDataReader.GetString(0);

                    CourseCode.Items.Add(Code);


                }

            }
            conn.Close();
        }


        void Read_StudentID()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=SMS;Integrated Security=True");
            conn.Open();
            string query2 = "select StudentID from student ";
            SqlCommand sqlCommand2 = new SqlCommand(query2, conn);
            using (SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader())
            {
                while (sqlDataReader2.Read())

                {

                    string StudentID = sqlDataReader2.GetString(0);
                    DropDownListStudentId.Items.Add(StudentID);


                }

            }


        }


        private void StudentInfo()
        {
            if (DropDownListStudentId.SelectedIndex == -1)
            {
                Response.Write("<script>alert('slect ID ');</script>");
            }

            if (DropDownListStudentId.SelectedIndex <= DropDownListStudentId.Items.Count)
            {

                SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=SMS;Integrated Security=True");
                String strcommand = ("select * from student where StudentID = '" + DropDownListStudentId.Text + "'");
                conn.Open();
                SqlCommand cmd = new SqlCommand(strcommand, conn);
                SqlDataReader dataReader;
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    Student_Name = dataReader["FullName"].ToString();
                    Student_Class = dataReader["Clas"].ToString();
                    Student_Department = dataReader["Department"].ToString();
                    Student_Semester = dataReader["Semester"].ToString();

                }
                dataReader.Close();
                conn.Close();
            }
        }


        void addNew()
        {
              SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
            //String ID = GenerateAutoID();
            Total = Convert.ToInt32(Midtearm.Text) + Convert.ToInt32(TextBoxFINAL.Text) + Convert.ToInt32(ACTIVITIES.Text);
            //Total = (Midtearm.Text + TextBoxFINAL.Text + ACTIVITIES.Text).ToString();

            SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[Result]
           ([CourseCode]
           ,[CourseName]
           ,[EMPID]
           ,[LecturerName]
           ,[Midterm]
           ,[Final]
           ,[Activity]
           ,[Total]
           ,[StudentName]
           ,[StudentClass]
           ,[StudentDepartment]
           ,[StudentSemester])
     VALUES      
                                    ('"
                    + CourseCode.Text + "','" + course_name + "','" + DropDownListEMPID.Text + "','" + Lecturer_name.ToString() + "' ,'" + Convert.ToInt32( Midtearm.Text )+ "' ,'" + Convert.ToInt32(TextBoxFINAL.Text) + "' ,'" + Convert.ToInt32(ACTIVITIES.Text )+ "' ,'" + Total + "' ,'" + Student_Name + "' ,'" + Student_Class + "'  ,'" + Student_Department + "' ,'" + Student_Semester + "')", con);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('New Result was added Successfully');</script>");


 
        }

        protected void savedata_Click(object sender, EventArgs e)
        {
            COURSE();
            lECTURER();
            StudentInfo();
            addNew();
            Response.Redirect("Result.aspx");
        }
    }
}