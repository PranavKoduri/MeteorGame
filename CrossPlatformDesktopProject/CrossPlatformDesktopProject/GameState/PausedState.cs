using CrossPlatformDesktopProject.InGameInfo;
using Microsoft.Xna.Framework;
using CrossPlatformDesktopProject.Gameplay;
using CrossPlatformDesktopProject.Sprites;

namespace CrossPlatformDesktopProject.GameState
{
    public class PausedState : IGameState
    {
        private Game1 game;
        private ISprite pausedSprite;
        public PausedState(Game1 game)
        {
            this.game = game;
            pausedSprite = SpriteFactory.Instance.PausedSprite(new Vector2((game.Dimensions.X - 50)/ 2, (game.Dimensions.Y - 20)/ 2));
        }
        public void Update(GameTime gameTime)
        {

        }
        public void Draw()
        {
            Score.Instance.Draw();
            Ammo.Instance.Draw();
            Stars.Instance.Draw();
            GameplayManager.Instance.Draw();
            game.Rover.Draw();
            game.Grass.Draw();
            pausedSprite.Draw();
        }
        public void NewState()
        {

        }
    }
}
