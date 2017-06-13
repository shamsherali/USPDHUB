using System;
using System.Data;
using USPDHUBBLL;

public partial class OnlineUpdate : System.Web.UI.Page
{
    public int BusinessUpdateID = 0;
    BusinessUpdatesBLL objUpdate = new BusinessUpdatesBLL();
    BusinessBLL bus = new BusinessBLL();
    CommonBLL objCommonBLL = new CommonBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["BID"] != null)
            {
                if (Request.QueryString["BID"].ToString() != "")
                {
                    string businessID = Request.QueryString["BID"].ToString().Replace(" ", "+");
                    businessID = businessID.Replace("irhmalli", "=").Replace("irhPASS","+");
                    int length = businessID.Length;
                    if (businessID[length - 1] != '=')
                    {
                        businessID += '=';
                    }
                    businessID = EncryptDecrypt.DESDecrypt(businessID);
                    BusinessUpdateID = Convert.ToInt32(businessID);
                }
            }
            else
            {
                if (Request.QueryString["TID"] != null && Request.QueryString["TID"] != "")
                    BusinessUpdateID = Convert.ToInt32(EncryptDecrypt.DESDecrypt(Request.QueryString["TID"].ToString()));
            }

            if (!IsPostBack)
            {
                Session["OnlineUpdate"] = "1";
                if (BusinessUpdateID > 0)
                {                    
                    DataTable dtBusinessUpdate = new DataTable();
                    dtBusinessUpdate = objUpdate.UpdateBusinessUpdateDetails(BusinessUpdateID);
                    if (dtBusinessUpdate.Rows.Count > 0)
                    {
                        string title = dtBusinessUpdate.Rows[0]["UpdateTitle"].ToString();
                        int profileID=Convert.ToInt32(dtBusinessUpdate.Rows[0]["ProfileID"]);                        
                        DataTable dtbus = new DataTable();
                        dtbus = bus.GetProfileDetailsByProfileID(profileID);
                        if (dtbus.Rows.Count > 0)
                        {
                            lbl_businessname.Text = "Online Update from " + "<br/><font  align='center' >" + dtbus.Rows[0]["Profile_name"].ToString() + "</font>";
                        }
                        if (title.ToString().Length > 0)
                        {
                            Lbl_Updatetitle.Text = title.ToString();
                        }
                        else
                        {
                            Lbl_Updatetitle.Text = "";
                        }
                        string htmlString = string.Empty;
                        htmlString = dtBusinessUpdate.Rows[0]["UpdatedText"].ToString(); 
                        lblBusinessUpdate.Text = objCommonBLL.ReplaceShortURltoHtmlString(htmlString); ;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblBusinessUpdate.Text = ex.Message;
        }
    }
}
