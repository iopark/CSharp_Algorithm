using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRpg
{
    public class Warrior : Player
    {
        //public char icon = '♤';
        //public int hp;
        //public int ap;
        //public int mana = 20;
        //public string response = "전사앍";
        public new string Ah;
        public Warrior(int hp, int ap, int mana, int regen, char icon, Position position) : base(position)
        {
            this.hp = 90;
            this.ap = 10;
            this.mana = mana;
            this.regen = 4; 
            this.icon = '♤';
            Ah = "전사앍";
        }

        public override string Response()
        {
            return Ah;
        }
    }
}
