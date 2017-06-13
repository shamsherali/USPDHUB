<%@ Page Title="" Language="C#" MasterPageFile="~/AdminHome.master" AutoEventWireup="true"
    CodeBehind="CreateCSUser.aspx.cs" Inherits="USPDHUB.Admin.CreateCSUser" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <asp:ScriptManager ID="smgr1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <div class="clear15">
                </div>
                <div class="adminpagehead">
                    Create CS User</div>
                <div align="center">
                    <img src="../images/Admin/shadow-title.png" title="USPD HUB" alt="USPD HUB" /></div>
                <div class="clear15">
                </div>
                <div class="adminformwrap">
                    <div class="clear15">
                    </div>
                    <div class="successmsg_text">
                        <asp:Label ID="lblSuccess" runat="server"></asp:Label>
                    </div>
                    <div class="clear15">
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
                    <div class="labeladmenq">
                        <span class="errormsgadm">*</span>First Name:</div>
                    <div class="txtfildwrapadm">
                        <asp:TextBox ID="txtFirstName" TabIndex="1" runat="server" MaxLength="50" class="txtfildadm">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtFirstName"
                            ErrorMessage="First Name is mandatory." SetFocusOnError="True" Display="Dynamic"
                            ValidationGroup="A">*
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtFirstName"
                            ErrorMessage="Enter Valid First Name." SetFocusOnError="True" ValidationExpression="^[a-zA-Z0-9\s]+$"
                            ValidationGroup="A">*
                        </asp:RegularExpressionValidator></div>
                    <div class="clear10">
                    </div>
                    <div class="labeladmenq">
                        <span class="errormsgadm">&nbsp;&nbsp;</span>Last Name:</div>
                    <div class="txtfildwrapadm">
                        <asp:TextBox ID="txtLastName" TabIndex="2" runat="server" MaxLength="50" class="txtfildadm">
                        </asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtLastName"
                            ErrorMessage="Enter Valid Last Name." SetFocusOnError="True" ValidationExpression="^[a-zA-Z0-9\s]+$"
                            ValidationGroup="A">*
                        </asp:RegularExpressionValidator></div>
                    <div class="clear10">
                    </div>
                    <div class="labeladmenq">
                        <span class="errormsgadm">*</span>Username:</div>
                    <div class="txtfildwrapadm">
                        <asp:TextBox ID="txtEmail" TabIndex="3" runat="server" class="txtfildadm" onblur="return ServerSidefill(this.id);"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtEmail"
                            ErrorMessage="Username is mandatory." Font-Size="14px" Display="Dynamic" SetFocusOnError="True"
                            ValidationGroup="A">*
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtEmail"
                            Font-Size="14px" ErrorMessage="Invalid Email format." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            ValidationGroup="A" SetFocusOnError="True">*</asp:RegularExpressionValidator><br />
                    </div>
                    <div class="clear">
                    </div>
                    <div class="txtfildwraps">
                        <div style="float: right;">
                            <div style="display: none;" id="Progress" class="CheckUsername">
                                <img src='../../images/popup_ajax-loader.gif' /><b><font color="green">Processing....</font></b></div>
                            <asp:Label ID="lblUserNameCheck" runat="server" Font-Size="14px" Font-Names="arial"
                                Width="500px" ForeColor="green"></asp:Label>
                        </div>
                    </div>
                    <div class="clear10">
                    </div>
                    <div class="labeladmenq">
                        <span class="errormsgadm">*</span>Password:</div>
                    <div class="txtfildwrapadm">
                        <asp:TextBox ID="txtPassword" TabIndex="4" runat="server" MaxLength="50" class="txtfildadm" TextMode="Password">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPassword"
                            ErrorMessage="Password is mandatory." SetFocusOnError="True" Display="Dynamic"
                            ValidationGroup="A">*
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtPassword"
                            Display="Dynamic" ErrorMessage="Passwords must contain 6 - 15 characters." SetFocusOnError="True"
                            ValidationExpression="^([^ ]).{5,15}$" ValidationGroup="A">*</asp:RegularExpressionValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Special Characters and blank spaces not allowed in Password."
                            Display="Dynamic" ValidationExpression="\w{1,255}" Width="7px" SetFocusOnError="True"
                            ControlToValidate="txtPassword" ValidationGroup="A">*</asp:RegularExpressionValidator></div>
                    <div class="clear10">
                    </div>
                    <div class="labeladmenq">
                    </div>
                    <div class="txtfildwrapadm" style="font-size: 11px;">
                        (Note: Passwords are case sensitive and must contain between 6-15 alpha/numeric
                        characters. Special characters are not allowed.)</div>
                    <div class="clear10">
                    </div>
                    <div class="labeladmenq">
                        <span class="errormsgadm">*</span>Confirm Password:</div>
                    <div class="txtfildwrapadm">
                        <asp:TextBox ID="txtConfirmPwd" TabIndex="5" runat="server" MaxLength="50" class="txtfildadm" onblur="return TextCompare();"
                            TextMode="Password">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtConfirmPwd"
                            ErrorMessage="Confirm Password is mandatory." SetFocusOnError="True" Display="Dynamic"
                            ValidationGroup="A">*
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="Special Characters and blank spaces not allowed in Confirm Password."
                            Display="Dynamic" ValidationExpression="\w{1,255}" Width="7px" SetFocusOnError="True"
                            ControlToValidate="txtConfirmPwd" ValidationGroup="A">*</asp:RegularExpressionValidator></div>
                    <div class="clear10">
                    </div>
                </div>
                <div class="clear41">
                    <center>
                        <asp:Label ID="lblerror" runat="server" ForeColor="Red"></asp:Label>
                    </center>
                </div>
                <div class="clear41">
                </div>
                <div class="submitadm">
                    <asp:Button ID="btnCreate" runat="server" TabIndex="4" ValidationGroup="A" CausesValidation="true"
                        Text="Create" OnClick="btnCreateAdminUser" />
                </div>
                <div class="clear10">
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
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
                document.getElementById("Progress").style.display = "none";
            }
            if (result == '2') {
                $get('<%=lblUserNameCheck.ClientID %>').innerHTML = '<font color=red>Email address is already in use; please use a different one.</font>';
                $get('<%=txtEmail.ClientID %>').focus();
                document.getElementById("Progress").style.display = "none";
            }
            if (result == '3') {
                $get('<%=lblUserNameCheck.ClientID %>').innerHTML = '<font color=red>Please enter a valid Email Address.</font>';
                $get('<%=txtEmail.ClientID %>').focus();
                document.getElementById("Progress").style.display = "none";
            }
        }
        function OnFailure(result) {
            $get('<%=lblUserNameCheck.ClientID %>').innerHTML = '<font color=red>An error occured.</font>';
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
</asp:Content>
