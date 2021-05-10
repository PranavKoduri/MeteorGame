using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.Sprites
{
    public class Sprite : ISprite
    {
        private Texture2D texture;
        private SpriteBatch spriteBatch;
        private int numFrames;
        private float layer;

        private int currentFrame;
        private List<Rectangle> frames;

        private ISprite.FrameChange frameChange;
        private float frameTimer;
        private readonly float frameDelay;

        private Rectangle position;

        public Sprite(Vector2 pos, Vector2 dim, SpriteBatch sprite, Texture2D txt, Vector2 subTopleft, Vector2 subDim, int rows, int columns, float spriteLayer, float delay = 0.1f)
        {
            position = new Rectangle(pos.ToPoint(), dim.ToPoint());

            spriteBatch = sprite;
            texture = txt;
            layer = spriteLayer;
            numFrames = rows * columns;

            frameChange = ISprite.FrameChange.Forward;
            frameTimer = frameDelay / 2;

            currentFrame = 0;
            LoadFrames(rows, columns, subTopleft, subDim);

            frameDelay = delay;
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
                    case ISprite.FrameChange.Forward:
                        currentFrame++;
                        if (currentFrame >= numFrames) currentFrame = 0;
                        break;
                    case ISprite.FrameChange.Backward:
                        currentFrame--;
                        if (currentFrame < 0) currentFrame = numFrames - 1;
                        break;
                }
            }
        }
        public void Draw()
        {
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
                if (value == ISprite.FrameChange.Changing) return;
                if (frameChange != value)
                {
                    frameTimer = frameDelay / 2;
                    frameChange = value;
                }
            }
        }
    }
}