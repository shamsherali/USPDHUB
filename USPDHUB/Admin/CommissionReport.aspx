<%@ Page Title="" Language="C#" MasterPageFile="~/AdminHome.master" AutoEventWireup="true"
    CodeBehind="CommissionReport.aspx.cs" Inherits="USPDHUB.Admin.CommissionReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSubmit" />
        </Triggers>
        <ContentTemplate>
            <table class="page-padding" cellspacing="0" cellpadding="0" width="100%" border="0">
                <tbody>
                    <tr>
                        <td class="valign-top">
                            <table class="page-title" cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td style="height: 35px; font-size: 18px; color: #EC2027; margin-bottom: 5px; margin-top: 5px;
                                            font-weight: bold;">
                                            Sales Commission Report
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:UpdateProgress ID="UpdateProgress2" runat="server" DisplayAfter="3">
                                                <ProgressTemplate>
                                                    <img src="../../images/popup_ajax-loader.gif" border="0"><b><font color="green">Processing....</font></b>
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td style="color: green" align="center">
                                            <asp:Label ID="lblmess" runat="server" Font-Size="14px" Font-Bold="true"></asp:Label>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table cellspacing="0" cellpadding="0" width="90%" border="0">
                                <tr>
                                    <td>
                                        &nbsp;
                                        <asp:Label ID="Label1" runat="server" Text="Sales Person" Font-Bold="true"></asp:Label>&nbsp;
                                        <asp:DropDownList ID="ddlSalesPerson" Width="150px" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text="From Date" Font-Bold="true"></asp:Label>&nbsp;
                                        <asp:TextBox ID="txtStartDate" runat="server" Width="150px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="reqdate" runat="server" ControlToValidate="txtStartDate"
                                            ValidationGroup="ABC" ErrorMessage="Date is mandatory.">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularDate" runat="server" ControlToValidate="txtStartDate"
                                            ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                            ValidationGroup="ABC" ErrorMessage="Invalid Date Format">*</asp:RegularExpressionValidator><br />
                                        <cc1:CalendarExtender ID="calex" runat="server" TargetControlID="txtStartDate" Format="MM/dd/yyyy"
                                            CssClass="MyCalendar" />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text="To Date" Font-Bold="true"></asp:Label>&nbsp;
                                        <asp:TextBox ID="txtEndDate" runat="server" Width="150px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEndDate"
                                            ValidationGroup="ABC" ErrorMessage="Date is mandatory.">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEndDate"
                                            ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                            ValidationGroup="ABC" ErrorMessage="Invalid Date Format">*</asp:RegularExpressionValidator><br />
                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtEndDate"
                                            Format="MM/dd/yyyy" CssClass="MyCalendar" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnSearch" Text="Search" runat="server" ValidationGroup="ABC" OnClick="BtnSearchClick" />
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <table class="admin-padding inputgrid" cellspacing="0" cellpadding="0" width="100%"
                                border="0">
                                <tbody>
                                    <tr>
                                        <td class="valign-top">
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tbody>
                                                    <tr>
                                                        <td style="padding-bottom: 20px;">
                                                            <asp:Panel ID="pnlCommission" runat="server" ScrollBars="Auto" Width="100%" Height="400px">
                                                                <asp:GridView ID="dgCommission" runat="server" ShowFooter="True" AutoGenerateColumns="false"
                                                                    Width="100%" AllowSorting="true" CssClass="datagrid2" OnRowDataBound="DgCommissionRowDataBound">
                                                                    <EmptyDataRowStyle ForeColor="#C00000"></EmptyDataRowStyle>
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Month">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblMonth" runat="server" Text='<%#Bind("Transaction_Date")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Customer">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblCustomer" runat="server" Text='<%#Bind("Customer")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Order <br/>/ Invoice #">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label2" runat="server" Text='#'></asp:Label>
                                                                                <asp:Label ID="lblTID" runat="server" Text='<%# Bind("OrderID") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblT" runat="server" Text="Total" />
                                                                            </FooterTemplate>
                                                                            <FooterStyle Font-Bold="True" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Revenue">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label4" runat="server" Text='$'></asp:Label>
                                                                                <asp:Label ID="lblOrderTotal" runat="server" Text='<%#Bind("Billable_Amount") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblRevenueTotal" runat="server" />
                                                                            </FooterTemplate>
                                                                            <FooterStyle Font-Bold="True" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Commissioned <br/>Salesperson">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblSalesName" runat="server" Text='<%#Bind("SalesName") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Commission <br/>Rate">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblPercentage" runat="server" Text='<%#Bind("Commission_Rate") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Commission <br/>Amount">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label3" runat="server" Text='$'></asp:Label>
                                                                                <asp:Label ID="lblCommission_Amt" runat="server" Text='<%#Bind("Commission_Amt") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblCommissionAmtTotal" runat="server" />
                                                                            </FooterTemplate>
                                                                            <FooterStyle Font-Bold="True" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Commission <br/>Payable">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label4" runat="server" Text='$'></asp:Label>
                                                                                <asp:Label ID="lblBillable_Amount" runat="server" Text='<%#Bind("Commission_Payable") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblBillableTotal" runat="server" />
                                                                            </FooterTemplate>
                                                                            <FooterStyle Font-Bold="True" />
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <HeaderStyle CssClass="title" />
                                                                    <EmptyDataTemplate>
                                                                        No Records are found.
                                                                    </EmptyDataTemplate>
                                                                    <EmptyDataRowStyle ForeColor="#C00000" />
                                                                </asp:GridView>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr id='ExportRow' runat="server" visible="false" style="height: 40px; background-color: #89D255;">
                                                        <td align="center">
                                                            <asp:Button ID="btnExportSelected" Text="Export to Excel" runat="server" OnClientClick="return ShowModalPopup()" />&nbsp;
                                                            <asp:Button ID="btnPrint" Text="Print" runat="server" OnClientClick="CallPrint();" />
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
            <table border="0" width="50%" cellpadding="0" cellspacing="0" align="center">
                <tr>
                    <td valign="top">
                        <asp:Label ID="lblexprot" runat="server"></asp:Label>
                        <cc1:ModalPopupExtender ID="ExportmodalPopup" runat="server" TargetControlID="lblexprot"
                            PopupControlID="pnlpopup5" BackgroundCssClass="modal" BehaviorID="lblhtml">
                        </cc1:ModalPopupExtender>
                        <asp:Panel ID="pnlpopup5" runat="server" Width="50%" Style="display: none;">
                            <table class="popuptable" width="70%" cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td align="right" style="padding: 5px 10px 0px 10px;">
                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="../../images/popup_close.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:UpdateProgress ID="UpdateProgress5" runat="server" DisplayAfter="3">
                                            <ProgressTemplate>
                                                <img src="../../images/popup_ajax-loader.gif" border="0"><span class="processing">Processing....</span>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table width="100%" cellpadding="3" cellspacing="0" border="0">
                                            <tr>
                                                <td>
                                                    Export User:
                                                </td>
                                                <td>
                                                    <asp:TextBox runat="server" Width="250px" ID="txtUserName"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RFExportUser" ControlToValidate="txtUserName" runat="server"
                                                        ErrorMessage="*" ValidationGroup="Validate">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top">
                                                    Comment:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtNotes" runat="server" TextMode="MultiLine" Width="250px" Height="100px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RFComments" runat="server" ControlToValidate="txtNotes"
                                                        ErrorMessage="*" ValidationGroup="Validate">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" align="center">
                                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" ValidationGroup="Validate"
                                                        OnClick="BtnSubmitOnClick" OnClientClick="return Message();" />&nbsp;
                                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
            <input type="hidden" id='SearchCount' runat="server" value="0" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
        function ShowModalPopup() {
            if (document.getElementById("<%=SearchCount.ClientID %>").value == "0") {
                alert("No records are found.");
            } else {
                document.getElementById('<%=txtUserName.ClientID%>').value = '';
                document.getElementById('<%=txtNotes.ClientID%>').value = '';
                $find("lblhtml").show();
            }
            return false;
        }
        //Print
        function CallPrint() {
            if (document.getElementById("<%=SearchCount.ClientID %>").value == "0") {
                alert("No records are found.");
            }
            else {
                var prtContent = document.getElementById('<%=pnlCommission.ClientID%>');
                var WinPrint = window.open('', '', 'letf=0,top=0,width=800,height=500,toolbar=0,scrollbars=0,status=0');
                WinPrint.document.write(prtContent.innerHTML);
                WinPrint.document.close();
                WinPrint.focus();
                WinPrint.print();
                WinPrint.close();
            }
        }

        function Message() {
            if (Page_ClientValidate('Validate')) {
                var result = confirm('Are you sure you want to export?');
                if (result) {
                    $find("lblhtml").hide();
                    return true;
                }
                else {
                    return false;
                }
            }
        }
    </script>
</asp:Content>
