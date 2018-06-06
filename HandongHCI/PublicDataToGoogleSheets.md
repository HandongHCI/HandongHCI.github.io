(작성 중)

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
