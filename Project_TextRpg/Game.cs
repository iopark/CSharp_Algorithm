using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRpg
{
    // Game 이 할수 있는것은 어떤것이 있을까?
    public class Game
    {
        // Where any actual Game must have differnt types of game, 
        // for any game, define a common framework for games. 

        private Scene curScene; // 해당 객체를 통해서 게임은 Scene 을 바꾸며 Scene 에 따른 갱신값들을 구현하도록 설정한다 
        private MainMenuScene mainMenuScene;
        // or 
        private JobSelectScene jobSelectScene;
        //private Scene mainMenuScene_2;  // can work too, given that this is defined v of Scene. 
        private InventoryScene inventoryScene;
        private BattleScene battleScene;
        private MapScene mapScene;
        //// 만약 Scene 들이 더 많아질 경우, Dict 를 통해 Scene 을 보관할수 있겠다. , which is uncovered in Init 
        //private Dictionary<string, Scene> sceneDict; 
        // 1. 게임을 동작시키는것 ('Start') the game or Run the game 
        private bool isRunning = true;
        public void Run()
        {
            // 게임 시작한다면 하는것 
            // 초기화 
            Init();
            // 게임 루프 의 3요소, 
            while (isRunning)
            {
                // 3. 렌더링 : 표현 
                Render();
                // 1. 입력 
                // 2. 갱신 : 입력을 기반한 
                Update(); //Update 속에서 Input 값을 받기에 우선 없앤다. 
            }

            // 마무리 
            Release();
        }

        private void Init()
        {
            Console.CursorVisible = false;

            Data.Init();
            // 이런식으로 구현이 가능하겠다. 
            //sceneDict.Add("메인메뉴", new MainMenuScene(this));
            //sceneDict.Add("맵", new MapScene(this));
            //sceneDict.Add("전투", new BattleScene(this));
            //sceneDict.Add("인벤토리", new InventoryScene(this));
            mainMenuScene = new MainMenuScene(this);
            mapScene = new MapScene(this);
            battleScene = new BattleScene(this);
            inventoryScene = new InventoryScene(this);
            
            curScene = mainMenuScene; // where the beginning of the Initializing stage should begin with Main Menu 

        }

        public void GameStart()
        {
            Data.LoadLevel();
            curScene = mapScene; 
        }

        public void JobSelect()
        {

        }

        public void GameOver()
        {

            Console.Clear(); 
            curScene = mainMenuScene;

            isRunning = false;
        }

        public void BattleStart(Monster monster)
        {
            curScene = battleScene;
            battleScene.BattleStart(monster);
        }

        private void Render()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            curScene.Render();
        }

        private void Update()
        {
            curScene.Update();
        }

        private void Release() 
        { 
            Data.Release();
        }
        
    }
}
