using Microsoft.Xna.Framework;
using CrossPlatformDesktopProject.Entities;
using CrossPlatformDesktopProject.InGameInfo;

namespace CrossPlatformDesktopProject.Gameplay
{
    public class Stage1 : IStage
    {
        private const int stage = 1;

        public Stage1()
        {

        }

        public void Update(GameTime gameTime)
        {

        }
        public void StartStage()
        {

        }
        public void FinishStage()
        {
            Score.Instance.StageComplete(stage);
        }
    }
}
