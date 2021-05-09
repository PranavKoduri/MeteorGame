using Microsoft.Xna.Framework;

namespace CrossPlatformDesktopProject.Menu.PopUps
{
    public interface IPopUp
    {
        public void Update(GameTime gameTime);
        public void Draw();
    }
}
