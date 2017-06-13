<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintManageSalesCode.aspx.cs"
    Inherits="USPDHUB.PrintManageSalesCode" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Channel Code Management</title>
    <script type="text/javascript" src="../../Scripts/jquery.js"></script>
    <script type="text/javascript" src="../../Scripts/jsapi.js" language="javascript"></script>
    <script type="text/javascript">

        google.load('visualization', '1', { packages: ['corechart'] });
      
    </script>
    <style type="text/css">
        @page
        {
            margin-left: 1in;
            margin-right: 1in;
            margin-top: 0.75in;
            margin-bottom: 0.5in;
        }
        @media print
        {
            /* style sheet for print goes here */
            #printpagebutton
            {
                display: none;
            }
        }
        P
        {
            margin: 0.02 0 0.02 0.0in;
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
        .tablecol
        {
            border-right: 1px solid #000;
            border-bottom: 1px solid #000;
        }
        .tablecol td
        {
            border-top: 1px solid #000;
            border-left: 1px solid #000;
        }
    </style>
    <script type="text/javascript">
        function printpage() {
            //Get the print button and put it into a variable
            var printButton = document.getElementById("printpagebutton");
            //Set the print button visibility to 'hidden' 
            printButton.style.display = 'none';
            //Print the page content
            window.print()
            //Set the print button to 'visible' again 
            //[Delete this line if you want it to stay hidden after printing]
            printButton.style.display = 'block';
        }
    </script>
</head>
<body onload="javascript:printpage();" style="background-color: #FFF;">
    <form id="form1" runat="server">
    <div id="printpagebutton">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 750px; margin: 0px auto;
            display: table;">
            <tr>
                <td align="right">
                    <a href="javacript:void(0);" onclick="printpage();">
                        <img src="images/OuterImages/printlabel.gif" border="0" /></a>
                </td>
            </tr>
        </table>
    </div>
    <table cellpadding="0" cellspacing="0" border="0" width="100%" style="padding-top: 10px;">
        <tr>
            <td align="center" valign="top">
                <table width="750px" border="0" cellpadding="2" cellspacing="0" style="page-break-before: always;"
                    class="tablecol">
                    <colgroup>
                        <col width="224px" />
                        <col width="182px" />
                        <col width="216px" />
                    </colgroup>
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
                            <td colspan="3" width="629px" height="25px" bgcolor="#ffffff">
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
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
