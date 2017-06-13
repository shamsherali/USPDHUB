var urls = new Array();
function rssMikleUpdatePreview() {
	var snippet = '';
	var preview = rssMikleValidateValues(this);
	
	if(!preview){
		snippet = rssMikleGetSnippet();
		preview = rssMikleGetPreview();
	}
        $("rssMiklePreview").show();
        $("rssmikle_snippet").value = snippet;
        $("rssmikle_preview").innerHTML = preview;
}

function rssMikleSelectDefault(obj,inputType,defaultNum){
	var selected = 0;
	if(inputType == 'select'){
		for(var i=0; i < obj.options.length; i++){
			if(obj.options[i].selected == 'true'){
				flag = 1;
				break;
			}
		}
		if(!selected){
			obj.options[defaultNum].selected = true;
		}
	} else if(inputType == 'radio'){
		for(var i=0; i < obj.length; i++){
			if(obj[i].checked){
				flag = 1;
				break;
			}
		}
		if(!selected){
			obj[defaultNum].checked = true;
		}
	}
}

function rssMikleInit() {
	/// set default value ///
	$("rssmikle_url").value = $("rssmikle_url").value ? $("rssmikle_url").value : '';
	$("rssmikle_frame_width").value = $("rssmikle_frame_width").value ? $("rssmikle_frame_width").value : 180;
	$("rssmikle_frame_height").value = $("rssmikle_frame_height").value ? $("rssmikle_frame_height").value : 500;
	$("rssmikle_font").value = $("rssmikle_font").value ? $("rssmikle_font").value : '';
	$("rssmikle_font_size").value = $("rssmikle_font_size").value ? $("rssmikle_font_size").value : 12;
        $("rssmikle_css_url").value = $("rssmikle_css_url").value ? $("rssmikle_css_url").value : '';
	$("rssmikle_title_bgcolor").value = $("rssmikle_title_bgcolor").value ? $("rssmikle_title_bgcolor").value : '0066FF';
	$("rssmikle_title_color").value = $("rssmikle_title_color").value ? $("rssmikle_title_color").value : 'FFFFFF';
	$("rssmikle_title_bgimage").value = $("rssmikle_title_bgimage").value ? $("rssmikle_title_bgimage").value : '';
	$("rssmikle_item_bgcolor").value = $("rssmikle_item_bgcolor").value ? $("rssmikle_item_bgcolor").value : 'FFFFFF';
	$("rssmikle_item_bgimage").value = $("rssmikle_item_bgimage").value ? $("rssmikle_item_bgimage").value : '';
	$("rssmikle_item_title_length").value = $("rssmikle_item_title_length").value ? $("rssmikle_item_title_length").value : 55;
	$("rssmikle_item_title_color").value = $("rssmikle_item_title_color").value ? $("rssmikle_item_title_color").value : '666666';
	$("rssmikle_item_description_length").value = $("rssmikle_item_description_length").value ? $("rssmikle_item_description_length").value : 150;
	$("rssmikle_item_description_color").value = $("rssmikle_item_description_color").value ? $("rssmikle_item_description_color").value : '666666';
        $("scrollstep").value = $("scrollstep").value ? $("scrollstep").value : 3;
	//$("responsive").value = $("responsive").value ? $("responsive").value : 0;

	/// attach event listener ///
	// onChange
	Event.observe("rssmikle_url","change",rssMikleUpdatePreview,false);
	Event.observe("rssmikle_frame_width","change",rssMikleUpdatePreview,false);
	Event.observe("rssmikle_frame_height","change",rssMikleUpdatePreview,false);
	Event.observe("rssmikle_font","change",rssMikleUpdatePreview,false);
	Event.observe("rssmikle_font_size","change",rssMikleUpdatePreview,false);
	Event.observe("rssmikle_css_url","change",rssMikleUpdatePreview,false);
	Event.observe("rssmikle_title_sentence","change",rssMikleUpdatePreview,false);
        Event.observe("rssmikle_title_link","change",rssMikleUpdatePreview,false);
        Event.observe("rssmikle_title_bgcolor","change",rssMikleUpdatePreview,false);
	Event.observe("rssmikle_title_color","change",rssMikleUpdatePreview,false);
	Event.observe("rssmikle_title_bgimage","change",rssMikleUpdatePreview,false);
	Event.observe("rssmikle_item_bgcolor","change",rssMikleUpdatePreview,false);
	Event.observe("rssmikle_item_bgimage","change",rssMikleUpdatePreview,false);
	Event.observe("rssmikle_item_title_length","change",rssMikleUpdatePreview,false);
	Event.observe("rssmikle_item_title_color","change",rssMikleUpdatePreview,false);
	Event.observe("rssmikle_item_description_length","change",rssMikleUpdatePreview,false);
	Event.observe("rssmikle_item_description_color","change",rssMikleUpdatePreview,false);
        Event.observe("scrollstep","change",rssMikleUpdatePreview,false);
	//Event.observe("responsive","change",rssMikleUpdatePreview,false);

	// onClick
	Event.observe("rssmikle_snippet","click",function(){
//		rssMikleUpdatePreview();
		Field.focus("rssmikle_snippet");
		Field.activate("rssmikle_snippet");
	},false);

	var obj = document.getElementsByName("rssmikle_title_bgcolors");
	for(var i = 0; i < obj.length ; i++){
		Event.observe(obj[i],"click",rssMikleSwitchColor,false);
	}
	obj = document.getElementsByName("rssmikle_target");
	for(var i = 0; i < obj.length ; i++){
		Event.observe(obj[i],"click",rssMikleUpdatePreview,false);
	}
	
	obj = document.getElementsByName("rssmikle_item_podcast");
	for(var i = 0; i < obj.length ; i++){
		Event.observe(obj[i],"click",rssMikleUpdatePreview,false);
	}

	obj = document.getElementsByName("rssmikle_border");
	for(var i = 0; i < obj.length ; i++){
		Event.observe(obj[i],"click",rssMikleUpdatePreview,false);
	}
        
        obj = document.getElementsByName("text_alignment");
        for(var i = 0; i < obj.length ; i++){
                Event.observe(obj[i],"click",rssMikleUpdatePreview,false);
        }

        obj = document.getElementsByName("corner");
        for(var i = 0; i < obj.length ; i++){
                Event.observe(obj[i],"click",rssMikleUpdatePreview,false);
        }

	obj = document.getElementsByName("autoscroll");
	for(var i = 0; i < obj.length ; i ++){
		Event.observe(obj[i],"click",rssMikleUpdatePreview,false);
	}

        obj = document.getElementsByName("scrolldirection");
        for(var i = 0; i < obj.length ; i ++){
                Event.observe(obj[i],"click",rssMikleUpdatePreview,false);
        }

        obj = document.getElementsByName("mcspeed");
        for(var i = 0; i < obj.length ; i ++){
                Event.observe(obj[i],"click",rssMikleUpdatePreview,false);
        }

        obj = document.getElementsByName("sort");
        for(var i = 0; i < obj.length ; i ++){
                Event.observe(obj[i],"click",rssMikleUpdatePreview,false);
        }

	obj = document.getElementsByName("rssmikle_title");
	for(var i = 0; i < obj.length ; i++){
		Event.observe(obj[i],"click",rssMikleUpdatePreview,false);
	}

	obj = document.getElementsByName("rssmikle_item_border_bottom");
	for(var i = 0; i < obj.length ; i++){
		Event.observe(obj[i],"click",rssMikleUpdatePreview,false);
	}

	obj = document.getElementsByName("rssmikle_item_description");
	for(var i = 0; i < obj.length ; i++){
		Event.observe(obj[i],"click",rssMikleUpdatePreview,false);
	}

	obj = document.getElementsByName("rssmikle_item_date");
	for(var i = 0; i < obj.length ; i++){
		Event.observe(obj[i],"click",rssMikleUpdatePreview,false);
	}

        obj = document.getElementsByName("date_format");
        for(var i = 0; i < obj.length ; i++){
                Event.observe(obj[i],"click",rssMikleUpdatePreview,false);
        }

        obj = document.getElementsByName("time_format");
        for(var i = 0; i < obj.length ; i++){
                Event.observe(obj[i],"click",rssMikleUpdatePreview,false);
        }

	obj = document.getElementsByName("rssmikle_item_date_timezone");
	for(var i = 0; i < obj.length ; i++){
		Event.observe(obj[i],"change",rssMikleUpdatePreview,false);
	}

	obj = document.getElementsByName("rssmikle_item_description_tag");
	for(var i = 0; i < obj.length ; i++){
		Event.observe(obj[i],"click",rssMikleUpdatePreview,false);
	}
        
        obj = document.getElementsByName("rssmikle_item_description_image_scaling");
        for(var i = 0; i < obj.length ; i++){
                Event.observe(obj[i],"click",rssMikleUpdatePreview,false);
        }

	obj = document.getElementsByTagName('label');
	for(var i = 0; i < obj.length; i++){
		var imgObj = obj[i].getElementsByTagName('img');
		for(var j=0; j < imgObj.length; j++){
			imgObj[j].formCtrlId = obj[i].htmlFor;
			imgObj[j].onclick = function(){$(this.formCtrlId).click()};
		}
	}


       obj = document.getElementsByName("responsive");
	for(var i = 0; i < obj.length ; i++){
		Event.observe(obj[i],"click",rssMikleUpdatePreview,false);
	}
}

function rssMikleValidateValues(evntObj){
	/// Validation ///
	// rssmikle_url
	if(!$("rssmikle_url").value  &&  urls.length == 0 ){
		Field.focus("rssmikle_url");
		return '<font color="red"><b>Please specify the URLs of your weblogs or RSS feeds.</b></font>';
	} else if(!$("rssmikle_url").value.match(/^https?\:\/\//i)){
		$("rssmikle_url").value = $("rssmikle_url").value.replace(/^/,'http\:\/\/');
	}

	// rssmikle_frame_width
	$("rssmikle_frame_width").value = $("rssmikle_frame_width").value.replace(/^0+/,'');
	if($("rssmikle_frame_width").value < 100){
		return '<font color="red">Please set the width more than 100px.</font>';
	} else if(!$("rssmikle_frame_width").value.match(/^[0-9]*$/g)) {
		return '<font color="red">Please input the integer to the width of the frame.</font>';
	}

	// rssmikle_frame_height
	$("rssmikle_frame_height").value = $("rssmikle_frame_height").value.replace(/^0+/,'');
	if($("rssmikle_frame_height").value < 100){
		return '<font color="red">Please set the height more than 100px.</font>';
	} else if(!$("rssmikle_frame_height").value.match(/^[0-9]*$/g)) {
		return '<font color="red">Please input the integer to the height of the frame.</font>';
	}

	// rssmikle_target

	// rssmikle_font_size
	$("rssmikle_font_size").value = $("rssmikle_font_size").value.replace(/^0+/,'');
	if($("rssmikle_font_size").value && !$("rssmikle_font_size").value.match(/^[0-9]*$/g)) {
		return '<font color="red">Please input the integer to the font size.</font>';
	}

	// rssmikle_border

	// rssmikle_css_url
	if($("rssmikle_css_url").value && !$("rssmikle_css_url").value.match(/^https?\:\/\//i)){
		$("rssmikle_css_url").value = $("rssmikle_css_url").value.replace(/^/,'http\:\/\/');
	}

	// rssmikle_title

	// rssmikle_title_bgcolor
	if($("rssmikle_title_bgcolor").value && !$("rssmikle_title_bgcolor").value.match(/^[0-9a-fA-F]{6}$/g)) {
		return '<font color="red">Please specify the background color of the feed title by the hexadecimal number.</font>';
	} else if($("rssmikle_title_bgcolor").value){
		$("rssmikle_title_bgcolor_colorbox").style.backgroundColor = '#' + $("rssmikle_title_bgcolor").value;
	}

	// rssmikle_title_color
	if($("rssmikle_title_color").value && !$("rssmikle_title_color").value.match(/^[0-9a-fA-F]{6}$/g)) {
		return '<font color="red">Please specify the font color of the feed title by the hexadecimal number.</font>';
	} else if($("rssmikle_title_color").value){
		$("rssmikle_title_color_colorbox").style.backgroundColor = '#' + $("rssmikle_title_color").value;
	}

	// rssmikle_title_bgimage
	if($("rssmikle_title_bgimage").value && !$("rssmikle_title_bgimage").value.match(/^https?\:\/\//i)){
		$("rssmikle_title_bgimage").value = $("rssmikle_title_bgimage").value.replace(/^/,'http\:\/\/');
	}

	// rssmikle_item_bgcolor
	if($("rssmikle_item_bgcolor").value && !$("rssmikle_item_bgcolor").value.match(/^[0-9a-fA-F]{6}$/g)) {
		return '<font color="red">Please specify the background color of the entry title by the hexadecimal number.</font>';
	} else if($("rssmikle_item_bgcolor").value){
		$("rssmikle_item_bgcolor_colorbox").style.backgroundColor = '#' + $("rssmikle_item_bgcolor").value;
	}

	// rssmikle_item_bgimage
	if($("rssmikle_item_bgimage").value && !$("rssmikle_item_bgimage").value.match(/^https?\:\/\//i)){
		$("rssmikle_item_bgimage").value = $("rssmikle_item_bgimage").value.replace(/^/,'http\:\/\/');
	}

	// rssmikle_item_title_length
	$("rssmikle_item_title_length").value = $("rssmikle_item_title_length").value.replace(/^0+/,'');
	if($("rssmikle_item_title_length").value && !$("rssmikle_item_title_length").value.match(/^[0-9]*$/g)) {
		return '<font color="red">Please input the integer to the maximum length of entry title.</font>';
	}

	// rssmikle_item_title_color
	if($("rssmikle_item_title_color").value && !$("rssmikle_item_title_color").value.match(/^[0-9a-fA-F]{6}$/g)) {
		return '<font color="red">Please specify the font color of the entry title by the hexadecimal number.</font>';
	} else if($("rssmikle_item_title_color").value){
		$("rssmikle_item_title_color_colorbox").style.backgroundColor = '#' + $("rssmikle_item_title_color").value;
	}

	// rssmikle_item_border_bottom
	// rssmikle_item_description

	// rssmikle_item_description_length
	$("rssmikle_item_description_length").value = $("rssmikle_item_description_length").value.replace(/^0+/,'');
	if($("rssmikle_item_description_length").value && !$("rssmikle_item_description_length").value.match(/^[0-9]*$/g)) {
		return '<font color="red">Please input the integer to the maximum length of entry contents.</font>';
	}

	// rssmikle_item_description_color
	if($("rssmikle_item_description_color").value && !$("rssmikle_item_description_color").value.match(/^[0-9a-fA-F]{6}$/g)) {
		return '<font color="red">Please specify the font color of the entry contents by the hexadecimal number.</font>';
	} else if($("rssmikle_item_description_color").value){
		$("rssmikle_item_description_color_colorbox").style.backgroundColor = '#' + $("rssmikle_item_description_color").value;
	}

	// rssmikle_item_description_tag
	if(rssMikleGetRadioValue("rssmikle_item_description_tag") == 'on') {
		$("rssmikle_item_description_length").disabled = true;
	} else {
		$("rssmikle_item_description_length").disabled = false;
	}

        // scrollstep
        $("scrollstep").value = $("scrollstep").value.replace(/^0+/,'');
        if($("scrollstep").value < 1){
                return '<font color="red">Please set the Scroll Step more than 1sec.</font>';
        } else if(!$("scrollstep").value.match(/^[0-9]*$/g)) {
                return '<font color="red">Please input the integer to the Scroll Step.</font>';
        }

	/// Disable ///
	if($("rssmikle_css_url").value != ""){
		$("rssmikle_font").disabled = true;
		$("rssmikle_font_size").disabled = true;
		$("rssmikle_border1").disabled = true;
		$("rssmikle_border2").disabled = true;
		$("rssmikle_title_bgcolors1").disabled = true;
		$("rssmikle_title_bgcolors2").disabled = true;
		$("rssmikle_title_bgcolors3").disabled = true;
		$("rssmikle_title_bgcolors4").disabled = true;
		$("rssmikle_title_bgcolors5").disabled = true;
		$("rssmikle_title_bgcolors6").disabled = true;
		$("rssmikle_title_bgcolor").disabled = true;
		$("rssmikle_title_color").disabled = true;
		$("rssmikle_title_bgimage").disabled = true;
		$("rssmikle_item_bgcolor").disabled = true;
		$("rssmikle_item_bgimage").disabled = true;
		$("rssmikle_item_title_color").disabled = true;
		$("rssmikle_item_border_bottom1").disabled = true;
		$("rssmikle_item_border_bottom2").disabled = true;
		$("rssmikle_item_description_color").disabled = true;

		$("rssmikle_title_bgcolor_colorbox").disabled = true;
		$("rssmikle_title_color_colorbox").disabled = true;
		$("rssmikle_item_title_color_colorbox").disabled = true;
		$("rssmikle_item_bgcolor_colorbox").disabled = true;
		$("rssmikle_item_description_color_colorbox").disabled = true;
		
                 $("responsive1").disabled = true;
		$("responsive1").disabled = true;
		
		/*ADD DISABLE CLASS*/
		$("rssmikle_font").parentNode.className += ' deactive';
		$("rssmikle_font_size").parentNode.className += ' deactive';
		$("rssmikle_border1").parentNode.parentNode.className += ' deactive';
		$("rssmikle_border2").parentNode.parentNode.className += ' deactive';
		$("rssmikle_title_bgcolors1").parentNode.parentNode.className += ' deactive';
		$("rssmikle_title_bgcolors2").parentNode.parentNode.className += ' deactive';
		$("rssmikle_title_bgcolors3").parentNode.parentNode.className += ' deactive';
		$("rssmikle_title_bgcolors4").parentNode.parentNode.className += ' deactive';
		$("rssmikle_title_bgcolors5").parentNode.parentNode.className += ' deactive';
		$("rssmikle_title_bgcolors6").parentNode.parentNode.className += ' deactive';
		$("rssmikle_title_bgcolor").parentNode.className += ' deactive';
		$("rssmikle_title_color").parentNode.className += ' deactive';
		$("rssmikle_title_bgimage").parentNode.className += ' deactive';
		$("rssmikle_item_bgcolor").parentNode.className += ' deactive';
		$("rssmikle_item_bgimage").parentNode.className += ' deactive';
		$("rssmikle_item_title_color").parentNode.className += ' deactive';
		$("rssmikle_item_border_bottom1").parentNode.className += ' deactive';
		$("rssmikle_item_border_bottom2").parentNode.className += ' deactive';
		$("rssmikle_item_description_color").parentNode.className += ' deactive';

                $("responsive1").parentNode.parentNode.className += ' deactive';
		$("responsive2").parentNode.parentNode.className += ' deactive';


	} else {
		$("rssmikle_frame_width").disabled = false;
		$("rssmikle_frame_height").disabled = false;
		$("rssmikle_font").disabled = false;
		$("rssmikle_font_size").disabled = false;
		$("rssmikle_border1").disabled = false;
		$("rssmikle_border2").disabled = false;
		$("rssmikle_title1").disabled = false;
		$("rssmikle_title2").disabled = false;
		$("rssmikle_title_bgcolors1").disabled = false;
		$("rssmikle_title_bgcolors2").disabled = false;
		$("rssmikle_title_bgcolors3").disabled = false;
		$("rssmikle_title_bgcolors4").disabled = false;
		$("rssmikle_title_bgcolors5").disabled = false;
		$("rssmikle_title_bgcolors6").disabled = false;
		$("rssmikle_title_bgcolor").disabled = false;
		$("rssmikle_title_color").disabled = false;
		$("rssmikle_title_bgimage").disabled = false;
		$("rssmikle_item_bgcolor").disabled = false;
		$("rssmikle_item_bgimage").disabled = false;
		$("rssmikle_item_title_color").disabled = false;
		$("rssmikle_item_border_bottom1").disabled = false;
		$("rssmikle_item_border_bottom2").disabled = false;
		$("rssmikle_item_description_color").disabled = false;

		$("rssmikle_title_bgcolor_colorbox").disabled = false;
		$("rssmikle_title_color_colorbox").disabled = false;
		$("rssmikle_item_title_color_colorbox").disabled = false;
		$("rssmikle_item_bgcolor_colorbox").disabled = false;
		$("rssmikle_item_description_color_colorbox").disabled = false;

                $("responsive1").disabled = false;
		$("responsive2").disabled = false;
		
		/*REMOVE DISABLE CLASS*/
		$("rssmikle_font").parentNode.className = $("rssmikle_font").parentNode.className.replace(/\bdeactive\b/,'');
		$("rssmikle_font_size").parentNode.className = $("rssmikle_font_size").parentNode.className.replace(/\bdeactive\b/,'');
		$("rssmikle_border1").parentNode.parentNode.className = $("rssmikle_border1").parentNode.parentNode.className.replace(/\bdeactive\b/,'');
		$("rssmikle_border2").parentNode.parentNode.className = $("rssmikle_border2").parentNode.parentNode.className.replace(/\bdeactive\b/,'');
		$("rssmikle_title_bgcolors1").parentNode.parentNode.className = $("rssmikle_title_bgcolors1").parentNode.parentNode.className.replace(/\bdeactive\b/,'');
		$("rssmikle_title_bgcolors2").parentNode.parentNode.className = $("rssmikle_title_bgcolors2").parentNode.parentNode.className.replace(/\bdeactive\b/,'');
		$("rssmikle_title_bgcolors3").parentNode.parentNode.className = $("rssmikle_title_bgcolors3").parentNode.parentNode.className.replace(/\bdeactive\b/,'');
		$("rssmikle_title_bgcolors4").parentNode.parentNode.className = $("rssmikle_title_bgcolors4").parentNode.parentNode.className.replace(/\bdeactive\b/,'');
		$("rssmikle_title_bgcolors5").parentNode.parentNode.className = $("rssmikle_title_bgcolors5").parentNode.parentNode.className.replace(/\bdeactive\b/,'');
		$("rssmikle_title_bgcolors6").parentNode.parentNode.className = $("rssmikle_title_bgcolors6").parentNode.parentNode.className.replace(/\bdeactive\b/,'');
		$("rssmikle_title_bgcolor").parentNode.className = $("rssmikle_title_bgcolor").parentNode.className.replace(/\bdeactive\b/,'');
		$("rssmikle_title_color").parentNode.className = $("rssmikle_title_color").parentNode.className.replace(/\bdeactive\b/,'');
		$("rssmikle_title_bgimage").parentNode.className = $("rssmikle_title_bgimage").parentNode.className.replace(/\bdeactive\b/,'');
		$("rssmikle_item_bgcolor").parentNode.className = $("rssmikle_item_bgcolor").parentNode.className.replace(/\bdeactive\b/,'');
		$("rssmikle_item_bgimage").parentNode.className = $("rssmikle_item_bgimage").parentNode.className.replace(/\bdeactive\b/,'');
		$("rssmikle_item_title_color").parentNode.className = $("rssmikle_item_title_color").parentNode.className.replace(/\bdeactive\b/,'');
		$("rssmikle_item_border_bottom1").parentNode.className = $("rssmikle_item_border_bottom1").parentNode.className.replace(/\bdeactive\b/,'');
		$("rssmikle_item_border_bottom2").parentNode.className = $("rssmikle_item_border_bottom2").parentNode.className.replace(/\bdeactive\b/,'');
		$("rssmikle_item_description_color").parentNode.className = $("rssmikle_item_description_color").parentNode.className.replace(/\bdeactive\b/,'');

                $("responsive1").parentNode.parentNode.className = $("responsive1").parentNode.parentNode.className.replace(/\bdeactive\b/,'');
		$("responsive2").parentNode.parentNode.className = $("responsive2").parentNode.parentNode.className.replace(/\bdeactive\b/,'');


	}
	
	if(rssMikleGetRadioValue("rssmikle_item_description") == 'off'){
		$("rssmikle_item_description_length").disabled = true;
		$("rssmikle_item_description_color").disabled = true;
		$("rssmikle_item_date1").disabled = true;
		$("rssmikle_item_date2").disabled = true;
		$("rssmikle_item_date3").disabled = true;
		$("rssmikle_item_description_tag1").disabled = false;
		$("rssmikle_item_description_tag2").disabled = false;
	} else {
		$("rssmikle_item_description_length").disabled = false;
		if($("rssmikle_css_url").value){
			$("rssmikle_item_description_color").disabled = true;
		} else {
			$("rssmikle_item_description_color").disabled = false;
		}
		$("rssmikle_item_date1").disabled = false;
		$("rssmikle_item_date2").disabled = false;
		$("rssmikle_item_date3").disabled = false;
		$("rssmikle_item_description_tag1").disabled = false;
		$("rssmikle_item_description_tag2").disabled = false;
	}

	if(rssMikleGetRadioValue("rssmikle_item_description_tag") == 'on'){
		$("rssmikle_item_description_length").disabled = true;
	} else {
		if(rssMikleGetRadioValue("rssmikle_item_description") == 'off'){
			$("rssmikle_item_description_length").disabled = true;
		} else {
			$("rssmikle_item_description_length").disabled = false;
		}
	}

	/*if(rssMikleGetRadioValue("rssmikle_item_description") == 'off'){
		$("rssmikle_item_description_length").disabled = true;
		$("rssmikle_item_description_color").disabled = true;
		if(evntObj.name == "rssmikle_item_description"){
			document.getElementsByName("rssmikle_item_description_tag").value = 'off';
			$("htmlLabel1").className += ' RadioSelected6';
			$("htmlLabel2").className = "RadioLabelClassContactimg htmlon";
		}
	} else {
		$("rssmikle_item_description_length").disabled = false;
		if($("rssmikle_css_url").value){
			$("rssmikle_item_description_color").disabled = true;
		} else {
			$("rssmikle_item_description_color").disabled = false;
		}
		if(evntObj.name == "rssmikle_item_description"){
			document.getElementsByName("rssmikle_item_description_tag").value = 'on_flexcroll';
			$("htmlLabel2").className += ' RadioSelected6';
			$("htmlLabel1").className = "RadioLabelClassContactimg htmlon";
		}
	}
	if(evntObj.name == "rssmikle_item_description_tag"){
		if(evntObj.value == "on_flexcroll"){
			document.getElementsByName("rssmikle_item_description_tag").value = 'off';
			$("htmlLabel2").className += ' RadioSelected6';
			$("htmlLabel1").className = "RadioLabelClassContactimg htmlon";
		} else {
			document.getElementsByName("rssmikle_item_description_tag").value = 'on_flexcroll';
			$("htmlLabel1").className += ' RadioSelected6';
			$("htmlLabel2").className = "RadioLabelClassContactimg htmlon";
		}
	}
	
	if(rssMikleGetRadioValue("rssmikle_item_description_tag") == 'on'){
		$("rssmikle_item_description_length").disabled = true;
	} else {
		if(rssMikleGetRadioValue("rssmikle_item_description") == 'off'){
			$("rssmikle_item_description_length").disabled = true;
		} else {
			$("rssmikle_item_description_length").disabled = false;
		}
	}*/

	if(rssMikleGetRadioValue("rssmikle_title") == 'off'){
		$("rssmikle_title_bgcolors1").disabled = true;
		$("rssmikle_title_bgcolors2").disabled = true;
		$("rssmikle_title_bgcolors3").disabled = true;
		$("rssmikle_title_bgcolors4").disabled = true;
		$("rssmikle_title_bgcolors5").disabled = true;
		$("rssmikle_title_bgcolors6").disabled = true;
		$("rssmikle_title_bgcolor").disabled = true;
		$("rssmikle_title_color").disabled = true;
		$("rssmikle_title_bgimage").disabled = true;

		$("rssmikle_title_bgcolor_colorbox").disabled = true;
		$("rssmikle_title_color_colorbox").disabled = true;

	} else {
		if($("rssmikle_css_url").value){
			$("rssmikle_title_bgcolors1").disabled = true;
			$("rssmikle_title_bgcolors2").disabled = true;
			$("rssmikle_title_bgcolors3").disabled = true;
			$("rssmikle_title_bgcolors4").disabled = true;
			$("rssmikle_title_bgcolors5").disabled = true;
			$("rssmikle_title_bgcolors6").disabled = true;
			$("rssmikle_title_bgcolor").disabled = true;
			$("rssmikle_title_color").disabled = true;
			$("rssmikle_title_bgimage").disabled = true;

			$("rssmikle_title_bgcolor_colorbox").disabled = true;
			$("rssmikle_title_color_colorbox").disabled = true;
		} else {
			$("rssmikle_title_bgcolors1").disabled = false;
			$("rssmikle_title_bgcolors2").disabled = false;
			$("rssmikle_title_bgcolors3").disabled = false;
			$("rssmikle_title_bgcolors4").disabled = false;
			$("rssmikle_title_bgcolors5").disabled = false;
			$("rssmikle_title_bgcolors6").disabled = false;
			$("rssmikle_title_bgcolor").disabled = false;
			$("rssmikle_title_color").disabled = false;
			$("rssmikle_title_bgimage").disabled = false;

			$("rssmikle_title_bgcolor_colorbox").disabled = false;
			$("rssmikle_title_color_colorbox").disabled = false;
		}
	}
	return "";
}

function rssMikleSwitchColor() {
	$("rssmikle_title_bgcolor").value = rssMikleGetRadioValue("rssmikle_title_bgcolors");
	$("rssmikle_title_bgcolor").style.background = "#"+rssMikleGetRadioValue("rssmikle_title_bgcolors");
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
  for(var i=0; i < urls.length; i++){
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

	for(var i = 0; i < obj.length ; i++){
		if(obj[i].checked){
			value = obj[i].value;
			break;
		}
	}

        return value;
}

function rssMikleGetSnippet(){
	var snippet = '<!-- start feedwind code -->'
		+ '<script type="text/javascript">'
                + 'document.write(\'<script type="text/javascript" src="\' + (\'https:\' == document.location.protocol ? \'https://\' : \'http://\') + \'feed.mikle.com/js/rssmikle.js"><\\/script>\');'
                + '</script>'
		+ '<script type="text/javascript">'
		+ '(function() {'
                + 'var params = {'
		+ 'rssmikle_url: "' + rssMikleGetURLs() + '",'
		+ 'rssmikle_frame_width: "' + $("rssmikle_frame_width").value + '",'
		+ 'rssmikle_frame_height: "' + $("rssmikle_frame_height").value + '",'
		+ 'rssmikle_target: "' + rssMikleGetRadioValue("rssmikle_target") + '",'
		+ 'rssmikle_font: "' + $("rssmikle_font").value + '",'
		+ 'rssmikle_font_size: "' + $("rssmikle_font_size").value + '",'
		+ 'rssmikle_border: "' + rssMikleGetRadioValue("rssmikle_border") + '",'
                + 'responsive: "' + rssMikleGetRadioValue("responsive") + '",'
		+ 'rssmikle_css_url: "' + $("rssmikle_css_url").value + '",'
                + 'text_align: "' + rssMikleGetRadioValue("text_alignment") + '",'
		+ 'corner: "' + rssMikleGetRadioValue("corner") + '",'
                + 'autoscroll: "' + rssMikleGetRadioValue("autoscroll") + '",'
                + 'scrolldirection: "' + rssMikleGetRadioValue("scrolldirection") + '",'
		+ 'scrollstep: "' + $("scrollstep").value + '",'
                + 'mcspeed: "' + rssMikleGetRadioValue("mcspeed") + '",'
                + 'sort: "' + rssMikleGetRadioValue("sort") + '",'
                + 'rssmikle_title: "' + rssMikleGetRadioValue("rssmikle_title") + '",'
		+ 'rssmikle_title_sentence: "' + $("rssmikle_title_sentence").value + '",'
                + 'rssmikle_title_link: "' + $("rssmikle_title_link").value + '",'
                + 'rssmikle_title_bgcolor: "' + ($("rssmikle_title_bgcolor").value ? '#' + $("rssmikle_title_bgcolor").value : '') + '",'
		+ 'rssmikle_title_color: "' + ($("rssmikle_title_color").value ? '#' + $("rssmikle_title_color").value : '') + '",'
		+ 'rssmikle_title_bgimage: "' + $("rssmikle_title_bgimage").value + '",'
		+ 'rssmikle_item_bgcolor: "' + ($("rssmikle_item_bgcolor").value ? '#' + $("rssmikle_item_bgcolor").value : '') + '",'
		+ 'rssmikle_item_bgimage: "' + $("rssmikle_item_bgimage").value + '",'
		+ 'rssmikle_item_title_length: "' + $("rssmikle_item_title_length").value + '",'
		+ 'rssmikle_item_title_color: "' + ($("rssmikle_item_title_color").value ? '#' + $("rssmikle_item_title_color").value : '') + '",'
		+ 'rssmikle_item_border_bottom: "' + rssMikleGetRadioValue("rssmikle_item_border_bottom") + '",'
		+ 'rssmikle_item_description: "' + rssMikleGetRadioValue("rssmikle_item_description") + '",'
		+ 'rssmikle_item_description_length: "' + $("rssmikle_item_description_length").value + '",'
		+ 'rssmikle_item_description_color: "' + ($("rssmikle_item_description_color").value ? '#' + $("rssmikle_item_description_color").value : '') + '",'
		+ 'rssmikle_item_date: "' + rssMikleGetRadioValue("rssmikle_item_date") + '",'
		+ 'rssmikle_timezone: "' + $("rssmikle_timezone").value + '",'
		+ 'datetime_format: "' + GetDatetimeFormat() + '",'
                + 'rssmikle_item_description_tag: "' + rssMikleGetRadioValue("rssmikle_item_description_tag") + '",'
                + 'rssmikle_item_description_image_scaling: "' + rssMikleGetRadioValue("rssmikle_item_description_image_scaling") + '",'
		+ 'rssmikle_item_podcast: "' + rssMikleGetRadioValue("rssmikle_item_podcast") + '"'
                + '};'
                + 'feedwind_show_widget_iframe(params);'
                + '})();'
		+ '</script>'
		+ '<div style="font-size:10px; text-align:center; '
		+ ((rssMikleGetRadioValue("responsive") == "on") ? '' : 'width:' + $("rssmikle_frame_width").value + ';') + '">'
		+ '<a href="http://feed.mikle.com/" target="_blank" style="color:#CCCCCC;">RSS Feed Widget</a>'
		+ '<!--Please display the above link in your web page according to Terms of Service.-->'
		+ '</div>'
		+ '<!-- end feedwind code -->';
	return snippet;
}

function rssMikleGetPreview() {
    var params = {
        rssmikle_url: rssMikleGetURLs(),
        rssmikle_frame_width: $("rssmikle_frame_width").value,
        rssmikle_frame_height: $("rssmikle_frame_height").value,
        rssmikle_target: rssMikleGetRadioValue("rssmikle_target"),
        rssmikle_font: $("rssmikle_font").value,
        rssmikle_font_size: $("rssmikle_font_size").value,
        rssmikle_border: rssMikleGetRadioValue("rssmikle_border"),
        responsive: rssMikleGetRadioValue("responsive"),
        rssmikle_css_url: $("rssmikle_css_url").value,
        text_align: rssMikleGetRadioValue("text_alignment"),
        corner: rssMikleGetRadioValue("corner"),
        autoscroll: rssMikleGetRadioValue("autoscroll"),
        scrolldirection: rssMikleGetRadioValue("scrolldirection"),
        scrollstep: $("scrollstep").value,
        mcspeed: rssMikleGetRadioValue("mcspeed"),
        sort: rssMikleGetRadioValue("sort"),
        rssmikle_title: rssMikleGetRadioValue("rssmikle_title"),
        rssmikle_title_sentence: $("rssmikle_title_sentence").value,
        rssmikle_title_link: $("rssmikle_title_link").value,
        rssmikle_title_bgcolor: ($("rssmikle_title_bgcolor").value ? '#' + $("rssmikle_title_bgcolor").value : ''),
        rssmikle_title_color: ($("rssmikle_title_color").value ? '#' + $("rssmikle_title_color").value : ''),
        rssmikle_title_bgimage: $("rssmikle_title_bgimage").value,
        rssmikle_item_bgcolor: ($("rssmikle_item_bgcolor").value ? '#' + $("rssmikle_item_bgcolor").value : ''),
        rssmikle_item_bgimage: $("rssmikle_item_bgimage").value,
        rssmikle_item_title_length: $("rssmikle_item_title_length").value,
        rssmikle_item_title_color: ($("rssmikle_item_title_color").value ? '#' + $("rssmikle_item_title_color").value : ''),
        rssmikle_item_border_bottom: rssMikleGetRadioValue("rssmikle_item_border_bottom"),
        rssmikle_item_description: rssMikleGetRadioValue("rssmikle_item_description"),
        rssmikle_item_description_length: $("rssmikle_item_description_length").value,
        rssmikle_item_description_color: ($("rssmikle_item_description_color").value ? '#' + $("rssmikle_item_description_color").value : ''),
        rssmikle_item_date: rssMikleGetRadioValue("rssmikle_item_date"),
        rssmikle_timezone: $("rssmikle_timezone").value,
        datetime_format: GetDatetimeFormat(),
        rssmikle_item_description_tag: rssMikleGetRadioValue("rssmikle_item_description_tag"),
        rssmikle_item_description_image_scaling: rssMikleGetRadioValue("rssmikle_item_description_image_scaling"),
        rssmikle_item_podcast: rssMikleGetRadioValue("rssmikle_item_podcast")
    }

    // "feedwind_show_widget_iframe" is defined in "/js/rssmikle.js".
    var iframe = feedwind_show_widget_iframe(params, 'html');
    return iframe.replace(/<iframe /,'<iframe id="rssmikle_iframe" onload="$(\'rssMiklePreview\').hide();" ');
}

function addURL(){
  if ($("rssmikle_url").value == 'http://') {
    return false;
  }
  jQuery("#rssmikle_urls_indicator").show();
  jQuery.ajax({
    type:"GET",
    dataType:"json",
    url: "http://feed.mikle.com/getFeedTitle/"+$("rssmikle_url").value,
    success: function(data){
      if(data.error){
        // wrong URI
        alert(data.error);
        $("rssmikle_url").value = '';
        jQuery("#rssmikle_urls_indicator").hide();
        rssMikleUpdatePreview();
      } else {
        var obj = {
          url: $("rssmikle_url").value,
          title: data.title,
        };
        $("rssmikle_url").value = '';
        urls.push(obj);
        updateURLs();
        jQuery("#rssmikle_urls_indicator").hide();
        rssMikleUpdatePreview();
      }
    },      
  });
}

function removeURL(number){
  urls.splice(number, 1);
  updateURLs();
  rssMikleUpdatePreview();
}

function updateURLs(){
  var urlsHTML = '<ul>';
  for(var i=0; i < urls.length; i++){
    urlsHTML = urlsHTML + '<li><strong>' + urls[i]['title'] + '</strong> | <em>' + urls[i]['url'] + '</em> <a class="delete_feed" href="/#" onClick="removeURL(' + i + ');return false;">remove</a>' + '</li><br />';
  }
  urlsHTML = urlsHTML + '</ul>';
  jQuery('#rssmikle_urls').html(urlsHTML);
}

window.onload = function(){
	rssMikleInit();
	initShowHideDivs();
	rssMikleUpdatePreview();
};
