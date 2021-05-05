using System.Collections.Generic;
using Microsoft.Xna.Framework;
using CrossPlatformDesktopProject.Sprites;
using System;

namespace CrossPlatformDesktopProject.GameState
{
    public class Stars
    {
        private Game1 game;

        private const int numStars = 100;
        private List<ISprite> stars;
        private List<double> probabilities;

        private static Stars starsInstance = new Stars();
        public static Stars Instance
        {
            get => starsInstance;
        }
        private Stars()
        {
            probabilities = new List<double>() { 0.975, 0.025 };
        }

        public void Update(GameTime gameTime)
        {
            foreach (ISprite star in stars)
            {
                star.Update(gameTime);
            }
        }
        public void Draw()
        {
            foreach (ISprite star in stars)
            {
                star.Draw();
            }
        }

        private void NewStars()
        {
            stars = new List<ISprite>();
            Random rd = new Random();
            int minX = 0;
            int maxX = (int)game.Dimensions.X;
            int minY = 0;
            int maxY = (int)game.Grass.TopLeft.Y;
            for (int i = 0; i < numStars; i++)
            {
                Vector2 pos = new Vector2(rd.Next(minX, maxX), rd.Next(minY, maxY));
                stars.Add(SpriteFactory.Instance.StarSprite(pos, probabilities, i));
            }
        }

        public void Reset()
        {
            NewStars();
        }

        public Game1 Game
        {
            set
            {
                game = value;
                NewStars();
            }
        }
    }
}
