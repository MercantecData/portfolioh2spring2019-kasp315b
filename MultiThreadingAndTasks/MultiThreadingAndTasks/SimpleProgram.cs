using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreadingAndTasks
{
    public class SimpleProgram
    {
        public Random random;
        public int answer;
        public bool timeout;
        public bool condition;

        public SimpleProgram()
        {
            random = new Random();
            answer = random.Next(1, 10);

            timeout = false;
            condition = false;

            _ = DoTimeout();

            Game();
        }

        public void Game()
        {
            bool running = true;

            while(running)
            {
                bool isNumber = int.TryParse(Console.ReadLine(), out int guess);

                if (timeout)
                {
                    break;
                }

                if(isNumber)
                {
                    if(guess == answer)
                    {
                        condition = true;
                        break;
                    }
                    else if(guess > answer)
                    {
                        Console.WriteLine("Guess too big");
                    }
                    else
                    {
                        Console.WriteLine("Guess too small");
                    }
                }
            }

            if (condition) Win();
            else Loose();
        }

        public void Win()
        {
            Console.WriteLine("Win");
            Console.ReadLine();
        }

        public void Loose()
        {
            Console.WriteLine("Loose");
        }

        public async Task DoTimeout()
        {
            for(int i = 0; i < 10; i++)
            {
                if (!condition)
                {
                    Console.WriteLine("Time remaining: " + (10 - i));
                    await Task.Delay(1000);
                }
            }

            if(!condition)
            {
                Console.WriteLine("You ran out of time");

                timeout = true;
            }
        }
    }
}
