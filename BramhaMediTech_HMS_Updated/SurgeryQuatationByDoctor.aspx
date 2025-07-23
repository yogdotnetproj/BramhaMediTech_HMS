<%@ Page Title="" Language="C#" MasterPageFile="~/mainMaster.master" AutoEventWireup="true" CodeFile="SurgeryQuatationByDoctor.aspx.cs" Inherits="SurgeryQuatationByDoctor" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/ucPatientInfo.ascx" TagPrefix="uc1" TagName="ucPatientInfo" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
   
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>--%>
    <section class="content-header d-flex">
        <h1>Surgery Quotation By Doctor</h1>
        <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Surgery Quotation By Doctor</li>
                    </ol>
    </section>
    <section class="content">
        <div id="Div1" class="box" runat="server">
           <!-- <div class="box-header with-border">
                <span class="red pull-right">Fields marked with * are compulsory</span>
                <asp:Label ID="lblMsg" class="red pull-center" runat="server" Text="" Font-Bold="true" ForeColor="green"></asp:Label>
                
            </div>-->
             <div class="box-body">
                

            </div>
            <div class="box-body">
               
               
                    <div class="col-lg-12"  >
                        <div class="row">
                            <div class="col-lg-10">
                                <div class="row">
                                    
                                    <div class="col-lg-3 text-left" >
                                        <div class="form-group">
                                           
                                            <label for="txtSurgeonName">Surgeon <span style="color: red">*</span></label>
                                            
                                        </div>
                                    </div>
                                    <div class="col-lg-5 text-left" >
                                        <div class="form-group">
                                           
                                           
                                           

                                             <asp:TextBox ID="txtSurgeonName" runat="server"  CssClass="form-control" placeholder="Enter Surgeon" AutoPostBack="True" OnTextChanged="txtSurgeonName_TextChanged"></asp:TextBox>     
                                                        <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="Searchsurgan"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                TargetControlID="txtSurgeonName"
                                                ID="AutoCompleteExtender2"
                                                runat="server"><%--ServicePath="~/AutoCompleteService.asmx"--%>
                                                   </asp:AutoCompleteExtender>
                                            
                                        </div>
                                    </div>
                               </div>
                                 <div class="row mt-3">

                                    <div class="col-lg-3 text-left" >
                                        <div class="form-group">
                                            <label>Procedure <span style="color: red">*</span></label>
                                            
                                        </div>
                                    </div>
                                  
                                     <div class="col-lg-5 text-left" >
                                        <div class="form-group">
                                           
                                           
                                            <asp:TextBox ID="txtprocedure" runat="server" AutoPostBack="true" AutoCompleteType="None"
                                                TabIndex="1" CssClass="form-control" OnTextChanged="txtprocedure_TextChanged"  >
                                            </asp:TextBox>
                                            <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchOperaation"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                TargetControlID="txtprocedure"
                                                ID="AutoCompleteExtender9"
                                                runat="server"><%--ServicePath="~/AutoCompleteService.asmx"--%>
                                                   </asp:AutoCompleteExtender>
                    
                                            
                                        </div>
                                    </div>
                                    

                                </div>

                                <div class="row mt-3">
                                    <div class="col-lg-3 text-left">
                                        <div class="form-group">
                                            <label >OT Time(Estimated)</label>
                                            
                                        </div>
                                    </div>
                                    <div class="col-lg-5 text-left">
                                        <div class="form-group">
                                           
                                            <asp:TextBox ID="txtOTTime" runat="server" CssClass="form-control">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                   </div>
                                 <div class="row mt-3">
                                    <div class="col-lg-3 text-left">
                                        <div class="form-group">
                                            <label >ASA</label>
                                            
                                        </div>
                                    </div>
                                    <div class="col-lg-5 text-left">
                                        <div class="form-group">
                                           
                                            <asp:TextBox ID="txtASA" runat="server" CssClass="form-control">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                   </div>
                                <div class="row mt-3">
                                    <div class="col-lg-3 text-left">
                                        <div class="form-group">
                                            <label> Surgeon's Fee(Estimated)</label>
                                            
                                        </div>
                                    </div>
                                    <div class="col-lg-5 text-left">
                                        <div class="form-group">
                                           
                                            <asp:TextBox ID="txtSurgeonFee" runat="server" CssClass="form-control">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                   </div>
                                <div class="row mt-3">
                                    <div class="col-lg-3 text-left">
                                        <div class="form-group">
                                            <label> Hospital Stay(Estimated)</label>
                                            
                                        </div>
                                    </div>
                                    <div class="col-lg-5 text-left">
                                        <div class="form-group">
                                           
                                            <asp:TextBox ID="txtHospStay" runat="server" CssClass="form-control">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                   </div>
                                <div class="row mt-3">
                                    <div class="col-lg-3 text-left">
                                        <div class="form-group">
                                            <label> Special Investigation</label>
                                            
                                        </div>
                                    </div>
                                    <div class="col-lg-5 text-left">
                                        <div class="form-group">
                                           
                                            <asp:TextBox ID="txtSpeInv" runat="server" CssClass="form-control">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                   </div>

                                 <div class="row mt-3">
                                    <div class="col-lg-5">
                                         <div class="form-group"> 
                                        <asp:Button ID="btnAdd" runat="server" TabIndex="6" Text="Save" OnClick="btnAdd_Click"
                                            class="btn btn-success" CausesValidation="False" />
                                        <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click"
                                            CausesValidation="False" class="btn btn-primary btnSearch"/>
                                             </div>
                                    </div>
                                     </div>

                                  
                            </div>
                            
                            
                                </div>
                     
                    </div>
               
                
            </div>
        </div>

    </section>
    <%--        </ContentTemplate>
    </asp:UpdatePanel>--%>
    <script language="javascript" type="text/javascript">
        function OpenReport() {

            window.open("Reports.aspx");
        }
               </script>
</asp:Content>


