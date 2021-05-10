using Microsoft.Xna.Framework;
using CrossPlatformDesktopProject.Sprites;

namespace CrossPlatformDesktopProject.Entities
{
    public class Bullet
    {
        private Game1 game;

        private Vector2 topLeft;

        public int Damage { get; }
        private readonly Vector2 velocity; //pixels per second

        private ISprite bulletSprite;

        public Bullet(Game1 game, Vector2 topLeftPosition, int dmg, int speed)
        {
            this.game = game;
            topLeft = topLeftPosition;
            Damage = dmg;
            velocity = new Vector2(0, -speed);
            bulletSprite = SpriteFactory.Instance.BulletSprite(topLeftPosition);
        }
        public void Update(GameTime gameTime)
        {
            bulletSprite.Update(gameTime);
            Position += (float)gameTime.ElapsedGameTime.TotalSeconds * velocity;
        }
        public void Draw()
        {
            bulletSprite.Draw();
        }

        public Vector2 Position
        {
            set
            {
                topLeft = value;
                bulletSprite.Center = value;
            }
            get => topLeft;
        }
    }
}
