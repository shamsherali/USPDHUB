<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OnlineCalendar.aspx.cs" Inherits="USPDHUB.OnlineCalendar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Online</title>
</head>
<body style="background-color: #FFF;">
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
                <table cellpadding="0" cellspacing="0" border="0" width="60%">
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
                        <td valign="top" style="padding-top: 10px; text-align: left">
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
