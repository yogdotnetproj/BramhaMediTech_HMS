using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_ucPatientInfo : System.Web.UI.UserControl
{
    BELPatientInformation objBELPatInfo = new BELPatientInformation();
    DALPatientInformation objDALPatInfo = new DALPatientInformation();
    BELOPDPatReg objBELOpdReg = new BELOPDPatReg();
    DALOpdReg objDALOpdReg = new DALOpdReg();
   
   
    public void Page_Load(object sender, EventArgs e)
    {
       // if (!IsPostBack)
       // {
       // Load();
       // }
    }

    public void Load (int PatientInfoId)
    {
           objBELPatInfo = objDALPatInfo.SelectOne(PatientInfoId);
           Session["PatientId"] = objBELPatInfo.PatientInfoId;
           lblPatientName.Text = objBELPatInfo.PatientName;//objBELPatientInformation.TitleName+" "+
            Session["PatientName"] = lblPatientName.Text;
            lblPrnNo.Text = objBELPatInfo.PatRegId;
            lblPatientCategory.Text = objBELPatInfo.PatMainType;
            lblAddress.Text = objBELPatInfo.PatientAddress;
            lblPatientSubCategory.Text = objBELPatInfo.PatientInsuType;
            lblEntryDate.Text = Convert.ToString(objBELPatInfo.EntryDate);
            lblBloodGroup.Text = Convert.ToString(objBELPatInfo.BloodGroup);
        
    }

    public void LoadByPatienntRegistrationId(int PatientRegistrationId)
    {
        objBELOpdReg = objDALOpdReg.SelectOne(PatientRegistrationId);

        objBELPatInfo = objDALPatInfo.SelectOne(objBELOpdReg.PatientInfoId);

        lblPatientName.Text = objBELPatInfo.PatientName;//objBELPatientInformation.TitleName + " " +
        lblPrnNo.Text = objBELPatInfo.PatRegId;
        lblPatientCategory.Text = objBELPatInfo.PatMainType;
        lblAddress.Text = objBELPatInfo.PatientAddress;
        lblPatientSubCategory.Text = objBELPatInfo.PatientInsuType;
        lblEntryDate.Text = Convert.ToString(objBELPatInfo.EntryDate);
        lblBloodGroup.Text = Convert.ToString(objBELPatInfo.BloodGroup);
    }
}