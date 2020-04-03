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
[긍/부정도 판단 방법](https://github.com/minji-o-j/Advertisement-Analysis-Program#%EA%B8%8D%EB%B6%80%EC%A0%95%EB%8F%84-%ED%8C%90%EB%8B%A8-%EB%B0%A9%EB%B2%95)  
[결과](#결과)  
[실제 구현 화면(wiki)](https://github.com/minji-o-j/Advertisement-Analysis-Program/wiki)

---
## >요약
- 뉴로 마케팅을 활용한 광고 분석 프로그램.

- 광고를 시청하는 동안의 사용자의 __집중도__ 와 __긍부정도__ 가 그래프로 나타남.  

- __실험에 기반한 계산__ 을 통해 사용자의 집중도와 긍부정도를 고려한 __구매 확률 제시__

---
## 필요성
- 만든 광고에 대해서 소비자의 무의식적인 반응을 광고주가 알 수 없다.

- 광고주가 강조하고자 하는 이미지(긍정,부정)가 소비자에게도 잘 전달되는지 확인하고 싶다.  

--> __소비자의 뇌파에 대한 피드백을 받음으로써 광고의 효과를 극대화하고 단점을 보완할 수 있다.__

---
## 개발 기간

- 2019/01/18 ~ 2019/02/01
---
## 개발자

- [김나혜(nahye03)](https://github.com/nahye03), [정민지(minji-o-j)](https://github.com/minji-o-j), [한나연(HanNayeoniee)](https://github.com/HanNayeoniee)

---
## 사용 하드웨어
- [EMOTIV EPOC+ 14 Channel Mobile Brainwear®](https://www.emotiv.com/product/emotiv-epoc-14-channel-mobile-eeg/?gclid=CjwKCAjwvZv0BRA8EiwAD9T2VfQbwRLqpyAp6D0mM0hGsmNmKJnzB6Lr0rptqZTDyOw-YRXm3BlRXxoCc18QAvD_BwE)

![image](https://user-images.githubusercontent.com/45448731/78367153-962d9700-75fc-11ea-9b82-33d49da8e792.png)  

- 14 채널(AF3, F7, F3, FC5, T7, P7, O1, O2, P8, T8, FC6, F4, F8, AF4)의 뇌파 측정 가능

- 전도성 물질(식염수 등)이 필요

- 전력에 의한 노이즈 제거 기능

---
## 사용 프로그램
- __Visual Studio__: 프로그래밍, 뇌파 관련 데이터 처리  

- __Blend for Visual Studio__: GUI 제작  

- __SPSS Statistics__: 기준 채널 선정, 데이터 분석  

- __EMOTIVE application__: 실험 데이터 추출, 뇌파 감지 확인

---
## 집중도 판단 방법
![image](https://user-images.githubusercontent.com/45448731/78375633-0ee62080-7608-11ea-9486-ca595ff0f843.png)  
- ERP(사건관련전위) 중 late cognitive component(후기 인지적 정점)인 `P300`을 이용하여  집중도를 측정한다.
<br>

### 1. p300 측정 방법
1. 1초에 128개의 뇌파 Data를 받는다.
2. 30초를 1초 단위로 쪼갠다. --> __1초 중에 250ms-500ms 구간중 최댓값을 P300으로 정한다.__ `Data Index: 32-63`
<br>

### 2. 변화율에 대한 정의
![image](https://user-images.githubusercontent.com/45448731/78376290-0fcb8200-7609-11ea-9585-4f644493a0c0.png)  
- R: 30초동안 측정한 Reference(중립 뇌파)의 P300의 평균 `<-30초동안 30개의 P300이 측정된다.`
- S: 자극시 P300  
<br>

### 3. 실험
1. 성공한 광고 영상과 실패한 광고 영상을 시청한다.
    - 실험 횟수: 13명*10번 = __130개의 샘플__
    - 성공 광고 영상, 실패 광고 영상 각 5개
    - 성공 광고와 실패 광고 기준은 뉴스를 통해 선정(실제로 매출 증가, 부적절한 광고로 기업 이미지 하락 등)  
    - 광고를 시청할 때 각 CH마다 샘플이 생김 (광고 10개 시청: 채널당 130개)  
    
2. P300 기준 DB 생성
![image](https://user-images.githubusercontent.com/45448731/78377184-405feb80-760a-11ea-81d4-b180760fecfe.png)

### 4. Data 분석, 채널 설정
- __SPSS Statistics__ 를 이용.

- 성공한 광고와 실패한 광고의 모든 채널에서 집중도의 척도인 __P300의 변화율__ 값을 받아 __대응표본 T검정 (paired t-test)__ 을 함.  

![image](https://user-images.githubusercontent.com/45448731/78378066-6afe7400-760b-11ea-90ae-f89ee7068937.png)
<br>

- 유의 확률 p가 0.05 이하일 때의 채널: __전두엽에 위치한 `FC5`__
<br>

---
## 긍/부정도 판단 방법

- EEG 이용  

### 1. 긍정/부정 감성의 구분
- 좌/우반구 대뇌피질의 비활성화 정도에 따라서 긍정/부정 감성을 구분할 수 있다.
- 비활성 상태: ![image](https://user-images.githubusercontent.com/45448731/78378794-73a37a00-760c-11ea-98c7-34ec769fb4be.png)  
- 활성 상태: ![image](https://user-images.githubusercontent.com/45448731/78378807-7900c480-760c-11ea-8c46-8626dac7ff45.png)  
![image](https://user-images.githubusercontent.com/45448731/78379059-caa94f00-760c-11ea-90c5-78a13cb1f07d.png)  
> (2002_[Review] Studies of emotion - A theoretical and empirical review of psychophysiological studies of emotion)

- 좌반구가 비활성: __부정적 감성__
- 우반구가 비활성: __긍정적 감성__
<br>

### 2. 실험
1. 성공한 광고 영상과 실패한 광고 영상을 시청한다.
    - 실험 횟수: 13명*10번
    - 성공 광고 영상, 실패 광고 영상 각 5개
    - 성공 광고와 실패 광고 기준은 뉴스를 통해 선정(실제로 매출 증가, 부적절한 광고로 기업 이미지 하락 등)  

2. 각 영상 시청 후 설문조사를 진행한다.
    - __시청하신 광고의 제품에 대해 구매 의향이 있나요?__: Y/N
    - __광고 시청 동안 광고에 집중하셨나요?__: 그렇다/보통이다/아니다
    - __광고를 볼 때 전반적인 기분은 어땠나요?__: 긍정적이다/보통이다/부정적이다
<br>

### 3. 결과 분석  
![image](https://user-images.githubusercontent.com/45448731/78379970-26280c80-760e-11ea-8de5-aa56650c7e1b.png)  
- 분석 결과 `T7`과 `T8`에서 유의미한 차이를 보임.
- 부정적임의 기준을 `T7`을 중점으로 잡고, 긍정적임의 기준을 `T8` 중점으로 설정함.

---
## 결과
![image](https://user-images.githubusercontent.com/45448731/78382454-dd725280-7611-11ea-9278-b656471edd1c.png)

### 사용자 모드
![image](https://user-images.githubusercontent.com/45448731/78381028-badf3a00-760f-11ea-81fd-1e7e99a9209a.png)  
<br>

__1. 분석하기__  

> 사용자는 __`분석하기`__ 에서 분석하고자 하는 광고를 업로드하여 실험을 의뢰한다.  


![image](https://user-images.githubusercontent.com/45448731/78381120-dcd8bc80-760f-11ea-8395-40d931073f53.png)

![image](https://user-images.githubusercontent.com/45448731/78381247-0d205b00-7610-11ea-863c-6f5edb89ce69.png)  
> 광고의 속성을 선택한다.
<br>

![image](https://user-images.githubusercontent.com/45448731/78381387-4062ea00-7610-11ea-934d-f69d3ef76446.png)

> 의뢰 완료 화면
<br>

__2. 결과 보기__  


![image](https://user-images.githubusercontent.com/45448731/78383116-ced86b00-7612-11ea-903a-9d0f66f786c2.png)

> 소비자의 구매 확률에 대해 %로 나타낸다.
<br>

![image](https://user-images.githubusercontent.com/45448731/78383162-e6175880-7612-11ea-93fa-25fea5767ad1.png)

> __초마다 집중도와 긍정도가 그래프로 나타나며, 최고 집중도 구간과 최고 긍정도 구간이 나타난다.__
<br>

### 실험자 모드
![image](https://user-images.githubusercontent.com/45448731/78383310-22e34f80-7613-11ea-9f8c-c67f0157ecdc.png)  

__1. 실험하기__  
<br>

![image](https://user-images.githubusercontent.com/45448731/78383735-d8ae9e00-7613-11ea-98cd-e073a5d05ac2.png)
> 실험자 정보를 입력한다.
<br>

![image](https://user-images.githubusercontent.com/45448731/78383783-ed8b3180-7613-11ea-8239-1a4029f9e1f4.png)
> 실험할 광고를 선택한다.
<br>

![image](https://user-images.githubusercontent.com/45448731/78383543-8bcac780-7613-11ea-8705-9ff86556770b.png)
> 광고를 시청한다.
<br>

![image](https://user-images.githubusercontent.com/45448731/78383675-ba48a280-7613-11ea-81ce-1a16e2fe5fd3.png)
> 실험 완료 화면
<br>


__2. 결과 보기__
<br>
![image](https://user-images.githubusercontent.com/45448731/78384259-ce40d400-7614-11ea-8ee8-2947265ac972.png)
> 실험자가 구매할 확률에 대해 %로 나타낸다.
<br>

![image](https://user-images.githubusercontent.com/45448731/78384336-f6303780-7614-11ea-835f-4d06ea430196.png)
> __초마다 집중도와 긍정도가 그래프로 나타나며, 최고 집중도 구간과 최고 긍정도 구간이 나타난다.__
<br>

---
## 실제 구현 화면(wiki)

[wiki로 이동하기](https://github.com/minji-o-j/Advertisement-Analysis-Program/wiki)

