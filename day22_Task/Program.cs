namespace day22_Task
{
    /* 우선순위 큐 구현 
     * --------------------------------------------------
     * 힙정렬 기술면접 준비 (힙 상태, 투가, 삭제, 완전이진트리 배열 표현)
     * ------------------------------------------------------------------
     * 응급실 만들기 patient = (string name, int hp(?))
     * 중간값 구하기 10000개의 숫자가 있다면, 그중 5000번째의 값 반환하라 
     */
    public class Program
    {
        // 힙은,  * 많은 자료 중 우선순위가 가장 높은 요소를 빠르게 가져오기 위해 사용하게 된다. 
        // 부모 (노드)가 항상 자식(노드)보다 우선순위가 높은 속성을 만족하는 트리기반의 자료구조
        // 사용 사례 
        // Big O    접근      탐색      
        // 
        public static void PriorityQueue()
        {
            Task_DataStructure.PriorityQueue<string> pq = new Task_DataStructure.PriorityQueue<string>();

            pq.Enqueue("감자", 3); // 이때 int 는 우선순위대상으로 가늠이 되는값이면 된다. (?)
            pq.Enqueue("양파", 5);
            pq.Enqueue("당근", 1);
            pq.Enqueue("토마토", 2);
            pq.Enqueue("마늘", 4);
            // 만약 숫자로 지정해준 값이 같을때, 나중에 들어온 element가 먼저 나오게 된다.
            while (pq.Count > 0)
            {
                Console.WriteLine(pq.Dequeue());
            }
            // Priority_Queue 는 Ascending, Descending 으로 제정립도 가능한데, default값은 Ascending 으로 제정되어있다 (해당 IComparer 메서드는) 

            //Descending 
            PriorityQueue<string, int> desc_pq = new PriorityQueue<string, int>(Comparer<int>.Create((a, b) => b - a));
            // where in Comparer/ and IComparable, in Lambda Expression, default = (a,b) => a -b .
            // 만약 a가 더 크면 >0 을 반환하게 되며 작다면 0<을 반환한다
            // 때문에, 알수있는 사실은 
            // if value >0, a 가 b 보다 작음으로, a가 b보다 (왼쪽기준) 먼저 와야하며,
            // value <0, b가 a 보다 작음으로, a는 b보다 오른쪽에 배치되야함을 시사한다
            // , 0 값이 같음, 배열에 변화가 없어도 된다. 

            // 따라서 b-a 라면, asc 와 반대 기준으로 정렬을 하게 된다. 
            // 이는 comparer 의 (return int 값이 0 > 이라면 우측값을 앞으로 배치하기 때문이다. 

        }
        public static void Emergency()
        {
            Console.WriteLine("탑라인에 오신걸 환영하네. 이곳에는 환자들이 많지. 가장 심각한친구들먼저 들여보내야만하네");
            Task_DataStructure.PriorityQueue<string> nerf_List = new Task_DataStructure.PriorityQueue<string>();
            Patient[] patients = new Patient[]
            {
                new Patient("제이스", Patient.Status.Delayed),
                new Patient("가렌", Patient.Status.Expectant), 
                new Patient("베인", Patient.Status.Urgent),
                new Patient("티모", Patient.Status.Immediate), 
                new Patient("나서스", Patient.Status.Delayed)
            };
            Patient newPatient = new Patient("카밀",Patient.Status.Immediate);

            
            foreach (Patient pat in patients)
            {
                nerf_List.Enqueue(pat.name, (int)pat.status); 
            }
            nerf_List.Enqueue(newPatient.name, ((int)newPatient.status));
            while (nerf_List.Count > 0)
                Console.WriteLine(nerf_List.Dequeue());
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            PriorityQueue();
            Emergency();
        }


    }
}