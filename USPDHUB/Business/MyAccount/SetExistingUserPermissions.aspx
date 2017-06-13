<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true"
    CodeBehind="SetExistingUserPermissions.aspx.cs" Inherits="USPDHUB.Business.MyAccount.SetExistingUserPermissions"
    ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <asp:DropDownList ID="ddlParentUsers" runat="server" ></asp:DropDownList>
    <asp:Button ID="btnInsertPerms" runat="server" OnClick="btnInsertPerms_Click" Text="Submit" />
</asp:Content>
