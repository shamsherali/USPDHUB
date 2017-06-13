<%@ Page Title="" Language="C#" MasterPageFile="~/AdminHome.master" AutoEventWireup="true"
    CodeBehind="ManagePromocodes.aspx.cs" EnableEventValidation="false" Inherits="USPDHUB.Admin.ManagePromocodes" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <asp:ScriptManager ID="smgr1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <script type="text/javascript">
        function Validate() {
            if ((document.getElementById('<%=txtFromDate.ClientID%>')).value != '') {
                var strDate = document.getElementById('<%=txtFromDate.ClientID%>').value;
                var endDate = document.getElementById('<%=txtToDate.ClientID%>').value;
                if (new Date(strDate) > new Date(endDate)){
                   alert("To Date should be later than  From Date.");
                  return false;
                  }
            }
            if ((document.getElementById('<%=txtFromDate.ClientID%>')).value == '' && document.getElementById('<%=txtSerach.ClientID %>').value=='') {
                alert("Please enter date or text for searching promocode");
                return false;
             }
        }
    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnExport" />
            <asp:PostBackTrigger ControlID="grdPromocodes" />
        </Triggers>
        <ContentTemplate>
            <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" class="page-padding">
                <tr>
                    <td class="valign-top">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="page-title">
                            <tr>
                                <td>
                                    Manage Promo codes
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
                        <table border="0" cellpadding="0" cellspacing="0" style="padding-bottom: 10px;" width="95%">
                            <tr>
                                <td>
                                    <fieldset style="border: 1px solid #D3D3D3; border-radius: 3px; margin-top: 8px;">
                                        <legend style="color: Green; font-weight: bold;">Search</legend>
                                        <table width="100%">
                                            <tr>
                                                <td colspan="3" align="right" style="padding-right: 190px;">
                                                    Vertical&nbsp;&nbsp;
                                                    <asp:DropDownList runat="server" ID="ddlVerticals" Height="19px">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;From Date:</div>
                                                    <asp:TextBox ID="txtFromDate" TabIndex="2" runat="server" Width="150px">
                                                    </asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqdate" runat="server" ControlToValidate="txtFromDate"
                                                        ValidationGroup="SearchValidationGroup" ErrorMessage="Expiry Date is mandatory.">*</asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularDate11" runat="server" ControlToValidate="txtFromDate"
                                                        ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                                        ValidationGroup="SearchValidationGroup" ErrorMessage="Invalid Expiry Date Format">*</asp:RegularExpressionValidator><br />
                                                    <cc1:CalendarExtender ID="calex" runat="server" TargetControlID="txtFromDate" Format="MM/dd/yyyy"
                                                        CssClass="MyCalendar" />
                                                   </td>
                                                   <td>
                                                    To Date
                                                    <asp:TextBox ID="txtToDate" TabIndex="2" runat="server" Width="150px">
                                                    </asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtToDate"
                                                        ValidationGroup="SearchValidationGroup" ErrorMessage="Expiry Date is mandatory.">*</asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtToDate"
                                                        ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                                        ValidationGroup="SearchValidationGroup" ErrorMessage="Invalid Expiry Date Format">*</asp:RegularExpressionValidator><br />
                                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtToDate"
                                                        Format="MM/dd/yyyy" CssClass="MyCalendar" />
                                                   </td><td>
                                              Search Text&nbsp
                                                    <asp:TextBox ID="txtSerach" runat="server" Width="150px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RFV_SearchText" runat="server" ControlToValidate="txtSerach"
                                                        ErrorMessage="Search Text Can not be blank" ToolTip="Search Text Can not be blank"
                                                        ValidationGroup="SearchValidationGroup">*
                                                    </asp:RequiredFieldValidator>
                                                    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"
                                                        OnClientClick="return Validate();" />&nbsp
                                                        <asp:Button ID="BtnClear" runat="server" Text="Clear"  OnClick="btnClear_Click"
                                                         />
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                </td>
                            </tr>
                        </table>
                        <table cellpadding="0" cellspacing="0" border="0" id="tabber" width="90%">
                            <colgroup>
                                <col width="310px" />
                                <col width="*" />
                            </colgroup>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                        <tr>
                                            <td width="155px">
                                                <asp:LinkButton ID="lnkCurrent" runat="server" OnClick="lnkCurrent_Click" CausesValidation="false"
                                                    Text="<img src='../../Images/Dashboard/current_h.gif' title='Current' border='0'/>"></asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkGetArchive" runat="server" CausesValidation="false" OnClick="lnkGetArchive_Click"
                                                    Text="<img src='../../Images/Dashboard/archive_h.gif' title='Archive' border='0'/>"></asp:LinkButton>
                                                <asp:HiddenField ID="hdnarchive" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td align="right">
                                    <asp:Button ID="btnCreatePromocode" Text="Create Promo code" runat="server" OnClick="btnCreatePromocode_Click" />
                                    &nbsp;
                                    <asp:Button ID="btnExport" Text="Export to Excel" runat="server" OnClick="btnExport_Click" />
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
                                                                            <div style="overflow: scroll; width: 880px; height: 500px;">
                                                                                <asp:GridView ID="grdPromocodes" Width="930px" runat="server" AllowSorting="true"
                                                                                    AutoGenerateColumns="False" AllowPaging="true" OnPageIndexChanging="grdPromocodes_PageIndexChanging"
                                                                                    CssClass="datagrid2" OnRowDataBound="grdPromocodes_OnRowDataBound">
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="Promo code">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblPromocode_Name" runat="server" Text='<%#Eval("Promocode_Name") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle Width="120px" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:BoundField HeaderText="Product" DataField="ProductName" Visible="false" />
                                                                                        <asp:TemplateField HeaderText="Product<br/> Price" Visible="false">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblPrice" runat="server" Text='<%#Eval("Product_Price") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle Width="75px" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Amount<br/> Charged" Visible="false">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("Amount_Charged") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle Width="75px" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Product<br/> Discount" Visible="false">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblDiscount" runat="server" Text='<%#Eval("Product_Discount") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle Width="75px" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Setup <br/>Fee" Visible="false">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblSetupPrice" runat="server" Text='<%#Eval("SetupFee") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle Width="75px" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Setup Fee<br/>Amount Charged" Visible="false">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblSetupAmount" runat="server" Text='<%#Eval("SetupFee_Charged") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle Width="105px" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Setup Fee<br/> Discount" Visible="false">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblSetupDiscount" runat="server"></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle Width="100px" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Renewal <br/>Life Time">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblLifeTime" runat="server" Text='<%#Eval("LifeTimeValid") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle Width="100px" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:BoundField HeaderText="Initials" DataField="InitialsBy" />
                                                                                        <asp:TemplateField HeaderText="Duration" Visible="false">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblDuration_Value" runat="server" Text='<%#Eval("Duration") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle Width="100px" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Created Date">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblCreatedDate" runat="server" Text='<%#Eval("Created_date") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle Width="110px" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Expiry Date">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblPromoCode_ExpiryDate" runat="server" Text='<%#Eval("PromoCode_ExpiryDate") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle Width="110px" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Domain Name">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblDomainname" runat="server" Text='<%#Eval("Domain_Name") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle Width="10px" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Description">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblPromoCode_Description" runat="server" Text='<%#Eval("Promocode_Desc") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle Width="155px" />
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                    <EmptyDataTemplate>
                                                                                        <asp:Label ID="lblBUempty" runat="server" Text="There are no promo codes at this time."
                                                                                            Font-Bold="true" Font-Size="15px" ForeColor="#E8C41D"></asp:Label>
                                                                                    </EmptyDataTemplate>
                                                                                    <HeaderStyle CssClass="title1" />
                                                                                    <EmptyDataRowStyle ForeColor="#C00000" />
                                                                                    <AlternatingRowStyle BackColor="#EEECEC"></AlternatingRowStyle>
                                                                                </asp:GridView>
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
                        <table width="100%" border="0" cellpadding="2" cellspacing="0" class="page-title">
                            <tr>
                                <td align="right">
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
