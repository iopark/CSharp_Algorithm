using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRpg
{
    public class Player : Ivunerable
    {
        public int hp;
        public int ap;
        public int mana; 
        public char icon = '♥'; // 플레이어를 표시하기 위한 
        public Position position;
        public string Ah;
        public int regen;

        public Player(int hp, int ap, int mana, int regen,  char icon, Position position, string Ah)
        {
            this.hp = hp;
            this.ap = ap;
            this.mana = mana;
            this.icon = icon;
            this.icon = icon;
            this.position = position;
            this.Ah = Ah;
            this.regen = regen;
        }

        public Player(Position position)
        {
            this.position = position;
        }

        public void Damaged(int damage)
        {
            hp = hp - damage;
        }

        public virtual string Response()
        {
            return Ah;
        }
        // 플레이어가 이동을 해야하기에 
        // TODO: Player moving skill 

        public void Move(Direction direction)
        {
            Position prevPos = position;
            // 플레이어 이동
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
    }
}
