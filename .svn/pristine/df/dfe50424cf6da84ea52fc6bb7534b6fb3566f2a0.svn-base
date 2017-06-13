<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" Inherits="Business_MyAccount_ManagePhotosAlbum"
    CodeBehind="ManagePhotosAlbum.aspx.cs" ValidateRequest="false" %>

<%@ Register Src="~/Controls/Sitemaplinks.ascx" TagName="wowmap" TagPrefix="uc3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphUser" runat="Server">
    <script type="text/javascript" src="<%=Page.ResolveClientUrl("~/Scripts/jquery.js")%>"></script>
    <script type="text/javascript" src="<%=Page.ResolveClientUrl("~/Scripts/jquery.lightbox-0.5.js")%>"></script>
    <link rel="stylesheet" type="text/css" href="<%=Page.ResolveClientUrl("~/css/jquery.lightbox-0.5.css")%>"
        media="screen" />
    <script language="JavaScript1.2" src="<%=Page.ResolveClientUrl("~/Scripts/main.js")%>"
        type="text/javascript"></script>
    <script language="JavaScript1.2" src="<%=Page.ResolveClientUrl("~/Scripts/dashboardstyle.js")%>"
        type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            CallingLightBox();
        });

        function CallingLightBox() {
            $('#gallery a').lightBox();
        }
    </script>
    <script type="text/javascript">
        function displaypanel() {
            $(function () {
                $('#gallery a').lightBox();
            });
        }
    </script>
    <script type="text/javascript">
        function openWin2(url) {
            window.open(url, "composerwindow", "toolbar=no,width=700,height=400,status=no,scrollbars=no,resize=no,menubar=no");
        }  
    </script>
    <script type="text/javascript">

        function checkchanged() {
            if (document.getElementById('<%=ckbprimaryphoto.ClientID %>').checked == true) {
                document.getElementById('<%=txtOrderNumber.ClientID %>').disabled = true;
                document.getElementById('<%=txtOrderNumber.ClientID %>').value = "0";
            }
            else {
                document.getElementById('<%=txtOrderNumber.ClientID %>').disabled = false;
                document.getElementById('<%=txtOrderNumber.ClientID %>').value = document.getElementById('<%=maxordernumber.ClientID %>').value;
            }
        }


        function ValidateOrderNumber(typeValue) {
            if (Page_ClientValidate('IMGOD')) {
                var errMsg = "";
                if (document.getElementById('<%=txtOrderNumber.ClientID %>').value.toString().substring(0, 1) == "0" && document.getElementById('<%=ckbprimaryphoto.ClientID %>').checked == false)
                    errMsg += "Please enter the ordering number greater than 0 value.\n";
                else if (document.getElementById('<%=txteditordernumber.ClientID %>').value.toString().substring(0, 1) == "0")
                    errMsg += "Please enter the ordering number greater than 0 value.\n";

                if (document.getElementById('<%=picture1Text.ClientID %>').value.length > 75 && typeValue == 1)
                    errMsg += "The text you have entered has exceeded the maximum limit of 75 characters.\n";

                if (document.getElementById('<%=txtphotodesc.ClientID %>').value.length > 75 && typeValue == 3)
                    errMsg += "The text you have entered has exceeded the maximum limit of 75 characters.";

                if (errMsg != "") {
                    alert(errMsg);
                    return false;
                }

                ClearText();
                if (typeValue == 1) {
                    ShowProgressBar();
                }
            }
            else
                return false;


        }
        function ClearText() {
            // To clear text message
            document.getElementById('<%=lblPhotoMsg.ClientID %>').innerText = '';
            document.getElementById('<%=lblAfterCount.ClientID %>').innerText = '';
            document.getElementById('<%=lblAfterEditCount.ClientID %>').innerText = '';

        }
        function ValidateText(ID, Val) {
            var etcChar = 75;
            if (ID.value.length <= 0)
                etcChar = "";
            else
                etcChar = (75 - ID.value.length) + " characters remaining";
            if (Val == 1)
                document.getElementById('<%=lblAfterCount.ClientID %>').innerHTML = etcChar;
            else
                document.getElementById('<%=lblAfterCount.ClientID %>').innerHTML = "";

            if (Val == 2)
                document.getElementById('<%=lblAfterEditCount.ClientID %>').innerHTML = etcChar;
            else
                document.getElementById('<%=lblAfterEditCount.ClientID %>').innerHTML = "";
        }
        function confirmDelete(frm) {
            ClearText();
            var confirmDelete;
            confirmDelete = true;
            var photoSelected;
            photoSelected = false;
            // loop through all elements
            for (i = 0; i < frm.length; i++) {
                // Look for our checkboxes only
                if (frm.elements[i].name.indexOf("chk") != -1) {
                    // If any are checked then confirm alert, otherwise nothing happens
                    if (frm.elements[i].checked) {

                        var name = frm.elements[i].name;

                        if (name != "ctl00$cphUser$chkbxImgPublicPrivate") {
                            photoSelected = true;
                            var chkObj = document.getElementsByName(name);

                            if (chkObj != null && chkObj[0].value == 'True') {
                                confirmDelete = false;
                                break;
                            }
                            else {
                                confirmDelete = true;

                            }
                        }
                    }
                }
            }
            if (photoSelected == false) {
                alert('Please select at least one image to delete.');
                return false;
            }
            if (confirmDelete == true) {
                return confirm('Are you sure you want to delete your selection(s)?');
            }
            else {

                if (confirm('Your selection contains the Homepage image. Deleting the Homepage image means your ' + document.getElementById('<%=hdnVerticalName.ClientID %>').value + ' will not display any image from this page. Continue?')) {
                    document.getElementById('<%=hdnHomepage.ClientID %>').value = 0;
                    document.getElementById('<%=hdnHomePageID.ClientID %>').value = 0;
                    return true;
                }
                else {
                    document.getElementById('<%=hdnHomepage.ClientID %>').value = 1;
                    return false;
                }
            }
        }
        function checkRbSelectedValue(radioButton) {
            var rbList = $("#<%=rbGalleryOrder.ClientID %>");
            if (radioButton == "bydate") {

                $("#<%=hdnGallerySelectedOrder.ClientID %>").val("1");
                $(rbList).find("input[value='3']").removeAttr("checked");
                $(rbList).find("input[value='1']").removeAttr("checked");
                $("#tblDate").css("display", "block");
                //$(rbList).css("display", "block");


            } else {
                if (radioButton == "byCustum") {
                    $(rbList).find("input[value='3']").removeAttr("checked");
                    $(rbList).find("input[value='1']").removeAttr("checked");
                    $("#<%=hdnGallerySelectedOrder.ClientID %>").val("2");
                    $(rbList).css("display", "none");
                    $("#tblDate").css("display", "none");
                }
            }
            $("#<%= lnkHdnCustDate.ClientID %>")[0].click();
        }
        function setSelectedGalleryOrderCheck() {
            //alert($("#<%=hdnGallerySelectedOrder.ClientID %>").val());
            var galleryOrder = $("#<%=hdnGallerySelectedOrder.ClientID %>").val();
            var rbList = $("#<%=rbGalleryOrder.ClientID %>");
            if (galleryOrder == 1) { //by date desc
                $(rbList).find("input[value='1']").attr("checked", true);
                $("#rbByCustom").attr("checked", false);
            }
            else if (galleryOrder == 2) { //by cust
                $("#rbByCustom").attr("checked", true);
                $("#rbBydate").attr("checked", false);
                $("#tblDate").css("display", "none");
                $(rbList).css("display", "none");

            } else if (galleryOrder == 3) { // date asc
                $(rbList).find("input[value='3']").attr("checked", true);
            }
            if (galleryOrder == 1 || galleryOrder == 3) {
                $("#rbBydate").attr("checked", true);
                $(rbList).css("display", "block");
            }
            else {
                //                $("#tblDate").css("display", "none");
                //                $(rbList).css("display", "none");
            }

        }
        $(document).ready(function () {
            if ($('#rbByCustom').is(':checked'))
                $("#tblDate").css("display", "none");
            else {
                $("#tblDate").css("display", "block");
                var rbList = $("#<%=rbGalleryOrder.ClientID %>");

                setSelectedGalleryOrderCheck();

                //                var checkedValue = $("#<%=rbGalleryOrder.ClientID %> input[type=radio]:checked").val();
                //                if (checkedValue == 1 || checkedValue == 3) {
                //                    $("#<%=rbBydate.ClientID %>").attr("checked", true);
                //                }
            }
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function (s, e) {
            setSelectedGalleryOrderCheck();
        });
    </script>
    <script type="text/javascript">
        function Display() {
            var rbList = $("#<%=rbGalleryOrder.ClientID %>");
            $(rbList).css("display", "block");
            $("#tblDate").css("display", "block");

        }
        function Display1() {
            var rbList = $("#<%=rbGalleryOrder.ClientID %>");
            $("#tblDate").css("display", "none");
            $(rbList).css("display", "none");
        }
        function confirmvalidate(frm, obj) {
            document.getElementById("<%=hdnnumber.ClientID %>").value = "2";
            ClearText();
            // loop through all elements
            var value = 0;
            var confirmDelete = true;
            for (i = 0; i < frm.length; i++) {
                // Look for our checkboxes only
                if (frm.elements[i].name.indexOf("chk") != -1) {
                    // If any are checked then confirm alert, otherwise nothing happens
                    if (frm.elements[i].checked) {

                        var name = frm.elements[i].name;

                        if (name != "ctl00$cphUser$chkbxImgPublicPrivate") {
                            var chkObj = document.getElementsByName(name);
                            value = value + 1;

                            if (chkObj != null && chkObj[0].value == 'True') {
                                confirmDelete = false;
                                if (value > 1)
                                    break;
                            }
                            else {

                                confirmDelete = true;
                            }
                        }

                    }
                }
            }
            if (obj == 1) {
                if (document.getElementById('<%=chkbxImgPublicPrivate.ClientID %>').checked == true && value == 0 && document.getElementById('<%=hdnHomepage.ClientID %>').value == "0") {
                    alert('Please select an image to be set as your Homepage image.');
                    return false
                }
                else if (value == 0) {
                    alert('Please select an image to be set as your Homepage image.');
                    return false
                }
                else if (value == 1) {
                    if (confirmDelete == true) {
                        return confirm('Are you sure you want to change the Homepage image?')
                    }
                    else {
                        alert('You have already chosen this photo as your Homepage image.');
                        return false;
                        // return true;
                    }
                }
                else if (value != 0) {
                    alert('You can have only one image as your Homepage image.');
                    return false
                    // return true;
                }
                else
                    return true;
            }
            else if (obj == 2) {
                if (value == 0) {
                    alert('Please select at least one image to update the caption.');
                    return false
                }
                else if (value == 1) {
                    return confirm('Are you sure you want to update the caption?')
                }
                else {
                    alert('You can update the caption of only one image at a time.');
                    return false
                }
            }
            else {

                if (value == 0) {
                    alert('Please select an image to update the order number.');
                    return false
                }
                else if (value == 1) {

                    if (confirmDelete == true) {
                        return true;
                    }
                    else {
                        alert('You can not edit the order number for Homepage image.');
                    }
                }
                else {
                    alert('You can update the order number of only one image at a time.');
                    return false
                }
            }

            return false

        }
        function SelectImage(frm) {
            var photoSelected;
            photoSelected = false;
            // loop through all elements
            for (i = 0; i < frm.length; i++) {
                // Look for our checkboxes only
                if (frm.elements[i].name.indexOf("chk") != -1) {
                    // If any are checked then confirm alert, otherwise nothing happens
                    if (frm.elements[i].checked) {

                        var name = frm.elements[i].name;

                        if (name != "ctl00$cphUser$chkbxImgPublicPrivate") {
                            photoSelected = true;
                        }
                    }
                }
            }
            if (photoSelected == false) {
                alert('Please select at least one image to add to google places.');
                return false;
            }
            else {
                return true;
            }
        }
    </script>
    <script type="text/javascript">
        function ShowProgressBar() {

            document.getElementById("divUpload").style.display = "block";

            return true;
        }
    </script>
    <style type="text/css">
        .datalist
        {
        }
        .datalist td
        {
            vertical-align: top;
            padding-top: 5px;
        }
    </style>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <table class="page-padding" cellspacing="0" cellpadding="0" width="100%" border="0">
                <tr>
                    <td>
                        <table class="page-title" cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tbody>
                                <tr>
                                    <td>
                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblTitle" runat="server"></asp:Label>
                                                    <span style="color: Black; font-size: 14px; margin: 0px; padding: 0px; position: absolute;
                                                        margin-left: 600px; margin-top: 0px;">
                                                        <asp:Label runat="server" ID="lblOn" Visible="false">Displayed on App: <font class="showonapp">On</font></asp:Label>
                                                        <asp:Label runat="server" ID="lblOff">Displayed on App: <font class="showoffapp">Off</font></asp:Label>
                                                    </span>
                                                </td>
                                                <td align="left">
                                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="3">
                                                        <ProgressTemplate>
                                                            <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                                        </ProgressTemplate>
                                                    </asp:UpdateProgress>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <div id="divUpload" style="display: none">
                                            <div style="text-align: center;">
                                                <img src="<%=Page.ResolveClientUrl("~/Images/Dashboard/ezSmartAjax.gif")%>" border="0" /><b><font
                                                    color="green">Processing....</font></b>
                                            </div>
                                        </div>
                                        <asp:Label ID="lblPhotoMsg" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <asp:Panel ID="pnlallimage" runat="server">
                            <div>
                                <table class="inputtable" cellspacing="0" cellpadding="0" width="100%" border="0">
                                    <tr>
                                        <td style="padding-right: 10px; padding-left: 10px; padding-bottom: 10px; padding-top: 10px">
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 24px">
                                                            <img height="28" src='<%=Page.ResolveClientUrl("~/Images/Dashboard/head-left.gif")%>'
                                                                width="9" />
                                                        </td>
                                                        <td class="new-header">
                                                            Upload Images
                                                        </td>
                                                        <td>
                                                            <img height="28" src='<%=Page.ResolveClientUrl("~/Images/Dashboard/head-right.gif")%>'
                                                                width="9" />
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                            <table class="new-table" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tbody>
                                                    <tr>
                                                        <td>
                                                            <table class="profile-padding" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                <tbody>
                                                                    <tr>
                                                                        <td class="profile-caption">
                                                                            <asp:Panel ID="pnlphotos" runat="server">
                                                                                <table cellspacing="0" cellpadding="0" width="100%" border="0" style="background-color: #E8F3FF;
                                                                                    border: 2px solid #D1DDEA;">
                                                                                    <colgroup>
                                                                                        <col width="15%" />
                                                                                        <col width="*" />
                                                                                    </colgroup>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            <b>&nbsp;Upload Image:</b>
                                                                                        </td>
                                                                                        <td>
                                                                                            <%-- <asp:UpdatePanel runat="server">
                                                                                        <ContentTemplate>--%>
                                                                                            <asp:FileUpload ID="Picture1" runat="server" Width="236px"></asp:FileUpload>
                                                                                            <a id="A1" href="javascript:ModalHelpPopup('Add Images',147,'');">
                                                                                                <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" /></a><%if (dtlistphotos.Items.Count > 0)
                                                                                                                                                                            { %>
                                                                                            <span style="color: #FBA862; padding-left: 200px; font-weight: bold; font-size: 14px;">
                                                                                                Total images: </span><span style="color: #205E07; font-size: 14px; font-weight: bold;">
                                                                                                    <asp:Label ID="lblCount" runat="server"></asp:Label></span>
                                                                                            <%} %>
                                                                                            <p>
                                                                                            </p>
                                                                                            <%-- </ContentTemplate>
                                                                                    </asp:UpdatePanel>--%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <%if (CheckMobileApp == false)
                                                                                      { %>
                                                                                    <tr>
                                                                                        <%}
                                                                                      else
                                                                                      { %>
                                                                                        <tr style="display: none;">
                                                                                            <%} %>
                                                                                            <td align="left">
                                                                                                <b>Set as Homepage Image:</b>
                                                                                            </td>
                                                                                            <td>
                                                                                                <input type="checkbox" id="ckbprimaryphoto" runat="server" onclick="checkchanged();" />
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                <b>Enter Image Caption:</b>
                                                                                            </td>
                                                                                            <td>
                                                                                                &nbsp;<asp:TextBox ID="picture1Text" runat="server" Width="400px" TextMode="MultiLine"
                                                                                                    MaxLength="75" CssClass="textfield" Height="50px" onkeyup="ValidateText(this, 1)"></asp:TextBox><br />
                                                                                                (75 characters maximum) <span style="padding-left: 176px;">
                                                                                                    <asp:Label ID="lblAfterCount" Font-Bold="true" ForeColor="#400000" runat="server"></asp:Label></span>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                <b>Enter Image Order Number:</b>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox runat="server" ID="txtOrderNumber" Width="100px"></asp:TextBox>
                                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtOrderNumber"
                                                                                                    ErrorMessage="Please Enter Only Numbers." ValidationExpression="^\d+(\.\d+)?$"></asp:RegularExpressionValidator>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:LinkButton ID="BtnUpdatePhoto" OnClick="BtnUpdatePhoto_Click" runat="server"
                                                                                                    Text="<img src='../../images/Dashboard/upload.gif' border='0'/>" OnClientClick="return ValidateOrderNumber(1)"></asp:LinkButton>
                                                                                            </td>
                                                                                            <td class="profile-caption red-color">
                                                                                                <a href="javascript:openWin2('<%=Page.ResolveClientUrl("~/samplephotos.htm")%>')"><b>
                                                                                                    Sample Images</b></a>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="profile-caption" colspan="2">
                                                                                                <span class="profile-caption red-color">NOTE:<%-- The file size for each image is 2MB.--%> When
                                                                                                    uploading files, please use gif, jpeg, png or bmp formats.
                                                                                                    <br />
                                                                                                    Image size must be greater than 320px X 240px.</span>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 100%;" align="left" colspan="2">
                                                                                                <span style="font-weight: bold; font-size: 14px; margin-right: 20%;">App Display Order
                                                                                                    :</span>
                                                                                                <p style="font-weight: bold; font-size: 14px; margin-right: 10.5%;">
                                                                                                    <table style="height: 30px;">
                                                                                                        <tr>
                                                                                                            <td style="font-weight: bold; font-size: 14px; margin-right: 10.5%;">
                                                                                                                <asp:RadioButton ID="rbBydate" runat="server" GroupName="rbDisplayOrder" Text="By Date"
                                                                                                                    OnCheckedChanged="rbBydate_CheckedChanged" AutoPostBack="true" onchange="Display();" />
                                                                                                                <%-- <input type="radio" name="rbDisplayOrder" id="rbBydate" value="By Date" onchange="return checkRbSelectedValue('bydate')"  />--%>
                                                                                                            </td>
                                                                                                            <td id="tddate" class="clsDate" style="display: block;">
                                                                                                                <table id="tblDate">
                                                                                                                    <tr>
                                                                                                                        <td>
                                                                                                                            <img src="../../Images/Arrow_Forward.png" />
                                                                                                                            <asp:RadioButtonList ID="rbGalleryOrder" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rbGalleryOrder_OnSelectedIndexChanged"
                                                                                                                                RepeatDirection="Horizontal" Style="color: Black; float: right; font-size: 14px;
                                                                                                                                border: 2px solid #ff9900; width: auto; border-radius: 4.5px; margin-left: 10px;">
                                                                                                                                <asp:ListItem Text="Ascending" Value="3"></asp:ListItem>
                                                                                                                                <asp:ListItem Text="Descending" Value="1" Selected="True"></asp:ListItem>
                                                                                                                            </asp:RadioButtonList>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                </table>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                    <div style="font-weight: bold; font-size: 14px; margin-right: 10.5%; padding-left: 7px">
                                                                                                        <asp:RadioButton ID="rbByCustom" runat="server" GroupName="rbDisplayOrder" Text="By Custom Order"
                                                                                                            OnCheckedChanged="rbByCustom_CheckedChanged" AutoPostBack="true" onchange="Display1();" />
                                                                                                        <%--     <input type="radio" name="rbDisplayOrder" id="rbByCustom" value="By Custom Order"
                                                                                                            onchange="return checkRbSelectedValue('byCustum')" />By Custom Order--%></div>
                                                                                                    <p>
                                                                                                    </p>
                                                                                                    <asp:LinkButton ID="lnkHdnCustDate" runat="server" CausesValidation="false" Enabled="true"
                                                                                                        OnClick="lnkHdnCustDate_OnClick" Style="display: none;"></asp:LinkButton>
                                                                                                    <asp:HiddenField ID="hdnGallerySelectedOrder" runat="server" />
                                                                                            </td>
                                                                                        </tr>
                                                                                </table>
                                                                            </asp:Panel>
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
                                                                        <td width="100%">
                                                                            <div id="gallery" style="height: 320px; overflow-y: auto; border: solid 1px #4684C5;">
                                                                                <asp:DataList ID="dtlistphotos" runat="server" RepeatDirection="Horizontal" RepeatColumns="4"
                                                                                    OnItemDataBound="dtlistphotos_ItemDataBound" DataKeyField="Profile_Photo_ID"
                                                                                    CssClass="datalist">
                                                                                    <ItemTemplate>
                                                                                        <table cellpadding="0" cellspacing="0" border="0" width="100%" class="imggrid">
                                                                                            <colgroup>
                                                                                                <col width="10px" />
                                                                                                <col width="*" />
                                                                                            </colgroup>
                                                                                            <tr class="row1">
                                                                                                <td>
                                                                                                    <input type="checkbox" id="chk" runat="server" value='<%#Eval("Photo_Prime_Flag") %>' />
                                                                                                </td>
                                                                                                <td style="vertical-align: top;">
                                                                                                    <asp:Label ID="imgpreview" runat="server"></asp:Label><br />
                                                                                                    <asp:Label ID="lblprimary" runat="server" Text='<%#Eval("Photo_Prime_Flag") %>' class="profile-caption"></asp:Label>
                                                                                                    <asp:Label ID="lblphotoId" runat="server" Text='<%#Eval("Profile_Photo_ID") %>' Visible="false"></asp:Label>
                                                                                                    <asp:Label ID="lblpnum" runat="server" Text='<%#Eval("Photo_Num") %>' Font-Bold="true"
                                                                                                        Visible="false"></asp:Label>
                                                                                                    <asp:Label ID="lblhiddenorder" runat="server" Text='<%#Eval("Image_OrderNo") %>'
                                                                                                        Visible="false"></asp:Label>
                                                                                                    <asp:Label ID="lblOrder" runat="server" Text="Order No:"></asp:Label><br />
                                                                                                    <asp:Label ID="lblimgdate" runat="server" Text='<%# Eval("CREATED_DT", "{0:MM/dd/yy hh:mm tt}") %>'></asp:Label>
                                                                                                    <asp:Label ID="lblppath" runat="server" Text='<%#Eval("Photo_image_path") %>' Visible="false"></asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr class="row2">
                                                                                                <td>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:Label ID="lbldesc" runat="server" Text='<%#Eval("Photo_Desc") %>'></asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </ItemTemplate>
                                                                                </asp:DataList>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <%if (CheckMobileApp == false)
                                                                      { %>
                                                                    <tr>
                                                                        <%}
                                                                      else
                                                                      { %>
                                                                        <tr style="display: none;">
                                                                            <%} %>
                                                                            <td>
                                                                                <asp:CheckBox ID="chkbxImgPublicPrivate" runat="server" />&nbsp;Uncheck the box
                                                                                if you do not want to automatically display an image on your USPDhub<sup style="font-size: 14px;">&reg;</sup>
                                                                                home page.
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="profile-caption red-color" style="height: 13px">
                                                                                NOTE: If you are unable to view the full caption, please move your mouse over the
                                                                                'More' link.
                                                                            </td>
                                                                        </tr>
                                                                </tbody>
                                                            </table>
                                                            <table class="profile-padding" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                <tbody>
                                                                    <tr>
                                                                        <td align="center">
                                                                            <asp:Button ID="BtnDelePhoto" OnClick="BtnDelePhoto_Click" runat="server" Text="Delete Images"
                                                                                OnClientClick="return confirmDelete (this.form)"></asp:Button>
                                                                            <a id="A3" href="javascript:ModalHelpPopup('Delete Images',149,'');">
                                                                                <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" /></a>&nbsp;
                                                                            <%if (CheckMobileApp == false)
                                                                              { %><asp:Button ID="Btnupdateprimaryflag" OnClick="Btnupdateprimaryflag_Click" runat="server"
                                          Text="Update Homepage Image" OnClientClick="return confirmvalidate (this.form, 1)" />
                                                                            <asp:Button ID="btnRemoveHomeImg" OnClick="btnRemoveHomeImg_Click" runat="server"
                                                                                Text="Remove Homepage Image" /><%} %>
                                                                            <asp:Button ID="BtnVieworEdit" OnClick="BtnVieworEdit_Click" runat="server" Text="View/Edit Caption"
                                                                                OnClientClick="return confirmvalidate (this.form , 2)" />
                                                                            <a id="A2" href="javascript:ModalHelpPopup('Edit Image Captions',150,'');">
                                                                                <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" /></a>
                                                                            <asp:Button ID="btnEditOrderNumber" runat="server" Text="Edit Order Number" OnClientClick="return confirmvalidate (this.form , 3)"
                                                                                OnClick="btnEditOrderNumber_Click" />
                                                                            <asp:Button ID="btnAddToGooglePlaces" Text="Add to Google Places" runat="server"
                                                                                Visible="false" OnClick="btnAddToGooglePlaces_Click" OnClientClick="return SelectImage(this.form);" />
                                                                            <a href="javascript:ModalHelpPopup('Change Image Order',148,'');">
                                                                                <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" /></a>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                            <table class="profile-btntbl" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                <tr>
                                                                    <td align="center">
                                                                        <asp:HiddenField ID="hdnVerticalName" runat="server" />
                                                                        <%--
                                                                        <asp:Button ID="btnBack" runat="server" CausesValidation="false" OnClick="btnBack_Click"
                                                                            Text="Back" />&nbsp;&nbsp;--%>
                                                                        <asp:Button ID="btndashboard1" OnClick="btndashboard1_Click" runat="server" Text="Go to Dashboard"
                                                                            CausesValidation="false" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </asp:Panel>
                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                            <tr>
                                <td>
                                    <asp:Label ID="lbl1" runat="server"></asp:Label>
                                    <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" PopupControlID="pnlpopup1"
                                        TargetControlID="lbl1" BackgroundCssClass="modal" CancelControlID="imclose">
                                    </cc1:ModalPopupExtender>
                                    <asp:Panel ID="pnlpopup1" runat="server" Style="display: none;">
                                        <table class="popuptable" cellspacing="0" cellpadding="0" width="600px" border="0">
                                            <colgroup>
                                                <col width="22%" />
                                                <col width="*" />
                                            </colgroup>
                                            <tr>
                                                <td align="center" colspan="2">
                                                    <asp:UpdateProgress ID="UpdateProgress2" runat="server" DisplayAfter="3">
                                                        <ProgressTemplate>
                                                            <img src="../../images/popup_ajax-loader.gif" border="0"><span class="processing">Processing....</span>
                                                        </ProgressTemplate>
                                                    </asp:UpdateProgress>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" colspan="2" class="header">
                                                    Image Caption
                                                </td>
                                                <td align="right">
                                                    <asp:ImageButton ID="imclose" runat="server" ImageUrl="~/images/popup_close.gif" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Label ID="lblmsg1" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="popuplabel" style="padding-top: 10px;" valign="top" nowrap>
                                                    Enter image caption:
                                                </td>
                                                <td style="padding-top: 10px;">
                                                    <asp:TextBox ID="txtphotodesc" runat="server" TextMode="MultiLine" MaxLength="75"
                                                        Width="400px" Height="50px" onkeyup="ValidateText(this,2)"></asp:TextBox><br />
                                                    (75 characters maximum) <span style="padding-left: 130px;">
                                                        <asp:Label ID="lblAfterEditCount" runat="server" Font-Bold="true" ForeColor="#400000"></asp:Label></span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-top: 10px;">
                                                    &nbsp;
                                                </td>
                                                <td style="padding-top: 10px;">
                                                    <asp:Button ID="btnupdate" runat="server" Text="Update" OnClick="btnupdate_Click"
                                                        OnClientClick="return ValidateOrderNumber(3)" />
                                                    <asp:Button ID="btncancel" runat="server" Text="Cancel" OnClick="btncancel_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                            <tr>
                                <td>
                                    <asp:Label ID="lbl2" runat="server"></asp:Label>
                                    <cc1:ModalPopupExtender ID="ModalPopupImgOrderNo" runat="server" PopupControlID="pnlpopup2"
                                        TargetControlID="lbl2" BackgroundCssClass="modal" CancelControlID="imgorderclose">
                                    </cc1:ModalPopupExtender>
                                    <asp:Panel ID="pnlpopup2" runat="server" Style="display: none;">
                                        <table class="popuptable" cellspacing="0" cellpadding="0" width="600px" border="0">
                                            <colgroup>
                                                <col width="30%" />
                                                <col width="*" />
                                            </colgroup>
                                            <tr>
                                                <td align="center" colspan="2">
                                                    <asp:UpdateProgress ID="UpdateProgress3" runat="server" DisplayAfter="3">
                                                        <ProgressTemplate>
                                                            <img src="../../images/popup_ajax-loader.gif" border="0"><span class="processing">Processing....</span>
                                                        </ProgressTemplate>
                                                    </asp:UpdateProgress>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="header">
                                                    Image Order Number
                                                </td>
                                                <td align="right">
                                                    <asp:ImageButton ID="imgorderclose" runat="server" ImageUrl="~/images/popup_close.gif" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Label ID="Label2" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" align="center">
                                                    <asp:Image ID="ImgOrder" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="popuplabel" style="padding-top: 10px;" valign="top">
                                                    Enter Image Order Number:
                                                </td>
                                                <td style="padding-top: 10px;">
                                                    <asp:TextBox ID="txteditordernumber" runat="server" MaxLength="100" Width="100px"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txteditordernumber"
                                                        ErrorMessage="Please Enter Only Numbers." ValidationExpression="^\d+(\.\d+)?$"
                                                        ValidationGroup="IMGOD"></asp:RegularExpressionValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-top: 10px;">
                                                    &nbsp;
                                                </td>
                                                <td style="padding-top: 10px;">
                                                    <asp:Button ID="btnUpdateImgOrderNumber" runat="server" OnClientClick="return ValidateOrderNumber(2);"
                                                        Text="Update" OnClick="btnUpdateImgOrderNumber_Click" ValidationGroup="IMGOD" />
                                                    <asp:Button ID="btnCancelImgOrderNumber" runat="server" Text="Cancel" CausesValidation="false"
                                                        OnClick="btnCancelImgOrderNumber_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="height: 25px;">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="Btnupdateprimaryflag" />
            <asp:PostBackTrigger ControlID="BtnUpdatePhoto" />
            <asp:PostBackTrigger ControlID="btnSubmitResizeImage" />
            <%--<asp:AsyncPostBackTrigger ControlID="BtnUpdatePhoto" EventName="Click" />--%>
        </Triggers>
    </asp:UpdatePanel>
    <input id="hdnHomepage" type="hidden" value="0" runat="server" />
    <input id="hdnHomePageID" type="hidden" value="0" runat="server" />
    <input id="maxordernumber" type="hidden" value="0" runat="server" />
    <asp:HiddenField ID="hdnnumber" runat="server" Value="0" />
    <asp:HiddenField ID="hdnPermissionType" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" Visible="false">
        <ContentTemplate>
            <div style="color: #005aa0; font-weight: bold;">
                Manage Images
            </div>
            <div style="color: red;" align="center">
                <asp:Label ID="lblerrormessage" runat="server"></asp:Label></div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
            <asp:Label ID="lblResizeImagePreview" runat="server"></asp:Label>
            <cc1:ModalPopupExtender ID="popupResizeImagepreview" runat="server" TargetControlID="lblResizeImagePreview"
                PopupControlID="pnlpreviewresizeImage" BackgroundCssClass="modal" CancelControlID="imgclosepreviewpopup"
                BehaviorID="ResizeImagereview">
            </cc1:ModalPopupExtender>
            <asp:Panel ID="pnlpreviewresizeImage" runat="server" Style="display: none" Width="800px"
                Height="500px">
                <table cellpadding="0" cellspacing="0" width="100%" style="border: 1px solid #EEECEC;
                    background-color: #F8F6F6;">
                    <tbody>
                        <tr>
                            <td style="padding-right: 120px;" align="right">
                                <asp:UpdateProgress ID="UpdateProgress4" runat="server" DisplayAfter="3">
                                    <ProgressTemplate>
                                        <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </td>
                            <td align="right" style="padding: 5px 10px 20px 10px;">
                                <asp:ImageButton ID="imgclosepreviewpopup" runat="server" ImageUrl="~/images/popup_close.gif" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100%; padding: 10px;" colspan="2">
                                <asp:Label ID="lblResizeImageWidth" runat="server" Text="Image Preview" Font-Bold="true"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100%; padding: 10px;" colspan="2">
                                <div style="overflow: auto; height: 450px; position: relative; width: 780px;">
                                    <asp:Label ID="lblimgpreview" runat="server"></asp:Label></div>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="margin-top: 10px;">
                                <asp:Button runat="server" Text="Submit" ID="btnSubmitResizeImage" OnClick="btnSubmitResizeImage_OnClick" />&nbsp;
                                <asp:Button ID="btnCancelResizeImage" runat="server" Text="Cancel" />&nbsp;
                            </td>
                        </tr>
                    </tbody>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
