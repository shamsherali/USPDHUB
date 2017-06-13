<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCPayPalEditor.ascx.cs"
    Inherits="CopyPaste_POC.UCPayPalEditor" %>
<script type="text/javascript">
    function ShowPayPalPopup(value) {
        controlID = value.id;
        $("#ids").val(controlID);
        $("#paypalPopup").css("display", "block");
        $("#popup").css("display", "block");

        // DIV HTML
        var editHTML = $("#" + controlID).html();

        editHTML = editHTML.replace("begin_of_the_skype_highlighting", "");
        editHTML = editHTML.replace("&nbsp;FREE&nbsp;", "");
        editHTML = editHTML.replace("end_of_the_skype_highlighting", "");
        editHTML = editHTML.replace("&amp;", "&");

        if (editHTML.indexOf("text-align:") == -1) {
            editHTML = editHTML.replace("\">", " text-align: left; display: block;\">");
        }

        var plainText = editHTML.replace(/<\/?[^>]+>/, '');
        plainText = plainText.replace(/<\/span>/gi, "");

        $("#<%=txtPaypalCode.ClientID %>").val(plainText.trim());
        $("#<%=txtPaypalCode.ClientID %>").focus();
    }

    function PayPalPopupSubmiteTxt() {

        //getting selected div ID
        var controlID = $("#ids").val();

        var plainText = $("#<%=txtPaypalCode.ClientID %>").val();
        if (plainText != "") {
            htmlContent = $("#htmlvalue").val().replace("</span>", "");
            plainText = plainText.replace(/\n/gi, "<br/>");

            if (htmlContent == "") {
                htmlContent = "<span style='font-weight: normal; font-style: normal; text-decoration: none; color: black; font-size: 16px; font-family: " + document.getElementById('<%=hdnUserFont.ClientID %>').value + "; text-align: left; display: block;'>";
            }

            //alert(document.getElementById('<%=hdnUserFont.ClientID %>').value);
            htmlContent = htmlContent + plainText + "</span>";

            htmlContent = htmlContent.replace("&yen;", "")

            // // DIV HTML
            $("#" + controlID).html("");
            $("#" + controlID).html(htmlContent);

            $("#paypalPopup").css("display", "none");
            $("#popup").css("display", "none");

            // For use IDS are store
            $("#htmlvalue").val("");
        }
        else {
            alert("Please enter the text.");
        }

        return false;
    }

    function CancelPayPalEditText() {
        $("#paypalPopup").css("display", "none");
        $("#popup").css("display", "none");
        // For use IDS are store
        $("#htmlvalue").val("");
        return false;
    }

</script>
<table cellpadding="0" cellspacing="0" style="border: 1px solid #EEECEC; background-color: #F8F6F6;">
    <tbody>
        <tr>
            <td align="right" style="padding: 5px 10px 0px 10px;">
                <asp:ImageButton ID="imcloseeditpopup" runat="server" OnClientClick="return CancelPayPalEditText();"
                    ImageUrl="images/popup_close.gif" />
            </td>
        </tr>
        <tr>
            <td style="padding: 10px;">
                <table>
                    <tr>
                        <td>
                            <asp:TextBox runat="server" TextMode="MultiLine" Width="500px" ID="txtPaypalCode"
                                Height="100px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="padding-bottom: 5px; padding-right: 10px; text-align: right;">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClientClick="return PayPalPopupSubmiteTxt();" />
            </td>
        </tr>
    </tbody>
</table>
<asp:HiddenField ID="hdnUserFont" runat="server" Value="Arial" />
