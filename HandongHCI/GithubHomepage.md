### Github로 홈페이지 만들기

#### Introduction
- ICT분야에 일하면서 Github 하나씩은 가지고 있어야 되는 때가 왔습니다. Github에 많은 프로젝트를 남길수록 
- 이번에는 Github로 홈페이지 만드는 방법에 대해 설명드리겠습니다.

#### 절차
1. 먼저 Github 계정을 만든다.
2. `본인계정명.github.io`라는 이름으로 repository를 만든다. 나의 계정 이름은 LeeLAMB이다.
3. 처음에는 아마 `본인계정명.github.io` 사이트가 없을 것인데, 생성한 repository로 들어가면 상단에 톱니바퀴 아이콘과 함께 'Setup' 메뉴가 있고, 클릭해서 `본인계정명.github.io` 사이트를 활성화 해야 된다.

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
