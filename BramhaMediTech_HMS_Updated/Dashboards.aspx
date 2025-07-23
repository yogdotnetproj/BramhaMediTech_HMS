<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="Dashboards.aspx.cs" Inherits="Dashboards" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/ucPatientInfo.ascx" TagPrefix="uc1" TagName="ucPatientInfo" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
     <section class="content-header d-flex">
                    <h1>Dashboard</h1>
                    <ol class="breadcrumb">
                       <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="breadcrumb-item active">Dashboard</li>
                    </ol>

                
                </section>
      
                 <div class="box" runat="server" id="Show">
                     <div class="box-body">
                                    <div class="row">    

                                         <div class="col-lg-12 mt-3">
                            <div class="row"> 
                                    <div class="col-sm-2">
                                                             <div class="form-group">
                                                                 
                                                             <label for="txtFrom">From Date:</label> 
                                                             </div>
                                                         </div>                             
                                    
                                                         
                                                        
                                                          <div class="col-sm-2">
                                                     <div class="form-group">
                                                         <div class="input-group date" data-date-format="dd/mm/yyyy"  runat="server" id="Div1" data-provide="datepicker" >
                                                           <asp:TextBox id="txtFrom" class="form-control" type="text" runat="server" autopostback="true" placeholder="Enter From Date" /> 
                                                                <span class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </span>
                                                         </div>
                                                      </div>
                                                    </div> 

                                                   
                                     <div class="col-sm-1">
                                                             <div class="form-group">
                                                               <label for="txtTo">To Date:</label>
                                                             </div>
                                                         </div>
                                     <div class="col-sm-2">
                                                     <div class="form-group">
                                                         
                                                         
                                                         <div class="input-group date" data-date-format="dd/mm/yyyy"  runat="server" id="datepicker1" data-provide="datepicker" >
                                                           <asp:TextBox id="txtTo" class="form-control" type="text" runat="server" autopostback="true" placeholder="Enter To Date" /> 
                                                               <span class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </span>
                                                         </div>
                                                     

                                                     </div>
                                                 </div>
                                  <div class="col-sm-2">
                                                     <div class="form-group">
                                                         <asp:RadioButtonList ID="Rbltype" runat="server" RepeatDirection="Horizontal"  >
                                                             <asp:ListItem Value="0" Selected="True">Today</asp:ListItem>
                                                             <asp:ListItem Value="1">Yesterday</asp:ListItem>
                                                         </asp:RadioButtonList>
                                                         </div>
                                      </div>
                                  <div class="col-sm-1">
                                                     <div class="form-group">
                                                          <asp:Button ID="btnshow" runat="server"   Text="Show" 
                                                 class="btn btn-danger"  CausesValidation="False" OnClick="btnshow_Click"  />
                                                         </div>
                                      </div>
                                </div>
                                             </div>
                                         <div class="col-lg-12 mt-3">
                            <div class="row"> 
                                          <div class="col-sm-3" >
                                            <div class="form-group">
                                                
                                                 <asp:Button ID="btnopdIncome" runat="server"   Text="Consultation + OPD" 
                                                 Width="270px" class="btn btn-primary"  CausesValidation="False"  />
                                                </div>
                                              </div>  
                                 <div class="col-sm-3" >
                                            <div class="form-group">
                                                
                                                 <asp:Button ID="btnEmerency" runat="server"   Text="Emergency" 
                                                 Width="270px" class="btn btn-primary"  CausesValidation="False"  />
                                                </div>
                                              </div>  
                                 <div class="col-sm-3" >
                                            <div class="form-group">
                                                
                                                 <asp:Button ID="btnEEG" runat="server"   Text="EEG" 
                                                Width="270px"  class="btn btn-primary"  CausesValidation="False"  />
                                                </div>
                                              </div>  
                                 <div class="col-sm-3" >
                                            <div class="form-group">
                                                
                                                 <asp:Button ID="btnAmbulance" runat="server"   Text="Ambulance" 
                                                 Width="270px"  class="btn btn-primary"  CausesValidation="False"  />
                                                </div>
                                              </div>   

                                        </div>
                         </div>

                                         <div class="col-lg-12 mt-3">
                            <div class="row"> 
                                          <div class="col-sm-3" >
                                            <div class="form-group">
                                                
                                                 <asp:Button ID="btnOphthal" runat="server"   Text="OPTHAL" 
                                                 Width="270px" class="btn btn-success"  CausesValidation="False"  />
                                                </div>
                                              </div>  
                                 <div class="col-sm-3" >
                                            <div class="form-group">
                                                
                                                 <asp:Button ID="btnIpdIncome" runat="server"   Text="IPD Income" 
                                                 Width="270px" class="btn btn-success"  CausesValidation="False"  />
                                                </div>
                                              </div>  
                                 <div class="col-sm-3" >
                                            <div class="form-group">
                                                 <asp:Button ID="btnDeposit" runat="server"   Text="Deposit " 
                                                 Width="270px"  class="btn btn-success"  CausesValidation="False"  />
                                                
                                                </div>
                                              </div>  
                                 <div class="col-sm-3" >
                                            <div class="form-group">
                                                 <asp:Button ID="btnRefund" runat="server"   Text="Refund Amt" 
                                                Width="270px"  class="btn btn-success"  CausesValidation="False"  />
                                                
                                                </div>
                                              </div>   

                                        </div>
                         </div>

                                         <div class="col-lg-12 mt-3">
                            <div class="row"> 
                                          <div class="col-sm-3" >
                                            <div class="form-group">
                                                
                                                 <asp:Button ID="BtnMedicalLab" runat="server"   Text="Medical Lab" 
                                                 Width="270px" class="btn btn-warning"  CausesValidation="False"  />
                                                </div>
                                              </div>  
                                 <div class="col-sm-3" >
                                            <div class="form-group">
                                                
                                                 <asp:Button ID="btnRadiology" runat="server"   Text="Radiology" 
                                                 Width="270px" class="btn btn-warning"  CausesValidation="False"  />
                                                </div>
                                              </div>  
                                 <div class="col-sm-3" >
                                            <div class="form-group">
                                                 <asp:Button ID="btnPathology" runat="server"   Text="Pathology " 
                                                 Width="270px"  class="btn btn-warning"  CausesValidation="False"  />
                                                
                                                </div>
                                              </div>  
                                 <div class="col-sm-3" >
                                            <div class="form-group">
                                                 <asp:Button ID="btnPharmacy" runat="server"   Text="Pharmacy" 
                                                Width="270px"  class="btn btn-warning"  CausesValidation="False"  />
                                                
                                                </div>
                                              </div>   

                                        </div>
                         </div>
                     </div>
                         </div>
                     </div>
</asp:Content>

