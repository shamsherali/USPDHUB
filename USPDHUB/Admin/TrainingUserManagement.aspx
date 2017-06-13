<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/AdminHome.master"
    CodeBehind="TrainingUserManagement.aspx.cs" Inherits="USPDHUB.Admin.TrainingUserManagement" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <link href="../css/reveal.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery.js" type="text/javascript"></script>
    <asp:ScriptManager ID="smgr1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
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
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="page-padding">
                <tr>
                    <td style="padding-left: 6px;" valign="top">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="page-title">
                            <tr>
                                <td>
                                    Training Users Management
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center;">
                                    <asp:Label ID="lblSuccess" runat="server" ForeColor="Green"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <%--<td>
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
                        </td>-
                         <td style="padding-right: 5px;">
                            <asp:Button ID="Button1" runat="server" Text="Export To Excel" OnClick="btn_ExporttoExcel_Click" />
                        </td>--%>
                                <td style="text-align: right; padding-right: 40px;">
                                    <asp:Button ID="BtnAdd" runat="server" OnClick="BtnAdd_Click" Text="Add New Training User"
                                        CausesValidation="false" />
                                </td>
                            </tr>
                        </table>
                        <br />
                        <div style="overflow: scroll; width: 880px; height: 500px;">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="admin-padding inputgrid">
                                <tr>
                                    <td valign="top">
                                        <asp:GridView ID="TrainingUsersGrid" runat="server" AutoGenerateColumns="False" DataKeyNames="User_ID"
                                            CssClass="datagrid2" OnRowDeleting="TrainingUsersGrid_RowDeleting" OnRowDataBound="TrainingUsersGrid_RowDataBound"
                                            AllowPaging="True" OnPageIndexChanging="TrainingUsersGrid_PageIndexChanging"
                                            Width="100%" OnSelectedIndexChanging="TrainingUsersGrid_SelectedIndexChanging"
                                            PageSize="10">
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
                                                <asp:TemplateField HeaderText="Agency Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblcompanyname" runat="server"></asp:Label>
                                                        <%--  <asp:LinkButton ID="lbtnpname" runat="server" OnClick="lbtnpname_Click"></asp:LinkButton>--%>
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
                                                <asp:TemplateField HeaderText="Role Name">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("Role_ID") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label7" runat="server" Text='<%# GetRoleName((int)DataBinder.Eval(Container.DataItem, "Role_ID")) %>'></asp:Label>
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
                                                <%-- <asp:TemplateField HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="deleteButton" runat="server" CommandName="Delete" Text="&lt;img src='http://www.uspdhub.com/Images/icon_delete.gif' alt='Delete' title='Delete' border='0'/&gt;"
                                                            CommandArgument='<%#DataBinder.Eval(Container.DataItem,"User_ID") %>' OnClientClick="return confirm('Are you sure you want to delete this user?');" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
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
            <br />
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td class="align-left">
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="DeleteUsersRecord"
                            OnClientClick="return confirmDelete (this.form)" />
                        <asp:Button ID="btn_Dashboard" runat="server" OnClick="btn_goDashboard" Text="Go To Dashboard" />
                    </td>
                    <%--  <td class="align-right">
                                            <asp:Button ID="btn_ExporttoExcel" runat="server" Text="Export To Excel" OnClick="btn_ExporttoExcel_Click" />
                                        </td>--%>
                </tr>
                <%--<tr>
                                            <td style="padding-top: 10px;">
                                                <div id="divError">
                                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Search Validations Errors . Please correct and re-try  :"
                                                        ValidationGroup="SearchValidationGroup" />
                                                </div>
                                            </td>
                                        </tr>--%>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Label ID="lblcreateshortcut" runat="server"></asp:Label>
            <cc1:ModalPopupExtender ID="popcreateshortcut" runat="server" TargetControlID="lblcreateshortcut"
                PopupControlID="pnlcreateshortcut" BackgroundCssClass="modal" BehaviorID="createshortcut"
                CancelControlID="imgclse">
            </cc1:ModalPopupExtender>
            <asp:Panel ID="pnlcreateshortcut" runat="server" Style="display: none" Width="600px">
                <div class="reveal-modal">
                    <div class="clear15">
                    </div>
                    <div>
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td align="left" style="color: Green; font-size: 14px; font-family: Arial; font-weight: bold;">
                                    Create Training User
                                </td>
                                <td align="right" style="padding: 5px 10px 0px 10px;">
                                    <asp:ImageButton ID="imgclse" runat="server" ImageUrl="~/images/admin/close.png"
                                        CausesValidation="false" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="adminformwrap">
                        <div class="clear10">
                        </div>
                        <div style="text-align: center;">
                            <asp:UpdateProgress ID="UpdateProgress6" runat="server" DisplayAfter="3">
                                <ProgressTemplate>
                                    <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </div>
                        <div class="clear15">
                        </div>
                        <div>
                            <asp:ValidationSummary ID="ValidateUserDetails" runat="server" ValidationGroup="A"
                                HeaderText="The following error(s) occurred:" CssClass="errormsg_text" />
                        </div>
                        <div class="clear10">
                        </div>
                        <div class="labeladm">
                            <span class="errormsgadm">*</span>Agency Name:</div>
                        <div class="txtfildwrapadm">
                            <asp:TextBox ID="txtAgencyName" TabIndex="1" runat="server" MaxLength="50" class="txtfildadm">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAgencyName"
                                ErrorMessage="Agency Name is mandatory" SetFocusOnError="True" Display="Dynamic"
                                ValidationGroup="A">*
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtAgencyName"
                                ErrorMessage="Enter Valid Agency Name." SetFocusOnError="True" ValidationExpression="^(a-z|A-Z|0-9)*[^#$%^&*()']*$"
                                ValidationGroup="A">*
                            </asp:RegularExpressionValidator></div>
                        <div class="clear10">
                        </div>
                        <div class="labeladm">
                            <span class="errormsgadm">*</span>Contact Person:</div>
                        <div class="txtfildwrapadm">
                            <asp:TextBox ID="txtContactPerson" TabIndex="2" runat="server" MaxLength="50" class="txtfildadm">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtContactPerson"
                                ErrorMessage="Contact Person is mandatory." SetFocusOnError="True" Display="Dynamic"
                                ValidationGroup="A">*
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtContactPerson"
                                ErrorMessage="Enter Valid Contact Person." SetFocusOnError="True" ValidationExpression="^(a-z|A-Z|0-9)*[^#$%^&*()']*$"
                                ValidationGroup="A">*
                            </asp:RegularExpressionValidator></div>
                        <div class="clear10">
                        </div>
                        <div class="labeladm">
                            <span class="errormsgadm">*</span>Phone Number:</div>
                        <div class="txtfildwrapadm">
                            <cc1:TextBoxWatermarkExtender ID="MaskedEditExtender1" TargetControlID="txtphonenumber"
                                WatermarkText="xxx-xxx-xxxx" runat="server" WatermarkCssClass="txtfildadm">
                            </cc1:TextBoxWatermarkExtender>
                            <asp:TextBox ID="txtphonenumber" TabIndex="3" runat="server" MaxLength="14" class="txtfildadm">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtphonenumber"
                                ErrorMessage="Phone Number is mandatory." Font-Size="14px" ValidationGroup="A"
                                SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtphonenumber"
                                ErrorMessage="Enter Valid Phone Number." ValidationExpression="^[0-9]\d{2}-\d{3}-\d{4}$"
                                SetFocusOnError="True" Font-Size="14px" ValidationGroup="A">*
                            </asp:RegularExpressionValidator></div>
                        <div class="clear10">
                        </div>
                        <div class="labeladm">
                            <span class="errormsgadm">*</span>Username:</div>
                        <div class="txtfildwrapadm">
                            <asp:TextBox ID="txtEmail" TabIndex="4" runat="server" class="txtfildadm" AutoCompleteType="Disabled"
                                onblur="return ServerSidefill(this.id);"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtEmail"
                                ErrorMessage="Username is mandatory." Font-Size="14px" Display="Dynamic" SetFocusOnError="True"
                                ValidationGroup="A">*
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtEmail"
                                Font-Size="14px" ErrorMessage="Invalid Username format." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                ValidationGroup="A" SetFocusOnError="True">*
                            </asp:RegularExpressionValidator>
                        </div>
                        <div class="clear10">
                        </div>
                        <div class="labeladm">
                        </div>
                        <div class="txtfildwraps">
                            <div style="display: none;" id="Progress" class="CheckUsername">
                                <img src='../images/popup_ajax-loader.gif' /><b><font color="green">Processing....</font></b></div>
                            <asp:Label ID="lblUserNameCheck" runat="server" Font-Size="14px" Font-Names="arial"
                                ForeColor="green"></asp:Label>
                        </div>
                        <div class="clear10">
                        </div>
                        <div class="labeladm">
                            <span class="errormsgadm">*</span>Agency Address:</div>
                        <div class="txtfildwrapadm">
                            <asp:TextBox ID="txtAgencyAddress" TabIndex="5" runat="server" MaxLength="200" class="txtfildadm">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtAgencyAddress"
                                ErrorMessage="Agency Address is mandatory." Font-Size="14px" ValidationGroup="A"
                                SetFocusOnError="True">*</asp:RequiredFieldValidator></div>
                        <div class="clear10">
                        </div>
                        <div class="labeladm">
                            <span class="errormsgadm">*</span>City:</div>
                        <div class="txtfildwrapadm">
                            <asp:TextBox ID="txtCity" TabIndex="6" runat="server" MaxLength="100" class="txtfildadm">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtCity"
                                ErrorMessage="City is mandatory." Font-Size="14px" ValidationGroup="A" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtCity"
                                ErrorMessage="Enter Valid City." ValidationExpression="^[a-zA-Z ]+$" SetFocusOnError="True"
                                Font-Size="14px" ValidationGroup="A">*
                            </asp:RegularExpressionValidator></div>
                        <div class="clear10">
                        </div>
                        <div class="labeladm">
                            <span class="errormsgadm">*</span>State:</div>
                        <div class="txtfildwrapadm">
                            <asp:TextBox ID="txtState" TabIndex="7" runat="server" MaxLength="50" class="txtfildadm">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtState"
                                ErrorMessage="State is mandatory." Font-Size="14px" ValidationGroup="A" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtState"
                                ErrorMessage="Enter Valid State." ValidationExpression="^[a-zA-Z]+$" SetFocusOnError="True"
                                Font-Size="14px" ValidationGroup="A">*
                            </asp:RegularExpressionValidator></div>
                        <div class="clear10">
                        </div>
                        <div class="labeladm">
                            <span class="errormsgadm">*</span>ZipCode:</div>
                        <div class="txtfildwrapadm">
                            <asp:TextBox ID="txtZipCode" TabIndex="8" runat="server" MaxLength="50" class="txtfildadm">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtZipCode"
                                ErrorMessage="ZipCode is mandatory" Font-Size="14px" ValidationGroup="A" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtZipCode"
                                ErrorMessage="Enter Valid ZipCode." ValidationExpression="^[0-9]+$" SetFocusOnError="True"
                                Font-Size="14px" ValidationGroup="A">*
                            </asp:RegularExpressionValidator></div>
                        <div class="clear10">
                        </div>
                        <div class="labeladm">
                            &nbsp;Vertical:</div>
                        <div class="txtfildwrapadm">
                            <asp:DropDownList ID="ddlVertical" runat="server" CssClass="ddlfildadm">
                            </asp:DropDownList>
                        </div>
                        <div class="clear10">
                        </div>
                    </div>
                    <div class="clear41">
                    </div>
                    <div class="submitadm">
                        <asp:ImageButton ID="btnBack" runat="server" ImageUrl="~/images/Admin/cancel.png"
                            CausesValidation="false" TabIndex="9" />
                        <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/images/Admin/save.png" CausesValidation="true"
                            TabIndex="10" ValidationGroup="A" OnClick="btnSave_Click" />
                    </div>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
        function ShortCut() {
            var modalDialog = $find("createshortcut");
            var iframe = document.getElementById('frmShortcut');
            var labelid = document.getElementById('<%=lblSuccess.ClientID%>');
            var labelid1 = document.getElementById('<%=lblUserNameCheck.ClientID%>');
            labelid.value = "";
            labelid1.value = "";
            modalDialog.show();
            return false;
        }
    </script>
    <script type="text/javascript">
        var divstyle = new String();
        function ServerSidefill(id) {
            if (document.getElementById('<%=txtEmail.ClientID%>').value.replace(/ /g, '') != '') {
                divstyle = document.getElementById("Progress").style.visibility;
                if (divstyle.toLowerCase() == "none" || divstyle == "") {
                    document.getElementById("Progress").style.display = "block";
                }
                else {
                    document.getElementById("Progress").style.display = "none";
                }


                var idvalue = '';
                idvalue = $get(id).value;
                if (idvalue != '') {
                    var typeval = PageMethods.ServerSidefill(idvalue, OnSuccess, OnFailure);
                }
            }
        }
        function OnSuccess(result) {
            if (result == '1') {
                $get('<%=lblUserNameCheck.ClientID %>').innerHTML = '<font color=green>Email address is available.</font>';
                if (divstyle.toLowerCase() == "none" || divstyle == "") {
                    document.getElementById("Progress").style.display = "none";
                }
                else {
                    document.getElementById("Progress").style.display = "none";
                }
            }
            if (result == '2') {
                $get('<%=lblUserNameCheck.ClientID %>').innerHTML = '<font color=red>Email address is already in use, please use a different one.</font>';
                $get('<%=txtEmail.ClientID %>').focus();
                if (divstyle.toLowerCase() == "none" || divstyle == "") {
                    document.getElementById("Progress").style.display = "none";
                }
                else {
                    document.getElementById("Progress").style.display = "none";
                }
            }
            if (result == '3') {
                $get('<%=lblUserNameCheck.ClientID %>').innerHTML = '<font color=red>Please enter a valid Email Address.</font>';
                $get('<%=txtEmail.ClientID %>').focus();
                if (divstyle.toLowerCase() == "none" || divstyle == "") {
                    document.getElementById("Progress").style.display = "none";
                }
                else {
                    document.getElementById("Progress").style.display = "none";
                }
            }
            if (result == '4') {
                $get('<%=lblUserNameCheck.ClientID %>').innerHTML = '<font color=red>Email address is already associated with another user.</font>';
                $get('<%=txtEmail.ClientID %>').focus();
                if (divstyle.toLowerCase() == "none" || divstyle == "") {
                    document.getElementById("Progress").style.display = "none";
                }
                else {
                    document.getElementById("Progress").style.display = "none";
                }
            }
        }
        function OnFailure(result) {
            $get('<%=lblUserNameCheck.ClientID %>').innerHTML = '<font color=red>An error occured.</font>';
            if (divstyle.toLowerCase() == "none" || divstyle == "") {
                document.getElementById("Progress").style.display = "none";
            }
            else {
                document.getElementById("Progress").style.display = "none";
            }
        }
    </script>
</asp:Content>
