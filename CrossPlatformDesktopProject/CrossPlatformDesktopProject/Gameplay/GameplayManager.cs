using System.Collections.Generic;
using Microsoft.Xna.Framework;
using CrossPlatformDesktopProject.Entities;

namespace CrossPlatformDesktopProject.Gameplay
{
    public class GameplayManager
    {
        private Game1 game;

        private Dictionary<int, IStage> stages;
        private List<Bullet> bullets;
        private List<Meteor> meteors;

        private static GameplayManager gameplayManagerInstance = new GameplayManager();
        public static GameplayManager Instance
        {
            get => gameplayManagerInstance;
        }
        private GameplayManager()
        {
            bullets = new List<Bullet>();
            meteors = new List<Meteor>();
        }

        public void Update(GameTime gameTime)
        {
            foreach (Bullet bullet in bullets)
            {
                bullet.Update(gameTime);
            }
            foreach (Meteor meteor in meteors)
            {
                meteor.Update(gameTime);
            }
        }
        public void Draw()
        {
            foreach (Bullet bullet in bullets)
            {
                bullet.Draw();
            }
            foreach (Meteor meteor in meteors)
            {
                meteor.Draw();
            }
        }
        public void Reset()
        {
            bullets = new List<Bullet>();
            meteors = new List<Meteor>();
        }

        public void AddBullet(Vector2 position)
        {
            bullets.Add(new Bullet(game, position, 1, 120));
        }
        public void AddMeteor(int radius, Vector2 position, int health, int speed)
        {
            meteors.Add(new Meteor(game, radius, position, health, 1, speed));
        }
        public void RemoveBullet(Bullet bullet)
        {
            bullets.Remove(bullet);
        }
        public void RemoveMeteor(Meteor meteor)
        {
            meteors.Remove(meteor);
        }

        public Game1 Game
        {
            set
            {
                game = value;
            }
        }
    }
}
