<%@ Page Title="" Language="C#" MasterPageFile="~/AdminHome.master" AutoEventWireup="true"
    CodeBehind="DashboardLoginReport.aspx.cs" EnableEventValidation="false" Inherits="USPDHUB.Admin.DashboardLoginReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <script type="text/javascript">
        function CheckvValidation() {
            var fromdate = document.getElementById('<%=txtDTFrom.ClientID %>').value;
            var todate = document.getElementById('<%=txttodate.ClientID %>').value;
            var cat = document.getElementById('<%=drpcategory.ClientID %>').value;
            if (fromdate != "" & todate != "" & cat != "0") {
                alert('Please enter either From & To Dates OR First/Last/Profile Names.');
                return false;
            }
            else if (fromdate == "" & todate == "" & cat == "0") {
                alert('Please enter either From & To Dates OR First/Last/Profile Names.');
                return false;
            }
            else if (fromdate != "" & todate == "" & cat == "0") {
                alert('Please enter either From & To Dates OR First/Last/Profile Names.');
                return false;
            }
            else if (fromdate == "" & todate != "" & cat == "0") {
                alert('Please enter either From & To Dates OR First/Last/Profile Names.');
                return false;
            }
            else if (fromdate == "" & todate != "" & cat != "0") {
                alert('Please enter either From & To Dates OR First/Last/Profile Names.');
                return false;
            }
            else if (fromdate != "" & todate == "" & cat != "0") {
                alert('Please enter either From & To Dates OR First/Last/Profile Names.');
                return false;
            }

            if (cat != "0") {
                var cat1 = document.getElementById('<%=txtcategory.ClientID %>').value;
                if (cat1 == "") {
                    alert('Enter First/Last/Profile Names.');
                    return false;
                }
            }
            return true;
        }    
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnReport" />
        </Triggers>
        <ContentTemplate>
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="page-padding">
                <tr>
                    <td>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="page-title">
                            <tr>
                                <td>
                                    Dashboard Login Report
                                </td>
                                <td>
                                    <asp:UpdateProgress ID="UpdateProgress6" runat="server" DisplayAfter="3">
                                        <ProgressTemplate>
                                            <img src="../../images/popup_ajax-loader.gif" border="0"><span class="processing">Processing....</span>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="lblvaliddate" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="datatable">
                            <tr>
                                <td>
                                    <table width="100%" border="0" cellpadding="0" cellspacing="5px">
                                        <colgroup>
                                            <col width="20%" />
                                            <col width="30%" />
                                            <col width="20%" />
                                            <col width="*" />
                                        </colgroup>
                                        <tr>
                                            <td class="lable">
                                                From Date:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDTFrom" runat="server" CssClass="textfield" Width="91px"></asp:TextBox>&nbsp;<b>(MM/DD/YYYY)</b>
                                                <cc1:CalendarExtender ID="calex" runat="server" TargetControlID="txtDTFrom" Format="MM/dd/yyyy"
                                                    CssClass="MyCalendar" />
                                                <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="g" runat="server"
                                            ControlToValidate="txtDTFrom" ErrorMessage="From Date is Mandatory." Display="Dynamic">*</asp:RequiredFieldValidator>--%>
                                                <asp:RangeValidator ID="RangeValidator1" ValidationGroup="g" MinimumValue="01/01/2008"
                                                    MaximumValue="12/31/2999" runat="server" Type="Date" ControlToValidate="txtDTFrom"
                                                    ErrorMessage="Please select valid date." Display="Dynamic">*</asp:RangeValidator>
                                            </td>
                                            <td class="lable">
                                                To Date:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txttodate" runat="server" CssClass="textfield" Width="91px"></asp:TextBox>&nbsp;<b>MM/DD/YYYY)</b>
                                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txttodate"
                                                    Format="MM/dd/yyyy" CssClass="MyCalendar" />
                                                <%--    <asp:RequiredFieldValidator ValidationGroup="g" ID="RequiredFieldValidator1" runat="server"
                                            ControlToValidate="txttodate" ErrorMessage="To Date is Mandatory." Display="Dynamic">*</asp:RequiredFieldValidator>--%>
                                                <asp:RangeValidator ID="RangeValidator2" ValidationGroup="g" MinimumValue="01/01/2008"
                                                    MaximumValue="12/31/2999" runat="server" Type="Date" ControlToValidate="txttodate"
                                                    ErrorMessage="Please select valid date." Display="Dynamic">*</asp:RangeValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="center">
                                                <b>(OR)</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lable">
                                                Select Criteria:
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="drpcategory" runat="server" OnSelectedIndexChanged="drpcategory_SelectedIndexChanged"
                                                    AutoPostBack="True">
                                                    <asp:ListItem Text="--Select Category--" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="First Name" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="Last Name" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="Profile Name" Value="3"></asp:ListItem>
                                                </asp:DropDownList>
                                                <%--  <asp:RequiredFieldValidator ID="reqcate" runat="server" Display="Dynamic" ErrorMessage="Category is Mandatory."
                                            ControlToValidate="drpcategory" ValidationGroup="g" InitialValue="0">*</asp:RequiredFieldValidator>--%>
                                            </td>
                                            <td colspan="2">
                                                <asp:Panel ID="pnlcategory" runat="server">
                                                    <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                                        <colgroup>
                                                            <col width="169px" />
                                                            <col width="*" />
                                                        </colgroup>
                                                        <tr>
                                                            <td>
                                                                Enter
                                                                <%=drpcategory.SelectedItem.Text %>:
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtcategory" runat="server"></asp:TextBox>
                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtcategory"
                                                            ErrorMessage="Category Name is mandatory." ValidationGroup="g" Display="Dynamic">*</asp:RequiredFieldValidator>--%>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="padding-right: 100px;">
                                    <asp:Button ID="btn" runat="server" Text="Get Login Details" ValidationGroup="g"
                                        OnClick="btn_Click" OnClientClick="return CheckvValidation()" />
                                    <%--<asp:Button ID="btndashboard" Text="Go to Dashboard" runat="server" CssClass="button"
                                        OnClick="btndashboard_Click" />&nbsp;&nbsp;&nbsp;--%>
                                    <%-- <asp:Label ID="lblmsg" runat="server" ForeColor="green" ></asp:Label>--%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblmsg" runat="server" ForeColor="green" Font-Bold="true"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblerr" runat="server" ForeColor="red" Font-Bold="true"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table>
                                        <tr>
                                            <td class="inputgrid">
                                                <asp:ValidationSummary ID="ValidationSummary1" HeaderText="Form Errors are:" ValidationGroup="g"
                                                    runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Panel ID="pnlgrid" runat="server">
                                        <div style="overflow: scroll; width: 900px; height: 450px;">
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="datagrid nomargin-bottom">
                                                <tr>
                                                    <td width="100%">
                                                        <asp:GridView ID="grdlogin" Width="100%" GridLines="None" CssClass="datagrid2" runat="server"
                                                            AutoGenerateColumns="False" AllowSorting="True" OnSorting="grdlogin_Sorting"
                                                            AllowPaging="True" PageSize="25" OnRowDataBound="grdlogin_RowDataBound" OnPageIndexChanging="grdlogin_PageIndexChanging">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Profile ID" SortExpression="Profile_ID">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblprofileid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Profile_ID") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                    <HeaderStyle Width="200px" Wrap="False" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="First Name" SortExpression="FirstName">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblfirstname" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FirstName") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" Width="150px" />
                                                                    <HeaderStyle Width="150px" Wrap="False" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Last Name" SortExpression="LastName">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbllastname" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "LastName") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                    <HeaderStyle Wrap="False" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Profile Name" SortExpression="Profile_name">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblbusinessname" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Profile_Name") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                                                    <HeaderStyle Wrap="False" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Email Id" SortExpression="Username">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblEmailId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Username") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Contact Number">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblPhone" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Profile_Phone1") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                    <HeaderStyle Wrap="False" ForeColor="Black" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Address" SortExpression="Profile_StreetAddress1">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblAddress" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Profile_StreetAddress1") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="City" SortExpression="Profile_City">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblcity" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Profile_City") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="State" SortExpression="Profile_State">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblstate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Profile_State") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Login attempts">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblNoofTimes" runat="server" Text='<%# Bind("Nooftimes") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Wrap="False" ForeColor="Black" />
                                                                    <ItemStyle HorizontalAlign="Center" Wrap="False" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Last Login Date">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbllastlogin" runat="server" Text='<%# Bind("LastloginDate") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" Width="250px"  Wrap="False" />
                                                                    <HeaderStyle Wrap="False" ForeColor="Black" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <HeaderStyle CssClass="title1" />
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div>
                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td align="right" style="padding-right: 10px; padding-top: 5px; padding-bottom: 5px;">
                                                        <asp:GridView ID="grdreport" Width="100%" GridLines="None" CssClass="datagrid2" runat="server"
                                                            AutoGenerateColumns="False" OnRowDataBound="grdreport_RowDataBound">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Profile ID" SortExpression="Profile_ID">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblprofileid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Profile_ID") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="First Name" SortExpression="FirstName">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblfirstname" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FirstName") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" Width="150px" />
                                                                    <HeaderStyle Width="150px" Wrap="False" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Last Name" SortExpression="LastName">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbllastname" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "LastName") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                    <HeaderStyle Wrap="False" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Profile Name" SortExpression="Profile_name">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblbusinessname" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Profile_Name") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                                                    <HeaderStyle Wrap="False" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Email Id" SortExpression="Username">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblEmailId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Username") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Contact Number">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblPhone" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Profile_Phone1") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                    <HeaderStyle Wrap="False" ForeColor="Black" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Address" SortExpression="Profile_StreetAddress1">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblAddress" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Profile_StreetAddress1") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="City" SortExpression="Profile_City">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblcity" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Profile_City") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="State" SortExpression="Profile_State">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblstate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Profile_State") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Login attempts">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblNoofTimes" runat="server" Text='<%# Bind("Nooftimes") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Wrap="False" ForeColor="Black" />
                                                                    <ItemStyle HorizontalAlign="Center" Wrap="False" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText=" Last Login Date">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbllastlogin" runat="server" Text='<%# Bind("LastloginDate") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" Width="170px" />
                                                                    <HeaderStyle Wrap="False" ForeColor="Black" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <HeaderStyle CssClass="title1" />
                                                        </asp:GridView>
                                                        <asp:Button ID="btnReport" runat="server" OnClick="btnReport_Click" Text="Generate Excel Report" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
