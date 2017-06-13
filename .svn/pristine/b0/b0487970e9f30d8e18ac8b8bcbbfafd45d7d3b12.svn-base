<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNotes.aspx.cs" Inherits="USPDHUB.ProfileIframes.AddNotes" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/CSS/AjaxControlsStyles.css" rel="stylesheet" type="text/css" />    
    <style type="text/css">
        body
        {
            font-size: 13px;
            font-family: Arial;
        }
    </style>
    <script type="text/javascript">
        function RefreshParent() {
            window.parent.location.href = window.parent.location.href;
        }
    </script>
</head>
<body>
<script type="text/javascript">
    function CheckNotes() {
        var msg = '';
        if (document.getElementById('<%=TxtBxNotes.ClientID %>').value == '')
            msg = 'Please enter Verification Notes.\n';
        var actiondate = document.getElementById("<%=txtActionDate.ClientID %>").value;
        var date_regex = /^(0[1-9]|1[0-2])\/(0[1-9]|1\d|2\d|3[01])\/(19|20)\d{2}$/;
        if (actiondate != "") {
            if (!(date_regex.test(actiondate)))
                msg = msg + 'Please enter valid date for next action date.\n';
        }
        else
            msg = msg + 'Please enter next action date.\n';
        var hours = document.getElementById("<%=ddlHours.ClientID %>").value;
        var minutes = document.getElementById("<%=ddlMints.ClientID %>").value;
        if (hours == '')
            msg = msg + 'Please select hours.\n';
        if (minutes == '')
            msg = msg + 'Please select minutes.\n';
        if (document.getElementById('<%=txtNotesBy.ClientID %>').value == '')
            msg = msg + 'Please enter your name for Notes By.\n';    
        if (msg != '') {
            alert(msg);
            return false;
        }
        else
            return true;
    }
    </script>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <div id="myModal" class="reveal-modal">
        <div class="adminformwrap">
            <div style="float: 0px auto; text-align: center;">
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </div>
            <div class="clear10">
            </div>
            <div class="labeladm">
                Verification Notes</div>
            <div class="clear10">
            </div>
            <div class="txtfildwrapadm">
                <asp:TextBox ID="TxtBxNotes" runat="server" TextMode="MultiLine" CssClass="textareaadm"
                    Width="580px" Height="100px" TabIndex="1"></asp:TextBox>
                <asp:Literal ID="Literal1" runat="server"></asp:Literal></div>
            <div class="clear10">
            </div>
            <br />
            <div class="labeladm">
                Next Action Date & Time</div>
            <div class="txtfildwrapadm">
                <asp:TextBox ID="txtActionDate" runat="server" TabIndex="2" CssClass="textareaadm"></asp:TextBox>
                <cc1:CalendarExtender ID="calex" runat="server" CssClass="MyCalendar" Format="MM/dd/yyyy" TargetControlID="txtActionDate">
                </cc1:CalendarExtender>
                &nbsp;
                <asp:DropDownList ID="ddlHours" runat="server" TabIndex="3">
                    <asp:ListItem Text="Hours" Value=""></asp:ListItem>
                    <asp:ListItem Value="00"></asp:ListItem>
                    <asp:ListItem Value="01"></asp:ListItem>
                    <asp:ListItem Value="02"></asp:ListItem>
                    <asp:ListItem Value="03"></asp:ListItem>
                    <asp:ListItem Value="04"></asp:ListItem>
                    <asp:ListItem Value="05"></asp:ListItem>
                    <asp:ListItem Value="06"></asp:ListItem>
                    <asp:ListItem Value="07"></asp:ListItem>
                    <asp:ListItem Value="08"></asp:ListItem>
                    <asp:ListItem Value="09"></asp:ListItem>
                    <asp:ListItem Value="10"></asp:ListItem>
                    <asp:ListItem Value="11"></asp:ListItem>
                    <asp:ListItem Value="12"></asp:ListItem>
                    <asp:ListItem Value="13"></asp:ListItem>
                    <asp:ListItem Value="14"></asp:ListItem>
                    <asp:ListItem Value="15"></asp:ListItem>
                    <asp:ListItem Value="16"></asp:ListItem>
                    <asp:ListItem Value="17"></asp:ListItem>
                    <asp:ListItem Value="18"></asp:ListItem>
                    <asp:ListItem Value="19"></asp:ListItem>
                    <asp:ListItem Value="20"></asp:ListItem>
                    <asp:ListItem Value="21"></asp:ListItem>
                    <asp:ListItem Value="22"></asp:ListItem>
                    <asp:ListItem Value="23"></asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="ddlMints" runat="server" TabIndex="4">
                    <asp:ListItem Text="Minutes" Value=""></asp:ListItem>
                    <asp:ListItem Value="00"></asp:ListItem>
                    <asp:ListItem Value="01"></asp:ListItem>
                    <asp:ListItem Value="02"></asp:ListItem>
                    <asp:ListItem Value="03"></asp:ListItem>
                    <asp:ListItem Value="04"></asp:ListItem>
                    <asp:ListItem Value="05"></asp:ListItem>
                    <asp:ListItem Value="06"></asp:ListItem>
                    <asp:ListItem Value="07"></asp:ListItem>
                    <asp:ListItem Value="08"></asp:ListItem>
                    <asp:ListItem Value="09"></asp:ListItem>
                    <asp:ListItem Value="10"></asp:ListItem>
                    <asp:ListItem Value="11"></asp:ListItem>
                    <asp:ListItem Value="12"></asp:ListItem>
                    <asp:ListItem Value="13"></asp:ListItem>
                    <asp:ListItem Value="14"></asp:ListItem>
                    <asp:ListItem Value="15"></asp:ListItem>
                    <asp:ListItem Value="16"></asp:ListItem>
                    <asp:ListItem Value="17"></asp:ListItem>
                    <asp:ListItem Value="18"></asp:ListItem>
                    <asp:ListItem Value="19"></asp:ListItem>
                    <asp:ListItem Value="20"></asp:ListItem>
                    <asp:ListItem Value="21"></asp:ListItem>
                    <asp:ListItem Value="22"></asp:ListItem>
                    <asp:ListItem Value="23"></asp:ListItem>
                    <asp:ListItem Value="24"></asp:ListItem>
                    <asp:ListItem Value="25"></asp:ListItem>
                    <asp:ListItem Value="26"></asp:ListItem>
                    <asp:ListItem Value="27"></asp:ListItem>
                    <asp:ListItem Value="28"></asp:ListItem>
                    <asp:ListItem Value="29"></asp:ListItem>
                    <asp:ListItem Value="30"></asp:ListItem>
                    <asp:ListItem Value="31"></asp:ListItem>
                    <asp:ListItem Value="32"></asp:ListItem>
                    <asp:ListItem Value="33"></asp:ListItem>
                    <asp:ListItem Value="34"></asp:ListItem>
                    <asp:ListItem Value="35"></asp:ListItem>
                    <asp:ListItem Value="36"></asp:ListItem>
                    <asp:ListItem Value="37"></asp:ListItem>
                    <asp:ListItem Value="38"></asp:ListItem>
                    <asp:ListItem Value="39"></asp:ListItem>
                    <asp:ListItem Value="40"></asp:ListItem>
                    <asp:ListItem Value="41"></asp:ListItem>
                    <asp:ListItem Value="42"></asp:ListItem>
                    <asp:ListItem Value="43"></asp:ListItem>
                    <asp:ListItem Value="44"></asp:ListItem>
                    <asp:ListItem Value="45"></asp:ListItem>
                    <asp:ListItem Value="46"></asp:ListItem>
                    <asp:ListItem Value="47"></asp:ListItem>
                    <asp:ListItem Value="48"></asp:ListItem>
                    <asp:ListItem Value="49"></asp:ListItem>
                    <asp:ListItem Value="50"></asp:ListItem>
                    <asp:ListItem Value="51"></asp:ListItem>
                    <asp:ListItem Value="52"></asp:ListItem>
                    <asp:ListItem Value="53"></asp:ListItem>
                    <asp:ListItem Value="54"></asp:ListItem>
                    <asp:ListItem Value="55"></asp:ListItem>
                    <asp:ListItem Value="56"></asp:ListItem>
                    <asp:ListItem Value="57"></asp:ListItem>
                    <asp:ListItem Value="58"></asp:ListItem>
                    <asp:ListItem Value="59"></asp:ListItem>
                </asp:DropDownList></div>
            <div class="clear10">
            </div>
            <div class="labeladm">
            </div>
            <div class="txtfildwrapadm">
                <div style="margin-top: 10px; margin-bottom: 10px; text-align: right;">
                    <span class="labeladm" style="text-align: right">Notes By:</span>
                    <asp:TextBox ID="txtNotesBy" runat="server" CssClass="txtfildadm-small"></asp:TextBox>&nbsp;
                    <asp:Button ID="BtnNotes" runat="server" Text="Submit" OnClick="BtnNotes_Click" OnClientClick="return CheckNotes();" />
                </div>
                <div class="clear41">
                </div>
                <div class="tblwrapper">
                    <asp:Panel ID="NotesDatalist" runat="server" Style="overflow: auto; height: 300px;">
                        <asp:DataList ID="DataList_CustomerNotes" runat="server" DataKeyField="Note_ID" ForeColor="Black"
                            CellSpacing="12" Width="100%">
                            <ItemTemplate>
                                <asp:Panel ID="UpdatePanel" runat="server" Style="overflow: auto;" BackColor="Gainsboro"
                                    Width="100%">
                                    <table style="border-collapse: collapse" border="0" cellpadding="10" width="100%">
                                        <tr>
                                            <td align="right">
                                                By:
                                                <asp:Label ID="lblRepName" runat="server" ForeColor="black" Text='<%# DataBinder.Eval(Container.DataItem,"AddedBy") %>' />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="justify">
                                                <asp:Label ID="NotesText" runat="server" ForeColor="black" Text='<%# DataBinder.Eval(Container.DataItem,"Note_Text") %>' />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="Label1" runat="server" ForeColor="black" Text='<%# DataBinder.Eval(Container.DataItem,"Created_Date") %>' />
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                </asp:Panel>
                            </ItemTemplate>
                        </asp:DataList>
                    </asp:Panel>
                </div>
                <div class="clear41">
                </div>
                <div class="clear41">
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hdnNotesCnt" runat="server" />
    </form>
</body>
</html>
