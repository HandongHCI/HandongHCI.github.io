[← go back to the list](README.md)

## Github로 홈페이지 만들기

### Introduction
- ICT분야에 일하면서 GitHub 하나씩은 가지고 있어야 되는 때가 왔습니다. GitHub에 많은 프로젝트를 남길수록 다양한 경험을 하였다는 것을 증명합니다.
- 이번에는 GitHub로 홈페이지 만드는 방법에 대해 설명드리겠습니다.

### 절차
1. 본인 GitHub 계정 하에 `본인계정명.github.io`라는 이름으로 repository를 만든다.
    - 예를 들어, 나의 계정 이름은 HandongHCI이며, 내가 GitHub Pages를 만들기 위해 생성한 repository의 이름은 [HandongHCI.github.io](https://HandongHCI.github.io)이다.
    - 따라서 나의 GitHub Pages 주소는 [`https://HandongHCI.github.io/`](https://HandongHCI.github.io/)가 되고, 이 홈페이지를 구성하는 github 계정 주소는 [`https://github.com/HandongHCI/HandongHCI.github.io`](https://github.com/HandongHCI/HandongHCI.github.io)이 된다.
2. Github에 가입한다고 바로 `본인계정명.github.io`의 page가 생성되지는 않는다. `본인계정명.github.io`으로 생성한 repository로 들어가면 상단 우측 정도에 톱니바퀴 아이콘의 'Setup' 메뉴가 있는데, 클릭해서 setup화면에 들어간다. (또는 `https://github.com/본인계정명/본인계정명.github.io/settings`으로 접속하면 된다.) Setting 화면의 아래쪽에 GitHub Pages라는 항목이 있는데, 여기에서 source를 `master`로 선택하여 `본인계정명.github.io`를 활성화해야 된다.

![GitHub Pages 활성화하는 setting 화면 예](img/GithubHomepageSetting.png)

### 글작성
- 본인 컴퓨터에다 폴더를 만들어서 파일들을 생성하고 sourcetree와 같은 app을 통해 파일을 github에 comit하는 방법으로 github에 파일을 생성하과 수정/관리할 수 있다.
- 하지만 글작성/수정의 가장 쉬운 방법은 github 사이트에서 직접 파일을 생성하고 수정하는 것이다.
- GitHub Pages에 보일 문서들을 가장 쉽게 documentation 하려면 markdown 방식이 유용하다. [매뉴얼을 참조하여 documentation 방법을 숙지하자.](https://guides.github.com/features/mastering-markdown/). [또 이 문서도 참고해보자.](https://docs.github.com/en/github/writing-on-github/basic-writing-and-formatting-syntax#using-emoji)
- Markdown을 이용하려면 파일 이름을 XXX.md로 만들고, 본문 내에서 XXX.md로 걸어주면 html을 이용하지 않고도 GitHub Pages를 만들 수 있다.
- Markdown을 쓰지 않고 html과 css, javascript를 이용해서도 홈페이지를 구성할 수 있다. 첫 실행될 파일명을 index.html로 하면 된다.
- [지금 이 문서에 대한 원 소스](https://github.com/HandongHCI/HandongHCI.github.io/blob/master/Tutorials/GithubHomepage.md)를 살펴보면, 이 문서의 markdown 형태를 확인할 수 있다.

### Markdown
- Markdown의 확장자는 .md파일로, GitHub Pages에서 .md파일을 html 형식으로 변환하여 보여준다. Markdown을 이용하면 html 문법을 모르더라도 간단한 웹페이지를 쉽게 구현할 수 있다.
- 몇 가지 대표적인 markdown
	- `#`는 제목을 나타낸다. 아래 예시를 참조한다.
	- `[클릭 문구](웹사이트 주소)`는 html의 `<a href="웹사이트 주소">클릭 문구</a>`와 같은 역할을 한다. 새 창/탭에서 열리지 않고 현재 창/탭이 새로운 웹사이트로 이동한다.
	- `![이미지설명](이미지주소)`는 html의 `<img src="이미지주소" alt="이미지설명">`과 같이 이미지를 출력한다.
	- `*TEXT*`는 TEXT를 italic체로 표현한다.
	- `**TEXT**`는 TEXT를 bold체로 표현한다.
	- `- TEXT`는 TEXT를 bullet point (개조식)으로 표현한다.
	- `1. TEXT`는 TEXT를 ordered bullet point (순서가 있는 개조식)으로 표현한다. 숫자를 증가시키면서 표현할 필요 없이, 여러 항목 앞에 항상 `1.`을 사용하면 숫자는 자동으로 증가한다.
	- 그 외에 table을 넣거나 emoji를 넣는 markdown code들이 있으니 [사이트](https://docs.github.com/en/github/writing-on-github/basic-writing-and-formatting-syntax#using-emoji)를 참고한다.

Title 표기 예시
```
# 1-level 제목
## 2-level 제목
### 3-level 제목
#### 4-level 제목
##### 5-level 제목
```

# 1-level 제목
## 2-level 제목
### 3-level 제목
#### 4-level 제목
##### 5-level 제목

- Markdown에 html을 섞어서 사용할 수 있다.
	- 예를 들어, markdown에서 이미지를 붙이는 방법은 `![이미지설명](이미지주소)`이다. 이미지 설명은 생략 가능하다. (이미지 설명 부분은 이미지 파일을 불러올 수 없을 경우 해당 이미지에 대해 설명한다.)
	- html에서 이미지를 붙이는 방법은 `<img srt="이미지주소" alt="이미지설명">`이다. alt 역시 생략 가능하다. alt는 이미지 파일을 불러올 수 없을 경우 해당 이미지에 대해 설명한다.
	- html에서는 좀 더 다양한 옵션을 붙여서 이미지를 삽입할 수 있다.

### 기타
- 더 다양한 테마를 원한다면: [http://jekyllthemes.org/](http://jekyllthemes.org/)

<br><br><br>
[← go back to the list](https://HandongHCI.github.io/Tutorials)
