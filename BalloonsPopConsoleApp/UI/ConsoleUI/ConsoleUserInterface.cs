﻿namespace BalloonsPopConsoleApp.UI.ConsoleUI
{
    using BalloonsPop.UI;
    using BalloonsPop.UI.Drawer;
    using BalloonsPop.UI.InputHandler;

    /// <summary>
    /// Provides common interface that contains both the Input Handler and the Drawer.
    /// </summary>
    public class ConsoleUserInterface : IUserInterface
    {
        /// <summary>
        /// ConsoleUserInteface constructor.
        /// </summary>
        public ConsoleUserInterface()
        {
            this.Drawer = new ConsoleDrawer();
            this.Reader = new ConsoleInputHandler();
        }

        /// <summary>
        /// IPicasso Object that takes care of displaying objects on the console.
        /// </summary>
        public IPicasso Drawer { get; private set; }

        /// <summary>
        /// IInputHandler Object that reads user input and handles any errors.
        /// </summary>
        public IInputHandler Reader { get; private set; }
    }
}
