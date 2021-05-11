using CrossPlatformDesktopProject.Sprites;
using Microsoft.Xna.Framework;

namespace CrossPlatformDesktopProject.Menu.Pages
{
    public class MenuControlsPage : IPage
    {
        private Game1 game;

        private ISprite screen;

        public MenuControlsPage(Game1 game)
        {
            this.game = game;
            screen = SpriteFactory.Instance.MenuControlsSprite(new Vector2());
        }

        public void PopUp()
        {
        }

        public void Update(GameTime gameTime)
        {
        }
        public void Draw()
        {
            screen.Draw();
        }

        public void Reset()
        {
        }

        public bool PopUpDisplayed
        {
            get => false;
        }
    }
}
