using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Xml.Linq;
using HtmlAgilityPack;
using System.IO;
using Winnovative.WnvHtmlConvert;
using System.Configuration;
using System.Drawing;
using System.Net;
using System.Text;
using System.Security.Cryptography;

namespace DataTransferSevice
{
    public partial class datatransfer : System.Web.UI.Page
    {
        static string uspdFolderPath = @"";
        static string connectionString = @"";

        static string updateID = "";
        static string SkipedUpdateIDs = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


            }
        }
        public void SkipUpdatesHandling(string updateID, string profileID)
        {
            uspdFolderPath = ConfigurationManager.AppSettings.Get("FolderPath"); ;
            string strLogFile = "";
            string errorLogFolder = uspdFolderPath + "\\SkipUpdatesLog\\";

            if (!Directory.Exists(errorLogFolder))
            {
                Directory.CreateDirectory(errorLogFolder);
            }

            strLogFile = errorLogFolder + DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "_ErrorLog.txt";

            StreamWriter oSW;
            if (File.Exists(strLogFile))
            {
                oSW = new StreamWriter(strLogFile, true);
            }
            else
            {
                oSW = File.CreateText(strLogFile);
            }

            oSW.WriteLine("================================" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "================================");
            oSW.WriteLine(" ");
            oSW.WriteLine("Update ID : " + updateID);
            oSW.WriteLine(" ");
            oSW.WriteLine("Profile ID : " + profileID);
            oSW.WriteLine(" ");

            oSW.Close();

        }


        public void CreateImage(string path, int profileID, int userID, int bulletinID, string html)
        {
            // *** Convert to image ***//
            string strhtml = html;
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(strhtml.ToString());
            ImgConverter imgConverter = new ImgConverter();
            MemoryStream msval = new MemoryStream(buffer);
            imgConverter.LicenseKey = ConfigurationManager.AppSettings.Get("imgkeyval");
            imgConverter.PageWidth = 650;
            string saveFilePath = path + "\\" + profileID.ToString();
            if (!System.IO.Directory.Exists(saveFilePath))
            {
                System.IO.Directory.CreateDirectory(saveFilePath);
            }
            string savelocation = saveFilePath + "\\" + bulletinID.ToString() + ".jpg";
            string tempimagepath = path + "\\" + profileID.ToString() + "\\" + profileID.ToString() + userID.ToString() + ".jpg";
            if (File.Exists(savelocation))
            {
                File.Delete(savelocation);
            }
            imgConverter.SaveImageFromHtmlStreamToFile(msval, Encoding.UTF8, System.Drawing.Imaging.ImageFormat.Jpeg, tempimagepath);
            msval = null;
            buffer = null;

            // *** Creating Thmb image *** //
            string srcfile = tempimagepath;
            string destfile = savelocation;
            int thumbWidth = 350;
            System.Drawing.Image image = System.Drawing.Image.FromFile(srcfile);
            int srcWidth = image.Width;
            int srcHeight = image.Height;
            Decimal sizeRatio = ((Decimal)srcHeight / srcWidth);
            int thumbHeight = Decimal.ToInt32(sizeRatio * thumbWidth);
            Bitmap bmp = new Bitmap(thumbWidth, thumbHeight);
            System.Drawing.Graphics gr = System.Drawing.Graphics.FromImage(bmp);
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            gr.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            System.Drawing.Rectangle rectDestination = new System.Drawing.Rectangle(0, 0, thumbWidth, thumbHeight);
            gr.DrawImage(image, rectDestination, 0, 0, srcWidth, srcHeight, GraphicsUnit.Pixel);
            bmp.Save(destfile);
            bmp.Dispose();
            image.Dispose();
            if (File.Exists(tempimagepath))
            {
                File.Delete(tempimagepath);
            }
        }

        public string longurlToshorturl(string longurl)
        {
            string shortURL = "";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://www.googleapis.com/urlshortener/v1/url");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            try
            {
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = "{\"longUrl\":\"" + longurl + "\"}";
                    streamWriter.Write(json);
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var responseText = streamReader.ReadToEnd();
                    shortURL = responseText.Split(',')[1].ToString().Substring(9);
                    shortURL = shortURL.Replace("\"", "");
                }
                return shortURL;
            }
            catch (Exception ex)
            {
                //ErrorHandling("ERROR ", "CommonBLL.cs", "longurlToshorturl", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return shortURL;
            }
        }

        public string DESEncrypt(string stringToEncrypt)// Encrypt the content
        {
            string sEncryptionKey = "01234567890123456789";
            byte[] key = { };
            byte[] iV = { 10, 20, 30, 40, 50, 60, 70, 80 };
            byte[] inputByteArray; //Convert.ToByte(stringToEncrypt.Length) 

            try
            {
                key = Encoding.UTF8.GetBytes(sEncryptionKey.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                inputByteArray = Encoding.UTF8.GetBytes(stringToEncrypt);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(key, iV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }
            catch
            {
                return (string.Empty);
            }
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            uspdFolderPath = ConfigurationManager.AppSettings.Get("FolderPath"); ;

            try
            {
                connectionString = ConfigurationManager.AppSettings.Get("DBConnection");
                // Getting Data Updates Rows
                SqlConnection sqlCon = new SqlConnection(connectionString);
                sqlCon.Open();

                //


                string[] pIDsValue = ConfigurationManager.AppSettings.Get("PIDs").ToString().Split(',');
                string[] uIDsValue = ConfigurationManager.AppSettings.Get("UIDs").ToString().Split(',');

                for (int i = 0; i < pIDsValue.Length; i++)
                {
                    SkipUpdatesHandling("pIDsValue[0]::" + pIDsValue[i].ToString(), "uIDsValue[0]: " + uIDsValue[i]);

                    string _ProfileID = pIDsValue[i].ToString();
                    string _UserID = uIDsValue[i].ToString();


                    if (_ProfileID != "")
                    {

                        string _DominName = ConfigurationManager.AppSettings.Get("DomainName");

                        // Getting details of T_PurchaseAddOns
                        string purchaseAddOns_InsertQuery = "INSERT INTO T_PurchaseAddOns(ProfileID,UserID,PurchaseAddOns,SoldAddOns,CreatedDate,CreatedUser,ModifiedDate,ModifiedUser)" +
                                                            "VALUES('" + _ProfileID + "','" + _UserID + "','1','1','" + DateTime.Now + "','" + _UserID + "','" + DateTime.Now + "','" + _UserID + "')";


                        SqlCommand cmd = new SqlCommand("SELECT * FROM T_PurchaseAddOns WHERE ProfileID=" + _ProfileID + "", sqlCon);
                        DataTable DTpURCHAS = new DataTable("dtAppSettings");
                        SqlDataAdapter sqlAdptr = new SqlDataAdapter(cmd);
                        sqlAdptr.Fill(DTpURCHAS);

                        if (DTpURCHAS.Rows.Count > 0)
                        {

                        }
                        else
                        {
                            cmd = new SqlCommand(purchaseAddOns_InsertQuery, sqlCon);
                            cmd.ExecuteNonQuery();
                        }


                        // Default Buttons
                        cmd = new SqlCommand("USP_InsertDefaultAppButtons", sqlCon);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ProfileID", _ProfileID);
                        cmd.Parameters.AddWithValue("@UserID", _UserID);
                        cmd.Parameters.AddWithValue("@DomainName", _DominName);
                        cmd.Parameters.AddWithValue("@CUserID", _UserID);
                        cmd.ExecuteNonQuery();
                        //

                        // Tab Details
                        cmd = new SqlCommand("SELECT * FROM M_DashboardSettings WHERE User_ID=" + _UserID + "", sqlCon);
                        DataTable dtAppSettings = new DataTable("dtAppSettings");
                        sqlAdptr = new SqlDataAdapter(cmd);
                        sqlAdptr.Fill(dtAppSettings);

                        SkipUpdatesHandling("dtAppSettings.Rows.Count:: " + dtAppSettings.Rows.Count, "");


                        string toolsSettings = Convert.ToString(dtAppSettings.Rows[0]["M_SettingValue"]); //GetSelectedToolsSettings(Convert.ToInt32(dtResult.Rows[i]["User_ID"]), ShowBulletins);
                        var XMLTools = XElement.Parse(toolsSettings, LoadOptions.PreserveWhitespace);
                        bool IsUpdates = Convert.ToBoolean(XMLTools.Element("Tools").Attribute("Updates").Value);


                        string updatesTabName = "";

                        if (XMLTools.Element("Tools").Attribute("UpdatesTabName") == null)
                        {
                            if (_DominName.Contains("uspdhub"))
                            {
                                updatesTabName = "News";
                            }
                            else
                            {
                                updatesTabName = "Updates";
                            }
                        }
                        else
                        {
                            updatesTabName = XMLTools.Element("Tools").Attribute("UpdatesTabName").Value;
                        }
                        //Convert.ToString(XMLTools.Element("Tools").Attribute("UpdatesTabName").Value);

                        // Custom Tab INSERT
                        string customModuleTabs_InsertQuery = "INSERT INTO T_UserCustom_Modules(ProfileID,UserID,AppIcon,TabName,IsActive,CreatedDate,ModifiedDate,CreatedUser,IsVisible,ManageUrl,ModifiedUser,OrderNo,IsDefaultButton,DefaultButtonID,ButtonType)" +
                                                              "VALUES('" + _ProfileID + "','" + _UserID + "','Updates','" + updatesTabName + "','True','" + DateTime.Now + "','" + DateTime.Now + "','" + _UserID + "','" + IsUpdates + "','/Business/MyAccount/ManageAddOns.aspx','" + _UserID + "','6','False',NULL,'AddOn') select @@identity";

                        cmd = new SqlCommand(customModuleTabs_InsertQuery, sqlCon);
                        int _UserCustomModuleID = Convert.ToInt32(cmd.ExecuteScalar());


                        // Get Module Ids from L_CustomModule_Templates
                        cmd = new SqlCommand("SELECT * FROM L_CustomModule_Templates   WHERE Domain='" + _DominName + "' AND TemplateName='Templates' ", sqlCon);
                        DataTable dtModuleDetails = new DataTable("dtAppSettings");
                        sqlAdptr = new SqlDataAdapter(cmd);
                        sqlAdptr.Fill(dtModuleDetails);
                        string moduleID = Convert.ToString(dtModuleDetails.Rows[0]["ModuleID"]);



                        // Insert into T_ManagePurchaseAddOns            
                        string managePurchaseAdd_InsertQuery = "INSERT INTO T_ManagePurchaseAddOns(UserModuleID,ModuleID,IsActive,CreatedDate,CreatedUser,ModifiedDate,ModifiedUser)" +
                                                               "VALUES('" + _UserCustomModuleID + "','" + moduleID + "','TRUE','" + DateTime.Now + "','" + _UserID + "','" + DateTime.Now + "','" + _UserID + "')";

                        cmd = new SqlCommand(managePurchaseAdd_InsertQuery, sqlCon);
                        cmd.ExecuteNonQuery();


                        // Now bring updates data AND Insert into Custom Modules
                        string query = "select  * from T_BusinessUpdates  WHERE ProfileId=" + _ProfileID;
                        cmd = new SqlCommand(query, sqlCon);
                        DataTable dtUpdates = new DataTable("dtUpdates");
                        sqlAdptr = new SqlDataAdapter(cmd);
                        sqlAdptr.Fill(dtUpdates);


                        string CustomXML = string.Empty;

                        // Checking each row data of Update
                        foreach (DataRow row in dtUpdates.Rows)
                        {
                            // Getting Profile Details By Profile ID

                            updateID = Convert.ToString(row["UpdateId"]);

                            if (_ProfileID != string.Empty)
                            {
                                cmd = new SqlCommand("select * from T_Business_Profiles where Profile_ID=" + _ProfileID, sqlCon);
                                DataTable dtProfileDetails = new DataTable("dtUser");
                                SqlDataAdapter sqlAdptr1 = new SqlDataAdapter(cmd);
                                sqlAdptr1.Fill(dtProfileDetails);

                                if (dtProfileDetails.Rows.Count > 0)
                                {
                                    bool IsArchive = false;
                                    if (Convert.ToBoolean(row["IsArchive"]) == true)
                                    {
                                        IsArchive = true;
                                    }
                                    else
                                    {
                                        IsArchive = false;
                                    }

                                    string ExpiryDate = "NULL";
                                    if (Convert.ToString(row["Expiration_Date"]) != string.Empty)
                                    {
                                        ExpiryDate = "'" + Convert.ToString(row["Expiration_Date"]) + "'";
                                    }

                                    string PublishDate = "NULL";
                                    if (Convert.ToString(row["Publish_Date"]) != string.Empty)
                                    {
                                        PublishDate = "'" + Convert.ToString(row["Publish_Date"]) + "'";
                                    }

                                    string ModifyDate = "NULL";
                                    if (Convert.ToString(row["MODIFIED_DATE"]) != string.Empty)
                                    {
                                        ModifyDate = "'" + Convert.ToString(row["MODIFIED_DATE"]) + "'";
                                    }

                                    string CreatedDate = "NULL";
                                    if (Convert.ToString(row["CREATED_DATE"]) != string.Empty)
                                    {
                                        CreatedDate = "'" + Convert.ToString(row["CREATED_DATE"]) + "'";
                                    }
                                    else
                                    {
                                        CreatedDate = ModifyDate;
                                    }

                                    string CreatedUser = "";
                                    if (Convert.ToString(row["CREATED_USER"]) != string.Empty)
                                    {
                                        CreatedUser = "'" + Convert.ToString(row["CREATED_USER"]) + "'";
                                    }
                                    else
                                    {
                                        CreatedUser = "'" + Convert.ToString(row["MODIFIED_USER"]) + "'";
                                    }

                                    string RootPath = "";

                                    string shortenURL = "";
                                    string List_Description = "";
                                    string Custom_XML = "";
                                    bool IsPhotoCapture = false;
                                    string previewHTML = Convert.ToString(row["UpdatedText"]);
                                    string EditHTML = Convert.ToString(row["Edit_HTML"]);
                                    HtmlDocument doc = new HtmlDocument();
                                    doc.LoadHtml(EditHTML);


                                    string newEditHTML = EditHTML;
                                    string rowHTML = "";
                                    // Edit HTML
                                    if (EditHTML != string.Empty && EditHTML.ToLower().Contains("<table") == true && previewHTML.Contains("<table") == true)
                                    {
                                        // Change old format to new Format Bulletin Drag&Drop
                                        int id = 1;
                                        foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//tr"))
                                        {
                                            HtmlDocument subDocu = new HtmlDocument();
                                            subDocu.LoadHtml(node.InnerHtml);

                                            foreach (HtmlNode Subnode in subDocu.DocumentNode.SelectNodes("//div"))
                                            {
                                                if (Subnode.InnerHtml.ToString().Contains("<span"))
                                                {
                                                    rowHTML = rowHTML + "<tr id=\"tr" + id + "\"><td class=\"drop ui-sortable\" style=\"min-height: 20px;\"> " +
                                                                        "<div class=\"assigned\" id=\"parentedit" + id + "\" style=\"margin-top: 10px; float: left;\">" +
                                                                        "<div class=\"textdivStyle\" id=\"edit" + id + "\" style=\"padding: 5px; float: left; min-height: 100px;\">" + // Next Span Text
                                                                        "" + Subnode.InnerHtml.ToString().Replace("'", "&apos;") + "</div> " +
                                                                        "<div class=\"editsectionclass\" id=\"editsection" + id + "\" style=\"float: left;\">" +
                                                                        "<img style=\"margin-left: 5px; cursor: pointer;\" onclick=\"ShowPopup(edit" + id + ")\" src=\"../../Images/EditText.png\"><br>" +
                             "<img class=\"deleteblockclass\" style=\"padding-top: 5px; margin-left: 5px; cursor: pointer;\" onclick=\"RemoveBlock(edit" + id + ")\" src=\"../../Images/Remove.png\">" +
                                            "</div></div></td></tr>";
                                                }
                                                else
                                                {
                                                    rowHTML = rowHTML + "<tr id=\"tr" + id + "\"><td class=\"drop ui-sortable\" style=\"min-height: 20px;\"> " +
                                                                      "<div class=\"assigned\" id=\"parentedit" + id + "\" style=\"margin-top: 10px; float: left;\">" +
                                                                      "<div class=\"textdivStyle\" id=\"edit" + id + "\" style=\"padding: 5px; float: left; min-height: 100px;\">" + // Next Span Text
                                                                      "" + Subnode.InnerHtml.ToString().Replace("'", "&apos;") + "</div> " +
                                                                      "<div class=\"editsectionclass\" id=\"editsection" + id + "\" style=\"float: left;\">" +
                                                                      "<img style=\"margin-left: 5px; cursor: pointer;\" onclick=\"EditImage(edit" + id + ")\" src=\"../../Images/EditImage.png\"><br>" +
                           "<img class=\"deleteblockclass\" style=\"padding-top: 5px; margin-left: 5px; cursor: pointer;\" onclick=\"RemoveBlock(edit" + id + ")\" src=\"../../Images/Remove.png\">" +
                                          "</div></div></td></tr>";
                                                }
                                                id++;

                                            }// INNER Text && Inner HTML

                                        }// END foreach Main //tr

                                        newEditHTML = "<table width=\"450\" id=\"maintable\" style=\"border: 0px solid gray; border-image: none; min-height: 100px;\" cellspacing=\"2\" " +
                                              " cellpadding=\"2\"> <tbody>" + rowHTML + "</tbody></table>";

                                    }// END ***** CHeck EditHTML   data ===  


                                    string newPreviewHTML = previewHTML;
                                    HtmlDocument previewDoc = new HtmlDocument();
                                    previewDoc.LoadHtml(previewHTML);
                                    string previewROWs = "";
                                    if (previewHTML != string.Empty && previewHTML.ToLower().Contains("<table") == true && previewHTML.Contains("<table") == true)
                                    {
                                        foreach (HtmlNode node in previewDoc.DocumentNode.SelectNodes("//td"))
                                        {
                                            string innerHTML = node.InnerHtml;
                                            if (innerHTML.StartsWith("<span"))
                                            {
                                                innerHTML = innerHTML.Replace("'", "&apos;");
                                                previewROWs = previewROWs + "<tr><td  style=\"width:300px; padding-bottom: 2px; text-align: justify;\">" + innerHTML + "</td></tr>";
                                            }
                                            else
                                            {
                                                previewROWs = previewROWs + "<tr><td  style=\"width:300px; padding-bottom: 2px; text-align: center;\">" + innerHTML + "</td></tr>";
                                            }
                                        }

                                        newPreviewHTML = "<table style=\"margin-left:20px; border:1px solid black;\" border=\"0\"  >" + previewROWs + "</table>";
                                    }
                                    else
                                    {
                                        newPreviewHTML = newPreviewHTML.Replace("'", "&apos;");
                                    }

                                    // Insert QUERy of Bulleitns
                                    // 30 Columns
                                    string bulletinInsertQuery = "INSERT INTO T_Manage_CustomModule (Bulletin_Title,Bulletin_HTML," +
                                                "Bulletin_XML,Created_Date,Created_User," +
                                                "Modified_Date,Modified_User,IsArchive,User_ID," +
                                                "Profile_ID,IsCall,IsPhotoCapture,IsContactUs,IsPublished," +
                                                "Expiration_Date,IsDeleted,Order_No," +
                                                "Publish_Date,Bulletin_Category,Published_By,Rejected_By," +
                                                "Remarks,APRJProcess_Initials,Custom_XML,Printer_Html,Shorten_Url," +
                                                "List_Description,UserModuleID,ModuleID) " +

                                                "VALUES ('" + Convert.ToString(row["UpdateTitle"]).Replace("'", "&apos;") + "','" + newPreviewHTML + "'," +
                                                        "'" + newEditHTML + "'" + "," + CreatedDate + "," + CreatedUser + "," +
                                                        "'" + DateTime.Now + "'," + "'" + row["MODIFIED_USER"] + "','" + IsArchive + "','" + _UserID + "'," +
                                                        "'" + _ProfileID + "','FALSE','FALSE','FALSE','" + row["IsPublic"] + "', " +
                                                          ExpiryDate + ",'0',NULL," +
                                                        PublishDate + ",'Miscellaneous','" + row["Published_By"] + "','" + row["Rejected_By"] + "','" +
                                                        row["Remarks"] + "'," + "'" + row["APRJProcess_Initials"] + "','" + Custom_XML + "','" + row["List_Description"].ToString().Replace("'", "&apos;") + "','" + shortenURL +
                                                        "','" + List_Description + "'," + _UserCustomModuleID + "," + moduleID + ") select @@identity";

                                    cmd = new SqlCommand(bulletinInsertQuery, sqlCon);
                                    int value = Convert.ToInt32(cmd.ExecuteScalar());


                                    // Getting Root Path Based on Vertical
                                    // getting rooth
                                    string Query3 = "SELECT * FROM L_Domain_Configs where domain_ID =(SELECT Domain_ID FROM L_Domains WHERE Domain_Name=(SELECT top(1) Domain_Name FROM L_Country_Verticals WHERE Vertical_Name='" + Convert.ToString(dtProfileDetails.Rows[0]["Vertical_Name"]) + "' AND Country='" + Convert.ToString(dtProfileDetails.Rows[0]["Profile_County"]) + "'))";
                                    cmd = new SqlCommand(Query3, sqlCon);
                                    SqlDataAdapter DACOnfig = new SqlDataAdapter(cmd);
                                    DataTable dtConfigs = new DataTable();
                                    DACOnfig.Fill(dtConfigs);
                                    if (dtConfigs.Rows.Count > 0)
                                    {
                                        for (int k = 0; k < dtConfigs.Rows.Count; k++)
                                        {
                                            if (Convert.ToString(dtConfigs.Rows[k]["Name"]).ToLower() == "Rootpath".ToLower())
                                            {
                                                RootPath = Convert.ToString(dtConfigs.Rows[k]["Value"]).Trim();
                                                break;
                                            }
                                        }
                                    }


                                    //RootPath = GetConfigSettings(profileID, "Paths", "RootPath");
                                    string bulletinURL = RootPath + "/OnlineItem.aspx?CMID=" + DESEncrypt(Convert.ToString(value)).Replace("=", "irhmalli").Replace("+", "irhPASS");
                                    bulletinURL = longurlToshorturl(bulletinURL);

                                    // Update LongURL to Short URL
                                    cmd = new SqlCommand("UPDATE T_Manage_CustomModule SET Shorten_Url='" + bulletinURL + "', Bulletin_Title=replace(Bulletin_Title,'&apos;','''')," +
                                        "Bulletin_HTML=replace(CAST(Bulletin_HTML AS NVARCHAR(MAX)),'&apos;',''''),Bulletin_XML=replace(CAST(Bulletin_XML AS NVARCHAR(MAX)),'&apos;',''''),Printer_Html=replace(CAST(Printer_Html AS NVARCHAR(MAX)),'&apos;','''') WHERE Custom_ID=" + value, sqlCon);
                                    cmd.ExecuteNonQuery();

                                    // Create Bulletin Thumb Image
                                    CreateImage(uspdFolderPath, Convert.ToInt32(_ProfileID), Convert.ToInt32(_UserID), Convert.ToInt32(value), newPreviewHTML);

                                }// END if(dtProfileDetails.Rows.Count>0)
                                else
                                {
                                    SkipedUpdateIDs = SkipedUpdateIDs + "," + updateID;
                                    //SkipUpdatesHandling(updateID, _ProfileID);
                                }

                            } // END profileID !=""
                            else
                            {
                                SkipedUpdateIDs = SkipedUpdateIDs + "," + updateID;
                                //SkipUpdatesHandling(updateID, _ProfileID);
                            }
                        }

                    }
                    //SkipUpdatesHandling(SkipedUpdateIDs, _ProfileID);
                }
            }
            catch (Exception ex)
            {
                string errror = "ErrorMessage::" + Convert.ToString(ex.Message) +
                    " InnerExpection:: " + Convert.ToString(ex.InnerException) + "Stacktrace:: " + Convert.ToString(ex.StackTrace) +
                    " DATA:: " + Convert.ToString(ex.Data);
                SkipUpdatesHandling("ERROR", errror);
            }
        }

    }
}