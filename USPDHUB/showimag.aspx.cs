using System;
using USPDHUBBLL;

public partial class showimag : System.Web.UI.Page
{
    public string ImageName = string.Empty;

    public CommonBLL objCommonBLL = new CommonBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (Request.QueryString["Na"] != null)
            {
                if (Request.QueryString["Na"].ToString() != "")
                {
                    ImageName = Request.QueryString["Na"].ToString();
                    string RootPath = objCommonBLL.GetConfigSettings(Convert.ToString(Request.QueryString["PID"]), "Paths", "RootPath");
                    ImageName = RootPath + "/tempimages/" + ImageName;
                }
            }
        }
        catch (Exception ex)
        {

            InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
            /*** Error Log ***/
            objInBuiltData.ErrorHandling("ERROR", "showimag.aspx.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
                Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
}
