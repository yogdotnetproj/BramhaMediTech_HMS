using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class VaccinationAssignToPatient : System.Web.UI.Page
{
        clsEmr obj = new clsEmr();
    clsTreatment objTreat = new clsTreatment();
    clsTreatmentTransaction transaction = new clsTreatmentTransaction();
    DataTable tempDatatable = new DataTable();
    BLLPatientCategory objBLLPatientCategory = new BLLPatientCategory();
    DOPatientCategory objDOPatientCategory = new DOPatientCategory();

  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (Session["EmrRegNo"] != "")
            {
                string regId = Convert.ToString(Session["EmrRegNo"]);
                string name = Request.QueryString["Name"];
                string opd = Convert.ToString(Session["EmrOpdNo"]);
                string entrydate = Request.QueryString["EntryDate"];
                Session["Branchid"] = "1";
               // lblOpd.Text = opd;
                PindPatientInformation();
                FillVaccination();
                FillVaccinationAssign();
            }
        }
    }
    protected void FillVaccination()
    {
        gvPatientCat.DataSource = objBLLPatientCategory.FillGrid_Vaccination();
        gvPatientCat.DataBind();
    }
    public void PindPatientInformation()
    {
        DataTable dt = new DataTable();
        dt = obj.Get_AllPatientInformation(Convert.ToString(Session["EmrRegNo"]), Convert.ToString(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]), Convert.ToInt32(Session["Branchid"]));
        try
        {
            if (dt != null)
            {
                //lblPatientName.Text = Convert.ToString(dt.Rows[0]["PatientName"]);
                //txtpatientregid.Text = Convert.ToString(dt.Rows[0]["PatRegId"]);
                //lblIpd.Text = Convert.ToString(dt.Rows[0]["Ipdno"]);
                //lblOpd.Text = Convert.ToString(dt.Rows[0]["PatRegId"]);
                //lblMobileNo.Text = Convert.ToString(dt.Rows[0]["MobileNo"]);
                //lbldrname.Text = Convert.ToString(dt.Rows[0]["DrName"]);
                //lblAge.Text = Convert.ToString(dt.Rows[0]["Age"]) + "" + Convert.ToString(dt.Rows[0]["AgeType"]) + "/" + Convert.ToString(dt.Rows[0]["GenderName"]);
                ViewState["Age"] = Convert.ToString(dt.Rows[0]["Age"]);
                ViewState["AgeType"] = Convert.ToString(dt.Rows[0]["AgeType"]);

            }
            //dt = new DataTable();
            //dt = obj.Get_AllPatientVitalTaken(Convert.ToString(Session["EmrRegNo"]), Convert.ToString(Session["EmrOpdNo"]),Convert.ToInt32(Session["EmrIpdNo"]), Convert.ToInt32(Session["Branchid"]));
            //if (dt.Rows.Count > 0)
            //{
            //    lblvtaken.Text = Convert.ToString(dt.Rows[0]["CreatedOn"]);
            //}
        }
        catch (Exception ex)
        {

        }
    }
    protected void gvPatientCat_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string Message = "";        
        int  VaccianId = Convert.ToInt32( (gvPatientCat.DataKeys[e.RowIndex]["VaccianId"].ToString()));
       DataTable  dt = new DataTable();
       dt = obj.GetAllCaccnationRegisterCriteria(Convert.ToString(ViewState["Age"]), Convert.ToString(ViewState["AgeType"]),  VaccianId);
       if (dt.Rows.Count > 0)
       {
           if( Convert.ToString(dt.Rows[0]["AgeType"])== Convert.ToString(ViewState["AgeType"]))
           {
               if (Convert.ToInt32(ViewState["Age"]) >= Convert.ToInt32(dt.Rows[0]["fromage"]) && Convert.ToInt32(ViewState["Age"]) <= Convert.ToInt32(dt.Rows[0]["Toage"]))
               {
                   objDOPatientCategory.VaccianId = VaccianId;
                   objDOPatientCategory.OpdNo = Convert.ToString( Session["EmrOpdNo"]);
                   objDOPatientCategory.IpdNo = Convert.ToString( Session["EmrIpdNo"]);
                   objDOPatientCategory.Patregid = Convert.ToString( Session["EmrRegNo"]);
                   objDOPatientCategory.CreatedBy = Convert.ToString(Session["username"]);
                   objDOPatientCategory.FId = Convert.ToInt32(Session["FId"]); ;
                   objDOPatientCategory.BranchId = Convert.ToInt32(Session["Branchid"]);
                   Message = objBLLPatientCategory.Insert_VaccanationAssignToPatient(objDOPatientCategory);
                   FillVaccinationAssign();

                   lblmsg.Text = "Vaccination given successfully.";
               }
               else
               {
                   lblmsg.Text = "Vaccination criteria Don't exists!";
               }
           }
           else
           {
               lblmsg.Text = "Vaccination criteria Don't exists!";
           }
           
       }
       else
       {
          

       }


       // string Message = objBLLPatientCategory.Delete_Vaccination(Convert.ToInt32(VaccianId));//Convert.ToInt32(ViewState["PCId"])
       
       


    }
    protected void gvPatientCat_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {

            string PatientCategoryID = (gvPatientCat.DataKeys[e.NewEditIndex]["VaccianId"].ToString());
            ViewState["VaccianId"] = PatientCategoryID;
            FillPage();
            e.Cancel = true;
        }
        catch (Exception ex)
        {
            
        }
    }
    protected void FillPage()
    {
        try
        {
            objDOPatientCategory = objBLLPatientCategory.SelectOne_Vaccination(Convert.ToInt32(ViewState["VaccianId"]));
            
        }
        catch (Exception ex)
        {
           
        }
    }
    protected void gvPatientCat_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPatientCat.PageIndex = e.NewPageIndex;
        FillVaccination();
    }

    protected void GVVaccinationAssign_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVVaccinationAssign.PageIndex = e.NewPageIndex;
        FillVaccinationAssign();
    }
    protected void GVVaccinationAssign_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string Message = "";
        int VId = Convert.ToInt32((gvPatientCat.DataKeys[e.RowIndex]["VId"].ToString()));
        objBLLPatientCategory.Delete_AssignVaccination(VId);
        FillVaccinationAssign();
        lblmsg.Text = "Vaccination delete successfully.";
    }
    protected void GVVaccinationAssign_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    protected void FillVaccinationAssign()
    {
        objDOPatientCategory.OpdNo = Convert.ToString(Session["EmrOpdNo"]);
        objDOPatientCategory.IpdNo = Convert.ToString(Session["EmrIpdNo"]);
        objDOPatientCategory.Patregid = Convert.ToString(Session["EmrRegNo"]);
        objDOPatientCategory.CreatedBy = Convert.ToString(Session["username"]);
        objDOPatientCategory.FId = Convert.ToInt32(Session["FId"]); ;
        objDOPatientCategory.BranchId = Convert.ToInt32(Session["Branchid"]);
        GVVaccinationAssign.DataSource = objBLLPatientCategory.FillGrid_VaccinationToPatient(objDOPatientCategory);
        GVVaccinationAssign.DataBind();
    }
   
}