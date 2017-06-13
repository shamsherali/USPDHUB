function feedwind_show_widget_iframe(params, html) {
    
    params['rssmikle_frame_width'] = params['rssmikle_frame_width'] ? params['rssmikle_frame_width'] : 180;
    params['rssmikle_frame_height'] = params['rssmikle_frame_height'] ? params['rssmikle_frame_height'] : 500;

    var iframe_width = params['rssmikle_frame_width'];
    var iframe_height = params['rssmikle_frame_height'];

    iframe_width = parseInt(params['rssmikle_frame_width']) + 2;
    iframe_height = parseInt(params['rssmikle_frame_height']) + 2;

    var url = ('https:' == document.location.protocol ? 'https://' : 'http://') + 'localhost:2107/ProfileIframes/DataFeedsPreview.aspx?';
    for (var key in params) {
        if (params[key]) {
            url += key + '=' + encodeURIComponent(params[key]) + '&';
        }
    }

    var iframe = '<iframe name="rssmikle_frame" width="' + iframe_width + '" height="' + iframe_height + '" frameborder="0" src="' + url + '" marginwidth="0" marginheight="0" vspace="0" hspace="0"></iframe>';

    if (html) {
        return iframe;
    } else {
        document.write(iframe);
    }
}

(function () {
    var a = window;
    if (a.rssmikle_url && typeof (a.rssmikle_url) == 'string') {
        old_snippet();
    }

    function undef_to_nullstr(v) {
        return (v ? v : '');
    }

    function old_snippet() {
        var params = {
            rssmikle_url: undef_to_nullstr(a.rssmikle_url),
            rssmikle_frame_width: undef_to_nullstr(a.rssmikle_frame_width),
            rssmikle_frame_height: undef_to_nullstr(a.rssmikle_frame_height),
            rssmikle_target: undef_to_nullstr(a.rssmikle_target),
            rssmikle_font: undef_to_nullstr(a.rssmikle_font),
            rssmikle_font_size: undef_to_nullstr(a.rssmikle_font_size),
            rssmikle_title_bgcolor: undef_to_nullstr(a.rssmikle_title_bgcolor),
            rssmikle_title_color: undef_to_nullstr(a.rssmikle_title_color),
            rssmikle_item_bgcolor: undef_to_nullstr(a.rssmikle_item_bgcolor),
            rssmikle_item_title_color: undef_to_nullstr(a.rssmikle_item_title_color),
            rssmikle_item_border_bottom: undef_to_nullstr(a.rssmikle_item_border_bottom),
            rssmikle_item_description_color: undef_to_nullstr(a.rssmikle_item_description_color)
        };

        feedwind_show_widget_iframe(params);
       
        a.rssmikle_frame_width = '';
        a.rssmikle_frame_height = '';
        a.rssmikle_target = '';
        a.rssmikle_font = '';
        a.rssmikle_font_size = '';
        a.rssmikle_title_bgcolor = '';
        a.rssmikle_title_color = '';
        a.rssmikle_item_bgcolor = '';
        a.rssmikle_item_title_color = '';
        a.rssmikle_item_border_bottom = '';
        a.rssmikle_item_description_color = '';
    }
})()
