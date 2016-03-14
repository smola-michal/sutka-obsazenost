using System;
using System.Threading;

namespace SutkaObsazenost
{
    public class Program
    {
        static void Main(string[] args)
        {
            ConsoleWrite = s => Console.WriteLine(s);
            Run();
            Console.WriteLine("To exit press <Enter>");
            Console.ReadLine();
            Console.WriteLine("To exit press <Enter> again");
            Console.ReadLine();
        }

        private static TimeSpan interval = new TimeSpan(0, 5, 0);

        public static Action<string> ConsoleWrite;
        public static void Run()
        {
            Timer t = new Timer(o => OnCount(), null, (int)Time.StartAfter(interval).TotalMilliseconds + 5000, (int)interval.TotalMilliseconds);
        }

        private static void OnCount()
        {
            try
            {
                if (Time.IsPoolOpened || Time.IsAquaparkOpened)
                {
                    Tuple<int, int> obsazenost = SutkaPage.ObsazenostBazenAquapark();
                    if (ConsoleWrite != null)
                    {
                        ConsoleWrite($"{DateTime.Now.ToLongTimeString()}, Ba: {obsazenost.Item1} Aq: {obsazenost.Item2}");
                    }
                    Storage.AddValues(obsazenost);
                }
            }
            catch (Exception ex)
            {
                Storage.RecordError(ex);
            }
        }
    }
}
