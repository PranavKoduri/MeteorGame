using Microsoft.Xna.Framework;
using CrossPlatformDesktopProject.Sprites;
using CrossPlatformDesktopProject.InGameInfo;
using System.Collections.Generic;
using System;
using CrossPlatformDesktopProject.Gameplay;

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

        private List<Vector2> hitboxOffsets;
        private List<Rectangle> hitboxes;

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

            hitboxOffsets = new List<Vector2>();
            hitboxes = new List<Rectangle>();
            hitboxOffsets.Add(new Vector2());
            hitboxes.Add(new Rectangle(topMid.ToPoint(), new Point(1, 2 * rad + 1)));
            for (int i = 1; i <= rad; i++)
            {
                double y = Math.Sqrt(Math.Pow(rad, 2) - Math.Pow(i, 2));
                hitboxOffsets.Add(new Vector2(-i, (float)(rad - y)));
                hitboxOffsets.Add(new Vector2(i, (float)(rad - y)));
                Point dim = new Point(1, 1 - 2 * ((int)(rad - y) - rad));
                hitboxes.Add(new Rectangle((topMid + hitboxOffsets[2 * i - 1]).ToPoint(), dim));
                hitboxes.Add(new Rectangle((topMid + hitboxOffsets[2 * i]).ToPoint(), dim));
            }
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

        public void Destroy(bool roverShot)
        {
            if (roverShot) Score.Instance.MeteorDestroyed(maxHealth);
            GameplayManager.Instance.RemoveMeteor(this);
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
                if (value <= 0) value = 0;
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
                for (int i = 0; i < hitboxOffsets.Count; i++)
                {
                    Rectangle hitbox = hitboxes[i];
                    hitbox.X = (int)(value.X + hitboxOffsets[i].X);
                    hitbox.Y = (int)(value.Y + hitboxOffsets[i].Y);
                    hitboxes[i] = hitbox;
                }
            }
            get => topMiddle;
        }

        public ref List<Rectangle> Hitboxes
        {
            get => ref hitboxes;
        }
    }
}
