<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SortOrder.aspx.cs" Inherits="USPDHUB.SortOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.8/themes/redmond/jquery-ui.css"
        type="text/css" media="all" />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.4/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.8/jquery-ui.min.js"
        type="text/javascript"></script>
        <script type="text/javascript">

            $(function () {
                $('#sortable').sortable({
                    placeholder: 'ui-state-highlight',
                    update: OnSortableUpdate
                });
                $('#sortable').disableSelection();
               

                function OnSortableUpdate(event, ui) {
                    var order = $('#sortable').sortable('toArray').join(',').replace(/id_/gi, '');
                    alert(order);

                }
            });

    </script>

    <style type="text/css">
        #sortable
        {
            list-style-type: none;
            margin: 0;
            padding: 0;
            width: 400px;
        }
        #sortable li
        {
            margin: 0 5px 5px 5px;
            padding: 5px;
            font-size: 1.2em;
            height: 1.5em;
            cursor: move;
        }
        html > body #sortable li
        {
            height: 1.5em;
            line-height: 1.2em;
        }
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ul id="sortable">
            <asp:ListView ID="ItemsListView" runat="server" ItemPlaceholderID="myItemPlaceHolder">
                <LayoutTemplate>
                </LayoutTemplate>
                <LayoutTemplate>
                    <asp:PlaceHolder ID="myItemPlaceHolder" runat="server"></asp:PlaceHolder>
                </LayoutTemplate>
                <ItemTemplate>
                    <li class="ui-state-default" id='id_<%# Eval("Bulletin_ID") %>'>
                        <%# Eval("Bulletin_Title")%></li>
                </ItemTemplate>
            </asp:ListView>
        </ul>
    </div>
    </form>
</body>
</html>
