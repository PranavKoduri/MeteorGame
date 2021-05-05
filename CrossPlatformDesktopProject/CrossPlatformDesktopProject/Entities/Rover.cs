using CrossPlatformDesktopProject.Sprites;
using Microsoft.Xna.Framework;
using CrossPlatformDesktopProject.InGameInfo;

namespace CrossPlatformDesktopProject.Entities
{
    public class Rover
    {
        private Game1 game;

        private int health;
        private int maxHealth;

        private Vector2 topLeft;
        private Vector2 dimensions;
        private Vector2 maxRight;

        private ISprite roverSprite;

        private int currentAmmo;
        private int maxAmmo;

        public Rover(Game1 game)
        {
            this.game = game;

            maxHealth = 1;
            health = maxHealth;

            MaxAmmo = 10;
            CurrentAmmo = maxAmmo;


            dimensions = new Vector2(30, 20);
            topLeft = game.Grass.TopLeft - new Vector2(0, dimensions.Y);
            maxRight = new Vector2(game.Dimensions.X - dimensions.X, topLeft.Y);

            roverSprite = SpriteFactory.Instance.RoverSprite(topLeft);
            roverSprite.FrameDirection = ISprite.FrameChange.Still;
        }

        public void Move(Vector2 movement)
        {
            Position += movement;
            if (movement.X < 0) roverSprite.FrameDirection = ISprite.FrameChange.Backward;
            else if (movement.X > 0) roverSprite.FrameDirection = ISprite.FrameChange.Forward;
            else roverSprite.FrameDirection = ISprite.FrameChange.Still;
        }

        public void Update(GameTime gameTime)
        {
            roverSprite.Update(gameTime);
        }
        public void Draw()
        {
            roverSprite.Draw();
        }

        public int Health
        {
            get => health;
            set => health = value;
        }
        public int MaxHealth
        {
            get => maxHealth;
            set => maxHealth = value;
        }
        public int MaxAmmo
        {
            set
            {
                if (value < 0) value = 0;
                maxAmmo = value;
                Ammo.Instance.MaxAmmo = value;
            }
            get => maxAmmo;
        }
        public int CurrentAmmo
        {
            set
            {
                if (value > maxAmmo) value = maxAmmo;
                else if (value < 0) value = 0;
                currentAmmo = value;
                Ammo.Instance.CurrentAmmo = value;
            }
            get => currentAmmo;
        }
        public Vector2 Position
        {
            set
            {
                if (value.X < 0) value.X = 0;
                else if (value.X > maxRight.X) value.X = maxRight.X;
                topLeft = value;
                roverSprite.Center = value;
            }
            get => topLeft;
        }
    }
}
