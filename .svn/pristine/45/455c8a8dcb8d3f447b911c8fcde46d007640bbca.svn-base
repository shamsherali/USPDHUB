<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true"
    CodeBehind="ManageBlockedSenders.aspx.cs" Inherits="USPDHUB.Business.MyAccount.ManageBlockedSenders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <style>
        .title1
        {
            background: url("../../images/Dashboard/pb_header.gif") repeat-x scroll 0 0 rgba(0, 0, 0, 0);
            color: #FFFFFF;
            height: 35px !important;
            font-size: 12px;
        }
        .headerrow
        {
            padding-left: 5px;
        }
    </style>
    <script type="text/javascript">
        function SelectAllMsgs(headerchk) {
            var grdNewsletercheck = document.getElementById('<%=this.gvDevices.ClientID%>');
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
            var grdTipscheck = document.getElementById('<%= this.gvDevices.ClientID %>');
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
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="datagrid nomargin-bottom">
                            <tr>
                                <td>
                                    <asp:GridView ID="gvDevices" runat="server" DataKeyNames="Device_ID" AutoGenerateColumns="false"
                                        OnRowDataBound="gvDevices_RowDataBound" CssClass="datagrid2">
                                        <HeaderStyle CssClass="title1" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="chkSelectAllMsgs" runat="server" Text="Select All" onclick="SelectAllMsgs(this);" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblModuleType" Style="display: none;" runat="server" Text='<%#Eval("ModuleType") %>'></asp:Label>
                                                    <asp:CheckBox ID="chkMessages" runat="server" />
                                                </ItemTemplate>
                                                <ItemStyle VerticalAlign="Top" />
                                                <HeaderStyle HorizontalAlign="Left" Width="100px" CssClass="headerrow" />
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Wrap="true" HeaderText="Device ID" ItemStyle-Width="810px">
                                                <ItemTemplate>
                                                    <a href="JavaScript:divexpandcollapse('divv<%# Container.DataItemIndex + 1 %>');">
                                                        <img id="imgdivv<%# Container.DataItemIndex + 1 %>" width="9px" border="0" src="../../images/plus.png" /></a>
                                                    <%#Eval("SplitID")%>
                                                    <div id="divv<%# Container.DataItemIndex + 1 %>" style="display: none; position: relative;
                                                        left: 20px; overflow: auto">
                                                        <asp:GridView ID="gvDevMessages" runat="server" AutoGenerateColumns="false" GridLines="None"
                                                            OnRowDataBound="gvMessages_RowDataBound" CssClass="datagrid2">
                                                            <HeaderStyle CssClass="title1" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Subject" ItemStyle-Width="210px">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lnkcontactname" runat="server" Text='<%#Eval("Subject") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                    <HeaderStyle HorizontalAlign="Center" Font-Size="12px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Message" ItemStyle-Width="400px" ItemStyle-Wrap="true">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbldescription" runat="server" Text='<%#Eval("Message") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                    <HeaderStyle Font-Size="12px" HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="CREATED_DT" HeaderText="Date &amp; Time Sent" SortExpression="DateSent"
                                                                    DataFormatString="{0:MM/dd/yyyy hh:mm tt PST}" ItemStyle-Width="145px" />
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <asp:HiddenField ID="hdnsortcount" runat="server"></asp:HiddenField>
                                    <asp:HiddenField ID="hdnsortdire" runat="server"></asp:HiddenField>
                                </td>
                            </tr>
                            <%if (gvDevices.Rows.Count == 0)
                              {%>
                            <tr>
                                <td align="center" style="height: 50px; font-size: 13px; color: red;">
                                    <%--There are no app messages at this time.--%>
                                    There are no blocked users at this time.
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
                                                <asp:Button ID="btnUnblockUsers" runat="server" Text="Unblock Sender" OnClick="btnUnblockUsers_Click" />
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
    <script language="javascript" type="text/javascript">
        function Confirmationbox(frm, type) {
            var result = false;
            for (i = 0; i < frm.length; i++) {
                // Look for our checkboxes only
                if (frm.elements[i].name.indexOf("chkMessages") != -1) {
                    // If any are checked then confirm alert, otherwise nothing happens
                    if (frm.elements[i].checked) {
                        return true;
                    }
                }
            }
            var msg = 'Please select at least one checkbox to unblock senders.';
            alert(msg);
            return false;
        }
        function divexpandcollapse(divname) {
            var div = document.getElementById(divname);
            var img = document.getElementById('img' + divname);
            if (div.style.display == "none") {
                div.style.display = "inline";
                img.src = "../../images/minus.png";
            } else {
                div.style.display = "none";
                img.src = "../../images/plus.png";
            }
        }
    </script>
</asp:Content>
