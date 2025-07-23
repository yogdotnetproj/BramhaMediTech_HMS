<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="Triage_Questionary.aspx.cs" Inherits="Triage_Questionary" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>


     <section class="content-header d-flex">
                    <h1>Triage Questionary</h1>
                    
                </section>
    <section class="content">
           <div class="box pt-3">
              <div class="box-body">
                    <div class="row">    

                           <div class="col-lg-12 mt-3">
                            <div class="row"> 
                                   <div class="col-sm-4" >
                                            <div class="form-group">
                                               
                                                <asp:Label runat="server" BackColor="Red" ForeColor="Black" Width="100%" Text =" Check for RED criteria"></asp:Label>
                                                </div>
                                       </div>
                                <div class="col-sm-4" >
                                            <div class="form-group">
                                               
                                                 <asp:Label ID="Label1" runat="server" BackColor="Yellow" ForeColor="Black" Width="100%" Text =" Check for YELLOW criteria"></asp:Label>
                                                </div>
                                       </div>
                                <div class="col-sm-4" >
                                            <div class="form-group">
                                               
                                                  <asp:Label ID="Label2" runat="server" BackColor="Red" ForeColor="Black" Width="100%" Text =" High-risk vital signs"></asp:Label>
                                                </div>
                                       </div>
                                </div>
                               </div>

                         <div class="col-lg-12 mt-2">
                            <div class="row"> 
                                   <div class="col-sm-4" >
                                            <div class="form-group">
                                               <div class="form-check" style="overflow: scroll; width: 348px; height: 320px" id="div">
                                                   <asp:TreeView ID="TR_HighRiskCrit"  runat="server"   ExpandDepth="1"   
                onselectednodechanged="TR_HighRiskCrit_SelectedNodeChanged" ShowCheckBoxes="Leaf" BackColor="White" >
                <HoverNodeStyle Font-Underline="true" />
                <NodeStyle Font-Names ="Tahoma" ForeColor="Black"   HorizontalPadding="2px" NodeSpacing="0px" VerticalPadding="2px" >
                </NodeStyle>
                <ParentNodeStyle Font-Bold="true" />
                <SelectedNodeStyle BackColor="#A1DCF2" ForeColor="#3AC0F2"  Font-Underline="false" HorizontalPadding="0px" 
                VerticalPadding="0px" />
                
                </asp:TreeView>
                                                   </div>
                                                </div>
                                       </div>
                                <div class="col-sm-4" >
                                            <div class="form-group">
                                               <div class="form-check" style="overflow: scroll; width: 348px; height: 320px" id="div1">
                                                   <asp:TreeView ID="TR_HighRiskCrit_Yellow"  runat="server"   ExpandDepth="1"   
                onselectednodechanged="TR_HighRiskCrit_Yellow_SelectedNodeChanged" ShowCheckBoxes="Leaf" BackColor="White" >
                <HoverNodeStyle Font-Underline="true" />
                <NodeStyle Font-Names ="Tahoma" ForeColor="Black"   HorizontalPadding="2px" NodeSpacing="0px" VerticalPadding="2px" >
                </NodeStyle>
                <ParentNodeStyle Font-Bold="true" />
                <SelectedNodeStyle BackColor="#A1DCF2" ForeColor="#3AC0F2"  Font-Underline="false" HorizontalPadding="0px" 
                VerticalPadding="0px" />
                
                </asp:TreeView>
                                                   </div>
                                                </div>
                                       </div>
                                <div class="col-sm-4" >
                                            <div class="form-group">
                                                 <div class="form-group">
                                               <div class="form-check" style="overflow: scroll; width: 348px; height: 320px" id="div2">
                                                   <asp:TreeView ID="TR_HighRiskCrit_Vital"  runat="server"   ExpandDepth="1"   
                onselectednodechanged="TR_HighRiskCrit_Vital_SelectedNodeChanged" ShowCheckBoxes="Leaf" BackColor="White" >
                <HoverNodeStyle Font-Underline="true" />
                <NodeStyle Font-Names ="Tahoma" ForeColor="Black"   HorizontalPadding="2px" NodeSpacing="0px" VerticalPadding="2px" >
                </NodeStyle>
                <ParentNodeStyle Font-Bold="true" />
                <SelectedNodeStyle BackColor="#A1DCF2" ForeColor="#3AC0F2"  Font-Underline="false" HorizontalPadding="0px" 
                VerticalPadding="0px" />
                
                </asp:TreeView>
                                                   </div>
                                                </div>
                                                </div>
                                       </div>
                                </div>
                               </div>

                         <div class="col-lg-12 mt-2">
                            <div class="row"> 
                                   <div class="col-sm-6" >
                                            <div class="form-group">
                                                Patient is suspected of suffering from a communicable disease ?
                                                </div>
                                       </div>
                                 <div class="col-sm-1" >
                                            <div class="form-group">
                                                <asp:CheckBox runat="server" ID="ChkYes" Text="YES" />
                                                </div>
                                 </div>
                                <div class="col-sm-1" >
                                            <div class="form-group">
                                                <asp:CheckBox runat="server" ID="ChkNo" Text="NO" />
                                                </div>
                                 </div>
                                </div>
                             </div>
                         <div class="col-lg-12 mt-2">
                            <div class="row"> 
                                <div class="col-sm-3" >
                                            <div class="form-group">
                                                If,yes what measures were taken:
                                                </div>
                                      </div>
                                <div class="col-sm-7" >
                                            <div class="form-group">
   <asp:TextBox ID="txtmeasures" CssClass="form-control"  runat="server" TextMode="MultiLine" placeholder="Enter If,yes what measures were taken" ></asp:TextBox>

                                                </div>
                                    </div>
                                </div>
                             </div>
                        <div class="col-lg-12 mt-2">
                            <div class="row"> 
                                <div class="col-sm-12" >
                                    <asp:RadioButtonList ID="RblTriageCriteria" runat="server" RepeatDirection="Horizontal" >
                                        <asp:ListItem Value="1">Move to High Acuity </asp:ListItem>
                                        <asp:ListItem Value="2">Move to Clinical </asp:ListItem>
                                        <asp:ListItem Value="0">Move to Low Acuity </asp:ListItem>
                                    </asp:RadioButtonList>
                                    </div>
                                </div>
                            </div>
                        <div class="col-lg-12 mt-2">
                            <div class="row"> 
                                <div class="col-sm-12" >
                                    <asp:Label runat="server" ID="Lblmsg"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        <div class="col-lg-12 mt-2">
                            <div class="row"> 
                                <div class="col-sm-12 text-center" >
                                     <asp:Button ID="btnsave" runat="server" Text="Save" CssClass="btn btn-primary" onclick="btnsave_Click" />        
                                    </div>
                                </div>
                            </div>
                        </div>
                     </div>
               </div>
        </section>
</asp:Content>

