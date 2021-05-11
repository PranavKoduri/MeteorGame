using CrossPlatformDesktopProject.GameState;
using CrossPlatformDesktopProject.Menu;
using CrossPlatformDesktopProject.Gameplay;

namespace CrossPlatformDesktopProject.CommandController
{
    public class RulesCommand : ICommand
    {
        private Game1 game;

        private bool pressed;

        public RulesCommand(Game1 game)
        {
            this.game = game;
            pressed = false;
        }

        public void Execute(int id)
        {
            if (pressed) return;
            pressed = true;
            if (GameStateManager.Instance.InMenu()) MenuManager.Instance.RulesPage();
            if (GameStateManager.Instance.IsPlaying()) GameplayManager.Instance.ShowHitboxes = !GameplayManager.Instance.ShowHitboxes;
        }
        public void Unexecute()
        {
            pressed = false;
        }
    }
}
