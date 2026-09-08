using System.Numerics;


namespace day16_test_commit
{
    internal class Program
    {


        static void Main(string[] args)
        {
            Random random = new Random();
            int randInt = random.Next(0, 1000);




            bool GiveUp = true;
            bool Complete = true;
            bool retry = false;
            int count = 0;
            while (GiveUp && Complete)
            {
                if (GiveUp && Complete && retry)
                {
                    Random new_random = new Random();
                    randInt = new_random.Next(0, 1000);
                    retry = false;
                    Console.WriteLine("Restarting with new number");
                }
                count++;
                int attempt = GameInput(count);


                int evaluation = GameUpdate(attempt, randInt, Complete);


                GameOutput(evaluation);




                (GiveUp, Complete, evaluation, count, retry) = GameEvaluate(GiveUp, Complete, evaluation, count, retry);


            }



        }
        /// <summary>
        /// returns -1 if not y/n 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int SortYN(string value)
        {
            value = value.ToLower();
            switch (value)
            {
                case "y":
                case "ㅛ":
                    return 1;
                case "n":
                case "ㅜ":
                    return 0;
            }
            return -1;
        }


        public static int GameInput(int count)
        {
            Console.WriteLine($"{count}/10 턴");
            int input;
            while (true)
            {
                string attempt = Console.ReadLine();
                if (int.TryParse(attempt, out int value))
                {
                    input = int.Parse(attempt);
                    break;
                }
                Console.WriteLine("Please type Int value"); 
            }

            return input;
        }


            /// <summary>
            /// return 1 if trial is higher 
            /// return -1 if trial is lower 
            /// return 0 if equal 
            /// </summary>
            /// <param name="trial"></param>
            /// <param name="answer"></param>
            /// <returns></returns>
            public static int GameUpdate(int trial, int answer, bool complete)
            {
                if (trial > answer)
                    return 1;
                else if (trial < answer)
                    return -1;
                else
                    complete = false;
                return 0;
            }


            public static void GameOutput(int evaluation)
            {
                switch (evaluation)
                {
                    case 1:
                        Console.WriteLine("커요");
                        break;
                    case -1:
                        Console.WriteLine("작아요");
                        break;
                    default:
                        Console.WriteLine("정답입니다");
                        break;
                }
            }
        ///// <summary>
        ///// 0: player selects y
        ///// 1: player selects n  
        ///// </summary>
        ///// <param name="condition"></param>
        ///// <returns>int val, 0: lost, 1: won </returns>
        public static int AskCont(int evaluation)
        {
            switch (evaluation)
            {
                case 0:
                    Console.WriteLine("승리하셨습니다, 계속하시겠습니까? y/n");
                    string input_winner = Console.ReadLine();
                    int value_winner = SortYN(input_winner);
                    return value_winner;
                default:
                    Console.WriteLine("턴을 전부 소진하셨습니다 다시 시작하시겠습니까? y/n");
                    string input = Console.ReadLine();
                    int value = SortYN(input); // returns 1for yes, 0 for no 
                    return value;
            }
            return -1;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="yield"></param>
        /// <param name="complete"></param>
        /// <param name="evaluation"></param>
        /// <param name="turn"></param>
        public static (bool, bool, int, int, bool) GameEvaluate(bool yield, bool complete, int evaluation, int turn, bool restart)
        {
            int yield_ = -1;
            if (turn == 10 && complete == true)
            {


                yield_ = AskCont(evaluation); // 1 for yes, 0 for no 


            }
            else if (complete == false)
                yield_ = AskCont(evaluation);
            else
                return (yield, complete, evaluation, turn, restart);



            switch (yield_)
            {
                case 1:
                    complete = true;
                    yield = true;
                    turn = 0;
                    restart = false;
                    break;
                case 0:
                    complete = true;
                    yield = true;

                    break;
                default:
                    Console.WriteLine("Something wrong in Evaluate");
                    break;
            }
            return (yield, complete, evaluation, turn, restart);
        }
    }
    }
