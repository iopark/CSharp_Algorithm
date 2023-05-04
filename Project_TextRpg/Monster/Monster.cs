using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRpg
{
    public abstract class Monster : IMonster_Attribute
    {
        public char icon = '▼';
        public Position position; // 몬스터또한 위치에 대한 값을 지니고 있다. 
        public int hp;
        public int ap;
        public int cooldown;

        public abstract void MoveAction(); // 몬스터는 어떤 특정한 행동값을 지니고 있습니다. 

        public void Move(Direction direction)
        {
            Position prevPos = position;
            // 몬스터 이동
            switch (direction)
            {
                case Direction.Up:
                    position.y--;
                    break;
                case Direction.Down:
                    position.y++;
                    break;
                case Direction.Left:
                    position.x--;
                    break;
                case Direction.Right:
                    position.x++;
                    break;
            }

            // 이동한 자리가 벽일 경우
            if (!Data.map[position.y, position.x])
            {
                // 원위치 시키기
                position = prevPos;
            }
        }

        public void Attack(Player player)
        {

        }
        public void Damaged(int damage)
        {

        }

    }
}
