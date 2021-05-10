using CrossPlatformDesktopProject.Menu;
using Microsoft.Xna.Framework;

namespace CrossPlatformDesktopProject.GameState
{
    public class MenuState : IGameState
    {
        private Game1 game;
        public MenuState(Game1 game)
        {
            this.game = game;
        }
        public void Update(GameTime gameTime)
        {
            MenuManager.Instance.Update(gameTime);
        }
        public void Draw()
        {
            MenuManager.Instance.Draw();
        }
        public void NewState()
        {
            MenuManager.Instance.Reset();
        }
    }
}
