using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q7
{
    public  enum Direction
    {
        Up, Down, Left, Right, Done, None
    }
    public class GameInput
    {
        Player player; 
        
        public Direction direction_;
        public Action<Direction> userTry;
        public GameInput(Player player)
        {
            this.player = player;
        }

        public Direction newDirection ()
        {
            ConsoleKeyInfo key = Console.ReadKey();
            
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                this.direction_ = Direction.Up; 
                break;

                case ConsoleKey.DownArrow:
                case ConsoleKey.S: 
                this.direction_ = Direction.Down; 
                break;

                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                this.direction_ = Direction.Left;
                break;

                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                this.direction_ = Direction.Right;
                break;

                case ConsoleKey.Escape:
                this.direction_ = Direction.Done;
                break;

                default:
                this.direction_ = Direction.None;
                break;
            }
            return direction_; 
        }
        /// <summary>
        /// 해당 함수를 호출시, 특정 Direction을 유저에게 요구하고, 
        /// Direction값을 다루는 다른 함수들 또한 반응을 해야만 한다. 
        /// </summary>
        /// <returns></returns>
        public void playerInsert()
        {
            Direction new_Input = newDirection();
            player.Move(new_Input);
            userTry?.Invoke(new_Input);

        }
    }
}
