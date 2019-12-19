const onDataLoaded = (data) => {
        //year
        const dataA3 = data.feed.entry.find((entry) => entry.title.$t == 'A3').content.$t
        //month
        const dataB3 = data.feed.entry.find((entry) => entry.title.$t == 'B3').content.$t
        //day
        const dataC3 = data.feed.entry.find((entry) => entry.title.$t == 'C3').content.$t
        //hour
        const dataD3 = data.feed.entry.find((entry) => entry.title.$t == 'D3').content.$t

        if(parseInt(dataD3) <= 12){
            document.getElementById('greeting').innerHTML = "Good Morning!"
            document.getElementById('greetingImg').src = 'img/sun.png'
        }
        else if(parseInt(dataD3) > 12 && parseInt(dataD3) <= 18){
            document.getElementById('greeting').innerHTML = "Good Afternoon!"
            document.getElementById('greetingImg').src = 'img/afternoon.png'
        }
        else if(parseInt(dataD3) > 18 && parseInt(dataD3) <= 24){
            document.getElementById('greeting').innerHTML = "Good Night!"
            document.getElementById('greetingImg').src = 'img/night.png'
        }

        document.getElementById('today').innerHTML ="Today is " + dataA3 + "-" + dataB3 + "-" + dataC3
        if(parseInt(dataD3 <= 12))
        {
            document.getElementById('time').innerHTML ='This time is ' + dataD3 + "AM."   
        }
        else{
            document.getElementById('time').innerHTML ='This time is ' + (dataD3 - 12) + "PM."
        }
        



		// 미세먼지
		const dataE3 = data.feed.entry.find((entry) => entry.title.$t == 'E3').content.$t
        document.getElementById('dust').innerHTML = "Current finedust is " + dataE3
    
        if(parseInt(dataE3) >= 0 && parseInt(dataE3) <= 30 )
        {
            document.getElementById('microImg').src = 'img/lev1.png'
            document.getElementById('microLevel').innerHTML = '"Good"'  
        }
        else if(parseInt(dataE3) >= 31 && parseInt(dataE3) <= 80)
        {
            document.getElementById('microImg').src = 'img/lev2.png'
            document.getElementById('microLevel').innerHTML = '"Fair"'    
        }
        else if(parseInt(dataE3) >= 81 && parseInt(dataE3) <= 120)
        {
            document.getElementById('microImg').src = 'img/lev3.png'
            document.getElementById('microLevel').innerHTML = '"Poor"'     
        }
        else if(parseInt(dataE3) >= 121 && parseInt(dataE3) <= 200)
        {
            document.getElementById('microImg').src = 'img/lev4.png'
            document.getElementById('microLevel').innerHTML = '"Fair Poor"'    
        }
        else if(parseInt(dataE3) >= 201 )
        {
            document.getElementById('microImg').src = 'img/lev5.png'
            document.getElementById('microLevel').innerHTML = '"Very Poor"'    
        }

		// 온도
		const dataG3 = data.feed.entry.find((entry) => entry.title.$t == 'G3').content.$t
		document.getElementById('temper').innerHTML = "Temperature: " + dataG3

		// 습도
		const dataH3 = data.feed.entry.find((entry) => entry.title.$t == 'H3').content.$t
		document.getElementById('humidity').innerHTML = "Humidity: " + dataH3

		// 하늘상태
		const dataI3 = data.feed.entry.find((entry) => entry.title.$t == 'I3').content.$t
		var dataI3text
		if (parseInt(dataI3) == 1) {
			dataI3text = "Sunny"
		} else if (parseInt(dataI3) == 2) {
			dataI3text = "little cloudy"
		} else if (parseInt(dataI3) == 3) {
			dataI3text = "cloudy"
		} else if (parseInt(dataI3) == 4) {
			dataI3text = "darkness"
		}
		document.getElementById('sky').innerHTML = "Sky status: " + dataI3text

		// 강수량
		const dataJ3 = data.feed.entry.find((entry) => entry.title.$t == 'J3').content.$t
		document.getElementById('rain').innerHTML = "rainny: " + dataJ3

		// 풍향
		//const dataK3 = data.feed.entry.find((entry) => entry.title.$t == 'K3').content.$t
		//document.getElementById('wind1').innerHTML = "현재 풍향: " + dataK3

		// 풍속
		//const dataL3 = data.feed.entry.find((entry) => entry.title.$t == 'L3').content.$t
        //document.getElementById('wind2').innerHTML = "현재 풍속: " + dataL3
        
	  }