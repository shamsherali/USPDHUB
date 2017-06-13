<%@ Page Title="" Language="C#" MasterPageFile="~/AdminHome.master" AutoEventWireup="true"
    CodeBehind="PrintSalesCode.aspx.cs" Inherits="USPDHUB.Admin.PrintSalesCode" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <style type="text/css">
        @page
        {
            margin-left: 1in;
            margin-right: 1in;
            margin-top: 0.75in;
            margin-bottom: 0.5in;
        }
        P
        {
            margin-bottom: 0.08in;
            direction: ltr;
            color: #000000;
            widows: 2;
            orphans: 2;
        }
        P.western
        {
            font-family: "Tahoma" , serif;
            font-size: 2pt;
        }
        P.cjk
        {
            font-size: 8pt;
        }
        P.ctl
        {
            font-size: 12pt;
        }
        H1
        {
            margin-top: 0in;
            margin-bottom: 0in;
            direction: ltr;
            color: #ffffff;
            text-align: center;
            widows: 2;
            orphans: 2;
            page-break-after: auto;
            text-transform: uppercase;
        }
        H1.western
        {
            font-family: "Tahoma" , serif;
            font-size: 12pt;
        }
        H1.cjk
        {
            font-family: "Times New Roman";
            font-size: 12pt;
        }
        H1.ctl
        {
            font-family: "Times New Roman";
            font-size: 12pt;
            font-weight: normal;
        }
        H2
        {
            margin-top: 0in;
            margin-bottom: 0in;
            direction: ltr;
            color: #000000;
            text-align: center;
            widows: 2;
            orphans: 2;
            page-break-after: auto;
            text-transform: uppercase;
        }
        H2.western
        {
            font-family: "Tahoma" , serif;
            font-size: 8pt;
        }
        H2.cjk
        {
            font-family: "Times New Roman";
            font-size: 8pt;
        }
        H2.ctl
        {
            font-family: "Times New Roman";
            font-size: 8pt;
            font-weight: normal;
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
                <asp:Button runat="server" ID="btnPrint" Text="Print" Width="70px" OnClick="btnPrint_OnClick" />
                &nbsp;&nbsp;<asp:Button runat="server" ID="btnDownload" Text="Download" Width="70px"
                    OnClick="btnDownload_OnClick" Style="text-align: center; padding-left: 3px;" />
            </div>
            <br />
            <br />
            <br />
            <br />
            <center>
                <table width="635" border="1" cellpadding="2" cellspacing="0" style="page-break-before: always;">
                    <colgroup>
                        <col width="224">
                        <col width="182">
                        <col width="216">
                    </colgroup>
                    <thead>
                        <tr>
                            <td colspan="3" width="629" height="29" bgcolor="#808080">
                                <h1 class="western">
                                    Logictree IT &ndash; channel code Management</h1>
                            </td>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td colspan="3" width="629" height="15" bgcolor="#d9d9d9">
                                <h2 class="western">
                                    <font size="3">RESELLER Details</font></h2>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" width="629" height="13" bgcolor="#ffffff">
                                <p class="western">
                                    <font face="Arial, serif"><font size="3">Reseller Name:
                                        <asp:Label ID="lblRName" runat="server"></asp:Label>
                                    </font></font>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td width="250" height="13" bgcolor="#ffffff">
                                <p class="western">
                                    <font face="Arial, serif"><font size="3"><b>Agreement Start Date:
                                        <asp:Label ID="lblAgreementSDate" runat="server"></asp:Label>
                                    </b></font></font>
                                </p>
                            </td>
                            <td width="182" bgcolor="#ffffff">
                                <p class="western">
                                    <font face="Arial, serif"><font size="3"><b>End Date:
                                        <asp:Label ID="lblAgreementEDate" runat="server"></asp:Label>
                                    </b></font></font>
                                </p>
                            </td>
                            <td width="216" bgcolor="#ffffff">
                                <p class="western" style="margin-bottom: 0in">
                                    <font face="Arial, serif"><font size="3"><b>Sales Code:
                                        <asp:Label ID="lblSalesCode" runat="server"></asp:Label>
                                    </b></font></font>
                                </p>
                                <p class="western">
                                    <font face="Arial, serif"><font size="3"><b>Commission Percentage :
                                        <asp:Label ID="lblCACP" runat="server"></asp:Label></b></font></font><font face="Arial, serif"><font
                                            size="3"> </font></font>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" width="629" height="13" bgcolor="#ffffff">
                                <p class="western">
                                    <font face="Arial, serif"><font size="3">Address:
                                        <asp:Label ID="lblCAAddress" runat="server"></asp:Label>
                                    </font></font>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td width="224" height="13" bgcolor="#ffffff">
                                <p class="western">
                                    <font face="Arial, serif"><font size="3">City:
                                        <asp:Label ID="lblCACity" runat="server"></asp:Label>
                                    </font></font>
                                </p>
                            </td>
                            <td width="182" bgcolor="#ffffff">
                                <p class="western">
                                    <font face="Arial, serif"><font size="3">State:
                                        <asp:Label ID="lblCAState" runat="server"></asp:Label>
                                    </font></font>
                                </p>
                            </td>
                            <td width="216" bgcolor="#ffffff">
                                <p class="western">
                                    <font face="Arial, serif"><font size="3">ZIP Code:
                                        <asp:Label ID="lblCAZip" runat="server"></asp:Label>
                                    </font></font>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" width="629" height="15" bgcolor="#d9d9d9">
                                <h2 class="western">
                                    <font face="Arial, serif"><font size="3">LT Manager</font></font></h2>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" width="629" height="13" bgcolor="#ffffff">
                                <p class="western">
                                    <font face="Arial, serif"><font size="3">LT MANAGER Name:
                                        <asp:Label ID="lblLTName" runat="server"></asp:Label>
                                    </font></font>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td width="224" height="13" bgcolor="#ffffff">
                                <p class="western">
                                    <br>
                                </p>
                            </td>
                            <td width="182" bgcolor="#ffffff">
                                <p class="western">
                                    <br>
                                </p>
                            </td>
                            <td width="216" bgcolor="#ffffff">
                                <p class="western">
                                    <font face="Arial, serif"><font size="3"><b>Commission Percentage :
                                        <asp:Label ID="lblLTCP" runat="server"></asp:Label>
                                    </b></font></font>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" width="629" height="15" bgcolor="#d9d9d9">
                                <h2 class="western">
                                    <font face="Arial, serif"><font size="3">Channel manager</font></font></h2>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" width="629" height="13" bgcolor="#ffffff">
                                <p class="western">
                                    <font face="Arial, serif"><font size="3">CHANNEL MANAGER Name :
                                        <asp:Label ID="lblCMName" runat="server"></asp:Label></font></font></p>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" width="410" height="13" bgcolor="#ffffff">
                                <p class="western" style="margin-bottom: 0in">
                                    <font face="Arial, serif"><font size="3">Address:
                                        <asp:Label ID="lblCMAddress" runat="server"></asp:Label>
                                    </font></font>
                                </p>
                                <p class="western" style="margin-bottom: 0in">
                                    <br>
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
                                <p class="western">
                                    <br>
                                </p>
                            </td>
                            <td width="216" bgcolor="#ffffff">
                                <p class="western">
                                    <font face="Arial, serif"><font size="3"><b>Commission Percentage :
                                        <asp:Label ID="lblCMCP" runat="server"></asp:Label>
                                    </b></font></font>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" width="629" height="15" bgcolor="#d9d9d9">
                                <h2 class="western">
                                    <font face="Arial, serif"><font size="3">Channel Partner</font></font></h2>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" width="629" height="13" bgcolor="#ffffff">
                                <p class="western">
                                    <font face="Arial, serif"><font size="3">CHANNEL PARTNER Name:
                                        <asp:Label ID="lblCPName" runat="server"></asp:Label>
                                    </font></font>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" width="410" height="13" bgcolor="#ffffff">
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
                                <p class="western">
                                    <br>
                                </p>
                            </td>
                            <td width="216" bgcolor="#ffffff">
                                <p class="western">
                                    <font face="Arial, serif"><font size="3"><b>Commission Percentage :
                                        <asp:Label ID="lblCPCP" runat="server"></asp:Label>
                                    </b></font></font>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" width="410" height="13" bgcolor="#ffffff">
                                <p class="western">
                                    <br>
                                </p>
                            </td>
                            <td width="216" bgcolor="#ffffff">
                                <p class="western">
                                    <br>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" width="629" height="15" bgcolor="#d9d9d9">
                                <h2 class="western">
                                    <font face="Arial, serif"><font size="3">Logictree IT &ndash; Internal use only</font></font></h2>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" width="629" height="34" bgcolor="#ffffff">
                                <p class="western">
                                    <font face="Arial, serif"><font size="3">NOTES :
                                        <asp:Label ID="lblNotes" runat="server"></asp:Label>
                                    </font></font>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" width="410" height="13" bgcolor="#ffffff">
                                <p class="western" style="margin-bottom: 0in">
                                    <font face="Arial, serif"><font size="3">Created by :
                                        <asp:Label ID="lblCreated" runat="server"></asp:Label>
                                    </font></font>
                                </p>
                                <p class="western">
                                    <br>
                                </p>
                            </td>
                            <td width="216" bgcolor="#ffffff">
                                <p class="western">
                                    <font face="Arial, serif"><font size="3">Date:
                                        <asp:Label ID="lblCreatedDate" runat="server"></asp:Label>
                                    </font></font>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" width="410" height="12" bgcolor="#ffffff">
                                <p class="western" style="margin-bottom: 0in">
                                    <font face="Arial, serif"><font size="3">Approved by :
                                        <asp:Label ID="lblApproved" runat="server"></asp:Label>
                                    </font></font>
                                </p>
                                <p class="western">
                                    <br>
                                </p>
                            </td>
                            <td width="216" bgcolor="#ffffff">
                                <p class="western">
                                    <font face="Arial, serif"><font size="3">Date:
                                        <asp:Label ID="lblApprovedDate" runat="server"></asp:Label>
                                    </font></font>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" width="629" height="15" bgcolor="#d9d9d9">
                                <h2 class="western">
                                    <font face="Arial, serif"><font size="3">Sign up Links</font></font></h2>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" width="216" height="13" bgcolor="#ffffff">
                                <p class="western" style="margin-bottom: 0in">
                                    <font face="Arial, serif"><font size="3">Uspdhub </font></font>
                                </p>
                                <p class="western">
                                    <br>
                                </p>
                            </td>
                            <td width="410" bgcolor="#ffffff">
                                <p class="western">
                                    <font face="Arial, serif"><font size="3">
                                        <asp:HyperLink ID="hlinkuspd" runat="server" Target="_blank"></asp:HyperLink>
                                    </font></font>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" width="216" height="13" bgcolor="#ffffff">
                                <p class="western" style="margin-bottom: 0in">
                                    <font face="Arial, serif"><font size="3">Twoive </font></font>
                                </p>
                                <p class="western">
                                    <br>
                                </p>
                            </td>
                            <td width="410" bgcolor="#ffffff">
                                <p class="western">
                                    <font face="Arial, serif"><font size="3">
                                        <asp:HyperLink ID="hlinkTwoive" runat="server" Target="_blank"></asp:HyperLink>
                                    </font></font>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" width="216" height="13" bgcolor="#ffffff">
                                <p class="western" style="margin-bottom: 0in">
                                    <font face="Arial, serif"><font size="3">InSchoolHub </font></font>
                                </p>
                                <p class="western">
                                    <br>
                                </p>
                            </td>
                            <td width="410" bgcolor="#ffffff">
                                <p class="western">
                                    <font face="Arial, serif"><font size="3">
                                        <asp:HyperLink ID="hlinkInSchool" runat="server" Target="_blank"></asp:HyperLink>
                                    </font></font>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" width="216" height="13" bgcolor="#ffffff">
                                <p class="western" style="margin-bottom: 0in">
                                    <font face="Arial, serif"><font size="3">MyYouthHub </font></font>
                                </p>
                                <p class="western">
                                    <br>
                                </p>
                            </td>
                            <td width="410" bgcolor="#ffffff">
                                <p class="western">
                                    <font face="Arial, serif"><font size="3">
                                        <asp:HyperLink ID="hlinkMyYouth" runat="server" Target="_blank"></asp:HyperLink>
                                    </font></font>
                                </p>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
