using System.IO;
using System.IO.Compression;

namespace day8_contfrom7 
{
    //
    /* 작성날짜: 04/04/2023 
     * 작성자: 박일두 
     * Task: 소코반 프로젝트 기능추가
     */

    internal class Program
    {
        /* 해당 게임 구성체 
         * 1. 맵, 2. 플레이어. 
         * 두 구성체 모두 유저의 입력값에 따라 Point 구조체에 의거하여 값이 출력되는데, 
         * 갱신되는 방식은 조금씩 다르다. 맵같은 경우 Tile 로 분류되는 값들에 따라 해당 Point 에 출력되는 값이 다르지만 
         * 플레이어 같은 경우 콘솔의 커서의 출력값에만 한정되어 출력값이 결정된다. (이경우 ♥이다).
         * 플레이어 맵 둘다 동시에 갱신이 되며, 해당 point 값의 tile 값의 갱신되는 조건은 
         * GameUpdate 함수에 명시되어 있다. 
         * 해당 프로그램은 아래의 순서와 같이 구동한다
         * 1. 게임 초기화 : 게임 시작과 동시에 저장된 맵 값과, 플레이어의 위치가 출력된다. 
         * 2. 사용자 입력값 받기: 해당 프로그램은 방향키 Up, Down, Left, Right 값만 입력받으며, 입력받은값은 Direction 에 따라 분류된다. 
         * 3. 자료갱신: 입력값에 따라 플레이어, 맵의 Point 값과, Point 값의 지정된 Tile값 모두 갱신된다. 
         * 4. 출력: 최초 출력(게임시작) 이후 유저의 입력과 동시에 출력되며, 따로 자동출력이 있지는 않다. 
         * 5. CheckGameClear 조건이 true 될때까지 2,3,4 를 반복하며, true 달성시 프로그램은 종료된다. 
         * 5-1. 해당조건은 매 갱신시 마다 확인된다. 
         */

        // day 8 실습 
        /* 1. 플레이어의 움직임 저장 및 출력 
         * 움직임에 해당되는 조건 
         * 1. 사용자가 Direction 에 None 제외 입력이 발생시 
         * 2. 초기화 이후 갱신이 발생시 
         * 3. 초기화 이후 렌더링 발생시 
         * 이번에는 사용자가 None 제외 Direction 값에 알맞는 입력 발생시 움직임값으로 추가 기록, 갱신 및 출력 해보겠다. 
         *
         * 입력 방법 
         * User 가 GameInput()에 None 제외한 값을 입력시 움직임으로 기록한다. 
         *      이를 확인하는것은 GameUpdate()에서 이루어지기에, 사실 확인 방법도 GameUpdate()함수에서 확인이 가능하다. 
         * 갱신 방법 
         *      초기화 단계에서 값을 0으로 설정, GameUpdate ()에서 매개변수로 등록 및 ++ 값을 반환시킨다. 
         * 출력 방법 
         * 맵출력 이전에 값을 출력하며, 출력이후에는 \n으로 구분짓는다. 
         * 문제점: 출력시 커서또한 맵과 동일한 좌표에서 시작되기 때문에 이를 고려하여 커서출력장소를 바꿔줘야만 했다. 
         *
         */

        /* 2. R 누르면 재시작 구현 
         * 재시작의 조건 
         * 1. 초기화 값으로 돌아간다 
         *          새로 시작했을때와 같은 조건으로 돌아간다. 
         *          
         * 재시작시 초기화 해당목록
         * 1. 맵 초기화 
         * 2. 플레이어 위치 초기화 
         * 3. 플레이어의 움직임값 초기화 
         * 
         * 재시작 구동 조건 
         * 플레이어가 R 값 입력시 구동 (R, r, ㄱ, 입력시) 
         * 
         * 입력방법
         * User가 Direction 으로 입력을 받을시 R값을 받을때 구동, 때문에 Direction 값에 Restart 값 설정 및 기록을 위한 변수 설정 
         * 
         * 갱신방법 
         * Direction값 중에 Restart를 입력 받았을시 게임 시작과 동일한 맵, 및 유저 값으로 반환한다. 
         * GameUpdate() 함수 변경 
         * 함수변경 사항: 처음 direction 값을 받을때 R 을 받았다면, 유저의 시도횟수를 0으로 돌리고 함수를 종료한다. 
         * 게임 루프를 처음부터 다시 시작한다. 
         * 때문에 게임루프를 다시 시작하기 위해 continue 를 활용해본다. 재시작함수를 추가한다. , 
         * 추가적으로, 초기화 값을 저장하기 위해 초기화값을 함수로 저장하여, 루프를 시작
         * 출력방법 
         * 
          */

        /* 3. 컬러게임으로 구현 
          */

        enum Direction { 
            Up, Down, Left, Right, None, Restart, Undo
        }
        enum Tile { None, Wall, Goal, Box, BoxGoal }
        static string FileName (int level) 
        {
            string[] levelList = { "1.txt",
            "2.txt", 
            "3.txt"};
            string parentFolder = "C:\\Users\\oapdr\\source\\repos\\iopark\\day8_\\day8_\\"; 
            string levelFile = parentFolder+levelList[level-1];

            return levelFile; 

        }


        static int[] FileSize (string path)
        {
            string[] lines = File.ReadAllLines (path);
            int count = 0;
            int width = 0;
            foreach (string ln in lines)
            {
                count++;
                if (count >1)
                {
                    width = ln.Split(",").Length; 
                }
            }
            int[] mapsize = { count - 1, width }; 
            return mapsize; 
        } 

        static Tile[,] FileToMapfile (string path)
        {
            string[] file = File.ReadAllLines(path);
            int[] mapsize = FileSize(path);

            int i = -1, j = 0;
            Tile[,] TileMap = new Tile[mapsize[0], mapsize[1]];
            foreach (string row in file)
            {
                
                if (i >= 0)
                {
                    string cleanedline = row.Replace("\n", "").Replace("\r", "");
                    string[] tempo = cleanedline.Split(",");

                    j = 0;
                    foreach (string col in tempo)
                    {

                        int parsedvalue = int.Parse(col);
                        TileMap[i, j] = (Tile)parsedvalue;
                        j++;
                    }
                }
                
                i++;
            }
            return TileMap; 
        } 

        static Point FileToPlayer (string path)
        {
            string[] file = File.ReadAllLines(path);
            int count = 0; 
            foreach (string ln in file)
            {
                if (count ==0)
                {
                    string cleanedline = ln.Replace("\n", "").Replace("\r", "");
                    string[] tempo = cleanedline.Split(",");
                    int[] saved = new int[tempo.Length];
                    int i = 0; 
                    foreach (string item in tempo)
                    {
                        saved[i] = int.Parse(item);
                        i++;
                    }
                    Point stagePlayer = new Point(saved[0], saved[1]);
                    return stagePlayer;
                }
                count++;
                break;
            }
            Point failure = new Point(-1, -1);
            return failure;
        }
        // Direction 의 이름의 자료형 생성, 이는 Up, Down, Left, Right으로,
        // 유저의 입력단계에서 ConsoleKeyInfo 의 입력값을 게임에 적용/갱신시키기 전,
        // 갱신 가능한 가능한 여러값들을 Enum으로 생성시,
        // 가독성이 좋고, 상수로써 변환이 안되기에 많이 사용된다. 


        // 위 Direction과 비슷하게 생성된 다양한 타일의 종류들을 집합해놓은 생성된 자료형이다. 
        // 다른점이 있다면, 위 Tile Enum은 사용자의 입력단계가 아닌 
        // 게임의 초기화 및 갱신단계에서 많이 사용이 된다. 
        // 정확히는 갱신되는 타일 값들에 대해 분류 및 갱신을 위해 사용이 된다. 
        struct Point
        {
            /* 이곳에서 구조체는 맵, 그리고 플레이어의 갱신값에 사용되는 [x,y]위치값을 저장하는데 사용된다. 

             */
            public int x;
            public int y;

            public Point(int x, int y)
            {
                // 포인트의 변수는 Point newpoint = new Point(int,int) 로 가능하다. 
                // (int, int)에 입력된 값은 구조체의 기본변수 public int x, int y 로 저장되며, 
                // 해당public x, y값은 따로 불러오기가 가능해진다. newpoint.x = public int x 값  
                // 또한 이 값들은 해당 구조체의 함수에도 적용이 가능하다.            {
                this.x = x;
                this.y = y;
            }
        }

        class Undo
        {
            public Tile[,] tile;
            public Point point;
            public Tile[][,] tileArchive;
            public int tileX = 0;
            public int tileY = 0;
            public Point[] pointArchive;
            public int undocount;
            public Undo (Tile[,] tile, Point point, string path)
            {
                this.tile = tile;
                this.point = point;
                this.undocount = 0;
                int[] xyvalue = FileSize(path);
                this.tileX = (int)xyvalue[0];
                this.tileY = (int)xyvalue[1];
                tileArchive = new Tile[1024][,];
                pointArchive = new Point[1024];
                //this.tileX = tileXY[0];
                //this.tileY = tileXY[1];
            }

            public void TileArchive (Tile[,] maptile)
            {
                tileArchive[undocount] = (Tile[,])maptile.Clone(); 
            }

            public void PointArchive (Point playerpoint)
            {
                pointArchive[undocount] = playerpoint;
            }

            public void XySize (string path)
            {
                int[] xyvalue = FileSize(path);
                this.tileX = xyvalue[0];
                this.tileY = xyvalue[1];
            }
            public (Tile[,], Point) ReturnArchive ()
            {
                Tile[,] returnTile = (Tile[,])tileArchive[undocount].Clone();
                Point returnpoint = pointArchive[undocount];
                return (returnTile, returnpoint); 
            }
            /*유저가 최초 Direction에 한정된 값을 입력시 (R 같은 경우 특별 트리거 부여) 기존의 포인트 값, 맵 값을 저장한다. 
             *저장되는 값들은 다른 함수 및 메인에서 불러오기가 가능하여야 하고, 
             *불러진 값들은 기록에서 삭제되며, 다시 유저 입력이 시작되는 시점부터는 기록이 재게 되어야 한다. 
             *반대로 되돌려지며 변하는 포인트/맵값은 기록되지 않는다. 
             */ 
            /* 게임루프에 반영되야할 요소 
             * 초기화: 게임이 재시작되거나 스테이지가 새로 시작될때 똑같이 초기화 된다. 
             * 입력값: 유저가 Direction에 맞는, None 제외 할때마다 갱신전 포인트, 타일값을 저장한다.
             * 갱신시 의미있는 갱신을 위해 입력값 Direction 중 Z 키 추가한다.  
             * 갱신시: Z값 반영시 기록된 값으로 돌아갈수 있도록 Restart와 비슷하게 이전아카이브에 기록된 포인트, 플레이어 시도, 그리고 타일값으로 전환한다. 
             * 출력: 수정사항은 필요없는것으로 예상된다. 
             */ 

        }

        //변환이 되지않는 상수로 저장해둔 값이다. 
        //해당자료는 tile 값에 적용되어 출력되는 값으로 응용된다. 
        const char PLAYER = '♥';
        const char WALL = '▩';
        const char GOAL = '□';
        const char BOX = '●';
        const char BOXGOAL = '■';

        static (Tile[,] defaultMap, Point defaultPoint) defaultSetting (int stage)
        {
            string stage_default = FileName(stage);
            Tile[,] map = FileToMapfile(stage_default);
            Point player = FileToPlayer(stage_default);
            return (map, player);
        }

        

        static void Main(string[] args)
        {
            

            // Game Init
            Console.Title = "Sokoban"; // 커서바에 명시되는 이름을 설정한다. 
            Console.CursorVisible = false; // 깜빡이는 커서의 출력기능을 없이한다. 
            /* Remnant of the past
            Tile[,] map =
                //타일 맵의 dimension 을 아래와 같이 설정 및 초기화 한다. 7 X 7
                //배열의 값은 Tile 구조체로 종류시킨다. 
            {
                { Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall },
                { Tile.Wall, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.Wall },
                { Tile.Wall, Tile.None, Tile.None, Tile.Wall, Tile.Box , Tile.None, Tile.Wall },
                { Tile.Wall, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.Wall },
                { Tile.Wall, Tile.None, Tile.None, Tile.None, Tile.Box , Tile.Goal, Tile.Wall },
                { Tile.Wall, Tile.None, Tile.None, Tile.None, Tile.Wall, Tile.Goal, Tile.Wall },
                { Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall },
            }; */
            
            /* Remnant of the past 
             * Point player = new Point(1, 1);
            int playerAttempt = 0;
            // Game render */

            
            int stage = 1;
            while (stage <= 3)
            {
                string stage_access = FileName(stage);
                Tile[,] map = FileToMapfile(stage_access);
                Point player = FileToPlayer(stage_access);
                int playerAttempt = 0;
                Undo undo = new Undo(map, player, stage_access);
                GameRender(map, player, playerAttempt, undo.undocount);
                // Game loop
                // 현재는 게임루프는 break; 선언 이전까지 무한 반복이 된다. 
                // 
                while (true)
                {
                    // Game input
                    Direction direction = GameInput();

                    // Game update
                    (Tile[,] map, Point player, int Attempt, int value) result = GameUpdate(map, player, direction, playerAttempt, stage, undo);
                    map = result.map;
                    //undo.TileArchive(map);
                    player = result.player;
                    //undo.PointArchive(player);
                    playerAttempt = result.Attempt;

                    // Game render
                    GameRender(map, player, playerAttempt, undo.undocount);

                    // Game end check
                    if (CheckGameClear(map) && stage == 3)
                    {
                        Console.Clear();
                        Console.WriteLine($"{playerAttempt} 시도만의 게임 클리어!, 아무키나 입력하세요");
                        stage++;
                        break;
                    }
                    else if (CheckGameClear(map))
                    {
                        Console.Clear();
                        Console.WriteLine($"{stage}/3을 {playerAttempt}시도만의 게임 클리어! 계속하시려면 아무키나 입력하시오");
                        Console.ReadKey();
                        stage++;
                        break;
                    }
                }
                


            }
            --stage;
            Console.WriteLine($"{stage}/{stage} 를 클리어!");
            Console.WriteLine("축하합니다, 승리하셨습니다 :D ");


        }
        /* Remnant of the past
        static void GameInitialize(Tile[,] map, Point player, int Attempt, int stage)
        {
            Console.Clear();
            Console.WriteLine($"시도횟수: {Attempt}.");
            Console.WriteLine();
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    switch (map[y, x])
                    {
                        case Tile.Wall:
                            Console.Write(WALL);
                            break;
                        case Tile.Goal:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(GOAL);
                            Console.ResetColor();
                            break;
                        case Tile.Box:
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write(BOX);
                            Console.ResetColor();
                            break;
                        case Tile.BoxGoal:
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(BOXGOAL);
                            Console.ResetColor();
                            break;
                        default:
                            Console.Write('　');
                            break;
                    }
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(player.x * 2, player.y + 2);

            Console.WriteLine(PLAYER);
            Console.ResetColor();
        }
        */

        static void GameRender(Tile[,] map, Point player, int Attempt, int Undo)
        {
            Console.Clear();
            Console.WriteLine($"시도횟수: {Attempt}. 남은 되돌림 횟수: {Undo}");
            Console.WriteLine();
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    switch (map[y, x])
                    {
                        case Tile.Wall:
                            Console.Write(WALL);
                            break;
                        case Tile.Goal:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(GOAL);
                            Console.ResetColor();
                            break;
                        case Tile.Box:
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black; 
                            Console.Write(BOX);
                            Console.ResetColor();
                            break;
                        case Tile.BoxGoal:
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Red; 
                            Console.Write(BOXGOAL);
                            Console.ResetColor();
                            break;
                        default:
                            Console.Write('　');
                            break;
                    }
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(player.x * 2, player.y+2);
            
            Console.WriteLine(PLAYER);
            Console.ResetColor();
        }

        static Direction GameInput()
        {
            Direction direction; // direction 이름의 Direction 자료형 선언; 
            ConsoleKeyInfo info = Console.ReadKey(); // ReadKey값을 ConsoleKeyInfo 구조체의 info 값에 저장한다. 
            // ConsoleKeyInfo 덕분에 입력되는 방향키 또한 컴파일 및 컴퓨터가 이해가능한 값으로 전환된다.
            // (Console.#입력받은값)의 형태로 말이다. 
            switch (info.Key)
            {
                case ConsoleKey.UpArrow:// 위방향키 입력시 
                    direction = Direction.Up; // 해당값을 Direction의 Up으로 저장한다. 

                    break;
                case ConsoleKey.DownArrow:
                    direction = Direction.Down;

                    break;
                case ConsoleKey.LeftArrow:
                    direction = Direction.Left;
                    break;
                case ConsoleKey.RightArrow:
                    direction = Direction.Right;
                    break;
                case ConsoleKey.R:
                    direction = Direction.Restart;
                    break;
                case ConsoleKey.Z:
                    direction = Direction.Undo;
                    break;
                default:
                    // switch의 제어장치로써, 명시된 입력값이 아니면 None값만을 전달시킨다.  
                    direction = Direction.None; //4가지 상황이 아닌경우 초기화값을 설정한다. 
                    break; // switch 문에 default로 어떠한경우에 대비하여 컴파일이 안되는 상황을 예방할수있다. 
            }
            return direction; // switch 를 통과하여 입력받고 Direction 의 일부분으로 분류된 값을 return 한다. 
        }

        static (Tile[,] map, Point player,int Attempt, int undoval) GameUpdate(Tile[,] map, Point player, Direction direction, int Attempt, int stagenum, Undo undo)
        {
            //해당함수는 튜플값을 return 하는데, 플레이어와 맵, 그리고 분류된 사용자의 입력값에 따라 플레이어와 맵값을 갱신시킨다. 
            Point prevPoint = player; //매개변수로 입력된 플레이어의 포인트값을 prevPoint로 입력된다. 
                                      // 플레이어 이동
            string filename = FileName(stagenum);
            undo.XySize(filename); 
            /* 갱신하는 과정 
             * 유저의 입력값에 따라 포인트값을 변환후, 
             * 조건에 따라 갱신 전 후 포인트의 타일값을 갱신한다. 
             */
            switch (direction)
            {
                case Direction.Up:
                    Attempt++;
                    player.y--;
                    undo.TileArchive(map);
                    undo.PointArchive(prevPoint);
                    undo.undocount++;
                    break;
                case Direction.Down:
                    player.y++;
                    Attempt++;
                    undo.TileArchive(map);
                    undo.PointArchive(prevPoint);
                    undo.undocount++;
                    break;
                case Direction.Left:
                    player.x--;
                    Attempt++;
                    undo.TileArchive(map);
                    undo.PointArchive(prevPoint);
                    undo.undocount++;
                    break;
                case Direction.Right:
                    player.x++;
                    Attempt++;
                    undo.TileArchive(map);
                    undo.PointArchive(prevPoint);
                    undo.undocount++;
                    break;
                case Direction.Restart:// Q2. 
                    undo = new Undo(defaultSetting(stagenum).Item1, defaultSetting(stagenum).Item2, filename);

                    return (defaultSetting(stagenum).Item1, defaultSetting(stagenum).Item2, 0, 0); //Q2. 
                case Direction.Undo:
                    if (undo.undocount == 0)
                    {
                        break;
                    }
                    Attempt++;
                    undo.undocount--;
                    return (undo.ReturnArchive().Item1, undo.ReturnArchive().Item2, Attempt, undo.undocount);


            }

            // 이동한 자리가 벽일 경우
            if (map[player.y, player.x] == Tile.Wall)
            //플레이어의 갱신된포인트와  맵의 포인트에 할당된 tile값중에 wall이 있다면 
            {
                // 원위치 시키기
                //구조체의 특성상 값을 복사후 새롭게 저장하기 때문에 이같은 기능이 가능하다. 
                player = prevPoint;
            }

            // 이동한 자리가 박스일 경우
            else if (map[player.y, player.x] == Tile.Box)
            {
                Point point = player;
                //플레이어와 박스포인트를 달리하여 맵에 할당되는 tile의 값을 갱신시킬수도 있다. 
                switch (direction)
                {
                    case Direction.Up:
                        point.y--;
                        break;
                    case Direction.Down:
                        point.y++;
                        break;
                    case Direction.Left:
                        point.x--;
                        break;
                    case Direction.Right:
                        point.x++;
                        break;
                }

                if (map[point.y, point.x] == Tile.None)
                //변환된 박스포인트에 tile값중에 None이라면 있다면 변환후포인트, 변환전 포인트 모두 새롭게 갱신한다. 
                {
                    //플레이어의 갱신된 포인트와, 
                    map[point.y, point.x] = Tile.Box;
                    map[player.y, player.x] = Tile.None;
                }
                else if (map[point.y, point.x] == Tile.Goal)
                {

                    //변환된포인트에 tile값이Goal 이라면 있다면 변환후포인트, 변환전 포인트 모두 새롭게 갱신한다
                    map[point.y, point.x] = Tile.BoxGoal;
                    map[player.y, player.x] = Tile.None;
                }
                else
                {
                    player = prevPoint;
                }
            }

            // 이동한 자리가 골에 있는 박스일 경우
            else if (map[player.y, player.x] == Tile.BoxGoal)
            //입력값에 따라 박스 타일값의 위치, 플레이어의 위치가 갱신되는데, 
            // 그에따라 박스골의 갱신 조건을 명시한다. 
            {
                Point point = player;
                //박스골 포인트를 입력받아 갱신된 플레이어 값으로 전환후, 추가로 박스골의 포인트 값을 갱신한다. 
                switch (direction)
                {
                    case Direction.Up:
                        point.y--;
                        break;
                    case Direction.Down:
                        point.y++;
                        break;
                    case Direction.Left:
                        point.x--;
                        break;
                    case Direction.Right:
                        point.x++;
                        break;
                }

                if (map[point.y, point.x] == Tile.None)
                //만약 갱신된 박스골의 포인트 값이 None 이라면, 
                //갱신된 포인트값에 박스값을 갱신하며, 
                //갱신전 포인트 값은 골로 전환한다. 
                {
                    map[point.y, point.x] = Tile.Box;
                    map[player.y, player.x] = Tile.Goal;
                }
                else if (map[point.y, point.x] == Tile.Goal)
                {
                    map[point.y, point.x] = Tile.BoxGoal;
                    map[player.y, player.x] = Tile.Goal;
                }
                else
                {
                    player = prevPoint;
                }
            }
            // 이후 갱신된 타일값이 적용된 맵값과, 갱신된 플레이어 값을 반환한다. 
            return (map, player, Attempt, undo.undocount);
        }


        static bool CheckGameClear(Tile[,] map)
        {
            foreach (Tile tile in map)
            //포인트값과, 타일값을 갱신후, 입력값을 받기 전 
            //맵에 타일값중 골값이 있는지 확인한다. 
            // 있다면 false 반환, 입력값을 다시 받지 않고 게임을 종료시킨다. 
            {
                if (tile == Tile.Goal)
                    return false;
            }

            return true;
        }
    }
}