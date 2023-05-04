using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRpg
{
    internal class MainMenuScene : Scene
    {
        public MainMenuScene(Game game): base(game) 
        {
            
        }
        // 메인메뉴에서 출력해야할 요소들을 정의하여보자. 
        public override void Render()
        {
            //TODO: Define MainMenuScene Render
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("게임 시작");
            sb.AppendLine("게임 종료");
            sb.Append("메뉴를 선택하세요: ");

            Console.Write(sb.ToString());
        }
        // 메인메뉴Scene 에서 갱신할때 구현되는것들 
        public override void Update()
        {
            //TODO: Define MainMenuScene Update
            string input = Console.ReadLine();

            int command; 

            if (!int.TryParse(input, out command))
            {
                Console.WriteLine("잘못 입력 하셨습니다");
                Thread.Sleep(1000); // where 1000 ms = 1 s; 
                return; 
            }

            switch(command)
            {
                case 1:
                    // TODO: 게임 시작 1. Game 에서 GameStart 구현, 
                    game.GameStart(); 
                    Console.WriteLine("게임 시작");
                    break;
                case 2:
                    // TODO: 게임 종료 
                    game.GameOver();
                    Console.WriteLine("게임 종료");
                    break;
                default:
                    Console.WriteLine("잘못 입력하셨습니다");
                    Thread.Sleep(1000); // give enough time for user to see the response 
                    break; 
            }
        }
    }
}
