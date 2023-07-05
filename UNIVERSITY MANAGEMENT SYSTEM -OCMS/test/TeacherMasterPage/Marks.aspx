
<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="System.Configuration" %>

<%@ Page Title="" Language="C#" MasterPageFile="~/TeacherMasterPage/TeacherMasterPage.Master" AutoEventWireup="true" CodeBehind="Marks.aspx.cs" Inherits="test.TeacherMasterPage.Marks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

       <div class="app-main" id="main">
                    <!-- begin container-fluid -->
                    <div class="container-fluid">
                        <!-- begin row -->
                        <div class="row">
                            <div class="col-md-12 m-b-30">
                                <!-- begin page title -->
                                <div class="d-block d-sm-flex flex-nowrap align-items-center">
                                    <div class="page-title mb-2 mb-sm-0">
                                        <h1>Marks</h1>
                                    </div>
                                    <div class="ml-auto d-flex align-items-center">
                                        <nav>
                                            <ol class="breadcrumb p-0 m-b-0">
                                                <li class="breadcrumb-item">
                                                    <a href="index.html"><i class="ti ti-home"></i></a>
                                                </li>
                                                <li class="breadcrumb-item">
                                                    Tables
                                                </li>
                                                <li class="breadcrumb-item active text-primary" aria-current="page">Marks Table</li>
                                            </ol>
                                        </nav>
                                    </div>
                                </div>
                                <!-- end page title -->
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
                                                        <th>NO</th>
                                                        <th>COURSE CODE</th>
                                                        <th>COURSE NAME</th>
                                                    
                                                        <th>MID-TERM</th>
                                                        <th>FINAL</th>
                                                        <th>ACTIVITY</th>
                                                        <th>TOTAL</th>
                                                     
                                                   
 
                                                    </tr>
                                                </thead>
                                                <tbody>
                                          <%


                                              try
                                              {
                                                  string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                                                  SqlConnection con = new SqlConnection(strcon);
                                                  if (con.State == System.Data.ConnectionState.Closed)
                                                  {
                                                      con.Open();
                                                  }
                                                  SqlCommand cmd = new SqlCommand("select * from Result ", con);
                                                  SqlDataReader dr = cmd.ExecuteReader();
                                                  if (dr.HasRows)
                                                  {
                                                      while (dr.Read())
                                                      {
                                                          Response.Write("<Tr>");
                                                          Response.Write("<TD>" + dr.GetValue(0).ToString() + "</TD>");
                                                          Response.Write("<TD>" + dr.GetValue(1).ToString() + "</TD>");
                                                          Response.Write("<TD>" + dr.GetValue(2).ToString() + "</TD>");                                                        
                                                          Response.Write("<TD>" + dr.GetValue(5).ToString() + "</TD>");
                                                          Response.Write("<TD>" + dr.GetValue(6).ToString() + "</TD>");
                                                          Response.Write("<TD>" + dr.GetValue(7).ToString() + "</TD>");
                                                          Response.Write("<TD>" + dr.GetValue(8).ToString() + "</TD>");
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
                                                        <th>NO</th>
                                                        <th>COURSE CODE</th>
                                                        <th>COURSE NAME</th>
                                                        <th>MID-TERM</th>
                                                        <th>FINAL</th>
                                                        <th>ACTIVITY</th>
                                                        <th>TOTAL</th>
                                                       
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
