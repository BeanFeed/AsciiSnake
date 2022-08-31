using System;
using SharpHook;
using SharpHook.Reactive;
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
        private Direction direction = Direction.Right;
        private GameLevel Gl;
        private Vector2 position;
        public Snake(GameLevel gl)
        {
            var hook = new SimpleReactiveGlobalHook();
            hook.KeyPressed.Subscribe(KeyPress);
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
            Gl = gl;
            SnakeSegment head = new SnakeSegment(new Vector2(3, yPos));
            position = new Vector2(3,yPos);
            head.renderAscii = "$ ";
            body.Add(head);
            for(int i = 2; i > 0; i--)
            {
                body.Add(new SnakeSegment(new Vector2(i, yPos)));
            }
        }

        private void KeyPress(KeyboardHookEventArgs obj)
        {
            if(obj.Data.KeyChar == 'W')
            {
                direction = Direction.Up;
            }else if(obj.Data.KeyChar == 'A')
            {
                direction = Direction.Left;
            }else if(obj.Data.KeyChar == 'S')
            {
                direction = Direction.Down;
            }else if(obj.Data.KeyChar == 'D')
            {
                direction = Direction.Right;
            }
        }

        public void Move()
        {
            if(direction == Direction.Up)
            {
                position.Y--;
            }else if(direction == Direction.Down)
            {
                position.Y++;
            }else if(direction == Direction.Left)
            {
                position.X--;
            }else if(direction == Direction.Right)
            {
                position.X++;
            }
            List<SnakeSegment> temp = body;
            body[0].position = position;
            for(int i = 1; i < temp.Count; i++)
            {
                body[i].position = temp[i - 1].position;
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