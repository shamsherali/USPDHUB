<%@ Page Title="" Language="C#" MasterPageFile="~/AdminHome.master" AutoEventWireup="true"
    CodeBehind="WebnairItems.aspx.cs" Inherits="USPDHUB.Admin.WebnairItems" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="page-padding">
                <tr>
                    <td style="padding-left: 6px;" valign="top">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="page-title">
                            <tr>
                                <td>
                                    Webinar Management
                                    <asp:HiddenField ID="hdnsortcount" runat="server" />
                                    <asp:HiddenField ID="hdnsortdire" runat="server" />
                                    <asp:HiddenField ID="hdnPopsortcount" runat="server" />
                                    <asp:HiddenField ID="hdnPopsortdire" runat="server" />
                                </td>
                                <td>
                                    <asp:Label ID="lblerr" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td style="text-align: center;">
                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="3">
                                        <ProgressTemplate>
                                            <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="admin-padding inputgrid">
                            <tr>
                                <td valign="top">
                                    <asp:GridView ID="GrdWebnairs" Style="margin-top: 5px;" runat="server" AllowSorting="True"
                                        AutoGenerateColumns="False" DataKeyNames="SystemTipId" CssClass="datagrid2" OnRowDataBound="GrdWebnairs_RowDataBound"
                                        AllowPaging="True" OnPageIndexChanging="GrdWebnairs_PageIndexChanging" Width="100%"
                                        PageSize="10" OnSorting="GrdWebnairs_Sorting">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Title" SortExpression="Title">
                                                <ItemStyle Width="300px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTitle" runat="server" Text='<%# Bind("WebnairTitle") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="SentDate" HeaderText="Sent Date" DataFormatString="{0:MMMM d, yyyy hh:mm tt}"
                                                HtmlEncode="false" ItemStyle-Width="70px" SortExpression="SentDate" />
                                            <asp:BoundField DataField="WebnairDate" HeaderText="Date" DataFormatString="{0:MMMM d, yyyy hh:mm tt}"
                                                HtmlEncode="false" ItemStyle-Width="70px" SortExpression="WebnairDate" />
                                            <asp:TemplateField HeaderText="Location" SortExpression="Location">
                                                <ItemStyle Width="120px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Location") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Opened">
                                                <ItemStyle Width="60px" HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkOpened" runat="server" Text='<%# Bind("OpenedCount") %>' OnClick="lnkOpened_Click"
                                                        CommandArgument='<%# Bind("SystemTipId") %>'></asp:LinkButton>
                                                    (<asp:Label ID="lblTotalSent" runat="server" Text='<%# Bind("TotalSent") %>'></asp:Label>)
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Registrations">
                                                <ItemStyle Width="60px" HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkRegistrations" runat="server" Text='<%# Bind("RegistrationCount") %>'
                                                        OnClick="lnkRegisrations_Click" CommandArgument='<%# Bind("SystemTipId") %>'></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Clicks">
                                                <ItemStyle Width="60px" HorizontalAlign="Center" />
                                                <ItemTemplate>                                                   
                                                    <asp:Label ID="lblTotalClicks" runat="server" Text='<%# Bind("TotalClicks") %>'></asp:Label>
                                                </ItemTemplate>
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
                    </td>
                </tr>
            </table>
            <asp:Panel ID="pnlexportexcel" runat="server" Visible="false">
                <asp:GridView ID="grdExportexcel" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                        <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                        <asp:BoundField DataField="EmailAddress" HeaderText="Email" />
                        <asp:BoundField DataField="PhoneNumber" HeaderText="Phone" ItemStyle-Width="80px" />
                        <asp:BoundField DataField="CreatedDate" HeaderText="Date" DataFormatString="{0:MMMM d, yyyy hh:mm tt}"
                            HtmlEncode="false" ItemStyle-Width="130px" />
                    </Columns>
                </asp:GridView>
                <asp:GridView ID="grdOpenExport" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="Receiver_EmailID" HeaderText="Email ID" />
                        <asp:BoundField DataField="City_Name" HeaderText="City Name" />
                        <asp:BoundField DataField="Country_Name" HeaderText="Country Name" />
                        <asp:BoundField DataField="Browser" HeaderText="Browser" />
                        <asp:BoundField DataField="Sending_Date" HeaderText="Sent Date" HtmlEncode="false"
                            DataFormatString="{0:MMMM d, yyyy hh:mm tt}" />
                        <asp:BoundField DataField="Modified_Date" HtmlEncode="false" DataFormatString="{0:MMMM d, yyyy hh:mm tt}"
                            HeaderText="Opened Date" />
                    </Columns>
                </asp:GridView>
            </asp:Panel>
            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                <tbody>
                    <tr>
                        <td>
                            <asp:Label ID="lblRegs" runat="server"></asp:Label>
                            <cc1:ModalPopupExtender ID="ModalRegs" runat="server" TargetControlID="lblRegs" PopupControlID="pnlRegs"
                                BackgroundCssClass="modal" CancelControlID="imglogin2">
                            </cc1:ModalPopupExtender>
                            <asp:Panel Style="display: none" ID="pnlRegs" runat="server" Width="100%">
                                <table class="popuptable" cellspacing="0" cellpadding="0" width="800" align="center"
                                    border="0">
                                    <tbody>
                                        <tr>
                                            <td align="center">
                                                <asp:UpdateProgress ID="UpdateProgress5" runat="server" DisplayAfter="3">
                                                    <ProgressTemplate>
                                                        <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                                    </ProgressTemplate>
                                                </asp:UpdateProgress>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td class="header">
                                                                Registrations <span style="color: maroon; font-family: Arial; font-size: 16px;"><span
                                                                    style="color: maroon; font-family: Arial; size: 2">
                                                                    <asp:Label ID="lblWebnairTitle" runat="server"></asp:Label>
                                                                </span>
                                                            </td>
                                                            <td align="right">
                                                                <asp:ImageButton ID="imglogin2" runat="server" ImageUrl="~/images/popup_close.gif"
                                                                    CausesValidation="false"></asp:ImageButton>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" align="right" style="padding: 10px 10px 10px 0px;">
                                                                <asp:Button ID="btnExport" runat="server" Text="Export to Excel" OnClick="btnExport_Click" />
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:GridView ID="GrdRegistrations" runat="server" AllowSorting="true" Width="100%"
                                                                    CssClass="datagrid2" AutoGenerateColumns="False" PageSize="15" AllowPaging="True"
                                                                    OnSorting="GrdRegistrations_Sorting" OnPageIndexChanging="GrdRegistrations_PageIndexChanging">
                                                                    <EmptyDataRowStyle ForeColor="#C00000"></EmptyDataRowStyle>
                                                                    <Columns>
                                                                        <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" />
                                                                        <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />
                                                                        <asp:BoundField DataField="EmailAddress" HeaderText="Email" SortExpression="EmailAddress" />
                                                                        <asp:BoundField DataField="PhoneNumber" HeaderText="Phone" ItemStyle-Width="90px" />
                                                                        <asp:BoundField DataField="CreatedDate" HeaderText="Date" DataFormatString="{0:MMMM d, yyyy hh:mm tt}"
                                                                            HtmlEncode="false" ItemStyle-Width="130px" SortExpression="CreatedDate" />
                                                                    </Columns>
                                                                    <EmptyDataTemplate>
                                                                        No contacts found
                                                                    </EmptyDataTemplate>
                                                                    <HeaderStyle CssClass="title1"></HeaderStyle>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </tbody>
            </table>
            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                <tbody>
                    <tr>
                        <td>
                            <asp:Label ID="lblmailopen" runat="server"></asp:Label>
                            <cc1:ModalPopupExtender ID="ModalViews" runat="server" TargetControlID="lblmailopen"
                                PopupControlID="pnlmailopen" BackgroundCssClass="modal" CancelControlID="imglogin10">
                            </cc1:ModalPopupExtender>
                            <asp:Panel Style="display: none; min-height: 150px; max-height: 600px;" ID="pnlmailopen"
                                runat="server" Width="900px" ScrollBars="Auto">
                                <table class="popuptable" cellspacing="0" cellpadding="0" width="900" align="center"
                                    border="0">
                                    <tbody>
                                        <tr>
                                            <td align="center">
                                                <asp:UpdateProgress ID="UpdateProgress9" runat="server" DisplayAfter="3">
                                                    <ProgressTemplate>
                                                        <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                                    </ProgressTemplate>
                                                </asp:UpdateProgress>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td class="header">
                                                                Opened Emails <span style="color: maroon; font-family: Arial; font-size: 16px;"><span
                                                                    style="color: maroon; font-family: Arial; size: 2">
                                                                    <asp:Label ID="lblWTForOpen" runat="server"></asp:Label>
                                                                </span>
                                                            </td>
                                                            <td align="right">
                                                                <asp:ImageButton ID="imglogin10" runat="server" ImageUrl="~/images/popup_close.gif"
                                                                    CausesValidation="false"></asp:ImageButton>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" align="right" style="padding: 10px 10px 10px 0px;">
                                                                <asp:Button ID="btnOpenedExport" runat="server" Text="Export to Excel" OnClick="btnOpenedExport_Click" />
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:GridView ID="grdmailopen" runat="server" Width="100%" CssClass="datagrid2" AutoGenerateColumns="False"
                                                                    AllowSorting="true" PageSize="15" AllowPaging="True" OnPageIndexChanging="grdmailopen_PageIndexChanging"
                                                                    OnSorting="grdmailopen_Sorting">
                                                                    <EmptyDataRowStyle ForeColor="#C00000"></EmptyDataRowStyle>
                                                                    <Columns>
                                                                        <asp:BoundField DataField="Receiver_EmailID" HeaderText="Email ID" SortExpression="ReceiverEmail" />
                                                                        <asp:BoundField DataField="City_Name" HeaderText="City Name" SortExpression="CityName" />
                                                                        <asp:BoundField DataField="Country_Name" HeaderText="Country Name" SortExpression="CountryName" />
                                                                        <asp:BoundField DataField="Browser" HeaderText="Browser" SortExpression="Browser" />
                                                                        <asp:BoundField DataField="Sending_Date" HeaderText="Sent Date" HtmlEncode="false"
                                                                            DataFormatString="{0:MMMM d, yyyy hh:mm tt}" SortExpression="SentDate" />
                                                                        <asp:BoundField DataField="Modified_Date" HtmlEncode="false" DataFormatString="{0:MMMM d, yyyy hh:mm tt}"
                                                                            HeaderText="Opened Date" SortExpression="ModifiedDate" />
                                                                        <asp:BoundField DataField="ClickThroughs" HeaderText="Clicks" />
                                                                    </Columns>
                                                                    <HeaderStyle CssClass="title1"></HeaderStyle>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </tbody>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnExport" />
            <asp:PostBackTrigger ControlID="btnOpenedExport" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
