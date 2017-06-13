<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="InschoolAlert.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>inSchool ALERT</title>
    <!-- Bootstrap core CSS -->
    <link href="<%=Page.ResolveClientUrl("~/css/bootstrap.css")%>" rel="stylesheet">
    <link href="<%=Page.ResolveClientUrl("~/css/custom.css")%>" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
    <div class="container-fluid no-padding">
        <header>
    <div class="container">
      <div class="logo"><img src="images/inschoolalert.png" alt="InSchoolAlert"></div>
      <div class="top-btn-right" id="navigation">
      
       
                                <a href="Javascript:void(0);" class="active">Home</a> | <a href="HowToWorks.aspx">
                                    How It Works</a> | <a href="features.htm">Pricing</a> | <a href="AboutUs.htm">About Us</a>
                                |          <button type="button" class="btn btn-green">Login</button>
      </div>
    </div>
  </header>
    </div>
    <div class="container-fluid no-padding">
        <div class="banner-bg">
            <div class="img-overly">
                <div class="container">
                    <div class="col-sm-6 hidden-xs">
                        <div class="video-container margintop30">
                            <iframe src="http://player.vimeo.com/video/160410752" width="560" height="315" frameborder="0"
                                webkitallowfullscreen mozallowfullscreen allowfullscreen></iframe>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <h1 class="slide-header">
                            Emergency Alert And Notification System For Schools</h1>
                        <p class="btn-signup">
                            <a class="btn btn-green" href="AgencyListing.aspx">Sign Up</a>
                        </p>
                        <p class="slider-text">
                            A proven app platform used and trusted by Law Enforcement</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid no-padding green-bg">
        <div class="container">
            <div class="col-sm-6 col-md-4 service-main">
                <div class="service-wrap">
                    <img src="images/Connect-first-responders.png" alt="connect first responders">
                </div>
                <div class="service-title">
                    Connects easily to first responders</div>
            </div>
            <div class="col-sm-6 col-md-4 service-main">
                <div class="service-wrap">
                    <img src="images/Notify-key-personnel.png" alt="Notifies key personnel">
                </div>
                <div class="service-title">
                    Quickly notifies key personnel to expedite safe mode</div>
            </div>
            <div class="col-sm-6 col-md-4 service-main">
                <div class="service-wrap">
                    <img src="images/inform-school-community-crisis.png" alt="Keeps school community informed during crisis">
                </div>
                <div class="service-title">
                    Keeps school community informed during a crisis</div>
            </div>
        </div>
        <div class="container">
            <div class="col-lg-12">
                <div class="buy-btn clearfix">
                    <a class="btn btn-blue btn-lg" href="AgencyListing.aspx">Buy for $25.00/month</a>
                </div>
            </div>
        </div>
    </div>
    <footer>
  <div class="container">
    <div class="footer-text">LogicTree IT Solutions Inc.  |   6060 Sunrise Vista Drive, Suite 3500  |  Citrus Heights, CA 95610</div>
    <div class="footer-text margintop10"><a href="mailto:info@logictreeit.com">Info@LogicTreeIT.com</a> |  916.676.7335  |  800.281.0263</div>
  </div>
</footer>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    </form>
</body>
</html>
