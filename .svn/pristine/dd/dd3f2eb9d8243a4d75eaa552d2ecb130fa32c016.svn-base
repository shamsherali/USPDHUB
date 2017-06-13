<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="USPDHUB.Register" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <title>Register</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="css/register.css" rel="stylesheet" type="text/css">
    <link href="css/responsive.css" rel="stylesheet" type="text/css">
    <script src="<%=Page.ResolveClientUrl("~/Scripts/jquery.js")%>" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="Scr1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container">
                <header>
                    <div class="logo"><img src="<%=LogoName%>"/></div>
                    <div class="reginal-events"><%--<img src="images/regionalevents.png" width="180" height="25" title="">--%></div>
                </header>
                <div class="clearfix">
                </div>
                <div class="strips-wrapper">
                    <div class="strip1">
                    </div>
                    <div class="strip2">
                    </div>
                    <div class="strip3">
                    </div>
                    <div class="strip4">
                    </div>
                </div>
                <div class="heading-section">
                    <h1>
                        <asp:Label ID="lblWebnairTitle" runat="server"></asp:Label>
                    </h1>
                </div>
                <div class="content-section">
                    <div class="left-cont-section">
                        <asp:Label ID="lblDescription" runat="server"></asp:Label>
                    </div>
                    <div class="devide-section">
                        <img class="devide-image" src="images/vert-line.png" alt=""></div>
                    <div id="contact-area" class="form-section">
                        <asp:Panel ID="pnlForm" runat="server">
                            <div style="text-align: center">
                                <asp:Label ID="lblMessage" runat="server"></asp:Label>
                                <div style="width: 65%; margin: 0 auto; text-align: left; line-height: 20px;">
                                    <asp:ValidationSummary ID="ValidateUserDetails" runat="server" ValidationGroup="A"
                                        HeaderText="The following error(s) occurred:" CssClass="errormsg_text" />
                                </div>
                            </div>
                            <label for="Name">
                                First Name: <span>*</span></label>
                            <asp:TextBox ID="txtFN" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFFirst" runat="server" ControlToValidate="txtFN"
                                ErrorMessage="First Name is mandatory." Font-Size="14px" ValidationGroup="A"
                                SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="REFirst" runat="server" ControlToValidate="txtFN"
                                ErrorMessage="Enter Valid Name of First Name." SetFocusOnError="True" Font-Size="14px"
                                ValidationExpression="^(a-z|A-Z|0-9)*[^#$%^&*()']*$" ValidationGroup="A">*
                            </asp:RegularExpressionValidator>
                            <label for="Name">
                                Last Name: <span>&nbsp;</span></label>
                            <asp:TextBox ID="txtLN" runat="server"></asp:TextBox>                            
                            <label for="Name">
                                Email Address: <span>*</span></label>
                            <asp:TextBox ID="txtEmail" runat="server" onblur="return ServerSidefill(this.id);"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFEmail" runat="server" ControlToValidate="txtEmail"
                                ErrorMessage="Email Address is mandatory." Font-Size="14px" ValidationGroup="A"
                                SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="REEmail" runat="server" ControlToValidate="txtEmail"
                                Font-Size="14px" ErrorMessage="Invalid Email format." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                ValidationGroup="A" SetFocusOnError="True">*
                            </asp:RegularExpressionValidator>
                            <div class="txtfildwraps">
                                <div style="float: right;">
                                    <div style="display: none;" id="Progress" class="CheckUsername">
                                        <img src='../../images/popup_ajax-loader.gif' /><b><font color="green">Processing....</font></b></div>
                                    <asp:Label ID="lblUserNameCheck" runat="server" Font-Size="14px" Font-Names="arial"
                                        Width="263px" ForeColor="green" Style="line-height: 14px;"></asp:Label>
                                </div>
                            </div>
                            <label for="Name">
                                Phone Number: <span>&nbsp;</span></label>
                            <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                            <div class="button-area">
                                <asp:LinkButton ID="lnkSubmit" runat="server" Text="Submit" OnClick="lnkSubmit_Click"
                                    CssClass="firefox-button" ValidationGroup="A"></asp:LinkButton>
                                <asp:LinkButton ID="lnkCancel" runat="server" Text="Cancel" OnClick="lnkCancel_Click"
                                    CssClass="firefox-button" CausesValidation="false"></asp:LinkButton><asp:HiddenField
                                        ID="hdnSchId" runat="server" />
                                <br />
                                <br />
                                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="3">
                                    <ProgressTemplate>
                                        <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b></ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="pnlExpired" runat="server" Visible="false">
                            <div>
                                Sorry, this webnair has been expired.
                            </div>
                        </asp:Panel>
                    </div>
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

                var schId=document.getElementById('<%=hdnSchId.ClientID %>').value;
                var idvalue = '';
                idvalue = $get(id).value;
                if (idvalue != '') {
                    var typeval = PageMethods.ServerSidefill(idvalue, schId, OnSuccess, OnFailure);
                }
            }
        }
        function OnSuccess(result) {
            document.getElementById("Progress").style.display = "none";
            if (result == '1') {
                $get('<%=lblUserNameCheck.ClientID %>').innerHTML = '';                
            }
            else if (result == '2') {
                $get('<%=lblUserNameCheck.ClientID %>').innerHTML = '<font color=red>You have already been registered.</font>';
                $get('<%=txtEmail.ClientID %>').focus();               
            }
            else if (result == 'Invalid') {
                $get('<%=lblUserNameCheck.ClientID %>').innerHTML = '<font color=red>Please enter a valid Email Address.</font>';
                $get('<%=txtEmail.ClientID %>').focus();
            }
            else
            {
                $get('<%=lblUserNameCheck.ClientID %>').innerHTML = result;
                $get('<%=txtEmail.ClientID %>').focus();      
            }
        }
        function OnFailure(result) {
            if (result.get_message() != "The server method 'ServerSidefill' failed.") {
                $get('<%=lblUserNameCheck.ClientID %>').innerHTML = '<font color=red>An error occured.</font>';
            }
            document.getElementById("Progress").style.display = "none";
        }

        function Focus(objname, waterMarkText) {
            obj = document.getElementById(objname);
            if (obj.value == waterMarkText) {
                obj.value = "";
            }
        }
        $(function() {
            $('#txtPhone').keyup(function(event) {
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
    </form>
</body>
</html>
