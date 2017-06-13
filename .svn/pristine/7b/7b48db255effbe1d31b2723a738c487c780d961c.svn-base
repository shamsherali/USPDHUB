<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CommonMasterGallery.ascx.cs"
    Inherits="USPDHUB.Controls.CommonMasterGallery" %>
<script type="text/javascript" src="http://code.jquery.com/jquery-1.8.2.js"></script>
<script src="../../Scripts/jquery.lightbox-0.5.js" type="text/javascript"></script>
<link href="../../css/jquery.lightbox-0.5.css" rel="stylesheet" type="text/css" />
<script src="../../Scripts/jquery.Jcrop.js" type="text/javascript"></script>
<link href="../../css/jquery.Jcrop.css" rel="stylesheet" type="text/css" />
<style>
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
    #drop_zone
    {
        padding: 10px;
        width: 400px;
        min-height: 100px;
        max-height: 200px;
        overflow: auto;
        text-align: left;
        text-transform: uppercase;
        font-weight: bold;
        border: 1px solid #005AA0;
        outline: 0px;
    }
    .clear20
    {
        clear: both;
        height: 20px;
    }
    
    .btnnew
    {
        background: #007ad1;
        background-image: -webkit-linear-gradient(top, #007ad1, #005ba0);
        background-image: -moz-linear-gradient(top, #007ad1, #005ba0);
        background-image: -ms-linear-gradient(top, #007ad1, #005ba0);
        background-image: -o-linear-gradient(top, #007ad1, #005ba0);
        background-image: linear-gradient(to bottom, #007ad1, #005ba0);
        -webkit-border-radius: 4;
        -moz-border-radius: 4;
        border-radius: 4px;
        font-family: Arial;
        color: #ffffff;
        font-size: 16px;
        padding: 10px 20px 10px 20px;
        border: solid #1f628d 0px;
        text-decoration: none;
        margin: 5px 0px;
        letter-spacing: 0.5px;
        cursor: pointer;
    }
    
    .btnnew:hover
    {
        background: #3cb0fd;
        background-image: -webkit-linear-gradient(top, #3cb0fd, #3498db);
        background-image: -moz-linear-gradient(top, #3cb0fd, #3498db);
        background-image: -ms-linear-gradient(top, #3cb0fd, #3498db);
        background-image: -o-linear-gradient(top, #3cb0fd, #3498db);
        background-image: linear-gradient(to bottom, #3cb0fd, #3498db);
        text-decoration: none;
        letter-spacing: 0.5px;
        cursor: pointer;
    }
    
    
    .btnneworange
    {
        background: #3cb0fd;
        background-image: -webkit-linear-gradient(top, #ffb45e, #d57300);
        background-image: -moz-linear-gradient(top, #ffb45e, #d57300);
        background-image: -ms-linear-gradient(top, #ffb45e, #d57300);
        background-image: -o-linear-gradient(top, #ffb45e, #d57300);
        background-image: linear-gradient(to bottom, #ffb45e, #d57300);
        -webkit-border-radius: 4;
        -moz-border-radius: 4;
        border-radius: 4px;
        font-family: Arial;
        color: #ffffff;
        font-size: 16px;
        padding: 10px 20px 10px 20px;
        border: solid #f7b100 0px;
        text-decoration: none;
        margin: 5px 0px;
        letter-spacing: 0.5px;
        cursor: pointer;
    }
    
    .btnneworange:hover
    {
        background: #d57300;
        background-image: -webkit-linear-gradient(top, #d57300, #d57300);
        background-image: -moz-linear-gradient(top, #d57300, #d57300);
        background-image: -ms-linear-gradient(top, #d57300, #d57300);
        background-image: -o-linear-gradient(top, #d57300, #d57300);
        background-image: linear-gradient(to bottom, #d57300, #d57300);
        text-decoration: none;
        cursor: pointer;
    }
</style>
<script type="text/javascript">

    $(function () {
        $('#gallery a').lightBox();
    });

    function displaypanel() {

        LoaddropzoneEvents();
        $('#gallery a').lightBox();

        $("[id$='cbSelectAll']").click(
             function () {
                 $("[id$='dtlistImages'] INPUT[type='checkbox']").attr('checked', $("[id$='cbSelectAll']").is(':checked'));
             });

    }
      

</script>
<script type="text/javascript">

    $(document).ready(function () {

        $("[id$='cbSelectAll']").click(
             function () {
                 $("[id$='dtlistImages'] INPUT[type='checkbox']").attr('checked', $("[id$='cbSelectAll']").is(':checked'));
             });

    });


    $(function () {
        $("[id*=TVAlbums] input[type=checkbox]").bind("click", function () {
            var table = $(this).closest("table");
            if (table.next().length > 0 && table.next()[0].tagName == "DIV") {
                //Is Parent CheckBox
                var childDiv = table.next();
                var isChecked = $(this).is(":checked");
                $("input[type=checkbox]", childDiv).each(function () {
                    if (isChecked) {
                        $(this).attr("checked", "checked");
                    } else {
                        $(this).removeAttr("checked");
                    }
                });
            } else {
                //Is Child CheckBox
                var parentDIV = $(this).closest("DIV");
                if ($("input[type=checkbox]", parentDIV).length == $("input[type=checkbox]:checked", parentDIV).length) {
                    $("input[type=checkbox]", parentDIV.prev()).attr("checked", "checked");
                } else {
                    $("input[type=checkbox]", parentDIV.prev()).removeAttr("checked");
                }
            }
        });
    })



    function ValidateImgSelection() {

        var selectedcount = 0;
        var TargetBaseControl = document.getElementById('<%= this.dtlistImages.ClientID %>');
        var Inputs = TargetBaseControl.getElementsByTagName("input");
        for (var iCount = 0; iCount < Inputs.length; ++iCount) {
            if (Inputs[iCount].type == 'checkbox') {
                if (Inputs[iCount].checked) {
                    selectedcount += 1;
                    if (selectedcount > 1)
                        break;
                }
            }
        }

        if (selectedcount == 0) {
            alert("Please select at least one image.");
            return false;
        }
        else if (selectedcount > 1) {
            alert("Multiple selections are not allowed.");
            return false;
        }
        else {
            ClosePopupWindow();
            return true;
        }
    } //
     

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
<asp:Panel runat="server">
    <table class="page-padding" cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td>
                <table class="inputtable" cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td style="padding-right: 10px; padding-left: 10px; padding-bottom: 10px; padding-top: 10px">
                            <div class="clear20">
                            </div>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="background: #fff;
                                border: #f2faff solid 0px; padding: 20px;">
                                <tr>
                                    <td valign="top" style="padding-top: 10px; background: #f2faff">
                                        <%--ShowCheckBoxes="All" --%>
                                        <style>
                                            .TVAlbums
                                            {
                                                background-color: none;
                                                width: 100px;
                                                padding: 10px;
                                            }
                                            .TVAlbumsseletednode
                                            {
                                                font-weight: bold;
                                                width: 150px;
                                            }
                                            .NodeChild
                                            {
                                                padding: 0px;
                                            }
                                        </style>
                                        <asp:TreeView ID="TVAlbums" runat="server" OnSelectedNodeChanged="TVAlbums_OnSelectedNodeChanged"
                                            Style="margin: 0px 10px; font-size: 14px;" Width="140px" SelectedNodeStyle-CssClass="TVAlbumsseletednode"
                                            NodeStyle-CssClass="NodeChild" ShowLines="true">
                                        </asp:TreeView>
                                    </td>
                                    <td valign="top" align="left">
                                        <div id="gallery" style="height: 320px; overflow-y: auto; border: solid 1px #ccc;
                                            width: 550px;">
                                            <asp:DataList ID="dtlistImages" runat="server" RepeatDirection="Horizontal" RepeatColumns="3"
                                                CssClass="datalist" OnItemDataBound="dtlistImages_ItemDataBound" DataKeyField="Image_ID">
                                                <ItemTemplate>
                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%" class="imggrid" style="border: 0px solid orange;">
                                                        <colgroup>
                                                            <col width="10px" />
                                                            <col width="*" />
                                                        </colgroup>
                                                        <tr class="row1">
                                                            <td>
                                                                <asp:CheckBox runat="server" ID="chk" />
                                                            </td>
                                                            <td style="vertical-align: top;">
                                                                <asp:Label ID="imgpreview" runat="server" Text='<%#Eval("Image_Unique_Name") %>'></asp:Label><br />
                                                                <asp:Label ID="lblImageUniqueName" Style="display: none;" runat="server" Text='<%#Eval("Image_Unique_Name") %>'></asp:Label><br />
                                                                <asp:Label ID="lblimgName" runat="server" Text='<%#Eval("Image_Name") %>'></asp:Label><br />
                                                                <asp:Label ID="lblImgID" runat="server" Style="display: none;" Text='<%#Eval("Image_ID") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:DataList>
                                        </div>
                                        <br />
                                        <div style="float: left; padding: 5px;">
                                            <%--  <asp:Button ID="btnSubmit" runat="server" CssClass="btnneworange" Text="Submit" OnClientClick="return ValidateImgSelection()"
                                                OnClick="btnSubmit_OnClick" />--%>
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
    <asp:HiddenField runat="server" ID="hdnAlbumID" Value="0" />
    <%--1 is Parent--%>
    <%--2 is Child--%>
    <asp:HiddenField runat="server" ID="hdnIsParent" Value="0" />
    <asp:HiddenField runat="server" ID="hdnAlbumUniqueName" />
    <script>
        function ClosePopupWindow() {
            var window = parent.$find("MasterGalleryPre");
            window.hide();
            return true;
        }

    </script>
</asp:Panel>
