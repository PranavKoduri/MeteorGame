using CrossPlatformDesktopProject.GameState;
using CrossPlatformDesktopProject.Menu;

namespace CrossPlatformDesktopProject.CommandController
{
    public class PopUpCommand : ICommand
    {
        private Game1 game;

        private bool pressed;

        public PopUpCommand(Game1 game)
        {
            this.game = game;
            pressed = false;
        }

        public void Execute(int id)
        {
            if (pressed) return;
            pressed = true;
            if (GameStateManager.Instance.InMenu()) MenuManager.Instance.PopUp();
        }
        public void Unexecute()
        {
            pressed = false;
        }
    }
}
