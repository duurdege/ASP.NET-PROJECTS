<%@ Page Title="" Language="C#" MasterPageFile="~/MaterPage.Master" AutoEventWireup="true" CodeBehind="AcademicUpdate.aspx.cs" Inherits="test.AcademicUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <!-- begin app-main -->
                <div class="app-main" id="main">
                    <!-- begin container-fluid -->
                    <div class="container-fluid">

                <!-- general form elements -->
               <div class="row">
              <div class="col-md-2"></div>
              <div class="col-md-8">
              <div class="card card-primary">
              <div class="card-header bg-primary ">
               <h3 class="card-title  text-white">Academic Registration</h3>
              </div>
              <!-- /.card-header -->
              <!-- form start -->
               <form id="form2" runat="server">
                <div class="card-body">
                  <div class="form-group">
                    <label for="Faculty">Code</label>
                      <asp:DropDownList ID="CourseCode" runat="server" class="form-control" >
                          <asp:ListItem Enabled="True">Course Code</asp:ListItem>
                      </asp:DropDownList>
                  </div>

              <%--    <div class="form-group">
                    <label for="Faculty">Course</label>
                      <asp:DropDownList ID="DropDownListCourse" runat="server" class="form-control" >
                          <asp:ListItem Enabled="True">Course </asp:ListItem>
                      </asp:DropDownList>
                  </div>

             
                   <div class="form-group">
                    <label for="Faculty">Class</label>
                      <asp:DropDownList ID="DropDownListClass" runat="server" class="form-control" >
                          <asp:ListItem Enabled="True">Class</asp:ListItem>
                      </asp:DropDownList>
                  </div>--%>
               
                    <div class="form-group">
                    <label for="exampleInputPassword1">Academic Year</label>
                        <asp:TextBox ID="Academicyear" runat="server" class="form-control" placeholder="Academic Year" ></asp:TextBox>
                   </div>


                         <div class="form-group">
                    <label for="exampleInputPassword1">Semester</label>
                        <asp:TextBox ID="academicsemester" runat="server" class="form-control" placeholder="Semester"></asp:TextBox>
                   </div>
                   <%--   <div class="form-group">
                    <label for="Faculty">Lecturer</label>
                      <asp:DropDownList ID="DropDownListlecturer" runat="server" class="form-control" >
                          <asp:ListItem Enabled="True">Lecturer</asp:ListItem>
                      </asp:DropDownList>
                  </div>--%>

                         <div class="form-group">
                    <label for="Faculty">EMPID</label>
                      <asp:DropDownList ID="DropDownListEMPID" runat="server" class="form-control" >
                          <asp:ListItem Enabled="True">EPMID</asp:ListItem>
                      </asp:DropDownList>
                  </div>
    
          
                </div>
                <!-- /.card-body -->
 
                <div class="card-footer">
                  <asp:Button ID="Updatedata" class="btn btn-success" runat="server" Text="Update" OnClick="Updatedata_Click"/>
                   
                </div>
              </form>
            </div>
                    </div>
              </div>
     

              </div>
 
              <div class="col-md-2"></div>
          </div>
                </div>
            <!-- /.card -->
                      
                        <!-- end row -->
                        <!-- event Modal -->

</asp:Content>
