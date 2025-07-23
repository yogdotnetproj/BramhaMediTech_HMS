<%@ Page Title="" Language="C#" MasterPageFile="~/mainMaster.master" AutoEventWireup="true" CodeFile="PostpartumExamination.aspx.cs" Inherits="PostpartumExamination" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
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
     <section class="content-header d-flex">
        <h1>Postpartum Examination</h1>
         <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Postpartum Examination</li>
                    </ol>
    </section>
     <section class="content">
        <div id="Div1" class="box" runat="server">
            <!--<div class="box-header with-border">
                <span class="red pull-right"></span>
                <asp:Label ID="lblMsg1" class="red pull-center" runat="server" Text="" Font-Bold="true" ForeColor="green"></asp:Label>
                <asp:HiddenField ID="txtTreatId" runat="server" />
            </div>-->
             <div class="box-header with-border">
                
                 
                  
                 
                <div class="col-lg-12 mt-3">
                    <div class="row">
                        <label for="lblBranchId" style="text-align: center"><b> Pre-Pregnancy Value :</b></label>
<asp:Label id="lblmsg" style="text-align: center" ForeColor="Red" runat="server"  Font-Bold="true"> </asp:Label>

                    </div>

                </div>

                 <div class="col-lg-12 mt-3">
                    <div class="row">
                         <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtHeight" CssClass="form-control" placeholder="Height" runat="server" Text=""></asp:TextBox>
                                    </div>
                                </div>
                          <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtweight" CssClass="form-control" placeholder="Weight" runat="server" Text=""></asp:TextBox>
                                    </div>
                                </div>
                        <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtBMI" CssClass="form-control" placeholder="BMI" runat="server" Text=""></asp:TextBox>
                                    </div>
                                </div>

                    </div>

                </div>
                 <div class="col-lg-12 mt-3">
                    <div class="row">
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="lbldsmoke"   runat="server" Text="Do u Smoke?"></asp:Label>
                                    </div>
                                </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group form-check">
                                       
                                        <asp:RadioButtonList ID="rblsmoking" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="1">Yes</asp:ListItem>
                                            <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                        <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtSmokeRemark" CssClass="form-control"  placeholder="Smoke Remark" runat="server" Text=""></asp:TextBox>

                                    </div>
                                </div>
                        <div class="col-lg-2 p-0">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="LblsmQu"   runat="server" Text="DateQuite(if applicable)"></asp:Label>
                                    </div>
                                </div>

                        <div class="col-lg-3  text-left">
                                        <div class="form-group">
                                           <%-- <label for="txtStart">Start Date:</label>--%>
                                            <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                <asp:TextBox ID="txtStart" runat="server" CssClass="form-control pull-right"></asp:TextBox>
                                                <span class="input-group-addon"> <i class="fa fa-calendar"></i></span>
                                            </div>
                                        </div>
                                    </div>
                        </div>
                     </div>
                 <div class="col-lg-12 mt-3">
                    <div class="row">
                         <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label1"   runat="server" Text="Depression:"></asp:Label>
                                    </div>
                                </div>
                        <div class="col-lg-5 text-left">
                                    <div class="form-group form-check pl-0">
                                       
                                        <asp:CheckBox ID="chkDep" Text="Signs/Symptoms of Postpartum Depression" runat="server" />
                                    </div>
                                </div>
                        
                        <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtDepressioncomment" CssClass="form-control"  placeholder="Comment" runat="server" Text=""></asp:TextBox>

                                    </div>
                                </div>

                        
                        </div>
                     </div>
                 <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label2"   runat="server" Text="Feeding:"></asp:Label>
                                    </div>
                                </div>
                        <div class="col-lg-5 text-left">
                                    <div class="form-group form-check">
                                       
                                        <asp:RadioButtonList ID="rblFeeding" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="0" Selected="True" Text="Brest Feeding"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Bottle Feeding"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                        
                        <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtFeedingComment" CssClass="form-control"  placeholder="Comment" runat="server" Text=""></asp:TextBox>

                                    </div>
                                </div>

                        
                        </div>
                     </div>

                 <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label5"   runat="server" Text="Bleeding:"></asp:Label>
                                    </div>
                                </div>
                        <div class="col-lg-5 text-left">
                                    <div class="form-group form-check">
                                       
                                        <asp:RadioButtonList ID="rblBleeding" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="0" Selected="True" Text="Stopped"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Light"></asp:ListItem>
                                             <asp:ListItem Value="2" text="Still Bleeding"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                        
                        <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtbleedingComment" CssClass="form-control" placeholder="Comment" runat="server" Text=""></asp:TextBox>

                                    </div>
                                </div>

                        
                        </div>
                     </div>

                  <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label7" runat="server" Text="Brest Exam:"></asp:Label>
                                    </div>
                                </div>
                        <div class="col-lg-5 text-left">
                                    <div class="form-group form-check">
                                       
                                        <asp:RadioButtonList ID="rblBrestExam" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="0" Selected="True" Text="WithoutMass"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Mass at"></asp:ListItem>
                                           
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                        
                        <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtBrestComment" CssClass="form-control"  placeholder="Comment" runat="server" Text=""></asp:TextBox>

                                    </div>
                                </div>

                        
                        </div>
                     </div>
                 <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label8"   runat="server" Text="Brest Complaints:"></asp:Label>
                                    </div>
                                </div>
                        
                        
                        <div class="col-lg-9 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtbrestcomplants"  CssClass="form-control" placeholder="Comment" runat="server" Text=""></asp:TextBox>

                                    </div>
                                </div>

                        
                        </div>
                     </div>

                  <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label9"   runat="server" Text="C-Section:"></asp:Label>
                                    </div>
                                </div>
                        <div class="col-lg-5 text-left">
                                    <div class="form-group form-check">
                                       
                                        <asp:RadioButtonList ID="RblCSection" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="0" Selected="True" Text="Well Healed" ></asp:ListItem>
                                            <asp:ListItem Value="1" Text="N/A" ></asp:ListItem>
                                           
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                        
                        <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtCComment" CssClass="form-control"  placeholder="Comment" runat="server" Text=""></asp:TextBox>

                                    </div>
                                </div>

                        
                        </div>
                     </div>
                  <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label10"   runat="server" Text="Episiotomy/Laceration:"></asp:Label>
                                    </div>
                                </div>
                        <div class="col-lg-5 text-left">
                                    <div class="form-group form-check">
                                       
                                        <asp:RadioButtonList ID="RblEPisiotomy" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="1" Text="Well Healed" ></asp:ListItem>
                                           
                                           
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                        
                        <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtEpisiotomyComment" CssClass="form-control"  placeholder="Comment" runat="server" Text=""></asp:TextBox>

                                    </div>
                                </div>

                        
                        </div>
                     </div>
                  <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label11"   runat="server" Text="Uterus:"></asp:Label>
                                    </div>
                                </div>
                        <div class="col-lg-5 text-left">
                                    <div class="form-group form-check">
                                       
                                        <asp:RadioButtonList ID="RblUterus" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="1" Text="Involuted"></asp:ListItem>                                          
                                           
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                        
                        <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtUterusComment" CssClass="form-control" placeholder="Comment" runat="server" Text=""></asp:TextBox>

                                    </div>
                                </div>

                        
                        </div>
                     </div>
                  <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label12"   runat="server" Text="Birth Control:"></asp:Label>
                                    </div>
                                </div>
                        <div class="col-lg-9 text-left">
                                    <div class="form-group form-check">
                                       
                                        <asp:RadioButtonList ID="RblBirthControl" runat="server" RepeatDirection="Horizontal" RepeatColumns="4">
                                            <asp:ListItem Selected="True" Value="4" Text="Condoms"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Oral Contraceptive Pills"></asp:ListItem>
                                            <asp:ListItem  Value="2" Text="Wants Mirena IUD"></asp:ListItem>   
                                            <asp:ListItem  Value="3" Text="Depo Provera"></asp:ListItem>                                            
                                            <asp:ListItem  Value="5" Text="Progestin Only Pill"></asp:ListItem>
                                            <asp:ListItem  Value="6" Text="Wants Paragard IUD"></asp:ListItem>
                                            <asp:ListItem  Value="7" Text="NuvaRing"></asp:ListItem>
                                            <asp:ListItem Value="0" Text="None"></asp:ListItem>
                                           
                                            
                                           
                                           
                                        </asp:RadioButtonList>
                                    </div>
                                </div> 
                        
                        </div>
                     </div>

                 <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label13"   runat="server" Text="Birth Control Comment:"></asp:Label>
                                    </div>
                                </div>
                        <div class="col-lg-9 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtbirthcontrolComment" CssClass="form-control" placeholder="Comment" runat="server" Text=""></asp:TextBox>

                                    </div>
                                </div> 
                        
                        </div>
                     </div>
                  <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label14"   runat="server" Text="Remark:"></asp:Label>
                                    </div>
                                </div>
                        <div class="col-lg-9 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtRemark" CssClass="form-control" placeholder="Remark" runat="server" Text=""></asp:TextBox>

                                    </div>
                                </div> 
                        
                        </div>
                     </div>
                  <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-12 text-center">
                                    <div class="form-group">
                                        <asp:Button ID="btnsave" runat="server" Text="Save" class="btn btn-success" OnClick="btnsave_Click" />
                                        <asp:Button ID="btnReset" runat="server" Text="Reset" class="btn btn-warning" />
                                         <asp:Button ID="BtnBirthRegister" runat="server" class="btn btn-primary btnSearch" Text="+" />
                                    </div>
                                </div>
                        
                        
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
                                Postpartum Examination  :
                            </div>
                            <div class="body">
                                <asp:GridView ID="gvdChief" runat="server" AutoGenerateColumns="false"
                                    class="table table-responsive table-sm table-bordered" Width="100%" DataKeyNames="PostID"
                                    HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3" OnRowDeleting="gvdChief_RowDeleting"
                                    AllowPaging="True" BackColor="White" OnRowCommand="gvdChief_RowCommand" OnRowEditing="gvdChief_RowEditing"
                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="15" ShowHeaderWhenEmpty="True"
                                    OnPageIndexChanging="gvdChief_PageIndexChanging">
                                    <Columns>
                                       
                                        <asp:BoundField DataField="DouSmoke" HeaderText="DouSmoke "  />
                                        
                                        <asp:BoundField DataField="Depression" HeaderText="Depression "  />
                                         <asp:BoundField DataField="Feeding" HeaderText="Feeding "  />
                                       
                                        <asp:BoundField DataField="Bleeding" HeaderText="Bleeding "  />
                                         <asp:BoundField DataField="BrestExam" HeaderText="Brest Exam "  />
                                        <asp:BoundField DataField="BrestComplant" HeaderText="Brest Complant "  />
                                         <asp:BoundField DataField="CSection" HeaderText="CSection "  />
                                        <asp:BoundField DataField="Episiotomy" HeaderText="Episiotomy "  />
                                         <asp:BoundField DataField="BirthControl" HeaderText="Birth Control "  />
                                        
                                          
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
</asp:Content>

