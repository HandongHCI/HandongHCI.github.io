# 미세먼지 데이터를 이용한 시각화 프로젝트

## Introduction
- 본 문서는 Raspberry Pi와 미세먼지 센서를 이용하여 얻은 데이터를 수치에 따라 홀로그램으로 디스플레이하는 것을 목표로 한다.

## 준비물
- Raspberry Pi
- 미세먼지 센서
- 7인치 디스플레이
- Frame(목재 합판, 아크릴판을 이용해 레이저 커팅)
- 사용 언어: python

## 개발 단계
1. 하드웨어
1. 소프트웨어

### 하드웨어 개발
#### 몸통부
1. 몸통부는 건물의 형태로 제작하였다.

1. 몸통부는 목재 합판을 이용해서 디스플레이를 올려놓을 수 있을 정도의 크기로 제작한다.

1. 윗면과 옆면은 잘 맞물릴 수 있도록 홈을 파서 글루건으로 고정시킨다.

1. Raspberry Pi와 전원선을 몸체 안에 고정시키고 디스플레이와 연결한다.

#### 디스플레이
1. 홀로그램 디스플레이는 역피라미드 형태의 아크릴판으로 화면에 사분할된 영상이 반사되어 상이 맺히도록 한다.

1. 크기는 밑면:높이:윗면 = 1 : 3.5 : 6의 비율로 4개의 사다리꼴을 붙여서 제작한다.

### 소프트웨어 개발
1. Raspberry Pi를 통해 미세먼지 데이터를 받아오는 방법은 [이 문서](https://handonghci.github.io/Tutorials/RaspberryPi_DustDevice_Project.html)를 참고한다.

1. Raspberry Pi를 통해 영상을 재생하기 위해서는 omxplayer-wrapper를 설치해야 한다.
    ```
    apt-get install libdbus-glib-1-dev
    pip3 install omxplayer-wrapper
    pip install pathlib
    ```
    - 참고문헌: [라즈베리파이3 OMXPlayer 제어 — 파이썬](https://medium.com/@lyoungh2570/라즈베리파이3-omxplayer-제어-파이썬-3e9327a6bfde)
   
1. 예제코드
    ```python
    from omxplayer.player import OMXPlayer
    from pathlib import Path
    from time import sleep

    VIDEO_PATH = Path("../tests/media/test_media_1.mp4")

    player = OMXPlayer(VIDEO_PATH)

    sleep(5)

    player.quit()
    ```
