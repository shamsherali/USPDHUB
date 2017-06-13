<%@ Page Title="" Language="C#" MasterPageFile="~/AdminHome.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="ManageBrandedAppProcessStatus.aspx.cs"
    Inherits="USPDHUB.Admin.ManageBrandedAppProcessStatus" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <asp:ScriptManager ID="smgr1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <style>
                .GridDock
                {
                    overflow-x: auto;
                    overflow-y: hidden;
                    width: 930px;
                    padding: 0 0 10px 0;
                }
              
            </style>
            <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" class="page-padding">
                <tr>
                    <td class="valign-top">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="page-title">
                            <tr>
                                <td style="padding-bottom:5px;">
                                    Manage Branded App Process Status
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
                                    <asp:Label ID="lblmsg" runat="server" ForeColor="Green"></asp:Label>
                                </td>
                            </tr>
                        </table>
                         <table style="padding-bottom: 10px;" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    Vertical&nbsp;&nbsp;
                                    <asp:DropDownList runat="server" ID="ddlVerticals" Height="19px">
                                    </asp:DropDownList>
                                </td>
                                <td>&nbsp Search Text&nbsp
                               <asp:TextBox ID="txtSearch" runat="server" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RFV_SearchText" runat="server" ControlToValidate="txtsearch"
                                ErrorMessage="Search Text Can not be blank" ToolTip="Search Text Can not be blank"
                                ValidationGroup="SearchValidationGroup">*
                            </asp:RequiredFieldValidator>
                           
                                <asp:Button ID="btnSearch" runat="server" Text="Search" ValidationGroup="SearchValidationGroup" OnClick="btnSearch_Click"  />
                                &nbsp
                                <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
                                </td>
                            </tr>
                        </table>
                        <table cellpadding="0" cellspacing="0" border="0" id="tabber" width="100%">
                            <colgroup>
                                <col width="310px" />
                                <col width="*" />
                            </colgroup>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                        <tr>
                                            <td width="155px">
                                                <asp:LinkButton ID="lnkCurrent" runat="server" OnClick="lnkCustomerService_Click"
                                                    CausesValidation="false" Text="<img src='../../Images/Dashboard/current_h.gif' title='Customer Service' border='0'/>"></asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkGetArchive" runat="server" CausesValidation="false" OnClick="lnkEngineering_Click"
                                                    Text="<img src='../../Images/Dashboard/archive_h.gif' title='Engineering' border='0'/>"></asp:LinkButton>
                                                <asp:HiddenField ID="hdnTabType" runat="server" />
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkCompleted" runat="server" CausesValidation="false" OnClick="lnkCompleted_Click"
                                                    Text="<img src='../../Images/Dashboard/archive_h.gif' title='Completed' border='0'/>"></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td align="right">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" class="content">
                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                        <tr>
                                            <td class="leftmenu">
                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td valign="top">
                                                            <table class="valign-top" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                <tbody>
                                                                    <tr>
                                                                        <td valign="top">
                                                                            <div class="GridDock" id="dvGridWidth">
                                                                                <asp:GridView ID="grdProcessStatus" runat="server" AllowSorting="true" AutoGenerateColumns="False"
                                                                                    AllowPaging="true" OnPageIndexChanging="grdProcessStatus_PageIndexChanging" CssClass="datagrid2"
                                                                                    Width="100%" OnRowDataBound="grdProcessStatus_OnRowDataBound" PageSize="10" OnSorting="grdProcessStatus_OnSorting">
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="Profile ID" SortExpression="ProfileID">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblProfileID" runat="server" Text='<%#Eval("ProfileID") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle Width="120px" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="User ID" SortExpression="UserID">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblUserID" runat="server" Text='<%#Eval("UserID") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle Width="120px" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="App Display Name" SortExpression="App_DisplayName">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblAppName" runat="server" Text='<%#Eval("App_DisplayName") %>'></asp:Label>
                                                                                                <asp:Label ID="lblRequestCount" runat="server" Text='<%#Eval("RequestCount") %>'
                                                                                                    Style="display: none;"></asp:Label>
                                                                                                <br />
                                                                                                <asp:LinkButton ID="lnkManageRequest" runat="server" CommandArgument='<%#Eval("BrandedApp_OrderID")%>' Visible="false" OnClick="lnkManageRequest_Click"></asp:LinkButton>
                                  
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle Width="200px" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Product Name" SortExpression="Vertical_Name">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblVertical_Name" runat="server" Text='<%#Eval("Vertical_Name") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle Width="200px" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Product Details">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblProfileDetails" runat="server" Text='<%#Eval("ProfileDetails") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle Width="400px" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Status" SortExpression="Status_Name">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblStatusName" runat="server" Text='<%#Eval("Status_Name") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle Width="200px" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:BoundField HeaderText="Modified Date" DataField="Modified_Date">
                                                                                            <ItemStyle Width="120px" />
                                                                                        </asp:BoundField>
                                                                                        <asp:TemplateField HeaderText="Edit">
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton runat="server" ID="btnEdit" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"BrandedApp_OrderID") %>'
                                                                                                    OnClick="btnEdit_Click" Text="<img src='../../Images/Dashboard/icon_modify.gif' title='Edit' border='0'"></asp:LinkButton>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle Width="50px" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Delete">
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton runat="server" ID="lnkDeleteApp" CommandArgument='<%#Eval("BrandedApp_OrderID") %>'
                                                                                                    Text="<img src='../../Images/Dashboard/icon_delete.gif' title='Edit' border='0'"
                                                                                                    OnClientClick="return confirm('Are you sure you want to delete this branded app request?');"
                                                                                                    OnClick="lnkDeleteApp_Click"></asp:LinkButton>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Change Status" Visible="false">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblBrandAppOrderID" runat="server" Text='<%#Eval("BrandedApp_OrderID") %>'
                                                                                                    Style="display: none;"></asp:Label>
                                                                                                <asp:Label ID="lblStatusID" runat="server" Text='<%#Eval("StatusID") %>' Style="display: none;"></asp:Label>
                                                                                                <asp:LinkButton runat="server" ID="btnChangeStatus" CommandArgument='<%#Eval("BrandedApp_OrderID") + ","+Eval("StatusID") %>'
                                                                                                    OnClick="btnChangeStatus_Click"></asp:LinkButton>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle Width="120px" />
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                    <EmptyDataTemplate>
                                                                                        <asp:Label ID="lblBUempty" runat="server" Text="" Font-Bold="true" Font-Size="15px"
                                                                                            ForeColor="#E8C41D"></asp:Label>
                                                                                    </EmptyDataTemplate>
                                                                                    <HeaderStyle CssClass="title1" />
                                                                                    <EmptyDataRowStyle ForeColor="#C00000" />
                                                                                    <AlternatingRowStyle BackColor="#EEECEC"></AlternatingRowStyle>
                                                                                </asp:GridView>
                                                                                <asp:HiddenField ID="hdnsortdire" runat="server"></asp:HiddenField>
                                                                                <asp:HiddenField ID="hdnsortcount" runat="server"></asp:HiddenField>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                       
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td>
                                    <asp:Label ID="lblDummy"  runat="server"></asp:Label>
                                    <cc1:ModalPopupExtender ID="MPERequestDetails" runat="server" TargetControlID="lblDummy"
                                        PopupControlID="pnlRequestDetails" BackgroundCssClass="modal" CancelControlID="imgClose">
                                    </cc1:ModalPopupExtender>
                                    <asp:Panel ID="pnlRequestDetails" runat="server" Style="display: none;">
                                        <table cellpadding="0" cellspacing="0" width="100%" class="popuptable" align="center"
                                            border="0">
                                            <tbody>
                                                <tr>
                                                    <td>
                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0" style="padding: 5px;">
                                                            <tbody>
                                                                <tr>
                                                                    <td align="right">
                                                                        <asp:ImageButton ID="imgClose" runat="server" ImageUrl="~/images/popup_close.gif"
                                                                            CausesValidation="false"></asp:ImageButton>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center">
                                                        <asp:UpdateProgress ID="UpdateProgress2" runat="server" DisplayAfter="3">
                                                            <ProgressTemplate>
                                                                <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                                            </ProgressTemplate>
                                                        </asp:UpdateProgress>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 100%;">
                                                        <div style="height: 400px; overflow-y:hidden; position: relative; width: 725px; border: 0px solid #888;">
                                                            <iframe name="iframeManageRequest" src="AdditionalBrandedRequestsPopUp.aspx" width="705" style="min-height:400px;" frameborder="0">
                                                            </iframe>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <script>
                function ShowMessage(SID) {
                    // SID=3 Status:: Development 
                    // SID=4:: Device Testing
                    // SID==5:: Submit to Store
                    if (SID == 3) {
                        return confirm("Do you want to submit app for testing?");
                    }
                    else if (SID == 4) {
                        return confirm("Do you want to upload app for store?");
                    }

                }

            </script>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
