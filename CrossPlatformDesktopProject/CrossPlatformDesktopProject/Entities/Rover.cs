using CrossPlatformDesktopProject.Sprites;
using Microsoft.Xna.Framework;
using CrossPlatformDesktopProject.InGameInfo;
using CrossPlatformDesktopProject.GameState;
using CrossPlatformDesktopProject.Gameplay;
using System.Collections.Generic;

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
        private const int initialMaxAmmo = 3;
        private const float initialReloadSpeed = 1.75f;
        private float reloadSpeed;
        private float reloadTime;

        private List<Vector2> hitboxOffsets;
        private List<Rectangle> hitboxes;

        public Rover(Game1 game)
        {
            this.game = game;

            maxHealth = 1;
            health = maxHealth;

            MaxAmmo = initialMaxAmmo;
            CurrentAmmo = maxAmmo;
            reloadSpeed = initialReloadSpeed;
            reloadTime = 0;

            dimensions = new Vector2(30, 20);
            topLeft = game.Grass.TopLeft + new Vector2((game.Dimensions.X - dimensions.X) / 2, -dimensions.Y);
            maxRight = new Vector2(game.Dimensions.X - dimensions.X, topLeft.Y);

            roverSprite = SpriteFactory.Instance.RoverSprite(topLeft);
            roverSprite.FrameDirection = ISprite.FrameChange.Still;

            hitboxOffsets = new List<Vector2>()
            {
                { new Vector2(12, 0) },
                { new Vector2(11, 1) },
                { new Vector2(8, 2) },
                { new Vector2(5, 3) },
                { new Vector2(2, 4) },
                { new Vector2(0, 5) },
            };
            hitboxes = new List<Rectangle>()
            {
                { new Rectangle((hitboxOffsets[0] + topLeft).ToPoint(), new Point(6, 1)) },
                { new Rectangle((hitboxOffsets[1] + topLeft).ToPoint(), new Point(8, 1)) },
                { new Rectangle((hitboxOffsets[2] + topLeft).ToPoint(), new Point(14, 1)) },
                { new Rectangle((hitboxOffsets[3] + topLeft).ToPoint(), new Point(20, 1)) },
                { new Rectangle((hitboxOffsets[4] + topLeft).ToPoint(), new Point(26, 1)) },
                { new Rectangle((hitboxOffsets[5] + topLeft).ToPoint(), new Point(30, 11)) },
            };
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
            GameStateManager.Instance.EndGame(false);
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
            reloadSpeed = initialReloadSpeed;

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
                for (int i = 0; i < hitboxOffsets.Count; i++)
                {
                    Rectangle hitbox = hitboxes[i];
                    hitbox.X = (int)(value.X + hitboxOffsets[i].X);
                    hitbox.Y = (int)(value.Y + hitboxOffsets[i].Y);
                    hitboxes[i] = hitbox;
                }
            }
            get => topLeft;
        }
        public float ReloadSpeed
        {
            get => reloadSpeed;
            set => reloadSpeed = value;
        }

        public ref List<Rectangle> Hitboxes
        {
            get => ref hitboxes;
        }
    }
}
