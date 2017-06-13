////////////////////////////////////////////////////////////
// This software is solely the property of Karamasoft LLC. /
//   Copyright 2008 Karamasoft LLC. All rights reserved.   /
//                  www.karamasoft.com                     /
////////////////////////////////////////////////////////////

// IMPORTANT: For the following emoticon arrays, code array represents the emoticon code, name array represents emoticon description tooltip, and file name array represents emoticon file name.
// When you add a new emoticon, you need to add all emoticon code, name and file name into their respective array locations so that they can match.
var ueEmoticonCodeArr = new Array(":)",":D",";)",":-O",":P","(H)",":-@",":S",":$",":(",":'(",":|","8o|","8-|","+o(","<:o)","|-)","*-)",":-#",":-*","^o)","8-)","(A)","(6)",":^)","(Y)","(N)","(L)","(U)","(B)","(S)","(*)","(@)","(&)","({)","(})","(K)","(F)","(W)","(O)","(G)","(^)","(P)","(I)","(C)","(T)","(mp)","(au)","(ap)","(co)","(mo)","(~)","(8)","(pi)","(so)","(E)","(Z)","(X)","(ip)","(um)");
var ueEmoticonNameArr = new Array("Smile","Open-mouthed","Wink","Surprised","Tongue out","Hot","Angry","Confused","Embarrassed","Sad","Crying","Disappointed","Baring teeth","Nerd","Sick","Party","Sleepy","Thinking","Don't tell anyone","Secret telling","Sarcastic","Eye-rolling","Angel","Devil","I don't know","Thumbs up","Thumbs down","Red heart","Broken heart","Beer mug","Sleeping half-moon","Star","Cat face","Dog face","Guy hug","Girl hug","Red lips","Red rose","Wilted rose","Clock","Gift with a bow","Birthday cake","Camera","Light bulb","Coffee cup","Telephone receiver","Mobile Phone","Auto","Airplane","Computer","Money","Filmstrip","Note","Pizza","Soccer ball","E-mail","Boy","Girl","Island with a palm tree","Umbrella");
var ueEmoticonFileNameArr = new Array("Smile.gif","OpenMouthed.gif","Wink.gif","Surprised.gif","TongueOut.gif","Hot.gif","Angry.gif","Confused.gif","Embarrassed.gif","Sad.gif","Crying.gif","Disappointed.gif","BaringTeeth.gif","Nerd.gif","Sick.gif","Party.gif","Sleepy.gif","Thinking.gif","DontTellAnyone.gif","SecretTelling.gif","Sarcastic.gif","EyeRolling.gif","Angel.gif","Devil.gif","IDontKnow.gif","ThumbsUp.gif","ThumbsDown.gif","RedHeart.gif","BrokenHeart.gif","BeerMug.gif","SleepingHalfMoon.gif","Star.gif","CatFace.gif","DogFace.gif","GuyHug.gif","GirlHug.gif","RedLips.gif","RedRose.gif","WiltedRose.gif","Clock.gif","GiftWithABow.gif","BirthdayCake.gif","Camera.gif","LightBulb.gif","CoffeeCup.gif","TelephoneReceiver.gif","MobilePhone.gif","Auto.gif","Airplane.gif","Computer.gif","Money.gif","Filmstrip.gif","Note.gif","Pizza.gif","SoccerBall.gif","Email.gif","Boy.gif","Girl.gif","IslandWithAPalmTree.gif","Umbrella.gif");

// Notify ASP.NET AJAX Framework that the script is loaded
if (typeof(Sys) != 'undefined' && typeof(Sys.Application) != 'undefined') {
	Sys.Application.notifyScriptLoaded();
}
