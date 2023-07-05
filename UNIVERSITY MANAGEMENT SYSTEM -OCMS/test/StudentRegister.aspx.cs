using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace test
{
    public partial class StudentRegister : System.Web.UI.Page
    {
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

         

        }
        void addNew()
        {
            //try
            //{
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                //String ID = GenerateAutoID();
                string fname = Path.GetFileName(fileuploadS.FileName);
                fileuploadS.SaveAs(Server.MapPath("Students-Photo/") + fname);
                SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[student]
           ([FullName]
           ,[StudentID]
           ,[Number]
           ,[Email]
           ,[Address]
           ,[Gender]
           ,[Password]
           ,[Date]
           ,[Faculty]
           ,[Department]
           ,[Clas]
           ,[Semester]
           ,[Photo])
            VALUES
             ('" + StudentFullnametext.Text + "', '" + StudentID.Text + "', '" + Snumber.Text + "','" + Semail.Text + "','" + SAdressTextBox.Text + "','" + StudentGender.Text + "','" + Spaasord.Text + "', '" + Sdate.Text + "','" + DropDownListStudentFaculty.Text + "', '" + DropDownListStudentDepartment.Text + "', '" + DropDownListStudentClass.Text + "', '" + TextBoxStudentSemester.Text + "', '" + fileuploadS.FileName + "')", con);




            cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('New Student was added Successfully');</script>");

                string message = "Your details have been saved successfully.";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);

            //}



            //catch (Exception ex)
            //{
            //    Response.Write("<script>alert('" + ex.Message + "');</script>");
            //}
        }
        //private string GenerateAutoID()
        //{
        //    string TheID = "";
        //    try
        //    {

        //        SqlConnection con = new SqlConnection(strcon);
        //        if (con.State == ConnectionState.Closed)
        //        {
        //            con.Open();
        //        }
        //        string flag = "C";
        //        string customID = string.Empty;
        //        DateTime dt = DateTime.Now;
        //        customID = flag + dt.ToString("yyyyMM");
        //        string Startpoint = "";


        //        SqlCommand cmd = new SqlCommand("select ID from Customer order by ID asc ", con);
        //        SqlDataReader dr = cmd.ExecuteReader();

        //        if (!dr.HasRows)
        //        {
        //            Startpoint = "1";
        //            TheID = customID + Startpoint;
        //        }

        //        else if (dr.HasRows)
        //        {
        //            while (dr.Read())
        //            {

        //                int newID = Convert.ToInt32(dr.GetValue(0).ToString());
        //                newID++;
        //                Startpoint = newID.ToString();
        //                TheID = customID + Startpoint;
        //            }
        //        }

        //        dr.Close();


        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write("<script>alert('" + ex.Message + "');</script>");
        //    }

        //    return TheID;
        //}
        protected void savedata_Click(object sender, EventArgs e)
        {
            addNew();
            //Response.Redirect("St.aspx");
        }
    }
}