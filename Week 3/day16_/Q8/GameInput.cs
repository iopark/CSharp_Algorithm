using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q8
{
    public class GameInput
    {
        public event Action<string> userInput;
        public string tryInput; 
        public void tryReceive()
        {
            while (true)
            {
                Console.Write("함 입력해바라: "); 
                string Input = Console.ReadLine();
                int value; 
                if (int.TryParse(Input, out value) == true)
                {
                    tryInput = Input;
                    break;
                }
            }
            
            userInput?.Invoke(tryInput);
        }
    }
}
