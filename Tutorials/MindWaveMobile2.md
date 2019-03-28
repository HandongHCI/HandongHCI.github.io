[← go back to the list](https://HandongHCI.github.io/Tutorials)

## Python으로 MindWave Mobile 2 뇌파 데이터 받아오기

### Introduction
- 본 문서는 Windows 10 환경에서 Python으로 MindWave Mobile 2 장비로부터 뇌파 정보를 받는 방법을 소개 (Mac은 Python의 bluetooth module이 잘 설치되지 않음)
- 장비가 수집하는 뇌파는 2가지 종류: (1) attention/concentration (집중도), (2) meditation/relaxation (이완도)

### 개발 환경 구축
1. 알려진 Python cdoe를 사용하기 위해서는 먼저 Pybluez라는 blooth 연결 모듈을 설치해야 한다. Pybluez는 현재 Windows 환경에서 제대로 작동하는 것으로 확인되며, Mac에서는 잘 설치되지 않았다. (Linux 및 Linux 기반의 Raspberry Pi에서 사용 가능하다는 보고가 있지만 test하진 않았다.)

1. 만약 Python 개발 환경이 구축되지 않았다면, Anaconda (Python 3.7)를 설치한다.

1. Windows에 Pybluez를 설치하기 위해서는 우선 [Visual Studio Build Tools](https://www.visualstudio.com/pl/thank-you-downloading-visual-studio/?sku=BuildTools&rel=15) 설치가 필요하다.

1. Visual Studio Build Tools를 실행하고 그 중에서 "Visual C++ build tools"과 "Universal Windows Platform build tools" 두 가지를 체크하고 설치한다.

1. Pybluez를 github로부터 받아와서 설치한다.
    `
    git clone https://github.com/pybluez/pybluez
    cd pybluez
    python setup.py install
    `

    - 만약 Anaconda에서 git 명령어가 실행되지 않으면 git을 설치해준다.
    `
    conda install -c anaconda git
    `

1. pybluez가 성공적으로 설치되면, MindWave를 구현할 수 있는 [Python code](https://github.com/robintibor/python-mindwave-mobile)를 github로부터 받아와서 설치한다.
    `
    git clone https://github.com/robintibor/python-mindwave-mobile
    cd python-mindwave-mobile
    python setup.py install
    `

### Python Application 개발
(작성 중)

### 참고문헌
- [MindWaveMobile2](http://download.neurosky.com/public/Products/MindWave%20Mobile%202/MindWave%20Mobile%202%20User%20Guide%20.pdf)
- [Win10에 Pybluez 설치](https://github.com/pybluez/pybluez/issues/180#issuecomment-448102727)


<br><br><br>
[← go back to the list](https://HandongHCI.github.io/Tutorials)
