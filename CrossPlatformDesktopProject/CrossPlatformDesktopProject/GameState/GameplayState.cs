using CrossPlatformDesktopProject.InGameInfo;
using Microsoft.Xna.Framework;

namespace CrossPlatformDesktopProject.GameState
{
    public class GameplayState : IGameState
    {
        private Game1 game;
        public GameplayState(Game1 game)
        {
            this.game = game;
        }
        public void Update(GameTime gameTime)
        {
            Score.Instance.Update(gameTime);
            Stars.Instance.Update(gameTime);
            game.Rover.Update(gameTime);
        }
        public void Draw()
        {
            Score.Instance.Draw();
            Ammo.Instance.Draw();
            Stars.Instance.Draw();
            game.Rover.Draw();
            game.Grass.Draw();
        }
    }
}
