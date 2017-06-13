using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.Data;
using System.IO;

namespace USPDHUB.Controls
{
    public partial class CommonMasterGallery : System.Web.UI.UserControl
    {
        public int UserID = 0;
        public int C_UserID = 0;
        public int ProfileID = 0;

        CommonBLL objCommon = new CommonBLL();
        public string Permission_Type = string.Empty;
        public int Permission_Value = 0;
        public string RootPath = "";
        public string DomainName = "";
        public string titleName = "";

        USPDHUBBLL.MobileAppSettings objApp = new USPDHUBBLL.MobileAppSettings();

        public string AlbumName = "";
        public string AlbumUniqueName = "";

        public string ImageName = "";
        public string ImageUniqueName = "";
        public string imgExt = "";
        public string ImageCaption = "";

        BusinessBLL objBusinessBLL = new BusinessBLL();
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();

        DataTable dtActiveAlbums = new DataTable();
        DataTable dtGalleryImages = new DataTable();


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "MasterGallery.aspx.cs", "Page_Load", string.Empty, string.Empty, string.Empty, string.Empty);

                if (Session["UserName"] == null)
                    Response.Redirect(Page.ResolveClientUrl("~/login.aspx?sflag=1"));
                else
                {
                    UserID = Convert.ToInt32(Session["UserID"]);
                    if (Session["ProfileID"] != null)
                        ProfileID = Convert.ToInt32(Session["ProfileID"]);

                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                        C_UserID = Convert.ToInt32(Session["C_USER_ID"]);
                    else
                        C_UserID = UserID;
                }
                // *** Get Domain Name *** //
                DomainName = Session["VerticalDomain"].ToString();
                RootPath = Session["RootPath"].ToString();
                titleName = objApp.GetMobileAppSettingTabName(UserID, "Gallery", DomainName);
                //lblTitle.Text = titleName;
                //lblMessage.Text = "";

                if (!IsPostBack)
                {
                    LoadAlbumDetails();
                }

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "MasterGallery.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void LoadAlbumDetails()
        {
            dtActiveAlbums = objBusinessBLL.GetActiveAlbumsByGalleryType(ProfileID, ImageGalleryTypes.MasterGalleryType.ToString());

            // Add Root (Main Parent Folder)

            AddNodes(TVAlbums.Nodes, "True", dtActiveAlbums);
            if (TVAlbums.Nodes.Count > 0)
            {
                // Child Nodes
                AddNodes(TVAlbums.Nodes[0].ChildNodes, "False", dtActiveAlbums);
            }

            TVAlbums.ExpandAll();
            if (TVAlbums.Nodes.Count > 0)
            {
                if (hdnAlbumID.Value == "0")
                {
                    TVAlbums.Nodes[0].Select();

                    TreeNode item = TVAlbums.Nodes[0];
                    hdnAlbumID.Value = item.Value;
                    Session["SelectedNode"] = item.ValuePath;
                    hdnAlbumUniqueName.Value = item.Text;
                    hdnIsParent.Value = "1";
                }
                else
                {
                    if (Session["SelectedNode"] != null)
                    {
                        TreeNode node = TVAlbums.FindNode(Session["SelectedNode"].ToString());
                        //node.Selected = true;
                    }
                }
                LoadGalleryImages();
            }
        }

        private void AddNodes(TreeNodeCollection nodes, string level, System.Data.DataTable dt)
        {
            nodes.Clear();
            string filterExp = string.Format("IsRoot='{0}'", level);
            foreach (System.Data.DataRow r in dt.Select(filterExp))
            {
                TreeNode item = new TreeNode()
                {
                    Text = r["Album_Name"].ToString(),
                    Value = r["Album_ID"].ToString(),

                };
                //this.AddNodes(item.ChildNodes, int.Parse(r[0].ToString()), dt);
                //item. = TVAlbums.Nodes[0] as TreeNode;
                nodes.Add(item);
            }
        }

        protected void TVAlbums_OnSelectedNodeChanged(object sender, EventArgs e)
        {
            var item = TVAlbums.SelectedNode;
            if (item != null)
            {
                Session["SelectedNode"] = item.ValuePath;
                hdnAlbumID.Value = item.Value;
                hdnAlbumUniqueName.Value = item.Text;

                if (item.Parent == null)
                {
                    // This is parent (Root) 
                    hdnIsParent.Value = "1";

                }
                else
                {

                    hdnIsParent.Value = "2";
                    // Child Nodes
                }
                LoadGalleryImages();
            }


        }

        private void LoadGalleryImages()
        {

            dtGalleryImages = objBusinessBLL.GetGalleryImagesByAlbumID(Convert.ToInt32(hdnAlbumID.Value));
            // Bind Images
            dtlistImages.DataSource = dtGalleryImages;
            dtlistImages.DataBind();

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Javascript", "<script type='text/javascript'>displaypanel()</script>", false);

           
        }

        protected void dtlistImages_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            Label imgpreview = e.Item.FindControl("imgpreview") as Label;
            Label lblAlbumUniqueName = e.Item.FindControl("lblImageUniqueName") as Label;
            string previewImgPath = "";
            if (hdnIsParent.Value == "1")
            {
                previewImgPath = RootPath + "/Upload/MasterGallery/" + ProfileID + "/" + imgpreview.Text.Trim();
            }
            else if (hdnIsParent.Value == "2")
            {
                previewImgPath = RootPath + "/Upload/MasterGallery/" + ProfileID + "/" + hdnAlbumUniqueName.Value.ToString() + "/" + imgpreview.Text.Trim();
            }

            imgpreview.Text = "";
            imgpreview.Text = "<IMG border='0' width='150px' height='150px' src=" + previewImgPath + " />";
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            string previewImgPath = "";
            string copyImgPath = "";
            string imgTitle = "";

            foreach (DataListItem row1 in dtlistImages.Items)
            {
                CheckBox chk1 = row1.FindControl("chk") as CheckBox;
                if (chk1.Checked)
                {
                    string imgID = dtlistImages.DataKeys[row1.ItemIndex].ToString();
                    Label lblOrderNo = (Label)row1.FindControl("lblOrderNo");
                    Label lblImageUniqueName = (Label)row1.FindControl("lblImageUniqueName");
                    Label lblimgName = (Label)row1.FindControl("lblimgName");
                    imgTitle = lblimgName.Text;

                    if (hdnIsParent.Value == "1")
                    {
                        previewImgPath = Server.MapPath("~/Upload/MasterGallery/") + ProfileID + "/" + lblImageUniqueName.Text.Trim();
                        copyImgPath = Server.MapPath("~/Upload/AppGallery/") + ProfileID + "/" + lblImageUniqueName.Text.Trim();
                    }
                    else if (hdnIsParent.Value == "2")
                    {
                        previewImgPath = Server.MapPath("~/Upload/MasterGallery/") + ProfileID + "/" + hdnAlbumUniqueName.Value.ToString() + "/" + lblImageUniqueName.Text.Trim();
                        copyImgPath = Server.MapPath("~/Upload/AppGallery/") + ProfileID + "/" + lblImageUniqueName.Text.Trim();
                    }
                    break;
                }
            }

            // Now Selected Image Copy to App Gallery 
            try
            {
                if (File.Exists(previewImgPath))
                {
                    File.Copy(previewImgPath, copyImgPath);
                }

                ImageUniqueName = Path.GetFileName(previewImgPath);
                dtActiveAlbums = objBusinessBLL.GetActiveAlbumsByGalleryType(ProfileID, ImageGalleryTypes.AppGalleryType.ToString());
                int copyAlbumID = 0;
                if (dtActiveAlbums.Rows.Count > 0)
                {
                    copyAlbumID = Convert.ToInt32(dtActiveAlbums.Rows[0]["Album_ID"]);
                }
                objBusinessBLL.InsertGalleryImages(imgTitle, ImageUniqueName, "", copyAlbumID, 0, C_UserID);


                GC.Collect();

                Business.MyAccount.MasterGallery oo = new Business.MyAccount.MasterGallery();
                oo.LoadAlbumDetails();

            }
            catch (Exception /*ex*/)
            {

            }
        }
    }
}