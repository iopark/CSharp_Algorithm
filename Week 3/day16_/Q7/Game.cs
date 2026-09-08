using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Q7
{
    public class Game
    {
        GameRender gameRender;
        GameUpdate gameUpdate;
        GameInput gameInput;
        Map map; 
        Player player; 
        Direction direction;
        public bool gameStop = false; 
        public event Action GameStart; 
        public event Action GameStop;
        //public static void 

        public void InIt()
        {
            map = new Map();
            player = new Player();
            gameInput = new GameInput(player);
            gameUpdate = new GameUpdate(map, player);
            gameRender = new GameRender(map, player);
            direction = new Direction();
            map.SetNumberMap(); // sets map.numberMap
            map.SetBlockMap(); // sets map.BlockMap 
            player.PlayerInitialPosition(map.numberMap_);
            initialChainEvent();

            Console.WriteLine("시작하시려면 아무키나 입력하세요");
            Console.ReadKey();
            //gameRender.RenderMap(); 
            //gameUpdate.Update();
            //gameRender.RenderMap();
            //gameStart += player.
             while (!gameStop)
            {
                //gameUpdate = new GameUpdate(map, player);
                Loop();
            }
            Stop();
        }

        public void initialChainEvent()
        {
            gameInput.userTry += player.Move;
            gameInput.userTry += gameUpdate.NewPlayerPoint; 
            gameUpdate.mapUpdate += gameRender.RenderGame;
            GameStop += gameRender.RenderEnd; 
        }
        public void Loop()
        {
            
            gameRender.RenderGame();
            gameInput.playerInsert();
            gameUpdate.Update();
            
            gameStop = gameUpdate.IsDone(); 
        }

        public void Stop()
        {
            gameInput.userTry -= player.Move;
            gameInput.userTry -= gameUpdate.NewPlayerPoint;
            gameUpdate.mapUpdate -= gameRender.RenderGame; 
            //gameUpdate.mapUpdate -= gameRender.RenderMap;
            GameStop?.Invoke();
        }

        public void GameTest()
        {
            
        }
        
    }
}
