#버튼 잡기 게임 (C# 코딩)

##개요 
-C# 프로그래밍
-핵심기능 : 버튼의 이동 기능,

## 실행화면
-1단계
<img width="1270" height="782" alt="버튼잡기1" src="https://github.com/user-attachments/assets/248661d8-4c0f-47d7-bc04-8b7bac495485" />
마우스가 버튼 위로 이동하면 버튼의 위치가 이동 됨, 버튼의 위치좌표가 폼 제목에 표시

-2단계
<img width="1360" height="820" alt="버튼잡기2" src="https://github.com/user-attachments/assets/6ae7143c-c8e0-4f59-afa3-3d5eeb430e08" />
버튼을 잡았을 때와 놓쳤을 때 다른 소리가 남, 버튼을 잡으면 '축하합니다~!'라는 메시지가 출력됨

-3단계
<img width="1274" height="778" alt="버튼잡기3-1" src="https://github.com/user-attachments/assets/fa954e0a-9254-49fa-bdff-1fa45c68f552" />
<img width="1278" height="772" alt="버튼잡기3-2" src="https://github.com/user-attachments/assets/08eae863-0987-4f05-b0f1-33ce6f0cad34" />
버튼을 잡으면 100점 놓치면 -10점 폼 제목에 점수와 좌표가 표시, 클릭에 성공 할 때마다 버튼이 10%씩 작아짐(최대 80%)

-4단계
<img width="1472" height="812" alt="버튼잡기4" src="https://github.com/user-attachments/assets/16f9f35a-4c37-4871-b9ab-1f616769d179" />
30번 놓치면 Game Over 메세지 출력, 다시 시작을 누르면 게임 재시


## 구현 시 어려웠던 점
-랜덤 좌표 추출 과정에서 죄표의 기준이 버튼의 좌상단을 기준으로 하기 때문에 버튼이 화면 밖으로 나가 잘리는 것을 방지하기 위해 이동 가능 촤대 좌표에서 버튼의 width와 height을 빼줌
-처음 4단계까지 완성하고 커밋한 후 다시 실행했을 때 실행 자체가 안되는 오류가 생김, 과거에 커밋했던 시점으로 코드를 되돌려서 다시 만듦 아마 GameOver 창을 위해서 GameOverForm을 하나 더 만들었는데 이것 때문에 생긴 문제인 것 같음
