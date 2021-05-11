using Microsoft.Xna.Framework;

namespace CrossPlatformDesktopProject.Menu.Pages
{
    public interface IPage
    {
        public void PopUp();
        public void Update(GameTime gameTime);
        public void Draw();
        public void Reset();

        public bool PopUpDisplayed { get; }
    }
}
