<%@ Page Title="" Language="C#" MasterPageFile="~/AdminHome.master" AutoEventWireup="true"
    CodeBehind="ModifyUserDetails.aspx.cs" Inherits="USPDHUB.Admin.ModifyUserDetails" %>

<%@ Register Src="~/Controls/Login.ascx" TagName="Login" TagPrefix="uc1" %>
<%--<%@ Register Src="~/Controls/WowAds.ascx" TagName="wowads" TagPrefix="uc2" %>--%>
<%@ Register Src="~/Controls/Sitemaplinks.ascx" TagName="wowmap" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <table width="100%" height="100%" class="page-top" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="page-top">
                <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" class="page-padding">
                    <tr>
                        <td class="valign-top">
                            <uc3:wowmap ID="sitemaplinks" runat="server" />
                            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="page-title">
                                <tr>
                                    <td>
                                        My Account
                                    </td>
                                </tr>
                            </table>
                            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="inputtable">
                                <tr>
                                    <td>
                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="inputgrid nomargin-bottom">
                                            <colgroup>
                                                <col width="200">
                                                <col width="230">
                                                <col width="180">
                                                <col width="*">
                                            </colgroup>
                                            <tr class="title">
                                                <td colspan="3">
                                                    Update Registration Details
                                                </td>
                                                <td colspan="5">
                                                    <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr class="row1">
                                                <td class="lable" style="vertical-align: top; padding-top: 8px;">
                                                    Username
                                                </td>
                                                <td colspan="5" class="valign">
                                                    <asp:TextBox ID="txtEmail" ReadOnly="true" runat="server" CssClass="textfield" Width="450px"
                                                        TabIndex="1"></asp:TextBox>&nbsp;<br />
                                                </td>
                                            </tr>
                                            <tr class="row2">
                                                <td class="lable" style="vertical-align: top; padding-top: 8px;">
                                                    Email ID
                                                </td>
                                                <td colspan="5" class="valign">
                                                    <asp:TextBox ID="txtemail2" runat="server" CssClass="textfield" Width="450px" TabIndex="1"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtemail2"
                                                        ErrorMessage="Email is mandatory.">*</asp:RequiredFieldValidator><br />
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server"
                                                        ControlToValidate="txtEmail" ErrorMessage="Invalid Email." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                        Font-Size="Smaller" Width="114px" />
                                                </td>
                                            </tr>
                                            <tr class="row1">
                                                <td class="lable" style="vertical-align: top; padding-top: 10px;">
                                                    Choose a password
                                                </td>
                                                <td style="vertical-align: top;">
                                                    <asp:TextBox ID="txtPassword" runat="server" CssClass="medium textfield" TabIndex="2"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword"
                                                        ErrorMessage="Password is mandatory.">*</asp:RequiredFieldValidator>
                                                </td>
                                                <td class="lable" style="vertical-align: top; padding-top: 10px;">
                                                    Re-enter password
                                                </td>
                                                <td style="vertical-align: top;">
                                                    <asp:TextBox ID="txtRePassword" runat="server" CssClass="medium textfield" TabIndex="3"></asp:TextBox>
                                                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="txtPassword"
                                                        ControlToValidate="txtRePassword" ErrorMessage="Re-confirm password is not matched."
                                                        Font-Size="Smaller" Width="210px" />
                                                </td>
                                            </tr>
                                            <tr class="row2">
                                                <td class="lable">
                                                    Forgot Password Question1
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtQuestion1" runat="server" CssClass="medium textfield" TabIndex="4"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtQuestion1"
                                                        ErrorMessage="Forgot password Question1 is mandatory">*</asp:RequiredFieldValidator>
                                                </td>
                                                <td class="lable">
                                                    Forgot Password Answer1
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtAnswer1" runat="server" CssClass="medium textfield" TabIndex="5"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAnswer1"
                                                        ErrorMessage="Forgot password Answer1 is mandatory">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr class="row1">
                                                <td class="lable">
                                                    Forgot Password Question2
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtQuestion2" runat="server" CssClass="medium textfield" TabIndex="6"></asp:TextBox>
                                                </td>
                                                <td class="lable">
                                                    Forgot Password Answer2
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtAnswer2" runat="server" CssClass="medium textfield" TabIndex="7"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr class="row2">
                                                <td class="lable" style="vertical-align: top; padding-top: 10px;">
                                                    First Name
                                                </td>
                                                <td style="vertical-align: top;">
                                                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="medium textfield" TabIndex="8"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtFirstName"
                                                        ErrorMessage="Firstname is mandatory.">*</asp:RequiredFieldValidator>
                                                </td>
                                                <td class="lable" style="vertical-align: top; padding-top: 10px;">
                                                    Last Name
                                                </td>
                                                <td style="vertical-align: top;">
                                                    <asp:TextBox ID="txtLastName" runat="server" CssClass="medium textfield" TabIndex="9"></asp:TextBox>
                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtLastName"
                                                        ErrorMessage="Lastname is mandatory.">*</asp:RequiredFieldValidator>--%>
                                                </td>
                                            </tr>
                                            <tr class="row1">
                                                <td class="lable" style="vertical-align: top; padding-top: 10px;">
                                                    Street Address
                                                </td>
                                                <td style="vertical-align: top;">
                                                    <asp:TextBox ID="txtAddress1" runat="server" CssClass="medium textfield" TabIndex="11"></asp:TextBox>
                                                </td>
                                                <td class="lable" style="vertical-align: top; padding-top: 10px;">
                                                    Address2
                                                </td>
                                                <td style="vertical-align: top;">
                                                    <asp:TextBox ID="txtAddress2" runat="server" CssClass="medium textfield" TabIndex="12"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr class="row2">
                                                <td class="lable" style="vertical-align: top; padding-top: 10px;">
                                                    City
                                                </td>
                                                <td style="vertical-align: top;">
                                                    <asp:TextBox ID="txtCity" runat="server" CssClass="medium textfield" TabIndex="13"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtCity"
                                                        ErrorMessage="City is mandatory.">*</asp:RequiredFieldValidator>
                                                </td>
                                                <td class="lable" style="vertical-align: top; padding-top: 10px;">
                                                    State/province
                                                </td>
                                                <td style="vertical-align: top;">
                                                    <asp:TextBox ID="txtState" runat="server" CssClass="medium textfield" TabIndex="14"
                                                        ValidationGroup="userValidation"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtState"
                                                        ErrorMessage="State is mandatory.">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr class="row1">
                                                <td class="lable" style="vertical-align: top; padding-top: 10px;">
                                                    Zip/Postal Code
                                                </td>
                                                <td style="vertical-align: top;">
                                                    <asp:TextBox ID="txtZipCode" Width="100px" runat="server" CssClass="medium textfield"
                                                        TabIndex="15" ValidationGroup="userValidation"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtZipCode"
                                                        ErrorMessage="Zipcode is mandatory.">*</asp:RequiredFieldValidator>
                                                </td>
                                                <td class="lable" style="vertical-align: top; padding-top: 10px;">
                                                    Phone Number
                                                </td>
                                                <td style="vertical-align: top;">
                                                    <asp:TextBox ID="txtPhone" runat="server" Width="100px" CssClass="medium textfield"
                                                        TabIndex="16" ValidationGroup="userValidation"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr class="row2">
                                                <td class="lable">
                                                    Country
                                                </td>
                                                <td colspan="3">
                                                    <asp:DropDownList ID="ddlCountry" runat="server" TabIndex="17">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td colspan="3" class="align-right">
                                        <asp:Button ID="btnUpdate" runat="server" Text="Update" TabIndex="19" OnClick="UserUpdate_Click" />
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" TabIndex="20" CausesValidation="false"
                                            OnClick="UserCancel_Click" />
                                            <asp:HiddenField ID="hdnOld" runat="server" />
                                            <asp:HiddenField ID="hdnIsFree" runat="server" Value="false" />
                                    </td>
                                </tr>
                            </table>
                            <table cellpadding="0" cellspacing="0" width="100%" class="inputgrid">
                                <tr>
                                    <td>
                                        <asp:ValidationSummary ID="ValidationSummary1" HeaderText="Registration validation Errors are as below. please correct and re-try:"
                                            runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="page-bottom">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
