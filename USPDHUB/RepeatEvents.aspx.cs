using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;

namespace USPDHUB
{
    public partial class RepeatEvents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {

                    txtStartDate.Text = "09/04/2014";
                    txtEndDate.Text = "09/07/2014";
                    chkRepeat.Checked = true;
                    hdnAlreadyRepeat.Value = "1";
                    string str3Items = "0##SP##5##SP##09/04/2014";
                    hdn3Itemsold.Value = str3Items;
                    string strEndsOn = "2##SP##09/07/2015";
                    hdnEndOnold.Value = strEndsOn;
                    hdnRepeatOnold.Value = "0,0,0,0,0,0,0,0";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "javascript", "javascript: ShowPublish(1,1);", true);
                }
                catch (Exception ex)
                {

                    InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                    /*** Error Log ***/
                    objInBuiltData.ErrorHandling("ERROR", "RepeatEvents.aspx.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
                        Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                }
            }
        }
    }
}