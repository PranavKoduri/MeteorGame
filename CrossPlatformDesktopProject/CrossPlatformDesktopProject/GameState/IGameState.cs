using Microsoft.Xna.Framework;

namespace CrossPlatformDesktopProject.GameState
{
    public interface IGameState
    {
        public void Update(GameTime gameTime);
        public void Draw();
        public void NewState();
    }
}
