using CrossPlatformDesktopProject.InGameInfo;
using Microsoft.Xna.Framework;
using CrossPlatformDesktopProject.Gameplay;

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
            GameplayManager.Instance.Update(gameTime);
            CollisionManager.Instance.Update();
            game.Rover.Update(gameTime);
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
        }
        public void NewState()
        {

        }
    }
}
