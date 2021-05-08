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
        private Texture2D paused;
        private Texture2D numberstransparent;
        private Texture2D title;
        private Texture2D highscreen;
        private Texture2D high;
        private Texture2D top3;
        private Texture2D page;
        private Texture2D menucontrols;
        private Texture2D rules;
        private Texture2D gamecontrols;
        private Texture2D clearconfirm;

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
            paused = content.Load<Texture2D>("paused");
            numberstransparent = content.Load<Texture2D>("numberstransparent");
            title = content.Load<Texture2D>("meteorrushtitle");
            highscreen = content.Load<Texture2D>("highscoresscreen");
            high = content.Load<Texture2D>("highscores");
            top3 = content.Load<Texture2D>("goldsilverbronze");
            page = content.Load<Texture2D>("pageindicators");
            menucontrols = content.Load<Texture2D>("menucontrols");
            rules = content.Load<Texture2D>("thegamerules");
            gamecontrols = content.Load<Texture2D>("gamecontrols");
            clearconfirm = content.Load<Texture2D>("clearhighscoreconfirm");
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

        /* game sprites */
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
        public ISprite StarSprite(Vector2 pos, List<double> frameProbabilities, int seed)
        {
            return new RandomSprite(pos, new Vector2(3, 3), spriteBatch, star, new Vector2(), new Vector2(6, 3), 1, 2, SpriteLayers.StarLayer, frameProbabilities, seed);
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

        /* menu sprites */
        public ISprite PageSprite(Vector2 pos, bool isLeft, bool pageExists) //CHANGE TEXTURE AND LAYER
        {
            int dir = isLeft ? 0 : 1;
            int exists = pageExists ? 0 : 1;
            return new Sprite(pos, new Vector2(9, 9), spriteBatch, page, new Vector2(9 * dir, 9 * exists), new Vector2(9, 9), 1, 1, SpriteLayers.PageIndicatorLayer);
        }
        public ISprite ClearConfirmSprite(Vector2 pos)
        {
            return new Sprite(pos, new Vector2(100, 40), spriteBatch, clearconfirm, new Vector2(), new Vector2(100, 80), 2, 1, SpriteLayers.PopUpLayer);
        }
        public ISprite PausedSprite(Vector2 pos)
        {
            return new Sprite(pos, new Vector2(4, 11), spriteBatch, paused, new Vector2(), new Vector2(4, 11), 1, 1, SpriteLayers.PopUpLayer);
        }
        public ISprite TitleSprite(Vector2 pos)
        {
            return new Sprite(pos, new Vector2(4, 11), spriteBatch, title, new Vector2(), new Vector2(4, 11), 1, 1, SpriteLayers.MenuLayer);
        }
        public ISprite HighScreenSprite(Vector2 pos)
        {
            return new Sprite(pos, new Vector2(4, 11), spriteBatch, highscreen, new Vector2(), new Vector2(4, 11), 1, 1, SpriteLayers.MenuLayer);
        }
        public ISprite HighScoresSprite(Vector2 pos)
        {
            return new Sprite(pos, new Vector2(4, 11), spriteBatch, high, new Vector2(), new Vector2(4, 11), 1, 1, SpriteLayers.MenuLabelLayer);
        }
        public ISprite Top3Sprite(Vector2 pos)
        {
            return new Sprite(pos, new Vector2(4, 11), spriteBatch, top3, new Vector2(), new Vector2(4, 11), 1, 1, SpriteLayers.GoldSilverBronzeLayer);
        }
        public ISprite MenuControlsSprite(Vector2 pos)
        {
            return new Sprite(pos, new Vector2(4, 11), spriteBatch, menucontrols, new Vector2(), new Vector2(4, 11), 1, 1, SpriteLayers.MenuLayer);
        }
        public ISprite GameControlsSprite(Vector2 pos)
        {
            return new Sprite(pos, new Vector2(4, 11), spriteBatch, gamecontrols, new Vector2(), new Vector2(4, 11), 1, 1, SpriteLayers.MenuLayer);
        }
        public ISprite GameRulesSprite(Vector2 pos)
        {
            return new Sprite(pos, new Vector2(4, 11), spriteBatch, rules, new Vector2(), new Vector2(4, 11), 1, 1, SpriteLayers.MenuLayer);
        }
        public ISprite NumberTransparentSprite(Vector2 pos, int i) // i = number from 0-9
        {
            return new Sprite(pos, new Vector2(10, 15), spriteBatch, numberstransparent, new Vector2(10 * i, 0), new Vector2(10, 15), 1, 1, SpriteLayers.MenuLabelLayer);
        }
    }
}