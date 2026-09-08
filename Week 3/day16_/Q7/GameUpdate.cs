using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Q7
{
    public class GameUpdate
    {
        public Action mapUpdate;
        Map map;
        Block[,] blockMap; int[,] numberMap; 
        Player player;
        Pointer updatePointer;
        Pointer new_Number;
        private bool upDated = false; 
        Direction updateDirection;
        private bool isWall = false;
        private bool gameDone = false;
        public GameUpdate(Map map, Player player)
        {
            this.map = map;
            this.updatePointer = player._importPlayerPosition;
            this.updateDirection = player._importPlayerDirection;
            this.blockMap = map.blockMap_;
            this.numberMap = map.numberMap_;
            this.player = player;
            this.updatePointer = new Pointer (player._importPlayerPosition.x,player._importPlayerPosition.y);
        }
        /// <summary>
        /// isWall 은 새로운 포인터의 블록값이 숫자가 아니라면 true, 숫자가 맞다면 false 를 반환합니다 
        /// </summary>
        /// <param name="point"></param>
        /// <param name="blockMap"></param>
        /// <returns>isWall</returns>
        public bool TestWall (Pointer point, Block[,] blockMap)
        {
            isWall = (blockMap[point.x+1, point.y+1] == Block.Numbers) ? false : true;

            return (blockMap[point.x + 1, point.y + 1] == Block.Numbers) ? false : true;

        }

        public void NewPlayerPoint(Direction direction)
        {
            Pointer new_Point = player._importPlayerPosition;
            switch (direction)
            {
                case Direction.Left:
                    new_Point.x -= 1;
                    if (TestWall(new_Point, blockMap))
                    {
                        upDated = false; 
                        break;
                    }
                    else
                        upDated = true;
                    map.number_Pointer = new Pointer(player._importPlayerPosition.x, player._importPlayerPosition.y);
                    player._importPlayerPosition = new_Point;
                        break;
                case Direction.Right:
                    new_Point.x += 1;
                    if (TestWall(new_Point, blockMap))
                    {
                        upDated = false;
                        break;
                    }
                    else
                        upDated = true;
                    map.number_Pointer = new Pointer(player._importPlayerPosition.x, player._importPlayerPosition.y);
                        player._importPlayerPosition = new_Point;
                    break;
                case Direction.Up:
                    new_Point.y -= 1;
                    if (TestWall(new_Point, blockMap))
                    {
                        upDated = false;
                        break;
                    }
                    else
                        upDated = true;
                        map.number_Pointer = new Pointer(player._importPlayerPosition.x, player._importPlayerPosition.y);
                        player._importPlayerPosition = new_Point;
                    break;
                case Direction.Down:
                    new_Point.y += 1;
                    if (TestWall(new_Point, blockMap))
                    {
                        upDated = false;
                        break;
                    }
                    else
                        upDated = true; 
                        map.number_Pointer = new Pointer(player._importPlayerPosition.x, player._importPlayerPosition.y);
                        player._importPlayerPosition = new_Point;
                    break;
                case Direction.Done:
                    gameDone = true; 
                    break;
                default:
                    break;
            }
        }

        public void SwapPointer()
        {
            if (upDated)
            {
                Console.Write("Updating");
                UpdateNumberMap();
                return;
            }
            else
                Console.Write("None Changed");
                return;
        }

        public void UpdateNumberMap()
        { 
            map.numberSwap(player._importPlayerPosition.x , player._importPlayerPosition.y, 
                map.number_Pointer.x, map.number_Pointer.y);
        }

        public void Update()
        {
            SwapPointer();
            mapUpdate?.Invoke(); //이것은 GameRender 중 Render자체를 실행시킵니다. 
        }

        public bool IsDone()
        {
            return this.gameDone;
        }
    }
}
