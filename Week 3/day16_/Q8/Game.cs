using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q8
{
    public class Game
    {
        private bool checkBingo = false; 
        
        GameCheck check;
        Map map;
        GameUpdate gameUpdate;
        GameInput gameInput;
        GameRender gameRender;

        public void Run()
        {
            
            map = new Map();
            map.SetBingoMap();

            gameInput = new GameInput();
            check = new GameCheck(map);
            gameUpdate = new GameUpdate(map, check);
            gameRender = new GameRender(map, check);
            InitializeEvent(); 

            while (!checkBingo)
            {
                Loop();
            }
            Stop(); 

        }
        public void InitializeEvent()
        {
            gameUpdate.mapUpdate += check.VerticalCheck; 
            gameUpdate.mapUpdate += check.HorizontalCheck;
            gameUpdate.mapUpdate += gameRender.RenderGame;
            gameInput.userInput += gameUpdate.CheckInput; 
        }
        public void Loop()
        {
            gameRender.RenderGame(); 
            gameInput.tryReceive();
            gameUpdate.Update(); 
            checkBingo = gameUpdate.checkDone(); 
        }

        public void Stop ()
        {
            gameUpdate.mapUpdate -= check.VerticalCheck;
            gameUpdate.mapUpdate -= check.HorizontalCheck;
            gameInput.userInput -= gameUpdate.CheckInput;
        }

    }

    
}
