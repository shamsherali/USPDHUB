<%@ Page Title="" Language="C#" MasterPageFile="~/AdminHome.master" AutoEventWireup="true"
    CodeBehind="ConsumerManagement.aspx.cs" Inherits="USPDHUB.Admin.ConsumerManagement" %>

<%@ Register Src="../Controls/Sitemaplinks.ascx" TagName="Sitemaplinks" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <style type="text/css">
        .realusers
        {
            background-color: #AFC7C7;
            font-weight: bold;
        }
    </style>
    <script type="text/javascript">
        function confirmDelete(frm, type) {
            // loop through all elements
            for (i = 0; i < frm.length; i++) {
                // Look for our checkboxes only
                if (frm.elements[i].name.indexOf("CheckBox1") != -1) {
                    // If any are checked then confirm alert, otherwise nothing happens
                    if (frm.elements[i].checked) {
                        if (type == 1) // *** deleting *** //
                            return confirm('Are you sure you want to delete your selection(s)?');
                        else if (type == 2) // *** Mark Demo users *** //
                            return confirm('Are you sure you want to mark the selected user(s) as demo user(s)?');
                        else// *** Mark Real users *** //
                            return confirm('Are you sure you want to mark the selected user(s) as real user(s)?');
                    }
                }
            }
            if (type == 1)
                alert('Please select at least one checkbox to delete.');
            else if (type == 2)
                alert('Please select at least one checkbox to mark demo users.');
            else if (type == 3)
                alert('Please select at least one checkbox to mark real users.');

            return false
        }
    </script>
    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="page-padding">
        <tr>
            <td style="padding-left: 6px;" valign="top">
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <%-- <uc3:wowmap id="sitemaplinks" runat="server" />--%>
                        </td>
                    </tr>
                </table>
                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="page-title">
                    <tr>
                        <td>
                            Users Management
                        </td>
                        <td>
                            <asp:Label ID="lblerr" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table border="0" cellpadding="0" cellspacing="0" width="100%" style="padding: 10px 35px 20px 0px;">
                    <tr>
                        <td style="width: 200px;" align="right">
                            <asp:Button ID="btnArchive" runat="server" Text="Mark Demo Users" OnClick="btnArchive_Click"
                                OnClientClick="return confirmDelete (this.form, 2)" />
                            &nbsp;&nbsp;&nbsp;<asp:Button ID="btnRealUsers" runat="server" Text="Mark Real Users"
                                OnClick="btnRealUsers_Click" OnClientClick="return confirmDelete (this.form, 3)" />
                            &nbsp;&nbsp;&nbsp;<asp:Button ID="btnTestUsers" runat="server" Text="Go To Test User Management"
                                OnClick="btnTestUsers_Click" />
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
                            <asp:DropDownList runat="server" ID="ddlVerticals" Height="16px">
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
                                <asp:Label runat="server" Text="&nbsp;" Style="background-color: #AFC7C7;" Width="25px"></asp:Label>
                                <asp:Label Text="- Colored rows are real users." runat="server" Style="font-weight: bold;"></asp:Label>
                                <asp:GridView ID="ConsumersGrid" Style="margin-top: 5px;" runat="server" AutoGenerateColumns="False"
                                    DataKeyNames="User_ID" CssClass="datagrid2" OnRowEditing="ConsumersGrid_RowEditing"
                                    OnRowDeleting="ConsumersGrid_RowDeleting" OnRowCancelingEdit="ConsumersGrid_RowCancelingEdit"
                                    OnRowDataBound="ConsumersGrid_RowDataBound" AllowPaging="True" OnPageIndexChanging="ConsumersGrid_PageIndexChanging"
                                    Width="100%" OnSelectedIndexChanging="ConsumersGrid_SelectedIndexChanging" PageSize="50">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Select">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="CheckBox1" runat="server" />
                                            </ItemTemplate>
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
                                                <asp:Label ID="lblIsArchived" runat="server" Text='<%# Bind("IsArchived") %>' Visible="false"></asp:Label>
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
                                        <%--<asp:TemplateField HeaderText="Role Name">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("Role_ID") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label7" runat="server" Text='<%# GetRoleName((int)DataBinder.Eval(Container.DataItem, "Role_ID")) %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="150px" />
                                        </asp:TemplateField>--%>
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
                                                    OnClientClick="return confirm('Are you sure you want to delete this user?');"
                                                    OnClick="deleteButton_Click" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkTestAc" runat="server" OnClick="lnkTestAc_Click" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"User_ID") %>'
                                                    Text="&lt;img src='../Images/user_type.png' alt='Make Test User' title='Make Test User' border='0'/&gt;"
                                                    OnClientClick="return confirm('Are you sure you want to make this user as test user?');"></asp:LinkButton>
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
                                                OnClientClick="return confirmDelete (this.form, 1)" />
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
                <asp:TemplateField HeaderText="Demo" Visible="true">
                    <ItemTemplate>
                        <asp:Label ID="lblDemo" runat="server" Text='<%# (Convert.ToBoolean(Eval("IsArchived"))?"Yes":"No") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
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
                <asp:TemplateField HeaderText="Role Name">
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%# GetRoleName((int)DataBinder.Eval(Container.DataItem, "Role_ID")) %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="150px" />
                </asp:TemplateField>
                <asp:BoundField DataField="CREATED_DT" HeaderText="Created Date" DataFormatString="{0:MM/dd/yyyy}">
                </asp:BoundField>
                <asp:BoundField HeaderText="Status" DataField="User_Status" />
            </Columns>
        </asp:GridView>
    </asp:Panel>
</asp:Content>
