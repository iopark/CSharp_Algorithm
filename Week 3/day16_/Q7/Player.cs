using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
// using Numerics.LinearAlgebra; could later implemement library as such (MathNet) in a program that deals more heavily using the matrix values 

namespace Q7
{
    
    public class Player
    {
        private Pointer playerPosition;
        public Pointer _importPlayerPosition
        {
            get { return playerPosition; }
            set { playerPosition = value; }
        }
        private Direction playerDirection;
        public Direction _importPlayerDirection { get { return playerDirection; } set {  playerDirection = value; } }

        //public Player(Pointer playerPosition, Direction playerDirection)
        //{

        //}
        public void Move(Direction direction)
        {
            this.playerDirection = direction;
            //Console.WriteLine($"플레이어가 {direction} 으로 움직였습니다"); 
        }
        /// <summary>
        /// 게임의 시작이벤트와 동시에 호출될 항목으로, 플레이어의 시작점을 설정함 
        /// </summary>
        /// <param name="array">5x5 랜덤한 숫자배열 전달바람</param>
        public void PlayerInitialPosition(int[,] array)
        {
            int[] flatarray = array.Cast<int>().ToArray();
            int find0 = Array.IndexOf(flatarray, 0); 
            
            this._importPlayerPosition = new Pointer((find0/array.GetLength(1)), (find0%array.GetLength(1)));
        }
        //public void Test1()
        //{
        //    Pointer target1 = new Pointer(1,1);
        //    Pointer target2 = new Pointer(2,2);
        //    (target1, target2) = target1.SwapPointer(target1, target2);

        //    Console.WriteLine(target1.x);
        //    Console.WriteLine(target2.x);
        //}
    }
}
