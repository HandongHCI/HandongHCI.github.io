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
-----|-----|----------|--------|------
1 | 0 ~ 1.5 m/s | Breeze | There is no wind today. | As the most windy wind, the sea surface has ripples in the form of fish scales.
2 | 1.6 ~ 5.4 m/s | Gentle wind | A good day for a picnic | The wind feels in your face, and the leaves falter. Also, the weather vane moves, and the sea surface has a ripple effect.
3 | 5.5 ~ 10.7 m/s | Biting Wind | Oh! Today I give up my hair. | Trees with small leaf begins to shake, and a small wave of water is created in the lake.
4 | 10.8 ~ 17.1 m/s | Strong Wind | I should cancel everything today. | The whole big tree shakes, and it is hard to walk toward the wind. At sea, the waves get rougher and the trough breaks
5 | 17.2 m/s 이상 | Typhoon | If you want to fly, go outside. | There is a slight damage to the building, such as a chimney cap and slate. At sea, the storm rises and the water spirals up.
2. ②	5 단계에 따라 바람의 이름, 코멘트, 특징 그리고 캐릭터 정하기








동화 속에서 앨리스가 토끼를 만나는 장면을 빠르게 움직이는 동화 속의 토끼를 사용자가 손으로 잡는 것으로 설정하였다.
1. npc 토끼: 진행될 게임의 방식을 설명한다
2. 토끼의 x,y 좌표를 0.6 초 간격으로 화면 이미지에 맞게 랜덤으로 설정한다
3. 토끼가 움직일 때 마다 게임적인 흥미 요소를 추가시키기 위해 효과음을 추가
4. 토끼의 이미지에 사용자의 손이 닿으면 토끼 이미지가 멈추고 게임 성공을 알리며 다음 화면으로 전환

![화면2](img/photo3.png)

#### 장면 2
동화 속 엉망진창 다과회 장면을 모티브로 하여 제시되는 음계와 똑같이 사용자가 손으로 컵 이미지를 터치하여 연주하면 게임에 성공하도록 설정하였다.
1. npc 모자장수: 게임 진행 방식을 설명
2. 사용자가 동일하게 연주할 음악 과제 들려줌
3. 모자장수가 음악이 끝났음을 알리고 사용자의 게임 시작을 유도
4. 사용자의 손이 각 각 컵 이미지에 닿을 때마다 지정된 음계가 들림
5. 음계가 맞으면 옆 Music List에 음계가 표시되고, 틀리면 모자장수로 하여금 틀린 음계라는 것을 말해주고 사용자의 재시도를 유도
6. 모든 음계가 맞을 시 모자장수는 게임 성공을 알리며 다음 장면으로 전환

![화면3](img/photo4.png)

#### 장면 3
붉은 여왕과 병사들이 쏘는 화살을 앨리스가 완벽히 피하면 최종적으로 게임에 승리하도록 설정하였다.
1. npc 붉은 여왕: 붉은 여왕이 게임의 마지막 단계임을 알리며 게임 방식 설명
2. 화살이미지가 랜덤의 위치에서 glide 된다
3. 화살은 총 20개가 떨어지며 사용자(앨리스)에게는 3번의 기회가 주어진다
4. 앨리스 이미지 위치는 사용자의 움직임에 따라 달라지며 화살이미지가 앨리스 이미지에 닿았을 경우 기회를 표시하는 Life가 1씩 감소된다
5. 화살 20개를 다 피하기 전에 3번의 기회를 모두 써버리면 게임의 재시도를 위한 창이 표시
6. 사용자의 손 이미지를 통해 replay 버튼을 누르게 되면 게임은 재시작된다
7. 화살 20개를 피하게 되면 효과음과 함께 붉은 여왕이 게임의 성공을 알리며 엔딩 장면으로 전환된다

![화면4](img/photo5.png)

#### Ending
모든 게임에 성공하였을 때 앨리스가 꿈에서 깨는 장면을 통해 엔딩을 보여준다.

![화면5](img/photo6.png)

#### Demo
<div style="position: relative; padding-bottom: 56.25%; padding-top: 25px; height: 0;"><iframe src="https://www.youtube.com/embed/tAQJ2TnOeU8" frameborder="0" allow="autoplay; encrypted-media" allowfullscreen style="position: absolute; top: 0; left: 0; width: 100%; height: 100%;"></iframe></div>



<br><br><br>
## 주제2: 영화 홍보 게임: 아이언맨
### 아이디어 선정 과정
키넥트 연결을 통해 어떤 흥미로운 주제를 만들어 낼 수 있을 것인가에 대해 논의하였고, 영화 캐릭터가 직접 되어 보는 프로젝트를 진해하기로 결정하였다. 기존의 정적인 홍보 포스터의 비해 사용자의 움직임에 따라 반응하고 움직이는 포스터를 제작하고 게임적 요소를 첨가하여 포스터 및 영화에 관심을 가지도록 한다. 이후 자연스럽게 영화 예고편 등을 틀어 준다면 자연스럽게 효과적으로 영화를 홍보할 수있다.

### 주요 내용
사용자의 관절을 인식하고 이에 맞춰 팔과 다리, 얼굴 그리고 몸의 움직임에 맞춰 아이언맨이 움직인다. 사용자가 직접 아이언맨이 되는 체험인데, 아이언맨의 손이 인피니티 스톤에 닿으면 스톤이 타노스로 바뀌며 손에서 빔 효과가 나온다. 영화 상 악당에 해당하는 타노스를 공격할 수 있으며 그 후에 자연스레 영화 예고편으로 넘어간다.

![화면1](img/photo7.gif)

#### Demo
<div style="position: relative; padding-bottom: 56.25%; padding-top: 25px; height: 0;"><iframe src="https://www.youtube.com/embed/-siTn7Pl7wc" frameborder="0" allow="autoplay; encrypted-media" allowfullscreen style="position: absolute; top: 0; left: 0; width: 100%; height: 100%;"></iframe></div>



<br><br><br>
## 주제3: 공익 광고 게임: 북한이탈주민 인남이의 상처되는 말 피하기
### 아이디어 선정 과정
키넥트 연결을 통해 흥미로운 주제도 좋지만 사회적인 메시지를 전달할 수 있는 도구로도 활용할 수 있다는 것을 보여주고 싶었다. 우리는 여러 사회적 문제 가운데 탈북민들의 아픔을 전달하기로 하였는데, 무심코 던지는 우리들의 말이 그들에게 큰 상처가 된다는 것을 표현하고 사람들에게 알려주고 싶었다. 

### 주요 내용
탈북민 캐릭터 ‘인남’이를 만들고 탈북민의 아픈 이야기를 들려준다. 그 후에 화면이 전환되어 탈북민에게 상처를 줄 수 있는 말들이 내려오는데 화면 인식을 통해 인남이가 된 사용자는 상처의 말들을 피할 수 있지만 3번 째 맞는 순간 화면이 바뀌면서 아픔에 대해 들려준다. 하지만 인남이는 아픔에 굴하는 것에 그치지 않고, 희망찬 화면으로 전환해  희망의 메시지도 전달하며 마무리한다.

![화면1](img/photo8.gif)
인남이에게 떨어지는 상처의 말 피하기

![화면2](img/photo9.gif)
인남이의 아픔에 공감하기

![화면3](img/photo10.gif)
인남이의 희망찬 앞날을 위한 사랑의 메시지

#### Demo
<div style="position: relative; padding-bottom: 56.25%; padding-top: 25px; height: 0;"><iframe src="https://www.youtube.com/embed/XQY1y7qoQhw" frameborder="0" allow="autoplay; encrypted-media" allowfullscreen style="position: absolute; top: 0; left: 0; width: 100%; height: 100%;"></iframe></div>



<br><br><br>
## 구현 방법: Kinect 2.0과 [ScratchX](https://scratchx.org/)를 이용한 미디어아트 제작
### 설치 (윈도우 PC인 경우)
- [Kinect for Windows SDK v1.8](http://microsoft.com/en-us/download/details.aspx?id=40278)
- [Kinect v2 To ScratchX 3](https://github.com/stephenhowell/kinect2scratch)

![ScratchX 화면](img/photo1.gif)

### 구현 원리
- Kinect는 인체의 주요 관절의 3차원 좌표를 파악
- 여러 관절 좌표들 중 일부(예: 엘리스 게임의 손) 또는 전부(예: 아이언맨, 북한이탈주민)를 이용하여 화면 상의 오브젝트를 조작
- 인터랙션 예
	- 손을 움직여서 열쇠로 문을 열거나 토끼를 잡음 (엘리스)
	- 손과 팔을 움직여 악당을 물리침(아이언맨)
	- 온 몸을 좌우로 움직여 화살(엘리스) 또는 상처되는 말(북한이탈주민)을 피함

### 장점
- 오늘날 사용자 참여식 인터랙티브 미디어 아트는 기술보다 콘텐츠의 창의성이 중요함
- ScratchX는 비교적 손쉽게 창의적인 미디어아트 콘텐츠 제작
- 빠르고 간편하게 다양한 콘텐츠를 프로토타이핑하고 비주얼 그래픽 효과를 검토 가능
- ScratchX가 인터랙티브 미디어 아트의 프로토타입을 목적으로 이용하기에 충분함을 확인함

### 한계
- 화면 크기, 해상도, 세부적인 구현 방식 등 기술적 제약
- 전문적 미디어 아트 구현에 한계

### Source Code
- download from <a href="https://github.com/HandongHCI/HandongHCI.github.io/tree/master/HCI2018S/MediaArt/download" target="_blank">here</a>

### Reference
- https://kocoafab.cc/tutorial/view/716
- (book) [스크래치 미디어아트](http://www.kyobobook.co.kr/product/detailViewKor.laf?mallGb=KOR&ejkGb=KOR&barcode=1400000262870)

<br><br><br>
[← go back to the list](https://HandongHCI.github.io/HCI2018S)
