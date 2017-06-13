<%@ Page Title="" Language="C#" MasterPageFile="~/AdminHome.master" AutoEventWireup="true"
    ValidateRequest="false" CodeBehind="AdditionalBrandedRequests.aspx.cs" Inherits="USPDHUB.Admin.AdditionalBrandedRequests" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <link href="../css/reveal.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" />
    <style type="text/css">
        .sectionblock
        {
            --width: 110%;
            display: none;
        }
        
        .errDiv
        {
            color: Red;
            font-size: 12px;
        }
        div.saparator
        {
            display: inline-table;
            width: 103%;
            padding: 10px 0px;
            margin: 10px -15px;
        }
    </style>
    <asp:ScriptManager ID="smgr1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="lnkSave" />
            <asp:PostBackTrigger ControlID="btnDownloadAppIcon" />
            <asp:PostBackTrigger ControlID="btnDownloadBackground" />
        </Triggers>
        <ContentTemplate>
            <div class="">
                <div class="panel panel-primary dialog-panel">
                    <div class="panel-heading">
                        <h4 class="text-center">
                            Branded App Additional Requests</h4>
                    </div>
                    <div align="center">
                        <img src="../images/Admin/shadow-title.png" title="USPD HUB" alt="USPD HUB" /></div>
                    <div style="text-align: center;">
                        <asp:UpdateProgress ID="UpdateProgress6" runat="server" DisplayAfter="3">
                            <ProgressTemplate>
                                <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                        <asp:HiddenField ID="hdnProfileId" runat="server" />
                        <asp:HiddenField ID="hdnIsEdit" runat="server" Value="0" />
                    </div>
                    <div style="text-align: center;">
                        <div id="Requests AppIcon-errDiv" style="display: none;" class="errDiv-RequestInfo errDiv">
                            App icon is a Required Field</div>
                        <div id="Requests BackIcon-errDiv" style="display: none;" class="errDiv-RequestInfo errDiv">
                            Background image is a Required Field</div>
                        <div id="Requests AppName-errDiv" style="display: none;" class="errDiv-RequestInfo errDiv">
                            App name is a Required Field</div>
                        <div id="Requests Splash-errDiv" style="display: none;" class="errDiv-RequestInfo errDiv">
                            Splash screen content is a Required Field</div>
                        <div id="Requests ShortDesc-errDiv" style="display: none;" class="errDiv-RequestInfo errDiv">
                            Short description is a Required Field</div>
                        <div id="Requests Desc-errDiv" style="display: none;" class="errDiv-RequestInfo errDiv">
                            Description is a Required Field</div>
                        <div id="Requests KeyWords-errDiv" style="display: none;" class="errDiv-RequestInfo errDiv">
                            Key words is a Required Field</div>
                    </div>
                    <div class="panel-body">
                        <form action="" class="form-horizontal">
                        <div class="form-group saparator">
                            <%if (hdnIsEdit.Value == "0")
                              { %>
                            <lable class="control-label col-md-2 col-md-offset-2">Select Option</lable>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlActions" runat="server" onchange="ShowAddRequestBlock(this);"
                                    class="form-control">
                                    <asp:ListItem Text="-- Select Action --" Value=""></asp:ListItem>
                                    <asp:ListItem Text="App Icon" Value="divAppIcon"></asp:ListItem>
                                    <asp:ListItem Text="Background Image" Value="divBackIcon"></asp:ListItem>
                                    <asp:ListItem Text="App Name" Value="divAppName"></asp:ListItem>
                                    <asp:ListItem Text="Splash Screen Content" Value="divSlpashContent"></asp:ListItem>
                                    <asp:ListItem Text="Short Description" Value="divShortDesc"></asp:ListItem>
                                    <asp:ListItem Text="Description" Value="divDesc"></asp:ListItem>
                                    <asp:ListItem Text="Key Words" Value="divKeyWords"></asp:ListItem>
                                    <asp:ListItem Text="App Update" Value="divAppUpdate"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <%} %>
                        </div>
                        <div id="divLogo" class="sectionblock">
                            <div class="saparator">
                                <div class="form-group">
                                    <lable class="control-label col-md-2 col-md-offset-2">Logo</lable>
                                    <div class="col-md-4">
                                        <asp:FileUpload ID="fileLogo" runat="server" /><br />
                                        <asp:Label runat="server" ID="lblLogo" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="clearfix">
                                    </div>
                                    <div class="clearfix col-lg-7 col-lg-offset-2">
                                        <div class="checkbox">
                                            <label>
                                                <div style="display:none;">
                                                    <asp:CheckBox runat="server" ID="chkLogo" Checked="true" />
                                                    Replace Existing Data</div>
                                            </label>
                                            <a href="javascript:DeleteAppBlock('divLogo','Logo');" class="pull-right btn btn-danger btn-sm">
                                                Remove</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="divAppIcon" class="sectionblock">
                            <div class="saparator">
                                <div class="form-group">
                                    <lable class="control-label col-md-2 col-md-offset-2">App Icon</lable>
                                    <div class="col-md-4">
                                        <asp:FileUpload ID="FileAppIcon" runat="server" />
                                        <p class="text-danger" id="pAppIcon" runat="server">
                                            1024px X 1024px Best Size</p>
                                        <asp:Label runat="server" ID="lblAppIcon" Text=""></asp:Label>
                                        <%if (hdnIsEdit.Value == "1")
                                          { %>
                                        <asp:Button runat="server" ID="btnDownloadAppIcon" Text="Download" class="btn btn-sm btn-warning"
                                            OnClick="btnDownloadAppIcon_OnClick" />
                                        <%} %>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="clearfix col-lg-7 col-lg-offset-2">
                                        <div class="checkbox">
                                            <label>
                                                <div style="display:none;">
                                                    <asp:CheckBox runat="server" ID="chkAppIcon" Checked="true" />
                                                    Replace Existing Data</div>
                                            </label>
                                            <a href="javascript:DeleteAppBlock('divAppIcon','AppIcon');" class="pull-right btn btn-danger btn-sm">
                                                Remove</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="divBackIcon" class="sectionblock">
                            <div class="saparator">
                                <div class="form-group">
                                    <lable class="control-label col-md-2 col-md-offset-2">Background Icon</lable>
                                    <div class="col-md-4">
                                        <asp:FileUpload ID="FileBackground" runat="server" />
                                        <p class="text-danger" id="pBackIcon" runat="server">
                                            640px X 165px Best Size</p>
                                        <br />
                                        <asp:Label runat="server" ID="lblBackground" Text=""></asp:Label>
                                        <%if (hdnIsEdit.Value == "1")
                                          { %>
                                        <asp:Button runat="server" ID="btnDownloadBackground" Text="Download" class="btn btn-sm btn-warning"
                                            OnClick="btnDownloadBackground_OnClick" />
                                        <%} %>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="clearfix col-lg-7 col-lg-offset-2">
                                        <div class="checkbox">
                                            <label>
                                                <div style="display:none;">
                                                    <asp:CheckBox runat="server" ID="chkBackIcon" Checked="true" />
                                                    Replace Existing Data</div>
                                            </label>
                                            <a href="javascript:DeleteAppBlock('divBackIcon','BackIcon');" class="pull-right btn btn-danger btn-sm">
                                                Remove</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="divAppName" class="sectionblock">
                            <div class="saparator">
                                <div class="form-group">
                                    <lable class="control-label col-md-2 col-md-offset-2">App Name</lable>
                                    <div class="col-md-5">
                                        <asp:TextBox runat="server" ID="txtAppName" MaxLength="30" onkeyup="ValidateMaxLength(this,'AppName', '30');"
                                            onChange="ValidateMaxLength(this,' AppName', '30');" class="form-control"></asp:TextBox>
                                        <p class="pull-left">
                                            <strong>
                                                <asp:Label runat="server" ID="lblCount3" Text="30" Font-Bold="true"></asp:Label></strong>
                                            characters remaining</p>
                                        <p class="pull-right text-danger">
                                            <strong>(30</strong> characters max)</p>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <lable class="control-label col-md-2 col-md-offset-2">App Name Notes</lable>
                                    <div class="col-md-5">
                                        <asp:TextBox ID="txtAppNameNotes" runat="server" TextMode="MultiLine" class="form-control"
                                            Style="height: 35px;"></asp:TextBox>
                                    </div>
                                    <div class="clearfix col-lg-7 col-lg-offset-2">
                                        <div class="checkbox">
                                            <label>
                                                <asp:CheckBox runat="server" ID="chkReplaceAppNameData" />
                                                Replace Existing Data
                                            </label>
                                            <a href="javascript:DeleteAppBlock('divAppName','AppName');" class="pull-right btn btn-danger btn-sm">
                                                Remove</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="divSlpashContent" class="sectionblock">
                            <div class="saparator">
                                <div class="form-group">
                                    <lable class="control-label col-md-2 col-md-offset-2">Splash Screen Content</lable>
                                    <div class="col-md-5">
                                        <asp:TextBox runat="server" ID="txtSplashContent" TextMode="MultiLine" class="form-control"></asp:TextBox>
                                        <br />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <lable class="control-label col-md-2 col-md-offset-2">Splash Screen Notes</lable>
                                    <div class="col-md-5">
                                        <asp:TextBox ID="txtSplashNotes" runat="server" TextMode="MultiLine" class="form-control"
                                            Style="height: 35px;"></asp:TextBox>
                                    </div>
                                    <div class="clearfix col-lg-7 col-lg-offset-2">
                                        <div class="checkbox">
                                            <label>
                                                <asp:CheckBox runat="server" ID="chkReplaceSlashData" />
                                                Replace Existing Data
                                            </label>
                                            <a href="javascript:DeleteAppBlock('divSlpashContent','SplashContent');" class="pull-right btn btn-danger btn-sm">
                                                Remove</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="divShortDesc" class="sectionblock">
                            <div class="saparator">
                                <div class="form-group">
                                    <lable class="control-label col-md-2 col-md-offset-2">Short Description</lable>
                                    <div class="col-md-5">
                                        <asp:TextBox runat="server" ID="txtShortDesc" TextMode="MultiLine" class="form-control"
                                            MaxLength="80" onkeyup="ValidateMaxLength(this,'short description','80');" onChange="ValidateMaxLength(this,'short description','80');"></asp:TextBox>
                                        <p class="pull-left">
                                            <strong>
                                                <asp:Label runat="server" ID="lblCount4" Text="80" Font-Bold="true"></asp:Label></strong>
                                            characters remaining</p>
                                        <p class="pull-right text-danger">
                                            (<strong>80</strong> characters max)</p>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <lable class="control-label col-md-2 col-md-offset-2">Short Description Notes</lable>
                                    <div class="col-md-5">
                                        <asp:TextBox ID="txtShortDescNotes" runat="server" TextMode="MultiLine" class="form-control"
                                            Style="height: 35px;"></asp:TextBox>
                                    </div>
                                    <div class="clearfix col-lg-7 col-lg-offset-2">
                                        <div class="checkbox">
                                            <label>
                                                <asp:CheckBox runat="server" ID="chkReplaceShortDescData" />
                                                Replace Existing Data
                                            </label>
                                            <a href="javascript:DeleteAppBlock('divShortDesc','ShortDesc');" class="pull-right btn btn-danger btn-sm">
                                                Remove</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="divDesc" class="sectionblock">
                            <div class="saparator">
                                <div class="form-group">
                                    <lable class="control-label col-md-2 col-md-offset-2">Description</lable>
                                    <div class="col-md-5">
                                        <asp:TextBox runat="server" ID="txtDescription" TextMode="MultiLine" MaxLength="2000"
                                            onkeyup="ValidateMaxLength(this,'description','2000');" onChange="ValidateMaxLength(this,'description','2000');"
                                            class="form-control"></asp:TextBox>
                                        <p class="pull-left">
                                            <strong>
                                                <asp:Label runat="server" ID="lblCount1" Text="2000" Font-Bold="true"></asp:Label></strong>
                                            characters remaining</p>
                                        <p class="pull-right text-danger">
                                            (<strong>2000</strong> characters max)</p>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <lable class="control-label col-md-2 col-md-offset-2">Description Notes</lable>
                                    <div class="col-md-5">
                                        <asp:TextBox ID="txtDescNotes" runat="server" TextMode="MultiLine" class="form-control"
                                            Style="height: 35px;"></asp:TextBox>
                                    </div>
                                    <div class="clearfix col-lg-7 col-lg-offset-2">
                                        <div class="checkbox">
                                            <label>
                                                <asp:CheckBox runat="server" ID="chkReplaceDescData" />
                                                Replace Existing Data
                                            </label>
                                            <a href="javascript:DeleteAppBlock('divDesc','Desc');" class="pull-right btn btn-danger btn-sm">
                                                Remove</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="divKeyWords" class="sectionblock">
                            <div class="saparator">
                                <div class="form-group">
                                    <lable class="control-label col-md-2 col-md-offset-2">Keywords</lable>
                                    <div class="col-md-5">
                                        <asp:TextBox runat="server" ID="txtKeywords" TextMode="MultiLine" class="form-control"
                                            MaxLength="200" onkeyup="ValidateMaxLength(this,'keywords','200');" onChange="ValidateMaxLength(this,'keywords','200');"></asp:TextBox>
                                        <p class="pull-left">
                                            <strong>
                                                <asp:Label runat="server" ID="lblCount2" Text="200" Font-Bold="true"></asp:Label></strong>
                                            characters remaining</p>
                                        <p class="pull-right text-danger">
                                            (<strong>200</strong> characters max)</p>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <lable class="control-label col-md-2 col-md-offset-2">Keywords Notes</lable>
                                    <div class="col-md-5">
                                        <asp:TextBox ID="txtKeywordNotes" runat="server" TextMode="MultiLine" class="form-control"
                                            Style="height: 35px;"></asp:TextBox>
                                    </div>
                                    <div class="clearfix col-lg-7 col-lg-offset-2">
                                        <div class="checkbox">
                                            <label>
                                                <asp:CheckBox runat="server" ID="chkReplaceKeyWordsData" />
                                                Replace Existing Data
                                            </label>
                                            <a href="javascript:DeleteAppBlock('divKeyWords','KeyWords');" class="pull-right btn btn-danger btn-sm">
                                                Remove</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                          <div id="divAppUpdate" class="sectionblock">
                            <div class="saparator">
                                <div class="form-group">
                                    <lable class="control-label col-md-2 col-md-offset-2">App Update</lable>
                                    <div class="col-md-5">
                                        <asp:TextBox runat="server" ID="txtAppUpdate" TextMode="MultiLine" class="form-control"
                                            MaxLength="200" onkeyup="ValidateMaxLength(this,'AppUpdate','200');" onChange="ValidateMaxLength(this,'AppUpdate','200');"></asp:TextBox>
                                        <p class="pull-left">
                                            <strong>
                                                <asp:Label runat="server" ID="lblCount6" Text="200" Font-Bold="true"></asp:Label></strong>
                                            characters remaining</p>
                                        <p class="pull-right text-danger">
                                            (<strong>200</strong> characters max)</p>
                                    </div>
                                </div>
                                <div class="form-group">
                                     <lable class="control-label col-md-2 col-md-offset-2">App Update Notes</lable>
                                    <div class="col-md-5">
                                        <asp:TextBox ID="txtAppUpdateNotes" runat="server" TextMode="MultiLine" class="form-control"
                                            Style="height: 35px;"></asp:TextBox>
                                    </div>
                                    <div class="clearfix col-lg-7 col-lg-offset-2">
                                        <div class="checkbox">
                                            <label>
                                                <asp:CheckBox runat="server" ID="chkReplaceAppUpdate" />
                                                Replace Existing Data
                                            </label>
                                            <a href="javascript:DeleteAppBlock('divAppUpdate','AppUpdate');" class="pull-right btn btn-danger btn-sm">
                                                Remove</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="saparator">
                            <div class="form-group">
                                <lable class="control-label col-md-2 col-md-offset-2">Status</lable>
                                <div class="col-md-4">
                                    <asp:DropDownList runat="server" ID="ddlStatus" class="form-control">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="saparator" style="display: none;">
                            <div class="form-group">
                                <lable class="control-label col-md-2 col-md-offset-2">AssignedCS</lable>
                                <div class="col-md-4">
                                    <asp:DropDownList runat="server" ID="ddlAssignedCS" Font-Size="13px" class="form-control"
                                        Width="150px">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-offset-4">
                            <asp:LinkButton ID="lnkBack" runat="server" CausesValidation="false" TabIndex="6"
                                OnClick="lnkBack_Click" class="btn btn-warning">Cancel</asp:LinkButton>
                            <asp:LinkButton ID="lnkSave" runat="server" CausesValidation="true" TabIndex="5"
                                OnClientClick="return ValidateRequests();" OnClick="lnkSave_Click" class="btn btn-primary">Submit</asp:LinkButton>
                        </div>
                        </form>
                    </div>
                </div>
            </div>
            <asp:HiddenField runat="server" ID="hdnAppOrderStatus" Value="0" />
            <asp:HiddenField runat="server" ID="hdnTabType" Value="0" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".saparator:even").css("background-color", "white");
            $(".saparator:odd").css("background-color", "#EAEBEC");
        });
        function ValidateRequests() {

            var editmode = document.getElementById('<%=hdnIsEdit.ClientID %>').value;

            var list = document.getElementsByClassName("errDiv-RequestInfo");
            for (var i = 0; i < list.length; i++) {
                if (list[i].style.display == "block")
                    list[i].style.display = 'none';
            }
            if (document.getElementById('divAppIcon').style.display == "block") {
                if (document.getElementById('<%=FileAppIcon.ClientID %>').value == "" && editmode != "1")
                    document.getElementById('Requests AppIcon-errDiv').style.display = "block";
            }
            if (document.getElementById('divBackIcon').style.display == "block") {
                if (document.getElementById('<%=FileBackground.ClientID %>').value == "" && editmode != "1")
                    document.getElementById('Requests BackIcon-errDiv').style.display = "block";
            }
            if (document.getElementById('divAppName').style.display == "block") {
                if (document.getElementById('<%=txtAppName.ClientID %>').value == "")
                    document.getElementById('Requests AppName-errDiv').style.display = "block";
            }
            if (document.getElementById('divSlpashContent').style.display == "block") {
                if (document.getElementById('<%=txtSplashContent.ClientID %>').value == "")
                    document.getElementById('Requests Splash-errDiv').style.display = "block";
            }
            if (document.getElementById('divShortDesc').style.display == "block") {
                if (document.getElementById('<%=txtShortDesc.ClientID %>').value == "")
                    document.getElementById('Requests ShortDesc-errDiv').style.display = "block";
            }
            if (document.getElementById('divDesc').style.display == "block") {
                if (document.getElementById('<%=txtDescription.ClientID %>').value == "")
                    document.getElementById('Requests Desc-errDiv').style.display = "block";
            }
            if (document.getElementById('divKeyWords').style.display == "block") {
                if (document.getElementById('<%=txtKeywords.ClientID %>').value == "")
                    document.getElementById('Requests KeyWords-errDiv').style.display = "block";
            }
            var errorCount = 0;
            for (var i = 0; i < list.length; i++) {
                if (list[i].style.display == "block")
                    errorCount += 1;
            }
            if (errorCount > 0)
                return false;
            else
                return true;
        }
        function DeleteAppBlock(divId, actionType) {
            if (actionType == 'Logo') {
                document.getElementById('<%=fileLogo.ClientID %>').value = "";
                document.getElementById(divId).style.display = "none";
            }
            if (actionType == 'AppIcon') {

                document.getElementById('<%=FileAppIcon.ClientID %>').value = "";
                document.getElementById(divId).style.display = "none";
            }

            if (actionType == 'BackIcon') {

                document.getElementById('<%=FileBackground.ClientID %>').value = "";
                document.getElementById(divId).style.display = "none";
            }

            if (actionType == 'AppName') {
                document.getElementById('<%=txtAppName.ClientID %>').value = "";
                document.getElementById('<%=txtAppNameNotes.ClientID %>').value = "";
                document.getElementById(divId).style.display = "none";
            }

            if (actionType == 'SplashContent') {
                document.getElementById('<%=txtSplashContent.ClientID %>').value = "";
                document.getElementById('<%=txtSplashNotes.ClientID %>').value = "";
                document.getElementById(divId).style.display = "none";
            }
            if (actionType == 'ShortDesc') {
                document.getElementById('<%=txtShortDesc.ClientID %>').value = "";
                document.getElementById('<%=txtShortDescNotes.ClientID %>').value = "";
                document.getElementById(divId).style.display = "none";
            }
            if (actionType == 'Desc') {
                document.getElementById('<%=txtDescription.ClientID %>').value = "";
                document.getElementById('<%=txtDescNotes.ClientID %>').value = "";
                document.getElementById(divId).style.display = "none";
            }
            if (actionType == 'KeyWords') {
                document.getElementById('<%=txtKeywords.ClientID %>').value = "";
                document.getElementById('<%=txtKeywordNotes.ClientID %>').value = "";
                document.getElementById(divId).style.display = "none";
            }
            if (actionType == 'AppUpdate') {
                document.getElementById('<%=txtAppUpdate.ClientID %>').value = "";
                document.getElementById('<%=txtAppUpdateNotes.ClientID %>').value = "";
                document.getElementById(divId).style.display = "none";
            }
        }
        function ShowAddRequestBlock11(controlIDs) {

            var ids = controlIDs.split(",");
            for (i = 0; i < ids.length; i++) {
                document.getElementById(ids[i]).style.display = "block";
            }
        }
        function ShowAddRequestBlock(ddlId) {
            var ControlName = document.getElementById(ddlId.id);
            if (ControlName.value != "") {
                document.getElementById(ControlName.value).style.display = "block";
            }
        }
        function ValidateMaxLength(id, type, maxlengthstr) {
            var maxlength = parseInt(maxlengthstr);
            if (id != null) {
                var Content = id.value;
                var TextLength = id.value.length;
                if (TextLength > maxlength) {
                    id.value = id.value.substring(0, maxlength);
                }
                TextLength = id.value.length;
                if (type == 'AppName')
                    document.getElementById('<%=lblCount3.ClientID %>').innerHTML = maxlength - TextLength;
                else if (type == 'short description')
                    document.getElementById('<%=lblCount4.ClientID %>').innerHTML = maxlength - TextLength;
                else if (type == 'description')
                    document.getElementById('<%=lblCount1.ClientID %>').innerHTML = maxlength - TextLength;
                else if (type == 'keywords')
                    document.getElementById('<%=lblCount2.ClientID %>').innerHTML = maxlength - TextLength;
                else if (type == 'AppUpdate')
                    document.getElementById('<%=lblCount6.ClientID %>').innerHTML = maxlength - TextLength;
            }
        }
        window.onload = function () {
            ValidateMaxLength(document.getElementById('<%=txtAppName.ClientID %>'), 'AppName', 30);
            ValidateMaxLength(document.getElementById('<%=txtShortDesc.ClientID %>'), 'short description', 80);
            ValidateMaxLength(document.getElementById('<%=txtDescription.ClientID %>'), 'description', 2000);
            ValidateMaxLength(document.getElementById('<%=txtKeywords.ClientID %>'), 'keywords', 200);
            ValidateMaxLength(document.getElementById('<%=txtAppUpdate.ClientID %>'), 'AppUpdate', 200);
            var editmode = document.getElementById('<%=hdnIsEdit.ClientID %>').value;
            var status = document.getElementById('<%=ddlStatus.ClientID %>').value;

            if (editmode == 1) {
                if (status == 8 || status == 5 || status == 6 || status == 7) {
                    document.getElementById('<%=FileAppIcon.ClientID %>').style.display = 'none';
                    document.getElementById('<%=FileBackground.ClientID %>').style.display = 'none';
                    document.getElementById('<%=pAppIcon.ClientID %>').style.display = 'none';
                    document.getElementById('<%=pBackIcon.ClientID %>').style.display = 'none';
                }
            }

        }
    </script>
</asp:Content>
