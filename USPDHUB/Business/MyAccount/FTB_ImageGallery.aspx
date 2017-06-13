<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" Inherits="Business_MyAccount_FTB_ImageGallery"
    CodeBehind="FTB_ImageGallery.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
    <%--FUNCTIONS & METHODS--%>
    <script type="text/javascript">
        function ProgressBar() {
            var filename = document.getElementById('<%=txtimagname.ClientID %>').value;
            if (filename.toString().substring(filename.length - 1) == ".") {
                alert("This file name format is not supported.");
                return false;
            }

            if ((document.getElementById('<%=FUUserImages.ClientID %>').value != "") && (document.getElementById('<%=txtimagname.ClientID %>').value != "")) {
                ShowProgressBar('2');
            }
            else {
                if ((document.getElementById('<%=FUUserImages.ClientID %>').value == "") && (document.getElementById('<%=txtimagname.ClientID %>').value == "")) {
                    alert('Please select an image to upload and enter an image name.');
                }
                else if (document.getElementById('<%=FUUserImages.ClientID %>').value == "") {
                    alert('Please select an image to upload.');
                }
                else {
                    alert('Please enter an image name.');
                }
                return false;
            }
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
                                                <asp:FileUpload ID="FUUserImages" runat="server" Width="220" />
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
                                                    runat="server" Text="<img src='../../images/upload.gif' border='0'/>"></asp:LinkButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <div id="divUpload" style="display: none">
                                                    <div style="text-align: center;">
                                                        <img src="<%=Page.ResolveClientUrl("~/Images/ezSmartAjax.gif")%>" border="0" /><b><font
                                                            color="green">Processing....</font></b>
                                                    </div>
                                                </div>
                                                <div id="divimage" style="display: none; text-align: center;">
                                                    <img src="<%=Page.ResolveClientUrl("~/Images/ezSmartAjax.gif")%>" border="0" /><asp:Label
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
                                    <asp:LinkButton ID="lnkDelete" runat="server" OnClick="lnkDelete_Click" Text="<img src='../../images/delete1.gif' border='0'/>"
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
            </div>
            <div style="border: 1px solid #DFE7F6; height: 480px; overflow-y: scroll; overflow-x: hidden;
                width: 730px; margin-top: 5px; margin-left: 5px;">
                <asp:DataList ID="DListUserImages" runat="server" RepeatColumns="4" RepeatDirection="Horizontal">
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
                                    <asp:ImageButton ID="ImgUserImg" runat="server" ImageUrl='<%#Eval("UserImagePath") %>'
                                        Height="100px" Width="100px" OnClick="ImgUserImg_Click" OnClientClick="return ShowProgressBar('2')"
                                        CausesValidation="false" />
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
                                    <asp:Label ID="lblimgname" runat="server" Text='<%#Eval("UserImageName") %>'></asp:Label><br />
                                    <asp:Label ID="lblimgdim" runat="server" Text='<%#Eval("UserImageDim") %>'></asp:Label>
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
    <asp:Panel ID="pnlResize" runat="server">
        <table border="0" cellpadding="0" cellspacing="0" width="100%" style="padding: 5px;
            font-family: Arial; font-size: 12px;">
            <tr>
                <td>
                    <table border="0" cellpadding="0" cellspacing="0" width="100%" style="margin-bottom: 5px;">
                        <tr>
                            <td align="center">
                                <strong>
                                    <asp:Label ID="lblresizemess" runat="server" ForeColor="Green"></asp:Label></strong>
                            </td>
                        </tr>
                    </table>
                    <table border="0" cellpadding="0" cellspacing="0" width="100%" style="border: 1px solid #000;">
                        <colgroup>
                            <col width="20%" />
                            <col width="33%" />
                            <col width="*" />
                        </colgroup>
                        <tr>
                            <td style="padding-bottom: 0px; margin-bottom: 0px; vertical-align: top; padding-top: 5px;">
                                <table cellpadding="0" border="0" cellspacing="0" width="100%" style="margin-left: 5px;
                                    line-height: 17px;">
                                    <tr>
                                        <td style="padding-left: 10px;">
                                            <strong style="font-size: 15px;">1 &nbsp;&nbsp;&nbsp;Change Image</strong>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="padding-top: 20px;">
                                            Select an image
                                            <br />
                                            from your gallery.
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding-top: 15px;" align="center">
                                            <asp:Button ID="btncancel" runat="server" Text="Image Gallery" OnClick="btncancel_Click"
                                                CausesValidation="false" OnClientClick="return ShowProgressBar('1');" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td style="padding-bottom: 0px; margin-bottom: 0px; vertical-align: top; border-left: 1px solid #000;
                                padding-top: 5px;">
                                <table cellpadding="0" border="0" cellspacing="0" width="100%" style="line-height: 17px;
                                    margin-left: 5px;">
                                    <colgroup>
                                        <col width="50px" />
                                        <col width="*" />
                                    </colgroup>
                                    <tr>
                                        <td style="padding-left: 25px;">
                                            <strong style="font-size: 15px;">2 &nbsp;&nbsp;&nbsp;&nbsp;Resize Image</strong>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding-left: 25px; padding-top: 2px;">
                                            Adjust the image size below.
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding-left: 50px; padding-top: 2px;">
                                            <asp:RadioButton ID="rbfittoblock" runat="server" Text="Fit to width <strong>246px X 225px</strong>"
                                                GroupName="rbresize" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding-left: 50px;">
                                            <table cellpadding='0' cellspacing='0'>
                                                <tr>
                                                    <td align="left">
                                                        <asp:RadioButton ID="rbResizewidth" Checked="true" runat="server" Text="Pixel Size "
                                                            GroupName="rbresize" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-left: 50px; padding-top: 5px;">
                                                        Width:
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="txtimagewidth2" runat="server" Width="40px" Height="15px"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-left: 50px;">
                                                        Height:
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="txtimageheight2" runat="server" Width="40px" Height="15px" EnableViewState="false"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding-left: 80px; padding-top: 10px;">
                                            <asp:Button ID="btnSaveResizeImage" runat="server" Text="Resize" Style="display: none"
                                                OnClick="btnSaveResizeImage_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <div id="DivImageGallery" style="display: none">
                                                <div style="text-align: center;">
                                                    <img src="<%=Page.ResolveClientUrl("~/Images/ezSmartAjax.gif")%>" border="0" /><b><font
                                                        color="green">Processing....</font></b>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td style="border-left: 1px solid #000; vertical-align: top; padding-top: 5px; padding-right: 5px;">
                                <table cellpadding="0" border="0" cellspacing="0" width="99%" style="margin-left: 5px;
                                    margin-top: 3px; line-height: 17px;">
                                    <colgroup>
                                        <col width="150px" />
                                        <col width="*" />
                                    </colgroup>
                                    <tr>
                                        <td>
                                            <strong style="font-size: 15px;">3&nbsp;&nbsp;Choose Alignment</strong>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="drpalign" onchange="SetDivAlignment()" runat="server">
                                                <asp:ListItem Text="left" Value="left"></asp:ListItem>
                                                <asp:ListItem Text="right" Value="right"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr style="padding-bottom: 10px;">
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <caption>
                                        <tr>
                                            <td style="padding-top: 20px; border-top: 2px solid #000;">
                                                <strong style="font-size: 15px;">4&nbsp;&nbsp;&nbsp;Insert in Template</strong>
                                            </td>
                                            <td style="padding-top: 21px; border-top: 2px solid #000;">
                                                <asp:Button ID="btnsubmit" runat="server" CausesValidation="false" OnClick="btnsubmit_Click"
                                                    OnClientClick="return CheckImageSizeing()" Text="Insert" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" width="100%">
                                                <%--  <table border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <asp:CheckBox ID="chkAddtoGallery" runat="server" />
                                                    </td>
                                                    <td style="padding-left: 10px; padding-top: 25px; padding-bottom: 10px;">
                                                        Select the check box if you want to save the image modifications to the gallery.
                                                    </td>
                                                </tr>
                                            </table>--%>
                                            </td>
                                        </tr>
                                    </caption>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="0" border="0" width="100%" height="100%" style="margin-top: 5px;
            font-family: Arial; font-size: 12px;">
            <tr>
                <td valign="top" style="padding-left: 5px; padding-top: 5px;">
                    <strong>Resize Image</strong>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top;">
                    <div id="RimgDivID" class="wrap" style="overflow: scroll;">
                        <div id="imgdotteddiv" style="border-bottom: 3px dashed #9A9898; border-left: 3px solid #9A9898;
                            border-top: 3px solid #9A9898; border-right: 3px solid #9A9898; margin-left: 1px;">
                            <div id="ImagAlignDivID" class="wrap">
                                <img height="<%=txtimageheight1.Value %>" width="<%=txtimagewidth1.Value %>" src='<%=hdnResizeImageValue.Value %>'
                                    id="yui_img" /></div>
                        </div>
                    </div>
                    <script type="text/javascript">

                        (function () {
                            var Dom = YAHOO.util.Dom;

                            var resize = new YAHOO.util.Resize('yui_img', {
                                handles: 'all',
                                knobHandles: true,
                                proxy: true,
                                ghost: true,
                                status: true,
                                draggable: false,
                                animate: false,
                                animateDuration: .75,
                                animateEasing: YAHOO.util.Easing.backBoth
                            });

                            resize.on('startResize', function () {
                                this.getProxyEl().innerHTML = '<img src="' + this.get('element').src + '" style="height: 100%; width: 100%;">';
                                Dom.setStyle(this.getProxyEl().firstChild, 'opacity', '.25');

                                document.getElementById('<%=txtimagewidth2.ClientID%>').innerHTML = document.getElementById("yui_img").offsetWidth;
                                document.getElementById('<%=txtimageheight2.ClientID%>').innerHTML = document.getElementById("yui_img").offsetHeight;

                            }, resize, true);

                            resize.on('endResize', function () {

                                document.getElementById('<%=txtimagewidth2.ClientID%>').innerHTML = document.getElementById("yui_img").offsetWidth;
                                document.getElementById('<%=txtimageheight2.ClientID%>').innerHTML = document.getElementById("yui_img").offsetHeight;

                                document.getElementById('<%=hdnheight.ClientID%>').value = document.getElementById("yui_img").offsetHeight;
                                document.getElementById('<%=hdnwidth.ClientID%>').value = document.getElementById("yui_img").offsetWidth;
                            }, resize, true);

                            resize.on('load', function () {
                                document.getElementById('<%=txtimagewidth2.ClientID%>').innerHTML = document.getElementById("yui_img").offsetWidth;
                                document.getElementById('<%=txtimageheight2.ClientID%>').innerHTML = document.getElementById("yui_img").offsetHeight;
                            }, resize, true);
                        }
  )();
                    </script>
                </td>
            </tr>
            <tr>
                <td style="padding-bottom: 10px; padding-top: 407px; font-size: 15px;" align="center">
                    <strong>Note: </strong>An image wider than the template image block will adjust
                    to fit the block width.
                </td>
            </tr>
        </table>
    </asp:Panel>
    <input type="hidden" id="resizewidth" runat="server" />
    <input type="hidden" id="resizeheight" runat="server" />
    <asp:HiddenField ID="txtimagewidth1" runat="server" />
    <asp:HiddenField ID="txtimageheight1" runat="server" />
    <asp:HiddenField ID="hdnResizeImageValue" runat="server" />
    <asp:HiddenField ID="hdnClose" runat="server" />
    <asp:HiddenField ID="hdnheight" runat="server" />
    <asp:HiddenField ID="hdnwidth" runat="server" />
    <asp:HiddenField ID="hdnCheck" runat="server" />
    <asp:HiddenField ID="hdnOrgDivDim" runat="server" />
    <asp:HiddenField ID="CheckWidth" runat="server" />
    <asp:HiddenField ID="ChangedHeight" runat="server" />
    <asp:HiddenField ID="hdnChangeResize" runat="server" />
    <asp:HiddenField ID="hdnLastimage" runat="server" />
    <asp:HiddenField ID="hdnimgheight2" runat="server" />
    <asp:HiddenField ID="hdnimgwidth2" runat="server" />
    <input type="hidden" id="TargetFreeTextBox" value="cphUser_cphUser_txtnewscontent1" />
    <script type="text/javascript">

        function SetDivAlignment() {
            sel = document.getElementById('drpalign').value;
            var imgWidth = document.getElementById('yui_img').width;
            var divWidth = document.getElementById('imgdotteddiv').offsetWidth;
            if (sel.length > 0) {
                if (sel == 'left') {
                    document.getElementById('ImagAlignDivID').style.left = 0;
                } else if (sel == 'center') {
                    if ((divWidth - imgWidth - 10) / 2 > 0) {
                        document.getElementById('ImagAlignDivID').style.left = (divWidth - imgWidth - 10) / 2;
                    }
                } else {
                    if ((divWidth - imgWidth - 10) > 0) {
                        document.getElementById('ImagAlignDivID').style.left = divWidth - imgWidth - 10;
                    }
                }
            }
        }
      
    </script>
    <script type="text/javascript" language="javascript">

        if (document.getElementById('hdnClose').value != "") {
            RImgURL = document.getElementById('hdnResizeImageValue').value;
            RImgURLHeight = document.getElementById('hdnheight').value;
            RImgURLWidth = document.getElementById('hdnwidth').value;
            ImgDivID = window.opener.document.getElementById('editDivCheck').value;
            ImgDivID1 = "edit" + ImgDivID;

            var width = RImgURLWidth;
            var height = RImgURLHeight;
            var align = document.getElementById('drpalign').value;
            // var hspace = "5";
            hspace = 'margin-left:0px; margin-right:5px; margin-top:2px;margin-bottom:2px;';
            if (align == "right") {
                hspace = 'margin-left:5px; margin-right:0px; margin-top:2px;margin-bottom:2px;';
            }
            var vspace = '0';
            var ftb = document.getElementById('TargetFreeTextBox').value;

            var img = '<img  onresizestart="return false;"  style="' + hspace + '"  src="' + RImgURL + '"' + ' temp_src="' + RImgURL + '"' +

		((width != '') ? ' width="' + width + '"' : '') +
		((height != '') ? ' height="' + height + '"' : '') +
		((height != '') ? ' height="' + height + '"' : '') +
		((align != '') ? ' align="' + align + '"' : '') +
            		((vspace != '') ? ' vspace="' + vspace + '"' : '') +
		' />';


            //window.opener.FTB_API["ctl00_ctl00_cphUser_cphUser_txtnewscontent1"].InsertHtml(img);
            window.opener.$find("ctl00_ctl00_cphUser_cphUser_RadEditor1").pasteHtml(img);
            window.close();
            document.getElementById('hdnResizeImageValue').value = '';
            document.getElementById('hdnheight').value = '';
            document.getElementById('hdnClose').value = '';
            document.getElementById('hdnwidth').value = '';
            window.opener.document.getElementById('editDivCheck').value = ImgDivID1;
        }
        else {
            ImgDivID = window.opener.document.getElementById('editDivCheck').value;
            ImgDivID1 = "edit" + ImgDivID;
            //-20 for Text Editor Space 5 * 5
            document.getElementById('<%=CheckWidth.ClientID %>').value = (window.opener.document.getElementById(ImgDivID1).parentElement.offsetWidth - 22);

        }

        function CheckImageSizeing() {

            if (document.getElementById("<%=rbResizewidth.ClientID %>").checked == true) {
                if (parseInt(document.getElementById("<%=txtimagewidth2.ClientID %>").innerHTML) > parseInt(parseInt(document.getElementById('<%=CheckWidth.ClientID%>').value) - 20)) {
                    alert('The image width should be less than or equal to the block width.');
                    return false;
                }
            }


            if (document.getElementById('<%=hdnChangeResize.ClientID %>').value != '') {
                if (document.getElementById('<%=txtimagewidth1.ClientID%>').value != document.getElementById('<%=txtimagewidth2.ClientID%>').innerHTML || document.getElementById('<%=txtimageheight1.ClientID%>').value != document.getElementById('<%=txtimageheight2.ClientID%>').innerHTML) {
                    if (document.getElementById('<%=txtimagewidth2.ClientID%>').innerHTML > window.opener.document.getElementById(ImgDivID1).offsetWidth) {
                        document.getElementById('<%=txtimagewidth2.ClientID%>').innerHTML = window.opener.document.getElementById(ImgDivID1).offsetWidth - 2;
                        document.getElementById('<%=hdnimgwidth2.ClientID %>').value = window.opener.document.getElementById(ImgDivID1).offsetWidth - 2;
                    }
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
        if (document.getElementById('<%=hdnOrgDivDim.ClientID %>').value != "") {
            ImgDivID1 = window.opener.document.getElementById('editDivCheck').value;

            if (ImgDivID1 != "") {
                imgpardotheight = window.opener.document.getElementById(ImgDivID1).offsetHeight;
                imgpardotheight = imgpardotheight;
            }

            if (document.getElementById('<%=hdnCheck.ClientID %>').value == '') {
                if (document.getElementById('<%=ChangedHeight.ClientID %>').value == '') {
                    if (ImgDivID1 != "") {
                    }
                }
                if (ImgDivID1 != "") {
                    document.getElementById('<%=CheckWidth.ClientID %>').value = window.opener.document.getElementById(ImgDivID1).offsetWidth - 2;
                }
            }
            if (ImgDivID1 != "") {
                document.getElementById("imgdotteddiv").style.height = imgpardotheight;
                document.getElementById("imgdotteddiv").style.width = window.opener.document.getElementById(ImgDivID1).offsetWidth - 20;
            }

            document.getElementById("RimgDivID").style.height = '403px';
            document.getElementById("RimgDivID").style.width = '780px';
        }

        if (document.getElementById('hdnCheck').value != "") {
            SetDivAlignment();
        }      
    </script>
    </form>
</body>
</html>
