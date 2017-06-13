<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true"
    CodeBehind="ManageBlockedSenders1.aspx.cs" Inherits="USPDHUB.Business.MyAccount.ManageBlockedSenders1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <script type="text/javascript">
        function SelectAllMsgs(headerchk) {
            var grdNewsletercheck = document.getElementById('<%=grdNewsletercontacts.ClientID%>');
            var i;
            if (headerchk.checked) {
                for (i = 0; i < grdNewsletercheck.rows.length; i++) {
                    var inputs = grdNewsletercheck.rows[i].getElementsByTagName('input');
                    inputs[0].checked = true;
                }
            }
            else {
                for (i = 0; i < grdNewsletercheck.rows.length; i++) {
                    var inputs = grdNewsletercheck.rows[i].getElementsByTagName('input');
                    inputs[0].checked = false;
                }
            }
        }
        function SelectMsgscheckboxes(header) {
            var count = 0;
            var rowcount = 0;
            var grdTipscheck = document.getElementById('<%= this.grdNewsletercontacts.ClientID %>');
            var headerchk = document.getElementById(header);
            var Inputs = grdTipscheck.getElementsByTagName("input");
            var itemCheckBox = "chkMessages";
            for (var n = 0; n < Inputs.length; ++n) {
                if (Inputs[n].type == 'checkbox'
                    && Inputs[n].id.indexOf(itemCheckBox, 0) >= 0) {
                    if (Inputs[n].checked)
                        count++;
                    rowcount++;
                }
            }
            if (count == rowcount) {
                headerchk.checked = true;
            }
            else {
                headerchk.checked = false;
            }

        }

        function SelectAllTips(headerchk) {
            var grdTipscheck = document.getElementById('<%=GrdTips.ClientID%>');
            var i;
            if (headerchk.checked) {
                for (i = 0; i < grdTipscheck.rows.length; i++) {
                    var inputs = grdTipscheck.rows[i].getElementsByTagName('input');
                    inputs[0].checked = true;
                }
            }
            else {
                for (i = 0; i < grdTipscheck.rows.length; i++) {
                    var inputs = grdTipscheck.rows[i].getElementsByTagName('input');
                    inputs[0].checked = false;
                }
            }
        }

        function SelectTipscheckboxes(header) {
            var count = 0;
            var rowcount = 0;
            var grdTipscheck = document.getElementById('<%= this.GrdTips.ClientID %>');
            var headerchk = document.getElementById(header);
            var Inputs = grdTipscheck.getElementsByTagName("input");
            var itemCheckBox = "chkTips";
            for (var n = 0; n < Inputs.length; ++n) {
                if (Inputs[n].type == 'checkbox'
                    && Inputs[n].id.indexOf(itemCheckBox, 0) >= 0) {
                    if (Inputs[n].checked)
                        count++;
                    rowcount++;
                }
            }
            if (count == rowcount) {
                headerchk.checked = true;
            }
            else {
                headerchk.checked = false;
            }

        }
        function Confirmationbox(frm, type) {
            var result = false;
            for (i = 0; i < frm.length; i++) {
                // Look for our checkboxes only
                if (frm.elements[i].name.indexOf("chkMessages") != -1) {
                    // If any are checked then confirm alert, otherwise nothing happens
                    if (frm.elements[i].checked) {
                        result = true;
                    }
                }
                if (frm.elements[i].name.indexOf("chkTips") != -1) {
                    // If any are checked then confirm alert, otherwise nothing happens
                    if (frm.elements[i].checked) {
                        result = true;
                    }
                }
            }
            var msg = '';
            if (result) {
                msg = 'Are you sure you want to unblock selected senders?';
                return confirm(msg);
            }
            else {
                msg = 'Please select at least one checkbox to unblock senders.';
                alert(msg);
                return false;
            }
        }
    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" class="page-padding">
                <tr>
                    <td class="valign-top">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="page-title">
                            <tr>
                                <td>
                                    Blocked Senders
                                </td>
                                <td style="padding-right: 70px;">
                                    <asp:UpdateProgress ID="UpdateProgress6" runat="server" DisplayAfter="3">
                                        <ProgressTemplate>
                                            <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="inputtable">
                            <%if (NewslettersCount > 0)
                              { %>
                            <tr>
                                <td style="padding-top: 10px; padding-left: 5px; color: #005AA0; font-weight: bold;">
                                    Blocked Senders Messages from Contact Us
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="datagrid nomargin-bottom">
                                        <tr>
                                            <td>
                                                <asp:GridView ID="grdNewsletercontacts" runat="server" DataKeyNames="Message_ID"
                                                    AllowSorting="true" AutoGenerateColumns="False" AllowPaging="true" Width="100%"
                                                    OnPageIndexChanging="grdNewsletercontacts_PageIndexChanging" OnRowDataBound="grdNewsletercontacts_RowDataBound"
                                                    CssClass="datagrid2">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:CheckBox ID="chkSelectAllMsgs" runat="server" Text="Select All" onclick="SelectAllMsgs(this);"
                                                                    OnCheckedChanged="ChkSelectAllMsgsCheckedChanged" />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chkMessages" runat="server" OnCheckedChanged="ChkMessagesCheckedChanged" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="8%" />
                                                            <HeaderStyle Font-Size="12px" HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Subject">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lnkcontactname" runat="server" Text='<%#Eval("Subject") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="25%" />
                                                            <HeaderStyle HorizontalAlign="Center" Font-Size="12px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Message">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbldescription" runat="server" Text='<%#Eval("Message") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="45%" />
                                                            <HeaderStyle Font-Size="12px" HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="CREATED_DT" HeaderText="Date &amp; Time Sent" SortExpression="DateSent"
                                                            DataFormatString="{0:MM/dd/yyyy hh:mm tt PST}" ItemStyle-Width="50%" />
                                                    </Columns>
                                                    <EmptyDataTemplate>
                                                        <asp:Label ID="lblBUempty" runat="server" Text="There are no mobile app inquiries at this time."
                                                            Font-Bold="true" Font-Size="15px" ForeColor="#E8C41D"></asp:Label>
                                                    </EmptyDataTemplate>
                                                    <HeaderStyle CssClass="title1" />
                                                </asp:GridView>
                                                <asp:HiddenField ID="hdnsortcount" runat="server"></asp:HiddenField>
                                                <asp:HiddenField ID="hdnsortdire" runat="server"></asp:HiddenField>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <%} %>
                            <%if (TipsCount > 0)
                              { %>
                            <tr>
                                <td style="padding-top: 10px; padding-left: 5px; color: #005AA0; font-weight: bold;">
                                    <%=DisplayFeedTip %>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="datagrid nomargin-bottom">
                                        <tr>
                                            <td>
                                                <asp:GridView ID="GrdTips" runat="server" DataKeyNames="Message_ID" AllowSorting="true"
                                                    AutoGenerateColumns="False" AllowPaging="true" Width="100%" OnPageIndexChanging="GrdTips_PageIndexChanging"
                                                    OnRowDataBound="GrdTips_RowDataBound" CssClass="datagrid2">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:CheckBox ID="chkSelectAllTips" runat="server" Text="Select All" onclick="SelectAllTips(this);"
                                                                    OnCheckedChanged="ChkSelectAllTipsCheckedChanged" />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chkTips" runat="server" OnCheckedChanged="ChkTipsCheckedChanged" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="8%" />
                                                            <HeaderStyle Font-Size="12px" HorizontalAlign="left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Subject">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lnktips" runat="server" Text='<%#Eval("Subject") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="25%" />
                                                            <HeaderStyle HorizontalAlign="Center" Font-Size="12px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Message">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbldescription" runat="server" Text='<%#Eval("Message") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="45%" />
                                                            <HeaderStyle Font-Size="12px" HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <EmptyDataTemplate>
                                                        <asp:Label ID="lblBUempty" runat="server" Text="There are no mobile app inquiries at this time."
                                                            Font-Bold="true" Font-Size="15px" ForeColor="#E8C41D"></asp:Label>
                                                    </EmptyDataTemplate>
                                                    <HeaderStyle CssClass="title1" />
                                                </asp:GridView>
                                            </td>
                                            <asp:HiddenField ID="hdnsortcnt" runat="server"></asp:HiddenField>
                                            <asp:HiddenField ID="hdnsortdir" runat="server"></asp:HiddenField>
                                            <asp:HiddenField ID="hdnPermissionType" runat="server"></asp:HiddenField>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <%} %>
                            <%if (NewslettersCount == 0 && TipsCount == 0)
                              {%>
                            <tr>
                                <td align="center" style="height: 50px; font-size: 13px; color: red;">
                                    <%--There are no app messages at this time.--%>
                                    There are no blocked senders at this time.
                                </td>
                            </tr>
                            <%}
                              else
                              { %>
                            <tr>
                                <td>
                                    <table border="0" width="100%" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="padding-left: 5px;">
                                                &nbsp;
                                            </td>
                                            <td align="right" style="padding-right: 5px;">
                                                <asp:Button ID="btnBlockUsers" runat="server" Text="Unblock Sender" OnClick="btnBlockUsers_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <%} %>
                            <tr>
                                <td align="center" style="background-color: #D2E5FA; border: 1px solid #D1DDEA; padding: 7px 0px 7px 0px;">
                                    <asp:Button ID="btnBack" CssClass="button" runat="server" Text="Back" OnClick="btnBack_Click"
                                        CausesValidation="false" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
