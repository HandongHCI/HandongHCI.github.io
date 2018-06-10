### Github로 홈페이지 만들기

#### Introduction
- ICT분야에 일하면서 Github 하나씩은 가지고 있어야 되는 때가 왔습니다. Github에 많은 프로젝트를 남길수록 다양한 경험을 하였다는 것을 증명합니다.
- 이번에는 Github로 홈페이지 만드는 방법에 대해 설명드리겠습니다.

#### 절차
1. 본인 Github 계정 하에 `본인계정명.github.io`라는 이름으로 repository를 만든다.
    - 예를 들어, 나의 계정 이름은 LeeLAMB이며, 내가 Github page를 만들기 위해 생성한 repository의 이름은 [LeeLAMB.github.io](https://LeeLAMB.github.io)이다.
    - 따라서 나의 github pages 주소는 `https://leelamb.github.io/`가 되고, 이 홈페이지를 구성하는 github 계정 주소는 `https://github.com/LeeLAMB/LeeLAMB.github.io`이 된다.
2. Github에 가입한다고 바로 `본인계정명.github.io`의 page가 생성되지는 않는다. `본인계정명.github.io`으로 생성한 repository로 들어가면 상단 우측 정도에 톱니바퀴 아이콘의 'Setup' 메뉴가 있는데, 클릭해서 setup화면에 들어간다. (또는 `https://github.com/본인계정명/본인계정명.github.io/settings`으로 접속하면 된다.) Setting 화면의 아래쪽에 Github Pages라는 항목이 있는데, 여기에서 source를 `master`로 선택하여 `본인계정명.github.io`를 활성화해야 된다.

![Github Pages 활성화하는 setting 화면 예](GithubHomepageSetting.png)

#### 글작성
- 가장 쉬운 방법으로, Github에 생성한 `본인계정명.github.io` repository에 가서 파일을 직접 수정하면 된다.
- 쉽게 documentation 하려면 markdown 방식의 documentation 방법을 꼭 숙지해야 된다. [매뉴얼 참조](https://guides.github.com/features/mastering-markdown/)
- Markdown을 이용하려면 파일들은 html이 아닌 모두 XXX.md 확장자를 가지도록 만들고, 링크를 걸 때도 XXX.md를 걸어주면 `본인계정명.github.io` 사이트에서 html을 대신하여 홈페이지가 가시화된다.
- Markdown을 쓰지 않고 html과 css, javascript를 이용해서도 홈페이지를 구성할 수 있다. 이때 처음 실행될 파일은 index.html로 하면 된다.

#### 참고
- [지금 이 문서에 대한 원 소스](https://github.com/LeeLAMB/LeeLAMB.github.io)를 살펴보자.

#### 기타
- 컴퓨터에서 coding 작업을 한 후 한번씩 Git에 update하는 방법 중 하나로, sourcetree라는 app을 쓰면 편하다.
- Git을 통해 협업하는 방법을 알면 좋다. Git은 단순 cloud storage가 아니라 issue를 제기하고, 서로 토론하고, 다른 사람의 code를 받아들이면서 프로젝트를 유기적으로 관리한다. [구글](https://github.com/google)과 [아마존](https://github.com/amzn)에서 어떻게 Github를 통해 프로젝트를 관리하는지 살펴보자.
