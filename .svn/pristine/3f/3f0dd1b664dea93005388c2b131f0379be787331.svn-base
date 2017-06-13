<%@ Page Title="" Language="C#" MasterPageFile="~/AdminHome.master" AutoEventWireup="true"
    CodeBehind="UpdateUserAppVersion.aspx.cs" Inherits="USPDHUB.Admin.UpdateUserAppVersion"
    EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <style type="text/css">
        .current
        {
            color: #74C2E1;
            font-weight: bold;
            font-size: 14px;
        }
    </style>
    <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="page-padding">
                <tr>
                    <td>
                    </td>
                    <td>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="page-title">
                            <tr>
                                <td style="padding-top: 8px;" align="left">
                                    Update Member App Version<asp:HiddenField ID="hdnSelectId" runat="server" />
                                </td>
                                <td align="left">
                                    <asp:UpdateProgress ID="UpdateProgress6" runat="server" DisplayAfter="3">
                                        <ProgressTemplate>
                                            <img src="../../images/popup_ajax-loader.gif" border="0"><span class="processing">Processing....</span>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="color: Red;">
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblerror" runat="server" Style="font-size: 14px;"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <table width="200px" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <asp:ValidationSummary ID="VSNewVersion" runat="server" ValidationGroup="V" HeaderText="The following error(s) are occurred:"
                                                    ShowSummary="true" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="background-color: #E9E9E9;
                                        padding: 10px; border: solid 1px #29A2C6;">
                                        <colgroup>
                                            <col width="175px" />
                                            <col width="200px" />
                                            <col width="175px" />
                                            <col width="200px" />
                                        </colgroup>
                                        <tr>
                                            <td style="font-weight: bold;">
                                                Select Criteria:
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="drpcategory" runat="server" OnSelectedIndexChanged="DrpcategorySelectedIndexChanged"
                                                    AutoPostBack="True">
                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="Member ID" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="Business Name" Value="6"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="font-weight: bold;">
                                                Enter
                                                <%=drpcategory.SelectedItem.Text%>:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtcategory" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtcategory"
                                                    ErrorMessage="Category Name is mandatory." ValidationGroup="g" Display="Dynamic">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-top: 5px;" align="left">
                                                &nbsp;
                                            </td>
                                            <td style="padding-top: 5px;" align="left">
                                                &nbsp;
                                            </td>
                                            <td colspan="2" style="padding-top: 5px; padding-right: 90px;" align="right">
                                                <asp:Button ID="btn" runat="server" Text="Get Details" OnClientClick="return isNumber();"
                                                    ValidationGroup="g" OnClick="BtnClick" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <asp:Panel ID="pnlBrandedApps" runat="server">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="admin-padding inputgrid">
                                <tr>
                                    <td valign="top">
                                        <asp:GridView ID="GrdBrandedApps" Style="margin-top: 5px;" runat="server" AutoGenerateColumns="False"
                                            DataKeyNames="BrandedApp_OrderID" CssClass="datagrid2" AllowPaging="True" OnPageIndexChanging="GrdBrandedApps_PageIndexChanging"
                                            Width="100%" PageSize="20">
                                            <Columns>
                                                <asp:TemplateField HeaderText="User ID">
                                                    <ItemStyle Width="100px" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblUserId" runat="server" Text='<%# Bind("UserID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Profile ID">
                                                    <ItemStyle Width="100px" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblProfileId" runat="server" Text='<%# Bind("ProfileID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Profile Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblProfileName" runat="server" Text='<%# Bind("Profile_name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Vertical">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblVertical" runat="server" Text='<%# Bind("Vertical_Name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="150px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="App Version">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAppVersion" runat="server" Text='<%# Bind("App_Version") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="150px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkEdit" runat="server" OnClick="lnkEdit_Click" CommandArgument='<%# Bind("BrandedApp_OrderID") %>'><img src="../Images/icon_modify.gif" alt='Edit' title='Edit' border='0'" /></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <HeaderStyle CssClass="title" />
                                            <EmptyDataTemplate>
                                                No data Found
                                            </EmptyDataTemplate>
                                            <EmptyDataRowStyle ForeColor="#C00000" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Panel runat="server" ID="pnlMember">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0" style="border: solid 1px #29A2C6;
                                border-top: 0px; padding: 20px;">
                                <tr>
                                    <td colspan="2" class="current">
                                        Member ID:
                                        <asp:Label ID="lblMemberId" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" class="current">
                                        Current Version:
                                        <asp:Label ID="lblCurrentVersion" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Enter New Version:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNewVersion" runat="server" MaxLength="5"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                                            ID="rfvNewVersion" runat="server" ValidationGroup="V" Display="Dynamic" ErrorMessage="New Version is mandatory."
                                            ControlToValidate="txtNewVersion">*</asp:RequiredFieldValidator>&nbsp;
                                        <asp:Button ID="btnUpdateVersion" runat="server" OnClick="btnUpdateVersion_Click"
                                            Text="Update" ValidationGroup="V" />&nbsp;<asp:Button ID="btnCancel" runat="server"
                                                Text="Cancel" CausesValidation="false" OnClick="btnCancel_Click" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
        function isNumber() {
            if (Page_ClientValidate('g')) {
                if (document.getElementById('<%=drpcategory.ClientID %>').selectedIndex == 1) {
                    var numbers = /^[0-9]+$/;
                    var inputtxt = document.getElementById("<%=txtcategory.ClientID %>").value;
                    if (inputtxt.match(numbers)) {
                        return true;
                    }
                    else {
                        alert('Please enter numerics only.');
                        return false;
                    }
                }
                else {
                    if (document.getElementById("<%=txtcategory.ClientID %>").value == "") {
                        var alertMessage = '<%=drpcategory.SelectedItem.Text%>';
                        alert(alertMessage);
                        return false;
                    }
                    return true;
                }
            }
            return false;
        }
    </script>
</asp:Content>
