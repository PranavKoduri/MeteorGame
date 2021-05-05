using Microsoft.Xna.Framework;
using CrossPlatformDesktopProject.Sprites;

namespace CrossPlatformDesktopProject.Entities
{
    public class Grass
    {
        private Game1 game;

        private Vector2 topLeft;
        private Vector2 dimensions;
        private ISprite grassSprite;

        public Grass(Game1 game)
        {
            this.game = game;

            int grassOffset = 10;
            dimensions = new Vector2(game.Dimensions.X, grassOffset);
            topLeft = new Vector2(0, game.Dimensions.Y - grassOffset);
            grassSprite = SpriteFactory.Instance.GrassSprite(topLeft, dimensions);
        }

        public void Draw()
        {
            grassSprite.Draw();
        }

        public Vector2 TopLeft
        {
            get => topLeft;
        }
        public Vector2 Dimensions
        {
            get => dimensions;
        }
    }
}
