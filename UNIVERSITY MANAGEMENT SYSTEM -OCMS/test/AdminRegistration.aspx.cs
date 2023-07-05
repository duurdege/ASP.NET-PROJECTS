using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.IO;

namespace test
{
    public partial class AdminRegistration : System.Web.UI.Page
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
                string fname = Path.GetFileName(fileupload1.FileName);
                fileupload1.SaveAs(Server.MapPath("images/") + fname);
                SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[AdminTB]
           ([AdminNmae]
           ,[AdminUser]
           ,[Gender]
           ,[Email]
           ,[Number]
           ,[Adminpassword]
           ,[Date]
           ,[Photo])
     VALUES
                                    ('"
                    + adminfullname.Text + "','" + ausername.Text + "','" + AdminGender.Text + "','" + aemail.Text + "','" + anumber.Text + "','" + apaasord.Text + "','" + adate.Text + "','" + fileupload1.FileName + "')", con);



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
            Response.Redirect("Admin.aspx");
        }
    }
}