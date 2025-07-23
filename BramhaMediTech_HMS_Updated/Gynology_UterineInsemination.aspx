<%@ Page Title="" Language="C#" MasterPageFile="~/TemplateMaster.master" AutoEventWireup="true" CodeFile="Gynology_UterineInsemination.aspx.cs" Inherits="Gynology_UterineInsemination" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
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
    
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <asp:UpdatePanel ID="UpdatePanel2" runat="server" >
         <Triggers>
            <asp:PostBackTrigger ControlID="btnreport" />
             
        </Triggers>
         <ContentTemplate>
     <section class="content-header d-flex">
        <h1>Intra -  Uterine  Insemination  </h1>
         <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Intra -  Uterine  Insemination </li>
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
              
                 
                 <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-12 text-left">
                                    <div class="form-group">
                                         <asp:Label ID="LblMSg"  Font-Bold="true" runat="server" Text=""></asp:Label>
                                        </div>
                             </div>
                        </div>
                      </div>
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
                        <div class="panel-heading">
                                  D-Lap |                 
                                                 
                 </div>
                     </div>
                 <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  LMP</strong>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                        <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                <asp:TextBox ID="txtLMP" autocomplete="off" runat="server" class="form-control pull-right" TabIndex="1"></asp:TextBox>
                                                <span class="input-group-addon">
                                                     <i class="fa fa-calendar"></i>
                                                </span>
                                            </div>
                                        </div>
                              </div>
                        </div>
                     </div>
                  <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                     
                                        
                                    </div>
                                </div>
                        
                         <div class="col-lg-10 text-left">
                                    <div class="form-group form-check pl-0">
                                        <asp:TextBox ID="txtDLAP" placeholder="Enter Remark" CssClass="form-control"  TextMode="MultiLine"  runat="server" />
                                      
                                    </div>
                                </div>
                        

                    </div>
                </div>

                  
                        <div class="panel-heading mt-3">
                                  IUI-3 Cycles |                 
                                                 
                 </div>

                      <div class="col-lg-12 mt-2">
                    <div class="row">

                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <strong>Clomifene</strong>
                                        </div>
                            </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <strong>LetroZole(1 OD)</strong>
                                        </div>
                            </div>
                         <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                        <strong>Metformin (500 mg TID)</strong>
                                        </div>
                            </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <strong>Inj.FSH</strong>
                                        </div>
                            </div>
                        </div>
                          </div>

                  <div class="col-lg-12 mt-2">
                    <div class="row">

                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        
                                        <asp:DropDownList ID="ddlClomifene"  CssClass="form-control form-select"  runat="server" >
                                           <asp:ListItem Value=""></asp:ListItem>
                                            <asp:ListItem Value="50">50</asp:ListItem>
                                            <asp:ListItem Value="100">100</asp:ListItem>
                                         <asp:ListItem Value="150">150</asp:ListItem>
                                           
                                        </asp:DropDownList>
                                        </div>
                            </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        
                                        <asp:DropDownList ID="ddlLetroZole"  CssClass="form-control form-select"  runat="server" >
                                           <asp:ListItem Value=""></asp:ListItem>
                                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                            <asp:ListItem Value="No">No</asp:ListItem>
                                         
                                           
                                        </asp:DropDownList>
                                        </div>
                            </div>
                         <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                      
                                         <asp:DropDownList ID="ddlMetformin"  CssClass="form-control form-select"  runat="server" >
                                           <asp:ListItem Value=""></asp:ListItem>
                                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                            <asp:ListItem Value="No">No</asp:ListItem>
                                         
                                           
                                        </asp:DropDownList>
                                        </div>
                            </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        
                                        <asp:TextBox ID="txtInjFsh" CssClass="form-control"  runat="server" placeholder="Inj.FSH" ></asp:TextBox>
                                        </div>
                            </div>
                           <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                         <asp:Button ID="btnAdd"  Text="+ Add" runat="server"  class="btn btn-success" OnClick="btnAdd_Click" />
                                        </div>
                               </div>
                        </div>
                          </div>
                  <div class="col-lg-12 mt-2">
                    <div class="row">
                    <asp:GridView ID="gvBill" runat="server" AutoGenerateColumns="False" 
                                OnRowDeleting="gvBill_RowDeleting" DataKeyNames="IUDId" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                                class="table table-responsive table-sm table-bordered" Width="100%"
                                HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White"   
                                 BorderWidth="1px" CellPadding="3"  TabIndex="17"
                                 ShowHeaderWhenEmpty="True" OnPageIndexChanging="gvBill_PageIndexChanging" 
                                 EmptyDataText="No Records to Display" onrowdatabound="gvBill_RowDataBound" 
                                ShowFooter="True" onselectedindexchanged="gvBill_SelectedIndexChanged" OnRowEditing="gvBill_RowEditing">
                                 <FooterStyle Font-Bold="true" BackColor="#61A6F8" ForeColor="black" />
<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                            <Columns>                                
                                    <asp:CommandField ButtonType="Image" EditImageUrl="~/Images0/edit.gif" 
                                    ShowCancelButton="False" ShowEditButton="True">
                                    <ItemStyle Width="30px" HorizontalAlign="Center" />
                                </asp:CommandField>
                               <asp:BoundField DataField="Clomifene" HeaderText="Clomifene"  >  
                                   
                                   </asp:BoundField>
                                 <asp:BoundField DataField="LetroZole" HeaderText="LetroZole(1 OD)"  > 
                                   
                                   
                                    </asp:BoundField>
                                 <asp:BoundField DataField="Metformin" HeaderText="Metformin (500 mg TID)"  > 
                                   
                                   
                                    </asp:BoundField>
                                  <asp:BoundField DataField="Inj_FSH" HeaderText="Inj.FSH"  > 
                                   
                                   
                                    </asp:BoundField>
                                
                                
                            
                                  <asp:TemplateField >
                                    <ItemTemplate>
                                        <asp:ImageButton ID="Delete" runat="server" CommandName="Delete"  CausesValidation="false"
                                            ImageUrl="~/Images0/delete.gif" OnClientClick="return ValidateDelete()" ToolTip="Click here to Delete this record" />
                                    </ItemTemplate>
                                    <ItemStyle Width="30px" HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                             <FooterStyle BackColor="White" ForeColor="#000066" HorizontalAlign="center" />                                     
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

                     <div class="panel-heading mt-3">
                                  FOLLICULAR IMAGING CHART FOR IUI |                 
                                                 
                 </div>
                       <div class="col-lg-12 mt-2">
                    <div class="row">
                        <asp:gridview ID="GVFOL_LICULAR" runat="server" ShowFooter="true" Width="100%" AutoGenerateColumns="false">

        <Columns>

        <asp:BoundField DataField="RowNumber" HeaderText="Row " />

        <asp:TemplateField HeaderText="Date" >

            <ItemTemplate>

                <asp:TextBox ID="txtDate1" CssClass="form-control" runat="server"></asp:TextBox>

            </ItemTemplate>
            <ItemStyle Width="100px" HorizontalAlign="Center" />
             <HeaderStyle Width="100px" HorizontalAlign="right" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Day">

            <ItemTemplate>

                <asp:TextBox ID="txtDay1" CssClass="form-control" runat="server"></asp:TextBox>

            </ItemTemplate>

        </asp:TemplateField>


            <asp:TemplateField HeaderText="Follicles Right Ovary">

            <ItemTemplate>

                <asp:TextBox ID="txtFolliclesRightOvary1" CssClass="form-control" runat="server"></asp:TextBox>

            </ItemTemplate>

        </asp:TemplateField>
             <asp:TemplateField HeaderText="Follicles Left Ovary">

            <ItemTemplate>

                <asp:TextBox ID="txtFolliclesLeftOvary1" CssClass="form-control" runat="server"></asp:TextBox>

            </ItemTemplate>

        </asp:TemplateField>
            <asp:TemplateField HeaderText="Endometrial Thickness">

            <ItemTemplate>

                <asp:TextBox ID="txtEndometrialThickness1" CssClass="form-control" runat="server"></asp:TextBox>

            </ItemTemplate>

        </asp:TemplateField>
             <asp:TemplateField HeaderText="Plan">

            <ItemTemplate>

                <asp:TextBox ID="txtPlan1" CssClass="form-control" runat="server"></asp:TextBox>

            </ItemTemplate>

        </asp:TemplateField>
        <asp:TemplateField HeaderText="Remark">

            <ItemTemplate>

                 <asp:TextBox ID="txtRemark1" CssClass="form-control" runat="server"></asp:TextBox>

            </ItemTemplate>

            <FooterStyle HorizontalAlign="Right" />

            <FooterTemplate>

             <asp:Button ID="ButtonAdd" runat="server" Text="Add New Row" OnClick="ButtonAdd_Click1" />

            </FooterTemplate>

        </asp:TemplateField>

        </Columns>

</asp:gridview>

                        </div>
                           </div>
                    <%--  <div class="col-lg-12 mt-2">
                    <div class="row">

                        <div class="col-lg-2 text-left  pl-0">
                                    <div class="form-group">
                                        <strong>Date</strong>
                                        </div>
                            </div>
                         <div class="col-lg-1 text-left  pl-0">
                                    <div class="form-group">
                                        <strong>Day</strong>
                                        </div>
                            </div>
                         <div class="col-lg-2 text-left  pl-0">
                                    <div class="form-group">
                                        <strong>Follicles Right Ovary</strong>
                                        </div>
                            </div>
                        <div class="col-lg-1 text-left  pl-0">
                                    <div class="form-group">
                                        <strong>Follicles Left Ovary</strong>
                                        </div>
                            </div>

                        <div class="col-lg-2 text-left ">
                                    <div class="form-group">
                                        <strong>Endometrial Thickness</strong>
                                        </div>
                            </div>
                        <div class="col-lg-1 text-left ">
                                    <div class="form-group">
                                        <strong>Plan</strong>
                                        </div>
                            </div>
                        <div class="col-lg-2 text-left  pl-0">
                                    <div class="form-group">
                                        <strong>Remark</strong>
                                        </div>
                            </div>
                        
                        </div>
                          </div>

                  <div class="col-lg-12 mt-2">
                    <div class="row">

                        <div class="col-lg-2 text-left  pl-0">
                                    <div class="form-group">
                                        
                                        <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                <asp:TextBox ID="txtdate" autocomplete="off"  runat="server" class="form-control pull-right" TabIndex="1"></asp:TextBox>
                                                <span class="input-group-addon">
                                                     <i class="fa fa-calendar"></i>
                                                </span>
                                            </div>
                                        </div>
                            </div>
                         <div class="col-lg-1 text-left  pl-0">
                                    <div class="form-group">
                                        
                                        <asp:TextBox ID="txtday" CssClass="form-control"  runat="server" placeholder=" Day" ></asp:TextBox>
                                        </div>
                            </div>
                         <div class="col-lg-2 text-left  pl-0">
                                    <div class="form-group">
                                      
                                         <asp:TextBox ID="txtFolliclesRightOvary" CssClass="form-control"  runat="server" placeholder=" Follicles Right Ovary" ></asp:TextBox>
                                        </div>
                            </div>
                        <div class="col-lg-2 text-left  pl-0">
                                    <div class="form-group">
                                        
                                        <asp:TextBox ID="txtFolliclesleftOvary" CssClass="form-control"  runat="server" placeholder="Follicles Left Ovary" ></asp:TextBox>
                                        </div>
                            </div>
                         <div class="col-lg-1 text-left  pl-0">
                                    <div class="form-group">
                                        
                                        <asp:TextBox ID="txtEndometrialThickness" CssClass="form-control"  runat="server" placeholder="Endometrial Thickness" ></asp:TextBox>
                                        </div>
                            </div>
                        <div class="col-lg-1 text-left  pl-0">
                                    <div class="form-group">
                                        
                                        <asp:TextBox ID="txtplan" CssClass="form-control"  runat="server" placeholder="Plan" ></asp:TextBox>
                                        </div>
                            </div>
                            <div class="col-lg-2 text-left  pl-0">
                                    <div class="form-group form-check pl-0">
                                        <asp:TextBox ID="txtRemark" placeholder="Enter Remark" CssClass="form-control"  TextMode="MultiLine"  runat="server" />
                                      
                                    </div>
                                </div>
                        </div>
                          </div>--%>

                  

                  <div class="col-lg-12 mt-3">
                    <div class="row">
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       <strong>Trigger</strong>
                                     
                                        
                                    </div>
                                </div>
                        
                         <div class="col-lg-2 text-left">
                                    <div class="form-group form-check pl-0">
                                        <asp:TextBox ID="txtTrigger" placeholder="Enter Trigger" CssClass="form-control"    runat="server" />
                                      
                                    </div>
                                </div>
                        <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       <strong>IUI Date</strong>
                                     
                                        
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                     <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                <asp:TextBox ID="txtIUIDate" autocomplete="off" runat="server" class="form-control pull-right" TabIndex="1"></asp:TextBox>
                                                <span class="input-group-addon">
                                                     <i class="fa fa-calendar"></i>
                                                </span>
                                            </div>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        (dd/MM/yyyy hh:mm)
                                        </div>
                            </div>

                    </div>
                </div>


                   <div class="col-lg-12 mt-3">
                    <div class="row">
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       <strong>Motility</strong>
                                     
                                        
                                    </div>
                                </div>
                        
                         <div class="col-lg-2 text-left">
                                    <div class="form-group form-check pl-0">
                                        <asp:TextBox ID="txtMotility" placeholder="Enter Motility" CssClass="form-control"    runat="server" />
                                      
                                    </div>
                                </div>
                        <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       <strong>Luteal Support</strong>
                                     
                                        
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                     <asp:TextBox ID="txtlutealsupport" placeholder="Enter Luteal Support" CssClass="form-control"    runat="server" />
                                        
                                    </div>
                                </div>
                        <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       <strong> Count</strong>
                                        </div>
                            </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                     <asp:TextBox ID="txtcount" placeholder="Enter Count" CssClass="form-control"    runat="server" />
                                        
                                    </div>
                                </div>
                    </div>
                </div>

                 <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                     
                                        <strong>Comments</strong>
                                    </div>
                                </div>
                        
                         <div class="col-lg-10 text-left">
                                    <div class="form-group form-check pl-0">
                                        <asp:TextBox ID="txtComments" placeholder="Enter Comments" CssClass="form-control"  TextMode="MultiLine"  runat="server" />
                                      
                                    </div>
                                </div>
                        

                    </div>
                </div>
                      </div>
              <%--  <div class="col-lg-2  text-left">
                         
                <strong>Case Sheet</strong>
                           <asp:TextBox ID="txtcaseheeet"  CssClass="form-control"  TextMode="MultiLine" Height="600px" runat="server" />
                                      
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
                  <div class="col-lg-12 mt-3 text-center">
                                    <div class="form-group">
                 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"
                                    class="table table-responsive table-sm table-bordered" Width="100%" DataKeyNames="IntraId"
                                    HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3" OnRowDeleting="gvdChief_RowDeleting"
                                    AllowPaging="True" BackColor="White" OnRowCommand="gvdChief_RowCommand" OnRowEditing="gvdChief_RowEditing"
                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="15" ShowHeaderWhenEmpty="True"
                                    OnPageIndexChanging="gvdChief_PageIndexChanging">
                                    <Columns>
                                       
                                       <asp:CommandField ButtonType="Image" EditImageUrl="~/Images0/edit.gif" 
                                     ShowCancelButton="False" ShowEditButton="True">
                                <ItemStyle HorizontalAlign="Center" Width="70px" />
                                </asp:CommandField>
                                        
                                        <asp:BoundField DataField="LMPDate" HeaderText="LMP Date"  />
                                          <asp:BoundField DataField="Clomifene" HeaderText="Clomifene"  />
                                        <asp:BoundField DataField="LetroZole" HeaderText="LetroZole"  />
                                         <asp:BoundField DataField="Metformin" HeaderText="Metformin"  />
                                        <asp:BoundField DataField="Inj_FSH" HeaderText="Inj_FSH "  />
                                        <asp:BoundField DataField="FollCareDate" HeaderText="FollCare Date"  />
                                         <asp:BoundField DataField="FollicareDay" HeaderText="Follicare Day"  />
                                         <asp:BoundField DataField="FolliclesRightOvary" HeaderText="FolliclesRight Ovary"  />
                                         <asp:BoundField DataField="FolliclesLiftOvary" HeaderText="FolliclesLift Ovary"  />
                                        <asp:BoundField DataField="Endometrial" HeaderText="Endometrial"  />
                                        <asp:BoundField DataField="FolliclesPlan" HeaderText="Follicles Plan"  />
                                         
                                         
                                         <asp:BoundField DataField="CreatedBy" HeaderText="Created By"  />
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
                               Infertility:
                            </div>
                            <div class="body">
                                <asp:GridView ID="gvdChief" runat="server" AutoGenerateColumns="false"
                                    class="table table-responsive table-sm table-bordered" Width="100%" DataKeyNames="IntraId"
                                    HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3" OnRowDeleting="gvdChief_RowDeleting"
                                    AllowPaging="True" BackColor="White" OnRowCommand="gvdChief_RowCommand" OnRowEditing="gvdChief_RowEditing"
                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="15" ShowHeaderWhenEmpty="True"
                                    OnPageIndexChanging="gvdChief_PageIndexChanging">
                                    <Columns>
                                       
                                      
                                        
                                        <asp:BoundField DataField="LMPDate" HeaderText="LMP Date"  />
                                          <asp:BoundField DataField="Clomifene" HeaderText="Clomifene"  />
                                        <asp:BoundField DataField="LetroZole" HeaderText="LetroZole"  />
                                         <asp:BoundField DataField="Metformin" HeaderText="Metformin"  />
                                        <asp:BoundField DataField="Inj_FSH" HeaderText="Inj_FSH "  />
                                        <asp:BoundField DataField="FollCareDate" HeaderText="FollCare Date"  />
                                         <asp:BoundField DataField="FollicareDay" HeaderText="Follicare Day"  />
                                         <asp:BoundField DataField="FolliclesRightOvary" HeaderText="FolliclesRight Ovary"  />
                                         <asp:BoundField DataField="FolliclesLiftOvary" HeaderText="FolliclesLift Ovary"  />
                                        <asp:BoundField DataField="Endometrial" HeaderText="Endometrial"  />
                                        <asp:BoundField DataField="FolliclesPlan" HeaderText="Follicles Plan"  />
                                         
                                         
                                         <asp:BoundField DataField="CreatedBy" HeaderText="Created By"  />
                                         <asp:BoundField DataField="CreatedOn" HeaderText="Created On"  />
                                      
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
                <asp:Button ID="Button1" runat="server" OnClick="btnAddT_Click"  Text="Add" class="btn btn-primary" />
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
                 <asp:Button ID="btnDelT" runat="server" Text="Delete Template" OnClick="btnDelT_Click" class="btn btn-danger" />
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
