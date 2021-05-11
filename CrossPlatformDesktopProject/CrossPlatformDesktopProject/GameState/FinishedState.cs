using CrossPlatformDesktopProject.InGameInfo;
using Microsoft.Xna.Framework;
using CrossPlatformDesktopProject.Gameplay;
using CrossPlatformDesktopProject.Sprites;

namespace CrossPlatformDesktopProject.GameState
{
    public class FinishedState : IGameState
    {
        private Game1 game;
        private ISprite gameOverSprite;
        private ISprite youWinLoseSprite;
        public FinishedState(Game1 game)
        {
            this.game = game;
            gameOverSprite = SpriteFactory.Instance.GameOverSprite(new Vector2((game.Dimensions.X - 100) / 2, game.Dimensions.Y / 3 - 40 / 2));
        }
        public void Update(GameTime gameTime)
        {
            youWinLoseSprite.Update(gameTime);
        }
        public void Draw()
        {
            Score.Instance.Draw();
            Ammo.Instance.Draw();
            Stars.Instance.Draw();
            GameplayManager.Instance.Draw();
            CollisionManager.Instance.Draw();
            game.Rover.Draw();
            game.Grass.Draw();
            gameOverSprite.Draw();
            youWinLoseSprite.Draw();
        }
        public void NewState()
        {
            youWinLoseSprite = SpriteFactory.Instance.YouWinLoseSprite(new Vector2((game.Dimensions.X - 160) / 2, 2 * game.Dimensions.Y / 3 - 50 / 2), GameStateManager.Instance.Win);
        }
    }
}
