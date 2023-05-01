namespace day24_Task
{
    /* 1. Dictionary 구현 
     * 2. 해싱과 해시함수에 대한 조사 (해시의 원리, 해싱함수의 효율, 등) 
     * 3. 해시테이블의 충돌과 충돌 해결 방안 
     */ 

    internal class Program
    {
        public static void Dictionary()
        {
            Task_DataStructure.Dictionary<string, Item> dictionary = new Task_DataStructure.Dictionary<string, Item>();
            // 기능 1. 키, 값을 키에 따라서 저장 하는 Add( key, value) 
            dictionary.Add("초기아이템", new Item("초보자용 검", 10));
            dictionary.Add("초기방어구", new Item("초보자용 방패", 30));

            Console.WriteLine($"인덱서 기능 확인, {dictionary["초기아이템"]}");
            // 기능 2. Remove(Key)로 키를 입력받아 해당키를 해쉬하여 지정된 주소값의 value를 삭제 
            dictionary.Remove("초기방어구");
            // 기능 3. ContainsKey
            bool test = dictionary.ContainsKey("초기방어구");
            Console.WriteLine($"ContainsKey, FindIndex, Remove도 테스트 {test}"); 
            // 기능 4. TryGetValue
        }
        public class Item
        {
            public string name;
            public int weight;

            public Item(string name, int weight)
            {
                this.name = name;
                this.weight = weight;
            }
        }
        static void Main(string[] args)
        {
            Dictionary();// 기능 구현 완료(?) 
            Console.WriteLine("Hello, World!");
        }
    }
}