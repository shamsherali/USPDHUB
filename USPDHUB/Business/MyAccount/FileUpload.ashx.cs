using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace USPDHUB.Business.MyAccount
{
    /// <summary>
    /// Summary description for FileUpload
    /// </summary>
    public class FileUpload : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        int mFileSize = 0;
        public void ProcessRequest(HttpContext context)
        {           
            try
            {

                if (context.Request.QueryString["path"] != null && context.Request.QueryString["file"] != null)
                {
                    //for deleting existing File by file name
                    string serverpath = context.Request.QueryString["path"].ToString();
                    string filename = context.Request.QueryString["file"].ToString();
                    serverpath = serverpath + "\\" + filename;

                    if (File.Exists(serverpath))
                    {
                        File.Delete(serverpath);
                    }
                }
                else if (context.Request.QueryString["filepath"] != null && context.Request.QueryString["file"] != null)
                {
                    //for downloading existing File
                    string filepath = context.Request.QueryString["filepath"].ToString();
                    string file = context.Request.QueryString["file"].ToString();

                    if (File.Exists(filepath + "\\" + file))
                    {
                        context.Response.Clear();
                        context.Response.ContentType = "application/octet-stream";
                        context.Response.AddHeader("Content-Disposition", string.Format("attachment; filename=\"{0}\"", file));
                        context.Response.WriteFile(filepath + "\\" + file);
                        context.Response.Flush();
                    }

                }
                else
                {
                    //for uploading new File
                    string serverpath = context.Server.MapPath("~") + "Upload\\Bulletins\\Forms\\";
                    var postedFile = context.Request.Files[0];
                    string filesize = "10";
                    mFileSize = postedFile.ContentLength / 1048576;

                    if (mFileSize <= Convert.ToInt32(filesize))
                    {
                        // Get Server Folder to upload file
                        string foldername = context.Request.QueryString["id"].ToString();
                        serverpath = serverpath + foldername;
                        string savepath = serverpath;
                        string file;

                        //For IE to get file name
                        if (HttpContext.Current.Request.Browser.Browser.ToUpper() == "IE")
                        {
                            string[] files = postedFile.FileName.Split(new char[] { '\\' });
                            file = files[files.Length - 1];

                        }
                        //For Other Browser to get file name
                        else
                        {
                            file = postedFile.FileName;
                        }

                        if (!Directory.Exists(savepath))
                            Directory.CreateDirectory(savepath);

                        string fileDirectory = savepath + "\\" + file;
                        postedFile.SaveAs(fileDirectory);

                        //Set response message
                        string msg = "{";
                        msg += string.Format("error:'{0}',\n", string.Empty);
                        msg += string.Format("upfile:'{0}'\n", file);
                        msg += "}";
                        context.Response.Write(msg);
                    }
                }
            }
            catch (Exception /*ex*/)
            {
                
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}