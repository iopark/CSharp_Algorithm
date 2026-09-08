using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q8
{
    public class GameCheck
    {
        Map map;
        public GameCheck(Map map)
        {
            this.map = map;
        }
        private int verticalBingo = 0;

        public int vB_ {
            get { return verticalBingo; }
            set { verticalBingo = value; }
        }
        private int horizontalBingo = 0;
        public int hB_
        {
            get { return horizontalBingo; }
            set { horizontalBingo = value; }
        }

        public int totalBingo
        {
            get { return verticalBingo + horizontalBingo; }
        } 
        

        public void VerticalCheck () 
        {
            int count = 0; 
            for (int x= 0; x <5; x++)
            {
                bool wholeLineChecked = true; 
                for (int y= 0; y <5; y++)
                {
                    if (map.bingoMap_[x, y] != "#")
                        wholeLineChecked = false; 
                }
                if (wholeLineChecked)
                {
                    count++;
                }
            }
            verticalBingo = count; 
        }

        public void HorizontalCheck () 
        {
            int count = 0;
            for (int y = 0; y < 5; y++)
            {
                bool wholeLineChecked = true;
                for (int x = 0; x < 5; x++)
                {
                    if (map.bingoMap_[x, y] != "#")
                        wholeLineChecked = false;
                }
                if (wholeLineChecked)
                {
                    count++;
                }
            }
            horizontalBingo = count;
        }
    }
}
