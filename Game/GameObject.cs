using System;

namespace AsciiSnake
{
    class GameObject
    {
        public Vector2 position = new Vector2(0,0);
        public string? renderAscii = null;
        public GameObject(){}
        public GameObject(Vector2 pos)
        {
            position = pos;
            //renderAscii = asciiChar;
        }

        public virtual void Render()
        {
            if(renderAscii == null) return;
            Console.SetCursorPosition((position.X) * 2, position.Y);
            Console.Write(renderAscii);
        }
    }
}