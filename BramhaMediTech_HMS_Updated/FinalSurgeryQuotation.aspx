<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="FinalSurgeryQuotation.aspx.cs" Inherits="FinalSurgeryQuotation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
      <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <script type="text/javascript" >
        function numeric_only(e) {
            var keycode;
            if (window.event)
                keycode = window.event.keyCode;
            else if (event)
                keycode = event.keyCode;
            else if (e)
                keycode = e.which;
            else
                return true;
            if ((keycode == 45) || (keycode == 46) || (keycode >= 48 && keycode <= 57)) {
                return true;
            }
            else {
                return false;
            }
            return true;
        }
      </script>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
         <Triggers>
            <asp:PostBackTrigger ControlID="btnReport" />
             </Triggers>
        <ContentTemplate>
    <section class="content-header d-flex">
        <h1>Final Quotation </h1>
        <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Final Quotation</li>
                    </ol>
    </section>
    <section class="content">
        <div id="Div1" class="box" runat="server">
            <div class="box-header with-border">
                <span class="red pull-right">Fields marked with * are compulsory</span>
                <asp:Label ID="lblMsg" class="red pull-center" runat="server" Text="" Font-Bold="true" ForeColor="green"></asp:Label>
                
            </div>
          <%--   <div class="box-header with-border">
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
                                        <label for="lblMobileNo" title="" style="text-align: left">Mobile No:</label>
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
               
            </div>--%>
            <div class="box-body">
               
               
                    <div class="col-lg-12"  >
                        <div class="row">
                            <div class="col-lg-10" style="width:1000px">
                                 <div class="row">
                                 <div class="col-lg-3 text-left" >
                                        <div class="form-group">
                                           
                                            <label for="lblOperation" style="font:bolder,400,x-large">TYPE OF PROCEDURE</label>
                                            
                                        </div>
                                    </div>
                                      <div class="col-lg-5 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="lblOperation" Width="500px" Font-Bold="false" Font-Size="Larger" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                    </div>
                                <div class="row">
                                 <div class="col-lg-3 text-left" >
                                        <div class="form-group">
                                           
                                            <label for="lblPatientName">PATIENT NAME</label>
                                            
                                        </div>
                                    </div>
                                      <div class="col-lg-5 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="lblPatientName" Width="500px" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                    </div>

                                <div class="row">
                                 <div class="col-lg-3 text-left" >
                                        <div class="form-group">
                                           
                                            <label for="lblAddress">ADDRESS:</label>
                                            
                                        </div>
                                    </div>
                                <div class="col-lg-5 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="lblAddress" Width="500px" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                    </div>
                                <div class="row">
                                 <div class="col-lg-3 text-left" >
                                        <div class="form-group">
                                           
                                            <label for="lblMobileNo">MOBILE NO:</label>
                                            
                                        </div>
                                    </div>
                                <div class="col-lg-5 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="lblMobileNo" Width="500px" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                    </div>
                                  <div class="row">
                                 <div class="col-lg-3 text-left" >
                                        <div class="form-group">
                                           
                                            <label for="lblDate">DATE</label>
                                            
                                        </div>
                                    </div>
                                      <div class="col-lg-5 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="lblDate" Width="500px" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                    </div>
                                <div class="row">
                                    
                                    <div class="col-lg-3 text-left" >
                                        <div class="form-group">
                                           
                                            <label for="txtSurgeonName">CONSULTANT DOCTOR</label>
                                            
                                        </div>
                                    </div>
                                    <div class="col-lg-5 text-left" >
                                        <div class="form-group">
                                           
                                           
                                           

                                             <asp:TextBox ID="txtSurgeonName" runat="server" ReadOnly="true"  CssClass="form-control" Width="500px" placeholder="Enter Surgeon" AutoPostBack="True"></asp:TextBox>     
                                                        
                                            
                                        </div>
                                    </div>
                               </div>
                                 <div class="row">

                                    <div class="col-lg-3 text-left" >
                                        <div class="form-group">
                                            <label>INVESTIGATIONS </label>
                                            
                                        </div>
                                    </div>
                                  
                                     <div class="col-lg-5 text-left" >
                                        <div class="form-group">
                                           
                                           
                                            <asp:TextBox ID="txtInvestigations" runat="server" Width="500" AutoPostBack="true" AutoCompleteType="None"
                                                TabIndex="1" CssClass="form-control"  onkeyPress="return numeric_only(event);" OnTextChanged="txtInvestigations_TextChanged"  >
                                            </asp:TextBox>
                                            
                                            
                                        </div>
                                    </div>
                                    

                                </div>

                                <div class="row">
                                    <div class="col-lg-3 text-left">
                                        <div class="form-group">
                                            <label >Room/ICU/WARD Charges</label>
                                            
                                        </div>
                                    </div>
                                    <div class="col-lg-5 text-left">
                                        <div class="form-group">
                                           
                                            <asp:TextBox ID="txtWardCharges" runat="server"  onkeyPress="return numeric_only(event);" Width="500px" AutoPostBack="true"  CssClass="form-control" OnTextChanged="txtWardCharges_TextChanged">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                   </div>
                                 <div class="row">
                                    <div class="col-lg-3 text-left">
                                        <div class="form-group">
                                            <label >MEDICINE CHARGES/MISCELLANEOUS</label>
                                            
                                        </div>
                                    </div>
                                    <div class="col-lg-5 text-left">
                                        <div class="form-group">
                                           
                                            <asp:TextBox ID="txtMedicineCharges" runat="server"  onkeyPress="return numeric_only(event);" Width="500px" AutoPostBack="true"  CssClass="form-control" OnTextChanged="txtMedicineCharges_TextChanged">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                   </div>
                                <div class="row">
                                    <div class="col-lg-3 text-left">
                                        <div class="form-group">
                                            <label>SURGEON'S FEE</label>
                                            
                                        </div>
                                    </div>
                                    <div class="col-lg-5 text-left">
                                        <div class="form-group">
                                           
                                            <asp:TextBox ID="txtSurgeonFee" runat="server" Width="500px"  onkeyPress="return numeric_only(event);" AutoPostBack="true"  CssClass="form-control" OnTextChanged="txtSurgeonFee_TextChanged">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                   </div>
                                <div class="row">
                                    <div class="col-lg-3 text-left">
                                        <div class="form-group">
                                            <label> THEATRE FEE</label>
                                            
                                        </div>
                                    </div>
                                    <div class="col-lg-5 text-left">
                                        <div class="form-group">
                                           
                                            <asp:TextBox ID="txttheatreFee" runat="server"  onkeyPress="return numeric_only(event);" Width="500px" AutoPostBack="true"  CssClass="form-control" OnTextChanged="txttheatreFee_TextChanged">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                   </div>
                                <div class="row">
                                    <div class="col-lg-3 text-left">
                                        <div class="form-group">
                                            <label> ANAESTHETIST FEE</label>
                                            
                                        </div>
                                    </div>
                                    <div class="col-lg-5 text-left">
                                        <div class="form-group">
                                           
                                            <asp:TextBox ID="txtAnaestFee"  onkeyPress="return numeric_only(event);" runat="server" Width="500px" AutoPostBack="true"  CssClass="form-control" OnTextChanged="txtAnaestFee_TextChanged">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                   </div>
                                 <div class="row">
                                    <div class="col-lg-3 text-left">
                                        <div class="form-group">
                                            <label> TOTAL CHARGES </label>
                                            
                                        </div>
                                    </div>
                                    <div class="col-lg-5 text-left">
                                        <div class="form-group">
                                           
                                            <asp:TextBox ID="txtTotalCharges" runat="server" Width="500px"  CssClass="form-control" Enabled="False"></asp:TextBox>
                                        </div>
                                    </div>
                                   </div>

                                 <div class="row">
                                    <div class="col-lg-8">
                                         <div class="form-group"> 
                                        <asp:Button ID="btnAdd" runat="server" TabIndex="6" Text="Save" OnClick="btnAdd_Click"
                                            Width="80px" class="btn btn-primary btnSearch" CausesValidation="False" />
                                        <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click"
                                            CausesValidation="False" class="btn btn-primary btnSearch" Width="80px" />
                                            
                                        <asp:Button ID="btnReport" runat="server" Text="Report"   OnClientClick="target='_blank';"
                                            CausesValidation="False" class="btn btn-primary btnSearch" Width="80px" OnClick="btnReport_Click" />
                                             </div> </div>
                                    </div>
                                     </div>

                                  
                            </div>
                            
                            
                                </div>
                     
                    </div>
               
                
            </div>
        </div>

    </section>
            </ContentTemplate>
    </asp:UpdatePanel>
    <script language="javascript" type="text/javascript">
        function OpenReport() {

            window.open("Reports.aspx");
        }
               </script>
</asp:Content>

