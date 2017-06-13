using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using USPDHUBBLL;
using System.IO;

namespace USPDHUB.Business.MyAccount
{
    public partial class ManageTipsAudio : System.Web.UI.Page
    {

        public int UserID = 0;
        public int C_UserID = 0;
        public int ProfileID = 0;


        DataTable dtobj = new DataTable();
        BusinessBLL busobj = new BusinessBLL();
        USPDHUBBLL.UtilitiesBLL utlObj = new USPDHUBBLL.UtilitiesBLL();
        public bool CheckMobileApp = true;
        public static DataTable dtpermissions = new DataTable();
        AgencyBLL agencyobj = new AgencyBLL();
        CommonBLL objCommon = new CommonBLL();
        public string RootPath = "";
        public string DomainName = "";

        DataTable dtAudios = new DataTable("dtAudio");

        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
                Response.Redirect(Page.ResolveClientUrl("~/login.aspx?sflag=1"));
            else
            {
                UserID = Convert.ToInt32(Session["UserID"]);
                if (Session["ProfileID"] != null)
                    ProfileID = Convert.ToInt32(Session["ProfileID"]);

                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")  //Added By Venkat...
                    C_UserID = Convert.ToInt32(Session["C_USER_ID"]);
                else
                    C_UserID = UserID;
            }
            // *** Get Domain Name *** //
            DomainName = Session["VerticalDomain"].ToString();
            RootPath = Session["RootPath"].ToString();
            if (!IsPostBack)
            {
                // *** Adding page title and meta keys for page *** //
                DataTable dtConfigPageKeys = objCommon.GetVerticalConfigsByType(DomainName, "VerticalNames");
                if (dtConfigPageKeys.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigPageKeys.Rows)
                    {
                        if (row[0].ToString() == "NameForDisplay")
                            hdnVerticalName.Value = row[1].ToString();
                    }
                }
                //roles & permissions..
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                {
                    hdnPermissionType.Value = objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "AppSettings");
                }

                // Retrive Audio Files
                LoadAudio();
            }
        }

        private void LoadAudio()
        {
            dtAudios = agencyobj.GetAudio_TipsManager(ProfileID, C_UserID, DomainName);
            GrdAudio.DataSource = dtAudios;
            GrdAudio.DataBind();


            foreach (DataRow objROw in dtAudios.Rows)
            {
                if (Convert.ToBoolean(objROw["IsDefault"]) == true && Convert.ToString(objROw["DefaultID"]) != string.Empty)
                {
                    string FolderPath = Server.MapPath("~\\Upload") + "\\TipsManagerAudio\\" + ProfileID;
                    string fileName = objROw["AudioFile"].ToString();
                    if (!File.Exists(FolderPath + "\\" + fileName))
                    {
                        if (!System.IO.Directory.Exists(FolderPath))
                        {
                            System.IO.Directory.CreateDirectory(FolderPath);
                        }

                        //File Copy from domain vertical folder path
                        string oldCopyPath = Server.MapPath("~\\Upload") + "\\TipsManagerAudio\\DefaultAudio\\" + DomainName + "\\" + fileName.Trim();
                        File.Copy(oldCopyPath, FolderPath + "\\" + fileName);
                    }
                    break;
                }
            }
        }

        protected void GrdAudio_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblAudioPlayer = e.Row.FindControl("lblAudioPlayer") as Label;
                Label lblDefaultAudioID = e.Row.FindControl("lblDefaultAudioID") as Label;
                LinkButton btnDelete = e.Row.FindControl("btnDelete") as LinkButton;
                Label lblAudioType = e.Row.FindControl("lblAudioType") as Label;

                Label lblIsDefault = e.Row.FindControl("lblIsDefault") as Label;

                string audioFilePath = "";
                if (lblAudioType.Text.Trim() == "UserAudio")
                {
                    audioFilePath = RootPath + "/Upload/TipsManagerAudio/" + ProfileID + "/" + lblAudioPlayer.Text.Trim();
                }
                else
                {
                    audioFilePath = RootPath + "/Upload/TipsManagerAudio/DefaultAudio/" + DomainName + "/" + lblAudioPlayer.Text.Trim();
                }

                if (lblAudioType.Text.Trim() == "SystemAudio")
                { btnDelete.Text = ""; }

//                string audioControl = @"<object type='application/x-shockwave-flash' id='player1' allowscriptaccess='always' allowfullscreen='true' data='" + audioFilePath + @"' width='200' height='30'><param name='movie' value='" + audioFilePath + @"' />
//                            <param name='FlashVars' value='#MusicColor#&playlistXmlPath=#Playlist#' /><param name='wmode' value='transparent' /></object>";

                string audioControl = "<embed src='" + audioFilePath + "' autoplay='false' autostart='false' >";
                lblAudioPlayer.Text = "";
                lblAudioPlayer.Text = audioControl;

                if (Convert.ToBoolean(lblIsDefault.Text) && lblAudioType.Text.Trim() == "UserAudio")
                {
                    e.Row.BackColor = System.Drawing.Color.Gray;
                }
            }
        }

        protected void BtnUpdate_OnClick(object sender, EventArgs e)
        {
            //Log
            objInBuiltData.ErrorHandling("LOG", "ManageTipsAudio.aspx.cs", "BtnUpdate_OnClick", string.Empty, string.Empty, string.Empty, string.Empty);

            if (AudioFileUpload.PostedFile != null)
            {
                if (AudioFileUpload.PostedFile.FileName.ToString().Length > 1)
                {
                    if (AudioFileUpload.PostedFile.ContentLength <= 2097152)
                    {
                        FileInfo pict1obj = new FileInfo(AudioFileUpload.PostedFile.FileName);
                        if (pict1obj.Extension == ".wav")
                        {
                            try
                            {
                                string FolderPath = Server.MapPath("~\\Upload") + "\\TipsManagerAudio\\" + ProfileID;
                                if (!System.IO.Directory.Exists(FolderPath))
                                {
                                    System.IO.Directory.CreateDirectory(FolderPath);
                                }

                                string audioFileName = AudioFileUpload.FileName.Replace(" ", "");
                                string audioFilePath = FolderPath + "\\" + audioFileName;
                                try
                                {
                                    if (File.Exists(audioFileName))
                                    {
                                        File.Delete(audioFilePath);
                                        GC.Collect();
                                    }
                                }
                                catch //Exception ex
                                { }


                                #region Delete Audio File Previuos Default File

                                if (chkDefaultAudio.Checked)
                                {
                                    var dtSelectedAudio = agencyobj.GetAudio_TipsManager(ProfileID, C_UserID, DomainName);
                                    foreach (DataRow objROw in dtSelectedAudio.Rows)
                                    {
                                        if (Convert.ToBoolean(objROw["IsDefault"]))
                                        {
                                            string FolderPath1 = Server.MapPath("~\\Upload") + "\\TipsManagerAudio\\" + ProfileID;
                                            string fileName = objROw["AudioFile"].ToString();
                                            if (File.Exists(FolderPath1 + "\\" + fileName))
                                            {
                                                File.Delete(FolderPath1 + "\\" + fileName);
                                            }

                                            break;
                                        }
                                    }
                                }

                                #endregion
                                // Upload Audio File to Folder
                                AudioFileUpload.SaveAs(audioFilePath);

                                // DB Updatation
                                agencyobj.Insert_UpdateAudio_TipsManager(0, ProfileID, UserID, txtAudioName.Text.Trim(), audioFileName, chkDefaultAudio.Checked, 0, "UserAudio");

                                lblPhotoMsg.Text = "<font color=green face=arial size=2><b>Your audio file has been uploaded successfully.</b></font>";
                                chkDefaultAudio.Checked = false;

                                txtAudioName.Text = "";

                                LoadAudio();

                            }
                            catch (Exception ex)
                            {
                                //Error 
                                objInBuiltData.ErrorHandling("ERROR", "ManageTipsAudio.aspx.cs", "BtnUpload_Click", ex.Message,
                                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                            }
                            finally
                            {

                            }

                        }
                        else
                        {
                            string errormsg = "<b>Your audio file is not in the correct file format. Please note the audio file requirements and try again.</b>";
                            lblPhotoMsg.Text = "<font color=red face=arial size=2>" + errormsg + "</font>";
                        }
                    }
                    else
                    {
                        lblPhotoMsg.Text = "<font color=red face=arial size=2>Your file was not uploaded because it exceeds the 2 MB size limit.</font>";
                    }
                }
                else
                {
                    lblPhotoMsg.Text = "<font color=red face=arial size=2>Please select a audio file to upload.</font>";
                }
            }
            else
            {
                lblPhotoMsg.Text = "<font color=red face=arial size=2>Please select a audio file to upload.</font>";
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ManageMedia.aspx"));
        }

        protected void btndashboard1_Click(object sender, EventArgs e)
        {
            string urlinfo = Page.ResolveClientUrl("~/Business/Myaccount/Default.aspx");
            Response.Redirect(urlinfo);
        }

        // Change Default Audio File
        protected void btnEdit_OnClick(object sender, EventArgs e)
        {
            LinkButton btnEdit = sender as LinkButton;
            GridViewRow row = (GridViewRow)btnEdit.NamingContainer;
            string AudioID = Convert.ToString(GrdAudio.DataKeys[Convert.ToInt32(row.RowIndex)].Values["AudioID"]);
            string DefaultAudioID = Convert.ToString(GrdAudio.DataKeys[Convert.ToInt32(row.RowIndex)].Values["DefaultID"]);
            string audioFile = Convert.ToString(GrdAudio.DataKeys[Convert.ToInt32(row.RowIndex)].Values["AudioFile"]);
            string AudioType = Convert.ToString(GrdAudio.DataKeys[Convert.ToInt32(row.RowIndex)].Values["AudioType"]);

            // DB Updatation
            agencyobj.Insert_UpdateAudio_TipsManager(Convert.ToInt32(AudioID), Convert.ToInt32(ProfileID), Convert.ToInt32(UserID), string.Empty, audioFile, true, Convert.ToInt32(DefaultAudioID), AudioType);

            LoadAudio();
        }

        // Delete User Audio File
        protected void btnDelete_OnClick(object sender, EventArgs e)
        {
            LinkButton btnDelete = sender as LinkButton;
            GridViewRow row = (GridViewRow)btnDelete.NamingContainer;
            string AudioID = Convert.ToString(GrdAudio.DataKeys[Convert.ToInt32(row.RowIndex)].Values["AudioID"]);

            agencyobj.DeleteAudio_TipsManager(Convert.ToInt32(AudioID));

            lblPhotoMsg.Text = "<font color=red face=arial size=2>This audio file has been deleted successfully.</font>";

            LoadAudio();
        }


    }
}