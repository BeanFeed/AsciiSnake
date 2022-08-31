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
        private Direction tempD = Direction.Right;
        private GameLevel Gl;
        private SimpleReactiveGlobalHook hook = new SimpleReactiveGlobalHook();
        public Snake(GameLevel gl)
        {
            hook.KeyPressed.Subscribe(KeyPress);
            hook.RunAsync();
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
            position = new Vector2(5,yPos);
            head.renderAscii = "$ ";
            body.Add(head);
            for(int i = 4; i > 0; i--)
            {
                body.Add(new SnakeSegment(new Vector2(i, yPos)));
            }
        }

        private void KeyPress(KeyboardHookEventArgs obj)
        {
            string Key = obj.Data.KeyCode.ToString();
            Key = Key.Remove(0,2);
            if(Key == "W" && direction != Direction.Down)
            {
                tempD = Direction.Up;
            }else if(Key == "A" && direction != Direction.Right)
            {
                tempD = Direction.Left;
            }else if(Key == "S" && direction != Direction.Up)
            {
                tempD = Direction.Down;
            }else if(Key == "D" && direction != Direction.Left)
            {
                tempD = Direction.Right;
            }else if(Key == "Escape")
            {
                hook.Dispose();
                Gl.game.running = false;
            }
            
        }

        private void Move()
        {
            direction = tempD;
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
            List<Vector2> oldPos = new List<Vector2>();
            foreach(SnakeSegment sm in body)
            {
                oldPos.Add(new Vector2(sm.position.X,sm.position.Y));
            }
            body[0].position = new Vector2(position.X, position.Y);
            
            for(int i = 1; i < oldPos.Count; i++)
            {
                body[i].position = oldPos[i - 1];
            }
            
        }
        private bool CheckSelfCollide()
        {
            for(int i = 1; i < body.Count; i++)
            {
                if(body[i].position.X == body[0].position.X && body[i].position.Y == body[0].position.Y)
                {
                    foreach(SnakeSegment sm in body)
                    {
                        sm.Render();
                    }
                    Console.SetCursorPosition(body[0].position.X * 2, body[0].position.Y);
                    ConsoleColor defCol = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("X");
                    Console.ForegroundColor = defCol;
                    Gl.game.running = false;
                    hook.Dispose();
                    return true;
                }
            }
            return false;
        }
        private void HandleCollisions()
        {
            List<GameObject> objects = new List<GameObject>(Gl.objects);
            foreach(GameObject obj in objects)
            {
                if(obj == this)
                {
                    objects.Remove(obj);
                }
            }
            foreach(GameObject obj in objects)
            {
                if(obj is Apple ap && ap.position.X == position.X && ap.position.Y == position.Y)
                {
                    Gl.game.score
                }
            }
        }
        public override void Render()
        {
            Move();
            if(CheckSelfCollide()) return;
            HandleCollisions();
            foreach(SnakeSegment sm in body)
            {
                sm.Render();
            }
        }
    }
}