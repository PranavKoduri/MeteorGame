using Microsoft.Xna.Framework;
using CrossPlatformDesktopProject.InGameInfo;
using System;

namespace CrossPlatformDesktopProject.Gameplay
{
    public class Stage4 : IStage
    {
        private Game1 game;

        private const int stage = 4;

        private const float spawnDuration = 30f;
        private const float spawnDelay = 1.15f;
        private float durationTimer;
        private float delayTimer;
        Random rd;

        public Stage4(Game1 game)
        {
            durationTimer = 0;
            delayTimer = 0;
            this.game = game;
            rd = new Random();
        }

        public void Update(GameTime gameTime)
        {
            durationTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            delayTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (durationTimer > spawnDuration)
            {
                if (!GameplayManager.Instance.MeteorsPresent()) FinishStage();
            }
            else if (delayTimer > spawnDelay)
            {
                delayTimer = 0;
                int rad = 35 - 5 * stage;
                int xPos;
                do
                {
                    xPos = rd.Next(rad, (int)game.Dimensions.X - rad);
                } while (false);
                GameplayManager.Instance.AddMeteor(rad, new Vector2(xPos, -2 * rad), 1, 65 + 5 * stage);
            }
        }
        public void StartStage()
        {

        }
        public void FinishStage()
        {
            Score.Instance.StageComplete(stage);
            GameplayManager.Instance.StageCompleted();
            game.Rover.MaxAmmo += 2;
            game.Rover.ReloadSpeed = 1f;
        }
        public void Reset()
        {
            durationTimer = 0;
            delayTimer = 0;
        }
    }
}
