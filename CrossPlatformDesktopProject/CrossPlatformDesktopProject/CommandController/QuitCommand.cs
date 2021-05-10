﻿namespace CrossPlatformDesktopProject.CommandController
{
    public class QuitCommand : ICommand
    {
        private Game1 game;

        public QuitCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute(int id)
        {
            game.Exit();
        }
        public void Unexecute() { }
    }
}