[← go back to HandongHCI page](https://leelamb.github.io/HandongHCI)

### Google Sheets에 저장된 데이터를 javascript로 받아오기

#### Introduction
- 본 문서는 Google Sheets의 특정 cell에 저장된 data를 HTML에 저장하는 방법에 대해 소개
- Google Sheets를 JSON형식으로 받아오는 것이므로 응용하면 특정 cell이 아닌 전체 데이터를 유기적으로 이용할 수 있을 것임
- Google Sheets 제작은 [주기적으로 국가공공데이터 불러서 Google Sheets에 자동 저장하기](#) 참고
- 참고자료: https://stackoverflow.com/questions/45671606/google-sheets-api-read-single-cell-value-from-public-sheet

#### 방법
1. Google Sheets를 누구나 볼 수 있도록 public으로 공유한다. 보기전용으로 공유하고 수정권한은 주지 않아도 된다.

2. 상단의 File > Publish to the web 메뉴를 선택한다. 첫 번째 옵션에서 "Entire Document" 혹은 특정 Sheet를 선택하고, 두 번째 옵션에서 "Web page"를 선택한 후 publish한다. (생성되는 link는 중요하지 않으니 창을 닫는다.)

3. 창을 닫고 원 Google Sheets로 돌아와서, 상단 주소창에 보면 주소명이 https://docs.google.com/spreadsheets/d/키값/... 이렇게 되어 있다. 그 키값이 필요하므로 복사해둔다.
    - 국가공공데이터에서 받아온 한국 날씨 데이터를 예로 들어보면,
    - 키값: 1fImbr5ovXR07P7NxYKqU6FsYKsHHaonZV9PmDnjt_T8
    - [원 Google Sheets (public으로 공유되어 있음)](https://docs.google.com/spreadsheets/d/1fImbr5ovXR07P7NxYKqU6FsYKsHHaonZV9PmDnjt_T8/edit#gid=851828607)
    - [위 Google Sheets의 JSON 형식](https://spreadsheets.google.com/feeds/cells/1fImbr5ovXR07P7NxYKqU6FsYKsHHaonZV9PmDnjt_T8/2/public/full?alt=json)

4. 이제는 javascript를 이용하여 JSON을 받아오기만 하면 된다. Public data를 받아오는 형식으로 API를 이용하기 위한 key값은 불필요하다.

5. Code는 [weather.html](weather.html) 참조

    ```
    <html>
    <head>
    </head>
    <body>
      <div id='dust'></div>
    </body>
    <script>
        // script는 body가 끝나고 들어감
        const onDataLoaded = (data) => {
            // Google Sheets의 E3 cell에 저장된 미세먼지 data를 받아와서 dust라는 div에 집어넣는 예
            const dataE3 = data.feed.entry.find((entry) => entry.title.$t == 'E3').content.$t
            document.getElementById('dust').innerHTML = "현재 미세먼지: " + dataE3
        }
    </script>
    <!--아래를 <script> 내에 불러줘야 위 code가 제대로 작동함-->
    <script src="https://spreadsheets.google.com/feeds/cells/1fImbr5ovXR07P7NxYKqU6FsYKsHHaonZV9PmDnjt_T8/2/public/basic?alt=json-in-script&callback=onDataLoaded"></script>
    </html>
    ```
