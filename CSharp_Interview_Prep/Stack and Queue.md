# Stack and Queue in C# Language

### Part of the Lecture Learning: Data Structure and Algorithmic Thinking: Day 21

#### <b>Prepping for the Technical Interview</b>


1. 이진 탐색 트리의 한계점 
2. 한계점에 대한 극복 방법 
해당 한계점을 극복한 사례로 Black/Red Tree, 그리고 AVL Tree가 있는데, 기존의 L < 노드 < R 값을 기반으로 각자 다른형태로 새로운 법칙을 추가하며 불균형의 문제를 해소하고자 한다. 

3. 트리기반 자료구조의 자료 순회 방법 

Stack 을 사용하기 좋은 상황
  
Queue 을 사용하기 좋은 상황
  대기열 

### <b> Stack and Queue 구현 방법</b>

#### Stack 
기존의 List 자료구조를 아답터 패턴을 적용하여 가볍게 구현이 가능하다. 

#### Queue
기존의 List를 응용하는것은 FIFO의 특성과 List 의 값을 삽입하거나 삭제이후의 처리와 상반되어 적용하는것이 까다롭다. 
