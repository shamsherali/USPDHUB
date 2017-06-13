<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebnairRegister.aspx.cs"
    Inherits="USPDHUB.WebnairRegister" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/Webnair.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #bodyId
        {
            background: #cccccc;
            font-family: Arial, sans-serif;
            font-size: 12px;
            text-align: center;
            margin: 0px;
            padding: 0px;
        }
        
        div#outerWrapDiv
        {
            position: relative;
            height: 100%;
            width: 100%;
        }
        
        div#innerWrapDiv
        {
            position: relative;
            background: #ffffff;
            padding: 0px;
            margin-left: auto;
            margin-right: auto;
            margin-top: 15px;
            margin-bottom: 0px;
            text-align: left;
        }
        
        
        /* Width of Full Page */
        div#innerWrapDiv
        {
            width: 775px;
        }
        
        /* Main Content Area - Controls height of page */
        div#mktContent
        {
            background: #ffffff;
            position: relative;
            height: 775px;
            width: 100%;
        }
        
        div#mktHeader
        {
            position: realtive;
            height: 100px;
            background: #cccccc;
        }
        div#mktFooter
        {
            position: relative;
            height: 50px;
            background: #cccccc;
        }
        
        
        
        
        
        /* Start fancy button */
        
        div.buttonSubmit
        {
            position: relative;
            float: left;
        }
        
        
        div.buttonSubmit input, div.buttonSubmit span
        {
            background-image: url(https://www.marketo.com/buttons/button-submit10.gif); /* change button and path to correct customer partition */
            background-position: right 0px;
            background-repeat: no-repeat;
            border: 0px none;
            color: #FFA500;
            cursor: pointer;
            float: left;
            font-weight: bold;
            height: 36px;
            margin: 0px;
            padding: 0px 15px 2px;
            position: relative;
            z-index: 5;
        }
        div.buttonSubmit span
        {
            background-position: left -36px;
            left: 0px;
            padding: 0px;
            position: absolute;
            top: 0px;
            width: 4px;
            z-index: 10;
        }
        div.buttonSubmit input
        {
            width: auto;
            padding-left: 10px !important;
            padding-right: 10px !important;
        }
        
        #mktFrmSubmit
        {
            color: #FFFFFF !important;
        }
        
        div.buttonSubmit:hover input
        {
            background-position: right -72px;
        }
        div.buttonSubmit:hover span
        {
            background-position: left -108px;
        }
        
        #mktFrmReset
        {
            display: none;
        }
        
        /* end fancy button */
        
        
        
        
        DIV#outerWrapDiv
        {
            height: 600px;
        }
        DIV#mktContent
        {
            height: 650px;
            width: 725px;
            text-align: normal;
        }
        BODY#bodyId
        {
            height: 565px;
        }
        
        div#lpeCDiv_14198
        {
            position: absolute;
            left: 14px;
            top: 180px;
            width: 395px;
            z-index: 15;
            height: 422px;
        }
        div#lpeCDiv_14198 span.lpContentsItem
        {
        }
        
        div#lpeCDiv_14199
        {
            position: absolute;
            left: 18px;
            top: 107px;
            width: 702px;
            z-index: 15;
            height: 41px;
        }
        div#lpeCDiv_14199 span.lpContentsItem
        {
        }
        
        div#lpeCDiv_14200
        {
            position: absolute;
            height: 485px;
            width: 10px;
            z-index: 15;
            left: 422px;
            top: 131px;
        }
        div#lpeCDiv_14200 span.lpContentsItem img.lpimg
        {
            width: 100%;
            height: 100%;
        }
        div#lpeCDiv_14200 span.lpContentsItem
        {
        }
        
        div#lpeCDiv_14201
        {
            position: absolute;
            height: 17px;
            width: 772px;
            z-index: 15;
            left: 3px;
            top: 66px;
        }
        div#lpeCDiv_14201 span.lpContentsItem img.lpimg
        {
            width: 100%;
            height: 100%;
        }
        div#lpeCDiv_14201 span.lpContentsItem
        {
        }
        
        div#lpeCDiv_14202
        {
            position: absolute;
            z-index: 15;
            left: 458px;
            top: 198px;
        }
        div#lpeCDiv_14202 span.lpContentsItem
        {
        }
        
        div#lpeCDiv_14203
        {
            position: absolute;
            min-width: 50px;
            z-index: 15;
            min-height: 50px;
            left: 252px;
            top: 429px;
            width: 146px;
        }
        div#lpeCDiv_14203 div.lpContentsItem
        {
            width: 146px;
        }
        
        div#lpeCDiv_14204
        {
            position: absolute;
            height: 30px;
            width: 205px;
            z-index: 15;
            left: 507px;
            top: 21px;
        }
        div#lpeCDiv_14204 span.lpContentsItem img.lpimg
        {
            width: 100%;
            height: 100%;
        }
        div#lpeCDiv_14204 span.lpContentsItem
        {
        }
        
        div#lpeCDiv_14205
        {
            position: absolute;
            min-width: 50px;
            z-index: 15;
            min-height: 50px;
            left: 14px;
            top: 13px;
            height: 49px;
            width: 184px;
        }
        div#lpeCDiv_14205 div.lpContentsItem
        {
            height: 49px;
            width: 184px;
        }
        .marketoContent
        {
            position: relative;
        }
        /* form */
        .mktoForm .mktoButtonWrap.mktoFirefox .mktoButton
        {
            background-color: #82C43A;
            background-image: -webkit-linear-gradient(top, rgba(0,0,0,0), rgba(0,0,0,0.1));
            background-image: -moz-linear-gradient(top, rgba(0,0,0,0), rgba(0,0,0,0.1));
            background-image: -ms-linear-gradient(top, rgba(0,0,0,0), rgba(0,0,0,0.1));
            background-image: -o-linear-gradient(top, rgba(0,0,0,0), rgba(0,0,0,0.1));
            background-image: linear-gradient(top, rgba(0,0,0,0), rgba(0,0,0,0.1));
            border: none;
            display: inline-block;
            vertical-align: middle;
            margin: 2px;
            font: italic 14px/32px Georgia,Serif;
            text-align: center;
            color: white;
            text-decoration: none;
            text-shadow: 0px 1px 0px rgba(0,0,0,0.1);
            -webkit-box-shadow: inset 0px -3px 0px rgba(0,0,0,0.1), 0px 3px 0px rgba(0,0,0,0.1);
            -moz-box-shadow: inset 0px -3px 0px rgba(0,0,0,0.1), 0px 3px 0px rgba(0,0,0,0.1);
            box-shadow: inset 0px -3px 0px rgba(0,0,0,0.1), 0px 3px 0px rgba(0,0,0,0.1);
            padding: 0px 15px 3px;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            border-radius: 5px;
        }
        .mktoForm .mktoButtonWrap.mktoFirefox .mktoButton:hover
        {
            background-image: -webkit-linear-gradient(top, rgba(0,0,0,0.05), rgba(0,0,0,0.2));
            background-image: -moz-linear-gradient(top, rgba(0,0,0,0.05), rgba(0,0,0,0.2));
            background-image: -ms-linear-gradient(top, rgba(0,0,0,0.05), rgba(0,0,0,0.2));
            background-image: -o-linear-gradient(top, rgba(0,0,0,0.05), rgba(0,0,0,0.2));
            background-image: linear-gradient(top, rgba(0,0,0,0.05), rgba(0,0,0,0.2));
        }
        .mktoForm .mktoButtonWrap.mktoFirefox .mktoButton:active
        {
            position: relative;
            top: 2px;
            -webkit-box-shadow: inset 0px -1px 0px rgba(0,0,0,0.1), 0px 2px 0px rgba(0,0,0,0.1);
            -moz-box-shadow: inset 0px -1px 0px rgba(0,0,0,0.1), 0px 2px 0px rgba(0,0,0,0.1);
            box-shadow: inset 0px -1px 0px rgba(0,0,0,0.1), 0px 2px 0px rgba(0,0,0,0.1);
        }
        
        .mktoForm .mktoButtonWrap.mktoFirefox button.mktoButton
        {
            background: #FF5800;
        }
    </style>
    <script type="text/javascript">
        function EnablePaste() {
            alert(2);
            return false;   // enable the Paste menu item
        }

        function OnPaste() {
            if (window.clipboardData) {
                alert(window.clipboardData);
                window.clipboardData.setData("Text", "My clipboard data");
            }
        }
        function handlepaste(elem, e) {
            var savedcontent = elem.innerHTML;
            if (e && e.clipboardData && e.clipboardData.getData) {// Webkit - get data from clipboard, put into editdiv, cleanup, then cancel event
                if (/text\/html/.test(e.clipboardData.types)) {
                    elem.innerHTML = e.clipboardData.getData('text/html');
                }
                else if (/text\/plain/.test(e.clipboardData.types)) {
                    elem.innerHTML = e.clipboardData.getData('text/plain');
                }
                else {
                    elem.innerHTML = "";
                }
                waitforpastedata(elem, savedcontent);
                if (e.preventDefault) {
                    e.stopPropagation();
                    e.preventDefault();
                }
                return false;
            }
            else {// Everything else - empty editdiv and allow browser to paste content into it, then cleanup
                elem.innerHTML = "";
                waitforpastedata(elem, savedcontent);
                return true;
            }
        }

        function waitforpastedata(elem, savedcontent) {
            if (elem.childNodes && elem.childNodes.length > 0) {
                processpaste(elem, savedcontent);
            }
            else {
                that = {
                    e: elem,
                    s: savedcontent
                }
                that.callself = function () {
                    waitforpastedata(that.e, that.s)
                }
                setTimeout(that.callself, 20);
            }
        }

        function processpaste(elem, savedcontent) {
            pasteddata = elem.innerHTML;
            //^^Alternatively loop through dom (elem.childNodes or elem.getElementsByTagName) here

            elem.innerHTML = savedcontent;

            // Do whatever with gathered data;
            alert(pasteddata);
        }
    </script>
</head>
<body class="mktEditable" align="center" id="bodyId">
    <form id="form1" runat="server">
    <div id="outerWrapDiv" class="mktEditable">
        <div id="innerWrapDiv">
            <div id="lpeCDiv_14198" class="lpeCElement Rich_Text_1">
                <span class="lpContentsItem richTextSpan">
                    <p class="p1">
                        <span style="font-size: 14px; font-family: arial, helvetica, sans-serif;">
                            Register for this interactive event in San Francisco. Join Birst to experience Birst
                            5X. This new Adaptive UX enriches the way the modern business user works with data
                            and turns every information consumer into an intelligence producer.</span></p>
                    <p class="p1">
                        <span style="font-size: 14px; font-family: arial, helvetica, sans-serif;">
                            Join us for this breakfast meeting to:</span></p>
                    <ul>
                        <li><span style="font-family: arial, helvetica, sans-serif; font-size: 14px;">
                            Learn how to seamlessly transition between dashboards and discovery</span></li><li><span
                                style="font-family: arial, helvetica, sans-serif; font-size: 14px;">
                                Experience our new mobile experience including Offline analytics</span></li><li><span
                                    style="font-family: arial, helvetica, sans-serif; font-size: 14px;">
                                    Analyze data in Birst semantic layer, using other analytic tools (like Tableau,
                                    Excel or R)</span></li></ul>
                    <p class="ppad">
                        <br>
                    </p>
                    <p class="ppad">
                        <span style="font-size: 14px; font-family: arial, helvetica, sans-serif;">
                            <strong>Date:</strong>&nbsp;Wednesday, May 27</span></p>
                    <p class="ppad">
                        <span style="font-size: 14px; font-family: arial, helvetica, sans-serif;">
                            <strong>Time:&nbsp;</strong>8:30 AM</span></p>
                    <p class="ppad">
                        <strong><span style="font-size: 14px; font-family: arial, helvetica, sans-serif;">Where:<br/>
                        </span></strong><span style="font-family: arial, helvetica, sans-serif; font-size: 14px;">The Palace
                            Hotel<br>
                            2 New Montgomery St<br>
                            San Francisco, CA 94105</span></p>
                </span>
            </div>
            <div id="lpeCDiv_14199" class="lpeCElement Rich_Text_2">
                <span class="lpContentsItem richTextSpan">
                    <p>
                        <span style="font-size: 28px;"><strong>Birst on the Road
                            - San Francisco: See Birst 5X in Action<br>
                        </strong></span><strong style="font-size: 28px;"></strong>
                    </p>
                </span>
            </div>
            <div id="lpeCDiv_14200" class="lpeCElement Image_6">
                <span class="lpContentsItem imageSpan">
                    <img class="lpimg" src="../images/vert-line.png"></span></div>
            <div id="lpeCDiv_14201" class="lpeCElement Image_8">
                <span class="lpContentsItem imageSpan">
                    <img class="lpimg" src="../images/sub-header.png"></span></div>
            <div id="lpeCDiv_14202" class="lpeCElement FE_ED_2015-05-27_BOTR_-_DallasForm">
                <span class="lpContentsItem formSpan">
                    <div class="mktoForm mktoHasWidth mktoLayoutLeft" style="font-family: Helvetica,Arial,sans-serif;
                        font-size: 13px; color: #333; width: 291px;">
                        <div class="mktoFormRow">
                            <div style="margin-bottom: 10px;" class="mktoFieldDescriptor mktoFormCol">
                                <div style="width: 10px;" class="mktoOffset">
                                </div>
                                <div class="mktoFieldWrap mktoRequiredField">
                                    <label style="width: 120px;" class="mktoLabel mktoHasWidth" for="FirstName">
                                        <div class="mktoAsterix">
                                            *</div>
                                        First Name:</label><div style="width: 10px;" class="mktoGutter mktoHasWidth">
                                        </div>
                                    <input style="width: 150px;" class="mktoField mktoTextField mktoHasWidth mktoRequired"
                                        maxlength="255" name="FirstName" id="FirstName" type="text"><div class="mktoClear">
                                        </div>
                                </div>
                                <div class="mktoClear">
                                </div>
                            </div>
                            <div class="mktoClear">
                            </div>
                        </div>
                        <div class="mktoFormRow">
                            <div style="margin-bottom: 10px;" class="mktoFieldDescriptor mktoFormCol">
                                <div style="width: 10px;" class="mktoOffset">
                                </div>
                                <div class="mktoFieldWrap mktoRequiredField">
                                    <label style="width: 120px;" class="mktoLabel mktoHasWidth" for="LastName">
                                        <div class="mktoAsterix">
                                            *</div>
                                        Last Name:</label><div style="width: 10px;" class="mktoGutter mktoHasWidth">
                                        </div>
                                    <input style="width: 150px;" class="mktoField mktoTextField mktoHasWidth mktoRequired"
                                        maxlength="255" name="LastName" id="LastName" type="text"><div class="mktoClear">
                                        </div>
                                </div>
                                <div class="mktoClear">
                                </div>
                            </div>
                            <div class="mktoClear">
                            </div>
                        </div>
                        <div class="mktoFormRow">
                            <div style="margin-bottom: 10px;" class="mktoFieldDescriptor mktoFormCol">
                                <div style="width: 10px;" class="mktoOffset">
                                </div>
                                <div class="mktoFieldWrap mktoRequiredField">
                                    <label style="width: 120px;" class="mktoLabel mktoHasWidth" for="Email">
                                        <div class="mktoAsterix">
                                            *</div>
                                        Email Address:&nbsp;&nbsp;</label><div style="width: 10px;" class="mktoGutter mktoHasWidth">
                                        </div>
                                    <input style="width: 150px;" class="mktoField mktoEmailField mktoHasWidth mktoRequired"
                                        maxlength="255" name="Email" id="Email" type="email"><div class="mktoClear">
                                        </div>
                                </div>
                                <div class="mktoClear">
                                </div>
                            </div>
                            <div class="mktoClear">
                            </div>
                        </div>
                        <div class="mktoButtonRow">
                            <span style="margin-left: 0px;" class="mktoButtonWrap mktoFirefox">
                                <asp:LinkButton ID="lnkSubmit" runat="server" CssClass="mktoButton" OnClick="lnkSubmit_Click">Submit</asp:LinkButton>
                            </span>
                        </div>
                    </div>
                </span>
                <div id='div' contenteditable='true' onpaste='handlepaste(this, event)'>Register for this interactive event in San Francisco. Join Birst to experience Birst 5X. This new Adaptive UX enriches the way the modern business user works with data and turns every information consumer into an intelligence producer.</div>
            </div>
            <div id="lpeCDiv_14203" class="lpeCElement HTML_1">
                <div class="lpContentsItem rawHtmlSpan">
                    <p>
                        <img src="http://info.birst.com/rs/birst/images/sanfrancisco.jpg" width="165" /></p>
                </div>
            </div>
            <div id="lpeCDiv_14204" class="lpeCElement regionaleventspng">
                <span class="lpContentsItem imageSpan">
                    <img class="lpimg" src="http://info.birst.com/rs/birst/images/regionalevents.png"></span></div>
            <div id="lpeCDiv_14205" class="lpeCElement HTML_2">
                <div class="lpContentsItem rawHtmlSpan">
                    <img src="<%=LogoName %>" style="color: #616363; font-family: 'Helvetica Neue', Helvetica, Arial, sans-serif;
                        font-size: 18px; font-weight: 500;"></div>
            </div>
            <div id="mktHeader" class="mktEditable">
                <!-- Logo and Header -->
            </div>
            <div id="mktContent" class="mktEditable">
                <!-- Base of Landing Page Content -->
            </div>
        </div>
        <div id="mktFooter" class="mktEditable">
            <!-- Footer links -->
        </div>
    </div>
    </form>
</body>
</html>
