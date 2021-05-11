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

        private Rectangle hitbox;

        public Bullet(Game1 game, Vector2 topLeftPosition, int dmg, int speed)
        {
            this.game = game;
            topLeft = topLeftPosition;
            Damage = dmg;
            velocity = new Vector2(0, -speed);
            bulletSprite = SpriteFactory.Instance.BulletSprite(topLeftPosition);
            hitbox = new Rectangle(topLeftPosition.ToPoint(), new Point(4, 11));
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
                hitbox.X = (int)value.X;
                hitbox.Y = (int)value.Y;
            }
            get => topLeft;
        }

        public ref Rectangle Hitbox
        {
            get => ref hitbox;
        }
    }
}
