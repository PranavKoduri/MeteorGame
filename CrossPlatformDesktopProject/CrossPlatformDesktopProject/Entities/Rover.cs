using CrossPlatformDesktopProject.Sprites;
using Microsoft.Xna.Framework;
using CrossPlatformDesktopProject.InGameInfo;
using CrossPlatformDesktopProject.GameState;
using CrossPlatformDesktopProject.Gameplay;

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
        private const int initialMaxAmmo = 5;
        private float reloadSpeed;
        private float reloadTime;

        public Rover(Game1 game)
        {
            this.game = game;

            maxHealth = 1;
            health = maxHealth;

            MaxAmmo = initialMaxAmmo;
            CurrentAmmo = maxAmmo;
            reloadSpeed = 1.75f;
            reloadTime = 0;

            dimensions = new Vector2(30, 20);
            topLeft = game.Grass.TopLeft + new Vector2((game.Dimensions.X - dimensions.X) / 2, -dimensions.Y);
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
            if (CurrentAmmo != MaxAmmo)
            {
                reloadTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (reloadTime > reloadSpeed)
                {
                    reloadTime = 0;
                    CurrentAmmo++;
                }
            }
        }
        public void Draw()
        {
            roverSprite.Draw();
        }

        public void Die()
        {
            GameStateManager.Instance.EndGame();
        }
        public void Shoot()
        {
            if (CurrentAmmo > 0)
            {
                CurrentAmmo--;
                GameplayManager.Instance.AddBullet(topLeft + new Vector2((dimensions.X - 4) / 2, 0));
            }
        }
        public void Reset()
        {
            maxHealth = 1;
            health = maxHealth;

            MaxAmmo = initialMaxAmmo;
            CurrentAmmo = maxAmmo;
            reloadTime = 0;

            Position = game.Grass.TopLeft + new Vector2((game.Dimensions.X - dimensions.X) / 2, -dimensions.Y);
            roverSprite = SpriteFactory.Instance.RoverSprite(topLeft);
            roverSprite.FrameDirection = ISprite.FrameChange.Still;
        }

        public int Health
        {
            get => health;
            set
            {
                if (value <= 0)
                {
                    value = 0;
                    Die();
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
