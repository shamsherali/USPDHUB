<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApprovalProcess.aspx.cs"
    Inherits="USPDHUB.ApprovalProcess" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Preview | Approval Process</title>
    <link href="css/reveal.css" rel="stylesheet" type="text/css" />
    <link href="css/popupcss.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            padding-left: 20px;
            align: center;
            padding-right: 20px;
            z-index: 9999;
        }
        .box
        {
            background-color: Gainsboro;
        }
        .boxmid
        {
        }
        .main
        {
            padding: 10px;
        }
        .main td
        {
            text-align: center;
        }
        .main td a
        {
            font-size: 12px;
            text-decoration: underline;
            font-weight: bold;
        }
        .main td a:hover
        {
            font-size: 12px;
            text-decoration: none;
            font-weight: bold;
        }
        .modal
        {
            background-color: Gray;
            filter: alpha(opacity=90);
            opacity: 0.7;
        }
        .bodttext
        {
            font-family: Arial, Helvetica, sans-serif;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="smgr1" runat="server">
    </asp:ScriptManager>
    <div class="bodttext">
        <asp:HiddenField ID="hdnProcess" runat="server" />
        <div style="margin: 0px auto;">
            <table cellpadding="0" cellspacing="0" border="0" width="60%" align="center">
                <tr>
                    <td align="center">
                        <asp:Label ID="lblMessage" runat="server" Style="color: Green;"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <asp:Panel ID="pnlBulletin" runat="server">
            <table cellpadding="0" cellspacing="0" border="0" width="60%" align="center">
                <tr>
                    <td align="right">
                        <a href="javascript:window.print();">
                            <img src="images/OuterImages/printlabel.gif" border="0" /></a>
                    </td>
                </tr>
            </table>
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr>
                    <td align="center" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" width="60%">
                            <tr>
                                <td valign="top" style="padding-top: 10px;" align="center">
                                    <asp:Label ID="lblbulletin" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlEvent" runat="server">
            <table cellpadding="0" cellspacing="0" border="0" width="60%" align="center">
                <tr>
                    <td align="right">
                        <a href="javascript:window.print();">
                            <img src="images/OuterImages/printlabel.gif" border="0" /></a>
                    </td>
                </tr>
            </table>
            <table cellpadding="0" cellspacing="0" border="0" width="60%" align="center">
                <tr>
                    <td align="center" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td>
                                    &nbsp;&nbsp;&nbsp;&nbsp; Event Name :
                                    <asp:Label ID="lbleventName" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;&nbsp;&nbsp;&nbsp; Event Start Date :
                                    <asp:Label ID="lblstartdate" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;&nbsp;&nbsp;&nbsp; Event End Date :
                                    <asp:Label ID="lbleventEndDate" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" style="padding-top: 10px;">
                                    <asp:Label ID="lblEventDesc" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlUpdate" runat="server">
            <table width="691px" border="0" cellpadding="0" cellspacing="0" align="center">
                <tr>
                    <td align="right">
                        <a href="javascript:window.print();">
                            <img src="images/OuterImages/printlabel.gif" border="0" /></a>
                    </td>
                </tr>
            </table>
            <table width="691px" border="0" cellpadding="0" cellspacing="0" class="box" align="center">
                <tr>
                    <td class="boxmid">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="main">
                            <tr>
                                <td style="text-align: center; padding-bottom: 15px;">
                                    <asp:Label ID="lbl_businessname" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Lbl_Updatetitle" ForeColor="#5C9DE1" runat="server" Style="font-size: large;"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: justify">
                                    <asp:Label ID="lblBusinessUpdate" ForeColor="black" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlSurvey" runat="server">
            <table width="691px" border="0" cellpadding="0" cellspacing="0" align="center">
                <tr>
                    <td align="right">
                        <a href="javascript:window.print();">
                            <img src="images/OuterImages/printlabel.gif" border="0" /></a>
                    </td>
                </tr>
            </table>
            <table width="691px" border="0" cellpadding="0" cellspacing="0" class="box" align="center">
                <tr>
                    <td class="boxmid">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="main">
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" ForeColor="#5C9DE1" runat="server" Text="Survey Details" Style="font-size: large;"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Survey Name:
                                    <asp:Label runat="server" ID="lblSurveyName"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Survey Type:
                                    <asp:Label runat="server" ID="lblSurveyType"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Description:
                                    <asp:Label runat="server" ID="lblSurveyDescription"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Questions:
                                    <asp:Label runat="server" ID="lblQuestions"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlShowButtons" runat="server">
            <table width="691px" border="0" cellpadding="0" cellspacing="0" align="center">
                <tr>
                    <td align="center">
                        <asp:ImageButton ID="imgApprove" ImageUrl="~/Images/approve_btn.gif" runat="server"
                            OnClick="imgApprove_Click" OnClientClick="return confirm('Are you sure you want approve?')" />&nbsp;&nbsp;<asp:ImageButton
                                ID="imgReject" ImageUrl="~/Images/reject_btn.gif" runat="server" OnClick="imgReject_Click"
                                OnClientClick="return confirm('Are you sure you want reject?')" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    <div>
        <asp:Label ID="lblcreateshortcut" runat="server"></asp:Label>
        <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="lblcreateshortcut"
            PopupControlID="pnlcreateshortcut" BackgroundCssClass="modal">
        </cc1:ModalPopupExtender>
        <asp:Panel Style="display: none" ID="pnlcreateshortcut" runat="server" Width="100%">
            <table class="popuptable" cellspacing="0" cellpadding="0" width="700" align="center"
                border="0">
                <tbody>
                    <tr>
                        <td>
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td class="header">
                                            &nbsp;
                                        </td>
                                        <td align="right">
                                            <asp:ImageButton ID="imgclse" OnClick="imgclse_Click" runat="server" CausesValidation="false"
                                                ImageUrl="~/images/popup_close.gif"></asp:ImageButton>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table cellspacing="0" cellpadding="2" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td>
                                            Initials
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtInitials" runat="server" Width="150px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Reason for reject is mandatory."
                                                Display="Dynamic" ControlToValidate="txtInitials" ValidationGroup="g">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblRemarks" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtRemarks" runat="server" TextMode="MultiLine" Width="380px" Height="50px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="reqeditcheck" runat="server" ErrorMessage="Reason for reject is mandatory."
                                                Display="Dynamic" ControlToValidate="TxtRemarks" ValidationGroup="g">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:CheckBox ID="chkFbAutoPost" runat="server" Text="Auto post on facebook" Style="font-size: 14px;
                                                padding-left: 15px;" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:CheckBox ID="chkTwrAutoPost" runat="server" Text="Auto post on twitter" Style="font-size: 14px;
                                                padding-left: 15px;" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center">
                                            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit"
                                                ValidationGroup="g" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
