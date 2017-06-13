<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true"
    Inherits="Business_MyAccount_NewsiteIntiation" Codebehind="NewsiteIntiation.aspx.cs" %>

<%@ Register Src="~/Controls/Login.ascx" TagName="Login" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/WowAds.ascx" TagName="wowads" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/Sitemaplinks.ascx" TagName="wowmap" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="Server">
    <div id="TipLayer" style="visibility: hidden; position: absolute; z-index: 1000;
        top: -100">
    </div>
    <table width="100%" class="page-top" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="page-padding">
                    <tr>
                        <td class="valign-top">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="page-title">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblfirstname" runat="server"></asp:Label>
                                    </td>
                                    <td class="right">
                                    </td>
                                </tr>
                            </table>
                            <table border="0" width="100%" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td align="center">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="left">
                                                    <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="g" HeaderText="Please correct the following:"
                                                        runat="server" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <table class="margin-top" cellspacing="0" cellpadding="0" width="100%" border="0">
                                            <tr>
                                                <td>
                                                    <img height="28" src='<%=Page.ResolveClientUrl("~/Images/Dashboard/head-left.gif")%>'
                                                        width="9" />
                                                </td>
                                                <td class="new-header">
                                                    Initiation
                                                </td>
                                                <td>
                                                    <img height="28" src='<%=Page.ResolveClientUrl("~/Images/Dashboard/head-right.gif")%>'
                                                        width="9" />
                                                </td>
                                            </tr>
                                        </table>
                                        <table id="table1" class="profile-input" cellspacing="0" cellpadding="0" width="100%"
                                            border="0">
                                            <colgroup>
                                                <col width="170" />
                                                <col width="*" />
                                            </colgroup>
                                            <tr>
                                                <td class="lable" colspan="2">
                                                    <br />
                                                    We appreciate your membership.
                                                </td>
                                            </tr>
                                            <tr class="lable">
                                                <td class="lable" colspan="2">
                                                    Please fill-in the following form to activate your site:
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lable">
                                                    *Street Address:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtStreetAdress" runat="server" Width="475px" TabIndex="1"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtStreetAdress"
                                                        ErrorMessage="Street Address is mandatory." ValidationGroup="g">*</asp:RequiredFieldValidator>
                                                    <br />
                                                    (Note: Street address may be kept private by choosing private in settings.)
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lable">
                                                    <br />
                                                    <font size="2">*</font>City:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtcity" runat="server" TabIndex="2"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtcity"
                                                        ErrorMessage="City is mandatory." Display="Dynamic" ValidationGroup="g">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lable">
                                                    <br />
                                                    Select State:
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlstate" runat="server" TabIndex="3">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlstate"
                                                        ErrorMessage="State is mandatory." Display="Dynamic" ValidationGroup="g" InitialValue="0">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lable">
                                                    <br />
                                                    <font size="2">*</font>Zip Code:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtzipcode" runat="server" TabIndex="4"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtzipcode"
                                                        ErrorMessage="Zip code is mandatory." Display="Dynamic" ValidationGroup="g">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td valign="bottom">
                                                    Please enter a brief description about your organization.<br />
                                                    <br />
                                                    <span style="color: #969797;">Note: Description appears on your site below the Name
                                                        Header and above the Primary Picture on the Media page (if pictures are present).
                                                        This should be the primary description of your organization.</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lable">
                                                    <font size="2">*</font>Description:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="Txtbusinessdesc" TextMode="MultiLine" MaxLength="7500" runat="server"
                                                        Width="475px" Height="100px" TabIndex="5"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="Txtbusinessdesc"
                                                        runat="server" ErrorMessage="Description is mandatory." Display="Dynamic" SetFocusOnError="True"
                                                        ValidationGroup="g">*</asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="txtConclusionValidator1" ControlToValidate="Txtbusinessdesc"
                                                        Text="Exceeding 7500 characters" ErrorMessage="Exceeding 7500 characters for Description."
                                                        ValidationExpression="^[\s\S]{0,7500}$" runat="server" ValidationGroup="g" />
                                                </td>
                                            </tr>                                            
                                            <tr>
                                                <td class="lable">
                                                    <font size="2">*</font>Type of Site:
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlbusinesstype" runat="server" TabIndex="7">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlbusinesstype"
                                                        ErrorMessage="Type of site is mandatory." InitialValue="0" ValidationGroup="g">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td nowrap>
                                                    * <font color="red">Marked fields are mandatory.</font>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table class="profile-btntbl" cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td>
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="button" TabIndex="8"
                                ValidationGroup="g" OnClick="btnSubmit_Click" />
                            &nbsp;<!--<asp:Button ID="btnreset" runat="server" Text="Reset" TabIndex="8" CssClass="button"
                                OnClick="btnreset_Click" />-->
                            <input type="reset" value="Reset" cssclass="button" />
                        </td>
                    </tr>
                </table>
                <div id="divError">
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
