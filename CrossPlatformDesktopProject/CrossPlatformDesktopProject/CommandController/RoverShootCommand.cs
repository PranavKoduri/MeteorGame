using Microsoft.Xna.Framework;
using CrossPlatformDesktopProject.GameState;

namespace CrossPlatformDesktopProject.CommandController
{
    public class RoverShootCommand : ICommand
    {
        private Game1 game;

        public RoverShootCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute(int id)
        {
            if (GameStateManager.Instance.IsPlaying()) game.Rover.Move(new Vector2(2 * (id * 2 - 1), 0));
        }
        public void Unexecute()
        {
            game.Rover.Move(new Vector2());
        }
    }
}