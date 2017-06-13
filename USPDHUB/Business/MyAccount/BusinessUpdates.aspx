<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/PaidTools.master"
    Inherits="Business_MyAccount_BusinessUpdates" Codebehind="BusinessUpdates.aspx.cs" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Login.ascx" TagName="Login" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/WowAds.ascx" TagName="wowads" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/Sitemaplinks.ascx" TagName="wowmap" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="Server">
    <style type="text/css">
        .datagrid2 th a
        {
            text-decoration: none !important;
            border-bottom: 1px solid #FFF;
            color: #FFF !important;
        }
        .datagrid2 th a:hover
        {
            color: #FFF !important;
        }
    </style>
    <script language="JavaScript1.2" src="<%=System.Configuration.ConfigurationManager.AppSettings.Get("SRootPath")%>/Scripts/main.js"
        type="text/javascript"></script>
    <script language="JavaScript1.2" src="<%=System.Configuration.ConfigurationManager.AppSettings.Get("SRootPath")%>/Scripts/dashboardstyle.js"
        type="text/javascript">        function TABLE1_onclick() {

        }

    </script>
    <script type="text/javascript">
        function GetThis(T, C, U) {
            var targetUrl = 'http://www.myspace.com/index.cfm?fuseaction=postto&t=' + encodeURIComponent(T) + '&c=' + encodeURIComponent(C) + '&u=' + encodeURIComponent(U);
            window.open(targetUrl).focus();
        }
        function openEmailwindow(url) {
            window.open(url, '', "width=700,height=650,scrollbars=no,toolbars=yes,status=yes,resizable=yes").focus();
        }
    </script>
    <script type="text/javascript">
        var CollapseImage = 'minus.gif';
        var ExpandImage = 'plus.gif';
        function toggleMe(a, image) {
            var e = document.getElementById(a);
            var img = document.getElementById(image);
            if (!e) return true;
            if (e.style.display == "none") {
                e.style.display = "";
                img.src = CollapseImage;
                img.title = "Collapse";
            }
            else {
                e.style.display = "none";
                img.src = ExpandImage;
                img.title = "Expand";
            }
            if (document.getElementById('<%=hdndivID.ClientID%>').value != "" && document.getElementById('<%=hdnimgID.ClientID%>').value !== "") {
                if (a != document.getElementById('<%=hdndivID.ClientID%>').value && image != document.getElementById('<%=hdnimgID.ClientID%>')) {
                    var dvid = document.getElementById('<%=hdndivID.ClientID%>').value;
                    var imgid = document.getElementById('<%=hdnimgID.ClientID%>').value;
                    var e1 = document.getElementById(dvid);
                    var img1 = document.getElementById(imgid);
                    e1.style.display = "none";
                    img1.src = ExpandImage;
                    img1.title = "Expand";
                }
            }
            document.getElementById('<%=hdndivID.ClientID%>').value = a;
            document.getElementById('<%=hdnimgID.ClientID%>').value = image;
            return true;
        }

        function Confirmation(ctrl) {
            if (ctrl.innerHTML == 'Active')
                return confirm('Are you sure you want to inactivate this update?');
            else
                return confirm('Are you sure you want to activate this update?');
        }
    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="page-top" cellspacing="0" cellpadding="0" width="100%" border="0">
                <tbody>
                    <tr>
                        <td>
                            <table style="width: 100%" cellspacing="0" cellpadding="10" border="0">
                                <tbody>
                                    <tr>
                                        <td style="width: 933px">
                                            <uc3:wowmap ID="sitemaplinks" runat="server"></uc3:wowmap>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table class="page-title" cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td>
                                            <img height="32" src='<%=System.Configuration.ConfigurationManager.AppSettings.Get("SRootPath")%>/images/icon_updatebusiness32.gif'
                                                width="31" />Updates Management
                                        </td>
                                        <td style="padding-right: 70px">
                                            <asp:UpdateProgress ID="UpdateProgress6" runat="server" DisplayAfter="3">
                                                <ProgressTemplate>
                                                    <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table class="margin-top" cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td>
                                            <img height="28" src='<%=System.Configuration.ConfigurationManager.AppSettings.Get("RootPath")%>/Images/head-left.gif'
                                                width="9" />
                                        </td>
                                        <td class="new-header">
                                            Update
                                        </td>
                                        <td>
                                            <img height="28" src='<%=System.Configuration.ConfigurationManager.AppSettings.Get("RootPath")%>/Images/head-right.gif'
                                                width="9" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table class="profile-inputbrdr" cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td>
                                            <table cellspacing="0" cellpadding="0" border="0">
                                                <tbody>
                                                    <tr>
                                                        <td>
                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                <tbody>
                                                                    <tr>
                                                                        <td style="font-size: 14px" align="center">
                                                                            <asp:Label ID="lblmess" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                <%-- <colgroup>
                                                                            <col width="25" />
                                                                            <col width="50" />
                                                                            <col width="25" />
                                                                            <col width="50" />
                                                                            <col width="25" />
                                                                            <col width="*" />
                                                                        </colgroup>--%>
                                                                                <tbody>
                                                                                    <tr id="Iconhide" runat="server">
                                                                                        <td class="img" width="30">
                                                                                            <img title="Send" src="../../Images/news_sendicon.png" border="0" />
                                                                                        </td>
                                                                                        <td class="img" width="40">
                                                                                            Send
                                                                                        </td>
                                                                                        <td class="img" width="30">
                                                                                            <img title="Edit" src="../../Images/news_editicon.png" border="0" />
                                                                                        </td>
                                                                                        <td class="img" width="30">
                                                                                            Edit
                                                                                        </td>
                                                                                        <td class="img" width="30">
                                                                                            <img title="Delete" height="25" src="../../Images/icon_delete.gif" border="0" />
                                                                                        </td>
                                                                                        <td class="img" width="48">
                                                                                            Delete
                                                                                        </td>
                                                                                        <td class="img" width="30">
                                                                                            <img title="Cancel" src="../../Images/inprogress.gif" border="0" />
                                                                                        </td>
                                                                                        <td class="img" width="*">
                                                                                            Cancel
                                                                                        </td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </td>
                                                                        <td style="padding-right: 16px; height: 24px" class="align-right">
                                                                            <%-- <asp:Button ID="Button2" runat="server" Text="Add New Update" PostBackUrl="~/Business/MyAccount/ModifyBusinessUpdate.aspx"
                                                        Font-Size="10pt" />--%>
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                <tbody>
                                                                    <tr>
                                                                        <td style="padding-bottom: 20px; padding-top: 20px">
                                                                            <asp:Label ID="lblsharetxt" runat="server" Text="Note: Please click the 'Share' link to share your Update."></asp:Label>
                                                                            <br />
                                                                            <asp:GridView ID="GrdbusinessUpdates" runat="server" PageSize="10" AllowPaging="True"
                                                                                OnPageIndexChanging="GrdbusinessUpdates_PageIndexChanging" ForeColor="Black"
                                                                                EmptyDataText="" OnRowDataBound="GrdbusinessUpdates_RowDataBound" DataKeyNames="UpdateId"
                                                                                GridLines="None" AutoGenerateColumns="False" CssClass="datagrid2" Width="100%"
                                                                                OnSorting="GrdbusinessUpdates_Sorting" AllowSorting="True">
                                                                                <EmptyDataRowStyle ForeColor="Red"></EmptyDataRowStyle>
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="Update Title" SortExpression="Name">
                                                                                        <ItemTemplate>
                                                                                            <table border="0" cellpadding="0" cellspacing="0">
                                                                                                <tr>
                                                                                                    <td style="border: 0px;" nowrap="nowrap">
                                                                                                        <asp:Image ID="imgTab" runat="server" ImageUrl="~/images/plus.gif" ToolTip="Expand" />
                                                                                                        <span style="font-size: 12px; color: #005AA0;"><strong>
                                                                                                            <asp:Label ID="lblshare" runat="server"></asp:Label>&nbsp;&nbsp;</strong></span><div
                                                                                                                runat="server" id="para1" style="display: none">
                                                                                                                <asp:Label ID="lbl_hare" runat="server" Text='<%# GetSharestrings((int)Eval("UpdateID"),(string)Eval("UpdateTitle")) %>'></asp:Label></div>
                                                                                                    </td>
                                                                                                    <td style="border: 0px;" valign="top">
                                                                                                        <asp:LinkButton ID="lnkUpdateName" OnClick="lnkUpdateName_Click" Text='<%#Eval("UpdateTitle") %>'
                                                                                                            runat="server" CommandArgument='<%#Eval("UpdateId") %>'></asp:LinkButton>
                                                                                                        <asp:LinkButton Style="font-weight: bold; color: blue; font-family: verdana" ID="lnkruncampaion"
                                                                                                            OnClick="lblhistroy_Click" runat="server" Text="<font style='color:#0b689d;'>(Campaign in progress report)</font>"
                                                                                                            CommandArgument='<%#Eval("UpdateId") %>'></asp:LinkButton>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle Width="300px"></ItemStyle>
                                                                                    </asp:TemplateField>
                                                                                    <asp:BoundField DataField="UpdateTime" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Posted on"
                                                                                        HtmlEncode="False" SortExpression="UpdateTime">
                                                                                        <ItemStyle HorizontalAlign="Center" Width="94px"></ItemStyle>
                                                                                    </asp:BoundField>
                                                                                    <asp:TemplateField HeaderText="Count">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblsent" runat="server"></asp:Label>
                                                                                            <asp:LinkButton ID="lblhistroy" runat="server" Text="<img src='../../Images/news_detailsicon.png' title='Details' border='0' width='25px' height='25px'>"
                                                                                                OnClick="lblhistroy_Click" CommandArgument='<%#Eval("UpdateId") %>'></asp:LinkButton>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle Width="47px" HorizontalAlign="Center"></ItemStyle>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Opened">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblopened" runat="server"></asp:Label>
                                                                                            <asp:LinkButton ID="lnkopen" runat="server" CommandArgument='<%# Bind("UpdateId") %>'
                                                                                                OnClick="lnkopen_Click" CausesValidation="false"></asp:LinkButton>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle Width="48px" HorizontalAlign="Center"></ItemStyle>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Opt-outs">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lboptout" runat="server"></asp:Label>
                                                                                            <asp:LinkButton ID="lnkoptout" runat="server" CommandArgument='<%# Bind("UpdateId") %>'
                                                                                                OnClick="lnkoptout_Click" CausesValidation="false"></asp:LinkButton>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle Width="48px" HorizontalAlign="Center"></ItemStyle>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Status" SortExpression="Status">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblstatus" runat="server" Text='<%# Bind("Status") %>' Visible="False"></asp:Label>
                                                                                            <asp:LinkButton ID="lnkStatus" runat="server" CausesValidation="false" CommandArgument='<%# Bind("UpdateId") %>'
                                                                                                OnClientClick="return Confirmation(this);" OnClick="lnkStatus_Click"></asp:LinkButton>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle HorizontalAlign="Center" Width="58px"></ItemStyle>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Action">
                                                                                        <ItemTemplate>
                                                                                            <table cellspacing="0" cellpadding="0" width="100%">
                                                                                                <colgroup>
                                                                                                    <col width="25%" />
                                                                                                    <col width="25%" />
                                                                                                    <col width="25%" />
                                                                                                    <col width="*" />
                                                                                                </colgroup>
                                                                                                <tbody>
                                                                                                    <tr>
                                                                                                        <td style="border-right: 0px; border-top: 0px; border-left: 0px; border-bottom: 0px;">
                                                                                                            <asp:LinkButton ID="lblsentupdate" OnClick="lblsentupdate_Click" runat="server" Text="<img src='../../Images/news_sendicon.png' title='Send' border='0' width='25px' height='25px'>"
                                                                                                                CommandArgument='<%#Eval("UpdateId") %>'></asp:LinkButton>
                                                                                                            <%--    //Issue 938 <asp:Image ID="imginactive" ImageUrl="~/images/icon_question_blueinact.gif" Width="25"
                                                                                        Height="25" runat="server" ToolTip="Updates must be active in order to send. To make an Update active select the edit icon and select the 'Active' radio button and then select save.">
                                                                                    </asp:Image>--%>
                                                                                                        </td>
                                                                                                        <td style="border-right: 0px; border-top: 0px; border-left: 0px; border-bottom: 0px;">
                                                                                                            <asp:LinkButton ID="btnModify" runat="server" OnClick="btnModify_Click" Text="<img src='../../Images/news_editicon.png' title='Edit' border='0' width='25px' height='25px'>"
                                                                                                                ToolTip="Edit" Width="25px" Height="25px" CommandArgument='<%#Eval("UpdateId") %>'></asp:LinkButton>
                                                                                                        </td>
                                                                                                        <td style="border-right: 0px; border-top: 0px; border-left: 0px; border-bottom: 0px;">
                                                                                                            <asp:LinkButton ID="lnkdelete" runat="server" CommandArgument='<%# Bind("UpdateId") %>'
                                                                                                                OnClick="lnkdelete_Click" Text="<img src='../../Images/icon_delete.gif'width='25px' height='25px' title='Delete' border='0'"></asp:LinkButton>
                                                                                                        </td>
                                                                                                        <td style="border: 0px;">
                                                                                                            <asp:LinkButton ID="lnkHis" runat="server" CommandArgument='<%# Bind("UpdateId") %>'
                                                                                                                OnClick="lnkruncampaion_Click" Text="<img src='../../Images/inprogress.png'  title='Cancel' border='0'/>"
                                                                                                                CausesValidation="false" Style='vertical-align: bottom;'></asp:LinkButton>
                                                                                                            <asp:Image ID="imgcanceleventblank" runat="server" ImageUrl="~/images/Eventblank.gif"
                                                                                                                Width="25px" Height="25px" />
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </tbody>
                                                                                            </table>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                                <EmptyDataTemplate>
                                                                                    No updates found.
                                                                                </EmptyDataTemplate>
                                                                                <HeaderStyle CssClass="title1"></HeaderStyle>
                                                                            </asp:GridView>
                                                                            <asp:HiddenField ID="hdnsortdire" runat="server"></asp:HiddenField>
                                                                            <asp:HiddenField ID="hdnsortcount" runat="server"></asp:HiddenField>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                            <table id="TABLE1" onclick="return TABLE1_onclick()" cellspacing="0" cellpadding="0"
                                                                width="100%" border="0">
                                                                <tbody>
                                                                    <tr>
                                                                        <td style="width: 879px; height: 25px" align="left">
                                                                            &nbsp;<asp:Label ID="emptyLbl" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td style="width: 104px; padding-top: 10px; height: 25px" colspan="20">
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                            <table id="Table2" onclick="return TABLE1_onclick()" cellspacing="0" cellpadding="0"
                                                                width="100%" border="0">
                                                                <tbody>
                                                                    <tr>
                                                                        <td style="width: 879px; height: 25px" align="left">
                                                                            &nbsp;<asp:Label ID="errMsg" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td style="padding-right: 16px; width: 104px; padding-top: 10px; height: 25px" colspan="20">
                                                                            <%--<asp:Button ID="Button3" runat="server" Text="Add New Update" PostBackUrl="~/Business/MyAccount/ModifyBusinessUpdate.aspx"
                                                        Font-Size="10pt" />--%>
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                            <table class="profile-btntbl" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                <tbody>
                                                                    <tr>
                                                                        <td class="align-center">
                                                                            &nbsp;&nbsp;
                                                                            <asp:Button ID="btndashboard1" OnClick="btndashboard1_Click" runat="server" Text="Go to Dashboard"
                                                                                Font-Size="10pt" CausesValidation="false"></asp:Button>
                                                                            <asp:Button ID="btnwizard" OnClick="btnwizard_Click" runat="server" Text="Go to Setup Wizard"
                                                                                CausesValidation="false"></asp:Button>
                                                                            <%--<asp:Button ID="NoBusinessUpdatesBtn" runat="server" Text="Add New Update" PostBackUrl="~/Business/MyAccount/ModifyBusinessUpdate.aspx"
                                                        Font-Size="10pt" />--%>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>
            <asp:HiddenField ID="hdndivID" runat="server"></asp:HiddenField>
            <asp:HiddenField ID="hdnimgID" runat="server"></asp:HiddenField>
            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                <tbody>
                    <tr>
                        <td>
                            <asp:Label ID="lblp" runat="server" Visible="false"></asp:Label><asp:Label ID="lblc"
                                runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="lblc"
                                PopupControlID="pnlcoupsch" BackgroundCssClass="modal">
                            </cc1:ModalPopupExtender>
                            <asp:Panel Style="display: none" ID="pnlcoupsch" runat="server" Width="100%">
                                <table class="popuptable" cellspacing="0" cellpadding="0" width="800" align="center"
                                    border="0">
                                    <tbody>
                                        <tr>
                                            <td align="center">
                                                <asp:UpdateProgress ID="UpdateProgress3" runat="server" DisplayAfter="3">
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
                                                            <td class="header">
                                                                Campaign History <span style="color: maroon; font-family: Arial; size: 2"><span style="color: maroon;
                                                                    font-family: Arial; size: 2">
                                                                    <asp:Label ID="lblx" runat="server"></asp:Label>
                                                                </span></span>
                                                            </td>
                                                            <td align="right">
                                                                <asp:ImageButton ID="imglogin1" OnClick="imclose_Click" runat="server" CausesValidation="false"
                                                                    ImageUrl="~/images/popup_close.gif"></asp:ImageButton>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:GridView ID="grdschemail" runat="server" PageSize="10" AllowPaging="True" OnPageIndexChanging="grdschemail_PageIndexChanging"
                                                                    OnRowDataBound="grdschemail_RowDataBound" AutoGenerateColumns="False" CssClass="datagrid2"
                                                                    Width="100%">
                                                                    <EmptyDataRowStyle ForeColor="#C00000"></EmptyDataRowStyle>
                                                                    <Columns>
                                                                        <asp:TemplateField Visible="false">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("UpdateId") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="Sending_Date" HeaderText="Date" />
                                                                        <asp:TemplateField HeaderText="Scheduled Date" Visible="false">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("Schedule_Date") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="No of Emails per Day">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label4" runat="server"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Status">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("Sent_Flag") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <EmptyDataTemplate>
                                                                        No contacts found
                                                                    </EmptyDataTemplate>
                                                                    <HeaderStyle CssClass="title1"></HeaderStyle>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                To cancel your campaign, please click here &nbsp;&nbsp;<asp:Button ID="btnstopcampain"
                                                                    OnClick="btnstopcampain_Click" runat="server" Text="Cancel campaign" CausesValidation="false">
                                                                </asp:Button>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </tbody>
            </table>
            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                <tbody>
                    <tr>
                        <td>
                            <asp:Label ID="lblviewc" runat="server"></asp:Label>
                            <cc1:ModalPopupExtender ID="ModalPopupExtender3" runat="server" TargetControlID="lblviewc"
                                PopupControlID="pnlviewcouponsenthis" BackgroundCssClass="modal" CancelControlID="imglogin2">
                            </cc1:ModalPopupExtender>
                            <asp:Panel Style="display: none" ID="pnlviewcouponsenthis" runat="server" Width="100%">
                                <table class="popuptable" cellspacing="0" cellpadding="0" width="800" align="center"
                                    border="0">
                                    <tbody>
                                        <tr>
                                            <td align="center">
                                                <asp:UpdateProgress ID="UpdateProgress4" runat="server" DisplayAfter="3">
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
                                                            <td class="header">
                                                                Update History <span style="color: maroon; font-family: Arial; size: 2"><span style="color: maroon;
                                                                    font-family: Arial; size: 2">
                                                                    <asp:Label ID="lblviewsentnewlettername" runat="server"></asp:Label>
                                                                </span>
                                                            </td>
                                                            <td align="right">
                                                                <asp:ImageButton ID="imglogin2" runat="server" ImageUrl="~/images/popup_close.gif"
                                                                    CausesValidation="false"></asp:ImageButton>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:GridView ID="grdviewsenthis" runat="server" Width="100%" CssClass="datagrid2"
                                                                    AutoGenerateColumns="False" OnRowDataBound="grdviewsenthis_RowDataBound" PageSize="15"
                                                                    AllowPaging="True" OnPageIndexChanging="grdviewsenthis_PageIndexChanging">
                                                                    <EmptyDataRowStyle ForeColor="#C00000"></EmptyDataRowStyle>
                                                                    <Columns>
                                                                        <asp:BoundField DataField="Receiver_EmailID" HeaderText="Email IDs" />
                                                                        <asp:BoundField DataField="Sending_Date" HeaderText="Date" />
                                                                        <asp:TemplateField HeaderText="Status">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("Sent_Flag") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <EmptyDataTemplate>
                                                                        No contacts found
                                                                    </EmptyDataTemplate>
                                                                    <HeaderStyle CssClass="title1"></HeaderStyle>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </tbody>
            </table>
            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                <tbody>
                    <tr>
                        <td>
                            <asp:Label ID="lblpre" runat="server" visiable="false"></asp:Label>
                            <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="lblpre"
                                PopupControlID="pnlpopup1" BackgroundCssClass="modal">
                            </cc1:ModalPopupExtender>
                            <asp:Panel Style="display: none" ID="pnlpopup1" runat="server" Width="100%">
                                <table style="padding-left: 10px; background-color: white" cellspacing="0" cellpadding="0"
                                    width="740" align="center" border="0">
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
                                                <asp:ImageButton ID="imglogin5" OnClick="imclose_Click" runat="server" CausesValidation="false"
                                                    ImageUrl="~/images/popup_close.gif"></asp:ImageButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="font-weight: bold; font-size: 14px; padding-bottom: 10px; color: green;
                                                padding-top: 10px" align="left">
                                                <asp:Label ID="lblupdatename" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-right: 10px; padding-bottom: 20px">
                                                <div style="overflow: auto; position: relative; height: 500px">
                                                    <asp:Label ID="lblPreviewHTML" runat="server"></asp:Label>
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
            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                <tbody>
                    <tr>
                        <td>
                            <asp:Label ID="lbloptout" runat="server"></asp:Label>
                            <cc1:ModalPopupExtender ID="ModalPopupExtender10" runat="server" TargetControlID="lbloptout"
                                PopupControlID="pnlOptCout" BackgroundCssClass="modal">
                            </cc1:ModalPopupExtender>
                            <asp:Panel Style="display: none" ID="pnlOptCout" runat="server" Width="100%">
                                <table class="popuptable" cellspacing="0" cellpadding="0" width="800" align="center"
                                    border="0">
                                    <tbody>
                                        <tr>
                                            <td align="center">
                                                <asp:UpdateProgress ID="UpdateProgress8" runat="server" DisplayAfter="3">
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
                                                            <td class="header">
                                                                Updates Opt-Outs <span style="color: maroon; font-family: Arial; size: 2"></span>
                                                            </td>
                                                            <td align="right">
                                                                <asp:ImageButton ID="imglogin9" OnClick="imclose_Click" runat="server" ImageUrl="~/images/popup_close.gif"
                                                                    CausesValidation="false"></asp:ImageButton>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:GridView ID="grdoptouts" runat="server" Width="100%" CssClass="datagrid2" AutoGenerateColumns="False"
                                                                    PageSize="15" AllowPaging="True" OnPageIndexChanging="grdoptouts_PageIndexChanging">
                                                                    <EmptyDataRowStyle ForeColor="#C00000"></EmptyDataRowStyle>
                                                                    <Columns>
                                                                        <asp:BoundField DataField="Receiver_EmailID" HeaderText="Email ID" />
                                                                        <asp:BoundField DataField="Sending_Date" HeaderText="Date" />
                                                                        <asp:BoundField DataField="MODIFIED_DATE" HtmlEncode="false" DataFormatString="{0:MM/dd/yyyy}"
                                                                            HeaderText="Opt-outs Date" />
                                                                    </Columns>
                                                                    <EmptyDataTemplate>
                                                                        No contacts found
                                                                    </EmptyDataTemplate>
                                                                    <HeaderStyle CssClass="title1"></HeaderStyle>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </tbody>
            </table>
            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                <tbody>
                    <tr>
                        <td>
                            <asp:Label ID="lblmailopen" runat="server"></asp:Label>
                            <cc1:ModalPopupExtender ID="ModalPopupExtender4" runat="server" TargetControlID="lblmailopen"
                                PopupControlID="pnlmailopen" BackgroundCssClass="modal" CancelControlID="imglogin10">
                            </cc1:ModalPopupExtender>
                            <asp:Panel Style="display: none" ID="pnlmailopen" runat="server" Width="100%">
                                <table class="popuptable" cellspacing="0" cellpadding="0" width="800" align="center"
                                    border="0">
                                    <tbody>
                                        <tr>
                                            <td align="center">
                                                <asp:UpdateProgress ID="UpdateProgress9" runat="server" DisplayAfter="3">
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
                                                            <td class="header">
                                                                Campaign Opened Emails <span style="color: maroon; font-family: Arial; size: 2">
                                                                </span>
                                                            </td>
                                                            <td align="right">
                                                                <asp:ImageButton ID="imglogin10" runat="server" ImageUrl="~/images/popup_close.gif"
                                                                    CausesValidation="false"></asp:ImageButton>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:GridView ID="grdmailopen" runat="server" Width="100%" CssClass="datagrid2" AutoGenerateColumns="False"
                                                                    PageSize="15" AllowPaging="True" OnPageIndexChanging="grdmailopen_PageIndexChanging">
                                                                    <EmptyDataRowStyle ForeColor="#C00000"></EmptyDataRowStyle>
                                                                    <Columns>
                                                                        <asp:BoundField DataField="Receiver_EmailID" HeaderText="Email ID" />
                                                                        <asp:BoundField DataField="City_Name" HeaderText="City Name" />
                                                                        <asp:BoundField DataField="Country_Name" HeaderText="Country Name" />
                                                                        <asp:BoundField DataField="Browser" HeaderText="Browser" />
                                                                        <asp:BoundField DataField="Sending_Date" HeaderText="Date" />
                                                                        <asp:BoundField DataField="MODIFIED_DATE" HtmlEncode="false" HeaderText="Opened Date" />
                                                                    </Columns>
                                                                    <EmptyDataTemplate>
                                                                        No contacts found
                                                                    </EmptyDataTemplate>
                                                                    <HeaderStyle CssClass="title1"></HeaderStyle>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </tbody>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
