using Microsoft.Xna.Framework;
using CrossPlatformDesktopProject.GameState;
using CrossPlatformDesktopProject.Menu;

namespace CrossPlatformDesktopProject.CommandController
{
    public class RoverMovementCommand : ICommand
    {
        private Game1 game;
        private bool pressed;

        public RoverMovementCommand(Game1 game)
        {
            this.game = game;
            pressed = false;
        }

        public void Execute(int id)
        {
            id = id % 2;
            bool changeLeft = id == 0;
            if (GameStateManager.Instance.IsPlaying()) game.Rover.Move(new Vector2(2 * (id * 2 - 1), 0));
            if (pressed) return;
            pressed = true;
            if (GameStateManager.Instance.InMenu()) MenuManager.Instance.PageChange(changeLeft);
        }
        public void Unexecute() 
        {
            game.Rover.Move(new Vector2());
            pressed = false;
        }
    }
}