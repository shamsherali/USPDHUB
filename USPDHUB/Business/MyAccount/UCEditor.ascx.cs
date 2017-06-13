using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using USPDHUBBLL;

namespace USPDHUB.Business.MyAccount
{
    public partial class UCEditor : System.Web.UI.UserControl
    {
        BusinessBLL busobj = new BusinessBLL();
        public int ProfileID = 0;


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["ProfileID"] != null)
                {
                    ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());
                }
                else
                {
                    if (Request.QueryString["pid"] != null)
                        ProfileID = Convert.ToInt32(EncryptDecrypt.DESDecrypt(Request.QueryString["pid"].ToString()));
                }


                if (!IsPostBack)
                {
                    //Font-Family Profile Base
                    DataTable dtProfileAddress = new DataTable();
                    dtProfileAddress = busobj.GetProfileDetailsByProfileID(ProfileID);
                    if (dtProfileAddress.Rows.Count > 0 && Convert.ToString(dtProfileAddress.Rows[0]["FontFamily"]) != "")
                    {
                        hdnUserFont.Value = Convert.ToString(dtProfileAddress.Rows[0]["FontFamily"]);
                    }
                }
            }
            catch (Exception ex)
            {
                //Error 
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                objInBuiltData.ErrorHandling("ERROR", "UCEditor.ascx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
    }
}