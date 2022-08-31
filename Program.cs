using System;

namespace AsciiSnake
{
    class Program
    {
        static void Main()
        {
            Console.Clear();
            Console.SetCursorPosition(0,0);
            Game game = new Game(Game.Difficulty.Medium);
            game.running = true;
            while(game.running)
            {
                game.Render();
                Thread.Sleep(500);
            }
            //Console.Clear();
            Console.CursorVisible = true;
        }
    }

    class Vector2
    {
        public int X = 0;
        public int Y = 0;
        public Vector2(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}