<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="Controls_popupcontorl" Codebehind="popupcontorl.ascx.cs" %>
<%@ Register Assembly="System.Web.Extensions" Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register TagPrefix="ECalendar" Namespace="ExtendedControls" Assembly="EventCalendar" %>
<%@ Register Assembly="DayPilot" Namespace="DayPilot.Web.Ui" TagPrefix="DayPilot" %>
<%@ Register Assembly="System.Web.Extensions" Namespace="System.Web.UI" TagPrefix="asp" %>
<script type="text/javascript">

    //function disablepop() {

    //}
</script>
<script type="text/javascript">


    function validatereview() {
        if (Page_ClientValidate()) {
            if (document.getElementById("<%=txtreviewerphone.ClientID %>").value == "" && document.getElementById("<%=txtrevieweremail.ClientID %>").value == "") {
                alert("Please enter either phone or email address");
                return false
            }
            else {
                return true;
            }
        }
        else {
            return false;
        }
    }
    function validatephandemail(val) {

        if (val == "1") {
            if (document.getElementById("<%=txtsenderphone.ClientID %>").value == "" && document.getElementById("<%=txtsenderemail.ClientID %>").value == "") {
                document.getElementById("<%=txt.ClientID %>").value = "";
            }
            else {
                document.getElementById("<%=txt.ClientID %>").value = "1";
            }
        }
        if (val == "2") {
            if (document.getElementById("<%=txtreviewerphone.ClientID %>").value == "" && document.getElementById("<%=txtrevieweremail.ClientID %>").value == "") {
                document.getElementById("<%=txt1.ClientID %>").value = "";
            }
            else {
                document.getElementById("<%=txt1.ClientID %>").value = "1";
            }
        }
    }
</script>
<script type="text/javascript">

    function autoIframe() {
        var iframe = document.getElementById("<%=ifrappointments.ClientID %>");
        try {

            var innerDoc = (iframe.contentDocument) ? iframe.contentDocument : iframe.contentWindow.document;
            if (innerDoc.body.offsetHeight) //ns6 syntax
            {
                var Height;
                if (navigator.appName == "Microsoft Internet Explorer") {
                    Height = 42;
                }
                else {
                    var is_chrome = navigator.userAgent.toLowerCase().indexOf('chrome') > -1;
                    if (is_chrome == true) {
                        Height = 32; //Extra height FireFox                
                    }
                    else {
                        Height = 75;
                    }
                }
                iframe.height = innerDoc.body.offsetHeight + Height;
            }
            else if (iframe.Document && iframe.Document.body.scrollHeight) //ie5+ syntax
            {
                iframe.height = iframe.Document.body.scrollHeight;
            }
        }
        catch (err) {
            alert(err.message);
        }
    }

</script>
<table cellspacing="0" cellpadding="0" width="100%" border="0">
    <tr>
        <td align="center">
            <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="3">
                <ProgressTemplate>
                    <img src='<%=System.Configuration.ConfigurationManager.AppSettings.Get("RootPath")%>/images/popup_ajax-loader.gif'
                        border="0"><b><font color="green">Processing....</font></b>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </td>
    </tr>
</table>
<table cellpadding="0" cellspacing="0" border="0" width="100%">
    <tr>
        <td>
            <%--Login Contol Starts--%>
            <asp:Panel ID="PnlLoginControl" runat="server" DefaultButton="btnlogin">
                <table border="0" align="center" cellpadding="0" cellspacing="0" class="popup-tbl">
                    <tr>
                        <td align="right">
                            <%--<asp:ImageButton ID="imglogin" runat="server" ImageUrl="~/images/popup_close.gif"
                                OnClick="imclose_Click" />--%>
                        </td>
                    </tr>
                    <!--Content Changes 18/08/2010 -->
                    <asp:Panel ID="pnlfavlogin" runat="server">
                        <tr>
                            <td class="popuplabel" align="center" style="color: Green; font-size: medium;" nowrap>
                                You must have an USPDhub<sup style="font-size: 14px;">&reg;</sup> to add this
                                to your favorites list.<br />
                            </td>
                        </tr>
                    </asp:Panel>
                    <asp:Panel ID="pnlafflogin" runat="server">
                        <tr>
                            <td class="popuplabel" align="center" style="color: Green; font-size: medium;" nowrap>
                                You must have an USPDhub<sup style="font-size: 14px;">&reg;</sup> to be able
                                to join my network.<br />
                            </td>
                        </tr>
                    </asp:Panel>
                    <asp:Panel ID="pnlapplogin" runat="server">
                        <tr>
                            <td class="popuplabel" align="center">
                                If you would like to schedule an appointment with me, you must be a USPDhub member.<br />
                                USPDhub Members, please sign in below.<br />
                                If you are not a USPDhub member, please sign up.<br />
                            </td>
                        </tr>
                    </asp:Panel>
                    <tr>
                        <td style="padding-left: 175px;">
                            <table border="0" cellspacing="0" cellpadding="0" style="border: 1px solid #7F9DB9;"
                                width="75%">
                                <tr>
                                    <td style="padding-left: 10px;" nowrap>
                                        <strong>Already a member? Login below.</strong>
                                    </td>
                                    <td valign="top">
                                        <strong>Not a member? Sign up below.</strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td class="popuplabel" align="left" valign="top" nowrap>
                                                    Login Name:
                                                </td>
                                                <td style="padding-left: 10px">
                                                    <asp:TextBox ID="email" runat="server" CssClass="textfield" Width="153px" ValidationGroup="logingroup"></asp:TextBox>
                                                    <asp:Label ID="lblusername" runat="server" ForeColor="Red"></asp:Label>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="email"
                                                        runat="server" ErrorMessage="Login Name is mandatory Field." ValidationGroup="logingroup">*</asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="email"
                                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"
                                                        Font-Size="Smaller" SetFocusOnError="True" ValidationGroup="logingroup" ErrorMessage="Invalid Email Format .">*</asp:RegularExpressionValidator>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="popuplabel" align="left" valign="top">
                                                    Password:
                                                </td>
                                                <td style="padding-left: 10px">
                                                    <asp:TextBox ID="password" TextMode="Password" CssClass="textfield" runat="server"
                                                        Width="153px" ValidationGroup="logingroup"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="password"
                                                        runat="server" ErrorMessage="Password is mandatory Field." ValidationGroup="logingroup">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-left: 105px;">
                                        <asp:Button ID="btnlogin" runat="server" OnClick="Login_Click" Text="Sign in" ValidationGroup="logingroup"
                                            class="button" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnsignup" runat="server" OnClientClick="window.open('../OP/<%=DomainName %>AddTools.aspx','',''); return false;"
                                            CausesValidation="false" Text="Sign Up" class="button" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <!--End Content changes 18/08/2010 -->
                    <tr>
                        <td align="center">
                            <asp:Label ID="lblmsg" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <%--Login Contol Ends--%>
            <%--Add Fav Statrs--%>
            <asp:Panel ID="PnlAddFav" runat="server" DefaultButton="btnSubmit">
                <table border="0" cellpadding="0" cellspacing="0" class="popup-tbl" width="100%">
                    <colgroup>
                        <col width="40%">
                        <col width="*">
                    </colgroup>
                    <tr>
                        <td class="header" colspan="2">
                            Add
                            <asp:Label ID="lblprofilename" runat="server"></asp:Label>
                            to your favorites list.
                        </td>
                        <td align="right">
                            <%-- <asp:ImageButton ID="imclose" runat="server" ImageUrl="~/images/popup_close.gif"
                                 OnClick="imclose_Click" />--%>
                        </td>
                    </tr>
                    <tr>
                        <!-- Content changes -->
                        <td style="padding-left: 25px;">
                            <asp:TextBox ID="txtfavoritename" runat="server" Width="361px" CssClass="textfield"
                                ValidationGroup="g" ReadOnly="True"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtfavoritename"
                                runat="server" ErrorMessage="Favorite Name is mandatory." Display="Dynamic" Font-Size="XX-Small"
                                ValidationGroup="g">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:Button ID="btnSubmit" runat="server" Text="Add" OnClick="Save_Favorite" CssClass="button"
                                ValidationGroup="g" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <%--Add Fav Ends--%>
            <%--Add Reviews Statrs--%>
            <asp:Panel ID="PnlAddReviews" runat="server" DefaultButton="Button1" Width="900px" style="margin-left:auto; margin-right:auto;">
                <table width="800px" border="0" cellpadding="0" cellspacing="0" class="popup-tbl">
                    <tr>
                        <td class="header" nowrap>
                            <asp:Label ID="lbladdreviewprofilename" runat="server"></asp:Label>
                        </td>
                        <td align="right">
                            <%-- <asp:ImageButton ID="imgreviews" runat="server" ImageUrl="~/images/popup_close.gif"
                                 OnClick="imclose_Click" />--%>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #7F9DB9;">
                                <colgroup>
                                    <col width="60%" />
                                    <col width="2%" />
                                    <col width="*" />
                                </colgroup>
                                <tr>
                                    <td align="left">
                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="radiocls">
                                            <colgroup>
                                                <col width="26%" />
                                                <col width="67%" />
                                                <col width="*" />
                                            </colgroup>
                                            <tr>
                                                <td class="popuplabel">
                                                    Professionalism:
                                                </td>
                                                <td style="white-space: nowrap;">
                                                    <table cellpadding="0" cellspacing="0" width="100%" style="text-align: right;">
                                                        <tr>
                                                            <td>
                                                                Poor
                                                            </td>
                                                            <td>
                                                                &nbsp;Average
                                                            </td>
                                                            <td>
                                                                &nbsp;&nbsp;Good
                                                            </td>
                                                            <td>
                                                                Very&nbsp;Good
                                                            </td>
                                                            <td align="left">
                                                                Excellent
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <asp:RadioButtonList ID="Review1" runat="server" RepeatDirection="Horizontal" RepeatLayout="Table"
                                                        TextAlign="Left" Width="100%" ValidationGroup="review" TabIndex="1">
                                                        <asp:ListItem Value="1" Text="&nbsp;"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="&nbsp;"></asp:ListItem>
                                                        <asp:ListItem Value="3" Text="&nbsp;"></asp:ListItem>
                                                        <asp:ListItem Value="4" Text="&nbsp;"></asp:ListItem>
                                                        <asp:ListItem Value="5" Text="&nbsp;&nbsp;&nbsp;"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                                <td style="text-align: left;">
                                                    <asp:RequiredFieldValidator ID="reqre1" runat="server" ControlToValidate="Review1"
                                                        Display="Dynamic" ValidationGroup="review" SetFocusOnError="True" ErrorMessage="Professionalism is mandatory.">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                        </table>
                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="radiocls">
                                            <colgroup>
                                                <col width="26%" />
                                                <col width="67%" />
                                                <col width="*" />
                                            </colgroup>
                                            <tr>
                                                <td class="popuplabel">
                                                    Communication:
                                                </td>
                                                <td style="white-space: nowrap;">
                                                    <asp:RadioButtonList ID="Review2" runat="server" RepeatDirection="Horizontal" ValidationGroup="review"
                                                        RepeatLayout="Table" TextAlign="Left" Width="100%" TabIndex="2">
                                                        <asp:ListItem Value="1" Text="&nbsp;"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="&nbsp;"></asp:ListItem>
                                                        <asp:ListItem Value="3" Text="&nbsp;"></asp:ListItem>
                                                        <asp:ListItem Value="4" Text="&nbsp;"></asp:ListItem>
                                                        <asp:ListItem Value="5" Text="&nbsp;&nbsp;&nbsp;"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                                <td align="left">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="Review2"
                                                        ValidationGroup="review" ErrorMessage="Communication is mandatory." SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                        </table>
                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="radiocls">
                                            <colgroup>
                                                <col width="26%" />
                                                <col width="67%" />
                                                <col width="*" />
                                            </colgroup>
                                            <tr>
                                                <td class="popuplabel">
                                                    Customer Service:
                                                </td>
                                                <td style="white-space: nowrap;">
                                                    <asp:RadioButtonList ID="Review3" runat="server" RepeatDirection="Horizontal" ValidationGroup="review"
                                                        RepeatLayout="Table" TextAlign="Left" Width="100%" TabIndex="3">
                                                        <asp:ListItem Value="1" Text="&nbsp;"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="&nbsp;"></asp:ListItem>
                                                        <asp:ListItem Value="3" Text="&nbsp;"></asp:ListItem>
                                                        <asp:ListItem Value="4" Text="&nbsp;"></asp:ListItem>
                                                        <asp:ListItem Value="5" Text="&nbsp;&nbsp;&nbsp;"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                                <td align="left">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="Review3"
                                                        ValidationGroup="review" SetFocusOnError="True" ErrorMessage="Customer Service is mandatory.">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                        </table>
                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="radiocls">
                                            <colgroup>
                                                <col width="26%" />
                                                <col width="67%" />
                                                <col width="*" />
                                            </colgroup>
                                            <tr>
                                                <td class="popuplabel">
                                                    Review Comments:
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label2" runat="server">Characters Left: </asp:Label>
                                                    <asp:TextBox ID="txtCount" runat="server" BorderStyle="None" Width="40px" ReadOnly="True"
                                                        ValidationGroup="review" CssClass="textfield"></asp:TextBox>
                                                    <br />
                                                    <asp:TextBox ID="txtcomments" TextMode="MultiLine" MaxLength="500" runat="server"
                                                        TabIndex="4" Height="103px" Width="280px" CssClass="textfield" ValidationGroup="review"
                                                        OnTextChanged="txtcomments_TextChanged"></asp:TextBox>
                                                </td>
                                                <td align="left">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtcomments"
                                                        ValidationGroup="review" SetFocusOnError="True" ErrorMessage="Review Comment is mandatory.">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                        </table>
                                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="center">
                                                    <asp:Label ID="Label1" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <!-- Issue 768-->
                                    <td align="left">
                                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="header" colspan="2">
                                                    Your Details
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="popuplabel">
                                                    Name:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtname" MaxLength="20" runat="server" Width="150px" CssClass="textfield"
                                                        ValidationGroup="review" TabIndex="5"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtname"
                                                        ValidationGroup="review" SetFocusOnError="True" ErrorMessage="Name is mandatory.">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="popuplabel" valign="top">
                                                    Phone:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtreviewerphone" runat="server" ValidationGroup="review" Width="150px"
                                                        TabIndex="6" onblur="validatephandemail(2)"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ValidationGroup="review"
                                                        runat="server" ControlToValidate="txtreviewerphone" ErrorMessage="Enter Valid Phone Number."
                                                        ValidationExpression="^[0-9]\d{2}-\d{3}-\d{4}$" SetFocusOnError="True">*
                                                    </asp:RegularExpressionValidator><br />
                                                    (XXX-XXX-XXXX)
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" align="center" style="padding-bottom: 10px;">
                                                    OR
                                                    <asp:TextBox ID="txt1" runat="server" Width="0" Height="0" BorderStyle="None" Style="display: none;"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" ControlToValidate="txt1"
                                                        runat="server" ErrorMessage="Phone or Email Address is mandatory." Display="Dynamic"
                                                        ValidationGroup="review" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="popuplabel" nowrap>
                                                    Email Address:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtrevieweremail" TabIndex="7" runat="server" ValidationGroup="review"
                                                        Width="150px" onblur="validatephandemail(2)"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtrevieweremail"
                                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"
                                                        SetFocusOnError="True" ValidationGroup="review" ErrorMessage="Invalid Email Format.">*</asp:RegularExpressionValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="content-lable">
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:Image ID="imgreviewrcaptcha" runat="server" ImageUrl="~/GenerateCaptcha.aspx"
                                                        AlternateText="Captcha" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="popuplabel" valign="top" nowrap>
                                                    Security Code:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtreviewercaptcha" runat="server" Width="60px" ValidationGroup="review"
                                                        TabIndex="8">
                                                    </asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtreviewercaptcha"
                                                        Display="Dynamic" ValidationGroup="review" ErrorMessage="Security Code is mandatory."
                                                        SetFocusOnError="True">*
                                                    </asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <!--Issue 768-->
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td style="padding-left: 100px;">
                                                    <asp:Button ID="Button1" runat="server" Text="Submit" Width="68px" OnClick="Button1_Click"
                                                        TabIndex="9" ValidationGroup="review" Style="text-align: center" CssClass="button"
                                                        OnClientClick="return validatereview()" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="font-family: Verdana" colspan="2">
                                                    <asp:Label ID="lblshowreviewerror" runat="server" ForeColor="Red"></asp:Label>
                                                </td>
                                            </tr>
                                            <!--End Issue 768-->
                                        </table>
                                    </td>
                                    <!--End Issue 768-->
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 190px;">
                            <table width="100%" style="background-color: #FFFFFF; font-size: 12px">
                                <tr>
                                    <td>
                                        <asp:ValidationSummary ID="ValidationSummary1" HeaderText="Please correct the following and retry:"
                                            runat="server" ValidationGroup="review" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <%--Add Reviews Ends--%>
            <%--Join My Network Starts--%>
            <asp:Panel ID="PnlJoinMyNetwork" runat="server" DefaultButton="btninvite" Width="100%"
                class="popup-tbl">
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="header" colspan="2">
                            Join the network of
                            <asp:Label ID="lblprofilename1" runat="server"></asp:Label>&nbsp;: By joining my
                            network your listing will be displayed on my site.
                        </td>
                        <%--   <td align="right">
                            <asp:ImageButton ID="imgjoinmynet" runat="server" ImageUrl="~/images/popup_close.gif"
                                 OnClick="imclose_Click" />
                        </td>--%>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Label ID="Label4" runat="server" ForeColor="Green"></asp:Label>
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <td class="popuplabel">
                            Business owner name:
                        </td>
                        <td>
                            <asp:TextBox ID="txtaffiliate" MaxLength="100" CssClass="textfield" runat="server"
                                Width="361px" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <td class="popuplabel">
                            Email ID:
                        </td>
                        <td>
                            <asp:TextBox ID="txtemail" MaxLength="100" CssClass="textfield" runat="server" Width="361px"
                                ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <%--<tr>
                        <td class="popuplabel">
                            Subject:</td>
                        <td>
                            <asp:TextBox onblur="return text();" ID="txtsubject" TabIndex="11" runat="server"
                                Width="361px" ValidationGroup="jmn"></asp:TextBox><asp:RequiredFieldValidator ID="reqjmn"
                                    runat="server" ValidationGroup="jmn" Display="Dynamic" ControlToValidate="txtsubject">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>--%>
                    <tr>
                        <td>
                            <asp:Label ID="lblerr" runat="server" Visible="False" ForeColor="Green"></asp:Label>
                        </td>
                        <td style="padding-left: 400px;">
                            <asp:Button ID="btninvite" CssClass="button" runat="server" Text="Join" OnClick="btninvite_Click"
                                ValidationGroup="jmn" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <%--Add Join My Network Ends--%>
            <%--Schedule Appointment Starts--%>
            <asp:Panel ID="PnlSchAppointment" runat="server" Width="100%">
                <table border="0" cellpadding="0" cellspacing="0" class="popuptable" width="100%">
                    <tr>
                        <td class="header">
                            <asp:Label ID="lblheader" runat="server"></asp:Label><asp:Label ID="lblBusiness"
                                runat="server"></asp:Label>
                        </td>
                        <td align="right">
                            <%--  <asp:ImageButton ID="imgschapp" runat="server" ImageUrl="~/images/popup_close.gif"
                                 OnClick="imclose_Click" />--%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div style="height: 600px; overflow-y: auto;">
                                <iframe id="ifrappointments" runat="server" width="850px" scrolling="no" frameborder="0">
                                </iframe>
                            </div>
                        </td>
                    </tr>
                </table>
                <table width="100%">
                    <tr align="center">
                        <td align="center">
                            <asp:Label ID="lblClosewindow" runat="server" Font-Size="Medium" ForeColor="green"></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <%--Schedule Appointment Ends--%>
            <%--Send Messages Starts--%>
            <asp:Panel ID="PnlSendMessages" runat="server" DefaultButton="Button3">
                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="popup-tbl">
                    <tr>
                        <td class="header">
                            <asp:Label ID="lblsendmessprofilename" runat="server"></asp:Label>
                        </td>
                        <td align="right">
                            <%--<asp:ImageButton ID="imgsendmess" runat="server" ImageUrl="~/images/popup_close.gif"
                                OnClick="imclose_Click" />--%>
                        </td>
                    </tr>
                    <%if (CheckSendMessage == 0)
                      {
                    %>
                    <tr>
                        <td colspan="2" class="header">
                            Thank you for visiting our site. If you would like to contact us with your questions
                            or comments, simply complete the form below and click on the 'Send' button.
                        </td>
                    </tr>
                    <%} %>
                    <tr>
                        <td colspan="2">
                            <table width="100%" cellpadding="0" cellspacing="0" style="border: 1px solid #7F9DB9;">
                                <tr>
                                    <td valign="top">
                                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                            <colgroup>
                                                <col width="130">
                                                <col width="*">
                                            </colgroup>
                                            <tr>
                                                <td class="popuplabel">
                                                    Subject:
                                                </td>
                                                <td nowrap>
                                                    <asp:TextBox ID="txtsendmessubject" MaxLength="100" CssClass="textfield" runat="server"
                                                        Width="351px" ValidationGroup="sendmessage" TabIndex="1"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtsendmessubject"
                                                        runat="server" ErrorMessage="Subject is mandatory." Display="Dynamic" SetFocusOnError="True"
                                                        ValidationGroup="sendmessage">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="popuplabel">
                                                    Message:
                                                </td>
                                                <td nowrap>
                                                    <asp:TextBox ID="txtmessage" TextMode="MultiLine" MaxLength="1000" CssClass="textfield"
                                                        runat="server" Width="351px" Height="154px" ValidationGroup="sendmessage" TabIndex="2"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtmessage"
                                                        runat="server" ErrorMessage="Message is mandatory." SetFocusOnError="True" Display="Dynamic"
                                                        ValidationGroup="sendmessage">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td valign="top">
                                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                            <colgroup>
                                                <col width="130">
                                                <col width="*">
                                            </colgroup>
                                            <tr>
                                                <td class="header">
                                                    Your Details
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="popuplabel">
                                                    Name:
                                                </td>
                                                <td nowrap>
                                                    <asp:TextBox ID="Txtsendername" runat="server" ValidationGroup="sendmessage" Width="180px"
                                                        TabIndex="3"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="Txtsendername"
                                                        runat="server" ErrorMessage="Name is mandatory." Display="Dynamic" SetFocusOnError="True"
                                                        ValidationGroup="sendmessage">*</asp:RequiredFieldValidator><br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="popuplabel" valign="top">
                                                    Phone:
                                                </td>
                                                <td nowrap>
                                                    <asp:TextBox ID="txtsenderphone" runat="server" ValidationGroup="sendmessage" Width="180px"
                                                        TabIndex="4" onblur="validatephandemail(1)"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ValidationGroup="sendmessage"
                                                        runat="server" ControlToValidate="txtsenderphone" ErrorMessage="Enter Valid Phone Number."
                                                        ValidationExpression="^[0-9]\d{2}-\d{3}-\d{4}$" SetFocusOnError="True">*
                                                    </asp:RegularExpressionValidator><br />
                                                    (XXX-XXX-XXXX)
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" align="center" style="padding-bottom: 10px; padding-left: 50px;">
                                                    OR
                                                    <asp:TextBox ID="txt" runat="server" Width="0" Height="0" BorderStyle="None" Style="display: none;"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="txt"
                                                        runat="server" ErrorMessage="Phone or Email Address is mandatory." Display="Dynamic"
                                                        ValidationGroup="sendmessage" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="popuplabel">
                                                    Email Address:
                                                </td>
                                                <td nowrap>
                                                    <asp:TextBox ID="txtsenderemail" TabIndex="5" runat="server" ValidationGroup="sendmessage"
                                                        Width="180px" onblur="validatephandemail(1)"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtsenderemail"
                                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"
                                                        SetFocusOnError="True" ValidationGroup="sendmessage" ErrorMessage="Invalid Email Format.">*</asp:RegularExpressionValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="content-lable">
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:Image ID="img1" runat="server" ImageUrl="~/GenerateCaptcha.aspx" AlternateText="Captcha" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="popuplabel" valign="top">
                                                    Security Code:
                                                </td>
                                                <td nowrap>
                                                    <asp:TextBox ID="txtcaptcha" runat="server" Width="60px" ValidationGroup="sendmessage"
                                                        TabIndex="6">
                                                    </asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="ReqCapha" runat="server" ControlToValidate="txtcaptcha"
                                                        Display="Dynamic" ValidationGroup="sendmessage" ErrorMessage="Security Code is mandatory."
                                                        SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <!---->
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td style="padding-left: 150px;">
                                                    <asp:Button ID="Button3" runat="server" CssClass="button" Text="Send" OnClick="Button3_Click"
                                                        TabIndex="7" ValidationGroup="sendmessage" />&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td style="font-family: Verdana">
                                                    <asp:Label ID="lblShowError" runat="server" ForeColor="Red"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 140px;">
                            <table width="100%" style="background-color: #FFFFFF; font-size: 12px">
                                <tr>
                                    <td>
                                        <asp:ValidationSummary ID="ValidationSummary2" HeaderText="Please correct the following and retry:"
                                            runat="server" ValidationGroup="sendmessage" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <%--Send Messages Ends--%>
            <%--Pnl Errors Starts--%>
            <asp:Panel ID="PnlError" runat="server">
                <table cellpadding="0" cellspacing="0" width="100%" class="popup-tbl">
                    <tr>
                        <td align="right" style="padding-right: 5px; padding-bottom: 10px;">
                            <%--  <asp:ImageButton ID="Imgsameprofile" runat="server" ImageUrl="~/images/popup_close.gif"
                                 OnClick="imclose_Click" />--%>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="padding-bottom: 10px;">
                            <asp:Label ID="lblSameProfileerror" runat="server" CssClass="link"></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <%--Pnl Errors Ends--%>
            <asp:HiddenField ID="hdncntrl" runat="server" />
            <asp:HiddenField ID="hdnezsmartreview" runat="server" />
            <asp:HiddenField ID="PID" runat="server" />
            <%-- Success Panel Starts --%>
            <asp:Panel ID="PnlSuccess" runat="server">
                <table cellpadding="0" cellspacing="0" width="100%" class="popup-tbl">
                    <tr>
                        <td align="right" style="padding-right: 5px; padding-bottom: 10px;">
                            <%--<asp:ImageButton ID="ImgSucess" runat="server" ImageUrl="~/images/popup_close.gif"
                                 OnClick="imclose_Click" />--%>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="padding-bottom: 10px;">
                            <asp:Label ID="lbpnlsucess1" runat="server"></asp:Label>
                            <asp:Label ID="lbpnlsucess" runat="server" CssClass="link"></asp:Label>
                            <asp:Label ID="lbpnlsucess2" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <%--Success Ends --%>
            <%-- Panel Save Search Results Starts --%>
            <asp:Panel ID="Pnlsavesearchresults" runat="server">
                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="popup-tbl">
                    <colgroup>
                        <col width="20%" />
                        <col width="*" />
                    </colgroup>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Label ID="lblsavesearch" runat="server" ForeColor="red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="popuplabel" align="center">
                            Name your search:
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtsearchname" runat="server" Width="361px" ValidationGroup="savesearch"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="reqsavesearch" ControlToValidate="txtsearchname"
                                runat="server" ErrorMessage="Search Name is mandatory." Display="Dynamic" Font-Size="XX-Small"
                                ValidationGroup="savesearch"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:Button ID="btnsavesearch" CssClass="button" runat="server" Text="Save Search Results"
                                OnClick="btnsavesearch_Click" ValidationGroup="savesearch" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <%--Panel Save Search Results  Ends --%>
            <asp:HiddenField ID="hdnrefresh" runat="server" />
            <asp:HiddenField ID="hdnclose1" runat="server" />
            <asp:HiddenField ID="hdnsuccess" runat="server" />
        </td>
    </tr>
</table>
<script type="text/javascript">
    //alert(parent.document.getElementById('Iframe2').offsetHeight);
    //alert(document.getElementById('<%= hdnsuccess.ClientID %>').value);
    if (document.getElementById('<%=hdnclose1.ClientID %>').value != "") {
        if (document.getElementById("ctl00_cphUser_hdnpopupfalse") != null) {
            document.getElementById("ctl00_cphUser_hdnpopupfalse").value = "F";
        }
        if (document.getElementById("hdnpopupfalse") != null) {
            document.getElementById("hdnpopupfalse").value = "F";
        }
        if (document.getElementById('<%=hdncntrl.ClientID %>').value == "4") {
            if (document.getElementById('<%=hdnezsmartreview.ClientID %>').value == "1") {
                top.document.getElementById('btnclick').click();
            }
        }
        parent.$find("Modal1").hide();
    }

    if (document.getElementById('<%= hdnsuccess.ClientID %>').value != '') {
        parent.document.getElementById('Iframe2').style.height = '50px';
        if (document.getElementById('<%= hdnsuccess.ClientID %>').value == "2") // favourites
        {
            parent.document.getElementById('Iframe2').style.height = '130px';
        }
        else if (document.getElementById('<%= hdnsuccess.ClientID %>').value == "3") // join my network 
        {
            parent.document.getElementById('Iframe2').style.height = '50px';
        }
        document.getElementById('<%= hdnsuccess.ClientID %>').value = '';
    }
</script>
