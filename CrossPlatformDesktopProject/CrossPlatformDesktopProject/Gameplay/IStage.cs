using Microsoft.Xna.Framework;

namespace CrossPlatformDesktopProject.Gameplay
{
    public interface IStage
    {
        public enum StageState
        {
            MeteorSpawning,
            MeteorSpawningFinished
        }
        public void Update(GameTime gameTime);
        public void StartStage();
        public void FinishStage();
        public void Reset();
    }
}
