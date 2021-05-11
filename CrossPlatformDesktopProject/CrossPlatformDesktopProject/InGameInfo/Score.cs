using Microsoft.Xna.Framework;
using CrossPlatformDesktopProject.Sprites;

namespace CrossPlatformDesktopProject.InGameInfo
{
    public class Score
    {
        private int score;

        private float scoreTimer;
        private const float scoreDelay = 0.1f;

        public const int ScoreDigitPixelSpace = 3;
        public const int MaxDigits = 5;
        private readonly Vector2 topLeft = new Vector2(10, 10);
        private readonly ISprite scoreBackground;

        private static Score scoreInstance = new Score();
        public static Score Instance
        {
            get => scoreInstance;
        }
        private Score()
        {
            score = 0;
            scoreTimer = 0;
            scoreBackground = SpriteFactory.Instance.BlackScoreBackgroundSprite(topLeft, new Vector2((MaxDigits + 1) * ScoreDigitPixelSpace + MaxDigits * 10, 15 + 2 * ScoreDigitPixelSpace));
        }

        public void StageComplete(int stageCompleted)
        {
            score += 1000 * stageCompleted;
        }
        public void MeteorDestroyed(int meteorHealth)
        {
            score += 150 * meteorHealth;
        }

        public void Update(GameTime gameTime)
        {
            scoreTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (scoreTimer > scoreDelay)
            {
                scoreTimer = 0;
                score += 5;
            }
        }
        public void Draw()
        {
            int tempScore = score;
            scoreBackground.Draw();
            Vector2 offset = topLeft + new Vector2(ScoreDigitPixelSpace, ScoreDigitPixelSpace);
            for (int i = MaxDigits - 1; i >= 0; i--)
            {
                int digit = tempScore % 10;
                tempScore /= 10;
                SpriteFactory.Instance.NumberSprite(offset + new Vector2((10 + ScoreDigitPixelSpace) * i, 0), digit).Draw();
                if (tempScore == 0) break;
            }
        }
        public void DrawHighScore(int score, Vector2 position)
        {
            for (int i = MaxDigits - 1; i >= 0; i--)
            {
                int digit = score % 10;
                score /= 10;
                SpriteFactory.Instance.NumberSprite(position + new Vector2((10 + ScoreDigitPixelSpace) * i, 0), digit).Draw();
                if (score == 0) break;
            }
        }

        public void Reset()
        {
            score = 0;
            scoreTimer = 0;
        }

        public int GetScore
        {
            get => score;
        }
    }
}
