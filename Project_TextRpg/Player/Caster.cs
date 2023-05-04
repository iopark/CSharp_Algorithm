using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRpg
{
    public class Caster:Player
    {
        public new string Ah;
        public Caster(int hp, int ap, int mana, int regen, char icon, Position position, string Ah) : base(position)
        {
            this.hp = 50;
            this.ap = 40;
            this.mana = 40;
            this.regen = 3;
            this.icon = '△';
            Ah = "간달프라 아프다";
        }

        public override string Response()
        {
            return Ah;
        }
    }
}
