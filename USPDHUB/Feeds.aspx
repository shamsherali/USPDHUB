<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Feeds.aspx.cs" Inherits="USPDHUB.Feeds" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/feeds.css" media="all" type="text/css" rel="stylesheet">
    <script type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <script type="text/javascript" src="Scripts/radio.js"></script>
    <script type="text/javascript" src="Scripts/float.js"></script>
    <script type="text/javascript" src="Scripts/float-div.js"></script>
    <script type="text/javascript" src="Scripts/jscolor.js"></script>
    <script type="text/javascript" src="Scripts/prototype.js" charset="utf-8"></script>
    <script type="text/javascript" src="Scripts/rssfeeds.js" charset="utf-8"></script>
    <script charset="utf-8" src="Scripts/setting_en.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    
                        <table width="900px" border="0" cellspacing="0" cellpadding="0">
                            <tbody>
                                <tr>
                                    <td valign="top">
                                        <div style="position: relative; width: 100%;" id="main">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tbody>
                                                    <tr id="bothdiv">
                                                        <td valign="top">
                                                            <div class="form LeftInfo">
                                                                <div class="Feed_Section">
                                                                    <div class="FeedSectionTitle">
                                                                        General</div>
                                                                    <div class="FeedInner">
                                                                        <div class="Clear">
                                                                            <div class="General">
                                                                                <div class="basic">
                                                                                    <div class="komoku">
                                                                                        <span>Type</span>
                                                                                        <select id="rssmikle_feedtype">
                                                                                            <option selected="" value="Updates">Updates</option>
                                                                                            <option value="Bulletins">Bulletins</option>
                                                                                        </select>
                                                                                        <br />
                                                                                        <br />
                                                                                        <input type="hidden" id="rssmikle_id" value="xBtv5Bu5yKY=" />
                                                                                    </div>
                                                                                    <div class="komoku">
                                                                                        <span>Width</span>
                                                                                        <input id="rssmikle_frame_width" type="text" value="300" size="4" maxlength="4">
                                                                                        <span>px</span> <span>Height</span>
                                                                                        <input id="rssmikle_frame_height" class="frame_height_en" type="text" value="400"
                                                                                            size="4" maxlength="4">
                                                                                        <span>px</span>
                                                                                        <br />
                                                                                        <br />
                                                                                    </div>
                                                                                </div>
                                                                                <div id="dhtmlgoodies_a1" class="dhtmlgoodies_answer" style="top: 0px; height: 1px;">
                                                                                    <div id="dhtmlgoodies_ac1" class="dhtmlgoodies_answer_content" style="width: 100%;
                                                                                        float: left; top: -65px;">
                                                                                        <strong>Open links in</strong>
                                                                                        <br />
                                                                                        <span>
                                                                                            <input id="rssmikle_target1" class="RadioClass7" type="radio" checked="checked" value="_blank"
                                                                                                name="rssmikle_target">
                                                                                            <label id="Label21" class="RadioLabelClassWindow RadioSelected7" for="rssmikle_target1">
                                                                                                <span style="padding-top: 3px;">New Window</span>
                                                                                                <img border="0" src="http://support.feed.mikle.com/images/new_window.gif" />
                                                                                            </label>
                                                                                        </span><span>
                                                                                            <input id="rssmikle_target2" class="RadioClass7" type="radio" value="_top" name="rssmikle_target">
                                                                                            <label id="Label22" class="RadioLabelClassWindow" for="rssmikle_target2">
                                                                                                <span style="padding-top: 3px;">Same Window</span>
                                                                                                <img width="16" border="0" height="16" src="http://support.feed.mikle.com/images/same_window.gif" />
                                                                                            </label>
                                                                                        </span>
                                                                                    </div>
                                                                                    <div class="komoku" style="width: 100%; float: left; padding-top: 15px;">
                                                                                        <strong>Font</strong>
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
                                                                                        <span style="float: left;">Font Size</span>
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
                                                                                        <span style="float: left;">Background Color#</span>
                                                                                        <input id="rssmikle_title_bgcolor" class="color" type="text" value="9ACD32" size="7"
                                                                                            maxlength="6" style="margin-top: 7px; width: 100px; background-image: none; background-color: rgb(154, 205, 50);
                                                                                            color: rgb(0, 0, 0);" autocomplete="off">
                                                                                        <button id="rssmikle_title_bgcolor_colorbox" class="colorbox" style="margin: 0px 0px 3px;
                                                                                            width: 1.5em; height: 1.5em; border: 1px outset rgb(102, 102, 102); display: none;
                                                                                            background-color: rgb(154, 205, 50);">
                                                                                        </button>
                                                                                    </div>
                                                                                    <div class="komoku" style="float: left; width: 100%;">
                                                                                        <span style="float: left;">Font Color#</span>
                                                                                        <input id="rssmikle_title_color" class="color" type="text" value="FFFFFF" size="7"
                                                                                            maxlength="6" style="margin-top: 7px; margin-left: 50px; width: 100px; background-image: none;
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
                                                                            <div class="komoku" style="float: left; margin: 0 0 20px 0;">
                                                                                <span style="float: left; line-height: 2em">Font Color</span>
                                                                                <div id="entryfont_title" class="" style="float: left;">
                                                                                    <span style="line-height: 2em !important; padding: 10px 10px 0 0;">Title#</span>
                                                                                    <input id="rssmikle_item_title_color" class="color" type="text" value="666666" style="margin-top: 7px;
                                                                                        margin-left: 0px; width: 100px; background-image: none; background-color: rgb(102, 102, 102);
                                                                                        color: rgb(255, 255, 255);" size="7" maxlength="6" autocomplete="off">
                                                                                    <button id="rssmikle_item_title_color_colorbox" class="colorbox" style="margin: 0px 0px 3px;
                                                                                        width: 1.5em; height: 1.5em; border: 1px outset rgb(102, 102, 102); display: none;
                                                                                        background-color: rgb(102, 102, 102);">
                                                                                    </button>
                                                                                </div>
                                                                                <div id="entryfont_content" class="" style="float: right; margin: 0 0 0 -1px;">
                                                                                    <span style="line-height: 2em !important;">Content#</span>
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
                                                                                <div class="komoku" style="float: left; padding: 9px 0; width: 100%;">
                                                                                    <span style="float: left; padding: 0 0 15px 0!important; width: 100%;">Separator Line</span>
                                                                                    <br />
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
                                                            <div style="float: right; position: relative; width: 378px;" class="floatsection">
                                                                <div style="position: absolute; right: 0px; top: 0px;" id="floatdiv" class="preview box">
                                                                    <div style="float: right; position: relative; width: 100%; font-size: 20px; color: #1A44FA;"
                                                                        class="FloatSection">
                                                                        Preview
                                                                        <div style="display: none;" id="rssMiklePreview">
                                                                            <img src="http://support.feed.mikle.com/images/ajax-loader.gif"></div>
                                                                        <div id="rssmikle_preview">
                                                                            <%--<iframe width="302" scrolling="no" height="402" frameborder="0" hspace="0" vspace="0"
                                                                                marginheight="0" marginwidth="0" src="http://feed.mikle.com/widget?rssmikle_url=http%3A%2F%2Frss.cnn.com%2Frss%2Fedition.rss&amp;rssmikle_frame_width=300&amp;rssmikle_frame_height=400&amp;rssmikle_target=_blank&amp;rssmikle_font=Arial%2C%20Helvetica%2C%20sans-serif&amp;rssmikle_font_size=12&amp;rssmikle_border=on&amp;responsive=off&amp;text_align=left&amp;corner=off&amp;autoscroll=off&amp;scrolldirection=up&amp;scrollstep=3&amp;mcspeed=20&amp;sort=New&amp;rssmikle_title=on&amp;rssmikle_title_bgcolor=%239ACD32&amp;rssmikle_title_color=%23FFFFFF&amp;rssmikle_item_bgcolor=%23FFFFFF&amp;rssmikle_item_title_length=55&amp;rssmikle_item_title_color=%23666666&amp;rssmikle_item_border_bottom=on&amp;rssmikle_item_description=on&amp;rssmikle_item_description_length=150&amp;rssmikle_item_description_color=%23666666&amp;rssmikle_item_date=off&amp;rssmikle_timezone=Etc%2FGMT&amp;datetime_format=%25b%20%25e%2C%20%25Y%20%25l%3A%25M%3A%25S%20%25p&amp;rssmikle_item_description_tag=off&amp;rssmikle_item_description_image_scaling=off&amp;rssmikle_item_podcast=off&amp;"
                                                                                name="rssmikle_frame" onload="$('rssMiklePreview').hide();" id="rssmikle_iframe">
                                                                            </iframe>--%>
                                                                        </div>
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
                                                                    </div>
                                                                    <div class="RightInner">
                                                                        <textarea id="rssmikle_snippet" name="content" cols="50" rows="5" readonly="" style="margin-top: 5px;"></textarea>
                                                                    </div>
                                                                    <div class="RightInner">
                                                                        <a id="copy-description" href="javascript:void(0);">Select Code</a>
                                                                        <%--<a class="cookie_save"
                                                                            onclick="saveValue(forms[0])" href="javascript:void(0);">
                                                                            <img width="14px" height="14px;" border="0" src="http://support.feed.mikle.com/images/inbox.png">
                                                                            Save the design</a> <a class="cookie_restore" onclick="restoreValue(forms[0])" href="javascript:void(0);">
                                                                                <img width="14px" height="14px;" border="0" src="http://support.feed.mikle.com/images/outgoing.png">
                                                                                Restore</a>--%>
                                                                    </div>
                                                                    <br style="clear: both;">
                                                                </div>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                        <!--main-->
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    
    </form>
</body>
</html>
