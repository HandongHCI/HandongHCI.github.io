[← go back to the list](https://HandongHCI.github.io/HCI2018S)

# Smart Mirror

Introduction Video<br>
[![Smart Mirror Team](https://img.youtube.com/vi/XpDLMKQtfx4/0.jpg)](https://www.youtube.com/watch?v=XpDLMKQtfx4 "Smart Mirror")



#### Members
- 박종욱, 이상규, 김진이, 노진기, 한진영, M. Janet Mwanjiwa

#### Agenda
- Tello & Leap Motion using Scratch
- Tello & Leap Motion using Gobot library



<br><br><br>
## Preparationㅁ### 부품 목록
- Raspberry Pi 3
- Monitor (밝을수록 좋음)
- 스피커 (또는 스피커가 내장된 모니터에 HDMI로 연결)
- Raspberry와 호환되는 USB microphone (예: http://lkqf.asdf.comtong.co.kr/product/detail.html?product_no=1652585)
- 유전원 USB 허브 (예: http://item.gmarket.co.kr/Item?goodscode=205565531)
- Philips HUE
- Fitbit smart band
- USB keyboard and mouse
- Wooden frame, glass, two-way mirror film

### Raspbian 설치 및 기본 설정
- [https://handonghci.github.io/Tutorials/Raspbian.html](https://handonghci.github.io/Tutorials/Raspbian.html) 참고
- Raspbian에 Smart Mirror 외에 다른 것은 설치하지 않는 것이 좋다. 특히 음성인식 관련하여 sound 관련 설정이 다른 프로그램(예: Magic Mirror)과 충돌날 가능성이 있다.


### Smart Mirror 설치 (참고: [docs.smart-mirror.io](https://docs.smart-mirror.io/docs/installing_raspbian.html))
1. 우선 node.js가 설치되어 있어야 한다.

2. Raspbian에서 root folder에 Evan Cohen의 Smart Mirror를 복사한다. Root에 smart-mirror라는 이름의 폴더가 생성된다.
```
cd ~
git clone https://github.com/evancohen/smart-mirror.git
```

3. 음성인식을 위해 sox와 libatlas-base-dev을 설치한다.
```
sudo apt-get install sox libatlas-base-dev
```

4. Smart Mirror에 필요한 javascript package들을 자동 설치한다. `npm install`을 통해 package.json에 적시된 필수 package들이 설치된다. 설치되는 package들 중에 electron이라는 것이 있는데, web browser가 아닌 환경에서 javascript, html, css를 구동시켜주기 위해 필요하다. Smart Mirror는 electron 상에서 구동되는 javascript application이다.
```
cd ~/smart-mirror
npm install
```

5. Smart Mirror의 핵심 기능은 Google의 Speech API를 이용하여 음성 명령을 통해 Smart Mirror의 기능을 제어하는 것이다. Google Cloud Speech API를 설정하기 위해 다음 단계를 시행한다.
	1. [Google Cloud Platform의 Projects](https://console.cloud.google.com/project) 사이트에 접속한다.
	1. 프로젝트를 하나 만든다.
	1. 생성한 프로젝트에 결제 방식을 연결한다. [Google Cloud Platform](https://console.cloud.google.com/)에서 `Billing` menu를 선택하고 Billing Account(본인의 google account. 신용카드가 연결되어 있어야 됨)를 등록한다. Google Cloud Speech API는 처음 시작한지 1년 동안 거의 무료로 사용할 수 있다. 거의 무료라 함은, 구글이 300달러의 point를 제공하고 여기에서 Speech API 이용료를 차감하기 때문에 실제 돈이 들지 않는다. (프로젝트에 결제 방식을 연결하는 방법은 [여기 참조 (영문)](https://cloud.google.com/billing/docs/how-to/modify-project))
	1. Google Cloud Platform에서 `APIs & Services`에서 프로젝트 하에 Cloud Speech API를 시작한다. 
	1. `APIs & Services` >`Credentials` 메뉴에서 `Service account key`를 생성하고 JSON 파일을 다운받는다. 다운받은 JSON 파일의 이름을 keyfile.json으로 하고 이를 Raspberry Pi의 smart-mirror 폴더 안에 넣는다.

6. 기타 Raspberry Pi 환경 설정
아래 환경설정 부분은 Smart Mirror의 설치 및 설정 파일에 포함되어 있지 않고 Raspbian에서 수정하는 부분이다.

	**1. 마이크 설정**
	- `sudo vim /usr/share/alsa/alsa.conf`로 설정 파일을 열고 68번째 줄 정도에 있는 아래 부분을
	```
	defaults.ctl.card 0
	defaults.pcm.card 0
	```

	- 아래와 같이 변경한다. Sound 관련 다른 설정은 바꾸지 않는다.
	```
	defaults.ctl.card 1
	defaults.pcm.card 1
	```


	**2. 화면을 세로로 회전**
	- `sudo vim /boot/config.txt`로 설정 파일을 열고 가장 아래쪽에 한 줄 추가한다.
	```
	display_rotate=1
	```


	**3. 화면보호기/화면자동꺼짐 중지**
	- `sudo vim /etc/X11/xinit/xinitrc`로 파일을 열고 9번째 줄 정도에 있는 `. /etc/X11/Xsession` 아래로 3줄 추가한다.
	```
	xset s off
	xset -dpms
	xset s noblank
	```

	- 그리고 나서 `sudo vim /etc/xdg/lxsession/LXDE/autostart`로 autostart 파일을 열고 가장 아래에 다음의 세 줄을 추가한다.
	```
	@xset s off
	@xset -dpms
	@xset s noblank
	```


	**4. 마우스 숨김**
	- 
	- Unclutter를 설치하고 autostart 파일을 열어 
	```
	sudo apt-get install unclutter
	sudo vim /etc/xdg/lxsession/LXDE/autostart
	```
	- 가장 아래에 한 줄을 추가한다.
	```
	@unclutter -idle 0.1 -root
	```

7. Smart Mirror 환경 설정
Smart Mirror를 처음 실행하기 위해 Raspberry Pi의 smart-mirror 폴더 내에서 `npm start`를 실행한다. 그러면 화면에 아래와 같은 문구가 뜨는데, 같은 wifi network 상의 다른 PC에서 web browser에 `http://192.168.1.130:8080`를 입력함으로써 Smart Mirror에 접속한다. (IP 주소는 다른 것이 될 수 있다.) 접속하여 Smart Mirror의 환경을 설정한다.
```
Remote listening on http://192.168.1.130:8080
```
	1. 세부 환경 설정은 [Evan Cohen의 document](https://docs.smart-mirror.io/docs/configure_the_mirror.html)를 참고한다
	1. (YouTube 연결 방법 추가)
	1. (HUE 연결 방법 추가)
	1. (Fitbit 연결 방법 추가)

### Smart Mirror 외형 frame 제작
- 모니터를 들고 인근 목공소에 가서 frame을 맞추었다.
- 그리고 frame을 들고 유리집에 가서 유리를 맞추었다.
- 그리고 two-way mirror film을 부착하였다. ([부착 방법 참조](https://www.youtube.com/watch?v=2kLI9h-Zydo))

### Demonstration 
[![Smart Mirror Demo](https://img.youtube.com/vi/tmxpc1bJFaQ/0.jpg)](https://www.youtube.com/watch?v=tmxpc1bJFaQ "Smart Mirror Demo")

### Source Code
- SmartMirror <a href="" target="_blank">here</a>
- From our project, the necessary files, `keyfile.json` and `config.json`, were deleted because it contains personal API keys.

### Acknowledgement
- This project was based on [Evan Cohen's Smart Mirror project](https://github.com/evancohen/smart-mirror).
- See details about this project from [Evan's documentation](http://docs.smart-mirror.io). Because the documents were written in 2016, some information are outdated.



<br><br><br>
## Further Issues
- 초음파센서를 이용하여 거울 가까이 가면 화면이 켜지도록 함
- 얼굴인식 센서 추가
- 기타 서비스 추가



<br><br><br>
[← go back to the list](https://HandongHCI.github.io/HCI2018S)