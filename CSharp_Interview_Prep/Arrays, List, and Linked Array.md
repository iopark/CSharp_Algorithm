# Arrays, Linked Arrays, & List in the C# Language

### Part of the Lecture Learning: Data Structure and Algorithmic Thinking

#### <b>Prepping for the Technical Interview</b>

Whilst all the <u>listed</u> classes holds the common theme in the grouping of the unique datum, the way each is dealt within its data structure and the way each is handled varies; with its differences uniquely taking its parts in OOP dynamic.
``` cs
//Array 
int[] int_Array = new int[10]; // Declaring an Array
string[] str_Array = new string[5];

//ArrayList
List<int> int_List = new List<int>(); // Declaring an ArrayList
List<string> str_List = new List<string>();

//LinkedList
LinkedList<string> linked_List = new LinkedList<string>(); // Declaring an Linked Array (Will learn more about it/discussed further in the future) 

```

04/09/2023 

우선 기본적으로 어떤 Array 든 
연속적인 메모리상에 동일한 타입의 요소를 일렬로 저장하는 자료구조이다. 

메모리속에 저장되는 데이터의 관점으로 볼때에, 
배열이 효용성이 있는 이유는 동일한 자료형의 집합이기 때문인데, 이것은 자료형마다 정해진 메모리에게 정해진 크기가 있기 때문이며, 이것을 활용한것이 배열의 Index요소이다. 
예시로, int[] array = int[10] 같은 경우, int는 4byte로의 값이 연속적으로 나열되어 메모리속에 저장이 되며, 그렇기에 각 자료형크기의 배수로/  배열의 크기에 따라 자료값의 총합의 나누기로 나누게 됨으로 메모리에 연속적으로 저장된 일정한 크기의 데이터 값을 접근하는 방식이다. 

연속적으로 저장된 값을 활용하는 예시로써, array[3] 을 호출할때에는, 해당변수의 정해진 자료형의 byte 값의 3 을 곱한 값을 호출함에 따라, 3번째 자리에 저장된 값을 찾을수 있게된다. 
문법적으론, array[200] = calling index val which is not initialized, 은 말이 아예안되는것은 아니다. 때문에, C#속에서는 해당 변수의 인덱스 크기에 대해 예외처리 기능이 포함되어 있다. 

배열의 시간 복잡도 
배열속에서는, n 만큼의 데이터가 저장된 배열을 탐색할때에, 값의 접근은 O(1) 이지만, 배열은 선형탐색을 통해서 처리 하기 때문에 O(n) 만큼 탐색하게 되는 시간 complexity 가 있다. 


그럼 List 는 어떨까?
우선 자료 구조적 관점에서 메모리에 어떤형태로 다뤄지고 있는지 살펴볼 필요가있다.\
List 의 최대크기는 64bit Windows 기준, maximum capacity to 2 billion elements 으로 설정될수도 있다 (최대 크기 = Maximum Capacity in List Class)\
Array와 다르게 선언된 자료형에 따라 미리 입력된 크기에 비례한 고정된 크기를 힙영역에서 갖는것이아닌, \
크기를 임의로 우선 default에 의거하여 설정하며, (where default = default_Capacity), Count < Capacity 상태를 유지하기 위해 \
Capacity가 올라가는 경우 새로운 인스턴스를 생성하며 (힙영역에서 새로운 List Class 값 생성), 해당값의 주소값을 이전하는 방식으로 구동한다.  
C#언어에서는 Array 와 비슷하게, 길이에 사용하는 Count 이상의 값을 유저가 강제로 호출한다면 C#자체에서 설정한 예외처리를 통해 통제한다. 

이렇게 태생적인 차이는 배열을 찾는 메서드 에서도 충분히 유추가 가능한데, Array. Length 와 List.Count으로써,\
Array는 구현당시 크기에 따라서 연속적으로 선언된 자료형에 따라 고정된 크기로 저장하는것이기에 해당 배열의 크기를 이미 값추적 및 사용이 가능한 상태이지만, 
(therefore size of object treated like an fullly grown adult)\
List 는 Capacity 따로, Count 따로 가며, 값을 추가할때마다 반응하는 사실이 메서드 네이밍당시 어느정도 반영된것을 유추해볼수 있다. ( where Count = ~ Array.Length() ) \
and If count = Capacity, copies the following array internally, before relocating into array with bigger capacity; 

Array 가 연속적인 값으로 저장되는 또 다른 이유는 선언된 특정 instance에 대해서 heap 영역에 저장이 될때 frag. 형태로 저장될수는 없기 때문이기도하지 않을까 생각이 들지만,(전혀 사실이 아니었고) 
이건 조금더 찾아보기로 하자 (연결 리스트로 바로 반론 개박살)

Linked List 

시간복잡도 
  접근 
  탐색 
  삽입 
  삭제 

Types 
  단방향 LinkedList 
  양방향 LinkedList 
  환형<C#>LinkedList 



