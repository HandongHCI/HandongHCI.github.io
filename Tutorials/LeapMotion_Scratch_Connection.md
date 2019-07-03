[← go back to the list](README.md)

## Scratch와 Leap Motion 연동하기

### Introduction
- 본 문서는 Scratch에서 Leap Motion을 이용하는 방법에 대해 소개
- 기본적으로 [ScratchX에서 Leap Motion을 이용할 수 있도록 하는 extension](https://khanning.github.io/scratch-leapmotion-extension/)을 이용
- Windows 10을 이용하는 경우에 Scratch에서 Leap Motion이 제대로 작동하지 않을 수 있는데, 이는 [Leap Motion 사이트에서 제시하는  방법](https://forums.leapmotion.com/t/resolved-windows-10-fall-creators-update-bugfix/6585/13)을 통해 해결이 가능함

### Windows 10에서 ScratchX로 Leap Motion 이용하기
1. Leap Motion을 연결하지 않은 상태에서, Leap Motion SW를 설치해야 한다. [공식 사이트](https://www.leapmotion.com/setup/) 에서 Desktop > [download our V2 software for Windows](https://developer.leapmotion.com/sdk/v2) > `Leap Motion SDK v2.3.1`을 다운받아 설치한다.
    - 상위 버전을 설치하지 말 것.
    - 아직 Leap Motion을 연결하지 말 것.

2. 다음으로, patch를 해주어야 한다. 이 과정은 공식 사이트에서 제시한 [연결 문제 해결 방법](https://forums.leapmotion.com/t/resolved-windows-10-fall-creators-update-bugfix/6585/13)을 따른다. 부연설명 하자면, Scratch에서 Leap Motion을 이용하기 위해서는 V2 (2.3.1)를 설치해야 한다. 하지만 Scratch를 이용하지 않는다면 V4를 설치해도 좋다.
    1. 윈도우 실행창(Win + R)에 `services.msc`라고 입력하여 서비스 윈도우를 띄운다.
    1. 여기서 **Leap Service**를 찾아 **중지**시킨다. (서비스 윈도우는 띄워 둔다.)
    1. 탐색기에서 `C:\Program Files (x86)\Leap Motion\Core Services`로 이동한다.
    1. **LeapSvc.exe** 파일과 **LeapSvc64.exe** 파일을 백업해둔다.
    1. [Patch를 다운로드](files\LeapSvc_Patch.zip)하여 **LeapSvc.exe**와 **LeapSvc64.exe**에 덮어 씌운다.
    1. 서비스 윈도우에서 **Leap Service**를 다시 **시작**한다.
    1. 끝

3. Leap Motion을 연결한다. 윈도우 하단 작업표시줄에 Leap Motion icon이 있는데(숨겨져 있을 수 있음), Leap Motion을 연결했을 때 이 icon이 초록으로 표시되어야 한다.

### ScratchX에서 Leap Motion extension 실행하기.
1. https://khanning.github.io/scratch-leapmotion-extension/ 사이트의 가장 아래로 내려가서 **Hand Skeleton** 예시를 클릭한다.

1. 최초로 ScratchX Leap Motion extension을 실행의 경우, 자동으로 Scratch 화면이 실행되지 않을 수 있다. 이 때는 **Open Extension URL**을 클릭하고 주소창의 인터넷 주소(.sbx로 끝남)를 붙여 넣는다. 인터넷 주소는 아래와 같다.
`http://scratchx.org/?url=http://khanning.github.io/scratch-leapmotion-extension/examples/Leap%20Motion%20Example%20-%20Hand%20Skeleton.sbx`

1. Scratch 화면의 가운데 Leap Motion과 관련된 block들이 보이는데, 이 창에 있는 동그라미가 초록색으로 보여야 한다. 초록색 동그라미 표시는 Leap Motion이 제대로 연결되었음을 의미한다.

1. 초록색 flag를 누르고 테스트한다.

### Trouble Shooting
(Leap Motion 사용에 관한 문제 해결에 관한 내용에 대해 추후 작성 예정)

<br><br><br>
[← go back to the list](https://HandongHCI.github.io/Tutorials)
