////////////////////////////////////////////////////////////
// This software is solely the property of Karamasoft LLC. /
//   Copyright 2008 Karamasoft LLC. All rights reserved.   /
//                  www.karamasoft.com                     /
////////////////////////////////////////////////////////////

var ueSymbolCountPerRow = 14;	// Symbol count per row
var ueSymbolCodeStart = 128;	// ASCII code for symbol code start
var ueSymbolCodeEnd = 256;	// ASCII code for symbol code end
var ueSymbolCodeExceptions = '129,141,143,144,157,160,173';	// Symbol code exceptions

// Return symbol array to populate the symbol popup
function GetSymbolArray() {
	var symbolArr = new Array(ueSymbolCodeEnd - ueSymbolCodeStart - ueSymbolCodeExceptions.split(',').length);
	for (var i = ueSymbolCodeStart, j = 0; i < ueSymbolCodeEnd; i++) {
		if (ueSymbolCodeExceptions.indexOf(i) == -1) {
			symbolArr[j++] = '&#' + i + ';';
		}
	}

	// Additional arrow symbols
	symbolArr[j++] = '&#8592;';
	symbolArr[j++] = '&#8593;';
	symbolArr[j++] = '&#8594;';
	symbolArr[j++] = '&#8595;';

	return symbolArr;
}

// Notify ASP.NET AJAX Framework that the script is loaded
if (typeof(Sys) != 'undefined' && typeof(Sys.Application) != 'undefined') {
	Sys.Application.notifyScriptLoaded();
}
