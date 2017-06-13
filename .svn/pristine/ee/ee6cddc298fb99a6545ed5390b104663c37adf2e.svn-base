<%@ Page Title="" Language="C#" MasterPageFile="~/PaidTools.master" AutoEventWireup="true"
    CodeBehind="SurveyEntry.aspx.cs" Inherits="USPDHUB.Business.MyAccount.SurveyEntry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <link href="../../css/Bulletins.css" rel="stylesheet" type="text/css" />
    <link href="../../css/jquery-bubble-popup-v3.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-bubble-popup-v3.min.js" type="text/javascript"></script>
    <script>
        $(document).ready(function () {

            $('#help1').CreateBubblePopup({

                position: 'top',
                align: 'center',

                innerHtml: 'A survey allows you to ask multiple<br /> questions across a wider range of <br/>question types.',
                innerHtmlStyle: {
                    color: '#FFFFFF',
                    'text-align': 'center'
                },
                themeName: 'all-blue',
                themePath: '../../Scripts/jquerybubblepopup-themes'

            });
            $('#help2').CreateBubblePopup({

                position: 'top',
                align: 'center',
                innerHtml: 'A poll allows you to ask one multiple<br /> choice question. ',
                innerHtmlStyle: {
                    color: '#FFFFFF',
                    'text-align': 'center'
                },
                themeName: 'all-blue',
                themePath: '../../Scripts/jquerybubblepopup-themes'

            });
        }); 
    </script>
    <style>
        .button
        {
            margin: auto auto;
            text-align: center;
            width: 200px;
            height: 60px;
            color: #FFFFFF;
            background-color: #006699;
            border: #003366 1px solid;
            cursor: pointer;
        }
    </style>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" DefaultButton="btnSaveExit" runat="server">
                <div id="wrapper">
                    <div class="headernav">
                        <asp:TextBox ID="txt" runat="server" Width="0" BorderStyle="none" BorderColor="white"
                            Style="border: 0; border-color: White!important;"></asp:TextBox>
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
                        </div>
                    </div>
                    <div class="clear">
                    </div>
                    <div class="contentwrap">
                        <div class="largetxt">
                            Survey Entry</div>
                        <div class="form_wrapper" style="float: none; width: auto;">
                            <div class="clear10">
                            </div>
                            <div class="fields_wrap">
                                <label style="color: Red; font-size: 16px; margin-left: 200px;">
                                    * Marked fields are mandatory.</label>
                            </div>
                            <div class="clear10">
                            </div>
                            <div class="fields_wrap">
                                <div class="left_lable" style="width: 190px;">
                                    <font color="red">*</font>
                                    <label>
                                        Survey Name :</label></div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtSurveyName" runat="server" CssClass="txtfild1" TabIndex="1"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
                                        ControlToValidate="txtSurveyName" ValidationGroup="SV" ErrorMessage="Survey Name is mandatory.">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="fields_wrap">
                                <div class="left_lable" style="width: 190px;">
                                    <span style="padding-left: 2px;">&nbsp;</span>
                                    <label>
                                        Description :
                                    </label>
                                    <br />
                                    <span style="padding-left: 2px;">&nbsp;</span>
                                    <label>
                                        <b>(</b>For your reference only.
                                    </label>
                                    <br />
                                    <span style="padding-left: 2px;">&nbsp;</span>
                                    <label>
                                        <b>This description does not</b>
                                    </label>
                                    <br />
                                    <span style="padding-left: 2px;">&nbsp;</span>
                                    <label>
                                        <b>display on the app.)</b>
                                    </label>
                                </div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" CssClass="txtfild1"
                                        TabIndex="2"></asp:TextBox>
                                </div>
                            </div>
                            <div class="clear10">
                            </div>
                            <div class="fields_wrap">
                                <div class="left_lable" style="width: 190px;">
                                    <span style="padding-left: 2px;">&nbsp;</span>
                                    <label>
                                        Survey Type :</label></div>
                                <div class="right_fields">
                                    <%-- <asp:DropDownList ID="ddlSurveyTypes" runat="server" CssClass="select1" TabIndex="3">
                                    </asp:DropDownList>--%>
                                    <asp:RadioButton runat="server" ID="rbSurvey" Text="Survey" GroupName="SType" Checked="true" />
                                    <a href="#">
                                        <img id='help1' src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" /></a>&nbsp;
                                    <asp:RadioButton runat="server" ID="rbPoll" Text="Poll" GroupName="SType" />
                                    <a href="#">
                                        <img id="help2" src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" /></a>
                                    <%--<asp:RadioButtonList ID="rbSurveyTypes" runat="server">
                                    </asp:RadioButtonList>--%>
                                </div>
                            </div>
                            <div class="clear10">
                            </div>
                            <div class="fields_wrap">
                                <%--<div class="left_lable" style="width: 190px;">
                                    <font color="red">*</font>
                                    <label>
                                        Thank You Message :</label>
                                    <br />
                                    <span style="padding-left: 2px;">&nbsp;</span>
                                    <label>
                                        <b>(This message will</b>
                                    </label>
                                    <br />
                                    <span style="padding-left: 2px;">&nbsp;</span>
                                    <label>
                                        <b>appear on the app.)</b>
                                    </label>
                                </div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtthanksMessage" runat="server" TextMode="MultiLine" CssClass="txtfild1"
                                        TabIndex="4" MaxLength="500"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                                        ControlToValidate="txtthanksMessage" ValidationGroup="SV" ErrorMessage="Thank You Message is mandatory.">*</asp:RequiredFieldValidator>
                                </div>--%>
                            </div>
                            <div class="fields_wrap">
                                <%--<div class="left_lable" style="width: 190px;">
                                    <font color="red">*</font>
                                    <label>
                                        Expiration Date & Time :</label></div>
                                <div class="right_fields">
                                    <table width="90%" style="margin-left: -3px; margin-top: -5px;">
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtExpiryDate" runat="server" CssClass="txtfild1" TabIndex="5" Width="95px"
                                                    onChange="ShowExTimeDiv();"></asp:TextBox>&nbsp;
                                                <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" TargetControlID="txtExpiryDate"
                                                    WatermarkText="MM/DD/YYYY" runat="server">
                                                </cc1:TextBoxWatermarkExtender>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic"
                                                    ControlToValidate="txtExpiryDate" ValidationGroup="SV" ErrorMessage="Expiration Date is mandatory.">*</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularDate" runat="server" Display="Dynamic"
                                                    ControlToValidate="txtExpiryDate" ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                                    SetFocusOnError="True" ValidationGroup="SV" ErrorMessage="Invalid Date Format">*</asp:RegularExpressionValidator>
                                                <cc1:CalendarExtender ID="calex" runat="server" TargetControlID="txtExpiryDate" Format="MM/dd/yyyy"
                                                    CssClass="MyCalendar" />
                                            </td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtExHours" Width="50px" Enabled="False" MaxLength="2"></asp:TextBox>
                                                <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender14" TargetControlID="txtExHours"
                                                    WatermarkText="Hour" runat="server" WatermarkCssClass="watermarkbulletindate">
                                                </cc1:TextBoxWatermarkExtender>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" Display="Dynamic"
                                                    ControlToValidate="txtExHours" ValidationExpression="^(1[0-2]|0?[1-9])" ValidationGroup="SV"
                                                    ErrorMessage="Invalid Time Format">*</asp:RegularExpressionValidator>
                                            </td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtExMinutes" Width="50px" Enabled="False" MaxLength="2"></asp:TextBox>
                                                <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender15" TargetControlID="txtExMinutes"
                                                    WatermarkText="Minutes" runat="server" WatermarkCssClass="watermarkbulletindate">
                                                </cc1:TextBoxWatermarkExtender>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Display="Dynamic"
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
                                </div>--%>
                            </div>
                            <div class="clear10">
                            </div>
                            <div class="fields_wrap ">
                                <%--<div class="left_lable">
                                    <label>
                                    </label>
                                </div>
                                <div class="right_fields">
                                    <div style="margin: 10px 0px 0px 30px;">
                                        <asp:RadioButton ID="rbPrivate" runat="server" GroupName="Public" Checked="true"
                                            onclick="javascript:ShowPublish('1')" />
                                        <label>
                                            Private</label>
                                        <asp:RadioButton ID="rbPublic" runat="server" GroupName="Public" onclick="javascript:ShowPublish('2')" />
                                        <asp:Label ID="lblPublish" runat="server" Text="Publish" CssClass="approval"></asp:Label>
                                        <div style="margin: 10px 0px 0px 10px; display: none;" id="divpublish">
                                            <font color="red">*</font>
                                            <label style="font-size: 14px;">
                                                Publish Date:</label>
                                            <asp:TextBox ID="txtPublishDate" runat="server" Width="75"></asp:TextBox><asp:TextBox
                                                ID="txtPD" runat="server" Width="0" Height="0" BorderStyle="None" Style="display: none;"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="REPublishDate" runat="server" Display="Dynamic"
                                                ControlToValidate="txtPublishDate" ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                                ValidationGroup="SV" ErrorMessage="Invalid Date Format">*</asp:RegularExpressionValidator>
                                            <cc1:CalendarExtender ID="calPublish" runat="server" TargetControlID="txtPublishDate"
                                                Format="MM/dd/yyyy" CssClass="MyCalendar" />
                                            <asp:HiddenField ID="hdnPublishDate" runat="server" />
                                            <asp:HiddenField ID="hdnPermissionType" runat="server" />
                                            <asp:HiddenField ID="hdnPublishTitle" runat="server" Value="Publish" />
                                        </div>
                                    </div>
                                </div>--%>
                                <asp:HiddenField ID="hdnPublishDate" runat="server" />
                                <asp:HiddenField ID="hdnPermissionType" runat="server" />
                                <asp:HiddenField ID="hdnPublishTitle" runat="server" Value="Publish" />
                            </div>
                            <div class="clear">
                            </div>
                            <div class="clear10">
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                </div>
                                <div class="right_fields" style="margin: 10px 0px 0px 30px;">
                                    <asp:Button ID="btnSaveExit" runat="server" Text="Save & Continue" CssClass="btn"
                                        border="0" ValidationGroup="SV" 
                                        OnClick="btnSaveExit_Click" /> <%--OnClientClick="return ValidateExpiryDate();"--%>
                                    <asp:Button ID="btnCancel" runat="server" CausesValidation="false" border="0" CssClass="btn"
                                        Text="Cancel" OnClick="btnCancel_Click" />
                                    <asp:Button ID="btnSkip" runat="server" CausesValidation="false" border="0" CssClass="btn"
                                        Text="Skip" OnClick="btnSkip_OnClick" Visible="false" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>    
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" Visible="false">
        <ContentTemplate>
            <div class="largetxt">
                Survey Entry
            </div>
            <br />
            <div style="color: red;" align="center">
                <asp:Label ID="lblerrormessage" runat="server"></asp:Label></div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
