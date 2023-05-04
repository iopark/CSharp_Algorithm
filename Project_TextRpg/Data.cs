using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRpg
{
    public static class Data
    {
        public static bool[,] map;
        public static Player player;
        public static List<Monster> monsters;
        public static void Init()
        {
            player = new Player();
            monsters = new List<Monster>();

        }

        public static void Release()
        {

        }
        public static void LoadLevel()
        {
            // working under Game InIt 
            map = new bool[,]
               {
                { false, false, false, false, false, false, false, false, false, false, false, false, false, false },
                { false,  true,  true,  true,  true, false,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true, false,  true,  true,  true,  true, false, false,  true, false },
                { false,  true,  true,  true,  true, false,  true,  true,  true,  true, false,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true, false,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true, false, false, false, false,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false,  true, false },
                { false,  true, false,  true,  true,  true,  true,  true,  true,  true,  true, false,  true, false },
                { false,  true, false,  true,  true,  true,  true,  true,  true,  true,  true, false,  true, false },
                { false,  true, false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true, false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false, false, false, false, false, false, false, false, false, false, false, false, false, false },
               };

            player.position = new Position(2, 2);

            Monster slime1 = new Slime(); 
            slime1.position = new Position(3, 5);
            monsters.Add(slime1); 

            Monster slime2 = new Slime();
            slime2.position = new Position(7, 5);
            monsters.Add(slime2);

            Monster dragon = new Dragon();
            dragon.position = new Position(12, 12);
            monsters.Add(dragon);
        }

        public static Monster MonsterInPos(Position pos)
        {
            foreach (Monster monster in monsters)
            {
                if (monster.position.x == pos.x &&
                    monster.position.y == pos.y)
                {
                    return monster;
                }
            }
            return null;
        }

        private Point SpawnPoint()
    }
}
