using Microsoft.Xna.Framework;
using CrossPlatformDesktopProject.Entities;
using System.Collections.Generic;
using CrossPlatformDesktopProject.Gameplay;
using CrossPlatformDesktopProject.GameState;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject
{
    public class CollisionManager
    {
        private Game1 game;
        private SpriteBatch spriteBatch;
        private Texture2D hitbox;
        private const int hitboxLineWidth = 1;

        private Rectangle grass;
        private List<Rectangle> rover;
        private List<Meteor> meteors;
        private List<Bullet> bullets;

        private static CollisionManager collisionManagerInstance = new CollisionManager();
        public static CollisionManager Instance
        {
            get => collisionManagerInstance;
        }
        private CollisionManager()
        {
        }

        public void Update()
        {
            //check if bullet goes offscreen or hits a meteor
            List<Bullet> bulletsToRemove = new List<Bullet>();
            foreach (Bullet bullet in bullets)
            {
                if (bullet.Position.Y < -11)
                {
                    bulletsToRemove.Add(bullet);
                    continue;
                }
                Meteor meteorToHit = null;
                foreach (Meteor meteor in meteors)
                {
                    bool hit = false;
                    foreach (Rectangle hitbox in meteor.Hitboxes)
                    {
                        if (bullet.Hitbox.Intersects(hitbox))
                        {
                            meteorToHit = meteor;
                            bulletsToRemove.Add(bullet);
                            hit = true;
                            break;
                        }
                    }
                    if (hit) break;
                }
                if (meteorToHit != null)
                {
                    meteorToHit.Health -= bullet.Damage;
                    if (meteorToHit.Destroyed()) meteorToHit.Destroy(true);
                }
            }
            foreach (Bullet bullet in bulletsToRemove) GameplayManager.Instance.RemoveBullet(bullet);

            //check if meteor hits ground or rover
            List<Meteor> meteorsToRemove = new List<Meteor>();
            foreach (Meteor meteor in meteors)
            {
                if (meteor.Hitboxes[0].Intersects(grass)) //just check middle rectangle b/c it has lowest point
                {
                    meteorsToRemove.Add(meteor);
                    continue;
                }
                foreach (Rectangle hitbox in meteor.Hitboxes)
                {
                    foreach (Rectangle pHitbox in rover)
                    {
                        if (pHitbox.Intersects(hitbox))
                        {
                            GameStateManager.Instance.EndGame(false);
                            return;
                        }
                    }
                }
            }
            foreach (Meteor meteor in meteorsToRemove) meteor.Destroy(false);
        }

        public void Draw()
        {
            if (!GameplayManager.Instance.ShowHitboxes) return;
            DrawLines(grass);
            foreach (Rectangle rectangle in rover) DrawLines(rectangle);
            foreach (Bullet bullet in bullets) DrawLines(bullet.Hitbox);
            foreach (Meteor meteor in meteors)
            {
                foreach (Rectangle rectangle in meteor.Hitboxes) DrawLines(rectangle, true);
            }
        }
        private void DrawLines(Rectangle rectangle, bool t = false)
        {
            spriteBatch.Draw(hitbox, new Rectangle(rectangle.X, rectangle.Y, hitboxLineWidth, rectangle.Height), null, Color.White, 0, new Vector2(), SpriteEffects.None, SpriteLayers.HitboxLayer);
            spriteBatch.Draw(hitbox, new Rectangle(rectangle.X, rectangle.Y, rectangle.Width, hitboxLineWidth), null, Color.White, 0, new Vector2(), SpriteEffects.None, SpriteLayers.HitboxLayer);
            spriteBatch.Draw(hitbox, new Rectangle(rectangle.X + rectangle.Width - 1, rectangle.Y, hitboxLineWidth, rectangle.Height), null, Color.White, 0, new Vector2(), SpriteEffects.None, SpriteLayers.HitboxLayer);
            spriteBatch.Draw(hitbox, new Rectangle(rectangle.X, rectangle.Y + rectangle.Height - 1, rectangle.Width, hitboxLineWidth), null, Color.White, 0, new Vector2(), SpriteEffects.None, SpriteLayers.HitboxLayer);
        }

        public void SetHitboxStuff(SpriteBatch spriteBatch, GraphicsDevice graphics)
        {
            this.spriteBatch = spriteBatch;
            hitbox = new Texture2D(graphics, 1, 1);
            hitbox.SetData(new Color[] { Color.Red });
        }
        public Game1 Game
        {
            set
            {
                game = value;
                grass = value.Grass.Hitbox;
                rover = value.Rover.Hitboxes;
                meteors = value.Meteors;
                bullets = value.Bullets;
            }
        }
    }
}
