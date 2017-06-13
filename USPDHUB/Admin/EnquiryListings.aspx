<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnquiryListings.aspx.cs"
    Inherits="USPDHUB.Admin.EnquiryListings" MasterPageFile="~/AdminHome.master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphUser" runat="Server">
    <asp:ScriptManager ID="smgr1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" class="page-padding">
                <tr>
                    <td class="valign-top">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="page-title">
                            <tr>
                                <td>
                                    Verifications
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
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td style="padding-top: 10px; padding-left: 5px; color: #005AA0; font-weight: bold;">
                                    Pending Verifications
                                </td>
                                <td align="right" style="padding-right: 10px;">
                                    <asp:Panel ID="pnlSerachPending" runat="server">
                                        Vertical:
                                        <asp:DropDownList runat="server" ID="ddlVerticalsPending">
                                        </asp:DropDownList>
                                        &nbsp;&nbsp;Country:
                                        <asp:DropDownList runat="server" ID="ddlCountryPending">
                                            <asp:ListItem Text="-- Select --" Value=""></asp:ListItem>
                                            <asp:ListItem Text="United States" Value="United States"></asp:ListItem>
                                            <asp:ListItem Text="India" Value="India"></asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp;&nbsp;<asp:Button ID="btnSearchPending" runat="server" Text="Submit" OnClick="btnSearchPending_Click" />
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                        <table border="0" cellpadding="0" cellspacing="0" class="datagrid nomargin-bottom">
                            <tr>
                                <td>
                                    <asp:GridView ID="grdVerifyListings" runat="server" DataKeyNames="Inquiry_ID" AllowSorting="true"
                                        AutoGenerateColumns="False" AllowPaging="true" Width="100%" OnPageIndexChanging="grdVerifyListings_PageIndexChanging"
                                        CssClass="datagrid2" OnSorting="grdVerifyListings_Sorting">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Subscription Type">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSubscriptionType" runat="server" Font-Bold="true" Text='<%#Eval("SubscriptionType") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="100px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Agency Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAgencyName" runat="server" Text='<%#Eval("Agency_Name") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="100px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Contact Person">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblContactPerson" runat="server" Text='<%#Eval("Contact_Person") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="150px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Phone Number">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPhoneNo" runat="server" Text='<%#Eval("Phone_Number") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="150px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Email Address">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("Email_Address") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="150px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Remarks">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRemarks" runat="server" Text='<%#Eval("Remarks") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="100px" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Created_Date" ItemStyle-Width="250px" HeaderText="Created Date"
                                                DataFormatString="{0:MM/dd/yyyy hh:mm tt PST}" />
                                            <asp:BoundField DataField="Call_Date" ItemStyle-Width="250px" HeaderText="Call Date &amp; Time"
                                                DataFormatString="{0:MM/dd/yyyy hh:mm tt PST}" SortExpression="CallDate" />
                                            <asp:TemplateField HeaderText="Account Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblstatus" runat="server" Text='<%#Eval("Verified_Status") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Verify">
                                                <ItemTemplate>
                                                    <asp:LinkButton runat="server" ID="btnEdit" Text="<img src='../../Images/Dashboard/icon_modify.gif' title='Verify' border='0'"
                                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Inquiry_ID") %>' OnClick="btnEdit_Click"></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle Width="10px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Delete">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%# Eval("Inquiry_ID") %>'
                                                        OnClick="lnkDelete_Click" Text="<img src='../../Images/Dashboard/icon_delete.gif'width='25px' height='25px' title='Delete' border='0'"
                                                        CausesValidation="false" OnClientClick="return confirm('Are you sure you want to delete this listing?');"></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Font-Size="12px" Width="30px" />
                                                <HeaderStyle Font-Size="12px" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <asp:Label ID="lblBUempty" runat="server" Text="There are no pending verifications at this time."
                                                Font-Bold="true" Font-Size="15px" ForeColor="#E8C41D"></asp:Label>
                                        </EmptyDataTemplate>
                                        <HeaderStyle CssClass="title1" />
                                        <EmptyDataRowStyle ForeColor="#C00000" />
                                        <AlternatingRowStyle BackColor="#EEECEC"></AlternatingRowStyle>
                                    </asp:GridView>
                                </td>
                                <asp:HiddenField ID="hdnsortcount" runat="server"></asp:HiddenField>
                            </tr>
                        </table>
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td style="padding-top: 10px; padding-left: 5px; color: #005AA0; font-weight: bold;">
                                    In Progress Verifications
                                </td>
                                <td align="right" style="padding-right: 10px;">
                                    <asp:Panel ID="pnlSerachProgress" runat="server">
                                        Vertical:
                                        <asp:DropDownList runat="server" ID="ddlVerticalProgress">
                                        </asp:DropDownList>
                                        &nbsp;&nbsp;Country:
                                        <asp:DropDownList runat="server" ID="ddlCountryProgress">
                                            <asp:ListItem Text="-- Select --" Value=""></asp:ListItem>
                                            <asp:ListItem Text="United States" Value="United States"></asp:ListItem>
                                            <asp:ListItem Text="India" Value="India"></asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp;&nbsp;<asp:Button ID="btnSearchProgress" runat="server" Text="Submit" OnClick="btnSearchProgress_Click" />
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                        <table border="0" cellpadding="0" cellspacing="0" class="datagrid nomargin-bottom">
                            <tr>
                                <td>
                                    <asp:GridView ID="grdInProgressListings" runat="server" DataKeyNames="Inquiry_ID"
                                        AllowSorting="true" AutoGenerateColumns="False" AllowPaging="true" Width="100%"
                                        OnPageIndexChanging="grdInProgressListings_PageIndexChanging" CssClass="datagrid2"
                                        OnSorting="grdInProgressListings_Sorting">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Subscription Type">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSubscriptionType" runat="server" Font-Bold="true" Text='<%#Eval("SubscriptionType") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="100px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Agency Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAgencyName" runat="server" Text='<%#Eval("Agency_Name") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="100px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Contact Person">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblContactPerson" runat="server" Text='<%#Eval("Contact_Person") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="150px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Phone Number">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPhoneNo" runat="server" Text='<%#Eval("Phone_Number") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="150px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Email Address">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("Email_Address") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="150px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Remarks">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRemarks" runat="server" Text='<%#Eval("Remarks") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="100px" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Created_Date" ItemStyle-Width="250px" HeaderText="Created Date"
                                                DataFormatString="{0:MM/dd/yyyy hh:mm tt PST}" />
                                            <asp:BoundField DataField="NextAction_Date" ItemStyle-Width="250px" HeaderText="Next Action Date &amp; Time"
                                                DataFormatString="{0:MM/dd/yyyy hh:mm tt PST}" SortExpression="CallDate" />
                                            <asp:TemplateField HeaderText="Account Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblstatus" runat="server" Text='<%#Eval("Verified_Status") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Verify">
                                                <ItemTemplate>
                                                    <asp:LinkButton runat="server" ID="btnEdit" Text="<img src='../../Images/Dashboard/icon_modify.gif' title='Verify' border='0'"
                                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Inquiry_ID") %>' OnClick="btnEdit_Click"></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle Width="10px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Delete">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkIPDelete" runat="server" CommandArgument='<%# Eval("Inquiry_ID") %>'
                                                        OnClick="lnkDelete_Click" Text="<img src='../../Images/Dashboard/icon_delete.gif'width='25px' height='25px' title='Delete' border='0'"
                                                        CausesValidation="false" OnClientClick="return confirm('Are you sure you want to delete this listing?');"></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Font-Size="12px" Width="30px" />
                                                <HeaderStyle Font-Size="12px" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <asp:Label ID="lblBUempty" runat="server" Text="There are no in progress verifications at this time."
                                                Font-Bold="true" Font-Size="15px" ForeColor="#E8C41D"></asp:Label>
                                        </EmptyDataTemplate>
                                        <HeaderStyle CssClass="title1" />
                                        <EmptyDataRowStyle ForeColor="#C00000" />
                                        <AlternatingRowStyle BackColor="#EEECEC"></AlternatingRowStyle>
                                    </asp:GridView>
                                </td>
                                <asp:HiddenField ID="hdnipsortcount" runat="server"></asp:HiddenField>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
