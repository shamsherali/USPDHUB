<%@ Page Title="" Language="C#" MasterPageFile="~/PaidTools.master" AutoEventWireup="true"
    ValidateRequest="false" CodeBehind="TrafficAlert.aspx.cs" Inherits="USPDHUB.Business.MyAccount.TrafficAlert" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <script src="../../Scripts/flyers/jquery-1.7.2.js" type="text/javascript"></script>
    <link href="../../css/Bulletins.css" rel="stylesheet" type="text/css" />
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
                        <div style="width: 300px; margin: 0 auto;">
                            <asp:ValidationSummary ID="ValidateUserDetails" runat="server" Style="text-align: left;"
                                ValidationGroup="SV" HeaderText="The following error(s) occurred:" />
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" Style="text-align: left;"
                                ValidationGroup="ABC" HeaderText="The following error(s) occurred:" />
                            <asp:ValidationSummary ID="ValidationSummary2" runat="server" Style="text-align: left;"
                                ValidationGroup="ABC1" HeaderText="The following error(s) occurred:" />
                        </div>
                    </div>
                    <div class="header">
                        <div style="margin: 0 auto; width: 100%; overflow: hidden;">
                            <asp:Label runat="server" ID="lblLogoHeader"></asp:Label>
                        </div>
                    </div>
                    <div class="clear">
                    </div>
                    <div class="contentwrap">
                        <div class="largetxt" style="text-align: center; padding-left: 110px; height: 35px;">
                            <asp:DropDownList ID='ddlTrafficTypes' runat="server" Width="320px" CssClass="select1"
                                Font-Size="14" Height="32">
                                <asp:ListItem Text="Traffic Alert" Value="Traffic Alert"></asp:ListItem>
                                <asp:ListItem Text="Traffic Bulletin" Value="Traffic Bulletin"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form_wrapper">
                            <div class="clear10">
                            </div>
                            <div class="fields_wrap">
                                <label style="color: Red; font-size: 16px; margin-left: 100px;">
                                    * Marked fields are mandatory.</label>
                            </div>
                            <div class="clear10">
                            </div>
                            <div class="fields_wrap">
                                <div class="left_lable">
                                    <font color="red">*</font>
                                    <label>
                                        Date :</label></div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtBulletinDate" runat="server"></asp:TextBox>
                                    <cc1:TextBoxWatermarkExtender ID="MaskedEditExtender1" TargetControlID="txtBulletinDate"
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
                            <div class="fields_wrap" style="height: 221px;">
                                <div style="float: left; text-align: left; width: 550px; padding: 3px 0px 0px 0px;
                                    margin-left: 106px;">
                                    <span style="padding-left: 2px;">&nbsp;</span>
                                    <label>
                                        <table width="95%">
                                            <tr>
                                                <td>
                                                    <asp:CheckBox runat="server" ID="chkAccident" Text="Accident" />
                                                </td>
                                                <td>
                                                    <asp:CheckBox runat="server" ID="chkSpeicalEvent" Text="Special Event" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:CheckBox runat="server" ID="chkRoadClosure" Text="Road Closure" />
                                                </td>
                                                <td>
                                                    <asp:CheckBox runat="server" ID="chkHazMat" Text="Haz Mat" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:CheckBox runat="server" ID="chkConstruction" Text="Construction" />
                                                </td>
                                                <td>
                                                    <asp:CheckBox runat="server" ID="chkOther" Text="Other" />
                                                    <asp:TextBox runat="server" ID="txtOther" Width="200px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:CheckBox runat="server" ID="chkWeather" Text="Weather" />
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:CheckBox runat="server" ID="chkChains" Text="Chains Required" />
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:CheckBox runat="server" ID="chkSnowLevel" Text="Snow Level Elevation" />
                                                    <asp:TextBox runat="server" ID="txtSnowLevel" Width="100px"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </label>
                                </div>
                                <div class="right_fields">
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                    </label>
                                </div>
                                <div class="right_fields">
                                    <table cellpadding="3" width="83%" style="border: solid 1px #ccc;">
                                        <tr>
                                            <td>
                                                <asp:CheckBox runat="server" ID="chkTuneRadio" Text="Tune radio to :" />
                                                <br />
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <label>
                                                    AM</label>
                                                <asp:TextBox runat="server" ID="txtAM" Width="50px"></asp:TextBox>
                                                &nbsp;<label>
                                                    FM</label>
                                                <asp:TextBox runat="server" ID="txtFM" Width="50px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:CheckBox runat="server" ID="chkForRoadCondition" Text="For Road Conditions Call" />
                                                <asp:TextBox runat="server" ID="txtConditionsCall" Width="100px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:CheckBox runat="server" ID="chkSaveFutureRef" Text="Save for future reference"
                                                    Visible="false" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <div class="fields_wrap">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        Location :</label></div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtLocation" Width="325px" Height="50px" runat="server" TextMode="MultiLine"
                                        CssClass="txtfild1"></asp:TextBox>
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        City :</label></div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtCity" Width="325px" runat="server" CssClass="txtfild1"></asp:TextBox>
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        Zip code :</label></div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtzipcode" Width="325px" runat="server" CssClass="txtfild1"></asp:TextBox>
                                </div>
                            </div>
                            <div class="browseimg_wrap">
                                <div class="avatar" style="text-align: center;">
                                    <div id='divAddImg1' style="width: 310px; min-height: 140px; display: block;">
                                    </div>
                                    <asp:HiddenField ID="hdnAddImg1" runat="server" />
                                    <asp:HiddenField ID="hdnAddImg1Link" runat="server" />
                                </div>
                                <label>
                                    <img style="cursor: pointer;" onclick="EditImage('divAddImg1');" src="../../Images/Dashboard/Browseimg.png" />
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
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        Information :</label></div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtInformation" Width="325px" Height="50px" runat="server" TextMode="MultiLine"
                                        CssClass="txtfild1"></asp:TextBox>
                                </div>
                            </div>
                            <div class="browseimg_wrap">
                                <div class="avatar" style="text-align: center;">
                                    <div id='divAddImg2' style="width: 310px; min-height: 140px; display: block;">
                                    </div>
                                    <asp:HiddenField ID="hdnAddImg2" runat="server" />
                                    <asp:HiddenField ID="hdnAddImg2Link" runat="server" />
                                </div>
                                <label>
                                    <img style="cursor: pointer;" onclick="EditImage('divAddImg2');" src="../../Images/Dashboard/Browseimg.png" />
                                </label>
                                <div style="float: right; margin-left: 0px;">
                                    <a id="anchor2" href="javascript:ModalHelpPopup('Add Image to Content',20,'');">
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
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        <asp:CheckBox ID="chkWhenDate" Text="When" runat="server" onclick="ShowDatesBoxes();" />
                                        :</label></div>
                                <div class="right_fields">
                                    <table>
                                        <tr>
                                            <td>
                                                <label>
                                                    From :
                                                </label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox>
                                                <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" TargetControlID="txtFromDate"
                                                    WatermarkText="MM/DD/YYYY" runat="server" WatermarkCssClass="watermarkbulletindate">
                                                </cc1:TextBoxWatermarkExtender>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtFromDate"
                                                    runat="server" ErrorMessage="Start Date is mandatory." Display="Dynamic" ValidationGroup="ABC"
                                                    SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" Display="Dynamic"
                                                    ControlToValidate="txtFromDate" ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                                    ValidationGroup="ABC" ErrorMessage="Invalid Date Format">*</asp:RegularExpressionValidator>
                                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFromDate"
                                                    Format="MM/dd/yyyy" CssClass="MyCalendar" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label>
                                                    To :
                                                </label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtToDate" runat="server"></asp:TextBox>
                                                <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" TargetControlID="txtToDate"
                                                    WatermarkText="MM/DD/YYYY" runat="server" WatermarkCssClass="watermarkbulletindate">
                                                </cc1:TextBoxWatermarkExtender>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtFromDate"
                                                    runat="server" ErrorMessage="End Date is mandatory." Display="Dynamic" ValidationGroup="ABC"
                                                    SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Display="Dynamic"
                                                    ControlToValidate="txtToDate" ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                                    ValidationGroup="ABC" ErrorMessage="Invalid Date Format">*</asp:RegularExpressionValidator>
                                                <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtToDate"
                                                    Format="MM/dd/yyyy" CssClass="MyCalendar" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <div class="fields_wrap">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span>
                                    <label>
                                        <asp:CheckBox runat="server" ID="chkClosureTime" onclick="ShowTimeBoxes();" />
                                        Expected &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Delay/Closure Time:</label></div>
                                <div class="right_fields">
                                    <table width="85%" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <label>
                                                    From :
                                                </label>
                                            </td>
                                            <td>
                                                <%-- <asp:DropDownList ID="ddlFrom" runat="server" Width="100px">
                                                </asp:DropDownList>--%>
                                                <asp:TextBox runat="server" ID="txtFromHours" Enabled="False" Width="50px" MaxLength="2"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtFromHours"
                                                    runat="server" ErrorMessage="From Hours is mandatory." Display="Dynamic" ValidationGroup="ABC1"
                                                    SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                                <span style="font-weight: bold;">Hours</span> &nbsp; &nbsp;
                                                <asp:TextBox runat="server" ID="txtFromMinutes" Enabled="False" Width="50px" MaxLength="2"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtFromMinutes"
                                                    runat="server" ErrorMessage="From Minutes is mandatory." Display="Dynamic" ValidationGroup="ABC1"
                                                    SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                                <span style="font-weight: bold;">Minutes</span>
                                            </td>
                                            <td>
                                                <asp:DropDownList runat="server" ID="ddlFromSS" Width="60px" Enabled="False">
                                                    <asp:ListItem Text="AM" Value="AM" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label>
                                                    To :
                                                </label>
                                            </td>
                                            <td>
                                                <%--<asp:DropDownList ID="ddlTo" runat="server" Width="100px">
                                                </asp:DropDownList>--%>
                                                <asp:TextBox runat="server" ID="txtToHours" Enabled="False" Width="50px" MaxLength="2"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtToHours"
                                                    runat="server" ErrorMessage="To Hours is mandatory." Display="Dynamic" ValidationGroup="ABC1"
                                                    SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                                <span style="font-weight: bold;">Hours</span> &nbsp; &nbsp;
                                                <asp:TextBox runat="server" ID="txtToMinutes" Enabled="False" Width="50px" MaxLength="2"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txtToMinutes"
                                                    runat="server" ErrorMessage="To Minutes is mandatory." Display="Dynamic" ValidationGroup="ABC1"
                                                    SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                                <span style="font-weight: bold;">Minutes</span> &nbsp;
                                            </td>
                                            <td>
                                                <asp:DropDownList runat="server" ID="ddlToSS" Width="60px" Enabled="False">
                                                    <asp:ListItem Text="AM" Value="AM" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                    </label>
                                </div>
                                <div class="right_fields">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:CheckBox runat="server" ID="chkPleaseLimit" />
                                                <strong>Please limit phone calls. </strong>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <div class="fields_wrap">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        Expiration Date & Time:</label></div>
                                <div class="right_fields" style="width: 470px;">
                                    <table width="85%" cellpadding="0" cellspacing="0" id='tblExTime'>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtExpires" runat="server" onChange="ShowExTimeDiv();"></asp:TextBox>
                                                <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" TargetControlID="txtExpires"
                                                    WatermarkText="MM/DD/YYYY" runat="server" WatermarkCssClass="watermarkbulletindate">
                                                </cc1:TextBoxWatermarkExtender>
                                                <asp:RegularExpressionValidator ID="RegularDate" runat="server" Display="Dynamic"
                                                    ControlToValidate="txtExpires" ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                                    ValidationGroup="SV" ErrorMessage="Invalid Date Format">*</asp:RegularExpressionValidator>
                                                <cc1:CalendarExtender ID="calex" runat="server" TargetControlID="txtExpires" Format="MM/dd/yyyy"
                                                    CssClass="MyCalendar" />
                                            </td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtExHours" Width="50px" Enabled="False" MaxLength="2"></asp:TextBox>
                                                <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender4" TargetControlID="txtExHours"
                                                    WatermarkText="Hour" runat="server" WatermarkCssClass="watermarkbulletindate">
                                                </cc1:TextBoxWatermarkExtender>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" Display="Dynamic"
                                                    ControlToValidate="txtExHours" ValidationExpression="^(1[0-2]|0?[1-9])" ValidationGroup="SV"
                                                    ErrorMessage="Invalid Time Format">*</asp:RegularExpressionValidator>
                                                &nbsp; &nbsp;
                                                <asp:TextBox runat="server" ID="txtExMinutes" Width="50px" Enabled="False" MaxLength="2"></asp:TextBox>
                                                <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender5" TargetControlID="txtExMinutes"
                                                    WatermarkText="Minutes" runat="server" WatermarkCssClass="watermarkbulletindate">
                                                </cc1:TextBoxWatermarkExtender>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" Display="Dynamic"
                                                    ControlToValidate="txtExMinutes" ValidationExpression="^[0-5]\d" ValidationGroup="SV"
                                                    ErrorMessage="Invalid Time Format">*</asp:RegularExpressionValidator>
                                            </td>
                                            <td>
                                                <asp:DropDownList runat="server" ID="ddlExSS" Enabled="False" Width="60px">
                                                    <asp:ListItem Text="AM" Value="AM" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                                                </asp:DropDownList>
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
                                    <label runat="server" id="divCall">
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
                            <div class="fields_wrap">
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
                            <div class="fields_wrap">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        Category:</label></div>
                                <div class="right_fields">
                                    <asp:DropDownList ID="ddlCategories" runat="server" Width="200px">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="fields_wrap">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                    </label>
                                </div>
                                <div class="right_fields">
                                    <asp:CheckBox runat="server" ID="chkCleared" Text="Cleared" />
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
                                        ValidationGroup="SV" OnClientClick="return BindImages(1);" />
                                    <asp:LinkButton ID="lnkPreview" runat="server" OnClick="lnkPreview_Click" OnClientClick="return BindImages(2);"><img src="../../images/BulletinThumbs/preview.png" width="100" height="37"></asp:LinkButton>
                                    <input type="hidden" id="editDivCheck" value="" />
                                    <input type="hidden" id='hdnFormImgPath' />
                                    <input type="hidden" id="hdnalignindex" />
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
        $(document).ready(function () {
            if ('<%= IsScheduleEmails %>' == 'False') {
                if (document.getElementById('<%= hdnPermissionType.ClientID%>').value == "A")
                    document.getElementById('<%= lblPublish.ClientID%>').innerHTML = "Submit for approval";
                else
                    document.getElementById('<%= lblPublish.ClientID%>').innerHTML = "Publish Now";
            }
        });
        function ShowDatesBoxes() {
            if (!document.getElementById("<%=chkWhenDate.ClientID %>").checked) {
                document.getElementById("<%=txtFromDate.ClientID %>").value = "";
                document.getElementById("<%=txtToDate.ClientID %>").value = ""

                document.getElementById("<%=txtFromDate.ClientID %>").disabled = true;
                document.getElementById("<%=txtToDate.ClientID %>").disabled = true;

                document.getElementById("<%=chkClosureTime.ClientID %>").checked = false;
            }
            else {
                document.getElementById("<%=txtFromDate.ClientID %>").disabled = false;
                document.getElementById("<%=txtToDate.ClientID %>").disabled = false;
            }
            ShowTimesDiv();
        }
        function ShowTimeBoxes() {
            if (document.getElementById("<%=chkClosureTime.ClientID %>").checked) {
                if (document.getElementById("<%=chkWhenDate.ClientID %>").checked == false) {
                    alert("Please make sure select above check box and select dates.");
                    document.getElementById("<%=txt.ClientID %>").focus();

                    document.getElementById("<%=chkClosureTime.ClientID %>").checked = false;
                }
                else {
                    ShowTimesDiv();
                }
            }
            else {
                ShowTimesDiv(); ;
            }
        }

        function ValidateTime() {

            var fromHour = "12";
            var fromMin = "00";
            var fromSS = "AM";

            var toHour = "12";
            var toMin = "59";
            var toSS = "PM";

            if (document.getElementById("<%=chkClosureTime.ClientID %>").checked) {
                if (Page_ClientValidate("ABC1") && Page_IsValid) {
                    //From Time
                    if (document.getElementById("<%=txtFromHours.ClientID %>").value != "") {
                        fromHour = document.getElementById("<%=txtFromHours.ClientID %>").value;
                    }
                    if (document.getElementById("<%=txtFromMinutes.ClientID %>").value != "") {
                        fromMin = document.getElementById("<%=txtFromMinutes.ClientID %>").value;
                    }

                    fromSS = document.getElementById("<%=ddlFromSS.ClientID %>").value;

                    // To Time
                    if (document.getElementById("<%=txtToHours.ClientID %>").value != "") {
                        toHour = document.getElementById("<%=txtToHours.ClientID %>").value;
                    }
                    if (document.getElementById("<%=txtToMinutes.ClientID %>").value != "") {
                        toMin = document.getElementById("<%=txtToMinutes.ClientID %>").value;
                    }
                    toSS = document.getElementById("<%=ddlToSS.ClientID %>").value;

                    var fromTime = fromHour + ":" + fromMin + ":00 " + fromSS;
                    var toTime = toHour + ":" + toMin + ":00 " + toSS;

                    var startDateTime = new Date(document.getElementById("<%=txtFromDate.ClientID %>").value + " " + fromTime);
                    var endDateTime = new Date(document.getElementById("<%=txtToDate.ClientID %>").value + " " + toTime);

                    if (startDateTime >= endDateTime) {
                        document.getElementById("<%=lblerror.ClientID %>").innerHTML = "<font size='2' color='red'>" + "Your to date time should be later than from date time." + "</font>";

                        return false;
                    }
                    else {
                        return true;
                    }
                }
            }
        }

        function ShowTimesDiv() {
            if (document.getElementById("<%=chkClosureTime.ClientID %>").checked == false) {
                //From Time
                document.getElementById("<%=txtFromHours.ClientID %>").disabled = true;
                document.getElementById("<%=txtFromMinutes.ClientID %>").disabled = true;
                document.getElementById("<%=ddlFromSS.ClientID %>").disabled = true;

                document.getElementById("<%=txtFromHours.ClientID %>").value = "";
                document.getElementById("<%=txtFromMinutes.ClientID %>").value = "";

                // To Time
                document.getElementById("<%=txtToHours.ClientID %>").disabled = true;
                document.getElementById("<%=txtToMinutes.ClientID %>").disabled = true;
                document.getElementById("<%=ddlToSS.ClientID %>").disabled = true;

                document.getElementById("<%=txtToHours.ClientID %>").value = "";
                document.getElementById("<%=txtToMinutes.ClientID %>").value = "";


            }
            else {
                //From Time
                document.getElementById("<%=txtFromHours.ClientID %>").disabled = false;
                document.getElementById("<%=txtFromMinutes.ClientID %>").disabled = false;
                document.getElementById("<%=ddlFromSS.ClientID %>").disabled = false;
                //To Time
                document.getElementById("<%=txtToHours.ClientID %>").disabled = false;
                document.getElementById("<%=txtToMinutes.ClientID %>").disabled = false;
                document.getElementById("<%=ddlToSS.ClientID %>").disabled = false;
            }
        }

        function ShowExTimeDiv() {
            if (document.getElementById("<%=txtExpires.ClientID %>").value == "") {
                document.getElementById("<%=txtExHours.ClientID %>").disabled = true;
                document.getElementById("<%=txtExMinutes.ClientID %>").disabled = true;
                document.getElementById("<%=ddlExSS.ClientID %>").disabled = true;
            }
            else {
                document.getElementById("<%=txtExHours.ClientID %>").disabled = false;
                document.getElementById("<%=txtExMinutes.ClientID %>").disabled = false;
                document.getElementById("<%=ddlExSS.ClientID %>").disabled = false;
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
        /*
        var toDayDate1 = new Date();
        var date1 = new Date(publishDate);
        var date2 = new Date(toDayDate1);
        var diffDays = parseInt(date2.getDate() - date1.getDate());
        var diffHours = parseInt(date2.getHours() - date1.getHours());
        var diffMins = parseInt(date2.getMinutes() - date1.getMinutes());
        */
        function ValidatePublishDate() {
            document.getElementById("<%=lblerror.ClientID %>").innerHTML = "";
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
        window.onload = function () {
            document.getElementById('<%=btnSave.ClientID %>').value = "";
            if (document.getElementById('<%=rbPrivate.ClientID %>').checked) {
                document.getElementById('<%=btnSave.ClientID %>').value = "Save";
            }
            else {
                document.getElementById('<%=btnSave.ClientID %>').value = "Submit";
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
        function EditImage(imgdivID) {
            document.getElementById('DIDIFrm').innerHTML = "";
            ifrm = document.createElement("IFRAME");
            imgSrc = document.getElementById(imgdivID).innerHTML.trim();
            ifrm.setAttribute("src", "BulletinsForm_ImageGallery.aspx?fitblockwidth=" + (document.getElementById(imgdivID).offsetWidth - 30) + "&imgSrc=" + imgSrc + "&folder=Forms");
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
            if (document.getElementById('divAddImg1').innerHTML.indexOf('img') != -1 || document.getElementById('divAddImg1').innerHTML.indexOf('IMG') != -1) {
                document.getElementById("<%=hdnAddImg1.ClientID %>").value = $('#divAddImg1 img').attr('src');
            }
            if (document.getElementById('divAddImg2').innerHTML.indexOf('img') != -1 || document.getElementById('divAddImg2').innerHTML.indexOf('IMG') != -1) {
                document.getElementById("<%=hdnAddImg2.ClientID %>").value = $('#divAddImg2 img').attr('src');
            }
            if (document.getElementById('divAddImg1').innerHTML.indexOf('href=') != -1) {
                document.getElementById("<%=hdnAddImg1Link.ClientID %>").value = $('#divAddImg1 a').attr('href');
            }
            if (document.getElementById('divAddImg2').innerHTML.indexOf('href=') != -1) {
                document.getElementById("<%=hdnAddImg2Link.ClientID %>").value = $('#divAddImg2 a').attr('href');
            }
            var value = true;
            if (typeValue == 1) {
                ValidatePublishDate();
                if (Page_ClientValidate('SV') && Page_IsValid) {
                    if (document.getElementById("<%=chkWhenDate.ClientID %>").checked) {
                        if (!Page_ClientValidate('ABC') && Page_IsValid) {
                            value = false;
                        }
                        else {
                            var eDate = new Date(document.getElementById("<%=txtToDate.ClientID %>").value);
                            var sDate = new Date(document.getElementById("<%=txtFromDate.ClientID %>").value);
                            if (eDate < sDate) {
                                document.getElementById("<%=lblerror.ClientID %>").innerHTML = "<font color='red'>" + "To date should be later than or equal to from date." + "</font>";

                                value = false;
                                document.getElementById("<%=txtToDate.ClientID %>").focus();
                            }
                        }
                    }
                    //Checking Time When Timings are Check// Closer Time Check Box...
                    if (value) {
                        value = ValidateTime();
                        document.getElementById("<%=txt.ClientID %>").focus();
                    }
                }
                else
                    value = false;

                if (value)
                    $find("<%=MPEProgress.ClientID %>").show();

            }
            return value;
        }
        function DisplayComplete() {
            if (document.getElementById("<%=hdnAddImg1.ClientID %>").value != "") {
                document.getElementById("imgDelete1").style.display = "block";
                if (document.getElementById("<%=hdnAddImg1Link.ClientID %>").value == "")
                    document.getElementById('divAddImg1').innerHTML = "<img src='" + document.getElementById("<%=hdnAddImg1.ClientID %>").value + "' />";
                else
                    document.getElementById('divAddImg1').innerHTML = "<a href='" + document.getElementById("<%=hdnAddImg1Link.ClientID %>").value + "' target='_blank'><img src='" + document.getElementById("<%=hdnAddImg1.ClientID %>").value + "' /></a>";
            }
            if (document.getElementById("<%=hdnAddImg2.ClientID %>").value != "") {
                document.getElementById("imgDelete2").style.display = "block";
                if (document.getElementById("<%=hdnAddImg2Link.ClientID %>").value == "")
                    document.getElementById('divAddImg2').innerHTML = "<img src='" + document.getElementById("<%=hdnAddImg2.ClientID %>").value + "' />";
                else
                    document.getElementById('divAddImg2').innerHTML = "<a href='" + document.getElementById("<%=hdnAddImg2Link.ClientID %>").value + "' target='_blank'><img src='" + document.getElementById("<%=hdnAddImg2.ClientID %>").value + "' /></a>";
            }
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
                document.getElementById('divAddImg1').innerHTML = "";
                document.getElementById("imgDelete1").style.display = "none";
                document.getElementById("<%=hdnAddImg1.ClientID %>").value = "";
            }
            return false;
        }
        function SecondImageDelete() {
            if (confirm("Are you sure you want to delete this image?")) {
                document.getElementById('divAddImg2').innerHTML = "";
                document.getElementById("imgDelete2").style.display = "none";
                document.getElementById("<%=hdnAddImg2.ClientID %>").value = "";
            }
            return false;
        }
    </script>
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" Visible="false">
        <ContentTemplate>
            <div class="largetxt">
                Traffic Alert</div>
            <br />
            <div style="color: red;" align="center">
                <asp:Label ID="lblerrormessage" runat="server"></asp:Label></div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
