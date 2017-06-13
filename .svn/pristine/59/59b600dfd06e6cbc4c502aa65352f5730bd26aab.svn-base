<%@ Page Language="C#" AutoEventWireup="true" Inherits="Business_MyAccount_PrintNewsletter"
    CodeBehind="Printer.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> </title>
    <style type="text/css">
        @media print
        {
            input
            {
                display: none;
            }
            #lblPreview
            {
                display: none;
            }
            #titlebar
            {
                display: none;
            }
            #ad
            {
                display: none;
            }
            #leftbar
            {
                display: none;
            }
            #header
            {
                display: none;
            }
            #lnkPrint
            {
                display: none;
            }
            #footer
            {
                display: none;
            }
            #Img
            {
                display: block;
            }
        }
        .preview
        {
            display: none;
        }
    </style>
</head>
<body onload="javascript:window.print();" style="background-color: #FFF;">
    <form id="form1" runat="server">
    <div>
        <asp:LinkButton ID="lnkPrint" runat="server" OnClick="lnkPrint_Click">Print</asp:LinkButton><br />
        <br />
    </div>
    <br />
    <div style="margin:0px;">
        <asp:Label ID="lblprintnewletter" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
