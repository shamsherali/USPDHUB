<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" Inherits="Business_MyAccount_AssociateLogin"
    EnableEventValidation="false" ValidateRequest="false" CodeBehind="AssociateLogin.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Sitemaplinks.ascx" TagName="wowmap" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="Server">
    <link rel="stylesheet" type="text/css" media="all" href="../../css/styles.css" />
    <script type="text/javascript">

        function blockChar(id) {
            id.value = filterNum(id.value)
            function filterNum(str) {
                re = /\$|,|@|#|~|`|\%|\*|\^|\/|\&|\(|\)|\+|\=|\[|\-|\_|\]|\[|\}|\{|\;|\:|\'|\"|\ |\<|\>|\?|\||\\|\!|\$|\./g;
                // remove special characters like "$" and "," etc...
                return str.replace(re, "");

            }
        }

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
                var vertical = document.getElementById('<%=hdnVertical.ClientID%>').value;
                var country = document.getElementById('<%=hdnCountry.ClientID%>').value;
                idvalue = $get(id).value;
                if (idvalue != '') {
                    PageMethods.ServerSidefill(idvalue, vertical, country, OnSuccess, OnFailure);
                }
            }
        }
        function OnSuccess(result) {
            if (result == '1') {
                $get('<%=lblUserNameCheck.ClientID %>').innerHTML = '<font color=green face=arial size=2>Email address is available.</font>';
                document.getElementById("Progress").style.display = "none";
            }
            if (result == '2') {
                $get('<%=lblUserNameCheck.ClientID %>').innerHTML = '<font color=red face=arial size=2>Email address is already in use, please use a different one.</font>';
                $get('<%=txtEmail.ClientID %>').focus();
                document.getElementById("Progress").style.display = "none";
            }
            if (result == '3') {
                $get('<%=lblUserNameCheck.ClientID %>').innerHTML = '<font color=red face=arial size=2>Please enter a valid Email Address.</font>';
                $get('<%=txtEmail.ClientID %>').focus();
                document.getElementById("Progress").style.display = "none";
            }
            if (result == '4') {
                $get('<%=lblUserNameCheck.ClientID %>').innerHTML = '<font color=red face=arial size=2>Email address is already associated with you (or) another user.</font>';
                $get('<%=txtEmail.ClientID %>').focus();
                document.getElementById("Progress").style.display = "none";
            }
        }
        function OnFailure(result) {
            $get('<%=lblUserNameCheck.ClientID %>').innerHTML = '<font color=red face=arial size=2>An error occured.</font>';
            document.getElementById("Progress").style.display = "none";
        }
        function Focus(objname, waterMarkText) {
            obj = document.getElementById(objname);
            if (obj.value == waterMarkText) {
                obj.value = "";
            }
        }
    </script>
    <script type="text/javascript">
        function TextCompare() {
            if (document.getElementById('<%=txtPassword.ClientID%>').value != '' && document.getElementById('<%=txtConfirmPwd.ClientID%>').value != '') {
                if (document.getElementById('<%=txtPassword.ClientID%>').value != document.getElementById('<%=txtConfirmPwd.ClientID%>').value) {
                    $get('<%=lblerror.ClientID %>').innerHTML = '<font color=red face=arial size=2>Confirm Password must match Password.</font>';
                    $get('<%=txtConfirmPwd.ClientID %>').focus();
                }
                else {
                    $get('<%=lblerror.ClientID %>').innerHTML = "";
                }
            }
        }
    </script>
    <script type="text/javascript">

        function displayalert() {
            alert("<font color=green face=arial size=2><b>Associate details have been saved successfully. An email has been sent with username and password.</b></font>");
            location.href = "Default.aspx?PFlag=1";
        }

        function ValidatePermissions() {
            if (Page_ClientValidate('g') && Page_IsValid) {
                if (document.getElementById('<%=chkIsSuperAdmin.ClientID%>').checked == false && document.getElementById('<%=hdnIsSuperAdmin.ClientID %>').value == 'True') {
                    return confirm('Are you sure you want to change permissions?');
                }
            }
        }

    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <uc3:wowmap ID="sitemaplinks" runat="server" />
                <tr>
                    <td class="ContactEditInfo">
                        <%if (associateID > 0)
                          { %>Edit Associate <a href="javascript:ModalHelpPopup('Edit Associate Login',157,'');">
                              <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" /></a>
                        <%}
                          else
                          { %>
                        Create Associate <a href="javascript:ModalHelpPopup('Edit Associate Login',154,'');">
                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" /></a>
                        <%} %>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Label ID="lblShowError" runat="server" ForeColor="green"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:ValidationSummary ID="ValidateUserDetails" runat="server" Style="text-align: left;"
                                        ValidationGroup="g" Font-Size="Small" HeaderText="The following error(s) occurred:" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table border="0" cellspacing="5" cellpadding="0" style="padding-left: 250px;">
                <colgroup>
                    <col width="20%" />
                    <col width="*" />
                </colgroup>
                <tr>
                    <td>
                        <label for="emailaddress">
                            First Name:</label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFirstName" TabIndex="2" runat="server" MaxLength="50">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtFirstName"
                            ErrorMessage="First Name is mandatory." SetFocusOnError="True" Display="Dynamic"
                            ValidationGroup="g">*
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtFirstName"
                            ErrorMessage="Enter Valid First Name" SetFocusOnError="True" ValidationExpression="^(a-z|A-Z|0-9)*[^#$%^&*()']*$"
                            ValidationGroup="g">*
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="comments">
                            Last Name:</label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtLastName" TabIndex="3" runat="server" MaxLength="50">
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="comments">
                            Email Address:</label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" TabIndex="4" runat="server" AutoCompleteType="Disabled"
                            onblur="return ServerSidefill(this.id);" tooltipText="Valid email address required. Your email address will be your login ID."></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtEmail"
                            ErrorMessage="Email Address is mandatory." SetFocusOnError="True" Display="Dynamic"
                            ValidationGroup="g">*
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtEmail"
                            ErrorMessage="Invalid Email format" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            ValidationGroup="g">*
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td style="font-size: 11px;">
                        (Login details will be sent to this email address.)
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <div id="Progress" style="display: none;">
                            <img src='<%=Page.ResolveClientUrl("~/images/popup_ajax-loader.gif")%>' /><b><font
                                color="green">Processing....</font></b></div>
                        <asp:UpdateProgress ID="upprogress" runat="server" DisplayAfter="1" AssociatedUpdatePanelID="UpdatePanel1">
                            <ProgressTemplate>
                                <img src='<%=Page.ResolveClientUrl("~/images/popup_ajax-loader.gif")%>' /><b><font
                                    color="green">Processing....</font></b></ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:Label ID="lblUserNameCheck" runat="server" ForeColor="green"></asp:Label>
                        <asp:HiddenField ID="hdnPwd" runat="server"></asp:HiddenField>
                        <asp:HiddenField ID="hdnIsSuperAdmin" runat="server" Value="false" />
                        <asp:HiddenField ID="hdnVertical" runat="server" />
                        <asp:HiddenField ID="hdnCountry" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="comments">
                            Password:</label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPassword" TabIndex="5" runat="server" MaxLength="50" TextMode="Password">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPassword"
                            ErrorMessage="Password is mandatory." SetFocusOnError="True" Display="Dynamic"
                            ValidationGroup="g">*
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtPassword"
                            Display="Dynamic" ErrorMessage="Passwords must contain 6 - 15 characters." SetFocusOnError="True"
                            ValidationExpression="^([^ ]).{5,15}$" ValidationGroup="g">*</asp:RegularExpressionValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Special Characters and blank spaces not allowed in Password."
                            Display="Dynamic" ValidationExpression="\w{1,255}" Width="7px" SetFocusOnError="True"
                            ControlToValidate="txtPassword" ValidationGroup="g">*</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td class="discription" style="font-size: 11px;">
                        (Note: Passwords are case sensitive and must contain between 6-15 alpha/numeric
                        characters. Special characters are not allowed.)
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="comments">
                            Confirm Password:</label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtConfirmPwd" TabIndex="6" runat="server" MaxLength="50" onblur="return TextCompare();"
                            TextMode="Password">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtConfirmPwd"
                            ErrorMessage="Confirm Password is mandatory." SetFocusOnError="True" Display="Dynamic"
                            ValidationGroup="g">*
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Special Characters and blank spaces not allowed in Confirm Password."
                            Display="Dynamic" ValidationExpression="\w{1,255}" Width="7px" SetFocusOnError="True"
                            ControlToValidate="txtConfirmPwd" ValidationGroup="g">*</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr style="display:none;">
                    <td>
                        <label for="comments">
                            Admin - Full Access:</label>
                    </td>
                    <td>
                        <asp:CheckBox ID="chkIsSuperAdmin" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Label ID="lblerror" runat="server" ForeColor="green"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <%if (associateID > 0)
                          { %><asp:LinkButton ID="lnkSubmit" runat="server" Text="Save" OnClientClick="return ValidatePermissions();"
                              OnClick="lnkSubmit_Click" CausesValidation="true" TabIndex="9" ValidationGroup="g"><img src="../../images/Dashboard/update.png" alt="" /></asp:LinkButton>
                        <%}
                          else
                          { %>
                        <asp:LinkButton ID="lnkSave" runat="server" Text="Save" OnClick="lnkSubmit_Click"
                            CausesValidation="true" TabIndex="9" ValidationGroup="g"><img src="../../images/Dashboard/save.png" alt="" /></asp:LinkButton>
                        <%} %>
                        &nbsp;<asp:LinkButton ID="lnkcancel" runat="server" Text="Cancel" CausesValidation="false"
                            TabIndex="10" OnClick="lnkcancel_Click"><img src="../../images/Dashboard/cancel.png" alt="" /></asp:LinkButton>
                    </td>
                </tr>
            </table>
            </tr>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" Visible="false">
        <ContentTemplate>
            <div class="ContactEditInfo">
                <%if (associateID > 0)
                  { %>Edit Associate
                <%}
                  else
                  { %>
                Create Associate
                <%} %>
                <</div>
            <br />
            <div style="color: red;" align="center">
                <asp:Label ID="lblerrormessage" runat="server"></asp:Label>
                <asp:HiddenField runat="server" ID="hdnPermissionType" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
