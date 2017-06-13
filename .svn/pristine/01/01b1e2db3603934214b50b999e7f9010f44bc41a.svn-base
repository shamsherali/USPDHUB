<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="InquiryAlerts.aspx.cs"
    Inherits="USPDHUB.Business.MyAccount.InquiryAlerts" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="Server">
    <script type="text/javascript">
        function RedirectailTo() {
            var mailToUser = document.getElementById('<%=hdnSelectedContactMailID.ClientID %>').value;
            var mailTolink = "mailto:" + mailToUser;
            if (!document.getElementById('<%=RBNone.ClientID %>').checked) {
                mailTolink = mailTolink + "?body=" + $('#ctl00_cphUser_rbCList').find(":checked").val();
            }
            window.location.href = mailTolink;
            closeDivPopup();
            return false;
        }
        function chkSelectAll(headerchk, type) {
            var grdNewsletercheck = "";
            if (type == "BL")
                grdNewsletercheck = document.getElementById('<%=grdNewsletercontacts.ClientID%>');
            else if (type == "BU")
                grdNewsletercheck = document.getElementById('<%=grdUpdatescontacts.ClientID%>');
            else if (type == "EC")
                grdNewsletercheck = document.getElementById('<%=grdECcontacts.ClientID%>');
            else if (type == "CA")
                grdNewsletercheck = document.getElementById('<%=grdCAcontacts.ClientID%>');
            var i;
            if (headerchk.checked) {
                for (i = 0; i < grdNewsletercheck.rows.length; i++) {
                    var inputs = grdNewsletercheck.rows[i].getElementsByTagName('input');
                    inputs[0].checked = true;
                }
            }
            else {
                for (i = 0; i < grdNewsletercheck.rows.length; i++) {
                    var inputs = grdNewsletercheck.rows[i].getElementsByTagName('input');
                    inputs[0].checked = false;
                }
            }
        }

        function UnSelectHeaderCheckboxes(header, type) {
            var count = 0;
            var rowcount = 0;
            var itemCheckBox;
            var grdTipschec;
            if (type == "BL") {
                grdTipscheck = document.getElementById('<%=this.grdNewsletercontacts.ClientID%>');
                itemCheckBox = "chkBL";
            }
            else if (type == "BU") {
                grdTipscheck = document.getElementById('<%=this.grdUpdatescontacts.ClientID%>');
                itemCheckBox = "chkBU";
            }
            else if (type == "EC") {
                grdTipscheck = document.getElementById('<%=this.grdECcontacts.ClientID%>');
                itemCheckBox = "chkEC";
            }
            else if (type == "CA") {
                grdTipscheck = document.getElementById('<%=this.grdCAcontacts.ClientID%>');
                itemCheckBox = "chkCA";
            }
            var headerchk = document.getElementById(header);
            var Inputs = grdTipscheck.getElementsByTagName("input");

            for (var n = 0; n < Inputs.length; ++n) {
                if (Inputs[n].type == 'checkbox'
                    && Inputs[n].id.indexOf(itemCheckBox, 0) >= 0) {
                    if (Inputs[n].checked)
                        count++;
                    rowcount++;
                }
            }
            if (count == rowcount) {
                headerchk.checked = true;
            }
            else {
                headerchk.checked = false;
            }
        }

        function Print(id, Flag) {
            var url = 'PrintInquiries.aspx?CID=' + id + '&Type=' + Flag;
            window.open(url, '', "height=650,scrollbars=no,toolbars=yes,status=yes,resizable=yes").focus();
            return false;
        }

        var overlay = $('<div id="overlay"></div>');
        function ShowCannedMessage(contactMailID) {

            //            document.getElementById("<%=lblErrorMessage1.ClientID %>").innerHTML = "";
            //            document.getElementById("<%=rbCList.ClientID %>").selectedIndex = -1;

            // var x = event.clientX;
            //var y = event.clientY;
            $("#divCannedMessage").css("display", "block")

            overlay.show();
            overlay.appendTo(document.body);
            if (document.getElementById("<%=hdnSelectedContactMailID.ClientID %>") != null)
                document.getElementById("<%=hdnSelectedContactMailID.ClientID %>").value = contactMailID;

            document.getElementById("<%=RBNone.ClientID %>").checked = true;
            $('#<%=rbCList.ClientID%> input').attr('checked', false);
        }

        function ValidateMessages() {

            /*
            var sel = document.getElementById("<%=rbCList.ClientID %>");
            if (document.getElementById("<%=RBNone.ClientID %>").checked == false && sel.selectedIndex == -1) {

            document.getElementById("<%=lblErrorMessage1.ClientID %>").innerHTML = "Please select atleast one message.";
            setTimeout(function () {
            if (document.getElementById("<%=lblErrorMessage1.ClientID %>") != null) {
            document.getElementById("<%=lblErrorMessage1.ClientID %>").innerHTML = "";
            }
            }, 3 * 1000);

            return false;
            }
            else {
            */
            closeDivPopup();
            return true;
            //}
        }

        function closeDivPopup() {
            $("#divCannedMessage").css("display", "none");
            overlay.appendTo(document.body).remove();
        }

        //        window.onload = function () {

        //            $("#<%=rbCList.ClientID%> input").change(function () {
        //                document.getElementById("<%=RBNone.ClientID %>").checked = false;
        //            });

        //            $("#<%=RBNone.ClientID%>").change(function () {
        //                $('#<%=rbCList.ClientID%> input').attr('checked', false);
        //            });

        //        }

        function changeRadio() {
            $('#<%=rbCList.ClientID%> input').attr('checked', false);
        }

        function changeRadioList() {
            document.getElementById("<%=RBNone.ClientID %>").checked = false;
        }

        function Confirmationbox(frm, type) {
            var result = false;
            for (i = 0; i < frm.length; i++) {
                // Look for our checkboxes only
                if (frm.elements[i].name.indexOf("chkBL") != -1) {
                    // If any are checked then confirm alert, otherwise nothing happens
                    if (frm.elements[i].checked) {
                        result = true;
                    }
                }
                if (frm.elements[i].name.indexOf("chkBU") != -1) {
                    // If any are checked then confirm alert, otherwise nothing happens
                    if (frm.elements[i].checked) {
                        result = true;
                    }
                }
                if (frm.elements[i].name.indexOf("chkEC") != -1) {
                    // If any are checked then confirm alert, otherwise nothing happens
                    if (frm.elements[i].checked) {
                        result = true;
                    }
                }
                if (frm.elements[i].name.indexOf("chkCA") != -1) {
                    // If any are checked then confirm alert, otherwise nothing happens
                    if (frm.elements[i].checked) {
                        result = true;
                    }
                }
            }
            var msg = '';
            if (result) {
                msg = 'Are you sure you want to delete selected items?';
                return confirm(msg);
            }
            else {
                msg = 'Please select at least one checkbox to delete.';
                alert(msg);
                return false;
            }
        }

    </script>
    <style type="text/css">
        .UnreadInquiry
        {
            background-color: #AFC7C7;
            font-weight: bold;
        }
        .readInquiry
        {
            background-color: #A8A8A8;
        }
        .tabs
        {
            border: 2px solid Orange;
            width: 98%;
        }
        
        .buttonsOverLine
        {
            background: #3b86d4;
            font-family: Arial;
            color: #ffffff;
            font-size: 16px;
            padding: 6px 6px 6px 6px;
            text-decoration: none;
            margin: 0px 0px -6px 0px;
            border-color: transparent;
            cursor: pointer;
            width: 150px;
            border-top-left-radius: 5px;
            border-top-right-radius: 5px;
        }
        .ActiveButton
        {
            background: #0d4884;
            font-family: Arial;
            font-weight: bold;
            color: #ffffff;
            font-size: 16px;
            padding: 6px 6px 6px 6px;
            text-decoration: none;
            margin: 0px 0px -6px 0px;
            cursor: pointer;
            border-color: transparent;
            width: 150px;
            border-top-left-radius: 5px;
            border-top-right-radius: 5px;
        }
    </style>
    <style type="text/css">
        #overlay
        {
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background-color: #000;
            filter: alpha(opacity=70);
            -moz-opacity: 0.7;
            -khtml-opacity: 0.7;
            opacity: 0.7;
            z-index: 100;
        }
        .content a
        {
            text-decoration: none;
        }
        .popup
        {
            width: 100%;
            margin: 0 auto;
            position: fixed;
            z-index: 101;
        }
        .content
        {
            min-width: 300px;
            width: 600px;
            min-height: 130px;
            margin-left: 150px;
            background: #f3f3f3;
            position: relative;
            z-index: 103;
            padding: 10px;
            border-radius: 5px;
            box-shadow: 0 2px 5px #000;
        }
        .content p
        {
            clear: both;
            color: #555555;
            text-align: justify;
        }
        .content p a
        {
            color: #d91900;
            font-weight: bold;
        }
        .content .x
        {
            float: right;
            left: 22px;
            position: relative;
            top: -25px;
        }
        .content .x:hover
        {
            cursor: pointer;
        }
        .btnorange
        {
            -webkit-border-radius: 3;
            -moz-border-radius: 3;
            border-radius: 3px;
            font-family: Arial;
            color: #ffffff;
            font-size: 15px;
            background: #DC7224;
            padding: 9px 20px;
            color: #fff !important;
            text-decoration: none !important;
            font-weight: normal;
        }
        
        .btnorange:hover
        {
            background: #3cb0fd;
            text-decoration: none;
        }
    </style>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hdnSelectedContactMailID" runat="server"></asp:HiddenField>
            <div id="divCannedMessage" style="display: none;">
                <div class='popup'>
                    <div class='content'>
                        <img src='../../images/x.png' alt='quit' class='x' id='x' onclick="closeDivPopup();" />
                        <br />
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <div class="page-title">
                                        Reply To Email Messages
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Enter a custom message or select a canned message.
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblErrorMessage1" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div style="border: 1px solid #DFE7F6; height: 200px; overflow-y: scroll; overflow-x: hidden;
                                        width: 600px; margin-top: 5px; margin-left: 5px;">
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="padding-left: 3px;">
                                                    <asp:RadioButton ID="RBNone" runat="server" Text="Enter your message" GroupName="rbCM"
                                                        Checked="true" onchange="changeRadio()" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 7px; padding-bottom: 3px;">
                                                    <b>Canned Messages</b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:RadioButtonList runat="server" ID="rbCList" GroupName="rbCM" onchange="changeRadioList()">
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Button ID="Button1" runat="server" Text="Reply" OnClick="btnReply_OnClick" OnClientClick="return RedirectailTo();" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
            <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" class="page-padding">
                <tr>
                    <td class="valign-top">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="page-title">
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <p style="font-size: 18px; margin-left: 10px; margin-bottom: 5px;">
                                        Email Messages
                                    </p>
                                </td>
                                <td style="padding-right: 70px;">
                                    <asp:UpdateProgress ID="UpdateProgress6" runat="server" DisplayAfter="3">
                                        <ProgressTemplate>
                                            <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </td>
                                <td align="right">
                                    <asp:LinkButton runat="server" ID="lnkCannedMessage" Text="Canned Messages" CssClass="btnorange"
                                        OnClick="lnkCannedMessage_OnClick"></asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="inputtable">
                            <tr>
                                <td valign="top">
                                    <table border="0" cellpadding="0" cellspacing="10">
                                        <tr>
                                            <td>
                                                <img src='<%=Page.ResolveClientUrl("~/images/Dashboard/unread.gif")%>' width="25"
                                                    height="25" />
                                            </td>
                                            <td>
                                                Unread
                                            </td>
                                            <td>
                                                <img src='<%= Page.ResolveClientUrl("~/images/Dashboard/msgread.gif")%>' width="25"
                                                    height="25" />
                                            </td>
                                            <td>
                                                Read
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <%if (BulletinsCount > 0)
                              { %>
                            <tr>
                                <td style="padding-top: 10px; padding-left: 5px; color: #005AA0; font-weight: bold;">
                                    <asp:Label ID="lblBulletins" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="datagrid nomargin-bottom">
                                        <tr>
                                            <td>
                                                <asp:GridView ID="grdNewsletercontacts" runat="server" DataKeyNames="ContactUser_ID"
                                                    AutoGenerateColumns="False" AllowPaging="true" Width="100%" OnPageIndexChanging="grdNewsletercontacts_PageIndexChanging"
                                                    OnRowDataBound="grdNewsletercontacts_RowDataBound" CssClass="datagrid2" PageSize="4">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:CheckBox ID="chkSelectAllBL" runat="server" Text="Select All" onclick="chkSelectAll(this,'BL');"
                                                                    OnCheckedChanged="ChkSelectAllBLCheckedChanged" />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chkBL" runat="server" OnCheckedChanged="ChkBLCheckedChanged" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="10%" />
                                                            <HeaderStyle Font-Size="12px" HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Contact Name">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkcontactname" runat="server" Text='<%#Eval("First_Name") %>'
                                                                    ToolTip="View Email Messages Details" CommandArgument='<%# Eval("ContactUser_ID") %>'
                                                                    OnClick="lnkcontactname_Click"></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="30%" />
                                                            <HeaderStyle HorizontalAlign="Center" Font-Size="12px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Description">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbldescription" runat="server" Text='<%#Eval("Description") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="50%" />
                                                            <HeaderStyle Font-Size="12px" HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Date Sent">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCreateddate" runat="server" Text='<%#Eval("Created_Date") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Font-Size="12px" Width="25%" />
                                                            <HeaderStyle Font-Size="12px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Delete">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkdelete" runat="server" CommandArgument='<%# Eval("ContactUser_ID") %>'
                                                                    OnClick="lnkdelete_Click" Text="<img src='../../Images/icon_delete.gif'width='25px' height='25px' title='Delete' border='0'"
                                                                    CausesValidation="false"></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Font-Size="12px" Width="15%" />
                                                            <HeaderStyle Font-Size="12px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Print">
                                                            <ItemTemplate>
                                                                <img id="lnkprint" onclick='<%# string.Format("javascript:Print(\"{0}\",\"{1}\")", Eval("ContactUser_ID"),"BL") %>'
                                                                    src='../../Images/Dashboard/printer.png' width='20px' height='20px' title='Print'
                                                                    border='0' style="cursor: pointer;"></img>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Font-Size="12px" Width="15%" />
                                                            <HeaderStyle Font-Size="12px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Reply">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblUserEmail" runat="server" Text='<%#Eval("User_Email") %>' Visible="false"></asp:Label>
                                                                <asp:Label ID="lblReply" runat="server" Text=""></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle Font-Size="12px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblchecked" runat="server" Text='<%#Eval("IsChecked") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <EmptyDataTemplate>
                                                        <asp:Label ID="lblBUempty" runat="server" Text="There are no Email Messages at this time."
                                                            Font-Bold="true" Font-Size="15px" ForeColor="#E8C41D"></asp:Label>
                                                    </EmptyDataTemplate>
                                                    <HeaderStyle CssClass="title1" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <%} %>
                            <%if (UpdatesCount > 0)
                              { %>
                            <tr>
                                <td style="padding-top: 10px; padding-left: 5px; color: #005AA0; font-weight: bold;">
                                    Content Module
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="datagrid nomargin-bottom">
                                        <tr>
                                            <td>
                                                <asp:GridView ID="grdUpdatescontacts" runat="server" DataKeyNames="ContactUser_ID"
                                                    AutoGenerateColumns="False" AllowPaging="true" Width="100%" OnPageIndexChanging="grdUpdatescontacts_PageIndexChanging"
                                                    OnRowDataBound="grdUpdatescontacts_RowDataBound" CssClass="datagrid2" PageSize="4">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:CheckBox ID="chkSelectAllBU" runat="server" Text="Select All" onclick="chkSelectAll(this,'BU');"
                                                                    OnCheckedChanged="ChkSelectAllBUCheckedChanged" />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chkBU" runat="server" OnCheckedChanged="ChkBUCheckedChanged" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="10%" />
                                                            <HeaderStyle Font-Size="12px" HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Contact Name">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkBUcontactname" runat="server" Text='<%#Eval("First_Name") %>'
                                                                    ToolTip="View Contact Details" CommandArgument='<%# Eval("ContactUser_ID") %>'
                                                                    OnClick="lnkBUcontactname_Click"></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="30%" />
                                                            <HeaderStyle HorizontalAlign="Center" Font-Size="12px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Description">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblBUdescription" runat="server" Text='<%#Eval("Description") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="50%" />
                                                            <HeaderStyle Font-Size="12px" HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Date Sent">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblBUCreateddate" runat="server" Text='<%#Eval("Created_Date") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Font-Size="12px" Width="25%" />
                                                            <HeaderStyle Font-Size="12px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Delete">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkBUdelete" runat="server" CommandArgument='<%# Eval("ContactUser_ID") %>'
                                                                    OnClick="lnkdelete_Click" Text="<img src='../../Images/icon_delete.gif'width='25px' height='25px' title='Delete' border='0'"
                                                                    CausesValidation="false"></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Font-Size="12px" Width="15%" />
                                                            <HeaderStyle Font-Size="12px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Print">
                                                            <ItemTemplate>
                                                                <img id="lnkprint" onclick='<%# string.Format("javascript:Print(\"{0}\",\"{1}\")", Eval("ContactUser_ID"),"BU") %>'
                                                                    src='../../Images/Dashboard/printer.png' width='20px' height='20px' title='Print'
                                                                    border='0' style="cursor: pointer;"></img>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Font-Size="12px" Width="15%" />
                                                            <HeaderStyle Font-Size="12px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Reply">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblUserEmail" runat="server" Text='<%#Eval("User_Email") %>' Visible="false"></asp:Label>
                                                                <asp:Label ID="lblReply" runat="server" Text=""></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle Font-Size="12px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblchecked" runat="server" Text='<%#Eval("IsChecked") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <EmptyDataTemplate>
                                                        <asp:Label ID="lblBUempty" runat="server" Text="There are no Email Messages at this time."
                                                            Font-Bold="true" Font-Size="15px" ForeColor="#E8C41D"></asp:Label></EmptyDataTemplate>
                                                    <HeaderStyle CssClass="title1" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <%} %>
                            <%if (EventCalendarCount > 0)
                              { %>
                            <tr>
                                <td style="padding-top: 10px; padding-left: 5px; color: #005AA0; font-weight: bold;">
                                    <asp:Label ID="lblEventCalendar" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="datagrid nomargin-bottom">
                                        <tr>
                                            <td>
                                                <asp:GridView ID="grdECcontacts" runat="server" DataKeyNames="ContactUser_ID" AutoGenerateColumns="False"
                                                    AllowPaging="true" Width="100%" OnPageIndexChanging="grdECcontacts_PageIndexChanging"
                                                    OnRowDataBound="grdECcontacts_RowDataBound" CssClass="datagrid2" PageSize="4">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:CheckBox ID="chkSelectAllEC" runat="server" Text="Select All" onclick="chkSelectAll(this,'EC');"
                                                                    OnCheckedChanged="ChkSelectAllECCheckedChanged" />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chkEC" runat="server" OnCheckedChanged="ChkECCheckedChanged" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="10%" />
                                                            <HeaderStyle Font-Size="12px" HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Contact Name">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkECcontactname" runat="server" Text='<%#Eval("First_Name") %>'
                                                                    ToolTip="View Contact Details" CommandArgument='<%# Eval("ContactUser_ID") %>'
                                                                    OnClick="lnkECcontactname_Click"></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="30%" />
                                                            <HeaderStyle HorizontalAlign="Center" Font-Size="12px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Description">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblECdescription" runat="server" Text='<%#Eval("Description") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="50%" />
                                                            <HeaderStyle Font-Size="12px" HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Date Sent">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblECCreateddate" runat="server" Text='<%#Eval("Created_Date") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Font-Size="12px" Width="25%" />
                                                            <HeaderStyle Font-Size="12px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Delete">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkECdelete" runat="server" CommandArgument='<%# Eval("ContactUser_ID") %>'
                                                                    OnClick="lnkdelete_Click" Text="<img src='../../Images/icon_delete.gif'width='25px' height='25px' title='Delete' border='0'"
                                                                    CausesValidation="false"></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Font-Size="12px" Width="15%" />
                                                            <HeaderStyle Font-Size="12px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Print">
                                                            <ItemTemplate>
                                                                <img id="lnkprint" onclick='<%# string.Format("javascript:Print(\"{0}\",\"{1}\")", Eval("ContactUser_ID"),"EC") %>'
                                                                    src='../../Images/Dashboard/printer.png' width='20px' height='20px' title='Print'
                                                                    border='0' style="cursor: pointer;"></img>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Font-Size="12px" Width="15%" />
                                                            <HeaderStyle Font-Size="12px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Reply">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblUserEmail" runat="server" Text='<%#Eval("User_Email") %>' Visible="false"></asp:Label>
                                                                <asp:Label ID="lblReply" runat="server" Text=""></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle Font-Size="12px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblchecked" runat="server" Text='<%#Eval("IsChecked") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <EmptyDataTemplate>
                                                        <asp:Label ID="lblECempty" runat="server" Text="There are no Email Messages at this time."
                                                            Font-Bold="true" Font-Size="15px" ForeColor="#E8C41D"></asp:Label></EmptyDataTemplate>
                                                    <HeaderStyle CssClass="title1" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <%} %>
                            <%if (CalendarAddOnCount > 0)
                              { %>
                            <tr>
                                <td style="padding-top: 10px; padding-left: 5px; color: #005AA0; font-weight: bold;">
                                    Calendar AddOn
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="datagrid nomargin-bottom">
                                        <tr>
                                            <td>
                                                <asp:GridView ID="grdCAcontacts" runat="server" DataKeyNames="ContactUser_ID" AutoGenerateColumns="False"
                                                    AllowPaging="true" Width="100%" OnPageIndexChanging="grdCAcontacts_PageIndexChanging"
                                                    OnRowDataBound="grdCAcontacts_RowDataBound" CssClass="datagrid2" PageSize="4">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:CheckBox ID="chkSelectAllCA" runat="server" Text="Select All" onclick="chkSelectAll(this,'CA');"
                                                                    OnCheckedChanged="ChkSelectAllCACheckedChanged" />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chkCA" runat="server" OnCheckedChanged="ChkCACheckedChanged" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="10%" />
                                                            <HeaderStyle Font-Size="12px" HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Contact Name">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkCAcontactname" runat="server" Text='<%#Eval("First_Name") %>'
                                                                    ToolTip="View Contact Details" CommandArgument='<%# Eval("ContactUser_ID") %>'
                                                                    OnClick="lnkCAcontactname_Click"></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="30%" />
                                                            <HeaderStyle HorizontalAlign="Center" Font-Size="12px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Description">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCAdescription" runat="server" Text='<%#Eval("Description") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="50%" />
                                                            <HeaderStyle Font-Size="12px" HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Date Sent">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCACreateddate" runat="server" Text='<%#Eval("Created_Date") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Font-Size="12px" Width="25%" />
                                                            <HeaderStyle Font-Size="12px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Delete">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkCAdelete" runat="server" CommandArgument='<%# Eval("ContactUser_ID") %>'
                                                                    OnClick="lnkdelete_Click" Text="<img src='../../Images/icon_delete.gif'width='25px' height='25px' title='Delete' border='0'"
                                                                    CausesValidation="false"></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Font-Size="12px" Width="15%" />
                                                            <HeaderStyle Font-Size="12px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Print">
                                                            <ItemTemplate>
                                                                <img id="lnkprint" onclick='<%# string.Format("javascript:Print(\"{0}\",\"{1}\")", Eval("ContactUser_ID"),"CA") %>'
                                                                    src='../../Images/Dashboard/printer.png' width='20px' height='20px' title='Print'
                                                                    border='0' style="cursor: pointer;"></img>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Font-Size="12px" Width="15%" />
                                                            <HeaderStyle Font-Size="12px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Reply">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblUserEmail" runat="server" Text='<%#Eval("User_Email") %>' Visible="false"></asp:Label>
                                                                <asp:Label ID="lblReply" runat="server" Text=""></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle Font-Size="12px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblchecked" runat="server" Text='<%#Eval("IsChecked") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <EmptyDataTemplate>
                                                        <asp:Label ID="lblCAempty" runat="server" Text="There are no Email Messages at this time."
                                                            Font-Bold="true" Font-Size="15px" ForeColor="#E8C41D"></asp:Label></EmptyDataTemplate>
                                                    <HeaderStyle CssClass="title1" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <%} %>
                            <%if (BulletinsCount == 0 && UpdatesCount == 0 && EventCalendarCount == 0 && CalendarAddOnCount == 0)
                              {%>
                            <tr>
                                <td align="center" style="height: 50px; font-size: 15px; color: red;">
                                    There are no Email Messages at this time.
                                </td>
                            </tr>
                            <%}
                              else
                              { %>
                            <tr>
                                <td>
                                    <table border="0" width="100%" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="padding-left: 5px;">
                                                <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <%} %>
                            <tr>
                                <td align="center" style="background-color: #D2E5FA; border: 1px solid #D1DDEA; padding: 7px 0px 7px 0px;">
                                    <asp:Button ID="btnBack" CssClass="button" runat="server" Text="Back" OnClick="btnBack_Click"
                                        CausesValidation="false" />
                                </td>
                            </tr>
                        </table>
                        <table cellspacing="0" cellpadding="0" border="0" width="100%">
                            <tbody>
                                <tr>
                                    <td align="center">
                                        <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" BackgroundCssClass="modal"
                                            TargetControlID="lbl" CancelControlID="imclose" PopupControlID="pnlpopup">
                                        </cc1:ModalPopupExtender>
                                        <asp:Panel Style="display: none" ID="pnlpopup" runat="server">
                                            <table style="width: 600px; text-align: left;" class="popuptable" cellspacing="0"
                                                cellpadding="0" border="0" align="center">
                                                <tbody>
                                                    <tr>
                                                        <td>
                                                            <table cellspacing="3" cellpadding="1" width="100%" border="0">
                                                                <colgroup>
                                                                    <col width="135" />
                                                                    <col width="*" />
                                                                </colgroup>
                                                                <tbody>
                                                                    <tr>
                                                                        <td class="header" nowrap align="left" colspan="2">
                                                                            <asp:Label ID="lblheader" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td align="right">
                                                                            <asp:ImageButton ID="imclose" OnClick="btnclose_Click" runat="server" ImageUrl="~/images/popup_close.gif">
                                                                            </asp:ImageButton>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="font-size: 14px" nowrap>
                                                                            First Name:
                                                                        </td>
                                                                        <td style="padding-left: 10px; font-size: 14px; color: #2b60de;">
                                                                            <asp:Label ID="lblfn" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="font-size: 14px" nowrap>
                                                                            Last Name:
                                                                        </td>
                                                                        <td style="padding-left: 10px; font-size: 14px; color: #2b60de;">
                                                                            <asp:Label ID="lblln" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="font-size: 14px" nowrap>
                                                                            Address:
                                                                        </td>
                                                                        <td style="padding-left: 10px; font-size: 14px; color: #2b60de;">
                                                                            <asp:Label ID="lbladdress" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="font-size: 14px" nowrap>
                                                                            Contact Email:
                                                                        </td>
                                                                        <td style="padding-left: 10px; font-size: 14px; color: #2b60de;">
                                                                            <asp:Label ID="lblemail" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="font-size: 14px">
                                                                            Phone Number:
                                                                        </td>
                                                                        <td style="padding-left: 10px; font-size: 14px; color: #2b60de;">
                                                                            <asp:Label ID="lblphone" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="font-size: 14px; vertical-align: top">
                                                                            Description:
                                                                        </td>
                                                                        <td style="padding-left: 10px; font-size: 14px; color: #2b60de;">
                                                                            <asp:Label ID="lbldescription" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </asp:Panel>
                                        <asp:Label ID="lbl" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
            </table>
            <asp:HiddenField ID="hdnPermissionType" runat="server" Value="1"></asp:HiddenField>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" Visible="false">
        <ContentTemplate>
            <div class="page-title">
                Email Messages
            </div>
            <div style="color: red;" align="center">
                <asp:Label ID="lblerrormessage" runat="server"></asp:Label></div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
