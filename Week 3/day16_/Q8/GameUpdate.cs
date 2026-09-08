using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q8
{
    public class GameUpdate
    {
        public event Action mapUpdate; 
        Map map;
        GameCheck gC; 
        private bool isValid = false;
        private bool isDone = false; 
        Pointer valueLoc; 
        public GameUpdate (Map map, GameCheck gC)
        {
            this.map = map;
            this.gC = gC;
        }
        public void CheckInput(string input)
        {
            string[,] testMap = map.bingoMap_; 
            string[] flatarray = testMap.Cast<string>().ToArray();
            int findValue = Array.IndexOf(flatarray, input);

            if (findValue != -1)
            {
                isValid = true;
                valueLoc = new Pointer((findValue / testMap.GetLength(1)), (findValue % testMap.GetLength(1)));
                map.binggoVal_ = valueLoc;
            }
            else
                isValid = false; 
                return; 
            
        }
        public void Update()
        {
            if (isValid)
            {
                map.bingoMap_[map.binggoVal_.x, map.binggoVal_.y] = "#";
                mapUpdate?.Invoke();
            }
            else
                return; 
        }

        public bool checkDone()
        {
            if (gC.totalBingo >= 3)
            {
                isDone = true;
                return isDone; 
            }
            return isDone; 
        }


    }
}
