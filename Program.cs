using System;

namespace AsciiSnake
{
    class Program
    {
        private static ConsoleKey GetInput()
        {
            ConsoleKeyInfo Key = Console.ReadKey();
            return Key.Key;
        }
        private static void StartGame(Game.Difficulty difficulty)
        {
            Game game = new Game(difficulty);
            game.running = true;
            while(game.running)
            {
                game.Render();
                Thread.Sleep(500);
            }
        }
        static void Main()
        {
            
            int selection = 1;
            while(true)
            {
                Console.Clear();
                Console.SetCursorPosition(0,0);
                Console.WriteLine("Ascii Snake");
                Console.SetCursorPosition(0,2);
                if(selection == 1)
                {
                    Console.WriteLine(">Easy");
                    Console.WriteLine("Medium");
                    Console.WriteLine("Hard");
                }else if(selection == 2)
                {
                    Console.WriteLine("Easy");
                    Console.WriteLine(">Medium");
                    Console.WriteLine("Hard");
                }else if(selection == 3)
                {
                    Console.WriteLine("Easy");
                    Console.WriteLine("Medium");
                    Console.WriteLine(">Hard");
                }
                ConsoleKey input = GetInput();
                if(input == ConsoleKey.UpArrow && selection != 1)
                {
                    selection--;
                }else if(input == ConsoleKey.DownArrow && selection != 3)
                {
                    selection++;
                }else if(input == ConsoleKey.Enter)
                {
                    break;
                }
            }
            if(selection == 1)
            {
                StartGame(Game.Difficulty.Easy);
            }else if(selection == 2)
            {
                StartGame(Game.Difficulty.Medium);
            }else
            {
                StartGame(Game.Difficulty.Hard);
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