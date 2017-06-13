using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.IO;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;

using Aurigma.GraphicsMill.Transforms;
using Aurigma.GraphicsMill.Codecs;
using Aurigma.GraphicsMill;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;
using Spire.Doc;
using Spire.Doc.Fields;
using Spire.Doc.Documents;
using Winnovative.WnvHtmlConvert;
namespace CopyPaste_POC
{
    public partial class TestEditor : System.Web.UI.Page
    {
        public string fileSavePath = "";
        public string RootPath = ConfigurationManager.AppSettings.Get("RootPath");


        string result = "";

        public int ProfileID = Convert.ToInt32(ConfigurationManager.AppSettings.Get("PID"));
        public int UserID = Convert.ToInt32(ConfigurationManager.AppSettings.Get("UID"));
        public int TemplateID = Convert.ToInt32(ConfigurationManager.AppSettings.Get("TemplateID"));
        public int CustomModuleTemplateID = Convert.ToInt32(ConfigurationManager.AppSettings.Get("CustomModuleTemplateID"));


        public int C_UserID = 0;
        public string FolderName = "Templates";
        public DataTable dtTabsNames = new DataTable();
        public int UserModuleID = 0;

        public string corruptedMessage = ConfigurationManager.AppSettings.Get("CorruptedMSG");
        public string NoContentMessage = ConfigurationManager.AppSettings.Get("NoContentMSG");

        public string spireDocLincensKey = ConfigurationManager.AppSettings.Get("spire_doc_Licensekey");


        protected void Page_Load(object sender, EventArgs e)
        {
            lblerrormsg.Text = "";

            Session["ProfileID"] = ProfileID;
            Session["RootPath"] = RootPath;
            Session["UserID"] = UserID;

            if (!IsPostBack)
            {
                dtTabsNames = GetProfileTabs(ProfileID);
                DataRow[] rows = dtTabsNames.Select("ButtonType='Bulletins' OR ButtonType='AddOn' OR ButtonType='PrivateAddOn' ");
                if (rows.Length > 0)
                { dtTabsNames = rows.CopyToDataTable(); }

                ddlContentModuleNames.DataSource = dtTabsNames;
                ddlContentModuleNames.DataTextField = "TabName";
                ddlContentModuleNames.DataValueField = "UserModuleID";
                ddlContentModuleNames.DataBind();



            }

            try
            {
                //Register the license key.
                Spire.License.LicenseProvider.SetLicenseFileName("license.elic.xml");
                Spire.License.LicenseProvider.LoadLicense();
                //Spire.License.LicenseProvider.LoadLicense();  
            }
            catch (Exception ex)
            {

            }
        }

        protected void lnkPreview_OnClick(object sender, EventArgs e)
        {
            lblPreviewHTML.Text = hdnPreviewHTML.Value;
            ModalPopupExtender2.Show();
        }

        [System.Web.Services.WebMethod]
        public static string ReplaceShortURltoHmlString(string htmlString)
        {
            //CommonBLL objCommonBll = new CommonBLL();
            //  htmlString = objCommonBll.ReplaceShortURltoHtmlString(htmlString);

            return htmlString;
        }

        // Normal browse and upload event
        protected void btnUpload_OnClick(object sender, EventArgs e)
        {
            if (fileupload.HasFile)
            {
                GC.Collect();

                string fileFolderPath = Server.MapPath("~") + "\\Upload\\Common\\" + ProfileID.ToString();
                if (!Directory.Exists(fileFolderPath))
                {
                    Directory.CreateDirectory(fileFolderPath);
                }
                string fileExtension = Path.GetExtension(fileupload.FileName).ToLower();
                string fileName = fileupload.FileName;
                fileSavePath = "";

                if (fileExtension == ".doc" || fileExtension == ".docx" || fileExtension == ".pdf"
                    || fileExtension == ".jpg" || fileExtension == ".JPG" || fileExtension == ".JPEG"
                    || fileExtension == ".jpeg" || fileExtension == ".GIF" || fileExtension == ".gif"
                    || fileExtension == ".png" || fileExtension == ".PNG")
                {

                    fileSavePath = fileFolderPath + "\\" + fileupload.FileName;
                    fileupload.SaveAs(fileSavePath);
                    fileupload.FileContent.Dispose();

                    result = "";
                    if (fileExtension == ".doc" || fileExtension == ".docx")
                    {
                        result = Word_WriteImages_Text(fileSavePath).Trim();
                        if (result.Trim().Contains("ERROR"))
                        {
                            lblerrormsg.Text = "<font color='red'>" + corruptedMessage + "</font>";
                        }
                        else if (result.Trim() != string.Empty)
                        {
                            result = "<table id='maintable' cellpadding=\"2\" cellspacing=\"2\" width=\"460px\" style=\"border: 0px solid gray;min-height: 100px;\" " + result + "</table>";
                        }
                        else
                        {
                            lblerrormsg.Text = "<font color='green'>" + NoContentMessage + "</font>";
                        }



                        lblEditText.Text = result;
                    }
                    else if (fileExtension == ".pdf")
                    {
                        Session["fileSavePath"] = fileSavePath;
                        pnlPDFOption.Visible = true;
                        //result = PDF_WriteImages_Text(fileSavePath);
                    }
                    else if (fileExtension == ".jpg" || fileExtension == ".JPG" || fileExtension == ".JPEG"
                    || fileExtension == ".jpeg" || fileExtension == ".GIF" || fileExtension == ".gif"
                    || fileExtension == ".png" || fileExtension == ".PNG")
                    {
                        int width = 0;
                        int height = 0;
                        GetImageHeight_Width(fileSavePath, out width, out height);
                        GC.Collect();

                        string rsizeImageSavePath = HttpContext.Current.Server.MapPath("~") + "\\Upload\\Bulletins\\" + FolderName + "\\" + ProfileID.ToString() + "\\" + ProfileID.ToString() + "\\" + fileName;
                        string imgRootPath = RootPath + "/Upload/Bulletins/" + FolderName + "/" + ProfileID.ToString() + "/" + ProfileID.ToString() + "/" + fileName;
                        if (width >= 300)
                        {
                            IMG_Resize(fileSavePath, rsizeImageSavePath, 300, 0, ResizeInterpolationMode.High);
                        }
                        else
                        {
                            fileupload.SaveAs(rsizeImageSavePath);
                        }
                        GC.Collect();

                        StringBuilder imgHtml = new StringBuilder();
                        TextAppend(imgHtml, "IMAGE", 300, string.Empty, imgRootPath, 1);
                        result = imgHtml.ToString();

                        if (result.Trim().Contains("ERROR"))
                        {
                            lblerrormsg.Text = "<font color='red'>" + corruptedMessage + "</font>";
                        }
                        else if (result.Trim() != string.Empty)
                        {
                            result = "<table id='maintable' cellpadding=\"2\" cellspacing=\"2\" width=\"460px\" style=\"border: 0px solid gray;min-height: 100px;\" " + result + "</table>";
                        }
                        else
                        {
                            lblerrormsg.Text = "<font color='green'>" + NoContentMessage + "</font>";
                        }

                        lblEditText.Text = result;

                    }

                }
                else
                {
                    lblerrormsg.Text = "<font color='red'>Your file is not in the correct file format; please use .doc,.docx, .pdf, .jpeg,.jpg,.gif or .png only.</font>";
                }

                LoadDropEvents();
            }
            else
            {
                lblEditText.Text = "";
                lblerrormsg.Text = "<font color='red'>Please select a file to upload.</font>";
            }

        }

        // After Drag&Drop Render text from PDF Or Word file
        protected void btnUpload1_OnClick(object sender, EventArgs e)
        {
            fileSavePath = Server.MapPath("~") + "\\Upload\\Common\\" + ProfileID.ToString() + "\\" + hdnImgName.Value;
            string fileExtension = Path.GetExtension(hdnImgName.Value).ToLower();
            result = "";
            if (fileExtension == ".doc" || fileExtension == ".docx")
            {
                result = Word_WriteImages_Text(fileSavePath);

                if (result.Trim().Contains("ERROR"))
                    lblerrormsg.Text = "<font color='red'>" + corruptedMessage + "</font>";
                else if (result.Trim() != string.Empty)
                    result = "<table id='maintable' cellpadding=\"2\" cellspacing=\"2\" width=\"460px\" style=\"border: 0px solid gray;min-height: 100px;\" " + result + "</table>";
                else
                {
                    lblerrormsg.Text = "<font color='green'>" + NoContentMessage + "</font>";
                }

                lblEditText.Text = result;
            }
            else if (fileExtension == ".pdf")
            {
                Session["fileSavePath"] = fileSavePath;
                //result = PDF_WriteImages_Text(fileSavePath);
                pnlPDFOption.Visible = true;
            }
            else if (fileExtension == ".jpg" || fileExtension == ".JPG" || fileExtension == ".JPEG"
                    || fileExtension == ".jpeg" || fileExtension == ".GIF" || fileExtension == ".gif"
                    || fileExtension == ".png" || fileExtension == ".PNG")
            {
                string rsizeimagepath = Server.MapPath("~") + "\\Upload\\Bulletins\\" + FolderName + "\\" + ProfileID.ToString() + "\\" + ProfileID.ToString() + "\\" + hdnImgName.Value;

                string imgRootPath = RootPath + "/Upload/Bulletins/" + FolderName + "/" + ProfileID.ToString() + "/" + ProfileID.ToString() + "/" + hdnImgName.Value;

                int width = 0;
                int height = 0;
                GetImageHeight_Width(fileSavePath, out width, out height);

                string rsizeImageSavePath = HttpContext.Current.Server.MapPath("~") + "\\Upload\\Bulletins\\" + FolderName + "\\" + ProfileID.ToString() + "\\" + ProfileID.ToString() + "\\" + hdnImgName.Value;

                if (width >= 300)
                {
                    IMG_Resize(fileSavePath, rsizeImageSavePath, 300, 0, ResizeInterpolationMode.High);
                }
                GC.Collect();

                StringBuilder imgHtml = new StringBuilder();
                TextAppend(imgHtml, "IMAGE", width, string.Empty, imgRootPath, 1);
                result = imgHtml.ToString();

                if (result.Trim().Contains("ERROR"))
                    lblerrormsg.Text = "<font color='red'>" + corruptedMessage + "</font>";
                else if (result.Trim() != string.Empty)
                    result = "<table id='maintable' cellpadding=\"2\" cellspacing=\"2\" width=\"460px\" style=\"border: 0px solid gray;min-height: 100px;\" " + result + "</table>";
                else
                {
                    lblerrormsg.Text = "<font color='green'>" + NoContentMessage + "</font>";
                }

                lblEditText.Text = result;


            }

            LoadDropEvents();
        }


        protected void btnProccedPDF_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (Session["fileSavePath"] != null)
                {
                    fileSavePath = Session["fileSavePath"].ToString();
                    Session.Remove("fileSavePath");
                }

                if (RBConvertoContent.Checked)
                {
                    result = PDF_WriteImages_Text(fileSavePath);
                }
                else
                {
                    result = PDF_Convert_Images(fileSavePath);
                }

                result = "<table id='maintable' cellpadding=\"2\" cellspacing=\"2\" width=\"460px\" style=\"border: 0px solid gray;min-height: 100px;\" " + result + "</table>";
                lblEditText.Text = result;

                pnlPDFOption.Visible = false;
                LoadDropEvents();

            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "Editor.aspx.cs", "btnProccedPDF_OnClick()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));

            }
        }

        protected void lnkCancelProcced_OnClick(object sender, EventArgs e)
        {
            pnlPDFOption.Visible = false;
        }

        private string PDF_WriteImages_Text(string pFilePath)
        {
            StringBuilder htmlStr = new StringBuilder();
            try
            {
                int index = 1;
                string imgName = "";
                string imgSavePath = "";
                string imgFullPath = "";
                string pdfText = "";
                string pdfFile_FolderPath = Server.MapPath("~") + "\\Upload\\Common\\" + ProfileID.ToString() + "\\PDFImages";
                if (!Directory.Exists(pdfFile_FolderPath))
                {
                    Directory.CreateDirectory(pdfFile_FolderPath);
                }

                using (PdfReader reader = new PdfReader(pFilePath))
                {
                    iTextSharp.text.Document document = new iTextSharp.text.Document(reader.GetPageSize(1));
                    for (int i = 1; i <= reader.NumberOfPages; i++)
                    {
                        pdfText = pdfText + PdfTextExtractor.GetTextFromPage(reader, i);
                    }
                }

                string[] paragraphs = pdfText.ToString().Split(new string[] { "\n " }, StringSplitOptions.None);
                for (int i = 0; i < paragraphs.Length; i++)
                {
                    if (paragraphs[i].ToString().Trim() != string.Empty)
                    {
                        TextAppend(htmlStr, "TEXT", 0, paragraphs[i].ToString().Trim(), string.Empty, index);
                        index++;
                    }
                }


                try
                {
                    using (PdfReader reader = new PdfReader(pFilePath))
                    {
                        for (int i = 1; i <= reader.NumberOfPages; i++)
                        {
                            PdfReader pdf = new PdfReader(pFilePath);
                            PdfDictionary pg = pdf.GetPageN(i);
                            PdfDictionary res = (PdfDictionary)PdfReader.GetPdfObject(pg.Get(PdfName.RESOURCES));
                            PdfDictionary xobj = (PdfDictionary)PdfReader.GetPdfObject(res.Get(PdfName.XOBJECT));
                            if (xobj != null)
                            {
                                foreach (PdfName name in xobj.Keys)
                                {
                                    PdfObject obj = xobj.Get(name);
                                    if (obj.IsIndirect())
                                    {
                                        PdfDictionary tg = (PdfDictionary)PdfReader.GetPdfObject(obj);
                                        string width = tg.Get(PdfName.WIDTH).ToString();
                                        string height = tg.Get(PdfName.HEIGHT).ToString();
                                        ImageRenderInfo imgRI = ImageRenderInfo.CreateForXObject(new iTextSharp.text.pdf.parser.Matrix(float.Parse(width), float.Parse(height)), (PRIndirectReference)obj, tg);

                                        PdfImageObject image = imgRI.GetImage();
                                        System.Drawing.Image objIMG = image.GetDrawingImage();

                                        imgName = DateTime.Now.ToString("yyyyMMddHHmmss") + "" + DateTime.Now.Millisecond + "" + index.ToString() + ".png";
                                        imgSavePath = pdfFile_FolderPath + "\\" + imgName;
                                        objIMG.Save(imgSavePath, System.Drawing.Imaging.ImageFormat.Png);

                                        imgFullPath = RootPath + "/Upload/Common/" + ProfileID.ToString() + "/PDFImages/" + imgName;

                                        TextAppend(htmlStr, "IMAGE", Int32.Parse(width), string.Empty, imgFullPath, index);
                                        index++;
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }


            }
            catch (Exception ex)
            {
                htmlStr.Append("ERROR");
                throw new Exception { };
            }

            return htmlStr.ToString();
        }

        private string Word_WriteImages_Text(string pFilePath)
        {
            StringBuilder htmlStr = new StringBuilder();
            try
            {

                string wordFile_FolderPath = Server.MapPath("~") + "\\Upload\\Common\\" + ProfileID.ToString() + "\\WordImages";
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
                    return htmlStr.Append("ERROR").ToString();
                }
                IList<Field> hyperlinks = new List<Field>();

                int index = 1;

                foreach (Section section in document.Sections)
                {
                    foreach (Paragraph paragraph in section.Paragraphs)
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
                                            ParaText = ParaText.Replace(field.FieldText, "<a href=" + field.Value.ToString() + " >" + field.FieldText + "</a>");
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

                                imgFullPath = RootPath + "/Upload/Common/" + ProfileID.ToString() + "/WordImages/" + imgName;

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

            }

            return htmlStr.ToString();
        }

        private void TextAppend(StringBuilder htmlStr, string blocktype, int imgWidth, string paragraphText, string imgFullPath, int index)
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
                htmlStr.Append("<img src='Images/EditText.png'  style='cursor: pointer; margin-left:5px;' onclick='ShowPopup(edit" + index + ")' />");
                htmlStr.Append("<br/><img class='deleteblockclass'  src='Images/Remove.png'  style='cursor: pointer; padding-top: 5px; margin-left:5px;' onclick='RemoveBlock(edit" + index + ")' />");
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
                htmlStr.Append("<img  src='Images/EditImage.png'  style='cursor: pointer; margin-left:5px;' onclick='EditImage(edit" + index + ")' />");
                htmlStr.Append("<br/><img class='deleteblockclass'  src='Images/Remove.png'  style='cursor: pointer; padding-top: 5px; margin-left:5px;' onclick='RemoveBlock(edit" + index + ")' />");
                htmlStr.Append("</div>");
                htmlStr.Append("</div>");
                htmlStr.Append("</td>");
                htmlStr.Append("</tr>");
            }
        }

        private string PDF_Convert_Images(string pFilePath)
        {
            StringBuilder htmlStr = new StringBuilder();
            try
            {
                Spire.Pdf.PdfDocument doc = new Spire.Pdf.PdfDocument();
                doc.LoadFromFile(pFilePath);
                for (int i = 0; i < doc.Pages.Count; i++)
                {
                    string pdfFile_FolderPath = Server.MapPath("~") + "\\Upload\\Common\\" + ProfileID.ToString() + "\\PDFImages";
                    if (!Directory.Exists(pdfFile_FolderPath))
                    {
                        Directory.CreateDirectory(pdfFile_FolderPath);
                    }

                    string imgName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".png";
                    int width = 0;
                    int height = 300;
                    using (System.Drawing.Image emf = doc.SaveAsImage(i, Spire.Pdf.Graphics.PdfImageType.Metafile))
                    {
                        GC.Collect();

                        width = emf.Width;
                        emf.Save(pdfFile_FolderPath + "\\" + imgName, ImageFormat.Png);
                    }

                    string new_imgName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".png";

                    IMG_Resize(pdfFile_FolderPath + "\\" + imgName, pdfFile_FolderPath + "\\" + new_imgName, 300, 0, ResizeInterpolationMode.High);


                    string imgRootPath = RootPath + "/Upload/Common/" + ProfileID.ToString() + "/PDFImages/" + new_imgName;
                    TextAppend(htmlStr, "IMAGE", width, string.Empty, imgRootPath, (i + 1));
                }
            }
            catch (Exception ex)
            {
                lblEditText.Text = "";

                ErrorHandling("ERROR ", "Editor.aspx.cs", "PDF_Convert_Images()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                //lblerrormsg.Text = "<font color='red'>Selected file is corrupted. Please choose another file and try again.</font>";
            }


            return htmlStr.ToString();
        }


        private void IMG_Resize(string originalFilePath, string newFilePath, int width, int height, ResizeInterpolationMode interpolationMode)
        {
            string Ext = Path.GetExtension(originalFilePath).ToLower();
            if (Ext == ".png")
            {
                using (var reader = new Aurigma.GraphicsMill.Codecs.PngReader(originalFilePath))
                using (var resize = new Aurigma.GraphicsMill.Transforms.Resize(width, height, interpolationMode, ResizeMode.Resize))
                using (var writer = new Aurigma.GraphicsMill.Codecs.PngWriter(newFilePath))
                {
                    Aurigma.GraphicsMill.Pipeline.Run(reader + resize + writer);
                }
            }
            else if (Ext == ".jpg" || Ext == ".jpeg")
            {
                using (var reader = new Aurigma.GraphicsMill.Codecs.JpegReader(originalFilePath))
                using (var resize = new Aurigma.GraphicsMill.Transforms.Resize(width, height, interpolationMode, ResizeMode.Resize))
                using (var writer = new Aurigma.GraphicsMill.Codecs.JpegWriter(newFilePath))
                {
                    Aurigma.GraphicsMill.Pipeline.Run(reader + resize + writer);
                }
            }
            else if (Ext == ".bmp")
            {
                using (var reader = new Aurigma.GraphicsMill.Codecs.BmpReader(originalFilePath))
                using (var resize = new Aurigma.GraphicsMill.Transforms.Resize(width, height, interpolationMode, ResizeMode.Resize))
                using (var writer = new Aurigma.GraphicsMill.Codecs.BmpWriter(newFilePath))
                {
                    Aurigma.GraphicsMill.Pipeline.Run(reader + resize + writer);
                }
            }
            else if (Ext == ".gif")
            {
                using (var reader = new Aurigma.GraphicsMill.Codecs.GifReader(originalFilePath))
                using (var resize = new Aurigma.GraphicsMill.Transforms.Resize(width, height, interpolationMode, ResizeMode.Resize))
                using (var writer = new Aurigma.GraphicsMill.Codecs.GifWriter(newFilePath))
                {
                    Aurigma.GraphicsMill.Pipeline.Run(reader + resize + writer);
                }
            }
        }

        public void GetImageHeight_Width(string imgPath, out int width, out int height)
        {
            using (FileStream fs = new FileStream(fileSavePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                System.Drawing.Image image = System.Drawing.Image.FromStream(fs);
                width = image.Width;
                height = image.Height;
            }
        }

        private void LoadDropEvents()
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Javascript", "<script type='text/javascript'>LoaddropzoneEvents();</script>", false);
        }


        protected void BtnSave_OnClick(object sender, EventArgs e)
        {
            UserModuleID = Convert.ToInt32(ddlContentModuleNames.SelectedValue);

            string ButtonType = "";
            dtTabsNames = GetProfileTabs(ProfileID);
            DataRow[] rows = dtTabsNames.Select("UserModuleID=" + UserModuleID + "");
            ButtonType = Convert.ToString(rows[0]["ButtonType"]);
            int returnID;
            if (String.Equals(ButtonType, "Bulletins", StringComparison.OrdinalIgnoreCase))
            {
                returnID = InsertBulletinsDetails();
                GenarateThumbnailForApp(returnID, ProfileID, "Bulletins", hdnPreviewHTML.Value);
                CreateImage("Bulletins", ProfileID, UserID, returnID, hdnPreviewHTML.Value);
            }
            else
            {
                returnID = InsertContentDetails();
                GenarateThumbnailForApp(returnID, ProfileID, "CustomModules", hdnPreviewHTML.Value);
                CreateImage("CustomModules", ProfileID, UserID, returnID, hdnPreviewHTML.Value);
            }

            LoadDropEvents();

            lblerrormsg.Text = "<font color='green'>" + txtContentTitle.Text.Trim() + " has been created successfully.</font>";
            lblEditText.Text = "";
            txtContentTitle.Text = "";
        }

        private int InsertBulletinsDetails()
        {
            int bulletinID = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_Insert_Update_BulletinDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Bulletin_ID", 0);
                sqlCmd.Parameters.AddWithValue("@Template_BID", TemplateID);
                sqlCmd.Parameters.AddWithValue("@Bulletin_Title", txtContentTitle.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Bulletin_HTML", hdnPreviewHTML.Value.Trim());
                sqlCmd.Parameters.AddWithValue("@Bulletin_XML", hdnEditHTML.Value.Trim());
                sqlCmd.Parameters.AddWithValue("@Created_User", UserID);
                sqlCmd.Parameters.AddWithValue("@Modified_User", UserID);
                sqlCmd.Parameters.AddWithValue("@IsArchive", 0);
                sqlCmd.Parameters.AddWithValue("@User_ID", UserID);
                sqlCmd.Parameters.AddWithValue("@Profile_ID", ProfileID);
                sqlCmd.Parameters.AddWithValue("@IsCall", false);
                sqlCmd.Parameters.AddWithValue("@IsPhotoCapture", false);
                sqlCmd.Parameters.AddWithValue("@IsContactUs", false);
                sqlCmd.Parameters.AddWithValue("@IsPrivate", false);
                sqlCmd.Parameters.AddWithValue("@Expiration_Date", null);
                sqlCmd.Parameters.AddWithValue("@Publish_Date", DateTime.Now);
                sqlCmd.Parameters.AddWithValue("@Category", "Miscellaneous");
                sqlCmd.Parameters.AddWithValue("@IsPublic", true);
                sqlCmd.Parameters.AddWithValue("@Published_By", UserID);
                sqlCmd.Parameters.AddWithValue("@PrinterHtml", hdnPreviewHTML.Value);
                sqlCmd.Parameters.AddWithValue("@CustomXML", "");
                sqlCmd.Parameters.AddWithValue("@ListDescription", "");
                sqlCmd.Parameters.AddWithValue("@IsDesktopPOC", false);
                bulletinID = Convert.ToInt32(sqlCmd.ExecuteScalar());

                return bulletinID;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        private int InsertContentDetails()
        {
            int returnID = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {

                SqlCommand sqlCmd = new SqlCommand("USP_AddUpdateItem", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Profile_ID", ProfileID);
                sqlCmd.Parameters.AddWithValue("@User_ID", UserID);
                sqlCmd.Parameters.AddWithValue("@Created_User", UserID);
                sqlCmd.Parameters.AddWithValue("@Custom_ID", 0);
                sqlCmd.Parameters.AddWithValue("@CustomModule_ID", UserModuleID);
                sqlCmd.Parameters.AddWithValue("@ModuleID", CustomModuleTemplateID);
                sqlCmd.Parameters.AddWithValue("@Bulletin_Title", txtContentTitle.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Bulletin_HTML", hdnPreviewHTML.Value);
                sqlCmd.Parameters.AddWithValue("@Bulletin_XML", hdnEditHTML.Value);
                sqlCmd.Parameters.AddWithValue("@IsArchive", 0);
                sqlCmd.Parameters.AddWithValue("@IsCall", 0);
                sqlCmd.Parameters.AddWithValue("@IsPhotoCapture", 0);
                sqlCmd.Parameters.AddWithValue("@IsContactUs", 0);
                sqlCmd.Parameters.AddWithValue("@Expiration_Date", null);
                sqlCmd.Parameters.AddWithValue("@IsPublished", 1);
                sqlCmd.Parameters.AddWithValue("@Publish_Date", DateTime.Now);
                sqlCmd.Parameters.AddWithValue("@Published_By", UserID);
                sqlCmd.Parameters.AddWithValue("@PrinterHtml", "");
                sqlCmd.Parameters.AddWithValue("@CustomXML", "");
                sqlCmd.Parameters.AddWithValue("@ListDescription", "");
                returnID = Convert.ToInt32(sqlCmd.ExecuteScalar());

                return returnID;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        private DataTable GetProfileTabs(int pPID)
        {
            DataTable vtable = new DataTable("customMessage");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_m_GetProfileTabsByPID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", pPID);
                sqlCmd.Parameters.AddWithValue("@DeviceID", string.Empty);
                sqlCmd.Parameters.AddWithValue("@AppID", 0);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(vtable);

                return vtable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }

        }
        private void CreateImage(string path, int profileID, int userID, int bulletinID, string html)
        {
            try
            {
                path = ConfigurationManager.AppSettings.Get("USPDhubFolderPath") + "\\" + path + "\\";
                string saveFilePath = path + profileID;
                // *** Convert to image ***//
                string strhtml = html;
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(strhtml.ToString());
                ImgConverter imgConverter = new ImgConverter();
                MemoryStream msval = new MemoryStream(buffer);
                imgConverter.LicenseKey = ConfigurationManager.AppSettings.Get("imgkeyval");
                imgConverter.PageWidth = 650;
                if (!System.IO.Directory.Exists(saveFilePath))
                {
                    System.IO.Directory.CreateDirectory(saveFilePath);
                }
                string savelocation = saveFilePath + "\\" + bulletinID.ToString() + ".jpg";
                string tempimagepath = path + profileID.ToString() + "\\" + profileID.ToString() + userID.ToString() + ".jpg";
                if (File.Exists(savelocation))
                {
                    File.Delete(savelocation);
                }
                imgConverter.SaveImageFromHtmlStreamToFile(msval, Encoding.UTF8, System.Drawing.Imaging.ImageFormat.Jpeg, tempimagepath);
                //msval = null;
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
                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(thumbWidth, thumbHeight);
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
                msval.Flush();
                msval.Close();
                msval.Dispose();
            }
            catch (Exception ex)
            {
                //Error 
                ErrorHandling("ERROR", "Editor.aspx.cs", "CreateImage", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        public void GenarateThumbnailForApp(int moduleID, int profileID, string moduleType, string htmlString)
        {
            try
            {

                string uspdUploadFolderPath = HttpContext.Current.Server.MapPath("~/upload");

                string originalFOlderUSPD = ConfigurationManager.AppSettings.Get("USPDhubFolderPath");
                string thumbVirtualPath = originalFOlderUSPD + "/AppThumbs/" + moduleType + "/" + profileID;

                if (!Directory.Exists(thumbVirtualPath))
                {
                    Directory.CreateDirectory(thumbVirtualPath);
                }

                //List<Uri> links = new List<Uri>();
                string imagePath = "";
                string regexImgSrc = @"<img[^>]*?src\s*=\s*[""']?([^'"" >]+?)[ '""][^>]*?>"; //<\s*?img\s+[^>]*?\s*src\s*=\s*(["'])((\\?+.)*?)\1[^>]*?>
                MatchCollection matchesImgSrc = Regex.Matches(htmlString, regexImgSrc, RegexOptions.IgnoreCase | RegexOptions.Singleline);
                foreach (Match m in matchesImgSrc)
                {
                    imagePath = m.Groups[1].Value;
                    if (imagePath.ToLower().Contains("images/located.png") || imagePath.ToLower().Contains("images/cleared.png"))
                    {

                    }
                    else
                    { break; }
                }

                thumbVirtualPath = thumbVirtualPath + "/" + moduleID + ".jpg";
                try
                {
                    if (File.Exists(thumbVirtualPath))
                    {
                        File.Delete(thumbVirtualPath);
                    }
                }
                catch (Exception /*ex*/)
                { }


                int width = 100;
                int height = 100;

                // Folder Names:: CustomModules   or  Bulletins  or  Events  or CalendarAddOns
                string image = string.Empty;
                image = imagePath;
                if (image == "")   //if image exists in html string
                {
                    /*
                    image = uspdUploadFolderPath + "/Upload/" + moduleType + "/" + profileID + "/" + moduleID + ".jpg";
                    if (File.Exists(image))
                    {
                        //Creating thumbnai
                        System.Drawing.Image img = System.Drawing.Image.FromFile(image);
                        System.Drawing.Image thumb = img.GetThumbnailImage(100, 100, null, IntPtr.Zero);
                        img.Dispose();

                        thumb.Save(thumbVirtualPath);
                    }

                    */
                }
                else
                {

                    string imgName = Path.GetFileName(image);

                    string FOlderPath = imagePath.ToLower().Substring(imagePath.ToLower().LastIndexOf("upload"));
                    FOlderPath = FOlderPath.Replace("upload", "");

                    string imgFullPath = uspdUploadFolderPath + FOlderPath;

                    if (File.Exists(imgFullPath))
                    {
                        //Creating thumbnai
                        System.Drawing.Image img = System.Drawing.Image.FromFile(imgFullPath);
                        System.Drawing.Image thumb = img.GetThumbnailImage(width, height, null, IntPtr.Zero);
                        img.Dispose();

                        thumb.Save(thumbVirtualPath);
                    }

                }

                //imgRootPath = rootPath + "/Upload/AppThumbs/" + moduleType + "/" + profileID + "/" + moduleID + ".jpg?GUID=" + Guid.NewGuid();

            }
            catch (Exception ex)
            {

            }
        }

        public void ErrorHandling(string errorType, string pPageName, string methodName, string message, string strackTrace, string innerException, string data)
        {
            string strLogFile = "";
            string errorLogFolder = HttpContext.Current.Server.MapPath("~") + "\\Upload\\ErrorLog\\";

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
            oSW.WriteLine("Type : " + errorType);
            oSW.WriteLine(" ");
            oSW.WriteLine("Page Name : " + pPageName);
            oSW.WriteLine(" ");
            oSW.WriteLine("Method Name : " + methodName);
            oSW.WriteLine(" ");
            oSW.WriteLine("MESSAGE : " + message);
            oSW.WriteLine(" ");
            oSW.WriteLine("STACKTRACE : " + strackTrace);
            oSW.WriteLine(" ");
            oSW.WriteLine("INNEREXCEPTION : " + innerException);
            oSW.WriteLine(" ");
            oSW.WriteLine("DATA : " + data);
            oSW.WriteLine(" ");
            oSW.Close();

        }

    }
}