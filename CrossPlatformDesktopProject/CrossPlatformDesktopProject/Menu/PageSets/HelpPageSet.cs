using System.Collections.Generic;
using CrossPlatformDesktopProject.Menu.Pages;
using Microsoft.Xna.Framework;
using CrossPlatformDesktopProject.Sprites;

namespace CrossPlatformDesktopProject.Menu.PageSets
{
    public class HelpPageSet : IPageSet
    {
        private Game1 game;

        private int currentPage;
        private List<IPage> pages;

        private ISprite leftPage;
        private ISprite rightPage;
        private const int offset = 20;
        private readonly Vector2 left;
        private readonly Vector2 right;

        public HelpPageSet(Game1 game)
        {
            this.game = game;
            currentPage = 0;
            pages = new List<IPage>()
            {
                { new MenuControlsPage(game) },
                { new GameRulesPage(game) },
                { new GameControlsPage(game) },
            };
            left = new Vector2(offset, game.Dimensions.Y - offset - 9);
            right = new Vector2(game.Dimensions.X - offset - 9, game.Dimensions.Y - offset - 9);
            UpdatePageIndicators();
        }

        public void PageChange(bool changeLeft)
        {
            if (pages[currentPage].PopUpDisplayed) return;
            if (changeLeft && currentPage > 0) currentPage--;
            else if (!changeLeft && currentPage < pages.Count - 1) currentPage++;
            UpdatePageIndicators();
        }
        public void PopUp()
        {
            pages[currentPage].PopUp();
        }
        public void Update(GameTime gameTime)
        {
            pages[currentPage].Update(gameTime);
        }
        public void Draw()
        {
            pages[currentPage].Draw();
            leftPage.Draw();
            rightPage.Draw();
        }

        public void Reset()
        {
            foreach (IPage page in pages)
            {
                page.Reset();
            }
            currentPage = 0;
        }

        private void UpdatePageIndicators()
        {
            leftPage = SpriteFactory.Instance.PageSprite(left, true, currentPage > 0);
            rightPage = SpriteFactory.Instance.PageSprite(right, false, currentPage < pages.Count - 1);
        }
    }
}
