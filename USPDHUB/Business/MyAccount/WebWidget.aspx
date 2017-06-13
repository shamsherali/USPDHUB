<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true"
    CodeBehind="WebWidget.aspx.cs" Inherits="USPDHUB.Business.MyAccount.WebWidget"
    ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <script type="text/javascript" src="../../Scripts/radio.js"></script>
    <%--<script type="text/javascript" src="../../Scripts/float.js"></script>
    <script type="text/javascript" src="../../Scripts/float-div.js"></script>--%>
    <script type="text/javascript" src="../../Scripts/jscolor.js"></script>
    <script type="text/javascript" src="../../Scripts/prototype.js" charset="utf-8"></script>
    <script type="text/javascript" src="../../Scripts/scriptaculous.js" charset="utf-8"></script>
    <script type="text/javascript" src="../../Scripts/rssfeeds.js" charset="utf-8"></script>
    <script charset="utf-8" src="../../Scripts/setting_en.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../Scripts/effects.js" charset="utf-8"></script>
    <link href="../../css/feeds.css" media="all" type="text/css" rel="stylesheet">
    <style type="text/css">
        .couponcode
        {
            /*width: 50px;*/
        }
        .couponcode:hover .coupontooltip
        {
            display: block;
        }
        
        .coupontooltip
        {
            font-weight: normal;
            font-size: 14px;
            display: none;
            background: #D9E8FF;
            border: 1px dashed #297CCF;
            position: absolute;
            padding:6px;
            z-index: 1000;
            width: 300px;
            height: auto;
            color: Black;
        }
    </style>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="page-padding" cellspacing="0" cellpadding="0" width="100%" border="0">
                <tbody>
                    <tr>
                        <td>
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td style="height: 32px; font-size: 18px; color: #EC2027; margin-bottom: 5px; margin-top: 5px;
                                            font-weight: bold;" valign="top">
                                            Generate Content Feed HTML Code &nbsp;&nbsp; <span class="couponcode">
                                                <img border="0" src="../../images/Dashboard/new.png" />
                                                <span class="coupontooltip" style="margin:4px 0px 0px 340px;">With the content widget you may customize the appearance
                                                    of the widget and generate the code that allows you to embed it on your website
                                                    to automatically display specific content from your mobile app.</span> </span>
                                        </td>
                                        <td class="navy20" valign="top" align="center" style="padding-left: 300px;">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 32px; font-size: 15px; margin-bottom: 5px; margin-top: 5px; font-weight: bold;"
                                            valign="top" colspan="2">
                                            Generate the HTML code to display content on other sites.
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="padding-right: 70px;" colspan="2">
                                            <label id="lblMailSuccessMsg" style="color: Green; width: 900px; font-weight: bold;">
                                            </label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="padding-right: 70px;" colspan="2">
                                            <asp:UpdateProgress ID="UpdateProgress3" runat="server" DisplayAfter="3">
                                                <ProgressTemplate>
                                                    <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table width="930px" border="0" cellspacing="0" cellpadding="0">
                                <tbody>
                                    <tr>
                                        <td valign="top">
                                            <div style="position: relative; width: 100%;" id="main">
                                                <div id="divWidget">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tbody>
                                                            <tr id="bothdiv">
                                                                <td valign="top" style="padding-top: 17px;">
                                                                    <div class="form LeftInfo">
                                                                        <div class="Feed_Section">
                                                                            <div class="FeedSectionTitle">
                                                                                General</div>
                                                                            <div class="FeedInner">
                                                                                <div class="Clear">
                                                                                    <div class="General">
                                                                                        <div class="basic">
                                                                                            <div class="komoku" style="height: 30px;">
                                                                                                <strong class="padding15">Widget Type</strong>
                                                                                                <select id="rssmikle_feedtype">
                                                                                                    <asp:Literal ID="ltrlOptions" runat="server"></asp:Literal>
                                                                                                </select>
                                                                                                <br />
                                                                                                <br />
                                                                                                <input type="hidden" id="rssmikle_id" runat="server" />
                                                                                                <input type="hidden" id="rssmikle_path" runat="server" />
                                                                                            </div>
                                                                                            <div class="komoku">
                                                                                                <span style="margin-top: 2px;">Width</span>
                                                                                                <input id="rssmikle_frame_width" type="text" value="300" size="4" maxlength="4">
                                                                                                <span>px</span> <span style="margin-top: 2px;">Height</span>
                                                                                                <input id="rssmikle_frame_height" class="frame_height_en" type="text" value="400"
                                                                                                    size="4" maxlength="4">
                                                                                                <span>px</span>
                                                                                            </div>
                                                                                            <div class="komoku">
                                                                                                <span style="width: 100%; text-align: center; padding: 0px; padding-top: 6px; font-weight: normal;">
                                                                                                    Min: 100px & Max: 900px</span>
                                                                                                <br />
                                                                                                <br />
                                                                                            </div>
                                                                                        </div>
                                                                                        <div id="dhtmlgoodies_a1" class="dhtmlgoodies_answer" style="top: 0px; height: 1px;">
                                                                                            <div id="dhtmlgoodies_ac1" class="dhtmlgoodies_answer_content" style="width: 100%;
                                                                                                float: left; top: -65px; margin-top: 10px;">
                                                                                                <strong>Open links in</strong>
                                                                                                <br />
                                                                                                <span style="height: 25px; padding-right: 0px;">
                                                                                                    <input id="rssmikle_target1" class="RadioClass7" type="radio" checked="checked" value="_blank"
                                                                                                        name="rssmikle_target">
                                                                                                    <label id="Label21" class="RadioLabelClassWindow RadioSelected7" for="rssmikle_target1"
                                                                                                        style="width: 115px;">
                                                                                                        <span style="padding-top: 3px; padding-right: 5px;">New Window</span><img border="0"
                                                                                                            src="../../images/newwindow.png" width="22px" />
                                                                                                    </label>
                                                                                                    <span class="couponcode" style="padding:4px;"><img border="0" src="../../images/Dashboard/new.png" />
                                                                                                    <span class="coupontooltip" style="font-weight:normal;padding:4px;margin:4px;">Items selected from the widget open in a new browser window.</span></span>&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                                </span><span style="height: 25px; padding-right: 0px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input
                                                                                                    id="rssmikle_target2" class="RadioClass7" type="radio" value="_top" name="rssmikle_target">
                                                                                                    <label id="Label22" class="RadioLabelClassWindow" for="rssmikle_target2" style="width: 120px;">
                                                                                                        <span style="padding-top: 3px; padding-right: 5px;">Same Window</span><img border="0"
                                                                                                            src="../../images/samewindow.png" />
                                                                                                    </label>
                                                                                                    <span class="couponcode" style="padding:4px;"><img border="0" src="../../images/Dashboard/new.png" />
                                                                                                    <span class="coupontooltip" style="font-weight:normal;padding:4px;margin:4px;">Items selected from the widget open in the same window of
                                                                                                        the browser.</span></span>&nbsp;&nbsp;&nbsp;&nbsp; </span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                                                                                            <div class="komoku" style="width: 100%; float: left;">
                                                                                                <span style="float: left; margin-top: 5px;">Corner</span> <span>
                                                                                                    <input id="corner1" class="RadioClassCorner" type="radio" checked="checked" value="off"
                                                                                                        name="corner">
                                                                                                    <label class="RadioLabelClassCorner" for="corner1">
                                                                                                        <span style="padding-top: 3px;">Square</span></label>
                                                                                                </span><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input id="corner2" class="RadioClassCorner"
                                                                                                    type="radio" value="on" name="corner">
                                                                                                    <label class="RadioLabelClassCorner RadioSelectedCorner" for="corner2">
                                                                                                        <span style="padding-top: 3px;">Rounded</span>
                                                                                                    </label>
                                                                                                </span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                                                                                            <div class="komoku" style="width: 100%; float: left; padding-top: 15px">
                                                                                                <strong class="padding15">Feed Font</strong>
                                                                                                <select id="rssmikle_font">
                                                                                                    <option value="">Choose Font Family</option>
                                                                                                    <option value="Times New Roman, serif">Times New Roman, serif</option>
                                                                                                    <option selected="" value="Arial, Helvetica, sans-serif">Arial, Helvetica, sans-serif</option>
                                                                                                    <option value="Courier New, Courier, mono">Courier New, Courier, mono</option>
                                                                                                    <option value="Trebuchet MS, Verdana, Arial">Trebuchet MS, Verdana, Arial</option>
                                                                                                    <option value="Verdana, Arial, sans-serif">Verdana, Arial, sans-serif</option>
                                                                                                    <option value="Geneva, Arial, sans-serif">Geneva, Arial, sans-serif</option>
                                                                                                </select>
                                                                                            </div>
                                                                                            <div class="komoku" style="width: 100%; float: left; padding-top: 15px;">
                                                                                                <span style="float: left; margin-top: 2px;">Font Size</span>
                                                                                                <input id="rssmikle_font_size" type="text" size="3" maxlength="2">
                                                                                                <span class="font08">px</span>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="Feed_Section">
                                                                            <div class="FeedSectionTitle">
                                                                                Feed Title</div>
                                                                            <div class="basic FeedInner">
                                                                                <div class="komoku" style="float: left; width: 100%;">
                                                                                    <div class="General">
                                                                                        <div id="dhtmlgoodies_a2" class="dhtmlgoodies_answer" style="display: block; height: 46px;
                                                                                            visibility: visible;">
                                                                                            <div id="dhtmlgoodies_ac2" class="dhtmlgoodies_answer_content" style="float: left;
                                                                                                width: 100%; top: 0px;">
                                                                                                <span style="float: left; margin-top: 2px;">Background Color#</span>
                                                                                                <input id="rssmikle_title_bgcolor" class="color" type="text" value="9ACD32" size="7"
                                                                                                    maxlength="6" style="margin-top: 0px; width: 100px; background-image: none; background-color: rgb(154, 205, 50);
                                                                                                    color: rgb(0, 0, 0);" autocomplete="off">
                                                                                                <button id="rssmikle_title_bgcolor_colorbox" class="colorbox" style="margin: 0px 0px 3px;
                                                                                                    width: 1.5em; height: 1.5em; border: 1px outset rgb(102, 102, 102); display: none;
                                                                                                    background-color: rgb(154, 205, 50);">
                                                                                                </button>
                                                                                            </div>
                                                                                            <div class="komoku" style="float: left; width: 100%;">
                                                                                                <span style="float: left; margin-top: 8px;">Font Color#</span>
                                                                                                <input id="rssmikle_title_color" class="color" type="text" value="FFFFFF" size="7"
                                                                                                    maxlength="6" style="margin-top: 7px; margin-left: 45px; width: 100px; background-image: none;
                                                                                                    background-color: rgb(255, 255, 255); color: rgb(0, 0, 0);" autocomplete="off">
                                                                                                <button id="rssmikle_title_color_colorbox" class="colorbox" style="margin: 0px 0px 3px;
                                                                                                    width: 1.5em; height: 1.5em; border: 1px outset rgb(102, 102, 102); display: none;
                                                                                                    background-color: rgb(255, 255, 255);">
                                                                                                </button>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="setting Feed_Section" style="width: auto;">
                                                                            <div class="FeedSectionTitle">
                                                                                Feed Content</div>
                                                                            <div class="basic FeedInner">
                                                                                <div class="General">
                                                                                    <div class="komoku" style="float: left; width: 100%; margin: 0 0 20px 0;">
                                                                                        <span style="float: left; line-height: 2em">Font Color</span>
                                                                                        <div id="entryfont_title" class="" style="float: left;">
                                                                                            <span style="line-height: 2em !important; padding: 10px 10px 0 12px;">Title#</span>
                                                                                            <input id="rssmikle_item_title_color" class="color" type="text" value="666666" style="margin-top: 7px;
                                                                                                margin-left: 0px; width: 100px; background-image: none; background-color: rgb(102, 102, 102);
                                                                                                color: rgb(255, 255, 255);" size="7" maxlength="6" autocomplete="off">
                                                                                            <button id="rssmikle_item_title_color_colorbox" class="colorbox" style="margin: 0px 0px 3px;
                                                                                                width: 1.5em; height: 1.5em; border: 1px outset rgb(102, 102, 102); display: none;
                                                                                                background-color: rgb(102, 102, 102);">
                                                                                            </button>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="komoku" style="float: left; width: 100%; margin: 0 0 20px 0;">
                                                                                        <div id="entryfont_content" class="" style="float: left; margin: 0 0 0 -1px;">
                                                                                            <span style="line-height: 2em !important; margin: 0 0 0 65px; padding: 10px 10px 0 0;">
                                                                                                Content#</span>
                                                                                            <input id="rssmikle_item_description_color" class="color" type="text" value="666666"
                                                                                                style="margin-top: 7px; margin-left: 0px; width: 100px; background-image: none;
                                                                                                background-color: rgb(102, 102, 102); color: rgb(255, 255, 255);" size="7" maxlength="6"
                                                                                                autocomplete="off">
                                                                                            <button id="rssmikle_item_description_color_colorbox" class="colorbox" style="margin: 0px 0px 3px;
                                                                                                width: 1.5em; height: 1.5em; border: 1px outset rgb(102, 102, 102); display: none;
                                                                                                background-color: rgb(102, 102, 102);">
                                                                                            </button>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="komoku" style="float: left; width: 100%; margin: 0 0 20px 0;">
                                                                                        <span style="float: left; line-height: 2em !important;">Background Color#</span>
                                                                                        <input id="rssmikle_item_bgcolor" class="color" type="text" value="" style="margin-top: 7px;
                                                                                            width: 100px; background-image: none; background-color: rgb(255, 255, 255); color: rgb(0, 0, 0);"
                                                                                            size="7" maxlength="6" autocomplete="off">
                                                                                        <button id="rssmikle_item_bgcolor_colorbox" class="colorbox" style="margin: 0px 0px 3px;
                                                                                            width: 1.5em; height: 1.5em; border: 1px outset rgb(102, 102, 102); display: none;
                                                                                            background-color: rgb(255, 255, 255);">
                                                                                        </button>
                                                                                    </div>
                                                                                    <div id="dhtmlgoodies_a3" class="dhtmlgoodies_answer" style="display: block; height: 73px;
                                                                                        visibility: visible;">
                                                                                        <div class="komoku" style="float: left; width: 100%;">
                                                                                            <span style="float: left; padding: 5px 0 15px 0!important; margin-right: 40px;">Separator
                                                                                                Line</span>
                                                                                            <input id="rssmikle_item_border_bottom1" class="RadioClass3" type="radio" checked="checked"
                                                                                                value="on" name="rssmikle_item_border_bottom">
                                                                                            <label class="RadioLabelClassEntryck RadioSelected3" for="rssmikle_item_border_bottom1">
                                                                                                <span class="font14" style="padding: 0px;">On</span>
                                                                                            </label>
                                                                                            <input id="rssmikle_item_border_bottom2" class="RadioClass3" type="radio" value="off"
                                                                                                name="rssmikle_item_border_bottom">
                                                                                            <label class="RadioLabelClassEntryck" for="rssmikle_item_border_bottom2">
                                                                                                <span class="font14" style="padding: 0px;">Off</span>
                                                                                            </label>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                                <td valign="top">
                                                                    <div style="float: right; position: relative; width: 550px;" class="floatsection">
                                                                        <div style="right: 0px; top: 0px;" id="floatdiv" class="preview box">
                                                                            <div style="float: left; position: relative; width: 100%; font-size: 20px; color: #1A44FA;"
                                                                                class="FloatSection">
                                                                                Preview
                                                                                <div style="display: none;" id="rssMiklePreview">
                                                                                    <img src="../../images/popup_ajax-loader.gif"></div>
                                                                                <div id="rssmikle_preview">
                                                                                    <%--<iframe width="302" scrolling="no" height="402" frameborder="0" hspace="0" vspace="0"
                                                                                marginheight="0" marginwidth="0" src="http://feed.mikle.com/widget?rssmikle_url=http%3A%2F%2Frss.cnn.com%2Frss%2Fedition.rss&amp;rssmikle_frame_width=300&amp;rssmikle_frame_height=400&amp;rssmikle_target=_blank&amp;rssmikle_font=Arial%2C%20Helvetica%2C%20sans-serif&amp;rssmikle_font_size=12&amp;rssmikle_border=on&amp;responsive=off&amp;text_align=left&amp;corner=off&amp;autoscroll=off&amp;scrolldirection=up&amp;scrollstep=3&amp;mcspeed=20&amp;sort=New&amp;rssmikle_title=on&amp;rssmikle_title_bgcolor=%239ACD32&amp;rssmikle_title_color=%23FFFFFF&amp;rssmikle_item_bgcolor=%23FFFFFF&amp;rssmikle_item_title_length=55&amp;rssmikle_item_title_color=%23666666&amp;rssmikle_item_border_bottom=on&amp;rssmikle_item_description=on&amp;rssmikle_item_description_length=150&amp;rssmikle_item_description_color=%23666666&amp;rssmikle_item_date=off&amp;rssmikle_timezone=Etc%2FGMT&amp;datetime_format=%25b%20%25e%2C%20%25Y%20%25l%3A%25M%3A%25S%20%25p&amp;rssmikle_item_description_tag=off&amp;rssmikle_item_description_image_scaling=off&amp;rssmikle_item_podcast=off&amp;"
                                                                                name="rssmikle_frame" onload="$('rssMiklePreview').hide();" id="rssmikle_iframe">
                                                                            </iframe>--%>
                                                                                </div>
                                                                                <%--<p style="color: #1A44FA; margin: 10px 0 -25px 0px; font-size: 17px;">
                                                                                Add to your site</p>
                                                                            <div style="font-size: 12px; margin: 25px 0 0; width: 100%; word-spacing: 1px;">
                                                                                <p style="float: left; color: #666666;">
                                                                                You may use FeedWind as long as you agree to the</p>
                                                                            <a style="float: right;" target="_blank" href="http://support.feed.mikle.com/legal">
                                                                                <p style="color: #0099CC; font-size: 11px;">
                                                                                    Terms of Service</p>
                                                                            </a>
                                                                            </div>--%>
                                                                            </div>
                                                                            <br>
                                                                            <div class="RightInner" style="margin: 15px 0 0;">
                                                                                <a id="generate-description" href="javascript:void(0);">Generate Code</a>
                                                                            </div>
                                                                            <%--<div class="RightInner">
                                                                            <textarea id="rssmikle_snippet" name="content" cols="50" rows="5" readonly="" style="margin-top: 5px;"></textarea>
                                                                        </div>

                                                                        <div class="RightInner">
                                                                            <a id="copy-description" href="javascript:void(0);">Select Code</a>
                                                                            <a class="cookie_save"
                                                                            onclick="saveValue(forms[0])" href="javascript:void(0);">
                                                                            <img width="14px" height="14px;" border="0" src="http://support.feed.mikle.com/images/inbox.png">
                                                                            Save the design</a> <a class="cookie_restore" onclick="restoreValue(forms[0])" href="javascript:void(0);">
                                                                                <img width="14px" height="14px;" border="0" src="http://support.feed.mikle.com/images/outgoing.png">
                                                                                Restore</a>
                                                                        </div>--%>
                                                                            <br style="clear: both;">
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </div>
                                                <div id="divCode" style="display: none;">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tbody>
                                                            <tr>
                                                                <td>
                                                                    <p style="color: #1A44FA; margin: 10px 0 -25px 0px; font-size: 17px;">
                                                                        Add to your site</p>
                                                                    <div style="font-size: 12px; margin: 25px 0 0; width: 100%; word-spacing: 1px;">
                                                                        <%--<p style="float: left; color: #666666;">
                                                                                You may use FeedWind as long as you agree to the</p>
                                                                            <a style="float: right;" target="_blank" href="http://support.feed.mikle.com/legal">
                                                                                <p style="color: #0099CC; font-size: 11px;">
                                                                                    Terms of Service</p>
                                                                            </a>--%>
                                                                    </div>
                                                                    <div class="RightInner">
                                                                        <textarea id="rssmikle_snippet" name="content" cols="100" rows="5" readonly="" style="margin-top: 5px;"></textarea>
                                                                    </div>
                                                                    <div class="RightInner">
                                                                        <a id="copy-description" href="javascript:void(0);">Select Code</a> <a id="create-widget"
                                                                            href="javascript:void(0);">Change Code</a> <a id="send-code" href="javascript:void(0);"
                                                                                class="topopup">Send Code</a>
                                                                        <%--<a class="cookie_save"
                                                                            onclick="saveValue(forms[0])" href="javascript:void(0);">
                                                                            <img width="14px" height="14px;" border="0" src="http://support.feed.mikle.com/images/inbox.png">
                                                                            Save the design</a> <a class="cookie_restore" onclick="restoreValue(forms[0])" href="javascript:void(0);">
                                                                                <img width="14px" height="14px;" border="0" src="http://support.feed.mikle.com/images/outgoing.png">
                                                                                Restore</a>--%>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>
                                            <!--main-->
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>
            <div style="width: 100%;" align="center">
                <asp:Button ID="btnBack" runat="server" Text="Back" Width="100px" Height="25px" OnClientClick="javascript:history.go(-1)" />
            </div>
            <div id="toPopup">
                <div class="close">
                </div>
                <div id="popup_content">
                    <div align="center">
                        <label id="lblMailFailureMsg" style="color: Red; width: 450px; font-weight: bold;">
                        </label>
                    </div>
                    <div align="center" style="display: none;" id="divPopLoader">
                        <img src="../../images/popup_ajax-loader.gif">
                        Sending...</div>
                    <br />
                    <span style="color: red; text-align: center">* Marked fields are mandatory.</span>
                    <div class="clear15">
                    </div>
                    <label for="user">
                        <span style="color: red">*</span> Email ID:</label>
                    <input type="text" runat="server" style="width: 250px;" class="inputtextarea" id="txtEmail"
                        name="txtEmail">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmail"
                        Display="Dynamic" ErrorMessage="Email ID is mandatory." SetFocusOnError="True"
                        ValidationGroup="g">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                        Display="Dynamic" ErrorMessage="Invalid Email Format." SetFocusOnError="True"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="g">*</asp:RegularExpressionValidator>
                    <label for="user">
                        <span style="color: red">*</span> Subject:</label>
                    <input type="text" runat="server" style="width: 250px;" class="inputtextarea" id="txtSubject"
                        name="txtSubject">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtSubject"
                        Display="Dynamic" ErrorMessage="Subject is mandatory." SetFocusOnError="True"
                        ValidationGroup="g">*</asp:RequiredFieldValidator>
                    <label for="user">
                        <span style="color: red">*</span> Description:</label>
                    <textarea class="feedTextarea" runat="server" style="width: 250px;" rows="5" id="txtDescription"
                        name="txtDescription"></textarea>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDescription"
                        Display="Dynamic" ErrorMessage="Description is mandatory." SetFocusOnError="True"
                        ValidationGroup="g">*</asp:RequiredFieldValidator>
                    <div id="send">
                        <a href="javascript:EmailCode()" runat="server" class="livebox" style="text-decoration: none;">
                            Send</a>
                    </div>
                    <asp:ValidationSummary ID="Valsummery" runat="server" ValidationGroup="g" HeaderText="Errors:"
                        ShowSummary="true" class="summary" />
                </div>
            </div>
            <div id="backgroundPopup">
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
        var popupStatus = 0; // set value
        jQuery(function ($) {

            $("a.topopup").click(function () {
                document.getElementById('<%=txtEmail.ClientID%>').value = '';
                document.getElementById('<%=txtSubject.ClientID%>').value = '';
                document.getElementById('<%=txtDescription.ClientID%>').value = '';
                document.getElementById('lblMailFailureMsg').innerHTML = '';
                document.getElementById('lblMailSuccessMsg').innerHTML = '';
                document.getElementById('<%=Valsummery.ClientID%>').style.display = 'none';
                document.getElementById('<%=RequiredFieldValidator2.ClientID%>').style.display = 'none';
                document.getElementById('<%=RequiredFieldValidator3.ClientID%>').style.display = 'none';
                document.getElementById('<%=RequiredFieldValidator4.ClientID%>').style.display = 'none';
                document.getElementById('<%=RegularExpressionValidator1.ClientID%>').style.display = 'none';
                //loading(); // loading
                setTimeout(function () { // then show popup, deley in .5 second
                    loadPopup(); // function show popup
                }, 500); // .5 second
                return false;
            });

            /* event for close the popup */
            $("div.close").click(function () {
                disablePopup();  // function close pop up
            });

            $(this).keyup(function (event) {
                if (event.which == 27) { // 27 is 'Ecs' in the keyboard
                    disablePopup();  // function close pop up
                }
            });

            $("div#backgroundPopup").click(function () {
                disablePopup();  // function close pop up
            });


            /************** start: functions. **************/



            function loadPopup() {
                if (popupStatus == 0) { // if value is 0, show popup
                    //closeloading(); // fadeout loading
                    $("#toPopup").fadeIn(0500); // fadein popup div
                    $("#backgroundPopup").css("opacity", "0.7"); // css opacity, supports IE7, IE8
                    $("#backgroundPopup").fadeIn(0001);
                    popupStatus = 1; // and set value to 1
                }
            }

            function disablePopup() {
                if (popupStatus == 1) { // if value is 1, close popup
                    $("#toPopup").fadeOut("normal");
                    $("#backgroundPopup").fadeOut("normal");
                    popupStatus = 0;  // and set value to 0
                }
            }
            /************** end: functions. **************/
        });  // jQuery End
    </script>
    <script type="text/javascript">
        //Sending email using page methods
        function EmailCode() {
            if (Page_ClientValidate('g') && Page_IsValid) {
                $('divPopLoader').show();
                var feedCode = $('rssmikle_snippet').value;
                var toEmail = document.getElementById('<%=txtEmail.ClientID%>').value;
                var subject = document.getElementById('<%=txtSubject.ClientID%>').value;
                var description = document.getElementById('<%=txtDescription.ClientID%>').value;
                var profileID = $('ctl00_cphUser_rssmikle_id').value;
                PageMethods.EmailHTMLCode(toEmail, feedCode, subject, description, profileID, feedemail_Success, feedemail_Failure);
            }
        }
        function feedemail_Success(result) {
            if (result == "SUCCESS") {
                $('divPopLoader').hide();
                new Effect.Fade('toPopup',
                    { duration: 2 });
                new Effect.Fade('backgroundPopup',
                    { duration: 2 });
                popupStatus = 0;
                document.getElementById('lblMailSuccessMsg').innerHTML = "Your email has been sent successfully.";
            }
            else
                feedemail_Failure();
        }
        function feedemail_Failure() {
            $('divPopLoader').hide();
            document.getElementById('lblMailFailureMsg').innerHTML = "This email failed. please try again."
        }

    </script>
</asp:Content>
