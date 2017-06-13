using System;
using System.Linq;
using System.Web;
using USPDHUBBLL;

namespace USPDHUB
{
    public partial class Default : System.Web.UI.Page
    {
        CommonBLL objCommon = new CommonBLL();
        public string RootPath = System.Configuration.ConfigurationManager.AppSettings.Get("RootPath");
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string url = HttpContext.Current.Request.Url.AbsoluteUri;

                string domainName = objCommon.CreateDomainUrl(url);
                if (Session["RootPath"] != null)
                {
                    Response.Redirect(Session["RootPath"].ToString() + "/OP/" + domainName);
                }
# if fixme
            string path = HttpContext.Current.Request.Url.AbsolutePath;
            // /TESTERS/Default6.aspx

            string host = HttpContext.Current.Request.Url.Host;
            // localhost

            string sURL = "http://test.uspdhub.com/";
            //string host = new System.Uri(sURL).Host.ToLower();
            //string domain = host.Substring(host.LastIndexOf('.', host.LastIndexOf('.') - 1) + 1);
            // *** google maps v3 to get geolocation latitude and longitude *** //
            string location = "6060 Sunrise Vista Drive,Citrus Heights,California,95610";

            string url = "http://maps.googleapis.com/maps/api/geocode/xml?sensor=false&address=" + location;
            
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            try
            {
                WebResponse response = request.GetResponse();
                XDocument xdoc = XDocument.Load(url);

                // Verify the GeocodeResponse status
                //string status = xdoc.Element("GeocodeResponse").Element("status").Value;
                //ValidateGeocodeResponseStatus(status, address);              

                XElement locationElement = xdoc.Element("GeocodeResponse").Element("result").Element("geometry").Element("location");
                double latitude1 = (double)locationElement.Element("lat");
                double longitude1 = (double)locationElement.Element("lng");
            }
            catch (System.Net.WebException exp)
            {

            }
#endif



            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "Default.aspx.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

        }
    }
}