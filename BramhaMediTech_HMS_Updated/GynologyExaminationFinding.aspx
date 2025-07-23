<%@ Page Title="" Language="C#" MasterPageFile="~/TemplateMaster.master" AutoEventWireup="true" CodeFile="GynologyExaminationFinding.aspx.cs" Inherits="GynologyExaminationFinding" %>
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
        <h1>Examination Finding </h1>
         <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Examination Finding</li>
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
                 
                 
                 <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                 <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-7 pl-0">
                                    <div class="form-group">
                           <asp:Button ID="btnAddTemplate"  Text="+ Template" runat="server"  class="btn btn-success"  />
                                        </div>
                             </div> 
                        <div class="col-lg-4 ">
                                    <div class="form-group">
                           <asp:Button ID="btnDelTemplate"  Text="Delete" class="btn btn-danger"  runat="server" />
                              </div>
                            </div>
                        </div>
                    </div> 
                            </div>

                         <div class="col-lg-3 text-left">
                 <div class="panel-heading">
                                   Pre Abdomen |                 
                                                 
                 
                     </div>
                             </div>
                         <div class="col-lg-3 text-left">
                 <div class="panel-heading">
                                   Inspection of Genitalia |                 
                                                 
                 
                     </div>
                             </div>
                        <div class="col-lg-2 text-left">
                 <div class="panel-heading">
                                   Surgical Advi.              
                                                 
                 
                     </div>
                             </div>
                        <div class="col-lg-2 text-left">
                 <div class="panel-heading">
                                   Date List |                 
                                                 
                 
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
                  <div class="col-lg-5">
                 <div class="col-lg-12 mt-2">
                    <div class="row">
                        
                         <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                       Mass
                                        
                                    </div>
                                </div>
                          
                         <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                       <asp:DropDownList ID="ddlmass"  CssClass="form-control form-select"  runat="server" >
                                           <asp:ListItem Value=""></asp:ListItem>
                                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                            <asp:ListItem Value="No">No</asp:ListItem>
                                           
                                        </asp:DropDownList>
                                        
                                    </div>
                                </div>
                          <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        </div>
                              </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <asp:CheckBox ID="chkWarts" runat="server" Font-Bold="true" Text="Warts" />
                                        </div>
                              </div>
                    </div>

                </div>
                    <div class="col-lg-12 mt-2">
                    <div class="row">
                        
                         <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                       Tenderness
                                        
                                    </div>
                                </div>
                          
                         <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                       <asp:DropDownList ID="ddlTenderness"  CssClass="form-control form-select"  runat="server" >
                                           <asp:ListItem Value=""></asp:ListItem>
                                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                            <asp:ListItem Value="No">No</asp:ListItem>
                                           
                                        </asp:DropDownList>
                                        
                                    </div>
                                </div>
                          <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        </div>
                              </div>
                        <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                        <asp:CheckBox ID="chkHerpetic" runat="server" Font-Bold="true" Text="Herpetic Lesions" />
                                        </div>
                              </div>
                    </div>

                </div>
                    <div class="col-lg-12 mt-2">
                    <div class="row">
                        
                         <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                       Size
                                        
                                    </div>
                                </div>
                          
                         <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                      <asp:TextBox ID="txtsize" CssClass="form-control"  runat="server" placeholder=" Size" ></asp:TextBox>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                        Weeks
                                        </div>
                            </div>
                          <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                        </div>
                              </div>
                        <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                        <asp:CheckBox ID="chkOthers" runat="server" Font-Bold="true" Text="Others" />
                                        </div>
                              </div>
                    </div>

                </div>
                 <div class="col-lg-12 mt-2">
                    
                 <div class="panel-heading mt-3">Per Speculum |-
                     </div>
                   
                     </div>

                 <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-4 text-left">
                                    <div class="form-group form-check pl-0 labelR">
                                       
                                        <asp:Label ID="TextBox1" Font-Bold="true"  runat="server" Text="Cervix Healthy" ></asp:Label>
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group form-check pl-0 labelR">
                                       
                                         <asp:DropDownList ID="ddlCervixH"  CssClass="form-control form-select"  runat="server" >
                                            <asp:ListItem Value=""></asp:ListItem>
                                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                              <asp:ListItem Value="No"> No</asp:ListItem>
                                          
                                        </asp:DropDownList>
                                    </div>
                                </div>

                         
                            <div class="col-lg-4 text-left">
                                    <div class="form-group form-check pl-0 labelR">
                                       
                                        <asp:Label ID="txtweeks"  Font-Bold="true" runat="server" Text="Polyp or Fibroid" ></asp:Label>
                                    </div>
                                </div>

                         <div class="col-lg-2 text-left">
                                    <div class="form-group form-check pl-0 labelR">
                                       
                                         <asp:DropDownList ID="ddlPolyp"  CssClass="form-control form-select"  runat="server" >
                                            <asp:ListItem Value=""></asp:ListItem>
                                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                              <asp:ListItem Value="No"> No</asp:ListItem>
                                          
                                        </asp:DropDownList>
                                    </div>
                                </div>
                         
                        

                         

                    </div>
                </div>
                 <div class="col-lg-12 mt-2">
                    <div class="row">
                         
                        <div class="col-lg-3 text-left">
                                    <div class="form-group form-check pl-0">
                                       
                                        <asp:Label ID="chkSuspected" Font-Bold="true" Text="Notes: " runat="server" />
                                    </div>
                                </div>
                         <div class="col-lg-9 text-left">
                                    <div class="form-group form-check pl-0">
                                        <asp:TextBox ID="txtnotes" placeholder="Enter Notes" CssClass="form-control"  TextMode="MultiLine" Height="100px" runat="server" />
                                      
                                    </div>
                                </div>
                        

                    </div>
                </div>

                  <div class="col-lg-12 mt-2">
                    
                 <div class="panel-heading mt-3">Per VaginalExamination |-
                     </div>
                   
                     </div>

                 <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-3 text-left">
                                    <div class="form-group form-check pl-0 labelR">
                                       
                                        <asp:Label ID="Label1" Font-Bold="true"  runat="server" Text="Uterus Size" ></asp:Label>
                                    </div>
                                </div>
                         <div class="col-lg-2 text-right">
                                    <div class="form-group form-check pl-0 labelR">
                                       
                                         <asp:DropDownList ID="ddlUterus"  CssClass="form-control form-select"  runat="server" >
                                            <asp:ListItem Value=""></asp:ListItem>
                                            <asp:ListItem Value="Normal">Normal</asp:ListItem>
                                              <asp:ListItem Value="Atrophic">Atrophic</asp:ListItem>
                                             <asp:ListItem Value="Enlarged">Enlarged</asp:ListItem>
                                          
                                        </asp:DropDownList>
                                    </div>
                                </div>

                         
                            <div class="col-lg-3 text-left">
                                    <div class="form-group form-check pl-0 labelR">
                                       
                                         <asp:TextBox ID="txtUterusWeeks" CssClass="form-control"  runat="server" placeholder=" Weeks" ></asp:TextBox>
                                    </div>
                                </div>

                         <div class="col-lg-2 text-left">
                                    <div class="form-group form-check pl-0 labelR">
                                       
                                         <asp:Label ID="Label2" Font-Bold="true"  runat="server" Text="Weeks" ></asp:Label>
                                    </div>
                                </div>
                         
                        

                         

                    </div>
                </div>

                   <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-3 text-left">
                                    <div class="form-group form-check pl-0 labelR">
                                       
                                        <asp:Label ID="Label3" Font-Bold="true"  runat="server" Text="Position" ></asp:Label>
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group form-check pl-0 labelR">
                                       
                                         <asp:DropDownList ID="ddlPosition"  CssClass="form-control form-select"  runat="server" >
                                            <asp:ListItem Value=""></asp:ListItem>
                                            <asp:ListItem Value="Retro-Verted">Retro-Verted</asp:ListItem>
                                              <asp:ListItem Value="Ante-Verted">Ante-Verted</asp:ListItem>
                                              <asp:ListItem Value="Enlarged">Enlarged</asp:ListItem>
                                          
                                        </asp:DropDownList>
                                    </div>
                                </div>

                         
                            <div class="col-lg-3 text-left">
                                    <div class="form-group form-check pl-0 labelR">
                                       
                                         <asp:CheckBox ID="chkTenderness" Text ="Tenderness" Font-Bold="true"  runat="server"></asp:CheckBox>
                                    </div>
                                </div>

                         <div class="col-lg-3 text-left">
                                    <div class="form-group form-check pl-0 labelR">
                                       
                                        <asp:CheckBox ID="chkMasses" Text ="Masses" Font-Bold="true"  runat="server"></asp:CheckBox>
                                    </div>
                                </div>
                         
                        

                         

                    </div>
                </div>
                  <div class="col-lg-12 mt-2">
                    
                 <div class="panel-heading mt-3">Medications |-
                     </div>
                   
                     </div>

                 <div class="col-lg-12 mt-2">
                    <div class="row">
                         
                        <div class="col-lg-3 text-left">
                                    <div class="form-group form-check pl-0">
                                       
                                        <asp:Label ID="Label7" Font-Bold="true" Text="Medications: " runat="server" />
                                    </div>
                                </div>
                         <div class="col-lg-8 text-left">
                                    <div class="form-group form-check pl-0">
                                        <asp:TextBox ID="txtMedications" placeholder="Enter Medications" CssClass="form-control"  TextMode="MultiLine" Height="100px" runat="server" />
                                      
                                    </div>
                                </div>
                        

                    </div>
                </div>
                
 
                 </div>
                  
        
                
                   <div class="col-lg-3  text-left">
                                             
                                             
                   <asp:CheckBoxList runat="server" ID="ChkSurgicalAdvice" cols="12" rows="28" style="width:100%;" >
                      
                       </asp:CheckBoxList>                       
                   </div> 
                     <div class="col-lg-2  text-left">
                                             
                                              <asp:TextBox runat="server" class="form-control" ID="TextBox2" ForeColor="Red" Font-Bold="true" TextMode="MultiLine"  cols="12" rows="28" style="width:100%;" > </asp:TextBox>
                                          </div> 
                
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
                                Examination Finding:
                            </div>
                            <div class="body">
                                <asp:GridView ID="gvdChief" runat="server" AutoGenerateColumns="false"
                                    class="table table-responsive table-sm table-bordered" Width="100%" DataKeyNames="Examid"
                                    HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3" OnRowDeleting="gvdChief_RowDeleting"
                                    AllowPaging="True" BackColor="White" OnRowCommand="gvdChief_RowCommand" OnRowEditing="gvdChief_RowEditing"
                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="15" ShowHeaderWhenEmpty="True"
                                    OnPageIndexChanging="gvdChief_PageIndexChanging">
                                    <Columns>
                                       
                                        <asp:BoundField DataField="Mass" HeaderText="Mass"  />
                                        
                                        <asp:BoundField DataField="Tenderness" HeaderText="Tenderness"  />
                                        <asp:BoundField DataField="Size" HeaderText="Size"  />
                                         <asp:BoundField DataField="CervixHealthy" HeaderText="CervixHealthy "  />
                                         <asp:BoundField DataField="UterusSize" HeaderText="UterusSize"  />
                                          <asp:BoundField DataField="UterusWeek" HeaderText="UterusWeek"  />
                                          
                                         <asp:BoundField DataField="CreatedBy" HeaderText=" Created By"  />
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
                <asp:Button ID="Button1" runat="server" Text="Add" OnClick="btnAddT_Click" class="btn btn-primary" />
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
