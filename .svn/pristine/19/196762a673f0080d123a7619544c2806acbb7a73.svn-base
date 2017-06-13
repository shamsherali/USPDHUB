<%@ Page Title="" Language="C#" MasterPageFile="~/PaidTools.master" AutoEventWireup="true"
    CodeBehind="HowToVideos.aspx.cs" Inherits="USPDHUB.Business.MyAccount.HowToVideos" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphUser" runat="server">
 <script src="../../Scripts/flyers/jquery-1.7.2.js" type="text/javascript"></script>
    <style type="text/css">
        #Videowrap
        {
            width: 230px;
            height: 170px;
        }
        .count
        {
            font-size: 18px;
            color: #04B404;
            font-weight: bold;
        }
        h1
        {
            font-size: 18px;
            color: #EC2027;
            height: 35px;
            line-height: 35px;
            width: 133px;
        }
        #Video
        {
            border: 1px solid #00AAA0;
            height: 200px;
            display: table;
        }
        #Video .img
        {
            vertical-align: middle;
            display: table-cell;
        }
        #Video img
        {
            width: 200px;
            vertical-align: middle;
        }
        .videotitle
        {
            padding-top: 3px;
            color: #FF7A5A;
            font-weight: bold;
        }
        .loading
        {
            font-family: Arial;
            font-size: 10pt;
            border: 5px solid #67CFF5;
            width: 200px;
            height: 150px;
            display: none;
            position: fixed;
            background-color: White;
            z-index: 999;
        }
        .HelpBox
        {
            width: 300px;
            height: 20px;
            border: solid 1px #41AAC4;
            padding: 5px;
            background-color: #FFFFFF;
            outline: none;
            color: #474747;
        }
        .HelpButton
        {
            -webkit-border-radius: 2;
            -moz-border-radius: 2;
            border-radius: 2px;
            font-family: Arial;
            border: solid #5d6061 2px;
            color: #ffffff;
            font-size: 14px;
            background: #5c5f61;
            padding: 4px 8px 4px 8px;
            text-decoration: none;
            cursor: pointer;
        }
        .btnmore
        {
            background-color: #4CAF50;
            border: none;
            color: #FFFFFF;
            padding: 10px 25px;
            text-align: center;
            text-decoration: none;
            font-size: 16px;
            border-radius: 3px;
            cursor: pointer;
        }
        .style2
        {
            width: 114px;
        }
    </style>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <div>
                <table>
                    <tr>
                        <td>
                            <table width="100%">
                                <tr>
                                    <td class="style2">
                                        <h1>
                                            How To Videos</h1>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblCount" runat="server" CssClass="count"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="3">
                                            <ProgressTemplate>
                                                <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <colgroup>
                                    <col width="70%" />
                                    <col width="*" />
                                </colgroup>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtVideoSearch" runat="server" CssClass="HelpBox"></asp:TextBox>
                                    </td>
                                    <td valign="middle">
                                        <%--  <asp:Button ID="btnHelpSearch" CommandName="Search" runat="server" Text="Search"
                                            CssClass="HelpButton" />
                                        <asp:Button ID="btnHelpClear" runat="server" Text="Clear" CssClass="HelpButton" />--%>
                                        <input type="button" class="HelpButton" value="Search" id="btnHelpSearch" />
                                        <input type="button" class="HelpButton" value="Clear" id="btnHelpClear" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <asp:Label ID="lblNoHelpMsg" runat="server" Font-Size="16px" ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div id="dlGridVideos">
                                <%--<asp:DataList runat="server" ID="dlVideos" RepeatColumns="3" RepeatDirection="Horizontal"
                                    CellPadding="30" CellSpacing="10" OnItemDataBound="dlVideos_OnItemDataBound">
                                    <ItemTemplate>
                                        <div id="Videowrap">
                                            <div id="Video">
                                                <a href="javascript:void(0)" onclick="ShowVideoPopup('<%#Eval("Url") %>', '<%#Eval("VideoID") %>')">
                                                    <asp:Label ID="lblThumbnailUrl" runat="server" Text='<%#Eval("Thumb_Url") %>' CssClass="img"></asp:Label></a>
                                            </div>
                                            <div class="videotitle">
                                                <asp:Label ID="lblTitle" runat="server" Text='<%#Eval("Title") %>'></asp:Label>
                                            </div>
                                            <div class="clear">
                                            </div>
                                        </div>
                                        <div class="clear">
                                        </div>
                                    </ItemTemplate>
                                </asp:DataList>--%>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td valign="bottom" align="center">
                            <img id="loading" alt="" src="../../Images/ajax-loader.gif" />
                            <input type="button" id="btnloadMore" value="View More" class="btnmore" />
                        </td>
                    </tr>
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
                                                <a href="javascript:void(0);" onclick="CloseModal1();">
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
            </div>
            <asp:Button ID="btnSubmit" runat="server" Text="Load Customers" Style="display: none;" />
            <div class="loading" align="center">
                Loading. Please wait.<br />
                <br />
                <img src="../../Images/ajax-loader.gif" alt="" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script src="../../Scripts/flyers/jquery-1.7.2.js" type="text/javascript"></script>
    <script type="text/javascript">
        var Start = parseInt('<%=ConfigurationManager.AppSettings.Get("Start") %>');
        var End = parseInt('<%=ConfigurationManager.AppSettings.Get("End") %>');
        var SearchStart = Start;
        var SearchEnd = End;
        var AppEnd = 0;
        var isMore = false;
        var backGround = "";


        $(document).ready(function () {
            BindDatatable(Start, End, "");
            //load more
            $("#btnloadMore").click(function () {
                Search = $("#<%=txtVideoSearch.ClientID%>").val();
                $("#loading").show();
                SearchStart = SearchStart + End;
                SearchEnd = SearchEnd + End;
                BindDatatable(SearchStart, SearchEnd, Search);
            });

            //searching a video
            $("#btnHelpSearch").click(function () {
                AppEnd = 0;
                Search = $("#<%=txtVideoSearch.ClientID%>").val().trim();
                SearchStart = Start;
                SearchEnd = End;
                if (Search != "") {
                    $("#dlGridVideos").empty();
                    BindDatatable(SearchStart, SearchEnd, Search);
                }
                else
                    alert('Please enter your search word.');
            });

            //clear search
            $("#btnHelpClear").click(function () {
                AppEnd = 0;
                SearchStart = Start;
                SearchEnd = End;
                $("#dlGridVideos").empty();
                document.getElementById('<%=txtVideoSearch.ClientID %>').value = '';
                $("<%=lblNoHelpMsg.ClientID %>").html('');
                BindDatatable(Start, End, "");
            });

        });

        function BindDatatable(start, end, Search) { // Function for calling activities from the database  
            var strSdata = "{Start:'" + start + "',End:" + end + ",Search:'" + Search.replace("'", "&apos;") + "'}";
            isMore = false;
            //alert(strSdata);
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "HowToVideos.aspx/BindVideosData",
                data: strSdata,
                dataType: "json",
                success: function (data) {
                    AppEnd = AppEnd + data.d.length;
                    var strdata = "";
                    if (data.d.length == 0 && Search != "") {
                        $("#loading").hide();
                        document.getElementById("<%=lblCount.ClientID %>").innerHTML = "(" + data.d.length + ")";
                        document.getElementById("<%=lblNoHelpMsg.ClientID %>").innerHTML = "<%=StrNoItemsFoundMSG %>".replace("##SearchHelpVideo##", $("#<%=txtVideoSearch.ClientID%>").val());
                        $("#btnloadMore").hide();
                    }
                    else {
                        $("#<%=lblNoHelpMsg.ClientID%>").html(" ");
                        for (var i = 0; i < data.d.length; i++) {
                            if (i == 0) {
                                if (AppEnd < parseInt(data.d[i].TotalVideoCount))
                                    isMore = true;
                            }
                            document.getElementById("<%=lblCount.ClientID %>").innerHTML = "(" + data.d[i].TotalVideoCount + ")";
                            strdata = strdata + "<div style='float:left;margin-bottom:5px; margin:20px;'><div id='Videowrap'><div id='Video' style='height:153px;'><a id='videoURL'  onclick=\"ShowVideoPopup1('" + data.d[i].Url + "','" + data.d[i].VideoID + "')\"><img id='lblThumbnailUrl' src='" + data.d[i].Thumb_Url + "' CssClass='img'/></a></div>";
                            strdata = strdata + "<div class='videotitle'><label id='lblTitle'>" + data.d[i].Title + "</label></div>";
                            strdata = strdata + "<div class='clear'></div></div><div class='clear'></div></div>";
                        }
                        //alert(strdata);

                        $("#dlGridVideos").append(strdata);
                        $("#loading").hide();
                        if (isMore)
                            $("#btnloadMore").show();
                        else
                            $("#btnloadMore").hide();
                    }
                },
                error: function (result) {
                    alert("Error Occured.");
                }

            });

        } 
    </script>
    <script type="text/javascript">

        function test(url) { //alert(url);
         }


        function ShowVideoPopup1(url, videoId) {
            var Iframe = document.getElementById("IframeVideoPopup");
            Iframe.src = "http://player.vimeo.com/video/" + url;
            //$find("<%=ModalPopupExtender2.ClientID %>").show();
            window.open("http://player.vimeo.com/video/" + url, "", "width=800,height=600");

            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                data: "{videoId:'" + videoId + "'}",
                url: "HowToVideos.aspx/InsertViewData",
                dataType: "json",
                processData: false,
                success: function (data) {
                    if (data.d == "No Session")
                        location.reload();
                },
                error: function (error) {
                }
            });
           
        }



        function CloseModal1() {
            var Iframe = document.getElementById("IframeVideoPopup");
            Iframe.src = '';
            $find("<%=ModalPopupExtender2.ClientID %>").hide();
        }
        function ShowProgress() {
            setTimeout(function () {
                var modal = $('<div />');
                modal.addClass("modal");
                $('body').append(modal);
                var loading = $(".loading");
                // loading.show();
                var top = Math.max($(window).height() / 2 - loading[0].offsetHeight / 2, 0);
                var left = Math.max($(window).width() / 2 - loading[0].offsetWidth / 2, 0);
                loading.css({ top: top, left: left });
            }, 200);
        }
         
    </script>
</asp:Content>
