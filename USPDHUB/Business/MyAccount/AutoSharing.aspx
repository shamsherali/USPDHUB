<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true"
    CodeBehind="AutoSharing.aspx.cs" Inherits="USPDHUB.Business.MyAccount.AutoSharing" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <style type="text/css">
        .MainDiv
        {
            /*background-color:#FD7512;*/
            width: 100%;
            height: 200px;
            padding-top: 60px;
            padding-bottom: 100px;
        }
        .couponcode
        {
            /*width: 50px;*/
        }
        .couponcode:hover .coupontooltip
        {
            display: block;
        }
        .coupontooltip
        {
            font-weight: normal;
            font-size: 14px;
            display: none;
            background: #D9E8FF;
            border: 1px dashed #297CCF;
            position: absolute;
            padding: 6px;
            z-index: 1000;
            width: 300px;
            height: auto;
            color: Black;
        }
    </style>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table>
                <tr>
                    <td>
                        <h3>
                            Auto Share</h3>
                    </td>
                    <td align="left">
                        <span class="couponcode">
                            <img border="0" src="../../images/Dashboard/new.png" />
                            <span class="coupontooltip" style="margin: 0px 0px 0px 12px;">Auto Share allows you
                                to automatically share your content and events to your Facebook and Twitter accounts.
                                You will always have the option to choose not to share a particular item when you
                                go to publish it.</span> </span>
                    </td>
                </tr>
            </table>
            <br />
            <span style="color: blue;">Please note there may be a delay before content is visible
                on your social media accounts.</span>
            <%-- <br />
            <br />
             <span><asp:HyperLink ID="hLink" runat="server" NavigateUrl="~/Business/MyAccount/SharedMediaHistory.aspx">
                 Display Shared Social Media History</asp:HyperLink> </span>--%>
            <div class="MainDiv">
                <table cellspacing="8px" cellpadding="8px" width="100%" border="0">
                    <colgroup>
                        <col width="62%" />
                        <col width="*" />
                    </colgroup>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Label ID="lblMsg" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="middle">
                            <asp:LinkButton ID="lnkFacebook" runat="server" OnClick="lnkFacebook_Click"><img id="imgFacebook" src="../../Images/Dashboard/FacebookAutoShare.png"/></asp:LinkButton>
                        </td>
                        <td valign="middle" align="left">
                            <asp:Literal ID="ltrlFacebook" runat="server"></asp:Literal>
                        </td>
                        <td>
                            <asp:LinkButton ID="lnkFacebookStatus" runat="server" Text="Activity Log" Visible="false"
                                OnClick="lnkFacebookStatus_Click" Style="font-size: larger; padding: 10px 28px;
                                    background: #4479BA; color: #FFF; text-decoration: none;border-radius:7px;"></asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="middle" style="vertical-align: bottom;">
                            <asp:LinkButton ID="lnkTwitter" runat="server" OnClick="lnkTwitter_Click"><img id="imgTwitter" src="../../Images/Dashboard/TwitterAutoShare.png" /></asp:LinkButton>
                        </td>
                        <td valign="middle" align="left">
                            <asp:Literal ID="ltrlTwitter" runat="server"></asp:Literal>
                        </td>
                        <td>
                            <div>
                                <asp:LinkButton ID="lnkTwitterStatus" runat="server" Text="Activity Log" Visible="false"
                                    OnClick="lnkTwitterStatus_Click" Style="font-size: larger; padding: 10px 28px;
                                    background: #4479BA; color: #FFF; text-decoration: none;border-radius:7px;"></asp:LinkButton>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
            <div style="display: none;">
                <asp:HiddenField ID="hdnIsAuth" Value="" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
