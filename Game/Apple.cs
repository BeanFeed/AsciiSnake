using System;

namespace AsciiSnake
{
    class Apple : GameObject
    {
        public Apple(Vector2 pos)
        {

        }
        public override void Render()
        {
            if(renderAscii == null) return;
            Console.SetCursorPosition((position.X) * 2, position.Y);
            Console.Write(renderAscii);
        }
    }
}