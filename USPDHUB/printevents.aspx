<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="printevents.aspx.cs" Inherits="USPDHUB.printevents" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Event Details</title>
    <script type="text/javascript">
        function printevent() {
            Window.print();
        }
    </script>
    <style>
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
</head>
<body>
    <form id="form1" runat="server" style="vertical-align: top;">
    <table width="450px" cellspacing="0" cellpadding="5" align="center" style="border: 2px solid #FFCC00;">
        <tr>
            <td style="vertical-align: top;">
                <table width="100%" border="0" height="100%" cellspacing="0" cellpadding="0" class="templatepopupbrdr"
                    style="vertical-align: top;">
                    <tr>
                        <td colspan="3" style="vertical-align: top;">
                            <asp:Label ID="lblmessage" runat="server" Font-Bold="true"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="valign" style="vertical-align: top;">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td colspan="3" align="right">
                                        <asp:ImageButton ID="imgbtnprint" runat="server" ImageUrl="~/images/OuterImages/printlabel.gif"
                                            border="0" OnClientClick="javascript:window.print();" />
                                    </td>
                                </tr>
                                <tr>
                                    <%if (logoflag == true)
                                      { %>
                                    <td class="templatelogo" >
                                        <asp:ImageButton ID="imglogo" runat="server" />
                                    </td>
                                    <td style="width: 10px;">
                                        &nbsp;
                                    </td>
                                    <%} %>
                                    <td class="templateheader">
                                        <asp:Label ID="lblbusinesssname" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="templatesubtitle"
                                id="tbltitle" runat="server" style="line-height:20px;">
                                <tr>
                                    <td>
                                        <asp:Label ID="lbltitle" runat="server"></asp:Label>
                                        <br />
                                        <span style="font-size: 12px; color: #333333;">
                                            <asp:Label ID="lblSevntdate" runat="server"></asp:Label></span>
                                    </td>
                                </tr>
                            </table>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="templateintbl"
                                id="tbldetails" runat="server">
                                <tr>
                                    <td class="tempheader">
                                    <%if (lbldesc.Text != "")
                                      { %>
                                        Event Details
                                        <%} %>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tempbody" align="center">
                                        <asp:Label ID="lbldesc" runat="server" CssClass="hyperlink"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
