<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="NotificationHub_POC._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">


    <style>
        *, body {
            font-family: Verdana, Geneva, Tahoma, sans-serif;
        }

        .btn {
            -webkit-border-radius: 3;
            -moz-border-radius: 3;
            border-radius: 3px;
            font-family: Arial;
            color: #ffffff;
            font-size: 16px;
            background: #3498db;
            padding: 6px 25px;
            text-decoration: none;
            font-weight: normal;
            display: inline-block;
        }

            .btn:hover {
                background: #3cb0fd;
                text-decoration: none;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>


            <table>

                <tr>
                    <td colspan="2" align="center" style="font-weight: bold;">Azure Notification Hub - Push Notification POC</td>
                    <br />
                </tr>
                <tr>
                    <td style="height: 25px;"></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label runat="server" ID="lblMessage"></asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 15px;"></td>
                </tr>
                <tr>
                    <td>Push Message: &nbsp;</td>
                    <td>
                        <asp:TextBox ID="txtPushMesssage" TextMode="MultiLine" runat="server" Width="350px" Height="70px"></asp:TextBox>
                    </td>
                </tr>
                <tr style="display: none;">
                    <td>Tab Name: &nbsp;</td>
                    <td>
                        <asp:DropDownList ID="ddlTabName" runat="server" Width="200px"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="height: 25px;"></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:LinkButton ID="btnSend" Text="Send" runat="server" OnClick="btnSend_Click" CssClass="btn"></asp:LinkButton>
                        <%--&nbsp;&nbsp;<asp:LinkButton ID="lnkActivatePrivate" Text="Activate" runat="server" OnClick="lnkActivatePrivate_Click" CssClass="btn"></asp:LinkButton>
                        <asp:LinkButton ID="btnGet" Text="Get List" runat="server"  CssClass="btn" OnClick="btnGet_Click"></asp:LinkButton>&nbsp;&nbsp;</td>--%>
                    <td>  
                      <%--<asp:LinkButton runat="server" ID="btnschedule" Text="Schedule Push"  CssClass="btn" OnClick="btnschedule_Click"></asp:LinkButton>--%>
                         </td>
                        </tr>
                <tr>
                    <td>  
                      <asp:Label runat="server" ID="lblList"></asp:Label>
                         </td>

                </tr>
                </table>
        </div>
    </form>
</body>
</html>
