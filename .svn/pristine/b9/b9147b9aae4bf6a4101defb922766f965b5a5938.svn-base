<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QRConnectCredits.ascx.cs"
    Inherits="USPDHUB.Controls.QRConnectCredits" %>
<style>
    /* Style the tab */
    div.tab
    {
        overflow: hidden;
        border: 1px solid #ccc;
        border-bottom: none;
        width: 180px;
        border-radius: 10px 10px 0px 0px;
        font-weight: bold;
        font-size: 16px;
        padding: 10px;
        margin-left: 10px;
        text-align:center;
    }
    
    /* Style the buttons inside the tab */
    div.tab button
    {
        background-color: inherit;
        float: left;
        border: none;
        outline: none;
        cursor: pointer;
        padding: 14px 16px;
        transition: 0.3s;
        font-size: 17px;
    }
    
    /* Change background color of buttons on hover */
    div.tab button:hover
    {
        background-color: #ddd;
    }
    
    /* Create an active/current tablink class */
    div.tab button.active
    {
        background-color: #ccc;
    }
    
    /* Style the tab content */
    .tabcontent
    {
        padding: 6px 12px;
        border: 1px solid #ccc;
        width: 400px;
        margin-left: 10px;
    }
    .tablinks
    {
        font-size:14px;
    }
    .buttonClass
    {
        ebkit-border-radius: 2;
        -moz-border-radius: 2;
        border-radius: 2px;
        font-family: Arial;
        border: solid #008000 2px;
        color: #ffffff;
        font-size: 14px;
        background: #008000;
        padding: 4px 8px 4px 8px;
        text-decoration: none;
        cursor: pointer;
        margin-bottom: 5px;
    }
</style>
<div class="tab">
    <h3 class="tablinks">
        Message Storage Units</h3>
</div>
<div id="London" class="tabcontent active">
    <table cellpadding="0" cellspacing="0" style="font-weight: bold; font-size:16px; width:100%;">
        <colgroup>
            <col width="*" />
            <col width="*" />
            <col width="*" />
            <col width="100px" />
        </colgroup>
        <tr>
            <td align="center">
                <font color="green">Total</font>
            </td>
            <td align="center" style="color:#EC2027;">
                <font>Used</font>
            </td>
            <td align="center">
                <font color="green">Available</font>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label runat="server" Text="0" ID="lblTotal"></asp:Label>
            </td>
            <td align="center">
                <asp:Label runat="server" Text="0" ID="lblSent"></asp:Label>
            </td>
            <td align="center">
                <asp:Label runat="server" Text="0" ID="lblRemaining"></asp:Label>
            </td>
            <td align="center">
                <asp:LinkButton ID="lnkBuyMoreSMS1" runat="server" Text="Buy More" CausesValidation="false" OnClick="lnkBuyMoreSMS1_OnClick"
                    Style="float: right; margin-right: 10px;" CssClass="buttonClass"></asp:LinkButton>
            </td>
        </tr>
    </table>
</div>
