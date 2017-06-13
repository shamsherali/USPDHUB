using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using USPDHUBBLL;

namespace USPDHUB
{
    public partial class DataTransfer : System.Web.UI.Page
    {
        CommonBLL objCommon = new CommonBLL();
        public string RootPath = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            try{
            if (Session["RootPath"] != null)
                RootPath = Session["RootPath"].ToString();


            if (!IsPostBack)
            {
                string connectionString = @"Data Source=SERVER\SQLEXPRESS;Initial Catalog=USPDHUB;User Id=uspdhub;Password=uspdhub";

                // Getting Data
                SqlConnection sqlCon = new SqlConnection(connectionString);
                string query = "select  top(1) * from T_BusinessUpdates order by 1 desc ";
                SqlCommand cmd = new SqlCommand(query, sqlCon);
                DataTable dtUpdates = new DataTable("dtUpdates");
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(cmd);
                sqlAdptr.Fill(dtUpdates);
                sqlCon.Dispose();
                sqlCon.Close();



                sqlCon = new SqlConnection(connectionString);
                sqlCon.Open();
                string bulletinTemplateID = "32";
                string CustomXML = string.Empty;

                foreach (DataRow row in dtUpdates.Rows)
                {
                    string profileID = Convert.ToString(row["ProfileId"]);
                    cmd = new SqlCommand("select User_ID from T_Business_Profiles where Profile_ID=" + profileID, sqlCon);
                    DataTable dtUser = new DataTable("dtUser");
                    SqlDataAdapter sqlAdptr1 = new SqlDataAdapter(cmd);
                    sqlAdptr1.Fill(dtUser);
                    string UserID = Convert.ToString(dtUser.Rows[0]["User_ID"]);

                    bool IsPrivate = false;
                    if (Convert.ToBoolean(row["IsPublic"]) == true)
                    {
                        IsPrivate = false;
                    }
                    else
                    {
                        IsPrivate = true;
                    }

                    string shortenURL = "";
                    string List_Description = "";
                    string Custom_XML = "";
                    bool IsPhotoCapture = false;
                    string previewHTML = Convert.ToString(row["UpdatedText"]).Replace("'", "\"");
                    string EditHTML = Convert.ToString(row["Edit_HTML"]).Replace("'", "\"");



                    // 30 Columns
                    string bulletinInsertQuery = "INSERT INTO T_Manage_Bulletins1 (Template_BID,Bulletin_Title,Bulletin_HTML," +
                                "Bulletin_XML,Created_Date,Created_User," +
                                "Modified_Date,Modified_User,IsArchive,User_ID," +
                                "Profile_ID,IsCall,IsPhotoCapture,IsContactUs,IsPublished," +
                                "IsPrivate,Expiration_Date,IsDeleted,Order_No," +
                                "Publish_Date,Bulletin_Category,Published_By,Rejected_By," +
                                "Remarks,APRJProcess_Initials,Custom_XML,Printer_Html,Shorten_Url," +
                                "List_Description,IsDesktopPOC) " +

                                "VALUES ('" + bulletinTemplateID + "' ,'" + Convert.ToString(row["UpdateTitle"]) + "','" + previewHTML + "'," +
                                        "'" + EditHTML + "'" + ",'" + row["CREATED_DATE"] + "','" + row["CREATED_USER"] + "'," +
                                        "'" + row["MODIFIED_DATE"] + "'," + "'" + row["MODIFIED_USER"] + "','" + row["IsArchive"] + "','" + UserID + "'," +
                                        "'" + profileID + "','" + row["IsCall"] + "','" + IsPhotoCapture + "','" + row["IsContactUs"] + "','" + row["IsPublic"] + "', '" +
                                        IsPrivate + "'," + "'" + row["Expiration_Date"] + "','" + row["IsDeleted"] + "','" + row["Order_No"] + "','" +
                                        row["Publish_Date"] + "','Miscellaneous','" + row["Published_By"] + "','" + row["Rejected_By"] + "','" +
                                        row["Remarks"] + "'," + "'" + row["APRJProcess_Initials"] + "','" + Custom_XML + "','" + row["List_Description"] + "','" + shortenURL +
                                        "','" + List_Description + "','" + row["IsDesktopPOC"] + "') select @@identity";

                    cmd = new SqlCommand(bulletinInsertQuery, sqlCon);
                    int value = Convert.ToInt32(cmd.ExecuteScalar());

                    string bulletinURL = RootPath + "/OnlineBulletin.aspx?BLID=" + EncryptDecrypt.DESEncrypt(Convert.ToString(value)).Replace("=", "irhmalli").Replace("+", "irhPASS");

                    bulletinURL = objCommon.longurlToshorturl(bulletinURL);
                    objCommon.UpdateShortenURl(value, bulletinURL, "BULLETINS");


                }
            }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "DataTransfer.aspx.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
    }
}