using CrossPlatformDesktopProject.GameState;
using CrossPlatformDesktopProject.InGameInfo;
using CrossPlatformDesktopProject.Gameplay;
using CrossPlatformDesktopProject.Menu;

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
            GameplayManager.Instance.Reset();
            game.Rover.Reset();
            MenuManager.Instance.Reset();
        }
        public void Unexecute()
        {
            pressed = false;
        }
    }
}