<%@ Page Title="" Language="C#" MasterPageFile="~/AdminHome.master" AutoEventWireup="true"
    CodeBehind="ActivityLog.aspx.cs" Inherits="USPDHUB.Admin.ActivityLog" ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <link href="../../css/Bulletins.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .modal
        {
            background-color: Gray;
            filter: alpha(opacity=90);
            opacity: 0.7;
        }
    </style>
    <script type="text/javascript">
        function ShowPreview() {
            var myBehavior = $find("popupop");
            var editor = $find("<%=RadEditor1.ClientID%>");
            var message = editor.get_html();
            $get('<%=lblPreview.ClientID %>').innerHTML = message;
            myBehavior.show();
            return false;
        }

        function ShowExTimeDiv() {
            if (document.getElementById("<%=txtExDate.ClientID %>").value == "") {
                document.getElementById("<%=txtExHours.ClientID %>").disabled = true;
                document.getElementById("<%=txtExMinutes.ClientID %>").disabled = true;
                document.getElementById("<%=ddlExSS.ClientID %>").disabled = true;
            }
            else {
                document.getElementById("<%=txtExHours.ClientID %>").disabled = false;
                document.getElementById("<%=txtExMinutes.ClientID %>").disabled = false;
                document.getElementById("<%=ddlExSS.ClientID %>").disabled = false;
            }
        }
        function OnTextChanged() {
            document.getElementById("hdnChanges").value = "true";
        }

        function checkExpiryValidation() {
            //ExDate checking
            if (document.getElementById("<%=txtExDate.ClientID %>").value != "") {
                var currentdate = new Date();
                var fromDate = document.getElementById("<%=txtExDate.ClientID %>").value;
                var selDate = new Date(fromDate);
                var selHours = 0;
                var selmins = 0;
                if (document.getElementById("<%=txtExHours.ClientID %>").value != '' && document.getElementById("<%=txtExHours.ClientID %>").value != 'Hour') {
                    selHours = parseInt(document.getElementById("<%=txtExHours.ClientID %>").value);
                    if (selHours > 12) {
                        alert("Invalid Date Format.");
                        return false;
                    }
                    if (document.getElementById("<%=ddlExSS.ClientID %>").value == 'AM' && selHours == 12)
                        selHours = 0;
                    if (document.getElementById("<%=ddlExSS.ClientID %>").value == 'PM' && selHours < 12)
                        selHours = 12;
                }
                if (document.getElementById("<%=txtExMinutes.ClientID %>").value != '' && document.getElementById("<%=txtExMinutes.ClientID %>").value != 'Minutes')
                    selmins = parseInt(document.getElementById("<%=txtExMinutes.ClientID %>").value);
                if (selmins >= 60) {
                    alert("Invalid Date Format.");
                    return false;
                }
                selDate.setHours(selHours, selmins, 0);
                if (selDate <= currentdate) {
                    alert('Expiration date should be later than current date.');
                    return false
                }
            }
        }

        function displayDomain() {
            if (document.getElementById("<%=rdbtnUser.ClientID %>").checked == true) {
                document.getElementById("<%=divDomain.ClientID %>").style.display = "none";
            }
            else {
                document.getElementById("<%=divDomain.ClientID %>").style.display = "block";
                document.getElementById("<%=lblSelectVertical.ClientID %>").style.display = "none"; 
            }
        }
        function OnClientPasteHtml(sender, args) {
            
            var commandName = args.get_commandName();
            var value = args.get_value();
            if (commandName == "MediaManager") {
                //See if an img has an alt tag set
                var div = document.createElement("DIV");
                //Do not use div.innerHTML as in IE this would cause the image's src or the link's href to be converted to absolute path.
                //This is a severe IE quirk.
                Telerik.Web.UI.Editor.Utils.setElementInnerHtml(div, value);
               
                var mediaString = div.innerHTML;
                mediaString = mediaString.replace("%3e%3cPARAM NAME%3d%22autoStart%22 VALUE%3d%22-1%22", "%3e%3cPARAM NAME%3d%22autoStart%22 VALUE%3d%220%22");
                //Set new content to be pasted into the editor
                args.set_value(mediaString);
            }

        }
       
    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server">
                <div id="wrapper">
                    <div class="headernav">
                        <asp:TextBox ID="txt" runat="server" Width="0" BorderStyle="none" BorderColor="white"
                            Style="border: 0; border-color: White!important;"></asp:TextBox>
                    </div>
                    <div style="text-align: center;">
                        <asp:Label ID="lblerror" runat="server" ForeColor="Green" Font-Size="14px"></asp:Label>
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="3">
                            <ProgressTemplate>
                                <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green"
                                    size="2">Processing....</font></b>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <div id="divLoading" style="display: none; width: 300px; margin: 0 auto;">
                            <div style="text-align: center;">
                                <img src="<%=Page.ResolveClientUrl("../../images/popup_ajax-loader.gif")%>" border="0" /><b><font
                                    color="green">Processing....</font></b>
                            </div>
                        </div>
                        <div style="width: 300px; margin: 0 auto;">
                            <asp:ValidationSummary ID="ValidateUserDetails" runat="server" Style="text-align: left;"
                                ValidationGroup="ABC" HeaderText="The following error(s) occurred:" />
                        </div>
                    </div>
                    <div class="clear">
                    </div>
                    <div class="contentwrap">
                        <div class="largetxt">
                            <asp:Label ID="lblHeading" runat="server" Text="News & Updates"></asp:Label>
                        </div>
                        <div class="fields_wrap" id="divUsers" style="display: none;" runat="server">
                            <br />
                            <br />
                            <asp:RadioButton ID="rdbtnUser" runat="server" GroupName="Users" Checked="true" onchange="displayDomain();" />
                            <asp:RadioButton ID="rdbtnAllUser" runat="server" GroupName="Users" Text="Select a Vertical"
                                onchange="displayDomain();" />
                            <br />
                            <br />
                        </div>
                        <div id="divDomain" style="display: block; width: 250px;" runat="server">
                            <br />
                            <asp:Label ID="lblSelectVertical" runat="server" Text="Select a Vertical" Style="float: left; display: block;"></asp:Label>
                            <asp:DropDownList ID="ddlDomainName" runat="server" Width="140px" Style="float: right;">
                            </asp:DropDownList>
                            <br />
                            <br />
                            <br />
                        </div>
                        <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />
                        <telerik:RadEditor ID="RadEditor1" runat="server" Width="100%" NewLineBr="False"
                            ContentAreaMode="Div" ToolsFile="Tools.xml" NewLineMode="P" EnableResize="false" OnClientPasteHtml="OnClientPasteHtml">
                            <ImageManager ViewPaths="~/Upload/ActivityLog/Images/" UploadPaths="~/Upload/ActivityLog/Images/"
                                DeletePaths="~/Upload/ActivityLog/Images/" EnableImageEditor="true" MaxUploadFileSize="2097152" />
                            <MediaManager ViewPaths="~/Upload/ActivityLog/Videos/" UploadPaths="~/Upload/ActivityLog/Videos/"
                                DeletePaths="~/Upload/ActivityLog/Videos/" MaxUploadFileSize="2097152" />
                            <CssFiles>
                                <telerik:EditorCssFile Value="EditorContentArea.css" />
                            </CssFiles>
                            <Content>
                            </Content>
                        </telerik:RadEditor>
                        <asp:RequiredFieldValidator ID="rfvEditor" runat="server" ControlToValidate="RadEditor1"
                            Display="Dynamic" ValidationGroup="ABC" ErrorMessage="Enter the Description">*</asp:RequiredFieldValidator>
                        <div>
                            <br />
                            <br />
                            <table width="70%" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width: 100px">
                                        Expiration Date & Time:
                                        <asp:TextBox ID="txtExDate" runat="server" Width="100px" onChange="ShowExTimeDiv();"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularDate" runat="server" ControlToValidate="txtExDate"
                                            ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                            ValidationGroup="ABC" ErrorMessage="Invalid Date Format">*</asp:RegularExpressionValidator><br />
                                        <cc1:CalendarExtender ID="calex" runat="server" TargetControlID="txtExDate" Format="MM/dd/yyyy"
                                            CssClass="MyCalendar" OnClientDateSelectionChanged="OnTextChanged" />
                                    </td>
                                    <td style="width: 50px">
                                        <asp:TextBox runat="server" ID="txtExHours" Width="50px" Enabled="False" MaxLength="2"></asp:TextBox>
                                        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender14" TargetControlID="txtExHours"
                                            WatermarkText="Hour" runat="server" WatermarkCssClass="watermarkbulletindate">
                                        </cc1:TextBoxWatermarkExtender>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" Display="Dynamic"
                                            ControlToValidate="txtExHours" ValidationExpression="^(1[0-2]|0?[1-9])" ValidationGroup="ABC"
                                            ErrorMessage="Invalid Time Format">*</asp:RegularExpressionValidator>
                                        &nbsp; &nbsp;
                                        <asp:TextBox runat="server" ID="txtExMinutes" Width="50px" Enabled="False" MaxLength="2"></asp:TextBox>
                                        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender15" TargetControlID="txtExMinutes"
                                            WatermarkText="Minutes" runat="server" WatermarkCssClass="watermarkbulletindate">
                                        </cc1:TextBoxWatermarkExtender>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Display="Dynamic"
                                            ControlToValidate="txtExMinutes" ValidationExpression="^[0-5]\d" ValidationGroup="ABC"
                                            ErrorMessage="Invalid Time Format">*</asp:RegularExpressionValidator>
                                    </td>
                                    <td style="width: 30px">
                                        &nbsp;
                                        <asp:DropDownList runat="server" ID="ddlExSS" Enabled="False" Width="60px">
                                            <asp:ListItem Text="AM" Value="AM" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="fields_wrap ">
                            <div class="right_fields" style="margin: 10px 0px 0px 220px; width: 430px;">
                                <asp:Button ID="btnCancel" runat="server" CausesValidation="false" border="0" CssClass="btn"
                                    Text="Cancel" OnClick="btnCancel_Click" />
                                <asp:Button ID="btnSave" runat="server" Text="Submit" CssClass="btn" border="0" OnClick="btnSave_Click"
                                    ValidationGroup="ABC" OnClientClick="return checkExpiryValidation();" />
                                <asp:Button ID="btnPreview" runat="server" Text="Preview" CssClass="btn" border="0"
                                    OnClientClick="return ShowPreview();" CausesValidation="false" />
                            </div>
                        </div>
                    </div>
                </div>
                <input type="hidden" id="hdnChanges" value="false" />
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tbody>
            <tr>
                <td>
                    <asp:Label ID="lblpre" runat="server" visiable="false"></asp:Label>
                    <cc1:ModalPopupExtender ID="MPEPreview" runat="server" TargetControlID="lblpre" PopupControlID="pnlpopup1"
                        BackgroundCssClass="modal" BehaviorID="popupop" CancelControlID="imglogin5">
                    </cc1:ModalPopupExtender>
                    <asp:Panel Style="display: none" ID="pnlpopup1" runat="server" Width="100%">
                        <table style="padding-left: 10px; background-color: white" cellspacing="0" cellpadding="0"
                            width="450" align="center" border="0">
                            <tbody>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:UpdateProgress ID="UpdateProgress7" runat="server" DisplayAfter="3">
                                            <ProgressTemplate>
                                                <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-right: 20px; padding-top: 10px" align="right">
                                        <asp:ImageButton ID="imglogin5" OnClientClick="return false;" runat="server" CausesValidation="false"
                                            ImageUrl="~/images/popup_close.gif"></asp:ImageButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-right: 10px; padding-bottom: 20px">
                                        <div style="overflow: auto; position: relative; height: 350px; border: 1px solid blue;">
                                            <asp:Label ID="lblPreview" runat="server"></asp:Label>
                                        </div>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
