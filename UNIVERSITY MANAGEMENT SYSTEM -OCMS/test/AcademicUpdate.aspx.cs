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
    public partial class AcademicUpdate : System.Web.UI.Page
    {
        public string ID;
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        public static string L_name = "";
        public static string course_name = "";
        public static string class_name = "";

        protected void Page_Load(object sender, EventArgs e)
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


            string query2 = "select TeacherID, TeacherName from TeacherTB ";
            SqlCommand sqlCommand2 = new SqlCommand(query2, conn);
            using (SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader())
            {
                while (sqlDataReader2.Read())

                {

                    string EMPID = sqlDataReader2.GetString(0);

                    DropDownListEMPID.Items.Add(EMPID);


                }

            }


            ID = Request.QueryString["Reffno"];
            if (!IsPostBack)
            {
                ReadData();
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

        void ReadData()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("select * from Academic where ID ='" + ID + "' ", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        CourseCode.Text = dr.GetValue(1).ToString();
                        Academicyear.Text = dr.GetValue(4).ToString();                       
                        DropDownListEMPID.Text = dr.GetValue(6).ToString();
                        academicsemester.Text = dr.GetValue(7).ToString();



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

                SqlCommand cmd = new SqlCommand("update Academic set  Code ='" + CourseCode.Text + "', Course ='" + course_name + "' , Class ='" + class_name + "', Academic_Year ='" + Academicyear.Text + "' , Lecturer ='" + L_name + "' , EMPID ='" + DropDownListEMPID.Text + "' , Semester ='" + academicsemester.Text + "'   where ID='" + ID + "' ", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Subject was updated Successfully');</script>");

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
            lECTURER();
            COURSE();
            EdiNew();
            Response.Redirect("Academic.aspx");
        }
    }
}