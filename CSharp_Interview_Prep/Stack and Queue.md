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
> Stack 과 Queue를 어떤 형태로 응용할수 있을까를 이해하고, 프로젝트 내에서 어떤식으로 구성을 할수 있는지 이해해볼수 있다.
> Queue의 구현 원리에 대해서도 설명할수 있도록 하자.ㅏ 
#### Stack 
기존의 List 자료구조를 아답터 패턴을 적용하여 가볍게 구현이 가능하다. 
- 예시 : 팝업 UI. 

#### Queue
기존의 List를 응용하는것은 FIFO의 특성과 List 의 값을 삽입하거나 삭제이후의 처리와 상반되어 적용하는것이 까다롭다. 
- 예시 : 대기열.

크게 방법은 2가지로 있으며, 
1. LinkedList를 통해서 구현한다.
2. 기존 배열을 통하여 Circular Buffer 형태로 구성한다.

이때 주의 사항 
1. 배열이 꽉찬 상황을 구분하는 방법.
  2가지의 Key로 구분하며 (Head: 값을 채우는 메모리 위치를 가리키는,  and Tail: 다음으로 Dequeue()될값을 지정하는)을 두어 구분한다.

  Head 과 Tail은 생성당시 한칸을 구분하여

3. 배열이 다차서 배열의 크기를 늘려야하는 경우
  경우 1.
  경우 2. 
```
test test
```
