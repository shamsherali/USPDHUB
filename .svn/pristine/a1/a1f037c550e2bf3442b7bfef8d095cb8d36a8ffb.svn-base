<%@ Page Title="" Language="C#" MasterPageFile="~/PaidTools.master" AutoEventWireup="true"
    CodeBehind="DataFeedsSettings.aspx.cs" Inherits="USPDHUB.Business.MyAccount.DataFeedsSettings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <style>
        .Feed_Section
        {
            float: left;
            width: 537px;
            -webkit-border-radius: 4px;
            border-radius: 4px;
            padding-bottom: 24px;
            margin-bottom: 8px;
        }
        .FeedSectionTitle
        {
            font-size: 14px;
            font-weight: bold;
            color: #fff; /*background:#1a44fa;*/
            background: #00AAD5;
            -webkit-border-radius: 4px 4px 0 0;
            border-radius: 4px 4px 0 0;
            padding: 8px 12px;
            padding: 10px;
        }
        .FeedInner
        {
            display: block;
            padding: 25px 20px;
            float: left;
            width: 496px;
            background: #fafafa;
            background: #fafafa;
            border-left: 1px solid #eaeaea;
            border-right: 1px solid #eaeaea;
            border-bottom: 1px solid #eaeaea;
        }
        .komoku input[type="button"]
        {
            border: 1px solid #0198be;
            -webkit-border-radius: 3px;
            -moz-border-radius: 3px;
            border-radius: 3px;
            padding: 5px 15px;
            text-shadow: -1px -1px 0 rgba(0,0,0,0.3);
            font-weight: bold;
            text-align: center;
            color: #fff;
            background-color: #06f;
            background-image: -webkit-gradient(linear,left top,left bottom,from(#00aad5),top(#00aad5));
            background-image: -webkit-linear-gradient(top,#00aad5,#00aad5);
            background-image: -moz-linear-gradient(top,#00aad5,#00aad5);
            background-image: -ms-linear-gradient(top,#00aad5,#00aad5);
            background-image: -o-linear-gradient(top,#00aad5,#00aad5);
            background-image: linear-gradient(to bottom,#00aad5,#00aad5);
            cursor: pointer;
            float: left;
            font-family: GIL,Gill Sans MT;
            font-size: 14px;
            margin-right: 4px;
            text-decoration: none;
            width: auto;
            height: auto;
        }
        .komoku input[type="button"]:hover
        {
            border: 1px solid #0198be !important;
            background-color: #0052cc !important;
            background-image: -webkit-gradient(linear,left top,left bottom,from(#19b8e0),to(#19b8e0)) !important;
            background-image: -webkit-linear-gradient(top,#19b8e0,#19b8e0) !important;
            background-image: -moz-linear-gradient(top,#19b8e0,#19b8e0) !important;
            background-image: -ms-linear-gradient(top,#19b8e0,#19b8e0) !important;
            background-image: -o-linear-gradient(top,#19b8e0,#19b8e0) !important;
            background-image: linear-gradient(to bottom,#19b8e0,#19b8e0) !important;
        }
        /******************************
Preview, Code
******************************/
        #floatdiv
        {
            float: left;
            height: auto;
            padding: 0;
            width: 378px;
            z-index: 999999;
        }
        .RightInner
        {
            float: left;
            width: 353px;
            padding-bottom: 20px;
            width: 100%;
        }
        .RightInner textarea
        {
            border: 1px solid #c3d7e1;
            -webkit-border-radius: 4px;
            border-radius: 4px;
            padding: 9px;
            height: 160px;
            width: 358px;
            font-size: 12px;
            font-weight: bold;
            color: #454545;
            font-family: Arial,Helvetica,sans-serif;
        }
    </style>
    <script src="../../Scripts/jquery.js" type="text/javascript"></script>
    <script src="../../Scripts/feeds/rssmikle.js" type="text/javascript"></script>
    <script>
        function GetPreview() {

            var frameWidth = document.getElementById("txtframe_width").value;
            var frameHeight = document.getElementById("txtframe_height").value;

            ifrm = document.createElement("IFRAME");
            ifrm.setAttribute("src", "http://localhost:2107/ProfileIframes/datafeedspreview.aspx?ProfileID=10001&FeedsType=Updates");
            ifrm.style.height = frameHeight + "px";
            ifrm.style.width = frameWidth + "px"
            ifrm.style.border = "0px";
            ifrm.scrolling = "no";
            ifrm.frameBorder = "0";
            document.getElementById('divIFrame').innerHTML = "";
            document.getElementById('divIFrame').appendChild(ifrm);
        }
        
    </script>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td>
                        <div class="floatsection" style="width: 378px; float: right; position: relative;">
                            <div style="top: 0px; right: 0px; position: absolute;" id="framepreview" class="preview box">
                                <div style="width: 100%; color: rgb(26, 68, 250); font-size: 20px; float: right;
                                    position: relative; float: left;" class="FloatSection">
                                    Preview
                                    <div style="display: none;" id="Div2">
                                        <img src="../../../images/ajax-loader.gif"></div>
                                    <div id="divIFrame">
                                        <iframe id="iframe" onload="$('rssMiklePreview').hide();" vspace="0" height="802"
                                            marginheight="0" src="http://localhost:2107/ProfileIframes/datafeedspreview.aspx?ProfileID=10001&FeedsType=Updates"
                                            frameborder="0" width="302" name="frame" marginwidth="0" scrolling="no" hspace="0">
                                        </iframe>
                                    </div>
                                </div>
                                <br style="clear: both;">
                            </div>
                        </div>
                        <div class="Feed_Section">
                            <div class="FeedSectionTitle">
                                General
                            </div>
                            <div class="FeedInner">
                                <div>
                                    <span>Width</span><input id="txtframe_width" maxlength="4" value="300" size="4" type="text"
                                        onchange="javascript:GetPreview();"><span>px</span> <span>Height</span><input id="txtframe_height"
                                           onchange="javascript:GetPreview();" maxlength="4" value="400" size="4" type="text"><span>px</span>
                                    <br>
                                    <br>
                                </div>
                                <div style="top: 0px; width: 100%; float: left;" id="dhtmlgoodies_ac1">
                                    <strong>Open links in</strong><br>
                                    <span>
                                        <input id="rbFrame_NewWindow" value="_blank" checked="checked" type="radio" name="frameLinksWindow">
                                        <label>
                                            <span style="padding-top: 3px;">New Window</span>&nbsp;
                                            <img border="0" src="../../../images/new_window.gif">
                                        </label>
                                    </span><span>
                                        <input id="rbFrame_SameWindow" value="_top" type="radio" name="frameLinksWindow">
                                        <label>
                                            <span style="padding-top: 3px;">Same Window</span>&nbsp;
                                            <img border="0" src="../../../images/same_window.gif" width="16" height='16'>
                                        </label>
                                    </span>
                                </div>
                                <div style="width: 100%; padding-top: 15px; float: left;">
                                    <strong>Font</strong>
                                    <select id="ddlFrame_fontFamily">
                                        <option value="">Choose Font Family</option>
                                        <option value="Times New Roman, serif">Times New Roman, serif</option>
                                        <option selected="" value="Arial, Helvetica, sans-serif">Arial, Helvetica, sans-serif</option>
                                        <option value="Courier New, Courier, mono">Courier New, Courier, mono</option>
                                        <option value="Trebuchet MS, Verdana, Arial">Trebuchet MS, Verdana, Arial</option>
                                        <option value="Verdana, Arial, sans-serif">Verdana, Arial, sans-serif</option>
                                        <option value="Geneva, Arial, sans-serif">Geneva, Arial, sans-serif</option>
                                    </select>
                                </div>
                                <div style="width: 100%; padding-top: 15px; float: left;">
                                    <span style="float: left;">Font Size</span>
                                    <input id="txtFrame_font_size" maxlength="2" size="3" type="text">
                                    <span class="font08">px</span>
                                </div>
                            </div>
                        </div>
                        <div class="Feed_Section">
                            <div class="FeedSectionTitle">
                                Feed Title
                            </div>
                            <div class="FeedInner">
                                <div style="top: 0px; width: 100%; float: left;">
                                    <span style="float: left;">Background Color#</span>
                                    <input style="width: 100px; color: rgb(0, 0, 0); margin-top: 7px; background-image: none;
                                        background-color: rgb(154, 205, 50);" id="Feed_title_bgcolor" class="color" maxlength="6"
                                        value="9ACD32" size="7" type="text" autocomplete="off">
                                    <button style="margin: 0px 0px 3px; border: 1px outset rgb(102, 102, 102); width: 1.5em;
                                        height: 1.5em; display: none; background-color: rgb(154, 205, 50);" id="Feed_title_bgcolor_Colorbox"
                                        class="colorbox">
                                    </button>
                                </div>
                                <div style="width: 100%; float: left;" class="komoku">
                                    <span style="float: left;">Font Color#</span>
                                    <input style="width: 100px; color: rgb(0, 0, 0); margin-top: 7px; margin-left: 50px;
                                        background-image: none; background-color: rgb(194, 255, 198);" id="feed_title_forecolor"
                                        class="color" maxlength="6" value="FFFFFF" size="7" type="text" autocomplete="off">
                                    <button style="margin: 0px 0px 3px; border: 1px outset rgb(102, 102, 102); width: 1.5em;
                                        height: 1.5em; display: none; background-color: rgb(194, 255, 198);" id="feed_title_forecolor_colorbox"
                                        class="colorbox">
                                    </button>
                                </div>
                            </div>
                        </div>
                        <div class="Feed_Section">
                            <div class="FeedSectionTitle">
                                Feed Content
                            </div>
                            <div class="FeedInner">
                                <div style="margin: 0px 0px 20px; float: left;" class="komoku">
                                    <span style="line-height: 2em; float: left;">Font Color</span>
                                    <div style="float: left;" id="entryfont_title">
                                        <span style="padding: 10px 10px 0px 0px; line-height: 2em !important;">Title#</span>
                                        <input style="width: 100px; color: rgb(255, 255, 255); margin-top: 7px; margin-left: 0px;
                                            background-image: none; background-color: rgb(102, 102, 102);" id="item_title_forecolor"
                                            class="color" maxlength="6" value="666666" size="7" type="text" autocomplete="off">
                                        <button style="margin: 0px 0px 3px; border: 1px outset rgb(102, 102, 102); width: 1.5em;
                                            height: 1.5em; display: none; background-color: rgb(102, 102, 102);" id="item_title_forecolor_colorbox"
                                            class="colorbox">
                                        </button>
                                    </div>
                                    <div style="margin: 0px 0px 0px -1px; float: right;" id="entryfont_content">
                                        <span style="line-height: 2em !important;">Content#</span>
                                        <input style="width: 100px; color: rgb(255, 255, 255); margin-top: 7px; margin-left: 0px;
                                            background-image: none; background-color: rgb(102, 102, 102);" id="item_content_forecolor"
                                            class="color" maxlength="6" value="666666" size="7" type="text" autocomplete="off">
                                        <button style="margin: 0px 0px 3px; border: 1px outset rgb(102, 102, 102); width: 1.5em;
                                            height: 1.5em; display: none; background-color: rgb(102, 102, 102);" id="item_content_forecolor_colorbox"
                                            class="colorbox">
                                        </button>
                                    </div>
                                </div>
                                <div style="margin: 0px 0px 20px; width: 100%; float: left;" class="komoku">
                                    <span style="line-height: 2em !important; float: left;">Background Color#</span>
                                    <input style="width: 100px; color: rgb(0, 0, 0); margin-top: 7px; background-image: none;
                                        background-color: rgb(255, 255, 255);" id="item_bgcolor" class="color" maxlength="6"
                                        value="" size="7" type="text" autocomplete="off">
                                    <button style="margin: 0px 0px 3px; border: 1px outset rgb(102, 102, 102); width: 1.5em;
                                        height: 1.5em; display: none; background-color: rgb(255, 255, 255);" id="item_bgcolor_colorbox"
                                        class="colorbox">
                                    </button>
                                </div>
                                <div style="padding: 9px 0px; width: 100%; float: left;" class="komoku">
                                    <span style="padding: 0px 0px 15px !important; width: 100%; float: left;">Separator
                                        Line</span><br>
                                    <input id="item_border_bottom1" class="RadioClass3" name="item_border_bottom" value="on"
                                        checked="checked" type="radio">
                                    <label class="RadioLabelClassEntryck RadioSelected3" for="item_border_bottom1">
                                        <span style="padding: 0px;" class="font14">On</span></label>
                                    &nbsp;
                                    <input id="item_border_bottom2" class="RadioClass3" name="item_border_bottom" value="off"
                                        type="radio">
                                    <label class="RadioLabelClassEntryck" for="item_border_bottom2">
                                        <span style="padding: 0px;" class="font14">Off</span></label>
                                </div>
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
            <input id="url" type="hidden" value="http://localhost:2107/ProfileIframes/datafeedspreview.aspx?ProfileID=10001&FeedsType=Updates" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
