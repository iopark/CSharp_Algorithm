namespace day16_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Q1. 문자열 속에 문자 찾기 
            Console.Write("The Sentence: ");
            string input = Console.ReadLine();
            Console.Write("The Word: ");
            string word = Console.ReadLine();

            string change = input.ToUpper();
            string findWord = word.ToUpper();
            int wordStart = change.IndexOf(findWord);
            //배열의 카운트 시작은 0임으로,  
            Console.WriteLine(wordStart);
            // string.IndexOf 단어우선 검색, 있으면 시작지점 인덱스 int 값으로 반환 
            // 없다면 -1 반환


        }
    }
}