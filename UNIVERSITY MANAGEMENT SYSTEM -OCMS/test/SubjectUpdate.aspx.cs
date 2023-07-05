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
    public partial class SubjectUpdate : System.Web.UI.Page
    {
        public string ID;
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
                SqlCommand cmd = new SqlCommand("select * from SubjectTB where ID='" + ID + "' ", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        DropDownListClass.Text = dr.GetValue(1).ToString();
                        subjecttext.Text = dr.GetValue(2).ToString();
                        subcode.Text = dr.GetValue(3).ToString();
                        Subdate.Text = dr.GetValue(4).ToString();


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

                SqlCommand cmd = new SqlCommand("update SubjectTB set  ClassName='" + DropDownListClass.Text + "', Subject ='" + subjecttext.Text + "' , subCode ='" + subcode.Text + "', Date ='" + Subdate.Text + "'  where ID='" + ID + "' ", con);
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
            EdiNew();
            Response.Redirect("Subject.aspx");
        }
    }
}