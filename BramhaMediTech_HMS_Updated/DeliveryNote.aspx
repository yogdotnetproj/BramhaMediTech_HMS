<%@ Page Title="" Language="C#" MasterPageFile="~/mainMaster.master" AutoEventWireup="true" CodeFile="DeliveryNote.aspx.cs" Inherits="DeliveryNote" %>
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
     <section class="content-header d-flex">
        <h1>Delivery Note</h1>
         <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Delivery Note</li>
                    </ol>
    </section>
    <section class="content">
        <div id="Div1" class="box" runat="server">
            <div class="box-header with-border">
                <span class="red pull-right"></span>
                <asp:Label ID="lblMsg1" class="red pull-center" runat="server" Text="" Font-Bold="true" ForeColor="green"></asp:Label>
                <asp:HiddenField ID="txtTreatId" runat="server" />
            </div>
             <div class="box-header with-border">
                <div class="row">
                    
                            <div class="col-lg-12 text-left">
                                <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                        <label for="lblPatientName" style="text-align: left">Name:</label>
                                        <asp:Label ID="lblPatientName" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>

                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <label for="lblPrnNo" title="" style="text-align: left">PRN:</label>
                                        <asp:Label ID="txtpatientregid" runat="server" Text="1"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <label for="lblIpd"   title="" style="text-align: left">IPD No:</label>
                                        <asp:Label ID="lblIpd" runat="server" Text="0"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <label for="lblOpd" title="" style="text-align: left">OPD No:</label>
                                        <asp:Label ID="lblOpd" runat="server" Text="11"></asp:Label>
                                    </div>
                                </div>

                              
                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <label for="lblBranchId" title="" style="text-align: left">Mobile No:</label>
                                        <asp:Label ID="lblMobileNo" runat="server" Text="1"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>


                         <div class="row">
                            <div class="col-lg-12 text-left">
                                <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                        <label for="lbldName" title="" style="text-align: left">Dr Name:</label>
                                        <asp:Label ID="lbldrname" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>

                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <label for="lblPrnNo" title="" style="text-align: left">Age:</label>
                                        <asp:Label ID="lblAge" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label3" runat="server" Font-Bold="true" ForeColor="Red" Text=" Vitals Taken:"></asp:Label>
                                        <asp:Label ID="lblvtaken" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                         <label for="lblIpd"   title="  " style="text-align: left"></label>
                                        <label for="lblOpd" title="" style="text-align: left"></label>
                                        
                                    </div>
                                </div>

                               
                                <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                        <label for="lblBranchId" style="text-align: left"></label>
                                        <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>

                 
                  <div class="col-lg-12">
                    <div class="row">
                         <div class="col-lg-12 text-left">
                                    <div class="form-group">
                                         <asp:Label ID="LblMSg"  Font-Bold="true" runat="server" Text=""></asp:Label>
                                        </div>
                             </div>
                        </div>
                      </div>
               
                 <div class="col-lg-12">
                    <div class="row">
                         <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="lblLmp"  runat="server" Text="Delivery Conducted By:"></asp:Label>
                                    </div>
                                </div>
                          <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                        
                                       <asp:TextBox ID="txtDeliveryConduct"   runat="server" placeholder="Delivery Conducted By" ></asp:TextBox>
                                    </div>
                                </div>
                        <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                         <asp:Label ID="Label1"  runat="server" Text="Gravida:"></asp:Label>
                                    </div>
                                </div>
                         <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtGravida"   runat="server" placeholder="Gravida" ></asp:TextBox>
                                    </div>
                                </div>   
                    </div>

                </div>
                  <div class="col-lg-12">
                    <div class="row">
                         <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label2"  runat="server" Text="Husband Name:"></asp:Label>
                                    </div>
                                </div>
                          <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                        
                                       <asp:TextBox ID="txthusbandname"   runat="server" placeholder="Husband Name" ></asp:TextBox>
                                    </div>
                                </div>
                        <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                         <asp:Label ID="Label9"  runat="server" Text="Condition:"></asp:Label>
                                    </div>
                                </div>
                         <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtCondition"   runat="server" placeholder="Condition" ></asp:TextBox>
                                    </div>
                                </div>   
                    </div>

                </div>
                  <div class="col-lg-12">
                    <div class="row">
                         <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label10"  runat="server" Text="Delivery date:"></asp:Label>
                                    </div>
                                </div>
                          <div class="col-lg-3 text-left">
                                    <div class="form-group">  
                                         <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                <asp:TextBox ID="txtdeliverydate" runat="server" placeholder="Delivery Date" class="form-control pull-right"></asp:TextBox>
                                                <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                                            </div>
                                    </div>
                                </div>
                        <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                         <asp:Label ID="Label11"  runat="server" Text="Matuarity:"></asp:Label>
                                    </div>
                                </div>
                         <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtMatuarity"   runat="server" placeholder="Matuarity" ></asp:TextBox><asp:Label ID="Label12"  runat="server" Text="(In Weeks)"></asp:Label>
                                    </div>
                                </div>   
                    </div>

                </div>
                  <div class="col-lg-12">
                    <div class="row">
                         <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label13"  runat="server" Text="No Of Baby:"></asp:Label>
                                    </div>
                                </div>
                          <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                        
                                      <asp:RadioButtonList ID="rblNoOFbaby" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="1" Selected="True">One</asp:ListItem>
                                            <asp:ListItem  Value="2" >More than One</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                        <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                          <asp:CheckBox ID="ChkMaterinalDeath" Text="Maternial Death" runat="server" />
                                    </div>
                                </div>
                         <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtmaterinalDReason"   runat="server" placeholder="Maternial Death Reason" ></asp:TextBox>
                                        
                                    </div>
                                </div>   
                    </div>

                </div>

                  <div class="col-lg-12">
                    <div class="row">
                         <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label14"  runat="server" Text="Mode of Delivery:"></asp:Label>
                                    </div>
                                </div>
                          <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                        
                                        <asp:DropDownList ID="ddlModeofDelivery" runat="server">
                                            <asp:ListItem Value="1">Normal</asp:ListItem>
                                            <asp:ListItem Value="2">Cesarean</asp:ListItem>
                                            <asp:ListItem Value="3">ForceFully</asp:ListItem>
                                            <asp:ListItem Value="4">Other</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                        <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                          <asp:Label ID="Label15"  runat="server" Text="Gender of Baby:"></asp:Label>
                                    </div>
                                </div>
                         <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                         <asp:RadioButtonList ID="rblGenderBaby" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="1" Selected="True">Male</asp:ListItem>
                                            <asp:ListItem  Value="2" >Female</asp:ListItem>
                                        </asp:RadioButtonList>
                                        
                                    </div>
                                </div>   
                    </div>
                </div>

                       <div class="col-lg-12">
                    <div class="row">
                         <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label16"  runat="server" Text="Delivery Time"></asp:Label>
                                    </div>
                                </div>
                          <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                        
                                        <asp:TextBox ID="txtdeliveryTime"  runat="server" placeholder="Delivery Time"></asp:TextBox>
                                    </div>
                                </div>
                        <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                          <asp:Label ID="Label17"  runat="server" Text="Weight of Baby(grams):"></asp:Label>
                                    </div>
                                </div>
                         <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtweightofbaby"  runat="server" placeholder="Weight of Baby(grams)"></asp:TextBox>
                                        
                                    </div>
                                </div>   
                    </div>
                </div>
                 <div class="col-lg-12">
                    <div class="row">
                         <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label18"  runat="server" Text="Para"></asp:Label>
                                    </div>
                                </div>
                          <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                        
                                        <asp:TextBox ID="txtPAra"  runat="server" placeholder="Para"></asp:TextBox>
                                    </div>
                                </div>
                        <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                          <asp:Label ID="Label20"  runat="server" Text="Still Birth:"></asp:Label>
                                    </div>
                                </div>
                         <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtstillbirth"  runat="server" placeholder="Still Birth"></asp:TextBox>
                                        
                                    </div>
                                </div>   
                    </div>
                </div>
                 <div class="col-lg-12">
                    <div class="row">
                         <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label21"  runat="server" Text="Living"></asp:Label>
                                    </div>
                                </div>
                          <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                        
                                        <asp:TextBox ID="txtLiving"  runat="server" placeholder="Living"></asp:TextBox>
                                    </div>
                                </div>
                        <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                          <asp:Label ID="Label23"  runat="server" Text="Abortion:"></asp:Label>
                                    </div>
                                </div>
                         <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtAbortion"  runat="server" placeholder="Abortion"></asp:TextBox>
                                        
                                    </div>
                                </div>   
                    </div>
                </div>
                                 

                     <div class="col-lg-12">
                    <div class="row">
                         <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label5"  runat="server" Text="Comment:"></asp:Label>
                                    </div>
                                </div>
                          
                        <div class="col-lg-9 text-left">
                                    <div class="form-group">
                                       
                                          <asp:TextBox ID="txtComment" Width="770px" Height="50px"  runat="server" ></asp:TextBox>
                                    </div>
                                </div>
                        
                    </div>
                </div>
                


                
                 
                  <div class="col-lg-12">
                    <div class="row">
                         <div class="col-lg-12 text-center">
                                    <div class="form-group">
                                        <asp:Button ID="btnsave" runat="server" Text="Save" class="btn btn-primary btnSearch" OnClick="btnsave_Click" />
                                        <asp:Button ID="btnReset" runat="server" Text="Reset" class="btn btn-primary btnSearch" />
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
                                Delivery Note:
                            </div>
                            <div class="body">
                                <asp:GridView ID="gvdChief" runat="server" AutoGenerateColumns="false"
                                    class="table table-responsive table-sm table-bordered" Width="100%" DataKeyNames="DelvID"
                                    HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3" OnRowDeleting="gvdChief_RowDeleting"
                                    AllowPaging="True" BackColor="White" OnRowCommand="gvdChief_RowCommand" OnRowEditing="gvdChief_RowEditing"
                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="15" ShowHeaderWhenEmpty="True"
                                    OnPageIndexChanging="gvdChief_PageIndexChanging">
                                    <Columns>
                                       
                                        <asp:BoundField DataField="DeliveryConductBy" HeaderText="Conduct By"  />
                                        
                                        <asp:BoundField DataField="DeliveryDate" HeaderText="Delivery Date"  />
                                        <asp:BoundField DataField="DeliveryTime" HeaderText="Delivery Time"  />
                                         <asp:BoundField DataField="Matuarity" HeaderText="Matuarity "  />
                                         <asp:BoundField DataField="NumberOfBaby" HeaderText="No of Baby"  />
                                          <asp:BoundField DataField="ModeofDelivery" HeaderText="Delivery Mode"  />
                                          <asp:BoundField DataField="GenderofBaby" HeaderText="Gender"  />
                                          <asp:BoundField DataField="WeightOfBaby" HeaderText="Weight"  />
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

