using System;

namespace AsciiSnake
{
    class SnakeSegment : GameObject
    {
        public SnakeSegment(Vector2 pos)
        {
            renderAscii = "# ";
            position = pos;
        }

        public override void Render()
        {
            base.Render();
        }
    }
}