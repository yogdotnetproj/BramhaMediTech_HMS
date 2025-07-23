using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BaseClass
/// </summary>
public class BaseClass : System.Web.UI.Page
{
	public BaseClass()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    /// <summary>
    /// 
    /// </summary>
    /// <param name="lblMessage"></param>
    /// <param name="Message"></param>
    public void SuccessMessage(System.Web.UI.WebControls.Label lblMessage,string Message)
    {
        lblMessage.ForeColor = System.Drawing.Color.Green;
        lblMessage.Visible = true;
        lblMessage.Text = Message;
        lblMessage.Font.Bold = true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="lblMessage"></param>
    /// <param name="Message"></param>
    public void ErrorMessage(System.Web.UI.WebControls.Label lblMessage, string Message)
    {
        lblMessage.ForeColor = System.Drawing.Color.Red;
        lblMessage.Visible = true;
        lblMessage.Text = Message;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="lblMessage"></param>
    /// <param name="Message"></param>
    public void WarningMessage(System.Web.UI.WebControls.Label lblMessage, string Message)
    {
        lblMessage.ForeColor = System.Drawing.Color.Khaki;
        lblMessage.Visible = true;
        lblMessage.Text = Message;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="lblMessage"></param>
    /// <param name="Message"></param>
    public void DynamicMessage( System.Web.UI.WebControls.Label lblMessage, string Message)
    {
        //if(Message.Substring(0,1).Equals("1"))
        //{
        //    //lblMessage.Text = Message.Substring(1, Message.Length-1);
        //    lblMessage.ForeColor = System.Drawing.Color.Green;
        //    lblMessage.Visible = true;
        //    Message = Message.Substring(1, Message.Length - 1);
        //    lblMessage.Text = Message;
        //}
        lblMessage.Visible = true;
         try
        {

        if (Message.Substring(0, 1).Equals("1"))
        {
            lblMessage.ForeColor = System.Drawing.Color.Green;
        }
        else
        { 
            lblMessage.ForeColor = System.Drawing.Color.Red;
        }
        lblMessage.Visible = true;
        lblMessage.Text = Message.Substring(1, Message.Length-1);

        }
        catch (Exception)
        {

            //throw;
        }
    } 

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ddl"></param>
    /// <param name="ListDo"></param>
    /// 
    //public void FillCombo(System.Web.UI.WebControls.DropDownList ddl, List<BELCombo> ListDo)
    //{
    //    ddl.DataSource = ListDo;
    //    ddl.DataTextField = "Name";
    //    ddl.DataValueField = "Id";
    //    ddl.DataBind();
    //}

    //public void FillRdbCombo(System.Web.UI.WebControls.RadioButtonList Rdb, List<BELCombo> ListDo)
    //{
    //    Rdb.DataSource = ListDo;
    //    Rdb.DataTextField = "Name";
    //    Rdb.DataValueField = "Id";
    //    Rdb.DataBind();
    //}

}
