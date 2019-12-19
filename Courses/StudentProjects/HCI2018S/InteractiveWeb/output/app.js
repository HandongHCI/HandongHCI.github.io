var menu_status;
menu_status = 0;
var _intervalId  ;

var main = function () {  
    // HOME PAGE
    consoleText(['SHOW ME THE WEATHER'], 'text', ['#f9ed68']);

    function consoleText(words, id, colors) {
        if (colors === undefined) colors = ['#fff'];
        var visible = true;
        var con = document.getElementById('console');
        var letterCount = 1;
        var x = 1;
        var waiting = false;
        var target = document.getElementById(id)
        target.setAttribute('style', 'color:' + colors[0])

        window.setInterval(function () {

            if (letterCount === 0 && waiting === false) {
                waiting = true;
                target.innerHTML = words[0].substring(0, letterCount)
                window.setTimeout(function () {
                    var usedColor = colors.shift();
                    colors.push(usedColor);
                    var usedWord = words.shift();
                    words.push(usedWord);
                    x = 1;
                    target.setAttribute('style', 'color:' + colors[0])
                    letterCount += x;
                    waiting = false;
                }, 200)
            } else if (letterCount === words[0].length + 1 && waiting === false) {
                waiting = true;
                window.setTimeout(function () {
                    x = -1;
                    letterCount += x;
                    waiting = false;
                }, 200)
            } else if (waiting === false) {
                target.innerHTML = words[0].substring(0, letterCount)
                letterCount += x;
            }
        }, 120)

        window.setInterval(function () {
            if (visible === true) {
                con.className = 'console-underscore hidden'
                visible = false;

            } else {
                con.className = 'console-underscore'

                visible = true;
            }
        }, 1000)
    }

    // Hide objects
    $("#mainBox").hide();
    $("#tempContentBox").hide();
    $("#windContentBox").hide();
    $("#microContentBox").hide();
    $("#firstImageBox").hide();
    $("#secondImageBox").hide();
    $("#thridImageBox").hide();
    $("#fourthImageBox").hide();
    $("#fifthImageBox").hide();
    $("#map2").hide();
    $("#map3").hide();
    $("#textBox").hide();
    $("#windInfoBox").hide();
    $("#tempInfoBox").hide();
    $("#microInfoBox").hide();
    $("#greeting").hide();
    $("#greetingImg").hide();
    $("#today").hide();
    $("#microTitle").hide();
    $("#microImg").hide();
    $("#microLevel").hide();
    //$("#infoBox").hide();
    currentStep = 1;

    // Click text in homepage
    $("#text").click(function () {
        $(".home").fadeOut(500);
        $("#mainBox").delay(500).fadeIn(500);
    });

    // Click GB
    $("#GB").click(function(){
      $("#map3").hide();
      $("#map1").fadeOut(500);
      $("#map2").delay(500);
      $("#map2").fadeIn(500);
      currentStep = 2;
    });

    // Click Pohang
    $("#Pohang").click(function(){
        $("#map1").hide();
        $("#map2").fadeOut(500);
        currentStep = 3;
    });

      // go back function
    $("#btnGoBack").click(function(){
        if (currentStep == 2) {
          $("#map3").hide();
          $("#map2").fadeOut(500);
          $("#map1").delay(500);
          $("#map1").fadeIn(500);
          currentStep = 1;
        };
        if (currentStep == 3) {
          $("#map1").hide();
          $("#map3").fadeOut(500);
          $("#map2").delay(500);
          $("#map2").fadeIn(500);
          currentStep = 2;
        };
    });



    $('#Pohang').click(function() {
    $('.menu').animate({left: '30px'}, 700);
    $('#mapBox').fadeOut(500);
    $("#btnGoBack").fadeOut(500);
    $("#windContentBox").delay(800).fadeIn(800);
  });
  
    $('.back').click(function() {
    $('.menu').animate({
       left: '-300px'
      }, 200);
    $("#windContentBox").fadeOut(500);
    $("#tempContentBox").fadeOut(500);
    $("#microContentBox").fadeOut(500);
    $("#firstImageBox").hide();
    $("#secondImageBox").hide();
    $("#thridImageBox").hide();
    $("#fourthImageBox").hide();
    $("#fifthImageBox").hide();
    $("#textBox").hide();
    $("#windInfoBox").hide();
    $("#tempInfoBox").hide();
    $("#microInfoBox").hide();
    $("#greeting").hide();
    $("#greetingImg").hide();
    $("#today").hide();
    $("#microTitle").hide();
    $("#microImg").hide();
    $("#microLevel").hide();
    $('#mapBox').delay(500).fadeIn(500);
    $("#btnGoBack").delay(500).fadeIn(500);
    $("#map2").delay(500).fadeIn(500);
    menu_status = 0;
  });
};

function reply_wind()
{
    if( menu_status != 2 ){
        $("#tempContentBox").hide();
        $("#microContentBox").hide();
        $("#windContentBox").show();

        $("#firstImageBox").hide();
        $("#secondImageBox").hide();
        $("#thridImageBox").hide();
        $("#fourthImageBox").hide();
        $("#fifthImageBox").hide();
        $(".img").hide();
    
        $("#greeting").hide();
        $("#greetingImg").hide();
        $("#today").hide();

        $("#microTitle").hide();
        $("#microImg").hide();
        $("#microLevel").hide();


        var windSpeed =  Math.floor((Math.random() * 20));
        //var windSpeed = 130;
        //10 35 70 110 130
        //var _intervalId;




        if (windSpeed >= 0 && windSpeed < 1.6) {
            $("#firstImageBox").show();
            $('.img').hide();
            function fadeInLastImg() {
                var backImg = $('#firstImageBox img:first');
                $('.img').hide();
                $('#firstImageBox').append(backImg);
                backImg.show();
            };

            _intervalId = setInterval(function () {
                fadeInLastImg();
            }, 200);
            $("#p1").html('Breeze');
            $("#p2").html('"There is no wind today."');
            $("#p3").html('Description: <br> As the most windy wind, the sea surface has ripples in the form of fish scales.');


        } else if (windSpeed >= 1.6 && windSpeed < 5.5) {
            $("#secondImageBox").show();
            $('.img').hide();
            function fadeInLastImg() {
                var backImg = $('#secondImageBox img:first');
                $('.img').hide();
                $('#secondImageBox').append(backImg);
                backImg.show();
            };

            _intervalId = setInterval(function () {
                fadeInLastImg();
            }, 200);
            $("#p1").html('Gentle Wind');
            $("#p2").html('"A good day for a picnic."');
            $("#p3").html('Description: <br> The wind feels in your face, and the leaves falter. Also, the weather vane moves, and the sea surface has a ripple effect.');

        } else if (windSpeed >= 5.5 && windSpeed < 10.8) {
            $("#thridImageBox").show();
            $('.img').hide();
            function fadeInLastImg() {
                var backImg = $('#thridImageBox img:first');
                $('.img').hide();
                $('#thridImageBox').append(backImg);
                backImg.show();
            };

            _intervalId = setInterval(function () {
                fadeInLastImg();
            }, 200);
            $("#p1").html('Biting Wind');
            $("#p2").html('"Oh! Today I give up my hair."');
            $("#p3").html('Description: <br> Trees with small leaf begins to shake, and a small wave of water is created in the lake.');
        

        } else if (windSpeed >= 10.8 && windSpeed < 17.2) {
            $("#fourthImageBox").show();
            $('.img').hide();
            function fadeInLastImg() {
                var backImg = $('#fourthImageBox img:first');
                $('.img').hide();
                $('#fourthImageBox').append(backImg);
                backImg.show();
            };

            _intervalId = setInterval(function () {
                fadeInLastImg();
            }, 200);
            $("#p1").html('Strong Wind');
            $("#p2").html('"I should cancel everything today."');
            $("#p3").html('Description: <br>  The whole big tree shakes, and it is hard to walk toward the wind. At sea, the waves get rougher and the trough breaks.');
        
        } else if (windSpeed >= 17.2) {
            $("#fifthImageBox").show();
            $('.img').hide();
            function fadeInLastImg() {
                var backImg = $('#fifthImageBox img:first');
                $('.img').hide();
                $('#fifthImageBox').append(backImg);
                backImg.show();
            };

            _intervalId = setInterval(function () {
                fadeInLastImg();
            }, 200);
            $("#p1").html('Typhoon');
            $("#p2").html('"If you want to fly, go outside."');
            $("#p3").html('Description: <br>  There is a slight damage to the building, such as a chimney cap and slate. At sea, the storm rises and the water spirals up.');
        }
        
        $("#textBox").html('Wind Speed is ' + windSpeed + ' m/s.');
        $("#textBox").delay(500).fadeIn(1000);
        //$("#windInfoBox").delay(1500);$("#windInfoBox").fadeIn(1000);
        setTimeout(function(){$("#windInfoBox").delay(1500);$("#windInfoBox").fadeIn(1000)}, 1000);
        //$("#windInfoBox").delay(1500);$("#windInfoBox").fadeIn(1000);
        
        menu_status = 2;
    }
};


function reply_temp() {
    if (menu_status != 1){
    $("#windContentBox").fadeOut(500);
    $("#microContentBox").fadeOut(500);
    $("#tempContentBox").delay(500).fadeIn(500);
    $("#greeting").delay(1000).slideDown("slow");
    setTimeout(function(){$("#greetingImg").show()},2000);
    setTimeout(function(){$("#today").delay(500).fadeIn(500)}, 2000);

    $("#microTitle").hide();
    $("#microImg").hide();
    $("#microLevel").hide();
    function startTime() {
        var today = new Date();
        var h = today.getHours();
        var m = today.getMinutes();
        var s = today.getSeconds();
        m = checkTime(m);
        s = checkTime(s);
        document.getElementById('clock').innerHTML = h + ":" + m + ":" + s;
        var t = setTimeout(startTime(), 500);
    }
    
    function checkTime(i) {
        if (i < 10) {i = "0" + i}; // 숫자가 10보다 작을 경우 앞에 0을 붙여줌
        return i;
    }

    setTimeout(function(){$("#tempInfoBox").delay(1500);$("#tempInfoBox").fadeIn(1000)}, 3000);

    //$("#greetingImg").delay(500).fadeIn(500);
    //$("#today").delay(500).fadeIn(500);



    menu_status = 1;
    

    }
    clearInterval(_intervalId);
    $("#tempInfoBox").delay(800).fadeIn(800);
    
};

function reply_micro() {
    if (menu_status != 3){
    $("#windContentBox").fadeOut(500);
    $("#tempContentBox").fadeOut(500);
    $("#microContentBox").delay(500).fadeIn(500);
    $("#greeting").hide();
    $("#greetingImg").hide();
    $("#today").hide();
    
    $("#microTitle").delay(1000).slideDown("slow");
    setTimeout(function(){$("#microImg").show()},2000);
    setTimeout(function(){$("#microLevel").delay(500).fadeIn(500)}, 2000);   
    
    menu_status = 3;
    }
    clearInterval(_intervalId);
    $("#microInfoBox").delay(800).fadeIn(800);
    
};

var currentStep = 0;
$(document).ready(main);


$(".hover").mouseleave(
  function() {
    $(this).removeClass("hover");
  }
);



