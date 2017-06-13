<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true"
    Inherits="Business_MyAccount_EventsReports" EnableEventValidation="false" CodeBehind="EventsReports.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphUser" runat="Server">
    <script type="text/javascript">
        function SelectAll(CheckBox) {
            TotalChkBx = parseInt('<%= this.GrdbusinessEvents.Rows.Count %>');
            var TargetBaseControl = document.getElementById('<%= this.GrdbusinessEvents.ClientID %>');
            var TargetChildControl = "chkUpdate";
            var Inputs = TargetBaseControl.getElementsByTagName("input");
            for (var iCount = 0; iCount < Inputs.length; ++iCount) {
                if (Inputs[iCount].type == 'checkbox' && Inputs[iCount].id.indexOf(TargetChildControl, 0) >= 0)
                    Inputs[iCount].checked = CheckBox.checked;
            }
        }

        function SelectDeSelectHeader(CheckBox) {
            TotalChkBx = parseInt('<%= this.GrdbusinessEvents.Rows.Count %>');
            var TargetBaseControl = document.getElementById('<%= this.GrdbusinessEvents.ClientID %>');
            var TargetChildControl = "chkUpdate";
            var TargetHeaderControl = "chkSelectAll";
            var Inputs = TargetBaseControl.getElementsByTagName("input");
            var flag = false;
            var HeaderCheckBox;
            for (var iCount = 0; iCount < Inputs.length; ++iCount) {
                if (Inputs[iCount].type == 'checkbox' && Inputs[iCount].id.indexOf(TargetHeaderControl, 0) >= 0)
                    HeaderCheckBox = Inputs[iCount];
                if (Inputs[iCount] != CheckBox && Inputs[iCount].type == 'checkbox' && Inputs[iCount].id.indexOf(TargetChildControl, 0) >= 0 && Inputs[iCount].id.indexOf(TargetHeaderControl, 0) == -1) {
                    if (CheckBox.checked) {
                        if (!Inputs[iCount].checked) {
                            flag = false;
                            HeaderCheckBox.checked = false;
                            return;
                        }
                        else
                            flag = true;
                    }
                    else if (!CheckBox.checked)
                        HeaderCheckBox.checked = false;
                }
            }
            if (flag)
                HeaderCheckBox.checked = CheckBox.checked
        }
        function Validate(radioID) {
            var grid = document.getElementById('<%= GrdbusinessEvents.ClientID%>');
            var controls = grid.getElementsByTagName("input");
            for (var i = 0; i < controls.length; i++) {
                if (controls[i].type == "radio") {
                    if (controls[i] != radioID && controls[i].checked) {
                        controls[i].checked = false;
                        break;
                    }
                }
            }
            for (var i = 0; i < controls.length; i++) {
                if (controls[i].type == "radio") {
                    if (controls[i] == radioID) {
                        document.getElementById('<%=hdnrdValue.ClientID%>').value = i;
                        break;
                    }
                }
            }
        }

        function ValidateRadioButton(type) {
            if (document.getElementById('<%=btnExportSelected.ClientID%>').value == 'Export Selected') {
                var selectedcount = 0;
                var TargetBaseControl = document.getElementById('<%= this.GrdbusinessEvents.ClientID %>');
                var TargetChildControl = "chkUpdate";
                var Inputs = TargetBaseControl.getElementsByTagName("input");
                for (var iCount = 0; iCount < Inputs.length; ++iCount) {
                    if (Inputs[iCount].type == 'checkbox' && Inputs[iCount].id.indexOf(TargetChildControl, 0) >= 0) {
                        if (Inputs[iCount].checked) {
                            selectedcount += 1;
                            if (selectedcount > 1)
                                break;
                        }
                    }
                }
                if (selectedcount == 0) {
                    if (type == '1')
                        alert('Please select a title to Export.');
                    else
                        alert('Please select a title to consolidate.');
                    return false;
                }
                else
                    return true;
            }
            return true;
        }
        //Print
        function CallPrint() {
            var prtContent = document.getElementById('<%=pnlGrdbusinessEvents.ClientID%>');
            var WinPrint = window.open('', '', 'letf=0,top=0,width=400,height=400,toolbar=0,scrollbars=0,status=0');
            WinPrint.document.write(prtContent.innerHTML);
            WinPrint.document.close();
            WinPrint.focus();
            WinPrint.print();
            WinPrint.close();
        }
        //Status Confirmation
        function Confirmation(ctrl) {
            if (ctrl.innerHTML == 'Active')
                return confirm('Are you sure you want to inactivate this update?');
            else
                return confirm('Are you sure you want to activate this update?');
        }
    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnExportSelected" />
        </Triggers>
        <ContentTemplate>
            <table class="page-padding" cellspacing="0" cellpadding="0" width="100%" border="0">
                <tbody>
                    <tr>
                        <td class="valign-top">
                            <table class="page-title" cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td style="height: 30px; font-size: 18px; color: #EC2027; margin-bottom: 5px; margin-top: 5px;
                                            font-weight: bold;">
                                            <div style="float: left;">
                                                <%=hdnTabName.Value %> Reports <a href="javascript:ModalHelpPopup('Event Campaign Tracking Report',170,'');">
                                                    <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" /></a></div>
                                            <asp:Label ID="lblConsolidated" Text="Consolidated Report" Visible="false" runat="server"></asp:Label>
                                            <asp:HiddenField ID="hdnTabName" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:UpdateProgress ID="UpdateProgress2" runat="server" DisplayAfter="3">
                                                <ProgressTemplate>
                                                    <img src="../../images/popup_ajax-loader.gif" border="0"><b><font color="green">Processing....</font></b>
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td style="color: green" align="center">
                                            <asp:Label ID="lblmess" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table class="inputtable" cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td class="valign-top">
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tbody>
                                                    <tr>
                                                        <td style="padding-bottom: 20px;">
                                                            <asp:Panel ID="pnlGrdbusinessEvents" runat="server" ScrollBars="Auto" Width="100%"
                                                                Height="400px">
                                                                <asp:GridView ID="GrdbusinessEvents" runat="server" ShowFooter="false" AutoGenerateColumns="false"
                                                                    Width="100%" BorderColor="#0086C6" OnRowDataBound="gridEvents_RowDataBound" AllowSorting="true"
                                                                    GridLines="None" CssClass="datagrid2" OnSorting="gridEvents_Sorting" FooterStyle-Height="60"
                                                                    DataKeyNames="EventId">
                                                                    <EmptyDataRowStyle ForeColor="#C00000"></EmptyDataRowStyle>
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Image" FooterText="Totals">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblEventimg" runat="server" />
                                                                            </ItemTemplate>
                                                                            <ItemStyle CssClass="align-center" />
                                                                            <FooterStyle CssClass="align-center" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Select All">
                                                                            <HeaderTemplate>
                                                                                <asp:CheckBox ID="chkSelectAll" runat="server" Text="Select All" onclick="SelectAll(this);" />
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkHidden" Visible="false" runat="server"></asp:LinkButton>
                                                                                <asp:CheckBox ID="chkUpdate" runat="server" />
                                                                            </ItemTemplate>
                                                                            <ItemStyle CssClass="align-center" Width="50px"></ItemStyle>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Title" SortExpression="EventTitle">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkEventName" runat="server" Text='<%#Bind("EventTitle")%>' CommandArgument='<%# Bind("EventId") %>'
                                                                                    OnClick="lnkEventName_Click" Class="SortHeader"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Title1" Visible="false">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblUpdateName" runat="server" Text='<%#Bind("EventTitle")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Status" SortExpression="Status">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblstatusflag" runat="server" Text='<%# Bind("Status") %>' Visible="False"></asp:Label>
                                                                                <asp:Label ID="lblstatus" runat="server"></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle CssClass="align-center" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Sent">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblSent" runat="server" Text='<%# GetEventsCount(Eval("EventId"),1) %>'></asp:Label>
                                                                                <asp:LinkButton ID="lblhistroy" runat="server" Text='<%#GetEventsCount(Eval("EventId"),1) %>'
                                                                                    OnClick="lblhistroy_Click" CommandArgument='<%#Eval("EventId") %>'></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                            <ItemStyle CssClass="align-center" />
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblsentTotal" runat="server" />
                                                                            </FooterTemplate>
                                                                            <FooterStyle CssClass="aligncenter" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Sent1" Visible="false">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblSent1" runat="server" Text='<%# GetEventsCount(Eval("EventId"),1) %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Opened">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblOpened" runat="server" Text='<%# GetEventsCount(Eval("EventId"),2) %>'></asp:Label>
                                                                                <asp:LinkButton ID="lnkopen" runat="server" CommandArgument='<%# Bind("EventId") %>'
                                                                                    Text='<%# GetEventsCount(Eval("EventId"),2) %>' OnClick="lnkopen_Click" CausesValidation="false"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                            <ItemStyle CssClass="align-center" />
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblOpenedTotal" runat="server" />
                                                                            </FooterTemplate>
                                                                            <FooterStyle CssClass="aligncenter" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Opened1" Visible="false">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblOpened1" runat="server" Text='<%# GetEventsCount(Eval("EventId"),2) %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Opt Out">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblOptOut" runat="server" Text='<%# GetEventsCount(Eval("EventId"),3) %>'></asp:Label>
                                                                                <asp:LinkButton ID="lnkoptout" runat="server" CommandArgument='<%# Bind("EventId") %>'
                                                                                    Text='<%#GetEventsCount(Eval("EventId"),3) %>' OnClick="lnkoptout_Click" CausesValidation="false"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                            <ItemStyle CssClass="align-center" />
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblOptOutTotal" runat="server" />
                                                                            </FooterTemplate>
                                                                            <FooterStyle CssClass="aligncenter" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Opt Out1" Visible="false">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblOptOut1" runat="server" Text='<%# GetEventsCount(Eval("EventId"),3) %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Unopened">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblUnopened" runat="server"></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle CssClass="align-center" />
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblUnOpendTotal" runat="server" />
                                                                            </FooterTemplate>
                                                                            <FooterStyle CssClass="aligncenter" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Bounced Back">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblBounced" runat="server" Text='<%#GetEventsCount(Eval("EventId"),4) %>'></asp:Label>
                                                                                <asp:LinkButton ID="lnkBounced" runat="server" Text='<%#GetEventsCount(Eval("EventId"),4) %>'
                                                                                    CommandArgument='<%# Bind("EventId") %>' OnClick="lnkBounced_Click" CausesValidation="false"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                            <ItemStyle CssClass="align-center" />
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblBouncedTotal" runat="server" />
                                                                            </FooterTemplate>
                                                                            <FooterStyle CssClass="aligncenter" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Bounced Back1" Visible="false">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblBounced1" runat="server" Text='<%# GetEventsCount(Eval("EventId"),4) %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="EventStartDate" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Start Date"
                                                                            SortExpression="EventStartDate" ItemStyle-CssClass="align-center"></asp:BoundField>
                                                                        <asp:TemplateField Visible="false">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="TotalScheduleCount" runat="server" Text='<%#GetSheduledCount(Eval("EventId")) %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <HeaderStyle CssClass="title3"></HeaderStyle>
                                                                    <EmptyDataTemplate>
                                                                        No email campaigns have been sent at this time.
                                                                    </EmptyDataTemplate>
                                                                    <EmptyDataRowStyle CssClass="aligncenter" />
                                                                </asp:GridView>
                                                                <asp:Button ID="ScrollDown" runat="server" BackColor="White" BorderColor="White"
                                                                    BorderStyle="None" Text="" Height="0px" Width="0px" />
                                                                <asp:HiddenField ID="hdnTotalEventsCount" runat="server" />
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 40px; background-color: #D2E5FA;">
                                                        <td align="center">
                                                            <asp:HiddenField ID="hdnrdValue" runat="server" />
                                                            <asp:HiddenField ID="hdnUrl" runat="server" />
                                                            <asp:Button ID="btnCancel" Text="Cancel" CssClass="ButtonText" runat="server" OnClick="btnCancel_Click" />
                                                            <asp:Button ID="btnExportSelected" Text="Export Selected" runat="server" OnClick="btnExportSelected_Click"
                                                                OnClientClick="return ValidateRadioButton('1');" />
                                                            <asp:Button ID="btnConsolidatedeport" Text="Consolidated Report" runat="server" OnClick="btnConsolidatedeport_Click"
                                                                OnClientClick="return ValidateRadioButton('2');" />
                                                            <asp:Button ID="btnPrint" Text="Print" runat="server" OnClientClick="javascript:CallPrint()" />
                                                            <asp:Button ID="btnBack" Text="Back" runat="server" OnClick="btnBack_Click" Visible="false" />
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                    </tr>
                                </tbody>
                            </table>
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
                                PopupControlID="pnlpopup1" BackgroundCssClass="modal" CancelControlID="imglogin5">
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
                                                <asp:ImageButton ID="imglogin5" runat="server" CausesValidation="false" ImageUrl="~/images/popup_close.gif">
                                                </asp:ImageButton>
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
                                                    <asp:Label ID="lblPreviewHTML" runat="server" CssClass="hyperlink"></asp:Label>
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
                                                                Event History <span style="color: maroon; font-family: Arial; size: 2"><span style="color: maroon;
                                                                    font-family: Arial; size: 2">
                                                                    <asp:Label ID="lblviewsentnewlettername" runat="server"></asp:Label>
                                                                </span></span>
                                                            </td>
                                                            <td align="right">
                                                                <asp:ImageButton ID="imglogin2" runat="server" CausesValidation="false" ImageUrl="~/images/popup_close.gif">
                                                                </asp:ImageButton>
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
                                                                <asp:GridView ID="grdviewsenthis" runat="server" AllowSorting="True" Width="100%"
                                                                    CssClass="datagrid2" AutoGenerateColumns="False" OnRowDataBound="grdviewsenthis_RowDataBound"
                                                                    OnPageIndexChanging="grdviewsenthis_PageIndexChanging" AllowPaging="True" PageSize="15">
                                                                    <EmptyDataRowStyle ForeColor="#C00000"></EmptyDataRowStyle>
                                                                    <Columns>
                                                                        <asp:BoundField DataField="Receiver_EmailID" HeaderText="Email IDs"></asp:BoundField>
                                                                        <asp:BoundField DataField="SchduleEventSubject" HeaderText="Subject" />
                                                                        <asp:BoundField DataField="Sending_Date" HeaderText="Date"></asp:BoundField>
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
                            <asp:Label ID="lbloptout" runat="server"></asp:Label>
                            <cc1:ModalPopupExtender ID="ModalPopupExtender10" runat="server" TargetControlID="lbloptout"
                                PopupControlID="pnlOptCout" BackgroundCssClass="modal">
                            </cc1:ModalPopupExtender>
                            <asp:Panel Style="display: none; min-height: 150px; max-height: 600px;" ID="pnlOptCout"
                                runat="server" Width="820" ScrollBars="Auto">
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
                                                                Events Opt-Outs <span style="color: maroon; font-family: Arial; size: 2"></span>
                                                            </td>
                                                            <td align="right">
                                                                <asp:ImageButton ID="imglogin9" runat="server" ImageUrl="~/images/popup_close.gif"
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
                                                                        <asp:BoundField DataField="SchduleEventSubject" HeaderText="Subject" />
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
                                <table class="popuptable" cellspacing="0" cellpadding="0" width="900" align="center"
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
                                                                        <asp:BoundField DataField="SchduleEventSubject" HeaderText="Subject" />
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
            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                <tbody>
                    <tr>
                        <td>
                            <asp:Label ID="lblBouncedM" runat="server"></asp:Label>
                            <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" BackgroundCssClass="modal"
                                PopupControlID="pnlBounced" TargetControlID="lblBouncedM" CancelControlID="imgBounced">
                            </cc1:ModalPopupExtender>
                            <asp:Panel Style="display: none" ID="pnlBounced" runat="server" Width="100%">
                                <table class="popuptable" cellspacing="0" cellpadding="0" width="800" align="center"
                                    border="0">
                                    <tbody>
                                        <tr>
                                            <td align="center">
                                                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="3">
                                                    <ProgressTemplate>
                                                        <img src="../../images/popup_ajax-loader.gif" border="0"><b><font color="green">Processing....</font></b>
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
                                                                Campaign Bounced Back
                                                            </td>
                                                            <td align="right">
                                                                <asp:ImageButton ID="imgBounced" runat="server" ImageUrl="~/images/popup_close.gif"
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
                                                                <asp:GridView ID="grdBounced" runat="server" Width="100%" CssClass="datagrid2" AutoGenerateColumns="False"
                                                                    PageSize="15" AllowPaging="True" OnPageIndexChanging="grdBounced_PageIndexChanging">
                                                                    <EmptyDataRowStyle ForeColor="#C00000"></EmptyDataRowStyle>
                                                                    <Columns>
                                                                        <asp:BoundField DataField="Receiver_EmailID" HeaderText="Email ID" />
                                                                        <asp:BoundField DataField="SchduleEventSubject" HeaderText="Subject" />
                                                                        <asp:BoundField DataField="Sending_Date" HeaderText="Date" DataFormatString="{0:MM/dd/yyyy}" />
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
