<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BulletinVideoGallery.aspx.cs"
    Inherits="UserForms.BulletinVideoGallery" ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../Styles/Bulletins.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery.js" type="text/javascript"></script>
    <script>

        function GetThumbUrl() {

            document.getElementById("divLoading").style.display = "block";

            var videoUrl = document.getElementById("<%=txtVideoUrl.ClientID %>").value;
            document.getElementById("<%=hdnOrginalUrl.ClientID %>").value = videoUrl;
            var thumbUrl = "";
            if (videoUrl == "") {
                alert("Video url is mandatory.");
                document.getElementById("divLoading").style.display = "none";
                return false;
            }
            else if (videoUrl.indexOf("youtube") != -1 || videoUrl.indexOf("youtu.be") != -1) {
                var youtube_video_id = '';
                if (videoUrl.indexOf("youtu.be") != -1) {
                    var regExp = /^.*((youtu.be\/)|(v\/)|(\/u\/\w\/)|(embed\/)|(watch\?))\??v?=?([^#\&\?]*).*/;
                    var match = videoUrl.match(regExp);
                    if (match && match[7].length == 11) {
                        youtube_video_id = match[7];
                    }
                } else {
                    youtube_video_id = videoUrl.match(/youtube\.com.*(\?v=|\/embed\/)(.{11})/).pop();
                }


                if (youtube_video_id != '') {
                    return true;
                }
                else {
                    alert("Please enter a valid YouTube url.");
                    return false;
                }
            }
            else if (videoUrl.indexOf("vimeo.com") != -1) {

                /*
                var match = /vimeo.*\/(\d+)/i.exec(videoUrl);
                var video_id = match[1];


                //alert(1);
                $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                data: "{id: '" + video_id + "'}",
                url: "BulletinVideoGallery.aspx/GetThumbFromVimeo",
                dataType: "json",
                success: function (data) {
                //alert(data.d);
                thumbUrl = data.d;
                //console.log(thumbUrl);
                SubmitVideoThumbUrl(thumbUrl, '');
                },
                error: function (error) {
                alert(error);
                }
                });

                */

                return true;


            } else if (videoUrl != "") {
                alert("Please enter a YouTube or Vimeo url only.");
                return false;
            }
        }
        function SubmitVideoThumbUrl(thumbUrl, youtube_video_id) {
            if (thumbUrl != '') {
                ImgDivID = parent.document.getElementById('editDivCheck').value;
                ImgDivID1 = ImgDivID;

                rootpath = '<%=RootPath %>'
                var VideUrl = document.getElementById('txtVideoUrl').value;
                var fileformat = "";
                var videoUrl = document.getElementById("<%=txtVideoUrl.ClientID %>").value;
                if (videoUrl.indexOf("youtube") != -1 || videoUrl.indexOf("youtu.be") != -1) {
                    fileformat = "youtube";
                    if (videoUrl.indexOf("youtu.be") != -1)
                        VideUrl = 'https://www.youtube.com/watch?v=' + youtube_video_id;
                }
                else if (videoUrl.indexOf("vimeo.com") != -1) {
                    fileformat = "vimeo";
                }
                else {
                    fileformat = "mp4";
                }

                var VideUrl = VideUrl + "?type=video&videoformat=" + fileformat;
                //"<img src='" + rootpath + "/Images/play_btn.png' style=\"margin-top: 90px; margin-left: 130px; position: absolute;\" >" +

                parent.document.getElementById(ImgDivID1).innerHTML = " <a  href='" + VideUrl + "' target=\"_blank\" style=\"position: relative;\" class=\"videoclass\" >" +
            "<img style='vertical-align:bottom;' src='" + thumbUrl + "' border='0' width='300px'    /></a>";

                parent.$find('VidePreview').hide();
                parent.DisableEventsForVideoBlocks();

                return true;
            }
            else {
                document.getElementById('<%=lblErrorMsg.ClientID %>').innerHTML = "The entered video is not a valid video. Please try with a different video.";
                return false;
            }
        }

        function HideModalPopup() {
            parent.$find('VidePreview').hide();
            return false;
        }

    </script>
</head>
<body class="yui-skin-sam" style="background-color: #F8F6F6;">
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="Panel1" runat="server">
            <table cellpadding="0" cellspacing="0" width="100%" style="margin-left: 30px;">
                <tr colspan="2">
                    <td style="padding-bottom: 15px;">
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center; padding-bottom: 5px;">
                        <asp:Label ID="lblErrorMsg" runat="server" Style="color: Red;"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td>
                                    <img src="../../Images/youtube.png" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="padding-top: 10px;">
                                    <b>OR </b>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <img src="../../Images/viemo.png" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <table cellpadding="0" cellspacing="0" width="100%" style="margin-left: 30px;">
                            <tr>
                                <td>
                                    <b>Enter Url: </b>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox Style="width: 390px; height: 27px; border: 1px solid #C2C2C2; padding: 8px 9px;
                                        color: #5F5F5F;" runat="server" ID="txtVideoUrl"></asp:TextBox>
                                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                                        ControlToValidate="txtVideoUrl" ValidationGroup="SV" ErrorMessage="Url is mandatory.">*</asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 20px;">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btnVideoSubmit" Text="Submit" runat="server" OnClick="btnVideoSubmit_OnClick"
                                        OnClientClick="return GetThumbUrl();" />&nbsp;
                                    <asp:Button ID="btnVideoCancel" Text="Cancel" runat="server" OnClientClick="return  HideModalPopup();" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;
                        <div id="divLoading" style="display: none;">
                            <div style="text-align: center;">
                                <img src="<%=Page.ResolveClientUrl("~/Images/Dashboard/ezSmartAjax.gif")%>" border="0" /><b><font
                                    color="green">Processing....</font></b>
                            </div>
                        </div>
                        <%-- <div style="width: 250px; margin: 0 auto;">
                            <asp:ValidationSummary ID="ValidateUserDetails" runat="server" Style="text-align: left;"
                                ValidationGroup="SV" HeaderText="The following error(s) occurred:" />
                        </div>--%>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;
                    </td>
                </tr>
            </table>
            <asp:HiddenField runat="server" ID="hdnVideoThumbUrl" />
            <asp:HiddenField runat="server" ID="hdnOrginalUrl" />
        </asp:Panel>
    </div>
    </form>
</body>
</html>
