<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintPSCQRCode.aspx.cs"
    Inherits="USPDHUB.PrintPSCQRCode" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>&nbsp; </title>
    <script type="text/javascript" src="../../Scripts/jquery.js"></script>
    <script type="text/javascript" src="../../Scripts/jsapi.js" language="javascript"></script>
    <style type="text/css">
        @media print
        {
            #printbtn
            {
                display: none;
            }
        }
    </style>
</head>
<body onload="javascript:window.print();" style="background-color: #FFF; font-family: Helvetica Neue,Helvetica,Arial,Lucida Grande,sans-serif;">
    <form id="form1" runat="server">
    <table cellpadding="0" cellspacing="0" border="0" width="30%" align="center">
        <tr>
            <td align="right">
                <a id="printbtn" href="javascript:window.print();">
                    <img src="images/OuterImages/printlabel.gif" border="0" /></a>
            </td>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="0" border="0" width="100%" style="padding-top: 10px;">
        <tr>
            <td align="center" valign="top">
                <table cellspacing="0" cellpadding="0" width="60%" border="0" align="center">
                    <tbody>
                       
                        <tr>
                            <td>
                                 <asp:Literal ID="litQRCode" runat="server"></asp:Literal>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
