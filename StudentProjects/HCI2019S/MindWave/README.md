# 뇌파 데이터를 이용한 시각화 프로젝트

## Introduction
- 본 문서는 Windows 10 환경에서 Python으로 MindWave Mobile 2 장비로부터 뇌파 정보를 받는 방법을 소개 (Mac은 Python의 bluetooth module이 잘 설치되지 않음)
- 장비가 수집하는 뇌파
    1. attention/concentration (집중도)
    1. meditation/relaxation (이완도)
    1. raw EEG data (delta, highAlpha, highBeta, lowAlpha, lowBeta, lowGamma, midGamma, theta)
- 작동원리
    1. MindWave Mobile 2
    - bluetooth를 통해 컴퓨터와 통신
    1. Philips HUE
    - wifi를 통해 컴퓨터와 통신
    - wifi 공유기에 HUE Bridge를 연결(컴퓨터에서는 Bridge가 연결된 wifi를 잡아야한다.)
    - Bridge와 전구가 연결되어 상호 통신

## 준비물
- Mindwave Mobile 2
- Philips HUE
- Windows 운영체제
- 사용 언어: python

## 개발 단계
1. Python으로 MindWave Mobile 2 뇌파 데이터 받아오기
2. 뇌파 데이터를 HUE로 표현하기

### Python으로 MindWave Mobile 2 뇌파 데이터 받아오기
#### 개발 환경 구축
1. 알려진 Python code를 사용하기 위해서는 먼저 Pybluez라는 bluetooth 연결 모듈을 설치해야 한다. Pybluez는 현재 Windows 환경에서 제대로 작동하는 것으로 확인되며, Mac에서는 잘 설치되지 않았다. (Linux 및 Linux 기반의 Raspberry Pi에서 사용 가능하다는 보고가 있지만 test하진 않았다.)

1. 만약 Python 개발 환경이 구축되지 않았다면, Anaconda (Python 3.7)를 설치한다.

1. Windows에 Pybluez를 설치하기 위해서는 우선 [Visual Studio Build Tools](https://www.visualstudio.com/pl/thank-you-downloading-visual-studio/?sku=BuildTools&rel=15) 설치가 필요하다.

1. Visual Studio Build Tools를 실행하고 그 중에서 "Visual C++ build tools"과 "Universal Windows Platform build tools" 두 가지를 체크하고 설치한다.

1. Pybluez를 github로부터 받아와서 설치한다.
    ```
    git clone https://github.com/pybluez/pybluez
    cd pybluez
    python setup.py install
    ```

    - 만약 Anaconda에서 git 명령어가 실행되지 않으면 git을 설치해준다.
    ```
    conda install -c anaconda git
    ```

1. pybluez가 성공적으로 설치되면, MindWave를 구현할 수 있는 [Python code](https://github.com/robintibor/python-mindwave-mobile)를 github로부터 받아와서 설치한다.
    ```
    git clone https://github.com/robintibor/python-mindwave-mobile
    cd python-mindwave-mobile
    python setup.py install
    ```

#### Python Application 개발
1.  Example 폴더이 있는 read_mindwave_mobile.py 파일을 기본으로 mindwavemobile 폴더에 있는 4가지의 파일의 내용을 추가해서 하나의 파일로 묶는다.
MIndwaveDataPointReader.py
MindwaveDataPoints.py
MindwaveMobileRawReader.py
MindwavePacketPayloadParser.py
 
1. 전부 합쳐서 만들어진 파일의 read_mindwave_mobile.py의 내용에 hasattr를 사용해서 mindwave mobile2에서 가져오는 데이터를 각각 저장 한다.
    ```python
    If hasattr(dataPoint, ‘meditationValue’)
         medVal = dataPoint.meditationValue
         attVal = dataPoint.attentionValue
         DVal = dataPoint.delta
         HAVal = dataPoint.highAlpha 
         HBVal = dataPoint.highBeta
         LAVal = dataPoint.lowAlpha                         	
         LBVal = dataPoint.lowBeta
         LGVal = dataPoint.lowGamma
         MGVal = dataPoint.midGamma
         TVal = dataPoint.theta
    ```

1. 받아온 데이터를 csv파일로 저장한다.
    ```python
    Sleepdata = open(‘sleepVal.csv’, ‘w’, encoding=’utf-8’, newline = ‘ ’)
    Sleepcsv = csv.writer(sleepdata)
    Sleepcsv.writerow([medVal, attVal, DVal, TVal, LAVal, HAVal, LBVal, HBVal, LGVal, MGVal])
    ```

#### 참고문헌
- [MindWaveMobile2](http://download.neurosky.com/public/Products/MindWave%20Mobile%202/MindWave%20Mobile%202%20User%20Guide%20.pdf)
- [Win10에 Pybluez 설치](https://github.com/pybluez/pybluez/issues/180#issuecomment-448102727)


### 뇌파 데이터를 HUE로 표현하기
#### 개발 환경 구축
1. HUE를 python으로 제어하기 위해서는 "phue"라는 모듈이 필요하다.
    ```
    git clone https://github.com/studioimaginaire/phue
    cd phue
    python setup.py install
    ```

#### Python Application 개발
1. Bridge 연결하기
    처음 브릿지를 연결할 때는 브릿지의 버튼을 누르고 b.connect() 를 활성화 시킨 다음 코드를 실행시킨다.
    다음부터는 주석처리하여 실행하면 된다.
    ```python
    #Enter bridge IP here.
    b = Bridge("000.000.000.000") 
    #If running for the first time, press button on bridge and run with b.connect() uncommented
    b.connect()
    ```

1. HUE 색깔 변경하기
    phue에서는 “CIE 1931”라는 색 규격을 사용한다.
    [CIE 1931](https://en.wikipedia.org/wiki/CIE_1931_color_space)는 색 좌표를 가지게 되는데 해당 색의 좌표를 
    ```python
    b.set_light(1, 'xy', [0.21, 0.72])
    ```
    이렇게 적어주면 된다.
    ()의 파라미터는 순서대로 “전구번호”, “적용함수(색깔바꾸기)”, “[x좌표, y좌표]”이다.

    ex) [0.21, 0.72] - 초록, [0.68, 0.32] - 빨강



