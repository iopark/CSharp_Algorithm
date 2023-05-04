using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRpg
{
    public interface Ivunerable
    {
        public void Damaged(int damage);
        public string Response(); 
    }
}
