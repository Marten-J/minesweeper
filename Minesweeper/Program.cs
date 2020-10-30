using Minesweeper.GameLogic;
using System;

namespace Minesweeper
{
    /// <summary>
    /// Application entry point.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Start method of the application.
        /// </summary>
        /// <param name="args">Command lines arguments</param>
        static void Main(string[] args)
        {
            Game game = new Game();
            game.StartGame();
            Environment.Exit(0);
        }
    }
}
