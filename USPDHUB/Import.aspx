<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Import.aspx.cs" Inherits="USPDHUB.Import" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <%--<asp:FileUpload ID="FileUpload1" runat="server"></asp:FileUpload>&nbsp;<asp:Button
            ID="CSVSubmit" OnClick="CSVSubmit_Click" runat="server" Text="Upload" CssClass="bold"
            CausesValidation="False"></asp:Button>--%>
        <table>
            <colgroup>
                <col width="50%" />
                <col width="*" />
            </colgroup>
            <tr>
                <td valign="top">
                    <asp:TextBox ID="txtImport" runat="server" Width="100%" Height="800px" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td style="padding-left:10px;">
                    <asp:Literal ID="ltrHtml" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>
        <asp:Button ID="CSVSubmitq" OnClick="CSVSubmit1_Click" runat="server" Text="Upload"
            CssClass="bold" CausesValidation="False"></asp:Button>
    </div>
    </form>
</body>
</html>
