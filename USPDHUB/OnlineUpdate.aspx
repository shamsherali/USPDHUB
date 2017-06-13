<%@ Page Language="C#" AutoEventWireup="true" Inherits="OnlineUpdate" CodeBehind="OnlineUpdate.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Online</title>
    <style type="text/css">
        body
        {
            padding: 5px;
            margin: 0px;
            background: #ffffff !important;
            vertical-align: top;
        }
        hyperlink a
        {
            color: Blue;
        }
        hyperlink a:hover
        {
            color: Blue;
        }
    </style>
    <link rel="icon" href="images/wow.ico" type="image/x-icon" />
    <link rel="shortcut icon" href="images/wow.ico" type="image/x-icon" />
</head>
<body>
    <form id="form1" runat="server" style="vertical-align: top;">
    <table width="450px" cellspacing="0" cellpadding="5" align="center" style="border: 2px solid #FFCC00;">
        <tr>
            <td style="vertical-align: top;">
                <table width="100%" border="0" height="100%" cellspacing="0" cellpadding="0" class="templatepopupbrdr"
                    style="vertical-align: top;">
                    <tr>
                        <td align="right">
                            <a href="javascript:window.print();">
                                <img src="images/OuterImages/printlabel.gif" border="0" /></a>
                        </td>
                    </tr>
                    <tr>
                        <td>
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
    </form>
</body>
</html>
