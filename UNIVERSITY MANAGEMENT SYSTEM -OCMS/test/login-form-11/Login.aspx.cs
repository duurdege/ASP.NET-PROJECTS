using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;

namespace test.login_form_11
{
    public partial class Login : System.Web.UI.Page
    {

        public static String AdminName = "";
        public static String Admin_Teacher_student = "";
        public static String Admin_Teacher_student_photo = "";
        public static String TeacherName = "";

        public static String Teacher_user = "";
        public static String Teacher_password = "";
        public static String Teacher_Email = "";
        public static String Teacher_ID = "";

        public static String Student_user = "";
        public static String Student_Password = "";
        public static String Student_Name = "";
        public static String student_Email = "";
        public static String StudentID = "";
        public static String StudentClass = "";

        public static String Admin_user = "";
        public static String Admin_Email = "";
        public static String Admin_password = "";



        private void Admin()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=SMS;Integrated Security=True");

            String strcommand = "select * from AdminTB where AdminUser = '" + TextBoxusername.Text + "' and Adminpassword = '" + TextBoxpassword.Text + "'";
            conn.Open();
            SqlCommand cmd = new SqlCommand(strcommand, conn);
            SqlDataReader dataReader;
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                Admin_user = dataReader["AdminUser"].ToString();
                Admin_password = dataReader["Adminpassword"].ToString();
                AdminName = dataReader["AdminNmae"].ToString();
                Admin_Email = dataReader["Email"].ToString();

                //byte[] bytes = (byte[])dataReader["Photo"];
                //string strBase64 = Convert.ToBase64String(bytes);
                Admin_Teacher_student_photo = dataReader["Photo"].ToString();
            }
 
            dataReader.Close();
            conn.Close();

        }

        private void Teacher()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=SMS;Integrated Security=True");

            String strcommand = "select * from TeacherTB where TeacherID = '" + TextBoxusername.Text + "' and Teacherpassword = '" + TextBoxpassword.Text + "'";
            conn.Open();
            SqlCommand cmd = new SqlCommand(strcommand, conn);
            SqlDataReader dataReader;
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                Teacher_user = dataReader["TeacherID"].ToString();
                Teacher_password = dataReader["Teacherpassword"].ToString();
                TeacherName = dataReader["TeacherName"].ToString();
                Teacher_Email = dataReader["TEmail"].ToString();

                //byte[] bytes = (byte[])dataReader["Photo"];
                //string strBase64 = Convert.ToBase64String(bytes);
                Admin_Teacher_student_photo = dataReader["TPhoto"].ToString();
            }

            dataReader.Close();
            conn.Close();

        }
        private void academic()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=SMS;Integrated Security=True");

            String strcommand = "select * from Academic where EMPID = '" + TextBoxusername.Text + "' ";
            conn.Open();
            SqlCommand cmd = new SqlCommand(strcommand, conn);
            SqlDataReader dataReader;
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                Teacher_ID = dataReader["EMPID"].ToString();
                StudentClass = dataReader["Class"].ToString();
                
            }

            dataReader.Close();
            conn.Close();

        }


        private void Student()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=SMS;Integrated Security=True");

            String strcommand = "select * from student where StudentID = '" + TextBoxusername.Text + "' and Password = '" + TextBoxpassword.Text + "'";
            conn.Open();
            SqlCommand cmd = new SqlCommand(strcommand, conn);
            SqlDataReader dataReader;
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                
                Student_user = dataReader["StudentID"].ToString();
                Student_Password = dataReader["Password"].ToString();
                Student_Name = dataReader["FullName"].ToString();
                student_Email = dataReader["Email"].ToString();
                StudentID = dataReader["StudentID"].ToString();
                 
                 
                Admin_Teacher_student_photo = dataReader["Photo"].ToString();
            }

            dataReader.Close();
            conn.Close();

        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Admin();
            Teacher();
            Student();
            academic();

            if (TextBoxusername.Text == "" && TextBoxpassword.Text == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Please Enter usename and password' );</script>");

            }
            else if (TextBoxusername.Text == Admin_user && TextBoxpassword.Text == Admin_password)
            {

                Session["Photo"] = Admin_Teacher_student_photo;
                Session["Email"] = Admin_Email;
                Session["AdminNmae"] = AdminName;
               

                Response.Redirect("../Dashboard.aspx");


            }
            else if (TextBoxusername.Text == Teacher_user && TextBoxpassword.Text == Teacher_password)
            {
                Session["TPhoto"] = Admin_Teacher_student_photo;
                Session["TEmail"] = Teacher_Email;
                Session["TeacherName"] = TeacherName;
                Session["EMPID"] = Teacher_ID;

                Response.Redirect("~/TeacherMasterPage/TeacherDashboard.aspx");

            }
            else if (TextBoxusername.Text == Student_user && TextBoxpassword.Text == Student_Password)
            {
                Session["Photo"] = Admin_Teacher_student_photo;
                Session["Email"] = student_Email;
                Session["FullName"] = Student_Name;
                Session["StudentID"] = StudentID;
                Session["Class"] = StudentClass;

                Response.Redirect("~/StudentMasterPage/StudentDashboard.aspx");

            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Incorrect Password or Username' );</script>");

            }

        }
    }
}