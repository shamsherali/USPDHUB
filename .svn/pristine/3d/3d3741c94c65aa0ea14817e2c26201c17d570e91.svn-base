<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddTools.aspx.cs" Inherits="USPDHUB.OP.localhost.AddTools" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mobile App for Law Enforcement, Community Outreach, Police App & Agency App from
        USPDhub.com</title>
    <meta name="author" content="USPDhub.com Team" />
    <meta name="description" content="USPDhub is an easy and smart online business tool box which includes email marketing, contact management, a dynamic web presence, calendar, local directory listings and more." />
    <meta name="keywords" content="online marketing system, online marketing, email marketing, internet marketing, local online marketing, online marketing companies, online marketing blog, online marketing tools" />
    <script src="<%=Page.ResolveClientUrl("~/Scripts/jquery.js")%>" type="text/javascript"></script>
    <link href="<%=Page.ResolveClientUrl("~/css/pricingtable.css")%>" rel="stylesheet" type="text/css" />
    <link href="<%=Page.ResolveClientUrl("~/css/global.css")%>" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.6.1/jquery.min.js"></script>
    <script type="text/javascript">
       function SelectedTools() {
            var ProfileID=<%=ProfileID %>;
            var EncryptAffilateID='<%=EncryptAffilateID%>';
            var result;        
            if (document.getElementById('hdnPkgVal').value == "") {
                if(parseInt(ProfileID) == 0){
                    result = confirm('You have not selected any package; click ok to proceed with a 30 Day Free Trial.'); 
                    if(result==true)
                    {
                        var str="";
                        if(EncryptAffilateID!="")
                        {            
                         str=EncryptAffilateID.replace('PLUS','+');
                            str=str.replace('EQUAL','=');               
                            window.location.href="../Business/BusinessListing.aspx?PC=FreeTrial&AID="+str;
                        }
                        else
                            window.location.href="../Business/BusinessListing.aspx?PC=FreeTrial"
                        return false;
                    }
                    else
                        return false;
                }
                else
                {
                     result = confirm('You have not selected any package, click ok to go to Dashboard.'); 
                     if(result==true)
                     {
                        window.location.href="MyAccount/Default.aspx";
                        return false;
                     }
                    else
                        return false;
               }
            }
            else
            {
               if(<%=UserPackegeNum %>!=0)
               {
                    if(selPacakgevalue<=<%=UserPackegeNum %>)
                    {
                        alert("You have selected the lower package. Please select higher package.");
                        return false;
                    }
                    else
                        return true;
               }
               else
                   return true;
           }
        }
    </script>
    <script language="javascript" type="text/ecmascript">
        var selPacakgevalue = 0;
        function CheckSelectedPackage(priceamt, value) {
            var price = 0;
            price = parseInt(priceamt);
            if (document.getElementById('hdnRemainingdays').value != "") {
                var RemaingAmt = price * parseInt(document.getElementById('hdnRemainingdays').value) / 30;
                price = RemaingAmt;
            }
            if (price != 0)
                document.getElementById('hdnPkgVal').value = 1;
            selPacakgevalue = parseInt(value);
            document.getElementById('hdnSelcPkg').value=value;
            document.getElementById('hdnTotal').value = parseFloat(price).toFixed(2);
            if (document.getElementById('hdnoldAmount').value != "") {
                price = (price - parseFloat(document.getElementById('hdnoldAmount').value)).toFixed(2);
            }
            document.getElementById('hdnAmount').value = parseFloat(price).toFixed(2);
            return SelectedTools();
        }
        function GetTools() {
            var price = 0;
            price = <%=PreviousPkgAmount %>
            if (document.getElementById('hdnRemainingdays').value != "") {
                var RemaingAmt = price * parseInt(document.getElementById('hdnRemainingdays').value) / 30;
                price = RemaingAmt;
            }
            if (price != 0)
                document.getElementById('hdnPkgVal').value = 1;
            selPacakgevalue = parseInt(document.getElementById('hdnSelcPkg').value);
            document.getElementById('hdnTotal').value = parseFloat(price).toFixed(2);
            if (document.getElementById('hdnoldAmount').value != "") {
                price = (price - parseFloat(document.getElementById('hdnoldAmount').value)).toFixed(2);
            }
            document.getElementById('hdnAmount').value = parseFloat(price).toFixed(2);
        }
    </script>
    <script type="text/javascript">
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
  m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-40935673-1', 'uspdhub.com');
        ga('send', 'pageview');

    </script>
</head>
<body>
    <form id="frm1" runat="server">
    <!--bodycontent start-->
    <div id="header">
        <div class="menu_top">
            <div class="container">
                <div class="navwrap">
                    <div class="nav">
                        <ul>
                            <li><a href="Default.aspx">Home</a></li>
                            <li><a href="contactus.aspx">Contact Us</a></li>
                            <li><a href="javascript:void(0);" class="active">Pricing</a></li>
                            <li><a href="Aboutus.html">About Us</a></li>
                            <li><a href="login.aspx">Login</a></li>
                        </ul>
                    </div>
                </div>
                <div class="clear">
                </div>
            </div>
        </div>
        <div id="bannerwrap">
            <div class="bg_colorwrap">
                <div class="banner" align="center">
                    <img src="<%=Page.ResolveClientUrl("~/images/Homepage/banner_1000.jpg")%>" />
                </div>
            </div>
        </div>
        <div class="shadow_banner">
        </div>
    </div>
    <div class="clear">
        <asp:HiddenField ID="hdnprice" runat="server" />
        <asp:HiddenField ID="hdnTotal" runat="server" />
        <asp:HiddenField ID="hdndiscount" runat="server" />
        <asp:HiddenField ID="hdnAmount" runat="server" Value="0.00" />
        <asp:HiddenField ID="hdnRemainingdays" runat="server" />
        <asp:HiddenField ID="hdnDiscountPercent" runat="server" Value="" />
        <asp:HiddenField ID="hdnPkgVal" runat="server" Value="" />
        <asp:HiddenField ID="hdnoldAmount" runat="server" />
        <asp:HiddenField ID="hdnSelcPkg" runat="server" />
    </div>
    <div id="contentwrap">
        <div id="content">
            <div class="pagehead">
                Pricing</div>
            <div align="center">
                <img src="<%=Page.ResolveClientUrl("~/images/OuterImages/shadow.png")%>" /></div>
            <div class="contentblockpricing">
                <h1>
                    Law Enforcement App</h1>
                <h2>
                    Features</h2>
                <p>
                    <div class="features">
                        <ul>
                            <li>Bulletins</li>
                            <li>Updates</li>
                            <li>Event Calendar</li>
                            <li>Receive Tips</li>
                            <li>Send Push Notifications</li>
                            <li>Multiple Logins</li>
                            <li>Customizable Buttons</li>
                            <li>Web Links on App</li>
                            <li>One Touch Call Button</li>
                            <li>Receive Location Info and Photos from App</li>
                            <li>1 Click Social Media Share</li>
                            <li>Free Live Chat</li>
                            <li>Free Phone Support</li>
                        </ul>
                    </div>
                </p>
                <div class="clear">
                </div>
            </div>
            <div id="pricingcol2">
                <br/>
                <div class="phead">
                    Two way communication<br /> for your community<br /></div>
                    <div class="bhead">
                    A Branded App<br /></div>
                    <div class="bcontent">
                    with Your Name<br />and Logo</div>                 
                    <div class="phead">Available for</div>
                <div style="width: 300px; margin-left: 50px;">
                    <div class="not1">
                        <img src="<%=Page.ResolveClientUrl("~/images/OuterImages/android_icon.png")%>" /><br />
                        <span>Android</span></div>
                    <div class="not1">
                        <img src="<%=Page.ResolveClientUrl("~/images/OuterImages/apple_icon.png")%>" /><br />
                        <span>iPhone</span></div>
                    <div class="not1">
                        <img src="<%=Page.ResolveClientUrl("~/images/OuterImages/windows_icon.png")%>" /><br />
                        <span>Windows</span></div>
                </div>
                <div class="clear">
                </div>
                <div class="price">
                    $1188.00 <span>/year<br/>
                        (only $99/month)</span></div>
                <div class="signup1">
                    <asp:ImageButton ID="btnContinuePremiumPlus" runat="server" ImageUrl="~/images/OuterImages/signup.png"
                        OnClick="btnContinue_Click" OnClientClick="return CheckSelectedPackage('74','5');" /></div>
                        <div class="brandapp">
                   <b>Plus $750.00</b><br />
                   One Time Set Up Fee</div>
            </div>
            <div class="clear40">                
            </div>
        </div>
        <div class="bottombrdr">
        </div>
        <div class="clear40">
        </div>
    </div>
    <!--bodycontent end-->
    <!--footer start-->
    <div id="menu">
        <div id="footer">
            <div class="copyrights">
                <a target="_blank" href="http://www.logictreeit.com">A Product of LogicTree IT</a></div>
            <div class="footerlinks">
                <%--<a href="javascript:void(0);">Privacy Policy</a> |--%> <a href="Terms.html" target="_blank">
                    Terms of Service</a></div>
            <div class="snwrap">
                <div class="followus">
                    Follow us on</div>
                <div class="sn1">
                    <ul>
                        <li><a href="https://twitter.com/USPDHub" target="_blank">
                            <img src="<%=Page.ResolveClientUrl("~/images/Homepage/twit.png")%>" alt="Twitter" title="Twitter" /></a></li>
                        <li><a href="https://www.facebook.com/UspDhub" target="_blank">
                            <img src="<%=Page.ResolveClientUrl("~/images/Homepage/fb.png")%>" alt="Facebook" title="Facebook" /></a></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <!--footer end-->
    </form>
</body>
</html>
