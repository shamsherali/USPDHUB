<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true"
    CodeBehind="RequestCustomForm.aspx.cs" Inherits="USPDHUB.Business.MyAccount.RequestCustomForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <link href="../../css/marketplace.css" rel="stylesheet" type="text/css" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="heading">
            </div>
            <div id="paymentwrap">
                <!--checkoutwrap starts-->
                <div id="checkoutwrapper">
                    <div id="process-two">
                        <div id="infobox">
                            <div class="head">
                                <asp:Label ID="lblFormType" Text="Request Custom Form" runat="server" Font-Bold="true"></asp:Label></div>
                            <div style="width: 400px; margin: 10px auto;">
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" tyle="text-align: left;"
                                    ValidationGroup="validate" HeaderText="The following error(s) occurred:" />
                                <asp:Label ID="lblMessage" runat="server"></asp:Label>
                            </div>
                            <div class="infocontent">
                                <div style="float: left; width: 80px;">
                                    <span style="color: Red;">*</span> Description:</div>
                                <asp:TextBox ID="txtDescription" runat="server" CssClass="paymenttxtfld" TextMode="MultiLine"
                                    Width="300px" Height="50px"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtDescription" ValidationGroup="validate"
                                    ErrorMessage="Description is mandatory">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="infocontent">
                                <div style="float: left; width: 80px;">
                                    <span style="color: Red; padding-left: 5px;">&nbsp;</span>Remarks:</div>
                                <asp:TextBox ID="txtRemarks" runat="server" CssClass="paymenttxtfld" TextMode="MultiLine"
                                    Width="300px" Height="50px"></asp:TextBox>
                            </div>
                            <div class="infocontent">
                                <div style="float: left; width: 80px;">
                                    &nbsp;
                                </div>
                                <asp:Button runat="server" ID="btnSubmit" Text="Submit" ValidationGroup="validate"
                                    OnClick="btnSubmit_Click" />
                                &nbsp;
                                <asp:Button runat="server" ID="btncancel" Text="Cancel" OnClick="btncancel_Click" />
                            </div>
                        </div>
                    </div>
                    <!--process-two div-->
                </div>
                <!--checkoutwrap ends-->
                <div class="clear">
                </div>
            </div>
            <div class="clear">
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
