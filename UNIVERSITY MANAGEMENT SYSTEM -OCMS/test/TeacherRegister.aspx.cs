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
    public partial class TeacherRegister : System.Web.UI.Page
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
                string fname = Path.GetFileName(fileuploadT.FileName);
                fileuploadT.SaveAs(Server.MapPath("Teacher-Photos/") + fname);
                SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[TeacherTB]
           ([TeacherName]
           ,[TeacherID]
           ,[TGender]
           ,[TEmail]
           ,[Tadress]
           ,[TNumber]
           ,[Teacherpassword]
           ,[Date]
           ,[TPhoto])
     VALUES
                                    ('"
                    + TeacherFullnametext.Text + "','" + TeacherID.Text + "','" + TeacherGender.Text + "','" + Temail.Text + "','" + TAdressTextBox.Text + "','" + Tnumber.Text + "', '" + Tpaasord.Text + "','" + Tdate.Text + "','" + fileuploadT.FileName + "')", con);



                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('New Admin was added Successfully');</script>");

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
            Response.Redirect("Teacher.aspx");
        }
    }
}