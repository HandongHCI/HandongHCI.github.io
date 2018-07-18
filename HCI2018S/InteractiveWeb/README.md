[← go back to the list](https://HandongHCI.github.io/HCI2018S)

# Interactive Media Art

<img src="img/Kinect.jpg" height="200"><img src="img/ScratchX.jpg" height="200"><img src="img/skeleton.jpg" height="200">

#### Members
- 김주은, 이예담, 정지원, 박예은, Ruth Nvoni, Smith Childreni



<br><br><br>
## Introduction
“SHOW ME THE WEATHER”는 날씨를 시각적으로 보여주는 웹사이트로, 사용자가 날씨에 대한 정보를 읽지 않더라도 그림, 애니메이션 등으로 표현하여 직관적으로 알 수 있게 한다. 일반적인 날씨 알림 사이트/앱에서는 날씨를 숫자형 데이터와 간단한 기호로 알려준다. 예를 들어, 풍속  “7m/s, → ” 와 같은 숫자와 방향기호를 보고 바람의 세기를 추측하기 쉽지 않다. 그래서 우리 팀은 날씨 데이터를 알려주는것 뿐만 아니라 시각적으로 보여줌으로써 사용자가 날씨 정보를 쉽게 인식할 수 있는 웹사이트를 만들기로 기획 하였다. 아직은 개발 단계인 관계로 바람에 초점을 두어 개발하였다.



<br><br><br>
## 1. Research
웹사이트 구축의 첫 번째 단계는 자신의 사이트에 대해 어떤 것을 원하는지(그리고 원하지 않는지)를 확인하기 위해 최대한 많은 정보를 수집하는 것이었다. 다양한 interactive website, 지도 관련 사이트 그리고 경쟁업체들의 사이트(날씨 관련 사이트)들을 살펴보고 친구 및 교수님으로부터 피드백을 얻어 이러한 작업을 수행할 수 있었다.

### 1-1. 용도
SHOW ME THE WEATHER 사이트의 용도는 직관적으로 알기 어려운 데이터를 시각화하여 사용자로 하여금 알기 쉽게 하는 것이다. 또한 재미의 요소를 더하여 사용자와 상호작용하는 데에 목적이 있다. SHOW ME THE WEATHER에서 제공하는 것은 캐릭터를 이용한 날씨(바람) 정보이다.

### 1-2. 목표
방문자들이 SHOW ME THE WEATHER 사이트를 방문할 때 바람 데이터와 시각화된 캐릭터 애니메이션을 동시에 확인함으로써 실시간 바람 상황을 직관적으로 파악하는 것이 목표이다.

### 1-3. 대상
실시간 날씨와 바람 상황을 궁금해하는 전 연령층 

### 1-4. 콘텐츠
특정 지역에 대한 날씨 정보를 알고 싶은 사용자가 캐릭터 애니메이션을 통해 원하는 정보를 쉽게 확인할 수 있다. 



<br><br><br>
## 2. Planning
### 2-1. 웹페이지 이름
우리 팀은 사용자가 정보나 데이터를 쉽게 인식 할 수있는 웹 사이트를 만들고자 했다. 우리의 목표는 데이터를 알리는 것만이 아니라 사용자가 쉽고 빠르게 이해할 수 있도록 데이터를 표시하는 것이였다. 그래서, 우리의 웹 사이트 이름은 ‘Show me the Weather’로 정하였다. 우리는 목적은 단순히 날씨를 알려주는 것뿐만 아니라 사용자가 쉽게 받아 들일 수 있도록 날씨를 시각화해서 보여주고, 사용자가 사이트를 계속해서 사용하도록 흥미롭게 사이트를 만드는 것이였다. 우리 팀은 아직 개발 단계이기 때문에 바람 데이터에 집중하기로 기획했다.

![](img/1.png)

### 2-2. 팀 분배
- Design: 정지원, 박예은
- Map Development: Ruth, Smith
- Web Desvelopment: 김주은, 이예담


## 3. Design
### 3-1. 풍속에 따른 데이터 시각화
풍속에 따라 바람을 5단계로 나누고, 단계에 따른 이름, 코멘트, 특징 정하기

단계 | 풍속 | 바람 이름 | 코멘트 | 특징
---- | ---- | -------- | ----- | -----
1 | 0 ~ 1.5 m/s | Breeze | "There is no wind today." | As the most windy wind, the sea surface has ripples in the form of fish scales.
2 | 1.6 ~ 5.4 m/s | Gentle wind | "A good day for a picnic" | The wind feels in your face, and the leaves falter. Also, the weather vane moves, and the sea surface has a ripple effect.
3 | 5.5 ~ 10.7 m/s | Biting Wind | "Oh! Today I give up my hair." | Trees with small leaf begins to shake, and a small wave of water is created in the lake.
4 | 10.8 ~ 17.1 m/s | Strong Wind | "I should cancel everything today." | The whole big tree shakes, and it is hard to walk toward the wind. At sea, the waves get rougher and the trough breaks
5 | 17.2 m/s 이상 | Typhoon | "If you want to fly, go outside."" | There is a slight damage to the building, such as a chimney cap and slate. At sea, the storm rises and the water spirals up.

단계에 따른 캐릭터 정하기: 스케치, vector graphic, 

위의 단계에서 만든 SVG 파일을 일러스트(Illustrator CC)를 사용하여 SVG 파일의 백터를 움직여 각 캐릭터의 행동을 수정하였다. 수정된 파일들을 연결하여 애니메이션을 만들 수 있도록 하였다.






### Demo

### Source Code



<br><br><br>
[← go back to the list](https://HandongHCI.github.io/HCI2018S)
