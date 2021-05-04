using Microsoft.Xna.Framework;

namespace CrossPlatformDesktopProject.Sprites
{
    public interface ISprite
    {
        public enum FrameChange
        {
            Forward,
            Backward,
            Still
        }
        public Vector2 Center { set; }
        public void Update(GameTime gameTime);
        public void Draw();
    }
}