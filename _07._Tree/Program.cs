namespace _07._Tree
{
    //Binary Search Tree 
    // 
    internal class Program
    {
        void BinarySearchTree()
        {
            SortedSet<int> sortedSet = new SortedSet<int>();
            //Where Key = Data 

            sortedSet.Add(1);
            sortedSet.Add(3);
            sortedSet.Add(7);
            sortedSet.Add(2);
            sortedSet.Add(5);

            int searchValue1;
            //탐색 이진탐색트리 자료구조에서 값 탐색 
            bool find = sortedSet.TryGetValue(3, out searchValue1);

            //삭제 
            sortedSet.Remove(3); 

            //Key Value 기준 이진탐색트리 
            // Where Key = for search, and Data = what's essentially a relevant data or datum  
            SortedDictionary<string, Monster> sortedDict = new SortedDictionary<string, Monster>();

            sortedDict.Add("피카츄", new Monster() { name = "피카츄", health = 40 });
            sortedDict.Add("파이리", new Monster() { name = "파이리", health = 80 });

            Monster monster; 
            sortedDict.TryGetValue("파이리", out monster); //파이리 탐색시도 
            Monster indexerMonster = sortedDict["파이리"]; // 인덱서를 통한 탐색또한 지원해준다. 

        }

        public class Monster
        {
            public string name { get; set; }
            public int health { get; set; }

            public Monster()
            {
                this.name = name;
                this.health = health;
            }

        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}