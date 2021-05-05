using CrossPlatformDesktopProject.GameState;
using CrossPlatformDesktopProject.InGameInfo;

namespace CrossPlatformDesktopProject.CommandController
{
    public class ResetCommand : ICommand
    {
        private Game1 game;
        private bool pressed;

        public ResetCommand(Game1 game)
        {
            this.game = game;
            pressed = false;
        }

        public void Execute(int id)
        {
            if (pressed) return;
            pressed = true;
            GameStateManager.Instance.Reset();
            Score.Instance.Reset();
            Stars.Instance.Reset();
            game.Rover.Reset();
        }
        public void Unexecute()
        {
            pressed = false;
        }
    }
}