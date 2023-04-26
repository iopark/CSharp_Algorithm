# Binary Search Tree C# Language

### Part of the Lecture Learning: Data Structure and Algorithmic Thinking
### + Design Pattern: Structural Pattern 

#### <b>Prepping for the Technical Interview</b>

어답터 패턴이란, 한 클래스의 인터페이스를 사용하고자 하는 다른 인터페이스로 변환 (Part of Lecture Day 21 on Adapter Pattern) 

List - Stack 은 해당 패턴이 순조롭지만 
List - Queue 

이는 List -Stack 에서는 값을 반환한 이후에는 뒷값만 없어지기에 삭제 할때 값이 이상이 없지만, List - Queue 는 제일 앞의 값이 반환 이후 삭제가 되기 때문에 모든 값에 대하여 재배치가 요구되며 (기존 list 의 접근에 대해서 O(1) 이 아닌 (O(n)) 으로 적용되게 된다 ) 

Adaptee - Adapter 관계에서 자료구조의 형태에 따라서 효율적으로 (where 척도 is Big O on 접근, 탐색, 삽입, 삭제) 해당 패턴을 이용하는 여부가 달라지게 된다. 만약 Adaptee - Adapter 관계에서 접근, 탐색, 삽입, 삭제 에 대해서 Adapter 의 Big-O가 더 커지게 된다면 아마 어댑터 패턴은 지양될 것이다. 

예시로 Queue 구현 당시 LinkedList를 활용하여 구현이 가능은 하지만, C#특성상 가상머신이 관리하는 힙영역에 노드기반 자료형은 특히 GC 에 부화를 많이 걸수밖에 없다. 
이와 같은 이유로, Queue또한 C# 자체 제작당시 아답터 패턴으로 생성되지 않았으며, 배열기반으로 생성이 되었다
