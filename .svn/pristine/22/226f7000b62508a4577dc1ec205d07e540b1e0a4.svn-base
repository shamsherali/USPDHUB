<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RepeatEvents.aspx.cs" Inherits="USPDHUB.RepeatEvents" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/flyers/jquery-1.7.2.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="stepswrap1">
            <div class="fields_wrap">
                <div class="right_fields">
                    <table class="border" width="100%" cellpadding="5">
                        <colgroup>
                            <col width="40%" />
                            <col width="*" />
                        </colgroup>
                        <tr>
                            <td class="lable" valign="top">
                                <span style="color: Red; font-size: 16px; vertical-align: middle;">*</span> Event
                                Start Date & Time
                            </td>
                            <td align="left">
                                <table border="0" cellpadding="0" cellspacing="0" width="135%">
                                    <tr>
                                        <td valign="top" align="left">
                                            <asp:TextBox ID="txtStartDate" runat="server" TabIndex="2" ValidationGroup="group"
                                                Width="100px" onChange="ShowDateTimeDiv('1');"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" SetFocusOnError="true" runat="server"
                                                ControlToValidate="txtStartDate" ValidationGroup="group" Text="*" ErrorMessage="Please enter Event Start Date."></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularDate" runat="server" ControlToValidate="txtStartDate"
                                                Display="Dynamic" ErrorMessage="Invalid Date Format" SetFocusOnError="True" ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                                ValidationGroup="group"></asp:RegularExpressionValidator>
                                        </td>
                                        <td valign="top">
                                            <asp:TextBox runat="server" ID="txtStrHours" Width="50px" Enabled="false" MaxLength="2"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" Display="Dynamic"
                                                ControlToValidate="txtStrHours" ValidationExpression="^[0-9]*$" ValidationGroup="group"
                                                ErrorMessage="Invalid Start Time">*</asp:RegularExpressionValidator>
                                            &nbsp;
                                            <asp:TextBox runat="server" ID="txtStrMins" Width="50px" Enabled="false" MaxLength="2"></asp:TextBox>
                                            
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" Display="Dynamic"
                                                ControlToValidate="txtStrMins" ValidationExpression="^[0-5]*$" ValidationGroup="group"
                                                ErrorMessage="Invalid Start Time">*</asp:RegularExpressionValidator>
                                        </td>
                                        <td valign="top" style="padding: 1px;">
                                            <asp:DropDownList runat="server" ID="ddlStrAPM" Enabled="false" Width="60px" Height="23px">
                                                <asp:ListItem Text="AM" Value="AM" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="lable" nowrap valign="top" style="padding-top: 2px;">
                                <span style="color: Red; font-size: 16px; vertical-align: middle;">*</span> Event
                                End Date & Time&nbsp;
                            </td>
                            <td>
                                <table border="0" cellpadding="0" cellspacing="0" width="137%">
                                    <tr>
                                        <td valign="top">
                                            <asp:TextBox ID="txtEndDate" runat="server" TabIndex="2" ValidationGroup="group"
                                                Width="100px" onChange="ShowDateTimeDiv('2');"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEndDate"
                                                ValidationGroup="group" SetFocusOnError="true" Display="Dynamic" Text="*" ErrorMessage="Please enter Event End Date."></asp:RequiredFieldValidator>
                                            <br />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" SetFocusOnError="true"
                                                runat="server" ControlToValidate="txtEndDate" Display="Dynamic" ErrorMessage="Invalid Date Format"
                                                ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                                ValidationGroup="group"></asp:RegularExpressionValidator>
                                        </td>
                                        <td valign="top">
                                            <asp:TextBox runat="server" ID="txtEndHours" Width="50px" Enabled="false" MaxLength="2"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" Display="Dynamic"
                                                ControlToValidate="txtEndHours" ValidationExpression="^[0-9]*$" ValidationGroup="group"
                                                ErrorMessage="Invalid End Time">*</asp:RegularExpressionValidator>
                                            &nbsp;
                                            <asp:TextBox runat="server" ID="txtEndMins" Width="50px" Enabled="false" MaxLength="2"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" Display="Dynamic"
                                                ControlToValidate="txtEndMins" ValidationExpression="^[0-5]*$" ValidationGroup="group"
                                                ErrorMessage="Invalid End Time">*</asp:RegularExpressionValidator>
                                        </td>
                                        <td valign="top" style="padding: 1px;">
                                            <asp:DropDownList runat="server" ID="ddlEndAPM" Enabled="false" Width="60px" Height="23px">
                                                <asp:ListItem Text="AM" Value="AM" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:CheckBox ID="chkRepeat" runat="server" OnClick="ShowRepeat(this);" />
                                Repeat
                                <asp:HiddenField ID="hdnAlreadyRepeat" runat="server" Value="0" />
                                <asp:HiddenField ID="hdn3Items" runat="server" />
                                <asp:HiddenField ID="hdnEndOn" runat="server" />
                                <asp:HiddenField ID="hdnRepeatOn" runat="server" />
                                <asp:HiddenField ID="hdn3Itemsold" runat="server" />
                                <asp:HiddenField ID="hdnEndOnold" runat="server" />
                                <asp:HiddenField ID="hdnRepeatOnold" runat="server" />
                                <div id="divRepeat" style="display: none;">
                                    <table>
                                        <tbody>
                                            <tr>
                                                <th>
                                                    Repeats:
                                                </th>
                                                <td>
                                                    <select id="my_select">
                                                        <option value="0" id="0" title="Daily">Daily</option>
                                                        <option value="1" id="1" title="Weekly">Weekly</option>
                                                        <option value="2" id="2" title="Monthly">Monthly</option>
                                                        <option value="3" id="3" title="Yearly">Yearly</option>
                                                    </select>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <div id="divDaily">
                                        <table>
                                            <tbody>
                                                <tr>
                                                    <th>
                                                        Repeat every:
                                                    </th>
                                                    <td>
                                                        <select id="Select0">
                                                            <option value="1">1</option>
                                                            <option value="2">2</option>
                                                            <option value="3">3</option>
                                                            <option value="4">4</option>
                                                            <option value="5">5</option>
                                                            <option value="6">6</option>
                                                            <option value="7">7</option>
                                                            <option value="8">8</option>
                                                            <option value="9">9</option>
                                                            <option value="10">10</option>
                                                            <option value="11">11</option>
                                                            <option value="12">12</option>
                                                            <option value="13">13</option>
                                                            <option value="14">14</option>
                                                            <option value="15">15</option>
                                                            <option value="16">16</option>
                                                            <option value="17">17</option>
                                                            <option value="18">18</option>
                                                            <option value="19">19</option>
                                                            <option value="20">20</option>
                                                            <option value="21">21</option>
                                                            <option value="22">22</option>
                                                            <option value="23">23</option>
                                                            <option value="24">24</option>
                                                            <option value="25">25</option>
                                                            <option value="26">26</option>
                                                            <option value="27">27</option>
                                                            <option value="28">28</option>
                                                            <option value="29">29</option>
                                                            <option value="30">30</option>
                                                        </select>
                                                        <label>
                                                            days</label>
                                                    </td>
                                                </tr>
                                                <tr tabindex="0">
                                                    <th id=":2s.rstart-label">
                                                        Starts on:
                                                    </th>
                                                    <td>
                                                        <input id="0Start" size="10" disabled="" autocomplete="off">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th class="ep-rec-ends-th">
                                                        Ends:
                                                    </th>
                                                    <td>
                                                        <span class="ep-rec-ends-opt">
                                                            <input id="radio0ccurances" type="radio" title="Ends after a number of occurrences"
                                                                checked="checked" name="radi0" onclick="ChangeEnds('0','1','5','');">
                                                            <label title="Ends after a number of occurrences" for=":2s.endson_count">
                                                                After
                                                                <input id="txt0occurance" title="Occurrences" value="5" size="3">
                                                                occurrences
                                                            </label>
                                                        </span><span class="ep-rec-ends-opt">
                                                            <input id="radio0until" type="radio" title="Ends on a specified date" name="radi0"
                                                                onclick="ChangeEnds('0','2','','');">
                                                            <label title="Ends on a specified date" for=":2s.endson_until">
                                                                On
                                                                <input id="txt0until" title="Specified date" disabled="" value="" size="10" autocomplete="off">
                                                            </label>
                                                        </span>
                                                    </td>
                                                </tr>
                                                <tr id=":2s.recsummary" tabindex="0">
                                                    <th>
                                                        Summary:
                                                    </th>
                                                    <td class="ep-rec-summary">
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                    <div id="divWeekly" style="display: none;">
                                        <table>
                                            <tbody>
                                                <tr>
                                                    <th>
                                                        Repeat every:
                                                    </th>
                                                    <td>
                                                        <select id="Select1">
                                                            <option value="1">1</option>
                                                            <option value="2">2</option>
                                                            <option value="3">3</option>
                                                            <option value="4">4</option>
                                                            <option value="5">5</option>
                                                            <option value="6">6</option>
                                                            <option value="7">7</option>
                                                            <option value="8">8</option>
                                                            <option value="9">9</option>
                                                            <option value="10">10</option>
                                                            <option value="11">11</option>
                                                            <option value="12">12</option>
                                                            <option value="13">13</option>
                                                            <option value="14">14</option>
                                                            <option value="15">15</option>
                                                            <option value="16">16</option>
                                                            <option value="17">17</option>
                                                            <option value="18">18</option>
                                                            <option value="19">19</option>
                                                            <option value="20">20</option>
                                                            <option value="21">21</option>
                                                            <option value="22">22</option>
                                                            <option value="23">23</option>
                                                            <option value="24">24</option>
                                                            <option value="25">25</option>
                                                            <option value="26">26</option>
                                                            <option value="27">27</option>
                                                            <option value="28">28</option>
                                                            <option value="29">29</option>
                                                            <option value="30">30</option>
                                                        </select>
                                                        <label>
                                                            weeks</label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>
                                                        Repeat on:
                                                    </th>
                                                    <td id=":2l.checkboxes">
                                                        <div>
                                                            <span class="ep-rec-dow">
                                                                <input id="chkSUN" value="1" type="checkbox" title="Sunday" aria-label="Repeat on Sunday"
                                                                    name="SU">
                                                                <label title="Sunday" for=":2l.dow0">
                                                                    S</label>
                                                            </span><span class="ep-rec-dow">
                                                                <input id=":chkMON" value="2" type="checkbox" title="Monday" aria-label="Repeat on Monday"
                                                                    name="MO">
                                                                <label title="Monday" for=":2l.dow1">
                                                                    M</label>
                                                            </span><span class="ep-rec-dow">
                                                                <input id="chkTUE" value="3" type="checkbox" title="Tuesday" aria-label="Repeat on Tuesday"
                                                                    name="TU">
                                                                <label title="Tuesday" for=":2l.dow2">
                                                                    T</label>
                                                            </span><span class="ep-rec-dow">
                                                                <input id="chkWED" value="4" type="checkbox" title="Wednesday" aria-label="Repeat on Wednesday"
                                                                    name="WE">
                                                                <label title="Wednesday" for=":2l.dow3">
                                                                    W</label>
                                                            </span><span class="ep-rec-dow">
                                                                <input id="chkTHU" value="5" type="checkbox" title="Thursday" aria-label="Repeat on Thursday"
                                                                    name="TH">
                                                                <label title="Thursday" for=":2l.dow4">
                                                                    T</label>
                                                            </span><span class="ep-rec-dow">
                                                                <input id="chkFRI" value="6" type="checkbox" title="Friday" aria-label="Repeat on Friday"
                                                                    name="FR">
                                                                <label title="Friday" for=":2l.dow5">
                                                                    F</label>
                                                            </span><span class="ep-rec-dow">
                                                                <input id="chkSAT" value="7" type="checkbox" title="Saturday" aria-label="Repeat on Saturday"
                                                                    name="SA">
                                                                <label title="Saturday" for=":2l.dow6">
                                                                    S</label>
                                                            </span>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr tabindex="0">
                                                    <th id=":2l.rstart-label">
                                                        Starts on:
                                                    </th>
                                                    <td>
                                                        <input id="1Start" size="10" disabled="" aria-labelledby=":2l.rstart-label" autocomplete="off">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th class="ep-rec-ends-th">
                                                        Ends:
                                                    </th>
                                                    <td>
                                                        <span class="ep-rec-ends-opt">
                                                            <input id="radio1occurance" type="radio" title="Ends after a number of occurrences"
                                                                checked="checked" name="radio1" onclick="ChangeEnds('1','1','5','');">
                                                            <label title="Ends after a number of occurrences" for=":2l.endson_count">
                                                                After
                                                                <input id="txt1occurance" title="Occurrences" value="5" size="3">
                                                                occurrences
                                                            </label>
                                                        </span><span class="ep-rec-ends-opt">
                                                            <input id="radio1until" type="radio" title="Ends on a specified date" name="radio1"
                                                                onclick="ChangeEnds('1','2','','');">
                                                            <label title="Ends on a specified date" for=":2l.endson_until">
                                                                On
                                                                <input id="txt1until" title="Specified date" disabled="" value="" size="10" autocomplete="off">
                                                            </label>
                                                        </span>
                                                    </td>
                                                </tr>
                                                <tr id=":2l.recsummary" tabindex="0">
                                                    <th>
                                                        Summary:
                                                    </th>
                                                    <td class="ep-rec-summary">
                                                        Weekly on Thursday
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                    <div id="divMonthly" style="display: none;">
                                        <table>
                                            <tbody>
                                                <tr>
                                                    <th>
                                                        Repeat every:
                                                    </th>
                                                    <td>
                                                        <select id="Select2">
                                                            <option value="1">1</option>
                                                            <option value="2">2</option>
                                                            <option value="3">3</option>
                                                            <option value="4">4</option>
                                                            <option value="5">5</option>
                                                            <option value="6">6</option>
                                                            <option value="7">7</option>
                                                            <option value="8">8</option>
                                                            <option value="9">9</option>
                                                            <option value="10">10</option>
                                                            <option value="11">11</option>
                                                            <option value="12">12</option>
                                                            <option value="13">13</option>
                                                            <option value="14">14</option>
                                                            <option value="15">15</option>
                                                            <option value="16">16</option>
                                                            <option value="17">17</option>
                                                            <option value="18">18</option>
                                                            <option value="19">19</option>
                                                            <option value="20">20</option>
                                                            <option value="21">21</option>
                                                            <option value="22">22</option>
                                                            <option value="23">23</option>
                                                            <option value="24">24</option>
                                                            <option value="25">25</option>
                                                            <option value="26">26</option>
                                                            <option value="27">27</option>
                                                            <option value="28">28</option>
                                                            <option value="29">29</option>
                                                            <option value="30">30</option>
                                                        </select>
                                                        <label>
                                                            months</label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>
                                                        Repeat by:
                                                    </th>
                                                    <td>
                                                        <span class="">
                                                            <input id=":2y.domrepeat" type="radio" title="Repeat by day of the month" aria-label="Repeat by day of the month"
                                                                checked="" name="repeatby">
                                                            <label title="Repeat by day of the month" for=":2y.domrepeat">
                                                                day of the month</label>
                                                        </span><span class="">
                                                            <input id=":2y.dowrepeat" type="radio" title="Repeat by day of the week" aria-label="Repeat by day of the week"
                                                                name="repeatby">
                                                            <label title="Repeat by day of the week" for=":2y.dowrepeat">
                                                                day of the week</label>
                                                        </span>
                                                    </td>
                                                </tr>
                                                <tr tabindex="0">
                                                    <th id=":2y.rstart-label">
                                                        Starts on:
                                                    </th>
                                                    <td>
                                                        <input id="2Start" size="10" disabled="" aria-labelledby=":2y.rstart-label" autocomplete="off">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th class="ep-rec-ends-th">
                                                        Ends:
                                                    </th>
                                                    <td>
                                                        <span class="ep-rec-ends-opt">
                                                            <input id="radio2occurance" type="radio" title="Ends after a number of occurrences"
                                                                checked="checked" name="radio2" onclick="ChangeEnds('2','1','5','');">
                                                            <label title="Ends after a number of occurrences" for=":2y.endson_count">
                                                                After
                                                                <input id="txt2occurance" title="Occurrences" value="5" size="3">
                                                                occurrences
                                                            </label>
                                                        </span><span class="ep-rec-ends-opt">
                                                            <input id="radio2until" type="radio" title="Ends on a specified date" aria-label="Ends on a specified date"
                                                                name="radio2" onclick="ChangeEnds('2','2','','');">
                                                            <label title="Ends on a specified date" for=":2y.endson_until">
                                                                On
                                                                <input id="txt2until" title="Specified date" disabled="" value="" size="10" autocomplete="off">
                                                            </label>
                                                        </span>
                                                    </td>
                                                </tr>
                                                <tr id=":2y.recsummary" tabindex="0">
                                                    <th>
                                                        Summary:
                                                    </th>
                                                    <td class="ep-rec-summary">
                                                        Monthly on day 4
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                    <div id="divYearly" style="display: none;">
                                        <table>
                                            <tbody>
                                                <tr>
                                                    <th>
                                                        Repeat every:
                                                    </th>
                                                    <td>
                                                        <select id="Select3">
                                                            <option value="1">1</option>
                                                            <option value="2">2</option>
                                                            <option value="3">3</option>
                                                            <option value="4">4</option>
                                                            <option value="5">5</option>
                                                            <option value="6">6</option>
                                                            <option value="7">7</option>
                                                            <option value="8">8</option>
                                                            <option value="9">9</option>
                                                            <option value="10">10</option>
                                                            <option value="11">11</option>
                                                            <option value="12">12</option>
                                                            <option value="13">13</option>
                                                            <option value="14">14</option>
                                                            <option value="15">15</option>
                                                            <option value="16">16</option>
                                                            <option value="17">17</option>
                                                            <option value="18">18</option>
                                                            <option value="19">19</option>
                                                            <option value="20">20</option>
                                                            <option value="21">21</option>
                                                            <option value="22">22</option>
                                                            <option value="23">23</option>
                                                            <option value="24">24</option>
                                                            <option value="25">25</option>
                                                            <option value="26">26</option>
                                                            <option value="27">27</option>
                                                            <option value="28">28</option>
                                                            <option value="29">29</option>
                                                            <option value="30">30</option>
                                                        </select>
                                                        <label>
                                                            years</label>
                                                    </td>
                                                </tr>
                                                <tr tabindex="0">
                                                    <th id=":3n.rstart-label">
                                                        Starts on:
                                                    </th>
                                                    <td>
                                                        <input id="3Start" size="10" disabled="" aria-labelledby=":3n.rstart-label" autocomplete="off">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th class="ep-rec-ends-th">
                                                        Ends:
                                                    </th>
                                                    <td>
                                                        <span class="ep-rec-ends-opt">
                                                            <input id="radio3occurance" type="radio" title="Ends after a number of occurrences"
                                                                checked="checked" name="radio3" onclick="ChangeEnds('3','1','5','');">
                                                            <label title="Ends after a number of occurrences" for=":3n.endson_count">
                                                                After
                                                                <input id="txt3occurance" title="Occurrences" value="5" size="3">
                                                                occurrences
                                                            </label>
                                                        </span><span class="ep-rec-ends-opt">
                                                            <input id="radio3until" type="radio" title="Ends on a specified date" aria-label="Ends on a specified date"
                                                                name="radio3" onclick="ChangeEnds('3','2','','');">
                                                            <label title="Ends on a specified date" for=":3n.endson_until">
                                                                On
                                                                <input id="txt3until" title="Specified date" disabled="" value="" size="10" autocomplete="off">
                                                            </label>
                                                        </span>
                                                    </td>
                                                </tr>
                                                <tr id=":3n.recsummary" tabindex="0">
                                                    <th>
                                                        Summary:
                                                    </th>
                                                    <td class="ep-rec-summary">
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function ShowPublish(val, type) {
            if (type == "1")
                BindRepeatDetails();
        }
        function BindRepeatDetails() {
            $("#divRepeat").show();
            if (document.getElementById('<%=hdnAlreadyRepeat.ClientID %>').value == "1") {
                $("#divDaily").hide(); $("#divWeekly").hide(); $("#divMonthly").hide(); $("#divYearly").hide();
                // *** Binding Repeats, Repeat Every and StartsOn *** //
                var repeats = document.getElementById('<%=hdn3Itemsold.ClientID %>').value.split("##SP##");
                var id = repeats[0];
                $('#my_select option[value=' + id + ']').attr('selected', 'selected');
                var divID = 'divDaily';
                if (id == '1')
                    divID = 'divWeekly';
                else if (id == '2')
                    divID = 'divMonthly';
                else if (id == '3')
                    divID = 'divYearly';
                $("#" + divID).show();
                var intervalID = 'Select' + id;
                $('#' + intervalID + ' option[value=' + repeats[1] + ']').attr('selected', 'selected');
                var startdateID = id + "Start";
                $('#' + startdateID).val(repeats[2]);
                // *** Binding Ends *** //
                var ends = document.getElementById('<%=hdnEndOnold.ClientID %>').value.split("##SP##");
                var occuranceID = "#radio" + id + "occurance";
                var untilID = "#radio" + id + "until";
                var txtoccurance = "#txt" + id + "occurance";
                var txtuntil = "#txt" + id + "until";
                alert(ends[0] + " " + occuranceID + " " + untilID);
                if (ends[0] == "1") {
                    $(untilID).removeAttr('checked');
                    $(occuranceID).attr('checked', "checked");
                    $(txtoccurance).removeAttr("disabled");
                    $(txtuntil).attr("disabled", "disabled");
                    $(txtoccurance).val(ends[1]);
                    $(txtuntil).val('');
                }
                else {
                    $(occuranceID).removeAttr('checked');
                    $(untilID).attr('checked', "checked");
                    $(txtoccurance).attr("disabled", "disabled");
                    $(txtuntil).removeAttr("disabled");
                    $(txtoccurance).val('');
                    $(txtuntil).val(ends[1]);
                }
            }
        }
        function ShowRepeat(chkRepeat) {
            if (chkRepeat.checked) {
                SelectRepeatType();
            }
            else
                $('#divRepeat').hide();
        }
        $(document).ready(function () {
            $("#my_select").change(function () {
                SelectRepeatType();
            });
        });
        function SelectRepeatType() {
            if (document.getElementById("<%=txtStartDate.ClientID %>").value != "" && document.getElementById("<%=txtEndDate.ClientID %>").value != "") {
                $("#divRepeat").show();
                var id = $('#my_select :selected').val();
                $("#divDaily").hide(); $("#divWeekly").hide(); $("#divMonthly").hide(); $("#divYearly").hide();
                var divID = 'divDaily';

                if (id == '1')
                    divID = 'divWeekly';
                else if (id == '2')
                    divID = 'divMonthly';
                else if (id == '3')
                    divID = 'divYearly';
                $("#" + divID).show();
                var startdateID = id + "Start";
                $('#' + startdateID).val(document.getElementById("<%=txtStartDate.ClientID %>").value);
            }
            else {
                document.getElementById("<%=chkRepeat.ClientID %>").checked = false;
                alert('Please select a start date.');
            }
        }
        function SaveRepeatFunction() {
            var id = $('#my_select :selected').val();
            var intervalID = 'Select' + id;
            var occuranceID = "radio" + id + "occurance";
            var endson = "1##SP##5";
            if ($("#" + occuranceID).attr("checked"))
                endson = "1##SP##" + $("#txt" + id + "occurance").val();
            else
                endson = "2##SP##" + $("#txt" + id + "until").val();
            var repeaton = '';
            if (id == "1") {
                if ($("#chkSUN").attr("checked"))
                    repeaton = "1,";
                else
                    repeaton = "0,";
                if ($("#chkMON").attr("checked"))
                    repeaton = repeaton + "1,";
                else
                    repeaton = repeaton + "0,";
                if ($("#chkTUE").attr("checked"))
                    repeaton = repeaton + "1,";
                else
                    repeaton = repeaton + "0,";
                if ($("#chkWED").attr("checked"))
                    repeaton = repeaton + "1,";
                else
                    repeaton = repeaton + "0,"
                if ($("#chkTHU").attr("checked"))
                    repeaton = repeaton + "1,";
                else
                    repeaton = repeaton + "0,";
                if ($("#chkFRI").attr("checked"))
                    repeaton = repeaton + "1,";
                else
                    repeaton = repeaton + "0,";
                if ($("#chkSAT").attr("checked"))
                    repeaton = repeaton + "1,";
                else
                    repeaton = repeaton + "0,";
                repeaton = repeaton + ',0';
            }
            document.getElementById("<%=hdn3Items.ClientID %>").value = id + "##SP##" + $('#' + intervalID + ' :selected').val() + "##SP##" + document.getElementById("<%=txtStartDate.ClientID %>").value;
            document.getElementById("<%=hdnEndOn.ClientID %>").value = endson;
            document.getElementById("<%=hdnRepeatOn.ClientID %>").value = repeaton;
            alert(document.getElementById("<%=hdn3Items.ClientID %>").value + "             " + document.getElementById("<%=hdnEndOn.ClientID %>").value + "           " + document.getElementById("<%=hdnRepeatOn.ClientID %>").value);
        }
        function ChangeEnds(id, type, occurance, date) {
            var occuranceID = "txt" + id + "occurance";
            var untilID = "txt" + id + "until";
            if (type == '2') {
                $("#" + untilID).removeAttr("disabled");
                $("#" + occuranceID).attr("disabled", "disabled");
            }
            else {
                $("#" + occuranceID).removeAttr("disabled");
                $("#" + untilID).attr("disabled", "disabled");
            }
            $("#" + untilID).val(date);
            $('#' + occuranceID).val(occurance);
        }         
    </script>
    </form>
</body>
</html>
