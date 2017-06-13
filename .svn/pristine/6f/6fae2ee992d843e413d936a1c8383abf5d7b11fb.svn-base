var urls = new Array();
function rssMikleUpdatePreview() {

    var snippet = '';
    var preview = rssMikleValidateValues(this);

    if (!preview) {
        snippet = rssMikleGetSnippet();
        preview = rssMikleGetPreview();
    }
    $("rssMiklePreview").show();
    $("rssmikle_snippet").value = snippet;
    $("rssmikle_preview").innerHTML = preview;
}

function rssMikleSelectDefault(obj, inputType, defaultNum) {
    var selected = 0;
    if (inputType == 'select') {
        for (var i = 0; i < obj.options.length; i++) {
            if (obj.options[i].selected == 'true') {
                flag = 1;
                break;
            }
        }
        if (!selected) {
            obj.options[defaultNum].selected = true;
        }
    } else if (inputType == 'radio') {
        for (var i = 0; i < obj.length; i++) {
            if (obj[i].checked) {
                flag = 1;
                break;
            }
        }
        if (!selected) {
            obj[defaultNum].checked = true;
        }
    }
}

function rssMikleInit() {
    /// set default value ///
    $("lblMailSuccessMsg").value = '';
    $("rssmikle_frame_width").value = $("rssmikle_frame_width").value ? $("rssmikle_frame_width").value : 180;
    $("rssmikle_frame_height").value = $("rssmikle_frame_height").value ? $("rssmikle_frame_height").value : 500;
    $("rssmikle_font").value = $("rssmikle_font").value ? $("rssmikle_font").value : '';
    $("rssmikle_font_size").value = $("rssmikle_font_size").value ? $("rssmikle_font_size").value : 12;
    $("rssmikle_title_bgcolor").value = $("rssmikle_title_bgcolor").value ? $("rssmikle_title_bgcolor").value : '0066FF';
    $("rssmikle_title_color").value = $("rssmikle_title_color").value ? $("rssmikle_title_color").value : 'FFFFFF';
    $("rssmikle_item_bgcolor").value = $("rssmikle_item_bgcolor").value ? $("rssmikle_item_bgcolor").value : 'FFFFFF';
    $("rssmikle_item_title_color").value = $("rssmikle_item_title_color").value ? $("rssmikle_item_title_color").value : '666666';
    $("rssmikle_item_description_color").value = $("rssmikle_item_description_color").value ? $("rssmikle_item_description_color").value : '666666';

    // onChange	
    Event.observe("rssmikle_feedtype", "change", rssMikleUpdatePreview, false);
    Event.observe("rssmikle_frame_width", "change", rssMikleUpdatePreview, false);
    Event.observe("rssmikle_frame_height", "change", rssMikleUpdatePreview, false);
    Event.observe("rssmikle_font", "change", rssMikleUpdatePreview, false);
    Event.observe("rssmikle_font_size", "change", rssMikleUpdatePreview, false);
    Event.observe("rssmikle_title_bgcolor", "change", rssMikleUpdatePreview, false);
    Event.observe("rssmikle_title_color", "change", rssMikleUpdatePreview, false);
    Event.observe("rssmikle_item_bgcolor", "change", rssMikleUpdatePreview, false);
    Event.observe("rssmikle_item_title_color", "change", rssMikleUpdatePreview, false);
    Event.observe("rssmikle_item_description_color", "change", rssMikleUpdatePreview, false);
    Event.observe("rssmikle_snippet", "click", function () {
        Field.focus("rssmikle_snippet");
        Field.activate("rssmikle_snippet");
    }, false);

    obj = document.getElementsByName("rssmikle_target");
    for (var i = 0; i < obj.length; i++) {
        Event.observe(obj[i], "click", rssMikleUpdatePreview, false);
    }

    obj = document.getElementsByName("corner");
    for (var i = 0; i < obj.length; i++) {
        Event.observe(obj[i], "click", rssMikleUpdatePreview, false);
    }

    obj = document.getElementsByName("rssmikle_item_border_bottom");
    for (var i = 0; i < obj.length; i++) {
        Event.observe(obj[i], "click", rssMikleUpdatePreview, false);
    }


    obj = document.getElementsByTagName('label');
    for (var i = 0; i < obj.length; i++) {
        var imgObj = obj[i].getElementsByTagName('img');
        for (var j = 0; j < imgObj.length; j++) {
            imgObj[j].formCtrlId = obj[i].htmlFor;
            imgObj[j].onclick = function () { $(this.formCtrlId).click() };
        }
    }
}

function rssMikleValidateValues(evntObj) {
    // rssmikle_frame_width
    $("rssmikle_frame_width").value = $("rssmikle_frame_width").value.replace(/^0+/, '');
    if ($("rssmikle_frame_width").value < 100) {
        return '<font color="red">Please set the width more than 100px.</font>';
    } else if ($("rssmikle_frame_width").value > 900) {
        return '<font color="red">Please set the width less than or equal to 900px.</font>';
    } else if (!$("rssmikle_frame_width").value.match(/^[0-9]*$/g)) {
        return '<font color="red">Please input the integer to the width of the frame.</font>';
    }

    // rssmikle_frame_height
    $("rssmikle_frame_height").value = $("rssmikle_frame_height").value.replace(/^0+/, '');
    if ($("rssmikle_frame_height").value < 100) {
        return '<font color="red">Please set the height more than 100px.</font>';
    } else if (!$("rssmikle_frame_height").value.match(/^[0-9]*$/g)) {
        return '<font color="red">Please input the integer to the height of the frame.</font>';
    }

    // rssmikle_font_size
    $("rssmikle_font_size").value = $("rssmikle_font_size").value.replace(/^0+/, '');
    if ($("rssmikle_font_size").value && !$("rssmikle_font_size").value.match(/^[0-9]*$/g)) {
        return '<font color="red">Please input the integer to the font size.</font>';
    }

    if ($("rssmikle_font").value == '') {
        return '<font color="red">Please select a font family.</font>';
    }
    // rssmikle_title

    // rssmikle_title_bgcolor
    if ($("rssmikle_title_bgcolor").value && !$("rssmikle_title_bgcolor").value.match(/^[0-9a-fA-F]{6}$/g)) {
        return '<font color="red">Please specify the background color of the feed title by the hexadecimal number.</font>';
    } else if ($("rssmikle_title_bgcolor").value) {
        $("rssmikle_title_bgcolor_colorbox").style.backgroundColor = '#' + $("rssmikle_title_bgcolor").value;
    }

    // rssmikle_title_color
    if ($("rssmikle_title_color").value && !$("rssmikle_title_color").value.match(/^[0-9a-fA-F]{6}$/g)) {
        return '<font color="red">Please specify the font color of the feed title by the hexadecimal number.</font>';
    } else if ($("rssmikle_title_color").value) {
        $("rssmikle_title_color_colorbox").style.backgroundColor = '#' + $("rssmikle_title_color").value;
    }

    // rssmikle_item_bgcolor
    if ($("rssmikle_item_bgcolor").value && !$("rssmikle_item_bgcolor").value.match(/^[0-9a-fA-F]{6}$/g)) {
        return '<font color="red">Please specify the background color of the entry title by the hexadecimal number.</font>';
    } else if ($("rssmikle_item_bgcolor").value) {
        $("rssmikle_item_bgcolor_colorbox").style.backgroundColor = '#' + $("rssmikle_item_bgcolor").value;
    }

    // rssmikle_item_title_color
    if ($("rssmikle_item_title_color").value && !$("rssmikle_item_title_color").value.match(/^[0-9a-fA-F]{6}$/g)) {
        return '<font color="red">Please specify the font color of the entry title by the hexadecimal number.</font>';
    } else if ($("rssmikle_item_title_color").value) {
        $("rssmikle_item_title_color_colorbox").style.backgroundColor = '#' + $("rssmikle_item_title_color").value;
    }

    // rssmikle_item_description_color
    if ($("rssmikle_item_description_color").value && !$("rssmikle_item_description_color").value.match(/^[0-9a-fA-F]{6}$/g)) {
        return '<font color="red">Please specify the font color of the entry contents by the hexadecimal number.</font>';
    } else if ($("rssmikle_item_description_color").value) {
        $("rssmikle_item_description_color_colorbox").style.backgroundColor = '#' + $("rssmikle_item_description_color").value;
    }
    /// Disable ///
    $("rssmikle_feedtype").disabled = false;
    $("rssmikle_frame_width").disabled = false;
    $("rssmikle_frame_height").disabled = false;
    $("rssmikle_font").disabled = false;
    $("rssmikle_font_size").disabled = false;
    $("rssmikle_title_bgcolor").disabled = false;
    $("rssmikle_title_color").disabled = false;
    $("rssmikle_item_bgcolor").disabled = false;
    $("rssmikle_item_title_color").disabled = false;
    $("rssmikle_item_description_color").disabled = false;
    $("rssmikle_item_border_bottom1").disabled = false;
    $("rssmikle_item_border_bottom2").disabled = false;

    /*REMOVE DISABLE CLASS*/
    $("rssmikle_feedtype").parentNode.className = $("rssmikle_feedtype").parentNode.className.replace(/\bdeactive\b/, '');
    $("rssmikle_font").parentNode.className = $("rssmikle_font").parentNode.className.replace(/\bdeactive\b/, '');
    $("rssmikle_font_size").parentNode.className = $("rssmikle_font_size").parentNode.className.replace(/\bdeactive\b/, '');
    $("rssmikle_title_bgcolor").parentNode.className = $("rssmikle_title_bgcolor").parentNode.className.replace(/\bdeactive\b/, '');
    $("rssmikle_title_color").parentNode.className = $("rssmikle_title_color").parentNode.className.replace(/\bdeactive\b/, '');
    $("rssmikle_item_bgcolor").parentNode.className = $("rssmikle_item_bgcolor").parentNode.className.replace(/\bdeactive\b/, '');
    $("rssmikle_item_title_color").parentNode.className = $("rssmikle_item_title_color").parentNode.className.replace(/\bdeactive\b/, '');
    $("rssmikle_item_border_bottom1").parentNode.className = $("rssmikle_item_border_bottom1").parentNode.className.replace(/\bdeactive\b/, '');
    $("rssmikle_item_border_bottom2").parentNode.className = $("rssmikle_item_border_bottom2").parentNode.className.replace(/\bdeactive\b/, '');
    $("rssmikle_item_description_color").parentNode.className = $("rssmikle_item_description_color").parentNode.className.replace(/\bdeactive\b/, '');


    return "";
}

function rssMikleSwitchColor() {
    $("rssmikle_title_bgcolor").value = rssMikleGetRadioValue("rssmikle_title_bgcolors");
    $("rssmikle_title_bgcolor").style.background = "#" + rssMikleGetRadioValue("rssmikle_title_bgcolors");
    rssMikleUpdatePreview();
}

function GetDatetimeFormat() {
    var format = rssMikleGetRadioValue("date_format") + rssMikleGetRadioValue("time_format");
    return format;
}

function rssMikleGetURLs() {
    var urls_string = $("rssmikle_url").value ? $("rssmikle_url").value : "";
    if (urls_string == 'http://') {
        urls_string = "";
    }
    for (var i = 0; i < urls.length; i++) {
        if (urls_string) {
            urls_string = urls_string + '|' + urls[i]['url'];
        } else {
            urls_string = urls_string + urls[i]['url'];
        }
    }
    return urls_string;
}

function rssMikleGetRadioValue(radioName) {
    var obj = document.getElementsByName(radioName);
    var value = '';

    for (var i = 0; i < obj.length; i++) {
        if (obj[i].checked) {
            value = obj[i].value;
            break;
        }
    }

    return value;
}

function rssMikleGetSnippet() {   
    var snippet = '<!-- start widget code -->'
		+ '<script type="text/javascript">'
                + 'document.write(\'<script type="text/javascript" src="\' + (\'https:\' == document.location.protocol ? \'https://\' : \'http://\') + \'' + $("ctl00_cphUser_rssmikle_path").value + '/Scripts/rssfeeds.js"><\\/script>\');'
                + '</script>'
		+ '<script type="text/javascript">'
		+ '(function() {'
                + 'var params = {'
        + 'rssmikle_id: "' + $("ctl00_cphUser_rssmikle_id").value + '",'
        + 'rssmikle_feedtype: "' + $("rssmikle_feedtype").value + '",'
		+ 'rssmikle_frame_width: "' + $("rssmikle_frame_width").value + '",'
		+ 'rssmikle_frame_height: "' + $("rssmikle_frame_height").value + '",'
        + 'rssmikle_target: "' + rssMikleGetRadioValue("rssmikle_target") + '",'
		+ 'rssmikle_font: "' + $("rssmikle_font").value + '",'
		+ 'rssmikle_font_size: "' + $("rssmikle_font_size").value + '",'
        + 'corner: "' + rssMikleGetRadioValue("corner") + '",'
        + 'rssmikle_title_bgcolor: "' + ($("rssmikle_title_bgcolor").value ? '#' + $("rssmikle_title_bgcolor").value : '') + '",'
		+ 'rssmikle_title_color: "' + ($("rssmikle_title_color").value ? '#' + $("rssmikle_title_color").value : '') + '",'
        + 'rssmikle_item_bgcolor: "' + ($("rssmikle_item_bgcolor").value ? '#' + $("rssmikle_item_bgcolor").value : '') + '",'
        + 'rssmikle_item_title_color: "' + ($("rssmikle_item_title_color").value ? '#' + $("rssmikle_item_title_color").value : '') + '",'
        + 'rssmikle_item_description_color: "' + ($("rssmikle_item_description_color").value ? '#' + $("rssmikle_item_description_color").value : '') + '",'
        + 'rssmikle_item_border_bottom: "' + rssMikleGetRadioValue("rssmikle_item_border_bottom") + '"'
                + '};'
                + 'feedwind_show_widget_iframe(params);'
                + '})();'
		+ '</script>'
		+ '<!-- end widget code -->';
    return snippet;
}

function rssMikleGetPreview() {
    var params = {
        rssmikle_id: $("ctl00_cphUser_rssmikle_id").value,
        rssmikle_feedtype: $("rssmikle_feedtype").value,
        rssmikle_frame_width: $("rssmikle_frame_width").value,
        rssmikle_frame_height: $("rssmikle_frame_height").value,
        rssmikle_target: rssMikleGetRadioValue("rssmikle_target"),
        rssmikle_font: $("rssmikle_font").value,
        rssmikle_font_size: $("rssmikle_font_size").value,
        corner: rssMikleGetRadioValue("corner"),
        rssmikle_title_bgcolor: ($("rssmikle_title_bgcolor").value ? '#' + $("rssmikle_title_bgcolor").value : ''),
        rssmikle_title_color: ($("rssmikle_title_color").value ? '#' + $("rssmikle_title_color").value : ''),
        rssmikle_item_bgcolor: ($("rssmikle_item_bgcolor").value ? '#' + $("rssmikle_item_bgcolor").value : ''),
        rssmikle_item_title_color: ($("rssmikle_item_title_color").value ? '#' + $("rssmikle_item_title_color").value : ''),
        rssmikle_item_border_bottom: rssMikleGetRadioValue("rssmikle_item_border_bottom"),        
        rssmikle_item_description_color: ($("rssmikle_item_description_color").value ? '#' + $("rssmikle_item_description_color").value : '')
    }
   
    // "feedwind_show_widget_iframe" is defined in "/js/rssmikle.js".
    var iframe = feedwind_show_widget_iframe(params, 'html');
   
    return iframe.replace(/<iframe /, '<iframe id="rssmikle_iframe" onload="$(\'rssMiklePreview\').hide();" ');
}
window.onload = function () {
    rssMikleInit();
    rssMikleUpdatePreview();
};
