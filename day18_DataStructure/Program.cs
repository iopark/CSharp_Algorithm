namespace day18_DataStructure
{
    /* 1. 선형리스트 구현 - MSDN C# List 참고
     * Indexer[], Add, Remove, Find, FindIndex, Count, etc. 
     * 배열, 선형리스트 기술면접 정리 
     */ 
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            day18_DataStructure.ArrayList<int> \
        }

        void Test_List()
        {
            //Console.WriteLine("Hello, World!");
            day18_DataStructure.List<string> newList = new day18_DataStructure.List<string>();
            newList.Add("1번 데이터");
            newList.Add("2번 데이터");
            newList.Add("3번 데이터");

            newList.Remove("2번 데이터");
            newList.RemoveAt(0);
            newList.Add("3번 데이터");
            newList.Add("3번 데이터");
            //newList.RemoveAt(5); throw new Index_related_exceptions 


            newList[0] = "1번 데이터 다시 소환";
            string str = newList[0];

            for (int i = 0; i < newList.Count; i++)
            {
                Console.WriteLine(newList[i]);
            }

            string? findValue = newList.Find(x => x.Contains('4'));
            int intIndex = newList.FindIndex(x => x.Contains('3'));
            Console.WriteLine(intIndex);
        }
    }
}