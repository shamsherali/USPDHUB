<%@ Page Title="" Language="C#" MasterPageFile="~/AdminHome.master" AutoEventWireup="true"
    CodeBehind="SalesCode.aspx.cs" Inherits="USPDHUB.Admin.SalesCode" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <link href="../css/MSC.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        @page
        {
            margin-left: 1in;
            margin-right: 1in;
            margin-top: 0.75in;
            margin-bottom: 0.5in;
        }
    </style>
    <asp:ScriptManager ID="smgr1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnDownload" />
        </Triggers>
        <ContentTemplate>
            <div style="float: right; margin-right: 40px; margin-top: 24px;">
                <asp:Button runat="server" ID="btnBack" Text="Back" Width="70px" OnClick="btnBack_OnClick" />
                &nbsp;&nbsp;
                <asp:Button runat="server" ID="btnPrint" Text="Print" Width="70px" OnClick="btnPrint_OnClick" />
                &nbsp;&nbsp;<asp:Button runat="server" ID="btnDownload" Text="Download" Width="70px"
                    OnClick="btnDownload_OnClick" Style="text-align: center; padding-left: 3px;" />
            </div>
            <br />
            <br />
            <br />
            <br />
            <center>
                <table width="90%" border="1" cellpadding="2" cellspacing="0" style="page-break-before: always;">
                    <colgroup>
                        <col width="224px">
                        <col width="182px">
                        <col width="216px">
                    </colgroup>
                    <thead>
                        <tr>
                            <td colspan="3" width="629px" height="29px" bgcolor="#808080">
                                <h1 class="western">
                                    Logictree IT &ndash; channel code Management</h1>
                            </td>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td width="250px" height="13px" bgcolor="#ffffff">
                                <p class="western">
                                    <font face="Arial, serif"><font size="3"><b>Agreement Start Date:
                                        <asp:Label ID="lblAgreementSDate" runat="server"></asp:Label>
                                    </b></font></font>
                                </p>
                            </td>
                            <td width="182px" bgcolor="#ffffff">
                                <p class="western">
                                    <font face="Arial, serif"><font size="3"><b>End Date:
                                        <asp:Label ID="lblAgreementEDate" runat="server"></asp:Label>
                                    </b></font></font>
                                </p>
                            </td>
                            <td width="216px" bgcolor="#ffffff">
                                <p class="western" style="margin-bottom: 0in">
                                    <font face="Arial, serif"><font size="3"><b>Sales Code:
                                        <asp:Label ID="lblSalesCode" runat="server"></asp:Label>
                                    </b></font></font>
                                </p>
                            </td>
                        </tr>
                        <%--Channel Partner Block--%>
                        <tr id="trCP" runat="server">
                            <td colspan="3" width="629px" height="15px" bgcolor="#d9d9d9">
                                <h2 class="western">
                                    <font face="Arial, serif"><font size="3">Channel Partner</font></font></h2>
                            </td>
                        </tr>
                        <tr id="trCPName" runat="server">
                            <td colspan="3" width="629px" height="13px" bgcolor="#ffffff">
                                <p class="western">
                                    <font face="Arial, serif"><font size="3">CHANNEL PARTNER Name:
                                        <asp:Label ID="lblCPName" runat="server"></asp:Label>
                                    </font></font>
                                </p>
                            </td>
                        </tr>
                        <tr id="trCPDetails" runat="server">
                            <td colspan="2" width="410px" height="13px" bgcolor="#ffffff">
                                <p class="western" style="margin-bottom: 0in">
                                    <font face="Arial, serif"><font size="3">Address :
                                        <asp:Label ID="lblCPAddress" runat="server"></asp:Label>
                                    </font></font>
                                </p>
                                <p class="western" style="margin-bottom: 0in">
                                    <font face="Arial, serif"><font size="3">Email :
                                        <asp:Label ID="lblCPEmail" runat="server"></asp:Label>
                                    </font></font>
                                </p>
                                <p class="western" style="margin-bottom: 0in">
                                    <font face="Arial, serif"><font size="3">Phone :
                                        <asp:Label ID="lblCPPhone" runat="server"></asp:Label>
                                    </font></font>
                                </p>
                            </td>
                            <td width="216px" bgcolor="#ffffff">
                                <p class="western">
                                    <font face="Arial, serif"><font size="3"><b>Commission Percentage :
                                        <asp:Label ID="lblCPCP" runat="server"></asp:Label>
                                    </b></font></font>
                                </p>
                            </td>
                        </tr>
                        <%--LT Manager Block--%>
                        <tr id="trLTManager" runat="server">
                            <td colspan="3" width="629px" height="15px" bgcolor="#d9d9d9">
                                <h2 class="western">
                                    <font face="Arial, serif"><font size="3">LT Manager</font></font></h2>
                            </td>
                        </tr>
                        <tr id="trLTManagerName" runat="server">
                            <td colspan="3" width="629px" height="13px" bgcolor="#ffffff">
                                <p class="western">
                                    <font face="Arial, serif"><font size="3">LT MANAGER Name:
                                        <asp:Label ID="lblLTName" runat="server"></asp:Label>
                                    </font></font>
                                </p>
                            </td>
                        </tr>
                        <tr id="trLTDetails" runat="server">
                            <td colspan="2" width="410px" height="13px" bgcolor="#ffffff">
                                <p class="western" style="margin-bottom: 0in">
                                    <font face="Arial, serif"><font size="3">Address:
                                        <asp:Label ID="lblLTAddress" runat="server"></asp:Label>
                                    </font></font>
                                </p>
                                <p class="western" style="margin-bottom: 0in">
                                    <font face="Arial, serif"><font size="3">Email :
                                        <asp:Label ID="lblLTEmail" runat="server"></asp:Label>
                                    </font></font>
                                </p>
                                <p class="western" style="margin-bottom: 0in">
                                    <font face="Arial, serif"><font size="3">Phone :
                                        <asp:Label ID="lblLTPhone" runat="server"></asp:Label>
                                    </font></font>
                                </p>
                            </td>
                            <td width="216px" bgcolor="#ffffff">
                                <p class="western">
                                    <font face="Arial, serif"><font size="3"><b>Commission Percentage :
                                        <asp:Label ID="lblLTCP" runat="server"></asp:Label>
                                    </b></font></font>
                                </p>
                            </td>
                        </tr>
                        <%--Channel Manager Block--%>
                        <tr id="trCM" runat="server">
                            <td colspan="3" width="629px" height="15px" bgcolor="#d9d9d9">
                                <h2 class="western">
                                    <font face="Arial, serif"><font size="3">Channel manager</font></font></h2>
                            </td>
                        </tr>
                        <tr id="trCMName" runat="server">
                            <td colspan="3" width="629px" height="13px" bgcolor="#ffffff">
                                <p class="western">
                                    <font face="Arial, serif"><font size="3">CHANNEL MANAGER Name :
                                        <asp:Label ID="lblCMName" runat="server"></asp:Label></font></font></p>
                            </td>
                        </tr>
                        <tr id="trCMDetails" runat="server">
                            <td colspan="2" width="410px" height="13px" bgcolor="#ffffff">
                                <p class="western" style="margin-bottom: 0in">
                                    <font face="Arial, serif"><font size="3">Address:
                                        <asp:Label ID="lblCMAddress" runat="server"></asp:Label>
                                    </font></font>
                                </p>
                                <p class="western" style="margin-bottom: 0in">
                                    <font face="Arial, serif"><font size="3">Email :
                                        <asp:Label ID="lblCMEmail" runat="server"></asp:Label>
                                    </font></font>
                                </p>
                                <p class="western" style="margin-bottom: 0in">
                                    <font face="Arial, serif"><font size="3">Phone :
                                        <asp:Label ID="lblCMPhone" runat="server"></asp:Label>
                                    </font></font>
                                </p>
                            </td>
                            <td width="216px" bgcolor="#ffffff">
                                <p class="western">
                                    <font face="Arial, serif"><font size="3"><b>Commission Percentage :
                                        <asp:Label ID="lblCMCP" runat="server"></asp:Label>
                                    </b></font></font>
                                </p>
                            </td>
                        </tr>
                        <%--Channel Affiliate Block--%>
                        <tr id="trCA" runat="server">
                            <td colspan="3" width="629px" height="15px" bgcolor="#d9d9d9">
                                <h2 class="western">
                                    <font face="Arial, serif"><font size="3">Channel Affiliate</font></font></h2>
                            </td>
                        </tr>
                        <tr id="trCAName" runat="server">
                            <td colspan="3" width="629px" height="13px" bgcolor="#ffffff">
                                <p class="western">
                                    <font face="Arial, serif"><font size="3">CHANNEL Affiliate Name :
                                        <asp:Label ID="lblRName" runat="server"></asp:Label></font></font></p>
                            </td>
                        </tr>
                        <tr id="trCADetails" runat="server">
                            <td colspan="2" width="410px" height="13px" bgcolor="#ffffff">
                                <p class="western" style="margin-bottom: 0in">
                                    <font face="Arial, serif"><font size="3">Address:
                                        <asp:Label ID="lblCAAddress" runat="server"></asp:Label>
                                    </font></font>
                                </p>
                                <p class="western" style="margin-bottom: 0in">
                                    <font face="Arial, serif"><font size="3">Email :
                                        <asp:Label ID="lblCAEmail" runat="server"></asp:Label>
                                    </font></font>
                                </p>
                                <p class="western" style="margin-bottom: 0in">
                                    <font face="Arial, serif"><font size="3">Phone :
                                        <asp:Label ID="lblCAPhone" runat="server"></asp:Label>
                                    </font></font>
                                </p>
                            </td>
                            <td width="216px" bgcolor="#ffffff">
                                <p class="western">
                                    <font face="Arial, serif"><font size="3"><b>Commission Percentage :
                                        <asp:Label ID="lblCACP" runat="server"></asp:Label>
                                    </b></font></font>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" width="629px" height="15px" bgcolor="#d9d9d9">
                                <h2 class="western">
                                    <font face="Arial, serif"><font size="3">Logictree IT &ndash; Internal use only</font></font></h2>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" width="629px" height="34px" bgcolor="#ffffff">
                                <p class="western">
                                    <font face="Arial, serif"><font size="3">NOTES :
                                        <asp:Label ID="lblNotes" runat="server"></asp:Label>
                                    </font></font>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" width="410px" height="13px" bgcolor="#ffffff">
                                <p class="western" style="margin-bottom: 0in">
                                    <font face="Arial, serif"><font size="3">Created by :
                                        <asp:Label ID="lblCreated" runat="server"></asp:Label>
                                    </font></font>
                                </p>
                            </td>
                            <td width="216px" bgcolor="#ffffff">
                                <p class="western">
                                    <font face="Arial, serif"><font size="3">Date:
                                        <asp:Label ID="lblCreatedDate" runat="server"></asp:Label>
                                    </font></font>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" width="410px" height="12px" bgcolor="#ffffff">
                                <p class="western" style="margin-bottom: 0in">
                                    <font face="Arial, serif"><font size="3">Approved by :
                                        <asp:Label ID="lblApproved" runat="server"></asp:Label>
                                    </font></font>
                                </p>
                            </td>
                            <td width="216px" bgcolor="#ffffff">
                                <p class="western">
                                    <font face="Arial, serif"><font size="3">Date:
                                        <asp:Label ID="lblApprovedDate" runat="server"></asp:Label>
                                    </font></font>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" width="629px" height="15px" bgcolor="#d9d9d9">
                                <h2 class="western">
                                    <font face="Arial, serif"><font size="3">Sign up Links</font></font></h2>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" width="629px" height="34px" bgcolor="#ffffff">
                                <p class="western">
                                    <font face="Arial, serif"><font size="3">USPDhub :
                                        <asp:HyperLink ID="hlinkuspd" runat="server" Target="_blank"></asp:HyperLink>
                                    </font></font>
                                </p>
                                <p class="western">
                                    <font face="Arial, serif"><font size="3">TwoVieHub :
                                        <asp:HyperLink ID="hlinkTwoive" runat="server" Target="_blank"></asp:HyperLink>
                                    </font></font>
                                </p>
                                <p class="western">
                                    <font face="Arial, serif"><font size="3">InSchoolHub :
                                        <asp:HyperLink ID="hlinkInSchool" runat="server" Target="_blank"></asp:HyperLink>
                                    </font></font>
                                </p>
                                <p class="western">
                                    <font face="Arial, serif"><font size="3">MyYouthHub :
                                        <asp:HyperLink ID="hlinkMyYouth" runat="server" Target="_blank"></asp:HyperLink>
                                    </font></font>
                                </p>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <br />
                <br />
                <div>
                    <asp:Button runat="server" ID="btndownBack" Text="Back" Width="70px" OnClick="btnBack_OnClick" />
                </div>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
