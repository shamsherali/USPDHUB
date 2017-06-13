using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Configuration;
using System.IO;
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;
using UserFormsBLL;

namespace USPDHUB.Business.MyAccount
{
    public partial class WordContentTemplate : System.Web.UI.Page
    {
        public int UserID = 0;
        public int ProfileID = 0;
        public string RootPath = "";
        public string DomainName = "";

        string fileSavePath = "";
        public string StrhtmlResult = "";

        public string corruptedMessage = ConfigurationManager.AppSettings.Get("CorruptedMSG");
        public string NoContentMessage = ConfigurationManager.AppSettings.Get("NoContentMSG");
        StringBuilder htmlStr = new StringBuilder();

        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userid"] == null)
            {
                string urlinfo = Page.ResolveClientUrl("~/Login.aspx?sflag=1");
                Response.Redirect(urlinfo);
            }
            else
            {
                RootPath = Session["RootPath"].ToString();
                UserID = Convert.ToInt32(System.Web.HttpContext.Current.Session["UserID"]);
                ProfileID = Convert.ToInt32(System.Web.HttpContext.Current.Session["ProfileID"]);
            }




            try
            {
                //Register the license key.
                Spire.License.LicenseProvider.SetLicenseFileName("license.elic.xml");
                Spire.License.LicenseProvider.LoadLicense();
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "WordContentTemplate.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        // Normal browse and upload event
        protected void btnUpload_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (fileupload.HasFile)
                {
                    GC.Collect();

                    string fileFolderPath = Server.MapPath("~") + "\\Upload\\WordContent\\" + ProfileID.ToString();
                    if (!Directory.Exists(fileFolderPath))
                    {
                        Directory.CreateDirectory(fileFolderPath);
                    }
                    string fileExtension = Path.GetExtension(fileupload.FileName).ToLower();
                    string fileName = fileupload.FileName;
                    fileSavePath = "";

                    if (fileExtension == ".doc" || fileExtension == ".docx")
                    {
                        fileSavePath = fileFolderPath + "\\" + fileupload.FileName;
                        fileupload.SaveAs(fileSavePath);
                        fileupload.FileContent.Dispose();

                        StrhtmlResult = "";
                        if (fileExtension == ".doc" || fileExtension == ".docx")
                        {
                            StrhtmlResult = Word_WriteImages_Text(fileSavePath).Trim();
                            if (StrhtmlResult.Trim().Contains("ERRORFORWORDUPLOAD"))
                            {
                                lblerrormsg.Text = "<font color='red'>" + corruptedMessage + "</font>";
                            }
                            else if (StrhtmlResult.Trim() != string.Empty)
                            {
                                //StrhtmlResult = "<table id='maintable' cellpadding=\"2\" cellspacing=\"2\" width=\"460px\" style=\"border: 0px solid gray;min-height: 100px;\" " + StrhtmlResult + "</table>";
                                hdnHTMLResult.Value = StrhtmlResult;
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Javascript", "<script type='text/javascript'>RedirectToParentWindow()</script>", false);

                            }
                            else
                            {
                                lblerrormsg.Text = "<font color='green'>" + NoContentMessage + "</font>";
                            }

                        }

                    }
                    else
                    {
                        lblerrormsg.Text = "<font color='red'>Your file is not in the correct file format; please use .doc,.docx only.</font>";
                    }

                    LoadDropEvents();
                }
                else
                {
                    // lblEditText.Text = "";
                    lblerrormsg.Text = "<font color='red'>Please select a file to upload.</font>";
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "WordContentTemplate.aspx.cs", "btnUpload_OnClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        // After Drag&Drop Render text from PDF Or Word file
        protected void btnUpload1_OnClick(object sender, EventArgs e)
        {
            try
            {
                StrhtmlResult = "";
                string fileFolderPath = Server.MapPath("~") + "\\Upload\\WordContent\\" + ProfileID.ToString();
                fileSavePath = fileFolderPath + "\\" + hdnFileName.Value;

                StrhtmlResult = Word_WriteImages_Text(fileSavePath);

                if (StrhtmlResult.Trim().Contains("ERRORFORWORDUPLOAD"))
                    lblerrormsg.Text = "<font color='red'>" + corruptedMessage + "</font>";
                else if (StrhtmlResult.Trim() != string.Empty)
                {
                    //StrhtmlResult = "<table id='maintable' cellpadding=\"2\" cellspacing=\"2\" width=\"460px\" style=\"border: 0px solid gray;min-height: 100px;\" " + StrhtmlResult + "</table>";
                    hdnHTMLResult.Value = StrhtmlResult;
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Javascript", "<script type='text/javascript'>RedirectToParentWindow()</script>", false);
                }
                else
                {
                    lblerrormsg.Text = "<font color='green'>" + NoContentMessage + "</font>";
                }

                LoadDropEvents();
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "WordContentTemplate.aspx.cs", "btnUpload1_OnClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }


        private void LoadDropEvents()
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Javascript", "<script type='text/javascript'>LoaddropzoneEvents();</script>", false);
        }

        private string Word_WriteImages_Text(string pFilePath)
        {
            try
            {
                htmlStr.Clear();
                string wordFile_FolderPath = ConfigurationManager.AppSettings.Get("USPDFolderPath") + "/Upload/WordContent/" + ProfileID.ToString() + "/WordImages";
                if (!Directory.Exists(wordFile_FolderPath))
                {
                    Directory.CreateDirectory(wordFile_FolderPath);
                }

                Document document = null;
                try
                {
                    document = new Document(pFilePath, Spire.Doc.FileFormat.Txt, XHTMLValidationType.None);
                }
                catch (Exception ex)
                {
                    return htmlStr.Append("ERRORFORWORDUPLOAD").ToString();
                }
                IList<Field> hyperlinks = new List<Field>();

                int index = Convert.ToInt32(DateTime.Now.Day + "" + DateTime.Now.Month + "" + DateTime.Now.Second);

                foreach (Section section in document.Sections)
                {
                    //foreach (Spire.Doc.Table table in section.Tables)
                    //{
                    //  index = LoadWordData(table, index);
                    //}
                    foreach (Paragraph paragraph in section.Paragraphs)
                    {
                        string ParaText = paragraph.Text.Trim();

                        hyperlinks = new List<Field>();
                        if (paragraph.Text.Trim() != string.Empty)
                        {
                            ParaText = ParaText.Replace("/&nbsp;/g", " ");
                            ParaText = ParaText.Replace("/,(?=[^\\s])/g", ", ");

                            foreach (DocumentObject docObject in paragraph.ChildObjects)
                            {
                                if (docObject.DocumentObjectType == DocumentObjectType.Field)
                                {

                                    Field field = docObject as Field;
                                    if (field.Type == FieldType.FieldHyperlink)
                                    {
                                        if (field.FieldText.Trim() != string.Empty)
                                        {
                                            //hyperlinks.Add(field);
                                            //ParaText = ParaText.Replace(field.Text, "####");
                                            ParaText = ParaText.Replace(field.FieldText, "<a target=\"_blank\" href=" + field.Value.ToString() + " >" + field.FieldText + "</a>");
                                            //ParaText = ParaText.Replace("############", "<a href=" + field.Value.ToString() + " style=\"font-weight: bold;\">" + field.FieldText + "</a>");
                                        }
                                    }
                                }
                            }




                            TextAppend(htmlStr, "TEXT", 0, ParaText, string.Empty, index);
                            index++;
                        }

                        string imgName = "";
                        string imgSavePath = "";
                        string imgFullPath = "";
                        foreach (DocumentObject docObject in paragraph.ChildObjects)
                        {
                            if (docObject.DocumentObjectType == DocumentObjectType.Picture)
                            {
                                DocPicture pic = docObject as DocPicture;

                                imgName = DateTime.Now.ToString("yyyyMMddHHmmss") + "" + DateTime.Now.Millisecond + "" + index.ToString() + ".png";
                                imgSavePath = wordFile_FolderPath + "\\" + imgName;
                                pic.Image.Save(imgSavePath, System.Drawing.Imaging.ImageFormat.Png);

                                imgFullPath = RootPath + "/Upload/WordContent/" + ProfileID.ToString() + "/WordImages/" + imgName;

                                TextAppend(htmlStr, "IMAGE", pic.Image.Width, string.Empty, imgFullPath, index);

                                index++;
                            }

                        }
                    }
                }


                document.Close();

            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "WordContentTemplate.aspx.cs", "Word_WriteImages_Text", ex.Message,
               Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

            return htmlStr.ToString();
        }
        private int LoadWordData(Spire.Doc.Table table, int index)
        {
            try
            {
                IList<Field> hyperlinks = new List<Field>();
                string wordFile_FolderPath = Server.MapPath("~") + "\\Upload\\WordContent\\" + ProfileID.ToString() + "\\WordImages";
                foreach (Spire.Doc.TableRow row in table.Rows)
                {
                    for (int i = 0; i <= row.Cells.Count; i++)
                    {
                        foreach (Spire.Doc.Table tablerec in row.Cells[i].Tables)
                        {
                            index = LoadWordData(tablerec, index);
                        }
                        foreach (Paragraph paragraph in row.Cells[i].Paragraphs)
                        {
                            string ParaText = paragraph.Text.Trim();

                            hyperlinks = new List<Field>();
                            if (paragraph.Text.Trim() != string.Empty)
                            {
                                foreach (DocumentObject docObject in paragraph.ChildObjects)
                                {
                                    if (docObject.DocumentObjectType == DocumentObjectType.Field)
                                    {

                                        Field field = docObject as Field;
                                        if (field.Type == FieldType.FieldHyperlink)
                                        {
                                            if (field.FieldText.Trim() != string.Empty)
                                            {
                                                //hyperlinks.Add(field);
                                                //ParaText = ParaText.Replace(field.Text, "####");
                                                ParaText = ParaText.Replace(field.FieldText, "<a target=\"_blank\" href=" + field.Value.ToString() + " >" + field.FieldText + "</a>");
                                                //ParaText = ParaText.Replace("############", "<a href=" + field.Value.ToString() + " style=\"font-weight: bold;\">" + field.FieldText + "</a>");
                                            }
                                        }
                                    }
                                }
                                TextAppend(htmlStr, "TEXT", 0, ParaText, string.Empty, index);
                                index++;
                            }

                            string imgName = "";
                            string imgSavePath = "";
                            string imgFullPath = "";
                            foreach (DocumentObject docObject in paragraph.ChildObjects)
                            {
                                if (docObject.DocumentObjectType == DocumentObjectType.Picture)
                                {
                                    DocPicture pic = docObject as DocPicture;

                                    imgName = DateTime.Now.ToString("yyyyMMddHHmmss") + "" + DateTime.Now.Millisecond + "" + index.ToString() + ".png";
                                    imgSavePath = wordFile_FolderPath + "\\" + imgName;
                                    pic.Image.Save(imgSavePath, System.Drawing.Imaging.ImageFormat.Png);

                                    imgFullPath = RootPath + "/Upload/WordContent/" + ProfileID.ToString() + "/WordImages/" + imgName;

                                    TextAppend(htmlStr, "IMAGE", pic.Image.Width, string.Empty, imgFullPath, index);

                                    index++;
                                }

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "WordContentTemplate.aspx.cs", "LoadWordData", ex.Message,
               Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return index;
        }
        private void TextAppend(StringBuilder htmlStr, string blocktype, int imgWidth, string paragraphText, string imgFullPath, int index)
        {
            try
            {
                if (blocktype == "TEXT")
                {
                    htmlStr.Append("<tr id=\"tr" + index + "\">");
                    htmlStr.Append("<td class=\"drop ui-sortable\" style=\"min-height: 20px;\">");
                    htmlStr.Append("<div id=\"parentedit" + index + "\" style=\"float: left; margin-top: 10px;\" class=\"assigned\" >");
                    htmlStr.Append("<div id='edit" + index + "' style='min-height: 100px; padding: 5px; float: left;' class='textdivStyle' >");
                    htmlStr.Append("<span style='font-weight: normal; font-style: normal; text-decoration: none; color: black; font-size: 16px; font-family:14px; text-align: left; display: block;'>" + paragraphText + "</span>");
                    htmlStr.Append("</div>");
                    htmlStr.Append("<div id='editsection" + index + "' class='editsectionclass' style='float:left;' >");
                    htmlStr.Append("<img src='../../Images/EditText.png'  style='cursor: pointer; margin-left:5px;' onclick='ShowPopup(edit" + index + ")' />");
                    htmlStr.Append("<br/><img class='deleteblockclass'  src='../../Images/Remove.png'  style='cursor: pointer; padding-top: 5px; margin-left:5px;' onclick='RemoveBlock(edit" + index + ")' />");
                    htmlStr.Append("</div>");
                    htmlStr.Append("</div>");
                    htmlStr.Append("</td>");
                    htmlStr.Append("</tr>");
                }
                else if (blocktype == "IMAGE")
                {
                    htmlStr.Append("<tr id=\"tr" + index + "\">");
                    htmlStr.Append("<td class=\"drop ui-sortable\" style=\"min-height: 20px;\">");
                    htmlStr.Append("<div id=\"parentedit" + index + "\" style=\"float: left; margin-top: 10px;\" class=\"assigned\" >");
                    htmlStr.Append("<div id='edit" + index + "' style='min-height: 100px; padding: 5px; float: left;' class='textdivStyle' >");

                    if (imgWidth >= 300)
                    {
                        htmlStr.Append("<img src='" + imgFullPath + "' width='300px' /> ");
                    }
                    else
                    {
                        htmlStr.Append("<img src='" + imgFullPath + "'  /> ");
                    }
                    htmlStr.Append("</div>");
                    htmlStr.Append("<div id='editsection" + index + "' class='editsectionclass' style='float:left;' >");
                    htmlStr.Append("<img  src='../../Images/EditImage.png'  style='cursor: pointer; margin-left:5px;' onclick='EditImage(edit" + index + ")' />");
                    htmlStr.Append("<br/><img class='deleteblockclass'  src='../../Images/Remove.png'  style='cursor: pointer; padding-top: 5px; margin-left:5px;' onclick='RemoveBlock(edit" + index + ")' />");
                    htmlStr.Append("</div>");
                    htmlStr.Append("</div>");
                    htmlStr.Append("</td>");
                    htmlStr.Append("</tr>");
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "WordContentTemplate.aspx.cs", "TextAppend", ex.Message,
               Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }


    }
}