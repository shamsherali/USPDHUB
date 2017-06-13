<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderCompleted.aspx.cs"
    Inherits="USPDHUB.OP.twoviecom.OrderCompleted" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mobile App for instant two way communication for organizations and their customers
    </title>
    <link rel="icon" href="<%=Page.ResolveClientUrl("~/images/tvfav.ico") %>" type="image/x-icon" />
    <link rel="shortcut icon" href="<%=Page.ResolveClientUrl("~/images/tvfav.ico") %>"
        type="image/x-icon" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="mainwrapper">
        <div id="container">
            <div id="bannersecondary">
                <div id="bannerleft">
                    <img src="<%=Page.ResolveClientUrl("~/images/TVOuterImages/logo.png")%>" alt="Two Vie"
                        border="0"></div>
                <!--bannerleft-->
                <div id="rightcol">
                    <div id="navigation">
                    </div>
                    <!--navigation-->
                </div>
                <!--bannerright-->
            </div>
            <!--bannersecondary-->
        </div>
        <div id="content">
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="body_bg" style="height: 380px;">
                <tr>
                    <td valign="top">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="page-width">
                            <tr>
                                <td class="valign-top">
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="font-family: Arial; font-size: 16px; font-weight: bold;
                                                color: Green; padding-top: 30px; line-height: 25px;">
                                                <asp:Label ID="lblEmailID1" runat="server" CssClass="lable"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                                    <tr>
                                                        <td>
                                                            <img src="<%=Page.ResolveClientUrl("~/images/Secure/junkmail.gif")%>" border="0"
                                                                title="Send an email marketing piece or newsletter.">
                                                        </td>
                                                        <td style="font-family: Arial; font-size: 16px; font-weight: bold; color: Green;
                                                            padding-left: 20px;">
                                                            <span>NOTE: If you do not see the email delivered to your "inbox", please check your
                                                                junk mail folder for an email from info@twovie.com before contacting customer service.
                                                            </span>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="center">
                                                <a href="<%=Page.ResolveClientUrl("login.aspx")%>">
                                                    <img src="<%=Page.ResolveClientUrl("~/images/Secure/btn_continue.gif")%>" style="border: 0px;" /></a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblMyMess" runat="server" CssClass="lable"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <asp:HiddenField ID="hdnorderid" runat="server" />
            <asp:HiddenField ID="hdnamount" runat="server" />
        </div>
    </div>
    </form>
</body>
</html>
