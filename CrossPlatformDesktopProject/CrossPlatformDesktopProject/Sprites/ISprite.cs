using Microsoft.Xna.Framework;

namespace CrossPlatformDesktopProject.Sprites
{
    public interface ISprite
    {
        public enum FrameChange
        {
            Forward, //Sprite
            Backward, //Sprite
            Changing, //RandomSprite
            Still
        }
        public FrameChange FrameDirection{ set; }
        public Vector2 Center { set; }
        public void Update(GameTime gameTime);
        public void Draw();
    }
}