<%@ Page Title="" Language="C#" MasterPageFile="~/mainMaster.master" AutoEventWireup="true" CodeFile="IPDPatientTreatmentSheet.aspx.cs" Inherits="IPDPatientTreatmentSheet" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <style type="text/css">
        .modalBackground {
            background-color: Black;
            filter: alpha(opacity=60);
            opacity: 0.6;
        }

        .modalPopup {
            background-color: white;
            width: auto;
            border: 3px solid #0DA9D0;
            border-radius: 12px;
            padding: 0;
        }

            .modalPopup .header {
                background-color: #2FBDF1;
                height: 30px;
                color: White;
                line-height: 30px;
                text-align: center;
                font-weight: bold;
                border-top-left-radius: 6px;
                border-top-right-radius: 6px;
            }

            .modalPopup .body {
                min-height: 50px;
                line-height: 30px;
                text-align: center;
                font-weight: bold;
            }

            .modalPopup .footer {
                padding: 6px;
            }

            .modalPopup .yes, .modalPopup .no .modalPopup .cancel {
                height: 23px;
                color: White;
                line-height: 23px;
                text-align: center;
                font-weight: bold;
                cursor: pointer;
                border-radius: 4px;
            }

            .modalPopup .yes {
                background-color: #2FBDF1;
                border: 1px solid #0DA9D0;
            }

            .modalPopup .no {
                background-color: #9F9F9F;
                border: 1px solid #5C5C5C;
            }

            .modalPopup .cancel {
                background-color: #9F9F9F;
                border: 1px solid #5C5C5C;
            }
    </style>
     <script src="Scripts/moment.js"></script>

    <script src="Scripts/jquery-3.0.0.js"></script>
    <script src="Scripts/jquery-ui-1.12.1.js"></script>
    <script src="Scripts/jquery.auto-complete-1.0.7.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    <script type="text/javascript">

        function isNumberKey(evt, obj) {

            var charCode = (evt.which) ? evt.which : event.keyCode
            var value = obj.value;
            var dotcontains = value.indexOf(".") != -1;
            if (dotcontains)
                if (charCode == 46) return false;
            if (charCode == 46) return true;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
        </script>
    
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <section class="content-header d-flex">
        <h1>Patient Treatment Sheet </h1>
         <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Patient Treatment Sheet</li>
                    </ol>
    </section>
    <section class="content">
        <div id="Div1" class="box" runat="server">
            <div class="box-header with-border">
                <span class="red pull-right"></span>
                <asp:Label ID="lblMsg1" class="red pull-center" runat="server" Text="" Font-Bold="true" ForeColor="green"></asp:Label>
             
            </div>
             <div class="box-body">
                
                    

                <div class="col-lg-12 mt-2">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="form-group">
                            <asp:Label ID="LblMSg"  Font-Bold="true" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
            </div>            
                     <div class="col-lg-12"  >
                        <div class="row">
                            <div class="col-lg-6" >   
                <div class="col-lg-12">
                                 <div class="row"> 
                                       <div class="col-lg-6">
                                                        <div class="form-group">  
                                                                                       
                                                             
                      <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">                                                            
                                                              <asp:TextBox ID="txttimestart" runat="server" CssClass="form-control"  placeholder="Enter Time Start"    
                                                                  AutoPostBack="True"></asp:TextBox>
                                                             
                                                                    <span class="input-group-addon">
                                                                        <i class="fa fa-calendar"></i>
                                                                    </span>                                                     
                         
                                                            </div>
                                                    
                                                        </div>
                                                    </div>
                                       <div class="col-lg-4 text-left" >
                                                        <div class="form-group">  
                                                                                
                                                            <asp:TextBox ID="txtTime" runat="server"  class="form-control" ></asp:TextBox>  
                                                            </div>
                                           </div>   
                                     </div>
                    
                    </div> 
                <div class="col-lg-12 mt-2">
                    <div class="row">
                        
                             <div class="row">
                                  <div class="col-lg-8 text-left">
                                        <div class="form-group">
                                            <label for="txtDrugName">Search Drug Name<span style="color: red">*</span></label>
                                            <asp:TextBox ID="txtDrugName" runat="server" AutoCompleteType="None"
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
                                 
                                  <div class="col-lg-2">
                                        <div class="form-group">
                                            <label for="txtDays">Qty <span style="color: red">*</span></label>
                                            <asp:TextBox ID="txtQty" runat="server" CssClass="form-control" placeholder="0"
                                                onkeyPress="return isNumberKey(event);"  AutoPostBack="false"
                                               ></asp:TextBox>

                                        </div>
                                    </div>
                                  <div class="col-lg-2">
                                        <div class="form-group">
                                            <label for="txtDays">Route <span style="color: red"></span></label>
                                            <asp:TextBox ID="txtRoute" runat="server" CssClass="form-control" placeholder="0"
                                                 AutoPostBack="false"
                                               ></asp:TextBox>

                                        </div>
                                    </div>
                                  <div class="col-lg-4 form-group">
                    <label for="txtNurse"><b>Nurse</b></label>
                        <div class="row">
                            <div class="col-lg-12">
                                 <asp:TextBox ID="txtNurse" runat="server" ReadOnly="true"  CssClass="form-control" 
                                  ></asp:TextBox>  
                            </div>
                       </div>
                </div>

                                 </div>
                                 <div class="row mt-2">
                        <div class="col-lg-12 form-group">
                    <label for="txtRemark"><b>Note</b></label>
                        <div class="row">
                            <div class="col-lg-12">
                                <textarea  rows="2" cols="68" id="txtRemark" class="form-control"  runat="server"></textarea>
                                </div>
                            </div>
                    </div>
                        </div>
                            
                       
                        </div>
                    </div>
                             </div>   
                            <div class="col-lg-6" >   
                       
                           <div class="col-lg-12 mt-3">
                               
                                              <div class="form-group">  
                                    
                                                 <div runat="server" id="Div2" style="height:250px; overflow:scroll"   >                                          
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
                                                     <asp:TemplateField  HeaderText="Refill" Visible="false">
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
                                                    <asp:ImageButton ID="ImageButton2" runat="server" Visible="false" CommandName="Delete" 
                                                        ImageUrl="~/Images0/delete.gif" OnClientClick="return ValidateDelete()" CausesValidation="false"
                                                        ToolTip="Click here to Delete this record" />
                                                </ItemTemplate>
                                                <ItemStyle Width="70px"  HorizontalAlign="Center" />
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
                                                    <asp:Button ID="btnnotedetails" Visible="false" runat="server" Text="Details" />
                                               </div>
                                 
                                             </div>

                                </div>
                
                
                    </div>            
                </div>

                <div class="col-lg-12 text-center">
                    <div class="form-group">
                        <asp:Button ID="btnsave" runat="server" Text="Save" class="btn btn-primary btnSearch" OnClick="btnsave_Click" />
                        <asp:Button ID="btnReset" runat="server" Text="Reset" class="btn btn-primary btnSearch" OnClick="btnReset_Click" />                                       
                        <asp:Button ID="btnReport" runat="server" Text="Report" class="btn btn-primary btnSearch" OnClick="btnReport_Click"  />                                       
                  
                    </div>
                </div>
                <div class="col-lg-12">
                    <div class="row">
                        <div runat="server" id="UploadedFiles" style="height:450px; width:1200px; overflow:scroll">   
                             <div class="table-responsive" style="width: 100%">
                                <asp:GridView ID="gvDailyNurseNote" runat="server" AutoGenerateColumns="False" AutoPostBack="false"
                                class="table table-responsive table-sm table-bordered" Width="100%" DataKeyNames="PatTreatmentId"
                                HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3" OnRowDeleting="gvDailyNurseNote_RowDeleting"
                                AllowPaging="True" BackColor="White" OnRowEditing="gvDailyNurseNote_RowEditing"
                                BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="100" ShowHeaderWhenEmpty="True" OnPageIndexChanging="gvDailyNurseNote_PageIndexChanging">
<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                                <Columns>

                                <asp:ButtonField CommandName="Edit" Text="Edit" ButtonType="Image" ImageUrl="~/Images0/edit.gif" />
                                <asp:BoundField DataField="DateInput" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}" />
                                <asp:BoundField DataField="TimeInput" HeaderText="Time" />
                                    <asp:BoundField DataField="CreatedBy" Visible="false" HeaderText="Enter by" />
                                <asp:BoundField DataField="DrugName"  HeaderText="Drug Name" />                                   
                                <asp:BoundField DataField="Qty"  HeaderText="Qty" />
                                     <asp:BoundField DataField="Routess"  HeaderText="Route" />
                                <asp:BoundField DataField="Name"  HeaderText="Given By" />
                                <asp:BoundField DataField="Remark"  HeaderText="Remark" /> 
                                       <asp:BoundField DataField="UpdatedOn" Visible="false" HeaderText="Updated On" DataFormatString="{0:dd/MM/yyyy hh:mm tt}" />
                                     <asp:BoundField DataField="UpdatedBy" Visible="false" HeaderText="Updated by" />                                   
                                <asp:ButtonField CommandName="Delete" Visible="false" Text="Delete" ButtonType="Image" ImageUrl="~/Images0/delete.gif" />

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
            </div>
                     
            
</section>
    <script language="javascript" type="text/javascript">
        function OpenReport() {

            window.open("Reports.aspx");
        }
               </script>
</asp:Content>



