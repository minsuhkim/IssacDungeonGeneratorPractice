# IssacDungeonGeneratorPractice
 Dungeon Generator Practice

해당 프로젝트에 대한 간단한 설명
빌드파일 제출해야함

## 맵 생성
1. Room 생성(Start, Empty, End)
   - Square 스프라이트를 사용하여 Wall을 배치
   -  Square 스프라이트를 사용하여 left, right, top, bottom Door 배치

2. Main Scene에서 LoadSceneAsync로 Room 들을 불러오는 방식으로 맵 생성을 진행할 예정
   - BasementStart Scene을 복사하여 BasementEmpty, BasementEnd Scene 생성

3. 자료구조 Queue를 사용
   - loadRoomQueue를 생성하여 생성하는 Room 관리
   - Update에서 LoadSceneAsync를 사용하여 Scene들을 Load(Async 사용을 위해 코루틴 활용)



<br>

## 개선점
아이디어
- 아이템
- 상점 및 아이템 방 추가
- 스테이지 추가 등


