using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q7
{
    /// <summary>
    /// 값 위주로 진행함으로 stuct형태로 포인터 구현, 
    /// </summary>
    public struct Pointer
    {
        public int x;
        public int y;
        public Pointer(int x, int y)
        {
            this.x = x; this.y = y;
        }
        public (Pointer, Pointer) SwapPointer(Pointer pointer1, Pointer pointer2)
        {
            //int temp_x = this.x;
            //int temp_y = this.y;
            //pointer1 = new Pointer (pointer2.x, pointer2.y ); 
            //pointer2 = new Pointer(temp_x, temp_y);

            return (pointer2, pointer1);
        }
    }
}
