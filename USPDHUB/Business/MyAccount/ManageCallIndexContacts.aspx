<%@ Page Title="" Language="C#" MasterPageFile="~/Business/MyAccount/CallIndexMaster.Master"
    ValidateRequest="false" AutoEventWireup="true" CodeBehind="ManageCallIndexContacts.aspx.cs"
    Inherits="USPDHUB.Business.MyAccount.ManageCallIndexContacts" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser1" runat="server">
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <link rel="stylesheet" type="text/css" media="all" href="../../css/styles.css" />
    <link href="../../css/accordion/jquery.ui.base.css" rel="stylesheet" type="text/css" />
    <link href="../../css/accordion/jquery.ui.theme.css" rel="stylesheet" type="text/css" />
    <link href="../../css/jquery-bubble-popup-v3.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .gvgroup
        {
            float: right;
            padding-right: 3px;
            padding-top: 5px;
        }
        .myCheckbox td
        {
            padding-top: 5px;
        }
        .myCheckbox input[type="checkbox"]
        {
            margin: 3px 3px 3px 4px;
        }
        fieldset
        {
            border: 1px solid black;
            padding: 1em;
        }
        .mycontact-add
        {
            width: 100%;
        }
        .mycontact-add td
        {
            height: 28px;
        }
        .mycontact-add td input[type="text"]
        {
            height: 20px;
            width: 200px;
        }
    </style>
    <div>
        <asp:UpdatePanel ID="uppnlpopup" runat="server">
            <ContentTemplate>
                <table class="page-padding" cellspacing="0" cellpadding="0" width="100%" border="0"
                    style="background: none; padding: 10px;">
                    <tbody>
                        <tr>
                            <td>
                                <asp:Panel ID="pnl" runat="server" DefaultButton="btnsearch">
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tr>
                                            <td align="center" style="color: Red; font-size: 14px; font-weight: bold;">
                                                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="3">
                                                    <ProgressTemplate>
                                                        <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green"
                                                            size="2">Processing....</font></b></ProgressTemplate>
                                                </asp:UpdateProgress>
                                                <asp:Label ID="lblMsg" runat="server" ForeColor="Green"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tr>
                                            <td align="left" style="width: 300px; padding-right: 5px;" valign="top">
                                                <table border="0" cellpadding="0" cellspacing="0" class="mailtbl" width="100%">
                                                    <tr>
                                                        <td class="ContactStepHeaderP">
                                                            Select a button to view contacts
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="headingP">
                                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                <tr>
                                                                    <td style="padding-right: 45px;">
                                                                        Buttons<%--Groups--%>
                                                                    </td>
                                                                    <td align="right" style="display: none;">
                                                                        <asp:Button ID="btnAddGroup" runat="server" CausesValidation="false" CssClass="mailbtnP"
                                                                            Text="Add Group" OnClick="btnAddGroup_Click" />
                                                                        <asp:Button ID="btnGroupDelete" runat="server" CausesValidation="false" CssClass="mailbtnP"
                                                                            OnClick="btnGroupDelete_Click" OnClientClick="return ConfirmGroupDelete (this.form)"
                                                                            Text="Delete" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="borderP" style="background-color: #CCFFFF;">
                                                            <div style="height: 350px; width: 300px; overflow: scroll; overflow-x: hidden;" id="mycustomscroll"
                                                                class="flexcroll">
                                                                <table border="0" cellpadding="0" cellspacing="0" style="padding: 5px; background-color: #CCFFFF;"
                                                                    width="100%">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:GridView ID="GVGroupNames" runat="server" AllowPaging="true" AutoGenerateColumns="False"
                                                                                BorderWidth="0" CssClass="Allleft" DataKeyNames="GroupID" GridLines="None" PagerSettings-Position="TopAndBottom"
                                                                                PagerStyle-Width="30px" PageSize="500" Width="100%" ShowHeader="true">
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="All" HeaderStyle-CssClass="groupsheadP" ItemStyle-Height="25px">
                                                                                        <HeaderTemplate>
                                                                                            <asp:CheckBox ID="chkAllGroup" runat="server" OnCheckedChanged="chkAllGroup_CheckedChanged"
                                                                                                AutoPostBack="true" Text="All" CssClass="myCheckbox" />
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <asp:CheckBox ID="chkGroupName" runat="server" OnCheckedChanged="chkGroupName_CheckedChanged"
                                                                                                AutoPostBack="true" Text='<%#Eval("GroupName_Count") %>' CssClass="myCheckbox" />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderStyle-CssClass="groupsheadP" Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkEditGroup" runat="server" ToolTip="Edit" OnClick="lnkEditGroup_Click"
                                                                                                CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'><img src="../../Images/Dashboard/icon_modify.gif" alt=""/></asp:LinkButton>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle CssClass="gvgroup" />
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                                <EmptyDataTemplate>
                                                                                    <span style="padding-left: 5px;">Create your groups.</span>
                                                                                </EmptyDataTemplate>
                                                                                <PagerStyle CssClass="PageContactManage" />
                                                                            </asp:GridView>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td valign="top" width="350px">
                                                <table border="0" cellpadding="0" cellspacing="0" class="mailtbl" width="100%">
                                                    <tr>
                                                        <td align="right" style="padding-right: 10px;">
                                                            <img src="../../Images/Button_Checked.png" />
                                                            indicates contact is approved for Call Directory
                                                            <br />
                                                            <%--Step 2: Select one or more contacts--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="headingP">
                                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                <tr>
                                                                    <td>
                                                                        Contacts
                                                                    </td>
                                                                    <td align="right">
                                                                    <%--    <asp:Button ID="btnImport" runat="server" CausesValidation="false" CssClass="mailbtnP"
                                                                            Text="Import CSV" OnClick="btnImport_Click" />--%>
                                                                        <asp:Button ID="btnPnlCAddContact" runat="server" CausesValidation="false" CssClass="mailbtnP"
                                                                            Text="Add Contact" OnClick="btnPnlCAddContact_Click" />
                                                                        <asp:Button ID="btnDeleteContact" runat="server" CausesValidation="false" CssClass="mailbtnP"
                                                                            OnClick="btnDeleteContact_Click" OnClientClick="return ConfirmDelete (this.form)"
                                                                            Text="Delete Contact(s)" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <input id="scrollPos" runat="server" type="hidden" value="0" />
                                                        <td class="borderP">
                                                            <table border="0" cellpadding="0" cellspacing="0" class="seachareaP" width="100%">
                                                                <tr>
                                                                    <td style="padding-top: 10px; padding-bottom: 10px;">
                                                                        <strong style="padding-left: 5px; width: 70px;">Contact Search:</strong>&nbsp;&nbsp;<asp:TextBox
                                                                            ID="txtSearchContact" runat="server" Style="margin-left: 8px;" Width="200px"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding-right: 5px;">
                                                                        <asp:Button ID="btnsearch" runat="server" CssClass="seachareabtn" OnClientClick="return checkdata()"
                                                                            Text="GO" OnClick="btnsearch_Click" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <table border="0" cellpadding="0" cellspacing="0" style="background-color: #CCFFFF;">
                                                                <tr>
                                                                    <td>
                                                                        <div runat="server" onscroll="javascript:setScroll(this);" style="height: 310px;
                                                                            width: 350px; overflow: scroll;" id="mycustomscroll" class="flexcroll Scroller">
                                                                            <asp:GridView ID="GVCallIndexContacts" runat="server" AllowPaging="true" AutoGenerateColumns="False"
                                                                                BorderWidth="0" CssClass="Allleft" DataKeyNames="ContactID" GridLines="None"
                                                                                PagerSettings-Position="TopAndBottom" PagerStyle-Width="30px" PageSize="500"
                                                                                Width="100%" ShowHeader="false">
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderStyle-CssClass="groupsheadP" ItemStyle-Height="25px">
                                                                                        <ItemTemplate>
                                                                                            <asp:CheckBox runat="server" ID="chkContactEmail" CssClass="myCheckbox" Text='<%# String.Format("{0} {1}", Eval("FirstName"), Eval("LastName")) %>'>
                                                                                            </asp:CheckBox>
                                                                                            <br />
                                                                                            <asp:Label ID="lblEmail" runat="server" ToolTip='<%# Eval("EmailID") %>' Text='<%#Eval("EmailID")%>' style="padding-left:21px;" />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField>
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblButtonchecked" runat="server" ToolTip="Allowed for sending invitation"
                                                                                                Visible='<%# Convert.ToInt32(Eval("IsAllowedToSendIvitation"))==0 ?false:true %>'>
                                                                                          <img src="../../Images/Button_Checked.png" /></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderStyle-CssClass="groupsheadP">
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkEditContact" runat="server" Text="Edit" OnClick="lnkEditContact_Click"
                                                                                                CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'><img src="../../Images/Dashboard/icon_modify.gif" alt=""/></asp:LinkButton>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle CssClass="gvgroup" />
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                                <EmptyDataTemplate>
                                                                                    <span style="padding-left: 5px;">No contacts found </span>
                                                                                </EmptyDataTemplate>
                                                                                <PagerStyle CssClass="PageContactManage" />
                                                                            </asp:GridView>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <%-- Add Groups--%>
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <asp:Label ID="lblGTarget" runat="server"></asp:Label>
                            <cc1:ModalPopupExtender ID="MPEGroups" runat="server" BackgroundCssClass="modal"
                                PopupControlID="pnlGroups" TargetControlID="lblGTarget" CancelControlID="closeImage">
                            </cc1:ModalPopupExtender>
                            <asp:Panel ID="pnlGroups" runat="server" Style="display: none" Width="450px">
                                <table cellspacing="0" cellpadding="0" width="400px" align="center" border="0" style="height: 320px;
                                    background-color: White;">
                                    <tr>
                                        <td align="center">
                                            <asp:UpdateProgress ID="UpdateProgress10" runat="server" DisplayAfter="3">
                                                <ProgressTemplate>
                                                    <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                        <td align="right">
                                            <asp:ImageButton ID="closeImage" runat="server" ImageUrl="~/images/popup_close.gif"
                                                CausesValidation="false"></asp:ImageButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="padding: 10px;">
                                            <div style="height: 300px; overflow-y: auto; border: solid 1px #4684C5; background-color: #CCFFFF;">
                                                <table cellpadding="0" cellspacing="0" width="100%" border="0" class="mailcontent">
                                                    <tr>
                                                        <td style="font-weight: bold; font-size: 14px; padding-bottom: 10px; padding-top: 10px"
                                                            align="left" colspan="2" class="groupsheadP">
                                                            Contact Group Information
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="2" style="padding-bottom: 10px;">
                                                            <asp:Label ID="lblgroupName" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top">
                                                            Group Name:
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtcontactgroupname" runat="server" MaxLength="15" Width="120px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvGName" runat="server" ControlToValidate="txtcontactgroupname"
                                                                ErrorMessage="*" Display="Dynamic" ValidationGroup="Groups"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top" style="padding-top: 10px;">
                                                            Group Description:
                                                        </td>
                                                        <td style="padding-top: 10px;">
                                                            <asp:TextBox ID="txtcontactgroupdes" runat="server" Width="210px" MaxLength="300"
                                                                Style="resize: none;" TextMode="MultiLine" Height="50px"></asp:TextBox>
                                                            <%--<asp:RequiredFieldValidator ID="rfvGDesc" runat="server" ControlToValidate="txtcontactgroupdes"
                                                            ErrorMessage="*" Display="Dynamic" ValidationGroup="Groups"></asp:RequiredFieldValidator>--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding-top: 10px;">
                                                            &nbsp;
                                                        </td>
                                                        <td style="padding-top: 10px;">
                                                            <asp:Button ID="btnAdd" runat="server" Text="Add" ValidationGroup="Groups" CssClass="mailbtnP"
                                                                OnClick="btnAdd_Click" />&nbsp;
                                                            <asp:Button ID="btnCancelGroup" runat="server" Text="Cancel" CssClass="mailbtnP"
                                                                CausesValidation="false" />
                                                            <asp:HiddenField ID="hdnGroupID" runat="server" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
                <%-- Add Contacts--%>
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <asp:Label ID="lblCTarget" runat="server"></asp:Label>
                            <cc1:ModalPopupExtender ID="MPEContacts" runat="server" BackgroundCssClass="modal"
                                PopupControlID="pnlContacts" TargetControlID="lblCTarget" CancelControlID="closeImage1">
                            </cc1:ModalPopupExtender>
                            <asp:Panel ID="pnlContacts" runat="server" Style="display: none" Width="600px">
                                <table cellspacing="0" cellpadding="0" width="400px" align="center" border="0" style="height: 500px;
                                    background-color: White;">
                                    <tr>
                                        <td align="center">
                                            <asp:UpdateProgress ID="UpdateProgress2" runat="server" DisplayAfter="3">
                                                <ProgressTemplate>
                                                    <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                        <td align="right" style="padding: 10px;">
                                            <asp:ImageButton ID="closeImage1" runat="server" ImageUrl="~/images/popup_close.gif"
                                                CausesValidation="false"></asp:ImageButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="padding: 10px;">
                                            <div style="height: 430px; width: 600px; overflow-y: auto; border: solid 1px #4684C5;
                                                background-color: #CCFFFF;">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td align="center" colspan="2">
                                                            <asp:Label runat="server" ID="lblmsg1" ForeColor="Red"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="font-weight: bold; font-size: 14px; padding: 10px; padding-bottom: 0px;"
                                                            align="left" class="groupsheadP">
                                                            Contact Information
                                                        </td>
                                                        <td style="font-weight: bold; font-size: 14px; padding: 10px; padding-left: 0px;
                                                            padding-bottom: 0px;" align="left" colspan="2" class="groupsheadP">
                                                            Select Buttons to send message<%--Select Groups--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top"  style="width: 350px;">
                                                            <table class="mycontact-add">
                                                             <tr>
                                                                    <td colspan="2">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top" align="right">
                                                                        First Name:
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtFirstname" CssClass="infoinput" runat="server"></asp:TextBox><span style="color:Red;font-size:medium;"> *</span> <br />
                                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtFirstname"
                                                                            ErrorMessage="First name is mandatory." Display="Dynamic" ValidationGroup="Contacts"
                                                                            Font-Size="Small"></asp:RequiredFieldValidator>
                                                                       
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right">
                                                                        Last Name:
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtLastname" CssClass="infoinput" runat="server"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top" align="right">
                                                                        Email:
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtEmail" CssClass="infoinput" runat="server"></asp:TextBox><span style="color:Red;font-size:medium;"> *</span><br />
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmail"
                                                                            ErrorMessage="Email id is mandatory." Display="Dynamic" ValidationGroup="Contacts"
                                                                            Font-Size="Small"></asp:RequiredFieldValidator>
                                                                        <asp:RegularExpressionValidator ID="revEmailID" runat="server" ControlToValidate="txtEmail"
                                                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Invalid email."
                                                                            Display="Dynamic" ValidationGroup="Contacts" Font-Size="Small"></asp:RegularExpressionValidator>
                                                                      
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top" align="right">
                                                                        Mobile:
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtMobile" CssClass="infoinput" MaxLength="12" runat="server" onkeyup="FormatPhoneNumber(this,event,3);"></asp:TextBox><span style="color:Red;font-size:medium;"> *</span><br />
                                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMobile"
                                                                            ErrorMessage="Mobile number is mandatory." Display="Dynamic" ValidationGroup="Contacts"
                                                                            Font-Size="Small"></asp:RequiredFieldValidator>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtMobile"
                                                                            ErrorMessage="Invalid mobile number." Display="Dynamic" ValidationExpression=".{12}.*"
                                                                            ValidationGroup="Contacts"></asp:RegularExpressionValidator><br />
                                                                        (xxx-xxx-xxxx)
                                                                       
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top" align="right">
                                                                        Title/Position:
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtPosition" CssClass="infoinput" runat="server"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top" align="right">
                                                                        Organization:
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtOrganization" CssClass="infoinput" runat="server"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top" style="padding-top: 3px; padding-bottom: 5px; padding-left: 10px;
                                                                        font-size: 13px;" colspan="2">
                                                                        <asp:CheckBox ID="chkSendInvitation" runat="server"></asp:CheckBox>
                                                                        Allow sending invitation to display directory.
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" style="display: none;">
                                                                        <table width="100%">
                                                                            <tr>
                                                                                <td align="right">
                                                                                    Company Name:
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtcompanyname" CssClass="infoinput" runat="server"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right">
                                                                                    Address:
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtAddress" CssClass="infoinput" runat="server"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right">
                                                                                    City:
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtCity" CssClass="infoinput" runat="server"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right">
                                                                                    State:
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtState" CssClass="infoinput" runat="server"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right">
                                                                                    Zip Code:
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtZipcode" CssClass="infoinput" runat="server"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td valign="top" align="right">
                                                                                    Landline:
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtPhone" CssClass="infoinput" MaxLength="12" runat="server" onkeyup="FormatPhoneNumber(this,event,1);"></asp:TextBox><br />
                                                                                    (xxx-xxx-xxxx)
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td valign="top" align="right">
                                                                                    Fax:
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtFax" CssClass="infoinput" MaxLength="12" runat="server" onkeyup="FormatPhoneNumber(this,event,2);"></asp:TextBox><br />
                                                                                    (xxx-xxx-xxxx)
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top" style="padding-top: 3px; padding-bottom: 5px; padding-left: 10px;
                                                                        font-size: 13px;" colspan="2">
                                                                        <asp:CheckBox ID="chkMobile" runat="server"></asp:CheckBox>
                                                                        This contact has agreed to receive emails and SMS(text messages).
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td valign="top" align="left" style="border: 1px solid #CCC;">
                                                            <asp:HiddenField ID="hdnSelG" Value="0" />
                                                            <asp:CheckBoxList ID="chkGroupList" runat="server" RepeatColumns="1" RepeatDirection="Vertical"
                                                                CellPadding="5" CellSpacing="0" CssClass="myCheckbox">
                                                            </asp:CheckBoxList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="padding-top: 10px;" align="center">
                                                            <asp:Button ID="btnContactAdd" runat="server" Text="Add" CssClass="mailbtnP" OnClick="btnContactAdd_Click"
                                                                ValidationGroup="Contacts" OnClientClick="return ValidateGroupSelection();" />&nbsp;
                                                            <asp:Button ID="btnContactCancel" runat="server" Text="Cancel" CssClass="mailbtnP"
                                                                CausesValidation="false" />
                                                            <asp:HiddenField ID="hdnContactID" runat="server" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <asp:Label ID="lblImport" runat="server"></asp:Label>
                            <cc1:ModalPopupExtender ID="modalImport" runat="server" BackgroundCssClass="modal"
                                PopupControlID="pnlImport" TargetControlID="lblImport" CancelControlID="imgImportClose">
                            </cc1:ModalPopupExtender>
                            <asp:Panel ID="pnlImport" runat="server" Style="display: none" Width="600px">
                                <table border="0" cellpadding="0" cellspacing="0" width="100%" style="background-color: White;
                                    padding: 10px;">
                                    <tr>
                                        <td align="center">
                                            <asp:UpdateProgress ID="UpdateProgress3" runat="server" DisplayAfter="3">
                                                <ProgressTemplate>
                                                    <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                        <td align="right" style="padding: 10px;">
                                            <asp:ImageButton ID="imgImportClose" runat="server" ImageUrl="~/images/popup_close.gif"
                                                CausesValidation="false"></asp:ImageButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="text-align: center; color: Red;">
                                            <asp:Label ID="lblError" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Panel ID="pnlImportAddGroup" runat="server">
                                                <table cellpadding="0" cellspacing="0" width="60%" border="0" class="mailcontent"
                                                    align="center">
                                                    <tr>
                                                        <td align="left" width="100px">
                                                            Select Button
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlGroups" runat="server" Width="200px" Height="20px">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr style="display: none;">
                                                        <td valign="top" colspan="2" align="center" style="padding: 10px 0px;">
                                                            <span style="font-weight: bold; font-size: 16px;">OR</span>
                                                        </td>
                                                    </tr>
                                                    <tr style="display: none;">
                                                        <td valign="top">
                                                            Add Group:
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtImportGroup" runat="server" Width="200px" Height="20px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding-top: 10px;">
                                                            &nbsp;
                                                        </td>
                                                        <td style="padding-top: 10px;">
                                                            <asp:Button ID="btnGroupNext" runat="server" Text="Next" CssClass="mailbtnP" OnClick="btnGroupNext_Click"
                                                                OnClientClick="return ValidateImportGroup();" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlCSV" runat="server" Visible="false">
                                                <table cellspacing="0" cellpadding="0" width="100%" border="0" style="height: 140px;">
                                                    <tbody>
                                                        <tr>
                                                            <td align="center" style="font-size: 18px; color: green" colspan="2">
                                                                <br />
                                                                <strong>Upload CSV file to Import Contacts</strong>
                                                            </td>
                                                        </tr>
                                                        <tr valign="top">
                                                            <td>
                                                                <div style="text-align: right;">
                                                                    <strong>Upload CSV file </strong>
                                                                </div>
                                                            </td>
                                                            <td style="text-align: left; padding-left: 20px;">
                                                                <asp:FileUpload ID="FileUpload1" runat="server"></asp:FileUpload>
                                                            </td>
                                                        </tr>
                                                        <tr valign="top">
                                                            <td colspan="2" align="center">
                                                                <asp:Button ID="CSVSubmit" OnClick="CSVSubmit_Click" runat="server" Text="Upload"
                                                                    CssClass="bold" CausesValidation="False" Width="60px" Height="30px"></asp:Button>&nbsp;
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel align="center" ID="pnlImportColumns" runat="server" Visible="false">
                                                <table border="0" align="center" bgcolor="#eeeeee" style="padding: 10px;">
                                                    <tr>
                                                        <td align="center">
                                                            <table width="250px">
                                                                <tr>
                                                                    <td>
                                                                        <asp:ValidationSummary ID="VSImportCSV" runat="server" ValidationGroup="A" Style="text-align: left;"
                                                                            HeaderText="The following error(s) occurred:" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <%if (hdnImportGroupName.Value != "")
                                                              { %>
                                                            <font size='3' color='green'>Your selected group is - </font><strong><font color='#3399CC'
                                                                size='3'>
                                                                <%= hdnImportGroupName.Value%>. </font></strong>
                                                            <%} %>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <%if (Filename != "" && Filename != null)
                                                              { %>
                                                            <%=Filenametext%>
                                                            <asp:LinkButton ID="lnkChangeFile" Font-Size="Medium" runat="server" Text="click here"
                                                                OnClick="lnkChangeFile_Click"></asp:LinkButton>
                                                            <%=Filenametexttext%>
                                                            <%} %>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <br />
                                                            <table border="0" cellpadding="0" cellspacing="0" style="line-height: 25px;">
                                                                <tr>
                                                                    <td align="left">
                                                                        <strong>Email:</strong>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlemail" runat="server" onchange="checkSelects(this.value, 0, this);">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator InitialValue="------- Select Appropriate Item ------"
                                                                            ControlToValidate="ddlemail" ID="RFVEmail" runat="server" ErrorMessage="Email is mandatory."
                                                                            ValidationGroup="A">*</asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" style="padding-right: 100px;">
                                                                        <strong>First Name:</strong>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlfirstname" runat="server" onchange="checkSelects(this.value, 1, this);">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator InitialValue="------- Select Appropriate Item ------"
                                                                            ControlToValidate="ddlfirstname" ID="RequiredFieldValidator3" runat="server"
                                                                            ErrorMessage="First Name is mandatory." ValidationGroup="A">*</asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        <strong>Last Name:</strong>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddllastname" runat="server" onchange="checkSelects(this.value, 2, this);">
                                                                        </asp:DropDownList>
                                                                        &nbsp;&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        <strong>Mobile Number:</strong>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlmobile" runat="server" onchange="checkSelects(this.value, 3, this);">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator InitialValue="------- Select Appropriate Item ------"
                                                                            ControlToValidate="ddlmobile" ID="RequiredFieldValidator6" runat="server" ErrorMessage="Mobile Number is mandatory."
                                                                            ValidationGroup="A">*</asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        <strong>Title:</strong>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlTitle" runat="server" onchange="checkSelects(this.value, 4, this);">
                                                                        </asp:DropDownList>
                                                                        <%--     <asp:RequiredFieldValidator InitialValue="------- Select Appropriate Item ------"
                                                                        ControlToValidate="ddlTitle" ID="RequiredFieldValidator8" runat="server" ErrorMessage="Title is mandatory."
                                                                        ValidationGroup="A">*</asp:RequiredFieldValidator>--%>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        <strong>Organization:</strong>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlOrg" runat="server" onchange="checkSelects(this.value, 5, this);">
                                                                        </asp:DropDownList>
                                                                        <%--  <asp:RequiredFieldValidator InitialValue="------- Select Appropriate Item ------"
                                                                        ControlToValidate="ddlOrg" ID="RequiredFieldValidator7" runat="server" ErrorMessage="Organization is mandatory."
                                                                        ValidationGroup="A">*</asp:RequiredFieldValidator>--%>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" style="display: none;">
                                                                        <table width="100%">
                                                                            <tr>
                                                                                <td align="left">
                                                                                    <strong>Company Name:</strong>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlcompanyname" runat="server" onchange="checkSelects(this.value, 6, this);">
                                                                                    </asp:DropDownList>
                                                                                    &nbsp;&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left">
                                                                                    <strong>Address:</strong>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddladdress" runat="server" onchange="checkSelects(this.value, 7, this);">
                                                                                    </asp:DropDownList>
                                                                                    &nbsp;&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left">
                                                                                    <strong>City:</strong>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlcity" runat="server" onchange="checkSelects(this.value, 8, this);">
                                                                                    </asp:DropDownList>
                                                                                    &nbsp;&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left">
                                                                                    <strong>State:</strong>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlstate" runat="server" onchange="checkSelects(this.value, 9, this);">
                                                                                    </asp:DropDownList>
                                                                                    &nbsp;&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left">
                                                                                    <strong>Zip Code:</strong>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlzipcode" runat="server" onchange="checkSelects(this.value, 10, this);">
                                                                                    </asp:DropDownList>
                                                                                    &nbsp;&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left">
                                                                                    <strong>Phone Number:</strong>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlphone" runat="server" onchange="checkSelects(this.value, 11, this);">
                                                                                    </asp:DropDownList>
                                                                                    &nbsp;&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left">
                                                                                    <strong>Fax Number:</strong>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlfax" runat="server" onchange="checkSelects(this.value, 12, this);">
                                                                                    </asp:DropDownList>
                                                                                    &nbsp;&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:CheckBox ID="chkauthorize" runat="server" />
                                                            &nbsp;&nbsp;&nbsp;&nbsp;These contacts have agreed to receive email and SMS(text messages).
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Button ID="Submit1" Text="Continue" runat="server" OnClick="Submit1_Click" ValidationGroup="A"
                                                                OnClientClick="return ValidateCSVContacts();" Width="80px" Height="30px" />
                                                            <asp:Button ID="Cancelcontacts" Text="Cancel" runat="server" CausesValidation="false"
                                                                OnClick="Cancelcontacts_Click" Width="60px" Height="30px" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="color: red" align="center">
                                                            <asp:Label ID="lblerrormsg" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="CSVSubmit" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <div align="center" style="padding-bottom: 3px; padding-top: 3px;">
        <asp:Button ID="btnDashboard" runat="server" Text="Dashboard" Style="padding: 5px;"
            OnClick="btnDashboard_Click" />
    </div>
    <input type="hidden" id="hdnCsvName" runat="server" />
    <asp:HiddenField ID="hdnImportGroupId" runat="server" />
    <asp:HiddenField ID="hdnImportGroupName" runat="server" />
    <script type="text/javascript">
        function checkdata() {
            if (document.getElementById('<%=txtSearchContact.ClientID %>').value != "") {
                return true;
            }
            else {
                alert('Please enter keyword to search.');
                return false;
            }
        }
        function ConfirmDelete(frm) {
            for (i = 0; i < frm.length; i++) {
                if (frm.elements[i].name.indexOf("chkContactEmail") != -1) {
                    if (frm.elements[i].checked) {
                        return confirm('This will completely remove the selected contact(s) from your contact list. Are you sure you want to delete your selection(s)?')
                    }
                }
            }
            alert('Please select at least one contact to delete');
            return false;
        }
        function ConfirmGroupDelete(frm) {
            for (i = 0; i < frm.length; i++) {
                if (frm.elements[i].name.indexOf("chkGroupName") != -1) {
                    if (frm.elements[i].checked) {
                        return confirm('Are you sure you want to delete your selection(s)?')
                    }
                }
            }
            alert('Please select at least one group to delete');
            return false;
        }
        function FormatPhoneNumber(id, event, Vtype) {

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
            val = id.value.replace(/\D/g, '');
            var newVal = '';
            if (val.length > 10) {
                val = val.substring(0, 10)
            }
            while (val.length >= 3 && newVal.length <= 7) {
                newVal += val.substr(0, 3) + '-';
                val = val.substr(3);
            }
            newVal += val;
            id.value = newVal;
            if (newVal.length == 12) {
                if (newVal.length == 12) {
                    window.setTimeout(function () { id.focus(); }, 0);
                }
            }

        }
        function ValidateGroupSelection() {
            if (Page_ClientValidate('Contacts')) {
                if (document.getElementById('<%=chkMobile.ClientID%>').checked == false) {
                    alert('Agreement to receive email and SMS must be checked.');
                    return false;
                }
                var chkListModules = document.getElementById('<%= chkGroupList.ClientID %>');
                if (chkListModules == null) {
                    alert('Please select at least one button name.');
                    return false
                }

                var chkListinputs = chkListModules.getElementsByTagName("input");
                if (chkListinputs.length > 0) {
                    for (var i = 0; i < chkListinputs.length; i++) {
                        if (chkListinputs[i].checked) {
                            //args.IsValid = true;
                            return true;
                        }
                    }
                    alert('Please select at least one button name.');
                }
                else
                    alert('Please build the groups to add contacts.');


            }
            return false;
        }
        function ValidateImportGroup() {
            var isValid = false;
            if (document.getElementById('<%=ddlGroups.ClientID%>').value != "")
                isValid = true;
            if (document.getElementById('<%=txtImportGroup.ClientID%>').value.trim() != "")
                isValid = true;
            if (isValid == false)
                alert('Please select a button.');
            // alert('Please select a group or add new group.');
            return isValid;
        }
        function checkSelects(value, index, obj) {
            var sels;
            var i;

            if (value != '------- Select Appropriate Item ------') {
                sels = document.getElementsByTagName('select');

                for (i = 0; i < sels.length; i++) {
                    if (i != index) {
                        if (sels[i].value == value) {
                            alert("This item has already been selected; please choose a different one.");
                            obj.selectedIndex = 0;
                            i = sels.length;
                        }
                    }
                }
            }
        }
        function ValidateCSVContacts() {
            if (Page_ClientValidate('A')) {
                if (document.getElementById('<%=chkauthorize.ClientID%>').checked == false) {
                    alert('Agreement to receive email and SMS must be checked.');
                    return false;
                }
                return true;
            }
            return false;
        }



        function GetSelectedValue() {

            var CHK = document.getElementById("<%=chkGroupList.ClientID%>");
            var checkbox = CHK.getElementsByTagName("input");
            var label = CHK.getElementsByTagName("label");



            debugger;

            /*
            for (var i = 1; i < checkbox.length; i++) {

            if (checkbox[i].checked) {
            checkbox[0].checked = false;

            }

            }

            if (checkbox[0].checked) {
            //                var str = label[0].innerHTML;
            //                var res = str.split(" ", 2);
            //                if (res == 'Not,Assigned') {
            var r = confirm("Are you sure you want to assign the contact to Not Assigned ?");
            if (r == true) {
            checkbox[0].checked = true;

            }
            else {
            checkbox[0].checked = false;

            }

            // }
            }
            */

        }

        $(function () {

            $('#<%=chkGroupList.ClientID%> :checkbox').live('click', function () {

                //$(this).is(':checked')
                var controlID = this.id;
                if (controlID.toString().indexOf("_0") > -1 && $(this).is(':checked')) {
                    var $all = $("#<%=chkGroupList.ClientID%>").find(":checkbox");
                    var $first = $all.eq(0);
                    if ($first.is(":checked")) {
                        if (confirm("Are you sure you want to check this box?")) {
                            $all.not($first).prop("checked", false);
                        } else {
                            ($first).prop("checked", false)
                        }
                    }
                }
                else if ($(this).is(':checked')) {
                    var $all = $("#<%=chkGroupList.ClientID%>").find(":checkbox");
                    var $first = $all.eq(0);
                    ($first).prop("checked", false);
                }

            });


        });

    </script>
</asp:Content>
