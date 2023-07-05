
<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="System.Configuration" %>


<%@ Page Title="" Language="C#" MasterPageFile="~/MaterPage.Master" AutoEventWireup="true" CodeBehind="Academic.aspx.cs" Inherits="test.Academic" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

          <!-- begin app-main -->
                <div class="app-main" id="main">
                    <!-- begin container-fluid -->
                    <div class="container-fluid">
                        <!-- begin row -->
                        <div class="row">
                            <div class="col-md-12 m-b-30">
                                <!-- begin page title -->
                                <div class="d-block d-sm-flex flex-nowrap align-items-center">
                                    <div class="page-title mb-2 mb-sm-0">
                                        <h1>Academic Year</h1>
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
                                                <li class="breadcrumb-item active text-primary" aria-current="page">Admin Form</li>
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
                                                        <th>Code</th>
                                                        <th>Course</th>
                                                        <th>Class</th>
                                                        <th>Academic Year</th>
                                                        <th>Lecturer</th>
                                                        <th>EMPID</th>
                                                        <th>Action</th>  
 
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
                             SqlCommand cmd = new SqlCommand("select * from Academic ", con);
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
                              
                                     Response.Write("<TD> <a href='AcademicUpdate.aspx?Reffno="+ dr.GetValue(0).ToString()+"'class='btn btn-success btn-xs'><i class='fa fa-edit'></i> " +
                                         "</a> <a href='AcademicDelete.aspx?Reffno="+ dr.GetValue(0).ToString()+"'class='btn btn-warning btn-xs'><i class='fa fa-trash'></i> </a> " + "</TD>");

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

</asp:Content>
