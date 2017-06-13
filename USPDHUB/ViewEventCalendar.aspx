<%@ Page Language="C#" AutoEventWireup="true" Inherits="ViewEventCalendar" Codebehind="ViewEventCalendar.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <script type="text/javascript">
         function CloseWindow() {
             var Browsername = navigator.appName;
             if (Browsername == "Netscape") {
                 var is_chrome = navigator.userAgent.toLowerCase().indexOf('chrome') > -1;
                 if (is_chrome == false) {
                     //netscape.security.PrivilegeManager.enablePrivilege("UniversalBrowserWrite");
                 }
             }
             window.open('', '_self', '');
             window.close();
         }
        </script>
</head>
<body>
    <form id="form1" runat="server">
     <table cellspacing="0" cellpadding="0" width="100%" border="0" style="font-family: Arial, Helvetica, sans-serif;
        font-size: 13px;">
        <tbody>
            <tr>
                <td>
                    <table style="padding-right: 10px; padding-left: 10px; padding-bottom: 5px; padding-top: 5px"
                        cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tbody>
                            <tr style="padding-top: 20px">
                                <td valign="top">
                                    <%=EventPreview%>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </tbody>
    </table>
    </form>
</body>
</html>
