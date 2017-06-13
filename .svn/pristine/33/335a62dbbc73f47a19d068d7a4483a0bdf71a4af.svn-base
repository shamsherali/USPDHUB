<%@ Page Title="" Language="C#" MasterPageFile="~/PaidTools.master" AutoEventWireup="true"
    CodeBehind="SMSCompose.aspx.cs" Inherits="USPDHUB.Business.MyAccount.SMSCompose" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <style type="text/css">
        .cursor
        {
            cursor: hand;
        }
        .navy20
        {
            color: #2F348F;
            font-size: 15px;
            font-weight: bold;
            font-family: Arial;
        }
        .navy16
        {
            color: #2F348F;
            font-size: 14px;
            line-height: 22px;
            font-family: Arial;
        }
        .black16
        {
            color: #333;
            font-size: 16px;
            line-height: 22px;
            font-family: Arial;
        }
        .black16normal
        {
            color: #000;
            font-size: 14px;
            line-height: 22px;
            font-family: Arial;
        }
        .sendcontactsbutton
        {
            background: url(../../images/Dashboard/sendcontactsbutton_bg.png) no-repeat;
            width: 149px;
            height: 32px;
            color: #fff;
            font-size: 14px;
            text-align: center;
            border: 0px;
            font-weight: bold;
            cursor: hand;
        }
        .txtarea11
        {
            font-size: 14px;
            color: #000;
            border: #D3D3D3 2px solid;
            font-family: Arial;
            resize: none;
        }
        #boxes .window
        {
            border: solid 2px #FFCC00;
            position: absolute;
            left: 0;
            top: 0;
            width: 490px;
            height: 200px;
            display: none;
            z-index: 9999;
        }
        
        #boxes #dialog
        {
            width: 500px;
            height: 369px;
            padding: 10px;
            background-color: #FFFFFF;
            margin-top: 11%;
            margin-left: 34%;
        }
    </style>
    <script>
        var count = 0;
        function checkemailcount(id) {
            var end = id.value.substring(id.value.length - 1, id.value.length);
            var str = id.value.split(",");

            if (end == ",") {
                count = str.length - 1;
            }
            else {
                count = str.length;
            }
            if (id.value == "") {
                count = 0;
                return false;
            }
            $get('<%=lblselectedcontactcount.ClientID %>').innerHTML = count;
            $get('<%=hdnSelectedSMS.ClientID%>').value = count;

        } 

    </script>
    <script type="text/javascript">
        // *** Check Max Length *** //
        function Count(text, long, type) {
            var maxlength = new Number(long); // Change number to your max length.
            if (document.getElementById('<%=txtmessage.ClientID%>').value.length > maxlength) {
                text.value = text.value.substring(0, maxlength);
                if (type == "1")
                    document.getElementById("<%=lblpreview.ClientID %>").innerHTML = document.getElementById("<%=txtmessage.ClientID %>").value;
                alert(" You have reached maximum " + long + " characters.");
            }
            else
                document.getElementById("<%=lblpreview.ClientID %>").innerHTML = document.getElementById("<%=txtmessage.ClientID %>").value;
            var divElement = document.getElementById("ctl00_cphUser_lblpreview");

        }
        // *** Check Max Length *** //
    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="page-padding" cellspacing="0" cellpadding="0" width="100%" border="0">
                <tbody>
                    <tr>
                        <td>
                            <table class="page-title" cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td align="center">
                                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="3">
                                                <ProgressTemplate>
                                                    <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 32px">
                                            Send SMS
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:Label ID="lblmess" runat="server" ForeColor="Green" Font-Size="Medium"></asp:Label>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="inputtable">
                                <tr>
                                    <td>
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td align="center">
                                                    <table border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <asp:ValidationSummary ID="asd" Style="text-align: left;" HeaderText="The following error(s) occurred:"
                                                                    runat="server" ValidationGroup="ABC"></asp:ValidationSummary>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td valign="top">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="5" class="maintbl">
                                                        <tr>
                                                            <td height="27" class="navy20">
                                                                Step 1: Select Recipients
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top" colspan="2">
                                                                <table border="0" cellpadding="0" cellspacing="0" width="90%" style="border-left: 1px solid #04519D;
                                                                    border-right: 1px solid #04519D; border-bottom: 1px solid #04519D;">
                                                                    <tr>
                                                                        <td colspan="2" style="background: url(../../images/header_newsletter.gif) repeat-x;
                                                                            height: 40px; border: 1px solid #04519D; padding: 0px 0px 0px 5px;">
                                                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                                <tr>
                                                                                    <td width="40px">
                                                                                        <img src="../../images/Dashboard/contacts.png" />
                                                                                    </td>
                                                                                    <td align="left">
                                                                                        <asp:Button ID="lnkimportcontacts" runat="server" TabIndex="2" ToolTip="Select Contacts"
                                                                                            CausesValidation="false" CssClass="sendcontactsbutton" Text="Select Contacts"
                                                                                            OnClick="lnkimportcontacts_Click"></asp:Button>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center" style="padding: 0px 0px 0px 10px;">
                                                                            <span class="navy16" style="padding: 0px 0px 0px 0px;">or<br />
                                                                                Enter Manually<br />
                                                                            </span><span class="black16" align="left">Note: Please separate contacts with a comma.</span>
                                                                        </td>
                                                                        <td valign="middle" style="padding: 8px 0px 8px 30px;">
                                                                            <asp:TextBox ID="txtto" TabIndex="1" runat="server" Width="350px" Height="90px" CssClass="txtarea11"
                                                                                TextMode="MultiLine" onblur="checkemailcount(this)" ValidationGroup="ABC"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="ABC"
                                                                                SetFocusOnError="true" ControlToValidate="txtto" Display="Dynamic" ErrorMessage="Select Recipients is mandatory.">*</asp:RequiredFieldValidator>
                                                                            <br />
                                                                            <asp:Panel ID="pnltext" runat="server">
                                                                                <span style="padding-left: 80px; font-weight: bold;">You have selected
                                                                                    <asp:Label ID="lblselectedcontactcount" runat="server"></asp:Label>&nbsp;contact(s).</span>
                                                                            </asp:Panel>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:Label ID="lblRemainingEmailsCount" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="30" class="navy20" style="padding: 8px 0px 0px 0px;">
                                                                Step 2: Enter SMS Message
                                                            </td>
                                                            <td rowspan="2">
                                                                <table style="background-image: url('../../images/Samsung.jpg'); background-repeat: no-repeat;
                                                                    width: 290px; margin-left: 20px;">
                                                                    <tr>
                                                                        <td style="width: 155px; height: 100px; text-align: left;">
                                                                            <div id="lblpreview" runat="server" style="width: 150px; height: 120px; overflow: auto;
                                                                                overflow-x: hidden; text-align: left; margin-left: 17px; margin-right: 25px;
                                                                                margin-top: 25px; display: none;">
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top" style="padding: 8px; border: 1px solid #04519D; width: 365px;">
                                                                <asp:TextBox onKeyUp="javascript:Count(this,1000,'1');" onChange="javascript:Count(this,1000,'0');"
                                                                    TextMode="MultiLine" ID="txtmessage" runat="server" Width="350px" Height="100px"
                                                                    TabIndex="4" class="txtarea11"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="ABC" runat="server"
                                                                    ControlToValidate="txtmessage" ErrorMessage="Message is mandatory">*</asp:RequiredFieldValidator>
                                                                <%--<asp:RegularExpressionValidator ID="txtConclusionValidator1" ControlToValidate="txtmessage" Text="Exceeding 150 characters" ValidationExpression="^[\s\S]{0,150}$" runat="server" />--%>
                                                                <br />
                                                                <strong>Note : Max 1000 characters</strong>
                                                            </td>
                                                        </tr>
                                                        <tr style="display: none;">
                                                            <td colspan="2" height="30" class="navy20" style="padding: 8px 0px 0px 0px;">
                                                                Step 5: Add Link That Will Appear on Your Message
                                                            </td>
                                                        </tr>
                                                        <tr style="display: none;">
                                                            <td colspan="2">
                                                                <asp:CheckBox ID="chkShortUrl" runat="server" Checked="False" />
                                                                <span style="color: #B85707; font-size: 15px;">Add My Website Short Url</span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" align="center">
                                                                <asp:LinkButton ID="lnkCancelMail" runat="server" OnClick="lnkCancelMail_Click" CausesValidation="false"
                                                                    TabIndex="8"><img src="../../images/Dashboard/cancel_button.gif" alt=""/></asp:LinkButton>
                                                                <asp:LinkButton ID="lnkSend" runat="server" OnClick="lnkSend_Click" CausesValidation="false"
                                                                    TabIndex="7"><img src="../../images/Dashboard/send_button.gif" alt=""/></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table width="100%" class="inputgrid">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblEmailsch" runat="server" ForeColor="red"></asp:Label><br />
                                                                <asp:Label ID="lblsendingDate" runat="server" ForeColor="green" nowrap></asp:Label>
                                                                <asp:Label ID="lblerror" runat="server" ForeColor="red"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>
            <div style="visibility: hidden;">
                <asp:Button ID="btnclick" runat="server" OnClick="btnclick_Click" CausesValidation="false" />
                <asp:Button ID="btncancelpop" runat="server" OnClick="btncancelpop_Click" CausesValidation="false" />
            </div>
            <table cellspacing="0" cellpadding="0" border="0">
                <tbody>
                    <tr>
                        <td>
                            <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="lblc"
                                PopupControlID="pnlpopup" BackgroundCssClass="modal">
                            </cc1:ModalPopupExtender>
                            <asp:Panel Style="display: none" ID="pnlpopup" runat="server" Width="100%">
                                <table style="padding-right: 10px" class="popuptable" cellspacing="0" cellpadding="0"
                                    width="800px" align="center" border="0">
                                    <tbody>
                                        <tr>
                                            <td>
                                                <asp:Panel ID="pnldiscontact" runat="server" Width="100%">
                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                        <tbody>
                                                            <tr>
                                                                <td class="header">
                                                                    Select Contacts
                                                                </td>
                                                                <td align="right">
                                                                    <asp:LinkButton ID="lnkCancel" OnClick="lnkCancel_Click" runat="server" CausesValidation="false"><img src="../../images/popup_close.gif" /></asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <iframe id="frmcontacts" runat="server" src="../../ProfileIframes/SMSContactManagement.aspx"
                                                                        frameborder="0" width="800px;" height="500px;" scrolling="no"></iframe>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Panel ID="pnlnocotnact" runat="server" Width="100%">
                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                        <colgroup>
                                                            <col width="30%" />
                                                            <col width="*" />
                                                        </colgroup>
                                                        <tbody>
                                                            <tr>
                                                                <td style="padding-top: 12px" class="header" colspan="2">
                                                                    We are sorry, you don't have any contacts in your contact lists.
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Button ID="btnenhance" OnClick="btnenhance_Click" runat="server" Text="Add Contacts"
                                                                        CausesValidation="false"></asp:Button>
                                                                </td>
                                                                <td>
                                                                    <asp:Button ID="btndashboard" OnClick="btnCancel_Click" runat="server" Text="No Thanks"
                                                                        CausesValidation="false"></asp:Button>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="popuplabel" colspan="2">
                                                                    Add Contacts: Add contacts to your contact lists so you can import them across the
                                                                    web site.
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="popuplabel" colspan="2">
                                                                    No Thanks: Manually enter the email addresses you want to send invitations to.
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </asp:Panel>
                            <asp:Label ID="lblc" runat="server"></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
            <asp:HiddenField ID="hdnuserid" runat="server" />
            <asp:HiddenField ID="hdnlimit" runat="server" />
            <asp:HiddenField ID="hdnRemainingSMS" Value="0" runat="server" />
            <asp:HiddenField ID="hdnSelectedSMS" Value="0" runat="server" />
            <asp:HiddenField ID="hdncheckcontact" runat="server" />
            <asp:HiddenField ID="hdnShortUrl" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
