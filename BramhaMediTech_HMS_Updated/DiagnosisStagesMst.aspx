<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="DiagnosisStagesMst.aspx.cs" Inherits="DiagnosisStagesMst" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

     <script type = "text/javascript">
         function Validate() {

             if (document.getElementById("MainContent_txtICDCode").value == "") {
                 alert("Please Enter IcDCode");
                 return false;
             }

             if (document.getElementById("MainContent_txtDiagnosis1").value == "") {

                 alert("Please Enter Diagnosis!");
                 return false;

             }
         }
        </script>

     <asp:ScriptManager ID="ScriptManager1" runat="server">

    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <section class="content-header d-flex">
                    <h1>Diagnosis Stages Master</h1>
                    <ol class="breadcrumb">
                         <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="breadcrumb-item active">Diagnosis Stages Master</li>
                    </ol>
                </section>
    <section class="content">
                    <div class="box">
                        <div class="box-header with-border">
                            <asp:Label ID="lblMessage" class="red pull-center"  runat="server" Text="" Font-Bold="true" ForeColor="green" ></asp:Label>
                            <span class="red pull-right">Fields marked with * are compulsory</span> 
                       <div class="col-lg-12" > 
                                            <div class="row">
                              <asp:Button ID="btnDstage1" runat="server" CssClass="btn btn-primary pull-left mr-2" Width="200px"  TabIndex="3" Text="Diagnosis Stage 1" OnClick="btnDstage1_Click"   />
                                        <asp:Button ID="btnDstage2" runat="server" CssClass="btn btn-primary pull-left mr-2" Width="200px" TabIndex="2" Text="Diagnosis Stage 2" OnClick="btnDstage2_Click"  />
                                        <asp:Button ID="btnDstage3" runat="server" CausesValidation="False"  Width="200px" CssClass="btn btn-primary pull-left"
                                              Text="Diagnosis Stage 3" OnClick="btnDstage3_Click" />
                                                </div>
                           </div>
                               
                        </div>

                        <div class="box-body" id="Diagno1" runat="server">
                            <div class="row mb-3">
                                <div class="col-sm-2">
                                    <div class="form-group">
                                         <label for="txtICDCode">ICD Code:</label>                                                                                
                                        </div>
                                    </div>
                                <div class="col-sm-3">
                                    <div class="form-group"> 
                                          <asp:TextBox ID="txtICDCode" runat="server" placeholder="Enter ICD code(*)" CssClass="form-control" TabIndex="1"></asp:TextBox>
                                   </div>
                                </div>
                            </div>

                                 
                                            <div class="row mb-3">
                                                 <div class="col-sm-2">
                                    <div class="form-group">
                                         <label for="txtDiagnosis1">Diagnosis:</label>                                                                                
                                        </div>
                                    </div>
                                <div class="col-sm-3 text-left">
                                    <div class="form-group"> 
                                          <asp:TextBox ID="txtDiagnosis1" runat="server" placeholder="Enter Diagnosis(*)" CssClass="form-control" TabIndex="1"></asp:TextBox>
                                   </div>
                                </div>
                                                
                                    

                                <div class="col-sm-4 text-left">
                                    <div class="form-group">
                                        
                                        <asp:Button ID="btnsaveD1" runat="server" CssClass="btn btn-primary"  TabIndex="3" Text="Save" OnClientClick="return Validate();" OnClick="btnsaveD1_Click"  />
                                        <asp:Button ID="btnResetD1" runat="server" CssClass="btn btn-primary"  TabIndex="2" Text="Reset" OnClick="btnResetD1_Click" />
                                        
                                       
                                    </div>
                                </div>
                                                </div>
               
                               
                                            <div class="row">
                   <div class="table-responsive" style="width:100%">
                  <asp:GridView ID="gvDiagno1" runat="server" class="table table-responsive table-sm table-bordered" AutoGenerateColumns="False" 
                    Width="592px" OnPageIndexChanging="gvDiagno1_PageIndexChanging" OnRowEditing="gvDiagno1_RowEditing"
                    DataKeyNames="TrDiagnoId" AllowPaging="True" PageSize="15" OnRowDeleting="gvDiagno1_RowDeleting"   HeaderStyle-ForeColor="Black"
                    AlternatingRowStyle-BackColor="White">
                         <AlternatingRowStyle BackColor="#95deff"></AlternatingRowStyle>
                       <Columns>
                                <asp:CommandField ButtonType="Image" EditImageUrl="~/Images0/edit.gif" 
                                     ShowCancelButton="False" ShowEditButton="True">
                                <ItemStyle HorizontalAlign="Center" Width="70px" />
                                </asp:CommandField>
                                <%--<asp:BoundField DataField="PatientInsuTypeId" HeaderText="Patient Category Id" 
                                    Visible="False" />--%>
                                <asp:BoundField DataField="TrDiagnoName" HeaderText="Diagnosis Name" /> 
                                                                    
                                
                                <asp:BoundField DataField="ICDId" HeaderText="ICD Code" /> 
                                   
                               
                               
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="Delete" runat="server" CommandName="Delete" 
                                             ImageUrl="~/Images0/delete.gif" 
                                            OnClientClick="return ValidateDelete()" 
                                            ToolTip="Click here to Delete this record" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="70px" />
                                </asp:TemplateField>
                            </Columns>
                             <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#38C8DD" Font-Bold="True" ForeColor="White" />
                            <PagerStyle CssClass="pagination" BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                            <RowStyle ForeColor="#000066" />
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                        </asp:GridView>
                </div>
                                                </div>
                       
                   

                            
                        </div>

                        <div class="box-body" id="Diagno2" runat="server">
                            <div class="row">
                                <div class="col-lg-1" style="width:180px">
                                    <div class="form-group">
                                         <label for="ddlParentDiagno" style="text-align:left">Parent Diagnosis:</label>                                                                                
                                        </div>
                                    </div>
                                <div class="col-lg-3 text-left">
                                    <div class="form-group">                                     
                   <asp:DropDownList ID="ddlParentDiagno" runat="server" AutoPostBack="True"
                                                OnSelectedIndexChanged="ddlParentDiagno_SelectedIndexChanged" Class="form-control"
                                                 TabIndex="2"></asp:DropDownList>
                                   </div>
                                </div>
                                <div class="col-lg-12" > 
                                            <div class="row">
                                                 <div class="col-lg-1" style="width:180px">
                                    <div class="form-group">
                                         <label for="txtDiagno2" style="text-align:left">Diagnosis:</label>                                                                                
                                        </div>
                                    </div>
                                                <div class="col-lg-3 text-left">
                                    <div class="form-group"> 
                                          <asp:TextBox ID="txtDiagno2" runat="server" placeholder="Enter Diagnosis(*)" class="form-control" TabIndex="1"></asp:TextBox>
                                   </div>
                                </div>
                                                </div>
                                    </div>
                                                
                                    
                                <div class="col-lg-12" > 
                                            <div class="row">
                                                 <div class="col-lg-1" style="width:180px">
                                    <div class="form-group">
                                         <label for="txtIcd2" style="text-align:left">ICD Stage2 Code:</label>                                                                                
                                        </div>
                                    </div>
                                        <div class="col-lg-3 text-left">
                                    <div class="form-group"> 
                                          <asp:TextBox ID="txtIcd2" runat="server" placeholder="Enter ICD Code(*)" class="form-control" TabIndex="1"></asp:TextBox>
                                   </div>
                                </div>

                                <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                        
                                        <asp:Button ID="btnSaveDiagno2" runat="server" class="btn btn-primary"  TabIndex="3" Text="Save" OnClientClick="return Validate();" OnClick="btnSaveDiagno2_Click"  />
                                        <asp:Button ID="btnResetDiagno2" runat="server" class="btn btn-primary"  TabIndex="2" Text="Reset" OnClick="btnResetDiagno2t_Click" />
                                        
                                       
                                    </div>
                                </div>
                                                </div>
               </div>
                                 <div class="col-lg-12" > 
                                            <div class="row">
                   <div class="table-responsive" style="width:100%">
                  <asp:GridView ID="gvDiagno2" runat="server" class="table table-responsive table-sm table-bordered" AutoGenerateColumns="False" 
                    Width="592px" OnPageIndexChanging="gvDiagno2_PageIndexChanging" OnRowEditing="gvDiagno2_RowEditing"
                    DataKeyNames="TrDiagnostage2Id" AllowPaging="True" PageSize="15" OnRowDeleting="gvDiagno2_RowDeleting"   HeaderStyle-ForeColor="Black"
                    AlternatingRowStyle-BackColor="White">
                       <Columns>
                                <asp:CommandField ButtonType="Image" EditImageUrl="~/Images0/edit.gif" 
                                     ShowCancelButton="False" ShowEditButton="True">
                                
                                </asp:CommandField>
                                <asp:BoundField DataField="TrDiagnostage2Id" HeaderText="TrDiagnostage2Id" 
                                    Visible="False" />
                                <asp:BoundField DataField="TrDiagnoNameStg2" HeaderText="Diagnosis" />
                                    
                                
                                <asp:BoundField DataField="Stage2Id" HeaderText="ICD Stage2 Code" 
                                    ItemStyle-HorizontalAlign="Left"/>
                               
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="Delete" runat="server" CommandName="Delete" 
                                             ImageUrl="~/Images0/delete.gif" 
                                            OnClientClick="return ValidateDelete()" 
                                            ToolTip="Click here to Delete this record" />
                                    </ItemTemplate>
                                    
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                            <RowStyle ForeColor="#000066" />
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                        </asp:GridView>
                </div>
                                                </div>
                       
                    </div>

                            </div>
                        </div>

                        <div class="box-body" id="Diagno3" runat="server">
                            <div class="row">
                                <div class="col-lg-1" style="width:180px">
                                    <div class="form-group">
                                         <label for="ddlParentDiagno2" style="text-align:left">Parent Diagnosis:</label>                                                                                
                                        </div>
                                    </div>
                                <div class="col-lg-3 text-left">
                                    <div class="form-group">                                     
                   <asp:DropDownList ID="ddlParentDiagno2" runat="server" AutoPostBack="True"
                                                OnSelectedIndexChanged="ddlParentDiagno2_SelectedIndexChanged" Class="form-control"
                                                 TabIndex="2"></asp:DropDownList>
                                   </div>
                                </div>
                                <div class="col-lg-12" > 
                                            <div class="row">
                                                 <div class="col-lg-1" style="width:180px">
                                    <div class="form-group">
                                         <label for="txtDiagno3" style="text-align:left">Diagnosis:</label>                                                                                
                                        </div>
                                    </div>
                                     <div class="col-lg-3 text-left">
                                    <div class="form-group"> 
                                          <asp:TextBox ID="txtDiagno3" runat="server" placeholder="Enter Parent Diagnosis(*)" class="form-control" TabIndex="1"></asp:TextBox>
                                   </div>
                                </div>

                                                </div>
                                    </div>
                                                 <div class="col-lg-12" >
                                                     <div class="row"> 

                                                 <div class="col-lg-1" style="width:180px">
                                    <div class="form-group">
                                         <label for="txtIcd3" style="text-align:left">ICD Stage3 Code:</label>                                                                                
                                        </div>
                                    </div>
                                        <div class="col-lg-3 text-left">
                                    <div class="form-group"> 
                                          <asp:TextBox ID="txtIcd3" runat="server" placeholder="Enter ICD Code(*)" class="form-control" TabIndex="1"></asp:TextBox>
                                   </div>
                                </div>
       
                                    

                                <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                         <asp:Button ID="btnSaveDiagno3" runat="server" class="btn btn-primary"  TabIndex="3" Text="Save" OnClientClick="return Validate();" OnClick="btnSaveDiagno3_Click"  />
                                        <asp:Button ID="btnResetDiagno3" runat="server" class="btn btn-primary"  TabIndex="2" Text="Reset" OnClick="btnResetDiagno3_Click" />
                                        
                                                                              
                                    </div>
                                </div>
                                                </div>
               </div>
                                 <div class="col-lg-12" > 
                                            <div class="row">
                   <div class="table-responsive" style="width:100%">
                  <asp:GridView ID="gvDiagno3" runat="server" class="table table-responsive table-sm table-bordered" AutoGenerateColumns="False" 
                     OnPageIndexChanging="gvDiagno3_PageIndexChanging" OnRowEditing="gvDiagno3_RowEditing"
                    DataKeyNames="TrDiagnostage3Id" AllowPaging="True" PageSize="15" OnRowDeleting="gvDiagno3_RowDeleting"   HeaderStyle-ForeColor="Black"
                    AlternatingRowStyle-BackColor="White">
                       <Columns>
                                <asp:CommandField ButtonType="Image" EditImageUrl="~/Images0/edit.gif" 
                                     ShowCancelButton="False" ShowEditButton="True">
                                
                                </asp:CommandField>
                                <asp:BoundField DataField="TrDiagnostage3Id" HeaderText="TrDiagnostage3Id" 
                                    Visible="False" />
                                <asp:BoundField DataField="TrDiagnoNameStg3" HeaderText="Diagnosis" /> 
                                    
                                <asp:BoundField DataField="Stage3Id" HeaderText="ICD Stage3 Code" /> 
                                    
                               
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="Delete" runat="server" CommandName="Delete" 
                                             ImageUrl="~/Images0/delete.gif" 
                                            OnClientClick="return ValidateDelete()" 
                                            ToolTip="Click here to Delete this record" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="70px" />
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                            <RowStyle ForeColor="#000066" />
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                        </asp:GridView>
                </div>
                                                </div>
                       
                    </div>

                            </div>
                        </div>
                    </div>
                  
                </section>
        </ContentTemplate>
        </asp:UpdatePanel>



</asp:Content>

