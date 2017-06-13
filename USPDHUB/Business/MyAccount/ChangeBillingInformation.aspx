<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="ChangeBillingInformation.aspx.cs"
    Inherits="USPDHUB.Business.MyAccount.ChangeBillingInformation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphUser" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
    <script type="text/javascript" src="../../Scripts/bootstrap.min.js"></script>
    <style type="text/css">
        .list-inline
        {
            margin-top: 0px;
            margin-left: -38px;
            list-style: none;
        }
        .row
        {
            padding-bottom: 9px;
        }
        .popupTool
        {
            background-color: #ffffff;
            position: absolute;
            display: inline-block;
            padding: .2em .5em;
            width: 160px;
            height: 29px;
        }
        .popupTool::after
        {
            border-bottom: 10px solid #ffffff;
            border-left: 10px solid transparent;
            border-right: 10px solid transparent;
            width: 0;
            height: 0;
            content: "";
            display: block;
            position: absolute;
            bottom: 100%;
            left: 1em;
        }
    </style>
    <table width="60%" height="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="valign-top">
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <h3>
                                Billing Information</h3>
                        </td>
                        <td style="padding-right: 70px;">
                            <asp:UpdateProgress ID="UpdateProgress6" runat="server" DisplayAfter="3">
                                <ProgressTemplate>
                                    <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lblBillEditMsg" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table cellpadding="0" cellspacing="0" border="0" id="tabber" width="100%">
                    <tr>
                        <td colspan="2">
                            <div>
                                <asp:ValidationSummary ID="ValidateDetails" runat="server" Style="text-align: left; padding-left: 149px"
                                    ValidationGroup="editbill" />
                            </div>
                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="10">
                                <colgroup>
                                    <col width="50%" />
                                    <col width="*" align="left" />
                                </colgroup>
                                <tr>
                                    <td colspan="2">
                                        <span class="errormsgadm">*</span> <b>Marked fields are mandatory.</b>
                                        <br />
                                    </td>
                                </tr>
                                <tr class="row">
                                    <td>
                                        <span class="errormsgadm">*</span> First Name:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtfirstName"  style=" width: 190px;" runat="server" MaxLength="30" ValidationGroup="editbill"
                                            CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                                            &nbsp;
                                        <asp:RequiredFieldValidator ID="reqfirstname" runat="server" ErrorMessage="First name is mandatory" ControlToValidate="txtfirstName"
                                            ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="X-Large"
                                            ValidationGroup="editbill">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="row">
                                        &nbsp;&nbsp;Last Name:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtlastname" style=" width: 190px;" runat="server" MaxLength="32"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="row">
                                        <span class="errormsgadm">*</span> Billing Email Address:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtEmail" runat="server" style=" width: 190px;" CssClass="tolower" ValidationGroup="editbill"
                                            ClientIDMode="Static"></asp:TextBox>
                                        &nbsp;
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Email Id is mandatory" ControlToValidate="txtEmail"
                                            ForeColor="Red" Display="Dynamic" Font-Size="X-Large" SetFocusOnError="true"
                                            ValidationGroup="editbill">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="regBillingEmail" runat="server" ControlToValidate="txtEmail"
                                            Display="Dynamic" ErrorMessage="Invalid Email format." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                            ValidationGroup="editbill" SetFocusOnError="True" ForeColor="Red">*</asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="row">
                                        <span class="errormsgadm">*</span> Verify Billing Email Address:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtVerBillingEmail" runat="server" style=" width: 190px;" CssClass="tolower" ValidationGroup="editbill"></asp:TextBox>
                                        <asp:CompareValidator ID="compBillingEmail" runat="server" ControlToCompare="txtVerBillingEmail"
                                            ControlToValidate="txtEmail" Operator="Equal" Type="String" ValidationGroup="editbill"
                                            SetFocusOnError="true" Display="Dynamic" ForeColor="Red" ErrorMessage="Billing Email Address should match.">*</asp:CompareValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="row">
                                        <span class="errormsgadm">*</span> Address 1:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtaddress1" runat="server" style=" width: 190px;" MaxLength="100" ValidationGroup="editbill"
                                            ClientIDMode="Static"></asp:TextBox>
                                        &nbsp;
                                        <asp:RequiredFieldValidator ID="reqaddress1" runat="server" ErrorMessage="Address1 is mandatory" ControlToValidate="txtaddress1"
                                            ForeColor="Red" Display="Dynamic" Font-Size="X-Large" SetFocusOnError="true"
                                            ValidationGroup="editbill">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;&nbsp;Address 2:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtaddress2" style=" width: 190px;"  runat="server" MaxLength="100" ClientIDMode="Static"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span class="errormsgadm">*</span> City:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtcity" runat="server" style=" width: 190px;"  MaxLength="40" ClientIDMode="Static"></asp:TextBox>
                                        &nbsp;
                                        <asp:RequiredFieldValidator ID="reqcity" runat="server" ErrorMessage="City is mandatory" ControlToValidate="txtcity"
                                            ForeColor="Red" Display="Dynamic" Font-Size="X-Large" SetFocusOnError="true"
                                            ValidationGroup="editbill">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span class="errormsgadm">*</span> State:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtState" runat="server" style=" width: 190px;" MaxLength="40" ClientIDMode="Static"></asp:TextBox>
                                        &nbsp;
                                        <asp:RequiredFieldValidator ID="reqstate" runat="server" ErrorMessage="State is mandatory" ControlToValidate="txtState"
                                            Display="Dynamic" Font-Size="X-Large" SetFocusOnError="true" ValidationGroup="editbill"
                                            ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span class="errormsgadm">*</span> Zip Code:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtzip" style=" width: 190px;" runat="server" MaxLength="8" ClientIDMode="Static" onkeypress="return isNumber(event)"></asp:TextBox>
                                        &nbsp;
                                        <asp:RequiredFieldValidator ID="reqzipcode" runat="server" ErrorMessage="Zipcode is mandatory" ControlToValidate="txtzip"
                                            ForeColor="Red" Display="Dynamic" Font-Size="X-Large" SetFocusOnError="true"
                                            ValidationGroup="editbill">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegExp1" runat="server" ErrorMessage="Invalid Zipcode."
                                            SetFocusOnError="True" ValidationGroup="editbill" ForeColor="Red" ControlToValidate="txtzip"
                                            ValidationExpression="^[0-9]{5,8}$">*</asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <%--        <tr>
                                    <td>
                                        <span class="errormsgadm">*</span>Country:
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlCountry" runat="server">
                                        </asp:DropDownList>
                                        &nbsp;
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlCountry"
                                            Display="Dynamic" Font-Size="X-Large" InitialValue="0" SetFocusOnError="true"
                                            ValidationGroup="editbill" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:Button ID="btnUpdate" runat="server" Text="Update" Width="100px" ValidationGroup="editbill"
                                            OnClick="btnUpdate_Click" />
                                              <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="100px" 
                                              OnClick="btnCancel_Click"/>
                                    </td>
                                </tr>
                            </table>
                            </div>
                            <%-- <a href="#" class="pull-right invoiceolder">Older</a>--%>
                            <asp:HiddenField ID="hdnAddress" runat="server" Value="" />
                            <div class="a-row">
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
