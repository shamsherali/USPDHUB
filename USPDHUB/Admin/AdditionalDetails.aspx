<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdditionalDetails.aspx.cs"
    MasterPageFile="~/AdminHome.master" Inherits="USPDHUB.Admin.AdditionalDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphUser" runat="Server">
    <link href="../css/reveal.css" rel="stylesheet" type="text/css" />
    <asp:ScriptManager ID="smgr1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <div class="clear15">
                </div>
                <div class="adminpagehead">
                    Additional Details</div>
                <div align="center">
                    <img src="../images/admin/shadow-title.png" /></div>
                <div class="clear15">
                </div>
                <div class="adminformwrap">
                    <div class="clear15">
                    </div>
                    <div class="successmsg_text">
                        <asp:Label ID="lblSuccess" runat="server"></asp:Label>
                    </div>
                    <div class="clear15">
                    </div>
                    <div style="text-align: center;">
                        <asp:UpdateProgress ID="UpdateProgress6" runat="server" DisplayAfter="3">
                            <ProgressTemplate>
                                <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </div>
                    <div class="clear15">
                    </div>
                    <div>
                        <asp:ValidationSummary ID="ValidateUserDetails" runat="server" ValidationGroup="A"
                            HeaderText="The following error(s) occurred:" CssClass="errormsg_text" />
                    </div>
                    <%if (hdnIsSubAccount.Value == "")
                      { %>
                    <div class="labeladm">
                        Logo</div>
                    <div class="logowrapadm">
                        <div class="logoform">
                            <asp:Image ID="logo" runat="server" Visible="false"></asp:Image>&nbsp;&nbsp;
                        </div>
                        <div class="browse">
                            <label for="fileField">
                            </label>
                            <asp:Button ID="btnLogoDelete" OnClick="btnLogoDelete_Click" OnClientClick="return confirm(' Are you sure you want to delete this logo?');"
                                runat="server" Text="Delete Logo"></asp:Button>
                            <br />
                            <asp:FileUpload ID="logoimage" runat="server"></asp:FileUpload><br />
                            NOTE: Your logo must be less than or equal to 150px X 150px. Please use gif, jpeg,
                            png or bmp files only.
                            <br>
                        </div>
                    </div>
                    <%}
                      else
                      {%>
                       <div>
                        For Sub accounts logo will be the parent logo.
                    </div>
                    <%} %>
                    <div class="clear41">
                    </div>
                    <div class="clear41">
                    </div>
                    
                    <div class="labeladm">
                        <strong>Social Media Links:</strong></div>
                    <br>
                    <br>
                    <div class="labeladm">
                        Facebook:</div>
                    <div class="txtfildwrapadm">
                        <asp:TextBox ID="txtFacebook" TabIndex="1" runat="server" MaxLength="50" class="txtfildadm">
                        </asp:TextBox></div>
                    <div class="clear10">
                    </div>
                    <div class="labeladm">
                        Twitter:</div>
                    <div class="txtfildwrapadm">
                        <asp:TextBox ID="txtTwitter" TabIndex="2" runat="server" MaxLength="50" class="txtfildadm">
                        </asp:TextBox></div>
                    <div class="clear15">
                    </div>
                </div>
                <div class="clear41">
                </div>
                <div class="clear41">
                </div>
                <div class="submitadm">
                    <asp:LinkButton ID="lnkSave" runat="server" OnClick="lnkSubmit_Click" CausesValidation="true" TabIndex="3" ><img src="../images/Admin/save.png" alt="" /></asp:LinkButton>
                    <asp:LinkButton ID="lnkNotes" runat="server" CausesValidation="false" TabIndex="4" OnClientClick="return ShortCut();" ><img src="../images/Admin/notes.png" alt="" /></asp:LinkButton>
                    <asp:LinkButton ID="lnkbNotes" runat="server" CausesValidation="false" Visible="false" TabIndex="4" OnClientClick="return ShortCut();" ><img src="../images/Admin/NewNotes.png" alt="" /></asp:LinkButton>
                    <asp:LinkButton ID="lnkcancel" runat="server" CausesValidation="false" TabIndex="5" OnClick="lnkcancel_Click" ><img src="../images/Admin/gtmscreen-btn.png" alt="" /></asp:LinkButton>
                    <asp:HiddenField ID="hdnInquiryId" runat="server" />
                    <asp:HiddenField ID="hdnphoto" runat="server" />
                    <asp:HiddenField ID="hdnNotesCnt" runat="server" />
                    <asp:HiddenField ID="hdnIsSubAccount" runat="server" />
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="lnkSave" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:Label ID="lblcreateshortcut" runat="server"></asp:Label>
            <cc1:ModalPopupExtender ID="popcreateshortcut" runat="server" TargetControlID="lblcreateshortcut"
                PopupControlID="pnlcreateshortcut" BackgroundCssClass="modal" BehaviorID="createshortcut" CancelControlID="imgclse">
            </cc1:ModalPopupExtender>
            <asp:Panel ID="pnlcreateshortcut" runat="server" Style="display: none" Width="600px">
                <table cellpadding="0" cellspacing="0" class="reveal-modal">
                    <tbody>
                        <tr>
                            <td align="left">
                                <div class="pageheading">
                                    &nbsp; Notes
                                </div>
                            </td>
                            <td align="right" style="padding: 5px 10px 0px 10px;">
                                <asp:ImageButton ID="imgclse" runat="server" ImageUrl="~/images/admin/close.png"
                                    OnClick="imgclse_Click" CausesValidation="false" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <iframe src="../ProfileIframes/AddNotes.aspx?ID=<%=InquiryId%>" frameborder="0" scrolling="no"
                                    height="500px" width="600px" style="border: 1px;" id="frmShortcut"></iframe>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <div>
                    <a class="close-reveal-modal">&#215;</a></div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
        function ShortCut() {
            var modalDialog = $find("createshortcut");
           // var iframe = document.getElementById('frmShortcut');
            modalDialog.show();
            return false;
        }
    </script>
</asp:Content>
