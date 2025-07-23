<%@ Page Title="" Language="C#" MasterPageFile="~/mainMaster.master" AutoEventWireup="true" CodeFile="DeliveryPage.aspx.cs" Inherits="DeliveryPage" %>

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
        </Triggers>
         <ContentTemplate>
                

     <section class="content-header d-flex">
        <h1>Delivery Page</h1>
         <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Delivery Page</li>
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
                                 Date of Birth:
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                    
                                   <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">                                                            
                                                          <asp:TextBox ID="txtdob" runat="server"   CssClass="form-control" 
                                                             AutoPostBack="True" ></asp:TextBox>
                                                             
                                                                 <span class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </span>                                                   
                        
                                                        </div>
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                  Time of Birth
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                <asp:TextBox runat="server" ID="txttimeofbirth"  CssClass="form-control" Text=" "></asp:TextBox>
                                 </div>
                            </div>
                        <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:CheckBox runat="server" ID="ChkMale" Text="Male" />
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:CheckBox runat="server" ID="ChkFemale" Text="Female" />
                                 </div>
                            </div>
                        
                        
                       
                        </div>

                      </div>

                 <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                 Birth Weight:
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                    <asp:TextBox runat="server" ID="txtbirthWeight"  CssClass="form-control" Text=" "></asp:TextBox>
                                 </div>
                            </div>  
                        </div>
                      </div>
                 Apgar score at 1 minute
                    <div class="col-lg-12 mt-2">

                      <div class="row">
                             <div class="col-lg-2 text-left">                          
                             <div class="form-group">
                              
                                 </div>
                                 </div>
                        <div class="col-lg-1 text-left">                          
                             <div class="form-group">
                               <strong>  0 Points</strong> 
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                                 <strong>   1 Points </strong>
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                                <strong>  2 Points </strong>
                                 </div>
                            </div> 
                          <div class="col-lg-3 text-left">
                             <div class="form-group">
                              <strong>   Total </strong>
                                 </div>
                            </div>                        
                        </div>
                         </div>

                 <div class="col-lg-12 mt-2">

                      <div class="row">
                             <div class="col-lg-2 text-left">                          
                             <div class="form-group">
                            <strong>   Activity</strong>
                                 </div>
                                 </div>
                        <div class="col-lg-1 text-left">                          
                             <div class="form-group">
                                 Absent
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                                  Arms & Legs Flexed
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                                Active Movement
                                 </div>
                            </div> 
                          <div class="col-lg-3 text-left">
                             <div class="form-group">
                                <asp:TextBox runat="server" ID="txttotal1Activity"  CssClass="form-control" Text=" "></asp:TextBox>
                                 </div>
                            </div>                        
                        </div>
                         </div>

                
                
                  <div class="col-lg-12 mt-2">

                      <div class="row">
                             <div class="col-lg-2 text-left">                          
                             <div class="form-group">
                            <strong>   Pulse</strong>
                                 </div>
                                 </div>
                        <div class="col-lg-1 text-left">                          
                             <div class="form-group">
                                 Absent
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                                 < 100 bpm
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                               > 100 bpm
                                 </div>
                            </div> 
                          <div class="col-lg-3 text-left">
                             <div class="form-group">
                                <asp:TextBox runat="server" ID="txtTotal1Pulse"  CssClass="form-control" Text=" "></asp:TextBox>
                                 </div>
                            </div>                        
                        </div>
                         </div>

                 <div class="col-lg-12 mt-2">

                      <div class="row">
                             <div class="col-lg-2 text-left">                          
                             <div class="form-group">
                            <strong>   Grimace</strong>
                                 </div>
                                 </div>
                        <div class="col-lg-1 text-left">                          
                             <div class="form-group">
                                 Flaccid
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                                some flexion of extremities
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                              Sneeze,Cough,Motion
                                 </div>
                            </div> 
                          <div class="col-lg-3 text-left">
                             <div class="form-group">
                                  <asp:TextBox runat="server" ID="txttotal1Grimace"  CssClass="form-control" Text=" "></asp:TextBox>
                                 </div>
                            </div>                        
                        </div>
                         </div>

                  <div class="col-lg-12 mt-2">

                      <div class="row">
                             <div class="col-lg-2 text-left">                          
                             <div class="form-group">
                            <strong>   Appearance</strong>
                                 </div>
                                 </div>
                        <div class="col-lg-1 text-left">                          
                             <div class="form-group">
                                 Blue/Pale
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                                Body pink ,feet & hands blue
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                             Completely Pink
                                 </div>
                            </div> 
                          <div class="col-lg-3 text-left">
                             <div class="form-group">
                                  <asp:TextBox runat="server" ID="txttotal1Appearance"  CssClass="form-control" Text=""></asp:TextBox>
                                 </div>
                            </div>                        
                        </div>
                         </div>
                 <div class="col-lg-12 mt-2">

                      <div class="row">
                             <div class="col-lg-2 text-left">                          
                             <div class="form-group">
                            <strong>   Respiration</strong>
                                 </div>
                                 </div>
                        <div class="col-lg-1 text-left">                          
                             <div class="form-group">
                                Absent
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                                Slow irregular
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                            Vigorous Cry
                                 </div>
                            </div> 
                          <div class="col-lg-3 text-left">
                             <div class="form-group">
                                <asp:TextBox runat="server" ID="txttotal1Respiration"  CssClass="form-control" Text=" "></asp:TextBox>
                                 </div>
                            </div>                        
                        </div>
                         </div>
                 Apgar score at 5 minute

                 <div class="col-lg-12 mt-2">

                      <div class="row">
                             <div class="col-lg-2 text-left">                          
                             <div class="form-group">
                              
                                 </div>
                                 </div>
                        <div class="col-lg-1 text-left">                          
                             <div class="form-group">
                               <strong>  0 Points</strong> 
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                                 <strong>   1 Points </strong>
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                                <strong>  2 Points </strong>
                                 </div>
                            </div> 
                          <div class="col-lg-3 text-left">
                             <div class="form-group">
                              <strong>   Total </strong>
                                 </div>
                            </div>                        
                        </div>
                         </div>


               
                 <div class="col-lg-12 mt-2">

                      <div class="row">
                             <div class="col-lg-2 text-left">                          
                             <div class="form-group">
                            <strong>   Activity</strong>
                                 </div>
                                 </div>
                        <div class="col-lg-1 text-left">                          
                             <div class="form-group">
                                 Absent
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                                  Arms & Legs Flexed
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                                Active Movement
                                 </div>
                            </div> 
                          <div class="col-lg-3 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txttotal5Activity"  CssClass="form-control" Text=" "></asp:TextBox>
                                 </div>
                            </div>                        
                        </div>
                         </div>
                  <div class="col-lg-12 mt-2">

                      <div class="row">
                             <div class="col-lg-2 text-left">                          
                             <div class="form-group">
                            <strong>   Pulse</strong>
                                 </div>
                                 </div>
                        <div class="col-lg-1 text-left">                          
                             <div class="form-group">
                                 Absent
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                                 < 100 bpm
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                               > 100 bpm
                                 </div>
                            </div> 
                          <div class="col-lg-3 text-left">
                             <div class="form-group">
                                <asp:TextBox runat="server" ID="txttotal5Pulse"  CssClass="form-control" Text=" "></asp:TextBox>
                                 </div>
                            </div>                        
                        </div>
                         </div>

                 <div class="col-lg-12 mt-2">

                      <div class="row">
                             <div class="col-lg-2 text-left">                          
                             <div class="form-group">
                            <strong>   Grimace</strong>
                                 </div>
                                 </div>
                        <div class="col-lg-1 text-left">                          
                             <div class="form-group">
                                 Flaccid
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                                some flexion of extremities
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                              Sneeze,Cough,Motion
                                 </div>
                            </div> 
                          <div class="col-lg-3 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txttotal5Grimace"  CssClass="form-control" Text=" "></asp:TextBox>
                                 </div>
                            </div>                        
                        </div>
                         </div>

                  <div class="col-lg-12 mt-2">

                      <div class="row">
                             <div class="col-lg-2 text-left">                          
                             <div class="form-group">
                            <strong>   Appearance</strong>
                                 </div>
                                 </div>
                        <div class="col-lg-1 text-left">                          
                             <div class="form-group">
                                 Blue/Pale
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                                Body pink ,feet & hands blue
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                             Completely Pink
                                 </div>
                            </div> 
                          <div class="col-lg-3 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txttotal5Appearance"  CssClass="form-control" Text=" "></asp:TextBox>
                                 </div>
                            </div>                        
                        </div>
                         </div>
                 <div class="col-lg-12 mt-2">

                      <div class="row">
                             <div class="col-lg-2 text-left">                          
                             <div class="form-group">
                            <strong>   Respiration</strong>
                                 </div>
                                 </div>
                        <div class="col-lg-1 text-left">                          
                             <div class="form-group">
                                Absent
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                                Slow irregular
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                            Vigorous Cry
                                 </div>
                            </div> 
                          <div class="col-lg-3 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txttotal5Respiration"  CssClass="form-control" Text=" "></asp:TextBox>
                                 </div>
                            </div>                        
                        </div>
                         </div>

                 <div class="col-lg-12 mt-2">

                      <div class="row">
                             <div class="col-lg-2 text-left">                          
                             <div class="form-group">
                            <strong>   Type of Delivery</strong>
                                 </div>
                                 </div>
                        <div class="col-lg-3 text-left">                          
                             <div class="form-group">
                                 <asp:CheckBox runat="server" ID="ChkSpontaneousVaginal" Text="Spontaneous Vaginal" />
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                                <asp:CheckBox runat="server" ID="ChkInductionOxy" Text="Induction Oxytocin" />
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                           <asp:CheckBox runat="server" ID="ChkInduction" Text="Induction Cytotec" />
                                 </div>
                            </div> 
                          <div class="col-lg-3 text-left">
                             <div class="form-group">
                                
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
                                 <asp:CheckBox runat="server" ID="ChkVaccum" Text="Vaccum Extraction" />
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                                <asp:CheckBox runat="server" ID="ChkForceps" Text="Forceps delivery" />
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                           <asp:CheckBox runat="server" ID="ChkCaesarian" Text="Caesarian section" />
                                 </div>
                            </div> 
                          <div class="col-lg-3 text-left">
                             <div class="form-group">
                                
                                 </div>
                            </div>                        
                        </div>
                         </div>
                <div class="col-lg-12 mt-2">

                      <div class="row">
                             <div class="col-lg-1 text-left">                          
                             <div class="form-group">
                              Summary
                                 </div>
                                 </div>
                        <div class="col-lg-2 text-left">                          
                             <div class="form-group">
                               <strong>  Date</strong> 
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                                 <strong>   Time(From)</strong>
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                                <strong>  Time(To)</strong>
                                 </div>
                            </div> 
                          <div class="col-lg-3 text-left">
                             <div class="form-group">
                              <strong>   Duration </strong>
                                 </div>
                            </div>                        
                        </div>
                         </div>

                  <div class="col-lg-12 mt-2">

                      <div class="row">
                             <div class="col-lg-1 text-left">                          
                             <div class="form-group">
                              Stage1
                                 </div>
                                 </div>
                        <div class="col-lg-2 text-left">                          
                             <div class="form-group">
                              
                                   <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">                                                            
                                                          <asp:TextBox ID="txtstage1date" runat="server"   CssClass="form-control" 
                                                             AutoPostBack="True" ></asp:TextBox>
                                                             
                                                                 <span class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </span>                                                   
                        
                                                        </div>
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtstage1timefrom"  CssClass="form-control" Text=" "></asp:TextBox>
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtstage1TimeTo"  CssClass="form-control" Text=" "></asp:TextBox>
                                 </div>
                            </div> 
                          <div class="col-lg-3 text-left">
                             <div class="form-group">
                               <asp:TextBox runat="server" ID="txtstage1duration"  CssClass="form-control" Text=" "></asp:TextBox>
                                 </div>
                            </div>                        
                        </div>
                         </div>

                 <div class="col-lg-12 mt-2">

                      <div class="row">
                             <div class="col-lg-1 text-left">                          
                             <div class="form-group">
                              Stage2
                                 </div>
                                 </div>
                        <div class="col-lg-2 text-left">                          
                             <div class="form-group">
                              
                                   <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">                                                            
                                                          <asp:TextBox ID="txtstage2date" runat="server"   CssClass="form-control" 
                                                             AutoPostBack="True" ></asp:TextBox>
                                                             
                                                                 <span class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </span>                                                   
                        
                                                        </div>
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtstage2timefrom"  CssClass="form-control" Text=" "></asp:TextBox>
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtstage2timeto"  CssClass="form-control" Text=" "></asp:TextBox>
                                 </div>
                            </div> 
                          <div class="col-lg-3 text-left">
                             <div class="form-group">
                               <asp:TextBox runat="server" ID="txtstage2duration"  CssClass="form-control" Text=" "></asp:TextBox>
                                 </div>
                            </div>                        
                        </div>
                         </div>
                 <div class="col-lg-12 mt-2">

                      <div class="row">
                             <div class="col-lg-1 text-left">                          
                             <div class="form-group">
                              Stage3
                                 </div>
                                 </div>
                        <div class="col-lg-2 text-left">                          
                             <div class="form-group">
                                  
                                   <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">                                                            
                                                          <asp:TextBox ID="txtstage3date" runat="server"   CssClass="form-control" 
                                                             AutoPostBack="True" ></asp:TextBox>
                                                             
                                                                 <span class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </span>                                                   
                        
                                                        </div>
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtstage3timefrom"  CssClass="form-control" Text=" "></asp:TextBox>
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                                  <asp:TextBox runat="server" ID="txtstage3timeto"  CssClass="form-control" Text=" "></asp:TextBox>
                                 </div>
                            </div> 
                          <div class="col-lg-3 text-left">
                             <div class="form-group">
                               <asp:TextBox runat="server" ID="txtstage3duration"  CssClass="form-control" Text=" "></asp:TextBox>
                                 </div>
                            </div>                        
                        </div>
                         </div>


                <div class="col-lg-12 mt-2">

                      <div class="row">
                             <div class="col-lg-3 text-left">                          
                             <div class="form-group">
                              <asp:CheckBox runat="server" ID="ChkPlacentacom" Text="Placenta Complete" />
                                 </div>
                                 </div>
                       
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                                <asp:CheckBox runat="server" ID="ChkPlacentainc" Text="Placenta incomplete/missing lobes" />
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                                <asp:CheckBox runat="server" ID="Chk3blood" Text="3 blood Vessels" />
                                 </div>
                            </div> 
                          <div class="col-lg-3 text-left">
                             <div class="form-group">
                              <asp:CheckBox runat="server" ID="ChkMeconium" Text="Meconium Staining" />
                                 </div>
                            </div>                        
                        </div>
                         </div>
                 <div class="col-lg-12 mt-2">

                      <div class="row">
                             <div class="col-lg-3 text-left">                          
                             <div class="form-group">
                              <asp:CheckBox runat="server" ID="ChkCord" Text="Cord around the neck" />
                                 </div>
                                 </div>
                       
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                                <asp:CheckBox runat="server" ID="ChkEpisiotomy" Text="Episiotomy" />
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                                <asp:CheckBox runat="server" ID="ChkVaginal" Text="Vaginal/Perineal laceration" />
                                 </div>
                            </div> 
                                                
                        </div>
                         </div>
                 <div class="col-lg-12 mt-2">

                      <div class="row">
                             <div class="col-lg-2 text-left">                          
                             <div class="form-group">
                              Repair By
                                 </div>
                                 </div>
                       
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                 <asp:TextBox ID="txtRepairBy"   CssClass="form-control"   runat="server" />
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                                Time of  rupture membrance
                                 </div>
                            </div> 
                              <div class="col-lg-4 text-left">
                             <div class="form-group">
                                 <asp:TextBox ID="txtTimeofrupture"   CssClass="form-control"   runat="server" />
                                 </div>
                            </div>                   
                        </div>
                         </div>
                 <div class="col-lg-12 mt-2">

                      <div class="row">
                             <div class="col-lg-2 text-left">                          
                             <div class="form-group">
                             Blood Loss
                                 </div>
                                 </div>
                       
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                 <asp:TextBox ID="txtbloodloss"   CssClass="form-control"   runat="server" />
                                 </div>
                            </div>
                                          
                        </div>
                         </div>
                <strong>Vaccum Extraction / Forceps Delivery</strong>
                 <div class="col-lg-12 mt-2">

                      <div class="row">
                             <div class="col-lg-2 text-left">                          
                             <div class="form-group">
                            Type of Forceps
                                 </div>
                                 </div>
                       
                        <div class="col-lg-4 text-left">
                             <div class="form-group">
                                 <asp:TextBox ID="txttypeofForceps"   CssClass="form-control"   runat="server" />
                                 </div>
                            </div>
                                   <div class="col-lg-2 text-left">                          
                             <div class="form-group">
                            Number of Pulls
                                 </div>
                                 </div>
                       
                        <div class="col-lg-4 text-left">
                             <div class="form-group">
                                 <asp:TextBox ID="txtnumberofpulls"   CssClass="form-control"   runat="server" />
                                 </div>
                            </div>        
                        </div>
                         </div>
                 <div class="col-lg-12 mt-2">

                      <div class="row">
                             <div class="col-lg-2 text-left">                          
                             <div class="form-group">
                            Number of slippage
                                 </div>
                                 </div>
                       
                        <div class="col-lg-4 text-left">
                             <div class="form-group">
                                 <asp:TextBox ID="txtnumberofslippage"   CssClass="form-control"   runat="server" />
                                 </div>
                            </div>
                                 <div class="col-lg-1 text-left">                          
                             <div class="form-group">
                                 COH 
                                 </div>
                                     </div> 
                           <div class="col-lg-2 text-left">                          
                             <div class="form-group">
                                 <asp:TextBox ID="txtCOH"   CssClass="form-control"   runat="server" />
                                 </div>
                                     </div> 
                           <div class="col-lg-1 text-left">                          
                             <div class="form-group">
                                 COC 
                                 </div>
                                     </div> 
                           <div class="col-lg-2 text-left">                          
                             <div class="form-group">
                                  <asp:TextBox ID="txtCOC"   CssClass="form-control"   runat="server" /> 
                                 </div>
                                     </div>         
                        </div>
                         </div>

                <div class="col-lg-12 mt-2">

                       <div class="row">
                             <div class="col-lg-12 text-center">                          
                             <div class="form-group">
                                 <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-success" OnClick="btnSave_Click" />
                                    <asp:Button ID="btnReport" runat="server" Text="Report" class="btn btn-warning" OnClick="btnReport_Click" />
                                 </div>
                                 </div>
                           </div>
                      </div>
                 <div class="col-lg-12 mt-2">
                    <div class="row">
                         <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                                    class="table table-responsive table-sm table-bordered" Width="100%" DataKeyNames="DeliveryId"
                                    HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3" 
                                    AllowPaging="True" BackColor="White"  
                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="30" ShowHeaderWhenEmpty="True"
                                    OnPageIndexChanging="GridView1_PageIndexChanging" OnRowEditing="GridView1_RowEditing">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:CommandField ButtonType="Image"  EditImageUrl="~/Images0/edit.gif" 
                                     ShowCancelButton="False" ShowEditButton="True">
                                <ItemStyle HorizontalAlign="Center" Width="70px" />
                                </asp:CommandField>
                                        <asp:BoundField DataField="DateOfBirth" HeaderText="DateOfBirth" DataFormatString="{0:dd/MM/yyyy}"   />
                                        
                                        <asp:BoundField DataField="TimeOfBirth" HeaderText="Time"  />
                                        <asp:BoundField DataField="BirthGender" HeaderText="Gender"  />
                                         <asp:BoundField DataField="BirthWeight" HeaderText="Weight"  />
                                        
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



