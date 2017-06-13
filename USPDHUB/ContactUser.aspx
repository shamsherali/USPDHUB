<%@ Page Language="C#" AutoEventWireup="true" Inherits="ContactUser" Codebehind="ContactUser.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
       
        <link href="CSS/wowzzy_general.css" rel="stylesheet" type="text/css" />
        <script type="text/javascript">
            function onpageload() {
                window.moveTo(0, 0)
            }
        </script>
            
        <script type="text/javascript">
            function CheckPhoneOrFax(CID, Vtype) {
                if (CID.value != "") {
                    var no = /^[0-9]\d{2}-\d{3}-\d{4}$/;
                    if (!no.test(CID.value)) {
                        if (Vtype == "1") {
                            alert("Please enter valid phone number.");
                        }
                        window.setTimeout(function () {
                            CID.focus();
                        }, 0);
                    }
                }
            }
        </script>

        <script type="text/javascript">
            function validatetext() {
                if (document.getElementById("<%=txtfirstname.ClientID %>").value == "" && document.getElementById("<%=txtemail.ClientID %>").value == "" && document.getElementById("<%=txtphone.ClientID %>").value == "") {
                    alert("Please enter First name and Phone number or Email address");
                    return false;
                }
                else if (document.getElementById("<%=txtfirstname.ClientID %>").value == "") {
                    alert("Please enter First name");
                    return false;
                }
                if (document.getElementById("<%=txtemail.ClientID %>").value == "" && document.getElementById("<%=txtphone.ClientID %>").value == "") {
                    alert("Please enter Phone number or Email address");
                    return false
                }
                return true;
            }
        </script>

        <script language="javascript" type="text/javascript">
            function MM_openBrWindow(theURL, winName, features) { //v2.0
                window.open(theURL, winName, features);
            }
        </script>
        <script src="<%=Page.ResolveClientUrl("~/Scripts/jquery.js")%>" type="text/javascript"></script>
        <script type="text/javascript">
            $(function () {
                $('#txtphone').keyup(function (event) {
                    // Allow: backspace, delete, tab, escape, and enter // Allow: home, end, left, right
                    if (event.keyCode == 46 || event.keyCode == 8 || event.keyCode == 9 || event.keyCode == 27 || event.keyCode == 13 ||
                (event.keyCode >= 35 && event.keyCode <= 39)) {
                        return;
                    }
                    else {
                        // Ensure that it is a number and stop the keypress
                        if (event.shiftKey || (event.keyCode < 48 || event.keyCode > 57) && (event.keyCode < 96 || event.keyCode > 105)) {
                            event.preventDefault();
                        }
                    }
                    var val = this.value.replace(/\D/g, '');
                    var newVal = '';
                    if (val.length > 10) {
                        val = val.substring(0, 10)
                    }
                    while (val.length >= 3 && newVal.length <= 7) {
                        newVal += val.substr(0, 3) + '-';
                        val = val.substr(3);
                    }
                    newVal += val;
                    this.value = newVal;
                });
            });
        
    </script>
    </head>
    <body>
        <form id="form1" runat="server">
            <div>
                <table align="center" width="60%" style="padding: 10px" border="0" cellspacing="0"
                       cellpadding="0">
                    <tr>
                        <td class="valign-top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td style="vertical-align: top">
                                        <img src="<%=Page.ResolveClientUrl("~/Images/OuterImages/head-left.gif")%>"
                                             width="9" height="28" />
                                    </td>
                                    <td class="new-header">
                                        <strong>Contact Details</strong>
                                    </td>
                                    <td class="new-header align-right">
                                        <a href="#">
                                            <img src="<%=Page.ResolveClientUrl("~/images/OuterImages/close-btn.gif")%>"
                                                 width="18" height="18" border="0" onclick="Javascript:window.close();" alt="Close Window" />
                                        </a>
                                    </td>
                                    <td style="vertical-align: top">
                                        <img src="<%=Page.ResolveClientUrl("~/images/OuterImages/head-right.gif")%>"
                                             width="9" height="28" />
                                    </td>
                                </tr>
                            </table>
                            <table style="border: solid 1px #5497DE; padding-bottom: 10px; padding-top: 20px;
                                   background-color: #F0F4E2;" width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="padding: 30px;">
                                        <fieldset style="width: 100%">
                                            <legend>Contact Details</legend>
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <asp:Label ID="lblContacts" runat="server" ForeColor="green" Font-Bold="true"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-left: 150px;">
                                                        <table width="100%" style="line-height: 28px;" border="0" cellpadding="0" cellspacing="0">
                                                            <colgroup>
                                                                <col width="20%" />
                                                                <col width="*" />
                                                            </colgroup>
                                                            <tr>
                                                                <td>
                                                                    First Name:
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtfirstname" runat="server" Width="200px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    Last Name:
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtlastname" runat="server" Width="200px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    Address:
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtaddress" runat="server" Width="200px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    Contact Email:
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtemail" runat="server" Width="200px"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="emailRegVal" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                                                    ControlToValidate="txtemail" ErrorMessage="Enter Valid Email Address" runat="server">*</asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="top">
                                                                    Phone Number:
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtphone" runat="server" Width="200px"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtphone"
                                                                                                    ErrorMessage="Enter Valid Phone Number" ValidationExpression="^[0-9]\d{2}-\d{3}-\d{4}$">
                                                                    </asp:RegularExpressionValidator><br />(XXX-XXX-XXXX)
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="top">
                                                                    Message:
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtdescription" runat="server" Height="50px" Width="350px" TextMode="MultiLine"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="padding-bottom: 10px; padding-top: 10px">
                                                        <asp:Button ID="btnAddDetails" runat="server" Text="Submit" OnClick="btnAddDetails_OnClick" OnClientClick="return validatetext()" />
                                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_OnClick"
                                                                    CausesValidation="false" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </fieldset>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </form>
    </body>
</html>
