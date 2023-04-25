# Iterators C# Language

### Part of the Lecture Learning: Data Structure and Algorithmic Thinking

#### <b>Prepping for the Technical Interview</b>

1. 이진 탐색 트리의 한계점 
2. 한계점에 대한 극복 방법 
3. 이진탐색트리의 순회 방법과 순회 순서 
Source: https://www.freecodecamp.org/news/binary-search-tree-traversal-inorder-preorder-post-order-for-bst/, and Lecture Learning from Day 23: Binary Search Tree

## 반복기는 디자인패턴에서 왜 중요할까요?

기본적으로 22 GoF 디자인 패턴 기준 행동 디자인 패턴으로 분류되는 패턴들은, 알고리즘/ 또는 객체간의 책임할당에 중점을 두고 있습니다. 그중에서 반복자를 알아봅시다. 

자료구조방식을 선택하고, 자료의 집합체를 만드는것도 까다로운 작업이지만, 이후의 집합체를 처리하는 방식또한 생각해봐야하는 영역입니다. 
특히 Complex data structure 같은 경우, 편의에 따라서 다른방식으로 (단순 linear 하게 자료를 순회가 불가능한 경우에), 다른 방식으로 자료집합체에 대해서 접근하는 방식이 필요합니다. 

이러한 문제앞에, 반복자 패턴은 다양한 접근방식의 도입의 문제에 관하여 일렬의 행동방식/패턴을 제시합니다. 

## 제시하는 것
특정한 방식으로 복잡한 자료구조의 element/ 혹은 값에 대하여 다룰수 있는 매서드를 담은 하나의 객체를 생성하는것을 반복자 패턴은 제시합니다. 

C# 같은 경우, 반복기의 도입에 관한문제를 IEnumerator/IEnumerable 인터페이스로써, 
반복기는 대부분 자료구조들이 지원을 하며, 어떠한 객체에서 반복기를 통해서 구현을 하게 될때, 다양한 자료구조형의 값에 대한 접근방식과, 알고리즘 적용 방식에 대해서 C#은 기준을 제시한다.

기본적으로 반복기는 
1. 리셋하는기능과, Reset () = set to the first pointer to search 
2. 키를 움직일수있는 기능과, MoveNext() Move to the  next pointer, if pointer == null, prints false 
3. 키가 가리키는 값을 도출하는 기능과, Current() Prints the value the pointer is pointing to (where in C#, its a pre-Iterator, considers the index prior to progress as a value to return. 
4. 마지막으로 키가 끝을 도달하였을때 Dispose 하는 (GC 와 밀접한 연관이 있어보이지만, 아직은 무지하다) when the MoveNext prints false, Iter.Dispose(); 

이러한 기본적인 툴을 C#은 제시하며, 프로그래머인 우리는 다루는 자료구조와, 객체에 특성에 맞게 반복기를 재구성할수 있게 된다. 



 