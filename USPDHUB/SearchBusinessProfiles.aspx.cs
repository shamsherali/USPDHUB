using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using USPDHUBBLL;

namespace USPDHUB
{
    public partial class SearchBusinessProfiles : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
        }
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetProfiles(string prefixText)
        {
            List<string> Profiles = new List<string>();
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["WOWZYDevServer"].ConnectionString);
                con.Open();
                //string query = "select Profile_name+Profile_Zipcode as ProfileSearch,Profile_ID from T_Business_Profiles where Profile_name+Profile_Zipcode LIKE '%" + textToSearch + "%'";
                SqlCommand cmd = new SqlCommand("select Profile_ID, Profile_name from T_Business_Profiles where Profile_name like '%'+@Name+'%'", con);
                cmd.Parameters.AddWithValue("@Name", prefixText);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Profiles.Add(dt.Rows[i][1].ToString());
                }
            }
            catch (Exception ex)
            {

                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "SearchBusinessProfiles.aspx.cs", "GetProfiles", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return Profiles;

        }

    }
}



