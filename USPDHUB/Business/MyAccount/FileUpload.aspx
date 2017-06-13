<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin.master" CodeBehind="FileUpload.aspx.cs"
    Inherits="USPDHUB.Business.MyAccount.FileUpload1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <script src="../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../Scripts/AjaxFileupload.js" type="text/javascript"></script>
    <link href="../../css/Bulletins.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">

        // check extension of file to be upload
        function checkFileExtension(file) {
            var flag = true;
            var extension = file.substr((file.lastIndexOf('.') + 1));

            switch (extension) {
                case 'jpg':
                case 'jpeg':
                case 'png':
                case 'gif':
                
                case 'JPG':
                case 'JPEG':
                case 'PNG':
                case 'GIF':                
                    flag = true;
                    break;
                default:
                    flag = false;
            }

            return flag;
        }

        //get file path from client system
        function getNameFromPath(strFilepath) {

            var objRE = new RegExp(/([^\/\\]+)$/);
            var strName = objRE.exec(strFilepath);

            if (strName == null) {
                return null;
            }
            else {
                return strName[0];
            }

        }
        // Asynchronous file upload process
        function ajaxFileUpload() {

            var FileFolder = $('#hdnFileFolder').val();
            var fileToUpload = getNameFromPath($('#fileToUpload').val());
            var filename = fileToUpload.substr(0, (fileToUpload.lastIndexOf('.')));
            if (checkFileExtension(fileToUpload)) {

                var flag = true;
                var counter = $('#hdnCountFiles').val();

                if (filename != "" && filename != null && FileFolder != "0") {
                    //Check duplicate file entry
                    for (var i = 1; i <= counter; i++) {
                        var hdnDocId = "#hdnDocId_" + i;

                        if ($(hdnDocId).length > 0) {
                            var mFileName = "#lblfilename_" + i;
                            if ($(mFileName).html() == filename) {
                                flag = false;
                                break;
                            }

                        }
                    }
                    if (flag == true) {
                        $.ajaxFileUpload({
                            url: 'FileUpload.ashx?id=' + FileFolder,
                            secureuri: false,
                            fileElementId: 'fileToUpload',
                            dataType: 'json',
                            success: function (data, status) {

                                if (typeof (data.error) != 'undefined') {
                                    if (data.error != '') {
                                        alert(data.error);
                                    } else {                                        
                                        $('#fileToUpload').val("");
                                    }
                                }
                            },
                            error: function (data, status, e) {
                                alert(e);
                            }
                        });
                    }
                    else {
                        alert('file ' + filename + ' already exist')
                        return false;
                    }
                }
            }
            else {
                alert('You can upload only jpg,jpeg,pdf,doc,docx,txt,zip,rar extensions files.');
            }
            return false;
        } 
    </script>
    <div id="wrapper">
        <div class="header">
            <div class="datawrap">
                <div class="logo">
                    <img src="../../images/BulletinThumbs/logo.png" alt="logo" title="logo" /></div>
                <div class="txtwrap">
                    <h1>
                        Paradise Police Department</h1>
                    <h2>
                        Non Emergency 530-872-6241</h2>
                    <h4>
                        Emergency 9-1-1</h4>
                </div>
            </div>
        </div>
        <div class="clear">
        </div>
        <div class="contentwrap">
            <div class="largetxt">
                Stolen Vehicle</div>
            <div class="browseimg_wrap">
                <div class="avatar">
                    <%if (hdnMissingVeh.Value != "")
                      { %>
                    <img src="../../images/BulletinThumbs/vehicle.jpg" id="imgMissingVeh" />
                    <%} %>
                    <asp:HiddenField ID="hdnMissingVeh" runat="server" />
                </div>
            </div>
            <div class="form_wrapper">
                <div class="fields_wrap ">
                    <div class="left_lable">
                        <label>
                            Make :</label>
                    </div>
                    <div class="right_fields">
                        <asp:TextBox ID="txtMake" runat="server" CssClass="txtfild1"></asp:TextBox>
                    </div>
                </div>
                <div class="fields_wrap ">
                    <div class="left_lable">
                        <label>
                            Model :</label></div>
                    <div class="right_fields">
                        <asp:TextBox ID="txtModel" runat="server" CssClass="txtfild1"></asp:TextBox>
                    </div>
                </div>
                <div class="fields_wrap ">
                    <div class="left_lable">
                        <label>
                            Style :</label>
                    </div>
                    <div class="right_fields">
                        <asp:TextBox ID="txtStyle" runat="server" CssClass="txtfild1"></asp:TextBox>
                    </div>
                </div>
                <div class="fields_wrap ">
                    <div class="left_lable">
                        <label>
                            Year :</label></div>
                    <div class="right_fields">
                        <asp:DropDownList ID="ddlMfdYear" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="fields_wrap ">
                    <div class="left_lable">
                        <label>
                            Color :</label></div>
                    <div class="right_fields">
                        <asp:DropDownList ID="ddlColors" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="fields_wrap ">
                    <div class="left_lable">
                        <label>
                            State :</label></div>
                    <div class="right_fields">
                        <asp:DropDownList ID="ddlStates" runat="server" Style="width: 130px;">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="fields_wrap ">
                    <div class="left_lable">
                        <label>
                            License Plate # :</label>
                    </div>
                    <div class="right_fields">
                        <asp:TextBox ID="txtLcsPlate" runat="server" CssClass="txtfild2"></asp:TextBox>
                    </div>
                </div>
                <div class="fields_wrap ">
                    <div class="left_lable">
                        <label>
                            Distinguishing Marks :</label></div>
                    <div class="right_fields">
                        <asp:TextBox ID="txtMarks" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
                <div class="fields_wrap ">
                    <div class="left_lable">
                        <label>
                            Date Last Seen :</label></div>
                    <div class="right_fields">
                        <asp:DropDownList ID="ddlMonth" runat="server">
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlDate" runat="server">
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlYear" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="fields_wrap ">
                    <div class="left_lable">
                        <label>
                            Remarks :</label></div>
                    <div class="right_fields">
                        <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
                <div class="fields_wrap ">
                    <div class="left_lable">
                        <label>
                            Expiration Date :</label></div>
                    <div class="right_fields">
                        <asp:TextBox ID="txtExpires" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqdate" runat="server" ControlToValidate="txtExpires"
                            ValidationGroup="SV" ErrorMessage="Expiration Date is mandatory.">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularDate" runat="server" ControlToValidate="txtExpires"
                            ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                            SetFocusOnError="True" ValidationGroup="SV" ErrorMessage="Invalid Date Format">*</asp:RegularExpressionValidator><br />
                        <b>(MM/DD/YYYY)</b>
                        <cc1:CalendarExtender ID="calex" runat="server" TargetControlID="txtExpires" Format="MM/dd/yyyy"
                            CssClass="MyCalendar" />
                    </div>
                </div>
                <div class="fields_wrap ">
                    <div class="left_lable">
                        <label>
                        </label>
                    </div>
                    <div class="right_fields">
                        <label>
                            <asp:CheckBox ID="chkCall" runat="server" Checked="true" />
                            Display Call Button</label>
                        <br />
                        <label>
                            <asp:CheckBox ID="chkPhoto" runat="server" Checked="true" />
                            Display Photo Upload Button</label>
                        <br />
                        <label>
                            <asp:CheckBox ID="chkContact" runat="server" Checked="true" />
                            Display Contact Us Button</label>
                        <br />
                    </div>
                </div>
                <div class="clear10">
                </div>
                <div class="fields_wrap ">
                    <div class="left_lable">
                        <label>
                        </label>
                    </div>
                    <div class="right_fields">
                        <asp:RadioButton ID="rbWorkprogress" runat="server" GroupName="Progress" Checked="true"
                            onclick="javascript:ShowPublicPrivate('1')" />
                        <label>
                            Work in Progress</label>
                        <asp:RadioButton ID="rbCompleted" runat="server" GroupName="Progress" onclick="javascript:ShowPublicPrivate('2')" />
                        <label>
                            Completed</label>
                        <div id="public" style="display: none; margin: 10px 0px 0px 136px;">
                            <asp:RadioButton ID="rbPublic" runat="server" GroupName="Public" />
                            <label>
                                Publish</label>
                            <asp:RadioButton ID="rbPrivate" runat="server" GroupName="Public" Checked="true" />
                            <label>
                                Unpublish</label></div>
                    </div>
                </div>
                <div class="clear">
                </div>
                <div class="clear10">
                </div>
                <div class="fields_wrap ">
                    <div class="left_lable">
                    </div>
                    <div class="right_fields" style="margin: 10px 0px 0px 0px; width: 450px;">
                        <asp:Button ID="btnCancel" runat="server" CausesValidation="false" CssClass="btn"
                            Text="Cancel" OnClick="btnCancel_Click" />
                        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn" OnClick="btnSave_Click"
                            ValidationGroup="SV" />
                        <a onclick="ShowPublicPrivate('preview')" style="cursor: pointer; cursor: hand;">
                            <img src="../../images/BulletinThumbs/preview.png" width="100" height="37"></a></div>
                </div>
            </div>
        </div>
    </div>
    <div>
        <asp:HiddenField ID="hdnFileFolder" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdnUploadFilePath" runat="server" ClientIDMode="Static" />
        <div style="padding-top: 10px; clear: both">
            <div style="float: left; padding-top: 5px;">
                <%--Show wrapper on above of fileUpload Control--%>
                <label class="file-upload">
                    <%-- Set Text To be displayed inplace of Browse button--%>
                    <span><strong>Select file</strong></span>
                    <%--Make clientID static if you are using Master Page--%>
                    <asp:FileUpload ID="fileToUpload" runat="server" ClientIDMode="Static" />
                </label>
            </div>
            <div style="float: left; padding-left: 10px">
                <span style="padding-left: 10px">
                    <%--Progress bar--%>
                    <img id="loading" src="images/loading.gif" style="display: none;"></span>
            </div>
        </div>
    </div>
</asp:Content>
