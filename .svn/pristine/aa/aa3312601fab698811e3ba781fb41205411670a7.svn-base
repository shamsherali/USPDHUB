<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OnlinePrivateCallItem.aspx.cs"
    Inherits="USPDHUB.OnlinePrivateCallItem" %>

<!DOCTYPE html>
<html>
<meta name="viewport" content="width=device-width, initial-scale=1.0">
<head id="Head1" runat="server">
    <title>Online</title>
     
    <script>
        window.onload = function () {

            var uagent = navigator.userAgent.toLowerCase();
            if (uagent.search("iphone") > -1 || uagent.search("android") > -1 || uagent.search("windows phone") > -1) {
                document.getElementById('<%=lblCallItem.ClientID%>').innerHTML = document.getElementById('<%=lblCallItem.ClientID%>').innerHTML.replace(/700 px/gi, "100%");
                document.getElementById('<%=lblCallItem.ClientID%>').innerHTML = document.getElementById('<%=lblCallItem.ClientID%>').innerHTML.replace(/700px/gi, "100%");
            }
        }
    </script>
</head>
<body style="background-color: #FFF;">
    <form id="form1" runat="server">
    <table cellpadding="0" cellspacing="0" border="0" width="60%" align="center">
        <tr>
            <td align="right">
                <a style="display: none;" href="javascript:window.print();">
                    <img src="images/OuterImages/printlabel.gif" border="0" /></a>
            </td>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td align="center" valign="top">
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td valign="top" style="padding-top: 10px; text-align: left">
                            <asp:Label ID="lblTitle" runat="server" Style="color: Green; font-weight: bold; font-size: 20px;
                                margin-left: 26px;"></asp:Label>
                            <br />
                            <asp:Label ID="lblCallItem" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
