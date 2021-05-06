using Microsoft.Xna.Framework;
using CrossPlatformDesktopProject.GameState;

namespace CrossPlatformDesktopProject.CommandController
{
    public class RoverShootCommand : ICommand
    {
        private Game1 game;
        private bool pressed;

        public RoverShootCommand(Game1 game)
        {
            this.game = game;
            pressed = false;
        }

        public void Execute(int id)
        {
            if (pressed) return;
            pressed = true;
            if (GameStateManager.Instance.IsPlaying()) game.Rover.Shoot();
        }
        public void Unexecute()
        {
            pressed = false;
        }
    }
}