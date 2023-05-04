using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRpg
{
    public  class BattleScene : Scene
    {
        private Monster monster;
        public BattleScene(Game game) : base(game) { }
        public override void Render()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("몬스터와 재회한다!");
            sb.AppendLine("1. 공격하기!");
            sb.AppendLine("2. Run!");
            sb.Append("행동을 선택하시오"); 

            Console.WriteLine(sb.ToString());
        }

        public override void Update()
        {
            string input = Console.ReadLine();
        }

        public void BattleStart(Monster monster)
        {
            this.monster = monster;
            Data.monsters.Remove(monster);

            Console.Clear(); 
            Console.WriteLine("전투 시작!");
            Thread.Sleep(1000);
        }
    }
}
