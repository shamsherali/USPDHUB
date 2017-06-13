<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OnlineBulletin.aspx.cs"
    Inherits="USPDHUB.OnlineBulletin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Online</title>
    <style>
        .lblfont
        {
            font-size: 11px;
        }
        .headerbgcolor
        {
            background-color: #000080;
        }
    </style>
</head>
<body style="background-color: #FFF; font-family: Arial, Helvetica, sans-serif; font-size:14px;">
    <form id="form1" runat="server">
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
                <table cellpadding="0" cellspacing="0" border="0" width="40%">
                    <tr>
                        <td valign="top" style="padding-top: 10px; text-align: left">
                            <asp:Label ID="lblTitle" runat="server" Style="color: Green; font-weight: bold; font-size: 16px;
                                margin-left: 0px;"></asp:Label>
                            <br />
                            <br />
                            <asp:Label ID="lblbulletin" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
