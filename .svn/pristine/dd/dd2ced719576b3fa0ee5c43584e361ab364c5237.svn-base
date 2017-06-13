using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using USPDHUBBLL;

namespace USPDHUB
{
    public partial class PlayVideo : System.Web.UI.Page
    {
        CommonBLL objCommonBll = new CommonBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {


                if (Request.QueryString["vplayid"] != null)
                {
                    ltrVideo.Text = objCommonBll.GetPlayerVideoById(Convert.ToInt32(Request.QueryString["vplayid"]));
                }
                //ltrVideo.Text = "<iframe width=\"560\" height=\"315\" src=\"//www.youtube.com/embed/leCsVj8SKyk\" frameborder=\"0\" allowfullscreen></iframe>";//"<iframe id = \"Iframe1\" width=\"420\" height=\"315\" frameborder=\"0\" src=\"//www.youtube.com/embed/cWuvnc6u93A\" allowfullscreen></iframe>";
            }

            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "PlayVideo.aspx.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
    }
}