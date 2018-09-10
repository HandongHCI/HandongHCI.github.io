[← go back to the list](https://HandongHCI.github.io/Tutorials)

## Setting Raspbian on Raspberry Pi 3

### Introduction
- Raspbian은 Raspberry Pi에 설치되는 Linux 기반 OS
- Version: Raspbian Stretch (그 이전 version명은 Jessie)

### 준비물
- Raspberry Pi 세트
	- Raspberry Pi 3
	- mini SD
	- Card Reader
	- HDMI
	- LAN 선
	- ...
- HDMI 모니터
- USB 키보드
- USB 마우스
- 마이크 (Google Speech API나 Alexa를 이용하려면 필요)
- 스피커 (스피커가 지원되는 모니터라면 HDMI 케이블을 이용하여 모니터

### 다운로드
- [Raspberry Pi site](http://www.raspberrypi.org/downloads/raspbian)
- 사이트에서 Raspbian with Desktop을 받는다(압축 풀지 않음).
- Raspbian Lite는 desktop(바탕화면) 환경이 빠진 가벼운 버전이다. MS Windows와 같은 desktop환경이 구축되므로 파일탐색기를 이용하여 파일을 관리하거나 Text Editor를 이용하여 coding할 수 있다.

### 설치
- Windows나 Mac에서 mini SD 카드에 Raspbian을 설치한 후, mini SD를 Raspberry Pi에 꽂는 방식으로 설치한다.
- 설치를 도와주는 tool로 NOOBS, Win32DiskImage, Etcher 등이 있는데, Etcher를 이용하는 것이 advanced된 방법이다.
- Etcher
	- [https://etcher.io](https://etcher.io)에서 Etcher 프로그램 중 하나를 선택하여 받는다(Windows의 경우 portable 버전을 사용하면 편함).
	- Mini SD에 Raspian을 설치한다.
		1. Etcher 실행
		1. 다운로드한 Raspbian with Desktop (zip 파일)을 선택 
		1. mini SD 카드를 USB 리더기에 꽂고 USB 리더기를 PC의 연결한다. Etcher에서 해당 드라이브를 선택한다.
		1. Flash를 눌러 Raspbian을 mini SD 카드에 설치한다(5분 이상 소요됨).
		1. 설치 과정에서 mini SD가 몇 개의 파티션으로 나눠진다. 설치 과정 중에 "포맷"하라고 물어도 포맷하지 않는다.
- Raspberry Pi에 Raspbian 연결
	1. 학과에 있는 7inch 디스플레이를 사용할 것이라면, PC에 Mini SD를 연결하고 Raspbian이 설치된 드라이브를 열어서 config.txt의 가장 아래 줄에 다음 몇 줄을 추가한다. (이 때 포맷하라고 물어도 절대 포맷하지 말 것)
	```
	# setting for 7-inch LCD display
	max_usb_current=1
	hdmi_group=2
	hdmi_mode=87
	hdmi_cvt 1024 600 60 6 0 0 0
	hdmi_drive=1
	```
	1. Raspberry Pi에 mini SD를 꽂고, 모니터, 키보드, 마우스 등을 연결한 후 전원을 공급한다.
	1. mini SD에 Raspbian이 제대로 설치가 되었다면 Raspbian을 초기 설정하는 화면이 보인다. 만약 초기 설정 화면으로 넘어가지 않고 부팅 중에 에러를 표시한다면 메모리를 FAT32로 파티션을 합쳐 포맷한 후(MacOS를 이용하는 것이 편할 수 있다. DiskUtil 사용하여 mini SD의 volume을 erase하면 된다. 이 때 MS-DOS(FAT) 옵션을 이용한다. Mac에서 volume이 삭제된 mini SD를 윈도 PC로 읽어서 다시 '장치 기본값'으로 포맷한다.), 다시 Etcher로 Raspbian을 설치해본다.
	1. Rapberry Pi 초기 설정 화면에서 **지역을 바꾸지 말고 넘어간다.** 그리고 반드시 비밀번호를 정해준다. (공용 장비는 0000으로 함) 그리고 Wifi를 잡은 후 자동 업데이트를 실행한다. (자동 업데이트가 성공적으로 되지 않고 오류가 날 수 있다. 업데이트 성공 여부에 관계 없이, 일단 **리부팅을 한 후**에 아래 3줄을 실행한다.)
	1. 설치가 완료되면 가장 먼저 update를 해주고 불필요한 것들을 지운다. (앞에 `sudo`를 붙이면 read-only나 수정권한이 없는 file도 강제 수정할 수 있도록 한다는 뜻) Upgrade할 사항이 있다면 약 20분 정도 소요된다.
	```
	sudo apt-get update
	sudo apt-get upgrade
	sudo apt autoremove
	```

- 기본 설정

	**1. Wifi 연결**
	- 화면 좌측상단에서 icon을 눌러 wifi를 연결한다.


	**2. Keyboard 입력 변경**
	- Preference에 들어가서 Keyboard Layout을 Korean (101/104 key compatible)로 변경한다.


	**3. 한글 폰트 설치**
	```
	sudo apt-get install ibus
	sudo apt-get install ibus-hangul
	sudo apt-get install fonts-unfonts-core
	```


	**4. VIM 설치**
	```
	sudo apt-get install vim-gnome
	```
	
	- VIM 사용법
		- Read only file은 sudo vim 파일명으로 실행
		- a를 누른 후 수정할 영역을 수정
		- 수정이 끝난 후에는 esc를 누른 후, :w로 저장
		- :w!로 강제 저장 (read-only file인 경우)
		- :q로 종료
		- :q!로 저장 없이 강제 종료
		- (파일탐색기에서 해당 파일을 찾은 후 text editor를 이용해서 수정할 수도 있음)


	**5. NodeJS 최신 버전으로 upgrade**
	- NodeJS는 자바스크립트를 그 위에서 돌아가게 하는 일종의 플랫폼이다.
	- NodeJS의 버전을 확인한다.
	```
	node -v
	```

	- 버전을 변경(예: v4.X.X에서 v6.X.X로 변경)하려면 자동 업데이트가 되지 않으므로 지우고 새로 깔아야 한다.
	```
	sudo apt-get remove nodered -y
	sudo apt-get remove nodejs nodejs-legacy -y
	sudo apt-get remove npm -y
	```

	- 설치할 NodeJS의 버전을 선택하고 설치한다. NodeJS의 버전은 중요하다.
	```
	curl -sL https://deb.nodesource.com/setup_6.x | sudo -E bash -
	sudo apt-get install nodejs -y
	```

	- npm 명령어를 이용하여 node_moduels를 설치할 때 해당 버전의 NodeJS를 이용하게 된다. `npm install`은 node_modules 폴더를 생성하여 그 속에 필요한 java script들을 설치한다. node_modules 설치 및 관리를 위해서는 아래 것들에 대한 이해가 필요하다. npm을 이용하면서 권한 문제가 있을 때에는 앞에 `sudo`를 붙인다.
	```
	npm install // package.json에 포함된 것들을 node_modules 폴더 내에 설치한다.
	npm install XXX // 특정 모듈만 설치한다.
	npm remove
	npm XXX
	npm update
	npm cache clean
	npm rebuild // 특정 모듈을 업데이트 하거나 변경하였을 때는 cache clean을 한 후에 rebuild를 해준다.
	npm start
	npm run XXX // 특정 JS를 실행한다.
	```

	**6. 악성코드 차단 방법**
	Raspberry Pi를 대상으로 한 악성코드는 Rapberry Pi를 가상화폐 채굴기로 만들어 버린다. 이 악성코드는 네트워크의 기본 포트인 22번을 사용해 라즈베리파이에 접속하고, 공장 출고 기본값의 비밀번호를 입력해서 로그인에 성공하면 ZMap과 sshpass를 설치해 가상화폐를 체굴-전송한다. 이 악성코드에 걸리지 않으려면, 비밀번호를 부여하고 SSH 포트를 막는 등 몇 가지 설정이 필요하다. [https://wikidocs.net/9784](https://wikidocs.net/9784)를 참고할 것.

- 참고사이트
	- [라즈비안 설치 (Eng)](www.raspberrypi.org/documentation/installation/installing-images/README.md)
	- [라즈베리파이 문서 (Kor)](https://wikidocs.net/book/483)

<br><br><br>
[← go back to the list](https://HandongHCI.github.io/Tutorials)
