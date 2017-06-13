<%@ Page Title="" Language="C#" MasterPageFile="~/AdminHome.master" AutoEventWireup="true" CodeBehind="ArchivedUserManagement.aspx.cs" Inherits="USPDHUB.Admin.ArchivedUserManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <script type="text/javascript">
        function confirmDelete(frm) {
            // loop through all elements
            for (i = 0; i < frm.length; i++) {
                // Look for our checkboxes only
                if (frm.elements[i].name.indexOf("CheckBox1") != -1) {
                    // If any are checked then confirm alert, otherwise nothing happens
                    if (frm.elements[i].checked) {
                        return confirm('Are you sure you want to delete your selection(s)?')
                    }
                }
            }
            alert('Please select at least one checkbox to delete');
            return false
        }
    </script>
    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="page-padding">
        <tr>
            <td style="padding-left: 6px;" valign="top">
                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="page-title">
                    <tr>
                        <td>
                           Archived Users Management
                        </td>
                        <td>
                            <asp:Label ID="lblerr" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table border="0" cellpadding="0" cellspacing="0" width="100%" style="padding: 10px 35px 20px 0px;">
                    <tr>
                        <td style="width: 200px;" align="right">
                           <asp:Button ID="btnClientUsers" runat="server" Text="Go To Client User Management"
                                OnClick="btnClientUsers_Click" />&nbsp;&nbsp;&nbsp; <asp:Button ID="btnTestUsers" runat="server" Text="Go To Test User Management" OnClick="btnTestUsers_Click" />
                        </td>
                    </tr>
                </table>
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td colspan="2">
                            <asp:CheckBox ID="chkRealUsers" runat="server" Text="Real Users" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            Vertical&nbsp;&nbsp;
                            <asp:DropDownList runat="server" ID="ddlVerticals">
                            </asp:DropDownList>
                            &nbsp;&nbsp;Country&nbsp;&nbsp;
                            <asp:DropDownList runat="server" ID="ddlCountries">
                                <asp:ListItem Text="-- Select --" Value=""></asp:ListItem>
                                <asp:ListItem Text="United States" Value="United States"></asp:ListItem>
                                <asp:ListItem Text="India" Value="India"></asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;&nbsp;<asp:Button ID="btnFilter" runat="server" Text="Submit" OnClick="btnFilter_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Search Option&nbsp;
                            <asp:DropDownList ID="ddloption" runat="server" Width="126px" OnSelectedIndexChanged="ddloption_SelectedIndexChanged">
                                <asp:ListItem Selected="True">---Select Option---</asp:ListItem>
                                <asp:ListItem>Firstname</asp:ListItem>
                                <asp:ListItem>Lastname</asp:ListItem>
                                <asp:ListItem>Email</asp:ListItem>
                                <asp:ListItem>Business Name</asp:ListItem>
                                <asp:ListItem>Zip code</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp; Search Text&nbsp;
                            <asp:TextBox ID="txtsearch" runat="server" CssClass="textfield" Width="250px" ToolTip="Enter Search Text"></asp:TextBox>
                            <asp:Button ID="btnsearch" runat="server" Text="Search" OnClick="btnsearch_Click"
                                ValidationGroup="SearchValidationGroup" />
                            <asp:RequiredFieldValidator ID="RFV_SearchText" runat="server" ControlToValidate="txtsearch"
                                ErrorMessage="Search Text Can not be blank" ToolTip="Search Text Can not be blank"
                                ValidationGroup="SearchValidationGroup">*
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="TextREValidator" runat="server" ControlToValidate="txtsearch"
                                ErrorMessage="Enter Name" ValidationExpression="^[a-zA-Z0-9''-'\s]{1,40}$" ToolTip="Enter valid text"
                                ValidationGroup="SearchValidationGroup">*
                            </asp:RegularExpressionValidator>
                            <asp:RegularExpressionValidator ID="EmailREValidator" runat="server" ControlToValidate="txtsearch"
                                ErrorMessage="Invaild Email " ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                ToolTip="Invaild Email " ValidationGroup="SearchValidationGroup">*
                            </asp:RegularExpressionValidator>
                        </td>
                        <td style="padding-right: 5px;">
                            <asp:Button ID="Button1" runat="server" Text="Export To Excel" OnClick="btn_ExporttoExcel_Click" />
                        </td>
                    </tr>
                </table>
                <div style="overflow: scroll; width: 880px; height: 500px;">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="admin-padding inputgrid">
                        <tr>
                            <td valign="top">
                                <asp:GridView ID="ConsumersGrid" runat="server" AutoGenerateColumns="False" DataKeyNames="User_ID"
                                    CssClass="datagrid2" OnRowEditing="ConsumersGrid_RowEditing" OnRowDeleting="ConsumersGrid_RowDeleting"
                                    OnRowCancelingEdit="ConsumersGrid_RowCancelingEdit" OnRowDataBound="ConsumersGrid_RowDataBound"
                                    AllowPaging="True" OnPageIndexChanging="ConsumersGrid_PageIndexChanging" Width="100%"
                                    OnSelectedIndexChanging="ConsumersGrid_SelectedIndexChanging" PageSize="50">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Select">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="CheckBox1" runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle Width="50px" CssClass="align-center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="User ID">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox1" Width="60px" ReadOnly="true" runat="server" Text='<%# Bind("User_ID") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemStyle Width="60px" />
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("User_ID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="First Name">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox2" Width="100px" runat="server" Text='<%# Bind("Firstname") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemStyle Width="100px" />
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("Firstname") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Last Name">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox3" Width="100px" runat="server" Text='<%# Bind("Lastname") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemStyle Width="100px" />
                                            <ItemTemplate>
                                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("Lastname") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Profile Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblcompanyname" runat="server"></asp:Label>
                                                <asp:LinkButton ID="lbtnpname" runat="server" OnClick="lbtnpname_Click"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Branded App">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBrandedApp" runat="server" Text='<%# Bind("Branded_App") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="User Name">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox4" runat="server" Width="160px" Text='<%# Bind("Username") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemStyle Width="200px" />
                                            <ItemTemplate>
                                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("Username") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="User_email" HeaderText="Email">
                                            <ItemStyle Width="200px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="User_zipcode" HeaderText="Zipcode">
                                            <ItemStyle Width="180px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="User_phone" HeaderText="Phone Number"></asp:BoundField>
                                        <asp:TemplateField HeaderText="Account Type">
                                            <ItemTemplate>
                                                <asp:Label ID="lbltype" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%-- Changed Label7 to lblRole--%>
                                        <asp:TemplateField HeaderText="Role Name" Visible="false">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("Role_ID") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblRole" runat="server" Text='<%# GetRoleName((int)DataBinder.Eval(Container.DataItem, "Role_ID")) %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="150px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="IsFree" Visible="false">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtFreeAcc" runat="server" Width="160px" Text='<%# Bind("IsFree") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemStyle Width="200px" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblFreeAcc" runat="server" Text='<%# Bind("IsFree") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <%-- suneel --%>
                                        <asp:TemplateField HeaderText="Vertical">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("Vertical") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label7" runat="server" Text='<%# Bind("Vertical") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="150px" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="CREATED_DT" HeaderText="Created Date"></asp:BoundField>
                                        <asp:TemplateField HeaderText="Status">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox6" runat="server" ReadOnly="true" Width="50px" Text='<%# Bind("User_Status") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemStyle Width="70px" />
                                            <ItemTemplate>
                                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("User_Status") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:CommandField ShowSelectButton="True" SelectText="&lt;img src='../Images/icon_modify.gif' alt='Edit' title='Edit' border='0'/&gt;">
                                            <ItemStyle CssClass="align-center" Width="25px" />
                                        </asp:CommandField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="deleteButton" runat="server" CommandName="Delete" Text="&lt;img src='../Images/icon_delete.gif' alt='Delete' title='Delete' border='0'/&gt;"
                                                    OnClientClick="return confirm('Are you sure you want to delete this user?');" OnClick="deleteButton_Click"/>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle CssClass="title" />
                                    <EmptyDataTemplate>
                                        No data Found
                                    </EmptyDataTemplate>
                                    <EmptyDataRowStyle ForeColor="#C00000" />
                                </asp:GridView>
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td class="align-left">
                                            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="DeleteUsersRecord"
                                                OnClientClick="return confirmDelete (this.form)" />
                                            <asp:Button ID="btn_Dashboard" runat="server" OnClick="btn_goDashboard" Text="Go To Dashboard" />
                                        </td>
                                        <td class="align-right">
                                            <asp:Button ID="btn_ExporttoExcel" runat="server" Text="Export To Excel" OnClick="btn_ExporttoExcel_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding-top: 10px;">
                                            <div id="divError">
                                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Search Validations Errors . Please correct and re-try  :"
                                                    ValidationGroup="SearchValidationGroup" />
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    <asp:Panel ID="pnlexportexcel" runat="server" Visible="false">
        <asp:GridView ID="grdExportexcel" runat="server" AutoGenerateColumns="False" DataKeyNames="User_ID"
            OnRowDataBound="grdExportexcel_RowDataBound">
            <Columns>
                <asp:BoundField HeaderText="User ID" DataField="User_ID" />
                <asp:BoundField HeaderText="First Name" DataField="Firstname" />
                <asp:BoundField HeaderText="Last Name" DataField="Lastname" />
                <asp:TemplateField HeaderText="Profile Name">
                    <ItemTemplate>
                        <asp:Label ID="lblcompanyname" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="User Name" DataField="Username" />
                <asp:BoundField DataField="User_email" HeaderText="Email">
                    <ItemStyle Width="200px" />
                </asp:BoundField>
                <asp:BoundField DataField="User_phone" HeaderText="Phone Number"></asp:BoundField>
                <asp:TemplateField HeaderText="Account Type">
                    <ItemTemplate>
                        <asp:Label ID="lbltype" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <%-- Changed Label7 to lblRole--%>
                <asp:TemplateField HeaderText="Role Name">
                    <ItemTemplate>
                        <asp:Label ID="lblRole" runat="server" Text='<%# GetRoleName((int)DataBinder.Eval(Container.DataItem, "Role_ID")) %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="150px" />
                </asp:TemplateField>
                <%-- suneel --%>
                <asp:BoundField DataField="CREATED_DT" HeaderText="Created Date" DataFormatString="{0:MM/dd/yyyy}">
                </asp:BoundField>
                <asp:BoundField HeaderText="Status" DataField="User_Status" />
            </Columns>
        </asp:GridView>
    </asp:Panel>
</asp:Content>
