<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LandingPage.aspx.cs" Inherits="USPDHUB.Business.MyAccount.LandingPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>USPD Hub Welcome Page</title>
    <style>
        *
        {
            margin: 0px;
            padding: 0px;
        }
        body
        {
            background-color: #e5e5e5;
            font-family: Arial, Helvetica, sans-serif;
            line-height: 2em;
        }
        .welcomemain_div
        {
            width: 990px;
            margin: 50px auto;
            color: #fff;
            border-radius: 10px;
            background: radial-gradient(#1c9fd8, #215b94); /* For browsers that do not support gradients */
            background: -webkit-radial-gradient(#1c9fd8, #215b94); /* Safari 5.1 to 6.0 */
            background: -o-radial-gradient(#1c9fd8, #215b94); /* For Opera 11.6 to 12.0 */
            background: -moz-radial-gradient(#1c9fd8, #215b94); /* For Firefox 3.6 to 15 */
            background: radial-gradient(#1c9fd8, #215b94); /* Standard syntax */
        }
        .welcomemain_divinner
        {
            padding: 50px;
        }
        .endingcontinue
        {
            text-align: center;
            border-bottom-right-radius: 10px;
            border-bottom-left-radius: 10px;
            background-color: #215b94;
        }
        .endingcontinue a
        {
            color: #fff;
            text-decoration: none;
            text-transform: uppercase;
            display: block;
            padding: 20px;
        }
        .welcomemain_divinner h2
        {
            margin-bottom: 5px;
        }
        .welcomelist
        {
            margin: 30px 40px;
            font-size: 13px;
        }
        .welcomelist li
        {
            list-style-type: none;
            margin-bottom: 20px;
        }
        .welcomelist li img
        {
            float: left;
            padding-right: 20px;
        }
        .welcomelist li h5
        {
            font-size: 20px;
            font-weight: normal;
            margin: 0px;
        }
        .welcomelist li p
        {
            padding-left: 70px;
            line-height: 1.5em;
        }
    </style>
</head>
<body>
    <form runat="server">
    <div class="welcomemain_div">
        <div class="welcomemain_divinner">
            <img src="<%=LogoName %>" title="logo" alt="USPDHub_Logo" />
            <h2 align="center">
                Welcome to
                <%=App_DisplayName.Replace(" ","")%>.com</h2>
            <br>
            <p>
                Here are some things you may want to think about when setting up your app.</p>
            <ul class="welcomelist">
                <li>
                    <img src="/Images/GettingStared/4.png" />
                    <h5>
                        Logo</h5>
                    <p>
                        Would you like your logo to display in the header on your App? Find it in Options.</p>
                </li>
                <li>
                    <img src="/Images/GettingStared/1.png" />
                    <h5>
                        Background Image</h5>
                    <p>
                        Would you like a background image showing off your
                        <%=agencyType %>
                        when users open your app? This is also in Options.</p>
                </li>
                <li>
                    <img src="/Images/GettingStared/2.png" />
                    <h5>
                        Short Message
                    </h5>
                    <p>
                        If you would like a short message displaying when users go to send <%=lbltext %> you may
                        add it in App Display Settings under Options.</p>
                </li>
                <li>
                    <img src="/Images/GettingStared/3.png" />
                    <h5>
                        Desktop Shortcut
                    </h5>
                    <p>
                        In Downloads you can install a desktop shortcut to conveniently access your account
                        and a Notifications Manager to receive alerts of incoming messages on your desktop.</p>
                </li>
                <li>
                    <img src="/Images/GettingStared/5.png" />
                    <h5>
                        QR Code
                    </h5>
                    <p>
                        To help get the word out to your community you are able to download a flyer with
                        a QR code that instructs users on installing your app.</p>
                </li>
                <li>
                    <img src="/Images/GettingStared/7.png" />
                    <h5>
                        Feed content to your website
                    </h5>
                    <p>
                        If you would like to automatically feed content to your website you can find that
                        in Resources under Options.</p>
                </li>
                <li>
                    <img src="/Images/GettingStared/6.png" />
                    <h5>
                        Change the button names and icons
                    </h5>
                    <p>
                        Under Options you may change the button names and icons to fit your
                        <%=agencyType %>.</p>
                </li>
            </ul>
            <p>
                The Help Menu and How To Videos provide easy to follow instructions for doing anything
                in this program.</p>
            <br />
            <p>
                If you have questions, please contact us at 800-281-0263 Monday through Friday 8
                - 5 PST. We're also available via LiveChat or email at support@<%=verticalName%>.com.</p>
        </div>
        <div class="endingcontinue">
            <a href="/Business/Myaccount/Default.aspx">Continue</a>
        </div>
    </div>
    </form>
</body>
</html>
