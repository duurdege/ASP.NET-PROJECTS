
<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="System.Configuration" %>

<%@ Page Title="" Language="C#" MasterPageFile="~/MaterPage.Master" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="test.Student" %>
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
                                        <h1>Teacher List </h1>
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
                                  <%--    <a href="AdminRegistration.aspx">--%>
<%--                                        <asp:Button type="submit" Text="Add New Student" class="btn btn-success" style="float:Right;" runat="server"  /> </a>--%>
                                        <div class="datatable-wrapper table-responsive">
                                            <table id="datatable" class="display compact table table-striped table-bordered">
                                                <thead>
                                                    <tr>
                                                        <th>ID</th>
                                                        <th>Name</th>
                                                        <th>Student ID</th>
                                                        <th>Number</th>
                                                        <th>Email</th>
                                                        <th>Adress</th>
                                                        <th>Gender</th>
                                                        <th>Password</th>
                                                        <th>Date</th>
                                                        <th>Faculty</th>
                                                        <th>Department</th>
                                                        <th>Class</th>
                                                        <th>Semester</th>
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
                             SqlCommand cmd = new SqlCommand("select * from student ", con);
                             SqlDataReader dr = cmd.ExecuteReader();
                             if (dr.HasRows)
                             {
                                 while (dr.Read())
                                 {
                                     Response.Write("<Tr>");
                                     Response.Write("<TD>" + dr.GetValue(0).ToString()+ "</TD>");
                                     Response.Write("<TD>" + dr.GetValue(1).ToString()+ "</TD>");
                                     Response.Write("<TD>" + dr.GetValue(2).ToString()+ "</TD>");
                                     Response.Write("<TD>" + dr.GetValue(3).ToString()+ "</TD>");
                                     Response.Write("<TD>" + dr.GetValue(4).ToString()+ "</TD>");
                                     Response.Write("<TD>" + dr.GetValue(5).ToString()+ "</TD>");
                                     Response.Write("<TD>" + dr.GetValue(6).ToString()+ "</TD>");
                                     Response.Write("<TD>" + dr.GetValue(7).ToString()+ "</TD>");
                                     Response.Write("<TD>" + dr.GetValue(8).ToString()+ "</TD>");
                                     Response.Write("<TD>" + dr.GetValue(9).ToString()+ "</TD>");
                                     Response.Write("<TD>" + dr.GetValue(10).ToString()+ "</TD>");
                                     Response.Write("<TD>" + dr.GetValue(11).ToString()+ "</TD>");
                                     Response.Write("<TD>" + dr.GetValue(12).ToString()+ "</TD>");
                                    
                                     Response.Write("<TD> <a href='StudentUpdate.aspx?Reffno="+ dr.GetValue(0).ToString()+"'class='btn btn-success btn-xs'><i class='fa fa-edit'></i> " +
                                         "</a> <a href='StudentDelete.aspx?Reffno="+ dr.GetValue(0).ToString()+"'class='btn btn-warning btn-xs'><i class='fa fa-trash'></i> </a> " + "</TD>");

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
                                                        <th>ID</th>
                                                        <th>Name</th>
                                                        <th>Student ID</th>
                                                        <th>Number</th>
                                                        <th>Email</th>
                                                        <th>Adress</th>
                                                        <th>Gender</th>
                                                        <th>Password</th>
                                                        <th>Date</th>
                                                        <th>Faculty</th>
                                                        <th>Department</th>
                                                        <th>Class</th>
                                                        <th>Semester</th>
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
