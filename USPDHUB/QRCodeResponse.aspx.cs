using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.Data;
using System.Configuration;
using USPDHUBDAL;

namespace USPDHUB
{
    public partial class QRCodeResponse : System.Web.UI.Page
    {
        public string AppName = "USPDhub";
        CommonBLL objCommonBLL = new CommonBLL();
        public string StoreUrl = "";

        public string verticalDomain = "";
        public string PID = "";
        public string TypeCode = "";
        public string AppID = "";
        public string VerticalCode = "";
        public string Parent_ProfileID = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {

                    if (Request.QueryString["ProfileID"] != null)
                    {
                        PID = Request.QueryString["ProfileID"];
                    }
                    if (Request.QueryString["ProfyleID"] != null)
                    {
                        PID = Request.QueryString["ProfyleID"];
                    }
                    if (Request.QueryString["Type"] != null)
                    {
                        TypeCode = Request.QueryString["Type"];
                    }

                    if (Request.QueryString["VertycalCode"] != null)
                    {
                        VerticalCode = Request.QueryString["VertycalCode"];
                    }
                    if (Request.QueryString["VerticalCode"] != null)
                    {
                        VerticalCode = Request.QueryString["VerticalCode"];
                    }

                    if (Request.QueryString["PPID"] != null)
                    {
                        Parent_ProfileID = Request.QueryString["PPID"];
                    }
                    if (Request.QueryString["PPYD"] != null)
                    {
                        Parent_ProfileID = Request.QueryString["PPYD"];
                    }

                    BusinessBLL objBusinessBLL = new BusinessBLL();
                    DataTable dtAppDisplayName = new DataTable();
                    DataTable dtAppStoresLinks = new DataTable();

                    if (Parent_ProfileID == string.Empty)
                    {
                        dtAppDisplayName = PrivateModuleDAL.GetAppDisplayName(Convert.ToInt32(PID));
                        dtAppStoresLinks = objBusinessBLL.GetAppStoresLinks(Convert.ToInt32(PID));
                    }
                    else
                    {
                        dtAppDisplayName = PrivateModuleDAL.GetAppDisplayName(Convert.ToInt32(Parent_ProfileID));
                        dtAppStoresLinks = objBusinessBLL.GetAppStoresLinks(Convert.ToInt32(Parent_ProfileID));
                    }
                    /*
                                        if (dtAppDisplayName.Rows.Count > 0)
                                        {
                                            AppName = Convert.ToString(dtAppDisplayName.Rows[0]["App_Name"]);
                                            if (dtAppStoresLinks.Rows.Count > 0)
                                            {
                                                StoreUrl = Convert.ToString(dtAppStoresLinks.Rows[0]["Store_Url"]).Trim();
                                            }

                                        }
                                        else*/

                    if (VerticalCode == "1")
                    {
                        AppName = "USPDhub";
                        StoreUrl = ConfigurationManager.AppSettings["USPDhubAppurl"];
                    }
                    else if (VerticalCode == "3")
                    {
                        AppName = "inSchoolHub";
                        StoreUrl = ConfigurationManager.AppSettings["InSchoolHubAppurl"];
                    }
                    else if (VerticalCode == "4")
                    {
                        AppName = "TwoVieHub";
                        StoreUrl = ConfigurationManager.AppSettings["TwoVieAppurl"];
                    }
                    else if (VerticalCode == "5")
                    {
                        AppName = "MyYouthHub";
                        StoreUrl = ConfigurationManager.AppSettings["MyYouthHubAppurl"];
                    }
                    else
                    {
                        //AppName = "USPDhub";
                        //StoreUrl = ConfigurationManager.AppSettings["USPDhubAppurl"];
                    }

                    if (dtAppDisplayName.Rows.Count > 0 && Parent_ProfileID != string.Empty)
                    {
                        AppName = Convert.ToString(dtAppDisplayName.Rows[0]["App_Name"]);
                        if (dtAppStoresLinks.Rows.Count > 0)
                        {
                            StoreUrl = Convert.ToString(dtAppStoresLinks.Rows[0]["Store_Url"]).Trim();
                        }

                    }

                    string additionalParamter = "";
                    if (Parent_ProfileID.Trim() != string.Empty)
                    { additionalParamter = "&PPID=" + Parent_ProfileID; }

                    hdnAppUrl.Value = AppName + "://?ProfileID=" + PID + "&VerticalCode=" + VerticalCode + "&Type=" + TypeCode + additionalParamter;



                }
                catch (Exception ex)
                {

                }
            }

        }

    }
}