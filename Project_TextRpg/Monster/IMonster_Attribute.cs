using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRpg
{
    public interface IMonster_Attribute
    {
        public abstract void Attack(Player player);

        public abstract void Damaged(int damage); 
    }
}
