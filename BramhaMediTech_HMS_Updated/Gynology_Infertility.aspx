<%@ Page Title="" Language="C#" MasterPageFile="~/TemplateMaster.master" AutoEventWireup="true" CodeFile="Gynology_Infertility.aspx.cs" Inherits="Gynology_Infertility" %>
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
        <h1>Infertility  </h1>
         <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Infertility </li>
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
                  <div class="col-lg-5">
                        <div class="panel-heading">
                                  Patient Info |                 
                                                 
                 
                     </div>
                 <div class="col-lg-12 mt-2">
                    <div class="row">
                        
                         <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                       LMP
                                        
                                    </div>
                                </div>
                          
                         <div class="col-lg-4 text-left">
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
                        
                         <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                       Year Of Infert.
                                        
                                    </div>
                                </div>
                          
                         <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                       <asp:TextBox ID="txtYearofInfer" CssClass="form-control"  runat="server" placeholder=" Year ." ></asp:TextBox>
                                        
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        </div>
                             </div>
                        <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       <asp:DropDownList ID="ddlYearOfInfe"  CssClass="form-control form-select"  runat="server" >
                                           <asp:ListItem Value=""></asp:ListItem>
                                            <asp:ListItem Value="Primary">Primary</asp:ListItem>
                                            <asp:ListItem Value="Secondary">Secondary</asp:ListItem>
                                           
                                        </asp:DropDownList>
                                        </div>
                              </div>
                    </div>

                </div>
                    <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                        RPR
                                        </div>
                              </div>
                        <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       <asp:DropDownList ID="ddlRPR"  CssClass="form-control form-select"  runat="server" >
                                           <asp:ListItem Value=""></asp:ListItem>
                                            <asp:ListItem Value="Reactive">Reactive</asp:ListItem>
                                            <asp:ListItem Value="Non Reactive">Non Reactive</asp:ListItem>
                                           
                                        </asp:DropDownList>
                                        </div>
                              </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                       HIV
                                        
                                    </div>
                                </div>
                          
                         <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                     <asp:DropDownList ID="ddlHiv"  CssClass="form-control form-select"  runat="server" >
                                           <asp:ListItem Value=""></asp:ListItem>
                                            <asp:ListItem Value="Positive">Positive</asp:ListItem>
                                            <asp:ListItem Value="Negative">Negative</asp:ListItem>
                                         <asp:ListItem Value="Not Done">Not Done</asp:ListItem>
                                           
                                        </asp:DropDownList>
                                        
                                    </div>
                                </div>
                         
                       
                    </div>

                </div>

                      <div class="col-lg-12 mt-2">
                    <div class="row">
                          <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       Blood Grp.
                                        </div>
                            </div>
                         <div class="col-lg-3 text-left">
                                    <div class="form-group">
                         <asp:TextBox ID="txtbloodgrooping" placeholder="Blood Grouping" CssClass="form-control"    runat="server" />
                                       </div>
                             </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        Hep B
                                        </div>
                            </div>
                          
                        <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                         <asp:DropDownList ID="ddlHepB"  CssClass="form-control form-select"  runat="server" >
                                           <asp:ListItem Value=""></asp:ListItem>
                                            <asp:ListItem Value="Positive">Positive</asp:ListItem>
                                            <asp:ListItem Value="Negative">Negative</asp:ListItem>
                                         <asp:ListItem Value="Not Done">Not Done</asp:ListItem>
                                           
                                        </asp:DropDownList>
                                        </div>
                              </div>
                        </div>
                            </div>  


                      <div class="col-lg-12 mt-2">
                    <div class="row">
                        
                         <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                       AFC
                                        
                                    </div>
                                </div>
                          
                         <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                      <asp:TextBox ID="txtAfc" placeholder="AFC" CssClass="form-control"    runat="server" />
                                        
                                    </div>
                                </div>
                        
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        Hep C
                                        </div>
                            </div>
                          
                        <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                          <asp:TextBox ID="txthepc" placeholder="  Hep C" CssClass="form-control"    runat="server" />
                                        </div>
                              </div>
                    </div>

                </div>

                       <div class="col-lg-12 mt-2">
                    <div class="row">
                        
                         <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                       RBS
                                        
                                    </div>
                                </div>
                          
                         <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                      <asp:TextBox ID="txtRBS" placeholder="RBS" CssClass="form-control"    runat="server" />
                                        
                                    </div>
                                </div>
                       
                        <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                     
                                        </div>
                            </div>
                          
                        <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                         
                                        </div>
                              </div>
                    </div>

                </div>
                 
                    
                 <div class="panel-heading mt-3">Hormones |-
                     </div>
                   
                    

                 <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                                    <div class="form-group form-check pl-0 labelR">
                                       
                                        <asp:Label ID="TextBox1" Font-Bold="true"  runat="server" Text="FSH" ></asp:Label>
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group form-check pl-0 labelR">
                                       
                                          <asp:TextBox ID="txtFSH" CssClass="form-control"  runat="server" placeholder="FSH" ></asp:TextBox>
                                    </div>
                                </div>

                         
                            <div class="col-lg-2 text-left">
                                    <div class="form-group form-check pl-0 labelR">
                                       
                                       
                                          <asp:Label ID="Label2"  Font-Bold="true" runat="server" Text="E2" ></asp:Label>
                                    </div>
                                </div>

                         <div class="col-lg-2 text-left">
                                    <div class="form-group form-check pl-0 labelR">
                                       
                                      
                                         <asp:TextBox ID="txtE2" CssClass="form-control"  runat="server" placeholder="E2" ></asp:TextBox>
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group form-check pl-0 labelR">
                                       
                                       
                                          <asp:Label ID="Label3" Font-Bold="true"  runat="server" Text="T3" ></asp:Label>
                                    </div>
                                </div>

                         <div class="col-lg-2 text-left">
                                    <div class="form-group form-check pl-0 labelR">
                                       
                                       
                                         <asp:TextBox ID="txtT3" CssClass="form-control"  runat="server" placeholder="T3" ></asp:TextBox>
                                    </div>
                                </div>
                        

                         

                    </div>
                </div>

                        <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                                    <div class="form-group form-check pl-0 labelR">
                                        <asp:Label ID="Label4"  Font-Bold="true" runat="server" Text="LH" ></asp:Label>
                                       
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group form-check pl-0 labelR">
                                        <asp:TextBox ID="txtLH" CssClass="form-control"  runat="server" placeholder="LH" ></asp:TextBox>
                                          
                                    </div>
                                </div>

                         
                            <div class="col-lg-2 text-left">
                                    <div class="form-group form-check pl-0 labelR">
                                       
                                        
                                         <asp:Label ID="Label7"  Font-Bold="true" runat="server" Text="P4" ></asp:Label>
                                    </div>
                                </div>

                         <div class="col-lg-2 text-left">
                                    <div class="form-group form-check pl-0 labelR">
                                         <asp:TextBox ID="txtP4" CssClass="form-control"  runat="server" placeholder="P4" ></asp:TextBox>
                                      
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group form-check pl-0 labelR">
                                       
                                       
                                        <asp:Label ID="Label11"  Font-Bold="true" runat="server" Text="T4" ></asp:Label>
                                    </div>
                                </div>

                         <div class="col-lg-2 text-left">
                                    <div class="form-group form-check pl-0 labelR">
                                       
                                       <asp:TextBox ID="txtt4" CssClass="form-control"  runat="server" placeholder="T4" ></asp:TextBox>
                                    </div>
                                </div>
                        

                         

                    </div>
                </div>

                        <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                                    <div class="form-group form-check pl-0 labelR">
                                       
                                         <asp:Label ID="txtweeks"  Font-Bold="true" runat="server" Text="AMH" ></asp:Label>
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group form-check pl-0 labelR">
                                       
                                          <asp:TextBox ID="txtAMH" CssClass="form-control"  runat="server" placeholder="AMH" ></asp:TextBox>
                                    </div>
                                </div>

                         <div class="col-lg-2 text-left">
                                    <div class="form-group form-check pl-0 labelR">
                                       
                                        <asp:Label ID="Label6"  Font-Bold="true" runat="server" Text="TSH" ></asp:Label>
                                    </div>
                                </div>

                         <div class="col-lg-2 text-left">
                                    <div class="form-group form-check pl-0 labelR">
                                       
                                        <asp:TextBox ID="txtTSH" CssClass="form-control"  runat="server" placeholder="TSH" ></asp:TextBox>
                                    </div>
                                </div>
                            <div class="col-lg-2 text-left">
                                    <div class="form-group form-check pl-0 labelR">
                                       
                                        <asp:Label ID="Label5" Font-Bold="true"  runat="server" Text="Prolact" ></asp:Label>
                                    </div>
                                </div>

                         <div class="col-lg-2 text-left">
                                    <div class="form-group form-check pl-0 labelR">
                                       
                                    <asp:TextBox ID="txtProlact" CssClass="form-control"  runat="server" placeholder="Prolact" ></asp:TextBox>
                                    </div>
                                </div>
                         
                        

                         

                    </div>
                </div>

                       <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-8 text-left">
                                    <div class="form-group form-check pl-0 labelR">
                                       
                                       
                                    </div>
                                </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group form-check pl-0 labelR">
                                       
                                        <asp:Label ID="Label12" Font-Bold="true"  runat="server" Text="CMV" ></asp:Label>
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group form-check pl-0 labelR">
                                       
                                          <asp:DropDownList ID="ddlCMV"  CssClass="form-control form-select"  runat="server" >
                                           <asp:ListItem Value=""></asp:ListItem>
                                            <asp:ListItem Value="Positive">Positive</asp:ListItem>
                                            <asp:ListItem Value="Negative">Negative</asp:ListItem>
                                         <asp:ListItem Value="Not Done">Not Done</asp:ListItem>
                                           
                                        </asp:DropDownList>
                                    </div>
                                </div>

                         

                      
                         
                        

                         

                    </div>
                </div>

                         <div class="panel-heading mt-3">Hysteroscopy Findings |-
                     </div>
                 <div class="col-lg-12 mt-2">
                    <div class="row">
                         
                        
                         <div class="col-lg-12 text-left">
                                    <div class="form-group form-check pl-0">
                                        <asp:TextBox ID="txtHysteroscopyFinding" placeholder="Enter Hysteroscopy Findings" CssClass="form-control"  TextMode="MultiLine" Height="100px" runat="server" />
                                      
                                    </div>
                                </div>
                        

                    </div>
                </div>
                       <div class="panel-heading mt-3">Notes |-
                     </div>
                 <div class="col-lg-12 mt-2">
                    <div class="row">
                         
                        
                         <div class="col-lg-12 text-left">
                                    <div class="form-group form-check pl-0">
                                        <asp:TextBox ID="txtNotes" placeholder="Enter Note" CssClass="form-control"  TextMode="MultiLine" Height="100px" runat="server" />
                                      
                                    </div>
                                </div>
                        

                    </div>
                </div>
                  
                
 
                 </div>
                  
        
                
                   <div class="col-lg-5  text-left">
                                             
                            <div class="panel-heading">
                                  Partner's Info | 
                     </div>  
                        <div class="col-lg-12 mt-2">
                    <div class="row">
                        
                         <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                       Partner Name
                                        
                                    </div>
                                </div>
                          
                         <div class="col-lg-6 text-left">
                                    <div class="form-group">
                                       
                                    <asp:TextBox ID="txtpartnerName" placeholder="Partner Name" CssClass="form-control"   runat="server" />
                                      
                                        
                                    </div>
                                </div>
                         
                        <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       Age
                                        </div>
                            </div>
                          
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                         <asp:TextBox ID="txtage" placeholder="Age" CssClass="form-control"   runat="server" />
                                        </div>
                              </div>
                    </div>

                </div>  
                        <div class="row">
                      <div class="col-lg-6 mt-2  text-left">
                       <div class="col-lg-12 mt-2">
                    <div class="row">
                          
                        <div class="col-lg-6 text-right">
                                    <div class="form-group">
                                       
                                       HIV
                                        
                                    </div>
                                </div>
                          
                         <div class="col-lg-6 text-left">
                                    <div class="form-group">
                                       
                                     <asp:DropDownList ID="ddlPartnerHiv"  CssClass="form-control form-select"  runat="server" >
                                           <asp:ListItem Value=""></asp:ListItem>
                                            <asp:ListItem Value="Positive">Positive</asp:ListItem>
                                            <asp:ListItem Value="Negative">Negative</asp:ListItem>
                                         <asp:ListItem Value="Not Done">Not Done</asp:ListItem>
                                           
                                        </asp:DropDownList>
                                        
                                    </div>
                                </div>
                        </div>
                           </div>
                        <div class="col-lg-12 mt-2">
                    <div class="row">
                          
                        <div class="col-lg-6 text-right">
                                    <div class="form-group">
                                       
                                       Hep B
                                        
                                    </div>
                                </div>
                          
                         <div class="col-lg-6 text-left">
                                    <div class="form-group">
                                       
                                     <asp:DropDownList ID="ddlPartnerHepb"  CssClass="form-control form-select"  runat="server" >
                                           <asp:ListItem Value=""></asp:ListItem>
                                            <asp:ListItem Value="Positive">Positive</asp:ListItem>
                                            <asp:ListItem Value="Negative">Negative</asp:ListItem>
                                         <asp:ListItem Value="Not Done">Not Done</asp:ListItem>
                                           
                                        </asp:DropDownList>
                                        
                                    </div>
                                </div>
                        </div>
                           </div>
                        <div class="col-lg-12 mt-2">
                    <div class="row">
                          
                        <div class="col-lg-6 text-right">
                                    <div class="form-group">
                                       
                                       Hep C
                                        
                                    </div>
                                </div>
                          
                         <div class="col-lg-6 text-left">
                                    <div class="form-group">
                                       
                                     <asp:DropDownList ID="ddlPartnerHepc"  CssClass="form-control form-select"  runat="server" >
                                           <asp:ListItem Value=""></asp:ListItem>
                                            <asp:ListItem Value="Positive">Positive</asp:ListItem>
                                            <asp:ListItem Value="Negative">Negative</asp:ListItem>
                                         <asp:ListItem Value="Not Done">Not Done</asp:ListItem>
                                           
                                        </asp:DropDownList>
                                        
                                    </div>
                                </div>
                        </div>
                           </div>
                        <div class="col-lg-12 mt-2">
                    <div class="row">
                          
                        <div class="col-lg-6 text-right">
                                    <div class="form-group">
                                       
                                     RPR
                                        
                                    </div>
                                </div>
                          
                         <div class="col-lg-6 text-left">
                                    <div class="form-group">
                                       
                                     <asp:DropDownList ID="ddlRPRPar"  CssClass="form-control form-select"  runat="server" >
                                           <asp:ListItem Value=""></asp:ListItem>
                                            <asp:ListItem Value="Reactive">Reactive</asp:ListItem>
                                            <asp:ListItem Value="Non Reactive">Non Reactive</asp:ListItem>
                                           
                                        </asp:DropDownList>
                                        
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
                          <div class="col-lg-2 text-right">
                                    <div class="form-group">
                                       <asp:Label ID="lblspace" Height="18px"   runat="server" />
                                        </div>
                            </div>
                          <div class="col-lg-2 text-right">
                                    <div class="form-group">
                                      
                                        </div>
                            </div>
                          <div class="col-lg-2 text-right">
                                    <div class="form-group">
                                       
                                        </div>
                            </div>
                             </div>
                            </div>

                          <div class="col-lg-12 mt-2">
                    <div class="row">
                          
                        <div class="col-lg-2 text-right">
                                    <div class="form-group">
                                        
                                        </div>
                            </div>
                          <div class="col-lg-2 text-right">
                                    <div class="form-group">
                                       
                                        </div>
                            </div>
                          <div class="col-lg-2 text-right">
                                    <div class="form-group">
                                     
                                        </div>
                            </div>
                          <div class="col-lg-2 text-right">
                                    <div class="form-group">
                                      
                                        </div>
                            </div>
                             </div>
                            </div>
                          </div>
                     <div class="col-lg-6  mt-2 text-left">
                         <div class="form-group">
                                       <asp:TextBox ID="txtpatientInfoNote" placeholder="Enter Note" Height="160px" CssClass="form-control"  TextMode="MultiLine" runat="server" />

                                        </div>
                         </div>
                    </div>
                           <div class="panel-heading  mt-3">
                                  Semen Analysis:
                     </div>  
                       
                       
                       
                        <div class="col-lg-12 mt-2">
                    <div class="row">
                         
                        
                         <div class="col-lg-12 text-left">
                                    <div class="form-group form-check pl-0">
                                        <asp:TextBox ID="txtSemenAnalysis" placeholder="Enter Semen Analysis" CssClass="form-control"  TextMode="MultiLine" runat="server" />
                                      
                                    </div>
                                </div>
                        

                    </div>
                </div>  
                       
                       <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        Fibroids
                                        </div>
                            </div>
                   <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                     <asp:DropDownList ID="ddlFibroids"  CssClass="form-control form-select"  runat="server" >
                                           <asp:ListItem Value=""></asp:ListItem>
                                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                            <asp:ListItem Value="No">No</asp:ListItem>
                                        
                                           
                                        </asp:DropDownList>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                        Endometriosis
                                        </div>
                            </div>
                   <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                     <asp:DropDownList ID="ddlEndometriosis"  CssClass="form-control form-select"  runat="server" >
                                           <asp:ListItem Value=""></asp:ListItem>
                                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                            <asp:ListItem Value="No">No</asp:ListItem>
                                        
                                           
                                        </asp:DropDownList>
                                        
                                    </div>
                                </div>
                                  
                              </div>
                           </div> 
                       
                       <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        Cycts
                                        </div>
                            </div>
                   <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                     <asp:DropDownList ID="ddlCycts"  CssClass="form-control form-select"  runat="server" >
                                           <asp:ListItem Value=""></asp:ListItem>
                                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                            <asp:ListItem Value="No">No</asp:ListItem>
                                        
                                           
                                        </asp:DropDownList>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                        Hydrosalpinx
                                        </div>
                            </div>
                   <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                     <asp:DropDownList ID="ddlHydrosalpinx"  CssClass="form-control form-select"  runat="server" >
                                           <asp:ListItem Value=""></asp:ListItem>
                                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                            <asp:ListItem Value="No">No</asp:ListItem>
                                        
                                           
                                        </asp:DropDownList>
                                        
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
                          <div class="col-lg-2 text-right">
                                    <div class="form-group">
                                       <asp:Label ID="Label1" Height="1px"   runat="server" />
                                        </div>
                            </div>
                          <div class="col-lg-2 text-right">
                                    <div class="form-group">
                                      
                                        </div>
                            </div>
                          <div class="col-lg-2 text-right">
                                    <div class="form-group">
                                       
                                        </div>
                            </div>
                             </div>
                            </div>
                        <div class="panel-heading  mt-3">
                                  Ultra Sound Finding:
                     </div>  
                       
                       
                       
                        <div class="col-lg-12 mt-2">
                    <div class="row">
                         
                        
                         <div class="col-lg-12 text-left">
                                    <div class="form-group form-check pl-0">
                                        <asp:TextBox ID="txtUltraSoundFinding" placeholder="Enter Ultra Sound Finding" CssClass="form-control" Height="100px" TextMode="MultiLine" runat="server" />
                                      
                                    </div>
                                </div>
                        

                    </div>
                </div>   
                       <div class="panel-heading  mt-3">
                                  Laparoscopy Finding:
                     </div>  
                       
                       
                       
                        <div class="col-lg-12 mt-2">
                    <div class="row">
                         
                        
                         <div class="col-lg-12 text-left">
                                    <div class="form-group form-check pl-0">
                                        <asp:TextBox ID="txtLaparoscopyFinding" placeholder="Enter Laparoscopy Finding"  Height="100px" CssClass="form-control"  TextMode="MultiLine" runat="server" />
                                      
                                    </div>
                                </div>
                        

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
                               Infertility:
                            </div>
                            <div class="body">
                                <asp:GridView ID="gvdChief" runat="server" AutoGenerateColumns="false"
                                    class="table table-responsive table-sm table-bordered" Width="100%" DataKeyNames="InferId"
                                    HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3" OnRowDeleting="gvdChief_RowDeleting"
                                    AllowPaging="True" BackColor="White" OnRowCommand="gvdChief_RowCommand" OnRowEditing="gvdChief_RowEditing"
                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="15" ShowHeaderWhenEmpty="True"
                                    OnPageIndexChanging="gvdChief_PageIndexChanging">
                                    <Columns>
                                       
                                        <asp:BoundField DataField="LMPDate" HeaderText="LMPDate"  />
                                        
                                        <asp:BoundField DataField="RPR" HeaderText="PRP"  />
                                        <asp:BoundField DataField="YearOfInfert" HeaderText="Year Of Infert"  />
                                         <asp:BoundField DataField="YearOfInfert1" HeaderText="Year Of Infert Details "  />
                                         <asp:BoundField DataField="SemenAnalysisNote" HeaderText="Semen Analysis Note "  />
                                          <asp:BoundField DataField="UltrasoundFinding" HeaderText="Ultrasound  Findings"  />
                                          <asp:BoundField DataField="HysteroscopyFinding" HeaderText=" Hysteroscopy Finding"  />
                                        <asp:BoundField DataField="LaparoscopyFinding" HeaderText=" Laparoscopy Finding"  />
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
