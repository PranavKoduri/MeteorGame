using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System;

namespace CrossPlatformDesktopProject.Sprites
{
    public class RandomSprite : ISprite
    {
        private Texture2D texture;
        private SpriteBatch spriteBatch;
        private float layer;

        private int currentFrame;
        private List<Rectangle> frames;

        private ISprite.FrameChange frameChange;
        private float frameTimer;
        private const float frameDelay = 0.5f;
        private List<double> frameCumulativeProbabilities;

        private Rectangle position;

        // |frameProbabilities| = numFrames
        // sum(i:[0,|frameProbabilities|),frameProbabilities[i]) = 1
        public RandomSprite(Vector2 pos, Vector2 dim, SpriteBatch sprite, Texture2D txt, Vector2 subTopleft, Vector2 subDim, int rows, int columns, float spriteLayer, List<double> frameProbabilities)
        {
            position = new Rectangle(pos.ToPoint(), dim.ToPoint());

            spriteBatch = sprite;
            texture = txt;
            layer = spriteLayer;

            frameChange = ISprite.FrameChange.Changing;
            frameTimer = 0;

            currentFrame = 0;
            LoadFrames(rows, columns, subTopleft, subDim);
            frameCumulativeProbabilities = frameProbabilities;
            for (int i = 1; i < frameCumulativeProbabilities.Count; i++)
            {
                frameCumulativeProbabilities[i] += frameCumulativeProbabilities[i - 1];
            }
        }
        private void LoadFrames(int rows, int columns, Vector2 subTopleft, Vector2 subDim)
        {
            Point rectangleDim = (subDim / new Vector2(columns, rows)).ToPoint();
            frames = new List<Rectangle>();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Vector2 topleft = subTopleft + new Vector2(rectangleDim.X * j, rectangleDim.Y * i);
                    frames.Add(new Rectangle(topleft.ToPoint(), rectangleDim));
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            frameTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (frameTimer > frameDelay)
            {
                frameTimer = 0;
                switch (frameChange)
                {
                    case ISprite.FrameChange.Changing:
                        Random rd = new Random();
                        double prob = rd.NextDouble();
                        int frame = 0;
                        while (frameCumulativeProbabilities[frame] < prob) frame++;
                        currentFrame = frame;
                        break;
                }
            }
        }
        public void Draw()
        {
            int c = currentFrame;
            spriteBatch.Draw(texture, position, frames[currentFrame], Color.White, 0, new Vector2(), SpriteEffects.None, layer);
        }

        public Vector2 Center
        {
            set
            {
                position.X = (int)value.X;
                position.Y = (int)value.Y;
            }
        }
        public ISprite.FrameChange FrameDirection
        {
            set
            {
                if (value == ISprite.FrameChange.Forward || value == ISprite.FrameChange.Backward) return;
                if (frameChange != value)
                {
                    frameTimer = 0;
                    frameChange = value;
                }
            }
        }
    }
}