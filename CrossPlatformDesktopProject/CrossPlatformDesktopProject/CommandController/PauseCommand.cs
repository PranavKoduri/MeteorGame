using CrossPlatformDesktopProject.GameState;
using CrossPlatformDesktopProject.Menu;

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
            if (GameStateManager.Instance.IsPaused() || GameStateManager.Instance.IsPlaying()) GameStateManager.Instance.TogglePause();
            else if (GameStateManager.Instance.InMenu()) MenuManager.Instance.StartGame();
        }
        public void Unexecute()
        {
            pressed = false;
        }
    }
}