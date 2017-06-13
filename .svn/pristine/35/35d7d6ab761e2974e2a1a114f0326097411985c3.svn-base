<%@ Page Title="" Language="C#" MasterPageFile="~/PaidTools.master" AutoEventWireup="true"
    CodeBehind="Wanted.aspx.cs" Inherits="UserForms.Wanted" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/TimeControl.ascx" TagName="TimeControl" TagPrefix="TimerUC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <script src="../../Scripts/flyers/jquery-1.7.2.js" type="text/javascript"></script>
    <link href="../../Styles/Bulletins.css" rel="stylesheet" type="text/css" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" DefaultButton="btnSave" runat="server">
                <div id="wrapper">
                    <div class="headernav">
                        <%=BulletinName %><asp:TextBox ID="txt" runat="server" Width="0" BorderStyle="none"
                            BorderColor="white" Style="border: 0; border-color: White!important;"></asp:TextBox>
                    </div>
                    <div style="text-align: center;">
                        <asp:Label ID="lblerror" runat="server"></asp:Label>
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="3">
                            <ProgressTemplate>
                                <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green"
                                    size="2">Processing....</font></b>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <div style="width: 350px; margin: 0 auto;">
                            <asp:ValidationSummary ID="ValidateUserDetails" runat="server" Style="text-align: left;"
                                ValidationGroup="SV" HeaderText="The following error(s) occurred:" />
                        </div>
                    </div>
                    <div>
                        <div style="margin: 0 auto; width: 100%; overflow: hidden;">
                            <asp:Label runat="server" ID="lblLogoHeader"></asp:Label>
                        </div>
                    </div>
                    <div class="clear">
                    </div>
                    <div class="contentwrap">
                        <div class="largetxt">
                            Wanted</div>
                        <div class="form_wrapper">
                            <div class="clear">
                            </div>
                            <div class="fields_wrap">
                                <div class="clear">
                                </div>
                                <label style="color: Red; font-size: 16px; margin-left: 100px;">
                                    * Marked fields are mandatory.</label>
                            </div>
                            <div class="clear">
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <font color="red">*</font>
                                    <label>
                                        Date :</label></div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtBulletinDate" runat="server"></asp:TextBox>
                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" TargetControlID="txtBulletinDate"
                                        WatermarkText="MM/DD/YYYY" runat="server" WatermarkCssClass="watermarkbulletindate">
                                    </cc1:TextBoxWatermarkExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                                        ControlToValidate="txtBulletinDate" ValidationGroup="SV" ErrorMessage="Date is mandatory.">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic"
                                        ControlToValidate="txtBulletinDate" ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                        ValidationGroup="SV" ErrorMessage="Invalid Date Format of Date.">*</asp:RegularExpressionValidator>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtBulletinDate"
                                        Format="MM/dd/yyyy" CssClass="MyCalendar" />
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        Reason :</label></div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtReason" runat="server" TextMode="MultiLine" CssClass="txtfild1"></asp:TextBox>
                                </div>
                            </div>
                            <div class="browseimg_wrap" style="margin-left: 150px;">
                                <div class="avatar" style="text-align: center;">
                                    <div id='divDefaultPerson' style="width: 310px; min-height: 140px; display: block;">
                                    </div>
                                    <asp:HiddenField ID="hdnDefaultPerson" runat="server" />
                                    <asp:HiddenField ID="hdnDPLink" runat="server" />
                                </div>
                                <label>
                                    <img style="cursor: pointer;" onclick="EditImage('divDefaultPerson');" src="../../Images/Dashboard/Browseimg.png" />
                                </label>
                                <div style="float: right; margin-left: 0px;">
                                    <a href="javascript:ModalHelpPopup('Add Image to Content',20,'');">
                                        <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" /></a>
                                </div>
                                <div id="imgDelete1" style="margin-top: 5px; display: none;">
                                    <asp:Button ID="btnImgDelete1" runat="server" CausesValidation="false" border="0"
                                        CssClass="btn" Text="Delete Image" OnClientClick="return FirstImageDelete();"
                                        Width="151px" />
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    &nbsp;<label>
                                        Last Name :</label></div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtLastName" runat="server" CssClass="txtfild1"></asp:TextBox>
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    &nbsp;<label>
                                        Middle Name :</label></div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtMiddleName" runat="server" CssClass="txtfild1"></asp:TextBox>
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    &nbsp;<label>
                                        First Name :</label>
                                </div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="txtfild1"></asp:TextBox>
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        Nickname :</label>
                                </div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtNickname" runat="server" CssClass="txtfild1"></asp:TextBox>
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    &nbsp;
                                    <label>
                                        Date of Birth :</label></div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtDOB" runat="server" onblur="ageCount();"></asp:TextBox>
                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" TargetControlID="txtDOB"
                                        WatermarkText="MM/DD/YYYY" runat="server" WatermarkCssClass="watermarkbulletindate">
                                    </cc1:TextBoxWatermarkExtender>
                                    <asp:RegularExpressionValidator ID="REVDOB" runat="server" Display="Dynamic" ControlToValidate="txtDOB"
                                        ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                        ValidationGroup="SV" ErrorMessage="Invalid format for Date of Birth. (mm/dd/yyyy)">*</asp:RegularExpressionValidator>
                                    <cc1:CalendarExtender ID="CEDOB" runat="server" TargetControlID="txtDOB" Format="MM/dd/yyyy"
                                        CssClass="MyCalendar" />
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        Age :</label></div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtAge" runat="server" CssClass="txtfild2" onkeypress="return isNumber(event)"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Display="Dynamic"
                                        ControlToValidate="txtAge" ErrorMessage="Enter Only Numbers" ValidationExpression="^\d+$"
                                        ValidationGroup="SV">*</asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        Gender/Race :</label></div>
                                <div class="right_fields">
                                    <asp:DropDownList ID="ddlGender" runat="server" Width="200px">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        Height :</label></div>
                                <div class="right_fields">
                                    <div style="float: left; margin-right: 15px;">
                                        <asp:DropDownList ID="ddlFeet" runat="server">
                                        </asp:DropDownList>
                                        Feet</div>
                                    <div style="float: left;">
                                        <asp:DropDownList ID="ddlInches" runat="server">
                                        </asp:DropDownList>
                                        Inches</div>
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        Weight :</label></div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtWeight" runat="server" CssClass="txtfild2"></asp:TextBox>
                                    &nbsp; Pounds &nbsp;<asp:RegularExpressionValidator ID="REVWeight" runat="server"
                                        Display="Dynamic" ForeColor="Red" ControlToValidate="txtWeight" ValidationGroup="SV"
                                        ErrorMessage="Enter a Valid Weight" ValidationExpression="^[0-9.]+$"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        Eyes :</label></div>
                                <div class="right_fields">
                                    <asp:DropDownList ID="ddlEyes" runat="server" CssClass="select1">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        Hair :</label></div>
                                <div class="right_fields">
                                    <asp:DropDownList ID="ddlHair" runat="server" CssClass="select1">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        Complexion :</label></div>
                                <div class="right_fields">
                                    <asp:DropDownList ID="ddlCompletion" runat="server" CssClass="select1">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        Race :</label></div>
                                <div class="right_fields">
                                    <asp:DropDownList ID="ddlRace" runat="server" CssClass="select1">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        Nationality :</label></div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtNationality" runat="server" CssClass="txtfild1"></asp:TextBox>
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        Distinguishing Marks :</label></div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtMarks" runat="server" TextMode="MultiLine" CssClass="txtfild1"></asp:TextBox>
                                </div>
                            </div>
                            <div class="browseimg_wrap" style="margin-left: 150px;">
                                <div class="avatar" style="text-align: center;">
                                    <div id='divAnotherImg' style="width: 310px; min-height: 140px; display: block;">
                                    </div>
                                    <asp:HiddenField ID="hdnAnotherImg" runat="server" />
                                    <asp:HiddenField ID="hdnAnotherImgLink" runat="server" />
                                </div>
                                <label>
                                    <img style="cursor: pointer;" onclick="EditImage('divAnotherImg');" src="../../Images/Dashboard/Browseimg.png" />
                                </label>
                                <div style="float: right; margin-left: 0px;">
                                    <a href="javascript:ModalHelpPopup('Add Image to Bulletin',20,'');">
                                        <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" /></a>
                                </div>
                                <div id="imgDelete2" style="margin-top: 5px; display: none;">
                                    <asp:Button ID="btnImgDelete2" runat="server" CausesValidation="false" border="0"
                                        CssClass="btn" Text="Delete Image" OnClientClick="return SecondImageDelete();"
                                        Width="151px" />
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label class="highlightLabel">
                                        Additional Information :</label>
                                </div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtAddInfo" runat="server" TextMode="MultiLine" CssClass="txtfild1"></asp:TextBox>
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label class="highlightLabel">
                                        Remarks :</label></div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" CssClass="txtfild1"></asp:TextBox>
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        <img style="vertical-align: middle" src="<%=RootPath %>/Images/content_call.png" />
                                        Number:
                                    </label>
                                </div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtContentPhone" runat="server" CssClass="txtfild1" onkeyup="transform(this);"></asp:TextBox>
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        Expiration Date & Time:</label></div>
                                <div class="right_fields" style="width: 470px;">
                                    <table cellpadding="0" cellspacing="0" id='tblExTime'>
                                        <colgroup>
                                            <col width="120px" />
                                            <col width="*" />
                                        </colgroup>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtExpires" runat="server" onChange="ShowExTimeDiv();" Width="100px"
                                                    Height="18px"></asp:TextBox>
                                                <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server" TargetControlID="txtExpires"
                                                    WatermarkCssClass="watermarkbulletindate" WatermarkText="MM/DD/YYYY">
                                                </cc1:TextBoxWatermarkExtender>
                                                <asp:RegularExpressionValidator ID="RegularDate" runat="server" ControlToValidate="txtExpires"
                                                    Display="Dynamic" ErrorMessage="Invalid Date Format of Expiration Date." ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                                    ValidationGroup="SV">*</asp:RegularExpressionValidator>
                                                <cc1:CalendarExtender ID="calex" runat="server" CssClass="MyCalendar" Format="MM/dd/yyyy"
                                                    TargetControlID="txtExpires" />
                                            </td>
                                            <td>
                                                <TimerUC:TimeControl ID="ExpiryTimeControl1" runat="server" Enabled="false" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <div class="fields_wrap">
                                <div class="left_lable">
                                    <label>
                                    </label>
                                </div>
                                <div class="right_fields">
                                    <label id="divCall" runat="server">
                                        <asp:CheckBox ID="chkCall" runat="server" />
                                        Display Call Button</label>
                                    <br />
                                    <label id="divContactUs" runat="server">
                                        <asp:CheckBox ID="chkContact" runat="server" />
                                        Display Contact Us Button</label>
                                    <br />
                                </div>
                            </div>
                            <div class="clear10">
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <label>
                                    </label>
                                </div>
                                <div class="right_fields">
                                    <div style="margin: 10px 0px 0px 0px;">
                                        <asp:RadioButton ID="rbPrivate" runat="server" GroupName="Public" Checked="true"
                                            onclick="javascript:ShowPublish('1')" />
                                        <label>
                                            Private</label>
                                        <asp:RadioButton ID="rbPublic" runat="server" GroupName="Public" onclick="javascript:ShowPublish('2')" />
                                        <asp:Label ID="lblPublish" runat="server" Text="Publish" CssClass="approval"></asp:Label>
                                        <div style="margin: 10px 0px 0px 10px; display: none;" id="divpublish">
                                            <div id="divSchedulePublish" style="display: block;">
                                                <font color="red">*</font>
                                                <label style="font-size: 14px;">
                                                    Publish Date:</label>
                                                <asp:TextBox ID="txtPublishDate" runat="server" Width="75"></asp:TextBox><asp:TextBox
                                                    ID="txtPD" runat="server" Width="0" Height="0" BorderStyle="None" Style="display: none;"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="txtPD"
                                                    runat="server" ErrorMessage="Publish Date is mandatory." Display="Dynamic" ValidationGroup="SV"
                                                    SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="REPublishDate" runat="server" Display="Dynamic"
                                                    ControlToValidate="txtPublishDate" ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                                    ValidationGroup="SV" ErrorMessage="Invalid Date Format">*</asp:RegularExpressionValidator>
                                                <cc1:CalendarExtender ID="calPublish" runat="server" TargetControlID="txtPublishDate"
                                                    Format="MM/dd/yyyy" CssClass="MyCalendar" />
                                            </div>
                                            <% if ((Session["C_USER_ID"] == null || Session["C_USER_ID"].ToString() == "") || hdnPermissionType.Value == "P")
                                               { %>
                                            <br />
                                            <%if (hdnFacebook.Value == "")
                                              { %>
                                            <asp:CheckBox ID="chkFbAutoPost" runat="server" Text="Auto post on facebook" Style="font-size: 14px;
                                                padding-left: 4px;" /><br />
                                            <%} %>
                                            <%if (hdnTwitter.Value == "")
                                              { %>
                                            <asp:CheckBox ID="chkTwrAutoPost" runat="server" Text="Auto post on twitter" Style="font-size: 14px;
                                                padding-left: 4px;" />
                                            <%} %>
                                            <%} %>
                                            <asp:HiddenField ID="hdnIsAlreadyPublished" runat="server" Value="0" />
                                            <asp:HiddenField ID="hdnFacebook" runat="server" />
                                            <asp:HiddenField ID="hdnTwitter" runat="server" />
                                            <asp:HiddenField ID="hdnPublishDate" runat="server" />
                                            <asp:HiddenField ID="hdnPublishTitle" runat="server" Value="Publish" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        Category:</label></div>
                                <div class="right_fields">
                                    <asp:DropDownList ID="ddlCategories" runat="server" Width="200px">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                    </label>
                                </div>
                                <div class="right_fields">
                                    <asp:CheckBox runat="server" ID="chkLocated" />
                                    <asp:TextBox runat="server" ID="txtApprehend" placeholder="Apprehended" Text="Apprehended"
                                        MaxLength="12" onkeyup="CountMaxLength(this,event);" onChange="CountMaxLength(this,event);" />
                                    <br />
                                    <span style="margin-left: 25px; font-weight: bold;">(Max Characters 12)</span>
                                    <br />
                                    <span style="margin-left: 25px; font-weight: bold;">You have
                                        <asp:Label ID="lblLength" runat="server"></asp:Label>
                                        characters left.</span>
                                    <br />
                                </div>
                            </div>
                            <div class="clear">
                            </div>
                            <div class="clear10">
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                </div>
                                <div class="right_fields" style="margin: 10px 0px 0px 0px; width: 450px;">
                                    <asp:Button ID="btnCancel" runat="server" CausesValidation="false" border="0" CssClass="btn"
                                        Text="Cancel" OnClick="btnCancel_Click" />
                                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn" border="0" OnClick="btnSave_Click"
                                        ValidationGroup="SV" OnClientClick="BindImages(1);" />
                                    <asp:LinkButton ID="lnkPreview" runat="server" OnClick="lnkPreview_Click" OnClientClick="BindImages(2);"><img src="../../images/BulletinThumbs/preview.png" width="100" height="37"></asp:LinkButton>
                                    <input type="hidden" id="editDivCheck" value="" />
                                    <input type="hidden" id='hdnFormImgPath' />
                                    <input type="hidden" id="hdnalignindex" />
                                    <asp:HiddenField ID="hdnTextImage" runat="server" Value="" />
                                    <asp:HiddenField ID="hdnArchive" runat="server" />
                                    <asp:HiddenField ID="hdnPermissionType" runat="server" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                <tbody>
                    <tr>
                        <td>
                            <asp:Label ID="lblProgress" runat="server" visiable="false"></asp:Label>
                            <cc1:ModalPopupExtender ID="MPEProgress" runat="server" TargetControlID="lblProgress"
                                PopupControlID="pnlProgress" BackgroundCssClass="modal">
                            </cc1:ModalPopupExtender>
                            <asp:Panel Style="display: none;" ID="pnlProgress" runat="server" Width="500px">
                                <table class="modalpopup" cellspacing="0" cellpadding="0" width="100%" align="center"
                                    border="0">
                                    <tr>
                                        <td align="center">
                                            <asp:UpdateProgress ID="UpdateProgress8" runat="server" DisplayAfter="3">
                                                <ProgressTemplate>
                                                    <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green"> Your
                                                        request is in progress, please don't refresh or close window. </font></b>
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </tbody>
            </table>
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:Label ID="lblMfdDate" runat="server"></asp:Label>
                        <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" BackgroundCssClass="modal"
                            PopupControlID="pnlMfdDate" TargetControlID="lblMfdDate" CancelControlID="imglogin11">
                        </cc1:ModalPopupExtender>
                        <asp:Panel ID="pnlMfdDate" runat="server" Style="display: none" Width="100%">
                            <table class="popuptable" cellspacing="0" cellpadding="0" width="580px" align="center"
                                border="0">
                                <tr>
                                    <td align="center">
                                        <asp:UpdateProgress ID="UpdateProgress10" runat="server" DisplayAfter="3">
                                            <ProgressTemplate>
                                                <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </td>
                                    <td align="right">
                                        <asp:ImageButton ID="imglogin11" runat="server" ImageUrl="~/images/popup_close.gif"
                                            CausesValidation="false"></asp:ImageButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="font-weight: bold; font-size: 14px; padding-bottom: 10px; color: green;
                                        padding-top: 10px" align="left" colspan="2">
                                        <asp:Label ID="lblbulletinamme" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="padding: 10px;">
                                        <div style="height: 500px; overflow-y: auto; border: solid 1px #4684C5;">
                                            <asp:Label ID="lblPreview" runat="server"></asp:Label>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <%--IMAGE GALLERY * RESIZE IMAGE--%>
                        <asp:Label ID="lblbulletinimage" runat="server"></asp:Label>
                        <cc1:ModalPopupExtender ID="popbulletinimage" runat="server" TargetControlID="lblbulletinimage"
                            PopupControlID="pnlbulletinimage" BackgroundCssClass="modal" BehaviorID="popupimage"
                            CancelControlID="imcloseimagepopup">
                        </cc1:ModalPopupExtender>
                        <asp:Panel ID="pnlbulletinimage" runat="server" Style="display: none" Width="800px">
                            <table cellpadding="0" cellspacing="0" width="100%" style="border: 1px solid #EEECEC;
                                background-color: #F8F6F6;">
                                <tbody>
                                    <tr>
                                        <td align="right" style="padding: 5px 10px 0px 10px;">
                                            <asp:ImageButton ID="imcloseimagepopup" runat="server" ImageUrl="~/images/popup_close.gif" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="mid">
                                            <div id="DIDIFrm">
                                            </div>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="lnkPreview" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <script type="text/javascript">

        function CountMaxLength(id, e) {
            var maxlength = 12;
            var myRegExp = new RegExp(/^[^<&]+$/);
            if (myRegExp.test(id.value)) {
                if (id.value.length > maxlength) {
                    id.value = id.value.substring(0, maxlength);
                    alert('You have exceeded the maximum of ' + maxlength + ' characters.');
                }
                document.getElementById('<%=lblLength.ClientID %>').innerHTML = maxlength - id.value.length;

                return true;
            }
            else {
                if (e != undefined && (e.keyCode == 8 || e.keyCode == 46)) {
                    //
                }
                else {
                    document.getElementById('<%=txtApprehend.ClientID %>').value = id.value.replace(/[&<]/g, '')
                    alert("Please do not enter & and < characters.");
                    return false;
                }
            }
        }

        function ShowExTimeDiv() {

            var allddls = document.getElementsByTagName("select");
            for (k = 0; k < allddls.length; k++) {
                var controlName = allddls[k].id;
                if (controlName.indexOf("ddlTime") >= 0) {
                    break;
                }
            }

            if (document.getElementById("<%=txtExpires.ClientID %>").value == "" || document.getElementById("<%=txtExpires.ClientID %>").value == "MM/DD/YYYY") {
                document.getElementById(controlName).disabled = true;
            }
            else {
                document.getElementById(controlName).disabled = false;
            }
        }
        function GetCurrentDate() {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "Default.aspx/GetUserTimeZoneDashboard",
                dataType: "json",
                success: function (response) {
                    currentTime = new Date(response.d);
                    dformat = [(currentTime.getMonth() + 1).padLeft(), currentTime.getDate().padLeft(), currentTime.getFullYear()].join('/');
                    document.getElementById('<%= txtPublishDate.ClientID%>').value = dformat;
                }
            });
        }
        Number.prototype.padLeft = function (base, chr) {
            var len = (String(base || 10).length - String(this).length) + 1;
            return len > 0 ? new Array(len).join(chr || '0') + this : this;
        }
        function ValidatePublishDate() {
            if (document.getElementById('<%= rbPublic.ClientID%>').checked) {
                if (document.getElementById("<%=txtPublishDate.ClientID %>").value == "") {
                    document.getElementById("<%=txtPD.ClientID %>").value = "";
                }
                else {
                    document.getElementById("<%=txtPD.ClientID %>").value = "1";
                }
            }
            else {
                document.getElementById("<%=txtPublishDate.ClientID %>").value = "";
                document.getElementById("<%=txtPD.ClientID %>").value = "1";
            }
        }
        function ShowPublish(val) {
            if (val == "1") {
                document.getElementById('<%=btnSave.ClientID %>').value = "Save";
                document.getElementById('divpublish').style.display = "none";
                document.getElementById('<%= txtPublishDate.ClientID%>').value = '';
            } else if (val == "2") {
                document.getElementById('<%=btnSave.ClientID %>').value = "Submit";
                document.getElementById('divpublish').style.display = "block";
                if ('<%= IsScheduleEmails %>' == 'True') {
                    document.getElementById('divSchedulePublish').style.display = "block";
                } else {

                    document.getElementById('divSchedulePublish').style.display = "none";
                }
                if (document.getElementById('<%= txtPublishDate.ClientID%>').value == "")
                    GetCurrentDate();
            }
        }
        function isLeap(year) {
            return year % 4 == 0 && (year % 100 != 0 || year % 400 == 0);
        }
        function GetExactAge(bDay, DOBDate) {
            // *** Checking Age in yeas and months *** //
            /*
            function getAge
            parameters: dateString dateType
            returns: boolean

            dateString is a date passed as a string in the following
            formats:

            type 1 : 19970529
            type 2 : 970529
            type 3 : 29/05/1997
            type 4 : 29/05/97

            dateType is a numeric integer from 1 to 4, representing
            the type of dateString passed, as defined above.

            Returns string containing the age in years, months and days
            in the format yyy years mm months dd days.
            Returns empty string if dateType is not one of the expected
            values.
            */
            var now = new Date();
            //var today = new Date(now.getYear(), now.getMonth(), now.getDate());

            var yearNow = now.getYear();
            var monthNow = now.getMonth();
            var dateNow = now.getDate();

            //                        if (dateType == 1)
            //                            var dob = new Date(bDay.substring(0, 4),
            //                            dateString.substring(4, 6) - 1,
            //                            dateString.substring(6, 8));
            //                        else if (dateType == 2)
            //                            var dob = new Date(dateString.substring(0, 2),
            //                            dateString.substring(2, 4) - 1,
            //                            dateString.substring(4, 6));
            //                        else if (dateType == 3)
            //var dob = new Date(bDay.substring(6, 10), bDay.substring(3, 5) - 1, bDay.substring(0, 2));
            //                        else if (dateType == 4)
            //                            var dob = new Date(bDay.substring(6, 8),
            //                            dateString.substring(3, 5) - 1,
            //                            dateString.substring(0, 2));
            //                        else
            //                            return '';

            var yearDob = DOBDate.getYear();
            var monthDob = DOBDate.getMonth();
            var dateDob = DOBDate.getDate();

            yearAge = yearNow - yearDob;

            if (monthNow >= monthDob)
                var monthAge = monthNow - monthDob;
            else {
                yearAge--;
                //var monthAge = 12 + monthNow - monthDob;
            }

            if (dateNow >= dateDob)
                var dateAge = dateNow - dateDob;
            else {
                monthAge--;
                //var dateAge = 31 + dateNow - dateDob;

                if (monthAge < 0) {
                    monthAge = 11;
                    yearAge--;
                }
            }

            alert(yearAge + ' years ' + monthAge + ' months ' + dateAge + ' days');
        }
        function ageCount() {
            var now = new Date();
            if (document.getElementById("<%=txtDOB.ClientID %>").value != "") {
                var DOBDate = new Date(document.getElementById("<%=txtDOB.ClientID %>").value);
                if (DOBDate > now) {
                    alert('Please select date of birth less than or equal to current date.');
                    document.getElementById("<%=txtAge.ClientID %>").value = "";
                    document.getElementById("<%=txtDOB.ClientID %>").value = "";
                    document.getElementById("<%=txtDOB.ClientID %>").focus();
                }
                else {
                    var years = now.getFullYear() - DOBDate.getFullYear();
                    var m = now.getMonth() - DOBDate.getMonth();
                    if (m < 0 || (m === 0 && now.getDate() < DOBDate.getDate())) {
                        years--;
                    }
                    document.getElementById("<%=txtAge.ClientID %>").value = years;
                }
            } else {
                document.getElementById("<%=txtAge.ClientID %>").value = "";
            }
        }
        function EditImage(imgdivID) {
            document.getElementById('DIDIFrm').innerHTML = "";
            ifrm = document.createElement("IFRAME");
            imgSrc = document.getElementById(imgdivID).innerHTML.trim();

            //ifrm.setAttribute("src", "Bulletin_ImageGallery.aspx?fitblockwidth=" + (document.getElementById(imgdivID).offsetWidth - 10) + "&imgSrc=" + imgSrc + "&folder=Forms");
            //ifrm.style.height = "750px";
            ifrm.setAttribute("src", "BulletinsForm_ImageGallery.aspx?fitblockwidth=" + (document.getElementById(imgdivID).offsetWidth - 10) + "&imgSrc=" + imgSrc + "&folder=Forms");
            ifrm.style.height = "650px";
            ifrm.style.width = "100%";
            ifrm.style.border = "0px";
            ifrm.scrolling = "no";
            ifrm.frameBorder = "0";
            document.getElementById('DIDIFrm').appendChild(ifrm);
            document.getElementById('editDivCheck').value = imgdivID;

            var modalDialog = $find("popupimage");
            modalDialog.show();
        }
        function BindImages(typeValue) {
            if (document.getElementById('divDefaultPerson').innerHTML.indexOf('img') != -1 || document.getElementById('divDefaultPerson').innerHTML.indexOf('IMG') != -1) {
                document.getElementById("<%=hdnDefaultPerson.ClientID %>").value = $('#divDefaultPerson img').attr('src');
            }
            if (document.getElementById('divAnotherImg').innerHTML.indexOf('img') != -1 || document.getElementById('divAnotherImg').innerHTML.indexOf('IMG') != -1) {
                document.getElementById("<%=hdnAnotherImg.ClientID %>").value = $('#divAnotherImg img').attr('src');
            }
            if (document.getElementById('divDefaultPerson').innerHTML.indexOf('href=') != -1) {
                document.getElementById("<%=hdnDPLink.ClientID %>").value = $('#divDefaultPerson a').attr('href');
            }
            if (document.getElementById('divAnotherImg').innerHTML.indexOf('href=') != -1) {
                document.getElementById("<%=hdnAnotherImgLink.ClientID %>").value = $('#divAnotherImg a').attr('href');
            }
            if (!Page_ClientValidate('group')) {
                return;
            }
            ValidatePublishDate();

            //ExDate checking
            if (document.getElementById("<%=txtExpires.ClientID %>").value != "" && typeValue == 1) {

                var allddls = document.getElementsByTagName("select");
                for (k = 0; k < allddls.length; k++) {
                    var controlName = allddls[k].id;
                    if (controlName.indexOf("ddlTime") >= 0) {
                        break;
                    }
                }

                var currentdate = new Date();
                var fromDate = document.getElementById("<%=txtExpires.ClientID %>").value + " " + document.getElementById(controlName).value;
                var selDate = new Date(fromDate);
                if (selDate <= currentdate) {
                    alert('Expiration date should be later than current date.');
                    return;
                    return false;
                }
            }
            //end exdate checking
            if (typeValue == "1") {
                if (Page_ClientValidate('SV') == true && Page_IsValid == true)
                    $find("<%=MPEProgress.ClientID %>").show();
            }
        }
        function DisplayImage() {
            if (document.getElementById('<%= hdnPermissionType.ClientID%>') != "" && document.getElementById('<%= hdnPermissionType.ClientID%>') != null) {  //roles & permissions..
                DisplayComplete();
                if (document.getElementById("<%=hdnDefaultPerson.ClientID %>").value != "") {
                    document.getElementById("imgDelete1").style.display = "block";
                    if (document.getElementById("<%=hdnDPLink.ClientID %>").value == "")
                        document.getElementById('divDefaultPerson').innerHTML = "<img src='" + document.getElementById("<%=hdnDefaultPerson.ClientID %>").value + "' />";
                    else
                        document.getElementById('divDefaultPerson').innerHTML = "<a href='" + document.getElementById("<%=hdnDPLink.ClientID %>").value + "' target='_blank'><img src='" + document.getElementById("<%=hdnDefaultPerson.ClientID %>").value + "' /></a>";
                }
                if (document.getElementById("<%=hdnAnotherImg.ClientID %>").value != "") {
                    document.getElementById("imgDelete2").style.display = "block";
                    if (document.getElementById("<%=hdnAnotherImgLink.ClientID %>").value == "")
                        document.getElementById('divAnotherImg').innerHTML = "<img src='" + document.getElementById("<%=hdnAnotherImg.ClientID %>").value + "' />";
                    else
                        document.getElementById('divAnotherImg').innerHTML = "<a href='" + document.getElementById("<%=hdnAnotherImgLink.ClientID %>").value + "' target='_blank'><img src='" + document.getElementById("<%=hdnAnotherImg.ClientID %>").value + "' /></a>";
                }
            }
        }
        window.onload = function () {
            if (document.getElementById('<%= hdnPermissionType.ClientID%>') != "" && document.getElementById('<%= hdnPermissionType.ClientID%>') != null)  //roles & permissions..
                DisplayComplete();
            if (document.getElementById('<%=rbPrivate.ClientID %>').checked) {
                document.getElementById('<%=btnSave.ClientID %>').value = "Save";
            }
            else {
                document.getElementById('<%=btnSave.ClientID %>').value = "Submit";
            }
            CountMaxLength(document.getElementById('<%=txtApprehend.ClientID %>'));
        }
        function DisplayComplete() {
            if (document.getElementById('<%= rbPublic.ClientID%>').checked) {
                document.getElementById('divpublish').style.display = "block";
                if ('<%= IsScheduleEmails %>' == 'True') {
                    document.getElementById('divSchedulePublish').style.display = "block";
                } else {

                    document.getElementById('divSchedulePublish').style.display = "none";
                }
                ShowPublish('2');
            }
            ShowExTimeDiv();
        }

        function FirstImageDelete() {
            if (confirm("Are you sure you want to delete this image?")) {
                document.getElementById('divDefaultPerson').innerHTML = "";
                document.getElementById("imgDelete1").style.display = "none";
                document.getElementById("<%=hdnDefaultPerson.ClientID %>").value = "";
                document.getElementById("<%=hdnDPLink.ClientID %>").value = "";
            }
            return false;
        }

        function SecondImageDelete() {
            if (confirm("Are you sure you want to delete this image?")) {
                document.getElementById('divAnotherImg').innerHTML = "";
                document.getElementById("imgDelete2").style.display = "none";
                document.getElementById("<%=hdnAnotherImg.ClientID %>").value = "";
                document.getElementById("<%=hdnAnotherImgLink.ClientID %>").value = "";
            }

            return false;
        }
        $(document).ready(function () {
            if ('<%= IsScheduleEmails %>' == 'False') {
                if (document.getElementById('<%= hdnPermissionType.ClientID%>').value == "A")
                    document.getElementById('<%= lblPublish.ClientID%>').innerHTML = "Submit for approval";
                else
                    document.getElementById('<%= lblPublish.ClientID%>').innerHTML = "Publish Now";
            }
        });
        function transform(obj) {
            // Allow: backspace, delete, tab, escape, and enter // Allow: home, end, left, right
            if (event.keyCode == 46 || event.keyCode == 8 || event.keyCode == 9 || event.keyCode == 27 || event.keyCode == 13 ||
                (event.keyCode >= 35 && event.keyCode <= 39)) {
                return;
            }
            else {
                // Ensure that it is a number and stop the keypress
                if (event.shiftKey || (event.keyCode < 48 || event.keyCode > 57) && (event.keyCode < 96 || event.keyCode > 105)) {
                    event.preventDefault();
                }
            }
            var val = obj.value.replace(/\D/g, '');
            var newVal = '';
            if (val.length > 10) {
                val = val.substring(0, 10);
            }
            while (val.length > 3 && newVal.length <= 7) {
                newVal += val.substr(0, 3) + '-';
                val = val.substr(3);
            }
            newVal += val;
            document.getElementById("<%=txtContentPhone.ClientID %>").value = newVal;

        }
        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }
    </script>
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" Visible="false">
        <ContentTemplate>
            <div class="largetxt">
                Wanted</div>
            <br />
            <div style="color: red;" align="center">
                <asp:Label ID="lblerrormessage" runat="server"></asp:Label></div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
