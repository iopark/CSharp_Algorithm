using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRpg
{
    // 맵 Scene 이 불려지는 상황은 최초 게임이 시작될때 구현이 되는데, 동시에 필요한 값으로는 
    // 
    internal class MapScene : Scene
    {
        public MapScene(Game game) : base(game) { }
        public override void Render()
        {
            // TODO: 맵씬 표현 구현 
            PrintMap();
        }

        public override void Update()
        {
            ConsoleKeyInfo input = Console.ReadKey();

            // 플레이어 이동 
            // 플레이어 위치 이동
            switch (input.Key)
            {
                case ConsoleKey.UpArrow:
                    Data.player.Move(Direction.Up);
                    break;
                case ConsoleKey.DownArrow:
                    Data.player.Move(Direction.Down);
                    break;
                case ConsoleKey.LeftArrow:
                    Data.player.Move(Direction.Left);
                    break;
                case ConsoleKey.RightArrow:
                    Data.player.Move(Direction.Right);
                    break;
            }

            // 플레이어 몬스터 접근 
            Monster monsterInPos = Data.MonsterInPos(Data.player.position);
            if (monsterInPos != null)
            {
                game.BattleStart(monsterInPos);
                // 전투 시작
                return; 
            }

            //몬스터 이동 
            foreach (Monster monster in Data.monsters)
            {
                monster.MoveAction();
                
                if (monster.position.x == Data.player.position.x &&
                    monster.position.y == Data.player.position.y)
                {
                    // 전투 시작 
                    game.BattleStart(monster); 
                    return;
                }
            }

        }

        private void PrintMap()
        {
            Console.ForegroundColor = ConsoleColor.White;
            StringBuilder sb = new StringBuilder();
            for (int y = 0; y < Data.map.GetLength(0); y++)
            {
                for (int x = 0; x < Data.map.GetLength(1); x++)
                {
                    if (Data.map[y, x])
                        sb.Append('　'); 
                    else 
                        sb.Append('▨');
                }
                sb.AppendLine();
            }

            Console.Write(sb.ToString());

            Console.ForegroundColor = ConsoleColor.Green;
            foreach(Monster monster in Data.monsters)
            {
                Console.SetCursorPosition(monster.position.x *2, monster.position.y);
                Console.Write(monster.icon);
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(Data.player.position.x *2 , Data.player.position.y);
            Console.Write(Data.player.icon);
        }

        
    }
}
