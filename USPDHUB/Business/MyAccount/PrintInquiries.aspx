<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintInquiries.aspx.cs"
    Inherits="USPDHUB.Business.MyAccount.PrintInquiries" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function printevent() {
            Window.print();
        }
    </script>
</head>
<body onload="javascript:window.print();">
    <form id="form1" runat="server">
    <table style="width: 100%; text-align: left;" class="popuptable" cellspacing="0"
        cellpadding="0" border="0">
        <tbody>
            <tr>
                <td>
                    <table cellspacing="3" cellpadding="1" width="100%" border="0">
                        <colgroup>
                            <col width="135" />
                            <col width="*" />
                        </colgroup>
                        <tbody>
                            <tr>
                                <td style="color: Green;" nowrap align="left" colspan="2">
                                    Email Messages Details
                                </td>
                                <td align="right">
                                    <asp:ImageButton ID="imgbtnprint" runat="server" ImageUrl="~/images/Dashboard/printlabel.gif"
                                        border="0" OnClientClick="javascript:window.print();" />
                                </td>
                            </tr>
                            <tr>
                                <td style="font-size: 14px" nowrap>
                                    User Name:
                                </td>
                                <td style="padding-left: 10px; font-size: 14px; color: #2b60de" nowrap>
                                    <asp:Label ID="lblfn" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-size: 14px" nowrap>
                                    Contact Email:
                                </td>
                                <td style="padding-left: 10px; font-size: 14px; color: #2b60de" nowrap>
                                    <asp:Label ID="lblemail" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-size: 14px" nowrap>
                                    Phone Number:
                                </td>
                                <td style="padding-left: 10px; font-size: 14px; color: #2b60de" nowrap>
                                    <asp:Label ID="lblphone" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-size: 14px; vertical-align: top" nowrap>
                                    <asp:Label ID="lblmess" runat="server" Style="display: none;"></asp:Label>
                                    Description
                                </td>
                                <td style="padding-left: 10px; font-size: 14px; color: #2b60de">
                                    <asp:Label ID="lbldescription" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </tbody>
    </table>
    </form>
</body>
</html>
