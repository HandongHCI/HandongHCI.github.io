[← go back to the list](https://HandongHCI.github.io/Tutorials)

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

## 미세먼지 데이터 읽기
1. command line에서 
	```
	sudo pigpiod
	python3 XXX.py
	```

## 미세먼지 값에 따라 Hue 밝기 조절하기

## 미세먼지 값을 Google Sheets에 올리기

<br><br><br>
[← go back to the list](https://HandongHCI.github.io/Tutorials)
