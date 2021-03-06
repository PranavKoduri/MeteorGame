using Microsoft.Xna.Framework;
using CrossPlatformDesktopProject.InGameInfo;
using System;

namespace CrossPlatformDesktopProject.Gameplay
{
    public class Stage1 : IStage
    {
        private Game1 game;

        private const int stage = 1;

        private const float spawnDuration = 30f;
        private const float spawnDelay = 2.45f;
        private float durationTimer;
        private float delayTimer;
        Random rd;

        public Stage1(Game1 game)
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
                GameplayManager.Instance.AddMeteor(rad, new Vector2(xPos, -2 * rad), (stage + 2) / 3, 65 + 5 * stage);
            }
        }
        public void StartStage()
        {

        }
        public void FinishStage()
        {
            Score.Instance.StageComplete(stage);
            GameplayManager.Instance.StageCompleted();
            game.Rover.MaxAmmo++;
        }
        public void Reset()
        {
            durationTimer = 0;
            delayTimer = 0;
        }
    }
}
