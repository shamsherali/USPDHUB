////////////////////////////////////////////////////////////
// This software is solely the property of Karamasoft LLC. /
//   Copyright 2009 Karamasoft LLC. All rights reserved.   /
//                  www.karamasoft.com                     /
////////////////////////////////////////////////////////////

var usdb3; var usde2='divSpellErrorType'; var usde3='divSpellErrorText'; var usdz4='divChangeTo'; var usde4='tbChangeTo'; var usde6='btnIgnore'; var usde8='btnChange'; var usdy3='btnOK'; var usdy4='btnCancel'; var usdz3='spanLoading'; var usdg1; var usdg2; var usdg3; var usdg5; var usdg7; var usdh7; var usd7m; var usd8m; var usdi2; function usdu4() { window.close(); } function usdf23(usdf24) { var usdf25=usdj2(usdf24); if (usdf25 && usdf25.offsetTop > usdc2) { usdg2.scrollTop=usdf25.offsetTop; } } function usdo0() { usdi2=new Object(); var s=window.location.href; s=s.substring(s.indexOf('?')+1); s=s.replace(/&amp;/g,/&/g); if (s) { var usdo1=s.split('&'); for (var i=0,usdn3=usdo1.length; i < usdn3; i++) { var usdo2=usdo1[i].split('='); if (usdo2.length > 1) { usdi2[decodeURIComponent(usdo2[0].replace(/\+/g,usd2n))]=decodeURIComponent(usdo2[1].replace(/\+/g,usd2n)); } } } } function usdo3(usdo2) { return (typeof (usdi2[usdo2]) != 'undefined') ? usdi2[usdo2] : ''; } function usde20(usde21,usde22,usde23) { var usde24=usde21.lastIndexOf(usde22); if (usde23 < usde24) { var usde25=usde21.indexOf('>',usde24); usde23=(usde25 != -1) ? usde25+1 : usde24+usde22.length; } return usde23; } function usde26(usde27,usde22,usde28) { var usde29=usde27.indexOf(usde22); if (usde29 != -1 && (usde28 == -1 || usde28 > usde29)) { usde28=usde29; } return usde28; } function usdf26(usdf24,usdf27,usdf28) { return usd3r+'id="'+usdf24+'"'+((usdf27) ? ' class="'+usdf27+'"' : '')+((usdf28) ? ' style="'+usdf28+'"' : '')+'>'; } function usdf29(usd1c) { usdh7=(typeof (parent.window.dialogArguments) != 'undefined') ? parent.window.dialogArguments : (top.opener) ? top.opener : null; usdo0(); usd7m=usdh7.UltimateSpells[usdo3(usdc9)]; usd8m=new UltimateSpell(usd7m.usd1e,usd7m.usdb18,usd7m.usdb91,usd7m.usd4g,usd7m.usdi7,usd7m.usd6a,usd7m.usd5b,usd7m.usdi8,usd7m.usdo9,usd7m.usd5g,usd7m.usd6g,usd7m.usd7g,usd7m.usd8g,usd7m.usd9g,usd7m.usd0h,usd7m.usd1h,usd7m.usd2h,usd7m.usd6b,usd7m.usd9b,usd7m.usd0c,usd7m.usd3h,usd7m.usd4h,usd7m.usd5h,usd7m.usd6h,usd7m.usd7h,usd7m.usde80,usd7m.usd8h,usd7m.usd9h,usd7m.usdb55,usd7m.usd0i,usd7m.usd2g,usd7m.usd1i,usd7m.usdb99,true,usd7m.usdr8,usd7m.usdr9,usd7m.usde81,usd7m.usde82,usd7m.usd3i,usd7m.usd4i,usd7m.usdf17,usd7m.usde83,usd7m.usde85,usd7m.usd5i,usd7m.usd6i,usd7m.usd7i,usd7m.usde86,usd7m.usd8i,usd7m.usde87,usd7m.usd9i,usd7m.usd0j,usd7m.usd1j,usd7m.usd2j,usd7m.usde88,usd7m.usd3j,usd7m.usd4j,usd7m.usd5j,usd7m.usd6j,usd7m.usd7j,usd7m.usde89,usd7m.usde90,usd7m.usde91,usd7m.usde92,usd7m.usde93,usd7m.usd8j,usd7m.usd9j,usd7m.usd0k,usd7m.usd1k,usd7m.usd2k,usd7m.usd3k,usd7m.usd4k,usd7m.usd5k,usd7m.usd6k,usd7m.usd7k); usdb3='<span style="color:#009900;font-weight:bold">'+usd8m.usd9i+'</span>'; if (!usd1c) { usdg1=usdj2(usde2); usdg2=usdj2(usde3); usdg3=usdj2(usde4); usdg5=usdj2(usde6); usdg7=usdj2(usde8); } } UltimateSpell.prototype.usd0m=function() { usdg1.innerHTML=this.usdf30()+((this.usdj0) ? usd2n+usdb3 : ''); usdg2.innerHTML=''; usdg3.value=''; if (window.usdg4) { usdg4.options.length=0; } usd1b(true,true); }; function usdf31(usd3e) { usd8m.usdt6(usd3e); } function usdf32(usd3e) { var usdt0=usd8m.usdi0[usd8m.usdi1-1]; var usdr6=usd8m.usdi5+((usd3e == usde58) ? usdt0.usde96[0].usde99 : (usd3e == usd7c) ? usdt0.usdr4 : 0); var s=usd8m.usdi3[usd8m.usdi4].usdl2; var usdu8=(usd3e == usd7c && usdt0.usdr2 == usdb0 && usdk9(s.charAt(usdr6-1))) ? -1 : 0; var usdu9=usdg3.value; var usdv0=((usd3e == usde58) ? usdt0.usde96[0].usdf10-usdt0.usde96[0].usde99 : (usd3e == usd7c) ? usdt0.usdn1.length : 0); var usdv1=usdu9.length-usdv0+usdu8; usd8m.usdi6 += usdv1; for (var i=usd8m.usdi1,usdn3=usd8m.usdi0.length; i < usdn3; i++) { if (usd3e == usde58) { for (var j=0,usdn4=usd8m.usdi0[i].usde96.length; j < usdn4; j++) { usd8m.usdi0[i].usde96[j].usde99 += usdv1; usd8m.usdi0[i].usde96[j].usdf10 += usdv1; } } else { usd8m.usdi0[i].usdr4 += usdv1; } } s=s.substring(0,usdr6+usdu8)+usdu9+s.substring(usdr6+usdv0); usd8m.usdi3[usd8m.usdi4].usdl2=s; usd8m.usdu3(); usd8m.usdt6(usd3e); } function usdf33(usd3e,s) { for (var i=0,usdn3=usdi9.length; i < usdn3; i++) { usdn5(usdh7.usdi9,usdi9[i]); } if (usd8m.usdj0) { if (usd3e == usde59) { var usdf14=usd7m.usdf14; var usdb92=usdb93(usdf14,usdh7); if (usd7m.usd9h && typeof (usdh7.UltimateSpellAsYouTypes[usdf14]) != 'undefined' && usdb92 == null) { var usdf34=usdh7.UltimateSpellAsYouTypes[usdf14]; var usd3z=usdf34.usd4z(usdf34.usd5z); usdf34.usd6z(usd3z); usdf34.usd1w(usd3z,s,0,false);  usdf34.usda16(); } else { usd7m.usdf13(s); } } else { for (var i=0,usdn3=usd8m.usdi3.length; i < usdn3; i++) { if (usd8m.usdi3[i].usdn9) { usd8m.usdi3[i].usdn9.text=usd8m.usdi3[i].usdl2; } else { usdl1(usd8m.usdi3[i].usdk8,usd8m.usdi3[i].usdl2,usdh7); } } if (usd7m.usd9h) { usd7m.usd2m(); } } } if (usd3e != usde59 && usdp5(usd8m.usd3i) && usdh7.__doPostBack) { if (typeof (usdh7.UltimateEditors) != 'undefined') { for (var i=0,usdn3=usd8m.usdi3.length; i < usdn3; i++) { var usdk8=usd8m.usdi3[i].usdk8; var usdb92=usdb93(usdk8,usdh7); if (usdb92 && typeof (usdb92.SetEditorHtmlBeforePostBack) != 'undefined') { usdb92.SetEditorHtmlBeforePostBack(); } } } usdh7.__doPostBack(usd8m.usdb18,usd8m.usdj0); } usdu4(); } function HandleUSDCancelClick() { usdu4(); } 