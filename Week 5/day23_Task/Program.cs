namespace day23_Task
{
    /*1. 이진탐색트리 탐색, 추가, 삭제 구현
     *2. 이진탐색트리의 한계점과 극복방법 조사
     *3. 이진탐색트리의 순회방법 조사와 순회순서
     */

    internal class Program
    {
        public static void Bst_test()
        {
            Task_DataStructure.BinarySearchTree<int> bst_Tree = new Task_DataStructure.BinarySearchTree<int>();
            bst_Tree.Add(1);
            bst_Tree.Add(5);
            bst_Tree.Add(6);
            bst_Tree.Add(2);
            bst_Tree.Add(3);
            bst_Tree.Add(4);
            bst_Tree.Add(7);
            bst_Tree.Print(); // 중위 순회방법을 적용한 기능또한 테스트 (오름차로 나온다면 성공) 

            bst_Tree.Remove(5);
            bst_Tree.Print();
            int tryGet1;
            bool test= bst_Tree.TryGetValue(1, out tryGet1);
            Console.WriteLine($"TryGetValue 기능 테스트 결과 {test}, {tryGet1}");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Bst_test(); // Print Successful! 
        }
    }
}