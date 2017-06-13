<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin.master"
    Inherits="Business_MyAccount_Discussions" Codebehind="Discussions.aspx.cs" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Login.ascx" TagName="Login" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/WowAds.ascx" TagName="wowads" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/Sitemaplinks.ascx" TagName="wowmap" TagPrefix="uc3" %>
<asp:Content ContentPlaceHolderID="cphUser" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <contenttemplate>
    <table class="page-padding" cellspacing="0" cellpadding="0" width="100%" align="center"
        border="0">
        <tbody>
            <tr>
                <td>
                    <uc3:wowmap ID="Wowmap1" runat="server"></uc3:wowmap>
                    <table class="page-title" cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tbody>
                            <tr>
                                <td style="height: 32px">
                                    <img height="32" src='<%=Page.ResolveClientUrl("~/images/icon_discussions.gif")%>'
                                        width="24" />
                                    <!--<asp:Label id="lblfirstname" runat="server"></asp:Label>-->
                                    Message Center</td>
                                <td align="center">
                                    <asp:UpdateProgress id="UpdateProgress2" runat="server" DisplayAfter="3">
                                        <progresstemplate>
                                                    <img src="<%=Page.ResolveClientUrl("~/images/popup_ajax-loader.gif")%>" border="0" /><b><font color="green">Processing....</font></b> 
                                                </progresstemplate>
                                    </asp:UpdateProgress>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">
                                    <asp:Label ID="lblmess" runat="server" ForeColor="Green" Font-Size="Medium"></asp:Label><asp:Label ID="errMsg" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tbody>
                            <tr>
                                <td>
                                    <div id="tabs1">
                                        <ul>
                                            <!-- CSS Tabs -->
                                            <li id="current"><a href='<%=Page.ResolveClientUrl("~/Business/MyAccount/Discussions.aspx")%>'>
                                                <span>Messages</span></a></li>
                                            <li><a href='<%=Page.ResolveClientUrl("~/Business/MyAccount/NewsletterAlerts.aspx")%>'>
                                                <span>Inquiries</span></a></li>                                            
                                        </ul>
                                    </div>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <table class="inputtable" cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tbody>
                            <tr>
                                <td>
                                    <table class="inputgrid" cellspacing="0" cellpadding="0" width="100%" border="0"
                                        style="padding-bottom: 0;">
                                        <tbody>
                                            <tr>
                                                <td align="justify" style="padding-bottom: 0; margin: 0px;">
                                                    Click on message subject to respond to a message.
                                                </tr>
                                                <tr>
                                                    <td>
                                                        *NOTE: Reply button will not appear on messages sent from Non-Members. You may copy the email address and reply via your email provider. 
                                                    </td>
                                                </tr>
                                        </tbody>
                                    </table>
                                    <table class="inputgrid" cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="pnlmail" runat="server" Width="100%">
                                                        <table cellpadding="0" cellspacing="0" border="0">
                                                        <%if (Session["Free"] != null)
                                                          {
                                                              if (Session["Free"] != "") { }
                                                          }
                                                               %>
                                                        <%else
                                                            { %>
                                                            <tr>
                                                                <td valign="top" nowrap>&nbsp;
                                                                   <%-- <a href="<%=Page.ResolveClientUrl("~/Business/Myaccount/sendmail.aspx")%>"
                                                                        title="Compose mail">
                                                                        <img src="<%=Page.ResolveClientUrl("~/Images/ComposeMail.gif")%>"
                                                                            title="Compose mail" border="0" /></a>&nbsp;
                                                                    <asp:LinkButton Style="font-weight: bold; color: #0b689d; font-family: verdana; size: 16px;"
                                                                        ID="lblCompose" OnClick="lblCompose_Click" runat="server" Text="Compose"></asp:LinkButton>--%>
                                                                </td>
                                                            </tr>
                                                            <%} %>
                                                            <tr>
                                                                <td class="valign-top" width="130" colspan="2">
                                                                    <table class="outlook" cellspacing="2" cellpadding="2" width="100%" border="0">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td>
                                                                                    <img height="15" src="../../images/inbox.gif" width="16" /></td>
                                                                                <td nowrap>
                                                                                    <a href="Discussions.aspx?T=INBOX">
                                                                                        <asp:Label ID="lblinbox" runat="server"></asp:Label></a>
                                                                                </td>
                                                                            </tr>

                                                                             <tr>
                                                                                <td>
                                                                                    <img height="15" src="../../images/message-r0-s3.gif" width="16" />
                                                                                </td>
                                                                                <td nowrap>
                                                                                  <asp:LinkButton ID="lnkUnRead" runat="server" Text="Unread" onclick="lnkUnRead_Click" ></asp:LinkButton>
                                                                                        </td>
                                                                            </tr>

                                                                            <tr>
                                                                                <td>
                                                                                    <img height="15" src="../../images/sent.gif" width="16" />
                                                                                </td>
                                                                                <td nowrap>
                                                                                    <a href="Discussions.aspx?T=SENT">
                                                                                        <asp:Label ID="lblsent" runat="server"></asp:Label></a></td>
                                                                            </tr>
                                                                            
                                                                        </tbody>
                                                                    </table>
                                                                </td>
                                                                <td style="width: 100%" class="valign-top">
                                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0" class="inputgrid">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td class="valign-top" style="padding-top: 0;">
                                                                                    <asp:GridView ID="Discussions" runat="server" Width="100%" OnSelectedIndexChanging="msgGrid_SelectedIndexChanging"
                                                                                        OnPageIndexChanging="msgGrid_PageIndexChanging" AllowPaging="True" OnRowDataBound="msgGrid_RowDataBound"
                                                                                        OnRowCancelingEdit="msgGrid_RowCancelingEdit"
                                                                                        OnRowEditing="msgGrid_RowEditing" DataKeyNames="Message_ID" AutoGenerateColumns="False"
                                                                                        CssClass="datagrid2" GridLines="none">
                                                                                        <Columns>
                                                                                            <asp:TemplateField>
                                                                                                <ItemStyle Width="10px" />
                                                                                                <ItemTemplate>
                                                                                                    <asp:Image ID="MessageLogo" Height="20px" Width="20px" runat="server" />
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Subject" HeaderStyle-CssClass="title1">
                                                                                                <EditItemTemplate>
                                                                                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# GetViewURLString((int)DataBinder.Eval(Container.DataItem, "Message_ID")) %>'></asp:TextBox>
                                                                                                </EditItemTemplate>
                                                                                                <ItemStyle />
                                                                                                <HeaderStyle CssClass="align-center" />
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="Label3" runat="server" Text='<%# GetViewURLString((int)DataBinder.Eval(Container.DataItem, "Message_ID")) %>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderStyle-CssClass="title1">
                                                                                                <EditItemTemplate>
                                                                                                    <asp:TextBox ID="TextBox6" runat="server" ReadOnly="true" Width="100px" Text='<%# Bind("sendername") %>'></asp:TextBox>
                                                                                                </EditItemTemplate>
                                                                                                <ItemStyle Width="100px" />
                                                                                                <HeaderStyle CssClass="align-center" />
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("sendername") %>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Date &amp; Time Sent" HeaderStyle-CssClass="title1">
                                                                                                <EditItemTemplate>
                                                                                                    <asp:TextBox ID="TextBox7" runat="server" ReadOnly="true" Width="100px" Text='<%# Bind("CREATED_DT") %>'></asp:TextBox>
                                                                                                </EditItemTemplate>
                                                                                                <ItemStyle Width="160px" />
                                                                                                <HeaderStyle CssClass="align-center" />
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("CREATED_DT") %>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderStyle-CssClass="title1">
                                                                                                <HeaderStyle CssClass="align-center" />
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblstatus" runat="server"></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Action" HeaderStyle-CssClass="title1">
                                                                                                <EditItemTemplate>
                                                                                                    <asp:TextBox ID="TextBox4" runat="server" Width="60px" Text='<%# GetURLString((int)DataBinder.Eval(Container.DataItem, "Message_ID")) %>'></asp:TextBox>
                                                                                                </EditItemTemplate>
                                                                                                <ItemStyle Width="60px" />
                                                                                                <HeaderStyle CssClass="align-center" />
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="Label4" runat="server" Text='<%# GetURLString((int)DataBinder.Eval(Container.DataItem, "Message_ID")) %>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Delete">
                                                                                              <ItemTemplate>
                                                                                               <asp:LinkButton ID="btnDelete" runat="server" Text="<img src='../../Images/icon_delete.gif' title='Delete.' border='0' width='25px' height='25px'>"
                                                                                                    CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Message_ID") %>' OnClick="btnDelete_Click"></asp:LinkButton>
                                                                                              </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                        <HeaderStyle CssClass="title1" Font-Size="12px" Height="25px" HorizontalAlign="left" />
                                                                                        <EmptyDataTemplate>
                                                                                           No messages found.
                                                                                        </EmptyDataTemplate>
                                                                                        <EmptyDataRowStyle ForeColor="#C00000" />
                                                                                        <AlternatingRowStyle BackColor="#E0E0E0" />
                                                                                    </asp:GridView>
                                                                                </td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td align="center" colspan="3">
                                                                                    <%--<asp:Label ID="errMsg" runat="server"></asp:Label>--%></td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </tbody>
    </table>
    </contenttemplate>
    </asp:UpdatePanel>
</asp:Content>
