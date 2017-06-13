<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RenewalExpiryDate.aspx.cs" Inherits="SchemaNameChange.RenewalExpiryDate" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Renewal Expiry Date</title>
    <script type="text/javascript">
        function dateselect(ev) {
            var calendarBehavior1 = $find("Calendar1");
            var d = calendarBehavior1._selectedDate;
            var now = new Date();
            calendarBehavior1.get_element().value = d.format("MM/dd/yyyy") + " " + now.format("HH:mm:ss:sss")
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 100%; margin: 0; padding: 0;">
        <div style="width: 500px; margin: 0 auto; border: 1px solid; padding: 10px; text-align: center;
            background-color: #f1eff5; min-height: 195px;">
            <span style="padding-bottom: 15px; color: Green; margin-left: 120px; float: left;
                font-size: 20px;">Renewal Expiry Date</span>
            <table width="400">
                <tr>
                    <td align="right">
                        <asp:Label Text="User ID" ID="lblUID" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUid" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label Text="Renewal Date" ID="lblRDate" runat="server"></asp:Label>
                    </td>
                    <td>
                        <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                        </cc1:ToolkitScriptManager>
                        <asp:TextBox ID="txtRDate" runat="server"></asp:TextBox>
                        <asp:ImageButton ID="imgPopup" ImageUrl="images/calendar.png" ImageAlign="Bottom"
                            runat="server" />
                        <cc1:CalendarExtender ID="Calendar1" PopupButtonID="imgPopup" runat="server" BehaviorID="Calendar1"
                            TargetControlID="txtRDate" >
                        </cc1:CalendarExtender>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" Style="padding: 5px 15px; background-color: #9689ff;
                            border-radius: 6px;" runat="server" Text="Submit" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Label ID="lblMsg" runat="server" Visible="false" Text="" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>