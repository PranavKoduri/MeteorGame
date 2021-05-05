using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace CrossPlatformDesktopProject.GameState
{
    public class GameStateManager
    {
        private Game1 game;
        private GameState gameState;
        private Dictionary<GameState, IGameState> gameStates;

        private enum GameState
        {
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
            gameState = GameState.Playing;
        }

        public bool IsPlaying()
        {
            return gameState == GameState.Playing;
        }

        public void TogglePause()
        {
            switch (gameState)
            {
                case GameState.Playing:
                    gameState = GameState.Paused;
                    break;
                case GameState.Paused:
                    gameState = GameState.Playing;
                    break;
            }
        }
        public void EndGame()
        {
            gameState = GameState.Finished;
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
            gameState = GameState.Playing;
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
                };
            }
        }
    }
}
