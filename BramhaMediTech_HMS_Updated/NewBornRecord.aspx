<%@ Page Title="" Language="C#" MasterPageFile="~/mainMaster.master" AutoEventWireup="true" CodeFile="NewBornRecord.aspx.cs" Inherits="NewBornRecord" %>

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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnReport" />     
            <asp:PostBackTrigger ControlID="btnCard" />       
        </Triggers>
         <ContentTemplate>
                

     <section class="content-header d-flex">
        <h1>New Born Record</h1>
         <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">New Born Record</li>
                    </ol>
    </section>
              <section class="content">
        <div id="Div1" class="box" runat="server">
            <div class="box-header with-border">
                <span class="red pull-right"></span>
                <asp:Label ID="lblMsg1" class="red pull-center" runat="server" Text="" Font-Bold="true" ForeColor="green"></asp:Label>
             
            </div>

             <div class="box-body">
                
                <div class="col-lg-12">
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
                             <div class="form-group">
                                Infant Name:
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                                    <asp:TextBox runat="server" ID="txtinfantname"  CssClass="form-control" Text=" "></asp:TextBox>
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                  Mother's Name
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                                <asp:TextBox runat="server" ID="txtmothername"  CssClass="form-control" Text=" "></asp:TextBox>
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                 <asp:RadioButtonList runat="server" ID="RblGender" RepeatDirection="Horizontal">
                                     <asp:ListItem Text="Male">Male</asp:ListItem>
                                     <asp:ListItem Text="Female">Female</asp:ListItem>
                                 </asp:RadioButtonList>
                                 </div>
                            </div>
                        
                        
                       
                        </div>

                      </div>

                   <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                               Birth Date:
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                                   
                                  <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">                                                            
                                                          <asp:TextBox ID="txtBirthDate" runat="server"   CssClass="form-control" 
                                                             AutoPostBack="True" ></asp:TextBox>
                                                             
                                                                 <span class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </span>                                                   
                        
                                                        </div>
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                 File No
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                                <asp:TextBox runat="server" ID="txtFileNo"  CssClass="form-control" Text=" "></asp:TextBox>
                                 </div>
                            </div>
                        <div class="col-lg-1 text-left">
                             <div class="form-group">
                                  <asp:Button ID="btnRegister" runat="server" class="btn btn-success" Text="Register" OnClick="btnRegister_Click" />
                                  
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                   <asp:Button ID="btnCard" runat="server" Text="Card" class="btn btn-warning" OnClick="btnCard_Click" />
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
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                                  
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                                
                                 </div>
                            </div>
                        <div class="col-lg-1 text-left">
                             <div class="form-group">
                               CIRC
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                                <asp:TextBox runat="server" ID="txtCIRC"  CssClass="form-control" Text=" "></asp:TextBox>
                                 </div>
                            </div>
                        
                        
                       
                        </div>

                      </div>
                   <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                              Date:
                                 </div>
                            </div>
                        <div class="col-lg-3 text-center">
                             <div class="form-group">
                                   Today's Weight
                                 </div>
                            </div>
                        <div class="col-lg-3 text-center">
                             <div class="form-group">
                                 Yesterday's Weight
                                 </div>
                            </div>
                        <div class="col-lg-1 text-left">
                             <div class="form-group">
                               Dr.
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                                <asp:TextBox runat="server" ID="txtDr"  CssClass="form-control" Text=" "></asp:TextBox>
                                 </div>
                            </div>
                        
                        
                       
                        </div>

                      </div>

                  <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                            Shift
                                 </div>
                            </div>
                        <div class="col-lg-3 text-center">
                             <div class="form-group">
                                  7:00 a.m. - 3:00 p.m.
                                 </div>
                            </div>
                        <div class="col-lg-3 text-center">
                             <div class="form-group">
                                 3:00 a.m. - 11:00 p.m.
                                 </div>
                            </div>
                        
                        <div class="col-lg-3 text-center">
                             <div class="form-group">
                                11:00 p.m. - 7:00 a.m.
                                 </div>
                            </div>
                        
                        
                       
                        </div>

                      </div>

                   <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                            Time
                                 </div>
                            </div>
                        <div class="col-lg-1 text-left">
                             <div class="form-group">
                                  <asp:TextBox runat="server" ID="txttime1"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                  <asp:TextBox runat="server" ID="txttime2"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                  <asp:TextBox runat="server" ID="txttime3"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                  <asp:TextBox runat="server" ID="txttime4"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                  <asp:TextBox runat="server" ID="txttime5"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                  <asp:TextBox runat="server" ID="txttime6"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                        
                        <div class="col-lg-1 text-left">
                             <div class="form-group">
                                  <asp:TextBox runat="server" ID="txttime7"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                  <asp:TextBox runat="server" ID="txttime8"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                  <asp:TextBox runat="server" ID="txttime9"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                        
                        
                       
                        </div>

                      </div>

                  <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                            Temperature
                                 </div>
                            </div>
                        <div class="col-lg-1 text-left">
                             <div class="form-group">
                              <asp:TextBox runat="server" ID="txtTemperature1"  CssClass="form-control" Text=""></asp:TextBox>    
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                  <asp:TextBox runat="server" ID="txtTemperature2"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                  <asp:TextBox runat="server" ID="txtTemperature3"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                  <asp:TextBox runat="server" ID="txtTemperature4"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                  <asp:TextBox runat="server" ID="txtTemperature5"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                  <asp:TextBox runat="server" ID="txtTemperature6"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                        
                        <div class="col-lg-1 text-left">
                             <div class="form-group">
                                  <asp:TextBox runat="server" ID="txtTemperature7"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                  <asp:TextBox runat="server" ID="txtTemperature8"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                  <asp:TextBox runat="server" ID="txtTemperature9"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                        
                        
                       
                        </div>

                      </div>

                  <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                            Respirations
                                 </div>
                            </div>
                        <div class="col-lg-1 text-left">
                             <div class="form-group">
                                  <asp:TextBox runat="server" ID="txtRespirations1"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                  <asp:TextBox runat="server" ID="txtRespirations2"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                  <asp:TextBox runat="server" ID="txtRespirations3"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                  <asp:TextBox runat="server" ID="txtRespirations4"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                  <asp:TextBox runat="server" ID="txtRespirations5"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                  <asp:TextBox runat="server" ID="txtRespirations6"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                        
                        <div class="col-lg-1 text-left">
                             <div class="form-group">
                                  <asp:TextBox runat="server" ID="txtRespirations7"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                  <asp:TextBox runat="server" ID="txtRespirations8"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                  <asp:TextBox runat="server" ID="txtRespirations9"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                        
                        
                       
                        </div>

                      </div>

                  <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                            Heart Rate
                                 </div>
                            </div>
                        <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtHeartRate1"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtHeartRate2"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtHeartRate3"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtHeartRate4"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtHeartRate5"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtHeartRate6"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                        
                        <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtHeartRate7"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtHeartRate8"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtHeartRate9"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                        
                        
                       
                        </div>

                      </div>

                   <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-1 text-left">
                             <div class="form-group">
                          
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                          F Time
                                 </div>
                            </div>
                        <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtFtime1"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtFtime2"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtFtime3"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtFtime4"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtFtime5"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtFtime6"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                        
                        <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtFtime7"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtFtime8"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtFtime9"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                        
                        
                       
                        </div>

                      </div>

                    <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-1 text-left">
                             <div class="form-group">
                          
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                          E Formula
                                 <br>
                                 <br></br>
                                 E Type
                                </br>
                                
                                 </div>
                            </div>
                        <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtFormula1"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtFormula2"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtFormula3"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtFormula4"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtFormula5"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtFormula6"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                        
                        <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtFormula7"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtFormula8"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtFormula9"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                        
                        
                       
                        </div>

                      </div>

                  <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-1 text-left">
                             <div class="form-group">
                          
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                          D Breast<br>
                                 <br></br>
                                 I
                                 <br>
                                 <br></br>
                                 N </br>
                                 </br>
                                
                                 </div>
                            </div>
                        <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtBreast1"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtBreast2"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtBreast3"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtBreast4"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtBreast5"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtBreast6"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                        
                        <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtBreast7"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtBreast8"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtBreast9"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                        
                        
                       
                        </div>

                      </div>

                   <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-1 text-left">
                             <div class="form-group">
                          
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left" >
                             <div class="form-group">
                          G Supplement<br>
                                 <br></br>
                                 S Type </br>
                                
                                 </div>
                            </div>
                        <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtSupplement1"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtSupplement2"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtSupplement3"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtSupplement4"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtSupplement5"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtSupplement6"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                        
                        <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtSupplement7"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtSupplement8"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtSupplement9"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                        
                        
                       
                        </div>

                      </div>

                   <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                            Cord Care
                                 </div>
                            </div>
                        <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtcordCare1"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtcordCare2"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtcordCare3"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtcordCare4"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtcordCare5"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtcordCare6"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                        
                        <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtcordCare7"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtcordCare8"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtcordCare9"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                        
                        
                       
                        </div>

                      </div>

                  <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                            Urine
                                 </div>
                            </div>
                        <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtUrine1"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtUrine2"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtUrine3"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtUrine4"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtUrine5"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtUrine6"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                        
                        <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtUrine7"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtUrine8"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtUrine9"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                        
                        
                       
                        </div>

                      </div>

                  <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                            Stools
                                 </div>
                            </div>
                        <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtStools1"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtStools2"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtStools3"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtStools4"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtStools5"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtStools6"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                        
                        <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtStools7"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtStools8"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtStools9"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                        
                        
                       
                        </div>

                      </div>

                  <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                          RN Signature
                                 </div>
                            </div>
                        <div class="col-lg-1 text-left">
                             <div class="form-group">
                                  <asp:TextBox runat="server" ID="txtRNSignature1"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                  <asp:TextBox runat="server" ID="txtRNSignature2"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                  <asp:TextBox runat="server" ID="txtRNSignature3"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                  <asp:TextBox runat="server" ID="txtRNSignature4"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                  <asp:TextBox runat="server" ID="txtRNSignature5"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                  <asp:TextBox runat="server" ID="txtRNSignature6"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                        
                        <div class="col-lg-1 text-left">
                             <div class="form-group">
                                  <asp:TextBox runat="server" ID="txtRNSignature7"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                  <asp:TextBox runat="server" ID="txtRNSignature8"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                  <asp:TextBox runat="server" ID="txtRNSignature9"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>
                        
                        
                       
                        </div>

                      </div>
                 
                  <div class="col-lg-12 mt-2">

                       <div class="row">
                             <div class="col-lg-12 text-center">                          
                             <div class="form-group">
                                 <asp:Button ID="btnSave" runat="server" class="btn btn-success" Text="Save" OnClick="btnSave_Click" />
                                    <asp:Button ID="btnReport" runat="server" Text="Report" class="btn btn-warning" OnClick="btnReport_Click" />
                                 </div>
                                 </div>
                           </div>
                      </div>

                 <div class="col-lg-12 mt-2">
                    <div class="row">
                         <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                                    class="table table-responsive table-sm table-bordered" Width="100%" DataKeyNames="BId"
                                    HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3" 
                                    AllowPaging="True" BackColor="White"  
                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="30" ShowHeaderWhenEmpty="True"
                                    OnPageIndexChanging="GridView1_PageIndexChanging" OnRowEditing="GridView1_RowEditing">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:CommandField ButtonType="Image" EditImageUrl="~/Images0/edit.gif" 
                                     ShowCancelButton="False" ShowEditButton="True">
                                <ItemStyle HorizontalAlign="Center" Width="70px" />
                                </asp:CommandField>
                                        <asp:BoundField DataField="InfantName" HeaderText="InfantName"  />
                                        
                                        <asp:BoundField DataField="MotherName" HeaderText="MotherName"  />
                                        <asp:BoundField DataField="BirthDate" HeaderText="BirthDate"  />
                                        <asp:BoundField DataField="FileNo" HeaderText="FileNo"  />
                                        <asp:BoundField DataField="CIRC" HeaderText="CIRC"  />
                                         <asp:BoundField DataField="DrName" HeaderText="DrName"  />
                                        <asp:BoundField DataField="CreatedBy" HeaderText="Created By"  />
                                         <asp:BoundField DataField="CreatedOn" HeaderText="Created On " DataFormatString="{0:dd/MM/yyyy}"  />
                                         
                                     
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
             <script language="javascript" type="text/javascript">
                 function OpenReport() {

                     window.open("Reports.aspx");
                 }
               </script>
             </ContentTemplate>
        </asp:UpdatePanel>

           
</asp:Content>

