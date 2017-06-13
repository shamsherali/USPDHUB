<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintMessages.aspx.cs"
    Inherits="Business_MyAccount_PrintMessages" %>

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
    <div id="dvprint" runat="server">
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
                                <td style="color:Green;" nowrap align="left" colspan="2">
                                    Message Details
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
                                    <asp:Label ID="lblmess" runat="server"></asp:Label>
                                </td>
                                <td style="padding-left: 10px; font-size: 14px; color: #2b60de">
                                    <asp:Label ID="lbldescription" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-size: 14px; vertical-align: top" nowrap>
                                    Location:
                                </td>
                                <td style="padding-left: 10px; font-size: 14px; color: #2b60de">
                                    <asp:Label ID="lblLocation" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">
                                    <%if (lblImg.Text != "" && lblImg.Text != null)
                                      { %>
                                    <div style="width: 520px;">
                                        <asp:Label ID="lblImg" runat="server"></asp:Label>
                                    </div>
                                    <%} %>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </tbody>
    </table>
    </div>
    <div id="dvprintPubiccall" runat="server" style="display:none;">
      <table style="width: 100%; text-align: left;" class="popupPublictable" cellspacing="0"
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
                                                                        <td class="header" nowrap align="left" colspan="2">
                                                                            <asp:Label ID="lblTitle" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td align="right">
                                                                            
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="font-size: 14px" nowrap>
                                                                           Custom message:
                                                                        </td>
                                                                        <td style="padding-left: 10px; font-size: 14px; color: #2b60de" nowrap>
                                                                            <asp:Label ID="lblCustomMsg" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                     <tr>
                                                                        <td style="font-size: 14px" nowrap>
                                                                            Contact Name:
                                                                        </td>
                                                                        <td style="padding-left: 10px; font-size: 14px; color: #2b60de" nowrap>
                                                                            <asp:Label ID="lblContactName" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="font-size: 14px" nowrap>
                                                                            Contact Email:
                                                                        </td>
                                                                        <td style="padding-left: 10px; font-size: 14px; color: #2b60de" nowrap>
                                                                            <asp:Label ID="lblContactEmail" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="font-size: 14px" nowrap>
                                                                            Phone Number:
                                                                        </td>
                                                                        <td style="padding-left: 10px; font-size: 14px; color: #2b60de" nowrap>
                                                                            <asp:Label ID="lblPhoneNum" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="font-size: 14px" nowrap>
                                                                            <asp:Label ID="lbllocationtext" runat="server" Text="Location:"></asp:Label>
                                                                        </td>
                                                                        <td style="padding-left: 10px; font-size: 14px; color: #2b60de" nowrap>
                                                                            <asp:Label ID="lblPublicCallLocation" runat="server" ></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                     <tr>
                                                                        <td style="font-size: 14px" nowrap>
                                                                             <asp:Label ID="lblimagetext" runat="server" Text="Image:"></asp:Label> 
                                                                        </td>
                                                                        <td style="padding-left: 10px; font-size: 14px; color: #2b60de" nowrap>
                                                                            <asp:Image ID="imgPublicImage" runat="server" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="font-size: 14px; vertical-align: top" nowrap>
                                                                            <asp:Label ID="Label5" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td style="padding-left: 10px; font-size: 14px; color: #2b60de">
                                                                            <asp:Label ID="Label6" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                   
                                                                                                                                      
                                                                </tbody>
                                                            </table>
                                                        </td>
                                                    </tr>
        </tbody>
    </table>
    </div>

        <div id="dvprintprivatecall" runat="server" style="display:none;">
      <table style="width: 100%; text-align: left;" class="popupPublictable" cellspacing="0"
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
                                                                        <td class="header" nowrap align="left" colspan="2">
                                                                            <asp:Label ID="lblPrivatetitle" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td align="right">
                                                                            
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="font-size: 14px" nowrap>
                                                                           Custom message:
                                                                        </td>
                                                                        <td style="padding-left: 10px; font-size: 14px; color: #2b60de" nowrap>
                                                                            <asp:Label ID="lblprivateCallMsg" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                     <tr>
                                                                        <td style="font-size: 14px" nowrap>
                                                                            Contact Name:
                                                                        </td>
                                                                        <td style="padding-left: 10px; font-size: 14px; color: #2b60de" nowrap>
                                                                            <asp:Label ID="lblPrivateName" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="font-size: 14px" nowrap>
                                                                            Contact Email:
                                                                        </td>
                                                                        <td style="padding-left: 10px; font-size: 14px; color: #2b60de" nowrap>
                                                                            <asp:Label ID="lblPrivateEmail" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="font-size: 14px" nowrap>
                                                                            Phone Number:
                                                                        </td>
                                                                        <td style="padding-left: 10px; font-size: 14px; color: #2b60de" nowrap>
                                                                            <asp:Label ID="lblPrivateNumber" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="font-size: 14px" nowrap>
                                                                            <asp:Label ID="Label8" runat="server" Text="Location:"></asp:Label>
                                                                        </td>
                                                                        <td style="padding-left: 10px; font-size: 14px; color: #2b60de" nowrap>
                                                                            <asp:Label ID="lblPrivatelocation" runat="server" ></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                     <tr>
                                                                        <td style="font-size: 14px" nowrap>
                                                                             <asp:Label ID="Label10" runat="server" Text="Image:"></asp:Label> 
                                                                        </td>
                                                                        <td style="padding-left: 10px; font-size: 14px; color: #2b60de" nowrap>
                                                                            <asp:Image ID="Image1" runat="server" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="font-size: 14px; vertical-align: top" nowrap>
                                                                            <asp:Label ID="Label11" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td style="padding-left: 10px; font-size: 14px; color: #2b60de">
                                                                            <asp:Label ID="Label12" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                   
                                                                                                                                      
                                                                </tbody>
                                                            </table>
                                                        </td>
                                                    </tr>
        </tbody>
    </table>
    </div>
    </form>
</body>
</html>
