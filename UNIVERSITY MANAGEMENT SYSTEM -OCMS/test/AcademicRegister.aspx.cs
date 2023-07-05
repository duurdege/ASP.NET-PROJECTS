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
    public partial class AsignTeacher : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        public static string L_name = "";
        public static string course_name = "";
        public static string class_name = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            readEMpID();

            readsub();



        }

        void readEMpID()
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
                    L_name = dataReader["TeacherName"].ToString();

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
                String strcommand = ("select  *from SubjectTB where subCode = '" + CourseCode.Text + "'");
                conn.Open();
                SqlCommand cmd = new SqlCommand(strcommand, conn);
                SqlDataReader dataReader;
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    course_name = dataReader["Subject"].ToString();
                    class_name = dataReader["ClassName"].ToString();
                   // L_name = dataReader["TeacherName"].ToString();

                }
                dataReader.Close();
                conn.Close();
            }
        }



        void readsub()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=SMS;Integrated Security=True");
            conn.Open();
            string query = "select   subCode, Subject, ClassName  from SubjectTB";
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

                SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[Academic]
           ([Code]
           ,[Course]
           ,[Class]
           ,[Academic_Year]
           ,[Lecturer]
           ,[EMPID]
           ,[Semester])
             VALUES       
                                    ('"
                    + CourseCode.Text + "','" + course_name + "','" + class_name + "','" + Academicyear.Text + "' ,'" + L_name.ToString() + "' ,'" + DropDownListEMPID.Text + "' ,'" + academicsemester.Text + "')", con);



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
            lECTURER();

            COURSE();

            addNew();
            Response.Redirect("Academic.aspx");
        }

        protected void DropDownListEMPID_SelectedIndexChanged(object sender, EventArgs e)
        {
            //class1();

        }
    }
}