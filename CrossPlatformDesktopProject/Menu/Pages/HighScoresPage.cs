using CrossPlatformDesktopProject.Sprites;
using Microsoft.Xna.Framework;
using CrossPlatformDesktopProject.Menu.PopUps;

namespace CrossPlatformDesktopProject.Menu.Pages
{
    public class HighScoresPage : IPage
    {
        private Game1 game;

        private ISprite highScoresLabel;
        private ISprite top3;
        private ISprite highScoresScreen;

        private IPopUp warning;
        private bool popUpDisplayed;

        public HighScoresPage(Game1 game)
        {
            this.game = game;
            highScoresLabel = SpriteFactory.Instance.HighScoresSprite(new Vector2((game.Dimensions.X - 68) / 2, 10));
            highScoresScreen = SpriteFactory.Instance.HighScreenSprite(new Vector2());
            top3 = SpriteFactory.Instance.Top3Sprite(new Vector2());
            popUpDisplayed = false;
            warning = new ClearConfirmPopUp(game);
        }

        public void PopUp()
        {
            if (popUpDisplayed) HighScores.Instance.ClearScores();
            popUpDisplayed = !popUpDisplayed;
        }

        public void Update(GameTime gameTime)
        {
            if (popUpDisplayed) warning.Update(gameTime);
        }
        public void Draw()
        {
            if (popUpDisplayed) warning.Draw();
            highScoresLabel.Draw();
            top3.Draw();
            highScoresScreen.Draw();
            HighScores.Instance.Draw();
        }

        public void Reset()
        {
            popUpDisplayed = false;
        }

        public bool PopUpDisplayed
        {
            get => popUpDisplayed;
        }
    }
}
