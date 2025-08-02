// File: App_Code/ControlHelper.cs
using System.Web.UI;
using System.Web.UI.WebControls;

public static class ControlHelper
{
    public static void ResetAllControls(Control parent)
    {
       


            foreach (Control ctrl in parent.Controls)
        {




            if (ctrl is TextBox)
            {
                TextBox txt = (TextBox)ctrl;

                double dummy;
                if (double.TryParse(txt.Text, out dummy))
                {
                    txt.Text = "0";
                }
                else
                {
                    txt.Text = string.Empty;
                }
            }
            else if (ctrl is DropDownList)
            {
                DropDownList ddl = (DropDownList)ctrl;
                if (ddl.Items.Count > 0)
                    ddl.SelectedIndex = 0;
            }
            else if (ctrl is CheckBox)
            {
                ((CheckBox)ctrl).Checked = false;
            }
            else if (ctrl is RadioButton)
            {
              //  ((RadioButton)ctrl).Checked = false;
            }
            else if (ctrl is RadioButtonList)
            {
                ((RadioButtonList)ctrl).ClearSelection();
            }
            else if (ctrl is CheckBoxList)
            {
                ((CheckBoxList)ctrl).ClearSelection();
            }
            else if (ctrl is GridView)
            {
                ((GridView)ctrl).DataSource = null;
                ((GridView)ctrl).DataBind();
            }

            // Recursively reset child controls
            if (ctrl.HasControls())
            {
                ResetAllControls(ctrl);
            }
        }
    }
}
