<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="System.Configuration" %>

<%@ Page Title="" Language="C#" MasterPageFile="~/MaterPage.Master" AutoEventWireup="true" CodeBehind="AcademicList.aspx.cs" Inherits="test.AcademicList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <!-- begin app-main -->
                <div class="app-main" id="main">
                    <!-- begin container-fluid -->
                    <div class="container-fluid">

                <!-- general form elements -->
               <div class="row">
              <div class="col-md-2"></div>
              <div class="col-md-12">
              <div class="card card-primary">
              <div class="card-header">
                  
                      <form id="formHeader" runat="server">
                                <!-- /.card-body -->
  
                   <div class="row">
              
                       <div class="col-md-11">
                
                      <asp:DropDownList ID="DropDownListacadamy" runat="server" class="form-control" >
                          <asp:ListItem Enabled="True">Semester</asp:ListItem>
                      </asp:DropDownList>
                       
                       </div>
                       <div class="col-md-0">
                        <asp:Button ID="savedata" class="btn btn-success" runat="server" Text="Search" OnClick="savedata_Click"  />

                        
                        </div>
                       </div>

           
   </div>
                  </div>
    
          
                 <!-- end row -->
                        <!-- begin row -->
                        <div class="row">
                            <div class="col-lg-12">
                                <div class="card card-statistics">
                                    <div class="card-body">
                                      
                                        <div class="datatable-wrapper table-responsive">
                                            <table id="datatable" class="display compact table table-striped table-bordered">
                                                <thead>
                                                    <tr>
                                                        <th>Code</th>
                                                        <th>Course</th>
                                                        <th>Class</th>
                                                        <th>Academic Year</th>
                                                        <th>Lecturer</th>
                                                        <th>EMPID</th>
                                                   
 
                                                    </tr>
                                                </thead>
                                                <tbody>
                                          <%

                         string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                         try
                         {
                             SqlConnection con = new SqlConnection(strcon);
                             if (con.State == System.Data.ConnectionState.Closed)
                             {
                                 con.Open();
                             }
                             SqlCommand cmd = new SqlCommand("select * from Academic where Semester ='"+DropDownListacadamy.Text +"' ", con);
                             SqlDataReader dr = cmd.ExecuteReader();
                             if (dr.HasRows)
                             {
                                 while (dr.Read())
                                 {
                                     Response.Write("<Tr>");
                                     Response.Write("<TD>" + dr.GetValue(1).ToString()+ "</TD>");
                                     Response.Write("<TD>" + dr.GetValue(2).ToString()+ "</TD>");
                                     Response.Write("<TD>" + dr.GetValue(3).ToString()+ "</TD>");
                                     Response.Write("<TD>" + dr.GetValue(4).ToString()+ "</TD>");
                                     Response.Write("<TD>" + dr.GetValue(5).ToString()+ "</TD>");
                                     Response.Write("<TD>" + dr.GetValue(6).ToString()+ "</TD>");
                              
                                    
                                     Response.Write("</Tr>");
                                 }
                             }
                             con.Close();
                         }

                         catch (Exception ex)
                         {
                             Response.Write("<script>alert('" + ex.Message + "');</script>");
                         }

                    %>
                                           
                                                </tbody>
                                                <tfoot>
                                                    <tr>
                                                        <th>Code</th>
                                                        <th>Course</th>
                                                        <th>Class</th>
                                                        <th>Academic Year</th>
                                                        <th>Lecturer</th>
                                                        <th>EMPID</th>
                                                        <th>Action</th>
                                                    </tr>
                                                </tfoot>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- end row -->
                    </div>
                    <!-- end container-fluid -->
                </div>
                <!-- end app-main -->
           
            <!-- end app-container -->
                       </form>
                   </div>
                    
                           
                  </div>
             <%--  <h3 class="card-title  text-white">Academic Registration</h3>--%>
              </div>
              <!-- /.card-header -->
              <!-- form start -->
         
            
 
              <div class="col-md-2"></div>
          </div>
                </div>
</asp:Content>
