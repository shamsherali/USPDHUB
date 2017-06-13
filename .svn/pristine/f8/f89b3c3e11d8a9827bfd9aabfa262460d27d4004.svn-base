<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HelpControl.ascx.cs"
    Inherits="USPDHUB.Controls.HelpControl" %>
<style type="text/css">
    .controlcontent
    {
        font-size: 14px;
        font-family: Arial, Helvetica, sans-serif;
        padding-bottom: 5px;
    }
    .treeview
    {        
        margin-left: 5px;        
    }
    .treeview a
    {
        color: #000000;
        text-decoration: none;
    }
    .treeview a:hover
    {
        text-decoration: none;
    }
    .treeview .helphighlights
    {
        font-size: 14px;
        background-color: #CCE6FF;
        margin: 0px;
        padding: 2px 0px;
    }
    .HelpBox
    {
        width: 370px;
        height: 20px;
        border: solid 1px #F0F0F0;
        padding: 5px;
        background-color: #FFFFFF;
        outline: none;
        color: #474747;
        border: 1px solid #5d6061;
    }
    .HelpButton
    {
        -webkit-border-radius: 2;
        -moz-border-radius: 2;
        border-radius: 2px;
        font-family: Arial;
        border: solid #5d6061 2px;
        color: #ffffff;
        font-size: 14px;
        background: #5c5f61;
        padding: 4px 8px 4px 8px;
        text-decoration: none;
    }
</style>
<asp:UpdatePanel ID="uppnlpopuphelp" runat="server" UpdateMode="Conditional">
    <Triggers>
        <asp:PostBackTrigger ControlID="lnkHelpDownloadCtrl" />
    </Triggers>
    <ContentTemplate>
        <div class="controlcontent">
            <asp:Panel ID="pnlContentCtrl" runat="server" Width="100%">
                <div width="100%" style="word-wrap: break-word;">
                    <table width="95%" border="0" cellpadding="0" cellspacing="0" class="linkcolor">
                        <tr>
                            <td align="right" style="padding-left: 8px;">
                                <table id="tblhelpmenu" cellpadding="0" cellspacing="0" border="0" style="padding-top: 10px;">
                                    <tr>
                                        <td>
                                            <a href="javascript:ShowHelpMenu();">
                                                <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/mpgotomenu.gif")%>" alt="" /></a>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="padding-left: 8px; padding-top: 10px; padding-bottom: 10px;"
                                class="linkcolor">
                                <div width="100%" id="divtoprintCtrl">
                                    <asp:Label ID="lblcontentCtrl" runat="server"></asp:Label><br />
                                    <asp:Label ID="lblvideoheadingCtrl" runat="server"></asp:Label><br />
                                    <asp:Label ID="lblvideoCtrl" runat="server" CssClass=""></asp:Label></div>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <table cellpadding="0" cellspacing="0" border="0">
                                    <tr>
                                        <td>
                                            <a href="javascript:PrintHelpContent();">
                                                <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/mpprint.gif")%>" /></a>
                                            <asp:LinkButton ID="lnkHelpDownloadCtrl" runat="server" OnClick="lnkHelpDownloadCtrl_OnClick"
                                                CausesValidation="false"><img src="<%=Page.ResolveClientUrl("~/images/Dashboard/DownloadHelp.jpg")%>" /></asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlGuideCtrl" runat="server" Width="100%" CssClass="noprint">
                <table style="background-color: #F0F3F4;" width="100%" border="0" cellpadding="0"
                    cellspacing="0">
                    <tr>
                        <td align="center">
                            <asp:UpdateProgress ID="UpdateProgress2" runat="server" DisplayAfter="3">
                                <ProgressTemplate>
                                    <img src="<%=Page.ResolveClientUrl("~/images/popup_ajax-loader.gif")%>" border="0" /><b><font
                                        color="green">Processing....</font></b>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </td>
                    </tr>
                </table>
                <table align="left" style="padding: 10px 0px 10px 20px;">
                    <colgroup>
                        <col width="70%" />
                        <col width="*" />
                    </colgroup>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtHelpSearch" runat="server" CssClass="HelpBox"></asp:TextBox>
                        </td>
                        <td valign="middle">
                            <asp:Button ID="btnHelpSearchCtrl" runat="server" Text="Search" OnClick="btnHelpSearchCtrl_Click"
                                CssClass="HelpButton" />
                            <asp:Button ID="btnHelpClearCtrl" runat="server" Text="Clear" OnClick="btnHelpClearCtrl_Click"
                                CssClass="HelpButton" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblNoHelpMsgCtrl" runat="server" Font-Size="12px" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                </table>
                <div width="100%" style="word-wrap: break-word; background-color: #F0F3F4;">
                    <table width="95%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="left">
                                <asp:TreeView ID="TVHelpCtrl" runat="server" CssClass="treeview">
                                </asp:TreeView>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblNoHelpCtrl" runat="server" Style="color: Green; font-size: 16px;"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlemailCtrl" runat="server" CssClass="noprint">
                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="mp-title">
                    <tr>
                        <td>
                        </td>
                        <td class="close">
                            <a href="javascript:Hidepopup()">
                                <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/mp-close.gif")%>" /></a>
                        </td>
                    </tr>
                </table>
                <table width="95%" border="0" cellpadding="0" cellspacing="0" style="word-wrap: break-word;
                    background-color: #F0F3F4;">
                    <tr>
                        <td colspan="2" style="padding-top: 5px;">
                            <asp:Label ID="lblhelpmsgCtrl" runat="server" ForeColor="green"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top: 5px;">
                            Enter Email ID:
                        </td>
                        <td style="padding-top: 5px;">
                            <asp:TextBox ID="txtemailCtrl" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="reqMovinggroup" runat="server" ControlToValidate="txtemailCtrl"
                                ValidationGroup="Help">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtemailCtrl"
                                ErrorMessage="Invalid Email format" Font-Size="XX-Small" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                ValidationGroup="Help"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top: 10px; padding-left: 100px; padding-right: 100px;" colspan="2">
                            <asp:ImageButton ID="btnsendCtrl" OnClick="btnsendCtrl_Click" runat="server" ValidationGroup="Help"
                                ImageUrl="~/images/Dashboard/mpsend.gif" />
                            <a href="javascript:displayemailpanel(0)">
                                <img src="<%= Page.ResolveClientUrl("~/images/Dashboard/mpback.gif")%>" /></a>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:HiddenField ID="hdnhelpTextCtrl" runat="server" />
<asp:HiddenField ID="hdnhelpvideoCtrl" runat="server" />
<asp:HiddenField ID="hdnhelpnameCtrl" runat="server" />
<asp:HiddenField ID="hdnhelpIDCtrl" runat="server" />
<asp:HiddenField ID="hdnhelpKeywordCtrl" runat="server" />
<script type="text/javascript">
    var Title11 = "";
    var DivID11 = "";
    var DivVideo11 = "";
    function ModalHelpPopup(Title1, DivID, divvideo) {
        Title11 = Title1;
        DivID11 = DivID;
        DivVideo11 = divvideo;
        document.getElementById('<%=hdnhelpIDCtrl.ClientID %>').value = DivID11;
        PageMethods.GetHelpcontentbyHelpID(DivID, GetHelpcontentbyHelpID_Success, GetHelpcontentbyHelpID_Failure);
    }

    function GetHelpcontentbyHelpID_Success(result) {
        var searchKeyword = "";
        var Divtxt1 = result;
        Divtxt1 = Divtxt1.replace(/__/g, "");
        var content = Divtxt1.replace(/</g, "&lt;");
        content = content.replace(/>/g, "&gt;");
        document.getElementById('<%=hdnhelpTextCtrl.ClientID %>').value = content;
        document.getElementById('<%=hdnhelpnameCtrl.ClientID %>').value = Title11;
        document.getElementById('<%=hdnhelpvideoCtrl.ClientID %>').value = DivVideo11;
        var Divtxt2 = Divtxt1.replace(/;/g, "~");
        Divtxt2 = Divtxt2.replace(/‘/g, "'");
        Divtxt2 = Divtxt2.replace(/’/g, "'");


        if (document.getElementById('<%=hdnhelpKeywordCtrl.ClientID %>').value != "")
            searchKeyword = document.getElementById('<%=hdnhelpKeywordCtrl.ClientID %>').value;

        var showcontent = document.getElementById('<%=hdnhelpTextCtrl.ClientID %>').value;
        showcontent = showcontent.replace(/&lt;/g, "<");
        showcontent = showcontent.replace(/&gt;/g, ">");
        document.getElementById('<%=lblcontentCtrl.ClientID %>').innerHTML = showcontent.replace(searchKeyword, '<span style="background-color:#CCE9FF;">' + searchKeyword + '</span>');
        if (document.getElementById('<%=hdnhelpvideoCtrl.ClientID %>').value != "") {
            document.getElementById('<%=lblvideoheadingCtrl.ClientID %>').innerHTML = "Looking for demonstration? Watch the video:";
            document.getElementById('<%=lblvideoCtrl.ClientID %>').innerHTML = divvideo11;
        }
        else {
            document.getElementById('<%=lblvideoheadingCtrl.ClientID %>').innerHTML = "";
            document.getElementById('<%=lblvideoCtrl.ClientID %>').innerHTML = "";
        }
        setTimeout("hidePop()", 0.5);
        setTimeout("displayPop()", 0.5);
    }
    function GetHelpcontentbyHelpID_Failure()
    { }
    function hidePop() {
        document.getElementById('<%=pnlGuideCtrl.ClientID %>').style.display = "none";
        document.getElementById('<%=pnlemailCtrl.ClientID %>').style.display = "none";

    }
    function displayPop() {
        document.getElementById('<%=pnlContentCtrl.ClientID %>').style.display = "inline";
    }
    function displayemailpanel(value) {
        if (document.getElementById('<%=hdnhelpnameCtrl.ClientID %>') != null && document.getElementById('<%=hdnhelpTextCtrl.ClientID %>') != null) {
            var content = document.getElementById('<%=hdnhelpTextCtrl.ClientID %>').value;
            content = content.replace(/&lt;/g, "<");
            content = content.replace(/&gt;/g, ">");
            document.getElementById('<%=lblcontentCtrl.ClientID %>').innerHTML = content;
            if (document.getElementById('<%=hdnhelpvideoCtrl.ClientID %>').value != "") {
                document.getElementById('<%=lblvideoheadingCtrl.ClientID %>').innerHTML = "Looking for demonstration? watch video:";
                document.getElementById('<%=lblvideoCtrl.ClientID %>').innerHTML = document.getElementById('<%=hdnhelpvideoCtrl.ClientID %>').value;
            }
            else {
                document.getElementById('<%=lblvideoheadingCtrl.ClientID %>').innerHTML = "";
                document.getElementById('<%=lblvideoCtrl.ClientID %>').innerHTML = "";
            }

            if (value != 1) {
                document.getElementById('<%=lblhelpmsgCtrl.ClientID %>').innerHTML = "";
                document.getElementById('<%=txtemailCtrl.ClientID %>').value = "";
                document.getElementById('<%=pnlemailCtrl.ClientID %>').style.display = "none";
                document.getElementById('<%=pnlContentCtrl.ClientID %>').style.display = "inline";
                document.getElementById('<%=pnlGuideCtrl.ClientID %>').style.display = "none";
            }
            else {
                document.getElementById('<%=pnlemailCtrl.ClientID %>').style.display = "inline";
                document.getElementById('<%=pnlContentCtrl.ClientID %>').style.display = "none";
                document.getElementById('<%=pnlGuideCtrl.ClientID %>').style.display = "none";
            }
        }
    }
    function ShowHelpMenu() {
        document.getElementById('<%=pnlContentCtrl.ClientID %>').style.display = "none";
        document.getElementById('<%=pnlGuideCtrl.ClientID %>').style.display = "inline";
        document.getElementById('<%=pnlemailCtrl.ClientID %>').style.display = "none";
    }
    function PrintHelpContent() {
        var DocumentContainer = document.getElementById('divtoprintCtrl');
        var WindowObject = window.open('', "PrintWindow", "width=420,height=380,top=50,left=50,toolbars=no,scrollbars=yes,status=no,resizable=yes");
        WindowObject.document.writeln("<div style='width:540px;'>" + DocumentContainer.innerHTML + "</div>");
        WindowObject.document.close();
        WindowObject.focus();
        WindowObject.print();
        WindowObject.close();
    }
</script>
