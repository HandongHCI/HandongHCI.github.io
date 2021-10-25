var winObject = null;

function sendPush(jikbun, list) {
    var strURL = "http://smart.handong.edu/mobile/push/send/" + window.btoa(jikbun);

    var settings ='toolbar=no,directories=0,status=no,menubar=0,scrollbars=no,resizable=no,location=no,fullscreen=no,height=600,width=400,left=0,top=0';
    winObject = window.open(strURL, "", settings);
    winObject.onload = function(event) {
        winObject.postMessage(list, "*");
    };
}