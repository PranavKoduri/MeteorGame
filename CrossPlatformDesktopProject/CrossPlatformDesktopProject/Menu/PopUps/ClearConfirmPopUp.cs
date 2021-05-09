using Microsoft.Xna.Framework;
using CrossPlatformDesktopProject.Sprites;

namespace CrossPlatformDesktopProject.Menu.PopUps
{
    public class ClearConfirmPopUp : IPopUp
    {
        private Game1 game;

        private ISprite sprite;

        public ClearConfirmPopUp(Game1 game)
        {
            this.game = game;
            sprite = SpriteFactory.Instance.ClearConfirmSprite(new Vector2((game.Dimensions.X - 100) / 2, (game.Dimensions.Y - 40) / 2));
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }
        public void Draw()
        {
            sprite.Draw();
        }
    }
}
