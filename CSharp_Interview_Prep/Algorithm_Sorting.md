# Algorithm_Sorting C# Language

### Part of the Lecture Learning: Data Structure and Algorithmic Thinking

#### <b>Prepping for the Technical Interview</b>

기본적으로 정렬이란 어떠한 값의 조합체, 또는 자료구조에 대해서, 구체적인 법칙으로 값을 옮기는것인데, C#에서는 기본적으로 Comparison 직접비교하여 정렬하는 방식에서는 크게 

1. 선형 정렬, 

2. 분할 정복 정렬으로 구분할수있다. 
## Aim
 - 각 Sort에 대해 설명할수 있다 
 - 각 Sort 구현 원리에 대해 나열할수 있다 
 - 각 Sort를 구현할수 있다 
 - 각 Sort의 시간복잡도와 공간복잡도를 계산할수 있다. 

##  1. 선형 정렬 
선형 정렬의 전재는 n 개의 element값을 정렬시키기 위해, 전체를 확인하는 정렬법이다.
아래의 정렬들의 가장큰 차이점은, 값을 비교하는 방식과, 재배치하는 방법에 있습니다. 

### 1. Selection Sort: 선택정렬 (O n^2)

#### 순서 (Default = Ascending)
 - 값이 들어올 장소를 선택합니다 
 - 장소를 기준으로 남은값을 탐색하며 가장 낮은 값을 구합니다 
 - 장소값과 결정된 가장 낮은 값을 스왑합니다. 

1. 선택정렬이란 우선적으로 사용자의 규칙의 첫번째 값을 찾기위해 탐색합니다. 탐색이후에는 i (where i = 첫번째 값)과 조건에 맞는 최상의 값을 스왑합니다 

2. 정렬이후에는 정렬을 마친 시점부터 다시 끝까지 탐색하여 적절한 다음값을 찾아 i+1 번째값과 swap 합니다. 
Big O기준 다른 선형정렬들과 매우 비슷하지만 다른점이 있다면 최고의 상황에서는 다른 정렬(선형정렬)에 비해 비교적 낮을수도 있다. 

### 2. Insertion Sort: 삽입정렬 
삽입정렬은 선택정렬, 그리고 버블정렬과는다르게, 
값을 조건에 따라 연속적인 값사이에 배치시키기위하여 
나열된 값들을 재복사하며 정렬을 진행하는 정렬법입니다. 

추가적으로 삽입정렬은 첫번째 값에 대해 이미 요건에 충족되는 값이라 전제를 함에 따라, 예측이 불가능한 집합체에 대해서는 사용이 적절치 않겠습니다. 
### 3. Bubble Sort: 버블정렬 
버블정렬은 처음값과 (i) 그다음값을 비교하며 (i+1)사용자의 요건에 따라 정리하며 값이 모두 정렬될때까지 진행합니다. 
해당 정렬은 더이상 정렬이 필요하지않을때까지 비교함에 따라 규칙에 의거한 스왑을 진행합니다.
#### 최적화 여부 
	1.  

##  2. 분할 정복 정렬 

기본적으로 분할정복의 시간복잡도는 O (N log N) 이지만, 
각각 정렬들의 해당 속성에 따라서 장단점이 구분이 됨에 따라 특징이 구분이 된다.

### 1. 힙정렬 

	-동작방법 
	1. 값이 새로 들어오면 이진완전트리를 유지하는 상황임을 전제로, 리스트의 마지막 위치에 값을 넣습니다. 
	2. 이후에 부모값과 비교하며 차례대로 올라갑니다. 
	3. 값을 추출할때에는 최상위값을 추출후 마지막우선순위값을 최상위로 
힙정렬은 기본적으로 힙상태를 유지하는 힙자료구조형에 위탁하며 정렬을 실시하는 방식이다. 
힙정렬의 약점은 

1. 캐쉬 적중률이 낮다.
캐쉬 메모리로 자주 이용되는 값들을 램으로 부터 가져오는데, 힙자료구조 특성상, 배열에 연속적으로 저장되어있지만 값을 다룰때에 
1. Poor Cache Locality (which often cause frequent cache evictions => leading to performance degradation)
2. Not a stable sort algorithm (does not gaurantee uniform sorted value for equal priority values)
3. Requires higher space complexity compared to QuickSort, and 일반적 merge sort 
3. 
### 2. 합병정렬
	-동작방법 
	1. 우선 해당 집합체를 절반, 또는 절반에 가까운 값으로 나눕니다 (this may change, 2 ways, 4 ways and more). 
	2. 반쪽들을 Recursively 나누며, 하나의 값을 지닐때까지 반복합니다. 
	3. (이때 나눠지며 병합되는 값들은 일시적으로 힙영역에 나눠지며 저장됩니다)나눠진 값을 하나씩 merge 하며 정렬도 같이 수행하며, 각 절반들이 모두 병합할때까지 병합을 수행합니다. 
	4. 마지막으로 병합을 모두 마친 절반들을 병합하며 동시에 재정렬을 같이 시행합니다. 
**While there's a case for In-Place Merge Sorting, we'll discuss traditional sorting here. 
합병정렬은 재귀적으로 값을 계속해서 나눈다음, 최소단위인 하나의 값을 base case 로 잡으며, 이때부터 정렬을 시행하는 방식이다.

	-장점 
	-분할적으로 시행되는 정렬은 분산작업으로 인해 큰 파일을 정렬해야할때에 멀티코어를 사용하는 장치에는 특히 유리하게 작용할수있다. 
	-또한 다른 분할정복 정렬과는 다르게 이것은 <b>안정한 정렬</b>을 진행한다.

합병정렬 의 단점은 이러하다 

	-단점
	-	추가적인 메모리 필요: 분할정복을 시행시 분할된값에 대한 추가적인 메모리가 요구된다(O(N)). 따라서 추가적인 메모리를 할당, 및 사용함에 따라 Overhead가 발생,  
	-Pivot 값을 마지막, 또는 처음값을 지정할때 발생하는 문제로써, 
	-또한 다른 분할정복 정렬과는 다르게 이것은 안정한 정렬을 진행한다.

	-극복방법 


### 3. 퀵정렬 (Default = Ascending) 
	-동작방법 
	1. 기준값이 되는 pivot을 선택, 배열의 마지막에 임시로 배치한다.  
	2. 오른쪽, 왼쪽 포인터를 선정한다. 
	3. 오른쪽은 왼쪽으로가며 피벗보다 작은수 탐색 
	4. 왼쪽은 오른쪽으로 가며 피벗보다 큰수를 탐색 
	5. 3,4에서 발생되는 조건에 따라 값을 교환 
	6. 3,4,5를 반복하며 왼쪽 오른쪽 포인터가 교차시에 피벗값과 왼쪽값의 값과 역할군을 교체 

<5, 3, 7, 1, 9, 2, 8, 4, 6> 
대부분 가장 왼쪽, 또는 오른값을 최초기준값을 설정 (최적화에 따라 중간값을 설정하기도 함.
해당 알고리즘은 i,j가 지날때 j를 기준점으로 변경하며, j 를 기준으로 이분할 실시함. 
i, j 기준으로 낮은값은 왼쪽, 높은값은 오른쪽에 이분할 정렬 

<2, 3, 4, 1, 5, 9, 8, 7, 6> 5 기준점, (<7,4> <9, 2> <2,5> 스왑), 2 기준점, <2,3,4,1> 5 <9,8,7,6> 분할 정복
<2,3,4,1>2 기준점 => <1,3> <1,2> 스왑), <1> 2 <4,3> => <3,4> => 3, 4  (1,2,3,4)5 
<9,8,7,6> 9 기준점, <6,9> => <6,8,7,9> 6기준점 => <6,8,7,9> => 6<8,7,9> : This is because pivot is now 6, && i == j, therefore j값이 start index 로 이동한후 while loop가 종료되기 때문이다. 
<8,7,9> 8기준점, <7,8> =>  <7>8<9> => (6,7,8,9)
(1,2,3,4)5 (6,7,8,9)


퀵정렬 또한 단점은 이러하다. 

	-단점
	-	최악의 경우 Big O = O(n^2)
	-Pivot 값을 적절치않게 선택시 발생할수있는 문제이며, 마지막, 또는 처음값을 지정할때 발생할수 있는 문제이다 
	-또한 이미 다른형태의 정렬이 이루어진 집합체일때도 발생할수 있다 

	-	불안정한 정렬 
	-힙정렬, 그리고 Selection Sort 와 비슷하게 안정된 정렬을 보장하지않는다. 

극복방법
	
	-퀵정렬을 이용시에는 적절한 피봇을 선택하는것이 중요하다.
	-따라서 중간요소를 피벗으로 이용하며 단점을 보완할수 있다. (Minimizing case for O(N^2)) 

퀵정렬의 장점은 이러하다. 

	-해당 기준은 (일반 배열을 정렬할때이며, LinkedList과는 예ㅓㅓㅓ자주 비교되는 Merge Sort 과는 다르게 

##  3. 하이브리드 정렬 
C# and C++ use IntroSort 
	Based on the QuickSort, if the Time-Complexity gets cloase to O(N^2), changes to Heap Sort, and or if the size pool is small, would also likely to choose Selection Sort. 
 
 
