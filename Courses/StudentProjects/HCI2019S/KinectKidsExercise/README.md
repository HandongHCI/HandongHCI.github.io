[← go back to the list](../../HCI.md)

# 뛰뛰쿨쿨 
![](1.png) 

#### 키넥트 카메라를 이용해 아동의 운동량을 늘리고 건강한 생활습관을 교육하여 소아비만을 예방해주는 게임

#### Members
   - 김동주, 신주혜, 이민지, 차승연

## 00. 게임설명
### Background
소아비만의 원인은 많은 양의 칼로리를 섭취하지만 소모되는 칼로리의 양이 적다는것이 주된 요인이다. 오늘날 아이들은 실내에서의 정적인 활동을 많이 하기때문에 운동량이 적다. 따라서 우리는 움직임을 감지하는 키넥트 카메라를 이용하여서 아이들의 운동량을 증진시켜주는 소아비만 예방게임을 개발하였다. 
더불어 유저리서치를 통해 아이들의 불규칙한 수면패턴과 고칼로리 음식을 선호하는 식습관을 발견하였다. 이와같이 소아비만으로 이어질수있는 불균형한 생활습관도 올바르게 교육할 수 있도록 하였다.

#### Character (뛰용이)
User research 결과 아이들이 좋아하는 게임은 대부분 3D 게임이라는 결과를 통해 3D 캐릭터로 만들었다.
뛰뛰쿨쿨은 뛰면서 움직이는 게임이므로 캐릭터 이름은 뛰용이이다. 또, 뛰용이의 머리카락은 줄넘기 모양이다.
원색을 좋아하는 어린이의 심리적 특성과 눈에 잘 띈다는 점이 맞물려 노란색은 어린이 용품의 색으로 자주 쓰이기 때문에 메인캐릭터 색상을 노랑으로 선정하였다.
![캐릭터](img/2.png)
  

## 01. 게임 구성
타깃이 아이들이기 때문에, 한가지 게임만으로는 쉽게 질려 해 운동량을 증가시키기 어려울 것이라고 생각했기 때문에 다양한 내용의 미니게임 6가지로 구성했다.
![menus](img/3.png)

####  01) 하늘에서 음식이 내린다면
건강한 음식을 먹는 것이 미션! 제한 시간 안에 미션을 수행해야 한다. 만약, 건강하지 않은 음식을 먹으면 뛰용이의 몸이 뚱뚱해진다.

####  02) 꿈나라로 뛰어가요
뛰용이를 일찍 잠자리에 들게 해야 한다. 사용자가 점프하면 왼쪽의 공도 점프한다. 공이 'Jump' 아이콘에 닿을수록 뛰용이가 침대에 가까워진다! 제한 시간 안에 뛰용이를 잠자리에 들게 하면, "덕분에 뛰용이가 일찍 잘 수 있었어요!"라는 문구로 일찍 자는 수면습관을 칭찬한다.

####  03) 지방 복싱!
제한 시간 내에 지방이를 최대한 많이 잡아라! 잡은 지방이의 수는 게임이 끝나고 숫자로 나타난다. 아이들이 친구들과 경쟁하며 즐겁게 할 수 있는 게임.

####  04) 엄마 아빠와 식사 준비
아이 혼자 게임하는 것이 아니라, 2P 게임이다. 재료를 고르고 요리를 만드는 게임으로, 건강한 식습관을 유도하는 게임이다. 아이들에게 디지털 프로토타입 테스트를 한 결과, 부모님과 게임을 하고 싶다는 의견이 많았기 때문에 아이들이 좋아할 것이라고 생각한다.

####  05) 날 따라해봐요
지정된 동작을 따라하는 게임! 간단한 스트레칭을 하는 게임이다. 

####  06) 빙글빙글 훌라후프
사용자가 허리를 돌리면 화면에는 실제 훌라후프를 돌리는 것처럼 나온다. 훌라후프를 떨어뜨리지 않고 최대한 오래 돌리면 성공!


## 02. Step by step tutorial
### 원리
- [Kinect SDK v2.0](https://www.microsoft.com/en-us/download/details.aspx?id=44561)
- [Scratch X](https://github.com/stephenhowell/kinect2scratch)

![image](img/4.png)
![image](img/5.png)

- Kinect 카메라가 User를 인식하여 User의 관절의 위치를 x, y, z 좌표로 입력 받음
입력 받은 User의 좌표를 이용하여 Scratch X를 통해 게임 구현
- 사용한 좌표
	- Spin Base: 캐릭터 뛰용과 공(**꿈나라로 뛰어가요**)의 상하좌우, 거리 표현
	- Right/Left Hand Tip: 왼쪽 오른쪽 글러브(**지방 복싱**) 상하좌우, 거리 표현


### 게임 튜토리얼 

#### menu
- User가 점프하면 캐릭터 뛰용이 게임시작 버튼에 닿음, 
- 미니게임을 선택할 수 있는 화면이 나오고 화살표에 캐릭터 뛰용이 닿으면 다음 게임으로 바뀜. 미니게임 썸네일 위치에서 User가 점프하여 캐릭터 뛰용이 닿으면 해당 게임으로 화면 넘어감

![1](img/6.png)

#### 하늘에서 음식이 내린다면 게임 첫화면
- User가 점프하여 게임 시작 버튼에 캐릭터 뛰용이 닿으면 게임 시작
- 왼쪽 위에 캐릭터 뛰용이 먹어야 하는 음식의 숫자가 랜덤하게 표시되고 User가 몸을 움직이며 캐릭터 뛰용이 음식을 먹거나 피함. 피해야 하는 음식(ex, 감자튀김, 도넛, 아이스크림)이 캐릭터 뛰용에 닿으면 Life의 하트가 하나씩 줄고, 캐릭터 뛰용의 모습이 뚱뚱해짐. 

![2](img/7.png)
![게임성공 화면과 게임 실패 화면](img/8.png)

#### 꿈나라로 뛰어가요 게임 첫 화면
- 제한시간동안 User가 점프하여 캐릭터 미니 뛰용이 침대로 이동함
- User의 점프는 왼쪽 주황색 공으로 표현

![4](img/9.png)
![게임 성공 화면과 게임 실패 화면](img/10.png)

#### 지방 복싱 게임 첫 화면
- User가 오른쪽 왼쪽 손을 움직여 캐릭터 '지방'을 잡음
- User의 손의 움직임은 빨간색 글러브를 통해 표현.

![6](img/11.png)
![7](img/12.png)

### 유저 플레이 영상
<div style="position: relative; padding-bottom: 56.25%; padding-top: 25px; height: 0;"><iframe src="https://www.youtube.com/embed/eOAuMgEgBc4" frameborder="0" allow="autoplay; encrypted-media" allowfullscreen style="position: absolute; top: 0; left: 0; width: 100%; height: 100%;"></iframe></div>


## 03. Source code
[뛰뛰쿨쿨 게임 코드 다운받으러 가기](https://github.com/HandongHCI/HandongHCI.github.io/tree/master/StudentProjects/HCI2019S/KinectKidsExercise/source.sbx)


## 04. Photos and Videos
Paper prototype
<div style="position: relative; padding-bottom: 56.25%; padding-top: 25px; height: 0;"><iframe src="https://www.youtube.com/embed/8O7r_UCfcts" frameborder="0" allow="autoplay; encrypted-media" allowfullscreen style="position: absolute; top: 0; left: 0; width: 100%; height: 100%;"></iframe></div>

Prototype test - 요약 영상
<div style="position: relative; padding-bottom: 56.25%; padding-top: 25px; height: 0;"><iframe src="https://www.youtube.com/embed/3JFlcdSHb60" frameborder="0" allow="autoplay; encrypted-media" allowfullscreen style="position: absolute; top: 0; left: 0; width: 100%; height: 100%;"></iframe></div>


## 05. References
- https://social.msdn.microsoft.com/Forums/en-US/c818387d-8717-48a9-b562-738e9e0b69e5/joints-in-kinect-v2?forum=kinectv2sdk


<br><br><br>
[← go back to the list](https://HandongHCI.github.io/StudentProjects/HCI2019S)