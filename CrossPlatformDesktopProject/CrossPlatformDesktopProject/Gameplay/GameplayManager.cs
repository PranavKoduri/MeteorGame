using System.Collections.Generic;
using Microsoft.Xna.Framework;
using CrossPlatformDesktopProject.Entities;
using CrossPlatformDesktopProject.GameState;

namespace CrossPlatformDesktopProject.Gameplay
{
    public class GameplayManager
    {
        private Game1 game;

        private Dictionary<int, IStage> stages;
        private int stage;
        private List<Bullet> bullets;
        private List<Meteor> meteors;

        private static GameplayManager gameplayManagerInstance = new GameplayManager();
        public static GameplayManager Instance
        {
            get => gameplayManagerInstance;
        }
        private GameplayManager()
        {
            stage = 1;
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
            stages[stage].Update(gameTime);
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
            stage = 1;
            bullets = new List<Bullet>();
            meteors = new List<Meteor>();
            foreach (int i in stages.Keys)
            {
                stages[i].Reset();
            }
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
        public bool MeteorsPresent()
        {
            return meteors.Count > 0;
        }
        public void StageCompleted()
        {
            stage++;
            if (stage > stages.Count) GameStateManager.Instance.EndGame();
            else game.Rover.CurrentAmmo = game.Rover.MaxAmmo;
        }

        public Game1 Game
        {
            set
            {
                game = value;
                stages = new Dictionary<int, IStage>()
                {
                    {1, new Stage1(game)},
                    {2, new Stage2(game)},
                    {3, new Stage3(game)},
                    {4, new Stage4(game)},
                    {5, new Stage5(game)},
                    {6, new Stage6(game)},
                };
            }
        }
    }
}
