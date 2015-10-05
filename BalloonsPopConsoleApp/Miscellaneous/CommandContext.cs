﻿namespace BalloonsPopConsoleApp.Miscellaneous
{
    using System.Collections.Generic;
    using BalloonsPop;
    using BalloonsPop.Logs;

    /// <summary>
    /// Provides common interface to be used by all Commands.
    /// </summary>
    public class CommandContext : ICommandContext
    {
        private readonly Dictionary<string, string> messages = new Dictionary<string, string>()
        {
            { "welcome", "\nWelcome to \"Balloons Pops\" game. \r\nTry to pop the balloons in as few moves as possible. \r\nUse 'top' to view the top scoreboard, \r\n'restart' to start a new game and \r\n'exit' to quit the game.\n" },
            { "goodbye", "\nGoodbye!\n" },
            { "invalidmove", "\nIllegal move: cannot pop missing ballon!" },
            { "invalidcommand", "\nInvalid move or command!" },
            { "gameover", "\nYou popped all baloons in {0} moves.\r\nPlease enter your name for the top scoreboard: " },
            { "invalidsave", "\nYou cannot restore the game to a previous state as one does not exist yet!" },
            { "sizeprompt", "\nEnter a number between 5 and 15 for the board size \r\nor leave empty if you wish to play with the default size! : " },
            { "inputprompt", "\nEnter a command or valid move in the format \"row column\": " }
        };

        /// <summary>
        /// CommandContext constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="board"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="memory"></param>
        /// <param name="score"></param>
        public CommandContext(ILogger logger, IBoard board, int row, int col, IBoardMemory memory, IHighscore score)
        {
            this.Logger = logger;
            this.Board = board;
            this.ActiveRow = row;
            this.ActiveCol = col;
            this.Memory = memory;
            this.Score = score;

            this.CurrentMessage = this.Messages["welcome"];
        }

        /// <summary>
        /// Logger logs messages runtime.
        /// </summary>
        public ILogger Logger { get; set; }

        /// <summary>
        /// Board object containing Balloon objects.
        /// </summary>
        public IBoard Board { get; set; }

        /// <summary>
        /// Target column on which a command will be executed.
        /// </summary>
        public int ActiveCol { get; set; }

        /// <summary>
        /// Target row on which a command will be executed.
        /// </summary>
        public int ActiveRow { get; set; }

        /// <summary>
        /// Dictionary containing all messages that can be displayed alongside the game board.
        /// </summary>
        public Dictionary<string, string> Messages
        {
            get { return this.messages; }
        }

        /// <summary>
        /// Memory object where a memento is stored.
        /// </summary>
        public IBoardMemory Memory { get; set; }

        /// <summary>
        /// Score object where the player's score is updated.
        /// </summary>
        public IHighscore Score { get; set; }

        /// <summary>
        /// A message that will be displayed on every invocation of the CommandContext object.
        /// </summary>
        public string CurrentMessage { get; set; }
    }
}