<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true"
    CodeBehind="MissingKid.aspx.cs" Inherits="USPDHUB.Business.MyAccount.MissingKid"
    ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/TimeControl.ascx" TagName="TimeControl" TagPrefix="TimerUC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <script src="../../Scripts/flyers/jquery-1.7.2.js" type="text/javascript"></script>
    <link href="../../css/Bulletins.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function ShowWatermark(value) {
            if (value.checked) {
                document.getElementById("imgwatermark").style.display = "block";
            }
            else {
                document.getElementById("imgwatermark").style.display = "none";
            }

        }

    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" DefaultButton="btnSave" runat="server">
                <div id="wrapper">
                    <div class="headernav">
                        <%=BulletinName %><asp:TextBox ID="txt" runat="server" Width="0" BorderStyle="none"
                            BorderColor="white" Style="border: 0; border-color: White!important;"></asp:TextBox>
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
                    <div>
                        <div style="margin: 0 auto; width: 100%; overflow: hidden;">
                            <asp:Label runat="server" ID="lblLogoHeader"></asp:Label>
                        </div>
                    </div>
                    <div class="clear">
                    </div>
                    <div class="contentwrap">
                        <div class="largetxt">
                            Missing Child</div>
                        <div class="largetxt" style="text-align: center; padding-left: 110px; height: 35px;
                            display: none;">
                            <asp:DropDownList ID='ddlMissingChildTypes' runat="server" Width="320px" CssClass="select1"
                                Font-Size="14" Height="32">
                                <asp:ListItem Text="Missing Child" Value="Missing Child"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form_wrapper">
                            <div class="clear10">
                            </div>
                            <div class="fields_wrap">
                                <label style="color: Red; font-size: 16px; margin-left: 100px;">
                                    * Marked fields are mandatory.</label>
                            </div>
                            <div class="fields_wrap">
                                <div class="left_lable">
                                    <font color="red">*</font>
                                    <label>
                                        Date :</label></div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtBulletinDate" runat="server"></asp:TextBox>
                                    <cc1:TextBoxWatermarkExtender ID="MaskedEditExtender1" TargetControlID="txtBulletinDate"
                                        WatermarkText="MM/DD/YYYY" runat="server" WatermarkCssClass="watermarkbulletindate">
                                    </cc1:TextBoxWatermarkExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                                        ControlToValidate="txtBulletinDate" ValidationGroup="SV" ErrorMessage="Date is mandatory.">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic"
                                        ControlToValidate="txtBulletinDate" ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                        ValidationGroup="SV" ErrorMessage="Invalid Date Format of Date.">*</asp:RegularExpressionValidator>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtBulletinDate"
                                        Format="MM/dd/yyyy" CssClass="MyCalendar" />
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <font color="red">*</font>
                                    <label>
                                        First Name :</label>
                                </div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="txtfild1"></asp:TextBox>
                                    &nbsp;<asp:RequiredFieldValidator ID="REFVFN" runat="server" ControlToValidate="txtFirstName"
                                        ValidationGroup="SV" ErrorMessage="First Name is mandatory.">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <font color="red">*</font>
                                    <label>
                                        Last Name :</label></div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtLastName" runat="server" CssClass="txtfild1"></asp:TextBox>
                                    &nbsp;<asp:RequiredFieldValidator ID="REFVLN" runat="server" ControlToValidate="txtLastName"
                                        ValidationGroup="SV" ErrorMessage="Last Name is mandatory.">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        City :</label>
                                </div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtCity" runat="server" CssClass="txtfild1"></asp:TextBox>
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        State :</label>
                                </div>
                                <div class="right_fields">
                                    <asp:DropDownList ID="ddlStates" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="browseimg_wrap">
                                <div id='imgwatermark' style="position: absolute; display: none; text-align: center;">
                                </div>
                                <div class="avatar" style="text-align: center;">
                                    <div id='divDefaultPerson' style="width: 310px; min-height: 140px; display: block;">
                                    </div>
                                    <asp:HiddenField ID="hdnDefaultPerson" runat="server" />
                                    <asp:HiddenField ID="hdnDPLink" runat="server" />
                                </div>
                                <label>
                                    <img style="cursor: pointer;" onclick="EditImage('divDefaultPerson');" src="../../Images/Dashboard/Browseimg.png" />
                                </label>
                                <div style="float: right; margin-left: 0px;">
                                    <a href="javascript:ModalHelpPopup('Add Image to Content',20,'');">
                                        <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" /></a>
                                </div>
                                <div id="imgDelete1" style="margin-top: 5px; display: none;">
                                    <asp:Button ID="btnImgDelete1" runat="server" CausesValidation="false" border="0"
                                        CssClass="btn" Text="Delete Image" OnClientClick="return FirstImageDelete();"
                                        Width="151px" />
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        Caption :</label>
                                </div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtCaption" runat="server" CssClass="txtfild1" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <font color="red">&nbsp</font>
                                    <label>
                                        Date Missing :</label></div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtLCD" runat="server"></asp:TextBox>
                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" TargetControlID="txtLCD"
                                        WatermarkText="MM/DD/YYYY" runat="server" WatermarkCssClass="watermarkbulletindate">
                                    </cc1:TextBoxWatermarkExtender>
                                    <asp:RegularExpressionValidator ID="REVLCD" runat="server" Display="Dynamic" ControlToValidate="txtLCD"
                                        ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                        ValidationGroup="SV" ErrorMessage="Invalid Date Format of Date Missing.">*</asp:RegularExpressionValidator>
                                    <cc1:CalendarExtender ID="CELCD" runat="server" TargetControlID="txtLCD" Format="MM/dd/yyyy"
                                        CssClass="MyCalendar" />
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 9px; color: #313131;">Last Seen Specific</span> <span
                                        style="padding-left: 9px; color: #313131;">Location :</span>
                                </div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtLastSeenSpec" runat="server" CssClass="txtfild1" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        Gender :</label></div>
                                <div class="right_fields">
                                    <asp:DropDownList ID="ddlGender" runat="server" CssClass="select1">
                                        <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                                        <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        Age :</label></div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtAge" runat="server" CssClass="txtfild2"></asp:TextBox>
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        Height :</label></div>
                                <div class="right_fields">
                                    <div style="float: left; margin-right: 15px;">
                                        <asp:DropDownList ID="ddlFeet" runat="server">
                                        </asp:DropDownList>
                                        Feet</div>
                                    <div style="float: left;">
                                        <asp:DropDownList ID="ddlInches" runat="server">
                                        </asp:DropDownList>
                                        Inches</div>
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        Weight :</label></div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtWeight" runat="server" CssClass="txtfild2"></asp:TextBox>
                                    &nbsp; Pounds &nbsp;<asp:RegularExpressionValidator ID="REVWeight" runat="server"
                                        Display="Dynamic" ForeColor="Red" ControlToValidate="txtWeight" ValidationGroup="SV"
                                        ErrorMessage="Enter a Valid Weight" ValidationExpression="^[0-9.]+$"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        Hair :</label></div>
                                <div class="right_fields">
                                    <asp:DropDownList ID="ddlHair" runat="server" CssClass="select1">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        Eyes :</label></div>
                                <div class="right_fields">
                                    <asp:DropDownList ID="ddlEyes" runat="server" CssClass="select1">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        Race :</label></div>
                                <div class="right_fields">
                                    <asp:DropDownList ID="ddlRace" runat="server" CssClass="select1">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        Identifying Marks :</label></div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtIdentityMarks" runat="server" TextMode="MultiLine" CssClass="txtfild1"></asp:TextBox>
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 9px; color: #313131;">Brief Description of </span><span
                                        style="padding-left: 9px; color: #313131;">Circumstances, </span><span style="padding-left: 9px;
                                            color: #313131;">Clothing, etc. :</span></div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtBriefDesc" runat="server" TextMode="MultiLine" CssClass="txtfild1"></asp:TextBox>
                                </div>
                            </div>
                            <div class="browseimg_wrap">
                                <div class="avatar" style="text-align: center;">
                                    <div id='divAnotherImg' style="width: 310px; min-height: 140px; display: block;">
                                    </div>
                                    <asp:HiddenField ID="hdnAnotherImg" runat="server" />
                                    <asp:HiddenField ID="hdnAnotherImgLink" runat="server" />
                                </div>
                                <label>
                                    <img style="cursor: pointer;" onclick="EditImage('divAnotherImg');" src="../../Images/Dashboard/Browseimg.png" />
                                </label>
                                <div style="float: right; margin-left: 0px;">
                                    <a id="anchor2" href="javascript:ModalHelpPopup('Add Image to Content',20,'');">
                                        <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" /></a>
                                </div>
                                <div id="imgDelete2" style="margin-top: 5px; display: none;">
                                    <asp:Button ID="btnImgDelete2" runat="server" CausesValidation="false" border="0"
                                        CssClass="btn" Text="Delete Image" OnClientClick="return SecondImageDelete();"
                                        Width="151px" />
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        Caption :</label>
                                </div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtAnotherCaption" runat="server" CssClass="txtfild1" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                            <div class="browseimg_wrap">
                                <div class="avatar" style="text-align: center;">
                                    <div id='divAnother1Img' style="width: 310px; min-height: 140px; display: block;">
                                    </div>
                                    <asp:HiddenField ID="hdnAnother1Img" runat="server" />
                                    <asp:HiddenField ID="hdnAnother1ImgLink" runat="server" />
                                </div>
                                <label>
                                    <img style="cursor: pointer;" onclick="EditImage('divAnother1Img');" src="../../Images/Dashboard/Browseimg.png" />
                                </label>
                                <div style="float: right; margin-left: 0px;">
                                    <a id="a1" href="javascript:ModalHelpPopup('Add Image to Content',20,'');">
                                        <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" /></a>
                                </div>
                                <div id="imgDelete3" style="margin-top: 5px; display: none;">
                                    <asp:Button ID="btnImgDelete3" runat="server" CausesValidation="false" border="0"
                                        CssClass="btn" Text="Delete Image" OnClientClick="return ThirdImageDelete();"
                                        Width="151px" />
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        Caption :</label>
                                </div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtAnother1Caption" runat="server" CssClass="txtfild1" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        KlaasKIDS Case # :</label>
                                </div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtKidsCase" runat="server" CssClass="txtfild1"></asp:TextBox>
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 9px; color: #313131;">Police Department :</span>
                                </div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtPDDept" runat="server" CssClass="txtfild1" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 9px; color: #313131;">Police Department </span><span style="padding-left: 9px;
                                        color: #313131;">Phone Number :</span>
                                </div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtPDPhone" runat="server" CssClass="checkphone txtfild1"></asp:TextBox>
                                </div>
                            </div>
                            <div class="clear">
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 9px; color: #313131;">KlaasKIDS :</span>
                                </div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtKidsDesc" runat="server" CssClass="txtfild1" Text="KlaasKIDS"
                                        TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 9px; color: #313131;">KlaasKIDS Phone </span><span style="padding-left: 9px;
                                        color: #313131;">Number :</span>
                                </div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtKidsPhone" runat="server" CssClass="checkphone txtfild1"></asp:TextBox>
                                </div>
                            </div>
                            <div class="clear">
                            </div>
                            <div class="fields_wrap" style="display: none;">
                                <div class="left_lable">
                                    &nbsp;
                                    <label>
                                        Date of Birth :</label></div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtDOB" runat="server" onblur="ageCount();"></asp:TextBox>
                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" TargetControlID="txtDOB"
                                        WatermarkText="MM/DD/YYYY" runat="server" WatermarkCssClass="watermarkbulletindate">
                                    </cc1:TextBoxWatermarkExtender>
                                    <asp:RegularExpressionValidator ID="REVDOB" runat="server" Display="Dynamic" ControlToValidate="txtDOB"
                                        ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                        ValidationGroup="SV" ErrorMessage="Invalid format for Date of Birth. (mm/dd/yyyy)">*</asp:RegularExpressionValidator>
                                    <cc1:CalendarExtender ID="CEDOB" runat="server" TargetControlID="txtDOB" Format="MM/dd/yyyy"
                                        CssClass="MyCalendar" />
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        Expiration Date & Time:</label></div>
                                <div class="right_fields" style="width: 470px;">
                                    <table width="85%" cellpadding="0" cellspacing="0" id='tblExTime'>
                                        <colgroup>
                                            <col width="120px" />
                                            <col width="*" />
                                        </colgroup>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtExpires" runat="server" onChange="ShowExTimeDiv();"></asp:TextBox>
                                                <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" TargetControlID="txtExpires"
                                                    WatermarkText="MM/DD/YYYY" runat="server" WatermarkCssClass="watermarkbulletindate">
                                                </cc1:TextBoxWatermarkExtender>
                                                <asp:RegularExpressionValidator ID="RegularDate" runat="server" Display="Dynamic"
                                                    ControlToValidate="txtExpires" ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                                    ValidationGroup="SV" ErrorMessage="Invalid Date Format of Expiration Date.">*</asp:RegularExpressionValidator>
                                                <cc1:CalendarExtender ID="calex" runat="server" TargetControlID="txtExpires" Format="MM/dd/yyyy"
                                                    CssClass="MyCalendar" />
                                            </td>
                                            <td>
                                                    <TimerUC:TimeControl ID="ExpiryTimeControl1" runat="server" Enabled="false" />
                                                </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <div class="fields_wrap">
                                <div class="left_lable">
                                    <label>
                                    </label>
                                </div>
                                <div class="right_fields">
                                    <label id="divCall" runat="server">
                                        <asp:CheckBox ID="chkCall" runat="server" />
                                        Display Call Button</label>
                                    <br />
                                    <label id="divContactUs" runat="server">
                                        <asp:CheckBox ID="chkContact" runat="server" />
                                        Display Contact Us Button</label>
                                    <br />
                                </div>
                            </div>
                            <div class="clear10">
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <label>
                                    </label>
                                </div>
                                <div class="right_fields">
                                    <div style="margin: 10px 0px 0px 0px;">
                                        <asp:RadioButton ID="rbPrivate" runat="server" GroupName="Public" Checked="true"
                                            onclick="javascript:ShowPublish('1')" />
                                        <label>
                                            Private</label>
                                        <asp:RadioButton ID="rbPublic" runat="server" GroupName="Public" onclick="javascript:ShowPublish('2')" />
                                        <asp:Label ID="lblPublish" runat="server" Text="Publish" CssClass="approval"></asp:Label>
                                        <div style="margin: 10px 0px 0px 10px; display: none;" id="divpublish">
                                            <div id="divSchedulePublish" style="display: block;">
                                                <font color="red">*</font>
                                                <label style="font-size: 14px;">
                                                    Publish Date:</label>
                                                <asp:TextBox ID="txtPublishDate" runat="server" Width="75"></asp:TextBox><asp:TextBox
                                                    ID="txtPD" runat="server" Width="0" Height="0" BorderStyle="None" Style="display: none;"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="txtPD"
                                                    runat="server" ErrorMessage="Publish Date is mandatory." Display="Dynamic" ValidationGroup="SV"
                                                    SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="REPublishDate" runat="server" Display="Dynamic"
                                                    ControlToValidate="txtPublishDate" ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                                    ValidationGroup="SV" ErrorMessage="Invalid Date Format">*</asp:RegularExpressionValidator>
                                                <cc1:CalendarExtender ID="calPublish" runat="server" TargetControlID="txtPublishDate"
                                                    Format="MM/dd/yyyy" CssClass="MyCalendar" />
                                            </div>
                                            <% if ((Session["C_USER_ID"] == null || Session["C_USER_ID"].ToString() == "") || hdnPermissionType.Value == "P")
                                               { %>
                                            <br />
                                            <%if (hdnFacebook.Value == "")
                                              { %>
                                            <asp:CheckBox ID="chkFbAutoPost" runat="server" Text="Auto post on facebook" Style="font-size: 14px;
                                                padding-left: 4px;" /><br />
                                            <%} %>
                                            <%if (hdnTwitter.Value == "")
                                              { %>
                                            <asp:CheckBox ID="chkTwrAutoPost" runat="server" Text="Auto post on twitter" Style="font-size: 14px;
                                                padding-left: 4px;" />
                                            <%} %>
                                            <%} %>
                                            <asp:HiddenField ID="hdnIsAlreadyPublished" runat="server" Value="0" />
                                            <asp:HiddenField ID="hdnFacebook" runat="server" />
                                            <asp:HiddenField ID="hdnTwitter" runat="server" />
                                            <asp:HiddenField ID="hdnPublishDate" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="fields_wrap" style="display: none;">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        Category:</label></div>
                                <div class="right_fields">
                                    <asp:DropDownList ID="ddlCategories" runat="server" Width="200px">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="fields_wrap" style="display: none;">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                    </label>
                                </div>
                                <div class="right_fields">
                                    <asp:CheckBox runat="server" ID="chkCleared" Text="Located" />
                                </div>
                            </div>
                            <div class="clear">
                            </div>
                            <div class="clear10">
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                </div>
                                <div class="right_fields" style="margin: 10px 0px 0px 0px; width: 450px;">
                                    <asp:Button ID="btnCancel" runat="server" CausesValidation="false" border="0" CssClass="btn"
                                        Text="Cancel" OnClick="btnCancel_Click" />
                                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn" border="0" OnClick="btnSave_Click"
                                        ValidationGroup="SV" OnClientClick="BindImages(1);" />
                                    <asp:LinkButton ID="lnkPreview" runat="server" OnClick="lnkPreview_Click" OnClientClick="BindImages(2);"><img src="../../images/BulletinThumbs/preview.png" width="100" height="37"></asp:LinkButton>
                                    <input type="hidden" id="editDivCheck" value="" />
                                    <input type="hidden" id='hdnFormImgPath' />
                                    <input type="hidden" id="hdnalignindex" />
                                    <asp:HiddenField ID="hdnArchive" runat="server" />
                                    <asp:HiddenField ID="hdnPermissionType" runat="server" />
                                    <asp:HiddenField ID="hdnPublishTitle" runat="server" Value="Publish" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:Label ID="lblMfdDate" runat="server"></asp:Label>
                        <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" BackgroundCssClass="modal"
                            PopupControlID="pnlMfdDate" TargetControlID="lblMfdDate" CancelControlID="imglogin11">
                        </cc1:ModalPopupExtender>
                        <asp:Panel ID="pnlMfdDate" runat="server" Style="display: none" Width="100%">
                            <table class="popuptable" cellspacing="0" cellpadding="0" width="580px" align="center"
                                border="0">
                                <tr>
                                    <td align="center">
                                        <asp:UpdateProgress ID="UpdateProgress10" runat="server" DisplayAfter="3">
                                            <ProgressTemplate>
                                                <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </td>
                                    <td align="right">
                                        <asp:ImageButton ID="imglogin11" runat="server" ImageUrl="~/images/popup_close.gif"
                                            CausesValidation="false"></asp:ImageButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="font-weight: bold; font-size: 14px; padding-bottom: 10px; color: green;
                                        padding-top: 10px" align="left" colspan="2">
                                        <asp:Label ID="lblbulletinamme" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="padding: 10px;">
                                        <div style="height: 500px; overflow-y: auto; border: solid 1px #4684C5;">
                                            <asp:Label ID="lblPreview" runat="server"></asp:Label>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <%--IMAGE GALLERY * RESIZE IMAGE--%>
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
                    </td>
                </tr>
            </table>
            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                <tbody>
                    <tr>
                        <td>
                            <asp:Label ID="lblProgress" runat="server" visiable="false"></asp:Label>
                            <cc1:ModalPopupExtender ID="MPEProgress" runat="server" TargetControlID="lblProgress"
                                PopupControlID="pnlProgress" BackgroundCssClass="modal">
                            </cc1:ModalPopupExtender>
                            <asp:Panel Style="display: none;" ID="pnlProgress" runat="server" Width="500px">
                                <table class="modalpopup" cellspacing="0" cellpadding="0" width="100%" align="center"
                                    border="0">
                                    <tr>
                                        <td align="center">
                                            <asp:UpdateProgress ID="UpdateProgress8" runat="server" DisplayAfter="3">
                                                <ProgressTemplate>
                                                    <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green"> Your
                                                        request is in progress, please don't refresh or close window. </font></b>
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </tbody>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="lnkPreview" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <script type="text/javascript">
        function ShowExTimeDiv() {
            var allddls = document.getElementsByTagName("select");
            for (k = 0; k < allddls.length; k++) {
                var controlName = allddls[k].id;
                if (controlName.indexOf("ddlTime") >= 0) {
                    break;
                }
            }

            if (document.getElementById("<%=txtExpires.ClientID %>").value == "" || document.getElementById("<%=txtExpires.ClientID %>").value == "MM/DD/YYYY") {

                document.getElementById(controlName).disabled = true;

            }
            else {
                document.getElementById(controlName).disabled = false;
            }
        }
        function GetCurrentDate() {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "Default.aspx/GetUserTimeZoneDashboard",
                dataType: "json",
                success: function (response) {
                    currentTime = new Date(response.d);
                    dformat = [(currentTime.getMonth() + 1).padLeft(), currentTime.getDate().padLeft(), currentTime.getFullYear()].join('/');
                    document.getElementById('<%= txtPublishDate.ClientID%>').value = dformat;
                }
            });
        }
        Number.prototype.padLeft = function (base, chr) {
            var len = (String(base || 10).length - String(this).length) + 1;
            return len > 0 ? new Array(len).join(chr || '0') + this : this;
        }
        function ValidatePublishDate() {
            if (document.getElementById('<%= rbPublic.ClientID%>').checked) {
                if (document.getElementById("<%=txtPublishDate.ClientID %>").value == "") {
                    document.getElementById("<%=txtPD.ClientID %>").value = "";
                }
                else {
                    document.getElementById("<%=txtPD.ClientID %>").value = "1";
                }
            }
            else {
                document.getElementById("<%=txtPublishDate.ClientID %>").value = "";
                document.getElementById("<%=txtPD.ClientID %>").value = "1";
            }
        }
        function ShowPublish(val) {
            if (val == "1") {
                document.getElementById('<%=btnSave.ClientID %>').value = "Save";
                document.getElementById('divpublish').style.display = "none";
                document.getElementById('<%= txtPublishDate.ClientID%>').value = '';
            } else if (val == "2") {
                document.getElementById('<%=btnSave.ClientID %>').value = "Submit";
                document.getElementById('divpublish').style.display = "block";
                if ('<%= IsScheduleEmails %>' == 'True') {
                    document.getElementById('divSchedulePublish').style.display = "block";
                } else {

                    document.getElementById('divSchedulePublish').style.display = "none";
                }
                if (document.getElementById('<%= txtPublishDate.ClientID%>').value == "")
                    GetCurrentDate();
            }
        }
        function isLeap(year) {
            return year % 4 == 0 && (year % 100 != 0 || year % 400 == 0);
        }
        function GetExactAge(bDay, DOBDate) {
            // *** Checking Age in yeas and months *** //            
            var now = new Date();
            var yearNow = now.getYear();
            var monthNow = now.getMonth();
            var dateNow = now.getDate();

            var yearDob = DOBDate.getYear();
            var monthDob = DOBDate.getMonth();
            var dateDob = DOBDate.getDate();

            yearAge = yearNow - yearDob;

            if (monthNow >= monthDob)
                var monthAge = monthNow - monthDob;
            else {
                yearAge--;
            }

            if (dateNow >= dateDob)
                var dateAge = dateNow - dateDob;
            else {
                monthAge--;

                if (monthAge < 0) {
                    monthAge = 11;
                    yearAge--;
                }
            }

            alert(yearAge + ' years ' + monthAge + ' months ' + dateAge + ' days');
        }
        function ageCount() {
            var now = new Date();
            if (document.getElementById("<%=txtDOB.ClientID %>").value != "") {
                var DOBDate = new Date(document.getElementById("<%=txtDOB.ClientID %>").value);
                if (DOBDate > now) {
                    alert('Please select date of birth less than or equal to current date.');
                    document.getElementById("<%=txtAge.ClientID %>").value = "";
                    document.getElementById("<%=txtDOB.ClientID %>").value = "";
                    document.getElementById("<%=txtDOB.ClientID %>").focus();
                }
                else {
                    var years = now.getFullYear() - DOBDate.getFullYear();
                    var m = now.getMonth() - DOBDate.getMonth();
                    if (m < 0 || (m === 0 && now.getDate() < DOBDate.getDate())) {
                        years--;
                    }
                    document.getElementById("<%=txtAge.ClientID %>").value = years;
                }
            } else {
                document.getElementById("<%=txtAge.ClientID %>").value = "";
            }
        }
        function EditImage(imgdivID) {
            document.getElementById('DIDIFrm').innerHTML = "";
            ifrm = document.createElement("IFRAME");
            imgSrc = document.getElementById(imgdivID).innerHTML.trim();

            //            ifrm.setAttribute("src", "Bulletin_ImageGallery.aspx?fitblockwidth=" + (document.getElementById(imgdivID).offsetWidth - 10) + "&imgSrc=" + imgSrc + "&folder=Forms");
            //            ifrm.style.height = "750px";
            ifrm.setAttribute("src", "BulletinsForm_ImageGallery.aspx?fitblockwidth=" + (document.getElementById(imgdivID).offsetWidth - 30) + "&imgSrc=" + imgSrc + "&folder=Forms");
            ifrm.style.height = "650px";
            ifrm.style.width = "100%";
            ifrm.style.border = "0px";
            ifrm.scrolling = "no";
            ifrm.frameBorder = "0";
            document.getElementById('DIDIFrm').appendChild(ifrm);
            document.getElementById('editDivCheck').value = imgdivID;

            var modalDialog = $find("popupimage");
            modalDialog.show();
        }
        function BindImages(typeValue) {
            if (document.getElementById('divDefaultPerson').innerHTML.indexOf('img') != -1 || document.getElementById('divDefaultPerson').innerHTML.indexOf('IMG') != -1) {
                document.getElementById("<%=hdnDefaultPerson.ClientID %>").value = $('#divDefaultPerson img').attr('src');
            }
            if (document.getElementById('divAnotherImg').innerHTML.indexOf('img') != -1 || document.getElementById('divAnotherImg').innerHTML.indexOf('IMG') != -1) {
                document.getElementById("<%=hdnAnotherImg.ClientID %>").value = $('#divAnotherImg img').attr('src');
            }
            if (document.getElementById('divAnother1Img').innerHTML.indexOf('img') != -1 || document.getElementById('divAnother1Img').innerHTML.indexOf('IMG') != -1) {
                document.getElementById("<%=hdnAnother1Img.ClientID %>").value = $('#divAnother1Img img').attr('src');
            }
            if (document.getElementById('divDefaultPerson').innerHTML.indexOf('href=') != -1) {
                document.getElementById("<%=hdnDPLink.ClientID %>").value = $('#divDefaultPerson a').attr('href');
            }
            if (document.getElementById('divAnotherImg').innerHTML.indexOf('href=') != -1) {
                document.getElementById("<%=hdnAnotherImgLink.ClientID %>").value = $('#divAnotherImg a').attr('href');
            }
            if (document.getElementById('divAnother1Img').innerHTML.indexOf('href=') != -1) {
                document.getElementById("<%=hdnAnother1ImgLink.ClientID %>").value = $('#divAnother1Img a').attr('href');
            }
            if (!Page_ClientValidate('group')) {
                return;
            }
            ValidatePublishDate();

            //ExDate checking
            var allddls = document.getElementsByTagName("select");
            for (k = 0; k < allddls.length; k++) {
                var controlName = allddls[k].id;
                if (controlName.indexOf("ddlTime") >= 0) {
                    break;
                }
            }
            if (document.getElementById("<%=txtExpires.ClientID %>").value != "") {
                var currentdate = new Date();
                var fromDate = document.getElementById("<%=txtExpires.ClientID %>").value + " " + document.getElementById(controlName).value;
                var selDate = new Date(fromDate);

                if (selDate <= currentdate) {
                    alert('Expiration date should be later than current date.');
                    return false
                }
            }

            //end exdate checking

            if (typeValue == "1") {
                if (Page_ClientValidate('SV') == true && Page_IsValid == true)
                    $find("<%=MPEProgress.ClientID %>").show();
            }

        }
        function DisplayImage() {
            if (document.getElementById('<%= hdnPermissionType.ClientID%>') != "" && document.getElementById('<%= hdnPermissionType.ClientID%>') != null)  //roles & permissions..
            {
                DisplayComplete();
                if (document.getElementById("<%=hdnDefaultPerson.ClientID %>").value != "") {
                    document.getElementById("imgDelete1").style.display = "block";
                    if (document.getElementById("<%=hdnDPLink.ClientID %>").value == "")
                        document.getElementById('divDefaultPerson').innerHTML = "<img src='" + document.getElementById("<%=hdnDefaultPerson.ClientID %>").value + "' />";
                    else
                        document.getElementById('divDefaultPerson').innerHTML = "<a href='" + document.getElementById("<%=hdnDPLink.ClientID %>").value + "' target='_blank'><img src='" + document.getElementById("<%=hdnDefaultPerson.ClientID %>").value + "' /></a>";
                }
                if (document.getElementById("<%=hdnAnotherImg.ClientID %>").value != "") {
                    document.getElementById("imgDelete2").style.display = "block";
                    if (document.getElementById("<%=hdnAnotherImgLink.ClientID %>").value == "")
                        document.getElementById('divAnotherImg').innerHTML = "<img src='" + document.getElementById("<%=hdnAnotherImg.ClientID %>").value + "' />";
                    else
                        document.getElementById('divAnotherImg').innerHTML = "<a href='" + document.getElementById("<%=hdnAnotherImgLink.ClientID %>").value + "' target='_blank'><img src='" + document.getElementById("<%=hdnAnotherImg.ClientID %>").value + "' /></a>";
                }
                if (document.getElementById("<%=hdnAnother1Img.ClientID %>").value != "") {
                    document.getElementById("imgDelete3").style.display = "block";
                    if (document.getElementById("<%=hdnAnother1ImgLink.ClientID %>").value == "")
                        document.getElementById('divAnother1Img').innerHTML = "<img src='" + document.getElementById("<%=hdnAnother1Img.ClientID %>").value + "' />";
                    else
                        document.getElementById('divAnother1Img').innerHTML = "<a href='" + document.getElementById("<%=hdnAnother1ImgLink.ClientID %>").value + "' target='_blank'><img src='" + document.getElementById("<%=hdnAnother1Img.ClientID %>").value + "' /></a>";
                }
            }
        }
        window.onload = function () {
            if (document.getElementById('<%= hdnPermissionType.ClientID%>') != "" && document.getElementById('<%= hdnPermissionType.ClientID%>') != null)  //roles & permissions..
                DisplayComplete();
            if (document.getElementById('<%=rbPrivate.ClientID %>').checked) {
                document.getElementById('<%=btnSave.ClientID %>').value = "Save";
            }
            else {
                document.getElementById('<%=btnSave.ClientID %>').value = "Submit";
            }

        }
        function DisplayComplete() {
            if (document.getElementById('<%= rbPublic.ClientID%>').checked) {
                document.getElementById('divpublish').style.display = "block";
                if ('<%= IsScheduleEmails %>' == 'True') {
                    document.getElementById('divSchedulePublish').style.display = "block";
                } else {

                    document.getElementById('divSchedulePublish').style.display = "none";
                }
                ShowPublish('2');
            }
            ShowExTimeDiv();
        }

        function FirstImageDelete() {
            if (confirm("Are you sure you want to delete this image?")) {
                document.getElementById('divDefaultPerson').innerHTML = "";
                document.getElementById("imgDelete1").style.display = "none";
                document.getElementById("<%=hdnDefaultPerson.ClientID %>").value = "";
            }
            return false;
        }

        function SecondImageDelete() {
            if (confirm("Are you sure you want to delete this image?")) {
                document.getElementById('divAnotherImg').innerHTML = "";
                document.getElementById("imgDelete2").style.display = "none";
                document.getElementById("<%=hdnAnotherImg.ClientID %>").value = "";
            }

            return false;
        }
        function ThirdImageDelete() {
            if (confirm("Are you sure you want to delete this image?")) {
                document.getElementById('divAnother1Img').innerHTML = "";
                document.getElementById("imgDelete3").style.display = "none";
                document.getElementById("<%=hdnAnother1Img.ClientID %>").value = "";
            }

            return false;
        }
        function pageLoad(sender, args) {
            $(function () {
                if ('<%= IsScheduleEmails %>' == 'False') {
                    document.getElementById('<%= lblPublish.ClientID%>').innerHTML = "Publish Now";
                    if (document.getElementById('<%= hdnPermissionType.ClientID%>').value == "A")
                        document.getElementById('<%= lblPublish.ClientID%>').innerHTML = "Submit for approval";
                    else
                        document.getElementById('<%= lblPublish.ClientID%>').innerHTML = "Publish Now";
                }
                $('.checkphone').keyup(function (event) {
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
        }
    </script>
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" Visible="false">
        <ContentTemplate>
            <div class="largetxt">
                Missing Child
            </div>
            <br />
            <div style="color: red;" align="center">
                <asp:Label ID="lblerrormessage" runat="server"></asp:Label></div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
