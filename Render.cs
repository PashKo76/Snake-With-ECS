using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Snake_With_ECS
{
    internal static class Render
    {
        static Render()
        {
            DeltaTime = 0;
        }
        static public void Set(int width, int height)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(width, height+1);
            Height = Console.WindowHeight-1;
            Width = Console.WindowWidth;
            Console.SetBufferSize(Width, Height+1);
            buffer = new char[Width * Height];
            Array.Fill(buffer, ' ');
        }
        static public int Height { get; private set; }
        static public int Width { get; private set; }
        static Stopwatch sw = new Stopwatch();
        static public int DeltaTime { get; private set; }
        static char[] buffer;
        public static void RenderBuffer(int SleepTime)
        {
            Console.SetCursorPosition(0, 0);
            Console.Write(buffer);
            Array.Fill(buffer, ' ');
            DeltaTime = (int)sw.ElapsedMilliseconds;
            if (SleepTime - DeltaTime > 0)
            {
                Thread.Sleep(SleepTime - DeltaTime);
            }
            sw.Restart();
        }
        public static void SetIcon(int X, int Y, char icon)
        {
            if (X >= Width || X < 0 || Y >= Height || Y < 0) return;
            buffer[Width * (Y) + X] = icon;
        }
        public static void CreateBorder(char Border)
        {
            int maxY = Height - 1;
            int maxX = Width - 1;
            for(int x = 0; x <= maxX; x++)
            {
                SetIcon(x, 0, Border);
                SetIcon(x, maxY, Border);
            }
            for(int y = 0; y <= maxY; y++)
            {
                SetIcon(0, y, Border);
                SetIcon(maxX, y, Border);
            }
        }
        
    }
}
