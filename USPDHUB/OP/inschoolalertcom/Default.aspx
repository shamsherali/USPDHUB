<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="USPDHUB.OP.inschoolalertcom.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8"><link rel="icon" href="/images/ishfav.ico" type="image/x-icon" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Mobile App for Community Outreach, Greater School Safety from inSchoolAlert.com
    </title>
    <!-- Bootstrap core CSS -->
    <link href="<%=Page.ResolveClientUrl("~/css/bootstrap.css")%>" rel="stylesheet">
    <link href="<%=Page.ResolveClientUrl("~/css/custom.css")%>" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
    <div class="container-fluid no-padding">
        <header>
            <div class="container">
                <div class="logo"><img src="<%=Page.ResolveClientUrl("~/images/ISAOuterImages/isa-logo.png")%>" alt="InSchoolAlert"></div>
                <div class="top-btn-right" id="navigation">
                    <a href="Javascript:void(0);" class="active">Home</a> | <a href="HowToWorks.aspx">
                                        How It Works</a> | <a href="features.html">Pricing</a> | <a href="AboutUs.html">About Us</a>
                                    | <a href="Login.aspx" class="btn btn-green">Sign In</a>
                </div>
            </div>
        </header>
    </div>
    <div class="container-fluid no-padding">
        <div class="banner-bg">
            <div class="img-overly">
                <div class="container">
                    <div class="col-sm-6">
                        <div class="video-container margintop30">                            
                            <iframe src="http://player.vimeo.com/video/162568140" width="560" height="315" frameborder="0"
                                webkitallowfullscreen mozallowfullscreen allowfullscreen></iframe>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <h1 class="slide-header" style="max-width:490px;">
                            Emergency Alert And Notification Mobile App For Schools</h1>
                        <p class="btn-signup">
                            <a class="btn btn-green" href="AgencyListing.aspx">Sign Up</a>
                        </p>
                        <p class="slider-text">
                            $25.00/month per school</p>
                            <p class="slider-text">
                            Free downloads for school community</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid no-padding green-bg">
        <div class="container">
            <div class="col-sm-6 col-md-4 service-main">
                <div class="service-wrap">
                    <img src="<%=Page.ResolveClientUrl("~/images/ISAOuterImages/Notify-key-personnel.png")%>"
                        alt="connect first responders">
                </div>
                <div class="service-title">
                    Connects easily to first responders</div>
            </div>
            <div class="col-sm-6 col-md-4 service-main">
                <div class="service-wrap">
                    <img src="<%=Page.ResolveClientUrl("~/images/ISAOuterImages/Connect-first-responders.png")%>"
                        alt="Notifies key personnel">
                </div>
                <div class="service-title">
                    Quickly notifies key personnel to expedite safe mode</div>
            </div>
            <div class="col-sm-6 col-md-4 service-main">
                <div class="service-wrap">
                    <img src="<%=Page.ResolveClientUrl("~/images/ISAOuterImages/inform-school-community-crisis.png")%>"
                        alt="Keeps school community informed during crisis">
                </div>
                <div class="service-title">
                    Keeps School Community Updated During Emergencies and Day to Day Information
                </div>
            </div>
            <%-- <div class="col-sm-6 col-md-4 service-main">
                <div class="service-wrap">
                    <img src="<%=Page.ResolveClientUrl("~/images/ISAOuterImages/TextMessageForDashboard.png")%>"
                        alt="Keeps school community informed during crisis">
                </div>
                <div class="service-title">
                    Send important notifications by text and push as needed</div>
            </div>--%>
        </div>
        <div class="container">
            <div class="col-lg-12">
                <div class="buy-btn clearfix">
                    <a class="btn btn-blue btn-lg" href="AgencyListing.aspx">Subscribe</a>
                </div>
            </div>
        </div>
    </div>
    <footer>
        <div class="container">
            <div class="footer-text">LogicTree IT Solutions Inc.  |   6060 Sunrise Vista Drive, Suite 3500  |  Citrus Heights, CA 95610</div>
            <div class="footer-text margintop10"><a href="mailto:info@logictreeit.com">Info@LogicTreeIT.com</a> | <a href="http://www.logictreeit.com" target="_blank">www.logictreeit.com</a> |  800.281.0263</div>
        </div>
     </footer>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="../../Scripts/bootstrap.min.js" type="text/javascript"></script>
    </form>
</body>
</html>
