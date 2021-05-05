using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace CrossPlatformDesktopProject.Sprites
{
    public class SpriteFactory
    {
        private SpriteBatch spriteBatch;

        private Texture2D bullet;
        private Texture2D rovers;
        private Texture2D numbers;
        private Texture2D star;
        private Dictionary<int, Texture2D> meteors;
        private Texture2D blackScoreBackgroundSprite;
        private Texture2D blueAmmoBorderSprite;
        private Texture2D whiteAmmoBackgroundSprite;
        private Texture2D grassSprite;

        private static SpriteFactory spriteFactoryInstance = new SpriteFactory();
        public static SpriteFactory Instance
        {
            get => spriteFactoryInstance;
        }
        private SpriteFactory()
        {
        }

        public void LoadTextures(ContentManager content, SpriteBatch sprbt, GraphicsDevice graphics)
        {
            spriteBatch = sprbt;
            bullet = content.Load<Texture2D>("bullet");
            rovers = content.Load<Texture2D>("rovers");
            numbers = content.Load<Texture2D>("numbers");
            star = content.Load<Texture2D>("star");
            meteors = new Dictionary<int, Texture2D>()
            {
                { 5, content.Load<Texture2D>("meteor5") },
                { 10, content.Load<Texture2D>("meteor10") },
                { 15, content.Load<Texture2D>("meteor15") },
                { 20, content.Load<Texture2D>("meteor20") },
                { 25, content.Load<Texture2D>("meteor25") },
                { 30, content.Load<Texture2D>("meteor30") },
            };
            LoadRectangles(graphics);
        }
        private void LoadRectangles(GraphicsDevice graphics)
        {
            grassSprite = new Texture2D(graphics, 1, 1);
            grassSprite.SetData(new Color[] { Color.Green });

            blackScoreBackgroundSprite = new Texture2D(graphics, 1, 1);
            blackScoreBackgroundSprite.SetData(new Color[] { Color.Black });

            blueAmmoBorderSprite = new Texture2D(graphics, 1, 1);
            blueAmmoBorderSprite.SetData(new Color[] { Color.Blue });

            whiteAmmoBackgroundSprite = new Texture2D(graphics, 1, 1);
            whiteAmmoBackgroundSprite.SetData(new Color[] { Color.White });
        }

        public ISprite BulletSprite(Vector2 pos)
        {
            return new Sprite(pos, new Vector2(4, 11), spriteBatch, bullet, new Vector2(), new Vector2(4, 11), 1, 1, SpriteLayers.BulletLayer);
        }
        public ISprite BulletAmmoSprite(Vector2 pos)
        {
            return new Sprite(pos, new Vector2(4, 11), spriteBatch, bullet, new Vector2(), new Vector2(4, 11), 1, 1, SpriteLayers.BulletAmmoLayer);
        }
        public ISprite RoverSprite(Vector2 pos)
        {
            return new Sprite(pos, new Vector2(30, 20), spriteBatch, rovers, new Vector2(), new Vector2(120, 20), 1, 4, SpriteLayers.RoverLayer);
        }
        public ISprite MeteorSprite(Vector2 pos, int i) // i = meteor radius
        {
            int dim = 2 * i + 1;
            return new Sprite(pos, new Vector2(dim, dim), spriteBatch, meteors[i], new Vector2(), new Vector2(dim, dim), 1, 1, SpriteLayers.MeteorLayer);
        }
        public ISprite NumberSprite(Vector2 pos, int i) // i = number from 0-9
        {
            return new Sprite(pos, new Vector2(10, 15), spriteBatch, numbers, new Vector2(10 * i, 0), new Vector2(10, 15), 1, 1, SpriteLayers.ScoreLayer);
        }
        public ISprite StarSprite(Vector2 pos, List<double> frameProbabilities)
        {
            return new RandomSprite(pos, new Vector2(3, 3), spriteBatch, star, new Vector2(), new Vector2(6, 3), 1, 2, SpriteLayers.StarLayer, frameProbabilities);
        }
        public ISprite BlackScoreBackgroundSprite(Vector2 pos, Vector2 dim)
        {
            return new Sprite(pos, dim, spriteBatch, blackScoreBackgroundSprite, new Vector2(), new Vector2(1, 1), 1, 1, SpriteLayers.BlackScoreBackgroundLayer);
        }
        public ISprite WhiteAmmoBackgroundSprite(Vector2 pos, Vector2 dim)
        {
            return new Sprite(pos, dim, spriteBatch, whiteAmmoBackgroundSprite, new Vector2(), new Vector2(1, 1), 1, 1, SpriteLayers.WhiteAmmoBackgroundLayer);
        }
        public ISprite BlueAmmoBorderSprite(Vector2 pos, Vector2 dim)
        {
            return new Sprite(pos, dim, spriteBatch, blueAmmoBorderSprite, new Vector2(), new Vector2(1, 1), 1, 1, SpriteLayers.BlueAmmoBorderLayer);
        }
        public ISprite GrassSprite(Vector2 pos, Vector2 dim)
        {
            return new Sprite(pos, dim, spriteBatch, grassSprite, new Vector2(), new Vector2(1, 1), 1, 1, SpriteLayers.GrassLayer);
        }
    }
}