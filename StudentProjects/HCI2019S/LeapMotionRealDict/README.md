[← go back to the list](https://HandongHCI.github.io/HCI2018S)

# Real-dict

#### Members
- 심재혁, 김성은, 정윤상, 최은정



<br><br><br>
## Introduction
인체와 동물, 공룡에 대하여 공부하고자 할 때, 책에 나와있는 글과 사진 만을 보고 그 모양을 이해하기 어려운 경우가 많다. 이를 해결하기 위해서 3D기기들을 이용하여 실제모양과 유사한 다양한 소재를 관찰과 조립을 통해 재미있는 학습을 가능하게 하는 3D 백과사전인 Real dict를 개발하고자 한다.


## Research
- 목표
1) Leap motion과 looking glass를 이용한 실제감 있는 백과사전 어플리케이션을 통해 초등학생들의 학습을 도와주는 컨셉을 설정했다. 
2) looking glass로 물체를 입체적으로 보면서 leap motion을 통해 물체를 만지고 조립하는 등의 조작을 하여 물체의 구조를 학습하고 학습에 대한 흥미도를 높인다. 
3) 입체적인 모형을 조립함으로써 공간적인 지각을 높일 수 있다.

- 대상
학습에 흥미를 느끼지 못하는 초등학생, 중학생


##  Method
기기 > looking glass: A Holographics Display for 3D Creators, 
       Leap motion: 손을 인식하여 가상의 환경을 조종하는 기계 
       
프로그램 > unity: 3D 및 2D 환경을 개발하는 게임 엔진


## Devices
[looking glass] [go →](https://www.leapmotion.com/)
[leapmotion] [go →](https://lookingglassfactory.com/)


## Development
- leapmotion 설치하는법
  : https://developer.leapmotion.com/get-started
    해당파일에있는 파일을 다운받은 후, 립모션 기기와 연결시켜 프로그램을 만들거나 작동시킬수 있다.
    
- looking glass의 구현원리
  : Looking glass회사에서 제공해주는 unity용 module을 import하여 화면을 looking glass에 나오게 했다. 바로 위의 사진을 보면 초록색 네모박스를 기준으로       looking glass화면이 나온다.
  

## Code of menu

버튼을 선택하는 script로써 해당 버튼에 손을 올라갔는지 확인하는 코드다. 
해당 버튼에 손가락이 올라가면 로딩중 표시가 나오고 2초동안 올려놓으면 다른 화면으로 전환된다. 
원하는 버튼에 손을 올리고 2초동안 있으면 다음 화면으로 넘어간다. 만약 선택 도중에 버튼에서 손을 멀리하면 
로딩중 표시는 없어지고 선택한 것에 대한 시간초가 초기화 된다. 장면에 대해 설명하자면 각각의 카테고리가 있고 
여러 버튼이 있어서, 원하는 버튼을 선택하여 다음 화면으로 넘어가는 장면이다.
그리고 메뉴가 처음에 오른쪽에서 왼쪽으로 움직여 등장하는 애니메이션을 넣었고, 배경은 별들이 움직이는 것을 넣었다.

```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class newgame : MonoBehaviour
{
    public GameObject activity;
    private System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();

    public bool selected = false;

    private void Start()
    {
        var actTransform = activity.GetComponent<RectTransform>().position;
        actTransform = GetComponent<RectTransform>().position;
       
        activity.SetActive(false);
    }

    private void Update()
    {	////해당 버튼위에 손이 있는지 확인하는 구문
        if (selected == true)
        {    ///선택됐다면 화면가운데 원형 로딩표시가 나옴
            activity.SetActive(true);

            ////2초 이상 버튼위에 손을 올리면 다른 화면으로 바뀌는 구문
            if (stopWatch.ElapsedMilliseconds > 2000.0f)
            {
                Debug.Log("바뀐다");
		///scene이 바뀌는 구문 
                SceneManager.LoadScene("CATEGORY");
            }
        }
        else
        {   ///만약 선택을 중단하면 로딩표시하는 원이 사라지고 2초이상 올리는지 확인하는게
///0초로 초기화됨
            activity.SetActive(false);
            stopWatch.Reset();
        }
    }

    private void OnTriggerEnter(Collider other)
    {   ///해당 버튼에 손가락이 닿았는지 확인하고 닿았으면 로딩중 화면과 시간이 카운터됨

        Debug.Log("들어왔다");
        selected = true;

        stopWatch.Start();
        activity.SetActive(true);
        //StartCoroutine(Wait3Sec());

    }

    private void OnTriggerExit(Collider other)
    {   ///해당 버튼에서 손가락이 나가면 로딩중 표시가 없어지고 시간초가 초기화됨
        Debug.Log("나갔다");
        selected = false;
        activity.SetActive(false);
     }
}
```


##	Code of assembling

뼈를 잡고 해당 뼈가 위치해야 될 곳에 뼈를 가져다 대면 일정 범위안에 들어가면 자동으로 뼈가 붙는 코드이다. 
정해진 위치에서만 조립이 된다. 만약 조립한 것을 때면 뼈에 다시 중력이 작용하면 땅으로 떨어진다. 
해당 물체에는 강체와 현재 손과 충동하였는지 확인하는 collider의 속성을 넣어주어 립모션으로 물체를 잡을 수 있게 했다. 

뼈가 심어진 공룡 모델에 공룡의 모션을 넣어서 공룡이 움직이도록 했다. 
그리고 해당 모델에 대한 설명을 초등학생의 수준으로 설명을 넣었다. 
또한 화면을 Looking-glass로 표시하여 화면을 홀로그램으로 띄어서 입체감 있는 화면을 만들었다. 

```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class newgame : MonoBehaviour
{
    public GameObject activity;
    private System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();

    public bool selected = false;

    private void Start()
    {
        var actTransform = activity.GetComponent<RectTransform>().position;
        actTransform = GetComponent<RectTransform>().position;
       
        activity.SetActive(false);
    }

    private void Update()
    {	////해당 버튼위에 손이 있는지 확인하는 구문
        if (selected == true)
        {    ///선택됐다면 화면가운데 원형 로딩표시가 나옴
            activity.SetActive(true);

            ////2초 이상 버튼위에 손을 올리면 다른 화면으로 바뀌는 구문
            if (stopWatch.ElapsedMilliseconds > 2000.0f)
            {
                Debug.Log("바뀐다");
		///scene이 바뀌는 구문 
                SceneManager.LoadScene("CATEGORY");
            }
        }
        else
        {   ///만약 선택을 중단하면 로딩표시하는 원이 사라지고 2초이상 올리는지 확인하는게
///0초로 초기화됨
            activity.SetActive(false);
            stopWatch.Reset();
        }
    }

    private void OnTriggerEnter(Collider other)
    {   ///해당 버튼에 손가락이 닿았는지 확인하고 닿았으면 로딩중 화면과 시간이 카운터됨

        Debug.Log("들어왔다");
        selected = true;

        stopWatch.Start();
        activity.SetActive(true);
        //StartCoroutine(Wait3Sec());

    }

    private void OnTriggerExit(Collider other)
    {   ///해당 버튼에서 손가락이 나가면 로딩중 표시가 없어지고 시간초가 초기화됨
        Debug.Log("나갔다");
        selected = false;
        activity.SetActive(false);
     }
}

```


### 재미/즐거움
조립을 통한 학습의 즐거움/ 실제감있는 학습


### 교육
- 입체적 체험, 다양한 소재
-생물/기기/건축 등


### TO-DO
- add documents and instructions
- add student projects
- add more student projects


### Contact
- 21700738 (at) HANDONG (dot) EDU