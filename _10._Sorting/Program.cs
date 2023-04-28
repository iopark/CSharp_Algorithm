using System.Globalization;

namespace _10._Sorting
{
    //정렬 알고리즘에 대해 이해하여 보기 
    // 1. 선형정렬 3종 구현 원리조사 
    // 2. 분할정복정렬 3종 구현 원리조사 
    // 3. 각각 정렬들의 속성에 따른 특징 조사 (분할정복정렬3종)
    //
    // 원리가 있을텐데, 해당 속성에 따라서 장단점이 구분이 됨에 따라 특징이 구분이 됨에 
    //학습 목표 
    // 각각 정렬들의 속성에 따른 원리가 있을텐데, 해당 속성에 따라서 장단점이 구분이 됨에 따라 특징이 구분이 된다. 

    internal class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        private static void Swap(IList<int> list, int left, int right)
        {
            int temp = list[left];
            list[left] = list[right]; 
            list[right] = temp;
        }
        //선택정렬 
        public void SelectionSort(IList<int> list)
        {
            for (int i = 1; i < list.Count; i++)
            {
                int minIndex = i;
                int j;
                for (j = i+1; j < list.Count; j++)
                {
                    if (list[j] < list[minIndex])
                    {
                        minIndex = i; 
                    }
                }
                Swap(list, i, minIndex); 
            }
        }

        //데이터를 하나씩 꺼내어 정렬하는 방식 
        public void InsertionSort(IList<int> list)
        {
            for (int i = 1; i <list.Count; i ++)
            {
                int key = list[i];
                int j; 
                for (j = i-1; j >= 0 && key < list[j]; j--) // i 부터 다시 시작점으로 탐색하며 만약 값이 더 작다면 
                {
                    list[j+1] = list[j]; // for all the iterating value where key < list[j], copy to the right 
                }
                list[j+1] = key;
            }
        }
        // 인접한 값을 반복적으로 정렬함으로써 집합체 전체를 일정한 규칙으로 정렬하는 방법 
        public void BubbleSort(IList<int> list)
        {
            for (int i = 0; i < list.Count; i ++)
            {
                for (int j = 1; j < list.Count; j ++)
                {
                    if (list[i] < list[j])
                    {
                        Swap(list, i, j); 
                    }
                }
            }
        }


        /* 분할 정복 정렬 
         */

        //1. 힙정렬 
        /// <summary>
        /// 삽입에 드는 비용 (O (N LogN)) 
        /// </summary>
        /// <param name="list"></param>
        public static void HeapSort(IList<int> list)
        {
            PriorityQueue<int, int> pq = new PriorityQueue<int, int>();

            for (int i = 0; i < list.Count; i++)
            {
                pq.Enqueue(list[i], list[i]); // where (first, second), first is the value and the second would represent the priority of that value. 
                // this would automatically heap sort values in ascending order (by default). 
            }

            for (int i = 0; i < list.Count; i++)
            {
                list[i] = pq.Dequeue(); // simply deQuueuing the value would 
            }
        }


        // <합병정렬>
        // M&A 데이터를 2분할하여 정렬 후 합병
        public static void MergeSort(IList<int> list, int left, int right)
        {
            if (left == right) return; // base case for the recursion, 가장 낮은 단위의 인덱스 

            int mid = (left + right) / 2;
            MergeSort(list, left, mid);
            MergeSort(list, mid + 1, right); // mid 가 겹치는것을 방지 
            Merge(list, left, mid, right);
        }
        public static void Merge(IList<int> list, int left, int mid, int right)
        {
            List<int> sortedList = new List<int>();
            int leftIndex = left;
            int rightIndex = mid + 1;

            // 분할 정렬된 List를 병합
            while (leftIndex <= mid && rightIndex <= right)
            {
                if (list[leftIndex] < list[rightIndex])
                    sortedList.Add(list[leftIndex++]);
                else
                    sortedList.Add(list[rightIndex++]);
            }

            if (leftIndex > mid)    // 왼쪽 List가 먼저 소진 됐을 경우
            {
                for (int i = rightIndex; i <= right; i++)
                    sortedList.Add(list[i]);
            }
            else  // 오른쪽 List가 먼저 소진 됐을 경우
            {
                for (int i = leftIndex; i <= mid; i++)
                    sortedList.Add(list[i]);
            }

            // 정렬된 sortedList를 list로 재복사
            for (int i = left; i <= right; i++)
            {
                list[i] = sortedList[i - left];
            }
        }

        public static void QuickSort(IList<int> list, int start, int end)
        {
            if (start >= end) return;

            int pivotIndex = start; // 시작점 
            int leftIndex = pivotIndex + 1; // i  
            int rightIndex = end; //j

            while (leftIndex <= rightIndex) // 엇갈릴때까지 반복
            {
                // pivot보다 큰 값을 만날때까지
                while (list[leftIndex] <= list[pivotIndex] && leftIndex < end)
                    leftIndex++;
                while (list[rightIndex] >= list[pivotIndex] && rightIndex > start)
                    rightIndex--;

                if (leftIndex < rightIndex)     // 엇갈리지 않았다면
                    Swap(list, leftIndex, rightIndex);
                else    // 엇갈렸다면
                    Swap(list, pivotIndex, rightIndex); // where l < r, pivot값하고 먼저가게된 index값과 교환시켜준다. 
            }

            QuickSort(list, start, rightIndex - 1);
            QuickSort(list, rightIndex + 1, end);
        }

    }
}