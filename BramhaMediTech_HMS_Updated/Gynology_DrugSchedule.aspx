<%@ Page Title="" Language="C#" MasterPageFile="~/TemplateMaster.master" AutoEventWireup="true" CodeFile="Gynology_DrugSchedule.aspx.cs" Inherits="Gynology_DrugSchedule" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
      <style>
        .list-group-item {
            user-select: none;
        }

        .list-group input[type="checkbox"] {
            display: none;
            border: double;
        }

            .list-group input[type="checkbox"] + label {
                cursor: pointer;
                border: 1px solid rgba(0,0,0,.125);
                position: relative;
                display: block;
                padding: 10px;
                background-color: #fff;
                text-align: center;
                border-radius: 6px;
                height: 55px;
                width: 115px;
                margin: 10px 0;
                background: aliceblue;
                font-size: 10px;
            }

                .list-group input[type="checkbox"] + label:before {
                    content: "\2713";
                    color: transparent;
                    font-weight: bold;
                    margin-right: 1em;
                }

            .list-group input[type="checkbox"]:checked + label {
                background-color: #106571;
                color: #FFF;
            }

                .list-group input[type="checkbox"]:checked + label:before {
                    color: inherit;
                }
    </style>
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
    <style type="text/css">
      input.larger {
        width: 80px;
        height: 80px;
      }
    </style>
    <style type="text/css">
  .BigCheckBox input {width:20px; height:20px;}
</style>

     
     <script src="Scripts/moment.js"></script>

    <script src="Scripts/jquery-3.0.0.js"></script>
    <script src="Scripts/jquery-ui-1.12.1.js"></script>
    <script src="Scripts/jquery.auto-complete-1.0.7.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

     <asp:UpdatePanel ID="UpdatePanel2" runat="server" >
         <Triggers>
            <asp:PostBackTrigger ControlID="btnreport" />
             
        </Triggers>
         <ContentTemplate>
     <section class="content-header d-flex">
        <h1>Drug SCHEDULE </h1>
         <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Drug SCHEDULE</li>
                    </ol>
    </section>
    <section class="content">
        <div id="Div1" class="box" runat="server">
           <!-- <div class="box-header with-border">
                <span class="red pull-right"></span>
                <asp:Label ID="lblMsg1" class="red pull-center" runat="server" Text="" Font-Bold="true" ForeColor="green"></asp:Label>
                <asp:HiddenField ID="txtTreatId" runat="server" />
            </div>-->
             <div class="box-header with-border">
             
                   <div class="row">

                       <div class="col-lg-2  text-left">
                         
                <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-7 pl-0">
                                    <div class="form-group">
                           <asp:Button ID="btnAddTemplate"  Text="+ Template" runat="server"  class="btn btn-success" OnClick="btnAddTemplate_Click" />
                                        </div>
                             </div> 
                        <div class="col-lg-4 ">
                                    <div class="form-group">
                           <asp:Button ID="btnDelTemplate"  Text="Delete" class="btn btn-danger"  runat="server" OnClick="btnDelTemplate_Click" />
                              </div>
                            </div>
                        </div>
                    </div> 
                            <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-7 pl-0">
                                    <div class="form-group">
                           <asp:Button ID="btnCaseSheet"  Text="+ Case Sheet" runat="server"  class="btn btn-primary" OnClick="btnCaseSheet_Click"  />
                                        </div>
                             </div> 
                        <div class="col-lg-4 ">
                                    <div class="form-group">
                           <asp:Button ID="btnCaseSheetDel"  Text="Delete" class="btn btn-warning"  runat="server" OnClick="btnCaseSheetDel_Click" />
                              </div>
                            </div>
                        </div>
                    </div> 
                           
                           <div class="col-lg-12 mt-2 border border-2">
                    <div class="row">
                         
           
                        
                             <ul class="metismenu template-sidemenu" >
                                 <span class="nav-label"><strong> Case Sheet</strong></span>
                   <%-- <li>
                        <a class="active" href="Home.aspx"><i class="sidebar-item-icon fa fa-th-large"></i>
                            <span class="nav-label">Case Sheet</span>
                        </a>
                    </li>--%>
                    <asp:PlaceHolder ID="SlidBarHolder" runat="server"></asp:PlaceHolder>
                </ul>   
                        </div>     
                      </div>       
                      </div>
                          
                  <div class="col-lg-10">
                 <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-12 text-left">
                                    <div class="form-group">
                                         <asp:Label ID="LblMSg"  Font-Bold="true" runat="server" Text=""></asp:Label>
                                        </div>
                             </div>
                        </div>
                      </div>
                 <div class="panel-heading">
                                   Drug Schedule:|                 
                                                 
                 
                     </div>
                 <div class="col-lg-12 mt-2">
                    <div class="row">
                            <div class="col-lg-3 text-center">
                                    <div class="form-group">
                                         <asp:Button ID="btnLongPRotocol" runat="server" Text="LONG AGONIST PROTOCOL" class="btn btn-success" OnClick="btnLongPRotocol_Click"  />
                                        </div>
                                </div>

                        <div class="col-lg-3 text-center">
                                    <div class="form-group">
                                        <asp:Button ID="btnAntagonist" runat="server" Text="ANTAGONIST PROTOCOL" class="btn btn-primary" OnClick="btnAntagonist_Click"  />
                                        </div>
                                </div>
                        </div>
                
                     </div>


                       <div class="col-lg-12 mt-2" id="longprotocol3" runat="server">

                    <div class="row">
                            <div class="col-lg-12 text-center">
                                    <div class="form-group">
                                        <strong>LONG AGONIST PROTOCOL</strong>
                                        </div>
                                </div>
                        </div>
                           </div>
                      <div class="col-lg-12 mt-2" id="longprotocol" runat="server">

                    <div class="row">
                            <div class="col-lg-12 text-center">
                                    <div class="form-group">
                                         <asp:gridview ID="GVlongprotocol" runat="server" ShowFooter="true" Width="100%" AutoGenerateColumns="false">

        <Columns>

        <asp:BoundField DataField="RowNumber" ItemStyle-Width="15px" HeaderText="Row " />

        <asp:TemplateField HeaderText="Date" >

            <ItemTemplate>

                <asp:TextBox ID="txtLongDate" CssClass="form-control" runat="server"></asp:TextBox>

            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
        </asp:TemplateField>

       <asp:TemplateField HeaderText="FSH" >

            <ItemTemplate>

                <asp:TextBox ID="txtLongFSH" CssClass="form-control" runat="server"></asp:TextBox>

            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
        </asp:TemplateField>

             <asp:TemplateField HeaderText="FSH+LH/LH" >

            <ItemTemplate>

                <asp:TextBox ID="txtLongFSHLH" CssClass="form-control" runat="server"></asp:TextBox>

            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
        </asp:TemplateField>

             <asp:TemplateField HeaderText="Units" >

            <ItemTemplate>

                <asp:TextBox ID="txtLongUnits" CssClass="form-control" runat="server"></asp:TextBox>

            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
        </asp:TemplateField>

             <asp:TemplateField HeaderText="Agonist" >

            <ItemTemplate>

                <asp:TextBox ID="txtlongAgonist" CssClass="form-control" runat="server"></asp:TextBox>

            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
        </asp:TemplateField>

            <asp:TemplateField HeaderText="MISC Name" >

            <ItemTemplate>

                <asp:TextBox ID="txtLongMiscName" CssClass="form-control" runat="server"></asp:TextBox>

            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
        </asp:TemplateField>

              <asp:TemplateField HeaderText="MISC Value" >

            <ItemTemplate>

                <asp:TextBox ID="txtLongMiscValue" CssClass="form-control" runat="server"></asp:TextBox>

            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Comments">

            <ItemTemplate>

                 <asp:TextBox ID="txtLongComments" CssClass="form-control" runat="server"></asp:TextBox>

            </ItemTemplate>

            <FooterStyle HorizontalAlign="Right" />

            <FooterTemplate>

             <asp:Button ID="ButtonAdd" runat="server" Text="Add New Row" Visible="false" OnClick="ButtonAdd_Click" />

            </FooterTemplate>

        </asp:TemplateField>

        </Columns>

</asp:gridview>
                                        </div>
                                </div>

                        
                        </div>
                
                     </div>

                       <div class="col-lg-12 mt-2" id="longprotocol1" runat="server">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <strong>No.of Follicles Left Ovary</strong>
                                        </div>
                                </div>

                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <asp:TextBox ID="txtNoofFolliclesleft"  CssClass="form-control"   runat="server" />
                                        </div>
                                </div>
                         <div class="col-lg-3 text-center">
                                    <div class="form-group">
                                         <strong>No.of Follicles Right Ovary</strong>
                                        </div>
                                </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <asp:TextBox ID="txtNoofFolliclesright"  CssClass="form-control"   runat="server" />
                                        </div>
                                </div>
                        <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                         <strong>Consent</strong>
                                        </div>
                                </div>

                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <asp:DropDownList ID="ddlConsent" CssClass="form-control form-select"   runat="server" />
                                        </div>
                                </div>
                        </div>
                           </div>

                       <div class="col-lg-12 mt-2" id="longprotocol2" runat="server">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                      <strong>  Note</strong>
                                        </div>
                            </div>
                        <div class="col-lg-10 text-left">
                                    <div class="form-group">
                                        <asp:TextBox ID="txtnote"  CssClass="form-control"  TextMode="MultiLine"  runat="server" />
                                        </div>
                            </div>
                        </div>
                           </div>



                      <div class="col-lg-12 mt-2" id="Antagonist3" runat="server">

                    <div class="row">
                            <div class="col-lg-12 text-center">
                                    <div class="form-group">
                                        <strong>ANTAGONIST PROTOCOL</strong>
                                        </div>
                                </div>
                        </div>
                           </div>
                        <div class="col-lg-12 mt-2" id="Antagonist" runat="server" visible="false">
                    <div class="row">
                            <div class="col-lg-12 text-center">
                                    <div class="form-group">
                                         <asp:gridview ID="GvAntagonist" runat="server" ShowFooter="true" Width="100%" AutoGenerateColumns="false">

        <Columns>

        <asp:BoundField DataField="RowNumber" ItemStyle-Width="15px" HeaderText="Row " />

        <asp:TemplateField HeaderText="Date" >

            <ItemTemplate>

                <asp:TextBox ID="txtAntaDate" CssClass="form-control" runat="server"></asp:TextBox>

            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
        </asp:TemplateField>

       <asp:TemplateField HeaderText="FSH" >

            <ItemTemplate>

                <asp:TextBox ID="txtAntaFSH" CssClass="form-control" runat="server"></asp:TextBox>

            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
        </asp:TemplateField>

             <asp:TemplateField HeaderText="FSH+LH/LH" >

            <ItemTemplate>

                <asp:TextBox ID="txtAntaFSHLH" CssClass="form-control" runat="server"></asp:TextBox>

            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
        </asp:TemplateField>

             <asp:TemplateField HeaderText="Units" >

            <ItemTemplate>

                <asp:TextBox ID="txtAntaUnits" CssClass="form-control" runat="server"></asp:TextBox>

            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
        </asp:TemplateField>

             <asp:TemplateField HeaderText="Agonist" >

            <ItemTemplate>

                <asp:TextBox ID="txtAntaAgonist" CssClass="form-control" runat="server"></asp:TextBox>

            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
        </asp:TemplateField>

            <asp:TemplateField HeaderText="MISC Name" >

            <ItemTemplate>

                <asp:TextBox ID="txtAntaMiscName" CssClass="form-control" runat="server"></asp:TextBox>

            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
        </asp:TemplateField>

              <asp:TemplateField HeaderText="MISC Value" >

            <ItemTemplate>

                <asp:TextBox ID="txtAntaMiscValue" CssClass="form-control" runat="server"></asp:TextBox>

            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Comments">

            <ItemTemplate>

                 <asp:TextBox ID="txtAntaComments" CssClass="form-control" runat="server"></asp:TextBox>

            </ItemTemplate>

            <FooterStyle HorizontalAlign="Right" />

            <FooterTemplate>

             <asp:Button ID="ButtonAdd" runat="server" Text="Add New Row" Visible="false"  />

            </FooterTemplate>

        </asp:TemplateField>

        </Columns>

</asp:gridview>
                                        </div>
                                </div>

                        
                        </div>
                
                     </div>

                       <div class="col-lg-12 mt-2" id="Antagonist1" runat="server" visible="false">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <strong>No.of Follicles Left Ovary</strong>
                                        </div>
                                </div>

                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <asp:TextBox ID="txtAntafolliclesLeft"  CssClass="form-control"   runat="server" />
                                        </div>
                                </div>
                         <div class="col-lg-3 text-center">
                                    <div class="form-group">
                                         <strong>No.of Follicles Right Ovary</strong>
                                        </div>
                                </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <asp:TextBox ID="txtAntafolliclesright"  CssClass="form-control"   runat="server" />
                                        </div>
                                </div>
                       
                        </div>
                           </div>

                       <div class="col-lg-12 mt-2" id="Antagonist2" runat="server" visible="false">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                      <strong>  Note</strong>
                                        </div>
                            </div>
                        <div class="col-lg-10 text-left">
                                    <div class="form-group">
                                        <asp:TextBox ID="txtAntaNote"  CssClass="form-control"  TextMode="MultiLine"  runat="server" />
                                        </div>
                            </div>
                        </div>
                           </div>

                </div>
                     
                   
                    <%-- <div class="col-lg-2  text-left">
                         
                <strong>Case Sheet</strong>
                           <asp:TextBox ID="txtcaseheeet1"  CssClass="form-control"  TextMode="MultiLine" Height="600px" runat="server" />
                                      
                      </div>--%>
                   </div>
                
                 
                  <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-12 text-center">
                                    <div class="form-group">
                                        <asp:Button ID="btnsave" runat="server" Text="Save" class="btn btn-success" OnClick="btnsave_Click" />
                                        <asp:Button ID="btnReset" runat="server" Text="Reset" class="btn btn-warning" />
                                        <asp:Button ID="BtnBirthRegister" runat="server" class="btn btn-primary btnSearch" Text="+" />
                                        <asp:Button ID="btnreport" runat="server" class="btn btn-primary btnSearch" Text="Report" OnClick="btnreport_Click" />
                                    </div>
                                </div>
                        
                        
                        </div>
                     </div>
                    <div class="col-lg-12 mt-2">
                    <div class="row">
                         <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"
                                    class="table table-responsive table-sm table-bordered" Width="100%" DataKeyNames="GeneralID"
                                    HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3" OnRowDeleting="gvdChief_RowDeleting"
                                    AllowPaging="True" BackColor="White" OnRowCommand="gvdChief_RowCommand" OnRowEditing="gvdChief_RowEditing"
                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="15" ShowHeaderWhenEmpty="True"
                                    OnPageIndexChanging="gvdChief_PageIndexChanging">
                                    <Columns>
                                        <asp:CommandField ButtonType="Image" EditImageUrl="~/Images0/edit.gif" 
                                     ShowCancelButton="False" ShowEditButton="True">
                                <ItemStyle HorizontalAlign="Center" Width="70px" />
                                </asp:CommandField>
                                        <asp:BoundField DataField="Duration_Days" HeaderText="Days"  />
                                        
                                        <asp:BoundField DataField="Duration_Week" HeaderText="Week"  />
                                        <asp:BoundField DataField="Duration_Months" HeaderText="Month"  />
                                         <asp:BoundField DataField="Duration_Years" HeaderText="Years "  />
                                         <asp:BoundField DataField="Parity" HeaderText="Parity"  />
                                          <asp:BoundField DataField="LastLMP" HeaderText="Last LMP"  />
                                          <asp:BoundField DataField="CreatedBy" HeaderText=" Created By"  />
                                         
                                         <asp:BoundField DataField="CreatedOn" HeaderText="Created On"  />
                                        <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="Delete" runat="server" CommandName="Delete" 
                                             ImageUrl="~/Images0/delete.gif" 
                                            OnClientClick="return ValidateDelete()" 
                                            ToolTip="Click here to Delete this record" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="70px" />
                                </asp:TemplateField>
                                       <%-- <asp:BoundField DataField="chiefcomplaints" ItemStyle-Width="80%" HeaderText="Complaints"  />--%>
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
           
    </section>
     <asp:ModalPopupExtender ID="mp1" runat="server" PopupControlID="CheifPanel" TargetControlID="BtnBirthRegister"
                CancelControlID="btnCloseM1" BackgroundCssClass="modalBackground ">
            </asp:ModalPopupExtender>

            <asp:Panel ID="CheifPanel" runat="server" CssClass="modalPopup" align="center" Style="display: none" CancelControlID="btnCloseM1">
                <div>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="header">
                                General Gynaecology:
                            </div>
                            <div class="body">
                                <asp:GridView ID="gvdChief" runat="server" AutoGenerateColumns="false"
                                    class="table table-responsive table-sm table-bordered" Width="100%" DataKeyNames="GeneralID"
                                    HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3" OnRowDeleting="gvdChief_RowDeleting"
                                    AllowPaging="True" BackColor="White" OnRowCommand="gvdChief_RowCommand" OnRowEditing="gvdChief_RowEditing"
                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="15" ShowHeaderWhenEmpty="True"
                                    OnPageIndexChanging="gvdChief_PageIndexChanging">
                                    <Columns>
                                       
                                        <asp:BoundField DataField="Duration_Days" HeaderText="Days"  />
                                        
                                        <asp:BoundField DataField="Duration_Week" HeaderText="Week"  />
                                        <asp:BoundField DataField="Duration_Months" HeaderText="Month"  />
                                         <asp:BoundField DataField="Duration_Years" HeaderText="Years "  />
                                         <asp:BoundField DataField="Parity" HeaderText="Parity"  />
                                          <asp:BoundField DataField="LastLMP" HeaderText="Last LMP"  />
                                          <asp:BoundField DataField="CreatedBy" HeaderText=" Created By"  />
                                         
                                         <asp:BoundField DataField="CreatedOn" HeaderText="Created On"  />
                                       <%-- <asp:BoundField DataField="chiefcomplaints" ItemStyle-Width="80%" HeaderText="Complaints"  />--%>
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
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <asp:Button ID="btnCloseM1" runat="server" Text="Close" />
            </asp:Panel>

               <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="AddTemp" TargetControlID="btnAddTemplate"
                CancelControlID="btnCloseM1" BackgroundCssClass="modalBackground ">
            </asp:ModalPopupExtender>

            <asp:Panel ID="AddTemp" runat="server" CssClass="modalPopup" align="center" Style="display: none" CancelControlID="btnCloseM1">
                <div>
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <div class="header">
                                Add Template
                            </div>  
                            <div class="col-lg-8 text-left">
                            <div class="form-group" style="width:300px" >
                               <asp:CheckBoxList ID="Chkmaintestshort"   type="checkbox" CssClass="BigCheckBox" Font-Bold="true" Font-Size="Large" Font-Italic="true"  RepeatDirection="Vertical" name="CheckBoxInputName" runat="server"   Width="100%" AutoPostBack="false" OnSelectedIndexChanged="Chkmaintestshort_SelectedIndexChanged">
                        </asp:CheckBoxList>
                            </div>
                                </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <asp:Button ID="btnAddT" runat="server" Text="Add" OnClick="btnAddT_Click" class="btn btn-primary" />
            </asp:Panel>


             <asp:ModalPopupExtender ID="ModalPopupExtender3" runat="server" PopupControlID="Panel15" TargetControlID="btnDelTemplate"
                CancelControlID="btnCloseM1" BackgroundCssClass="modalBackground ">
            </asp:ModalPopupExtender>

            <asp:Panel ID="Panel15" runat="server" CssClass="modalPopup" align="center" Style="display: none" CancelControlID="btnCloseM1">
                <div>
                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                        <ContentTemplate>
                            <div class="header">
                                Add Template
                            </div>  
                            <div class="col-lg-8 text-left">
                            <div class="form-group" style="width:300px" >
                              <asp:CheckBoxList ID="ChkDelTemplate"   type="checkbox" CssClass="BigCheckBox" Font-Bold="true" Font-Size="Large" Font-Italic="true"  RepeatDirection="Vertical" name="CheckBoxInputName" runat="server"   Width="100%" AutoPostBack="false" OnSelectedIndexChanged="ChkDelTemplate_SelectedIndexChanged"  >
                        </asp:CheckBoxList>
                            </div>
                                </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                 <asp:Button ID="btnDelT" runat="server" Text="Add" OnClick="btnDelT_Click" class="btn btn-danger" />
            </asp:Panel>

              <asp:ModalPopupExtender ID="ModalPopupExtender2" runat="server" PopupControlID="Panel16" TargetControlID="btnCaseSheetDel"
                CancelControlID="btnCloseM1" BackgroundCssClass="modalBackground ">
            </asp:ModalPopupExtender>

            <asp:Panel ID="Panel16" runat="server" CssClass="modalPopup" align="center" Style="display: none" CancelControlID="btnCloseM1">
                <div>
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                            <div class="header">
                                Add Template
                            </div>  
                            <div class="col-lg-10 text-left">
                            <div class="form-group" style="width:400px" >
                              <asp:CheckBoxList ID="ChkCaseSheet"   type="checkbox" CssClass="BigCheckBox" Font-Bold="true" Font-Size="Large" Font-Italic="true"  RepeatDirection="Vertical" name="CheckBoxInputName" runat="server"   Width="100%" AutoPostBack="false" OnSelectedIndexChanged="ChkCaseSheet_SelectedIndexChanged"  >
                        </asp:CheckBoxList>
                            </div>
                                </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                 <asp:Button ID="btndelcasesheet" runat="server" Text="Delete Case Sheet" OnClick="btnDelT_Click" class="btn btn-danger" />
            </asp:Panel>
             

           

             
           
             </ContentTemplate>
         </asp:UpdatePanel>
    <script language="javascript" type="text/javascript">
        function OpenReport() {
            window.open("Reports.aspx");
        }
        </script>
</asp:Content>
