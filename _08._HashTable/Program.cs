namespace _08._HashTable
{
    internal class Program
    {
        /* 해시테이블:
         * 키 값을 헤시함수로 헤싱하여,헤시 테이블의 특정 위치로, 직접 엑세스하도록 만든 방식이다. 
         * 헤시 : 임의로 길이를 가진 데이트를 고정된 길이를 가진 데이터로 매핑하는 자료구조이다
         */ 

        void Dictionary()
        {
            Dictionary<string, Item> dictionary = new Dictionary<string, Item>();
            // 기능 1. 키, 값을 키에 따라서 저장 하는 Add( key, value) 
            dictionary.Add("초기아이템", new Item("초보자용 검", 10));
            dictionary.Add("초기방어구", new Item("초보자용 방패", 30));

            Console.WriteLine(dictionary["초기아이템"]);
            // 기능 2. Remove(Key)로 키를 입력받아 해당키를 해쉬하여 지정된 주소값의 value를 삭제 
            dictionary.Remove("초기방어구");
            // 기능 3. ContainsKey
            dictionary.ContainsKey("초기아이템"); 
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
            Console.WriteLine("Hello, World!");
        }
    }
}