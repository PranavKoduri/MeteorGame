using System.Collections.Generic;
using Microsoft.Xna.Framework;
using CrossPlatformDesktopProject.Menu;
using CrossPlatformDesktopProject.InGameInfo;

namespace CrossPlatformDesktopProject.GameState
{
    public class GameStateManager
    {
        private Game1 game;
        private GameState gameState;
        private Dictionary<GameState, IGameState> gameStates;
        private bool winner;

        private enum GameState
        {
            Menu,
            Playing,
            Paused,
            Finished
        }

        private static GameStateManager gameStateManagerInstance = new GameStateManager();
        public static GameStateManager Instance
        {
            get => gameStateManagerInstance;
        }
        private GameStateManager()
        {
            gameState = GameState.Menu;
        }

        public bool IsPlaying()
        {
            return gameState == GameState.Playing;
        }
        public bool InMenu()
        {
            return gameState == GameState.Menu;
        }
        public bool IsPaused()
        {
            return gameState == GameState.Paused;
        }

        public void TogglePause()
        {
            switch (gameState)
            {
                case GameState.Playing:
                    NewGameState = GameState.Paused;
                    break;
                case GameState.Paused:
                    NewGameState = GameState.Playing;
                    break;
            }
        }
        public void StartGame()
        {
            NewGameState = GameState.Playing;
        }
        public void EndGame(bool win)
        {
            winner = win;
            NewGameState = GameState.Finished;
            HighScores.Instance.AddScore(Score.Instance.GetScore);
        }

        public void Update(GameTime gameTime)
        {
            gameStates[gameState].Update(gameTime);
        }
        public void Draw()
        {
            gameStates[gameState].Draw();
        }

        public void Reset()
        {
            NewGameState = GameState.Menu;
        }

        public Game1 Game
        {
            set
            {
                game = value;
                gameStates = new Dictionary<GameState, IGameState>()
                {
                    {GameState.Playing, new GameplayState(game) },
                    {GameState.Paused, new PausedState(game) },
                    {GameState.Finished, new FinishedState(game) },
                    {GameState.Menu, new MenuState(game) },
                };
            }
        }
        public bool Win
        {
            get => winner;
        }
        private GameState NewGameState
        {
            set
            {
                gameState = value;
                gameStates[value].NewState();
            }
        }
    }
}
