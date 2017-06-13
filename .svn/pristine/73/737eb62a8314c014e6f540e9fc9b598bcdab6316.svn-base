<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchemaNameChange.aspx.cs"
    Inherits="SchemaNameChange.SchemaNameChange" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style>
        .btn
        {
            -webkit-border-radius: 3;
            -moz-border-radius: 3;
            border-radius: 3px;
            font-family: Arial;
            color: #ffffff;
            font-size: 16px;
            background: #3498db;
            padding: 7px 15px 7px 15px;
            text-decoration: none;
        }
        
        .btn:hover
        {
            background: #3cb0fd;
            text-decoration: none;
        }
        
        body
        {
            font-family: Segoe UI;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div>
                <h3 style="color: #DC7224;">
                    Change App Scheme Name :
                </h3>
                <table cellpadding="5">
                    <colgroup>
                        <col width="250px" />
                        <col width="*" />
                    </colgroup>
                    <tr>
                        <td align="center" colspan="2">
                            <div style="width: 300px; margin: 0 auto;">
                                <asp:ValidationSummary ID="ValidateUserDetails" runat="server" ForeColor="Red" Style="text-align: left;"
                                    ValidationGroup="ABC" HeaderText="The following error(s) occurred:" />
                            </div>
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="3">
                                <ProgressTemplate>
                                    <img src="images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                            <br />
                            <asp:Label ID="lblmess" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Test Account Web Service Name:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlAppName" runat="server" Width="250px" 
                            OnSelectedIndexChanged="ddlAppName_OnSelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            User ID:
                        </td>
                        <td>
                            <asp:TextBox ID="txtUserID" runat="server" ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            App Scheme Name
                            <br />
                            (Web Service Name):
                            <br />
                            <font size='1' style="font-weight: bold;">  Note: We used web service name as app scheme name. </font>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtSchemaName" Width="250px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="txtSchemaName"
                                runat="server" ErrorMessage="Schema Name is mandatory." Display="Dynamic" ValidationGroup="ABC"
                                SetFocusOnError="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:LinkButton runat="server" ID="btnUpdate" Text="Update App Scheme Name" CssClass="btn"
                                ValidationGroup="ABC" OnClick="btnUpdate_OnClick" />
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
