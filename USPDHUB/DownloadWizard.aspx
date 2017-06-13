<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DownloadWizard.aspx.cs"
    Inherits="USPDHUB.DownloadWizard" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Expires" content="0" />
    <meta http-equiv="Cache-Control" content="no-cache" />
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="CSS/wowzzy_newcss.css" rel="stylesheet" type="text/css" />
    <link href="css/dashboard.css" rel="stylesheet" type="text/css" />
    <link href="~/CSS/Calendar.css" rel="stylesheet" type="text/css" />
    <link href="css/popupcss.css" rel="stylesheet" type="text/css" />
    <link href="css/Menu.css" rel="stylesheet" type="text/css" />
    <link href="css/DashboardMenu.css" rel="stylesheet" type="text/css" />
    <link href="css/AjaxControlsStyles.css" rel="stylesheet" type="text/css" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <script type="text/javascript" src="../../Scripts/ModalPopups.js" language="javascript"></script>
</head>
<body style="background-color: #E5E5E5;">
    <link rel="icon" href="images/<%=DomainName %>fav.ico" type="image/x-icon" />
    <link rel="shortcut icon" href="images/<%=DomainName %>fav.ico" type="image/x-icon" />
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" AsyncPostBackTimeout="1000">
    </asp:ScriptManager>
    <div>
        <!-- *** Start of Header Menu -->
        <div id="navwrapper">
            <div id="logo">
                <img src="<%=LogoName%>" /></div>
            <!-- *** End of Header Menu -->
            <div class="clear">
            </div>
            <div id="contentwrapper">
                <!--box starts-->
                <div id="innertop" style="margin-top: 35px;">
                </div>
                <div id="innermidbg">
                    <%--  download installer--%>
                    <table>
                        <tr>
                            <td>
                                <img src="images/exedownload.png" width="100px" />
                            </td>
                            <td>
                                <b>Download the inSchoolALERT Wizard Setup file </b>
                                <br />
                                <asp:LinkButton ID="lnkDownload" runat="server" OnClick="lnkDownload_Click"> <img src="images/dashboard/donwloadcontent.png" style="cursor: arrow;" /></asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="innerbottom">
                </div>
            </div>
            <div class="clear">
            </div>
            <div>
            </div>
        </div>
    </form>
</body>
</html>
