<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" Inherits="Karamasoft.WebControls.UltimateEditor.Explorer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
	<title>UltimateEditor Explorer</title>
	<style>
	body {background-color:#ECE9D8;font-family:Tahoma;font-size:11px}
	input {font-family:Tahoma;font-size:11px}
	.cursordefault {cursor:default}
	.explorerheader {background-color:#ECE9D8;border-bottom:1px solid #ACA899;padding:3px;padding-left:8px}
	.file {background-color:#FFFFFF;color:#00008B;padding:2px;cursor:pointer}
	.fileselect {background-color:#00008B;color:#FFFFFF;padding:2px;cursor:pointer}
	.btndisabled {-moz-opacity:0.25;filter:alpha(opacity=25)}
	.section {margin-top:10px}
	</style>
	<script src="UltimateEditor.explorer.js" type="text/javascript"></script>
</head>
<body onload="Body_OnLoad('<%=ultimateEditorID%>','<%=IncludePath%>','<%=FileSourceID%>','<%=FileSizeID%>','<%=AttachmentFileTypesID%>','<%=FlashFileTypesID%>','<%=ImageFileTypesID%>','<%=LinkFileTypesID%>','<%=TemplateFileTypesID%>','<%=WindowsMediaFileTypesID%>','<%=CreateFolderSubDirsID%>','<%=DeleteSubDirsID%>','<%=FileOverwriteSubDirsID%>','<%=UploadSubDirsID%>','<%=ViewSubDirsID%>','<%=ServerExplorerInitialSubDirID%>','<%=hfNewFolderName.ClientID%>','<%=hfDeletePath.ClientID%>','<%=imgPreview.ClientID%>','frmPreview','<%=ibCreateFolder.ClientID%>','<%=fileToUpload.ClientID%>','<%=btnUpload.ClientID%>','<%=hfPageStatus.ClientID%>','<%=PAGE_STATUS_HIDDEN_IS_SET%>','<%=hfAttachmentFileTypes.ClientID%>','<%=hfFlashFileTypes.ClientID%>','<%=hfImageFileTypes.ClientID%>','<%=hfLinkFileTypes.ClientID%>','<%=hfTemplateFileTypes.ClientID%>','<%=hfWindowsMediaFileTypes.ClientID%>','<%=hfCreateFolderSubDirs.ClientID%>','<%=hfDeleteSubDirs.ClientID%>','<%=hfFileOverwriteSubDirs.ClientID%>','<%=hfUploadSubDirs.ClientID%>','<%=hfViewSubDirs.ClientID%>','<%=hfServerExplorerInitialSubDir.ClientID%>','<%=FileType%>','file','fileselect','btndisabled','<%=EnableViewFilesInDBID%>','<%=EnableUploadFilesInDBID%>','<%=EnableDeleteFilesInDBID%>','<%=EnableOverwriteFilesInDBID%>','<%=hfEnableViewFilesInDB.ClientID%>','<%=hfEnableUploadFilesInDB.ClientID%>','<%=hfEnableDeleteFilesInDB.ClientID%>','<%=hfEnableOverwriteFilesInDB.ClientID%>','<%=FileNameInDatabaseID%>','<%=file.ClientID%>','<%=EnableAmazonS3ID%>','<%=CreateFolderAmazonS3SubDirsID%>','<%=DeleteAmazonS3SubDirsID%>','<%=UploadAmazonS3SubDirsID%>','<%=ViewAmazonS3SubDirsID%>','<%=EnableAmazonS3CreateBucketID%>','<%=EnableAmazonS3DeleteBucketID%>','<%=hfEnableAmazonS3.ClientID%>','<%=hfCreateFolderAmazonS3SubDirs.ClientID%>','<%=hfDeleteAmazonS3SubDirs.ClientID%>','<%=hfUploadAmazonS3SubDirs.ClientID%>','<%=hfViewAmazonS3SubDirs.ClientID%>','<%=hfEnableAmazonS3CreateBucket.ClientID%>','<%=hfEnableAmazonS3DeleteBucket.ClientID%>',<%=IsAmazonS3Root().ToString().ToLower()%>,'<%=btnUploadAmazonS3.ClientID%>','<%=CurrentAmazonS3BaseHref%>','<%=CurrentAmazonS3BucketName%>')">
	<form id="form1" runat="server">
		<asp:PlaceHolder id="phFormContent" runat="server" Visible="false">
			<asp:Label ID="lblCurrentDir" runat="server" Font-Bold="True" CssClass="cursordefault"></asp:Label>
			<table border="1" cellpadding="0" cellspacing="0" bordercolor="#CAC7B9" style="width:100%;margin-top:5px;background-color:#FFFFFF;border-collapse:collapse">
				<tr>
					<td class="explorerheader"><asp:ImageButton ID="ibUpDir" runat="server" ImageUrl="Images/Explorer/up.gif" BorderWidth="0" AlternateText="Up One Level" ToolTip="Up One Level" onmouseover="this.src='Images/Explorer/upover.gif'" onmouseout="this.src='Images/Explorer/up.gif'" OnClick="ibUpDir_Click" /><asp:ImageButton ID="ibCreateFolder" runat="server" ImageUrl="Images/Explorer/create.gif" BorderWidth="0" AlternateText="Create New Folder" ToolTip="Create New Folder" onmouseover="this.src='Images/Explorer/createover.gif'" onmouseout="this.src='Images/Explorer/create.gif'" OnClick="ibCreateFolder_Click" OnClientClick="return CreateFolder_Click();" /><asp:ImageButton ID="ibCreateBucket" runat="server" ImageUrl="Images/Explorer/amazons3createbucket.gif" BorderWidth="0" AlternateText="Create New Bucket" ToolTip="Create New Bucket" onmouseover="this.src='Images/Explorer/amazons3createbucketover.gif'" onmouseout="this.src='Images/Explorer/amazons3createbucket.gif'" OnClick="ibCreateBucket_Click" OnClientClick="return CreateFolder_Click(true);" Visible="false" /><asp:ImageButton ID="ibDelete" runat="server" ImageUrl="Images/Explorer/delete.gif" BorderWidth="0" AlternateText="Delete" ToolTip="Delete" onmouseover="this.src='Images/Explorer/deleteover.gif'" onmouseout="this.src='Images/Explorer/delete.gif'" OnClick="ibDelete_Click" OnClientClick="return Delete_Click();" /></td>
					<td class="explorerheader cursordefault">Preview</td>
				</tr>
				<tr class="cursordefault">
					<td style="width:40%" valign="top">
						 <asp:Panel ID="pnlFolderContent" runat="server" Height="300" Width="100%" style="overflow:auto"></asp:Panel>
					</td>
					<td align="center" style="height:300px">
						<asp:Image ID="imgPreview" runat="server" style="display:none" />
						<iframe id="frmPreview" style="display:none;width:250px;height:250px" onload="TemplatePreview_OnLoad()"></iframe>
					</td>
				</tr>
			</table>
			<fieldset class="section" style="padding:2px">
				<legend>Upload a file to the selected folder?</legend>
				<table border="0" cellpadding="0" cellspacing="0" align="center">
					<tr>
						<td>File to Upload:&nbsp;</td>
						<td><asp:FileUpload ID="fileToUpload" runat="server" Width="340px" size="50" />&nbsp;</td>
						<td><asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" /></td>
					</tr>
				</table>
			</fieldset>
			<div align="center" class="section">
				<asp:Button ID="btnOK" runat="server" Text="Select File" Width="100px" OnClientClick="OK_Click();return false;" />
				<asp:Button ID="btnCancel" runat="server" Text="Close Window" Width="100px" OnClientClick="Cancel_Click();return false;" />
			</div>
		</asp:PlaceHolder>
		<span style="display:none"><asp:Button ID="btnChangeDir" runat="server" Text="Button" OnClick="btnChangeDir_Click" /></span>
		<asp:HiddenField ID="hfPageStatus" runat="server" Value="" />
		<asp:HiddenField ID="hfCurrentDir" runat="server" />
		<asp:HiddenField ID="hfNewFolderName" runat="server" />
		<asp:HiddenField ID="hfDeletePath" runat="server" />
		<asp:HiddenField ID="hfAttachmentFileTypes" runat="server" />
		<asp:HiddenField ID="hfFlashFileTypes" runat="server" />
		<asp:HiddenField ID="hfImageFileTypes" runat="server" />
		<asp:HiddenField ID="hfLinkFileTypes" runat="server" />
		<asp:HiddenField ID="hfTemplateFileTypes" runat="server" />
		<asp:HiddenField ID="hfWindowsMediaFileTypes" runat="server" />
		<asp:HiddenField ID="hfCreateFolderSubDirs" runat="server" />
		<asp:HiddenField ID="hfDeleteSubDirs" runat="server" />
		<asp:HiddenField ID="hfFileOverwriteSubDirs" runat="server" />
		<asp:HiddenField ID="hfUploadSubDirs" runat="server" />
		<asp:HiddenField ID="hfViewSubDirs" runat="server" />
		<asp:HiddenField ID="hfServerExplorerInitialSubDir" runat="server" />
		<asp:HiddenField ID="hfEnableViewFilesInDB" runat="server" />
		<asp:HiddenField ID="hfEnableUploadFilesInDB" runat="server" />
		<asp:HiddenField ID="hfEnableDeleteFilesInDB" runat="server" />
		<asp:HiddenField ID="hfEnableOverwriteFilesInDB" runat="server" />
		<asp:HiddenField ID="hfEnableAmazonS3" runat="server" />
		<asp:HiddenField ID="hfCreateFolderAmazonS3SubDirs" runat="server" />
		<asp:HiddenField ID="hfDeleteAmazonS3SubDirs" runat="server" />
		<asp:HiddenField ID="hfUploadAmazonS3SubDirs" runat="server" />
		<asp:HiddenField ID="hfViewAmazonS3SubDirs" runat="server" />
		<asp:HiddenField ID="hfEnableAmazonS3CreateBucket" runat="server" />
		<asp:HiddenField ID="hfEnableAmazonS3DeleteBucket" runat="server" />
	</form>
	<asp:PlaceHolder ID="phUploadAmazonS3" runat="server" Visible="false">
	<form id="formUploadAmazonS3" action="" method="post" enctype="multipart/form-data">
		<input type="hidden" id="key" runat="server" />
		<input type="hidden" id="acl" runat="server" />
		<input type="hidden" id="success_action_redirect" runat="server" />
		<input type="hidden" id="AWSAccessKeyId" runat="server" />
		<input type="hidden" id="policy" runat="server" />
		<input type="hidden" id="signature" runat="server" />
		<input type="file" id="file" runat="server" size="50" style="position:absolute;left:-1000px;top:-1000px;width:340px;" />
		<input type="submit" id="btnUploadAmazonS3" runat="server" style="position:absolute;left:-1000px;top:-1000px" value="Upload" />
	</form>
	</asp:PlaceHolder>
</body>
</html>
