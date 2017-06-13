<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataFeedsPreview.aspx.cs"
    Inherits="USPDHUB.ProfileIframes.DataFeedsPreview" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style type="text/css">
        #content
        {
            height: 100%;
            overflow: hidden;
        }
        #content:hover
        {
            overflow-y: auto;
        }
        .mCustomScrollBox > .mCSB_scrollTools
        {
            /* 15 */
            height: 100%;
            right: 0;
            top: 0;
            width: 16px;
        }
        .mCSB_scrollTools .mCSB_draggerContainer
        {
            /*21*/
            bottom: 0;
            height: auto;
            left: 0;
            position: absolute;
            right: 0;
            top: 0;
        }
        .mCSB_scrollTools a + .mCSB_draggerContainer
        {
            /*29*/
            margin: 20px 0;
        }
        .mCSB_scrollTools .mCSB_draggerRail
        {
            /*32*/
            border-radius: 10px;
            height: 100%;
            margin: 0 auto;
            width: 2px;
        }
        .mCSB_scrollTools .mCSB_dragger
        {
            /*40*/
            cursor: pointer;
            height: 30px;
            width: 100%;
        }
        .mCSB_scrollTools .mCSB_dragger .mCSB_dragger_bar
        {
            /*45*/
            border-radius: 10px;
            height: 100%;
            margin: 0 auto;
            text-align: center;
            width: 4px;
        }
        .mCSB_scrollTools .mCSB_buttonUp, .mCSB_scrollTools .mCSB_buttonDown
        {
            /* 54*/
            cursor: pointer;
            display: block;
            height: 20px;
            margin: 0 auto;
            overflow: hidden;
            position: relative;
        }
        .mCSB_scrollTools .mCSB_buttonDown
        {
            /*63*/
            margin-top: -40px;
            top: 100%;
        }
        .mCustomScrollBox > .mCSB_scrollTools
        {
            /* 134*/
            opacity: 0.75;
        }
        .mCSB_scrollTools .mCSB_draggerRail
        {
            /*142*/
            background: none repeat scroll 0 0 rgba(0, 0, 0, 0.4);
        }
        .mCSB_scrollTools .mCSB_dragger .mCSB_dragger_bar
        {
            /*147*/
            background: none repeat scroll 0 0 rgba(255, 255, 255, 0.75);
        }
        .mCSB_scrollTools .mCSB_buttonUp, .mCSB_scrollTools .mCSB_buttonDown, .mCSB_scrollTools .mCSB_buttonLeft, .mCSB_scrollTools .mCSB_buttonRight
        {
            /*161*/
            background-image: url("../images/mCSB_buttons.png");
            background-repeat: no-repeat;
            opacity: 0.4;
        }
        
        .mCSB_scrollTools .mCSB_buttonUp
        {
            /*170*/
            background-position: 0 0;
        }
        .mCSB_scrollTools .mCSB_buttonDown
        {
            /*176*/
            background-position: 0 -20px;
        }
        .mCSB_scrollTools .mCSB_buttonUp:hover, .mCSB_scrollTools .mCSB_buttonDown:hover, .mCSB_scrollTools .mCSB_buttonLeft:hover, .mCSB_scrollTools .mCSB_buttonRight:hover
        {
            opacity: 0.75;
        }
        .mCSB_scrollTools .mCSB_buttonUp:active, .mCSB_scrollTools .mCSB_buttonDown:active, .mCSB_scrollTools .mCSB_buttonLeft:active, .mCSB_scrollTools .mCSB_buttonRight:active
        {
            opacity: 0.9;
        }
        /*.mCS-dark-thin > .mCSB_scrollTools .mCSB_draggerRail {
    background: none repeat scroll 0 0 rgba(0, 0, 0, 0.15);    
}
.mCS-dark-thin > .mCSB_scrollTools .mCSB_dragger .mCSB_dragger_bar {
    background: none repeat scroll 0 0 rgba(0, 0, 0, 0.75);    
    width: 2px;
}
.mCS-dark-thin > .mCSB_scrollTools .mCSB_buttonUp {
    background-position: -80px 0px;
}
.mCS-dark-thin > .mCSB_scrollTools .mCSB_buttonDown { 
    background-position: -80px -20px;
}*/
        .mCS-dark-thick > .mCSB_scrollTools .mCSB_draggerRail
        {
            background: none repeat scroll 0 0 rgba(0, 0, 0, 0.1);
            border-radius: 2px;
            width: 4px;
        }
        .mCS-dark-thick > .mCSB_scrollTools .mCSB_dragger .mCSB_dragger_bar
        {
            background: none repeat scroll 0 0 rgba(0, 0, 0, 0.40);
            border-radius: 2px;
            width: 6px;
        }
        .mCS-dark-thick > .mCSB_scrollTools .mCSB_buttonUp
        {
            background-position: -112px 0px;
        }
        .mCS-dark-thick > .mCSB_scrollTools .mCSB_buttonDown
        {
            background-position: -112px -20px;
        }
    </style>
    <script type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
    <script type='text/javascript'>
<!--
        function getObjectHeight(obj) {
            var result = 0;
            if (obj.offsetHeight) {
                result = obj.offsetHeight;
            } else if (obj.clip && obj.clip.height) {
                result = obj.clip.height;
            } else if (obj.style && obj.style.pixelHeight) {
                result = obj.style.pixelHeight;
            } else if (obj.scrollHeight) {
                result = obj.scrollHeight;
            }
            return strToInt(result);
        }

        function getElementStyle(obj, IEStyleProp, CSSStyleProp) {
            if (obj.currentStyle) {
                return obj.currentStyle[IEStyleProp];
            } else if (window.getComputedStyle) {
                return window.getComputedStyle(obj, '').getPropertyValue(CSSStyleProp);
            } else if (document.defaultView.getComputedStyle) {
                return document.defaultView.getComputedStyle(obj, '').getPropertyValue(CSSStyleProp);
            }
            return '';
        }
        function strToInt(str) {
            num = parseInt(str);
            if (isNaN(num)) {
                return 0;
            } else if (!num) {
                return 0;
            }
            return num;
        }

        var autoscrollTimer;
        function init() {
            var rssMikleType = '';
            var anchorTarget = document.getElementById('hdnTarget').value;

            var containerObj = document.getElementById('container');
            var headerObj = document.getElementById('header') ? document.getElementById('header') : "";
            var contentObj = document.getElementById('content');

            var totalHeight = getObjectHeight(containerObj);
            var borderSize = 1 * 2;
            var headerHeight = headerObj ? getObjectHeight(headerObj) + strToInt(getElementStyle(headerObj, 'marginTop', 'margin-top')) + strToInt(getElementStyle(headerObj, 'marginBottom', 'margin-bottom')) : 0;
            var contentMargin = strToInt(getElementStyle(contentObj, 'marginTop', 'margin-top')) + strToInt(getElementStyle(contentObj, 'marginBottom', 'margin-bottom'))
            var contentPadding = strToInt(getElementStyle(contentObj, 'paddingTop', 'padding-top')) + strToInt(getElementStyle(contentObj, 'paddingBottom', 'padding-bottom'));

            var contentHeight = totalHeight - borderSize - headerHeight - contentMargin - contentPadding;
            var tmpHeight = contentHeight - contentPadding;

            if (rssMikleType == 'ticker') {
                var spanElem = document.getElementsByTagName('span');
                for (var i = 0; i < spanElem.length; i++) {
                    if (spanElem[i].className == 'feed_item_title') {
                    } else if (spanElem[i].className == 'feed_item_podcast') {
                        spanElem[i].innerHTML = "";
                    } else if (spanElem[i].className == 'feed_item_description') {
                        spanElem[i].innerHTML = spanElem[i].innerHTML.replace(/<.*?>/g, '');
                    }
                }
            } else {
                var divElem = document.getElementsByTagName('div');
                var noneFlag = 0;
                var itemCounter = 1;
                for (var i = 0; i < divElem.length; i++) {
                    if (divElem[i].className == 'feed_item') {
                        if (!noneFlag) {
                            var tmpObjHeight = getObjectHeight(divElem[i]);
                            var tmpMarginTop = strToInt(getElementStyle(divElem[i], 'marginTop', 'margin-top'));
                            var tmpMarginBottom = strToInt(getElementStyle(divElem[i], 'marginBottom', 'margin-bottom'));
                            tmpHeight -= tmpObjHeight - tmpMarginTop;
                            if (tmpHeight < 0 && itemCounter != 1) {
                                if ('off' != 'on_scrollbar' && 'off' != 'on_flexcroll' && '' == 'off') {
                                    divElem[i].style.display = 'none';
                                    noneFlag = 1;
                                }
                            }
                            tmpHeight -= tmpMarginBottom;
                        } else {
                            divElem[i].style.display = 'none';
                        }
                        itemCounter++;
                    }
                }
                contentObj.style.height = contentHeight + 'px';
            }
            var aElem = document.getElementsByTagName('a');
            for (var i = 0; i < aElem.length; i++) {
                aElem[i].target = anchorTarget;
            }
        }
        window.onload = init;
-->
    </script>
    <script src="../Scripts/scrollbar.js" type="text/javascript"></script>
    <script>
        (function ($) {
            $(window).load(function () {
                $("#content").mCustomScrollbar({
                    scrollButtons: {
                        enable: true
                    },
                    theme: "dark-thick"
                });
            });
        })(jQuery);
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:ScriptManager runat="server">
                </asp:ScriptManager>
                <div id="container">
                    <div id="header">
                        <div class="feed_title">
                            <asp:Label ID="lblTitle" runat="server"></asp:Label>
                            <%--<%if (Request.QueryString["rssmikle_feedtype"].ToString() == "Updates")
                              {%>
                            Updates<%}
                              else if (Request.QueryString["rssmikle_feedtype"].ToString() == "Bulletins")
                              { %>
                            Bulletins
                            <%} 
                              else if (Request.QueryString["rssmikle_feedtype"].ToString() == "Events")
                              { %>
                              Events
                            <%} else { %>
                                Content Modules
                            <%} %>--%>
                            <asp:HiddenField ID="hdnTarget" runat="server" />
                        </div>
                    </div>
                    <div id="content">
                        <asp:DataList runat="server" ID="DLDataFeeds" RepeatDirection="Vertical" Style="width: 100%;
                            height: 100%;">
                            <ItemTemplate>
                                <div class="feed_item">
                                    <div class="feed_item_title">
                                        <a id="itemTitle" href='<%#Eval("URL") %>'>
                                            <%#Eval("title") %></a>
                                    </div>
                                    <div class="feed_item_description">
                                        <asp:Label ID="lblModifyDate" runat="server" Text='<%#Eval("ModifiedDate") %>'></asp:Label><br />
                                        <asp:Label ID="lblHtmlDescription" CssClass="feed_item_Content" runat="server" Text='<%#Eval("HtmlDescription") %>'></asp:Label>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:DataList>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
