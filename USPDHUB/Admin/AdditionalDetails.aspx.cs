using System;
using System.Data;
using System.Configuration;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.IO;

namespace USPDHUB.Admin
{
    public partial class AdditionalDetails : System.Web.UI.Page
    {
        DataTable dtoptionalDetails = new DataTable();
        AgencyBLL agencyobj = new AgencyBLL();
        public int InquiryId = 0;
        public string Errormsg = string.Empty;
        public string PhotoFileName = string.Empty;
        AdminBLL admnobj = new AdminBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["adminuserid"] == null)
                {
                    string urlinfo = Page.ResolveClientUrl("~/Admin/AdminLogin.aspx?sflag=1");
                    Response.Redirect(urlinfo);
                }

                if (!string.IsNullOrEmpty(Request.QueryString["ID"].ToString()))
                {
                    InquiryId = Convert.ToInt32(EncryptDecrypt.DESDecrypt(Request.QueryString["ID"].ToString()));
                    hdnNotesCnt.Value = Convert.ToString(admnobj.GetNotesCountById(InquiryId));
                    if (!string.IsNullOrEmpty(hdnNotesCnt.Value) && hdnNotesCnt.Value != "0")
                    {
                        lnkNotes.Visible = false;
                        lnkbNotes.Visible = true;
                    }
                }

                if (!IsPostBack)
                {
                    if (InquiryId != 0)
                    {
                        dtoptionalDetails = agencyobj.GetVerifyDetailsById(InquiryId);
                        if (dtoptionalDetails.Rows.Count == 1)
                        {
                            if (!string.IsNullOrEmpty(dtoptionalDetails.Rows[0]["Facebook_Link"].ToString()))
                                txtFacebook.Text = dtoptionalDetails.Rows[0]["Facebook_Link"].ToString();
                            else
                                txtFacebook.Text = "http://";

                            if (!string.IsNullOrEmpty(dtoptionalDetails.Rows[0]["Twitter_Link"].ToString()))
                                txtTwitter.Text = dtoptionalDetails.Rows[0]["Twitter_Link"].ToString();
                            else
                                txtTwitter.Text = "http://";
                            if (!string.IsNullOrEmpty(dtoptionalDetails.Rows[0]["Parent_ProfileID"].ToString()))
                                hdnIsSubAccount.Value = "1";
                        }
                        else
                            txtTwitter.Text = txtFacebook.Text = "http://";

                        Loadlogo(InquiryId);
                    }
                    if (Session["Success"] != null)
                    {
                        lblSuccess.Text = "<font size='2' color='green'>" + Session["Success"] + "</font>";
                        Session["Success"] = null;
                    }
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "AdditionalDetails.aspx.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        public void Loadlogo(int id)
        {
            try
            {
                string logourl = string.Empty;
                dtoptionalDetails = agencyobj.GetVerifyDetailsById(id);
                if (dtoptionalDetails.Rows[0]["Logo"].ToString().Length > 0)
                {
                    logourl = dtoptionalDetails.Rows[0]["Logo"].ToString();
                    hdnphoto.Value = dtoptionalDetails.Rows[0]["Logo"].ToString();
                    string originalfilename = logourl;
                    string extension = System.IO.Path.GetExtension(Server.MapPath(originalfilename));

                    string junk = ".";
                    string[] ret = originalfilename.Split(junk.ToCharArray());
                    string thumbimg1 = ret[0];
                    thumbimg1 = thumbimg1 + "_thumb" + extension;
                    string url = Server.MapPath("~") + "\\Upload\\Inquires\\" + id + "\\" + thumbimg1;
                    FileInfo obj = new FileInfo(url);

                    if (obj.Exists)
                    {
                        string imageDisID = Guid.NewGuid().ToString();
                        logo.ImageUrl = Page.ResolveClientUrl("~/Upload/Inquires/" + id + "/" + thumbimg1 + "?Guid=" + imageDisID);
                        logoimage.Enabled = false;
                        btnLogoDelete.Visible = true;
                        logo.Visible = true;
                        obj = null;
                    }
                    else
                    {
                        logoimage.Enabled = true;
                        btnLogoDelete.Visible = false;
                    }
                }
                else
                {
                    logoimage.Enabled = true;
                    btnLogoDelete.Visible = false;
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "AdditionalDetails.aspx.cs", "Loadlogo", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void lnkcancel_Click(object sender, EventArgs e)
        {
            lblSuccess.Text = "";
            Response.Redirect(Page.ResolveClientUrl("~/Admin/EnquiryDetails.aspx?ID=" + EncryptDecrypt.DESEncrypt(InquiryId.ToString())));
        }

        protected void lnkSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    lblSuccess.Text = string.Empty;

                    if (logoimage.PostedFile != null)
                    {
                        if (logoimage.PostedFile.FileName.ToString().Length > 1)
                        {
                            FileInfo logoobj = new FileInfo(logoimage.PostedFile.FileName);
                            if (logoobj.Extension == ".jpg" || logoobj.Extension == ".JPG" || logoobj.Extension == ".JPEG" || logoobj.Extension == ".jpeg" ||
                                logoobj.Extension == ".GIF" || logoobj.Extension == ".gif" || logoobj.Extension == ".bmp" || logoobj.Extension == ".BMP" ||
                                logoobj.Extension == ".png" || logoobj.Extension == ".PNG")
                            {
                                System.Drawing.Image myImage = System.Drawing.Image.FromStream(logoimage.PostedFile.InputStream);
                                if ((myImage.Height <= 150) && (myImage.Width <= 150))
                                {
                                    UploadAndSaveFile(logoimage, 1);
                                }
                                else
                                    lblSuccess.Text = "<font color=red face=arial size=2><b>Your logo must be less than or equal to 150px X 150px</b>.</font>";
                            }
                            else
                            {
                                Errormsg = Errormsg.ToString() + "Your logo is in an incorrect file format. Please try again.";
                                lblSuccess.Text = "<font color=red face=arial size=2><b>" + Errormsg + "</b></font>";
                            }
                            logoobj = null;
                        }
                    }

                    if (string.IsNullOrEmpty(lblSuccess.Text))
                    {
                        dtoptionalDetails = agencyobj.GetVerifyDetailsById(InquiryId);
                        int i = agencyobj.InsertOptionalDtlsbyId(txtFacebook.Text.Trim(), txtTwitter.Text.Trim(), InquiryId, hdnphoto.Value, true);
                        if (i == 1)
                        {
                            if (dtoptionalDetails.Rows[0]["Facebook_Link"].ToString() == "" || dtoptionalDetails.Rows[0]["Facebook_Link"].ToString() == null || dtoptionalDetails.Rows[0]["Twitter_Link"].ToString() == null || dtoptionalDetails.Rows[0]["Twitter_Link"].ToString() == "")
                                lblSuccess.Text = "<font size='2' color='green'>Additional details have been saved successfully.</font>";
                            else
                                lblSuccess.Text = "<font size='2' color='green'>Additional details have been updated successfully.</font>";
                            Loadlogo(InquiryId);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "AdditionalDetails.aspx.cs", "lnkSubmit_Click", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btnLogoDelete_Click(object sender, EventArgs e)
        {

            DeleteLogo();
            lblSuccess.Text = "<font size='2' color='green'>Logo has been deleted successfully.</font>";
        }

        private void DeleteLogo()
        {
            try
            {
                string strlogoPath = Server.MapPath("~") + "\\Upload\\Inquires\\" + InquiryId + "\\";
                DataTable dtobj = new DataTable();
                string logourl = string.Empty;
                dtobj = agencyobj.GetVerifyDetailsById(InquiryId);
                if (dtobj.Rows.Count == 1)
                {
                    logourl = strlogoPath + dtobj.Rows[0]["logo"].ToString();
                    agencyobj.InsertOptionalDtlsbyId(string.Empty, string.Empty, InquiryId, string.Empty, false);
                    logoimage.Visible = true;
                    logoimage.Enabled = true;
                    string imagename1 = dtobj.Rows[0]["logo"].ToString();

                    string extension = System.IO.Path.GetExtension(Server.MapPath(imagename1));
                    logo.Visible = false;
                    string junk = ".";
                    string[] ret = logourl.Split(junk.ToCharArray());
                    string thumbimg = ret[0];
                    thumbimg = thumbimg + "_thumb" + extension;

                    if (System.IO.File.Exists(logourl))
                    {
                        System.Threading.Thread.Sleep(500);
                        System.IO.File.Delete(logourl);
                    }

                    if (System.IO.File.Exists(thumbimg))
                    {
                        System.Threading.Thread.Sleep(500);
                        File.Delete(thumbimg);
                    }
                    btnLogoDelete.Visible = false;
                }
                Loadlogo(InquiryId);
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "AdditionalDetails.aspx.cs", "DeleteLogo", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void UploadAndSaveFile(FileUpload file, int imagetype)
        {
            try
            {
                string saveFilePath = Server.MapPath("~") + "\\Upload";
                string folderPath = string.Empty;
                if (imagetype == 1) //logo folder
                    folderPath = saveFilePath + "\\Inquires\\" + InquiryId;
                if (!System.IO.Directory.Exists(folderPath))
                {
                    System.IO.Directory.CreateDirectory(folderPath);
                }

                FileInfo logoobj = new FileInfo(file.PostedFile.FileName);
                string logoExtension = logoobj.Extension;
                if (logoExtension == ".bmp" || logoExtension == ".BMP")
                {
                    logoExtension = ".jpg";
                }

                if (!Directory.Exists(Server.MapPath("~") + "\\Upload\\Inquires\\" + InquiryId))
                {
                    Directory.CreateDirectory(Server.MapPath("~") + "\\Upload\\Inquires\\" + InquiryId);
                }
                string fileName1 = Server.MapPath("~") + "\\Upload\\Inquires\\" + InquiryId + "\\" + InquiryId + "_thumb_dummy" + logoExtension;
                System.Drawing.Image myImage = System.Drawing.Image.FromStream(logoimage.PostedFile.InputStream);
                if ((myImage.Height <= 65) || (myImage.Width <= 65))
                {
                    fileName1 = Server.MapPath("~") + "\\Upload\\Inquires\\" + +InquiryId + "\\" + InquiryId + "_thumb" + logoExtension;
                }
                file.SaveAs(fileName1);
                hdnphoto.Value = InquiryId + logoExtension;

                //
                if ((myImage.Height > 65) || (myImage.Width > 65))
                {
                    // Mobile App Logo Size 65*65
                    LogoResize(65, 65, InquiryId, logoExtension);
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "AdditionalDetails.aspx.cs", "UploadAndSaveFile", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            finally
            {
                file.Dispose();
            }
        }

        protected void imgclse_Click(object sender, EventArgs e)
        {
            try
            {
                hdnNotesCnt.Value = Convert.ToString(admnobj.GetNotesCountById(InquiryId));
                if (!string.IsNullOrEmpty(hdnNotesCnt.Value) && hdnNotesCnt.Value != "0")
                {
                    lnkNotes.Visible = false;
                    lnkbNotes.Visible = true;
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "AdditionalDetails.aspx.cs", "imgclse_Click", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void LogoResize(int pWidth, int pHeight, int ProfileID, string logoExtension)
        {
            try
            {
                GC.Collect();
                string dummyFIleName = null;

                // Duplicate Logo Save Path
                dummyFIleName = Server.MapPath("~") + "\\Upload\\Inquires\\" + +ProfileID + "\\" + ProfileID + "_thumb_dummy" + logoExtension;

                // Original Logo Save Path
                string LogoSavePath = Server.MapPath("~") + "\\Upload\\Inquires\\" + +ProfileID + "\\" + ProfileID + "_thumb" + logoExtension;

                if (File.Exists(dummyFIleName))
                {
                    string imageUrl = dummyFIleName;
                    imageUrl = Path.GetFileName(imageUrl);
                    //Read in the width and height 

                    string dummyFileName = "";
                    if (imageUrl.Contains("?"))
                    {
                        var urls = imageUrl.Split('?');
                        dummyFileName = urls[0].ToString();
                    }
                    else
                    {
                        dummyFileName = imageUrl;
                    }

                    imageUrl = "\\Upload\\Inquires\\" + ProfileID + "\\" + dummyFileName;
                    imageUrl = Server.MapPath("~") + imageUrl;

                    Neodynamic.WebControls.ImageDraw.ImageElement uploadedImage;
                    uploadedImage = Neodynamic.WebControls.ImageDraw.ImageElement.FromFile(imageUrl);

                    Neodynamic.WebControls.ImageDraw.Resize actResize = new Neodynamic.WebControls.ImageDraw.Resize();
                    actResize.Width = pWidth;
                    actResize.Height = pHeight;
                    actResize.LockAspectRatio = Neodynamic.WebControls.ImageDraw.LockAspectRatio.None;
                    uploadedImage.Actions.Add(actResize);
                    actResize = null;
                    Neodynamic.WebControls.ImageDraw.ImageDraw imgDraw = new Neodynamic.WebControls.ImageDraw.ImageDraw();

                    imgDraw.Elements.Add(uploadedImage);

                    imgDraw.ImageFormat = Neodynamic.WebControls.ImageDraw.ImageDrawFormat.Jpeg;
                    imgDraw.JpegCompressionLevel = 90;

                    uploadedImage = null;
                    //Now, save the output image on disk

                    imgDraw.Save(LogoSavePath);
                    imgDraw.Dispose();

                }

                // Delete Dummy Logo :: Resize before logo
                if (File.Exists(dummyFIleName))
                {
                    File.Delete(dummyFIleName);
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "AdditionalDetails.aspx.cs", "LogoResize", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
    }
}