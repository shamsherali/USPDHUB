<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testform.aspx.cs" Inherits="USPDHUB.Business.MyAccount.testform" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
     <link href="../../css/feeds.css" media="all" type="text/css" rel="stylesheet">
     <script type="text/javascript">
         function EmailCode() {
             var feedCode = 'test';
             var toEmail = 'malli.nookala@gmail.com';
             var subject = 'test subject';
             var description = 'test description';
             $.ajax({
                 type: "POST",
                 url: "WebWidget.aspx/EmailHTMLCode",
                 data: "{'toEmail': '" + toEmail + "','feedCode': '" + feedCode + "','subject': '" + subject + "','description':'" + description + "'}",
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: fnsuccesscallback,
                 error: fnerrorcallback
             });
         }
         function fnsuccesscallback(data) {
             alert(data.d);
         }
         function fnerrorcallback(result) {
            
         }
     </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="send">
            <a href="javascript:EmailCode()" class="livebox" style="text-decoration: none;">Send</a>
        </div>
    </div>
    </form>
</body>
</html>
