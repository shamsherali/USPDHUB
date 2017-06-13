using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using USPDHUBBLL;

public partial class Business_MyAccount_PrintNewsletter : System.Web.UI.Page
{
    DataTable DtNewsletterDetails = new DataTable();
    BulletinBLL objBulleting = new BulletinBLL();
    AddOnBLL objAddon = new AddOnBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                int ID = 0;
                bool isBulletin = true;
                if (!string.IsNullOrEmpty(Request.QueryString["BLID"]) || !string.IsNullOrEmpty(Request.QueryString["CMID"]))
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["BLID"]))
                        ID = Convert.ToInt32(Request.QueryString["BLID"].ToString());
                    else
                    {
                        ID = Convert.ToInt32(Request.QueryString["CMID"].ToString());
                        isBulletin = false;
                    }
                    if (ID > 0)
                    {
                        if (isBulletin)
                            DtNewsletterDetails = objBulleting.GetBulletinDetailsByID(ID);
                        else
                            DtNewsletterDetails = objAddon.GetCustomModuleByID(ID);
                        if (DtNewsletterDetails.Rows.Count > 0)
                        {
                            lblprintnewletter.Text = DtNewsletterDetails.Rows[0]["Printer_Html"].ToString();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "PrintNewsletter.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
    }
    protected void lnkPrint_Click(object sender, EventArgs e)
    {

    }
}
