<%@ Page Title="" Language="C#" MasterPageFile="~/MaterPage.Master" AutoEventWireup="true" CodeBehind="SubjectUpdate.aspx.cs" Inherits="test.SubjectUpdate" %>
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
                    <label for="Faculty">Class</label>
                      <asp:DropDownList ID="DropDownListClass" runat="server" class="form-control" >
                          <asp:ListItem Enabled="True">Select Class</asp:ListItem>
                      </asp:DropDownList>
                  </div>

                    <div class="form-group">
                    <label for="Department">Subject</label>
                  <asp:TextBox ID="subjecttext" runat="server" class="form-control" placeholder="Subject"></asp:TextBox>
                     
                  </div>

             
                   <div class="form-group">
                    <label for="Department">Sub Code</label>
                  <asp:TextBox ID="subcode" runat="server" class="form-control" placeholder="Subject Code"></asp:TextBox>
                     
                  </div>
                 
               
                    <div class="form-group">
                    <label for="exampleInputPassword1">Date</label>
                        <asp:TextBox ID="Subdate" runat="server" class="form-control" TextMode="Date" ></asp:TextBox>
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
