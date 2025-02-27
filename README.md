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

## 해야할 일
1. 스타트 지점에서 문이 자동으로 열리도록 (UI 버튼으로 실행해볼 예정)
2. 공격 싱크 맞추기
3. 시작화면에서 아이템 선택 -> 공격 모션 달라지게(공격력, 공격 속도)
4. 간단한 UI만들기(어떤 아이템 먹었는지, HP, 미니맵)
