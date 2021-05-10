using System.Collections.Generic;
using CrossPlatformDesktopProject.Menu.PageSets;
using CrossPlatformDesktopProject.Sprites;
using Microsoft.Xna.Framework;
using CrossPlatformDesktopProject.GameState;

namespace CrossPlatformDesktopProject.Menu
{
    public class MenuManager
    {
        private Game1 game;

        private ISprite menuSprite;

        private bool inMainMenu;
        private PageSets currentPageSet;
        private List<IPageSet> pageSets;
        private Dictionary<PageSets, int> pageSetMap;
        private enum PageSets
        {
            Rules,
            Scores
        }

        private static MenuManager menuManagerInstance = new MenuManager();
        public static MenuManager Instance
        {
            get => menuManagerInstance;
        }
        private MenuManager()
        {
            inMainMenu = true;
            currentPageSet = PageSets.Rules;
            pageSetMap = new Dictionary<PageSets, int>()
            {
                { PageSets.Rules, 0 },
                { PageSets.Scores, 1 },
            };
        }

        public void HighScoresPage()
        {
            if (inMainMenu)
            {
                currentPageSet = PageSets.Scores;
                inMainMenu = false;
            }
        }
        public void RulesPage()
        {
            if (inMainMenu)
            {
                currentPageSet = PageSets.Rules;
                inMainMenu = false;
            }
        }
        public void GoBack()
        {
            inMainMenu = true;
            pageSets[pageSetMap[currentPageSet]].Reset();
        }

        public void PageChange(bool changeLeft)
        {
            if (!inMainMenu) pageSets[pageSetMap[currentPageSet]].PageChange(changeLeft);
        }
        public void PopUp()
        {
            if (!inMainMenu) pageSets[pageSetMap[currentPageSet]].PopUp();
        }

        public void Update(GameTime gameTime)
        {
            if (!inMainMenu) pageSets[pageSetMap[currentPageSet]].Update(gameTime);
        }
        public void Draw()
        {
            if (inMainMenu) menuSprite.Draw();
            else pageSets[pageSetMap[currentPageSet]].Draw();
        }

        public void Reset()
        {
            inMainMenu = true;
            foreach (IPageSet pageSet in pageSets)
            {
                pageSet.Reset();
            }
        }

        public void StartGame()
        {
            if (inMainMenu) GameStateManager.Instance.StartGame();
        }

        public Game1 Game
        {
            set
            {
                game = value;
                menuSprite = SpriteFactory.Instance.TitleSprite(new Vector2());
                pageSets = new List<IPageSet>()
                {
                    { new HelpPageSet(game) },
                    { new HighScorePageSet(game) },
                };
            }
        }
    }
}
