namespace Project_TextRpg
{
    internal class Program
    {
        //객체 지향 프로그레밍의 첫번째 심화 응용 프로젝트 

        static void Main(string[] args)
        {
            // 메인 함수에는 이렇게 게임을 객체지향으로 만들어 준 후, 
            // 이렇게 Game 객체에만 집중할수 있도록 설정하여줄수 있겠다. 
            Game game = new Game();
            game.Run(); 
        }
    }
}