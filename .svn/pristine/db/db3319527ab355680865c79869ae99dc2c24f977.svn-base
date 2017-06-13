<%@ Page Title="" Language="C#" MasterPageFile="~/AdminHome.master" AutoEventWireup="true"
    CodeBehind="GeneratePromocode.aspx.cs" Inherits="USPDHUB.Admin.GeneratePromocode" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <link href="../css/reveal.css" rel="stylesheet" type="text/css" />
    <asp:ScriptManager ID="smgr1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <div class="clear15">
                </div>
                <div class="adminpagehead">
                    Promo Codes</div>
                <div align="center">
                    <img src="../images/Admin/shadow-title.png" title="USPD HUB" alt="USPD HUB" /></div>
                <div class="clear15">
                </div>
                <div class="adminformwrap">
                    <div class="clear15">
                    </div>
                    <div style="text-align: center;">
                        <asp:UpdateProgress ID="UpdateProgress6" runat="server" DisplayAfter="3">
                            <ProgressTemplate>
                                <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                    </div>
                    <div class="clear15">
                    </div>
                    <div>
                        <asp:ValidationSummary ID="ValidateUserDetails" runat="server" ValidationGroup="A"
                            HeaderText="The following error(s) occurred:" CssClass="errormsg_text" />
                    </div>
                    <div class="clear10">
                    </div>
                    <div class="labeladmenq">
                        &nbsp; Select Vertical:</div>
                    <div class="txtfildwrapadm">
                        <asp:DropDownList ID="ddlDomains" runat="server" TabIndex="4" Font-Size="13px" CssClass="ddlfildadm"
                            Width="150px" AutoPostBack="true" OnSelectedIndexChanged="ddlDomains_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <div class="labeladmenq">
                        &nbsp; Select Promocode Type:</div>
                    <div class="txtfildwrapadm" style="padding: 10px 0px;">
                        <asp:RadioButton runat="server" ID="RBSingle" Text="Single Use" Checked="true" GroupName="Type" />
                        <asp:RadioButton runat="server" ID="RBMultiple" Text="Multiple Use" GroupName="Type" />
                    </div>
                    <div>
                        <div class="labeladmenq">
                            <span class="errormsgadm">*</span>Promocode Text:</div>
                        <div class="txtfildwrapadm" style="padding: 10px 0px;">
                            <asp:RadioButton runat="server" ID="RBAutoGenerate" Text="Auto Generate" Checked="true"
                                GroupName="Type1" OnCheckedChanged="RBAutoGenerate_CheckedChanged" AutoPostBack="true" />
                            <asp:RadioButton runat="server" ID="RBCustom" Text="Custom" GroupName="Type1" AutoPostBack="true"
                                OnCheckedChanged="RBCustom_CheckedChanged" />
                        </div>
                    </div>
                    <div class="labeladmenq">
                        <span class="errormsgadm"></span>
                    </div>
                    <div class="txtfildwrapadm">
                        <asp:TextBox ID="txtPromocode" TabIndex="1" runat="server" class="txtfildadm" Width="150px">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPromocode"
                            ErrorMessage="Promocode is mandatory." SetFocusOnError="True" Display="Dynamic"
                            ValidationGroup="A">*
                        </asp:RequiredFieldValidator>
                    </div>
                    <div class="clear10">
                    </div>
                    <div>
                        <div class="labeladmenq">
                            Discount(in Percentage):</div>
                        <div class="txtfildwrapadm" style="padding: 6px 0px;">
                            <asp:TextBox ID="txtDiscount" runat="server" class="txtfildadm" Width="150px" onkeypress="return event.charCode >= 48 && event.charCode <= 57">
                            </asp:TextBox>
                            <asp:RangeValidator ID="rgvDiscount" runat="server" ControlToValidate="txtDiscount"  ValidationGroup="A" SetFocusOnError="True" Display="Dynamic"
                                Type="Integer" MinimumValue="1" MaximumValue="100" ErrorMessage="Please enter discount between 1 to 100 only">*</asp:RangeValidator>
                        </div>
                    </div>
                    <!-- Start of discount remove code -->
                    <div style="display: none;">
                        <div style="float: left; width: 45%; border: 1px solid grey; margin-right: 1px; border-radius: 2px;
                            -moz-border-radius: 2px; -webkit-border-radius: 2px; padding-left: 10px;">
                            <div>
                                <div class="labeladmenq">
                                    &nbsp;Products</div>
                                <div class="txtfildwrapadm" style="padding: 4px 0px 10px 0px;">
                                    <asp:DropDownList ID="ddlProducts" runat="server" TabIndex="4" Font-Size="13px" CssClass="ddlfildadm"
                                        Width="150px" AutoPostBack="true" OnSelectedIndexChanged="ddlProducts_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div>
                                <div class="labeladmenq">
                                    &nbsp;Price:</div>
                                <div class="txtfildwrapadm" style="padding: 4px 0px 10px 0px;">
                                    <asp:TextBox ID="txtProdPrice" ReadOnly="true" runat="server" Text="0.00" class="txtfildadm"
                                        Width="142px">
                                    </asp:TextBox>
                                </div>
                            </div>
                            <div>
                                <div class="labeladmenq">
                                    &nbsp;Discount Amount:</div>
                                <div class="txtfildwrapadm" style="padding: 4px 0px 10px 0px;">
                                    <asp:TextBox ID="txtProdDiscount" Text="0.00" runat="server" class="txtfildadm allownumber"
                                        Width="142px">
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtProdDiscount"
                                        ValidationGroup="A" ErrorMessage="Product Discount is requried.">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div>
                                <div class="labeladmenq">
                                    &nbsp;Amount to be charged:</div>
                                <div class="txtfildwrapadm" style="padding: 4px 0px 10px 0px;">
                                    <asp:TextBox ID="txtProdAmount" ReadOnly="true" runat="server" class="txtfildadm"
                                        Width="142px">
                                    </asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div style="width: 45%; margin-left: 48%; margin-top: 1.3px; border: 1px solid grey;
                            padding-bottom: 264px; border-radius: 2px; -moz-border-radius: 2px; -webkit-border-radius: 2px;
                            padding-left: 10px;">
                            <asp:Panel ID="pnlSetupFee" runat="server" Visible="false">
                                <div>
                                    <div class="labeladmenq">
                                        &nbsp;Setup Fee:</div>
                                    <div class="txtfildwrapadm" style="padding: 4px 0px 10px 0px;">
                                        <asp:TextBox ID="txtSetupPrice" ReadOnly="true" runat="server" class="txtfildadm"
                                            Width="142px">
                                        </asp:TextBox>
                                    </div>
                                </div>
                                <div>
                                    <div class="labeladmenq">
                                        &nbsp;Discount Amount:</div>
                                    <div class="txtfildwrapadm" style="padding: 4px 0px 10px 0px;">
                                        <asp:TextBox ID="txtSetupDiscount" Text="0.00" runat="server" class="txtfildadm SetupDiscount"
                                            Width="142px">
                                        </asp:TextBox>
                                    </div>
                                </div>
                                <div>
                                    <div class="labeladmenq">
                                        &nbsp;Amount to be charged:</div>
                                    <div class="txtfildwrapadm" style="padding: 4px 0px 10px 0px;">
                                        <asp:TextBox ID="txtSetupAmount" ReadOnly="true" runat="server" class="txtfildadm"
                                            Width="142px">
                                        </asp:TextBox>
                                    </div>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>
                     <!-- End of discount remove code -->
                    <div>
                        <div class="labeladmenq">
                            &nbsp;<b>Renewal Option</b><br />
                            &nbsp;Discount price for
                            <br />
                            &nbsp;Subscription Life</div>
                        <div class="txtfildwrapadm" style="padding: 10px 0px;">
                            <asp:RadioButton runat="server" ID="rbLifeTimeNo" Text="No" Checked="true" GroupName="LifeTime" />
                            <asp:RadioButton runat="server" ID="rbLifeTimeYes" Text="Yes" GroupName="LifeTime" />
                        </div>
                    </div>
                    <div style="margin-top: 10px;">
                        <div class="labeladmenq">
                            <span class="errormsgadm">*</span> &nbsp; Approved By Initials
                            <asp:TextBox ID="txtInitailFirst" runat="server" Width="120px">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvInitalFirst" runat="server" ControlToValidate="txtInitailFirst"
                                ValidationGroup="A" ErrorMessage="Initial first name is requried.">*</asp:RequiredFieldValidator></div>
                        <div class="txtfildwrapadm" style="padding: 10px 0px; padding-left: 200px;">
                            <asp:TextBox ID="txtInitailLast" runat="server" Width="120px">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvInitalSecond" runat="server" ControlToValidate="txtInitailFirst"
                                ValidationGroup="A" ErrorMessage="Initial last name is requried.">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <!-- Start of remove code -->
                    <div style="display: none;">
                        <div style="float: left;">
                            <div class="labeladmenq">
                            </div>
                            <div class="txtfildwrapadm" style="padding: 10px 0px;">
                                <asp:RadioButton runat="server" ID="rbPerncent" Text="Percent" Checked="true" GroupName="PromocodeFor"
                                    onclick="ShowPromocodeforAmountType(1);" />
                                <asp:RadioButton runat="server" ID="rbAmount" Text="Dollar Amount" GroupName="PromocodeFor"
                                    onclick="ShowPromocodeforAmountType(2);" />
                            </div>
                        </div>
                        <div class="labeladmenq">
                            <span class="errormsgadm"></span>
                        </div>
                        <div id="PercentBox">
                            <div class="labeladmenq">
                                <span class="errormsgadm"></span>&nbsp;Percentage:
                            </div>
                            <div class="txtfildwrapadm" style="margin-left: -5px;">
                                <asp:TextBox ID="txtPercentage" TabIndex="1" runat="server" MaxLength="3" class="txtfildadm"
                                    Width="150px">
                                </asp:TextBox>
                                <asp:RangeValidator ID="RangeValidator1" runat="server" Type="Integer" MinimumValue="0"
                                    ValidationGroup="A" MaximumValue="100" ControlToValidate="txtPercentage" ErrorMessage="Percentage must be a whole number between 0 and 100">*</asp:RangeValidator>
                            </div>
                        </div>
                        <div id="AmountBox" style="display: none;">
                            <div class="labeladmenq">
                                <span class="errormsgadm"></span>&nbsp;Amount:
                            </div>
                            <div class="txtfildwrapadm" style="margin-left: -5px;">
                                <span style="float: left; margin-top: 5px;">$</span>
                                <asp:TextBox ID="txtAmount" TabIndex="1" runat="server" class="txtfildadm" Width="150px"
                                    onkeyup="return AllowNumbers();">
                                </asp:TextBox>
                            </div>
                        </div>
                        <div class="clear10">
                        </div>
                        <div>
                            <div class="labeladmenq">
                                <span class="errormsgadm">*</span>&nbsp;Apply Discount to:
                            </div>
                            <div class="txtfildwrapadm">
                                <span id="rdbProduct">
                                    <asp:RadioButton runat="server" ID="RBProdcut" Text="Products Total" Checked="true"
                                        GroupName="Type3" /></span> <span id="rdbInvoice">
                                            <asp:RadioButton runat="server" ID="RBInvoice" Text="Invoice Total" GroupName="Type3" /></span>
                            </div>
                        </div>
                    </div>
                    <!-- End of remove code -->
                    <div class="clear10">
                    </div>
                    <div class="labeladmenq">
                        <span class="errormsgadm">*</span>&nbsp;Expiration Date:</div>
                    <div class="txtfildwrapadm">
                        <asp:TextBox ID="txtExpiryDate" TabIndex="2" runat="server" class="txtfildadm" Width="150px">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqdate" runat="server" ControlToValidate="txtExpiryDate"
                            ValidationGroup="A" ErrorMessage="Expiry Date is mandatory.">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularDate11" runat="server" ControlToValidate="txtExpiryDate"
                            ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                            ValidationGroup="A" ErrorMessage="Invalid Expiry Date Format">*</asp:RegularExpressionValidator><br />
                        <cc1:CalendarExtender ID="calex" runat="server" TargetControlID="txtExpiryDate" Format="MM/dd/yyyy"
                            CssClass="MyCalendar" />
                    </div>
                    <div class="clear10">
                    </div>
                    <div class="labeladmenq">
                        &nbsp; Description:</div>
                    <div class="txtfildwrapadm">
                        <asp:TextBox ID="txtPromoDes" runat="server" TextMode="MultiLine" onchange="CheckLength()"
                            Width="230px" Height="60px"></asp:TextBox>
                    </div>
                    <div class="clear10">
                    </div>
                </div>
                <div class="clear41">
                </div>
                <div class="clear41">
                </div>
                <div class="submitadm">
                    <asp:LinkButton ID="lnkBack" runat="server" CausesValidation="false" TabIndex="6"
                        OnClick="lnkBack_Click"><img src="../images/Admin/cancel.png" alt="" /></asp:LinkButton>
                    <asp:LinkButton ID="lnkSave" runat="server" CausesValidation="true" TabIndex="5"
                        ValidationGroup="A" OnClick="lnkSave_Click"><img src="../images/Admin/save.png" alt="" /></asp:LinkButton>
                </div>
            </div>
            <div style="display: none;">
                <asp:GridView ID="grdPromocodes" runat="server" AllowSorting="true" AutoGenerateColumns="False"
                    AllowPaging="true" Width="100%" CssClass="datagrid2">
                    <Columns>
                        <asp:TemplateField HeaderText="Promo code">
                            <ItemTemplate>
                                <asp:Label ID="lblPromocode_Name" runat="server" Text='<%#Eval("Promocode_Name") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Percentage">
                            <ItemTemplate>
                                <asp:Label ID="lblPromocode_Value" runat="server" Text='<%#Eval("Promocode_Value") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="150px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Duration">
                            <ItemTemplate>
                                <asp:Label ID="lblDuration_Value" runat="server" Text='<%#Eval("Duration") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="150px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Created Date">
                            <ItemTemplate>
                                <asp:Label ID="lblCreatedDate" runat="server" Text='<%#Eval("Created_Date") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="150px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Expiry Date">
                            <ItemTemplate>
                                <asp:Label ID="lblPromoCode_ExpiryDate" runat="server" Text='<%#Eval("PromoCode_ExpiryDate") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="150px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Vertical Name">
                            <ItemTemplate>
                                <asp:Label ID="lblVerticalname" runat="server" Text='<%#Eval("Domain_Name") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="150px" />
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle CssClass="title1" />
                    <EmptyDataRowStyle ForeColor="#C00000" />
                    <AlternatingRowStyle BackColor="#EEECEC"></AlternatingRowStyle>
                </asp:GridView>
            </div>
            <div>
                <asp:HiddenField ID="hdnexpDate" runat="server" />
                <asp:HiddenField ID="hdnHowmany" runat="server" />
                <asp:HiddenField ID="hdnDomain" runat="server" />
                <asp:HiddenField ID="hdnPromo" runat="server" />
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="lnkSave" />
        </Triggers>
    </asp:UpdatePanel>
    <script type="text/javascript">
        function ShowSuccessMsg() {
            alert("Promocode has been saved successfully.");
        } 
        
    </script>
    <script type="text/javascript">
        function CheckLength() {
            var textbox = document.getElementById("<%=txtPromoDes.ClientID%>").value;
            if (textbox.trim().length > 500) {
                text.value = textbox.value.substring(0, 500);
                return false;
            }
            else
                return true;
        }

        function ShowPromocodeforAmountType(type) {
            //****Here if TYPE is 1 says Percentage Type is 2 says Dollor Amount****//
            if (type == '1') {
                document.getElementById('AmountBox').style.display = "none";
                document.getElementById('PercentBox').style.display = "Block";
                document.getElementById("<%=txtPercentage.ClientID%>").value = "100";
                $('#rdbInvoice').show()
            }
            else {
                document.getElementById('PercentBox').style.display = "none";
                document.getElementById('AmountBox').style.display = "Block";
                document.getElementById("<%=txtAmount.ClientID%>").value = "0";
                $('#rdbInvoice').hide();
                document.getElementById("<%=RBProdcut.ClientID%>").checked = true;
            }
        }

        function AllowNumbers() {
            var amount = document.getElementById("<%=txtAmount.ClientID%>").value;
            if (isNaN(amount)) {
                document.getElementById("<%=txtAmount.ClientID%>").value = "";
                alert("Please Enter Numbers Only.");
                return false;
            }
            else
                return true;
        }
     
    </script>
    <script type="text/javascript">
        $(document).keypress(function () {
            $(".allownumber").keypress(function () {
                if ((event.which != 46 || $(this).val().indexOf('.') != -1) && (event.which < 48 || event.which > 57)) {
                    event.preventDefault();
                }
                var text = $(this).val();
                if ((text.indexOf('.') != -1) && (text.substring(text.indexOf('.')).length > 2)) {
                    event.preventDefault();
                }
            });
            $(".allownumber").keyup(function () {
                var text = $(this).val();
                var price = parseFloat($("#<%=txtProdPrice.ClientID %>").val());
                if (text == '')
                    text = '0.00';
                var discount = parseFloat(text);
                if (discount > price) {
                    alert('Discount should be less than or equals to Product Price.');
                    $(this).val(text.slice(0, -1))
                }
                else
                    $("#<%=txtProdAmount.ClientID %>").val((price - discount).toFixed(2));
            });
        });
        $(document).keypress(function () {
            $(".SetupDiscount").keypress(function () {
                if ((event.which != 46 || $(this).val().indexOf('.') != -1) && (event.which < 48 || event.which > 57)) {
                    event.preventDefault();
                }
                var text = $(this).val();
                if ((text.indexOf('.') != -1) && (text.substring(text.indexOf('.')).length > 2)) {
                    event.preventDefault();
                }
            });
            $(".SetupDiscount").keyup(function () {
                var text = $(this).val();
                var price = parseFloat($("#<%=txtSetupPrice.ClientID %>").val());
                if (text == '')
                    text = '0.00';
                var discount = parseFloat(text);
                if (discount > price) {
                    alert('Discount should be less than or equals to setup fee.');
                    $(this).val(text.slice(0, -1))
                }
                else
                    $("#<%=txtSetupAmount.ClientID %>").val((price - discount).toFixed(2));
            });
        });
    </script>
</asp:Content>
