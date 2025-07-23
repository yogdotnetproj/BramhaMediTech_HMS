<%@ Page Title="" Language="C#" MasterPageFile="~/HospitalTemp.master"  AutoEventWireup="true" CodeFile="PatientInsuranceDetails.aspx.cs" Inherits="PatientInsuranceDetails" %>
<%-- --%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
     <script type = "text/javascript">
         function Validate() {

             if (document.getElementById("MainContent_ddlInsuranceCompany").value == "0") {

                 alert("select Company Name");
                 return false;
             }

             if (document.getElementById("MainContent_txtPatientName").value == "") {

                 alert("Please Enter Patient Name !");
                 return false;

             }


             if (document.getElementById("MainContent_txtMembershipNo").value == "") {
                 alert("Please Enter Membership No!");
                 return false;
             }
             if (document.getElementById("MainContent_txtAge").value == "") {
                 alert("Please Enter Age!");
                 return false;
             } 
             if (document.getElementById("MainContent_txtRelation").value == "") {
                 alert("Please Enter Relation!");
                 return false;
             }
             if (document.getElementById("MainContent_txtMemberName").value == "") {
                 alert("Please Enter Member Name!");
                 return false;
             }
         }

       </script>
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
           

            <section class="content-header d-flex">
                    <h1>Patient Insurance Details</h1>
                    <ol class="breadcrumb">
                       <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                      <li class="breadcrumb-item active">Patient Insurance Details</li>
                    </ol>
                </section>
            <section class="content">
                           <div class="box" runat="server" id="show">
                                <div class="box-header with-border">
                                    <asp:Label ID="lblMessage" class="red pull-center"  runat="server" Text="" Font-Bold="true" ForeColor="green" ></asp:Label>                              
                                    <span class="red pull-right">Fields marked with * are compulsory</span>                                 
                                </div>
                                <div class="box-body">
                                        <div class="row"> 
                                                       
                                            <div class="col-lg-12">
                                             <div class="row"> 
                                                 <div class="col-lg-1 text-left" style="width:600px">

                                                    <div class="form-Inline"> 
                                                         <asp:RadioButtonList ID="RdbCompany" runat="server" AutoPostBack="true" Width="300px" RepeatDirection="Horizontal" OnSelectedIndexChanged="RdbCompany_SelectedIndexChanged" >
                                                             <asp:ListItem Selected="True">Insurance</asp:ListItem>
                                                             <asp:ListItem>Corporate</asp:ListItem>                                                            
                                                          </asp:RadioButtonList>                                              
                      
                                                        </div>
                                                     </div>
                                                
                                            
                                        </div>
                                            </div>  
                                             <div class="col-lg-12">
                                                 <div class="row">                                                                 
                                                     <div class="col-lg-1" style="width:230px">
                                                          <div class="form-group">
                                                                 <label for="ddlInsuranceCompany" style="text-align:left">Insurance/Corporate Company:<span style="color:red">*</span></label> 
                                                              
                                                                                                                                                 
                                                          </div>
                                                     </div>
                                                     <div class="col-lg-3" style="width:300px">
                                                        <div class="form-group">                                                                                                    
                                                             <asp:DropDownList ID="ddlInsuranceCompany" runat="server" class="form-control">                                                        
                                                             </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                 </div>
                                               </div>
                                             
                                                
                                            <div class="col-lg-12">
                                                <div class="row">  
                                                     <div class="col-lg-1 text-left" style="width:230px">
                                                        <div class="form-group"> 
                                                            <label for="txtPatientName" style="text-align:left">Patient Name:<span style="color:red">*</span></label>                                                                                                                                                                                              
                                                         </div>
                                                      </div> 
                                                <div class="col-lg-1 text-left" style="width:70px">
                                                           
                                            <div class="form-group">  
                                                                                                         
                                                <asp:DropDownList ID="ddlTitleName" runat="server"  CssClass="form-control pull-left" AutoPostBack="True" 
                                                 Width="70px" TabIndex="5">
                                                </asp:DropDownList>
                                                
                                            </div>
                                        </div>
                                                                            
                                                <div class="col-lg-2 text-left" style="width:250px"  >
                                                    <div class="form-group">                 
                                   
                                                <asp:TextBox ID="txtPatientName" runat="server"  AutoCompleteType="None"  CssClass="form-control" placeholder="Enter Patient Name(*)"
                                                Width="230px"  onkeyPress="return alpha_only(event);"></asp:TextBox>
                                               
                                             </div>
                                        </div>
                                           
                                             </div>
                                            </div>
                                            <div class="col-lg-12">
                                                <div class="row">                                            
                                                  <div class="col-lg-1 text-left" style="width:230px">
                                                        <div class="form-group"> 
                                                            <label for="txtPatientAddress" style="text-align:left">Address:<span style="color:red">*</span></label>                                                                                                                                                                                              
                                                         </div>
                                                      </div>
                                                <div id="Div2" class="col-lg-2  text-left" runat="server"  style="width:310px">
                                                    <div class="form-group">
                                                       <asp:TextBox ID="txtPatientAddress" runat="server" class="form-control"   placeholder="Enter Patient Address"
                                            TabIndex="9"  Width="300px"></asp:TextBox>
                                                    </div>
                                                   </div>                                           
                                                 </div>  
                                         </div>     
                                            <div class="col-lg-12">
                                                <div class="row">  
                                                      <div class="col-lg-1 text-left" style="width:230px" >
                                            <div class="form-group">
                                                <label for="ddlGender" style="text-align:left">Gender:<span style="color:red">*</span></label>  
                                                </div>
                                              </div>
                                                      <div class="col-lg-2 text-left" style="width:180px">                                                    
                                                    <div class="form-group">
                                                                                                                              
                                                        <asp:DropDownList ID="ddlGender" runat="server" AutoPostBack="True" class="form-control"
                                                         Width="170px" 
                                                        TabIndex="9" Enabled="true">
                                                        </asp:DropDownList>
                                                    </div>
                                               </div>                                          
                                                      <div class="col-lg-1 text-left" style="width:50px">
                                                        <div class="form-group"> 
                                                            <label for="txtAge" style="text-align:left">Age:<span style="color:red">*</span></label>                                                                                                                                                                                              
                                                         </div>
                                                      </div> 
                                                      <div class="col-lg-1 text-left" style="width:70px">
                                                           <div class="form-group"> 
                                                                                                                     
                                                       
                                                                <asp:TextBox ID="txtAge" runat="server" TabIndex="10" class="form-control" placeholder="Age" 
                                                                Width="70px"  onkeyPress="return numeric_only(event);" AutoPostBack="True"></asp:TextBox>
                                                            
                                                           </div>
                                                         </div> 
                                                       <div class="col-lg-1 text-left" style="width:100px">
                                                            <div class="form-group">
                                                                
                                                                    <asp:DropDownList ID="ddlAge" runat="server" AutoPostBack="True" 
                                                                        class="form-control" 
                                                                        TabIndex="11" Width="90px" 
                                                                        >
                                                                        <asp:ListItem>Years</asp:ListItem>
                                                                        <asp:ListItem>Months</asp:ListItem>
                                                                        <asp:ListItem>Days</asp:ListItem>
                                                                    </asp:DropDownList>
                                                           </div>
                                                           
                                                         
                                                        </div>                                      
                                                 </div>  
                                         </div>  
                                             <div class="col-lg-12">
                                                <div class="row">  
                                                     <div class="col-lg-1 text-left" style="width:230px">
                                                        <div class="form-group"> 
                                                            <label for="txtMembershipNo" style="text-align:left">Membership No:<span style="color:red">*</span></label>                                                                                                                                                                                              
                                                         </div>
                                                      </div> 
                                                     <div class="col-lg-2 text-left" style="width:300px"  >
                                                       <div class="form-group">
                                                             <asp:TextBox ID="txtMembershipNo" runat="server"    CssClass="form-control" placeholder="Enter Membership No (*)"
                                                                 Width="300px"  ></asp:TextBox>                                               
                                                        </div>
                                                     </div>          
                                                    </div>
                                                 </div>     
                                            <div class="col-lg-12">
                                                <div class="row">  
                                                     <div class="col-lg-1 text-left" style="width:230px">
                                                        <div class="form-group"> 
                                                            <label for="txtMemberName" style="text-align:left">Member Name:<span style="color:red">*</span></label>                                                                                                                                                                                              
                                                         </div>
                                                      </div> 
                                                     <div class="col-lg-1 text-left" style="width:70px">
                                                           
                                            <div class="form-group">  
                                                                                                         
                                                <asp:DropDownList ID="ddlmemberTitle" runat="server"  CssClass="form-control pull-left" AutoPostBack="True" 
                                                 Width="70px" TabIndex="5">
                                                </asp:DropDownList>
                                                
                                            </div>
                                        </div>                                                                            
                                                     <div class="col-lg-2 text-left" style="width:250px"  >
                                                    <div class="form-group">                 
                                   
                                                <asp:TextBox ID="txtMemberName" runat="server"    CssClass="form-control" placeholder="Enter Member Name(*)"
                                                Width="230px"    onkeyPress="return alpha_only(event);"></asp:TextBox>
                                               
                                             </div>
                                        </div>                                           
                                                </div>
                                            </div>                      
                                           <div class="col-lg-12">
                                                <div class="row">  
                                                     <div class="col-lg-1 text-left" style="width:230px">
                                                        <div class="form-group"> 
                                                            <label for="txtRelation" style="text-align:left">Relation:<span style="color:red">*</span></label>                                                                                                                                                                                              
                                                         </div>
                                                      </div> 
                                                     <div class="col-lg-2 text-left" style="width:250px"  >
                                                       <div class="form-group">
                                                             <asp:TextBox ID="txtRelation" runat="server"    CssClass="form-control" placeholder="Enter Relation (*)"
                                                                 Width="230px"  ></asp:TextBox>                                               
                                                        </div>
                                                     </div>          
                                                    </div>
                                                 </div>          
                                       
                                        <div class="col-lg-12 text-center">
                                    
                                              <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" class="btn btn-primary" OnClientClick="return Validate();"
                                             Width="80px" />
                                              <asp:Button ID="btnReset" runat="server" Text="Close" OnClick="btnReset_Click" class="btn btn-primary" Width="80px"
                                              CausesValidation="False" />
                                            
                                             
                                        </div>
                                    </div>

                                       
                                    
                               </div>                               
                               
                            </div>

                 

                        </section>


        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>



