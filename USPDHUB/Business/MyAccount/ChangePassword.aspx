<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin.master" Inherits="Business_MyAccount_ChangePassword"
    CodeBehind="ChangePassword.aspx.cs" %>

<%@ Register Src="~/Controls/Login.ascx" TagName="Login" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/WowAds.ascx" TagName="wowads" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/Sitemaplinks.ascx" TagName="wowmap" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="Server">
    <script type="text/javascript">
        function ValidatePassword(key) {
            var str = key.value;
            var lastchar = str.charAt(str.length - 1);
            //        alert(lastchar);
            var re = /^[a-zA-Z0-9]$/;
            var a = re.test(lastchar)
            if (a == true) {
                return true;
            }
            else {
                var newstr = str.substring(0, str.length - 1);
                key.value = newstr
                return false;
            }

        }
    </script>
    
  
    <asp:UpdatePanel ID="UpCheck" runat="server">
        <ContentTemplate>
            <table width="100%" class="page-top" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="page-padding">
                            <tr>
                                <td class="valign-top">
                                    <uc3:wowmap ID="sitemaplinks" runat="server" />
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="page-title">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblfirstname" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <asp:UpdateProgress ID="UpdateProgress6" runat="server" DisplayAfter="3">
                                                    <ProgressTemplate>
                                                        <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                                    </ProgressTemplate>
                                                </asp:UpdateProgress>
                                                <asp:Label ID="lblstatus" runat="server" ForeColor="green" Font-Bold="true"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td align="center">
                                                <table border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:ValidationSummary ID="ValidateUserDetails" runat="server" Style="text-align: left;"
                                                                ValidationGroup="g" HeaderText="The following error(s) occurred:" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" cellpadding="0">
                                        <tr>
                                            <td align="center">
                                                <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                <div id="divError" class="inputgrid">
                                                    <asp:HiddenField ID="hdn" runat="server" />
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                    <table class="margin-top" cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tr>
                                            <td>
                                                <img height="28" src='<%=Page.ResolveClientUrl("~/Images/Dashboard/head-left.gif")%>'
                                                    width="9" />
                                            </td>
                                            <td class="new-header">
                                                Change Password
                                            </td>
                                            <td>
                                                <img height="28" src='<%=Page.ResolveClientUrl("~/Images/Dashboard/head-right.gif")%>'
                                                    width="9" />
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="profile-input">
                                        <tr>
                                            <td>
                                                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="inputgrid nomargin-bottom">
                                                    <colgroup>
                                                        <col width="130" />
                                                        <col width="140" />
                                                        <col width="20" />
                                                        <col width="140" />
                                                        <col width="*" />
                                                    </colgroup>
                                                    <tr class="row1">
                                                        <td class="lable">
                                                            <asp:Label ID="Lbl_Currentpassword" runat="server" Text="Current Password"></asp:Label>
                                                        </td>
                                                        <td colspan="4">
                                                            <asp:TextBox ID="txtoldpassword" TextMode="Password" runat="server" CssClass="textfield"
                                                                TabIndex="1" Width="120"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtoldpassword"
                                                                ErrorMessage="Current (Temporary) Password is mandatory." ValidationGroup="g">*</asp:RequiredFieldValidator>
                                                            <asp:Label ID="Lbl_Msg_Temporarypassword" runat="server" ForeColor="#C00000" vali></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <%if (Request.QueryString["CPD"] == "ActivateUser")
                                                      {%>
                                                    <tr>
                                                        <td colspan="5">
                                                            <asp:Label ID="Lbl_Msg_Headermessage" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <%} %>
                                                    <tr class="row1">
                                                        <td colspan="5" class="discription" style="color: Red;">
                                                            Note: Passwords are case sensitive and must contain between 6-15 alpha/numeric characters.
                                                            Special characters are not allowed.
                                                        </td>
                                                    </tr>
                                                    <tr class="row2">
                                                        <td class="lable">
                                                            <asp:Label ID="Lbl_ChooseNewPassword" runat="server" Text="Choose New Password"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" TabIndex="2" Width="120"
                                                                MaxLength="15" onkeyup="return ValidatePassword(this);"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 20px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword"
                                                                ErrorMessage="It is mandatory to choose a new password." ValidationGroup="g">*</asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPassword"
                                                                Display="Dynamic" ErrorMessage="Passwords must contain 6 - 15 characters." SetFocusOnError="True"
                                                                ValidationExpression="^([^ ]).{5,15}$" ValidationGroup="g">*</asp:RegularExpressionValidator>
                                                            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                                                                ControlToValidate="txtPassword" ValidationExpression="^[a-zA-Z0-9]*$ " SetFocusOnError="True" ErrorMessage="RegularExpressionValidator">*</asp:RegularExpressionValidator>--%>
                                                        </td>
                                                        <td class="lable" style="padding-left: 20px;">
                                                            <asp:Label ID="Lbl_ReenterNewpassword" runat="server" Text="Re-enter New Password"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <!--Issue No: #104
                                                                 Lavanya
                                                                 05-01-09                   
                                                             -->
                                                            <asp:TextBox ID="txtRePassword" runat="server" class="alpha" CssClass="medium textfield"
                                                                TextMode="Password" TabIndex="3" Width="120" MaxLength="15"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Display="Dynamic"
                                                                ErrorMessage="Re-enter password; it must contain 6 - 15 characters." ControlToValidate="txtPassword"
                                                                SetFocusOnError="True" ValidationExpression="^([^ ]).{5,15}$" ValidationGroup="g">*</asp:RegularExpressionValidator>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtRePassword"
                                                                ErrorMessage="It is mandatory to re-enter new password." ValidationGroup="g">*</asp:RequiredFieldValidator>&nbsp;
                                                            <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="txtPassword"
                                                                ControlToValidate="txtRePassword" ErrorMessage="New password and Confirm password do not match."
                                                                Font-Size="Smaller" ValidationGroup="g">*</asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" cellpadding="2" cellspacing="0" class="profile-btntbl">
                                        <tr>
                                            <td>
                                                <asp:HiddenField ID="hdnVerticalName" runat="server" />
                                                <asp:Button ID="btnUpdate" runat="server" Text="Update" TabIndex="19" OnClick="Update_Password"
                                                    ValidationGroup="g" />
                                                <asp:Button ID="btndashboard1" OnClick="btndashboard1_Click" runat="server" Text="Go to Dashboard"
                                                    CausesValidation="false" />
                                                <%--  <asp:Button ID="btnCancel" runat="server"  Text="Cancel" TabIndex="20" CausesValidation="false" OnClick="btnCancel_Click" />--%>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <script type="text/javascript">
                function displayalert() {
                    if (document.getElementById('<%= hdn.ClientID %>').value == "1") {
                        alert("Your password has been changed successfully. You are now being redirected to your " + document.getElementById('<%= hdnVerticalName.ClientID %>').value + " Dashboard.");
                        location.href = "LandingPage.aspx";
                        /*
                        if (document.getElementById('ctl00_hdnIsLiteVersion').value.toLowerCase() == "true")
                            location.href = "LandingPage.aspx";
                        else {
                            location.href = "Default.aspx?PFlag=1";
                        }
                        */
                    }
                }
            </script>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" Visible="false">
        <ContentTemplate>
            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                <tr>
                    <td>
                        <img height="28" src='../../Images/Dashboard/head-left.gif' width="9" />
                    </td>
                    <td class="new-header">
                        Change Password
                    </td>
                    <!-- Issue No 670, Suresh-->
                    <td>
                        <img height="28" src='../../Images/Dashboard/head-right.gif' width="9" />
                    </td>
                </tr>
            </table>
            <br />
            <div style="color: red;" align="center">
                <asp:Label ID="lblerrormessage" runat="server"></asp:Label></div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
