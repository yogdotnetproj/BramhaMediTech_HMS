<%@ Page Title="Treatment" EnableEventValidation="false" Language="C#" MasterPageFile="~/mainMaster.master" AutoEventWireup="true" CodeFile="DischargeMedication.aspx.cs" Inherits="DischargeMedication" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/ucPatientInfo.ascx" TagPrefix="uc1" TagName="ucPatientInfo" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <script type = "text/javascript">
         function Validate() {

             if (document.getElementById("MainContent_txtItemUnit").value == "") {
                 alert("Please Enter Item Unit");
                 return false;
             }
             if (document.getElementById("MainContent_txtItemUnitCode").value == "") {
                 alert("Please Enter Item UnitCode");
                 return false;
             }
         }
        </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>--%>
    <section class="content-header d-flex">
        <h1>Discharge Medication</h1>
         <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Discharge Medication</li>
                    </ol>
    </section>
    <section class="content">
        <div class="box" runat="server">
           
            <div class="box-header with-border">
                <span class="red pull-right">Fields marked with * are compulsory</span>
                <asp:Label ID="lblMsg" class="red pull-center" runat="server" Text="" Font-Bold="true" ForeColor="green"></asp:Label>
               
            </div>
            



            <div class="panel-heading" style="font-size:medium;font-weight:bold">.</div> 
            <div class="box-body">
               
               
                    <div class="col-lg-12 mt-3"  >
                        <div class="row">
                            <div class="col-lg-6" >
                                <div class="row">
                                    <div class="col-lg-12 text-center" >
                                        <div class="form-group">
                                             <asp:HiddenField ID="txtTreatId" runat="server" />
                                              <asp:RadioButtonList ID="rdbpkg" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rdbpkg_SelectedIndexChanged">
                                                <asp:ListItem Selected="True">Drug</asp:ListItem>
                                                <asp:ListItem>Package</asp:ListItem>
                                            </asp:RadioButtonList>
                                            </div>
                                        </div>
                                            <div class="row">
                                    <div class="col-lg-12 text-left" >
                                            <label for="txtDrugName">Search Drug Name<span style="color: red">*</span></label>
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
                                                ID="AutoCompleteExtender3"
                                                runat="server">
                                            </asp:AutoCompleteExtender>
                                         
                                        </div>
                                    </div>
                               </div>
                                 <div class="row">
                                        <div class="col-lg-2 text-left" runat="server" visible="false">
                                              <div class="form-group"> 
                                                   <label class="control-label">
                                                    Inst.
                                                  </label> 
                                                   <asp:DropDownList ID="ddlinstruction"  CssClass="form-control form-select"  runat="server" BackColor="#99CCFF" Font-Bold="True" Font-Size="Small" ></asp:DropDownList> 

                                                  </div>
                                            </div>
                                       <div class="col-lg-2 text-left">
                                              <div class="form-group"> 
                                                   <label class="control-label">
                                                    Dose
                                                  </label> 
                                                   <asp:TextBox ID="txtnewDose"  CssClass ="form-control" BackColor="#99CCFF" Font-Bold="True" Font-Size="Larger"  runat="server" ></asp:TextBox> 

                                                  </div>
                                            </div>
                                      <div class="col-lg-3 text-left"  >
                                              <div class="form-group"> 
                                                   <label class="control-label">
                                                   Unit
                                                  </label> 
                                                                                                  <asp:DropDownList ID="drpfrequency" runat="server" AutoPostBack="false"
                                                class="form-control" OnSelectedIndexChanged="drpfrequency_SelectedIndexChanged" BackColor="#99CCFF" Font-Bold="True" Font-Size="Larger" 
                                                TabIndex="2" >
                                                
                                            </asp:DropDownList>  
                                                  </div>
                                            </div>
                                        <div class="col-lg-2 text-left" >
                                        <div class="form-group">
                                            <label for="drpfrequency" style="text-align: left">Frequency<span style="color: red">*</span></label>
                                            <asp:DropDownList ID="ddlDoseTime" runat="server"  CssClass="form-control" AutoPostBack="true"   BackColor="#99CCFF" Font-Bold="True" Font-Size="Small" ></asp:DropDownList>


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
                                            <asp:TextBox ID="txtDays" runat="server" CssClass="form-control"  placeholder="0"
                                                onkeyPress="return numeric_only(event);" TabIndex="3" AutoPostBack="false"
                                                OnTextChanged="txtDays_TextChanged"></asp:TextBox>

                                        </div>
                                    </div>
                                      <div class="col-lg-3 text-left" runat="server" visible="false">
                                        <div class="form-group">
                                            <label for="txtDays">Qty <span style="color: red">*</span></label>
                                            <asp:TextBox ID="txtQty" runat="server" CssClass="form-control" placeholder="0"
                                                onkeyPress="return numeric_only(event);" TabIndex="3" AutoPostBack="false"
                                                ></asp:TextBox>

                                        </div>
                                    </div>
                                  

                                    <div runat="server" visible="false">
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

                                <div class="row">
                                    <div class="col-lg-12 text-left">
                                        <div class="form-group">
                                            <label for="txtNote">Dr Remark</label>
                                            <asp:TextBox ID="txtNote" runat="server"  TextMode="MultiLine" Rows="4"
                                                AutoPostBack="false" TabIndex="4" CssClass="form-control">
                                            </asp:TextBox>
                                        </div>
                                    </div>

                                   </div>
                                 <div class="row">
                                    <div class="col-lg-12 text-left">
                                        <div class="form-group">
                                            <label for="txtNote">Diagnosis </label>
                                            <asp:TextBox ID="txtDiagnosis" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4"
                                                AutoPostBack="false" ></asp:TextBox>
                                        </div>
                                    </div>

                                   </div>
                                 <div class="row">
                                    <div class="col-lg-12 mt-3">
                                         <div class="form-group"> 
                                        <asp:Button ID="btnAdd" runat="server" TabIndex="6" Text="Add" OnClick="btnAdd_Click"
                                            Width="80px" class="btn btn-primary btnSearch" CausesValidation="False" />
                                        <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click"
                                            CausesValidation="False" class="btn btn-primary btnSearch" Width="80px" />
                                             </div>
                                    </div>
                                     </div>

                                  
                            </div>
                            <div class="col-lg-6" >
                               
                                              <div class="form-group">  
                                    
                                                 <div runat="server" id="Div1" style="height:250px; overflow:scroll"   >                                          
                                                         <div class="table-responsive" style="width:100%" >
                                                                <asp:GridView ID="GvNoteIngrid" DataKeyNames="TreatmentId,TransId" runat="server" AutoGenerateColumns="false"
                                                class="table table-responsive table-lg table-bordered" Width="100%" 
                                                HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3"
                                                BackColor="White"  BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"  ShowHeaderWhenEmpty="True"  OnRowCommand="GvNoteIngrid_RowCommand" OnDataBound="GvNoteIngrid_DataBound" OnRowDeleting="GvNoteIngrid_RowDeleting" OnRowEditing="GvNoteIngrid_RowEditing">
<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                                                <Columns>
                                        <asp:CommandField ButtonType="Image" EditImageUrl="~/Images0/edit.gif" ShowEditButton="True" >                           
                                                <ItemStyle Width="70px" HorizontalAlign="Center"/> </asp:CommandField>
                                                    <asp:BoundField DataField="EntryDate" ItemStyle-Width="20%" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy hh:mm tt}"  >
                                                    
<ItemStyle Width="20%"></ItemStyle>
                                                    </asp:BoundField>
                                                    
                                                    <asp:BoundField DataField="DrName" ItemStyle-Width="30%" HeaderText="Doctor"  >
<ItemStyle Width="30%"></ItemStyle>
                                                    </asp:BoundField>
                                                     <asp:TemplateField  HeaderText="Refill">
                                                             <ItemTemplate>
                                                                <asp:CheckBox ID="IsChkRefill" AutoPostBack="true" Text="" runat="server" OnCheckedChanged="IsChkRefill_CheckedChanged" />
                                                              </ItemTemplate>
                                                         </asp:TemplateField>
                                                    <asp:BoundField DataField="DrugName" ItemStyle-Width="50%" HeaderText="Drugs"  >
                                                       
<ItemStyle Width="50%"></ItemStyle>
                                                    </asp:BoundField>
                                                       <asp:BoundField DataField="CreatedBy" ItemStyle-Width="50%" HeaderText="Enter By"  >
                                                       
<ItemStyle Width="50%"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:TemplateField >
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImageButton2" runat="server" CommandName="Delete" 
                                                        ImageUrl="~/Images0/delete.gif" OnClientClick="return ValidateDelete()" CausesValidation="false"
                                                        ToolTip="Click here to Delete this record" />
                                                </ItemTemplate>
                                                <ItemStyle Width="70px"  HorizontalAlign="Center" />
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
                                                    <asp:Button ID="btnnotedetails" Visible="false" runat="server" Text="Details" />
                                               </div>
                                 
                                             </div>
                            
                                </div>
                     
                    </div>
               <div class="col-lg-12 mt-3 text-center">
                        <div class="row">
                               <div class="form-group"> 
                                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"
                                            class="btn btn-success" CausesValidation="False"  OnClientClick="this.disabled=true;" UseSubmitBehavior="false" />
                             <asp:Button ID="btnreport" runat="server" Text="Prescription" 
                                             class="btn btn-warning" CausesValidation="False" OnClick="btnreport_Click" />

                                        <asp:Button ID="btnBack" runat="server" OnClientClick="window.history.back()"
                                            Text="Back"  class="btn btn-primary btnSearch" CausesValidation="False" />
                                  </div>
                            </div>
                   </div>
                <div class="row">
                    <div class="col-lg-12 mt-3">
                        <div class="row">
                            <div runat="server" id="Div2" style="height:450px; width:100%; overflow:scroll"   >  
                            <div class="table-responsive" style="width: 100%">
                                <asp:GridView ID="gvTempTable" runat="server" AutoGenerateColumns="False" AutoPostBack="false"
                                    class="table table-responsive table-sm table-bordered" Width="100%" DataKeyNames="Id"
                                    HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3" OnRowDeleting="gvTempTable_RowDeleting"
                                    AllowPaging="True" BackColor="White" OnRowCommand="gvTempTable_RowCommand" OnRowEditing="gvTempTable_RowEditing"
                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="1000" ShowHeaderWhenEmpty="True" OnPageIndexChanging="gvTempTable_PageIndexChanging">
                                    <Columns>

                                        <asp:ButtonField CommandName="Edit" Text="Edit" ButtonType="Image" ImageUrl="~/Images0/edit.gif" />
                                        <asp:BoundField DataField="Id" HeaderText="Sr No" ItemStyle-Width="50" Visible="False" />
                                        <asp:BoundField DataField="DrugName" HeaderText="DrugName" />
                                         <asp:BoundField DataField="Dose" HeaderText="Dose" />
                                        <asp:BoundField DataField="Frequency" HeaderText="Frequency" ItemStyle-Width="150" />
                                        <asp:BoundField DataField="Days" HeaderText="Days" ItemStyle-Width="50" />
                                       <%-- <asp:BoundField DataField="StartDate" HeaderText="StartDate" ItemStyle-Width="100" DataFormatString="{0:dd/MM/yyyy}" />
                                        <asp:BoundField DataField="EndDate" HeaderText="EndDate" ItemStyle-Width="100" DataFormatString="{0:dd/MM/yyyy}" />
                                       --%> <asp:BoundField DataField="Note" HeaderText="Note" />
                                         <asp:BoundField DataField="DoseTimeId" Visible="true" />
                                         <asp:BoundField DataField="DoseId" Visible="true" />
                                         <asp:BoundField DataField="ItemId" Visible="true" />
                                        <asp:BoundField DataField="InstName" Visible="true" />
                                         <asp:BoundField DataField="NewDose" Visible="true" />
                                         <asp:BoundField DataField="Route" Visible="true" />
                                        <asp:ButtonField CommandName="Delete" Text="Delete" ButtonType="Image" ImageUrl="~/Images0/delete.gif" />

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
        </div>

    </section>
    <%--        </ContentTemplate>
    </asp:UpdatePanel>--%>
    <script language="javascript" type="text/javascript">
        function OpenReport() {

            window.open("Reports.aspx");
        }
               </script>
</asp:Content>

