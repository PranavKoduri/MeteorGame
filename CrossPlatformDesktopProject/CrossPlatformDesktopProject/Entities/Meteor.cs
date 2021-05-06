using Microsoft.Xna.Framework;
using CrossPlatformDesktopProject.Sprites;
using CrossPlatformDesktopProject.InGameInfo;

namespace CrossPlatformDesktopProject.Entities
{
    public class Meteor
    {
        private Game1 game;

        private int radius;
        private Vector2 topMiddle;
        private readonly Vector2 topLeftTranslation;

        private int health;
        private int maxHealth;
        public int Damage { get; }
        private readonly Vector2 velocity; //pixels per second

        private ISprite meteorSprite;

        public Meteor(Game1 game, int rad, Vector2 topMid, int hp, int dmg, int fallSpeed)
        {
            this.game = game;
            radius = rad;
            topLeftTranslation = new Vector2(-radius, 0);
            topMiddle = topMid;
            health = hp;
            maxHealth = hp;
            Damage = dmg;
            velocity = new Vector2(0, fallSpeed);
            meteorSprite = SpriteFactory.Instance.MeteorSprite(topMiddle + topLeftTranslation, radius);
        }
        public void Update(GameTime gameTime)
        {
            meteorSprite.Update(gameTime);
            Position += (float)gameTime.ElapsedGameTime.TotalSeconds * velocity;
        }
        public void Draw()
        {
            meteorSprite.Draw();
        }

        public void Destroy()
        {
            Score.Instance.MeteorDestroyed(maxHealth);
        }
        public bool Destroyed()
        {
            return health <= 0;
        }

        public int Health
        {
            get => health;
            set
            {
                if (value <= 0)
                {
                    value = 0;
                    Destroy();
                }
                else if (value > maxHealth) value = maxHealth;
                health = value;
            }
        }
        public int MaxHealth
        {
            get => maxHealth;
            set
            {
                if (value < 0) value = 0;
                maxHealth = value;
            }
        }
        public Vector2 Position
        {
            set
            {
                topMiddle = value;
                meteorSprite.Center = value + topLeftTranslation;
            }
            get => topMiddle;
        }
    }
}
