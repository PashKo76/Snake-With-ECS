using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_With_ECS
{
    internal class Input
    {
        static Task task = Task.Run(Read);
        static ConsoleKey? curr = null;
        static void Read()
        {
            while (true)
            {
                curr = Console.ReadKey(true).Key;
            }
        }
        static public (int, int) Get()
        {
            var res = (0, 0);
            switch (curr)
            {
                case ConsoleKey.W:
                    res = (0, -1);
                    break;
                case ConsoleKey.S:
                    res = (0, 1);
                    break;
                case ConsoleKey.A:
                    res = (-1, 0);
                    break;
                case ConsoleKey.D:
                    res = (1, 0);
                    break;
                default:
                    break;
            }
            //curr = null;
            return res;
        }
    }
}
