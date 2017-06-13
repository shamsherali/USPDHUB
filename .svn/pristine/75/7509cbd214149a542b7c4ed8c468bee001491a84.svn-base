using System;
using System.Data;
using System.Configuration;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using stescodes;
using autoupdate;
using System.Text;

namespace USPDHUB
{
    public partial class Import : System.Web.UI.Page
    {
        CommonBLL objCommon = new CommonBLL();
        protected string shortUrl = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.Attributes.Add("enctype", "multipart/form-data");

        }
        protected void CSVSubmit1_Click(object sender, EventArgs e)
        {
            try
            {

                string strvalue = txtImport.Text;
                Regex urlRegEx = new Regex("http(s)?://([\\w+?\\.\\w+])+([a-zA-Z0-9\\~\\!\\@\\#\\$\\%\\^\\&amp;\\*\\(\\)_\\-\\=\\+\\\\/\\?\\.\\:\\;\'\\,]*)?", RegexOptions.IgnoreCase);
                MatchCollection urls = urlRegEx.Matches(strvalue);
                foreach (Match url in urls)
                {
                    shortUrl = objCommon.longurlToshorturl(Convert.ToString(url));

                    if (string.IsNullOrEmpty(shortUrl))
                        shortUrl = Convert.ToString(url);
                    strvalue = strvalue.Replace(Convert.ToString(url), "<a target='_blank' href='" + shortUrl + "'>" + shortUrl + "</a>");
                }
                ltrHtml.Text = strvalue;
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "Import.aspx.cs", "CSVSubmit1_Click", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        //protected void CSVSubmit_Click(object sender, EventArgs e)
        //{
        //    string str = txtImport.Text;
        //    int headerempty = 0;
        //    string fileext = string.Empty;
        //    if (FileUpload1.HasFile)
        //    {
        //        DataTable dt = new DataTable();
        //        CSVReader reader = new CSVReader(FileUpload1.PostedFile.InputStream);
        //        string[] headers = reader.GetCsvLine();

        //        DataTable dtheaders = new DataTable();
        //        dtheaders.Columns.Add("Select");
        //        DataRow drcon1 = dtheaders.NewRow();
        //        drcon1["Select"] = "------- Select Appropriate Item ------";
        //        dtheaders.Rows.Add(drcon1);
        //        //add headers 
        //        foreach (string strHeader in headers)
        //        {
        //            if (strHeader == "")
        //                headerempty = 1;
        //            dtheaders.Rows.Add(strHeader.Trim());
        //            dt.Columns.Add(strHeader.Trim());
        //        }
        //        string[] data;
        //        string strIds = "";
        //        StringBuilder strbuilder = new StringBuilder();
        //        while ((data = reader.GetCsvLine()) != null)
        //        {

        //            if (!strIds.Contains(data[1].ToString()))
        //            {
        //                strbuilder.Append("INSERT into tblVenues(VenueId, VenueName, StoreID, RetailerId,Color) VALUES (" + data[1].ToString() + ", '" + data[5].ToString() + "'," + data[4].ToString() + "," + data[2].ToString() + ",'" + data[6].ToString() + "')\r\n\r\n");
        //                //strbuilder.Append("IF EXISTS(SELECT 1 FROM tblStores where StoreId= " + data[2].ToString() + ")\r\nBEGIN\r\nINSERT into tblVenues(VenueId, VenueName, StoreID, RetailerId,Color) VALUES (" + data[3].ToString() + ", '" + data[4].ToString() + "'," + data[2].ToString() + "," + data[1].ToString() + ",'" + data[0].ToString() + "')\r\nEND\r\n\r\n");
        //                dt.Rows.Add(data);
        //            }
        //            strIds = strIds + data[1].ToString() + ",";
        //        }
        //        txtImport.Text = strbuilder.ToString();
        //    }
        //}
    }
}