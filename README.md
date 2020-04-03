# Advertisement Analysis Program (Neuro-Marketing)
# 광고 분석 프로그램 (뉴로 마케팅 이용)
![image](https://img.shields.io/badge/language-C%23-blue?style=plat&logo=Visual-Studio)  
[요약](#요약)  
[필요성](#필요성)  
[개발 기간](#개발-기간)  
[개발자](#개발자)  
[사용 하드웨어](#사용-하드웨어)  
[사용 프로그램](#사용-프로그램)  
[집중도 판단 방법](#집중도-판단-방법)  
[결과](https://github.com/minji-o-j/Advertisement-Analysis-Program/wiki)

---
### 요약
- 뉴로 마케팅을 활용한 광고 분석 프로그램.

- 광고를 시청하는 동안의 사용자의 __집중도__ 와 __긍부정도__ 가 그래프로 나타남.  

- 실험에 기반한 계산을 통해 사용자의 집중도와 긍부정도를 고려한 구매 확률 제시

---
### 필요성
- 만든 광고에 대해서 소비자의 무의식적인 반응을 광고주가 알 수 없다.

- 광고주가 강조하고자 하는 이미지(긍정,부정)가 소비자에게도 잘 전달되는지 확인하고 싶다.  

--> __소비자의 뇌파에 대한 피드백을 받음으로써 광고의 효과를 극대화하고 단점을 보완할 수 있다.__

---
### 개발 기간

- 2019/01/18 ~ 2019/02/01
---
### 개발자

- [김나혜(nahye03)](https://github.com/nahye03), [정민지(minji-o-j)](https://github.com/minji-o-j), [한나연(HanNayeoniee)](https://github.com/HanNayeoniee)

---
### 사용 하드웨어
- [EMOTIV EPOC+ 14 Channel Mobile Brainwear®](https://www.emotiv.com/product/emotiv-epoc-14-channel-mobile-eeg/?gclid=CjwKCAjwvZv0BRA8EiwAD9T2VfQbwRLqpyAp6D0mM0hGsmNmKJnzB6Lr0rptqZTDyOw-YRXm3BlRXxoCc18QAvD_BwE)

![image](https://user-images.githubusercontent.com/45448731/78367153-962d9700-75fc-11ea-9b82-33d49da8e792.png)  

- 14 채널(AF3, F7, F3, FC5, T7, P7, O1, O2, P8, T8, FC6, F4, F8, AF4)의 뇌파 측정 가능

- 전도성 물질(식염수 등)이 필요
---
### 사용 프로그램
- __Visual Studio__: 프로그래밍, 뇌파 관련 데이터 처리  

- __Blend for Visual Studio__: GUI 제작  

- __SPSS Statistics__: 기준 채널 선정, 데이터 분석  

- __EMOTIVE application__: 실험 데이터 추출, 뇌파 감지 확인

---
### 집중도 판단 방법
![image](https://user-images.githubusercontent.com/45448731/78375633-0ee62080-7608-11ea-9486-ca595ff0f843.png)  
- ERP(사건관련전위) 중 late cognitive component(후기 인지적 정점)인 `P300`을 이용하여  집중도를 측정한다.
<br>

#### 1. p300 측정 방법
1. 1초에 128개의 뇌파 Data를 받는다.
2. 30초를 1초 단위로 쪼갠다. --> __1초 중에 250ms-500ms 구간중 최댓값을 P300으로 정한다.__ `Data Index: 32-63`
<br>

#### 2. 변화율에 대한 정의
![image](https://user-images.githubusercontent.com/45448731/78376290-0fcb8200-7609-11ea-9585-4f644493a0c0.png)  
- R: 30초동안 측정한 Reference(중립 뇌파)의 P300의 평균 `<-30초동안 30개의 P300이 측정된다.`
- S: 자극시 P300  
<br>

#### 3. 실험
1. 성공한 광고 영상과 실패한 광고 영상을 시청한다.
    - 실험 횟수: 13명*10번 = __130개의 샘플__
    - 성공 광고 영상, 실패 광고 영상 각 5개
    - 성공 광고와 실패 광고 기준은 뉴스를 통해 선정(실제로 매출 증가, 부적절한 광고로 기업 이미지 하락 등)  
    - 광고를 시청할 때 각 CH마다 샘플이 생김 (광고 10개 시청: 채널당 130개)  
    
2. P300 기준 DB 생성
![image](https://user-images.githubusercontent.com/45448731/78377184-405feb80-760a-11ea-81d4-b180760fecfe.png)

#### 4. Data 분석
- __SPSS Statistics__ 를 이용.

- 성공한 광고와 실패한 광고의 모든 채널에서 집중도의 척도인 __P300의 변화율__ 값을 받아 __대응표본 T검정 (paired t-test)__ 을 함.  

![image](https://user-images.githubusercontent.com/45448731/78377623-cb40e600-760a-11ea-8c8b-2f152e5e6399.png)
<br>

- 유의 확률 p가 0.05 이하일 때의 채널: _전두엽에 위치한_ `FC5`
---
### 긍/부정도 판단 방법

---
### 실험자 모드

---
###사용자 모드

---
### 결과

[결과 이미지 보기!!](https://github.com/minji-o-j/Advertisement-Analysis-Program/wiki)

