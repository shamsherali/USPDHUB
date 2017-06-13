<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintMessageDetails.aspx.cs"
    Inherits="USPDHUB.Business.MyAccount.PrintMessageDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../css/Bulletins.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <script src="../../Scripts/flyers/jquery-1.7.2.js" type="text/javascript"></script>
    <div id="wrapper">
        <div style="text-align: center;">
            <asp:Label ID="lblerror" runat="server"></asp:Label>
            <div style="width: 350px; margin: 0 auto;">
            </div>
        </div>
        <div class="clear">
        </div>
        <div class="contentwrap">
            <div class="largetxt">
                Message Details
                <asp:Label runat="server" ID="lblSubject" Style="display: none;" Font-Bold="true"></asp:Label>
            </div>
            <div class="form_wrapper" style="width: 860px;">
                <div class="clear">
                </div>
                <div class="fields_wrap">
                    <div class="clear">
                    </div>
                    <label style="color: Red; font-size: 16px; margin-left: 100px;">
                    </label>
                    <table cellpadding="0" cellspacing="0" border="0" width="70%" align="center">
                        <tr>
                            <td align="right">
                                <a href="javascript:window.print();">
                                    <img src="../../images/OuterImages/printlabel.gif" border="0" /></a>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
                <div class="clear10">
                </div>
                <div class="fields_wrap ">
                    <div class="left_lable">
                        <span style="padding-left: 2px;">&nbsp;</span><label>
                    </div>
                    <div class="right_fields">
                        <asp:Label runat="server" ID="lblMessage" Font-Size="Medium" Visible="false" Text="Your message has been sent successfully."
                            Font-Bold="true" ForeColor="Green"></asp:Label>
                    </div>
                </div>
                <div class="clear">
                </div>
                <div class="clear10">
                </div>
                <div class="fields_wrap ">
                    <div class="left_lable">
                        <span style="padding-left: 2px;">&nbsp;</span><label>
                            <label>
                                Contact Name:</label></div>
                    <div class="right_fields">
                        <asp:Label runat="server" ID="lblContactName"></asp:Label>
                    </div>
                </div>
                <div class="clear">
                </div>
                <div class="fields_wrap ">
                    <div class="left_lable">
                        <span style="padding-left: 2px;">&nbsp;</span><label>
                            Contact EmailID:</label></div>
                    <div class="right_fields">
                        <asp:Label runat="server" ID="lblContactEmailID"></asp:Label>
                    </div>
                </div>
                <div class="clear">
                </div>
                <div class="fields_wrap ">
                    <div class="left_lable">
                        <span style="padding-left: 2px;">&nbsp;</span><label>
                            Phone Number:</label></div>
                    <div class="right_fields">
                        <asp:Label runat="server" ID="lblPhoneNumber"></asp:Label>
                    </div>
                </div>
                <div class="clear">
                </div>
                <div class="clear10">
                </div>
                <div class="fields_wrap ">
                    <div class="left_lable">
                        <span style="padding-left: 2px;">&nbsp;</span><label>
                            Message Date & Time:</label></div>
                    <div class="right_fields">
                        <asp:Label runat="server" ID="lblMessageDate"></asp:Label>
                    </div>
                </div>
                <div class="clear">
                </div>
                <div class="fields_wrap ">
                    <div class="left_lable">
                        <span style="padding-left: 2px;">&nbsp;</span><label>
                            Custom Message:</label></div>
                    <div class="right_fields">
                        <asp:Label runat="server" ID="lblCustomMessage"></asp:Label>
                    </div>
                </div>
                <div class="clear">
                </div>
                <div class="clear10">
                </div>
                <div class="fields_wrap ">
                    <div class="left_lable">
                        <span style="padding-left: 2px;">&nbsp;</span><label>
                            Device Location:</label></div>
                    <div class="right_fields">
                        <asp:Label runat="server" ID="lblLocation"></asp:Label>
                    </div>
                </div>
                <div class="clear">
                </div>
                <div class="clear10">
                </div>
                <%if (lblQRLocation.Text != "")
                  { %>
                <div class="fields_wrap ">
                    <div class="left_lable">
                        <span style="padding-left: 2px;">&nbsp;</span><label>
                            QR Location:</label></div>
                    <div class="right_fields">
                        <asp:Label runat="server" ID="lblQRLocation"></asp:Label>
                    </div>
                </div>
                <div class="clear">
                </div>
                <div class="clear10">
                </div>
                <%} %>
                <%if (ButtonType == USPDHUBBLL.ButtonTypes.PrivateSmartConnect)
                  {%>
                <div class="fields_wrap ">
                    <div class="left_lable">
                        <span style="padding-left: 2px;">&nbsp;</span><label>
                            Proximity:</label></div>
                    <div class="right_fields">
                        <asp:Label runat="server" ID="lblIsApproximateDistance"></asp:Label>
                    </div>
                </div>
                <div class="clear">
                </div>
                <div class="clear10">
                </div>
                <%} %>
                <div class="fields_wrap ">
                    <div class="left_lable">
                        <span style="padding-left: 2px;">&nbsp;</span><label>
                            Tab Name:</label></div>
                    <div class="right_fields">
                        <asp:Label runat="server" ID="lblTabName"></asp:Label>
                    </div>
                </div>
                <div class="clear">
                </div>
                <div class="clear10">
                </div>
                <%if (ButtonType == USPDHUBBLL.ButtonTypes.PrivateCall
                      || ButtonType == USPDHUBBLL.ButtonTypes.SmartConnect
                      || ButtonType == USPDHUBBLL.ButtonTypes.PrivateSmartConnect)
                  {%>
                <div class="fields_wrap ">
                    <div class="left_lable">
                        <span style="padding-left: 2px;">&nbsp;</span><label>
                            Button Name:</label></div>
                    <div class="right_fields">
                        <asp:Label runat="server" ID="lblItemTitle"></asp:Label>
                    </div>
                </div>
                <%} %>
                <div class="clear">
                </div>
                <div class="clear10">
                </div>
                <%if (!(string.IsNullOrEmpty(lblCategoryName.Text.Trim())) && (ButtonType == USPDHUBBLL.ButtonTypes.SmartConnect
                                  || ButtonType == USPDHUBBLL.ButtonTypes.PrivateSmartConnect))
                  { %>
                <div class="fields_wrap ">
                    <div class="left_lable">
                        <span style="padding-left: 2px;">&nbsp;</span><label>
                            Category:</label></div>
                    <div class="right_fields">
                        <asp:Label runat="server" ID="lblCategoryName"></asp:Label>
                    </div>
                </div>
                <div class="clear">
                </div>
                <div class="clear10">
                </div>
                <%} %>
                <div class="fields_wrap ">
                    <div class="left_lable">
                        <span style="padding-left: 2px;">&nbsp;</span><label>
                            Reference ID:</label></div>
                    <div class="right_fields">
                        <asp:Label runat="server" ID="lblRefID"></asp:Label>
                    </div>
                </div>
                <div class="clear">
                </div>
                <div class="clear10">
                </div>
                <%if (ImageName != "")
                  { %>
                <div class="fields_wrap ">
                    <div class="left_lable">
                    </div>
                    <div class="right_fields">
                        <asp:Label runat="server" ID="lblImage"></asp:Label>
                    </div>
                </div>
                <%} %>
                <div class="clear">
                </div>
                <div class="clear10">
                </div>
                <div class="fields_wrap">
                    <div class="left_lable">
                    </div>
                </div>
                <div class="fields_wrap ">
                    <div class="left_lable">
                    </div>
                    <div class="right_fields" style="margin: 10px 0px 0px 0px; width: 450px;">
                        <asp:HiddenField runat="server" ID="hdnImageName" />
                        <asp:HiddenField runat="server" ID="hdnEmailIds" />
                        <asp:HiddenField runat="server" ID="hdnAssociateUsers" />
                    </div>
                </div>
                <div class="clear">
                </div>
                <div class="clear10">
                </div>
                <div class="fields_wrap ">
                    <div class="right_fields" style="margin: 10px 0px 0px 50px; width: 800px;">
                        <asp:DataList ID="DLNotes" runat="server" DataKeyField="ReplyHistoryID" ForeColor="Black"
                            CellSpacing="12" Width="100%">
                            <ItemTemplate>
                                <asp:Panel ID="UpdatePanel" runat="server" Style="overflow: auto;" BackColor="Gainsboro"
                                    Width="100%">
                                    <table style="border-collapse: collapse" border="0" cellpadding="10" width="80%">
                                        <tr>
                                            <td align="justify" colspan="2">
                                                <asp:Label ID="NotesText" runat="server" ForeColor="black" Text='<%# DataBinder.Eval(Container.DataItem,"Notes") %>' />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                Notes By:
                                                <asp:Label ID="lblRepName" runat="server" ForeColor="black" Text='<%# DataBinder.Eval(Container.DataItem,"NotesByUser") %>' />
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="Label1" runat="server" ForeColor="black" Text='<%#  DataBinder.Eval(Container.DataItem,"CreatedDate","{0:MM/dd/yyyy hh:mm tt}") %>' />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </ItemTemplate>
                        </asp:DataList>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            window.print();
        });
    </script>
    </form>
</body>
</html>
