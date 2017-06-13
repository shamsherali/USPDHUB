<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchBusinessProfiles.aspx.cs"
    Inherits="USPDHUB.SearchBusinessProfiles" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .autocomplete_completionListElement
        {
            margin : 0px !important;
            background-color: inherit;
            color: windowtext;
            border: buttonshadow;
            border-width: 1px;
            border-style: solid;
            cursor: 'default';
            overflow: auto;
            height: 200px;
            text-align: left;
            list-style-type: none;
            position:absolute;
            padding: 0px;
        }
        .SearchPlace
        {
            top:270px;
            bottom:100px;
            position:absolute;
            left:400px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div class="SearchPlace" align="center">
        Search Business Profiles:<asp:TextBox ID="txtSearch" runat="server" Width="300px"></asp:TextBox>
        <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtSearch"
            MinimumPrefixLength="1" EnableCaching="False" CompletionSetCount="1" CompletionInterval="100"
            ServiceMethod="GetProfiles" CompletionListCssClass="autocomplete_completionListElement">
        </asp:AutoCompleteExtender>
    </div>
    </form>
</body>
</html>
