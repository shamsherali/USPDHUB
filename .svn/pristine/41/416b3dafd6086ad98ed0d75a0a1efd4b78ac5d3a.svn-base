<%@ Page Title="" Language="C#" MasterPageFile="~/AdminHome.master" AutoEventWireup="true"
    CodeBehind="SetupContentModule.aspx.cs" Inherits="USPDHUB.Admin.SetupContentModule"
    ValidateRequest="false" %>

<%@ Import Namespace="USPDHUBBLL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <style>
     @charset "utf-8";
/* CSS Document */

body { font-family:Arial, Helvetica, sans-serif; font-size: 17px;
    background-color:white;
}
select
{
    color: #555555;
    height: 28px;
    width: 150px;
    color: #313131;
    font-size: 13px;
    text-align: left;
    border: 1px solid #c9c9c9;
    outline: none;
    margin: 0px 4px 8px 8px;
    background: #fff;
    padding: 3px;
    
    
}
.select1
{
    color: #555555;
    height: 28px;
    width: 170px;
    float: left;
    border: 1px solid #c9c9c9;
    outline: none;
    margin: 0px 4px 0px 0px;
    background: #fff;
    padding: 3px;
}
input {}
.lft { float:left}

.txt-input { 
 
    border: 1px solid #848484; 
    -webkit-border-radius: 30px; 
    -moz-border-radius: 30px; 
    border-radius: 30px; 
    outline:0; 
    height:25px; 
    width: 100px; 
    padding-left:10px; 
    padding-right:10px; 
	margin-left: 10px;
	margin-bottom: 8px;
  } 


#popup-cont { width:650px; display:block; margin: 0 auto; padding:0 auto; background:#1569C7; border:#1c1c1c solid 2px; padding:30px; border-radius:20px; }

#popup-cont h1 {font-size: 24px;font-weight: normal;color: #FFF;clear: both;display: block;margin: 0 auto; padding-left:20px; padding-bottom:20px; font-family:Arial, Helvetica, sans-serif}

#popup-cont h2 {font-size: 17px;font-weight: normal;color: #FFF;clear: both;display: block;margin: 0 auto; padding-left:20px;padding-bottom:20px;font-family:Arial, Helvetica, sans-serif}



#popup-cont .top	 { background:url('../../images/dashboard/top-part.png') no-repeat 0 0; width:588px; height:29px;}
#popup-cont .top a	 { position:relative; top: -8px; right: -565px; display:block; background:url('../../images/dashboard/close_btn.png') no-repeat 0 0; width:30px; height:30px;}

#popup-cont .middle { background:url('../../images/dashboard/middle-part.png')  repeat-y; }

#popup-cont .bottom { background:url('../../images/dashboard/bottom-part.png') no-repeat 0 0; width:588px; height:112px; }

#popup-cont .scrollablebox  { width:432px; display:block; height:104px; margin:0 auto;}
#popup-cont a.btn { background: url('../../images/dashboard/btn-on.png') no-repeat scroll 0px 0px transparent;
width: 144px;
height: 54px;
display: block;
font-size: 20px;
color: #323031;
text-decoration: none;
line-height: 52px;
text-align: center;
margin-left: 398px;
margin-top: 120px;}
#popup-cont a.btn1 { background: url('../../images/dashboard/btn-on.png') no-repeat scroll 0px 0px transparent;
width: 144px;
height: 54px;
display: block;
font-size: 20px;
color: #323031;
text-decoration: none;
line-height: 52px;
text-align: center;
margin-left: 230px;
margin-top: 120px;
float:left;
}
#popup-cont a.btn:hover { background:url('../../images/dashboard/btn-over.png') no-repeat 0 0; width:144px ; height:54px}


#popup-cont ul { list-style:none; list-style-position:inside; background:#FFFFFF; padding:0; }
#popup-cont ul li { list-style:none;list-style-position:inside;  height:34px; float:left }

.auto{
	display:block;
	border: 1px solid white;
	padding:5px;
	height:165px;
	overflow:auto; background-color:#FFFFFF;
	}
.pad { padding:0px}
#szlider
        {
            width: 80%;
            height: 15px;
            border: 1px solid #000;
            overflow: hidden;
        }
        #szliderbar
        {
            width: 37%;
            height: 15px;
            border-right: 1px solid #000000;
            background: #ff6600;
        }
        .szliderbar
        {
            width: 37%;
            height: 15px;
            border-right: 1px solid #000000;
            background: #ff6600;
            float: left;
        }
        #szazalek
        {
            color: #000000;
            font-size: 15px;
            font-style: italic;
            font-weight: bold;
            left: 25px;
            position: relative;
            top: -16px;
        }
     </style>
    <script src="../../Scripts/flyers/jquery-1.7.2.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.contentcarousel.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.easing.1.3.js" type="text/javascript"></script>
    <link href="../../css/jquery.jscrollpane.css" rel="stylesheet" type="text/css" media="all" />
    <script type="text/javascript">
        $('#ca-container').contentcarousel();
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="page-padding">
                <tr>
                    <td style="padding-left: 6px;" valign="top">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="page-title">
                            <tr>
                                <td>
                                    Setup Additional Module
                                </td>
                                <td>
                                    <asp:Label ID="lblerr" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <div>
                            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="admin-padding inputgrid">
                                <tr>
                                    <td valign="top">
                                        <div id='divCustomTemplatePopupStep1'>
                                            <div id="popup-cont">
                                                <div>
                                                    <asp:Panel ID="pnlTemplates" runat="server" Style="display: none;">
                                                        <h1>
                                                            Install and configure additional module - step 1</h1>
                                                        <h2>
                                                            1. Select one of the below from the templates</h2>
                                                        <div class="scrollablebox">
                                                            <div class="ca-container" id="ca-container">
                                                                <div class="ca-nav">
                                                                    <span class="ca-nav-prev">Previous</span> <span class="ca-nav-next">Next</span>
                                                                </div>
                                                                <asp:Label runat="server" ID="lblCustomModuleInstallationhtml"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <a href="javascript:OpenCustomModulePopup2();" class="btn" id="btnStep1">Next</a>
                                                    </asp:Panel>
                                                    <asp:Panel ID="pnlNameandTab" runat="server">
                                                        <h1>
                                                            Install and configure
                                                            <asp:Label ID="lblModuleType" runat="server"></asp:Label>
                                                            - step 1</h1>
                                                        <%-- <h2 class="lft">
                                                            Select Module Type
                                                        </h2>--%>
                                                        <asp:DropDownList runat="server" ID="ddlModuleType" onchange="ChangeModuleHeader();"
                                                            Style="display: none;">
                                                            <asp:ListItem Text="Content Module" Value="AddOns" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="Calendar Module" Value='CalendarAddOns'></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <br />
                                                        <h2 class="lft">
                                                            1. App Button name</h2>
                                                        <asp:TextBox ID="txtAppButtonName" runat="server" onkeypress="return isNumberKey(event);"
                                                            onkeydown="return Maxlength(this);" MaxLength="13" class="txt-input"></asp:TextBox>
                                                        <h2>
                                                            2. App Button Icon (Select any one from the below list)</h2>
                                                        <div class="scrollablebox">
                                                            <div class="auto" id="divAppIcons">
                                                            </div>
                                                        </div>
                                                        <asp:LinkButton ID="lnkBack" runat="server" Text="Back" CssClass="btn1" OnClick="lnkBack_Click"></asp:LinkButton>
                                                        <asp:LinkButton ID="lnkNext" runat="server" class="btn" Text="Submit" OnClientClick="return OpenCustomModulePopup3()"
                                                            OnClick="lnkNext_Click"></asp:LinkButton>
                                                    </asp:Panel>
                                                    <asp:Panel ID="pnlProgress" runat="server" Style="display: none;">
                                                        <h1>
                                                            Install and configure
                                                            <%=ddlModuleType.SelectedItem.Text %></h1>
                                                        <div class="scrollablebox" style="color: White; width: 100%;" align="center">
                                                            <h3>
                                                                Installaton in progress. Please wait...</h3>
                                                            <br />
                                                            <img src="../../Images/popup_ajax-loader.gif" alt="progress" />
                                                            <br />
                                                            <div id="divUpload" style="display: none">
                                                                <div style="width: 300pt; height: 15px; border: solid 1pt gray">
                                                                    <div id="divProgress" runat="server" style="display: none;" class="szliderbar">
                                                                    </div>
                                                                    <asp:Label ID="lblPercentage" runat="server" Text="Label"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </asp:Panel>
                                                    <asp:Panel ID="pnlSuccess" runat="server" Style="display: none;">
                                                        <h1>
                                                        </h1>
                                                        <div class="scrollablebox" style="color: White; width: 100%;" align="center">
                                                            <h3>
                                                                New module has been installed and configured successfully.</h3>
                                                            <h3>
                                                                It is ready for use.</h3>
                                                        </div>
                                                        <asp:LinkButton ID="lnkBackLast" runat="server" Text="Back" CssClass="btn1" OnClick="lnkBack_Click"></asp:LinkButton>
                                                        <a href="javascript:HideCustomModuleModalWindow();" class="btn" id="A1">Add New</a>
                                                    </asp:Panel>
                                                </div>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
            <asp:HiddenField runat="server" ID="hdnModuleTemplateID" />
            <asp:HiddenField runat="server" ID="hdnModuleAppName" />
            <asp:HiddenField runat="server" ID="hdnModuleAppButton" />
            <asp:HiddenField runat="server" ID="hdnAddOnName" />
            <asp:HiddenField runat="server" ID="hdnLaunchPlay" />
            <asp:HiddenField runat="server" ID="hdnVersionPlay" />
            <script type="text/javascript">
                window.onload = function () {
                    OpenCustomModuleModalWindow();
                    ChangeModuleHeader();
                };

                var size = 2;
                var id = 0;
                function OpenCustomModuleModalWindow() {
                    BindDatatable();
                    document.getElementById("<%=hdnModuleAppButton.ClientID %>").value = "0";
                    document.getElementById("<%=txtAppButtonName.ClientID %>").value = "";
                    document.getElementById("<%=pnlNameandTab.ClientID %>").style.display = "block";
                    document.getElementById("<%=pnlProgress.ClientID %>").style.display = "none";
                    document.getElementById("<%=pnlSuccess.ClientID %>").style.display = "none";

                }
                function HideCustomModuleModalWindow() {
                    if (document.getElementById("<%=pnlSuccess.ClientID %>").style.display == "block")
                        location.reload();
                    else {

                    }
                }
                function GetSelectedModule(moduleTemplateID) {
                    var prevTempID = document.getElementById("<%=hdnModuleTemplateID.ClientID %>").value;
                    if (prevTempID != "0") {
                        $("#imgCustom" + prevTempID).removeClass("templateselect");
                        $("#imgCustom" + prevTempID).addClass("template");
                    }
                    $("#imgCustom" + moduleTemplateID).removeClass("template");
                    $("#imgCustom" + moduleTemplateID).addClass("templateselect");
                    document.getElementById("<%=hdnModuleTemplateID.ClientID %>").value = moduleTemplateID;
                }
                function OpenCustomModulePopup2() {
                    if (document.getElementById("<%=hdnModuleTemplateID.ClientID %>").value == "" || document.getElementById("<%=hdnModuleTemplateID.ClientID %>").value == "0") {
                        alert("Please select template.");
                    }
                    else {
                        document.getElementById("<%= pnlTemplates.ClientID %>").style.display = "none";
                        document.getElementById("<%= pnlNameandTab.ClientID %>").style.display = "block";
                        document.getElementById("<%=pnlProgress.ClientID %>").style.display = "none";
                        document.getElementById("<%=pnlSuccess.ClientID %>").style.display = "none";
                    }
                }
                function GetSelectAppButton(moduleAppButton) {

                    var src = moduleAppButton.split('/');
                    var imgFile = src[src.length - 1].replace(".jpeg", "").replace(".jpg", "").replace(".gif", "").replace(".png", "");
                    $("#img" + imgFile).parent("li").addClass("iconselect").siblings().removeClass('iconselect');
                    document.getElementById("<%=hdnModuleAppButton.ClientID %>").value = imgFile;

                }
                function OpenCustomModulePopup3() {
                    var appName = document.getElementById("<%=txtAppButtonName.ClientID %>").value;
                    document.getElementById("<%=hdnModuleAppName.ClientID %>").value = appName;

                    var errMsg = "";
                    if (appName == "") {
                        errMsg = "Please enter app button name.\n";
                    }
                    if (document.getElementById("<%=hdnModuleAppButton.ClientID %>").value == "0")
                        errMsg = errMsg + "Please select icon for app button.";

                    if (errMsg == "") {
                        if (ValidateAppButton()) {
                            document.getElementById("<%= pnlTemplates.ClientID %>").style.display = "none";
                            document.getElementById("<%= pnlNameandTab.ClientID %>").style.display = "none";
                            document.getElementById("<%= pnlProgress.ClientID %>").style.display = "block";
                            document.getElementById("<%=pnlSuccess.ClientID %>").style.display = "none";
                            size = 2;
                            id = 0;
                            ProgressBar();
                        }
                        else
                            return false;
                    }
                    else {
                        alert(errMsg);
                        return false;
                    }

                }
                function ProgressBar() {
                    document.getElementById("<%=divProgress.ClientID %>").style.display = "block";
                    document.getElementById("divUpload").style.display = "block";
                    id = setInterval("progress()", 20);
                }
                function progress() {
                    size = size + 1;
                    if (size > 299) {
                        clearTimeout(id);
                    }
                    document.getElementById("<%=divProgress.ClientID %>").style.width = size + "pt";
                    document.getElementById("<%=lblPercentage.ClientID %>").firstChild.data = parseInt(size / 3) + "%";
                }
                function ProgressTimer() {
                    document.getElementById("<%= pnlProgress.ClientID %>").style.display = "block";
                    var time = [0, 10, 26, 59, 77, 99, 101];
                    var i;
                    for (i = 0; i < time.length; i++) {
                        timer(time[i]);
                    }
                }
                function progressbar(percent) {
                    //var szazalek=Math.round((meik*100)/ossz);
                    document.getElementById("szliderbar").style.width = percent + '%';
                    document.getElementById("szazalek").innerHTML = percent + '%';
                }
                function timer(elapsedTime) {
                    if (elapsedTime > 100) {
                        document.getElementById("szazalek").style.color = "#FFF";
                        document.getElementById("szazalek").innerHTML = "Completed.";
                        document.getElementById("<%= pnlProgress.ClientID %>").style.display = "none";
                    }
                    else {
                        progressbar(elapsedTime);
                    }
                }
                function BindDatatable() {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "SetupContentModule.aspx/BindAppIcons",
                        data: "{moduleID:'" + document.getElementById("<%=hdnModuleTemplateID.ClientID %>").value + "'}",
                        dataType: "json",
                        success: function (data) {
                            var customAppIcons = "<ul class=\"AppIcons\">";
                            for (var i = 0; i < data.d.length; i++) {
                                var imgPath = data.d[i].ImagePath;
                                customAppIcons = customAppIcons + "<li class='icon'><img src='" + imgPath + "' alt='' id='img" + data.d[i].AppIcon + "' class='pad' onclick='javascript:GetSelectAppButton(this.src)' /></li>";
                            }
                            customAppIcons = customAppIcons + "</ul>";
                            $('#divAppIcons').html(customAppIcons);
                        },
                        error: function (result) {
                            alert("Error Occured.");
                        }
                    });
                }
                function isNumberKey(evt) {
                    var charCode = (evt.which) ? evt.which : event.keyCode;
                    if ((charCode > 47 && charCode < 58) || (charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123) || charCode == 32)
                        return true;
                    else
                        return false;
                }
                function ValidateAppButton() {
                    var appButton = document.getElementById("<%=txtAppButtonName.ClientID %>").value; ;
                    var re = /^[a-zA-Z0-9 ]*$/;
                    if ((re.test(appButton)) == true) {
                        returnValue = true;
                    }
                    else {
                        alert("Special characters are not allowed in tab names.");
                        returnValue = false;
                    }
                    return returnValue;
                }
                function Maxlength(text) {
                    var textLength = text.value.length;
                    if (parseInt(textLength) > 13) {
                        alert("The maximum allowable length should be 13 characters only.");
                        return false;
                    }
                    else
                        return true;
                }
                function ChangeModuleHeader() {
                    var ControlName = document.getElementById('<%=ddlModuleType.ClientID %>');
                    var SelectedText = ControlName.options[ControlName.selectedIndex].text;
                    document.getElementById('<%=lblModuleType.ClientID %>').innerHTML = SelectedText;
                } 
            </script>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
