<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImageGallery.aspx.cs" Inherits="USPDHUB.Business.MyAccount.ImageGallery"
    ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../css/Bulletins.css" rel="stylesheet" type="text/css" />
    <link href="../../Scripts/resize/button.css" rel="stylesheet" type="text/css" />
    <link href="../../Scripts/resize/resize.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/resize/yuiloader-min.js" type="text/javascript"></script>
    <script src="../../Scripts/resize/event-min.js" type="text/javascript"></script>
    <script src="../../Scripts/resize/dom-min.js" type="text/javascript"></script>
    <script src="../../Scripts/resize/animation-min.js" type="text/javascript"></script>
    <script src="../../Scripts/resize/element-min.js" type="text/javascript"></script>
    <script src="../../Scripts/resize/dragdrop-min.js" type="text/javascript"></script>
    <script src="../../Scripts/resize/button-min.js" type="text/javascript"></script>
    <script src="../../Scripts/resize/resize-min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        function ProgressBar() {
            var filename = document.getElementById('<%=txtimagname.ClientID %>').value;
            if (filename.toString().substring(filename.length - 1) == ".") {
                alert("This file name format is not supported.");
                return false;
            }
            else if (filename.toString().indexOf("%") > -1) {
                alert("This file name not allowed % character.");
                return false;
            }
            else if (filename.toString().indexOf("#") > -1) {
                alert("The special character # not allowed in file name.");
                return false;
            }

            var copyImgName = '<%= Session["ImgName"] %>';


            if ((document.getElementById('<%=FUUserImages.ClientID %>').value != "") && (document.getElementById('<%=txtimagname.ClientID %>').value != "")) {
                ShowProgressBar('2');
            }
            else {
                if ((document.getElementById('<%=FUUserImages.ClientID %>').value == "") && (document.getElementById('<%=txtimagname.ClientID %>').value == "")) {
                    alert('Please select an image to upload and enter an image name.');
                }
                else if (document.getElementById('<%=FUUserImages.ClientID %>').value == "" && copyImgName == "") {
                    alert('Please select an image to upload.');
                }
                else {
                    if (copyImgName == "")
                        alert('Please enter an image name.');
                    else {
                        ShowProgressBar('2');
                        return true;
                    }
                }
                return false;
            }
        }
        function SelectAll(obj) {
            var list = document.getElementById("<%=DListBulletinImages.ClientID%>");
            alert(list.items.length);
            for (var i = 0; i < list.items.length; i++) {
                if (list[i].type == "checkbox") {
                    chklist.checked = document.getElementById(obj).checked;
                }
            }
        }

        function CheckImageDelete() {
            for (i = 0; i < this.frm1.length; i++) {
                if (this.frm1.elements[i].name.indexOf("ChekImage") != -1) {
                    if (this.frm1.elements[i].checked) {
                        if (confirm('Are you sure you want to delete your selection(s)?')) {
                            document.getElementById("divUpload").style.display = "block";
                            return true;
                        }
                        else {
                            return false;
                        }
                    }
                }
            }
            alert('Please select at least one checkbox to delete.');
            return false
        }
    </script>
    <script type="text/javascript">
        function ShowProgressBar(Value) {
            if (Value == "1") {
                document.getElementById("DivImageGallery").style.display = "block";
            }
            else {
                document.getElementById("divUpload").style.display = "block";
            }
            return true;
        }
    </script>
    <script type="text/javascript">
        function CloseModalPopup() {

        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            //check all
            $("[id$='cbSelectAll']").click(
             function () {
                 $("INPUT[type='checkbox']").attr('checked',
			$("[id$='cbSelectAll']").is(':checked'));
             });

        });
    </script>
    <script type="text/javascript">
        function SetFileName() {
            var arrFileName = document.getElementById('<%= FUUserImages.ClientID %>').value.split('\\');
            var imageName = arrFileName[arrFileName.length - 1].replace(".jpeg", "").replace(".jpg", "").replace(".gif", "").replace(".png", "");
            imageName = imageName.replace("%", "");
            imageName = imageName.replace("#", "");
            document.getElementById('<%= txtimagname.ClientID %>').value = imageName;
        }
    </script>
    <script type="text/javascript">
        function EnterEvent(e) {
            if (e.keyCode == 13) {
                document.getElementById('<%= lnkSearch.ClientID %>').click();
            }
        }
    </script>
</head>
<body class="yui-skin-sam" style="background-color: #F8F6F6;">
    <form runat="server" id="frm1">
    <style>
        #yui_img
        {
            position: absolute;
            top: 3px;
            left: 5px;
        }
        #example-canvas
        {
            height: 200px;
        }
        div.wrap
        {
            position: absolute;
            left: 0px;
        }
        .verticaltext
        {
            writing-mode: tb-rl;
            filter: flipV flipH;
            font-size: 12px;
        }
        .rounded-cornersBox
        {
            background-color: #DFE7F6;
            border: 1px solid #BED1F4;
            margin-left: 4px;
            font-family: arial;
            font-size: 12px;
            line-height: 25px;
        }
        .rounded-cornersBox td.title
        {
            font-weight: bold;
            color: #060C49;
            font-size: 20px;
        }
        .rounded-cornersBox td.title1
        {
            font-weight: bold;
            color: #060C49;
            font-size: 20px;
            border-right: 1px solid #BED1F4;
            vertical-align: top;
            padding-left: 10px;
        }
        .logo
        {
            width: 200px;
            border: #005879 solid 1px;
            vertical-align: top;
        }
    </style>
    <asp:Panel ID="pnlallimage" runat="server">
        <div>
            <table width="730px" border="0" cellpadding="0" cellspacing="0" class="rounded-cornersBox">
                <colgroup>
                    <col width="22%" />
                    <col width="*" />
                    <col width="19%" />
                </colgroup>
                <tr>
                    <td valign="top" style="border-right: 1px solid #BED1F4;">
                        <table border="0" cellpadding="0" cellspacing="0" style="line-height: 18px; padding: 10px;">
                            <tr>
                                <td style="font-weight: bold; font-size: 16px; text-align: center;">
                                    Select
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-top: 5px;">
                                    To select an image from the gallery click on the image.
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="border-right: 1px solid #BED1F4;">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="line-height: 18px;
                            padding: 10px;">
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblerrormsg" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-size: 16px;" align="center">
                                    <strong>Add</strong> an image to the gallery
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-top: 7px;">
                                    <table border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td valign="top">
                                                <strong>Select image to upload:&nbsp;</strong>
                                            </td>
                                            <td>
                                                <asp:FileUpload ID="FUUserImages" runat="server" Width="220" onchange="SetFileName();" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <strong style="padding-right: 2px;">Name the image:</strong>
                                            </td>
                                            <td style="padding-top: 2px;">
                                                <table border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="txtimagname" runat="server" Width="130px"></asp:TextBox>
                                                        </td>
                                                        <td valign="top">
                                                            <div style="position: absolute; font-size: 9px; padding-left: 5px;">
                                                                NOTE: jpeg, jpg, gif or png only
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td style="padding-top: 5px;">
                                                <asp:LinkButton ID="BtnUpload" OnClick="BtnUpload_Click" OnClientClick="return ProgressBar()"
                                                    runat="server" Text="<img src='../../images/Dashboard/upload.gif' border='0'/>"></asp:LinkButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <div id="divUpload" style="display: none">
                                                    <div style="text-align: center;">
                                                        <img src="<%=Page.ResolveClientUrl("~/Images/Dashboard/ezSmartAjax.gif")%>" border="0" /><b><font
                                                            color="green">Processing....</font></b>
                                                    </div>
                                                </div>
                                                <div id="divimage" style="display: none; text-align: center;">
                                                    <img src="<%=Page.ResolveClientUrl("~/Images/Dashboard/ezSmartAjax.gif")%>" border="0" /><asp:Label
                                                        ID="lblloadimgs" runat="server" Text="Images are loading. Please wait till this message disappears."
                                                        ForeColor="green" Font-Size="10"></asp:Label>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td valign="top">
                        <table border="0" cellpadding="0" cellspacing="0" style="line-height: 18px; padding: 10px;">
                            <tr>
                                <td style="font-weight: bold; font-size: 16px; text-align: center;">
                                    Delete
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-top: 5px;">
                                    To delete an image select the box next to the image and click below.
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="padding-right: 10px; padding-top: 3px;">
                                    <asp:LinkButton ID="lnkDelete" runat="server" OnClick="lnkDelete_Click" Text="<img src='../../images/Dashboard/delete1.gif' border='0'/>"
                                        OnClientClick="return CheckImageDelete()" CausesValidation="false"></asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td style="color: Green; font-size: 14px; padding: 5px;" align="center">
                        <asp:Label ID="lblload" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <div style="font-family: Verdana; font-size: 12px; margin-left: 5px;">
                <asp:CheckBox ID="cbSelectAll" runat="server" Text="Select All" Checked="false" />
                <div style="float: right; padding-right: 67px;">
                    <asp:Panel ID="pnlSelectSearch" runat="server" DefaultButton="lnkSearch">
                        Search:
                        <asp:TextBox ID="txtSearch" runat="server" onkeypress="return EnterEvent(event)"></asp:TextBox><asp:RequiredFieldValidator
                            ID="rfvSearch" runat="server" ValidationGroup="S" ControlToValidate="txtSearch">*</asp:RequiredFieldValidator>&nbsp;<asp:LinkButton
                                ID="lnkSearch" runat="server" OnClick="lnkSearch_Click" Text="Search" ValidationGroup="S"
                                Class="btnorange"></asp:LinkButton>&nbsp;&nbsp;<asp:LinkButton ID="lnkClear" runat="server"
                                    OnClick="lnkClear_Click" Text="Clear" CausesValidation="false" Class="btnblue"></asp:LinkButton>
                    </asp:Panel>
                </div>
            </div>
            <div style="border: 1px solid #DFE7F6; height: 400px; overflow-y: scroll; overflow-x: hidden;
                width: 730px; margin-top: 5px; margin-left: 5px;">
                <asp:DataList ID="DListBulletinImages" runat="server" RepeatColumns="4" RepeatDirection="Horizontal">
                    <ItemTemplate>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="padding: 5px;
                            font-family: Arial; font-size: 12px;">
                            <colgroup>
                                <col width="20%" />
                                <col width="*" />
                            </colgroup>
                            <tr>
                                <td style="padding-left: 10px;">
                                    <asp:CheckBox ID="ChekImage" Style="background-color: #8FC2F8; margin-bottom: 15px;"
                                        runat="server" />
                                </td>
                                <td rowspan="2" style="padding-left: 10px;">
                                    <asp:Image ID="ImgUserImg" runat="server" ImageUrl='<%# Eval("Image_Thumb","~/Upload/Common/" + ProfileID + "/{0}") %>'
                                          OnClientClick="return ShowProgressBar('2')" CausesValidation="false" />
                                    <asp:Label ID="lblImageId" runat="server" Text='<%# Eval("ImageId")%>' Visible="false"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-left: 10px;">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-left: 10px;">
                                    &nbsp;
                                </td>
                                <td style="line-height: 18px; padding-left: 10px; padding-top: 10px; padding-bottom: 10px;">
                                    <asp:Label ID="lblimgname" runat="server" Text='<%#Eval("ImageDimension") %>'></asp:Label><br />
                                    <asp:Label ID="lblimgdim" runat="server" Text='<%#Eval("Image_Name") %>'></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
            </div>
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td style="padding-bottom: 10px; padding-top: 10px; font-size: 15px; font-family: Arial;"
                        align="center">
                        <strong>Note: </strong>An image wider than the template image block will adjust
                        to fit the block width.
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    </form>
</body>
</html>
