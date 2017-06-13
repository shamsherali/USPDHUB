<%@ Page Title="" Language="C#" MasterPageFile="~/AdminHome.master" AutoEventWireup="true" CodeBehind="BillingHistory.aspx.cs" Inherits="USPDHUB.Admin.BillingHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">

<link href="../../css/InvoiceDetails.css" rel="stylesheet" type="text/css" />
    <link href="../../css/Invoicestyle.css" rel="stylesheet" type="text/css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
    <script type="text/javascript" src="../../Scripts/bootstrap.min.js"></script>
    <style type="text/css">
        .list-inline
        {
            margin-top: 0px;
            margin-left: -38px;
            list-style: none;
        }
        
        .popupTool
        {
            background-color: #ffffff;
            position: absolute;
            display: inline-block;
            padding: .2em .5em;
            width: 160px;
            height: 29px;
        }
        .popupTool::after
        {
            border-bottom: 10px solid #ffffff;
            border-left: 10px solid transparent;
            border-right: 10px solid transparent;
            width: 0;
            height: 0;
            content: "";
            display: block;
            position: absolute;
            bottom: 100%;
            left: 1em;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.a-popover-trigger').popover({
                animation: false,
                html: true,
                content: function () {
                    return $(this).closest("span.a-color-secondary").next('div.billinginfo:first').html();
                }
            });
            $(".toggleOrderIems").click(function () {
                var orderItems = $(this).closest("div.order-info").next("div.a-orderitems:first");
                if (orderItems.css("display") == "none")
                    orderItems.css("display", "block")
                else
                    orderItems.css("display", "none")
                //$(this).closest('').css("display", "block");
                //                if (!$(this).hasClass('toggleArrowClose')) {
                //                    $(this).closest('table').next().css("display", "block");
                //                    $(this).css('background-image', 'url(../../Images/StoreImages/arrow-up.png)');
                //                    $(this).addClass("toggleArrowClose");
                //                    $(this).removeClass("toggleArrow");

                //                } else {
                //                    $(this).closest('table').next().css("display", "none");
                //                    $(this).css('background-image', 'url(../../Images/StoreImages/arrow-down.png)');
                //                    $(this).addClass("toggleArrow");
                //                    $(this).removeClass("toggleArrowClose");
                //                }
            });
        });
        function ShowOrderItems() {

        }

        function GetPopupTool(obj) {
            $("#" + obj).show();

        }
        function closePopupTool(obj) {
            $("#" + obj).hide();
        }

  
    </script>
    <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" class="page-padding">
        <tr>
            <td class="valign-top">
                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="page-title">
                    <tr>
                        <td>
                            <h3>
                                Billing History</h3>
                        </td>
                        <td style="padding-right: 70px;">
                           <%-- <asp:UpdateProgress ID="UpdateProgress6" runat="server" DisplayAfter="3">
                                <ProgressTemplate>
                                    <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                </ProgressTemplate>
                            </asp:UpdateProgress>--%>
                        </td>
                    </tr>
                    <tr>
                    <td style="height:30px;"></td>
                    <td></td>
                    </tr>
                    <tr>
                    <td>Profile Name: <asp:Label ID="lblPname" runat="server"></asp:Label> </td>
                    <td style="text-align:right;">User ID: <asp:Label ID="lblUid" runat="server"></asp:Label> </td>
                    
                    </tr>
                </table>
                <table cellpadding="0" cellspacing="0" border="0" id="tabber" width="100%">
                    <colgroup>
                        <col width="310px" />
                        <col width="*" />
                    </colgroup>
                    <tr>
                        <td colspan="2" class="content">
                            <div class="ordersContainer">
                                <asp:Repeater ID="rptrInvoiceDetails" runat="server" OnItemDataBound="rptrInvoice_OnItemDataBound">
                                    <ItemTemplate>
                                        <div class="a-box-group a-spacing-base order">
                                            <div class="a-box a-color-offset-background order-info">
                                                <div class="a-box-inner">
                                                    <div class="a-fixed-right-grid">
                                                        <div class="a-fixed-right-grid-inner" style="padding-right: 180px">
                                                            <div class="a-fixed-right-grid-col a-col-left" style="padding-right: 0%; *width: 99.6%;
                                                                float: left;">
                                                                <div class="a-row">
                                                                    <div class="a-column a-span3">
                                                                        <div class="a-row a-size-mini">
                                                                            <span class="a-color-secondary label">Order placed </span>
                                                                        </div>
                                                                        <div class="a-row a-size-base">
                                                                            <span class="a-color-secondary value">
                                                                                <%#Eval("Start_Date", "{0:MMMM dd yyyy}")%></span>
                                                                        </div>
                                                                    </div>
                                                                    <div class="a-column a-span2">
                                                                        <div class="a-row a-size-mini">
                                                                            <span class="a-color-secondary label">Total </span>
                                                                        </div>
                                                                        <div class="a-row a-size-base">
                                                                            <span class="a-color-secondary value">$<%#Eval("Billable_Amount")%></span>
                                                                        </div>
                                                                    </div>
                                                                    <div class="a-column a-span7 recipient a-span-last">
                                                                        <div class="a-row a-size-mini">
                                                                            <span class="a-color-secondary label">Billing To </span>
                                                                        </div>
                                                                        <div class="a-row a-size-base">
                                                                            <span class="a-color-secondary"><span class="a-declarative"><a href="javascript:void(0)"
                                                                                class="a-popover-trigger a-declarative value" data-content="" rel="popover" data-placement="bottom"
                                                                                data-trigger="hover"><span class="trigger-text">
                                                                                    <%#Eval("Billing_Name")%></span><i class="a-icon a-icon-popover"></i></a> </span>
                                                                            </span>
                                                                            <div id="biilingInfo" class="billinginfo" style="display: none;">
                                                                                <div class="a-popover-wrapper" style="width: 300px; height: auto; z-index: 10001;
                                                                                    position: absolute;">
                                                                                    <div class="a-popover-a11y-container">
                                                                                        <span tabindex="0" role="dialog" class="a-popover-start aok-offscreen" aria-label="Recipient address">
                                                                                        </span>
                                                                                    </div>
                                                                                    <div class="a-popover-inner" style="height: auto; overflow-y: auto;">
                                                                                        <div class="a-popover-content" id="a-popover-content-1">
                                                                                            <div class="a-row recipient-address">
                                                                                                <div class="displayAddressDiv">
                                                                                                    <ul class="displayAddressUL">
                                                                                                        <li class="displayAddressLI displayAddressFullName"><span class="id-addr-ux-search-text">
                                                                                                            <%#Eval("Billing_Name")%></span></li>
                                                                                                        <li class="displayAddressLI displayAddressAddressLine1"><span class="id-addr-ux-search-text">
                                                                                                            <%#Eval("Billing_Address")%></span></li>
                                                                                                        <li class="displayAddressLI displayAddressCityStateOrRegionPostalCode"><span class="id-addr-ux-search-text">
                                                                                                            <%#Eval("Billing_City")%>,
                                                                                                            <%#Eval("Billing_State")%>
                                                                                                            <%#Eval("Billing_Zipcode")%></span></li>
                                                                                                        <li class="displayAddressLI displayAddressCountryName"><span class="id-addr-ux-search-text">
                                                                                                            <%#Eval("Billing_Country")%></span></li>
                                                                                                        <%--<li class="displayAddressLI displayAddressPhoneNumber"><span class="id-addr-ux-search-text">
                                                                                                                    Phone: 916-365-3082</span></li>--%>
                                                                                                    </ul>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                    <span tabindex="0" class="a-popover-end aok-offscreen"></span>
                                                                                    <div class="a-arrow-border" style="left: 125px;">
                                                                                        <div class="a-arrow">
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="a-fixed-right-grid-col actions a-col-right" style="width: 180px; margin-right: -180px;
                                                                float: left;">
                                                                <div class="a-row a-size-mini">
                                                                    <span class="a-color-secondary label">Order # </span><span class="a-color-secondary value">
                                                                        <%#Eval("InvoiceID")%>
                                                                    </span>
                                                                </div>
                                                                <div class="a-row a-size-base">
                                                                    <ul class="a-nostyle a-vertical">
                                                                        <asp:LinkButton ID="lnkDownload" runat="server" CommandArgument='<%#Eval("InvoiceID") %>'
                                                                            OnClick="lnkDownload_Click">Download</asp:LinkButton><i class="a-icon a-icon-text-separator"></i>
                                                                        <a class="a-link-normal toggleOrderIems"><i class="a-icon a-icon-popover"></i></a>
                                                                    </ul>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <asp:Panel ID="pnlOrders" CssClass="a-orderitems a-box" runat="server" Style="display: none;">
                                                <div class="shipment">
                                                    <div class="a-box-inner">
                                                        <div class="a-fixed-right-grid a-spacing-top-medium">
                                                            <div class="a-fixed-right-grid-inner" style="padding-right: 220px">
                                                                <div class="a-fixed-right-grid-col a-col-left" style="padding-right: 3.2%; *width: 96.4%;
                                                                    float: left;">
                                                                    <div class="a-row">
                                                                        <asp:Repeater ID="rptrOrders" runat="server">
                                                                            <ItemTemplate>
                                                                                <div class="a-fixed-left-grid a-spacing-base">
                                                                                    <div class="a-fixed-left-grid-inner" style="padding-left: 65px">
                                                                                        <div class="a-text-center a-fixed-left-grid-col a-col-left" style="width: 100px;
                                                                                            margin-left: -100px; _margin-left: -50px; float: left;">
                                                                                            <div class="item-view-left-col-inner">
                                                                                                <img alt="" src='../../Images/StoreImages/<%#Eval("Store_Image_Icon")%>' aria-hidden="true"
                                                                                                    title="" data-a-hires='../../Images/StoreImages/<%#Eval("Store_Image_Icon")%>' />
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="a-fixed-left-grid-col a-col-right" style="padding-left: 1.5%; *width: 98.1%;
                                                                                            float: left;">
                                                                                            <div class="a-row">
                                                                                                <%#Eval("Title")%>
                                                                                            </div>
                                                                                            <div class="a-row">
                                                                                                <span class="a-size-small a-color-secondary">Quantity:
                                                                                                    <%#Eval("Quantity")%>
                                                                                                </span>
                                                                                            </div>
                                                                                            <div class="a-row">
                                                                                                <span class="a-size-small a-color-price">$<%#Eval("Billable_Amount")%>
                                                                                                </span>
                                                                                            </div>
                                                                                            <div class="a-row">
                                                                                                <span class="a-color-secondary a-text-bold"></span><span class="a-color-secondary">
                                                                                                </span>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </asp:Repeater>
                                                                    </div>
                                                                </div>
                                                                <div class="a-fixed-right-grid-col a-col-right" style="width: 220px; margin-right: -220px;
                                                                    float: left; display: none;">
                                                                    <div class="a-row">
                                                                        <div class="a-button-stack">
                                                                            <span class="a-button a-button-normal a-spacing-mini" id="a-autoid-4"><span class="a-button-inner">
                                                                                <a id="Return-or-replace-items_1" href="javascript:void(0);" class="a-button-text"
                                                                                    role="button"></a></span></span><span class="a-button a-button-normal a-spacing-mini"
                                                                                        id="a-autoid-5"><span class="a-button-inner"><a id="Write-a-product-review_1" href="javascript:void(0);"
                                                                                            class="a-button-text" role="button"></a></span></span><span class="a-declarative"
                                                                                                data-action="a-modal"><span class="a-button a-button-normal a-spacing-mini" id="a-autoid-6">
                                                                                                    <span class="a-button-inner"><a id="Archive-order_1" href="javascript:void(0);" class="a-button-text"
                                                                                                        role="button"></a></span></span></span>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </asp:Panel>
                                            <asp:HiddenField ID="hdnSubscriptionID" Value='<%#Eval("InvoiceID") %>' runat="server" />
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <%-- <a href="#" class="pull-right invoiceolder">Older</a>--%>
                            <div class="a-row">
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

</asp:Content>
