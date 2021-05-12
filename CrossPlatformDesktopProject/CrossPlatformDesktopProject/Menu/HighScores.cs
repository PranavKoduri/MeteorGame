using System.IO;
using System.Collections.Generic;
using CrossPlatformDesktopProject.InGameInfo;
using CrossPlatformDesktopProject.Sprites;
using Microsoft.Xna.Framework;
using System;

namespace CrossPlatformDesktopProject.Menu
{
    public class HighScores
    {
        private Game1 game;

        private const int charOffset = 48;

        private const int numScores = 10;

        private FileStream file;
        private List<int> scores;

        private const int scoresTopPixel = 29;
        private const int verticalScoreDistance = 4;

        private const string relativeFileName = "scores.txt";
        private readonly string fileName;

        private static HighScores highScoresInstance = new HighScores();
        public static HighScores Instance
        {
            get => highScoresInstance;
        }
        private HighScores()
        {
            string workingDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            fileName = workingDirectory + "/" + relativeFileName;
            LoadScores();
        }

        private void LoadScores()
        {
            file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            scores = new List<int>();
            for (int i = 0; i < numScores; i++)
            {
                int score = 0;
                for (int j = 0; j < Score.MaxDigits; j++)
                {
                    score = score * 10 + (file.ReadByte() - charOffset);
                }
                scores.Add(score);
            }
            file.Close();
            scores.Sort();
        }

        public void AddScore(int score)
        {
            bool high = false;
            for (int i = numScores - 1; i >= 0; i--)
            {
                if (scores[i] < score)
                {
                    high = true;
                    break;
                }
            }
            if (high)
            {
                scores[0] = score;
                scores.Sort();
                file = new FileStream(fileName, FileMode.Truncate, FileAccess.Write);
                for (int i = 0; i < numScores; i++)
                {
                    List<int> digits = new List<int>();
                    score = scores[i];
                    for (int j = 0; j < Score.MaxDigits; j++)
                    {
                        int digit = score % 10;
                        score /= 10;
                        digits.Add(digit);
                    }
                    for (int j = Score.MaxDigits - 1; j >= 0; j--)
                    {
                        file.WriteByte((byte)(digits[j] + charOffset));
                    }
                }
                file.Close();
            }
        }

        public void ClearScores()
        {
            scores = new List<int>();
            file = new FileStream(fileName, FileMode.Truncate, FileAccess.Write);
            for (int i = 0; i < numScores; i++)
            {
                for (int j = 0; j < Score.MaxDigits; j++)
                {
                    file.WriteByte(charOffset);
                }
                scores.Add(0);
            }
            file.Close();
        }

        public void Draw()
        {
            int scoreWidth = Score.MaxDigits * 10 + (Score.MaxDigits - 1) * Score.ScoreDigitPixelSpace;
            for (int i = 0; i < 3; i++)
            {
                int score = scores[numScores - 1 - i];
                for (int j = Score.MaxDigits - 1; j >= 0; j--)
                {
                    int digit = score % 10;
                    score /= 10;
                    SpriteFactory.Instance.NumberTransparentSprite(new Vector2((10 + Score.ScoreDigitPixelSpace) * j + (game.Dimensions.X - scoreWidth) / 2, scoresTopPixel + (15 + verticalScoreDistance) * i), digit).Draw();
                }
            }
            for (int i = 3; i < numScores; i++)
            {
                int score = scores[numScores - 1 - i];
                for (int j = Score.MaxDigits - 1; j >= 0; j--)
                {
                    int digit = score % 10;
                    score /= 10;
                    SpriteFactory.Instance.NumberSprite(new Vector2((10 + Score.ScoreDigitPixelSpace) * j + (game.Dimensions.X - scoreWidth) / 2, scoresTopPixel + (15 + verticalScoreDistance) * i), digit, true).Draw();
                }
            }
        }

        public Game1 Game
        {
            set => game = value;
        }
    }
}
