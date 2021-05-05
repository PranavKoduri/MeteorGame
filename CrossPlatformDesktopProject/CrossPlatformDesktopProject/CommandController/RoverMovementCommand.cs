using Microsoft.Xna.Framework;

namespace CrossPlatformDesktopProject.CommandController
{
    public class RoverMovementCommand : ICommand
    {
        private Game1 game;

        public RoverMovementCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute(int id)
        {
            id = id % 2;
            game.Rover.Move(new Vector2(2 * (id * 2 - 1), 0));
        }
        public void Unexecute() 
        {
            game.Rover.Move(new Vector2());
        }
    }
}