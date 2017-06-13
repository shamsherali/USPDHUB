<%@ Page Title="" Language="C#" MasterPageFile="~/PaidTools.master" AutoEventWireup="true"
    CodeBehind="CrisisCallLog.aspx.cs" Inherits="UserForms.CrisisCallLog" ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/TimeControl.ascx" TagName="TimeControl" TagPrefix="TimerUC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <script src="../../Scripts/flyers/jquery-1.7.2.js" type="text/javascript"></script>
    <link href="../../css/jquery-ui.css" rel="stylesheet" type="text/css" />
    <%--Add & Edit & Delete Call Log--%>
    <script type="text/javascript">

        function LoadCallertypeAgency(controlID) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                data: "{}",
                url: "CrisisCallLog.aspx/GetCallertypeAgency",
                dataType: "json",
                success: function (data) {
                    var agencyString = data.d;
                    if (controlID != null) {
                        //Add New Block
                        var dllcallertypeagency = "dllcallertypeagency" + controlID;
                        document.getElementById(dllcallertypeagency).options.length = 0;

                        var list = agencyString.split(',');
                        for (i = 0; i < list.length; i++) {
                            $('#' + dllcallertypeagency).append($("<option></option>").attr("value", list[i]).text(list[i]));
                        }
                    }
                    else {//Edit Page Load All DDL
                        var divtable = document.getElementById("maintable");

                        if (divtable != null) {
                            for (x = 0; x < divtable.rows.length; ) {
                                j = divtable.rows[x].id.replace('trheader', '');
                                //We have 3rows every call 1==Header 2==preview 3==edit row
                                x = x + 3;
                                document.getElementById("dllcallertypeagency" + j).options.length = 0;

                                var list = agencyString.split(',');
                                for (i = 0; i < list.length; i++) {
                                    $('#dllcallertypeagency' + j).append($("<option></option>").attr("value", list[i]).text(list[i]));
                                }
                            }
                        }
                    }
                }
            });
        }

        function LoadCallerTypeRegions(controlID) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                data: "{}",
                url: "CrisisCallLog.aspx/GetCallerTypeRegions",
                dataType: "json",
                success: function (data) {
                    var regionString = data.d;

                    //Add New Block
                    if (controlID != null) {

                        var ddlcallertypeRegion = "ddlcallertyperegion" + controlID;
                        document.getElementById(ddlcallertypeRegion).options.length = 0;

                        var list = regionString.split(',');
                        for (i = 0; i < list.length; i++) {
                            $('#' + ddlcallertypeRegion).append($("<option></option>").attr("value", list[i]).text(list[i]));
                        }
                    }
                    else {//Edit Page Load All DDL
                        var divtable = document.getElementById("maintable");

                        if (divtable != null) {
                            for (x = 0; x < divtable.rows.length; ) {
                                j = divtable.rows[x].id.replace('trheader', '');
                                //We have 3rows every call 1==Header 2==preview 3==edit row
                                x = x + 3;
                                document.getElementById("ddlcallertyperegion" + j).options.length = 0;

                                var list = regionString.split(',');
                                for (i = 0; i < list.length; i++) {
                                    $('#ddlcallertyperegion' + j).append($("<option></option>").attr("value", list[i]).text(list[i]));
                                }

                            }
                        }

                    }
                }
            });
        }

        function LoadCallerRequestRegions(controlID) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                data: "{}",
                url: "CrisisCallLog.aspx/GetCallerRequestRegions",
                dataType: "json",
                success: function (data) {
                    var regionString = data.d;
                    //Add New Block
                    if (controlID != null) {

                        var ddlcallerRequestRegion = "ddldvrtregion" + controlID;
                        document.getElementById(ddlcallerRequestRegion).options.length = 0;

                        var list = regionString.split(',');
                        for (i = 0; i < list.length; i++) {
                            $('#' + ddlcallerRequestRegion).append($("<option></option>").attr("value", list[i]).text(list[i]));
                        }
                        ddldvrtregion_onchange("ddldvrtregion" + controlID);
                    }
                    else {//Edit Page Load All DDL
                        var divtable = document.getElementById("maintable");

                        if (divtable != null) {
                            for (x = 0; x < divtable.rows.length; ) {
                                j = divtable.rows[x].id.replace('trheader', '');
                                //We have 3rows every call 1==Header 2==preview 3==edit row
                                x = x + 3;
                                document.getElementById("ddldvrtregion" + j).options.length = 0;

                                var list = regionString.split(',');
                                for (i = 0; i < list.length; i++) {
                                    $('#ddldvrtregion' + j).append($("<option ></option>").attr("value", list[i]).text(list[i]));
                                }
                            } //Main For                            
                        }
                    }
                }
            });
        }

        function AddCallPanel() {


            if (document.getElementById('maintable') == null) {
                var maintableTag = "<table id='maintable' cellpadding=\"2\" cellspacing=\"2\" width=\"400px\" style=\"border: 0px solid gray; " +
                                                                        "min-height: 100px;\"> " +
                                                                    "</table>";

                document.getElementById("<%=lblBulletinedit.ClientID %>").innerHTML = maintableTag;
            }

            //GETTING DIVS COUNT
            var CID = 0;
            var divtable = document.getElementById('maintable');
            for (i = 0; i < divtable.rows.length; i++) {
                for (j = 0; j < divtable.rows[i].cells.length - 1; j++) {
                    for (k = 0; k < divtable.rows[i].cells[j].children.length; k++) {
                        CID++;
                    }
                }
            }

            // GET MAX DIV ID
            CID = CID + 1;
            for (i = CID; i <= CID; i++) {
                if (!document.getElementById("edit" + i)) {
                    break;
                }
                else {
                    CID++;
                }
            }

            document.getElementById('DivIds').value = CID;
            var newRow = "<tr id='trheader" + CID + "' ><td   style=\"border-left: 2px dashed blue; border-right: 2px dashed blue; border-Top: 2px dashed blue; border-bottom:1px solid gray;\">" +
                            "<span style='font-size:20px; margin-top:20px; '  ><b>&nbsp;&nbsp;Call&nbsp;&nbsp;</b></span>" +
                            "<img align='right' src=\"../../Images/DeleteCall.png\" style='cursor: pointer; padding-right:5px;' onclick='RemoveCallPanel(edit" + CID + ")' />&nbsp;&nbsp;" +
                            "<img align='right' src=\"../../Images/EditCall.png\" style='cursor: pointer; display:none; padding-right:5px;' id='imgeditcall" + CID + "' onclick='EditCallPanel(trpreview" + CID + ")'  />&nbsp;&nbsp;" +
                            "</td>" +
                            "</tr>" +
                              "<tr id='trpreview" + CID + "' style='display:none;' ><td id='tdpreview" + CID + "'></td></tr>" +
                            "<tr id='tr" + CID + "' ><td>" +
                            "<div  id=\"edit" + CID + "\"> " +
                        " <table style='border-bottom:2px solid gray;' cellpadding=\"5\" cellspacing=\"0\"> " +
                            "<tr>" +
                                "<td colspan=\"4\">Name" +
                                "</td>" +
                                "</tr>" +
                            "<tr>" +
                                "<td>" +
                                    "<span style=\"color: Red;\">*&nbsp;</span>First:" +
                                "</td>" +
                                "<td>" +
                                    "<input type=\"text\" id='txtfirst" + CID + "'  />" +
                                "</td>" +
                                "<td>" +
                                    "Last:" +
                                "</td>" +
                                "<td>" +
                                    "<input type=\"text\" id='txtlast" + CID + "' />" +
                                "</td>" +
                            "</tr>" +
                            "<tr>" +
                                "<td colspan=\"4\">" +
                                    "<span style=\"color: Red;\">*&nbsp;</span>Phone Number: &nbsp;" +
                                    "<input type=\"text\" id='txtPhone" + CID + "'   />" +
                                "</td>" +
                            "</tr>" +
                            "<tr>" +
                                "<td colspan=\"4\">" +
                                    "<span style=\"color: Red;\">*&nbsp;</span>Time of Call: &nbsp;" +
                                    "<select id=\"ddlcallhour" + CID + "\" style=\"width: 50px;\" onChange='displaypage()' >" +

                                    "<option value=\"1\">1</option>" +
                                    "<option value=\"2\">2</option>" +
                                    "<option value=\"3\">3</option>" +
                                    "<option value=\"4\">4</option>" +
                                    "<option value=\"5\">5</option>" +
                                    "<option value=\"6\">6</option>" +
                                    "<option value=\"7\">7</option>" +
                                    "<option value=\"8\">8</option>" +
                                    "<option value=\"9\">9</option>" +
                                    "<option value=\"10\">10</option>" +
                                    "<option value=\"11\">11</option>" +
                                     "<option value=\"12\" >12</option>" +
                                    "</select>&nbsp;<span>Hours&nbsp;&nbsp;&nbsp;</span>" +
                                    "<input type=\"text\" id=\"txtcallmin" + CID + "\" style=\"width: 50px;\" value='00' />&nbsp;" +
                                    "<span>Minutes</span>&nbsp;&nbsp;&nbsp;" +
                                    "<select id=\"ddlcallsection" + CID + "\" style=\"width: 50px;\">" +
                                     "<option value=\"AM\" >AM</option>" +
                                     "<option value=\"PM\" >PM</option>" +
                                    "</select>" +
                                "</td>" +
                            "</tr>" +
                            "<tr>" +
                                   "<td colspan=\"4\">" +
                                         "<strong>Caller Location: </strong>" +
                                     "</td>" +
                              "</tr>" +
                                    "<tr>" +
                                        "<td colspan=\"4\">" +
                                            "Address: &nbsp;" +
                                            "<input type=\"text\" id=\"txtAddress" + CID + "\" />" +
                                        "</td>" +
                                    "</tr>" +
                                    "<tr>" +
                                        "<td colspan=\"4\">" +
                                            "City: &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
                                            "<input type=\"text\" id=\"txtCity" + CID + "\" />" +
                                        "</td>" +
                                    "</tr>" +
                                        "<tr>" +
                                        "<td colspan=\"4\">" +
                                            "Zip: &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
                                            "<input type=\"text\" id=\"txtZip" + CID + "\" />" +
                                        "</td>" +
                                    "</tr>" +
                            "<tr>" +
                                "<td colspan=\"4\">" + //Caller Type
                                    "<table id='tblCallerType" + CID + "'>" +
                                              "  <tr>" +
                                                    "<td>" +
                                                        "<span style=\"color: Red;\">*&nbsp;</span><strong>Caller Type: </strong>" +
                                                    "</td>" +
                                                "</tr>" +
                                                "<tr>" +
                                                    "<td>" +
                                                        "<input checked='true' id='rbagency" + CID + "' type='radio' name='callertype" + CID + "' onclick='ShowCallerType(this.name);' value='Agency' />Agency" +
                                                        "<div id='divagency" + CID + "' style='display: block; padding-left: 20px; padding-top: 10px;'>" +
                                                            "<select id='dllcallertypeagency" + CID + "' style='width: 150px;' onLoad='LoadCallertypeAgency(this.id)' onchange='ddlcallertypeAgency_onchange(" + CID + ");'> " +
                                                            "</select>" +
                                                            "<div style='padding-left:49px; padding-top:5px;'>" +
                                                                " <input id='txtcallertypeagency" + CID + "' style='display:none; width:150px;' type='text' name='callertype" + CID + "' />" +
                                                            "</div>" +
                                                            "</div>" +
                                                    "</td>" +
                                                "</tr>" +
                                                "<tr>" +
                                                 "<td>" +
                                                        "<input id='rbLaw" + CID + "' type='radio' name='callertype" + CID + "' onclick='ShowCallerType(this.name);' value='Law Enforcement' />" +
                                                        "Law Enforcement" +
                                                        "<div id='divcallertyperegion" + CID + "' style='display: none; padding-left: 20px; padding-top: 10px; '>" +
                                                            "Region: &nbsp;" +
                                                            "<select id='ddlcallertyperegion" + CID + "' style='width:150px;' onLoad='LoadCallerTypeRegions(this.id)' onchange='ddlcallertyperegion_onchange(" + CID + ");'>" +
                                                            "</select>" + //Caller Type Region text box for other option
                                                            "<div style='padding-left:49px; padding-top:5px;'>" +
                                                                " <input id='txtcallertyperegion" + CID + "' style='display:none; width:150px;' type='text' name='callertype" + CID + "' />" +
                                                            "</div>" +
                                                        "</div>" +
                                                    "</td>" +
                                                "</tr>" +
                                                "<tr>" +
                                                    "<td>" +
                                                        "<input id='rbsocial" + CID + "' type='radio' name='callertype" + CID + "' onclick='ShowCallerType(this.name);' value='Social Worker' />Social" +
                                                        "&nbsp;Worker" +
                                                    "</td>" +
                                                "</tr>" +
                                                "<tr>" +
                                                    "<td>" +
                                                        "<input id='rbvictim" + CID + "' type='radio' name='callertype" + CID + "' onclick='ShowCallerType(this.name);' value='Victim' />Victim</span>" +
                                                    "</td>" +
                                                "</tr>" +
                                                "<tr>" +
                                                    "<td>" +
                                                        "<input id='rbwitness" + CID + "' type='radio' name='callertype" + CID + "' onclick='ShowCallerType(this.name);' value='Witness' />Witness</span>" +
                                                    "</td>" +
                                                "</tr>" +
                                                "<tr>" +
                                                    "<td>" +
                                                        "<input id='rbothers" + CID + "' type='radio' name='callertype" + CID + "' onclick='ShowCallerType(this.name);' value='Other' />Others</span>" +
                                                        "&nbsp;<input id='rbtxtothers" + CID + "' type='text' name='callertype" + CID + "' />" +
                                                    "</td>" +
                                                "</tr>" +
                                            "</table>" + //End Caller Type
                                "</td>" +
                            "</tr>" +

                                    "<tr>" +
                                        "<td colspan=\"4\">" + //Start Caller Request
                                            "<table id='tblcallerreq" + CID + "'>" +
                                "<tr>" +
                                    "<td>" +
                                        "<strong>Call Request: </strong>&nbsp;&nbsp;&nbsp;(Check one or more)" +
                                    "</td>" +
                                "</tr>" +
                                "<tr>" +
                                    "<td>" +
                                        "<input  type='checkbox' name='callerrequest" + CID + "' id='chkagency" + CID + "' onclick='ShowCallerRequest(this.name);' value='Agency' />Agency" +
                                    "</td>" +
                                "</tr>" +
                                "<tr>" +
                                    "<td>" +
                                        "<input type='checkbox' name='callerrequest" + CID + "' id='chkcounseling" + CID + "' onclick='ShowCallerRequest(this.name);' value='Counseling' />Counseling" +
                                    "</td>" +
                                "</tr>" +
                                "<tr>" +
                                    "<td>" +
                                        "<input type='checkbox' name='callerrequest" + CID + "' id='chkdvrt" + CID + "' onclick='ShowCallerRequest(this.name);' value='DVRT' />DVRT" +
                                        "<table id='divdvrtlist" + CID + "' style='display: none; padding-left: 20px; padding-top: 10px;'>" +
                                            "<tr>" +
                                                "<td>" +
                                                    "<strong>For:</strong>" +
                                                "</td>" +
                                            "</tr>" +
                                            "<tr>" +
                                                "<td>" +
                                                    "<input type='checkbox' name='dvrtlist" + CID + "' id='chkcps" + CID + "' onclick='ShowCallerRequest(this.name);' value='CPS' />CPS" +
                                                    "<div id='divcps" + CID + "' style='display: none; padding-left: 20px; padding-top: 10px;'>" +
                                                        "<input type='checkbox' name='cpslist" + CID + "' id='chkchildrenscene" + CID + "' value='Children on scene' />Children on scene <br/>" +
                                                        "<input type='checkbox' name='cpslist" + CID + "' id='chkchildrenhousehold" + CID + "' value='Children in household' />Children in household" +
                                                    "</div>" +
                                                "</td>" +
                                            "</tr>" +
                                            "<tr>" +
                                                "<td>" +
                                                    "<input type='checkbox' name='dvrtlist" + CID + "' id='chkfollowup" + CID + "' onclick='ShowCallerRequest(this.name);' value='Follow Up' />Follow" +
                                                    "Up" +
                                                "</td>" +
                                            "</tr>" +
                                            "<tr>" +
                                                "<td>" +
                                                    "<input type='checkbox' name='dvrtlist" + CID + "' id='chkhospital" + CID + "' onclick='ShowCallerRequest(this.name);' value='Hospital' />Hospital" +
                                                "</td>" +
                                            "</tr>" +
                                            "<tr>" +
                                                "<td>" +
                                                    "<input type='checkbox' name='dvrtlist" + CID + "' id='chklaw" + CID + "' onclick='ShowCallerRequest(this.name);' value='Law Enforcement' />" +
                                                    "Law Enforcement" +
                                                    "<div id='divdvrtregion" + CID + "' style='display: none; padding-left: 20px; padding-top: 10px;'>" +
                                                        "Region: &nbsp;" +
                                                        "<select id='ddldvrtregion" + CID + "' onLoad='LoadCallerRequestRegions(this.id)' onchange='ddldvrtregion_onchange(this.id);'>" +
                                                        "</select>" + // Region Other Textbox
                                                             "<div style='padding-left:49px; padding-top:5px;'>" +
                                                                " <input id='txtcallerReqregion" + CID + "' style='display:none; width:150px;' type='text' name='dvrtlist" + CID + "' />" +
                                                            "</div>" +
                                                        "<div id='divOfficer" + CID + "' style='display: block; padding-left: 25px; padding-top: 10px;'>" +
                                                            "Officer: &nbsp;" +
                                                            "<select id='ddlofficer" + CID + "'>" +
                                                            "</select>" +
                                                        "</div>" +
                                                    "</div>" +
                                                "</td>" +
                                            "</tr>" +
                                            "<tr>" +
                                                "<td>" +
                                                    "<input type='checkbox' name='dvrtlist" + CID + "' id='chkScene" + CID + "' onclick='ShowCallerRequest(this.name);' value='Scene' />Scene" +
                                                "</td>" +
                                            "</tr>" +
                                            "<tr>" +
                                                "<td>" +
                                                    "<input type='checkbox' name='dvrtlist" + CID + "' id='chksubother" + CID + "' onclick='ShowCallerRequest(this.name);' value='Other' />Other" +
                                                    "&nbsp;<input id='chktxtothers" + CID + "' type='text' name='dvrtlist" + CID + "' />" +
                                                "</td>" +
                                            "</tr>" +
                                        "</table>" +
									"</td>" +
                                "</tr>" +
                                "<tr>" +
                                    "<td>" +
                                        "<input type='checkbox' name='callerrequest" + CID + "' id='chklegal" + CID + "' onclick='ShowCallerRequest(this.name);' value='Legal' />Legal" +
                                    "</td>" +
                                "</tr>" +
                                "<tr>" +
                                    "<td>" +
                                        "<input type='checkbox' name='callerrequest" + CID + "' id='chkshelter" + CID + "' onclick='ShowCallerRequest(this.name);' value='Shelter' />Shelter" +
                                    "</td>" +
                                "</tr>" +
                                "<tr>" +
                                    "<td>" +
                                        "<input type='checkbox' name='callerrequest" + CID + "' id='chksocial" + CID + "' onclick='ShowCallerRequest(this.name);' value='Social Worker' />Social" +
                                        "&nbsp;Worker" +
                                    "</td>" +
                                "</tr>" +
                                "<tr>" +
                                    "<td>" +
                                        "<input type='checkbox' name='callerrequest" + CID + "' id='chkmainothers" + CID + "' onclick='ShowCallerRequest(this.name);' value='Other' />Other" +
                                    "</td>" +
                                "</tr>" +
                            "</table>" +
            //End Caller Request
                                        "</td>" +
                                    "</tr>" +
                                    "<tr>" +
                                        "<td colspan=\"4\">" +
                                            "Notes: &nbsp;" +
                                            "<textarea id=\"txtDescription" + CID + "\"></textarea>" +
                                        "</td>" +
                                    "</tr>" +
                                    "<tr>" +
                                        "<td colspan=\"4\">" +
                                            "<input type=\"checkbox\" id='chkRequirefollowup" + CID + "' />&nbsp;<span>Requires Follow Up</span>" +
                                        "</td>" +
                                    "</tr>" +
                        "</table>" +
                    "</div></td></tr>";


            if (divtable.rows.length == 0) {
                $("#maintable").append(newRow);
            }
            else {
                $("#" + divtable.rows[0].id).before(newRow);
            }




            //Auto scroll when add new item
            var co = document.getElementById("edit" + CID);
            co.focus();

            //Water mark for Phone Number
            SetWatermarkPhone(CID);

            LoadCallertypeAgency(CID);

            LoadCallerTypeRegions(CID);
            LoadCallerRequestRegions(CID);

            //            document.getElementById("txtCity" + CID).focus(); ;
            //            document.getElementById("txtfirst" + CID).focus(); ;
        }

        function SetWatermarkPhone(CID) {
            $("#txtPhone" + CID).addClass("lightText")
            // set default value
            $("#txtPhone" + CID).val("xxx-xxx-xxxx")
            // onfocus action
            $("#txtPhone" + CID).focus(function () {
                if ($(this).val() == "xxx-xxx-xxxx") {
                    $(this).removeClass("lightText").val("");
                }
                // focus lost action
            }).blur(function () {
                if ($(this).val() == "") {
                    $(this).val("xxx-xxx-xxxx").addClass("lightText");
                }
            });
        }

        function ShowCallerType(controlID) {

            var divID = controlID.replace(/callertype/gi, "");
            if ($('#rbagency' + divID).is(':checked') == true) {
                $("#divagency" + divID).css('display', 'block');
            }
            else {
                $("#divagency" + divID).css('display', 'none');
            }

            if ($('#rbLaw' + divID).is(':checked') == true) {
                $("#divcallertyperegion" + divID).css('display', 'block');
            }
            else {
                $("#divcallertyperegion" + divID).css('display', 'none');
            }
        }

        function ShowCallerRequest(controlID) {
            //Sub check boxes
            var divID = controlID.replace(/callerrequest/gi, "");
            if ($('#chkdvrt' + divID).is(':checked') == true) {
                $("#divdvrtlist" + divID).css('display', 'block');
            }
            else {
                $("#divdvrtlist" + divID).css('display', 'none');
            }

            // Law Enforcement Region DROPDOWN
            divID = controlID.replace(/dvrtlist/gi, "");
            if ($('#chklaw' + divID).is(':checked') == true) {
                $("#divdvrtregion" + divID).css('display', 'block');
            }
            else {
                $("#divdvrtregion" + divID).css('display', 'none');
            }

            //cps sub checkboxes
            if ($('#chkcps' + divID).is(':checked') == true) {
                $("#divcps" + divID).css('display', 'block');
            }
            else {
                $("#divcps" + divID).css('display', 'none');
            }

        }

        function ddlcallertyperegion_onchange(controlID) {
            var ddlID = "ddlcallertyperegion" + controlID;
            if (document.getElementById(ddlID).value == "Other") {
                $("#txtcallertyperegion" + controlID).css('display', 'block');

            }
            else {
                $("#txtcallertyperegion" + controlID).css('display', 'none');

            }
        }
        function ddlcallertypeAgency_onchange(controlID) {
            var ddlID = "dllcallertypeagency" + controlID;
            if (document.getElementById(ddlID).value == "Other") {
                $("#txtcallertypeagency" + controlID).css('display', 'block');

            }
            else {
                $("#txtcallertypeagency" + controlID).css('display', 'none');

            }
        }

        function ddldvrtregion_onchange(controlID) {
            var divID = controlID.replace(/ddldvrtregion/gi, "");
            var selectText = document.getElementById(controlID).value;
            if (selectText == "Other") {
                $("#txtcallerReqregion" + divID).css('display', 'block');
                $("#divOfficer" + divID).css('display', 'none');
            }
            else {
                $("#txtcallerReqregion" + divID).css('display', 'none');
                $("#divOfficer" + divID).css('display', 'block');

                //Fill Officers
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    data: "{regionName: '" + selectText + "'}",
                    processData: false,
                    url: "CrisisCallLog.aspx/GetOfficers",
                    dataType: "json",
                    success: function (data) {
                        var officerString = data.d;

                        var ddlOfficer = "ddlofficer" + divID;
                        document.getElementById(ddlOfficer).options.length = 0;

                        var list = officerString.split(',');
                        for (i = 0; i < list.length; i++) {
                            $('#' + ddlOfficer).append($("<option></option>").attr("value", list[i]).text(list[i]));
                        }

                    }
                });
            }
        }



        // Delete Call Header Row & Preview & Edit html
        function RemoveCallPanel(value) {
            var divID = value.id;
            var trID = divID.replace("edit", "tr");
            var trHeaderID = divID.replace("edit", "trheader");
            var trpreviewID = divID.replace("edit", "trpreview");

            if (confirm("Are you sure you want to delete this call?")) {
                $("#" + trID).remove();
                $("#" + trHeaderID).remove();
                $("#" + trpreviewID).remove();
            }
            var divCount = $("#maintable tr").size();
            if (divCount <= 0) {
                document.getElementById('<%= lblBulletinedit.ClientID%>').innerHTML = "<div id='watermark'>Your block goes here!!!</div>";
            }
        }

        function EditCallPanel(controlID, editImageControl) {
            var id = controlID.id.replace(/trpreview/gi, "");
            $("#trpreview" + id).css('display', 'none');
            $("#tr" + id).css('display', 'block');
            $("#imgeditcall" + id).css('display', 'none');

            //document.getElementById("ddlcallhour" + id).value = document.getElementById("ddlcallhour" + id).value;
        }

        function LoadData() {
            GetCurrentDate();
            var divtable = document.getElementById("maintable");
            if ($("#divTitle") != null) {
                $("#divTitle").css('display', 'none');
            }

            if (divtable != null) {
                var dd = document.getElementById("<%=lbldummy.ClientID %>").innerHTML;
                for (x = 0; x < divtable.rows.length; ) {
                    j = divtable.rows[x].id.replace('trheader', '');

                    //We have 3rows every call 1==Header 2==preview 3==edit row
                    x = x + 3;
                    var html = document.getElementById("tblpreview" + j).outerHTML;
                    $("#tdpreview" + j).append(html);
                    document.getElementById("tblpreview" + j).style.width = '100%';
                }

                for (x = 0; x < divtable.rows.length; ) {
                    j = divtable.rows[x].id.replace('trheader', '');

                    //We have 3rows every call 1==Header 2==preview 3==edit row
                    x = x + 3;
                    $("#tr" + j).css('display', 'none');
                    $("#trpreview" + j).css('display', 'block');
                    $("#imgeditcall" + j).css('display', '');
                }

                LoadCallertypeAgency(null);
                LoadCallerTypeRegions(null);
                LoadCallerRequestRegions(null);
            }

            if (document.getElementById('<%=rbPrivate.ClientID %>').checked) {
                document.getElementById('<%=BtnSave.ClientID %>').style.display = "block";
                document.getElementById('<%=BtnPublish.ClientID %>').style.display = "none";
            }
            else {
                document.getElementById('<%=BtnSave.ClientID %>').style.display = "none";
                document.getElementById('<%=BtnPublish.ClientID %>').style.display = "block";
            }

            $("#dummyDIV").css('display', 'none');
        }

        function ValidateCallDetails() {

            var reurnValue = true;
            if (Page_ClientValidate('ABC') && Page_IsValid) {

                var phonenumberPattern = /^[0-9]\d{2}-\d{3}-\d{4}$/;

                //Inner Values
                var divtable = document.getElementById("maintable");
                if (divtable != null) {

                    for (x = 0; x < divtable.rows.length; ) {
                        i = divtable.rows[x].id.replace('trheader', '');

                        //We have 3rows every call 1==Header 2==preview 3==edit row
                        x = x + 3;

                        if (document.getElementById("txtfirst" + i).value.trim() == "") {
                            alert('First Name is mandatory in Call Log' + i);
                            reurnValue = false;
                        }
                        else if (document.getElementById("txtPhone" + i).value.trim() == "" || document.getElementById("txtPhone" + i).value.trim() == "xxx-xxx-xxxx") {
                            alert('Phone Number is mandatory in Call Log' + i);
                            reurnValue = false;
                        }
                        else if (!phonenumberPattern.test(document.getElementById("txtPhone" + i).value.trim())) {
                            alert('Phone Number Format  is Wrong in Call Log' + i);
                            reurnValue = false;
                        }
                        else if (document.getElementById("txtcallmin" + i).value.trim() == "") {
                            alert('Time of Call Minutes is mandatory in Call Log' + i);
                            reurnValue = false;
                        }
                    } //end for loop

                    //Log Out Time
                    if (document.getElementById("<%= txtlogoutmin.ClientID%>").value.trim() == "") {
                        alert('Time of Call Minutes is mandatory in Call Log' + i);
                        return false;
                    }
                }
            }
            else {
                reurnValue = false;
            }

            return reurnValue;
        }

        function SaveHTMLData() {
            //getting preview html
            if (ValidateCallDetails()) {
                PreviewHTML(2);
                //edit html 
                var divtable = document.getElementById("maintable");
                if (divtable != null) {
                    for (x = 0; x < divtable.rows.length; ) {
                        j = divtable.rows[x].id.replace('trheader', '');

                        //We have 3rows every call 1==Header 2==preview 3==edit row
                        x = x + 3;
                        $("#tblpreview" + j).remove();
                    }
                    //Remove preview divs getting only Edit html(input values)
                    document.getElementById("<%=hdnEditHTML.ClientID %>").value = divtable.outerHTML;
                }

                var isCompleted = false;
                var isPrivate = false;

                isPrivate = document.getElementById('<%=rbPrivate.ClientID %>').checked;
                var exDate = document.getElementById("<%=txtExDate.ClientID %>").value;
                document.getElementById("<%=hdnExDate.ClientID %>").value = exDate;
                document.getElementById("<%=hdnPrivate.ClientID %>").value = isPrivate;
                document.getElementById("<%=hdnCompleted.ClientID %>").value = isCompleted;


                $find("<%=MPEProgress.ClientID %>").show();
                return true;
            }
            else {
                return false;
            }
        }

        

    </script>
    <%--Preview HTML & Edit HTML--%>
    <script type="text/javascript">

        function ReplaceSpecialCharacter(value) {
            value = value.replace(/&/gi, "&amp;");
            value = value.replace(/&amp;amp;/gi, "&amp;");

            value = value.replace(/'/gi, "&apos;");
            value = value.replace(/&apos;apos;/gi, "&apos;");

            value = value.replace(/</gi, "&lt;");
            value = value.replace(/&lt;lt;/gi, "&lt;");

            return value;
        }

        function displaypage() {
            //document.forms[0].submit();
        }

        // #region
        function PreviewHTML(type) {

            var divCount = $("#maintable div").size();
            var divtable = "";
            if (divCount > 0) {
                var elems = document.getElementById("maintable").getElementsByTagName("input");
                for (var i = 0; i < elems.length; i++) {
                    // set attribute to property value
                    if (elems[i].type == "text") {
                        elems[i].setAttribute("value", elems[i].value);
                    }
                    if (elems[i].type == "checkbox" || elems[i].type == "radio") {
                        if (elems[i].checked == true) {
                            elems[i].setAttribute("checked", "checked");
                        }
                        else {
                            elems[i].removeAttribute("checked");
                            //elems[i].setAttribute("checked", " ");
                        }
                    } //end loop
                }

                var elems = document.getElementById("maintable").getElementsByTagName("select");
                for (var i = 0; i < elems.length; i++) {
                    elems[i].setAttribute("value", elems[i].value);
                    for (k = 0; k < elems[i].length; k++) {
                        if (elems[i].options[k].text == elems[i].value) {
                            elems[i].options[k].setAttribute('selected', "selected");
                        }
                        else {
                            elems[i].options[k].removeAttribute('selected');
                        }
                    }
                }
                var divtable = document.getElementById("maintable");
            }

            var ROWS = "";
            var previewHTMLStr = "";

            var XMLString = "";

            // bulletin & login name
            var bulletinName = document.getElementById("<%=txtbulletinName.ClientID %>").value.trim();
            var loginAssociateName = document.getElementById("<%=ddlAssociates1.ClientID %>").value;
            if (bulletinName != "") {
                bulletinName = ReplaceSpecialCharacter(bulletinName);
                //HTML
                ROWS = "<tr><td>Report Title:</td><td>" + bulletinName + "</td></tr>";
                //XML
                XMLString = " BulletinName= '" + bulletinName + "'  ";
            }
            if (loginAssociateName != "") {

                //HTML
                ROWS = ROWS + "<tr><td>DVRT Associate ID:</td><td> " + loginAssociateName + "</td></tr>";
                //XML
                XMLString = XMLString + "  Associate1= '" + loginAssociateName + "'";
            }
            // login Time
            var loginHour = document.getElementById("<%=ddlloginhour.ClientID %>").value.trim();
            var loginMin = document.getElementById("<%=txtloginMins.ClientID %>").value.trim();
            var loginSection = document.getElementById("<%=ddlloginsection.ClientID %>").value.trim();
            //Login Date
            var loginDate = document.getElementById("<%=txtlogindate.ClientID %>").value.trim()

            // HTML
            ROWS = ROWS + "<tr><td colspan='2'>Log In Date:&nbsp;" + loginDate + "&nbsp;&nbsp;Time:&nbsp;" + loginHour + ":" + loginMin + " " + loginSection + "</td></tr>";
            // XML
            XMLString = XMLString + " LoginDate='" + loginDate + "'  LoginHour='" + loginHour + "'  LoginMin='" + loginMin + "' LoginSection='" + loginSection + "' ";

            //log out date & time
            var logOutDate = document.getElementById("<%=txtlogoutDate.ClientID %>").value.trim();
            var logoutHour = document.getElementById("<%=ddllogouthour.ClientID %>").value.trim();
            var logoutMin = document.getElementById("<%=txtlogoutmin.ClientID %>").value.trim();
            var logoutSection = document.getElementById("<%=ddllogoutsection.ClientID %>").value.trim();

            // HTML
            ROWS = ROWS + "<tr><td colspan='2'>Log Out Date:&nbsp;" + logOutDate + "&nbsp;&nbsp;Time:&nbsp;" + logoutHour + ":" + logoutMin + " " + logoutSection + "</td></tr>";
            // XML
            XMLString = XMLString + "LogOutDate='" + logOutDate + "' LogOutHour='" + logoutHour + "' LogOutMin='" + logoutMin + "' LogOutSection='" + logoutSection + "'";



            // Transferred TO Users
            var associate2 = document.getElementById("<%=ddlAssociates2.ClientID %>").value;
            // HTML
            ROWS = ROWS + "<tr><td>Transferred To:</td><td>" + associate2 + "</td></tr>";
            // XML
            XMLString = XMLString + " TransferredPhoneTo='" + associate2 + "' ";

            ROWS = " <tr><td colspan='2'><table cellpadding='3' cellspacing='3' style='border: 2px solid black; width: 300px;'>" + ROWS + "</table></td></tr>";

            //Start Caller Details 
            if (divtable != "") {
                var childTable = "";
                var totalchildXMlString = "";
                //var totalRowCount = divtable.rows.length / 3;


                //for (x = 1; x <= totalRowCount; x++) {
                for (x = 0; x < divtable.rows.length; ) {
                    i = divtable.rows[x].id.replace('trheader', ''); ;

                    //We have 3rows every call 1==Header 2==preview 3==edit row
                    x = x + 3;


                    var childRow = "";
                    var childXMLElements = "";

                    var first = ReplaceSpecialCharacter(document.getElementById("txtfirst" + i).value.trim());
                    var last = ReplaceSpecialCharacter(document.getElementById("txtlast" + i).value.trim());
                    var phone = document.getElementById("txtPhone" + i).value.trim();

                    var callSection = document.getElementById("ddlcallsection" + i).value.trim();
                    var callHour = document.getElementById("ddlcallhour" + i).value.trim()
                    var callMin = document.getElementById("txtcallmin" + i).value.trim();

                    if (first != "") {
                        // HTML
                        childRow = childRow + "<tr><td>Name:</td><td>" + first + " " + last + "</td></tr>";
                        // XML
                        childXMLElements = " FirstName='" + first + "' LastName='" + last + "' ";
                    }
                    var address = ReplaceSpecialCharacter(document.getElementById("txtAddress" + i).value.trim());
                    if (address != "") {
                        // HTML
                        childRow = childRow + "<tr><td>Address:</td><td>" + address + "</td></tr>";
                        // XML
                        childXMLElements = childXMLElements + " Address='" + address + "'";
                    }
                    var city = ReplaceSpecialCharacter(document.getElementById("txtCity" + i).value.trim());
                    if (city != "") {
                        // HTML
                        childRow = childRow + "<tr><td>City:</td><td>" + city + "</td></tr>";
                        // XML
                        childXMLElements = childXMLElements + " City='" + city + "'";
                    }
                    var zip = ReplaceSpecialCharacter(document.getElementById("txtZip" + i).value.trim());
                    if (zip != "") {
                        // HTML
                        childRow = childRow + "<tr><td>Zip:</td><td>" + zip + "</td></tr>";
                        // XML
                        childXMLElements = childXMLElements + " Zip='" + zip + "'";
                    }
                    if (phone != "" && phone != "xxx-xxx-xxxx") {
                        // HTML
                        childRow = childRow + "<tr><td>Phone Number:</td><td>" + phone + "</td></tr>";
                        // XML
                        childXMLElements = childXMLElements + " PhoneNumber='" + phone + "'";
                    }
                    if (callSection != "" && callHour != "" && callMin != "") {
                        // HTML
                        //childRow = childRow + "<tr><td>Time of Call:</td><td>" + callHour + ":" + callMin + " " + callSection + "</td></tr>";
                        // XML
                        childXMLElements = childXMLElements + "  CallHour='" + callHour + "' CallMin='" + callMin + "' CallSection='" + callSection + "'";
                    }
                    // Check box If Requires
                    var chkRequire = document.getElementById("chkRequirefollowup" + i);
                    // HTML
                    if (chkRequire.checked) {
                        childRow = childRow + "<tr><td>Requires Follow Up:</td><td>Yes</td></tr>";
                    }
                    else {
                        childRow = childRow + "<tr><td>Requires Follow Up:</td><td>No</td></tr>";
                    }
                    // XML
                    childXMLElements = childXMLElements + " IsRequirefollowup='" + chkRequire.checked + "'";


                    childRow = "<tr>" +
                                    "<td colspan='2' align='center' style='border-bottom: 2px dashed #ccc; height:30px; font-size:16px;'>" +
                                        "<b>CALL " + i + " &nbsp; Time: " + callHour + ":" + callMin + " " + callSection + "</b>" +
                                    "</td>" +
                                "</tr>" +
                                "<tr>" + //start caller information
                                    "<td colspan='2'>" +
                                     "   <span style='margin-left: 10px;'><b>Caller Information</b></span>" +
                                    "</td>" +
                                "</tr>" +
                                "<tr>" +
                                    "<td colspan='2'>" +
                                        "<table cellpadding='3' cellspacing='3' style='border: 2px solid black; margin-left: 5px;'" +
                                            "width='97%'>" + childRow + "" +
                                          "</table>" +
                                     "</td>" +
                               "</tr>";  //end caller information

                    var otherText = "";

                    //Start Caller Type
                    var callerTypeRow = "";
                    var rb_list = $('#tblCallerType' + i + ' input:radio');
                    for (k = 0; k < rb_list.length; k++) {
                        if (rb_list[k].checked == true) {
                            if (rb_list[k].value == "Other") {
                                // HTML
                                otherText = ReplaceSpecialCharacter(document.getElementById("rbtxtothers" + i).value.trim())
                                callerTypeRow = callerTypeRow + "<tr><td>Caller Type:</td><td>Other</td></tr>";
                                callerTypeRow = callerTypeRow + "<tr><td>Other:</td><td>" + otherText + "</td></tr>";

                                //XML
                                childXMLElements = childXMLElements + " CallerType='Other:" + otherText + "'";
                            }
                            else if (rb_list[k].value == "Agency") {
                                if (document.getElementById("dllcallertypeagency" + i).value == "Other") {
                                    // HTML
                                    callerTypeRow = callerTypeRow + "<tr><td>Caller Type:</td><td>Agency</td></tr>";
                                    callerTypeRow = callerTypeRow + "<tr><td>Agency:</td><td>" + ReplaceSpecialCharacter(document.getElementById("txtcallertypeagency" + i).value.trim()) + "</td></tr>";
                                    //XML
                                    childXMLElements = childXMLElements + " CallerType='Agency:" + document.getElementById("dllcallertypeagency" + i).value.trim() + "'";
                                }
                                else {
                                    // HTML
                                    callerTypeRow = callerTypeRow + "<tr><td>Caller Type:</td><td>Agency</td></tr>";
                                    callerTypeRow = callerTypeRow + "<tr><td>Agency:</td><td> " + document.getElementById("dllcallertypeagency" + i).value.trim() + "</td></tr>";
                                    //XML
                                    childXMLElements = childXMLElements + " CallerType='Agency:" + document.getElementById("dllcallertypeagency" + i).value.trim() + "'";
                                }
                            }
                            else if (rb_list[k].value == "Law Enforcement") {
                                if (document.getElementById("ddlcallertyperegion" + i).value == "Other") {

                                    value = ReplaceSpecialCharacter(document.getElementById("txtcallertyperegion" + i).value.trim())
                                    // HTML
                                    callerTypeRow = callerTypeRow + "<tr><td>Caller Type:</td><td>Law Enforcement</td></tr>";
                                    callerTypeRow = callerTypeRow + "<tr><td>Region:</td><td>" + value + "</td></tr>";
                                    // XML
                                    childXMLElements = childXMLElements + " CallerType='Law Enforcement:Other-" + value + "'";
                                }
                                else {
                                    // HTML
                                    callerTypeRow = callerTypeRow + "<tr><td>Caller Type:</td><td>Law Enforcement</td></tr>";
                                    callerTypeRow = callerTypeRow + "<tr><td>Region:</td><td>" + document.getElementById("ddlcallertyperegion" + i).value.trim() + "</td></tr>";
                                    // XML
                                    childXMLElements = childXMLElements + " CallerType='Law Enforcement:" + document.getElementById("ddlcallertyperegion" + i).value.trim() + "'";
                                }
                            }
                            else {
                                // HTML
                                callerTypeRow = callerTypeRow + "<tr><td>Caller Type:</td><td>" + rb_list[k].value + "</td></tr>";
                                // XML
                                childXMLElements = childXMLElements + " CallerType='" + rb_list[k].value + "'";
                            }
                            break;
                        }
                    } //End Caller Types


                    childRow = childRow + "<tr>" + //caller type
                                    "<td colspan='2'>" +
                                        "<span style='margin-left: 10px;'><b>Caller Type</b></span>" +
                                    "</td>" +
                                "</tr>" +
                                  "<tr>" +
                                    "<td colspan='2'>" +
                                        "<table cellpadding='3' cellspacing='3' style='border: 2px solid black; margin-left: 5px;'" +
                                            "width='97%'>" +
                                            callerTypeRow
                                            + "</table>" +
                                    "</td>" +
                                "</tr>";




                    var firsRow = "";
                    var DVRTROW = "";
                    var LawEnforcementRow = "";

                    var callreqValues = "";
                    var htmlRowValues = "";
                    //Start Caller Request
                    var chk_list = document.getElementsByName("callerrequest" + i);
                    for (k = 0; k < chk_list.length; k++) {
                        if (chk_list[k].checked == true) {
                            if (chk_list[k].value == "DVRT") {
                                var value = "";
                                var xmlValue = "";
                                var dvrtlist = document.getElementsByName("dvrtlist" + i);
                                for (a = 0; a < dvrtlist.length; a++) {
                                    if (dvrtlist[a].checked == true) {
                                        if (dvrtlist[a].value == "Law Enforcement") {
                                            var regionValue = document.getElementById("ddldvrtregion" + i).value;
                                            if (regionValue == "Other") {

                                                otherText = ReplaceSpecialCharacter(document.getElementById("txtcallerReqregion" + i).value)
                                                // HTML
                                                value = value + "DVRT--> Law Enforcement-->Other:" + otherText + "</br>";
                                                // XML
                                                xmlValue = xmlValue + "DVRT:Law Enforcement:Other:" + otherText + "|";
                                            }
                                            else {//CHPD else
                                                // HTML
                                                value = value + "DVRT--> Law Enforcement-->" + regionValue + "--> &nbsp;" + document.getElementById("ddlofficer" + i).value + "</br>";
                                                // XML
                                                xmlValue = xmlValue + "DVRT:Law Enforcement:" + regionValue + ":" + document.getElementById("ddlofficer" + i).value + "|";
                                            }
                                        }
                                        else if (dvrtlist[a].value == "Other") {

                                            otherText = ReplaceSpecialCharacter(document.getElementById("chktxtothers" + i).value);

                                            // HTML
                                            value = value + "DVRT:Other-->" + otherText + "";
                                            // XML
                                            xmlValue = xmlValue + "DVRT:Other:" + otherText + "";
                                        }
                                        else {//Law Enforcement else
                                            // HTML
                                            value = value + "DVRT--> " + dvrtlist[a].value.trim() + "</br>";
                                            xmlValue = xmlValue + "DVRT:" + dvrtlist[a].value.trim() + "|";
                                        }
                                    } //End checked false
                                } //End for loop
                                if (value.endsWith(">")) {
                                    value = value.substring(0, value.length - 6);
                                }

                                if (value == "") {
                                    //value = "<tr><td>Caller Request:</td><td>" + chk_list[k].value.trim() + "</td></tr>";
                                    value = "" + chk_list[k].value.trim() + "";
                                    xmlValue = chk_list[k].value;


                                }
                                //childRow = childRow + "<tr><td>Caller Request:</td><td>" + value + "</td></tr>";
                                htmlRowValues = htmlRowValues + "" + value + "</br>";
                                callreqValues = callreqValues + xmlValue + ",";
                            } //DVRT Else                           
                            else {
                                // HTML
                                //childRow = childRow + "<tr><td>Caller Request:</td><td>" + chk_list[k].value + "</td></tr>";
                                htmlRowValues = htmlRowValues + "" + chk_list[k].value + "</br>";
                                // XML
                                callreqValues = callreqValues + chk_list[k].value + ",";
                            }
                        }
                    } //End Caller Request     
                    // XML Call Request

                    var rootPath = '<%=RootPath %>';
                    var emptyBoxImage = "<img src='" + rootPath + "/Images/EmptyBox.png' />";
                    var fillBoxImgae = "<img src='" + rootPath + "/Images/FillBox.png' />";

                    var chkAgency = emptyBoxImage;
                    var chkCounseling = emptyBoxImage;
                    var chkLegal = emptyBoxImage;
                    var chkShelter = emptyBoxImage;
                    var chkSocial = emptyBoxImage;
                    var chkMainOther = emptyBoxImage;
                    var chkDVRT = emptyBoxImage;


                    if (document.getElementById("chkagency" + i).checked == true) {
                        //chkAgency = " checked='checked' ";
                        chkAgency = fillBoxImgae;
                    }
                    if (document.getElementById("chkcounseling" + i).checked == true) {
                        chkCounseling = fillBoxImgae;
                    }
                    if (document.getElementById("chklegal" + i).checked == true) {
                        chkLegal = fillBoxImgae;
                    }
                    if (document.getElementById("chkshelter" + i).checked == true) {
                        chkShelter = fillBoxImgae;
                    }
                    if (document.getElementById("chksocial" + i).checked == true) {
                        chkSocial = fillBoxImgae;
                    }
                    if (document.getElementById("chkdvrt" + i).checked == true) {
                        chkDVRT = fillBoxImgae;
                    }
                    if (document.getElementById("chkmainothers" + i).checked == true) {
                        chkMainOther = fillBoxImgae;
                    }


                    firsRow = "<tr>" +
                                            "<td>" + chkAgency + "&nbsp;Agency" + "</td>" +
                                                "<td>" + chkCounseling + "&nbsp;Counseling" + "</td>" +
                                                "<td>" + chkLegal + "  &nbsp;Legal" + "</td>" +
                                            "</tr>" +
                                             "  <tr>" +
                                              "  <td>" + chkShelter + "&nbsp;Shelter" + " </td>" +
                                              "  <td>" + chkSocial + "&nbsp;Social Worker" + " </td>" +
                                               " <td>" + chkMainOther + " Other &nbsp;</td>" +
                                           " </tr>" +
                                            "<tr>" +
                                            "<td> " + chkDVRT + "  <b>DVRT</b>" +
                                            "</td>" +
                                            "</tr>";


                    var chkcps = emptyBoxImage;
                    var chkhospital = emptyBoxImage;
                    var chkScene = emptyBoxImage;
                    var chkfollowup = emptyBoxImage;
                    var chklaw = emptyBoxImage;
                    var chksubother = emptyBoxImage;

                    // Start Sub CPS
                    var chkchildrenscene = emptyBoxImage;
                    var chkchildrenhousehold = emptyBoxImage;
                    var cpsChecks = "";

                    if (document.getElementById("chkchildrenscene" + i) != null) {
                        childXMLElements = childXMLElements + " CPSIsChildrenScene='" + document.getElementById("chkchildrenscene" + i).checked + "' ";
                        childXMLElements = childXMLElements + " CPSIsChildrenHouseHold='" + document.getElementById("chkchildrenhousehold" + i).checked + "' ";

                        if (document.getElementById("chkchildrenscene" + i).checked == true) {
                            chkchildrenscene = fillBoxImgae;
                        }
                        if (document.getElementById("chkchildrenhousehold" + i).checked == true) {
                            chkchildrenhousehold = fillBoxImgae;
                        }
                    }
                    //End Sub CPS

                    if (document.getElementById("chkcps" + i).checked == true) {
                        chkcps = fillBoxImgae;

                        cpsChecks = "<div style='float:left;'>" + chkchildrenscene + "&nbsp;Children on scene " +
                        " &nbsp;&nbsp;" + chkchildrenhousehold + "&nbsp;Children in household</div>";
                    }
                    if (document.getElementById("chkhospital" + i).checked == true) {
                        chkhospital = fillBoxImgae;
                    }
                    if (document.getElementById("chkScene" + i).checked == true) {
                        chkScene = fillBoxImgae;
                    }
                    if (document.getElementById("chkfollowup" + i).checked == true) {
                        chkfollowup = fillBoxImgae;
                    }
                    if (document.getElementById("chklaw" + i).checked == true) {
                        chklaw = fillBoxImgae;
                    }
                    if (document.getElementById("chksubother" + i).checked == true) {
                        chksubother = fillBoxImgae;
                    }








                    if (document.getElementById("chkdvrt" + i).checked == true) {
                        if (cpsChecks != "") {
                            firsRow = firsRow + "<tr>" +
                                                    "<td colspan='3'>" + chkcps + " &nbsp;<b>CPS</b>" + cpsChecks +
                                                    "</td>" +
                                                 "</tr>" +
                                                "<tr>" +
                                                    "<td>" + chkhospital + " &nbsp;Hospital" +
                                                    "</td>" +
                                                    "<td>" + chkScene + " &nbsp;Scene" +
                                                    "</td>" +
                                               "<td></td>" +
                                            "</tr>" +
                                            "<tr>" +
                                                "<td>" + chkfollowup + " &nbsp;Follow Up" +
                                              "  </td>" +
                                               " <td >" + chklaw + " &nbsp;Law Enforcement" +
                                                "</td>" +
                                               " <td>" + chksubother + "  &nbsp;" + document.getElementById("chktxtothers" + i).value + "</td>" +
                                           " </tr>";
                        }
                        else {
                            firsRow = firsRow + "<tr>" +
                                                "<td>" + chkcps + " &nbsp;CPS" + cpsChecks +
                                                "</td>" +
                                               " <td>" + chkhospital + " &nbsp;Hospital" +
                                                "</td>" +
                                                "<td>" + chkScene + " &nbsp;Scene" +
                                               " </td>" +
                                            "</tr>" +
                                            "<tr>" +
                                                "<td>" + chkfollowup + " &nbsp;Follow Up" +
                                              "  </td>" +
                                               " <td >" + chklaw + " &nbsp;Law Enforcement" +
                                                "</td>" +
                                               " <td>" + chksubother + "  &nbsp;" + ReplaceSpecialCharacter(document.getElementById("chktxtothers" + i).value) + "</td>" +
                                           " </tr>";
                        }
                    }
                    if (document.getElementById("chkdvrt" + i).checked == true && document.getElementById("chklaw" + i).checked == true) {
                        firsRow = firsRow + "<tr>" +
                                               " <td colspan='3'>" +
                                                   " <span><b>Law Enforcement Information:</b></span>" +
                                                "</td>" +
                                            "</tr>" +
                                            "<tr>" +
                                               " <td colspan='3'>" +
                                                   " Region:&nbsp;" + document.getElementById("ddldvrtregion" + i).value +
                                               " </td>" +
                                           " </tr>" +
                                           " <tr>" +
                                              "  <td colspan='3'>" +
                                                   " Law Enforcement Personnel:&nbsp;" + document.getElementById("ddlofficer" + i).value +
                                               " </td>" +
                                           " </tr>";
                    }


                    childRow = childRow + "<tr>" +
                                    "<td colspan='2'>" +
                                        "<span style='margin-left: 10px;'><b>Caller Request</b></span>" +
                                    "</td>" +
                                "</tr>" +
                                "<tr>" +
                                    "<td>" +
                                        "<table cellpadding='3' cellspacing='3' style='border: 2px solid black; margin-left: 5px;'" +
                                            "width='97%'>" + firsRow +
                                        "</table>" +
                                   "</td>" +
                                  "</tr>";

                    childXMLElements = childXMLElements + " CallRequest='" + callreqValues + "'";

                    //Description
                    var description = ReplaceSpecialCharacter(document.getElementById("txtDescription" + i).value.trim());
                    document.getElementById("txtDescription" + i).innerHTML = description;

                    if (description != "") {
                        // HTML
                        childRow = childRow + " <tr>" +
                                                 "<td colspan='2'>" +
                                                     "<span style='margin-left: 10px;'><b>Notes:</b></span>" +
                                                 "</td>" +
                                              "</tr>";
                        childRow = childRow + "<tr><td colspan='2' ><div style='overflow: auto; word-wrap: break-word; border: 2px solid black; height: 50px; margin-left: 5px; padding-left: 5px;' " +
                        " width='97%'>" + description.replace(/\n/gi, "<br/>") + "</div></td></tr><tr><td></td></tr>";
                        // XML
                        childXMLElements = childXMLElements + " Description='" + description + "'";
                    }

                    childRow = "<table class='radius' id='tblpreview" + i + "' cellpadding='0' cellspacing='3' style='border:1px solid black; margin-top:5px; width: 300px;'>" + childRow + "</table>";
                    //$("#tdpreview" + i).append(childRow);
                    childTable = childTable + childRow;

                    //XML Sub Elements
                    childXMLElements = "<ChildCallerDetails " + childXMLElements + " />";
                    totalchildXMlString = totalchildXMlString + childXMLElements;

                } //End For each

                //All Caller Details 
                //ROWS = ROWS + "<tr><td colspan='2'><b>Caller Details</b></td></tr>";
                ROWS = ROWS + "<tr><td colspan='2'>" + childTable + "</td></tr>";

            } //End Caller Details 


            //end preview html


            previewHTMLStr = "<table cellpadding='0' cellspacing='0' style='padding-left:0px; padding-top:10px; text-align:left;'>" + ROWS + "</table>";
            var titleName = "<div id='divTitle' style=\"background: #fffdfb; overflow: hidden; width: auto; margin: 0px; padding: 15px 0px 40px 0px;\">" +
                                "<div style=\"font-size: 26px; line-height: 28px; font-weight: normal; color: #f15b29; text-align: center; padding: 0px 0px 10px 0px; border-bottom: 1px dashed #d1d1d1;\">Crisis Log Report</div>";
            previewHTMLStr = titleName + previewHTMLStr + "</div>";
            //Preview HTMl
            document.getElementById("<%=hdnPreviewHTML.ClientID %>").value = previewHTMLStr;
            //Edit HTML
            document.getElementById("<%=hdnEditHTML.ClientID %>").value = divtable.outerHTML;

            //Final XML String
            XMLString = "<Bulletins><CallLogDetails " + XMLString + " /> " + totalchildXMlString + " </Bulletins>";
            document.getElementById("<%=hdnEditXML.ClientID %>").value = XMLString;
            if (type == "1") {
                var bulletinHeader = document.getElementById("<%=hdnBulletinHeader.ClientID %>").value;
                bulletinHeader = bulletinHeader.replace("#BuildHtmlForForm#", previewHTMLStr);
                // Shorten URL Purpose
                document.getElementById("divLoading").style.display = "block";
                bulletinHeader = bulletinHeader.replace(/</gi, "&lt;_");
                bulletinHeader = bulletinHeader.replace(/>/gi, "&gt;_");
                bulletinHeader = bulletinHeader.replace(/'/gi, "&quots;_");

                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    data: "{htmlString:'" + bulletinHeader + "'}",
                    url: "CrisisCallLog.aspx/ReplaceShortURltoHmlString",
                    dataType: "json",
                    processData: false,
                    success: function (data) {
                        bulletinHeader = data.d;

                        document.getElementById("<%=lblpreview.ClientID %>").innerHTML = "";
                        document.getElementById("<%=lblpreview.ClientID %>").innerHTML = bulletinHeader;
                        document.getElementById("<%=lblbulletinamme.ClientID %>").innerHTML = document.getElementById("<%=lblBulletinName.ClientID %>").innerHTML;

                        var modal = $find("BulletinPreview");
                        modal.show();

                        document.getElementById("divLoading").style.display = "none";

                    },
                    error: function (error) {
                        //alert("ERROR:: " + error.statusText);
                        document.getElementById("divLoading").style.display = "none";
                    }
                });

                return false;
            }
        }
        // #endregion
    </script>
    <script src="../../Scripts/jquery-ui.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            //SearchText();
            if ('<%= IsScheduleEmails %>' == 'False') {
                if (document.getElementById('<%= hdnPermissionType.ClientID%>').value == "A")
                    document.getElementById('<%= lblPublish.ClientID%>').innerHTML = "Submit for approval";
                else
                    document.getElementById('<%= lblPublish.ClientID%>').innerHTML = "Publish Now";
            }
        });
        function SearchText() {
            $("#<%=txtbulletinName.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "CrisisCallLog.aspx/GetBulletinAutoCompleteData",
                        data: "{'bulletinName':'" + document.getElementById('<%=txtbulletinName.ClientID %>').value + "'}",
                        dataType: "json",
                        success: function (data) {
                            //response(data.d);
                        },
                        error: function (result) {
                            alert("Error");
                        }
                    });
                }
            });
        }

        function GetCurrentDate() {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "Default.aspx/GetUserTimeZoneDashboard",
                dataType: "json",
                success: function (response) {
                    currentTime = new Date(response.d);
                    dformat = [(currentTime.getMonth() + 1).padLeft(), currentTime.getDate().padLeft(), currentTime.getFullYear()].join('/');
                    document.getElementById('<%= txtPublishDate.ClientID%>').value = dformat;
                }
            });
        }
        Number.prototype.padLeft = function (base, chr) {
            var len = (String(base || 10).length - String(this).length) + 1;
            return len > 0 ? new Array(len).join(chr || '0') + this : this;
        }

        function ValidatePublishDate() {
            if (document.getElementById('<%= rbPublic.ClientID%>').checked) {
                if (document.getElementById("<%=txtPublishDate.ClientID %>").value == "") {
                    document.getElementById("<%=txtPD.ClientID %>").value = "";
                }
                else {
                    document.getElementById("<%=txtPD.ClientID %>").value = "1";
                }
            }
            else {
                document.getElementById("<%=txtPublishDate.ClientID %>").value = "";
                document.getElementById("<%=txtPD.ClientID %>").value = "1";
            }
        }

        function ShowPublicPrivate(val, ischange) {
            document.getElementById("<%=rbPrivate.ClientID %>").checked = true;
            document.getElementById("<%=rbPublic.ClientID %>").checked = false;
        }
        window.onload = function () {
            if (document.getElementById('<%= hdnPermissionType.ClientID%>') != "" && document.getElementById('<%= hdnPermissionType.ClientID%>') != null)  //roles & permissions..
                DisplayComplete();
            if (document.getElementById('<%=rbPrivate.ClientID %>').checked) {
                document.getElementById('<%=BtnSave.ClientID %>').style.display = "block";
                document.getElementById('<%=BtnPublish.ClientID %>').style.display = "none";
            }
            else {
                document.getElementById('<%=BtnSave.ClientID %>').style.display = "none";
                document.getElementById('<%=BtnPublish.ClientID %>').style.display = "block";
            }

        }
        function DisplayComplete() {
            if (document.getElementById('<%= rbPublic.ClientID%>').checked) {
                document.getElementById('divpublish').style.display = "block";
                if ('<%= IsScheduleEmails %>' == 'True') {
                    document.getElementById('divSchedulePublish').style.display = "block";
                } else {

                    document.getElementById('divSchedulePublish').style.display = "none";
                }
            }
        }
        function ShowPublish(val, ischanges) {
            if (val == "1") {
                document.getElementById('divpublish').style.display = "none";
                document.getElementById('<%= txtPublishDate.ClientID%>').value = '';
                ShowPublishSave('1');
            } else if (val == "2") {
                if ('<%= IsScheduleEmails %>' == 'True') {
                    document.getElementById('divSchedulePublish').style.display = "block";
                } else {

                    document.getElementById('divSchedulePublish').style.display = "none";
                }
                if (ischanges == "true" && document.getElementById('<%= txtPublishDate.ClientID%>').value == "") {
                    document.getElementById('<%= txtPublishDate.ClientID%>').value = GetCurrentDate();
                    ShowPublishSave('2');
                }
            }
        }
        function ShowPublishSave(val) {
            if (val == "1") {
                document.getElementById('<%=BtnSave.ClientID %>').style.display = "block";
                document.getElementById('<%=BtnPublish.ClientID %>').style.display = "none";
            } else if (val == "2") {
                document.getElementById('<%=BtnSave.ClientID %>').style.display = "none";
                document.getElementById('<%=BtnPublish.ClientID %>').style.display = "block";
                document.getElementById('divpublish').style.display = "block";
                if ('<%= IsScheduleEmails %>' == 'True') {
                    document.getElementById('divSchedulePublish').style.display = "block";
                } else {

                    document.getElementById('divSchedulePublish').style.display = "none";
                }
            }
        }

        function ShowExTimeDiv() {
            var allddls = document.getElementsByTagName("select");
            for (k = 0; k < allddls.length; k++) {
                var controlName = allddls[k].id;
                if (controlName.indexOf("ddlTime") >= 0) {
                    break;
                }
            }
            if (document.getElementById("<%=txtExDate.ClientID %>").value == "" || document.getElementById("<%=txtExDate.ClientID %>").value == "MM/DD/YYYY") {
                document.getElementById(controlName).disabled = true;
            }
            else {
                document.getElementById(controlName).disabled = false;
              
            }
        }

    </script>
    <style>
        .lightText
        {
            color: #9B9B9B;
        }
        .textboxstyle
        {
            border: 2 solid black;
        }
        .modal
        {
            background-color: Gray;
            filter: alpha(opacity=90);
            opacity: 0.7;
        }
        #popup
        {
            background-color: Gray;
            filter: alpha(opacity=90);
            opacity: 0.7;
            width: 100%;
            height: 100%;
        }
        .textdivStyle
        {
            text-align: justify;
            border: 1px solid black;
            overflow: auto;
            font-family: Arial;
            font-size: 12px;
            width: 300px;
        }
        .imgdivStyle
        {
            text-align: justify;
            border: 1px solid black;
            overflow: auto;
            font-family: Arial;
            font-size: 12px;
        }
    </style>
    <style type="text/css">
        .radius
        {
            -moz-border-radius: 10px;
            -webkit-border-radius: 10px;
            border-radius: 10px;
        }
        .navy20
        {
            color: #2F348F;
            font-size: 15px;
            font-weight: bold;
            font-family: Arial;
            padding: 10px 0px 5px 0px;
        }
        .navy16
        {
            color: #2F348F;
            font-size: 14px;
            line-height: 22px;
            font-weight: bold;
            font-family: Arial;
        }
        .black16
        {
            color: #000;
            font-size: 14px;
            line-height: 22px;
            font-weight: bold;
            font-family: Arial;
        }
        .black16normal
        {
            color: #000;
            font-size: 14px;
            line-height: 22px;
            font-family: Arial;
        }
        .txtarea11
        {
            font-size: 14px;
            color: #000;
            border: #D3D3D3 2px solid;
            font-family: Arial;
            resize: none;
        }
        .border
        {
            border: 1px solid #04519D;
        }
        .cursor
        {
            cursor: hand;
        }
        #boxes .window
        {
            border: solid 2px #FFCC00;
            position: absolute;
            left: 0;
            top: 0;
            width: 490px;
            height: 200px;
            display: none;
            z-index: 9999;
        }
        
        #boxes #dialog
        {
            width: 500px;
            height: 369px;
            padding: 10px;
            background-color: #FFFFFF;
            margin-top: 12%;
            margin-left: 31%;
        }
        #watermark
        {
            color: #d0d0d0;
            font-size: 26px;
            width: 100%;
            height: 100%;
            text-align: center;
            vertical-align: middle;
            margin-top: 40px;
        }
    </style>
    <%--Application COntrol Style--%>
    <style>
        body, h1, h2, h3, h4, h5, h6
        {
            margin: 0px;
            padding: 0px;
            font-family: Arial, Helvetica, sans-serif;
            outline: 0px;
            border: 0px;
        }
        .clear
        {
            clear: both;
        }
        .clear10
        {
            clear: both;
            height: 10px;
        }
        #wrapper
        {
            width: 100%;
            margin: 0 auto;
            padding: 0px;
            border: 1px solid #fff;
        }
        .header
        {
            background: #eeeeee url(../images/BulletinThumbs/header_bg.gif) repeat-x;
            min-height: 74px;
            padding: 20px 0px;
        }
        .datawrap
        {
            margin: 0 auto;
            width: 500px;
            overflow: hidden;
        }
        .logo
        {
            float: left;
            margin: 0px 0px 0px 50px;
        }
        .txtwrap
        {
            float: left;
            margin: 0px 0px 0px 30px;
        }
        h1
        {
            font-size: 28px;
            line-height: 25px;
            font-weight: bold;
            color: #fcb040;
            text-align: center;
        }
        h2
        {
            font-size: 18px;
            line-height: 28px;
            font-weight: normal;
            color: #6e7723;
            text-align: center;
        }
        h4
        {
            font-size: 16px;
            line-height: 28px;
            font-weight: bold;
            color: #383838;
            text-align: center;
        }
        .contentwrap
        {
            background: #fffdfb;
            overflow: hidden;
            padding: 15px 10px 40px 10px;
        }
        
        .largetxt
        {
            font-size: 26px;
            line-height: 28px;
            font-weight: normal;
            color: #f15b29;
            text-align: center;
            padding: 0px 0px 10px 0px;
            border-bottom: 1px dashed #d1d1d1;
        }
        .browseimg_wrap
        {
            margin: 0px auto;
            width: 500px;
            overflow: hidden;
            padding: 20px 0px 20px 70px;
        }
        .avatar
        {
            margin: 0px 20px 0px 0px;
            float: left;
            border: 1px solid #dddddd;
            padding: 0px;
        }
        .browse_btn
        {
            float: left;
            outline: 0px;
            margin: 10px 0px 0px 0px;
        }
        
        label
        {
            color: #313131;
            font-size: 14px;
            text-align: left;
        }
        .label1
        {
            color: #313131;
            font-size: 15px;
            text-align: left;
        }
        .txtfildwrap
        {
            border: 1px solid #cccccc;
            height: 30px;
            width: 330px;
            margin: 5px 0px 30px 0px;
        }
        .txtfildwrap img
        {
            float: right;
        }
        .txtfild
        {
            color: #555555;
            width: 208px;
            float: left;
            border: none;
            outline: none;
            padding: 4px 0px 0px 4px;
        }
        input[type="checkbox"]
        {
            display: inline;
        }
        .signin_btn
        {
            float: right;
            width: 92px;
            height: 35px;
            margin: 0px 47px 0px 0px;
        }
        .remember_txt
        {
            float: left;
            color: #848484;
            font-size: 12px;
            text-align: left;
        }
        /*Form Styles*/
        
        .form_wrapper
        {
            overflow: hidden;
            width: 752px;
            float: left;
        }
        .fields_wrap
        {
            width: 100%;
            margin: 0px 0px;
        }
        .left_lable
        {
            float: left;
            text-align: left;
            width: 160px;
            padding: 3px 0px 0px 0px;
            margin: 2px 20px 0px 100px;
        }
        .right_fields
        {
            color: #353535;
            float: left;
            padding: 3px 0px 0px 0px;
            font-size: 12px;
            margin: 2px 0px;
            width: 400px;
        }
        /*.right_buttons
{
    color: #353535;
    float: right;
    padding: 3px 0px 0px 0px;
    font-size: 12px;
    margin: -135px 0px;
    width: 200px;
    height:100px;
}*/
        .txtfild1
        {
            color: #555555;
            height: 24px;
            width: 248px;
            background: #fff;
            border: 1px solid #d7d7d7;
            outline: none;
            color: #313131;
            font-size: 13px;
            text-align: left;
            padding: 4px 0px 0px 4px;
        }
        .txtfild2
        {
            color: #555555;
            height: 24px;
            width: 73px;
            float: left;
            color: #313131;
            font-size: 13px;
            text-align: left;
            background: #fff;
            border: 1px solid #d7d7d7;
            outline: none;
            padding: 4px 0px 0px 4px;
        }
        textarea
        {
            min-height: 60px;
            color: #9a9a9a;
            font-size: 13px;
            text-align: left;
            width: 252px;
            border: 1px solid #d7d7d7;
            resize: none;
            clear: both;
            background: #fff;
            font-family: Arial, Helvetica, sans-serif;
            outline: none;
            padding: 4px 0px 0px 0px;
            margin: 0px 0px 4px 0px;
        }
        select
        {
            color: #555555;
            height: 24px;
            width: 82px;
            color: #313131;
            font-size: 13px;
            text-align: left;
            border: 1px solid #c9c9c9;
            outline: none;
            margin: 0px 4px 0px 0px;
            background: #fff;
        }
        .select1
        {
            color: #555555;
            height: 28px;
            width: 170px;
            float: left;
            border: 1px solid #c9c9c9;
            outline: none;
            margin: 0px 4px 0px 0px;
            background: #fff;
            padding: 3px;
        }
        
        .row3
        {
            background: #fffcf9;
            margin: 2px 0px;
            overflow: hidden;
            min-height: 30px;
            padding: 10px 0px 10px 0px;
        }
        .row4
        {
            background: #f8f8f8;
            overflow: hidden;
            margin: 2px 0px;
            min-height: 30px;
            padding: 10px 0px 10px 0px;
        }
        .btn
        {
            background: url(../../images/BulletinThumbs/button_bg.gif) repeat-x;
            height: 37px;
            float: left;
            border: 1px solid #dcdcdc;
            margin: 0px 6px 0px 0px;
            cursor: hand;
            cursor: pointer;
            padding: 0px 20px;
            font-size: 16px; /*color: #464646;*/
            -moz-border-radius: 4px;
            -webkit-border-radius: 4px;
            border-radius: 4px; /* future proofing */
            -khtml-border-radius: 4px; /* for old Konqueror browsers */
            text-shadow: 1px 1px 1px #f2f2f2;
        }
        #preview
        {
            left: 43%;
            margin: 0 auto;
            position: absolute;
            z-index: 999;
            top: 200px;
            background-color: #E9E9E9;
        }
        .closebtn
        {
            margin: 0;
            padding: 0;
            position: absolute;
            right: -7px;
            top: -10px;
        }
        .black_overlay
        {
            display: none;
            position: absolute;
            top: 0%;
            left: 0%;
            width: 100%;
            height: 1540px;
            background-color: black;
            z-index: 800;
            opacity: 0.7;
            -ms-filter: "progid:DXImageTransform.Microsoft.Alpha(Opacity=70)";
            filter: alpha(opacity=70);
        }
        /* *** Adding style for file upload *** */
        .file-upload
        {
            overflow: hidden;
            display: inline-block;
            position: relative;
            vertical-align: middle;
            text-align: center; /* Cosmetics */
            border: 1px solid #cfcfcf;
            background: #e2e2e2; /* Nice if your browser can do it */
            -moz-border-radius: 5px;
            -webkit-border-radius: 5px;
            border-radius: 5px;
            cursor: pointer;
        }
        
        .file-upload:hover
        {
            background: #e9e9e9;
        }
        
        .file-upload.focus
        {
            outline: 1px solid yellow;
        }
        
        .file-upload input
        {
            position: absolute;
            top: 0;
            left: 0;
            margin: 0;
            font-size: 10pt; /* Loses tab index in webkit if width is set to 0 */
            opacity: 0;
            filter: alpha(opacity=0);
        }
        
        .file-upload strong
        {
            padding-top: 5px;
            font-size: 9pt;
            font-weight: normal;
        }
        
        .file-upload span
        {
            position: absolute;
            top: 0;
            left: 0;
            z-index: 100;
            display: inline-block; /* Adjust button text vertical alignment */
            padding-top: 5px;
        }
        
        /* Adjust the button size */
        .file-upload
        {
            height: 22px;
        }
        .file-upload, .file-upload span
        {
            width: 75px;
        }
        .headernav
        {
            color: #2F348F;
            font-family: Arial;
            font-size: 16px;
            font-weight: bold;
        }
        .highlightLabel
        {
            color: red;
        }
        .watermarkbulletindate
        {
            color: Gray;
        }
        .headerdropdown
        {
            padding-left: 75px;
            color: #555555;
            height: 28px;
            width: 170px;
            float: left;
            border: 1px solid #c9c9c9;
            outline: none;
            margin: 0px 4px 0px 0px;
            background: #fff;
        }
    </style>
    <div id="popup" class="popup" style="width: 100%; display: none;">
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="wrapper">
                <div class="headernav">
                    <asp:Label ID="lblBulletinName" runat="server"></asp:Label>
                    <asp:TextBox ID="txt" runat="server" Width="0" BorderStyle="none" BorderColor="white"
                        Style="border: 0; border-color: White!important;"></asp:TextBox>
                </div>
                <div style="text-align: center;">
                    <asp:Label ID="lblerror" runat="server"></asp:Label>
                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="3">
                        <ProgressTemplate>
                            <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green"
                                size="2">Processing....</font></b>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    <div id="divLoading" style="display: none; width: 300px; margin: 0 auto;">
                        <div style="text-align: center;">
                            <img src="<%=Page.ResolveClientUrl("../../images/popup_ajax-loader.gif")%>" border="0" /><b><font
                                color="green">Processing....</font></b>
                        </div>
                    </div>
                    <div style="width: 300px; margin: 0 auto;">
                        <asp:ValidationSummary ID="ValidateUserDetails" runat="server" Style="text-align: left;"
                            ValidationGroup="ABC" HeaderText="The following error(s) occurred:" />
                        <asp:Label ID="lblmess" runat="server" Font-Size="Medium" ForeColor="Green"></asp:Label>
                    </div>
                </div>
                <div>
                    <div style="margin: 0 auto; width: 100%; overflow: hidden;">
                        <asp:Label runat="server" ID="lblLogoHeader"></asp:Label>
                    </div>
                </div>
                <div class="clear">
                </div>
                <div class="contentwrap">
                    <div class="largetxt">
                        Crisis Call Log</div>
                    <div class="form_wrapper" style="float: none; width: auto;">
                        <div class="clear10">
                        </div>
                        <div class="fields_wrap">
                            <label style="color: Red; font-size: 16px; margin-left: 200px;">
                                * Marked fields are mandatory.</label>
                        </div>
                        <div class="clear10">
                        </div>
                        <div class="steps">
                        </div>
                        <div class="stepswrapmain">
                            <div class="clear10">
                            </div>
                            <div class="steps">
                            </div>
                            <div class="fields_wrap">
                                <div class="left_lable">
                                    <span style="color: Red;">*&nbsp;</span>Report Title:
                                </div>
                                <div class='right_fields'>
                                    <asp:TextBox ID="txtbulletinName" runat="server" Width="180px" Height='19'></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtbulletinName"
                                        ValidationGroup="ABC" ForeColor="Red" ErrorMessage="Sign In Name is mandatory.">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="fields_wrap">
                                <div class="left_lable">
                                    <span style="color: Red;">*&nbsp;</span>DVRT Associate ID:
                                </div>
                                <div class='right_fields'>
                                    <asp:DropDownList ID="ddlAssociates1" runat="server" Width="130px">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="fields_wrap">
                                <div class="left_lable">
                                    <span style="color: Red;">*&nbsp;</span>Log In Time:
                                </div>
                                <div class='right_fields'>
                                    <asp:DropDownList runat="server" ID="ddlloginhour" Width="100px">
                                        <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                        <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                        <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                        <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                        <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                        <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                        <asp:ListItem Text="12" Value="12" Selected="True"></asp:ListItem>
                                    </asp:DropDownList>
                                    <span>Hours</span>&nbsp;&nbsp;
                                    <asp:TextBox runat="server" ID="txtloginMins" Text="00" Width="50px" MaxLength="2"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtloginMins"
                                        ValidationGroup="ABC" ForeColor="Red" ErrorMessage="Log In Time is mandatory.">*</asp:RequiredFieldValidator>
                                    <span>Minutes</span>&nbsp;&nbsp;
                                    <asp:DropDownList runat="server" Width="50px" ID="ddlloginsection">
                                        <asp:ListItem Text="AM" Value="AM" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="fields_wrap">
                                <div class="left_lable">
                                    <span style="color: Red;">*&nbsp;</span>Date of Log:
                                </div>
                                <div class='right_fields'>
                                    <asp:TextBox ID="txtlogindate" runat="server" Width="200px" Height="19"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtlogindate"
                                        ValidationGroup="ABC" ForeColor="Red" ErrorMessage="Date of Log is mandatory.">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtlogindate"
                                        ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                        ValidationGroup="ABC" ErrorMessage="Invalid Log In Date Format">*</asp:RegularExpressionValidator><br />
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtlogindate"
                                        Format="MM/dd/yyyy" CssClass="MyCalendar" />
                                </div>
                            </div>
                            <div class="fields_wrap">
                                <div class="left_lable">
                                    <div class="avatar" style="margin-left: 20px; border-width: 1px; min-height: 100px;
                                        width: 450px; max-height: 600px; overflow: auto;">
                                        <asp:Label ID="lblBulletinedit" runat="server" Text="<div id='watermark'>Your block goes here!!!</div>"></asp:Label>
                                        <%--  <table id='maintable' cellpadding="5" width="99%" cellspacing="0" style="border: 0px solid black;">
                                        </table>--%>
                                    </div>
                                </div>
                            </div>
                            <div style="float: left; margin: 5px 0px 0px 300px;">
                                <img style="cursor: pointer;" onclick="AddCallPanel();" src="../../Images/addcall.png" />
                            </div>
                            <div class="clear10">
                            </div>
                            <div class="steps">
                            </div>
                            <div class="fields_wrap">
                                <div class="left_lable">
                                    <span style="color: Red;">*&nbsp;</span>Log Out Date:
                                </div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtlogoutDate" runat="server" Width="200px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtlogoutDate"
                                        ValidationGroup="ABC" ForeColor="Red" ErrorMessage="Log Out Date is mandatory.">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtlogoutDate"
                                        ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                        ValidationGroup="ABC" ErrorMessage="Invalid Log Out Date Format">*</asp:RegularExpressionValidator><br />
                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtlogoutDate"
                                        Format="MM/dd/yyyy" CssClass="MyCalendar" />
                                </div>
                            </div>
                            <div class="fields_wrap">
                                <div class="left_lable">
                                    <span style="color: Red;">*&nbsp;</span>Log Out Time:
                                </div>
                                <div class="right_fields">
                                    <asp:DropDownList runat="server" ID="ddllogouthour" Width="70px">
                                        <asp:ListItem Text="1" Value="01"></asp:ListItem>
                                        <asp:ListItem Text="2" Value="02"></asp:ListItem>
                                        <asp:ListItem Text="3" Value="03"></asp:ListItem>
                                        <asp:ListItem Text="4" Value="04"></asp:ListItem>
                                        <asp:ListItem Text="5" Value="05"></asp:ListItem>
                                        <asp:ListItem Text="6" Value="06"></asp:ListItem>
                                        <asp:ListItem Text="7" Value="07"></asp:ListItem>
                                        <asp:ListItem Text="8" Value="08"></asp:ListItem>
                                        <asp:ListItem Text="9" Value="09"></asp:ListItem>
                                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                        <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                        <asp:ListItem Text="12" Value="12" Selected="True"></asp:ListItem>
                                    </asp:DropDownList>
                                    <span>Hours</span>&nbsp;&nbsp;
                                    <asp:TextBox runat="server" ID="txtlogoutmin" Width="70px" Text="00" MaxLength="2"></asp:TextBox>
                                    <span style='margin: 0;'>Minutes</span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtlogoutmin"
                                        ValidationGroup="ABC" ForeColor="Red" ErrorMessage="Log Out Time is mandatory.">*</asp:RequiredFieldValidator>
                                    &nbsp;&nbsp;
                                    <asp:DropDownList runat="server" Width="50px" ID="ddllogoutsection">
                                        <asp:ListItem Text="AM" Value="AM" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="fields_wrap">
                                <div class="left_lable">
                                    <span style="color: Red;">*&nbsp;</span>Transferred To:
                                </div>
                                <div class="right_fields">
                                    <asp:DropDownList ID="ddlAssociates2" runat="server" Width="163px">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="fields_wrap">
                                <div class="left_lable">
                                    <span style="color: Red;">&nbsp;&nbsp;</span> Expiration Date & Time:
                                </div>
                                <div class="right_fields">
                                    <div style="margin: 0px 0px 0px 0px;">
                                        <table width="80%" cellpadding="0" cellspacing="0" id='tblExTime'>
                                        <colgroup>
                                            <col width="120px" />
                                            <col width="*" />
                                        </colgroup>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtExDate" runat="server" Width="100px" Height="18px" onChange="ShowExTimeDiv();"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularDate" runat="server" ControlToValidate="txtExDate"
                                                        ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                                        ValidationGroup="ABC" ErrorMessage="Invalid Date Format">*</asp:RegularExpressionValidator><br />
                                                    <cc1:CalendarExtender ID="calex" runat="server" TargetControlID="txtExDate" Format="MM/dd/yyyy"
                                                        CssClass="MyCalendar" />
                                                </td>
                                                <td>
                                                     <TimerUC:TimeControl ID="ExpiryTimeControl1" runat="server" Enabled="false" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </div>
                            <div class="fields_wrap">
                                <div class="left_lable">
                                    <label>
                                    </label>
                                </div>
                                <div class="right_fields">
                                    <div style="margin: 0px 0px 0px 0px;">
                                        <div id="public" style="margin: 10px 0px 0px 15px;">
                                            <asp:RadioButton ID="rbPrivate" runat="server" GroupName="Public" Checked="true"
                                                onclick="javascript:ShowPublish('1','true')" />
                                            <label>
                                                Private</label>
                                            <asp:Label ID="lblCompleted" runat="server"></asp:Label>
                                            <asp:RadioButton ID="rbPublic" runat="server" GroupName="Public" onclick="javascript:ShowPublish('2','true')" />
                                            <asp:Label ID="lblworkprogress" runat="server"></asp:Label>
                                            <asp:Label ID="lblPublish" runat="server" Text="Publish" CssClass="approval"></asp:Label>
                                            <div style="margin: 10px 10px 0px 80px; display: none;" id="divpublish">
                                                <div id="divSchedulePublish" style="display: block;">
                                                    <label style="font-size: 14px;">
                                                    </label>
                                                    <asp:TextBox ReadOnly="true" ID="txtPublishDate" runat="server" Width="75"></asp:TextBox><asp:TextBox
                                                        ID="txtPD" runat="server" Width="0" Height="0" BorderStyle="None" Style="display: none;"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="clear">
                            </div>
                            <div class="steps">
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;&nbsp;</span> Category:
                                </div>
                                <div class="right_fields">
                                    <asp:DropDownList ID="ddlCategories" runat="server" Width="200px">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="clear10">
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                </div>
                                <div class="right_fields" style="margin: 10px 0px 0px 0px;">
                                    <asp:Button ID="BtnCancel" runat="server" Text="Cancel" border="0" CssClass="btn"
                                        OnClick="BtnCancel_Click" />
                                    <asp:Button ID="BtnSave" runat="server" Text="Save" ValidationGroup="ABC" OnClientClick="return SaveHTMLData()"
                                        border="0" CssClass="btn" OnClick="BtnSave_Click" />
                                    <asp:Button ID="BtnPublish" runat="server" Text="Submit" ValidationGroup="ABC" OnClientClick="return SaveHTMLData()"
                                        border="0" CssClass="btn" OnClick="BtnPublish_Click" />
                                    <asp:LinkButton ID="lnkPreview" runat="server" OnClientClick="return PreviewHTML('1');">
                                        <img src="../../images/BulletinThumbs/preview.png" width="100" height="37"></asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <input type="hidden" id='ids' value='' />
            <input type="hidden" value="2" id="DivIds" />
            <asp:HiddenField runat="server" ID="hdnEditHTML" />
            <asp:HiddenField runat="server" ID="hdnPreviewHTML" />
            <asp:HiddenField runat="server" ID="hdnEditXML" />
            <asp:HiddenField runat="server" ID="hdnExDate" />
            <asp:HiddenField runat="server" ID="hdnPrivate" />
            <asp:HiddenField runat="server" ID="hdnCompleted" />
            <asp:HiddenField runat="server" ID="hdnBulletinHeader" />
            <asp:HiddenField ID="hdnPublishTitle" runat="server" Value="Publish" />
            <asp:HiddenField ID="hdnPermissionType" runat="server" />
            <asp:HiddenField ID="hdnCrisisCallLogHTML" runat="server" />
            <div id='dummyDIV' style="display: none;">
                <asp:Label runat="server" ID='lbldummy'></asp:Label>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:Label ID="lblBulletinPreview" runat="server"></asp:Label>
            <cc1:ModalPopupExtender ID="popupBulletinpreview" runat="server" TargetControlID="lblBulletinPreview"
                PopupControlID="pnlpreviewBulletin" BackgroundCssClass="modal" CancelControlID="imgclosepreviewpopup"
                BehaviorID="BulletinPreview">
            </cc1:ModalPopupExtender>
            <asp:Panel ID="pnlpreviewBulletin" runat="server" Style="display: none" Width="600px">
                <table cellpadding="0" cellspacing="0" width="100%" style="border: 1px solid #EEECEC;
                    background-color: #F8F6F6;">
                    <tbody>
                        <tr>
                            <td style="padding-right: 120px;" align="right">
                                <asp:UpdateProgress ID="UpdateProgress2" runat="server" DisplayAfter="3">
                                    <ProgressTemplate>
                                        <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </td>
                            <td align="right" style="padding: 5px 10px 20px 10px;">
                                <asp:ImageButton ID="imgclosepreviewpopup" runat="server" ImageUrl="~/images/popup_close.gif" />
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold; font-size: 14px; padding-bottom: 10px; color: green;
                                padding-top: 10px" align="left" colspan="2">
                                <asp:Label ID="lblbulletinamme" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100%; padding: 10px;" colspan="2">
                                <div style="overflow-y: auto; min-height: 300px; max-height: 600px; position: relative;">
                                    <asp:Label ID="lblpreview" runat="server"></asp:Label></div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </asp:Panel>
            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                <tbody>
                    <tr>
                        <td>
                            <asp:Label ID="lblProgress" runat="server" visiable="false"></asp:Label>
                            <cc1:ModalPopupExtender ID="MPEProgress" runat="server" TargetControlID="lblProgress"
                                PopupControlID="pnlProgress" BackgroundCssClass="modal">
                            </cc1:ModalPopupExtender>
                            <asp:Panel Style="display: none;" ID="pnlProgress" runat="server" Width="500px">
                                <table class="modalpopup" cellspacing="0" cellpadding="0" width="100%" align="center"
                                    border="0">
                                    <tr>
                                        <td align="center">
                                            <asp:UpdateProgress ID="UpdateProgress8" runat="server" DisplayAfter="3">
                                                <ProgressTemplate>
                                                    <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green"> Your
                                                        request is in progress, please don't refresh or close window. </font></b>
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </tbody>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel4" runat="server" Visible="false">
        <ContentTemplate>
            <div style="color: red;" align="center">
                <asp:Label ID="lblerrormessage" runat="server"></asp:Label></div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
