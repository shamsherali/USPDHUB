<%@ Page Title="" Language="C#" MasterPageFile="~/AdminHome.master" AutoEventWireup="true"
    CodeBehind="EditAppOrderStatus.aspx.cs" Inherits="USPDHUB.Admin.EditAppOrderStatus" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <link href="../css/reveal.css" rel="stylesheet" type="text/css" />
    <asp:ScriptManager ID="smgr1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="lnkSave" />
            <asp:PostBackTrigger ControlID="btnDownloadLogo" />
            <asp:PostBackTrigger ControlID="btnDownloadAppIcon" />
            <asp:PostBackTrigger ControlID="btnlogoDownload" />
            <asp:PostBackTrigger ControlID="btnappDownload" />
            <asp:PostBackTrigger ControlID="btDownloadAppStoreIcon" />
            <asp:PostBackTrigger ControlID="btnDowloadPrintableAppStoreIcon" />
            <asp:PostBackTrigger ControlID="btnDownloadIOS" />
            <asp:PostBackTrigger ControlID="btnDowloadAndriod" />
            <asp:PostBackTrigger ControlID="btnDowloadWindows" />
            <asp:PostBackTrigger ControlID="btnDownloadQRCode" />
        </Triggers>
        <ContentTemplate>
            <div>
                <div class="clear15">
                </div>
                <div class="adminpagehead">
                    Edit Branded App Order Status</div>
                <div align="center">
                    <img src="../images/Admin/shadow-title.png" title="USPD HUB" alt="USPD HUB" /></div>
                <div class="clear15">
                </div>
                <div class="adminformwrap">
                    <div class="clear15">
                    </div>
                    <div style="text-align: center;">
                        <asp:UpdateProgress ID="UpdateProgress6" runat="server" DisplayAfter="3">
                            <ProgressTemplate>
                                <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                    </div>
                    <div class="clear15">
                    </div>
                    <div>
                        <asp:ValidationSummary ID="ValidateUserDetails" runat="server" ValidationGroup="A"
                            HeaderText="The following error(s) occurred:" CssClass="errormsg_text" />
                    </div>
                    <asp:Panel runat="server" ID="pnlFirst">
                        <div class="clear10" style="height: 1px;">
                        </div>
                        <div class="labeladmenq">
                            &nbsp;&nbsp; Logo:
                            <div class="txtfildwrapadm" style="padding: 5px 0px 5px 13px;">
                                <asp:FileUpload ID="fileLogo" runat="server" Width="250px" />
                                <%--<%if (hdnTabType.Value == "1")
                                  { %><div style="width: 510px; margin: 0px 0px 0px 0px;">
                                      <label>
                                          150px X 150px Best Size
                                      </label>
                                  </div>
                                <%} %>--%>
                                <div style="padding: 10px;">
                                    <asp:Label runat="server" ID="lblLogo" Text=""></asp:Label>
                                    <asp:Button runat="server" ID="btnDeleteLogo" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete logo?');"
                                        OnClick="btnDeleteLogo_OnClick" Style="vertical-align: top;" />
                                    <asp:Button runat="server" ID="btnDownloadLogo" Text="Download" OnClick="btnDownloadLogo_OnClick"
                                        Style="vertical-align: top;" />
                                </div>
                            </div>
                        </div>
                        <div class="clear10">
                        </div>
                        <div class="labeladmenq">
                            &nbsp;&nbsp; App Icon:
                            <div class="txtfildwrapadm" style="padding: 5px 0px 5px 13px;">
                                <asp:FileUpload ID="FileAppIcon" runat="server" Width="250px" />
                                <%if (hdnTabType.Value == "1")
                                  { %>
                                <div style="width: 510px; margin: 0px 0px 0px 0px;">
                                    <label>
                                        1024px X 1024px Best Size
                                    </label>
                                </div>
                                <%} %>
                                <div style="padding: 10px;">
                                    <asp:Label runat="server" ID="lblAppIcon" Text=""></asp:Label>
                                    <asp:Button runat="server" ID="btnDeleteAppIcon" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete app icon?');"
                                        OnClick="btnDeleteAppIcon_OnClick" Style="vertical-align: top;" />
                                    <asp:Button runat="server" ID="btnDownloadAppIcon" Text="Download" OnClick="btnDownloadAppIcon_OnClick"
                                        Style="vertical-align: top;" />
                                </div>
                            </div>
                        </div>
                        <div class="clear10">
                        </div>
                        <div class="labeladmenq">
                            &nbsp;&nbsp; Background Icon:
                            <div class="txtfildwrapadm" style="padding: 5px 0px 5px 13px;">
                                <asp:FileUpload ID="FileBackground" runat="server" Width="250px" />
                                <%if (hdnTabType.Value == "1")
                                  { %>
                                <div style="width: 510px; margin: 0px 0px 0px 0px;">
                                    <label>
                                        640px X 165px Best Size
                                    </label>
                                </div>
                                <%} %>
                                <div style="padding: 10px;">
                                    <asp:Label runat="server" ID="lblBackground" Text=""></asp:Label>
                                    <asp:Button runat="server" ID="btnDeleteBackground" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete background icon?');"
                                        OnClick="btnDeleteBackground_OnClick" Style="vertical-align: top;" />
                                    <asp:Button runat="server" ID="btnDownloadBackground" Text="Download" OnClick="btnDownloadBackground_OnClick"
                                        Style="vertical-align: top;" />
                                </div>
                            </div>
                        </div>
                        <div class="clear10" style="height: 1px;">
                        </div>
                        <%if (hdnTabType.Value != "3")
                          { %>
                        <div class="labeladmenq">
                            &nbsp;&nbsp; App Name:
                            <div class="txtfildwrapadm" style="padding: 5px 0px 5px 13px;">
                                <asp:TextBox runat="server" ID="txtAppName" Width="262px" MaxLength="30" onkeyup="CountAppNameMaxLength(this,'AppName');"
                                    onChange="CountAppNameMaxLength(this,' AppName');"></asp:TextBox>
                                <div style="width: 810px; margin: 0px 0px 0px 0px;">
                                    <label>
                                        <asp:Label runat="server" ID="Label3" Text="25" Font-Bold="true"></asp:Label>
                                        Characters remaining.
                                    </label>
                                    <label style="margin-left: 10px;">
                                        (30 characters max)
                                    </label>
                                </div>
                            </div>
                        </div>
                        <div class="clear10" style="height: 1px;">
                        </div>
                        <div>
                            <div class="labeladmenq">
                                &nbsp;&nbsp; Splash Screen Content:
                                <div class="txtfildwrapadm" style="padding: 5px 0px 5px 13px;">
                                    <asp:TextBox runat="server" ID="txtSplashContent" TextMode="MultiLine" Width="700px"
                                        Height="30px"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="clear10" style="height: 1px;">
                        </div>
                        <div>
                            <div class="labeladmenq">
                                &nbsp;&nbsp; Short Description:
                                <div class="txtfildwrapadm" style="padding: 5px 0px 5px 13px;">
                                    <asp:TextBox runat="server" ID="txtShortDesc" TextMode="MultiLine" Width="700px"
                                        Height="30px" MaxLength="80" onkeyup="CountDescriptionMaxLength(this,'short description');"
                                        onChange="CountDescriptionMaxLength(this,'short description');"></asp:TextBox>
                                    <div style="width: 810px; margin: 0px 0px 0px 0px;">
                                        <label>
                                            <asp:Label runat="server" ID="Label2" Text="80" Font-Bold="true"></asp:Label>
                                            Characters remaining.
                                        </label>
                                        <label style="margin-left: 440px;">
                                            (80 characters max)
                                        </label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="clear10" style="height: 1px;">
                        </div>
                        <div>
                            <div class="labeladmenq">
                                &nbsp;&nbsp; Description:
                                <div class="txtfildwrapadm" style="padding: 5px 0px 5px 13px;">
                                    <asp:TextBox runat="server" ID="txtDescription" TextMode="MultiLine" Width="700px"
                                        Height="60px" MaxLength="2000" onkeyup="CountDescriptionMaxLength(this,'description');"
                                        onChange="CountDescriptionMaxLength(this,'description');"></asp:TextBox>
                                    <div style="width: 810px; margin: 0px 0px 0px 0px;">
                                        <label>
                                            <asp:Label runat="server" ID="lblCount1" Text="2000" Font-Bold="true"></asp:Label>
                                            Characters remaining.
                                        </label>
                                        <label style="margin-left: 412px;">
                                            (2000 characters max)
                                        </label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="clear10" style="height: 1px;">
                        </div>
                        <div>
                            <div class="labeladmenq">
                                &nbsp;&nbsp; Keywords:
                                <div class="txtfildwrapadm" style="padding: 5px 0px 5px 13px;">
                                    <asp:TextBox runat="server" ID="txtKeywords" TextMode="MultiLine" Width="700px" Height="60px"
                                        MaxLength="200" onkeyup="CountkeywordsMaxLength(this,'keywords');" onChange="CountkeywordsMaxLength(this,'keywords');"></asp:TextBox>
                                    <div style="width: 810px; margin: 0px 0px 0px 0px;">
                                        <label>
                                            <asp:Label runat="server" ID="lblCount2" Text="200" Font-Bold="true"></asp:Label>
                                            Characters remaining.
                                        </label>
                                        <label style="margin-left: 425px;">
                                            (200 characters max)
                                        </label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <%} %>
                        <div class="clear10" style="height: 1px;">
                        </div>
                        <div style="display: none;">
                            <div class="labeladmenq">
                                <span class="errormsgadm">*</span>&nbsp; AssignedCS:
                                <div class="txtfildwrapadm" style="padding: 5px 0px 5px 13px;">
                                    <asp:DropDownList runat="server" ID="ddlAssignedCS" Font-Size="13px" CssClass="ddlfildadm"
                                        Width="150px">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel runat="server" ID="pnlSecond">
                        <div class="clear10">
                        </div>
                        <%if (lblSLogo.Text != "" && hdnTabType.Value == "2")
                          { %>
                        <div class="labeladmenq">
                            &nbsp;&nbsp; Logo Icon:
                            <div class="txtfildwrapadm" style="padding: 5px 0px 5px 13px;">
                                <asp:Label runat="server" ID="lblSLogo" Text=""></asp:Label>
                                <asp:Button runat="server" ID="btnlogoDownload" Text="Download" OnClick="btnDownloadLogo_OnClick"
                                    Style="vertical-align: top;" />
                            </div>
                        </div>
                        <div class="clear10">
                        </div>
                        <%} %>
                        <%if (lblSApp.Text != "" && hdnTabType.Value == "2")
                          { %>
                        <div class="labeladmenq">
                            &nbsp;&nbsp; App Icon:
                            <div class="txtfildwrapadm" style="padding: 5px 0px 5px 13px;">
                                <asp:Label runat="server" ID="lblSApp" Text=""></asp:Label>
                                <asp:Button runat="server" ID="btnappDownload" Text="Download" OnClick="btnDownloadAppIcon_OnClick"
                                    Style="vertical-align: top;" />
                            </div>
                        </div>
                        <div class="clear10">
                        </div>
                        <%} %>
                        <%if (lblSBackground.Text != "" && hdnTabType.Value == "2")
                          { %>
                        <div class="labeladmenq">
                            &nbsp;&nbsp; App Icon:
                            <div class="txtfildwrapadm" style="padding: 5px 0px 5px 13px;">
                                <asp:Label runat="server" ID="lblSBackground" Text=""></asp:Label>
                                <asp:Button runat="server" ID="btnDowloadbackgimg" Text="Download" OnClick="btnDownloadBackground_OnClick"
                                    Style="vertical-align: top;" />
                            </div>
                        </div>
                        <div class="clear10">
                        </div>
                        <%} %>
                        <div class="labeladmenq1">
                            &nbsp;&nbsp; <b>App Name:</b>
                            <asp:Label runat="server" ID="lblAppName" Text=""></asp:Label>
                        </div>
                        <div class="clear10">
                        </div>
                        <div class="labeladmenq1">
                            &nbsp;&nbsp; <b>Splash Screen Content:</b>
                            <asp:Label runat="server" ID="lblSplashContent" Text=""></asp:Label>
                        </div
                        <div class="clear10">
                        </div>
                        <div class="labeladmenq1">
                            &nbsp;&nbsp; <b>Short Description:</b>
                            <asp:Label runat="server" ID="lblShortDescription" Text=""></asp:Label>
                        </div>
                        <div class="clear10">
                        </div>
                        <div class="labeladmenq1">
                            &nbsp;&nbsp; <b>App Description:</b>
                            <asp:Label runat="server" ID="lblAppDescription" Text=""></asp:Label>
                        </div>
                        <div class="clear10">
                        </div>
                        <div class="labeladmenq1">
                            &nbsp;&nbsp; <b>App Keywords:</b>
                            <asp:Label runat="server" ID="lblAppKeywords" Text=""></asp:Label>
                        </div>
                        <% if (Convert.ToInt32(hdnAppOrderStatus.Value) == Convert.ToInt32(USPDHUBDAL.BusinessDAL.BranedAppProcessStatus.DeviceTesting) ||
                            Convert.ToInt32(hdnAppOrderStatus.Value) == Convert.ToInt32(USPDHUBDAL.BusinessDAL.BranedAppProcessStatus.SubmitStore) ||
                            Convert.ToInt32(hdnAppOrderStatus.Value) == Convert.ToInt32(USPDHUBDAL.BusinessDAL.BranedAppProcessStatus.Completed))
                           { %>
                        <div class="clear10" style="height: 20px;">
                        </div>
                        <div class="labeladmenq">
                            &nbsp;&nbsp; App Store Icon:
                            <div class="txtfildwrapadm" style="padding: 5px 0px 5px 13px;">
                                <asp:FileUpload ID="fileupload_AppstoreIcon" runat="server" Width="250px" />
                                <div style="padding: 10px;">
                                    <asp:Label runat="server" ID="lblAppStoreIcon" Text=""></asp:Label>
                                    <asp:Button runat="server" ID="btnDeleteAppStoreIcon" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete app store icon?');"
                                        OnClick="btnDeleteAppStoreIcon_OnClick" Style="vertical-align: top;" />
                                    <asp:Button runat="server" ID="btDownloadAppStoreIcon" Text="Download" OnClick="btDownloadAppStoreIcon_OnClick"
                                        Style="vertical-align: top;" />
                                </div>
                            </div>
                        </div>
                        <div class="clear10">
                        </div>
                        <div class="labeladmenq">
                            &nbsp;&nbsp; Printable App Store Icon:
                            <div class="txtfildwrapadm" style="padding: 5px 0px 5px 13px;">
                                <asp:FileUpload ID="fileuploadPrintableAppStoreIcon" runat="server" Width="250px" />
                                <div style="padding: 10px;">
                                    <asp:Label runat="server" ID="lblPrintableAppStoreIcon" Text=""></asp:Label>
                                    <asp:Button runat="server" ID="btnDeletePrintableAppStoreIcon" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete printable app store icon?');"
                                        OnClick="btnDeletePrintableAppStoreIcon_OnClick" Style="vertical-align: top;" />
                                    <asp:Button runat="server" ID="btnDowloadPrintableAppStoreIcon" Text="Download" OnClick="btnDowloadPrintableAppStoreIcon_OnClick"
                                        Style="vertical-align: top;" />
                                </div>
                            </div>
                        </div>
                        <%} %>
                        <div class="clear10">
                        </div>
                        <div class="labeladmenq">
                            &nbsp;&nbsp; IOS URL:
                            <div class="txtfildwrapadm" style="padding: 5px 0px 5px 13px;">
                                <asp:TextBox runat="server" ID="txtIOS_URL" Width="300px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtIOS_URL"
                                    ErrorMessage="IOS URL is mandatory." SetFocusOnError="True" Display="Dynamic"
                                    ValidationGroup="A">*
                                </asp:RequiredFieldValidator></div>
                        </div>
                        <div class="clear10">
                        </div>
                        <div class="labeladmenq">
                            &nbsp;&nbsp; Android URL:
                            <div class="txtfildwrapadm" style="padding: 5px 0px 5px 13px;">
                                <asp:TextBox runat="server" ID="txtAndroid_URL" Width="300px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAndroid_URL"
                                    ErrorMessage="Android URL is mandatory." SetFocusOnError="True" Display="Dynamic"
                                    ValidationGroup="A">*
                                </asp:RequiredFieldValidator></div>
                        </div>
                        <div class="clear10">
                        </div>
                        <div>
                            <div class="labeladmenq">
                                &nbsp;&nbsp; Windows URL:
                                <div class="txtfildwrapadm" style="padding: 5px 0px 5px 13px;">
                                    <asp:TextBox runat="server" ID="txtWindows_URL" Width="300px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtWindows_URL"
                                        ErrorMessage="Windows URL is mandatory." SetFocusOnError="True" Display="Dynamic"
                                        ValidationGroup="A">*
                                    </asp:RequiredFieldValidator></div>
                            </div>
                        </div>
                        <div class="clear10">
                        </div>
                        <div>
                            <div class="labeladmenq">
                                &nbsp;&nbsp; Website URL:
                                <div class="txtfildwrapadm" style="padding: 5px 0px 5px 13px;">
                                    <asp:TextBox runat="server" ID="txtWebSite_URL" Width="300px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtWebSite_URL"
                                        ErrorMessage="Website URL is mandatory." SetFocusOnError="True" Display="Dynamic"
                                        ValidationGroup="A">*
                                    </asp:RequiredFieldValidator></div>
                            </div>
                        </div>
                        <div class="clear10">
                        </div>
                    </asp:Panel>
                    <div class="clear10" style="height: 1px;">
                    </div>
                    <div class="adminformwrap">
                        <div class="labeladmenq">
                            &nbsp;&nbsp; Status:
                            <div class="txtfildwrapadm" style="padding: 5px 0px 5px 13px;">
                                <asp:DropDownList runat="server" ID="ddlStatus" Font-Size="13px" CssClass="ddlfildadm"
                                    Width="250px">
                                </asp:DropDownList>
                                <asp:Label ID="lblEditStatus" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="clear10" style="height: 5px;">
                        </div>
                        <% if (Convert.ToInt32(hdnAppOrderStatus.Value) == Convert.ToInt32(USPDHUBDAL.BusinessDAL.BranedAppProcessStatus.SubmitStore) ||
                            Convert.ToInt32(hdnAppOrderStatus.Value) == Convert.ToInt32(USPDHUBDAL.BusinessDAL.BranedAppProcessStatus.Completed))
                           { %>
                        <div class="clear10">
                        </div>
                        <div class="labeladmenq">
                            &nbsp;&nbsp; QR Codes:
                            <div class="txtfildwrapadm" style="padding: 5px 0px 5px 13px;">
                                <asp:FileUpload ID="fileupload_QRCode" runat="server" Width="250px" />
                                <div style="padding: 10px;">
                                    <asp:Label runat="server" ID="lblQRCode" Text=""></asp:Label>
                                    <asp:Button runat="server" ID="btnDownloadQRCode" Text="Download" OnClick="btnDownloadQRCode_OnClick"
                                        Style="vertical-align: top;" />
                                </div>
                            </div>
                        </div>
                        <%} %>
                        <%if (hdnTabType.Value == "3")
                          { %>
                        <asp:Panel runat="server" ID="pnlQRCodes" Visible="false">
                            <div class="labeladmenq">
                                &nbsp;&nbsp; QR Codes:
                                <div class="txtfildwrapadm" style="padding: 5px 0px 5px 13px;">
                                    <span style="font-weight: bold; vertical-align: top; padding-right: 45px;">IOS </span>
                                    <asp:Label ID="lblIOS" runat="server"></asp:Label>
                                    <asp:Button runat="server" ID="btnDownloadIOS" Text="Download" OnClick="btnDowloadIOS_OnClick"
                                        Style="vertical-align: top;" />
                                </div>
                                <div class="txtfildwrapadm" style="padding: 5px 0px 5px 13px;">
                                    <span style="font-weight: bold; vertical-align: top; padding-right: 20px;">Android
                                    </span>
                                    <asp:Label ID="lblAndriod" runat="server"></asp:Label>
                                    <asp:Button runat="server" ID="btnDowloadAndriod" Text="Download" OnClick="btnDowloadAndriod_OnClick"
                                        Style="vertical-align: top;" />
                                </div>
                                <div class="txtfildwrapadm" style="padding: 5px 0px 5px 13px;">
                                    <span style="font-weight: bold; vertical-align: top; padding-right: 20px;">Windows
                                    </span>
                                    <asp:Label ID="lblWindows" runat="server"></asp:Label>
                                    <asp:Button runat="server" ID="btnDowloadWindows" Text="Download" OnClick="btnDowloadWindows_OnClick"
                                        Style="vertical-align: top;" />
                                </div>
                            </div>
                        </asp:Panel>
                        <%} %>
                    </div>
                </div>
                <div class="clear41">
                </div>
                <div class="clear41">
                </div>
                <div class="submitadm">
                    <asp:LinkButton ID="lnkBack" runat="server" CausesValidation="false" TabIndex="6"
                        OnClick="lnkBack_Click"><img src="../images/Admin/cancel.png" alt="" /></asp:LinkButton>
                    <asp:LinkButton ID="lnkSave" runat="server" CausesValidation="true" TabIndex="5"
                        OnClientClick="return ValidateURLs()" OnClick="lnkSave_Click"><img src="../images/Admin/Submit.png" alt="" /></asp:LinkButton>
                </div>
                <asp:Panel ID="NotesTable" runat="server" Style="margin-left: 50px;">
                    <table>
                        <tr>
                            <td style="width: 336px; height: 3px;">
                                <span style="color: #FB8926; font-size: 14px;">Notes:</span>
                                <asp:TextBox ID="TxtBxNotes" runat="server" TextMode="MultiLine" Height="100px" Width="647px"></asp:TextBox>
                                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                            </td>
                            <td style="width: 336px; height: 3px;">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 336px; height: 3px;">
                                <span style="color: #FB8926; font-size: 14px;">Notes By:</span>
                                <asp:TextBox ID="txtNotesBy" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 336px; height: 3px;">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 336px; height: 3px;">
                            </td>
                            <td style="width: 336px; height: 3px;">
                                <asp:Button ID="BtnNotes" runat="server" Text="Submit" OnClientClick="return CheckNotes();"
                                    OnClick="BtnNotes_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="NotesDatalist" runat="server" Style="margin-top: 30px;">
                    <asp:DataList ID="DataList_CustomerNotes" runat="server" DataKeyField="CustomerNotesId"
                        ForeColor="Black" CellSpacing="12" Width="100%">
                        <ItemTemplate>
                            <asp:Panel ID="UpdatePanel" runat="server" Style="overflow: auto;" BackColor="Gainsboro"
                                Width="100%">
                                <table style="border-collapse: collapse" border="0" cellpadding="10" width="100%">
                                    <tr>
                                        <td align="right">
                                            By:
                                            <asp:Label ID="lblRepName" runat="server" ForeColor="black" Text='<%# DataBinder.Eval(Container.DataItem,"Notes_By") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="justify">
                                            <asp:Label ID="NotesText" runat="server" ForeColor="black" Text='<%# DataBinder.Eval(Container.DataItem,"Notes") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label1" runat="server" ForeColor="black" Text='<%# DataBinder.Eval(Container.DataItem,"Created_Dt") %>' />
                                        </td>
                                    </tr>
                                </table>
                                <br />
                            </asp:Panel>
                            <cc1:RoundedCornersExtender ID="RoundedCornersExtender1" TargetControlID="UpdatePanel"
                                runat="server">
                            </cc1:RoundedCornersExtender>
                        </ItemTemplate>
                    </asp:DataList>
                </asp:Panel>
            </div>
            <asp:HiddenField runat="server" ID="hdnAppOrderStatus" Value="0" />
            <asp:HiddenField runat="server" ID="hdnTabType" Value="0" />
            <script type="text/javascript">
                function CheckNotes() {
                    var msg = '';
                    if (document.getElementById('<%=TxtBxNotes.ClientID %>').value == '')
                        msg = 'Please enter comments for Notes.\n';
                    if (document.getElementById('<%=txtNotesBy.ClientID %>').value == '')
                        msg = msg + 'Please enter your name for Notes By.';
                    if (msg != '') {
                        alert(msg);
                        return false;
                    }
                    else
                        return true;
                }
                function ValidateURLs() {
                    //7 Means Completed Status
                    var ReturnValue = true;
                    if (document.getElementById("<%=ddlStatus.ClientID %>").value == "8") {
                        if (!Page_ClientValidate('A')) {
                            ReturnValue = false;
                        }
                    }
                    return ReturnValue;
                }
                window.onload = function () {

                    CountDescriptionMaxLength(document.getElementById('<%=txtDescription.ClientID %>'), 'description');
                    CountkeywordsMaxLength(document.getElementById('<%=txtKeywords.ClientID %>'), 'keywords');
                    CountAppNameMaxLength(document.getElementById('<%=txtAppName.ClientID %>'), 'keywords');
                }
                function CountDescriptionMaxLength(id, text) {
                    var maxlength = 2000;
                    if (id != null) {
                        var Content = id.value;
                        var TextLength = id.value.length;
                        if (TextLength > maxlength) {
                            id.value = id.value.substring(0, maxlength);
                            //alert('You have exceeded the maximum of ' + maxlength + ' characters for ' + text + '.');
                        }
                        document.getElementById('<%=lblCount1.ClientID %>').innerHTML = maxlength - TextLength;
                    }
                }
                function CountkeywordsMaxLength(id, text) {
                    var maxlength = 200;
                    if (id != null) {
                        var Content = id.value;
                        var TextLength = id.value.length;
                        if (TextLength > maxlength) {
                            id.value = id.value.substring(0, maxlength);
                            //alert('You have exceeded the maximum of ' + maxlength + ' characters for ' + text + '.');
                        }
                        document.getElementById('<%=lblCount2.ClientID %>').innerHTML = maxlength - TextLength;
                    }
                }
                function CountAppNameMaxLength(id, text) {
                    var maxlength = 30;
                    if (id != null) {
                        var Content = id.value;
                        var TextLength = id.value.length;
                        if (TextLength > maxlength) {
                            id.value = id.value.substring(0, maxlength);
                        }
                        TextLength = id.value.length;
                        document.getElementById('<%=Label3.ClientID %>').innerHTML = maxlength - TextLength;
                    }
                }
            </script>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
