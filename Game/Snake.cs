using System;

namespace AsciiSnake
{
    class Snake : GameObject
    {
        public enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }
        private List<SnakeSegment> body = new List<SnakeSegment>();
        public Snake(GameLevel gl)
        {
            int yPos = gl.size.Y / 2;
            /*
            if (gl.size.Y % 2 == 1)
            {
                yPos = (gl.size.Y) / 2;
            }else
            {
                yPos = gl.size.Y / 2;
            }
            */
            SnakeSegment head = new SnakeSegment(new Vector2(3, yPos));
            head.renderAscii = "$ ";
            body.Add(head);
            for(int i = 2; i > 0; i--)
            {
                body.Add(new SnakeSegment(new Vector2(i, yPos)));
            }
        }

        public void Move(Direction direction)
        {
            if(direction == Direction.Up)
            {
                
            }
        }

        public override void Render()
        {
            foreach(SnakeSegment sm in body)
            {
                sm.Render();
            }
        }
    }
}