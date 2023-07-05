<%@ Page Title="" Language="C#" MasterPageFile="~/TeacherMasterPage/TeacherMasterPage.Master" AutoEventWireup="true" CodeBehind="MarksRegister.aspx.cs" Inherits="test.TeacherMasterPage.MarksRegister" %>
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
               <h3 class="card-title  text-white">Result Registration</h3>
              </div>
              <!-- /.card-header -->
              <!-- form start -->
               <form id="form2" runat="server">
                <div class="card-body">
                  <div class="form-group">
                    <label for="Faculty"> Course Code</label>
                      <asp:DropDownList ID="CourseCode" runat="server" class="form-control" >
                          <asp:ListItem Enabled="True">Course Code</asp:ListItem>
                      </asp:DropDownList>
                  </div>
 
               
                     <div class="form-group">
                    <label for="Faculty">EMPID</label>
                      <asp:DropDownList ID="DropDownListEMPID" runat="server" class="form-control"    >
                          <asp:ListItem Enabled="True"> Lecturer ID</asp:ListItem>
                      </asp:DropDownList>
                  </div>

                    
                         <div class="form-group">
                    <label for="Faculty">Student ID</label>
                      <asp:DropDownList ID="DropDownListStudentId" runat="server" class="form-control"  >
                          <asp:ListItem Enabled="True">Student ID</asp:ListItem>
                      </asp:DropDownList>
                  </div>

                         <div class="form-group">
                    <label for="exampleInputPassword1">Mid-Tearm</label>
                        <asp:TextBox ID="Midtearm" runat="server" class="form-control" placeholder="MID-TEARM"></asp:TextBox>
                   </div>

                         <div class="form-group">
                    <label for="exampleInputPassword1">Final</label>
                        <asp:TextBox ID="TextBoxFINAL" runat="server" class="form-control" placeholder="FINAL"></asp:TextBox>
                   </div>

                         <div class="form-group">
                    <label for="exampleInputPassword1">ACTIVITY</label>
                        <asp:TextBox ID="ACTIVITIES" runat="server" class="form-control" placeholder="Activity"></asp:TextBox>
                   </div>
    
          
                </div>
                <!-- /.card-body -->
 
                <div class="card-footer">
                  <asp:Button ID="savedata" class="btn btn-primary" runat="server" Text="SAVE" OnClick="savedata_Click"/>
                   
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
