using System.Runtime.InteropServices;

namespace Q7
{
    internal class Program
    {
        // 해당게임은 이벤트를 통해서 상호작용을 일으키는 객체지향적 프로그램을 제작하기 위해 집중되었습니다 
        static void Main(string[] args)
        {
            GameRender gameRender;
            GameUpdate gameUpdate;
            GameInput gameInput;
            Map map;
            Player player;
            Direction direction;

            Game game = new Game();

            game.InIt(); 
        }

    
    }
}