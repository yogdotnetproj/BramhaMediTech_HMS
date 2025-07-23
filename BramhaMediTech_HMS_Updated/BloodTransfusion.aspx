<%@ Page Title="" Language="C#" MasterPageFile="~/mainMaster.master" AutoEventWireup="true" CodeFile="BloodTransfusion.aspx.cs" Inherits="BloodTransfusion" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="cc1" %>

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
        <h1>Blood Transfusion</h1>
         <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Blood Transfusion</li>
                    </ol>
    </section>
    <section class="content">
        <div id="Div1" class="box" runat="server">
            <div class="box-header with-border">
                <span class="red pull-right"></span>
                <asp:Label ID="lblMsg1" class="red pull-center" runat="server" Text="" Font-Bold="true" ForeColor="green"></asp:Label>
                <asp:HiddenField ID="txtTreatId" runat="server" />
               
            </div>
             <div class="box-body">
                    <div class="row">
                    
                    <div class="col-sm-12 text-left">
                    <div class="col-sm-4 text-left">
                    <div class="form-group">
                    <label for="lblPatientName" style="text-align: left">Name:</label>
                    <asp:Label ID="lblPatientName" runat="server" Text=""></asp:Label>
                    </div>
                    </div>

                    <div class="col-sm-2 text-left">
                    <div class="form-group">
                    <label for="lblPrnNo" title="" style="text-align: left">PRN:</label>
                    <asp:Label ID="txtpatientregid" runat="server" Text="1"></asp:Label>
                    </div>
                    </div>
                    <div class="col-sm-2 text-left">
                    <div class="form-group">
                    <label for="lblIpd"   title="" style="text-align: left">IPD No:</label>
                    <asp:Label ID="lblIpd" runat="server" Text="0"></asp:Label>
                    </div>
                    </div>
                    <div class="col-sm-2 text-left">
                    <div class="form-group">
                    <label for="lblOpd" title="" style="text-align: left">OPD No:</label>
                    <asp:Label ID="lblOpd" runat="server" Text="11"></asp:Label>
                    </div>
                    </div>

                              
                    <div class="col-sm-2 text-left">
                    <div class="form-group">
                    <label for="lblBranchId" title="" style="text-align: left">Mobile No:</label>
                    <asp:Label ID="lblMobileNo" runat="server" Text="1"></asp:Label>
                    </div>
                    </div>
                    </div>
                    </div>


                <div class="row">
                <div class="col-sm-12 text-left">
                <div class="col-sm-4 text-left">
                <div class="form-group">
                <label for="lbldName" title="" style="text-align: left">Dr Name:</label>
                <asp:Label ID="lbldrname" runat="server" Text=""></asp:Label>
                </div>
                </div>

                <div class="col-sm-2 text-left">
                <div class="form-group">
                <label for="lblPrnNo" title="" style="text-align: left">Age:</label>
                <asp:Label ID="lblAge" runat="server" Text=""></asp:Label>
                </div>
                </div>
                <div class="col-sm-3 text-left">
                <div class="form-group">
                                       
                <asp:Label ID="Label3" runat="server" Font-Bold="true" ForeColor="Red" Text=" Vitals Taken:"></asp:Label>
                <asp:Label ID="lblvtaken" runat="server" Text=""></asp:Label>
                </div>
                </div>
                <div class="col-sm-2 text-left">
                        <div class="form-group">
                        <label for="lblIpd"   title="  " style="text-align: left"></label>
                        <label for="lblOpd" title="" style="text-align: left"></label>
                                        
                        </div>
                </div>

                               
                <div class="col-sm-1 text-left">
                <div class="form-group">
                <label for="lblBranchId" style="text-align: left"></label>
                <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
                </div>
                </div>
                </div>
                </div>

                 
        <div class="col-sm-12">
            <div class="row">
                <div class="col-sm-12 text-left">
                    <div class="form-group">
                        <asp:Label ID="LblMSg"  Font-Bold="true" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>
        </div>
               
            <div class="col-sm-12">
                             <div class="row"> 
                                   <div class="col-sm-2 text-left" >
                                                    <div class="form-group">  
                                                                                       
                                                             
                                                     <%--  <input type="text" value="9/23/2009" style="width: 100px;" readonly="readonly" name="Date" id="Date" class="hasDatepicker"/>--%>
                  <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">                                                            
                                                          <asp:TextBox ID="txttimestart" runat="server" class="form-control"  placeholder="Enter Time Start"    
                                                             Width="140px" AutoPostBack="True"></asp:TextBox>
                                                             
                                                                <span class="input-group-addon">
                                                                    <span class="glyphicon glyphicon-calendar"></span>
                                                                </span>                                                     
                        
                                                        </div>
                                                     
                                                    </div>
                                                </div>
                                   <div class="col-sm-2 text-left" style="width:200px" >
                                                    <div class="form-group">  
                                                                                
                                                        <asp:TextBox ID="txtTime" runat="server"  class="form-control" 
                                                       Font-Bold="True"   Width="100px" Font-Size="Large"></asp:TextBox>  
                                                        </div>
                                       
                                                        </div>
                                       
                                <%-- <cc1:TimeSelector ID="txtTime"    Width="190px"  Font-Size="Large"   Font-Bold="true" runat="server" DisplaySeconds="false">
                   </cc1:TimeSelector>--%>

                                 </div>
                </div> 
            <div class="col-sm-12">
            <div class="row">
            <div class="col-sm-6" style="width:600px">                                            
            <div class="panel panel-info" style="width:580px">
            <div class="panel-heading" style="font-size:medium;font-weight:bold"">Transfusion Product List</div>
            <div class="panel-body"  style="background-color:aliceblue;">
                            
            <div class="col-sm-6" style="width:580px">
            <div class="form-group">
            <div class="row">
                    
                            
                                <div class="col-sm-1" style="width:120px">
                             <label for="ddlbloodGroup"><b>Blood Group :</b></label>
                                    </div>
                                <div class="col-sm-2" style="width:150px">
                            <asp:DropDownList ID="ddlbloodGroup" Width="140px" runat="server" class="form-control" >
                               <%-- <asp:ListItem Value="0">SelectType</asp:ListItem>--%>                                
                                <asp:ListItem>Select</asp:ListItem>
                                <asp:ListItem>O+</asp:ListItem>
                            </asp:DropDownList>
                                </div>
                           
                       
                   
                            
                            <div class="col-sm-1" style="width:90px">
                             <label for="txtIndication"><b>Indication</b></label>
                                </div>
                            <div class="col-sm-2" style="width:150px">
                    <asp:TextBox ID="txtIndication" runat="server" CssClass="form-control" Width="140px"  ></asp:TextBox>
                                </div>
                           
            </div>
            </div>
                                                          
            </div>
                                  
            <div class="col-sm-6" style="width:580px">
            <div class="form-group">
            <div class="row">
                    
                            <div class="col-sm-1"style="width:120px">
                             <label for="Chkbox" ><b>Whole Blood</b></label>
                                </div>
                                <div class="col-sm-1" style="width:50px">
                                    <asp:CheckBox ID="ChkWholeBlood" runat="server" />
                                    </div>
                           
                        
                
                            <div class="col-sm-1"style="width:120px">
                                <label for="chkPackedCells"><b>Packed Cells</b></label>
                                </div>
                            
                 <div class="col-sm-1" style="width:50px">
                                    <asp:CheckBox ID="chkPackedCells" runat="server" />
                                    </div>

                <div class="col-sm-1" style="width:100px">
                                <label for="Chkffp"><b>FFP</b></label>
                                </div>
                            
                 <div class="col-sm-1" style="width:50px">
                                    <asp:CheckBox ID="Chkffp" runat="server" />
                                    </div>

                </div>
                   
            </div>
            </div>

           
                                                                
                

                 <div class="col-sm-6" style="width:580px">
            <div class="form-group">
            <div class="row">
                    
                            <div class="col-sm-1"style="width:120px">
                             <label for="ChkPlatelets" ><b>Platelets</b></label>
                                </div>
                                <div class="col-sm-1" style="width:50px">
                                    <asp:CheckBox ID="ChkPlatelets" runat="server" />
                                    </div>
                <div class="col-sm-1" style="width:120px">
                             <label for="Chkcryo" ><b>Cryoprecipitate</b></label>
                                </div>
                                <div class="col-sm-1" style="width:90px">
                                    <asp:CheckBox ID="Chkcryo" runat="server" />
                                    </div>
                           
                        </div>
                   
            </div>
            </div>

            
                 

            
                                                
                                           
                                                
            </div>
            </div>
                                           
            </div> 
            <div class="col-sm-6" style="width:600px;height:140px">
                                        
            <div class="panel panel-info" style="width:580px" >
            <div class="panel-heading" style="font-size:medium;font-weight:bold">CheckList
                                                     
            </div>
            <div class="panel-body"  style="background-color:aliceblue">
                <div class="col-sm-6 form-group" style="width:580px;height:110px">
                    <div class="form-group">
            <div class="row" style="height:40px" >
                    

           
                            <div class="col-sm-1"style="width:170px">
                            <label for="rdbConsent"><b>Consent Taken :</b></label>

                            </div>  
                            <div class="col-sm-1" style="width:110px">
                                <asp:RadioButtonList ID="rdbConsent" runat="server" Width="90px" RepeatDirection="Horizontal">
                                    <asp:ListItem Selected="True">Yes</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:RadioButtonList>
                         
                        </div>
                            <div class="col-sm-1"style="width:170px">
                            <label for="rdbDocOrder"><b>Doctor's Order :</b></label>

                            </div>  
                            <div class="col-sm-1" style="width:110px">
                                <asp:RadioButtonList ID="rdbDocOrder" runat="server" Width="90px"  RepeatDirection="Horizontal">
                                     <asp:ListItem Selected="True">Yes</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:RadioButtonList>
                         
                           </div>
             

                                                          
            </div>      
            <div class="row" style="height:40px">
                    

           
                            <div class="col-sm-1"style="width:170px">
                            <label for="rdbPreMedication"><b>PreMedication Order</b></label>

                            </div>  
                            <div class="col-sm-1" style="width:110px">
                                <asp:RadioButtonList ID="rdbPreMedication" runat="server" Width="90px" RepeatDirection="Horizontal"> <asp:ListItem Selected="True">Yes</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:RadioButtonList>
                        </div>
                            <div class="col-sm-1"style="width:170px">
                            <label for="rdbPreTrans"><b>Previous Transfusion</b></label>

                            </div>  
                            <div class="col-sm-1" style="width:110px">
                                <asp:RadioButtonList ID="rdbPreTrans" runat="server" Width="90px" RepeatDirection="Horizontal">
                                    <asp:ListItem >Yes</asp:ListItem>
                                    <asp:ListItem Selected="True">No</asp:ListItem>
                                </asp:RadioButtonList>
                         
                        </div>
                </div>
                                                   
            <div class="row" style="height:40px">
                    

            
                            <div class="col-sm-1"style="width:200px">
                            <label for="rdbReaction"><b>Prev Transfusion Reaction </b></label>

                            </div>  
                            <div class="col-sm-1" style="width:110px">
                                <asp:RadioButtonList ID="rdbReaction" runat="server" Width="90px" RepeatDirection="Horizontal">
                                    <asp:ListItem>Yes</asp:ListItem>
                                    <asp:ListItem Selected="True">No</asp:ListItem>
                                </asp:RadioButtonList>
                         
                        </div>
               

                                                          
            </div>
                                                
            </div>
          
                                       
            </div>
            </div>
                </div>

            </div>
                         
            </div>
            
          
            </div>
                 <div class="col-sm-12">
                                    <div class="row">

                                         <div class="col-sm-1 text-center"  style="width:105px">
                                    <div class="form-group">
                                        
                                        <label CssClass="control-label">
                                                    Unit No
                                                  </label>
                                         <asp:TextBox ID="txtUnit" runat="server" CssClass="form-control"  Width="100px" ></asp:TextBox> 
                                    </div>
                                </div>
                                 <div class="col-sm-1 text-center"  style="width:205px">
                                    <div class="form-group"> 
                                        <label CssClass="control-label">
                                                     Checked By
                                                  </label> 
                                        
                                        <asp:DropDownList ID="ddlCheckedBy" runat="server" CssClass="form-control" Width="200px"></asp:DropDownList>                 
                                          
                                    </div>
                                </div> 
                                 <div class="col-sm-1 text-center"  style="width:205px">
                                    <div class="form-group">  
                                        <label CssClass="control-label">
                                                     Checked & StartedBy
                                                  </label> 
                                         <%--<asp:Label ID="lblBatchNo" runat="server" Text="BatchNo"></asp:Label>--%>
                                        <asp:DropDownList ID="ddlStartedBy" runat="server" CssClass="form-control"  Width="200px" ></asp:DropDownList>
                                      
                                          
                                    </div>
                                </div>
                                 <div class="col-sm-1 text-left"  style="width:105px" >
                                                    <div class="form-group">  
                                                          <label CssClass="control-label">
                                                    Start Time
                                                  </label>                       
                                                        <asp:TextBox ID="txtStrtTime" runat="server"  class="form-control" 
                                                       Font-Bold="True"  Width="100px" Font-Size="Large"></asp:TextBox>  
                                                        </div>
                                       </div>   
                                 <div class="col-sm-1 text-Center"  style="width:85px">
                                    <div class="form-group">
                                        <label CssClass="control-label">
                                                     Rate
                                                  </label> 
                                      
                                         <asp:TextBox ID="txtRate" CssClass="form-control"  Width="80px" runat="server" ></asp:TextBox>        
                                        
                                          
                                    </div>
                                </div>

                                        <div class="col-sm-1 text-left"  style="width:85px" >
                                                    <div class="form-group">  
                                                          <label CssClass="control-label">
                                                    Time
                                                  </label>                       
                                                        <asp:TextBox ID="txttime1" runat="server"  class="form-control" 
                                                       Font-Bold="True"  Width="80px" Font-Size="Large"></asp:TextBox>  
                                                        

                                          <%--  <div class='input-group date' style="width: 200px">
        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" />
        <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
</div>--%>
                                       </div>  
                                            </div> 
                                 <div class="col-sm-1 text-left"  style="width:85px">
                                    <div class="form-group">
                                        
                                        <label CssClass="control-label">
                                                   T
                                                  </label>
                                         <asp:TextBox ID="txtT" runat="server" CssClass="form-control" Width="80px" ></asp:TextBox> 
                                    </div>
                                </div>  
                                         <div class="col-sm-1 text-center"  style="width:85px">
                                              <div class="form-group">
                                                  <label CssClass="control-label">
                                                  p
                                                  </label>    
                                                  
                                               <asp:TextBox ID="txtP" Width="80px"  CssClass ="form-control" runat="server"></asp:TextBox>   
                                               </div>
                                            </div>                               

                                    <div class="col-sm-1 text-center"  style="width:85px">
                                              <div class="form-group">
                                                  <label CssClass="control-label">
                                                     R
                                                  </label>    
                                                  
                                               <asp:TextBox ID="txtR" Width="80px"   CssClass ="form-control" runat="server" ></asp:TextBox>  
                                               </div>
                                            </div>
                                        <div class="col-sm-1 text-center"  style="width:85px">
                                              <div class="form-group">
                                                  <label CssClass="control-label">
                                                    BP
                                                  </label>    
                                                  
                                               <asp:TextBox ID="txtBP" Width="80px"  CssClass ="form-control" runat="server" ></asp:TextBox>    
                                               </div>
                                            </div>
                                  
                                   
                                        </div>
                                       </div>
<div class="col-sm-12">
 <div class="row">
      <div class="col-sm-2 text-center"  style="width:205px">
                                              <div class="form-group">
                                                  <label CssClass="control-label" >
                                                    Transfusion Reaction
                                                  </label> 
                                                   
                                                  <asp:TextBox ID="txtTransfusionReaction" CssClass ="form-control" Width="200px" runat="server"  ></asp:TextBox> 
                                                  </div>
                                                </div>           
                                     <div class="col-sm-1"  style="width:150px">
                                              <div class="form-group">
                                                  <label CssClass="control-label">
                                                     Finish-Time
                                                  </label>    
                                                  
                                               <asp:TextBox ID="txtFTime" Width="95px"  CssClass ="form-control" runat="server"  TabIndex="6"></asp:TextBox> 
                                                 </div>
                                            </div>
       <div class="col-sm-3"  style="width:350px">
                                              <div class="form-group">                               
<asp:Button ID="btnsave" runat="server" Text="Save" class="btn btn-primary btnSearch" OnClick="btnsave_Click" />
<asp:Button ID="btnReset" runat="server" Text="Reset" class="btn btn-primary btnSearch" OnClick="btnReset_Click" />
      <asp:Button ID="btnReport" runat="server" Text="Report" class="btn btn-primary btnSearch" OnClick="btnReport_Click"  /> 
                                                  </div>
           </div>
                                                                                       
                  
                                       
</div>
</div>

<div class="col-sm-12">
<div class="row">
<div runat="server" id="UploadedFiles" style="height:150px; width:1200px; overflow:scroll"    >   
<div class="table-responsive" style="width: 100%">

<asp:GridView ID="gvBloodTrans" runat="server" AutoGenerateColumns="False" AutoPostBack="false"
class="table table-responsive table-sm table-bordered" Width="100%" DataKeyNames="BloodTransId"
HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3" OnRowDeleting="gvBloodTrans_RowDeleting"
AllowPaging="True" BackColor="White" OnRowEditing="gvBloodTrans_RowEditing"
BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="100" ShowHeaderWhenEmpty="True" OnPageIndexChanging="gvBloodTrans_PageIndexChanging" >
<Columns>

<asp:ButtonField CommandName="Edit" Text="Edit" ButtonType="Image" ImageUrl="~/Images0/edit.gif" />
<asp:BoundField DataField="DateInput" HeaderText="Date" />
    <asp:BoundField DataField="TimeInput" HeaderText="Time" />
<asp:BoundField DataField="UnitNo" HeaderText="UnitNo" />
<asp:BoundField DataField="CheckedBy"  HeaderText="CheckedBy" />
<asp:BoundField DataField="StartedBy" HeaderText="StartedBy" ItemStyle-Width="150" />
<asp:BoundField DataField="StartTime" HeaderText="StartTime" ItemStyle-Width="50" />
<asp:BoundField DataField="Rate" HeaderText="Rate" />
<asp:BoundField DataField="TimeS" HeaderText="Time" />
<asp:BoundField DataField="T" HeaderText="T" />
<asp:BoundField DataField="P" HeaderText="P" />
<asp:BoundField DataField="R" HeaderText="R" />
<asp:BoundField DataField="BP" HeaderText="BP" />
<asp:BoundField DataField="TRDetails"  HeaderText="ReactionDetails" />
<asp:BoundField DataField="FinishTime"  HeaderText="FinishTime" />    
<asp:ButtonField CommandName="Delete" Text="Delete" ButtonType="Image" ImageUrl="~/Images0/delete.gif" />

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

         $(function () {
             $('[id*=TextBox1]').datetimepicker({
                 format: 'LT'
             });
         });
               </script>
</asp:Content>

