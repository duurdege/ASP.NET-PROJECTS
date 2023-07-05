<%@ Page Title="" Language="C#" MasterPageFile="~/MaterPage.Master" AutoEventWireup="true" CodeBehind="ClassUpdate.aspx.cs" Inherits="test.ClassUpdate" %>
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
               <h3 class="card-title  text-white">Class Registration</h3>
              </div>
              <!-- /.card-header -->
              <!-- form start -->
               <form id="form2" runat="server">
                <div class="card-body">
                  <div class="form-group">
                    <label for="Faculty">Faculty</label>
                    <asp:TextBox ID="Facultytext" runat="server" class="form-control" placeholder="Faculty"></asp:TextBox>
                     
                  </div>

                    <div class="form-group">
                    <label for="Department">Department</label>
                  <asp:TextBox ID="Departmenttext" runat="server" class="form-control" placeholder="Department"></asp:TextBox>
                     
                  </div>

               
                    <div class="form-group">
                    <label for="Department">Class</label>
                  <asp:TextBox ID="Classtextbox" runat="server" class="form-control" placeholder="Class"></asp:TextBox>
                     
                  </div>
                   <div class="form-group">
                    <label for="Department">Class Code</label>
                  <asp:TextBox ID="classcodetext" runat="server" class="form-control" placeholder="Class Code"></asp:TextBox>
                     
                  </div>
                 
               
                    <div class="form-group">
                    <label for="exampleInputPassword1">Date</label>
                        <asp:TextBox ID="Classdate" runat="server" class="form-control" TextMode="Date" ></asp:TextBox>
                   </div>
    
          
                </div>
                <!-- /.card-body -->
 
                <div class="card-footer">
                  <asp:Button ID="Updateclass" class="btn btn-success" runat="server" Text="Update" OnClick="Updateclass_Click1"/>
                   
                </div>
              </form>
            </div>
                    </div>
              </div>
     

              </div>
 
              <div class="col-md-2"></div>
          </div>
                
            <!-- /.card -->
                      
                        <!-- end row -->
                        <!-- event Modal -->

</asp:Content>
