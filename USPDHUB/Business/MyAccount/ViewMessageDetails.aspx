<%@ Page Title="" Language="C#" MasterPageFile="~/PaidTools.master" AutoEventWireup="true"
    CodeBehind="ViewMessageDetails.aspx.cs" Inherits="USPDHUB.Business.MyAccount.ViewMessageDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <script src="../../Scripts/flyers/jquery-1.7.2.js" type="text/javascript"></script>
    <script src="../../Scripts/autopopulatedbox/sol.js" type="text/javascript"></script>
    <link href="../../css/Bulletins.css" rel="stylesheet" type="text/css" />
    <link href="../../css/autopopulatedbox/sol.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">

        function SelectAll(CheckBox) {
            TotalChkBx = parseInt('<%= this.gveContacts.Rows.Count %>');
            var TargetBaseControl = document.getElementById('<%= this.gveContacts.ClientID %>');
            var TargetChildControl = "chkContacts";
            var Inputs = TargetBaseControl.getElementsByTagName("input");
            for (var iCount = 0; iCount < Inputs.length; ++iCount) {
                if (Inputs[iCount].type == 'checkbox' && Inputs[iCount].id.indexOf(TargetChildControl, 0) >= 0)
                    Inputs[iCount].checked = CheckBox.checked;
            }
        }



        function getValues() {
            var selectedEmailIds = "";
            var TargetBaseControl = document.getElementById('<%= this.gveContacts.ClientID %>');

            var InputsEmailIds = TargetBaseControl.getElementsByTagName("span");
            var Inputs = TargetBaseControl.getElementsByTagName("input");
            var TargetChildControl = "chkContacts";

            var k = 2;
            for (var iCount = 0; iCount < Inputs.length; ++iCount) {
                if (Inputs[iCount].type == 'checkbox' && Inputs[iCount].id.indexOf(TargetChildControl, 0) >= 0) {
                    if (Inputs[iCount].checked == true) {
                        selectedEmailIds = selectedEmailIds + "," + InputsEmailIds[k].innerHTML;
                    }

                    if (iCount != 0)
                        k = k + 3;
                }
            }

            document.getElementById('<%= hdnSelectedEMailIds.ClientID %>').value = selectedEmailIds;

        }

        function checkItem_All(objRef, colIndex) {
            var GridView = objRef.parentNode.parentNode.parentNode;
            var selectAll = GridView.rows[0].cells[colIndex].getElementsByTagName("input")[0];
            if (!objRef.checked) {
                selectAll.checked = false;
            }
            else {
                var checked = true;
                for (var i = 1; i < GridView.rows.length; i++) {
                    var chb = GridView.rows[i].cells[colIndex].getElementsByTagName("input")[0];
                    if (!chb.checked) {
                        checked = false;
                        break;
                    }
                }
                selectAll.checked = checked;
            }
        }
        
    </script>
    <style>
        .leftdiv
        {
            float: left;
            text-align: left;
            width: 41%;
        }
        .rightdiv
        {
            color: #353535;
            float: left;
            padding: 3px 0px 0px 0px;
            font-size: 12px;
            margin: 2px 35px;
            width: 26%;
        }
    </style>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" DefaultButton="btnSave" runat="server">
                <div id="wrapper">
                    <div class="headernav">
                        <asp:TextBox ID="txt" runat="server" Width="0" BorderStyle="none" BorderColor="white"
                            Style="border: 0; border-color: White!important;"></asp:TextBox>
                    </div>
                    <div style="text-align: center;">
                        <asp:Label ID="lblerror" runat="server"></asp:Label>
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="3">
                            <ProgressTemplate>
                                <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green"
                                    size="2">Processing....</font></b>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <div style="width: 350px; margin: 0 auto;">
                            <asp:ValidationSummary ID="ValidateUserDetails" runat="server" Style="text-align: left;"
                                ValidationGroup="SV" HeaderText="The following error(s) occurred:" />
                        </div>
                    </div>
                    <div class="clear">
                    </div>
                    <div class="contentwrap">
                        <div class="largetxt">
                            Message Details
                            <asp:Label runat="server" ID="lblSubject" Style="display: none;" Font-Bold="true"></asp:Label>
                        </div>
                        <div class="form_wrapper" style="width: 860px;">
                            <div class="clear">
                            </div>
                            <div class="fields_wrap">
                                <div class="clear">
                                </div>
                                <label style="color: Red; font-size: 16px; margin-left: 100px;">
                                    * Marked fields are mandatory.</label>
                                <input type="button" value="Print" onclick="printMessageDetails();" style="float: right;
                                    width: 70px; margin-top: 10px;" class="button" />
                            </div>
                            <div class="clear">
                            </div>
                            <div class="clear10">
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                </div>
                                <div class="right_fields">
                                    <asp:Label runat="server" ID="lblMessage" Font-Size="Medium" Visible="false" Text="Your message has been sent successfully."
                                        Font-Bold="true" ForeColor="Green"></asp:Label>
                                </div>
                            </div>
                            <div class="clear">
                            </div>
                            <div class="clear10">
                            </div>
                            <div style="overflow: hidden; padding: 3px 0px 0px 0px; margin: 2px 20px 0px 100px;">
                                <div style="border: 1px solid black; width: 55%; float: left;">
                                    <div class="leftdiv">
                                        <caption>
                                            <span style="padding-left: 2px;">&nbsp;</span><label>
                                                <label>
                                                    Contact Name:</label></label></caption>
                                    </div>
                                    <div class="rightdiv">
                                        <asp:Label runat="server" ID="lblContactName"></asp:Label>
                                    </div>
                                    <div class="clear">
                                    </div>
                                    <div class="leftdiv">
                                        <span style="padding-left: 2px;">&nbsp;</span><label>
                                            Contact Email ID:</label></div>
                                    <div class="rightdiv">
                                        <asp:Label runat="server" ID="lblContactEmailID" Style="vertical-align: top;"></asp:Label>
                                    </div>
                                    <div class="clear">
                                    </div>
                                    <div class="leftdiv">
                                        <span style="padding-left: 2px;">&nbsp;</span><label>
                                            Phone Number:</label></div>
                                    <div class="rightdiv">
                                        <asp:Label runat="server" ID="lblPhoneNumber"></asp:Label>
                                    </div>
                                    <div class="clear">
                                    </div>
                                </div>
                                <div style="width: 30%; float: left; padding-top: 12px; padding-left: 5px">
                                    <%if (lblContactEmailID.Text != string.Empty)
                                      { %>
                                    <img alt="reply" src="../../Images/Dashboard/ReplySender.png" onclick="return ReplyPopup();"
                                        style="margin-top: -15px;">
                                    <%} %>
                                    <br />
                                    <%if (ButtonType != "PrivateCallAddOns" && ButtonType != "PrivateSmartConnectAddOns")
                                      {%>
                                    <asp:ImageButton ID="imgButton" runat="server" ImageUrl="../../Images/Dashboard/BlockSender.png"
                                        OnClick="btnBlock_Click" Width="105px" OnClientClick="return ConfirmationWindow();" />
                                    <% } %>
                                </div>
                            </div>
                            <div class="clear">
                            </div>
                            <div class="clear10">
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        Message Date & Time:</label></div>
                                <div class="right_fields">
                                    <asp:Label runat="server" ID="lblMessageDate"></asp:Label>
                                </div>
                            </div>
                            <div class="clear">
                            </div>
                            <div class="clear10">
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        Custom Message:</label></div>
                                <div class="right_fields">
                                    <asp:Label runat="server" ID="lblCustomMessage"></asp:Label>
                                </div>
                            </div>
                            <div class="clear">
                            </div>
                            <div class="clear10">
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        Device Location:</label></div>
                                <div class="right_fields">
                                    <asp:Label runat="server" ID="lblLocation"></asp:Label>
                                </div>
                            </div>
                            <div class="clear">
                            </div>
                            <div class="clear10">
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        QR Location:</label></div>
                                <div class="right_fields">
                                    <asp:Label runat="server" ID="lblQRLocation"></asp:Label>
                                </div>
                            </div>
                            <div class="clear">
                            </div>
                            <div class="clear10">
                            </div>
                            <%if (ButtonType == USPDHUBBLL.ButtonTypes.PrivateSmartConnect)
                              {%>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        Proximity:</label></div>
                                <div class="right_fields">
                                    <asp:Label runat="server" ID="lblIsApproximateDistance"></asp:Label>
                                </div>
                            </div>
                            <div class="clear">
                            </div>
                            <div class="clear10">
                            </div>
                            <%} %>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        Tab Name:</label></div>
                                <div class="right_fields">
                                    <asp:Label runat="server" ID="lblTabName"></asp:Label>
                                </div>
                            </div>
                            <%if (ButtonType == USPDHUBBLL.ButtonTypes.PrivateCall ||
                                  ButtonType == USPDHUBBLL.ButtonTypes.SmartConnect || ButtonType == USPDHUBBLL.ButtonTypes.PrivateSmartConnect)
                              {%>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        Button Name:</label></div>
                                <div class="right_fields">
                                    <asp:Label runat="server" ID="lblItemTitle"></asp:Label>
                                </div>
                            </div>
                            <%} %>
                            <div class="clear">
                            </div>
                            <div class="clear10">
                            </div>
                            <%if (!(string.IsNullOrEmpty(lblCategoryName.Text.Trim())) && (ButtonType == USPDHUBBLL.ButtonTypes.SmartConnect
                                  || ButtonType == USPDHUBBLL.ButtonTypes.PrivateSmartConnect))
                              { %>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        Category:</label></div>
                                <div class="right_fields">
                                    <asp:Label runat="server" ID="lblCategoryName"></asp:Label>
                                </div>
                            </div>
                            <div class="clear">
                            </div>
                            <div class="clear10">
                            </div>
                            <%} %>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        Reference ID:</label></div>
                                <div class="right_fields">
                                    <asp:Label runat="server" ID="lblRefID"></asp:Label>
                                </div>
                            </div>
                            <div class="clear">
                            </div>
                            <div class="clear10">
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <asp:Button runat="server" Text="Copy to Image Gallery" ID="Button1" Visible="false" />
                                </div>
                                <div class="right_fields">
                                </div>
                            </div>
                            <div class="clear">
                            </div>
                            <div class="clear10">
                            </div>
                            <%if (ImageName != "")
                              { %>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <asp:Button runat="server" Text="Copy to Image Gallery" ID="btnCopyImageGallery"
                                        Visible="false" OnClientClick="return ShowImageGallary();" />
                                </div>
                                <div class="right_fields">
                                    <asp:Label runat="server" ID="lblImage"></asp:Label>
                                </div>
                            </div>
                            <%} %>
                            <div class="clear">
                            </div>
                            <div class="clear10">
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <font color="red">*</font><label>
                                        Notes:</label></div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtNotes" runat="server" TextMode="MultiLine" CssClass="txtfild1"
                                        ValidationGroup="SV" Width="350px" onkeyup="CountMaxLength(this,'Notes',event);"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                                        ControlToValidate="txtNotes" ValidationGroup="SV" ErrorMessage="Notes is mandatory.">*</asp:RequiredFieldValidator>
                                    <br />
                                    <span style="float: left;">You have
                                        <asp:Label ID="lblLength" runat="server" Text="500"></asp:Label>
                                        characters left.</span><span style="margin-left: 80px;">(Max Characters 500)</span>
                                </div>
                            </div>
                            <div class="clear">
                            </div>
                            <div class="clear10">
                            </div>
                            <div class="fields_wrap">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        Send Notes To:</label>
                                    <asp:CheckBox runat="server" ID="chkNotify" Checked="false" AutoPostBack="false" /><br />
                                    <asp:LinkButton ID="lnkSelectContacts" runat="server" Text="Select Contacts" OnClick="lnkSelectContacts_Click"
                                        Style="padding-left: 10px; padding-top: 5px; color: #FF7A5A; font-weight: bold;
                                        display: none;"></asp:LinkButton></div>
                                <asp:HiddenField runat="server" ID="hdnSelectedEMailIds" Value="" />
                            </div>
                            <div class="right_fields">
                                <asp:TextBox ID="txtEMailIds" runat="server" TextMode="MultiLine" Width="350px" placeholder="Enter Email Address"
                                    Enabled="false"></asp:TextBox>
                                <fieldset style="padding: 10px; border-radius: 7px; width: 330px; display: none;">
                                    <input id="dummy" type="text" placeholder=" Click here to search" disabled style="height: 28px;
                                        width: 320px;"></input>
                                    <div id="DivEmailIds" style="display: none;">
                                        <select id="my-selectEmailIds" name="character" multiple="multiple" style="min-width: 320px;">
                                        </select></div>
                                </fieldset>
                            </div>
                        </div>
                        <div class="fields_wrap">
                            <div class="left_lable">
                            </div>
                            <div class="right_fields">
                            </div>
                        </div>
                        <div class="fields_wrap">
                            <div class="left_lable">
                            </div>
                            <div class="right_fields">
                                <asp:CheckBox runat="server" ID="chkIncludePreviousNotes" Checked="false" />
                                <label style="font-weight: bold;">
                                    Include Previous Notes</label>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                </div>
                                <div class="right_fields" style="margin: 10px 0px 0px 0px; width: 450px;">
                                    <asp:Button ID="Button2" runat="server" CausesValidation="false" border="0" CssClass="btn"
                                        Text="Back" OnClick="btnCancel_Click" />
                                    <asp:Button ID="btnCancel" runat="server" CausesValidation="false" border="0" CssClass="btn"
                                        Text="Cancel" OnClick="btnCancel_Click" />
                                    <asp:Button ID="btnSave" runat="server" Text="Submit" CssClass="btn" border="0" OnClick="btnSave_Click"
                                        ValidationGroup="SV" OnClientClick="return ValidateDetails();" />
                                    <asp:HiddenField runat="server" ID="hdnImageName" />
                                    <asp:HiddenField runat="server" ID="hdnEmailIds" />
                                    <asp:HiddenField runat="server" ID="hdnAssociateUsers" />
                                    <asp:HiddenField runat="server" ID="hdnQueryStringParms" />
                                    <asp:HiddenField runat="server" ID="hdnIsBlocked" />
                                </div>
                            </div>
                            <div class="clear10">
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                </div>
                                <div class="right_fields" style="font-family: Segoe UI; font-size: 14px;">
                                    (Note: When clicking Submit, your notes will be logged and if the 'Send Notes To:'
                                    box has been checked, an email will be sent out to the selected contacts.)</div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="right_fields" style="margin: 10px 0px 0px 50px; width: 800px;">
                                    <asp:DataList ID="DLNotes" runat="server" DataKeyField="ReplyHistoryID" ForeColor="Black"
                                        CellSpacing="12" Width="100%">
                                        <ItemTemplate>
                                            <asp:Panel ID="UpdatePanel" runat="server" Style="overflow: auto;" BackColor="Gainsboro"
                                                Width="100%">
                                                <table style="border-collapse: collapse" border="0" cellpadding="10" width="100%">
                                                    <tr>
                                                        <td align="justify" colspan="2">
                                                            <asp:Label ID="NotesText" runat="server" ForeColor="black" Text='<%# DataBinder.Eval(Container.DataItem,"Notes") %>' />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Notes By:
                                                            <asp:Label ID="lblRepName" runat="server" ForeColor="black" Text='<%# DataBinder.Eval(Container.DataItem,"NotesByUser") %>' />
                                                        </td>
                                                        <td align="right">
                                                            <asp:Label ID="Label1" runat="server" ForeColor="black" Text='<%#  DataBinder.Eval(Container.DataItem,"CreatedDate","{0:MM/dd/yyyy hh:mm tt}") %>' />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <cc1:RoundedCornersExtender ID="RoundedCornersExtender1" TargetControlID="UpdatePanel"
                                                runat="server">
                                            </cc1:RoundedCornersExtender>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
            <asp:Label ID="lblbulletinimage" runat="server"></asp:Label>
            <cc1:ModalPopupExtender ID="popbulletinimage" runat="server" TargetControlID="lblbulletinimage"
                PopupControlID="pnlbulletinimage" BackgroundCssClass="modal" BehaviorID="popupimage"
                CancelControlID="imcloseimagepopup">
            </cc1:ModalPopupExtender>
            <asp:Panel ID="pnlbulletinimage" runat="server" Style="display: none" Width="800px">
                <table cellpadding="0" cellspacing="0" width="100%" style="border: 1px solid #EEECEC;
                    background-color: #F8F6F6;">
                    <tbody>
                        <tr>
                            <td align="right" style="padding: 5px 10px 0px 10px;">
                                <asp:ImageButton ID="imcloseimagepopup" runat="server" ImageUrl="~/images/popup_close.gif" />
                            </td>
                        </tr>
                        <tr>
                            <td class="mid">
                                <div id="DIDIFrm">
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </asp:Panel>
            <asp:Label ID="lblDummyReply" runat="server"></asp:Label>
            <cc1:ModalPopupExtender ID="popReply" runat="server" TargetControlID="lblDummyReply"
                PopupControlID="pnlReplyContent" BackgroundCssClass="modal" BehaviorID="popupReplyContent"
                CancelControlID="imcloseimagepopup">
            </cc1:ModalPopupExtender>
            <asp:Panel ID="pnlReplyContent" runat="server" Style="display: none" Width="600px">
                <table cellpadding="0" cellspacing="0" width="100%" style="border: 1px solid #EEECEC;
                    background-color: #F8F6F6;">
                    <tbody>
                        <tr>
                            <td align="right" style="padding: 5px 10px 0px 10px;">
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/popup_close.gif" />
                            </td>
                        </tr>
                        <tr>
                            <td class="mid">
                                <table width="100%" cellpadding="0" cellspacing="0" style="margin-left: 20px;">
                                    <colgroup>
                                        <col width="80px" />
                                        <col width="*" />
                                        <tr>
                                            <td>
                                                Reply To:
                                            </td>
                                            <td>
                                                <asp:Label ID="lblReplyEmailId" runat="server" Font-Bold="true"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <font color="red">*</font> Message:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtReplyNotes" runat="server" CssClass="txtfild1" onkeyup="ReplyNotes_CountMaxLength(this,'Notes',event);"
                                                    TextMode="MultiLine" Width="350px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="reqtxtReplyNotes" runat="server" ControlToValidate="txtReplyNotes"
                                                    Display="Dynamic" Enabled="true" ErrorMessage="*" ForeColor="Red" ValidationGroup="replyNotes"></asp:RequiredFieldValidator>
                                                <br />
                                                <div>
                                                    <span style="float: left;">You have
                                                        <asp:Label ID="lblReplyNotesLength" runat="server" Text="500"></asp:Label>
                                                        characters left.</span>
                                                    <br />
                                                    <br />
                                                    &nbsp;&nbsp;&nbsp;<span style="margin-left: 35px;">
                                                        <br />
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(Max Characters 500)</span>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:Button ID="btnCloseReplyPopup" runat="server" CausesValidation="false" CssClass="btn"
                                                    OnClientClick="return CloseReplyPopup('cancel');" Text="Cancel" />
                                                <asp:Button ID="btnSendReply" runat="server" CausesValidation="true" CssClass="btn"
                                                    OnClick="btnSendReply_OnClick" OnClientClick="return ValidateReplyNotesDetails();"
                                                    Text="Send" ValidationGroup="replyNotes" />
                                            </td>
                                        </tr>
                                    </colgroup>
                                </table>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </asp:Panel>
            <asp:Label ID="lblContactList" runat="server"></asp:Label>
            <cc1:ModalPopupExtender ID="ContactsList" runat="server" TargetControlID="lblContactList"
                PopupControlID="pnlContactList" BackgroundCssClass="modal" CancelControlID="ImageButton2">
            </cc1:ModalPopupExtender>
            <asp:Panel Style="display: none;" ID="pnlContactList" runat="server" Width="100%">
                <table class="popuptable" cellspacing="0" cellpadding="0" width="400px" border="0"
                    align="center">
                    <tbody>
                        <tr>
                            <td align="center">
                                <asp:UpdateProgress ID="UpdateProgress5" runat="server" DisplayAfter="3">
                                    <ProgressTemplate>
                                        <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                    <tbody>
                                        <tr>
                                            <td style="font-weight: bold; color: #F2635F; font-size: 14px;">
                                                Select Contacts
                                            </td>
                                            <td align="right">
                                                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/popup_close.gif"
                                                    CausesValidation="false"></asp:ImageButton>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-right: 10px;">
                                <div style="overflow-y: auto; max-height: 320px; border: 1px solid #F2635F;">
                                    <asp:GridView runat="server" ID="gveContacts" AutoGenerateColumns="False" Width="50%"
                                        Height="30%" ShowHeader="true" ForeColor="#333333" GridLines="None">
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="left">
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="chkSelectAll" runat="server" Text="Select All" AutoPostBack="false"
                                                        onclick="SelectAll(this);"></asp:CheckBox>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkContacts" runat="server" AutoPostBack="false" onclick="checkItem_All(this,0)" />
                                                    <asp:Label ID="lblFCName" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
                                                    <asp:Label ID="lblLCName" runat="server" Text='<%# Bind("LastName") %>'></asp:Label><br />
                                                    <asp:Label ID="lblCEmail" name='LstEmailIds' runat="server" Text='<%# Bind("EmailID") %>'
                                                        Style="padding-left: 25px;"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblContactID" runat="server" Text='<%# Bind("ContactID") %>' Visible="false"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            No contacts found
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <br />
                                <asp:Button ID="btnContactSubmit" runat="server" Text="Submit" CssClass="HelpButton"
                                    OnClick="btnContactSubmit_Click" OnClientClick="return getValues();" border="0" />
                                <asp:HiddenField ID="chkcount" runat="server" Value="0" />
                                <asp:HiddenField ID="txtvalue" runat="server" Value="" />
                                <br />
                                <br />
                            </td>
                        </tr>
                    </tbody>
                </table>
            </asp:Panel>
            <script type="text/javascript">

                function ConfirmationWindow() {

                    if ($("#<%=hdnIsBlocked.ClientID %>").val() == "0") {
                        return confirm("Are you sure you want to block?");
                    }
                    else {
                        return confirm("Are you sure you want to unblock?");
                    }
                }


                function ReplyPopup() {
                    var ReplyPopupcontrol = $find("popupReplyContent");
                    var replyMailId = $("#<%=lblContactEmailID.ClientID %>").text();
                    $("#<%=lblReplyEmailId.ClientID %>").text(replyMailId);
                    $("#<%=txtReplyNotes.ClientID %>").val("").focus();
                    ReplyPopupcontrol.show();
                }

                function CloseReplyPopup(Closetype) {

                    var ReplyPopupcontrol = $find("popupReplyContent"); //$find("<%=popReply.ClientID %>").show();
                    ReplyPopupcontrol.hide();
                    if (Closetype == "cancel") {
                        $('#<%=lblReplyNotesLength.ClientID %>').text(500);
                        return false;
                    }
                    else {
                        var Eid = $("#<%=lblReplyEmailId.ClientID %>").val();
                        $("#<%=hdnEmailIds.ClientID %> ").val(Eid);
                        return true;
                    }

                }

                var btnType;
                var mhIDs;
                $(document).ready(function () {

                    LoadControls();

                });
                function printMessageDetails() {
                    var QueryStringValues = $("#<%=hdnQueryStringParms.ClientID %>").val();
                    var url = "PrintMessageDetails.aspx?BT=" + QueryStringValues.split("|")[0] + "&MHID=" + QueryStringValues.split("|")[1];
                    window.open(url, "", "height=420,width=600");
                }
                function GetAssociateUsers() {
                    var emailIdsString = $("#<%=hdnAssociateUsers.ClientID %>").val();
                    document.getElementById("my-selectEmailIds").options.length = 0;
                    document.getElementById("my-selectEmailIds").focus();
                    var list = emailIdsString.split(',');
                    for (i = 0; i < list.length; i++) {
                        $('#my-selectEmailIds').append($("<option></option>").attr("value", list[i]).text(list[i]));
                    } //

                }
                function ShowImageGallary() {
                    document.getElementById('DIDIFrm').innerHTML = "";
                    ifrm = document.createElement("IFRAME");

                    if ('<%=ButtonType %>' == "Tips" || '<%=ButtonType %>' == "Contact")
                        ifrm.setAttribute("src", "ImageGallery.aspx?TipsimgName=" + document.getElementById("<%=hdnImageName.ClientID %>").value);
                    else if ('<%=ButtonType %>' == "PublicCallAddOns")
                        ifrm.setAttribute("src", "ImageGallery.aspx?SmartConnectimgName=" + document.getElementById("<%=hdnImageName.ClientID %>").value);
                    else
                        ifrm.setAttribute("src", "ImageGallery.aspx?PSCimgName=" + document.getElementById("<%=hdnImageName.ClientID %>").value);

                    ifrm.style.height = "650px";
                    ifrm.style.width = "100%";
                    ifrm.style.border = "0px";
                    ifrm.scrolling = "no";
                    ifrm.frameBorder = "0";
                    document.getElementById('DIDIFrm').appendChild(ifrm);

                    var modalDialog = $find("popupimage");
                    modalDialog.show();

                    return false;
                }


                function ValidateDetails() {
                    if (Page_ClientValidate("SV")) {
                        //$("#<%=hdnEmailIds.ClientID %>").val($('#my-selectEmailIds').val());
                        $("#<%=hdnEmailIds.ClientID %>").val($('#<%=txtEMailIds.ClientID %>').val());
                        if (($("#<%=hdnEmailIds.ClientID %>").val() == "" && $("#<%=chkNotify.ClientID %>").is(":checked"))) {
                            alert("Please enter at least one email id.");
                            return false;
                        }
                        return true;
                    }
                    else {
                        return false;
                    }
                }

                function ValidateReplyNotesDetails() {
                    if (Page_ClientValidate("replyNotes")) {
                        return true;
                    }
                    else {
                        return false;
                    }
                }

                var prm = Sys.WebForms.PageRequestManager.getInstance();
                prm.add_endRequest(function () {
                    LoadControls();

                    var maxlength = 500;
                    //alert($("#<%=txtNotes.ClientID %>").val().length);
                    document.getElementById('<%=lblLength.ClientID %>').innerHTML = maxlength - $("#<%=txtNotes.ClientID %>").val().length;
                    document.getElementById('<%=lblReplyNotesLength.ClientID %>').innerHTML = maxlength - $("#<%=txtReplyNotes.ClientID %>").val().length;
                });

                function LoadControls() {

                    var buttontype = '<%=ButtonType %>';

                    $("#<%=chkNotify.ClientID %>").click(function () {
                        if ($(this).is(":checked")) {
                            document.getElementById("my-selectEmailIds").focus();

                            if (buttontype == 'PublicCallAddOns' || buttontype == 'PrivateSmartConnectAddOns')
                                document.getElementById('<%=lnkSelectContacts.ClientID %>').style.display = 'block';
                            //$("#my-selectEmailIds").attr("disabled", false);
                            document.getElementById('<%= txtEMailIds.ClientID %>').value = "";

                            $("#<%=txtEMailIds.ClientID %>").attr("disabled", false);
                            $("#DivEmailIds").css("display", "block");
                            $("#dummy").css("display", "none");
                        }
                        else if ($(this).is(":not(:checked)")) {
                            //$("#my-selectEmailIds").attr("disabled", true);
                            document.getElementById('<%=lnkSelectContacts.ClientID %>').style.display = 'none';
                            $("#<%=txtEMailIds.ClientID %>").attr("disabled", true);
                            $("#DivEmailIds").css("display", "none");
                            $("#dummy").css("display", "block");
                            document.getElementById('<%= txtEMailIds.ClientID %>').value = "";
                        }
                    });
                    if ($("#ctl00_ctl00_cphUser_cphUser_chkNotify").is(":checked")) {
                        if (buttontype == 'PublicCallAddOns' || buttontype == 'PrivateSmartConnectAddOns') {
                            document.getElementById('<%=lnkSelectContacts.ClientID %>').style.display = 'block';
                            $("#<%=txtEMailIds.ClientID %>").attr("disabled", false);
                        }
                    }
                    else {
                        document.getElementById('<%=lnkSelectContacts.ClientID %>').style.display = 'none';
                    }
                    // initialize sol
                    $('#my-selectEmailIds').searchableOptionList({
                        showSelectAll: true
                    });

                } //
                function CountMaxLength(id, text, e) {
                    var maxlength = 500;
                    var myRegExp = new RegExp(/^[^<&]+$/);   //(/^[a-zA-Z0-9\-\.\'\,]+$/);            
                    if (myRegExp.test(id.value)) {
                        if (id.value.length > maxlength) {
                            id.value = id.value.substring(0, maxlength);
                            alert('You have exceeded the maximum of ' + maxlength + ' characters for ' + text + '.');
                        }
                        document.getElementById('<%=lblLength.ClientID %>').innerHTML = maxlength - id.value.length;
                        return true;
                    }
                }

                function ReplyNotes_CountMaxLength(id, text, e) {
                    var maxlength = 500;
                    var myRegExp = new RegExp(/^[^<&]+$/);   //(/^[a-zA-Z0-9\-\.\'\,]+$/);            
                    if (myRegExp.test(id.value)) {
                        if (id.value.length > maxlength) {
                            id.value = id.value.substring(0, maxlength);
                            alert('You have exceeded the maximum of ' + maxlength + ' characters for ' + text + '.');
                        }
                        document.getElementById('<%=lblReplyNotesLength.ClientID %>').innerHTML = maxlength - id.value.length;
                        return true;
                    }
                }

            </script>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
