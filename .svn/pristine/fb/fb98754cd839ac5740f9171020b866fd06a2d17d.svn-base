<%@ Page Language="C#" MasterPageFile="~/PaidTools.master" AutoEventWireup="true"
    CodeBehind="MissingPersonRisk.aspx.cs" Inherits="USPDHUB.Business.MyAccount.MissingPersonRisk"
    ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <script src="../../Scripts/flyers/jquery-1.7.2.js" type="text/javascript"></script>
    <link href="../../css/Bulletins.css" rel="stylesheet" type="text/css" />
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
                        <div style="width: 300px; margin: 0 auto;">
                            <asp:ValidationSummary ID="ValidateUserDetails" runat="server" Style="text-align: left;"
                                ValidationGroup="SV" HeaderText="The following error(s) occurred:" />
                        </div>
                    </div>
                    <div class="header">
                        <div style="margin: 0 auto; width: 100%; overflow: hidden;">
                            <asp:Label runat="server" ID="lblLogoHeader"></asp:Label>
                        </div>
                    </div>
                    <div class="clear">
                    </div>
                    <div class="contentwrap">
                        <div class="largetxt">
                            Missing Person at Risk</div>
                        <div class="browseimg_wrap">
                            <div class="avatar" style="text-align: center;">
                                <div id='divDefaultPerson' style="width: 310px; min-height: 140px; display: block;">
                                </div>
                                <asp:HiddenField ID="hdnDefaultPerson" runat="server" />
                                <asp:HiddenField ID="hdnLink" runat="server" />
                            </div>
                            <label>
                                <img style="cursor: pointer;" onclick="EditImage('divDefaultPerson');" src="../../Images/Dashboard/Browseimg.png" />
                            </label>
                        </div>
                        <div class="form_wrapper">
                            <div class="fields_wrap">
                                <label style="color: Red; font-size: 16px; margin-left: 100px;">
                                    * Marked fields are mandatory.</label>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <font color="red">*</font><label>
                                        Last Name :</label></div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtLastName" runat="server" CssClass="txtfild1"></asp:TextBox>
                                    &nbsp;<asp:RequiredFieldValidator ID="REFVLN" runat="server" ControlToValidate="txtLastName"
                                        ValidationGroup="SV" ErrorMessage="Last Name is mandatory.">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <font color="red">*</font><label>
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
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        Nickname</label>
                                    :</div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtNickName" runat="server" CssClass="txtfild1"></asp:TextBox>
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <font color="red">*</font><label>
                                        Date of Birth :</label></div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtDOB" runat="server" onblur="ageCount();"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="REFVDOB" runat="server" Display="Dynamic" ControlToValidate="txtDOB"
                                        ValidationGroup="SV" ErrorMessage="Date of Birth is mandatory.">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="REVDOB" runat="server" Display="Dynamic" ControlToValidate="txtDOB"
                                        ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                        ValidationGroup="SV" ErrorMessage="Invalid Date Format of Date of Birth.">*</asp:RegularExpressionValidator>
                                    <b>(MM/DD/YYYY)</b>
                                    <cc1:CalendarExtender ID="CEDOB" runat="server" TargetControlID="txtDOB" Format="MM/dd/yyyy"
                                        CssClass="MyCalendar" />
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
                                        Gender :</label></div>
                                <div class="right_fields">
                                    <asp:DropDownList ID="ddlGender" runat="server">
                                    </asp:DropDownList>
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
                                        Feet
                                    </div>
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
                                    <asp:TextBox ID="txtWeight" runat="server" CssClass="txtfild2"></asp:TextBox>&nbsp;
                                    Pounds &nbsp;<asp:RegularExpressionValidator ID="REVWeight" runat="server" Display="Dynamic"
                                        ForeColor="Red" ControlToValidate="txtWeight" ValidationGroup="SV" ErrorMessage="Enter a Valid Weight"
                                        ValidationExpression="^[0-9.]+$"> </asp:RegularExpressionValidator>
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
                                        Hair :</label></div>
                                <div class="right_fields">
                                    <asp:DropDownList ID="ddlHair" runat="server" CssClass="select1">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        Complexion :</label></div>
                                <div class="right_fields">
                                    <asp:DropDownList ID="ddlCompletion" runat="server" CssClass="select1">
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
                                        Nationality :</label></div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtNationality" runat="server" CssClass="txtfild1"></asp:TextBox>
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        Distinguishing Marks :</label></div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtDistinguishing_Marks" Width="325px" Height="70px" runat="server"
                                        TextMode="MultiLine" CssClass="txtfild1"></asp:TextBox>
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <font color="red">*</font><label>
                                        Date of Last Contact&nbsp;:</label></div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtLCD" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="REFVLCD" runat="server" Display="Dynamic" ControlToValidate="txtLCD"
                                        ValidationGroup="SV" ErrorMessage="Date of Last Contact is mandatory.">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="REVLCD" runat="server" Display="Dynamic" ControlToValidate="txtLCD"
                                        ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                        ValidationGroup="SV" ErrorMessage="Invalid Date Format of Date of Last Contact.">*</asp:RegularExpressionValidator>
                                    <b>(MM/DD/YYYY)</b>
                                    <cc1:CalendarExtender ID="CELCD" runat="server" TargetControlID="txtLCD" Format="MM/dd/yyyy"
                                        CssClass="MyCalendar" />
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        Remarks :</label></div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtRemarks" Height="100px" Width="350px" runat="server" TextMode="MultiLine"
                                        CssClass="txtfild1"></asp:TextBox>
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        Expiration Date :</label></div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtExpires" runat="server"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularDate" runat="server" Display="Dynamic"
                                        ControlToValidate="txtExpires" ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                        ValidationGroup="SV" ErrorMessage="Invalid Date Format">*</asp:RegularExpressionValidator>
                                    <b>(MM/DD/YYYY)</b>
                                    <cc1:CalendarExtender ID="calex" runat="server" TargetControlID="txtExpires" Format="MM/dd/yyyy"
                                        CssClass="MyCalendar" />
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <label>
                                    </label>
                                </div>
                                <div class="right_fields">
                                    <label runat="server" id="divCall">
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
                                            Unpublish</label>
                                        <asp:RadioButton ID="rbPublic" runat="server" GroupName="Public" onclick="javascript:ShowPublish('2')" />
                                        <label>
                                            Publish</label>
                                        <div style="margin: 10px 0px 0px 10px; display: none;" id="divpublish">
                                            <div id="divSchedulePublish" style="display: block;">
                                                <font color="red">*</font><label style="font-size: 14px;">
                                                    Publish Date:</label>
                                                <asp:TextBox ID="txtPublishDate" runat="server" Width="75"></asp:TextBox><asp:TextBox
                                                    ID="txtPD" runat="server" Width="0" Height="0" BorderStyle="None" Style="display: none;"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="txtPD"
                                                    runat="server" ErrorMessage="Publish Date is mandatory." Display="Dynamic" ValidationGroup="SV"
                                                    SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="REPublishDate" runat="server" Display="Dynamic"
                                                    ControlToValidate="txtPublishDate" ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                                    ValidationGroup="SV" ErrorMessage="Invalid Date Format">*</asp:RegularExpressionValidator>
                                                <span style="padding-left: 0px;"><b>(MM/DD/YYYY)</b></span>
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
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        Category:</label></div>
                                <div class="right_fields">
                                    <asp:DropDownList ID="ddlCategories" runat="server">
                                    </asp:DropDownList>
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
                                        ValidationGroup="SV" OnClientClick="BindImages();" />
                                    <asp:LinkButton ID="lnkPreview" runat="server" OnClick="lnkPreview_Click" OnClientClick="BindImages();"><img src="../../images/BulletinThumbs/preview.png" width="100" height="37"></asp:LinkButton>
                                    <input type="hidden" id="editDivCheck" value="" />
                                    <input type="hidden" id='hdnFormImgPath' />
                                    <input type="hidden" id="hdnalignindex" />
                                    <asp:HiddenField ID="hdnArchive" runat="server" />
                                    <asp:HiddenField ID="hdnPermissionType" runat="server" />
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
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="lnkPreview" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <script type="text/javascript">
        $(document).ready(function () {
            if ('<%= IsScheduleEmails %>' == 'False') {
                if (document.getElementById('<%= hdnPermissionType.ClientID%>').value == "A")
                    document.getElementById('<%= lblPublish.ClientID%>').innerHTML = "Submit for approval";
                else
                    document.getElementById('<%= lblPublish.ClientID%>').innerHTML = "Publish Now";
            }
        });
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
                document.getElementById('divpublish').style.display = "none";
                document.getElementById('<%= txtPublishDate.ClientID%>').value = '';
            } else if (val == "2") {
                if ('<%= IsScheduleEmails %>' == 'True') {
                    document.getElementById('divSchedulePublish').style.display = "block";
                } else {

                    document.getElementById('divSchedulePublish').style.display = "none";
                }
                document.getElementById('divpublish').style.display = "block";
                GetCurrentDate();
            }
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
            //            ifrm.setAttribute("src", "Bulletin_ImageGallery.aspx?fitblockwidth=" + (document.getElementById(imgdivID).offsetWidth - 10) + "&imgSrc=" + imgSrc);
            //            ifrm.style.height = "750px";
            ifrm.setAttribute("src", "BulletinsForm_ImageGallery.aspx?fitblockwidth=" + (document.getElementById(imgdivID).offsetWidth - 30) + "&imgSrc=" + imgSrc);
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
        function BindImages() {
            if (document.getElementById('divDefaultPerson').innerHTML.indexOf('img') != -1 || document.getElementById('divDefaultPerson').innerHTML.indexOf('IMG') != -1) {
                document.getElementById("<%=hdnDefaultPerson.ClientID %>").value = $('#divDefaultPerson img').attr('src');
            }
            if (document.getElementById('divDefaultPerson').innerHTML.indexOf('href=') != -1) {
                document.getElementById("<%=hdnLink.ClientID %>").value = $('#divDefaultPerson a').attr('href');
            }
            ValidatePublishDate();
        }
        function DisplayImage() {
            if (document.getElementById('<%= hdnPermissionType.ClientID%>') != "" && document.getElementById('<%= hdnPermissionType.ClientID%>') != null) {  //roles & permissions..
                DisplayComplete();

                var imgHyperLink = document.getElementById("<%=hdnLink.ClientID %>").value;
                var ImgURL = document.getElementById("<%=hdnDefaultPerson.ClientID %>").value;

                if (imgHyperLink == "") {
                    if (ImgURL != "")
                        document.getElementById('divDefaultPerson').innerHTML = "<img src='" + ImgURL + "' />";
                }
                else {
                    document.getElementById('divDefaultPerson').innerHTML = "<a href='" + imgHyperLink + "' target='_blank'><img style='vertical-align:bottom;' src='" + ImgURL + "' border='0' /></a>";
                }
            }
        }
        window.onload = function () {
            if (document.getElementById('<%= hdnPermissionType.ClientID%>') != "" && document.getElementById('<%= hdnPermissionType.ClientID%>') != null)  //roles & permissions..
                DisplayComplete();
        }
        function DisplayComplete() {
            if (document.getElementById('<%= rbPublic.ClientID%>').checked)
                document.getElementById('divpublish').style.display = "block";
        }
    </script>
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" Visible="false">
        <ContentTemplate>
            <div class="largetxt">
                Missing Person at Risk</div>
            <br />
            <div style="color: red;" align="center">
                <asp:Label ID="lblerrormessage" runat="server"></asp:Label></div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
