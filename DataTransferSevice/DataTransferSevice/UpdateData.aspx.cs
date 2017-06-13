using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using HtmlAgilityPack;

namespace DataTransferSevice
{
    public partial class UpdateData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.AppSettings.Get("DBConnection");
            // Getting Data Updates Rows
            SqlConnection sqlCon = new SqlConnection(connectionString);
            sqlCon.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM T_Manage_CustomModule", sqlCon);
            DataTable dtCustomData = new DataTable("dtAppSettings");
            SqlDataAdapter sqlAdptr = new SqlDataAdapter(cmd);
            sqlAdptr.Fill(dtCustomData);

            foreach (DataRow row in dtCustomData.Rows)
            {
                string EditHTML = Convert.ToString(row["Bulletin_XML"]);
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(EditHTML);

                if (EditHTML.StartsWith("<table"))
                {
                    string rowHTML = "";

                    int id = 1;
                    foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//tr"))
                    {
                        HtmlDocument subDocu = new HtmlDocument();
                        subDocu.LoadHtml(node.InnerHtml);

                        if (subDocu.DocumentNode.SelectNodes("//td//div//div") != null)
                        {
                            foreach (HtmlNode Subnode in subDocu.DocumentNode.SelectNodes("//td//div//div").Take(1))
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
                            }
                        }// INNER Text && Inner HTML

                       

                    }// END foreach Main //tr

                    string newEditHTML = "<table width=\"450\" id=\"maintable\" style=\"border: 0px solid gray; border-image: none; min-height: 100px;\" cellspacing=\"2\" " +
                                                   " cellpadding=\"2\"> <tbody>" + rowHTML + "</tbody></table>";

                    // Update LongURL to Short URL
                    cmd = new SqlCommand("UPDATE T_Manage_CustomModule SET Bulletin_XML='" + newEditHTML + "' WHERE Custom_ID=" + Convert.ToInt32(row["Custom_ID"]), sqlCon);
                    cmd.ExecuteNonQuery();

                    // Update LongURL to Short URL
                    cmd = new SqlCommand("UPDATE T_Manage_CustomModule SET Bulletin_XML=replace(CAST(Bulletin_XML AS NVARCHAR(MAX)),'&apos;','''') WHERE Custom_ID=" + Convert.ToInt32(row["Custom_ID"]), sqlCon);
                    cmd.ExecuteNonQuery();
                }

            }
        }
    }
}