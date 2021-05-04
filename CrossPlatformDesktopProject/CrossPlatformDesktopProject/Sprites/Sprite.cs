using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace CrossPlatformDesktopProject.Sprites
{
    public class Sprite : ISprite
    {
        private Texture2D texture;
        private SpriteBatch spriteBatch;
        private int rows;
        private int columns;
        private int frames;
        private float layer;

        private Vector2 center;
        private Vector2 dimensions;
        private Vector2 subTopLeft;
        private Vector2 subDimensions;

        public Sprite(Vector2 pos, Vector2 dim, SpriteBatch sprite, Texture2D txt, Vector2 subTopleft, Vector2 subDim, int rows, int columns, float layer)
        {
            center = pos;
            dimensions = dim;
            subTopLeft = subTopleft;
            subDimensions = subDim;

            spriteBatch = sprite;
            texture = txt;
            this.rows = rows;
            this.columns = columns;
            this.layer = layer;
            frames = rows * columns;
        }

        public void Update(GameTime gameTime)
        {

        }

        public Vector2 Center
        {
            set => center = value;
        }
    }
}