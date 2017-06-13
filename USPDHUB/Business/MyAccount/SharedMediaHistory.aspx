<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="SharedMediaHistory.aspx.cs" Inherits="USPDHUB.Business.MyAccount.SharedMediaHistory" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cphUser" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" class="page-padding">
                <tr>
                    <td class="valign-top">

                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="inputtable">


                            <tr>
                                <td style="padding-top: 10px; padding-left: 5px; color: #005AA0; font-weight: bold;">
                                    History of Shared Social Media 
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="datagrid nomargin-bottom">
                                        <tr>
                                            <td>
                                                <asp:GridView ID="gvSharedHistory" runat="server"
                                                    AutoGenerateColumns="False" AllowPaging="true" Width="100%" OnPageIndexChanging="gvSharedHistory_PageIndexChanging"
                                                     CssClass="datagrid2" PageSize="10">
                                                    <Columns>
                                                    
                                                      
                                                        <asp:TemplateField HeaderText="Title">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTitle" runat="server" Text='<%#Eval("ContentTitle") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="25%" />
                                                            <HeaderStyle Font-Size="12px" HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="MediaType">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblMediaType" runat="server" Text='<%#Eval("Media_TYPE") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="25%" />
                                                            <HeaderStyle Font-Size="12px" HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Status">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("Status") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="25%" />
                                                            <HeaderStyle Font-Size="12px" HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Sent Date">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSenddate" runat="server" Text='<%#Eval("Sent_Date") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Font-Size="12px" Width="25%" />
                                                            <HeaderStyle Font-Size="12px" />
                                                        </asp:TemplateField>
                                                      
                                                        
                                                    </Columns>
                                                    <EmptyDataTemplate>
                                                        <asp:Label ID="lblNoempty" runat="server" Text="There are no records at this time."
                                                            Font-Bold="true" Font-Size="15px" ForeColor="#E8C41D"></asp:Label>
                                                    </EmptyDataTemplate>
                                                    <HeaderStyle CssClass="title1" />
                                                </asp:GridView>
                                               
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>



                            <tr>
                                <td align="center" style="background-color: #D2E5FA; border: 1px solid #D1DDEA; padding: 7px 0px 7px 0px;">
                                    <asp:Button ID="btnGoDashboard" CssClass="button" runat="server" Text="Go to Dashboard" OnClick="btnGoDashboard_Click"
                                        CausesValidation="false" />
                                </td>
                            </tr>
                        </table>

                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
