using CrossPlatformDesktopProject.GameState;

namespace CrossPlatformDesktopProject.CommandController
{
    public class PauseCommand : ICommand
    {
        private Game1 game;
        private bool pressed;

        public PauseCommand(Game1 game)
        {
            this.game = game;
            pressed = false;
        }

        public void Execute(int id)
        {
            if (pressed) return;
            pressed = true;
            GameStateManager.Instance.TogglePause();
        }
        public void Unexecute()
        {
            pressed = false;
        }
    }
}