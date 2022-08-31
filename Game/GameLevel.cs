using System;

namespace AsciiSnake
{
    class GameLevel
    {
        public Vector2 size;
        public int score = 0;
        private Snake snake;
        public List<GameObject> objects = new List<GameObject>();
        public Game game;
        public GameLevel(Vector2 Size, Game g)
        {
            game = g;
            size = Size;
            snake = new Snake(this);
            objects.Add(snake);
        }
        private void AddObject(GameObject obj)
        {
            objects.Add(obj);
        }
        public void Render()
        {
            Console.CursorVisible = false;
            Console.Clear();
            Console.SetCursorPosition(0,0);
            Console.Write("+ ");
            for(int i = 2 ; i < (size.X * 2) - 1; i += 2)
            {
                Console.SetCursorPosition(i,0);
                Console.Write("- ");
            }
            Console.SetCursorPosition((size.X * 2) - 2, 0);
            Console.Write("+ ");
            for(int i = 1; i < size.Y - 1; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("| ");
                Console.SetCursorPosition((size.X * 2) - 2, i);
                Console.Write("| ");
            }
            Console.SetCursorPosition(0, size.Y - 1);
            Console.Write("+ ");
            for(int i = 2; i < (size.X * 2) - 1; i += 2)
            {
                Console.SetCursorPosition(i, size.Y - 1);
                Console.Write("- ");
            }
            Console.SetCursorPosition((size.X * 2) - 2, size.Y - 1);
            Console.Write("+ ");
            foreach(GameObject obj in objects)
            {
                obj.Render();
                //[\Console.SetCursorPosition(15,0);
                //Console.Write("Rendered");
            }
            Console.SetCursorPosition(0, 800);

        }
    }
}