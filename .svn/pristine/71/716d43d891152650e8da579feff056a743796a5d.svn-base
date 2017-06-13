<%@ Page Title="" Language="C#" MasterPageFile="~/AdminHome.Master" AutoEventWireup="true"
    CodeBehind="ManageSalesPeople.aspx.cs" Inherits="USPDHUB.Admin.ManageSalesPeople" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="page-padding">
                <tr>
                    <td>
                    </td>
                    <td>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="page-title">
                            <tr>
                                <td style="width: 35px;">
                                </td>
                                <td style="padding-top: 8px;" align="left">
                                    Manage Sales People
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="color: Red;">
                            <tr>
                                <td align="center">
                                    <asp:UpdateProgress ID="UpdateProgress6" runat="server" DisplayAfter="3">
                                        <ProgressTemplate>
                                            <img src="../../images/popup_ajax-loader.gif" border="0"><span class="processing">Processing....</span>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                    <asp:Label ID="lblSuccess" runat="server" Style="font-weight: bold; font-size: 16px;"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td align="right">
                                    <asp:Button ID="btnAddNew" runat="server" Text="Add Sales Person" OnClick="BtnAddNewClick"
                                        CausesValidation="false" />
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <div style="overflow-y: auto; overflow-x: hidden; height: 500px;">
                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="admin-padding inputgrid">
                                            <tr>
                                                <td valign="top">
                                                    <asp:GridView ID="SalesPersonGrid" runat="server" AutoGenerateColumns="False" DataKeyNames="SalePerson_ID"
                                                        CssClass="datagrid2" AllowPaging="True" OnPageIndexChanging="SalesPersonGrid_PageIndexChanging"
                                                        OnRowCommand="SalesPersonGrid_RowCommand" OnRowDeleting="SalesPersonGrid_RowDeleting"
                                                        PageSize="50">
                                                        <Columns>
                                                            <asp:BoundField DataField="Sales_Firstname" HeaderText="First Name">
                                                                <HeaderStyle Width="100px"></HeaderStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Sales_Lastname" HeaderText="Last Name">
                                                                <HeaderStyle Width="100px"></HeaderStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Email" HeaderText="Email">
                                                                <HeaderStyle Width="150px"></HeaderStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Contact_Phone" HeaderText="Phone Number">
                                                                <HeaderStyle Width="100px"></HeaderStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Effected_Date" HeaderText="Effected Date" DataFormatString="{0:MM/dd/yyyy}"
                                                                HtmlEncode="False">
                                                                <HeaderStyle Width="150px"></HeaderStyle>
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="Commission">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblCommission" runat="server" Text='<%# GetCommission(Eval("Percentage"),Eval("CPercentage")) %>'>
                                                                    </asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle Width="120px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Manager">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblManager" runat="server" Text='<%# Eval("SalesManager") %>'>
                                                                    </asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle Width="150px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Created_Date" HeaderText="Created Date" DataFormatString="{0:MM/dd/yyyy}"
                                                                HtmlEncode="False">
                                                                <HeaderStyle Width="150px"></HeaderStyle>
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="Edit">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton runat="server" ID="btnEdit" Text="<img src='../Images/icon_modify.gif' title='Edit' border='0'"
                                                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"SalePerson_ID") %>' OnClientClick="return confirm('Are you sure you want to edit this sales person?');"
                                                                        OnClick="BtnEditClick"></asp:LinkButton>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="50px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Delete">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton runat="server" ID="btnDelete" CommandName="Delete" Text="<img src='../Images/icon_delete.gif' title='Delete' border='0'"
                                                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"SalePerson_ID") %>' OnClientClick="return confirm('Are you sure you want to delete this sales person?');"></asp:LinkButton>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="50px" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <HeaderStyle CssClass="title" />
                                                        <EmptyDataTemplate>
                                                            No data Found
                                                        </EmptyDataTemplate>
                                                        <EmptyDataRowStyle ForeColor="#C00000" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <table cellspacing="0" cellpadding="0" border="0">
                            <tbody>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblSalesPerson" runat="server"></asp:Label>
                                        <asp:ModalPopupExtender ID="mpeSalesPerson" runat="server" BackgroundCssClass="modal"
                                            PopupControlID="pnlSalesPerson" TargetControlID="lblSalesPerson" CancelControlID="imgClose">
                                        </asp:ModalPopupExtender>
                                        <asp:Panel Style="display: none" ID="pnlSalesPerson" runat="server" Width="100%">
                                            <table class="popuptable" cellspacing="0" cellpadding="0" width="600px" align="center"
                                                border="0">
                                                <tr>
                                                    <td align="center">
                                                        <asp:UpdateProgress ID="UpdateProgress10" runat="server" DisplayAfter="3">
                                                            <ProgressTemplate>
                                                                <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                                            </ProgressTemplate>
                                                        </asp:UpdateProgress>
                                                    </td>
                                                    <td align="right">
                                                        <asp:ImageButton ID="imgClose" runat="server" ImageUrl="~/images/popup_close.gif"
                                                            CausesValidation="false"></asp:ImageButton>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="center">
                                                        <asp:Label ID="lblerror" runat="server" Style="font-weight: bold; font-size: 16px;"></asp:Label>
                                                        <table border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td>
                                                                    <asp:ValidationSummary ID="ValidateUserDetails" runat="server" Style="text-align: left;"
                                                                        ValidationGroup="A" HeaderText="The following error(s) occurred:" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <table border="0" cellpadding="4" cellspacing="0" width="100%">
                                                            <tr>
                                                                <td style="width: 100px;">
                                                                    First Name:
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtFirstName" runat="server" TabIndex="1"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator runat="server" ID="RFFirstName" ControlToValidate="txtFirstName"
                                                                        ValidationGroup="A" ErrorMessage="First name is mandatory.">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td style="width: 100px;">
                                                                    Last Name:
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtLastName" runat="server" TabIndex="2"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100px;">
                                                                    Email:
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtEmail" runat="server" TabIndex="3"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator runat="server" ID="RFEmail" ControlToValidate="txtEmail"
                                                                        ValidationGroup="A" ErrorMessage="Email is mandatory.">*</asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                                                            ID="REEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email is invalid format."
                                                                            Font-Size="XX-Small" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                            ValidationGroup="A">*
                                                                        </asp:RegularExpressionValidator>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td style="width: 100px;">
                                                                    Phone Number:
                                                                </td>
                                                                <td>
                                                                    <asp:TextBoxWatermarkExtender ID="txtWM" TargetControlID="txtPhone" WatermarkText="xxx-xxx-xxxx"
                                                                        WatermarkCssClass="watermark" runat="server">
                                                                    </asp:TextBoxWatermarkExtender>
                                                                    <asp:TextBox ID="txtPhone" runat="server" MaxLength="14" TabIndex="4">
                                                                    </asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="REPhone" runat="server" ControlToValidate="txtPhone"
                                                                        ErrorMessage="Phone numaber is invalid format." Font-Size="XX-Small" ValidationExpression="^[0-9]\d{2}-\d{3}-\d{4}$"
                                                                        ValidationGroup="A">*
                                                                    </asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    Manager:
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlManager" runat="server" TabIndex="5" Width="150px">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                    Commission:
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlCommission" runat="server" TabIndex="6" Width="150px">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator runat="server" ID="RFCommssion" ControlToValidate="ddlCommission"
                                                                        ValidationGroup="A" ErrorMessage="Select a commission." InitialValue="0">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding-bottom: 17px;">
                                                                    Effected Date:
                                                                </td>
                                                                <td colspan="4">
                                                                    <asp:TextBox ID="txtEffectedDate" runat="server" TabIndex="5"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="reqdate" runat="server" ControlToValidate="txtEffectedDate"
                                                                        ValidationGroup="A" ErrorMessage="Effected date is mandatory.">*</asp:RequiredFieldValidator>
                                                                    <asp:RegularExpressionValidator ID="RegularDate" runat="server" ControlToValidate="txtEffectedDate"
                                                                        ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                                                        SetFocusOnError="True" ValidationGroup="A" ErrorMessage="Effected date is invalid format.">*</asp:RegularExpressionValidator><br>
                                                                    <b>(MM/DD/YYYY)</b>
                                                                    <asp:CalendarExtender ID="calex" runat="server" TargetControlID="txtEffectedDate"
                                                                        Format="MM/dd/yyyy" CssClass="MyCalendar" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding-bottom: 17px;">
                                                                    Comments:
                                                                </td>
                                                                <td colspan="4">
                                                                    <asp:TextBox ID="txtComments" runat="server" MaxLength="200" Width="430px" TabIndex="8"></asp:TextBox><br />
                                                                    (200 Characters)
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="5">
                                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                        <tr>
                                                                            <td style="padding-bottom: 17px;">
                                                                                Verticals:
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="color: #F88408; font-weight: bold;">
                                                                                <asp:CheckBox ID="CheckVerticalAll" runat="server" Text="Select All" onclick='CheckVerticalAll(this);' />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="padding-left: 15px;">
                                                                                <asp:CheckBoxList ID="CheckVerticals" runat="server" EnableViewState="true" RepeatDirection="Horizontal"
                                                                                    RepeatColumns="3" onclick="Uncheck();" OnDataBound="CheckVerticals_DataBound">
                                                                                </asp:CheckBoxList>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" style="padding: 10px;" colspan="5">
                                                                    <asp:Button ID="btnSumbit" runat="server" Text="Add Sales Person" ValidationGroup="A"
                                                                        TabIndex="9" OnClick="BtnSumbitClick" OnClientClick="Changehdn()" /><asp:HiddenField
                                                                            ID="hdnComsRate" runat="server" />
                                                                    <asp:HiddenField ID="hdnSPID" runat="server" Value="0" />
                                                                    <asp:HiddenField ID="hdnVerticals" runat="server" Value="" />
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
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
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
        function CheckVerticalAll(obj1) {
            var checkboxCollection = document.getElementById('<%=CheckVerticals.ClientID %>').getElementsByTagName('input');
            for (var i = 0; i < checkboxCollection.length; i++) {
                if (checkboxCollection[i].type.toString().toLowerCase() == "checkbox") {
                    checkboxCollection[i].checked = obj1.checked;
                }
            }
        }
        function Uncheck() {
            var count=0;            
            var checkboxCollection1 = document.getElementById('<%=CheckVerticals.ClientID %>').getElementsByTagName('input');
            for (var i = 0; i < checkboxCollection1.length; i++) {
                if (checkboxCollection1[i].checked == false) {
                    document.getElementById('<%=CheckVerticalAll.ClientID %>').checked = false;
                }
                else
                    count++;
            }
            if (checkboxCollection1.length == count)
                document.getElementById('<%=CheckVerticalAll.ClientID %>').checked = true;
        }
        function Changehdn() {
            var verticals = "";
            var checkboxCollection = document.getElementById('<%=CheckVerticals.ClientID %>').getElementsByTagName('input');
            var cbValues = document.getElementById('<%=CheckVerticals.ClientID %>').getElementsByTagName('span');
            for (var i = 0; i < checkboxCollection.length; i++) {
                if (checkboxCollection[i].checked) {
                    if (verticals == "") {
                        verticals = cbValues[i].attributes["ValueField"].value;
                    }
                    else {
                        verticals = verticals + "," + cbValues[i].attributes["ValueField"].value;
                    }
                }
            }
            document.getElementById('<%=hdnVerticals.ClientID %>').value = verticals;
        }
        function CheckVerticals() {
            var selectedVerticals = document.getElementById('<%=hdnVerticals.ClientID %>').value;
            var count=0;
            if (selectedVerticals != '')
            {
                var checkboxCollection = document.getElementById('<%=CheckVerticals.ClientID %>').getElementsByTagName('input');
                var cbValues = document.getElementById('<%=CheckVerticals.ClientID %>').getElementsByTagName('span');
                for (var i = 0; i < checkboxCollection.length; i++) {
                    if (selectedVerticals.indexOf(cbValues[i].attributes["ValueField"].value) != -1) {
                        checkboxCollection[i].checked = true;
                        count++;
                    }
                }
                 if(checkboxCollection.length == count)
                    document.getElementById('<%=CheckVerticalAll.ClientID %>').checked = true; 
            }
           
        }
    </script>
</asp:Content>
