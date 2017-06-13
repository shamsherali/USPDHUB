<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
<head id="Head1" runat="server">
<title>UltimateEditor Insert Image</title>
<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
<meta name="CODE_LANGUAGE" Content="C#">
<meta name="vs_defaultClientScript" content="JavaScript">
<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
<style>
.FileTable { background-color:#ECE9D8;font-family:Tahoma;font-size:11px;border-style:solid;border-color:#2457CA;border-width:2px; }
.FileTable TD { font-family:Tahoma;font-size:11px }
.FileTable FIELDSET { padding:7px }
.FileTable INPUT, SELECT { font-family:Tahoma;font-size:11px }
</style>
<script src="UltimateEditor.file.js" type="text/javascript"></script>
</head>
<body onload="Body_OnLoad('<%=Request.QueryString["ii"]%>','<%=Request.QueryString["ft"]%>','<%=Request.QueryString.ToString().Replace("'", "\\'")%>','<%=Request.QueryString["ei"]%>','<%=fileSource.ClientID%>','<%=txtAlt.ClientID%>','<%=ddlImageAlign.ClientID%>','<%=txtBorder.ClientID%>','<%=txtImageWidth.ClientID%>','<%=txtImageHeight.ClientID%>','<%=txtHSpace.ClientID%>','<%=txtVSpace.ClientID%>','<%=txtMediaWidth.ClientID%>','<%=txtMediaHeight.ClientID%>','<%=rbMediaLoopYes.ClientID%>','<%=ddlMediaAlign.ClientID%>','<%=ddlFlashQuality.ClientID%>','<%=txtFlashBackgroundColor.ClientID%>','<%=txtMediaID.ClientID%>','<%=hfFileSize.ClientID%>','divInsertImage','divInsertMedia','trFlashQuality','trFlashBackgroundColor','tblFile','<%=hfFileNameInDatabase.ClientID%>')">
	<form id="Form1" method="post" enctype="multipart/form-data" runat="server">
		<table id="tblFile" class="FileTable" border="0" cellpadding="6" cellspacing="0">
			<tr style="background-color:#2457CA">
				<td style="padding-left:4px;font-family:Tahoma;font-size:11px;font-weight:bold;color:#FFFFFF"><%=Request.QueryString["wt"]%></td>
			</tr>
			<tr>
				<td>
					<fieldset>
						<legend>Browse</legend>
						<table border="0" cellpadding="0" cellspacing="5">
							<tr>
								<td>File:</td>
								<td nowrap><asp:TextBox ID="fileSource" runat="server" size="59"></asp:TextBox><asp:Button ID="btnBrowse" runat="server" Text="Browse..." OnClientClick="Explorer_Click();return false;" /></td>
							</tr>
						</table>
					</fieldset>
					<div id="divInsertImage" style="display:none">
						<fieldset>
							<legend>Accessibility</legend>
							<table border="0" cellpadding="0" cellspacing="5">
								<tr>
									<td nowrap>Alternate text:</td>
									<td><asp:TextBox ID="txtAlt" Runat="Server" EnableViewState="False" style="width:328px" /></td>
								</tr>
							</table>
						</fieldset>
						<table border="0" cellpadding="0" cellspacing="0">
							<tr valign="top">
								<td>
									<fieldset>
										<legend>Layout</legend>
										<table border="0" cellpadding="0" cellspacing="5">
											<tr>
												<td>Alignment:</td>
												<td><asp:DropDownList id="ddlImageAlign" runat="server">
														<asp:ListItem Value="">Not set</asp:ListItem>
														<asp:ListItem Value="left">Left</asp:ListItem>
														<asp:ListItem Value="right">Right</asp:ListItem>
														<asp:ListItem Value="texttop">Texttop</asp:ListItem>
														<asp:ListItem Value="absmiddle">Absmiddle</asp:ListItem>
														<asp:ListItem Value="baseline">Baseline</asp:ListItem>
														<asp:ListItem Value="absbottom">Absbottom</asp:ListItem>
														<asp:ListItem Value="bottom">Bottom</asp:ListItem>
														<asp:ListItem Value="middle">Middle</asp:ListItem>
														<asp:ListItem Value="top">Top</asp:ListItem>
													</asp:DropDownList>
												</td>
												<td style="width:10px">&nbsp;</td>
												<td>Width:</td>
												<td><asp:TextBox ID="txtImageWidth" Runat="Server" style="width:45px" /></td>
											</tr>
											<tr>
												<td nowrap>Border size:</td>
												<td><asp:TextBox ID="txtBorder" Runat="Server" style="width:78px" /></td>
												<td></td>
												<td>Height:</td>
												<td><asp:TextBox ID="txtImageHeight" Runat="Server" style="width:45px" /></td>
											</tr>
										</table>
									</fieldset>
								</td>
								<td style="width:14px">&nbsp;</td>
								<td style="width:150px">
									<fieldset>
										<legend>Spacing</legend>
										<table border="0" cellpadding="0" cellspacing="5">
											<tr>
												<td>Horizontal:</td>
												<td><asp:TextBox ID="txtHSpace" Runat="Server" style="width:45px" /></td>
											</tr>
											<tr>
												<td>Vertical:</td>
												<td><asp:TextBox ID="txtVSpace" Runat="Server" style="width:45px" /></td>
											</tr>
										</table>
									</fieldset>
								</td>
							</tr>
						</table>
					</div>
					<div id="divInsertMedia" style="display:none">
						<fieldset>
							<legend>Properties</legend>
							<table border="0" cellpadding="0" cellspacing="4">
								<tr>
									<td>Width:</td>
									<td><asp:TextBox ID="txtMediaWidth" Runat="Server" Text="200" style="width:45px" /></td>
								</tr>
								<tr>
									<td>Height:</td>
									<td><asp:TextBox ID="txtMediaHeight" Runat="Server" Text="200" style="width:45px" /></td>
								</tr>
								<tr>
									<td>Loop:</td>
									<td>
										<asp:RadioButton ID="rbMediaLoopYes" runat="server" GroupName="MediaLoop" Text="Yes" Checked="true" />&nbsp;
										<asp:RadioButton ID="rbMediaLoopNo" runat="server" GroupName="MediaLoop" Text="No" />
									</td>
								</tr>
								<tr>
									<td>Alignment:</td>
									<td><asp:DropDownList id="ddlMediaAlign" runat="server">
											<asp:ListItem Value="">Not set</asp:ListItem>
											<asp:ListItem Value="left">Left</asp:ListItem>
											<asp:ListItem Value="right">Right</asp:ListItem>
											<asp:ListItem Value="texttop">Texttop</asp:ListItem>
											<asp:ListItem Value="absmiddle">Absmiddle</asp:ListItem>
											<asp:ListItem Value="baseline">Baseline</asp:ListItem>
											<asp:ListItem Value="absbottom">Absbottom</asp:ListItem>
											<asp:ListItem Value="bottom">Bottom</asp:ListItem>
											<asp:ListItem Value="middle">Middle</asp:ListItem>
											<asp:ListItem Value="top">Top</asp:ListItem>
										</asp:DropDownList>
									</td>
								</tr>
								<tr id="trFlashQuality">
									<td>Quality:</td>
									<td><asp:DropDownList id="ddlFlashQuality" runat="server">
											<asp:ListItem Value="best">Best</asp:ListItem>
											<asp:ListItem Value="high" Selected="True">High</asp:ListItem>
											<asp:ListItem Value="medium">Medium</asp:ListItem>
											<asp:ListItem Value="autohigh">Autohigh</asp:ListItem>
											<asp:ListItem Value="autolow">Autolow</asp:ListItem>
											<asp:ListItem Value="low">Low</asp:ListItem>
										</asp:DropDownList>
									</td>
								</tr>
								<tr id="trFlashBackgroundColor">
									<td>Background color:</td>
									<td><asp:TextBox ID="txtFlashBackgroundColor" Runat="Server" Text="#FFFFFF" style="width:60px" /></td>
								</tr>
								<tr>
									<td>ID:</td>
									<td><asp:TextBox ID="txtMediaID" Runat="Server" /></td>
								</tr>
							</table>
						</fieldset>
					</div>
				</td>
			</tr>
			<tr>
				<td align="center">
					<asp:Button ID="btnOK" runat="server" Text="OK" Width="80px" OnClientClick="OK_Click();return false;" />
					<asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="80px" OnClientClick="Cancel_Click();return false;" />
				</td>
			</tr>
		</table>
		<asp:HiddenField ID="hfFileSize" runat="server" />
		<asp:HiddenField ID="hfFileNameInDatabase" runat="server" />
	</form>
</body>
</HTML>
