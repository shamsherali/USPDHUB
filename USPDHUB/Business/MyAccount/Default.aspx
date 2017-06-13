<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.master" AutoEventWireup="true"
    Inherits="Business_MyAccount_Default" CodeBehind="Default.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/EditCCDetails.ascx" TagName="CCDetails" TagPrefix="uc2" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphUser" runat="Server">
    <link href="../../css/jquery.ad-gallery.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/flyers/jquery-1.7.2.js" type="text/javascript"></script>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <%--<script type="text/javascript" src="../../Scripts/jquery.ad-gallery.js"></script>--%>
    <link href="../../css/dashboard.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $("#flip").click(function () {
                $("#divAppStats").slideToggle("fast");
            });

            //maintaining toggle state through out session


            var DomainName = '<%= Session["VerticalDomain"] %>';
            if (DomainName.toString().toLowerCase() == "inschoolalertcom") {
                var IsShowUpgradeISAMessage = '<%=IsShowUpgradeISAMessage %>';
                if (IsShowUpgradeISAMessage == "True")
                { alert("Your inSchoolALERT account has recently been upgraded to inSchoolHub and hence you will now be redirected to inSchoolHub dashboard."); }
            }


            //  ----------- Lite Dashboard Suggestions ----------
            var Start = 1;
            var End = 5;
            var SearchStart = Start;
            var SearchEnd = End;
            BindData(Start, End);
            //load more
            $("#btnloadMore").click(function () {
                SearchStart = SearchStart + End;
                SearchEnd = SearchEnd + End;
                BindData(SearchStart, SearchEnd);
            });



            function BindData(Start, End) {
                var value = '<%= Session["IsLiteVersion"] %>';

                var strSdata = "{Start:'" + Start + "',End:'" + End + "'}";
                $.ajax({
                    type: "POST",
                    url: "Default.aspx/GetContentActivityLog",
                    data: strSdata,
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: onSuccess,
                    failure: function (response) {
                        //alert(response.d);
                    },
                    error: function (response) {
                        //alert(response.d);
                    }
                });


            } // bind data

            function onSuccess(result) {
                var row = "";
                if (result.d.length >= 5) {
                    $('.dvContentlog').css('display', 'block');
                    $("#btnloadMore").css('display', 'block');
                }
                else {
                    // $('#dvactivitylog').css('display', 'none');
                    $("#btnloadMore").css('display', 'none');
                    $("#<%=lblNewsUpdate.ClientID%>").css('display', 'block');


                }
                for (var i = 0; i < result.d.length; i++) {
                    row += "<tr><td>" + result.d[i].PreviewHTML + "</td><td align='center' style='width: 26%;' >" + result.d[i].ModifiedDate + "</td></tr>";
                }
                $("#tbodyContent").append(row);
            }
            // ----------- End of Lite Dashboard Suggestions ---------

        });
    </script>
    <%--<script type="text/javascript">
        $(function () {
            $('img.image1').data('ad-desc', 'Whoa! This description is set through elm.data("ad-desc") instead of using the longdesc attribute.<br>And it contains <strong>H</strong>ow <strong>T</strong>o <strong>M</strong>eet <strong>L</strong>adies... <em>What?</em> That aint what HTML stands for? Man...');
            $('img.image1').data('ad-title', 'Title through $.data');
            $('img.image4').data('ad-desc', 'This image is wider than the wrapper, so it has been scaled down');
            $('img.image5').data('ad-desc', 'This image is higher than the wrapper, so it has been scaled down');
            var galleries = $('.ad-gallery').adGallery();

            $('#switch-effect').change(
                function () {
                    galleries[0].settings.effect = $(this).val();
                    return false;
                });
            $('#toggle-slideshow').click(
                function () {
                    galleries[0].slideshow.toggle();
                    return false;
                });
            $('#toggle-description').click(
                function () {
                    if (!galleries[0].settings.description_wrapper) {
                        galleries[0].settings.description_wrapper = $('#descriptions');
                    } else {
                        galleries[0].settings.description_wrapper = false;
                    }
                    return false;
                });
        });
    </script>--%>
    <%--Custom Module Installations Popups --%>
    <script src="../../Scripts/jquery.contentcarousel.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.easing.1.3.js" type="text/javascript"></script>
    <link href="../../css/jquery.jscrollpane.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../../css/pop-up.css" rel="stylesheet" type="text/css" />
    <%-- <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.6.1/jquery.min.js"></script>--%>
    <style type="text/css">
        .btnmore
        {
            background-color: #d2ddeb;
            border: none;
            color: #151414;
            padding: 4px 5px;
            text-align: center;
            text-decoration: none;
            font-size: 16px;
            border-radius: 3px;
            cursor: pointer;
            margin-top: 3px;
            margin-left: 268;
        }
        .appvisible
        {
        }
        .appnotvisible
        {
            color: Red;
        }
        .versions ul
        {
            line-height: 20px;
        }
        .bgimg
        {
            background-image: url(../../images/Dashboard/v5ip2guo.png);
            background-repeat: no-repeat;
            width: 222px;
            height: 74px;
            text-align: center;
            line-height: 35px;
        }
        /*.QuicklinksNamesStyle
        {
            font-size: 12px;
            color: Black;
            font-family: Arial, Helvetica, sans-serif;
            text-align: center;
        }*/
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
        #flip
        {
            text-align: center;
            cursor: pointer;
        }
        .style1
        {
            width: 213px;
        }
        .button-link
        {
            padding: 10px 15px;
            background: #4479BA;
            color: #FFF;
            text-decoration: none; /* border: solid 1px #20538D;
           -webkit-border-radius: 4px;
            -moz-border-radius: 4px;
            border-radius: 4px;text-shadow: 0 -1px 0 rgba(0, 0, 0, 0.4);
            -webkit-box-shadow: inset 0 1px 0 rgba(255, 255, 255, 0.4), 0 1px 1px rgba(0, 0, 0, 0.2);
            -moz-box-shadow: inset 0 1px 0 rgba(255, 255, 255, 0.4), 0 1px 1px rgba(0, 0, 0, 0.2);
            box-shadow: inset 0 1px 0 rgba(255, 255, 255, 0.4), 0 1px 1px rgba(0, 0, 0, 0.2);*/
        }
        div.parent
        {
            display: table;
            width: 100%;
        }
        div.text
        {
            vertical-align: middle;
            display: table-cell;
            text-align: justify;
            padding-left: 7px;
        }
        div.parent .img
        {
            vertical-align: middle;
            display: table-cell;
            padding-right: 5px;
        }
        div.img img
        {
            vertical-align: middle;
        }
        #tblpreview
        {
            width: 100%;
            margin: 5px;
        }
        #tblActaivityLog tr:nth-child(even)
        {
            background-color: #d2ddeb;
        }
        #tblActaivityLog td
        {
            padding: 5px;
        }
        .txtcss
        {
            width: 250px;
            height: 25px;
            line-height: 25px;
            border: solid 1px #bcc8d3;
            padding: 2px;
            font-size: 13px;
            color: #666;
            border-radius: 5px;
            margin-top: 3px;
            font-weight: bold;
        }
        .btn
        {
            height: 27px;
            border: 1px solid #dcdcdc;
            margin: 0px 6px 0px 0px;
            cursor: hand;
            cursor: pointer;
            padding: 0px 20px;
            font-size: 16px;
        }
        .submit-text
        {
            margin: 10px 0px;
            font-size: 14px;
            display: block;
        }
        .submit-text span
        {
            font-weight: 500;
            color: #459511;
        }
        .app-launch button
        {
            background: none;
            border: none;
        }
        .app-launch .submit
        {
            background: #4f84d9;
            border-radius: 3px;
            padding: 10px 20px;
            color: #FFFFFF;
            cursor: pointer;
            font-size: 14px;
            font-weight: 600;
            transition: all .2s ease-in-out;
            text-decoration: none;
            margin-top: 10px;
        }
        .app-launch .submit:hover
        {
            background: #525252;
        }
        @media (max-width:640px)
        {
            .app-launch
            {
                width: 100%;
                padding: 15px;
                margin-top: 5px;
            }
        }
    </style>
    <div id="leftcol">
        <!--&& CheckDescription == true-->
        <%if (CheckProfile == true && CheckAppSettings == true)
          { %>
        <div id="topquicklinks">
            <div id="quicklinks">
                <%--<div class="quicklinks_txt">
                Quick Links
            </div>--%>
                <div>
                    <div id="gallery" class="ad-gallery">
                        <div class="ad-nav" style="width: 723px;">
                            <div class="ad-thumbs">
                                <ul class="ad-thumb-list" id="dashboardIcons" runat="server">
                                    <asp:Literal ID="ltrlAdditems" runat="server"></asp:Literal>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="quicklinks1">
                    <span style="font-size: 12px; padding-left: 20px; color: Green;">Red titles indicate
                        which buttons are currently turned off on the App.</span>
                </div>
            </div>
        </div>
        <%} %>
        <%if (Session["IsSponsor"] == null)
          { %>
        <!--Getting Started starts-->
        <%if (CheckProfile == false || CheckDescription == false || CheckAppSettings == false || Session["DashboardFlow"] != null)
          { %>
        <div id="box">
            <div class="headingbar">
                <div class="heading">
                    Getting Started</div>
                <div class="box-actions">
                    <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/boxhead-divider.png")%>" width="1"
                        height="25" alt="divider">&nbsp;<a href="javascript:void(0);" onclick="toggle_visibility('divGettingStarted');"><img
                            src="<%=Page.ResolveClientUrl("~/images/Dashboard/maximise1.png")%>" alt="max"></a>
                </div>
            </div>
            <div id="divGettingStarted">
                <div class="midbg">
                    <div class="rowbg">
                        <div class="icon">
                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/flow1.png")%>" alt="icon" /></div>
                        <%if (CheckProfile == false)
                          { %>
                        Create your
                        <%=VerticalType %>'s information<span class="ul_span"> <a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/ModifyProfileDetails.aspx?Check=1")%>">
                            Click here</a></span>
                        <%}
                          else
                          { %>
                        <span style="color: Green;">You have updated your
                            <%=VerticalType %>'s information.</span>
                        <%} %>
                    </div>
                    <%--<div class="rowbg">
                        <div class="icon">
                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/flow2.png")%>" alt="icon" />
                        </div>
                        <%if (CheckDescription == false)
                          { %>
                        Create your
                        <%=VerticalType%>'s description <span class="ul_span">
                            <%if (CheckProfile == true)
                              { %>
                            <a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/ProfileDescription.aspx?Check=1")%>">
                                Click here</a><%}
                              else
                              { %>
                            <a href="javascript:alert('Please make sure to complete step 1 before you proceed.');">
                                Click here</a>
                            <%} %></span>
                        <%}
                          else
                          { %>
                        <span style="color: Green;">You have updated your
                            <%=VerticalType%>'s description.</span>
                        <%} %>
                    </div>--%>
                    <div class="rowbg">
                        <div class="icon">
                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/flow2.png")%>" alt="icon" />
                        </div>
                        <%if (CheckAppSettings == false)
                          { %>
                        Choose the features to display on the App <span class="ul_span2">
                            <%if (CheckProfile == true && CheckDescription == true)
                              { %>
                            <a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/MobileAppSettings.aspx?Check=1")%>">
                                Click here</a><%}
                              else
                              { %>
                            <a href="javascript:alert('Please make sure to complete steps 1 before you proceed.');">
                                Click here</a>
                            <%} %></span>
                        <%}
                          else
                          { %>
                        <span style="color: Green;">You have configured the features to display on the App.
                            Congratulations! You are all set now.</span>
                        <%} %>
                    </div>
                    <%if (Session["DashboardFlow"] != null)
                      {
                          Session["DashboardFlow"] = null; %>
                    <div class="rowbg">
                        <div class="icon">
                            <%--   <%if (GettingIsDescription)
                              { %>
                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/flow4.png")%>" alt="icon" /><%}
                              else
                              { %>
                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/flow3.png")%>" alt="icon" />
                            <%} %>--%>
                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/flow3.png")%>" alt="icon" />
                        </div>
                        <span style="color: green;">Your system is now ready to use<%--; to
                            begin <a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/ManageAppButtons.aspx")%>">
                                Click here</a> class="spancontent"--%>.</span>
                        <%--<img src="<%=Page.ResolveClientUrl("~/images/Dashboard/settings.png")%>" class="image6" />
                        <span class="spancontent" style="color: green;">above.</span>--%>
                    </div>
                    <%} %>
                </div>
                <div class="bottom">
                </div>
            </div>
        </div>
        <%} %>
        <%} %>
        <!--Getting Started ends-->
        <!--box starts-->
        <%if (Session["IsSponsor"] == null)
          { %>
        <div id="box">
            <div class="headingbar">
                <div class="heading">
                    Account Notifications &nbsp;&nbsp;<a id="ViewMessagesTips" href="javascript:ModalHelpPopup('Account Notifications',134,'');"><img
                        src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" /></a></div>
                <div class="box-actions">
                    <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/boxhead-divider.png")%>" width="1"
                        height="25" alt="divider">&nbsp;<a href="javascript:void(0);" onclick="toggle_visibility('divNotify');"><img
                            src="<%=Page.ResolveClientUrl("~/images/Dashboard/maximise1.png")%>" alt="max"></a>
                </div>
            </div>
            <div id="divNotify">
                <div class="midbg">
                    <%--<div class="rowbg">
                        <div class="icon">
                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/star.png")%>" width="23" height="22"
                                alt="icon"></div>
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:Label ID="lblAlert" runat="server" Style="vertical-align: top;" Text="A new design version for your App is in the process of being submitted to the app stores and should be available in approximately two weeks. You will still be able to use the current version during this transition.  We will notify you when your App has been approved."></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>--%>
                    <div class="rowbg">
                        <div class="icon">
                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/star.png")%>" width="23" height="22"
                                alt="icon"></div>
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    What's new - 2.8.1 Release, <a href="javascript:void(0);" onclick="ShowVersionPopupModal();"
                                        style="color: Red;">Click here</a>.
                                </td>
                            </tr>
                        </table>
                    </div>
                    <% if (NotificationAlert != "")
                       { %>
                    <%if (FreetrialRemainingdays != 0)
                      { %>
                    <div class="rowbg">
                        <div class="icon">
                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/star.png")%>" width="23" height="22"
                                alt="icon"></div>
                        <asp:Label ID="lblremainingdays" runat="server" Style="vertical-align: top;"></asp:Label>
                    </div>
                    <%} %>
                    <%if (ExpDaysalert != "")
                      { %>
                    <div class="rowbg">
                        <div class="icon">
                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/star.png")%>" width="23" height="22"
                                alt="icon"></div>
                        <asp:Label ID="lblrenew" runat="server" Style="vertical-align: top;"></asp:Label>
                    </div>
                    <%} %>
                    <%if (CCExpDaysalert != "")
                      { %>
                    <div class="rowbg">
                        <div class="icon">
                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/star.png")%>" width="23" height="22"
                                alt="icon"></div>
                        <asp:Label ID="lblccexpdate" runat="server"></asp:Label>
                    </div>
                    <%} %>
                    <% if (FreeFlag != 0)
                       { %>
                    <div class="rowbg">
                        <div class="icon">
                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/star.png")%>" width="23" height="22"
                                alt="icon"></div>
                        <asp:Label ID="lblfreealert" runat="server" Style="vertical-align: top;"></asp:Label>
                    </div>
                    <%} %>
                    <%if (lblalerts.Text != "0")
                      { %>
                    <div class="rowbg">
                        <div class="icon">
                            <img src="<%=Page.ResolveClientUrl("~/images/NewDashboard/star.png")%>" width="23"
                                height="22" alt="icon"></div>
                        You have <a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/Alerts.aspx")%>">
                            <asp:Label ID="lblalerts" runat="server"></asp:Label></a> <a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/Alerts.aspx")%>">
                                Notification(s)</a>
                    </div>
                    <%} %>
                    <%if (lblmobilenewsletter.Text != "0")
                      { %>
                    <div class="rowbg">
                        <div class="icon">
                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/star.png")%>" width="23" height="22"
                                alt="icon"></div>
                        You have <a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/MobileAppAlerts.aspx")%>">
                            <asp:Label ID="lblmobilenewsletter" runat="server"></asp:Label></a> <a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/MobileAppAlerts.aspx")%>">
                                App Message(s)</a>
                    </div>
                    <%}%>
                    <%if (lblmobiletips.Text != "0")
                      { %>
                    <div class="rowbg">
                        <div class="icon">
                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/star.png")%>" width="23" height="22"
                                alt="icon"></div>
                        You have <a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/MobileAppAlerts.aspx")%>">
                            <asp:Label ID="lblmobiletips" runat="server"></asp:Label></a> <a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/MobileAppAlerts.aspx")%>">
                                App Tip(s)</a>
                    </div>
                    <%}%>
                    <%if (lblEmailContacts.Text != "0")
                      { %>
                    <div class="rowbg">
                        <div class="icon">
                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/star.png")%>" width="23" height="22"
                                alt="icon"></div>
                        You have <a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/InquiryAlerts.aspx")%>">
                            <asp:Label ID="lblEmailContacts" runat="server"></asp:Label></a> <a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/InquiryAlerts.aspx")%>">
                                New Email Messages</a>
                    </div>
                    <%} %>
                    <%if (lblPublicCallAlert.Text != "0")
                      { %>
                    <div class="rowbg">
                        <div class="icon">
                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/star.png")%>" width="23" height="22"
                                alt="icon"></div>
                        You have <a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/SmartConnectMessage.aspx?message=1")%>">
                            <asp:Label ID="lblPublicCallAlert" runat="server"></asp:Label></a> <a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/SmartConnectMessage.aspx?message=1")%>">
                                New SmartConnect Message(s)</a>
                    </div>
                    <%} %>
                    <%if (lblPrivateCallAlert.Text != "0")
                      { %>
                    <div class="rowbg">
                        <div class="icon">
                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/star.png")%>" width="23" height="22"
                                alt="icon"></div>
                        You have <a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/MobileAppAlerts.aspx")%>">
                            <asp:Label ID="lblPrivateCallAlert" runat="server"></asp:Label></a> <a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/MobileAppAlerts.aspx")%>">
                                New Private Call Message(s)</a>
                    </div>
                    <%} %>
                        <%if (lblPSCMessagesCount.Text != "0")
                      { %>
                    <div class="rowbg">
                        <div class="icon">
                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/star.png")%>" width="23" height="22"
                                alt="icon"></div>
                        You have <a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/PrivateSmartConnectMessages.aspx?message=1")%>">
                            <asp:Label ID="lblPSCMessagesCount" runat="server"></asp:Label></a> <a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/PrivateSmartConnectMessages.aspx?message=1")%>">
                                New Private QR Connect Message(s)</a>
                    </div>
                    <%} %>
                    <%if (lblMasterGalMemory.Text != "")
                      { %>
                    <div class="rowbg" style="display: none;">
                        <div class="icon">
                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/star.png")%>" width="23" height="22"
                                alt="icon"></div>
                        Your master library has occupied
                        <asp:Label ID="lblMasterGalMemory" runat="server"></asp:Label>% of space of
                        <%=AllowedMemory %>
                        GB. <a href='<%=System.Configuration.ConfigurationManager.AppSettings["ShoppingCartRootPath"] %>/RedirectPage.aspx?MID=<%=MemID %>&MPID=<%=MemPID %>&CID=<%=CID %>&VC=<%=DomainNameenc %>&ReqType=3'>
                            Click here</a> to buy more space.
                    </div>
                    <%} %>
                    <%}
                       else
                       {%>
                    <%--Currently you have no notifications.--%>
                    <%} %>
                    <asp:Label runat="server" ID="lblSubAppInvitation"></asp:Label>
                </div>
                <div class="bottom">
                </div>
            </div>
        </div>
        <%-- <% if (Session["IsLiteVersion"].ToString().ToLower() == "true")
           { %>--%>
        <div id="box" class="dvContentlog">
            <div class="headingbar">
                <div class="heading">
                    News & Updates &nbsp;&nbsp;<%--<a id="A2" href="javascript:ModalHelpPopup('Account Notifications',134,'');"><img
                        src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" /></a></div>--%>
                </div>
                <div class="box-actions">
                    <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/boxhead-divider.png")%>" width="1"
                        height="25" alt="divider">&nbsp;<a href="javascript:void(0);" onclick="toggle_visibility('dvactivitylog');"><img
                            src="<%=Page.ResolveClientUrl("~/images/Dashboard/maximise1.png")%>" alt="max"></a>
                </div>
            </div>
            <div id="dvactivitylog">
                <div class="midbg">
                    <div class="">
                        <table id="tblActaivityLog" class="rowbg" style="width: 100%; border-collapse: collapse;">
                            <%--<thead>
                                <tr>
                                    <th>
                                        Title
                                    </th>
                                    <th>
                                        preview HTML
                                    </th>
                                </tr>
                            </thead>--%>
                            <tbody id="tbodyContent">
                            </tbody>
                        </table>
                        <div align="center">
                            <input type="button" id="btnloadMore" value="View More" class="btnmore" style="display: none;" />
                            <asp:Label ID="lblNewsUpdate" runat="server" Text="No more updates available." Font-Size="14px"
                                ForeColor="green" Style="display: none"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="bottom">
                </div>
            </div>
        </div>
        <%--     <%} %>--%>
        <!--box ends-->
        <div class="clear">
        </div>
        <%} %>
        <!--  <div id="box">
            <div class="headingbar">
                <div class="heading">
                    App Download Statistics
                </div>
                <div class="box-actions">
                    <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/boxhead-divider.png")%>" width="1"
                        height="25" alt="divider">&nbsp;<a href="javascript:void(0);" onclick="toggle_visibility('divAppDownloads');"><img
                            src="<%=Page.ResolveClientUrl("~/images/Dashboard/maximise.png")%>" width="9"
                            height="7" alt="max"></a>
                </div>
            </div>
            <div id="divAppDownloads">
                <div class="midbg">
                    <br />
                    <asp:Label ID="lblTotalCount" ForeColor="Black" runat="server"></asp:Label>
                    <center>
                        <asp:Chart ID="chartAppUsage" runat="server" Width="300px" Height="200px">
                            <Titles>
                                <asp:Title ShadowOffset="30" />
                            </Titles>
                            <Legends>
                                <asp:Legend Font="Microsoft Sans Serif, 10pt" Alignment="Center" Docking="Right"
                                    LegendStyle="Column">
                                </asp:Legend>
                            </Legends>
                            <Series>
                                <asp:Series IsVisibleInLegend="true" Name="Legend" ChartType="Pie" IsValueShownAsLabel="true"
                                    Font="Microsoft Sans Serif, 10pt" LabelForeColor="#FFFFFF">
                                </asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="UsageChartArea" BackColor="white">
                                </asp:ChartArea>
                            </ChartAreas>
                        </asp:Chart>
                    </center>
                </div>
                <div class="bottom">
                </div>
            </div>
        </div>
        <div class="clear">
        </div>-->
    </div>
    <div id="rightcol">
        <div class="bgimg">
            <asp:Label ID="lblDate" runat="server" ForeColor="white" Font-Size="Medium"></asp:Label><br />
            <asp:Label ID="lblTime" runat="server" ForeColor="White" Font-Size="Medium"></asp:Label>
            <%if (Session["IsSponsor"] == null)
              { %>
            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/downarrow.png")%>" border="0"
                id="imgSlideZones" />
            <div class="slidedown" align="center">
                <span>Select Your Time Zone:</span>
                <asp:DropDownList ID="ddlTimeZones" runat="server" CssClass="dropdown">
                </asp:DropDownList>
                <br />
                <input type="button" id="Button1" value="Submit" onclick="SaveZone();" />
            </div>
            <%} %>
        </div>
        <br />
        <div id="howto">
            <table border="0" width="221px">
                <colgroup>
                    <col width="170px" />
                    <col width="*" />
                </colgroup>
                <tr>
                    <td style="color: #E18A07;" colspan="2">
                        <a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/HowToVideos.aspx")%>" style="color: #787878;
                            font-weight: bold; text-decoration: none;">
                            <div class="parent" style="font-size: 16px; font-weight: bold;">
                                <div class="text" style="padding: 0px; padding-right: 20px;">
                                    How To Videos</div>
                                <div class="img">
                                    <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/videoicon.png")%>" /></div>
                            </div>
                        </a>
                    </td>
                    <%--<td>
                        <div style="float: right; margin-right: 20px; margin-top: 7px;" id="divShowMore">
                            <a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/HowToVideos.aspx")%>" style="color: Green;
                                font-weight: bold; text-decoration: none;">
                                <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/icon-download.png")%>" title="Show Videos" /></a>
                        </div>
                        <div style="float: right; margin-right: 20px; margin-top: 7px; display: none;" id="divHideMore">
                            <a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/HowToVideos.aspx")%>" style="color: Green;
                                font-weight: bold; text-decoration: none;">
                                <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/bended-arrow-up.png")%>" title="Hide Videos" /></a>
                        </div>
                    </td>--%>
                </tr>
                <%--<tr>
                    <td>
                        Dashboard and Features
                    </td>
                    <td>
                        <a href="javascript:void(0)" onclick="ShowVideoPopup(1)" title="Dashboard and Features">
                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/videoicon.png")%>" /></a>
                    </td>
                </tr>--%>
                <%--<tr>
                    <td colspan="2">
                        <div id="divShowVideos" style="display: none; margin-left: -3px;">
                            <table>
                                <colgroup>
                                    <col width="170px" />
                                    <col width="*" />
                                </colgroup>
                                <tr>
                                    <td>
                                        Getting Started
                                    </td>
                                    <td>
                                        <a href="javascript:void(0)" onclick="ShowVideoPopup(115029786)" title="Getting Started">
                                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/videoicon.png")%>" /></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        What's Next
                                    </td>
                                    <td>
                                        <a href="javascript:void(0)" onclick="ShowVideoPopup(115029788)" title="What's Next">
                                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/videoicon.png")%>" /></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Rename a Title
                                    </td>
                                    <td>
                                        <a href="javascript:void(0)" onclick="ShowVideoPopup(119144922)" title="Rename a Title">
                                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/videoicon.png")%>" /></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Schedule Push Notification
                                    </td>
                                    <td>
                                        <a href="javascript:void(0)" onclick="ShowVideoPopup(119144924)" title="Schedule Push Notification">
                                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/videoicon.png")%>" /></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Setup Facebook Auto Share
                                    </td>
                                    <td>
                                        <a href="javascript:void(0)" onclick="ShowVideoPopup(119144923)" title="Setup Facebook Auto Share">
                                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/videoicon.png")%>" /></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Setup Twitter Auto Share
                                    </td>
                                    <td>
                                        <a href="javascript:void(0)" onclick="ShowVideoPopup(119144921)" title="Setup Twitter Auto Share">
                                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/videoicon.png")%>" /></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Push Notification
                                    </td>
                                    <td>
                                        <a href="javascript:void(0)" onclick="ShowVideoPopup(115195598)" title="Push Notification">
                                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/videoicon.png")%>" /></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Item as Push Notification
                                    </td>
                                    <td>
                                        <a href="javascript:void(0)" onclick="ShowVideoPopup(115029787)" title="Item as Push Notification">
                                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/videoicon.png")%>" /></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Move Template Blocks
                                    </td>
                                    <td>
                                        <a href="javascript:void(0)" onclick="ShowVideoPopup(109352916)" title="Move Template Blocks">
                                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/videoicon.png")%>" /></a>
                                    </td>
                                </tr>
                                <%if (DomainName.ToLower().Contains("uspdhub") || DomainName.ToLower().Contains("localhost"))
                                  { %>
                                <tr>
                                    <td>
                                        Remove Template
                                    </td>
                                    <td>
                                        <a href="javascript:void(0)" onclick="ShowVideoPopup(109351962)" title="Remove Template">
                                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/videoicon.png")%>" /></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Move App Buttons
                                    </td>
                                    <td>
                                        <a href="javascript:void(0)" onclick="ShowVideoPopup(109351961)" title="Move App Buttons">
                                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/videoicon.png")%>" /></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Hide Button
                                    </td>
                                    <td>
                                        <a href="javascript:void(0)" onclick="ShowVideoPopup(109351846)" title="Hide Button">
                                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/videoicon.png")%>" /></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Change Button
                                    </td>
                                    <td>
                                        <a href="javascript:void(0)" onclick="ShowVideoPopup(109351842)" title="Change Button">
                                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/videoicon.png")%>" /></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        App Display Settings
                                    </td>
                                    <td>
                                        <a href="javascript:void(0)" onclick="ShowVideoPopup(109351840)" title="App Display Settings">
                                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/videoicon.png")%>" /></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Add Template
                                    </td>
                                    <td>
                                        <a href="javascript:void(0)" onclick="ShowVideoPopup(109351839)" title="Add Template">
                                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/videoicon.png")%>" /></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Add Content Module
                                    </td>
                                    <td>
                                        <a href="javascript:void(0)" onclick="ShowVideoPopup(109351752)" title="Add Content Module">
                                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/videoicon.png")%>" /></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Press Release
                                    </td>
                                    <td>
                                        <a href="javascript:void(0)" onclick="ShowVideoPopup(97152731)" title="Press Release">
                                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/videoicon.png")%>" />
                                        </a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Traffic Alert
                                    </td>
                                    <td>
                                        <a href="javascript:void(0)" onclick="ShowVideoPopup(97152732)" title="Traffic Alert">
                                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/videoicon.png")%>" /></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Wanted Bulletin
                                    </td>
                                    <td>
                                        <a href="javascript:void(0)" onclick="ShowVideoPopup(97152734)" title="Wanted Bulletin">
                                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/videoicon.png")%>" /></a>
                                    </td>
                                </tr>
                                <%}
                                  else
                                  { %>
                                <tr>
                                    <td>
                                        Move App Buttons
                                    </td>
                                    <td>
                                        <a href="javascript:void(0)" onclick="ShowVideoPopup(109351961)" title="Move App Buttons">
                                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/videoicon.png")%>" /></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Hide Button
                                    </td>
                                    <td>
                                        <a href="javascript:void(0)" onclick="ShowVideoPopup(109351846)" title="Hide Button">
                                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/videoicon.png")%>" /></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Change Button
                                    </td>
                                    <td>
                                        <a href="javascript:void(0)" onclick="ShowVideoPopup(109351842)" title="Change Button">
                                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/videoicon.png")%>" /></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        App Display Settings
                                    </td>
                                    <td>
                                        <a href="javascript:void(0)" onclick="ShowVideoPopup(109351840)" title="App Display Settings">
                                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/videoicon.png")%>" /></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Add Content Module
                                    </td>
                                    <td>
                                        <a href="javascript:void(0)" onclick="ShowVideoPopup(109351752)" title="Add Content Module">
                                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/videoicon.png")%>" /></a>
                                    </td>
                                </tr>
                                <%} %>
                                <tr>
                                    <td>
                                        Add / Change App Background Image
                                    </td>
                                    <td>
                                        <a href="javascript:void(0)" onclick="ShowVideoPopup(133683007)" title="Add / Change App Background Image">
                                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/videoicon.png")%>" /></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Send Content via Email
                                    </td>
                                    <td>
                                        <a href="javascript:void(0)" onclick="ShowVideoPopup(133684475)" title="Send Content via Email">
                                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/videoicon.png")%>" /></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Import CSV File
                                    </td>
                                    <td>
                                        <a href="javascript:void(0)" onclick="ShowVideoPopup(133683304)" title="Import CSV File">
                                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/videoicon.png")%>" /></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Add Manual Contact
                                    </td>
                                    <td>
                                        <a href="javascript:void(0)" onclick="ShowVideoPopup(133683136)" title="Add Manual Contact">
                                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/videoicon.png")%>" /></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Create Contact Group
                                    </td>
                                    <td>
                                        <a href="javascript:void(0)" onclick="ShowVideoPopup(133683245)" title="Create Contact Group">
                                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/videoicon.png")%>" /></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Create a Survey
                                    </td>
                                    <td>
                                        <a href="javascript:void(0)" onclick="ShowVideoPopup(133683302)" title="Create a Survey">
                                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/videoicon.png")%>" /></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Create a Poll
                                    </td>
                                    <td>
                                        <a href="javascript:void(0)" onclick="ShowVideoPopup(133683301)" title="Create a Poll">
                                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/videoicon.png")%>" /></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Change Content Order on App
                                    </td>
                                    <td>
                                        <a href="javascript:void(0)" onclick="ShowVideoPopup(133683244)" title="Change Content Order on App">
                                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/videoicon.png")%>" /></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Block Sender
                                    </td>
                                    <td>
                                        <a href="javascript:void(0)" onclick="ShowVideoPopup(133683135)" title="Block Sender">
                                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/videoicon.png")%>" /></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Unblock Sender
                                    </td>
                                    <td>
                                        <a href="javascript:void(0)" onclick="ShowVideoPopup(133684474)" title="Unblock Sender">
                                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/videoicon.png")%>" /></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Manual Share to Facebook
                                    </td>
                                    <td>
                                        <a href="javascript:void(0)" onclick="ShowVideoPopup(133684404)" title="Manual Share to Facebook">
                                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/videoicon.png")%>" /></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Manual Share to Twitter
                                    </td>
                                    <td>
                                        <a href="javascript:void(0)" onclick="ShowVideoPopup(133684403)" title="Manual Share to Twitter">
                                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/videoicon.png")%>" /></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Survey Report
                                    </td>
                                    <td>
                                        <a href="javascript:void(0)" onclick="ShowVideoPopup(133684476)" title="Survey Report">
                                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/videoicon.png")%>" /></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Email Report
                                    </td>
                                    <td>
                                        <a href="javascript:void(0)" onclick="ShowVideoPopup(133684402)" title="Email Report">
                                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/videoicon.png")%>" /></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Associates And Permissions
                                    </td>
                                    <td>
                                        <a href="javascript:void(0)" onclick="ShowVideoPopup(134257229)" title="Associates And Permissions">
                                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/videoicon.png")%>" /></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Create Canned Messages
                                    </td>
                                    <td>
                                        <a href="javascript:void(0)" onclick="ShowVideoPopup(139755807)" title="Create Canned Messages">
                                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/videoicon.png")%>" /></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Add video to template
                                    </td>
                                    <td>
                                        <a href="javascript:void(0)" onclick="ShowVideoPopup(139755919)" title="Add video to template">
                                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/videoicon.png")%>" /></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Create banner ads
                                    </td>
                                    <td>
                                        <a href="javascript:void(0)" onclick="ShowVideoPopup(139755871)" title="Create banner ads">
                                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/videoicon.png")%>" /></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="padding-top: 10px; color: #E18A07;">
                                        <h3>
                                            Private Module</h3>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Add Private Module
                                    </td>
                                    <td>
                                        <a href="javascript:void(0)" onclick="ShowVideoPopup(127312868)" title="Add Private Module">
                                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/videoicon.png")%>" /></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Set Up Private Module Contacts
                                    </td>
                                    <td>
                                        <a href="javascript:void(0)" onclick="ShowVideoPopup(127313237)" title="Set Up Private Module Contacts">
                                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/videoicon.png")%>" /></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Send Private Module Invitations
                                    </td>
                                    <td>
                                        <a href="javascript:void(0)" onclick="ShowVideoPopup(127313238)" title="Send Private Module Invitations">
                                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/videoicon.png")%>" /></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        View Private Module Invitations
                                    </td>
                                    <td>
                                        <a href="javascript:void(0)" onclick="ShowVideoPopup(127313239)" title="View Private Module Invitations">
                                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/videoicon.png")%>" /></a>
                                    </td>
                                </tr>
                            </table>
                        </div>--%>
                <%--<div style="float: right; margin-right: 20px; margin-top: 7px;" id="divShowMore">
                            <a href="javascript:void(0);" onclick="toggle_Videos();" style="color: Green; font-weight: bold;
                                text-decoration: none;">Show More Videos
                                <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/icon-download.png")%>" /></a>
                        </div>
                        <div style="float: right; margin-right: 20px; margin-top: 7px; display: none;" id="divHideMore">
                            <a href="javascript:void(0);" onclick="toggle_Videos();" style="color: Green; font-weight: bold;
                                text-decoration: none;">Hide Videos
                                <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/bended-arrow-up.png")%>" /></a>
                        </div>--%>
                <%--</td>
                </tr>--%>
            </table>
        </div>
        <%if (IsAppStastics)
          { %>
        <div id="statistics" runat="server" style="background-color: #FFF; padding: 8px 0px 0px 1px;
            width: 99%; margin-top: 7px;">
            <table border="0">
                <tbody>
                    <tr>
                        <td>
                            <div id="flip" class="parent" style="font-size: 18px; font-weight: bold; color: #787878;">
                                <div class="text">
                                    App Statistics</div>
                                <div class="img" style="padding-left: 50px;">
                                    <img src="../../Images/appsstatistics.png" /></div>
                            </div>
                            <div id="divAppStats" style="margin-top: 10px; display: none;">
                                <div>
                                    <a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/AppUsageReports.aspx")%>"
                                        style="display: block; font-size: medium; border-bottom: solid 1px #20538D;"
                                        class="button-link">App Usage Report</a></div>
                                <div>
                                    <a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/AppOpenReports.aspx")%>"
                                        style="display: block; font-size: medium;" class="button-link">App Open Count
                                    </a>
                                </div>
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <%} %>
        <%if (Session["IsSponsor"] == null)
          { %>
        <%if (IsAdmin && CheckAppSettings == true && CheckDescription == true && CheckProfile == true)
          {
              if (!Convert.ToBoolean(Session["IsLiteVersion"]))
              {
        %>
        <div id="rightbox" style="padding: 8px 0px 0px 1px;">
            <a href='<%=System.Configuration.ConfigurationManager.AppSettings["ShoppingCartRootPath"] %>/RedirectStore.aspx?MID=<%=MemID %>&MPID=<%=MemPID %>&CID=<%=CID %>&VC=<%=DomainNameenc %>&PackID=<%=hdnPackageID.Value %>'>
                <img src="<%=Page.ResolveClientUrl("~/images/store/marketplace-icon.png")%>"></a>
        </div>
        <%if (ExpDaysalert == "1")
          { %>
        <div id="rightbox" style="padding: 8px 0px 0px 1px;">
            <a href='<%=System.Configuration.ConfigurationManager.AppSettings["ShoppingCartRootPath"] %>/RedirectStore.aspx?MID=<%=MemID %>&MPID=<%=MemPID %>&CID=<%=CID %>&VC=<%=DomainNameenc %>&type=renewal&PackID=<%=hdnPackageID.Value %>'>
                <img src="<%=Page.ResolveClientUrl("~/images/store/RenewalMarketplace.png")%>"></a>
        </div>
        <%} %>
        <%}
          } %>
        <%if (IsDownloadAccess)
          { %>
        <div id="rightbox" runat="server" style="padding: 8px 0px 0px 1px;">
            <a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/DownloadInstallers.aspx")%>">
                <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/downloads.png")%>"></a>
        </div>
        <%} %>
        <%if (IsCustomModulAccess && MobileApp && IsMobileApp)
          { %>
        <div id="div22" runat="server" style="padding: 8px 0px 0px 0px; width: 99%;">
            <div style="background-color: #FFF; padding: 10px; display: block; margin: auto;
                text-align: center;">
                <span style="font-size: 16px; color: #787878; font-weight: bold;">Install
                    <%=hdnAddOnName.Value %><br />
                    <br />
                </span><a href="javascript:OpenCustomModuleModalWindow('AddOns');">
                    <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/installcontent.gif")%>"></a></div>
        </div>
        <%} %>
        <%if (IsPrivateCustomModulAccess && MobileApp && IsMobileApp)
          { %>
        <div id="div1" runat="server" style="padding: 8px 0px 0px 0px; width: 99%;">
            <div style="background-color: #FFF; padding: 10px; display: block; margin: auto;
                text-align: center;">
                <span style="font-size: 16px; color: #787878; font-weight: bold;">Install
                    <%=hdnPrivateAddOnName.Value %><br />
                    <br />
                </span><a href="javascript:OpenCustomModuleModalWindow('PrivateAddOns');">
                    <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/installcontent.gif")%>"></a></div>
        </div>
        <%} %>
        <%if (IsPrivateCallAccess && MobileApp && IsMobileApp)
          { %>
        <div id="div5" runat="server" style="padding: 8px 0px 0px 0px; width: 99%;">
            <div style="background-color: #FFF; padding: 10px; display: block; margin: auto;
                text-align: center;">
                <span style="font-size: 16px; color: #787878; font-weight: bold;">Install
                    <%=hdnPrivateCallAddOnName.Value%><br />
                    <br />
                </span><a href="javascript:OpenCustomModuleModalWindow('PrivateCallAddOns');">
                    <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/installcontent.gif")%>"></a></div>
        </div>
        <%} %>
        <%if (IsPublicCallAccess && MobileApp && IsMobileApp)
          { %>
        <div id="div8" runat="server" style="padding: 8px 0px 0px 0px; width: 99%;">
            <div style="background-color: #FFF; padding: 10px; display: block; margin: auto;
                text-align: center;">
                <span style="font-size: 16px; color: #787878; font-weight: bold;">Install
                    <%=hdnPublicCallAddOnName.Value%><br />
                    <br />
                </span><a href="javascript:OpenCustomModuleModalWindow('PublicCallAddOns');">
                    <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/installcontent.gif")%>"></a></div>
        </div>
        <%} %>
         <%if (IsPrivateSmartConnectAccess && MobileApp && IsMobileApp)
          { %>
        <div id="div9" runat="server" style="padding: 8px 0px 0px 0px; width: 99%;">
            <div style="background-color: #FFF; padding: 10px; display: block; margin: auto;
                text-align: center;">
                <span style="font-size: 16px; color: #787878; font-weight: bold;">Install
                    <%=hdnPrivateSmartConnectAddOnsName.Value%><br />
                    <br />
                </span><a href="javascript:OpenCustomModuleModalWindow('PrivateSmartConnectAddOns');">
                    <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/installcontent.gif")%>"></a></div>
        </div>
        <%} %>
        <%if (IsCalendarAddOnsAccess && MobileApp && IsMobileApp)
          { %>
        <div id="div23" runat="server" style="padding: 8px 0px 0px 0px; width: 99%;">
            <div style="background-color: #FFF; padding: 10px; display: block; margin: auto;
                text-align: center;">
                <span style="font-size: 16px; color: #787878; font-weight: bold;">Install
                    <%=hdnCalendarAddOnName.Value %><br />
                    <br />
                </span><a href="javascript:OpenCalModuleModalWindow('CalendarAddOns');">
                    <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/installcontent.gif")%>"></a></div>
        </div>
        <%} %>
        <%if (IsBannerAdsAccess && MobileApp && IsMobileApp)
          { %>
        <div id="div3" runat="server" style="padding: 8px 0px 0px 0px; width: 99%;">
            <div style="background-color: #FFF; padding: 10px; display: block; margin: auto;
                text-align: center;">
                <span style="font-size: 16px; color: #787878; font-weight: bold;">Install
                    <%=hdnBannerAdsName.Value %><br />
                    <br />
                </span><a href="javascript:OpenBannerAdModuleModalWindow('BannerAds');">
                    <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/installcontent.gif")%>"></a></div>
        </div>
        <%} %>
        <%} //session checking %>
        <%--************************Written By Suneel Kumar Biyyapu**********************--%>
        <%--
        <br />
        <div id="searchCode" runat="server" style="padding: 8px 0px 10px 1px; background-color: #FFFFFF;
            width: 222px;">
            <asp:LinkButton ID="lnkSearchCode" runat="server" Style="text-decoration: none;" OnClientClick="return ShowAccessCodeDialog();"></asp:LinkButton>
        </div>
        --%>
        <%--*****************************************************************************--%>
        <%--   <div>
            <div id="div6" runat="server" style="padding: 8px 0px 0px 0px; width: 99%;">
                <div style="background-color: #FFF; display: block; margin: auto; text-align: center;">
                    <asp:ImageButton runat="server" ID="btnPremium" OnClick="btnPremium_Click" />
                </div>
            </div>
        </div>--%>
        <%if (Convert.ToBoolean(Session["IsLiteVersion"]) == true)
          { %>
        <div id="div6" runat="server" style="padding: 8px 0px 0px 0px; width: 99%;">
            <div style="background-color: #FFF; padding: 10px; display: block; margin: auto;
                text-align: center;">
                <span style="font-size: 16px; color: #787878; font-weight: bold;">Many more features
                    are available in our Premium subscription<br />
                    <br />
                </span>
                <asp:LinkButton ID="LinkButton1" runat="server" Text='<img src="/images/Dashboard/LearnMore.png"></a>'
                    OnClick="lnkPremium_OnClick"></asp:LinkButton>
            </div>
        </div>
        <%--<div>
            <div id="div7" runat="server" style="padding: 8px 0px 0px 0px; width: 99%;">
                <div style="background-color: #FFF; display: block; margin: auto; text-align: center;">
                    <asp:ImageButton runat="server" ID="btnBrandedeApp" OnClick="btnBrandedeApp_Click" />
                </div>
            </div>
        </div>--%>
        <div id="div7" runat="server" style="padding: 8px 0px 0px 0px; width: 99%;">
            <div style="background-color: #FFF; padding: 10px; display: block; margin: auto;
                text-align: center;">
                <span style="font-size: 16px; color: #787878; font-weight: bold;">Looking for a Branded
                    App with Your Name and Logo in App Stores?<br />
                    <br />
                </span>
                <asp:LinkButton ID="lnkBrandedApp" runat="server" Text='<img src="/images/Dashboard/LearnMore.png"></a>'
                    OnClick="lnkBrandedApp_OnClick"></asp:LinkButton>
            </div>
        </div>
        <%} %>
    </div>
    <table width="100%">
        <tr>
            <td>
                <asp:Label ID="lblpre" runat="server" visiable="false"></asp:Label>
                <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="lblpre"
                    PopupControlID="pnlpopup1" BackgroundCssClass="modal">
                </cc1:ModalPopupExtender>
                <asp:Panel Style="display: none" ID="pnlpopup1" runat="server" Width="100%">
                    <table style="background-color: White" cellspacing="0" cellpadding="0" width="450"
                        align="center" border="0">
                        <tbody>
                            <tr>
                                <td align="center">
                                    <asp:UpdateProgress ID="UpdateProgress7" runat="server" DisplayAfter="3">
                                        <ProgressTemplate>
                                            <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-right: 0px; padding-top: 0px" align="right">
                                    <a href="javascript:void(0);" onclick="CloseModal();">
                                        <img src="../../images/popup_close.gif" /></a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <iframe id="IframeVideoPopup" width="640" height="375" frameborder="0" webkitallowfullscreen
                                        mozallowfullscreen allowfullscreen></iframe>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        function ShowVideoPopup(url) {
            var Iframe = document.getElementById("IframeVideoPopup");
            if (parseInt(url) == 109175332) {
                if (document.getElementById("<%=hdnLaunchPlay.ClientID %>").value == "Yes") {
                    url = url + "?autoplay=1";
                    Iframe.src = "http://player.vimeo.com/video/" + url;
                    $find("<%=ModalPopupExtender2.ClientID %>").show();
                    UpdateLaunchPlay('Initial');
                }
            }
            else {
                if (parseInt(url) == 1) // 1 for first login video and how to video are same.
                    url = 109175332;
                Iframe.src = "http://player.vimeo.com/video/" + url;
                $find("<%=ModalPopupExtender2.ClientID %>").show();
            }
        }
        function ShowVersionPopupModal() {

            if (document.getElementById('divVersionShow').style.display == 'block')
                document.getElementById('divVersionShow').style.display = 'none';
            ShowVersionPopup();
        }
        function ShowVersionPopup() {
            $find("<%=ModalPopupExtenderFeatures.ClientID %>").show();
        }
        function CloseFeaturesModal() {
            $find("<%=ModalPopupExtenderFeatures.ClientID %>").hide();
            if (document.getElementById('<%=chkVersionShow.ClientID %>').checked)
                UpdateLaunchPlay('Version');
            document.getElementById('<%=chkVersionShow.ClientID %>').checked = false;
        }
        function CloseModal() {
            var Iframe = document.getElementById("IframeVideoPopup");
            Iframe.src = '';
            $find("<%=ModalPopupExtender2.ClientID %>").hide();
        }
        function UpdateLaunchPlay(playType) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                data: "{playType:'" + playType + "'}",
                url: "Default.aspx/UpdateLaunchPlay",
                dataType: "json",
                success: function (response) {
                    var response = response.d;
                }
            });
        }
    </script>
    <%--************************Written By Suneel Kumar Biyyapu**********************--%>
    <script type="text/javascript">
        var slidevalue = '';
        function Redirect(url) {
            window.location = url;
        }
        function DashboardSettings() {
            var settingValue = document.getElementById("<%=hdnsettings.ClientID %>").value;
            var modalDialog = $find("popupimage");
            modalDialog.show();
            document.getElementById("<%=chkContacts.ClientID %>").checked = Boolean.parse(settingValue.split(',')[0]);
            document.getElementById("<%=chkUpdates.ClientID %>").checked = Boolean.parse(settingValue.split(',')[1]);
            document.getElementById("<%=chkEventCalendar.ClientID %>").checked = Boolean.parse(settingValue.split(',')[2]);
            document.getElementById("<%=chkMedia.ClientID %>").checked = Boolean.parse(settingValue.split(',')[3]);
            document.getElementById("<%=chkMobileApp.ClientID %>").checked = Boolean.parse(settingValue.split(',')[4]);
            document.getElementById("<%=chkBulletins.ClientID %>").checked = Boolean.parse(settingValue.split(',')[5]);
        }

        function HidePopup() {
            var modalDialog = $find("popupimage");
            modalDialog.hide();
            return false;
        }
        $(document).ready(function () {
            $("#imgSlideZones").click(function () {
                if (slidevalue == '') {
                    $('.slidedown').slideDown('slow', 'swing')
                    slidevalue = '1';
                }
                else {
                    $('.slidedown').slideUp('slow', 'swing')
                    slidevalue = '';
                }
            });
        });
        function SaveZone() {
            $('.slidedown').slideUp('slow', 'swing')
            slidevalue = '';
            var timeZoneID = document.getElementById("<%=ddlTimeZones.ClientID%>").options[document.getElementById("<%=ddlTimeZones.ClientID%>").selectedIndex].value;
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                data: "{'selZoneID': '" + timeZoneID + "' }",
                url: "Default.aspx/GetProfileID",
                dataType: "json",
                success: function (response) {
                    document.getElementById("<%=hdnTimeZoneID.ClientID %>").value = response.d;
                    doSomething();
                }
            });
        }
    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Label ID="lblFeatures" runat="server" visiable="false"></asp:Label>
            <cc1:ModalPopupExtender ID="ModalPopupExtenderFeatures" runat="server" TargetControlID="lblFeatures"
                PopupControlID="pnlFeatures" BackgroundCssClass="modal">
            </cc1:ModalPopupExtender>
            <asp:Panel Style="display: none" ID="pnlFeatures" runat="server" Width="100%">
                <table style="background-color: White; padding: 20px; border-radius" cellspacing="0"
                    cellpadding="0" width="450" align="center" border="0">
                    <tbody>
                        <tr>
                            <td style="padding-right: 0px; padding-top: 0px" align="right">
                                <a href="javascript:void(0);" onclick="CloseFeaturesModal();">
                                    <img src="../../images/popup_close.gif" /></a>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold; font-size: 14px; padding-bottom: 10px; color: Orange;
                                padding-top: 10px" align="left">
                                What's new - 2.8.1 Release
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="overflow-y: auto; height: 350px; position: relative; width: auto; padding: 10px;
                                    border: 1px solid #FFCC00;" class="versions">
                                    <table border="0" width="100%" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="color: #40B8AF; font-size: 16px; font-weight: bold; padding-bottom: 10px;">
                                                Hub Management System
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-left: 10px;">
                                                <h3>
                                                    Enhancements:</h3>
                                                <ul>
                                                    <li>SmartConnect: Message Management – Included the ability to create and assign a Category
                                                        to SmartConnect Buttons for reporting purposes. Added message reports and filtering
                                                        feature (date to date search, category search, reference id search or text search).
                                                        Included the down export to Excel.</li>
                                                    <li>SmartConnect: Improvement to SmartConnect message reply</li>
                                                    <li>SmartConnect: Added ability to create notes and maintain a log. Included sending
                                                        notes via email.</li>
                                                    <li>SmartConnect messages, App messages and email messages are now on separate pages.</li>
                                                    <li>SmartConnect/Private Call Directory: Added default image library for SmartConnect
                                                        button icons.</li>
                                                    <li>App Messages: Improvement to message reply</li>
                                                    <li>App Messages: Added archive button</li>
                                                    <li>App Image Gallery: Added ascending and descending options for image sorting</li>
                                                    <li>How to Videos: Now display in separate window when playing.</li>
                                                    <li>Permissions page: Now displays SmartConnect in parenthesis when button name is renamed
                                                        for easy identification.</li>
                                                </ul>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-top: 15px; padding-left: 10px;">
                                                <h3>
                                                    Fixes:</h3>
                                                <ul>
                                                    <li>Youtube share link no longer cutting off URL when pasting.</li>
                                                    <li>Facebook Auto Share: Shortened link will no longer display error. (link was duplicating
                                                        shortened url displaying error)</li>
                                                </ul>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-top: 10px;">
                                <div id="divVersionShow" style="display: none;">
                                    <asp:CheckBox ID="chkVersionShow" runat="server" />&nbsp;<span style="font-weight: bold;
                                        font-size: 14px;">Don't show again</span>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="padding: 10px;">
                                <a class="versionbutton" href="javascript:void(0);" onclick="CloseFeaturesModal();">
                                    Close</a>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </asp:Panel>
            <asp:Label ID="lblnewsimage" runat="server"></asp:Label>
            <cc1:ModalPopupExtender ID="popnewsletterimage" runat="server" TargetControlID="lblnewsimage"
                PopupControlID="pnlnewsletterimage" BackgroundCssClass="modal" BehaviorID="popupimage"
                CancelControlID="imcloseimagepopup">
            </cc1:ModalPopupExtender>
            <asp:Panel ID="pnlnewsletterimage" runat="server" Style="display: none" Width="600px">
                <table cellpadding="0" cellspacing="0" width="80%" style="border: 1px solid #EEECEC;
                    background-color: #F8F6F6;">
                    <tbody>
                        <tr>
                            <td align="right" style="padding: 5px 10px 0px 10px;">
                                <asp:ImageButton ID="imcloseimagepopup" runat="server" ImageUrl="~/images/popup_close.gif" />
                            </td>
                        </tr>
                        <tr>
                            <td class="mid" style="padding: 10px;">
                                <div class="pageheading">
                                    Dashboard Settings
                                </div>
                                <br>
                                <div style="text-align: center;">
                                    <asp:UpdateProgress ID="UpdateProgress2" runat="server" DisplayAfter="1">
                                        <ProgressTemplate>
                                            <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b></ProgressTemplate>
                                    </asp:UpdateProgress>
                                    <asp:Label ID="lblsuccess" runat="server"></asp:Label>
                                    <asp:HiddenField ID="SettingsId" runat="server"></asp:HiddenField>
                                </div>
                                <br />
                                By default all the tool icons you have purchased will be displayed on your Dashboard.
                                <br>
                                To remove icons from the Dashboard uncheck the boxes.<br>
                                <br>
                                <div style="width: 720px; float: left;">
                                    <div style="float: left;">
                                        <span class="checkbox">
                                            <asp:CheckBox ID="chkContacts" Checked="true" runat="server" /></span></div>
                                    <div style="float: left;" class="long">
                                        <span class="checkboxapp">
                                            <asp:CheckBox ID="chkBulletins" Checked="true" runat="server" /></span></div>
                                    <div style="float: left;" class="long">
                                        <span class="checkboxapp">
                                            <asp:CheckBox ID="chkMobileApp" Checked="true" runat="server" /></span></div>
                                    <div style="float: left;">
                                        <span class="checkbox">
                                            <asp:CheckBox ID="chkMedia" Checked="true" runat="server" /></span></div>
                                    <div style="float: left;" class="long">
                                        <span class="checkboxapp">
                                            <asp:CheckBox ID="chkEventCalendar" Checked="true" runat="server" /></span></div>
                                    <div style="float: left;">
                                        <span class="checkbox">
                                            <asp:CheckBox ID="chkUpdates" Checked="true" runat="server" /></span></div>
                                </div>
                                <br />
                                <div style="margin-top: 20px; float: right;">
                                    <asp:ImageButton ID="btnCancel" runat="server" ImageUrl="~/images/Dashboard/Cancel.png"
                                        OnClientClick="return  HidePopup();" />&nbsp;<asp:ImageButton ID="btnSubmit" runat="server"
                                            ImageUrl="~/images/Dashboard/Update.png" OnClick="btnSubmit_Click" />
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </asp:Panel>
            <asp:LinkButton ID='lnkUpdateCredicard' runat='server' Text='Click Here' ForeColor='Blue'
                OnClick='lnkUpdateCredicard_OnClick' Style="display: none"></asp:LinkButton>
            <table border="0" width="50%" cellpadding="0" cellspacing="0">
                <tr>
                    <td valign="top">
                        <asp:Label ID="lblpre5" runat="server"></asp:Label>
                        <cc1:ModalPopupExtender ID="CCDetailsModalPopup" runat="server" TargetControlID="lblpre5"
                            PopupControlID="pnlpopup5" BackgroundCssClass="modal">
                        </cc1:ModalPopupExtender>
                        <asp:Panel ID="pnlpopup5" runat="server" Width="50%" Style="display: none;">
                            <table class="inputgrid nomargin-bottom">
                                <tr>
                                    <td align="right" style="padding: 5px 10px 0px 10px;">
                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="../../images/popup_close.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:UpdateProgress ID="UpdateProgress5" runat="server" DisplayAfter="3">
                                            <ProgressTemplate>
                                                <img src="../../images/popup_ajax-loader.gif" border="0"><span class="processing">Processing....</span>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </td>
                                </tr>
                                <tr>
                                    <td id='tds' runat="server">
                                        <uc2:CCDetails ID="CCDetails1" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
            <table border="0" width="50%" cellpadding="0" cellspacing="0">
                <tr>
                    <td valign="top">
                        <asp:Label ID="lblCustomModule" runat="server"></asp:Label>
                        <cc1:ModalPopupExtender ID="ModalCustomModule" runat="server" TargetControlID="lblCustomModule"
                            PopupControlID="pnlCustomModule" BackgroundCssClass="modal">
                        </cc1:ModalPopupExtender>
                        <asp:Panel ID="pnlCustomModule" runat="server" Width="50%" Style="display: none;">
                            <table>
                                <tr>
                                    <td>
                                        <div id='divCustomTemplatePopupStep1'>
                                            <div id="popup-cont">
                                                <div class="top">
                                                    <a href="javascript:HideCustomModuleModalWindow();"></a>
                                                </div>
                                                <div class="middle">
                                                    <asp:Panel ID="pnlTemplates" runat="server" Style="display: none;">
                                                        <h1>
                                                            Install and configure
                                                            <%=hdnAddOnName.Value %>
                                                            - step 1</h1>
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
                                                            <asp:Label ID="lblAddOnName" runat="server"></asp:Label>
                                                            - step 1</h1>
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
                                                        <asp:LinkButton ID="lnkNext" runat="server" class="btn" Text="Submit" OnClientClick="return OpenCustomModulePopup3()"
                                                            OnClick="lnkNext_Click"></asp:LinkButton>
                                                    </asp:Panel>
                                                    <asp:Panel ID="pnlProgress" runat="server" Style="display: none;">
                                                        <h1>
                                                            Install and configure
                                                            <asp:Label ID="lblAddOnNamePro" runat="server"></asp:Label></h1>
                                                        <div class="scrollablebox" style="color: White; width: 100%;" align="center">
                                                            <h3>
                                                                Installation in progress. Please wait...</h3>
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
                                                        <a href="javascript:HideCustomModuleModalWindow();" class="btn" id="A1">Close</a>
                                                    </asp:Panel>
                                                </div>
                                                <div class="bottom">
                                                </div>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
            <table border="0" width="50%" cellpadding="0" cellspacing="0">
                <tr>
                    <td valign="top">
                        <asp:Label ID="lblCalendorAddons" runat="server"></asp:Label>
                        <cc1:ModalPopupExtender ID="ModalCalendorAddons" runat="server" TargetControlID="lblCalendorAddons"
                            PopupControlID="pnlCalendorAddons" BackgroundCssClass="modal">
                        </cc1:ModalPopupExtender>
                        <asp:Panel ID="pnlCalendorAddons" runat="server" Width="50%" Style="display: none;">
                            <table>
                                <tr>
                                    <td>
                                        <div id='div2'>
                                            <div id="popup-cont">
                                                <div class="top">
                                                    <a href="javascript:HideCalendorModuleModal();"></a>
                                                </div>
                                                <div class="middle">
                                                    <asp:Panel ID="pnlCalNameTab" runat="server">
                                                        <h1>
                                                            Install and configure
                                                            <%=hdnCalendarAddOnName.Value%>
                                                            - step 1</h1>
                                                        <h2 class="lft">
                                                            1. App Button name</h2>
                                                        <asp:TextBox ID="txtCalTabName" runat="server" onkeypress="return isNumberKey(event);"
                                                            onkeydown="return Maxlength(this);" MaxLength="13" class="txt-input"></asp:TextBox>
                                                        <h2>
                                                            2. App Button Icon (Select any one from the below list)</h2>
                                                        <div class="scrollablebox">
                                                            <div class="auto" id="divCalAppIcons">
                                                            </div>
                                                        </div>
                                                        <asp:LinkButton ID="lnkAddCalendar" runat="server" class="btn" Text="Submit" OnClientClick="return OpenCustomModulePopup3()"
                                                            OnClick="lnkAddCalendar_Click"></asp:LinkButton>
                                                    </asp:Panel>
                                                    <asp:Panel ID="pnlCalProgress" runat="server" Style="display: none;">
                                                        <h1>
                                                            Install and configure
                                                            <%=hdnCalendarAddOnName.Value%></h1>
                                                        <div class="scrollablebox" style="color: White; width: 100%;" align="center">
                                                            <h3>
                                                                Installation in progress. Please wait...</h3>
                                                            <br />
                                                            <img src="../../Images/popup_ajax-loader.gif" alt="progress" />
                                                            <br />
                                                            <div id="divCalUpload" style="display: none">
                                                                <div style="width: 300pt; height: 15px; border: solid 1pt gray">
                                                                    <div id="divCalProgress" runat="server" style="display: none;" class="szliderbar">
                                                                    </div>
                                                                    <asp:Label ID="lblCalPercentage" runat="server" Text="Label"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </asp:Panel>
                                                    <asp:Panel ID="pnlCalSuccess" runat="server" Style="display: none;">
                                                        <h1>
                                                        </h1>
                                                        <div class="scrollablebox" style="color: White; width: 100%;" align="center">
                                                            <h3>
                                                                New module has been installed and configured successfully.</h3>
                                                            <h3>
                                                                It is ready for use.</h3>
                                                        </div>
                                                        <a href="javascript:HideCalendorModuleModal();" class="btn">Close</a>
                                                    </asp:Panel>
                                                </div>
                                                <div class="bottom">
                                                </div>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
            <table border="0" width="50%" cellpadding="0" cellspacing="0">
                <tr>
                    <td valign="top">
                        <asp:Label ID="lblBannerAds" runat="server"></asp:Label>
                        <cc1:ModalPopupExtender ID="ModalBannerAds" runat="server" TargetControlID="lblBannerAds"
                            PopupControlID="pnlBannerAds" BackgroundCssClass="modal">
                        </cc1:ModalPopupExtender>
                        <asp:Panel ID="pnlBannerAds" runat="server" Width="50%" Style="display: none;">
                            <table>
                                <tr>
                                    <td>
                                        <div id='div4'>
                                            <div id="popup-cont">
                                                <div class="top">
                                                    <a href="javascript:HideBannerAdModuleModalWindow();"></a>
                                                </div>
                                                <div class="middle">
                                                    <asp:Panel ID="pnlBannerAdTabName" runat="server">
                                                        <h1>
                                                            Install and configure
                                                            <%=hdnBannerAdsName.Value%>
                                                            - step 1</h1>
                                                        <h2 class="lft">
                                                            1. App Button name</h2>
                                                        <asp:TextBox ID="txtBannerAdTabName" runat="server" onkeypress="return isNumberKey(event);"
                                                            onkeydown="return Maxlength(this);" Text="Banner Ads" MaxLength="13" class="txt-input"></asp:TextBox>
                                                        <h2>
                                                            2. App Button Icon (Select any one from the below list)</h2>
                                                        <div class="scrollablebox">
                                                            <div class="auto" id="divBannerAdIcons">
                                                            </div>
                                                        </div>
                                                        <asp:LinkButton ID="lnkAddBannerAd" runat="server" class="btn" Text="Submit" OnClientClick="return OpenCustomModulePopup3()"
                                                            OnClick="lnkAddBannerAd_Click"></asp:LinkButton>
                                                    </asp:Panel>
                                                    <asp:Panel ID="pnlBannerAdProgress" runat="server">
                                                        <<h1>
                                                            Install and configure
                                                            <%=hdnCalendarAddOnName.Value%></h1>
                                                        <div class="scrollablebox" style="color: White; width: 100%;" align="center">
                                                            <h3>
                                                                Installation in progress. Please wait...</h3>
                                                            <br />
                                                            <img src="../../Images/popup_ajax-loader.gif" alt="progress" />
                                                            <br />
                                                            <div id="divBanUpload" style="display: none">
                                                                <div style="width: 300pt; height: 15px; border: solid 1pt gray">
                                                                    <div id="divBannerAdProgress" runat="server" style="display: none;" class="szliderbar">
                                                                    </div>
                                                                    <asp:Label ID="lblBanPercentage" runat="server" Text="Label"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </asp:Panel>
                                                    <asp:Panel ID="pnlBannerAdSuccess" runat="server" Style="display: none;">
                                                        <h1>
                                                        </h1>
                                                        <div class="scrollablebox" style="color: White; width: 100%;" align="center">
                                                            <h3>
                                                                New module has been installed and configured successfully.</h3>
                                                            <h3>
                                                                It is ready for use.</h3>
                                                        </div>
                                                        <a href="javascript:HideBannerAdModuleModalWindow();" class="btn">Close</a>
                                                    </asp:Panel>
                                                </div>
                                                <div class="bottom">
                                                </div>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                <tbody>
                    <tr>
                        <td>
                            <asp:Label ID="lblUpgradePremium" runat="server"></asp:Label>
                            <cc1:ModalPopupExtender ID="ModalPremium" runat="server" TargetControlID="lblUpgradePremium"
                                PopupControlID="pnlUpgradePremium" BackgroundCssClass="modal" CancelControlID="imcloseimagepopup">
                            </cc1:ModalPopupExtender>
                            <asp:Panel ID="pnlUpgradePremium" runat="server" Width="100%" Style="display: none;">
                                <table class="popuptable" cellspacing="0" cellpadding="0" width="620" align="center"
                                    border="0">
                                    <tbody>
                                        <tr>
                                            <td align="right" colspan="2">
                                                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="../../images/popup_close.gif"
                                                    CausesValidation="false"></asp:ImageButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="3">
                                                    <ProgressTemplate>
                                                        <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                                    </ProgressTemplate>
                                                </asp:UpdateProgress>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td colspan="2">
                                                            <h2>
                                                                <b>Upgrade to Premium Membership </b>
                                                            </h2>
                                                            <br />
                                                            Customer Service will call you to assist you in upgrading your subscription from
                                                            Basic to Premium.
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="height: 15px;">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    Profile Name:
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="txtProfileName" runat="server" Style="font-weight: bold; margin-left: 15px;"></asp:Label>
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <fieldset style="border: 1px solid #D3D3D3; border-radius: 3px; margin-top: 8px;">
                                                                <legend style="color: Green; font-weight: bold;">Contact Info</legend>
                                                                <table>
                                                                    <tr>
                                                                        <td colspan="3">
                                                                            <p>
                                                                                <b>Note: </b>Our customer service will reach you using the following details. Please
                                                                                make any changes necessary.</p>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            Contact Name:
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtCntctName" class="txtcss" margin-top="6px" runat="server"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            Email Id:
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtMail" class="txtcss" margin-top="6px" runat="server"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            Phone Number:
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtNumber" class="txtcss" runat="server" margin-top="6px"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            Preferred date &amp; time to call:
                                                                        </td>
                                                                        <td colspan="2">
                                                                            <asp:TextBox ID="txtPreferedDate" runat="server" Width="110px"></asp:TextBox>
                                                                            <cc1:TextBoxWatermarkExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtPreferedDate"
                                                                                WatermarkCssClass="watermarkbulletindate" WatermarkText="MM/DD/YYYY">
                                                                            </cc1:TextBoxWatermarkExtender>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPreferedDate"
                                                                                Display="Dynamic" ErrorMessage="Date is mandatory." ValidationGroup="SV">*</asp:RequiredFieldValidator>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPreferedDate"
                                                                                Display="Dynamic" ErrorMessage="Invalid Date Format of Date." ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                                                                ValidationGroup="SV">*</asp:RegularExpressionValidator>
                                                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                                                                                Format="MM/dd/yyyy" TargetControlID="txtPreferedDate" />
                                                                            &nbsp;
                                                                            <asp:TextBox ID="txtHours" runat="server" MaxLength="2" Width="35px"></asp:TextBox>
                                                                            <span style="font-weight: bold;">Hours</span> &nbsp;
                                                                            <asp:TextBox ID="txtMinutes" runat="server" MaxLength="2" Width="35px"></asp:TextBox>
                                                                            <span style="font-weight: bold;">Minutes</span> &nbsp;
                                                                            <asp:DropDownList ID="ddlFromSS" runat="server" Width="40px" Height="20">
                                                                                <asp:ListItem Selected="True" Text="AM" Value="AM"></asp:ListItem>
                                                                                <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </fieldset>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table>
                                                                <tr>
                                                                    <td>
                                                                        Please use this box to leave any notes for us:
                                                                    </td>
                                                                    <td colspan="2">
                                                                        <asp:TextBox ID="lblRemarks" runat="server" Style="height: 45px; width: 251px; border-radius: 3px;"
                                                                            TextMode="MultiLine"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="height: 20px;">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr style="margin-top: 10px;" style="margin-bottom: 10px;">
                                                        <td align="center">
                                                            <asp:Button ID="btnSubmitPremium" runat="server" class="btn" OnClick="btnSubmitPremium_Click"
                                                                OnClientClick="return DatePremiumFiled();" Text="Submit" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-left: 10px;">
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </asp:Panel>
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblBrandedApp" runat="server"></asp:Label>
                                            <cc1:ModalPopupExtender ID="ModalBrandedApp" runat="server" TargetControlID="lblBrandedApp"
                                                PopupControlID="pnlBrandedApp" BackgroundCssClass="modal" CancelControlID="imcloseimagepopup">
                                            </cc1:ModalPopupExtender>
                                            <asp:Panel ID="pnlBrandedApp" runat="server" Width="100%" Style="display: none;">
                                                <table class="popuptable" cellspacing="0" cellpadding="0" width="620" align="center"
                                                    border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right" colspan="2">
                                                                <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="../../images/popup_close.gif"
                                                                    CausesValidation="false"></asp:ImageButton>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center">
                                                                <asp:UpdateProgress ID="UpdateProgress3" runat="server" DisplayAfter="3">
                                                                    <ProgressTemplate>
                                                                        <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                                                    </ProgressTemplate>
                                                                </asp:UpdateProgress>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <table cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td colspan="2">
                                                                            <h2>
                                                                                <b>Upgrade to a Branded App </b>
                                                                            </h2>
                                                                            <br />
                                                                            Customer Service will call you to answer any questions you may have about a branded
                                                                            app and collect the data needed to proceed further.
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" style="height: 15px;">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <table>
                                                                            <tr>
                                                                                <td>
                                                                                    Profile Name:
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="txtbrndProfilename" runat="server" Style="font-weight: bold; margin-left: 15px;"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <fieldset style="border: 1px solid #D3D3D3; border-radius: 3px; margin-top: 8px;">
                                                                                <legend style="color: Green; font-weight: bold;">Contact Info</legend>
                                                                                <table>
                                                                                    <tr>
                                                                                        <td colspan="3">
                                                                                            <p>
                                                                                                <b>Note: </b>Our customer service will reach you using the following details. Please
                                                                                                make any changes necessary.</p>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            Contact Name:
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtbrndcntct" class="txtcss" margin-top="6px" runat="server"></asp:TextBox>
                                                                                        </td>
                                                                                        <td>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            Email Id:
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtbrndmail" class="txtcss" margin-top="6px" runat="server"></asp:TextBox>
                                                                                        </td>
                                                                                        <td>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            Phone Number:
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtbrndnum" class="txtcss" runat="server" margin-top="6px"></asp:TextBox>
                                                                                        </td>
                                                                                        <td>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            Preferred date &amp; time to call:
                                                                                        </td>
                                                                                        <td colspan="2">
                                                                                            <asp:TextBox ID="txtprfrdDate" runat="server" Width="110px"></asp:TextBox>
                                                                                            <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txtprfrdDate"
                                                                                                WatermarkCssClass="watermarkbulletindate" WatermarkText="MM/DD/YYYY">
                                                                                            </cc1:TextBoxWatermarkExtender>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtprfrdDate"
                                                                                                Display="Dynamic" ErrorMessage="Date is mandatory." ValidationGroup="SV">*</asp:RequiredFieldValidator>
                                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtprfrdDate"
                                                                                                Display="Dynamic" ErrorMessage="Invalid Date Format of Date." ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                                                                                ValidationGroup="SV">*</asp:RegularExpressionValidator>
                                                                                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="MyCalendar"
                                                                                                Format="MM/dd/yyyy" TargetControlID="txtprfrdDate" />
                                                                                            &nbsp;
                                                                                            <asp:TextBox ID="txthrs" runat="server" MaxLength="2" Width="35px"></asp:TextBox>
                                                                                            <span style="font-weight: bold;">Hours</span> &nbsp;
                                                                                            <asp:TextBox ID="txtmns" runat="server" MaxLength="2" Width="35px"></asp:TextBox>
                                                                                            <span style="font-weight: bold;">Minutes</span> &nbsp;
                                                                                            <asp:DropDownList ID="ddlam" runat="server" Width="40px" Height="20">
                                                                                                <asp:ListItem Selected="True" Text="AM" Value="AM"></asp:ListItem>
                                                                                                <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                                                                                            </asp:DropDownList>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </fieldset>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <table>
                                                                                <tr>
                                                                                    <td>
                                                                                        Please use this box to leave any notes for us:
                                                                                    </td>
                                                                                    <td colspan="2">
                                                                                        <asp:TextBox ID="txtRemarks" runat="server" Style="height: 45px; width: 251px; border-radius: 3px;"
                                                                                            TextMode="MultiLine"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" style="height: 20px;">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="margin-top: 10px;" style="margin-bottom: 10px;">
                                                                        <td align="center">
                                                                            <asp:Button ID="btnBrandedApp" runat="server" class="btn" OnClick="btnSubmitBrandedApp_Click"
                                                                                OnClientClick="return DateFiled();" Text="Submit" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding-left: 10px;">
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblSubAppM" runat="server"></asp:Label>
                                            <cc1:ModalPopupExtender ID="modalSubApp" runat="server" TargetControlID="lblSubAppM"
                                                BehaviorID="modalSubAppWindow" PopupControlID="pnlSubApp" BackgroundCssClass="modal"
                                                CancelControlID="imcloseimagepopup">
                                            </cc1:ModalPopupExtender>
                                            <asp:Panel ID="pnlSubApp" runat="server" Width="100%" Style="display: none;">
                                                <table class="popuptable" cellspacing="0" cellpadding="0" width="620" align="center"
                                                    border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right" colspan="2">
                                                                <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="../../images/popup_close.gif"
                                                                    CausesValidation="false"></asp:ImageButton>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center">
                                                                <asp:UpdateProgress ID="UpdateProgress4" runat="server" DisplayAfter="3">
                                                                    <ProgressTemplate>
                                                                        <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                                                    </ProgressTemplate>
                                                                </asp:UpdateProgress>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <fieldset style="border: 1px solid #D3D3D3; border-radius: 3px; margin-top: 8px;">
                                                                    <legend style="color: Green; font-weight: bold;">Affiliate Invitation Info</legend>
                                                                    <table>
                                                                        <col width="150px" />
                                                                        <col width="*" />
                                                                        <tr>
                                                                            <td>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Invitation from:
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label runat="server" ID="lblfromProfileName" Font-Bold="true"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                User ID:
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label runat="server" ID="lblfromUserID" Font-Bold="true"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr style="display: none;">
                                                                            <td>
                                                                                Notes:
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox runat="server" ID="txtNotes" Height="150px" Width="250px" TextMode="MultiLine"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" align="center">
                                                                                <asp:HiddenField runat="server" ID="hdnInvitationID" />
                                                                                <asp:HiddenField runat="server" ID="hdnNotes" />
                                                                                <asp:LinkButton ID="btnAccept" runat="server" CssClass="submit" OnClick="btnAccept_OnClick">
                                                                                <img width="150px" src="/Images/approve_btn.gif" border="0" />
                                                                                </asp:LinkButton>
                                                                                <asp:LinkButton Style="display: none;" ID="lnkDecline" runat="server" OnClick="lnkDecline_OnClick"
                                                                                    CssClass="submit" OnClientClick="return confirm('Are you sure you want Decline?')">
                                                                                <img src="/Images/reject_btn.gif"  border="0" /></asp:LinkButton>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </fieldset>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding-left: 10px;">
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <%--<asp:HiddenField ID="hdnAccessCode" runat="server" />--%>
                            <asp:HiddenField runat="server" ID="hdnModuleTemplateID" Value="0" />
                            <asp:HiddenField runat="server" ID="hdnModuleAppName" />
                            <asp:HiddenField runat="server" ID="hdnModuleAppButton" />
                            <asp:HiddenField runat="server" ID="hdnAddOnName" />
                            <asp:HiddenField runat="server" ID="hdnPrivateAddOnName" />
                            <asp:HiddenField runat="server" ID="hdnPrivateCallAddOnName" />
                            <asp:HiddenField runat="server" ID="hdnPublicCallAddOnName" />
                            <asp:HiddenField runat="server" ID="hdnCalendarAddOnName" />
                            <asp:HiddenField runat="server" ID="hdnBannerAdsName" />
                            <asp:HiddenField runat="server" ID="hdnLaunchPlay" />
                            <asp:HiddenField runat="server" ID="hdnVersionPlay" />
                            <asp:HiddenField runat="server" ID="hdnSelModulePopup" />
                            <asp:HiddenField runat="server" ID="hdnPackageID" Value="0" />
                            <asp:HiddenField runat="server" ID="hdnPrivateSmartConnectAddOnsName" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Label ID="lblSearchCode" runat="server"></asp:Label>
            <cc1:ModalPopupExtender ID="mpeAccessCode" runat="server" TargetControlID="lblSearchCode"
                PopupControlID="pnlSearchCode" BackgroundCssClass="modal" CancelControlID="imgcloseimagepopup1">
            </cc1:ModalPopupExtender>
            <asp:Panel ID="pnlSearchCode" runat="server" Style="display: none" Width="600px">
                <table cellpadding="4px" cellspacing="0" width="80%" style="border: 1px solid #EEECEC;
                    background-color: #F8F6F6;">
                    <tbody>
                        <tr>
                            <td align="right" style="padding: 5px 10px 0px 10px;">
                                <asp:ImageButton ID="imgcloseimagepopup1" runat="server" ImageUrl="~/images/popup_close.gif" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="pageheading">
                                    <asp:Label ID="lblHeading" runat="server"></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="text-align: center;">
                                    <asp:UpdateProgress ID="UpdateProgress3" runat="server" DisplayAfter="1">
                                        <ProgressTemplate>
                                            <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b></ProgressTemplate>
                                    </asp:UpdateProgress>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                Enter Access Code:
                                <asp:TextBox ID="txtAccessCode" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtAccessCode"
                                    Display="Dynamic" SetFocusOnError="True" ErrorMessage="Access code is mandatory."
                                    ValidationGroup="AccessCode">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="REValphaOnly" runat="server" Display="Dynamic"
                                    ErrorMessage="Please enter alphanumerics only." ValidationGroup="AccessCode"
                                    ControlToValidate="txtAccessCode" ValidationExpression="^[a-zA-Z0-9]+$">*</asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnSubmitCode" runat="server" ValidationGroup="AccessCode" Text="Submit"
                                    OnClick="btnSubmitCode_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-bottom: 30px;">
                                <asp:Label ID="lblerror" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:ValidationSummary ID="ValidationSummary3" runat="server" HeaderText="The following error(s) are occurred:"
                                    ShowSummary="true" ValidationGroup="AccessCode" />
                            </td>
                        </tr>
                    </tbody>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>--%>
    <asp:HiddenField ID="hdnsettings" runat="server" />
    <asp:HiddenField ID="hdnTimeZoneID" runat="server" />
    <script type="text/javascript">
        function DateFiled() {
            if (document.getElementById("<%=txtprfrdDate.ClientID %>").value != "") {
                var currentdate = new Date();
                var fromDate = document.getElementById("<%=txtprfrdDate.ClientID %>").value;
                var selDate = new Date(fromDate);
                var selHours = document.getElementById("<%=txthrs.ClientID %>").value;
                var selmins = document.getElementById("<%=txtmns.ClientID %>").value;
                selDate.setHours(selHours, selmins, 0);
                if (selDate <= currentdate) {
                    alert('Preferred date should be later than today.');
                    document.getElementById("<%=txtprfrdDate.ClientID %>").value = "";

                    return false;
                }
            }

            if (document.getElementById("<%=txthrs.ClientID %>").value != "" && document.getElementById("<%=txtmns.ClientID %>").value != "") {
                if (selHours > 12) {
                    alert('Invalid  time format.');
                    document.getElementById("<%=txthrs.ClientID %>").focus();
                    return false;
                }
                else if (selmins >= 60) {
                    alert('Invalid  time format.');
                    document.getElementById("<%=txtmns.ClientID %>").focus();
                    return false;
                }
            } //end of if
            else if (document.getElementById("<%=txthrs.ClientID %>").value != "") {
                if (selHours > 12) {
                    alert('Invalid  time format.');
                    document.getElementById("<%=txthrs.ClientID %>").focus();
                    return false;
                }
            } //end of else if
            else
                if (selmins >= 60) {
                    alert('Invalid  time format.');
                    document.getElementById("<%=txtmns.ClientID %>").focus();
                    return false;
                }

        }

        function DatePremiumFiled() {
            if (document.getElementById("<%=txtPreferedDate.ClientID %>").value != "") {
                var currentdate = new Date();
                var fromDate = document.getElementById("<%=txtPreferedDate.ClientID %>").value;
                var selDate = new Date(fromDate);
                var selHours = document.getElementById("<%=txtHours.ClientID %>").value;
                var selmins = document.getElementById("<%=txtMinutes.ClientID %>").value;
                selDate.setHours(selHours, selmins, 0);
                if (selDate <= currentdate) {
                    alert('Preferred date should be later than today.');
                    document.getElementById("<%=txtPreferedDate.ClientID %>").value = "";
                    return false;
                }
            }
            if (document.getElementById("<%=txtHours.ClientID %>").value != "" && document.getElementById("<%=txtMinutes.ClientID %>").value != "") {
                if (selHours > 12) {
                    alert('Invalid  time format.');
                    document.getElementById("<%=txtHours.ClientID %>").focus();
                    return false;
                }
                else if (selmins >= 60) {
                    alert('Invalid  time format.');
                    document.getElementById("<%=txtMinutes.ClientID %>").focus();
                    return false;
                }
            } //end of if
            else if (document.getElementById("<%=txtHours.ClientID %>").value != "") {
                if (selHours > 12) {
                    alert('Invalid  time format.');
                    document.getElementById("<%=txtHours.ClientID %>").focus();
                    return false;
                }
            } //end of else if
            else
                if (selmins >= 60) {
                    alert('Invalid  time format.');
                    document.getElementById("<%=txtMinutes.ClientID %>").focus();
                    return false;
                }

        }

        function fireServerButtonEvent() {
            document.getElementById("<%=lnkUpdateCredicard.ClientID %>").click();
        }
        function doSomething() {
            var days = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"]
            var currentTime;
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "Default.aspx/GetUserTimeZoneDashboard",
                dataType: "json",
                success: function (response) {
                    currentTime = new Date(response.d);
                    var month = currentTime.getMonth() + 1;
                    var day = currentTime.getDate();
                    var year = currentTime.getFullYear();
                    var hours = currentTime.getHours()
                    var minutes = currentTime.getMinutes()
                    if (minutes < 10)
                        minutes = "0" + minutes;
                    var hr = hours;
                    var dd = "A.M";
                    if (hr >= 12) {
                        hr = hours - 12;
                        dd = "P.M";
                    }
                    if (hr == 0) {
                        hr = 12;
                    }
                    var time = hr + ":" + minutes + " " + dd;
                    document.getElementById('<%=lblTime.ClientID %>').innerHTML = time + " " + document.getElementById("<%=hdnTimeZoneID.ClientID %>").value;
                    document.getElementById('<%=lblDate.ClientID %>').innerHTML = days[currentTime.getDay()] + ", " + month + "/" + day + "/" + year;
                    setTimeout(doSomething, 60000); //Then set it to run again after 6 seconds
                }
            });
        }
        function toggle_visibility(id) {
            if (document.getElementById(id).style.display == "none") {
                document.getElementById(id).style.display = "block";

                if (shown.length > 0) {
                    var items = shown.toString().split(',');
                    shown = [];
                    for (var i = 0; i < items.length; i++) {
                        if (items[i] == id)
                            continue;
                        shown.push(items[i]);
                    }
                }
                localStorage.setItem('shown', shown);
            }
            else {

                document.getElementById(id).style.display = "none";

                shown.push(id);
                localStorage.setItem('shown', shown);
            }
        }
        function toggle_Videos() {
            document.getElementById('divShowMore').style.display = "none";
            document.getElementById('divHideMore').style.display = "none";
            if (document.getElementById('divShowVideos').style.display == "none") {
                document.getElementById('divShowVideos').style.display = "block";
                document.getElementById('divHideMore').style.display = "block";
            }
            else {
                document.getElementById('divShowVideos').style.display = "none";
                document.getElementById('divShowMore').style.display = "block";
            }
        }
        window.onload = function () {
            doSomething(); //Make sure the function fires as soon as the page is loaded
            //ShowVideoPopup(109175332);
            //            if (document.getElementById("<%=hdnVersionPlay.ClientID %>").value == "Yes") {
            //                document.getElementById('divVersionShow').style.display = 'block';
            //                ShowVersionPopup();
            //            }
        }
        function CallAlert(text) {
            alert('You do not have permission to access ' + text + '.');
        }

        function SmartConnectAppVersionMSG(navigatonUrl) {
            //alert('You may begin setting up the SmartConnect immediately. In order to display this module your Branded App must be updated in the app stores. We have begun the process; please allow two weeks for the update to be published.');
            location.href = navigatonUrl;
        }

        var shown = []
        $(document).ready(function () {
            var shown = localStorage.getItem('shown');
            if (shown != null) {
                if (shown.length > 0) {
                    var items = shown.toString().split(',');
                    for (var i = 0; i < items.length; i++) {
                        $('#' + items[i]).css('display', 'none');
                    }
                }
            }
        });

    </script>
    <script type="text/javascript">
        var size = 2;
        var id = 0;
        function OpenCustomModuleModalWindow(purchaseType) {
            document.getElementById("<%=hdnSelModulePopup.ClientID %>").value = purchaseType;
            BindDatatable(purchaseType);
            if (purchaseType == "AddOns")
                document.getElementById("<%=lblAddOnName.ClientID %>").innerHTML = document.getElementById("<%=hdnAddOnName.ClientID %>").value;
            else if (purchaseType == "PrivateAddOns")
                document.getElementById("<%=lblAddOnName.ClientID %>").innerHTML = document.getElementById("<%=hdnPrivateAddOnName.ClientID %>").value;
            else if (purchaseType == "PrivateCallAddOns")
                document.getElementById("<%=lblAddOnName.ClientID %>").innerHTML = document.getElementById("<%=hdnPrivateCallAddOnName.ClientID %>").value;
            else if (purchaseType == "PublicCallAddOns")
                document.getElementById("<%=lblAddOnName.ClientID %>").innerHTML = document.getElementById("<%=hdnPublicCallAddOnName.ClientID %>").value;
            else if (purchaseType == "PrivateSmartConnectAddOns")
                document.getElementById("<%=lblAddOnName.ClientID %>").innerHTML = document.getElementById("<%=hdnPrivateSmartConnectAddOnsName.ClientID %>").value;

            document.getElementById("<%=hdnModuleAppButton.ClientID %>").value = "0";
            document.getElementById("<%=txtAppButtonName.ClientID %>").value = "";
            document.getElementById("<%=pnlNameandTab.ClientID %>").style.display = "block";
            document.getElementById("<%=pnlProgress.ClientID %>").style.display = "none";
            document.getElementById("<%=pnlSuccess.ClientID %>").style.display = "none";
            $find("<%=ModalCustomModule.ClientID %>").show();
        }
        function HideCustomModuleModalWindow() {
            if (document.getElementById("<%=pnlSuccess.ClientID %>").style.display == "block")
                location.reload();
            else {
                $find("<%=ModalCustomModule.ClientID %>").hide();
            }
        }
        /*  *** Below  'GetSelectedModule' function is not using *** */
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
        /*  *** Below  'OpenCustomModulePopup2' function is not using *** */
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
            var purchaseType = document.getElementById("<%=hdnSelModulePopup.ClientID %>").value;
            var appName = "";
            if (purchaseType == "CalendarAddOns")
                appName = document.getElementById("<%=txtCalTabName.ClientID %>").value;
            else if (purchaseType == "BannerAds")
                appName = document.getElementById("<%=txtBannerAdTabName.ClientID %>").value;
            else
                appName = document.getElementById("<%=txtAppButtonName.ClientID %>").value;
            document.getElementById("<%=hdnModuleAppName.ClientID %>").value = appName;

            var errMsg = "";
            if (appName == "") {
                errMsg = "Please enter app button name.\n";
            }
            if (document.getElementById("<%=hdnModuleAppButton.ClientID %>").value == "0")
                errMsg = errMsg + "Please select icon for app button.";
            if (errMsg == "") {
                if (ValidateAppButton(purchaseType)) {
                    if (purchaseType == "CalendarAddOns") {
                        document.getElementById("<%= pnlCalNameTab.ClientID %>").style.display = "none";
                        document.getElementById("<%= pnlCalProgress.ClientID %>").style.display = "block";
                        document.getElementById("<%= pnlCalSuccess.ClientID %>").style.display = "none";
                    }
                    if (purchaseType == "BannerAds") {
                        document.getElementById("<%= pnlBannerAdTabName.ClientID %>").style.display = "none";
                        document.getElementById("<%= pnlBannerAdProgress.ClientID %>").style.display = "block";
                        document.getElementById("<%= pnlBannerAdSuccess.ClientID %>").style.display = "none";
                    }
                    else {
                        document.getElementById("<%= pnlTemplates.ClientID %>").style.display = "none";
                        document.getElementById("<%= pnlNameandTab.ClientID %>").style.display = "none";
                        document.getElementById("<%= pnlProgress.ClientID %>").style.display = "block";
                        document.getElementById("<%=pnlSuccess.ClientID %>").style.display = "none";
                    }
                    size = 2;
                    id = 0;
                    ProgressBar(purchaseType);
                }
                else
                    return false;
            }
            else {
                alert(errMsg);
                return false;
            }

        }
        function ProgressBar(purchaseType) {
            if (purchaseType == "CalendarAddOns") {
                document.getElementById("<%=divCalProgress.ClientID %>").style.display = "block";
                document.getElementById("divCalUpload").style.display = "block";
            }
            else if (purchaseType == "BannerAds") {
                document.getElementById("<%=divBannerAdProgress.ClientID %>").style.display = "block";
                document.getElementById("divBanUpload").style.display = "block";
            }
            else {
                document.getElementById("<%=divProgress.ClientID %>").style.display = "block";
                document.getElementById("divUpload").style.display = "block";
            }
            id = setInterval("progress('" + purchaseType + "')", 20);
        }
        function progress(purchaseType) {
            size = size + 1;
            if (size > 299) {
                clearTimeout(id);
            }
            if (purchaseType == "CalendarAddOns") {
                document.getElementById("<%=divCalProgress.ClientID %>").style.width = size + "pt";
                document.getElementById("<%=lblCalPercentage.ClientID %>").firstChild.data = parseInt(size / 3) + "%";
            }
            else if (purchaseType == "BannerAds") {
                document.getElementById("<%=divBannerAdProgress.ClientID %>").style.width = size + "pt";
                document.getElementById("<%=lblBanPercentage.ClientID %>").firstChild.data = parseInt(size / 3) + "%";
            }
            else {
                document.getElementById("<%=divProgress.ClientID %>").style.width = size + "pt";
                document.getElementById("<%=lblPercentage.ClientID %>").firstChild.data = parseInt(size / 3) + "%";
            }
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
        function OpenCalModuleModalWindow(purchaseType) {
            document.getElementById("<%=hdnSelModulePopup.ClientID %>").value = purchaseType;
            BindDatatable(purchaseType);
            document.getElementById("<%=hdnModuleAppButton.ClientID %>").value = "0";
            document.getElementById("<%=txtCalTabName.ClientID %>").value = "";
            document.getElementById("<%=pnlCalNameTab.ClientID %>").style.display = "block";
            document.getElementById("<%=pnlCalProgress.ClientID %>").style.display = "none";
            document.getElementById("<%=pnlCalSuccess.ClientID %>").style.display = "none";
            $find("<%=ModalCalendorAddons.ClientID %>").show();
        }
        function HideCalendorModuleModal() {
            if (document.getElementById("<%=pnlCalSuccess.ClientID %>").style.display == "block")
                location.reload();
            else {
                $find("<%=ModalCalendorAddons.ClientID %>").hide();
            }
        }
        function OpenBannerAdModuleModalWindow(purchaseType) {
            document.getElementById("<%=hdnSelModulePopup.ClientID %>").value = purchaseType;
            document.getElementById("<%=hdnModuleAppButton.ClientID %>").value = "0";
            document.getElementById("<%=pnlBannerAdTabName.ClientID %>").style.display = "none";
            document.getElementById("<%=pnlBannerAdProgress.ClientID %>").style.display = "none";
            document.getElementById("<%=pnlBannerAdSuccess.ClientID %>").style.display = "none";
            document.getElementById("<%=hdnModuleAppButton.ClientID %>").value = "BannerAd1";
            $find("<%=ModalBannerAds.ClientID %>").show();
            document.getElementById('<%= lnkAddBannerAd.ClientID %>').click();
        }
        function HideBannerAdModuleModalWindow() {
            if (document.getElementById("<%=pnlBannerAdSuccess.ClientID %>").style.display == "block")
                location.reload();
            else {
                $find("<%=ModalBannerAds.ClientID %>").hide();
            }
        }
        function Openupgradewindow() {
            $find("<%=ModalPremium.ClientID %>").show();
        }
        function OpenSubscriptionwindow() {
            $find("<%=ModalBrandedApp.ClientID %>").show();
        }


        function BindDatatable(purchaseType) {
            var moduleid = "0";
            if (purchaseType == "AddOns" || purchaseType == "PrivateAddOns")
                moduleid = document.getElementById("<%=hdnModuleTemplateID.ClientID %>").value;
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "Default.aspx/BindAppIcons",
                data: "{moduleID:'" + moduleid + "',purchaseType:'" + purchaseType + "'}",
                dataType: "json",
                success: function (data) {
                    var customAppIcons = "<ul class=\"AppIcons\">";
                    for (var i = 0; i < data.d.length; i++) {
                        var imgPath = data.d[i].ImagePath;
                        customAppIcons = customAppIcons + "<li class='icon'><img src='" + imgPath + "' alt='' id='img" + data.d[i].AppIcon + "' class='pad' onclick='javascript:GetSelectAppButton(this.src)' /></li>";
                    }
                    customAppIcons = customAppIcons + "</ul>";
                    if (purchaseType == "CalendarAddOns")
                        $('#divCalAppIcons').html(customAppIcons);
                    else if (purchaseType == "BannerAds")
                        $('#divBannerAdIcons').html(customAppIcons);
                    else
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
        function ValidateAppButton(purchaseType) {
            var appButton = "";
            if (purchaseType == "CalendarAddOns")
                appButton = document.getElementById("<%=txtCalTabName.ClientID %>").value;
            else if (purchaseType == "BannerAds")
                appButton = document.getElementById("<%=txtBannerAdTabName.ClientID %>").value;
            else
                appButton = document.getElementById("<%=txtAppButtonName.ClientID %>").value;
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
        function DisplayVideos() {
            window.location = "/business/myaccount/HowToVideos.aspx";
        }

        function InvitationConfirm(InvitationID, ParentProfileName, ParentUserID, InvitationID, Notes) {

            document.getElementById("<%=lblfromProfileName.ClientID %>").innerHTML = ParentProfileName;
            document.getElementById("<%=lblfromUserID.ClientID %>").innerHTML = ParentUserID;

            document.getElementById("<%=txtNotes.ClientID %>").value = document.getElementById("<%=hdnNotes.ClientID %>").value = Notes;
            document.getElementById("<%=hdnInvitationID.ClientID %>").value = InvitationID;

            var modal = $find("modalSubAppWindow");
            modal.show();
        }

    </script>
    <script type="text/javascript">
        $('#ca-container').contentcarousel();
    </script>
</asp:Content>
