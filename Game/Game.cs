using System;
using System.Collections.Generic;

namespace AsciiSnake
{
    class Game
    {
        public enum Difficulty
        {
            Easy = 1,
            Medium = 2,
            Hard = 3
        }
        private Vector2 size;
        private GameLevel level;
        public int score = 0;
        public Game(Game.Difficulty? difficulty)
        {
            if(difficulty == Difficulty.Easy)
            {
                size = new Vector2(7, 7);
            }else if(difficulty == Difficulty.Medium)
            {
                size = new Vector2(12,12);
            }else if(difficulty == Difficulty.Hard)
            {
                size = new Vector2(22,22);
            }else
            {
                size = new Vector2(5,5);
            }
            level = new GameLevel(size);

        }

        public void Render()
        {
            level.Render();
        }
    }
}