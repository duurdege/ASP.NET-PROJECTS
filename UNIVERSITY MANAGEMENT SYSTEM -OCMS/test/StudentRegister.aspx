<%@ Page Title="" Language="C#" MasterPageFile="~/MaterPage.Master" AutoEventWireup="true" CodeBehind="StudentRegister.aspx.cs" Inherits="test.StudentRegister" %>
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
               <h3 class="card-title  text-white">Student Registration Form</h3>
              </div>
              <!-- /.card-header -->
              <!-- form start -->
               <form id="form2" runat="server">
                <div class="card-body">
                  <div class="form-group">
                    <label for="exampleInputEmail1">Full Name</label>
                    <asp:TextBox ID="StudentFullnametext" runat="server" class="form-control" placeholder="Full name"></asp:TextBox>
                     
                  </div>

                    <div class="form-group">
                    <label for="exampleInputPassword1">Student ID</label>
                  <asp:TextBox ID="StudentID" runat="server" class="form-control" placeholder="Student ID"></asp:TextBox>
                     
                  </div>

                     <div class="form-group">
                    <label for="exampleInputPassword1">Gender</label>
                         <asp:DropDownList ID="StudentGender" runat="server" class="form-control">
                              <asp:ListItem>Choose</asp:ListItem>
                             <asp:ListItem>Male</asp:ListItem>
                             <asp:ListItem>Female</asp:ListItem>
                         </asp:DropDownList>
                      
                  </div>

                     <div class="form-group">
                    <label for="exampleInputEmail1">Email</label>
                         <asp:TextBox ID="Semail" runat="server" class="form-control" placeholder="Enter email"></asp:TextBox>
                   </div>

                     <div class="form-group">
                    <label for="exampleInputEmail1">Adress</label>
                     <asp:TextBox ID="SAdressTextBox" runat="server" class="form-control" placeholder="Adress"></asp:TextBox>
                   </div>

                     <div class="form-group">
                    <label for="exampleInputEmail1">Number</label>
                     <asp:TextBox ID="Snumber" runat="server" class="form-control" placeholder="Number"></asp:TextBox>
                   </div>

                  <div class="form-group">
                    <label for="exampleInputPassword1">Password</label>
                      <asp:TextBox ID="Spaasord" runat="server" class="form-control" placeholder="password"></asp:TextBox>
                   </div>
                    <div class="form-group">
                    <label for="exampleInputPassword1">Date</label>
                        <asp:TextBox ID="Sdate" runat="server" class="form-control" TextMode="Date" ></asp:TextBox>
                   </div>

                    <div class="form-group">
                    <label for="Faculty">Faculty</label>
                      <asp:DropDownList ID="DropDownListStudentFaculty" runat="server" class="form-control" >
                          <asp:ListItem Enabled="True">Select Faculty</asp:ListItem>
                      </asp:DropDownList>
                  </div>

                         <div class="form-group">
                    <label for="Faculty">Department</label>
                      <asp:DropDownList ID="DropDownListStudentDepartment" runat="server" class="form-control" >
                          <asp:ListItem Enabled="True">Select Department</asp:ListItem>
                      </asp:DropDownList>
                  </div>

                     <div class="form-group">
                    <label for="Faculty">Class</label>
                      <asp:DropDownList ID="DropDownListStudentClass" runat="server" class="form-control" >
                          <asp:ListItem Enabled="True">Select Class</asp:ListItem>
                      </asp:DropDownList>
                  </div>

                     <div class="form-group">
                    <label for="exampleInputPassword1">Semester</label>
                      <asp:TextBox ID="TextBoxStudentSemester" runat="server" class="form-control" placeholder="Semester"></asp:TextBox>
                   </div>

                  <div class="form-group">
                    <label for="exampleInputFile">File input</label>
                    <div class="input-group">
                      <div class="custom-file">
                       <asp:FileUpload ID="fileuploadS" runat="server" class="custom-file-input" />
                        <%--<input type="file" class="custom-file-input" id="exampleInputFile">--%>
                        <label class="custom-file-label" for="exampleInputFile">Choose file</label>
                      </div>
                      <div class="input-group-append">
                        <span class="input-group-text" id="">Upload</span>
                      </div>
                    </div>
                  </div>
                  <div class="form-check">
                    <input type="checkbox" class="form-check-input" id="exampleCheck1">
                    <label class="form-check-label" for="exampleCheck1">Check me out</label>
                  </div>
                </div>
                <!-- /.card-body -->
 
                <div class="card-footer">
                  <asp:Button ID="savedata" class="btn btn-primary" runat="server" Text="Register" OnClick="savedata_Click" />
                   
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
                      
                   
                    <!-- end container-fluid -->
              
                <!-- end app-main -->
         
    
            <!-- end app-container -->
            <!-- begin footer -->

</asp:Content>
