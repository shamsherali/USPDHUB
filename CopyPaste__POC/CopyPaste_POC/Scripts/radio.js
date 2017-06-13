(function ($) {
    $(document).ready(function () {
        $(".RadioClass0").change(function () {
            if ($(this).is(":checked")) {
                $(".RadioSelected0:not(:checked)").removeClass("RadioSelected0");
                $(this).next(".RadioLabelClass0").addClass("RadioSelected0");
                $("#rssmikle_title_bgcolors").val("");
            }
        });
        /*Default Setting Code*/
        $(".RadioClass0").each(function () {
            if ($(this).is(":checked")) {
                $(".RadioSelected0:not(:checked)").removeClass("RadioSelected0");
                $(this).next(".RadioLabelClass0").addClass("RadioSelected0");
            }
        });
        $(".RadioClass1").each(function () {
            if ($(this).is(":checked")) {
                $(".RadioSelected1:not(:checked)").removeClass("RadioSelected1");
                $(this).next(".RadioLabelClass1").addClass("RadioSelected1");
            }
        });
        $(".RadioClass3").each(function () {
            if ($(this).is(":checked")) {
                $(".RadioSelected3:not(:checked)").removeClass("RadioSelected3");
                $(this).next(".RadioLabelClassEntryck").addClass("RadioSelected3");
            }
        });
        $(".RadioClass4").each(function () {
            if ($(this).is(":checked")) {
                $(".RadioSelected4:not(:checked)").removeClass("RadioSelected4");
                $(this).next(".RadioLabelClassProduct").addClass("RadioSelected4");
            }
        });
        $(".RadioClass5").each(function () {
            if ($(this).is(":checked")) {
                $(".RadioSelected5:not(:checked)").removeClass("RadioSelected5");
                $(this).next(".RadioLabelClassContact").addClass("RadioSelected5");
            }
        });
        $(".RadioClass6").each(function () {
            if ($(this).is(":checked")) {
                $(".RadioSelected6:not(:checked)").removeClass("RadioSelected6");
                $(this).next(".RadioLabelClassContactimg").addClass("RadioSelected6");
            }
        });
        $(".RadioClass7").each(function () {
            if ($(this).is(":checked")) {
                $(".RadioSelected7:not(:checked)").removeClass("RadioSelected7");
                $(this).next(".RadioLabelClassWindow").addClass("RadioSelected7");
            }
        });
        $(".RadioClass8").each(function () {
            if ($(this).is(":checked")) {
                $(".RadioSelected8:not(:checked)").removeClass("RadioSelected8");
                $(this).next(".RadioLabelClassBorder").addClass("RadioSelected8");
            }
        });
        $(".RadioClass2").each(function () {
            if ($(this).is(":checked")) {
                $(".RadioSelected2:not(:checked)").removeClass("RadioSelected2");
                $(this).next(".RadioLabelClass2").addClass("RadioSelected2");
            }
        });
        $(".RadioClassTextAlignment").each(function () {
            if ($(this).is(":checked")) {
                $(".RadioSelectedTextAlignment:not(:checked").removeClass("RadioSelected");
                $(this).next(".RadioLabelClassTextAlignment").addClass("RadioSelected");
            }
        });
        $(".RadioClassCorner").each(function () {
            if ($(this).is(":checked")) {
                $(".RadioSelectedCorner:not(:checked)").removeClass("RadioSelectedCorner");
                $(this).next(".RadioLabelClassCorner").addClass("RadioSelectedCorner");
            }
        });
        $(".RadioClassAutoscroll").each(function () {
            if ($(this).is(":checked")) {
                $(".RadioSelectedAutoscroll:not(:checked)").removeClass("RadioSelectedAutoscroll");
                $(this).next(".RadioLabelClassAutoscroll").addClass("RadioSelectedAutoscroll");
            }
        });
        $(".RadioClassScrolldirection").each(function () {
            if ($(this).is(":checked")) {
                $(".RadioSelectedScrolldirection:not(:checked)").removeClass("RadioSelectedScrolldirection");
                $(this).next(".RadioLabelClassScrolldirection").addClass("RadioSelectedScrolldirection");
            }
        });
        $(".RadioClassMCSpeed").each(function () {
            if ($(this).is(":checked")) {
                $(".RadioSelectedMCSpeed:not(:checked)").removeClass("RadioSelectedMCSpeed");
                $(this).next(".RadioLabelClassMCSpeed").addClass("RadioSelectedMCSpeed");
            }
        });
        $(".RadioClassSort").each(function () {
            if ($(this).is(":checked")) {
                $(".RadioSelectedSort:not(:checked)").removeClass("RadioSelectedSort");
                $(this).next(".RadioLabelClassSort").addClass("RadioSelectedSort");
            }
        });
        $(".RadioClassResponsive").each(function () {
            if ($(this).is(":checked")) {
                $(".RadioClassResponsiveSelected:not(:checked)").removeClass("RadioClassResponsiveSelected");
                $(this).next(".RadioLabelClassResponsive").addClass("RadioClassResponsiveSelected");
            }
        });

        /*     Responsive code    */

        $(".RadioClassResponsive").change(function () {
            if ($(this).is(":checked")) {
                $(".RadioClassResponsiveSelected:not(:checked)").removeClass("RadioClassResponsiveSelected");
                $(this).next(".RadioLabelClassResponsive").addClass("RadioClassResponsiveSelected");
            }
        });

        $(".RadioClassDateFormat").each(function () {
            if ($(this).is(":checked")) {
                $(".RadioClassDateFormat:not(:checked)").removeClass("RadioSelected");
                $(this).next(".RadioLabelClassDateFormat").addClass("RadioSelected");
            }
        });
        $(".RadioClassTimeFormat").each(function () {
            if ($(this).is(":checked")) {
                $(".RadioClassTimeFormat:not(:checked)").removeClass("RadioSelected");
                $(this).next(".RadioLabelClassTimeFormat").addClass("RadioSelected");
            }
        });
        $(".RadioClassImageScaling").each(function () {
            if ($(this).is(":checked")) {
                $(".RadioClassImageScaling:not(:checked)").removeClass("RadioSelected");
                $(this).next(".RadioLabelClassImageScaling").addClass("RadioSelected");
            }
        });

        /*On event Setting Code*/
        $(".RadioClass1").change(function () {
            if ($(this).is(":checked")) {
                $(".RadioSelected1:not(:checked)").removeClass("RadioSelected1");
                $(this).next(".RadioLabelClass1").addClass("RadioSelected1");
            }
        });
        $(".RadioClass3").change(function () {
            if ($(this).is(":checked")) {
                $(".RadioSelected3:not(:checked)").removeClass("RadioSelected3");
                $(this).next(".RadioLabelClassEntryck").addClass("RadioSelected3");
            }
        });
        $(".RadioClass4").change(function () {
            if ($(this).is(":checked")) {
                $(".RadioSelected4:not(:checked)").removeClass("RadioSelected4");
                $(this).next(".RadioLabelClassProduct").addClass("RadioSelected4");
            }
        });
        $(".RadioClass5").change(function () {
            if ($(this).is(":checked")) {
                $(".RadioSelected5:not(:checked)").removeClass("RadioSelected5");
                $(this).next(".RadioLabelClassContact").addClass("RadioSelected5");
            }
        });
        $(".RadioClass6").change(function () {
            if ($(this).is(":checked")) {
                $(".RadioSelected6:not(:checked)").removeClass("RadioSelected6");
                $(this).next(".RadioLabelClassContactimg").addClass("RadioSelected6");
            }

            var speed = 'normal';
            if ($(this).val() == 'on_flexcroll') {
                $("#HTMLOnOption").show(speed);
            } else {
                $("#HTMLOnOption").hide();
            }
        });
        $(".RadioClass7").change(function () {
            if ($(this).is(":checked")) {
                $(".RadioSelected7:not(:checked)").removeClass("RadioSelected7");
                $(this).next(".RadioLabelClassWindow").addClass("RadioSelected7");
            }
        });
        $(".RadioClass8").change(function () {
            if ($(this).is(":checked")) {
                $(".RadioSelected8:not(:checked)").removeClass("RadioSelected8");
                $(this).next(".RadioLabelClassBorder").addClass("RadioSelected8");
            }
        });
        $(".RadioClass2").change(function () {
            if ($(this).is(":checked")) {
                $(".RadioSelected2:not(:checked)").removeClass("RadioSelected2");
                $(this).next(".RadioLabelClass2").addClass("RadioSelected2");
            }
        });
        $(".RadioClassTextAlignment").change(function () {
            if ($(this).is(":checked")) {
                $(".RadioSelected:not(:checked").removeClass("RadioSelected");
                $(this).next(".RadioLabelClassTextAlignment").addClass("RadioSelected");
            }
        });
        $(".RadioClassCorner").change(function () {
            if ($(this).is(":checked")) {
                $(".RadioSelectedCorner:not(:checked)").removeClass("RadioSelectedCorner");
                $(this).next(".RadioLabelClassCorner").addClass("RadioSelectedCorner");
            }
        });
        $(".RadioClassAutoscroll").change(function () {
            if ($(this).is(":checked")) {
                $(".RadioSelectedAutoscroll:not(:checked)").removeClass("RadioSelectedAutoscroll");
                $(this).next(".RadioLabelClassAutoscroll").addClass("RadioSelectedAutoscroll");
            }
            var speed = 'normal';
            if ($(this).val() == 'on') {
                $("#ScrollStep").show();
                $("#MCSpeed").hide();
                $("#ScrollOption").show(speed);
            } else if ($(this).val() == 'on_mc') {
                $("#ScrollStep").hide();
                $("#MCSpeed").show();
                $("#ScrollOption").show(speed);
            } else {
                $("#ScrollOption").hide();
                $("#ScrollStep").hide();
                $("#MCSpeed").hide();
            }
        });
        $(".RadioClassScrolldirection").change(function () {
            if ($(this).is(":checked")) {
                $(".RadioSelectedScrolldirection:not(:checked)").removeClass("RadioSelectedScrolldirection");
                $(this).next(".RadioLabelClassScrolldirection").addClass("RadioSelectedScrolldirection");
            }
        });
        $(".RadioClassMCSpeed").change(function () {
            if ($(this).is(":checked")) {
                $(".RadioSelectedMCSpeed:not(:checked)").removeClass("RadioSelectedMCSpeed");
                $(this).next(".RadioLabelClassMCSpeed").addClass("RadioSelectedMCSpeed");
            }
        });
        $(".RadioClassSort").change(function () {
            if ($(this).is(":checked")) {
                $(".RadioSelectedSort:not(:checked)").removeClass("RadioSelectedSort");
                $(this).next(".RadioLabelClassSort").addClass("RadioSelectedSort");
            }
        });
        $(".RadioClassDateFormat").change(function () {
            if ($(this).is(":checked")) {
                $(".RadioLabelClassDateFormat:not(:checked)").removeClass("RadioSelected");
                $(this).next(".RadioLabelClassDateFormat").addClass("RadioSelected");
            }
        });
        $(".RadioClassTimeFormat").change(function () {
            if ($(this).is(":checked")) {
                $(".RadioLabelClassTimeFormat:not(:checked)").removeClass("RadioSelected");
                $(this).next(".RadioLabelClassTimeFormat").addClass("RadioSelected");
            }
        });
        $(".RadioClassImageScaling").change(function () {
            if ($(this).is(":checked")) {
                $(".RadioLabelClassImageScaling:not(:checked)").removeClass("RadioSelected");
                $(this).next(".RadioLabelClassImageScaling").addClass("RadioSelected");
            }
        });
        $(".tabLink").each(function () {
            $(this).click(function () {
                tabeId = $(this).attr('id');
                $(".tabLink").removeClass("activeLink");
                $(this).addClass("activeLink");
                $(".tabcontent").addClass("hide");
                $("#" + tabeId + "-1").removeClass("hide")
                return false;
            });
        });
        $("#copy-description").click(function () {
            $("#rssmikle_snippet").select();
        });
        $("#generate-description").click(function () {
            $('#divWidget').css('display', 'none');
            $('#divCode').css('display', 'block');            
        });
        $("#create-widget").click(function () {
            $('#divWidget').css('display', 'block');
            $('#divCode').css('display', 'none');
            $("lblMailSuccessMsg").value = '';
        });
    });
})(jQuery);
