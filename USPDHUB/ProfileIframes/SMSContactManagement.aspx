<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SMSContactManagement.aspx.cs"
    Inherits="USPDHUB.ProfileIframes.SMSContactManagement" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../css/popupcss.css" rel="stylesheet" type="text/css" />
    <link href="../css/wowzzy_newcss.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function reloadparpage() {
            top.document.getElementById('ctl00_ctl00_cphUser_cphUser_btnclick').click();
        }
        function reloadparpage1() {
            top.document.getElementById('ctl00_ctl00_cphUser_cphUser_btncancelpop').click();
        }
    </script>
</head>
<body style="background-color: White;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="popuptable" cellspacing="0" cellpadding="0" width="800" align="center"
                border="0">
                <tbody>
                    <tr>
                        <td align="center">
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="3">
                                <ProgressTemplate>
                                    <img src="../images/popup_ajax-loader.gif" border="0"><b><font color="green">Processing....</font></b>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div style="overflow: scroll; width: 770px; height: 450px;">
                                <table class="popuptablecheckbox" cellspacing="0" cellpadding="0" width="100%">
                                    <tr>
                                        <td>
                                            *Note: Please select 1 or more contacts within your chosen group.
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CheckBox ID="chkall" runat="server" AutoPostBack="True" OnCheckedChanged="chkall_CheckedChanged"
                                                Text="All Groups"></asp:CheckBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CheckBoxList ID="drpcheck" runat="server" AutoPostBack="True" RepeatColumns="5"
                                                RepeatDirection="Horizontal" OnSelectedIndexChanged="drpcheck_SelectedIndexChanged">
                                            </asp:CheckBoxList>
                                        </td>
                                    </tr>
                                </table>
                                <asp:GridView ID="grdusercontacts" AllowSorting="true" runat="server" CssClass="datagrid2"
                                    Width="100%" OnRowDataBound="grdusercontacts_RowDataBound" OnPageIndexChanging="grdusercontacts_PageIndexChanging"
                                    AllowPaging="True" DataKeyNames="contactid,groupname,checkvalue" AutoGenerateColumns="False"
                                    PageSize="10" OnSorting="grdusercontacts_Sorting">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <img src="<%=System.Configuration.ConfigurationManager.AppSettings.Get("RootPath")%>/Images/emailarrow.gif"
                                                    width="17px" height="8" border="0" /><asp:CheckBox ID="chkSelectAll" runat="server"
                                                        AutoPostBack="True" OnCheckedChanged="chkSelectAll_CheckedChanged"></asp:CheckBox>Select
                                                All
                                            </HeaderTemplate>
                                            <ItemStyle Width="100px" CssClass="align-center"></ItemStyle>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged">
                                                </asp:CheckBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="False">
                                            <ItemStyle Width="60px"></ItemStyle>
                                            <ItemTemplate>
                                                <asp:Label ID="lblcontactid" runat="server" Text='<%# Bind("ContactID") %>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Mobile Number" SortExpression="Phone">
                                            <ItemTemplate>
                                                <asp:Label ID="lblname" runat="server" Text='<%# Bind("Mobile") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Group" SortExpression="groupname" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgroup" runat="server" Text='<%# Bind("groupname") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblcheckvalue" runat="server" Text='<%# Bind("checkvalue") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        No contacts found
                                    </EmptyDataTemplate>
                                    <EmptyDataRowStyle ForeColor="#C00000"></EmptyDataRowStyle>
                                    <HeaderStyle CssClass="ContactTitle" />
                                    <PagerStyle CssClass="pagination1" />
                                </asp:GridView>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top: 10px;">
                            <asp:Button ID="btnContinue" OnClick="btnContinue_Click" runat="server" Text="Submit"
                                OnClientClick="reloadparpage()" UseSubmitBehavior="false"></asp:Button>
                            <asp:Button ID="btnpopcancel" OnClick="btnpopcancel_Click" runat="server" Text="Cancel"
                                OnClientClick="reloadparpage1()"></asp:Button>
                        </td>
                    </tr>
            </table>
            <asp:HiddenField ID="hdnsortdire" runat="server" />
            <asp:HiddenField ID="hdnsortcount" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
