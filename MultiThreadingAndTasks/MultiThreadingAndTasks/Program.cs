using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreadingAndTasks
{
    public class Program
    {
        public AtomicBoolean running;
        public AtomicBoolean timedOut;
        public CancellationTokenSource source;
        public Random random;
        public int answer;

        public Program()
        {
            random = new Random();
            answer = random.Next(1, 10);
            running = new AtomicBoolean(true);
            timedOut = new AtomicBoolean(false);
            source = new CancellationTokenSource();
            Task<string> reader = CancellableAsyncReadInput(source);

            void OnInputHappened(string s)
            {
                bool success = int.TryParse(s, out int input);

                if (success)
                {
                    if(input > answer)
                    {
                        Console.WriteLine("Dit nummer er for stort!");
                    } 
                    else if(input < answer)
                    {
                        Console.WriteLine("Dit nummer er for småt!");
                    }
                    else
                    {
                        running.Value = false;
                    }
                }
            }

            _ = DoTimeoutTimer(10, source, running);

            while(running.Value)
            {
                if(source.IsCancellationRequested)
                {
                    running.Value = false;
                    timedOut.Value = true;
                }
                else
                {
                    if (reader.IsCompleted)
                    {
                        OnInputHappened(reader.GetAwaiter().GetResult());
                        reader.Dispose();

                        if(running.Value) reader = CancellableAsyncReadInput(source);
                    }
                }

                
                Thread.Sleep(100);
            }

            if(timedOut.Value)
            {
                Console.WriteLine("You've run out of time, too bad!");
            }
            else
            {
                Console.WriteLine("Congratulations, you've won!");
                Console.ReadLine();
            }
        }

        public async Task DoTimeoutTimer(int seconds, CancellationTokenSource source, AtomicBoolean continueCountdown)
        {
            for(int i = 0; i < seconds; i++)
            {
                if (!continueCountdown.Value) return;
                Console.WriteLine("Du har " + (seconds - i) + " sekunder tilbage");
                await Task.Delay(1000);
            }

            source.Cancel();
        }

        public async Task<string> CancellableAsyncReadInput(CancellationTokenSource source) // Doesn't actually cancel the readline, as it's not cancellable but acts like it does
        {
            try
            {
                string s = null;
                await Task.Run(() => { s = Console.In.ReadLineAsync().GetAwaiter().GetResult(); }, source.Token);
                return s;
            }
            catch (TaskCanceledException)
            {
                Console.WriteLine("Cancelled");
                return null;
            }
        }


    }
}
