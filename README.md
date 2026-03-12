#버튼 잡기 게임 (C# 코딩)

##개요 
-C# 프로그래밍
-핵심기능 : 버튼의 이동 기능,

## 실행화면
-1단계
<img width="1270" height="782" alt="버튼잡기1" src="https://github.com/user-attachments/assets/248661d8-4c0f-47d7-bc04-8b7bac495485" />
마우스가 버튼 위로 이동하면 버튼의 위치가 이동 됨

-2단계

-3단계

-4단계
<img width="1270" height="771" alt="스크린샷 2026-03-12 130402" src="https://github.com/user-attachments/assets/92a60c3b-fff7-404c-884b-dde76cd861eb" />
30번 놓치면 Game Over 메세지 출력, 확인을 누르면 모든 버튼 비활성화 처리, 다시를 누르면 게임 재식작


## 구현 시 어려웠던 점
-랜덤 좌표 추출 과정에서 죄표의 기준이 버튼의 좌상단을 기준으로 하기 때문에 버튼이 화면 밖으로 나가 잘리는 것을 방지하기 위해 이동 가능 촤대 좌표에서 버튼의 width와 height을 빼줌
