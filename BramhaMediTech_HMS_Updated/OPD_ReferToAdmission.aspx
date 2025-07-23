<%@ Page Title="OPD Refer Admission" Language="C#" EnableEventValidation="false" MasterPageFile="~/mainMaster.master" AutoEventWireup="true" CodeFile="OPD_ReferToAdmission.aspx.cs" Inherits="OPD_ReferToAdmission" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register TagPrefix="cc" Namespace="Winthusiasm.HtmlEditor" Assembly="Winthusiasm.HtmlEditor" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControls/ucPatientInfo.ascx" TagPrefix="uc1" TagName="ucPatientInfo" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <h1>General EMR</h1>
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
  
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <script src="ckeditor/ckeditor.js"></script>
    <%--<asp:UpdatePanel runat="server">
        <ContentTemplate>--%>
            <section class="content-header d-flex">
                <h1>Refer To Admission</h1>
                <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Refer To Admission</li>
                     <asp:HiddenField ID="txtTreatId" runat="server" />
                    </ol>
            </section>

            <section class="content">
                <div class="box" runat="server">
                    
                      <div class="box-body">
                      <div class="col-lg-12 mt-3">
                                 <div class="row">

                                     <div class="col-lg-2" >
                                         <strong>Attending Physician</strong>
                                         </div>
                                      <div class="col-lg-3" >
                                           <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                               <ContentTemplate>
                                         <asp:TextBox ID="txtConsDoctorName" runat="server" AutoCompleteType="None"  CssClass="form-control" placeholder="Doctor Name(*)"
                                                AutoPostBack="True"  onkeyPress="return alpha_only(event);" OnTextChanged="txtConsDoctorName_TextChanged" Font-Bold="True" Font-Size="Medium"></asp:TextBox>
                                               <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchConsultDoc"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                     CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                TargetControlID="txtConsDoctorName"
                                                ID="AutoCompleteExtender4"
                                                runat="server">
                                                   </asp:AutoCompleteExtender>
                                                   </ContentTemplate>
                                               </asp:UpdatePanel>
                                           </div>
                                     <div class="col-lg-2" >
                                         <strong>Ward Name</strong>
                                         </div>
                                     <div class="col-lg-2" >
                                         <asp:DropDownList ID="ddlRoomTypeName" runat="server" CssClass="form-control form-select">
                                                </asp:DropDownList>
                                           </div>
                                     <div class="col-lg-1" >
                                         <strong>Bed Name</strong>
                                         </div>
                                       <div class="col-lg-2" >
                                           <asp:TextBox runat="server" ID="txtbedName"  CssClass="form-control" placeholder="Bed Name"></asp:TextBox>
                                           </div>
                                     </div>
                               </div>
                            
                          <div class="col-lg-12 mt-3">
                                 <div class="row">
                                      <div class="col-lg-6">
                        <div class="panel-heading">
                                  Notes|                 
                                                 
                 
                     </div>
                                       <div class="col-lg-12" >
                                           <asp:TextBox ID="Editor1" runat="server" Height="2000px" TextMode="MultiLine"></asp:TextBox>
<script type="text/javascript" lang="javascript">  CKEDITOR.replace('<%=Editor1.ClientID%>');</script> 
                                           </div>
                                     </div>

                                     <div class="col-lg-6">
                                          <div class="panel-heading">
                                  Investigation|                 
                                                 
                 
                     </div>
                               <div id="Div8" class="col-lg-12  mt-2" runat="server" > 
                                            <div class="row">
                                                    <div class="form-Inline form-check pl12">
                                                        <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                               <ContentTemplate>
                                                        <asp:RadioButtonList ID="RBLLabType" runat="server"    BackColor="#66ccff"  RepeatDirection="Horizontal" AutoPostBack="True"  Font-Bold="True" Font-Size="Medium" Width="100%" OnSelectedIndexChanged="RBLLabType_SelectedIndexChanged" >
                                                             <asp:ListItem Value="P" >Pathology</asp:ListItem>
                                                             <asp:ListItem Value="R">Radiology</asp:ListItem>                                                            
                                                             <asp:ListItem Selected="True" Value="M">Medical Lab</asp:ListItem>
                                                         
                                                             </asp:RadioButtonList>
                                                   </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </div>
                                                    
                                                </div>
                                            </div>
  <div class="col-lg-12 mt-3">
                                 <div class="row">
                                      
                                       <div class="col-lg-12" >
                                           <asp:UpdatePanel ID="kk" runat="server">
                                               <ContentTemplate>

                                              
<asp:TextBox ID="txtService" runat="server" TabIndex="13" AutoCompleteType="None"  CssClass="form-control" placeholder="Enter Test Name(*)"
                                              AutoPostBack="True"   onkeyPress="return alpha_only(event);" OnTextChanged="txtService_TextChanged" Font-Bold="True" Font-Size="Medium"></asp:TextBox>
                                               <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchService"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                     CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                TargetControlID="txtService"
                                                ID="AutoCompleteExtender3"
                                                runat="server">
                                                   </asp:AutoCompleteExtender>
                                                    </ContentTemplate>
                                           </asp:UpdatePanel>
                                           </div>
                                     
                                     </div>
                              </div>
                              
                            <div class="col-lg-12 mt-3">
                                 <div class="row">
                                      
                                       <div class="col-lg-12" >
                                           <div class="table-responsive" style="width:100%" >
                                             <div style=" overflow: scroll; width: 100%; height: 200px; text-align: left"
                                                                                id="Div6">
                                                 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                               <ContentTemplate>
                                                 <asp:GridView ID="gvBill" runat="server" AutoGenerateColumns="False" 
                                OnRowDeleting="gvBill_RowDeleting"  BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                                class="table table-responsive table-sm table-bordered" Width="100%"
                                HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White"   
                                 BorderWidth="1px" CellPadding="3" AllowPaging="True" TabIndex="170"
                                 ShowHeaderWhenEmpty="True" OnPageIndexChanging="gvBill_PageIndexChanging" 
                                 EmptyDataText="No Records to Display" onrowdatabound="gvBill_RowDataBound" 
                                ShowFooter="True" onselectedindexchanged="gvBill_SelectedIndexChanged" OnRowEditing="gvBill_RowEditing" PageSize="1000">
                                 <FooterStyle Font-Bold="true" BackColor="#61A6F8" ForeColor="black" />
<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                            <Columns>                                
                                    <asp:CommandField ButtonType="Image"  EditImageUrl="~/Images0/edit.gif" 
                                    ShowCancelButton="False" ShowEditButton="True">
                                    <ItemStyle Width="30px" HorizontalAlign="Center" />
                                </asp:CommandField>
                               <asp:BoundField DataField="Service" HeaderText="Test Name"  >  
                                   
                                    <ItemStyle Width="150px" Font-Bold="True" Font-Size="Medium" /></asp:BoundField>
                                 <asp:BoundField DataField="Empname" Visible="false" HeaderText="Consultant Dr"  > 
                                   
                                    <ItemStyle Width="120px" Font-Bold="True" Font-Size="Medium" />
                                    </asp:BoundField>
                                 <asp:BoundField DataField="SingleBillServiceCharges" Visible="false" HeaderText="Charges"  >  
                                    
                                <ItemStyle Width="50px" Font-Bold="True" Font-Size="Medium" HorizontalAlign="center" /></asp:BoundField>
                              
                                <asp:BoundField DataField="Qty" Visible="false" HeaderText="Qty"  >
                                    
                                    <ItemStyle Width="50px" Font-Bold="True" Font-Size="Medium" /> </asp:BoundField>
                              
                                <asp:BoundField DataField="Charge" HeaderText="Total Charge"  >  
                                   
                                <ItemStyle Width="50px" Font-Bold="True" Font-Size="Medium" HorizontalAlign="center" /></asp:BoundField>

                                  <asp:BoundField DataField="DrId" HeaderText="Consultant Dr Id" 
                                    Visible="False"  > <ItemStyle Width="70px" /></asp:BoundField>                            
                               
                                 <asp:BoundField DataField="BillServiceId" HeaderText="Service Id" Visible="False"  > <ItemStyle Width="70px" /></asp:BoundField>
                            
                                  <asp:TemplateField >
                                    <ItemTemplate>
                                        <asp:HiddenField ID="HdnMTcode" runat="server" Value='<%#Eval("MTCode") %>' />
                                         <asp:HiddenField ID="HdnLabType" runat="server" Value='<%#Eval("LabType") %>' />
                                        <asp:ImageButton ID="Delete" runat="server" CommandName="Delete"  CausesValidation="false"
                                            ImageUrl="~/Images0/delete.gif" OnClientClick="return ValidateDelete()" ToolTip="Click here to Delete this record" />
                                    </ItemTemplate>
                                    <ItemStyle Width="30px" HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                              <FooterStyle BackColor="White" ForeColor="#000066" />
                                                <HeaderStyle BackColor="#38C8DD" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                <RowStyle ForeColor="#000066" />
                                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                <SortedDescendingHeaderStyle BackColor="#00547E" />
                        </asp:GridView>
                                                   </ContentTemplate>
                                                     </asp:UpdatePanel>
                                                 </div>
                                               </div>
                                           </div>
                                     </div>
                                </div>
                           <div class="col-lg-12 mt-3">
                                 <div class="row">
                                      
                                       <div class="col-lg-6" >
<asp:Button runat="server" ID="btnSaveInv" Text="Save Investigation" CssClass="btn btn-warning" OnClick="btnSaveInv_Click" />
                                           </div>
                                    
                                     </div>
                              </div>
                              <div class="col-lg-12 mt-3">
                                 <div class="row">                                      
                                       <div class="col-lg-12" >
                                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                               <ContentTemplate>
                                           <asp:TextBox runat="server" Height="125px"  id="txtinvdetails" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                         </ContentTemplate>
                                                </asp:UpdatePanel>
                                                     </div>
                                     </div>
                                  </div>
                                         </div>
                                     </div>
                              </div>
                           <div class="col-lg-12 mt-2">
                    <div class="row">
                          <div class="col-lg-5">
                              <div class="col-lg-12 mt-3">
                                 <div class="row">

                                     <div class="col-lg-2" >
                                         <strong>Plan</strong>
                                         </div>
                                      <div class="col-lg-4" >
                                        <asp:DropDownList ID="ddlPlan" CssClass="form-control form-select" runat="server" >
                                              <asp:ListItem Value="3">Reffered Admision</asp:ListItem>
                                            
                                            
                                          </asp:DropDownList>
                                           </div>
                                     <div class="col-lg-2" >
                                         <strong>Diagnosis</strong>
                                         </div>
                                     <div class="col-lg-4" >
                                        <asp:TextBox ID="txtdiagnosis" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                                           </div>
                                     </div>
                               </div>
                           <div class="col-lg-12 mt-3">
                                 <div class="row">

                                     <div class="col-lg-2" >
                                         <strong>Remarks</strong>
                                         </div>
                                      
                                     <div class="col-lg-10" >
                                        <asp:TextBox ID="txtRemarks" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                                           </div>
                                     </div>
                               </div>
                               <div class="col-lg-12 mt-2 " >
                                         <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                               <ContentTemplate>
                                           <asp:TextBox runat="server" Height="125px"  id="txttreatmentshow" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                          </ContentTemplate>
                                             </asp:UpdatePanel>
                                                    </div>
                      
                              </div>

                           <div class="col-lg-7">
                        <div class="panel-heading">
                                 Pharmacy |                 
                                                 
                 
                     </div>

                               
                                      <div class="col-lg-12" >
                                             <div class="row">
                                    <div class="col-lg-12 mt-2 text-left" ">
                                        <div class="form-group">
                                             <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                               <ContentTemplate>
                                            <asp:TextBox ID="txtDrugName" runat="server"  AutoCompleteType="None"
                                                AutoPostBack="true" TabIndex="1" CssClass="form-control" placeholder="Search Drug Name" OnTextChanged="txtDrugName_TextChanged">
                                            </asp:TextBox>
                                            <asp:AutoCompleteExtender
                                                MinimumPrefixLength="1"
                                                ServiceMethod="GetDrugsName"
                                                CompletionInterval="100"
                                                EnableCaching="false"
                                                CompletionSetCount="10"
                                                 CompletionListCssClass="AutoExtender"
                                                CompletionListItemCssClass="AutoExtenderList"
                                                 CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                TargetControlID="txtDrugName"
                                                ID="AutoCompleteExtender1"
                                                runat="server">
                                            </asp:AutoCompleteExtender>
                                          </ContentTemplate>
                                                 </asp:UpdatePanel>
                                        </div>
                                    </div>
                               </div>
                                <div class="col-lg-12 mt-2 text-left">
                                 <div class="row">
                                      <div id="Div2" class="col-lg-2 text-left" runat="server" visible="false">
                                              <div class="form-group"> 
                                                   <label class="control-label">
                                                    Inst.
                                                  </label> 
                                                   <asp:DropDownList ID="ddlinstruction"  CssClass="form-control form-select"  runat="server" BackColor="#99CCFF" Font-Bold="True" Font-Size="Small" ></asp:DropDownList> 

                                                  </div>
                                            </div>
                                       <div id="Div7" class="col-lg-2 text-left" runat="server" >
                                              <div class="form-group"> 
                                                   <label class="control-label">
                                                    Dose Qty 
                                                  </label> 
                                                   <asp:TextBox ID="txtnewDose" onkeyPress="return numeric_only(event);" placeholder="Dose Qty "  CssClass ="form-control"  runat="server" ></asp:TextBox> 

                                                  </div>
                                            </div>
                                       <div class="col-lg-3 text-left"  >
                                              <div class="form-group"> 
                                                   <label class="control-label">
                                                   Dosage Format/Unit 
                                                  </label> 
                                                  <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                                      <ContentTemplate>
                                                   <asp:DropDownList ID="drpfrequency" runat="server" AutoPostBack="false"
                                                class="form-control" OnSelectedIndexChanged="drpfrequency_SelectedIndexChanged"
                                                TabIndex="2" >
                                                
                                            </asp:DropDownList>
                                                         </ContentTemplate>
                                                      </asp:UpdatePanel>
                                                  </div>
                                            </div>
                                     <div class="col-lg-2 text-left" >
                                        <div class="form-group">
                                            <label for="drpfrequency" style="text-align: left">Frequency<span style="color: red">*</span></label>
                                            <asp:DropDownList ID="ddlDoseTime" runat="server"  CssClass="form-control" AutoPostBack="false"   BackColor="#99CCFF" Font-Bold="True" Font-Size="Small" ></asp:DropDownList>


                                        </div>
                                    </div>
                                       
                                   <div class="col-lg-2 text-left" >
                                        <div class="form-group">
                                            <label for="drpfrequency" style="text-align: left">Route<span style="color: red">*</span></label>
                                            <asp:DropDownList ID="ddlRoute" runat="server"  CssClass="form-control" AutoPostBack="false"   ></asp:DropDownList>


                                        </div>
                                    </div>
                                    
                                   
                                    <div class="col-lg-2 text-left" >
                                        <div class="form-group">
                                            <label for="txtDays">Days <span style="color: red">*</span></label>
                                            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                <ContentTemplate>
                                            <asp:TextBox ID="txtDays" runat="server" CssClass="form-control"  placeholder="0"
                                                onkeyPress="return numeric_only(event);" TabIndex="3" AutoPostBack="true"
                                                OnTextChanged="txtDays_TextChanged"></asp:TextBox>
                                                  </ContentTemplate>
                                                </asp:UpdatePanel>

                                        </div>
                                    </div>
                                      <div id="Div3" class="col-lg-2 text-left" runat="server" visible="false" >
                                        <div class="form-group">
                                            <label for="txtDays">Qty <span style="color: red">*</span></label>
                                            <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                 <ContentTemplate>
                                            <asp:TextBox ID="txtQty" runat="server" CssClass="form-control"  placeholder="0"
                                                onkeyPress="return numeric_only(event);" TabIndex="3" AutoPostBack="false"
                                                ></asp:TextBox>
                                                   </ContentTemplate>
                                                </asp:UpdatePanel>

                                        </div>
                                    </div>
                                  

                                    <div id="Div4" runat="server" visible="false">
                                         <div class="col-lg-2  text-left">
                                        <div class="form-group">
                                            <label for="txtStart">Start Date:</label>
                                            <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                <asp:TextBox ID="txtStart" runat="server" OnTextChanged="txtStart_TextChanged" class="form-control pull-right"></asp:TextBox>
                                                <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                                            </div>
                                        </div>
                                    </div>
                                         <div class="col-lg-2  text-left">
                                        <div class="form-group">
                                            <label for="txtEnd">End Date:</label>
                                            <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                <asp:TextBox ID="txtEnd" autocomplete="off" runat="server" OnTextChanged="txtEnd_TextChanged" class="form-control pull-right"></asp:TextBox>
                                                <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                                            </div>
                                        </div>
                                    </div>
                                         <div class="col-lg-2 text-left">
                                        <div class="form-group">
                                            <label for="txtFollowUp">Follow-Up Date<span style="color: red">*</span></label>
                                            <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                <asp:TextBox ID="txtFollowUp" autocomplete="off" AutoPostBack="true" runat="server" class="form-control pull-right" TabIndex="5"></asp:TextBox>
                                                <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                                                <asp:RequiredFieldValidator InitialValue="-1" Display="Dynamic" ControlToValidate="txtFollowUp" ID="RequiredFieldValidator12"
                                                    runat="server" ForeColor="Red" ErrorMessage="Please select"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                   </div>
                                     </div>
                                </div>

                                <div class="row">
                                    <div class="col-lg-5 mt-2 text-left">
                                        <div class="form-group">
                                           <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                             <ContentTemplate>
                                            <asp:TextBox ID="txtNote" runat="server"  
                                                AutoPostBack="false"  placeholder="Note" TextMode="MultiLine" TabIndex="4" CssClass="form-control">
                                            </asp:TextBox>
                                                 </ContentTemplate>
                                               </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div class="col-lg-5 mt-2 text-left">
                                        <div class="form-group">
                                            <asp:TextBox ID="txtDiagnosisTreatment" placeholder="Diagnosis" runat="server" CssClass="form-control" TextMode="MultiLine" 
                                                AutoPostBack="false" ></asp:TextBox>
                                            </div>
                                        </div>
                                     <div class="col-lg-2 mt-2 text-left">
                                        <div class="form-group">
                                             <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                               <ContentTemplate>
<asp:Button runat="server" ID="btnAddTreat" Text="Add Treatment" CssClass="btn btn-success" OnClick="btnAddTreat_Click"   />
                                                   </ContentTemplate>
                                                 </asp:UpdatePanel>
                                            </div>
                                         </div>

                                   </div>
                                        
                                           <div class="row">
                                           <div class="col-lg-12 mt-3">
                        <div class="row">
                            <div runat="server" id="Div5" style="height:200px; width:100%; overflow:scroll"   >  
                            <div class="table-responsive" style="width: 100%">
                                 <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                               <ContentTemplate>
                                <asp:GridView ID="gvTempTable" runat="server" AutoGenerateColumns="False" AutoPostBack="false"
                                    class="table table-responsive table-sm table-bordered" Width="100%" DataKeyNames="Id"
                                    HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3" OnRowDeleting="gvTempTable_RowDeleting"
                                    AllowPaging="True" BackColor="White" OnRowCommand="gvTempTable_RowCommand" OnRowEditing="gvTempTable_RowEditing"
                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="1000" ShowHeaderWhenEmpty="True" OnPageIndexChanging="gvTempTable_PageIndexChanging">
                                    <Columns>

                                        <asp:ButtonField CommandName="Edit" Text="Edit" ButtonType="Image" ImageUrl="~/Images0/edit.gif" />
                                        <asp:BoundField DataField="Id" HeaderText="Sr No" ItemStyle-Width="50" Visible="False" />
                                        <asp:BoundField DataField="DrugName" HeaderText="DrugName"  ItemStyle-Width="250" />
                                         <asp:BoundField DataField="NewDose" Visible="true" HeaderText="Dose"   />
                                        
                                        <asp:BoundField DataField="Frequency" HeaderText="Unit" ItemStyle-Width="110" />
                                         <asp:BoundField DataField="Dose" HeaderText="Frequency" />
                                         <asp:BoundField DataField="Route" HeaderText="Route" />
                                        <asp:BoundField DataField="Days" HeaderText="Days" ItemStyle-Width="40" />
                                       <%-- <asp:BoundField DataField="StartDate" HeaderText="StartDate" ItemStyle-Width="100" DataFormatString="{0:dd/MM/yyyy}" />
                                        <asp:BoundField DataField="EndDate" HeaderText="EndDate" ItemStyle-Width="100" DataFormatString="{0:dd/MM/yyyy}" />
                                       --%> <asp:BoundField DataField="Note" HeaderText="Note" />
                                         <asp:BoundField DataField="DoseTimeId" Visible="true" />
                                         <asp:BoundField DataField="DoseId" Visible="true" />
                                         <asp:BoundField DataField="ItemId" Visible="true" />
                                         <asp:BoundField DataField="InstName" Visible="true" />
                                        
                                        <asp:ButtonField CommandName="Delete" Text="Delete" ButtonType="Image" ImageUrl="~/Images0/delete.gif" />

                                    </Columns>
                                   <FooterStyle BackColor="White" ForeColor="#000066" />
                                                <HeaderStyle BackColor="#38C8DD" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                <RowStyle ForeColor="#000066" />
                                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                <SortedDescendingHeaderStyle BackColor="#00547E" />
                                </asp:GridView>

                                                   </ContentTemplate>
                                     </asp:UpdatePanel>

                            </div>
                                </div>
                        </div>
                    </div>
                                               </div>
                                           <div class="row">
                                            <div class="col-lg-12 mt-3">
                                 <div class="row">
                                      
                                       <div class="col-lg-12 text-right" >
<asp:Button runat="server" ID="btnTreatment" Text="Save Treatment" CssClass="btn btn-warning" OnClick="btnTreatment_Click"  />
                                           </div>
                                   
                                     </div>
                                                </div>
                              </div>
                                           </div>

                               

                               </div>
                          
                        </div>
                               </div>

                          

                             <div class="row" >
                                    <div class="col-lg-12 mt-3 text-center" >
                                        <asp:Button ID="btnSave"  CssClass="btn btn-success" runat="server"  Text="Save" OnClick="btnSave_Click"  OnClientClick="this.disabled=true;" UseSubmitBehavior="false" />
                                        <asp:Button ID="btnClear" CssClass="btn btn-default" Visible="false" runat="server" Text="Clear" OnClick="btnClear_Click" />
                                         <asp:Label ID="lblMsg" ForeColor="DarkRed" runat="server" Text="" EnableViewState="False"></asp:Label>
                                    </div>
                                </div>

                            <div class="row" >
                                    <div class="col-lg-12 mt-3 text-left" >
                                          <div class="form-group">  
                                    
                                                 <div runat="server" id="Div1" style="height:1300px;  overflow:scroll"    >                                          
                                                         <div class="table-responsive" style="width:100%" >
                                                                <asp:GridView ID="GvNoteIngrid" runat="server" AutoGenerateColumns="False"
                                                class="table table-responsive table-lg table-bordered" Width="100%" DataKeyNames="Id"
                                                HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3"
                                                AllowPaging="True" BackColor="White" 
                                                BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="310" ShowHeaderWhenEmpty="True"
                                                OnPageIndexChanging="GvNoteIngrid_PageIndexChanging">
<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                                                <Columns>
                                       
                                                    <asp:BoundField DataField="NoteAddOn" HeaderText="Date"  />
                                                    
                                                     <asp:BoundField DataField="DrNote"    HeaderText="Clinical Notes" HtmlEncode="False"  />
                                                   
                                                     <asp:BoundField DataField="DrPlan"  HeaderText="Plan"  />
                                                     <asp:BoundField DataField="Diagnosis"  HeaderText="Diagnosis"  />
                                                     <asp:BoundField DataField="InvestigationDetails"  HeaderText="Investigation Details"  />
                                                     <asp:BoundField DataField="TreatmentDetails"  HeaderText="Treatment Details"  />
                                                     <asp:BoundField DataField="Remarks"  HeaderText="Remarks"  />
                                                     <asp:BoundField DataField="Createdby"  HeaderText="Consultant"  />
                                                         
                                                </Columns>
                                                <FooterStyle BackColor="White" ForeColor="#000066" />
                                                <HeaderStyle BackColor="#38C8DD" Font-Bold="True" ForeColor="White" />
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
                            
                           <%--  </div>--%>
                             
                            </div>
                  </div>
                   
            </section>


            


        <%--</ContentTemplate>
    </asp:UpdatePanel>--%>


    <script src="Scripts/jquery-3.4.1.js"></script>
    <script src="Scripts/jquery-ui.min.js"></script>
    <script src="Scripts/moment.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/bootstrap-datetimepicker.js"></script>
     <script src="plugins/Emergency.js"></script>
        <script>
            $(document).ready(function () {
                var speed = 500;
                function effectFadeIn(classname) {
                    $("." + classname).fadeOut(speed).fadeIn(speed, effectFadeOut(classname))
                }
                function effectFadeOut(classname) {
                    $("." + classname).fadeIn(speed).fadeOut(speed, effectFadeIn(classname))
                }
                //Calling fuction on pageload
                $(document).ready(function () {
                    effectFadeIn('flashingTextcss');
                });
            });
  </script>
</asp:Content>

