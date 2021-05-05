using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace CrossPlatformDesktopProject.CommandController
{
    public class CommandList
    {
        private Dictionary<Keys[], ICommand> keyboardCommandMap;

        private Game1 game;

        public CommandList(Game1 game)
        {
            this.game = game;
            BuildCommands();
        }

        private void BuildCommands()
        {
            keyboardCommandMap = new Dictionary<Keys[], ICommand>()
            {
                {new Keys[] {Keys.Q}, new QuitCommand(game)},
                {new Keys[] {Keys.Left, Keys.Right, Keys.A, Keys.D}, new RoverMovementCommand(game)},
            };
        }

        public Dictionary<Keys[], ICommand> KeyboardCommands
        {
            get => keyboardCommandMap;
        }
    }
}