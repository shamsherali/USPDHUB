<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditBillingInfo.ascx.cs"
    Inherits="USPDHUB.Controls.EditBillingInfo" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<style type="text/css">
    .errormsgadm
    {
        color: red;
    }
</style>
<asp:Panel ID="pnleditbillinginfo" runat="server" Width="400px">
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="10">
        <colgroup>
            <col width="40%" />
            <col width="*" align="left" />
        </colgroup>
        <tr>
            <td colspan="2">
                <span class="errormsgadm">*</span> <b>Marked feilds are mandatory.</b>
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <span class="errormsgadm">*</span>First Name:
            </td>
            <td>
                <asp:TextBox ID="txtfirstName" runat="server" MaxLength="30" ValidationGroup="g" ClientIDMode="Static"></asp:TextBox>&nbsp;
                <asp:RequiredFieldValidator ID="reqfirstname" runat="server" ControlToValidate="txtfirstName"
                    Display="Dynamic" SetFocusOnError="true" Font-Size="X-Large" ValidationGroup="g">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;&nbsp;Last Name:
            </td>
            <td>
                <asp:TextBox ID="txtlastname" runat="server" MaxLength="32" ValidationGroup="g" ClientIDMode="Static"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <span class="errormsgadm">*</span>Address 1:
            </td>
            <td>
                <asp:TextBox ID="txtaddress1" runat="server" MaxLength="100" ValidationGroup="g" ClientIDMode="Static"></asp:TextBox>
                &nbsp;
                <asp:RequiredFieldValidator ID="reqaddress1" runat="server" ControlToValidate="txtaddress1"
                    Display="Dynamic" Font-Size="X-Large" SetFocusOnError="true" ValidationGroup="g">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;&nbsp;Address 2:
            </td>
            <td>
                <asp:TextBox ID="txtaddress2" runat="server" MaxLength="100" ClientIDMode="Static"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <span class="errormsgadm">*</span>City:
            </td>
            <td>
                <asp:TextBox ID="txtcity" runat="server" MaxLength="40" ValidationGroup="g" ClientIDMode="Static"></asp:TextBox>
                &nbsp;
                <asp:RequiredFieldValidator ID="reqcity" runat="server" ControlToValidate="txtcity"
                    Display="Dynamic" Font-Size="X-Large" SetFocusOnError="true" ValidationGroup="g">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <span class="errormsgadm">*</span>State:
            </td>
            <td>
                <asp:DropDownList ID="ddlState" runat="server" ValidationGroup="g" Width="150" style="padding:2px;" ClientIDMode="Static" >
                    <asp:ListItem Text="Select State" Value="0"></asp:ListItem>
                    <asp:ListItem Text="AK" Value="AK"></asp:ListItem>
                    <asp:ListItem Text="AL" Value="AL"></asp:ListItem>
                    <asp:ListItem Text="AR" Value="AR"></asp:ListItem>
                    <asp:ListItem Text="AZ" Value="AZ"></asp:ListItem>
                    <asp:ListItem Text="CA" Value="CA"></asp:ListItem>
                    <asp:ListItem Text="CO" Value="CO"></asp:ListItem>
                    <asp:ListItem Text="CT" Value="CT"></asp:ListItem>
                    <asp:ListItem Text="DC" Value="DC"></asp:ListItem>
                    <asp:ListItem Text="DE" Value="DE"></asp:ListItem>
                    <asp:ListItem Text="FL" Value="FL"></asp:ListItem>
                    <asp:ListItem Text="GA" Value="GA"></asp:ListItem>
                    <asp:ListItem Text="HI" Value="HI"></asp:ListItem>
                    <asp:ListItem Text="IA" Value="IA"></asp:ListItem>
                    <asp:ListItem Text="ID" Value="ID"></asp:ListItem>
                    <asp:ListItem Text="IL" Value="IL"></asp:ListItem>
                    <asp:ListItem Text="IN" Value="IN"></asp:ListItem>
                    <asp:ListItem Text="KS" Value="KS"></asp:ListItem>
                    <asp:ListItem Text="KY" Value="KY"></asp:ListItem>
                    <asp:ListItem Text="LA" Value="LA"></asp:ListItem>
                    <asp:ListItem Text="MA" Value="MA"></asp:ListItem>
                    <asp:ListItem Text="MD" Value="MD"></asp:ListItem>
                    <asp:ListItem Text="ME" Value="ME"></asp:ListItem>
                    <asp:ListItem Text="MI" Value="MI"></asp:ListItem>
                    <asp:ListItem Text="MN" Value="MN"></asp:ListItem>
                    <asp:ListItem Text="MO" Value="MO"></asp:ListItem>
                    <asp:ListItem Text="MS" Value="MS"></asp:ListItem>
                    <asp:ListItem Text="MT" Value="MT"></asp:ListItem>
                    <asp:ListItem Text="NC" Value="NC"></asp:ListItem>
                    <asp:ListItem Text="ND" Value="ND"></asp:ListItem>
                    <asp:ListItem Text="NE" Value="NE"></asp:ListItem>
                    <asp:ListItem Text="NH" Value="NH"></asp:ListItem>
                    <asp:ListItem Text="NJ" Value="NJ"></asp:ListItem>
                    <asp:ListItem Text="NM" Value="NM"></asp:ListItem>
                    <asp:ListItem Text="NV" Value="NV"></asp:ListItem>
                    <asp:ListItem Text="NY" Value="NY"></asp:ListItem>
                    <asp:ListItem Text="OH" Value="OH"></asp:ListItem>
                    <asp:ListItem Text="OK" Value="OK"></asp:ListItem>
                    <asp:ListItem Text="OR" Value="OR"></asp:ListItem>
                    <asp:ListItem Text="PA" Value="PA"></asp:ListItem>
                    <asp:ListItem Text="RI" Value="RI"></asp:ListItem>
                    <asp:ListItem Text="SC" Value="SC"></asp:ListItem>
                    <asp:ListItem Text="SD" Value="SD"></asp:ListItem>
                    <asp:ListItem Text="TN" Value="TN"></asp:ListItem>
                    <asp:ListItem Text="TX" Value="TX"></asp:ListItem>
                    <asp:ListItem Text="UT" Value="UT"></asp:ListItem>
                    <asp:ListItem Text="VA" Value="VA"></asp:ListItem>
                    <asp:ListItem Text="VT" Value="VT"></asp:ListItem>
                    <asp:ListItem Text="WA" Value="WA"></asp:ListItem>
                    <asp:ListItem Text="WI" Value="WI"></asp:ListItem>
                    <asp:ListItem Text="WV" Value="WV"></asp:ListItem>
                    <asp:ListItem Text="WY" Value="WY"></asp:ListItem>
                    <asp:ListItem Text="AA" Value="AA"></asp:ListItem>
                    <asp:ListItem Text="AE" Value="AE"></asp:ListItem>
                    <asp:ListItem Text="AP" Value="AP"></asp:ListItem>
                    <asp:ListItem Text="AS" Value="AS"></asp:ListItem>
                    <asp:ListItem Text="FM" Value="FM"></asp:ListItem>
                    <asp:ListItem Text="GU" Value="GU"></asp:ListItem>
                    <asp:ListItem Text="MH" Value="MH"></asp:ListItem>
                    <asp:ListItem Text="MP" Value="MP"></asp:ListItem>
                    <asp:ListItem Text="PR" Value="PR"></asp:ListItem>
                    <asp:ListItem Text="PW" Value="PW"></asp:ListItem>
                    <asp:ListItem Text="VI" Value="VI"></asp:ListItem>
                </asp:DropDownList>
                &nbsp;&nbsp;
                <asp:RequiredFieldValidator ID="reqstate" runat="server" ControlToValidate="ddlState"
                    Display="Dynamic" Font-Size="X-Large" InitialValue="0" SetFocusOnError="true"
                    ValidationGroup="g">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <span class="errormsgadm">*</span>Zip Code:
            </td>
            <td>
                <asp:TextBox ID="txtzip" runat="server" MaxLength="10" ValidationGroup="g" ClientIDMode="Static"></asp:TextBox>
                &nbsp;
                <asp:RequiredFieldValidator ID="reqzipcode" runat="server" ControlToValidate="txtzip"
                    Display="Dynamic" Font-Size="X-Large" SetFocusOnError="true" ValidationGroup="g">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <span class="errormsgadm">*</span>Country:
            </td>
            <td>
                <asp:Label ID="lblCountry" runat="server" Text="United States"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="padding-left: 150px;">
                <asp:Button ID="btnUpdate" runat="server" Text="Update" ValidationGroup="g" />
            </td>
        </tr>
    </table>
</asp:Panel>
