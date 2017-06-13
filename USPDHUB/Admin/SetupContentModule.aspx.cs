using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.Data;
using System.Web.Services;

namespace USPDHUB.Admin
{
    public partial class SetupContentModule : System.Web.UI.Page
    {
        BusinessBLL busobj = new BusinessBLL();

        public bool IsContacts = true;
        public bool IsMedia = true;
        public bool Update = true;
        public bool IsUpdate = true;
        public bool Event = true;
        public bool IsEvent = true;
        public bool MobileApp = true;
        public bool IsMobileApp = true;
        public bool IsBulletins = true;
        public bool Bulletins = true;
        public bool Media = true;
        public bool Contacts = true;
        public bool Messages = true;
        public bool PushNotifications = true;
        public bool Surveys = true;

        public int ProfileID = 0;
        public int UserID = 0;
        public int CUserID = 0;

        public string MemID = "";
        public string MemPID = "";
        public string CID = "";


        public string RootPath = "";
        public string DomainName = "";
        public string DomainNameenc = "";

        AgencyBLL agencyobj = new AgencyBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // *** Chcking for user session ***
                if (Session["UserID"] == null || Session["ProfileID"] == null)
                {
                    string urlinfo = Page.ResolveClientUrl("~/Login.aspx?sflag=1");
                    Response.Redirect(urlinfo);
                }
                else
                {
                    UserID = Convert.ToInt32(Session["UserID"].ToString());
                    MemID = EncryptDecrypt.DESEncrypt(UserID.ToString());
                    ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());
                    MemPID = EncryptDecrypt.DESEncrypt(ProfileID.ToString());
                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                        CUserID = Convert.ToInt32(Session["C_USER_ID"]);
                    else
                        CUserID = UserID;
                    CID = EncryptDecrypt.DESEncrypt(CUserID.ToString());
                }
                // *** Get Domain Name *** //
                DomainName = Session["VerticalDomain"].ToString();
                DomainNameenc = EncryptDecrypt.DESEncrypt(DomainName);
                RootPath = Session["RootPath"].ToString();

                if (!IsPostBack)
                {
                    hdnModuleTemplateID.Value = "0";
                    DataTable dtCustomModuleTemplates = agencyobj.GetCustomModuleTemplates(DomainName, true); // *** Get only content template *** //
                    if (dtCustomModuleTemplates.Rows.Count == 1)
                    {
                        hdnModuleTemplateID.Value = Convert.ToString(dtCustomModuleTemplates.Rows[0]["ModuleID"]);
                        DataTable dtStoreItems = busobj.GetStoreItems("Store", DomainName);
                        string filterRows = "Type='AddOn'";
                        DataRow[] drAddOn = dtStoreItems.Select(filterRows);
                        if (drAddOn.Length > 0)
                            hdnAddOnName.Value = Convert.ToString(drAddOn[0]["Title"]);
                    }
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SetupContentModule.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void lnkNext_Click(object sender, EventArgs e)
        {
            try
            {
                pnlTemplates.Style.Add("display", "none");
                pnlNameandTab.Style.Add("display", "none");
                pnlProgress.Style.Add("display", "block");
                int module = 0;
                string manageUrl = "/Business/MyAccount/" + WebConstants.ManageUrl_CalendarAddOns;
                bool isHasChilds = false;
                string buttonType = WebConstants.Tab_CalendarAddOns;
                if (ddlModuleType.SelectedValue == WebConstants.Purchase_ContentAddOns)
                {
                    module = Convert.ToInt32(hdnModuleTemplateID.Value);
                    manageUrl = "/Business/MyAccount/" + WebConstants.ManageUrl_ContentAddOns;
                    isHasChilds = true;
                    buttonType = WebConstants.Tab_ContentAddOns;
                }
                string appIcon = Convert.ToString(hdnModuleAppButton.Value);
                string tabName = Convert.ToString(hdnModuleAppName.Value);
                busobj.InsertUserCustomModules(ProfileID, UserID, CUserID, module, appIcon, tabName, true, DateTime.Now, DateTime.Now,
                    DateTime.Now.AddYears(1), manageUrl, isHasChilds, buttonType, ddlModuleType.SelectedValue.ToString());
                System.Threading.Thread.Sleep(3000);
                pnlProgress.Style.Add("display", "none");
                pnlSuccess.Style.Add("display", "block");
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SetupContentModule.aspx.cs", "lnkNext_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        public class AppIcons
        {
            public string AppIcon { get; set; }
            public string ModuleID { get; set; }
            public string ImagePath { get; set; }
        }
        [WebMethod(EnableSession = true)]
        public static AppIcons[] BindAppIcons(string moduleID)
        {
            List<AppIcons> details = new List<AppIcons>();
            try
            {
                string rootPath = HttpContext.Current.Session["RootPath"].ToString();
                DataTable dtAppIcons = new DataTable();

                string domainName = HttpContext.Current.Session["VerticalDomain"].ToString();
                AgencyBLL agencyobj = new AgencyBLL();

                moduleID = "0";
                dtAppIcons = agencyobj.GetCustomModuleAppIcons(Convert.ToInt32(moduleID), domainName, false);
                foreach (DataRow dtrow in dtAppIcons.Rows)
                {
                    AppIcons appIcon = new AppIcons();
                    appIcon.AppIcon = dtrow["AppIcon"].ToString();
                    appIcon.ModuleID = moduleID;
                    appIcon.ImagePath = rootPath + "/Images/CustomModulesAppIcons/" + dtrow["AppIcon"].ToString() + ".png"; ;
                    details.Add(appIcon);
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SetupContentModule.aspx.cs", "BindAppIcons", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return details.ToArray();
        }

        protected void lnkBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/CustomerServiceNew.aspx?SearchSelectedValue=" + Request.QueryString["SearchSelectedValue"] + "&SearchInputValue=" + Request.QueryString["SearchInputValue"]);
        }


    }
}