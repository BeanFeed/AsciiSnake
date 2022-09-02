using System;

namespace AsciiSnake
{
    class Apple : GameObject
    {
        public Apple(Vector2 pos)
        {
            position = pos;
            renderAscii = "@ ";
        }
    }
}