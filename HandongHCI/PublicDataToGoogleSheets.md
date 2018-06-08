### 대한민국 공공데이터 이용하기

#### 공공데이터 가입하기
- [대한민국 공공데이터 사이트](https://www.data.go.kr)
- 한국환경공단 대기오염정보 조회 서비스 예: https://www.data.go.kr/dataset/15000581/openapi.do
- 절차
1. 회원 가입
2. 원하는 공공데이터 신청 (1시간 정도 후부터 서비스키(key) 사용이 가능함; 아래는 미세먼지 정도를 알 수 있는 한국환경공단의 대기오염정보 조회 서비스 예시임)
3. 이용
	- Key값 복사
	- 데이터 접속 방법: 아래 `ServiceKey` 부분에 본인의 서비스키를 넣고, `stationName`에 본인의 위치(동 이름)를 입력한 후 주소창에 붙여 넣음
	```http://openapi.airkorea.or.kr/openapi/services/rest/ArpltnInforInqireSvc/getMsrstnAcctoRltmMesureDnsty?stationName=장량동&dataTerm=daily&pageNo=1&numOfRows=1&ServiceKey=서비스키```
	- 변수
		- stationName: 모든 지역이 가능한 것은 아님(입력 가능한 지역 확인: http://www.airkorea.or.kr/index)
		- dataTerm
		- pageNo
		- numofRows: 1시간마다 업데이트 되므로 1로 하면 1시간 이내의 정보를 받게 됨, 2로 하면 최근 2회의 데이터를 받음
		- ServiceKey: 자신의 서비스키를 넣음
		- _type=json: 맨 마지막에 붙여 넣으면 JSON 형식으로 받아오고, 붙이지 않으면 XML 형식으로 받아옴
	- 데이터 형식
		- dataTime 측정일 및 시간 (매 시간 업데이트 됨)
		- so2Value 아황산가스 농도
		- coValue 일산화탄소 농도
		- o3Value 오존 농도
		- no2Value 이상화질소 농도
		- pm10Value 미세먼지 농도
		- pm10Value24 24시간 예측 농도
		- pm25Value 초미세먼지 농도
		- pm25Value24 24시간 예측 농도
		- khaiValue 통합대기환경수치
		- khaiGrade 통합대기환경지수
		- so2Grade 아황산가스 지수
		- coGrade 일산화탄소 지수
		- o3Grade 오존 지수
		- no2Grade 이상화질소 지수
		- pm10Grade 미세먼지 24시간 등급
		- pm25Grade 초미세먼지 24시간 등급
		- pm10Grade1h 미세먼지 1시간 등급
		- pm25Grade1h 초미세먼지 1시간 등급
	- 활용 방법
  
  
  
  
  
  

site: https://docs.google.com/spreadsheets/d/1fImbr5ovXR07P7NxYKqU6FsYKsHHaonZV9PmDnjt_T8/edit#gid=0

(국가공공데이터 받는 법 넣기)
- 날씨 조회 사이트: [동네예보정보조회서비스](https://www.data.go.kr/dataset/15000099/openapi.do)

script editor에 들어갈 내용
```
function ImportJSON()
{
  var url1 = "https://goo.gl/YMdXHS"; // shorten URL 쓰지 말고 원 URL로 수정하기
  var res1 = UrlFetchApp.fetch(url1);
  var content1 = res1.getContentText();
  var json1 = JSON.parse(content1);
  
  var date1 = [];
  var pm10Value = [];
  
  var xPath = "list/dataTime";
  var patharray1_1 = xPath.split("/");
  for (var i in json1[patharray1_1[0]]) {
    date1.push(json1[patharray1_1[0]][i][patharray1_1[1]]);
  }
  
  var xPath = "list/pm10Value";
  var patharray1_2 = xPath.split("/");
  for (var i in json1[patharray1_2[0]]) {
    pm10Value.push(json1[patharray1_2[0]][i][patharray1_2[1]]);
  }
  
  var sheet = SpreadsheetApp.getActiveSheet();
  var datarange = sheet.getDataRange();
  var currentRowNo = datarange.getNumRows();
  
  sheet.getRange("O1").setValue(date1);
  sheet.getRange("P1").setValue("=YEAR(O1)");
  sheet.getRange("Q1").setValue("=MONTH(O1)");
  sheet.getRange("R1").setValue("=DAY(O1)");
  sheet.getRange("S1").setValue("=HOUR(O1)");
  var Y = sheet.getRange("P1").getValue();
  var M = sheet.getRange("Q1").getValue();
  var D = sheet.getRange("R1").getValue();
  var H = sheet.getRange("S1").getValue();
  var currentHour = H; // current hour
  var lastHour = sheet.getRange(currentRowNo, 4).getValue(); // last hour
  
  
  var date2 = sheet.getRange("T1").getValue();
  var time2 = sheet.getRange("U1").getValue();
  var url2 = "http://newsky2.kma.go.kr/service/SecndSrtpdFrcstInfoService2/ForecastGrib?base_date=" + date2 + "&base_time=" + time2 + "&nx=102&ny=95&numOfRows=10&pageSize=10&pageNo=1&startPage=10&_type=json&serviceKey=키값" // URL에 시간값을 넣어야 되어서 shorten URL을 쓰지 못함
  sheet.getRange("Z1").setValue(url2);
  var res2 = UrlFetchApp.fetch(url2);
  var content2 = res2.getContentText();
  var json2 = JSON.parse(content2);
  
  var LGT;
  var PTY;
  var REH;
  var RN1;
  var SKY;
  var T1H;
  var UUU;
  var VEC;
  var VVV;
  var WSD;
  
  var xPath = "response/body/items/item/obsrValue";
  var patharray2 = xPath.split("/");
  T1H = json2[patharray2[0]][patharray2[1]][patharray2[2]][patharray2[3]][5][patharray2[4]];
  REH = json2[patharray2[0]][patharray2[1]][patharray2[2]][patharray2[3]][2][patharray2[4]];
  SKY = json2[patharray2[0]][patharray2[1]][patharray2[2]][patharray2[3]][4][patharray2[4]];
  RN1 = json2[patharray2[0]][patharray2[1]][patharray2[2]][patharray2[3]][3][patharray2[4]];
  VEC = json2[patharray2[0]][patharray2[1]][patharray2[2]][patharray2[3]][7][patharray2[4]];
  WSD = json2[patharray2[0]][patharray2[1]][patharray2[2]][patharray2[3]][9][patharray2[4]];
  
  if(currentHour !== lastHour)
  {
    sheet.getRange(currentRowNo+1, 1).setFormula(Y);
    sheet.getRange(currentRowNo+1, 2).setFormula(M);
    sheet.getRange(currentRowNo+1, 3).setFormula(D);
    sheet.getRange(currentRowNo+1, 4).setFormula(H);
    sheet.getRange(currentRowNo+1, 5).setValue(pm10Value);
    
    sheet.getRange(currentRowNo+1, 7).setFormula(T1H); //온도
    sheet.getRange(currentRowNo+1, 8).setFormula(REH); //습도
    sheet.getRange(currentRowNo+1, 9).setFormula(SKY); //하늘상태
    sheet.getRange(currentRowNo+1, 10).setFormula(RN1); //강수량
    sheet.getRange(currentRowNo+1, 11).setFormula(VEC); //풍향
    sheet.getRange(currentRowNo+1, 12).setFormula(WSD); //풍속
  }
}
```
