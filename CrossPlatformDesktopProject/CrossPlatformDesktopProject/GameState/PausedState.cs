﻿using CrossPlatformDesktopProject.InGameInfo;
using Microsoft.Xna.Framework;
using CrossPlatformDesktopProject.Gameplay;

namespace CrossPlatformDesktopProject.GameState
{
    public class PausedState : IGameState
    {
        private Game1 game;
        public PausedState(Game1 game)
        {
            this.game = game;
        }
        public void Update(GameTime gameTime)
        {

        }
        public void Draw()
        {
            Score.Instance.Draw();
            Ammo.Instance.Draw();
            Stars.Instance.Draw();
            GameplayManager.Instance.Draw();
            game.Rover.Draw();
            game.Grass.Draw();
        }
    }
}