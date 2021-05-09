using Microsoft.Xna.Framework;

namespace CrossPlatformDesktopProject.Menu.PageSets
{
    public interface IPageSet
    {
        public void PageChange(bool changeLeft);
        public void PopUp();
        public void Update(GameTime gameTime);
        public void Draw();
        public void Reset();
    }
}
