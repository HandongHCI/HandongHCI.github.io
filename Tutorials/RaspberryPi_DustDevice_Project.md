[← go back to the list](README.md)

# Raspberry Pi 미세먼지 디바이스 제작 프로젝트 (작성 중)
### 목차
1. 준비물
1. Raspberry Pi에 미세먼지 센서 연결하기
1. Raspberry Pi에 Hue 연결하기
1. Raspberry Pi 설정하기
1. 미세먼지 데이터 읽기
1. 미세먼지 값에 따라 Hue 밝기 조절하기
1. 미세먼지 값을 Google Sheets에 올리기
1. Case 제작

## 준비물
- Raspberry Pi (Raspberry Pi에 Raspbian OS 설치 방법은 [여기](Raspbian.md) 참조)
- 미세먼지 센서
- USB keyboard, mouse

## Raspberry Pi에 미세먼지 센서 연결하기
1. [여기](Raspbian.md)를 참조하여 PC에서 `config.txt`와 `cmdline.txt`를 수정한다.
1. Raspberry Pi에서 수정하려면 다음과 같이 파일에 접근할 수 있다. Nano라는 text editor를 사용할 줄 알아야 한다.
	```
	sudo nano /boot/config.txt
	sudo nano /boot/cmdline.txt
	```

## Raspberry Pi 설정하기
1. Terminal에서 `sudo raspi-config`를 입력하여 설정창이 열리면, `5 Interfacing Options` > `P5 Serial`을 선택하고 순서대로 `No`와 `Yes`를 선택한다.
1. Terminal에서 `sudo chmod g+r /dev/ttyAMA0`라고 입력하여 ttyAMA0에 대한 접근 권한을 변경한다.
1. Terminal에서 `reboot`을 입력하여 재시작한다.
1. 재시작된 후, terminal에서 `ls -l /dev/ttyAMA0`라고 입력하였을 때 아래와 같이 출력이 되어야 한다.
	- `crw--w----`라는 메시지가 출력되면 안 됨 (위 2번 단계에서 chmod를 변경하기 전에 이런 상태임)
	- `crw-rw----`라는 메시지가 출력되어야 함

## 미세먼지 데이터 읽기
1. [여기](files/code_micro_dust.py)서 Python code를 다운로드한다. 초당 1회로 총 100번 미세먼지를 측정하는 code이다.
1. command line에서 아래와 같이 입력하여 python code를 실행한다. `sudo pigpiod`는 한 번만 실행하면 된다.
	```
	sudo pigpiod
	python3 code_micro_dust.py
	```
1. 만약 python code가 실행되지 않는다면, 몇 가지 이유가 있다.
	- 재부팅해본다.
	- Terminal 상에서 현재 위치한 directory에 code_micro_dust.py 파일이 없을 수 있다. Directory를 이동해야 한다(이동 방법은 직접 검색해볼 것).
	- `sudo pigpiod`가 실행되지 않았기 때문일 수 있다. 만약 Raspberry Pi를 재부팅하였다면, `sudo pigpiod`를 다시 실행해줘야 한다. pigpiod가 실행되지 않은 문제라면 해당 문제라는 메시지를 보여주기 때문에, 확인 후 `sudo pigpiod`를 해주면 된다.
	- ttyAMA0 세팅이 제대로 되지 않았을 수 있다. 본 tutorial를 찬찬히 다시 따라한다.
1. 센서를 통해 3가지 종류(10, 2.5, 1.0 마이크론)의 미세먼지를 분석할 수 있다. Python code를 수정해보자.

## 미세먼지 값에 따라 Hue 밝기 조절하기

## 미세먼지 값을 Google Sheets에 올리기

<br><br><br>
[← go back to the list](https://HandongHCI.github.io/Tutorials)
