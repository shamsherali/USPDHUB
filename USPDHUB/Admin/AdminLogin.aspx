<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/AdminInterface.master" CodeBehind="AdminLogin.aspx.cs" Inherits="USPDHUB.Admin.AdminLogin" %>

<%@ Register Src="~/Controls/AdminLogin.ascx" TagName="Login" TagPrefix="uc2" %>
<asp:content contentplaceholderid="cphUser" id="logout" runat="server">
<table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td align="center">
      <asp:Label ID="lblmsg" runat="server" >
      </asp:Label>
    </td>
  </tr>
  <tr>
    <td>
      <uc2:Login ID="loginbox" runat="server" />
    </td>
  </tr>
</table>
</asp:content>
