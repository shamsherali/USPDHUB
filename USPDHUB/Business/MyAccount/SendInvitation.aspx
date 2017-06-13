<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.master" AutoEventWireup="true"
    CodeBehind="SendInvitation.aspx.cs" Inherits="USPDHUB.Business.MyAccount.SendInvitation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="webmangement_wrapper">
                <div id="webmangement_rightcol">
                    <div id="divManageWebLinksPage">
                        <div class="webmangement_rightcol_heading">
                            Affiliate Apps</div>
                        <div class="clear5">
                        </div>
                        <div style="min-height: 374px;">
                            <div style="text-align: center; color: Green;">
                                <asp:Label ID="lblsuccess" runat="server"></asp:Label>
                            </div>
                            <div align="center">
                                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="3">
                                    <ProgressTemplate>
                                        <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b></ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>
                            <div id="webmangement_body">
                                <div class="socialmedia_wrapper">
                                    <div style="display:none;">
                                        <asp:Button ID="btnRequestCodes" runat="server" Text="Request Activation Codes" OnClick="btnRequestCodes_Click" />
                                        <a id="A1" href="javascript:ModalHelpPopup('Create Affiliate Sub-App',195,'');">
                                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" /></a>
                                        <%--<div style="float: right; padding-right: 55px; font-size: 15px; font-weight: bold;">
                                            <a href="javascript:Display_HowIt_Popup();">How it works?</a>
                                        </div>--%>
                                    </div>
                                    <div class="clear10">
                                    </div>
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="padding-right: 50px;">
                                        <tr>
                                            <td class="content">
                                                <asp:HiddenField ID="hdnCommandArg" runat="server" />
                                                <asp:HiddenField ID="hdnResend" runat="server" />
                                                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="valign-top">
                                                    <tr>
                                                        <td valign="top" align="center">
                                                            <asp:GridView ID="InvitationGrid" runat="server" AutoGenerateColumns="False" DataKeyNames="Affiliate_ID"
                                                                CssClass="datagrid2" AllowPaging="True" OnPageIndexChanging="InvitationGrid_PageIndexChanging"
                                                                OnRowDataBound="InvitationGrid_RowDataBound" PageSize="10" Width="100%" ForeColor="Black">
                                                                <Columns>
                                                                    <asp:BoundField DataField="Code" HeaderText="Activation Code">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Email_Address" HeaderText="Email Address">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Paid" HeaderText="Type" Visible="false">
                                                                        <HeaderStyle Width="60px"></HeaderStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Modified_Date" HeaderText="Date" DataFormatString="{0:MM/dd/yyyy}">
                                                                        <HeaderStyle Width="50px"></HeaderStyle>
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="Status">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status") %>' Style="font-weight: bold;"></asp:Label>
                                                                            <asp:LinkButton runat="server" ID="lnkStatus" Text='<%# Bind("Status") %>' CausesValidation="false"
                                                                                CommandArgument='<%# Bind("Invitation_CodeID") %>' OnClick="lnkStatus_Click"
                                                                                Style="cursor: pointer; font-weight: bold;">                                                                            
                                                                            </asp:LinkButton>
                                                                            <asp:LinkButton runat="server" ID="lnkResend" Text=" (Resend)" CausesValidation="false"
                                                                                CommandArgument='<%# Bind("Affiliate_ID") %>' OnClick="lnkResend_Click" Style="cursor: pointer;
                                                                                font-weight: bold;">                                                                            
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="100px" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Cancel">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton runat="server" ID="lnkCancel" ToolTip="Cancel" CausesValidation="false"
                                                                                CommandArgument='<%# Bind("Affiliate_ID") %>' OnClick="lnkCancel_Click" OnClientClick="return confirm('Are you sure you want to cancel this invitation?');"
                                                                                Style="cursor: pointer;">
                                                                            <img src="../../Images/Dashboard/icon_delete.gif" alt="Cancel" />    
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="50px" />
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <HeaderStyle CssClass="title3" />
                                                                <AlternatingRowStyle BackColor="#EEECEC"></AlternatingRowStyle>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top" align="center">
                                                            <asp:Button runat="server" ID="btnViewApps" Text="View Affiliate Apps" Visible="false" OnClick="btnViewApps_OnClick" />
                                                            <br />
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblSend" runat="server"></asp:Label>
                                                                <asp:ModalPopupExtender ID="modalSend" runat="server" BackgroundCssClass="modal"
                                                                    PopupControlID="pnlSend" TargetControlID="lblSend" CancelControlID="imgClose">
                                                                </asp:ModalPopupExtender>
                                                                <asp:Panel Style="display: none" ID="pnlSend" runat="server" Width="100%">
                                                                    <table class="modalpopup" cellspacing="0" cellpadding="0" width="750px" align="center"
                                                                        border="0">
                                                                        <tr>
                                                                            <td align="left" class="header">
                                                                                Send Invitation
                                                                            </td>
                                                                            <td align="right">
                                                                                <asp:ImageButton ID="imgClose" runat="server" ImageUrl="~/images/popup_close.gif"
                                                                                    CausesValidation="false"></asp:ImageButton>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="center" colspan="2" style="padding-bottom: 20px;">
                                                                                <asp:UpdateProgress ID="UpdateProgress10" runat="server" DisplayAfter="3">
                                                                                    <ProgressTemplate>
                                                                                        <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                                                                    </ProgressTemplate>
                                                                                </asp:UpdateProgress>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" align="center">
                                                                                <asp:Label ID="lblerror" runat="server" Style="color: red; font-size: 12px;"></asp:Label>
                                                                                <table border="0" cellpadding="0" cellspacing="0">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:ValidationSummary ID="Valsummery" runat="server" ValidationGroup="g" Style="text-align: left;"
                                                                                                HeaderText="The following error(s) occurred:" Font-Size="Small" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" align="center">
                                                                                <table border="0" cellpadding="0" cellspacing="0" width="76%" class="innermodal">
                                                                                    <colgroup>
                                                                                        <col width="120px;" />
                                                                                        <col width="*" />
                                                                                    </colgroup>
                                                                                    <tr>
                                                                                        <td>
                                                                                            First Name:
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtFirtsName" runat="server" Width="200px"></asp:TextBox>
                                                                                            <asp:RequiredFieldValidator ID="REVFirstName" runat="server" ControlToValidate="txtFirtsName"
                                                                                                Display="Dynamic" ErrorMessage="First Name is mandatory." ValidationGroup="g">*</asp:RequiredFieldValidator>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            Last Name:
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtLastName" runat="server" Width="200px"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            Email Address:
                                                                                        </td>
                                                                                        <td style="vertical-align: top;">
                                                                                            <asp:TextBox ID="txtEmail" runat="server" Width="200px"></asp:TextBox>
                                                                                            <asp:RequiredFieldValidator ID="RFVEmail" runat="server" ControlToValidate="txtEmail"
                                                                                                Display="Dynamic" ErrorMessage="Email Address is mandatory." ValidationGroup="g">*</asp:RequiredFieldValidator>
                                                                                            <asp:RegularExpressionValidator ID="REGVEmail" runat="server" ControlToValidate="txtEmail"
                                                                                                Display="Dynamic" ErrorMessage="Invalid Email Format." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                                                ValidationGroup="g">*</asp:RegularExpressionValidator>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2">
                                                                                            <b>Note for the Message:</b> Please make any needed edits to the following email
                                                                                            content.
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td valign="top">
                                                                                            Message:
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtMessage" runat="server" Width="400px" TextMode="MultiLine" Height="100px"></asp:TextBox>
                                                                                            <asp:RequiredFieldValidator ID="rfvMessage" runat="server" ControlToValidate="txtMessage"
                                                                                                Display="Dynamic" ErrorMessage="Message is mandatory." ValidationGroup="g">*</asp:RequiredFieldValidator>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2">
                                                                                            <b>Note:</b> The following text will be appended to the email content.<br />
                                                                                            <br />
                                                                                            To register click the link below or copy and paste in your browser window.
                                                                                            <asp:Label ID="lblLink" runat="server"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            &nbsp;
                                                                                        </td>
                                                                                        <td style="text-align: right; padding-right: 25px;">
                                                                                            <asp:LinkButton ID="lnkSend" runat="server" ValidationGroup="g" OnClick="lnkSend_Click"><img src="../../images/Dashboard/sendnotify.png" /></asp:LinkButton>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </asp:Panel>
                                                                <asp:Label ID="lblHowIt" runat="server"></asp:Label>
                                                                <asp:ModalPopupExtender ID="modalHowIt" runat="server" BackgroundCssClass="modal"
                                                                    PopupControlID="pnlHowIt" TargetControlID="lblHowIt" CancelControlID="imgClosePopup">
                                                                </asp:ModalPopupExtender>
                                                                <asp:Panel Style="display: none; line-height: 22px;" ID="pnlHowIt" runat="server"
                                                                    Width="100%">
                                                                    <table class="modalpopup" cellspacing="0" cellpadding="0" width="615px" align="center"
                                                                        border="0">
                                                                        <tr>
                                                                            <td colspan="2" align="right">
                                                                                <asp:ImageButton ID="imgClosePopup" runat="server" ImageUrl="~/images/popup_close.gif"
                                                                                    CausesValidation="false"></asp:ImageButton>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2">
                                                                                <h2 style="color: Green;">
                                                                                    Affiliate Apps Setup
                                                                                </h2>
                                                                                <br />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2">
                                                                                <h3>
                                                                                    How it works:</h3>
                                                                                <br />
                                                                                <p>
                                                                                    A Affiliate App is a mobile application that is available for entities associated
                                                                                    with your organization. The Affiliate App carries your logo, but the name on the
                                                                                    App can be changed to fit the identity of the associated entity. Affiliate Apps
                                                                                    are listed in Favorites on your App.</p>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2">
                                                                                <h3>
                                                                                    How to register Sub Apps:</h3>
                                                                                <br />
                                                                                <p>
                                                                                    There are 2 types of Affiliate Apps, ‘prepaid’ paid by you and ‘non-paid’ that are
                                                                                    paid by the associated entity.</p>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2">
                                                                                <h3>
                                                                                    Prepaid:</h3>
                                                                                <br />
                                                                                <p>
                                                                                    We will be contacting you to complete set up for an Affiliate Prepaid App. You may
                                                                                    call us to request prepaid codes at 800-281-0263.</p>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2">
                                                                                <h3>
                                                                                    Unpaid:</h3>
                                                                                <br />
                                                                                <p>
                                                                                    You request an unpaid activation code that you send to the associated entity. The
                                                                                    entity clicks on the registration link to begin the sign up and payment process.</p>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </asp:Panel>
                                                                <asp:Label ID="lblviewc" runat="server"></asp:Label>
                                                                <asp:ModalPopupExtender ID="modalPopupSubapp" runat="server" TargetControlID="lblviewc"
                                                                    PopupControlID="pnlSubApp" BackgroundCssClass="modal" CancelControlID="imglogin2">
                                                                </asp:ModalPopupExtender>
                                                                <asp:Panel Style="display: none" ID="pnlSubApp" runat="server" Width="100%">
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
                                                                                                    Sub-Apps
                                                                                                </td>
                                                                                                <td align="right">
                                                                                                    <asp:ImageButton ID="imglogin2" runat="server" ImageUrl="~/images/popup_close.gif"
                                                                                                        CausesValidation="false"></asp:ImageButton>
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
                                                                                                    <asp:GridView ID="grdSubApps" runat="server" Width="100%" CssClass="datagrid2" AutoGenerateColumns="False"
                                                                                                        PageSize="5" AllowPaging="True">
                                                                                                        <EmptyDataRowStyle ForeColor="#C00000"></EmptyDataRowStyle>
                                                                                                        <Columns>
                                                                                                            <asp:BoundField DataField="Profile_name" HeaderText="Sub App Name" />
                                                                                                            <asp:BoundField DataField="User_ID" HeaderText="User ID" />
                                                                                                            <asp:BoundField DataField="Username" HeaderText="Username" />
                                                                                                            <asp:BoundField DataField="CREATED_DT" HeaderText="Activation Date" />
                                                                                                        </Columns>
                                                                                                        <EmptyDataTemplate>
                                                                                                            No sub app(s) found
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
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
        function Display_HowIt_Popup() {
            $find('<%=modalHowIt.ClientID%>').show();
        }   
    </script>
</asp:Content>
