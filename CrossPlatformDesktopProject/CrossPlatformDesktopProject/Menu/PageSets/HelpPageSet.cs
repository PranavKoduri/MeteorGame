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
            pages = new List<IPage>()
            {
                { new MenuControlsPage(game) },
                { new GameRulesPage(game) },
                { new GameControlsPage(game) },
                { new MoreInfoPage(game) },
            };
            left = new Vector2(offset, game.Dimensions.Y - offset - 9);
            right = new Vector2(game.Dimensions.X - offset - 9, game.Dimensions.Y - offset - 9);
            CurrentPage = 0;
        }

        public void PageChange(bool changeLeft)
        {
            if (pages[CurrentPage].PopUpDisplayed) return;
            if (changeLeft && CurrentPage > 0) CurrentPage--;
            else if (!changeLeft && CurrentPage < pages.Count - 1) CurrentPage++;
        }
        public void PopUp()
        {
            pages[CurrentPage].PopUp();
        }
        public void Update(GameTime gameTime)
        {
            pages[CurrentPage].Update(gameTime);
        }
        public void Draw()
        {
            pages[CurrentPage].Draw();
            leftPage.Draw();
            rightPage.Draw();
        }

        public void Reset()
        {
            foreach (IPage page in pages)
            {
                page.Reset();
            }
            CurrentPage = 0;
        }

        private int CurrentPage
        {
            set
            {
                currentPage = value;
                leftPage = SpriteFactory.Instance.PageSprite(left, true, currentPage > 0);
                rightPage = SpriteFactory.Instance.PageSprite(right, false, currentPage < pages.Count - 1);
            }
            get => currentPage;
        }
    }
}
