﻿namespace BalloonsPopConsoleApp.Tests.Miscellaneous
{
    using Logs;
    using Memory;
    using BalloonsPopConsoleApp.Miscellaneous;
    using BalloonsPopConsoleApp.Models;
    using NUnit.Framework;

    [TestFixture]
    public class CommandContextTests
    {
        [Test]
        public void CommandContextShouldCreateProperly()
        {
            var ctx = new CommandContext(new Logger(), new Board(5, 5), 4, 4, new BoardMemory(), new Highscore());
        }

        [Test]
        public void CommandContextPropertiesAreAccessible()
        {
            var ctx = new CommandContext(new Logger(), new Board(5, 5), 4, 4, new BoardMemory(), new Highscore());
            Assert.IsTrue(ctx.Logger != null && ctx.Board != null && ctx.ActiveCol != null && ctx.ActiveRow != null && ctx.Memory != null && ctx.Score != null);
        }

        [Test]
        public void CommandContextMessagesShouldContainOneOrMoreEntries()
        {
            var ctx = new CommandContext(new Logger(), new Board(5, 5), 4, 4, new BoardMemory(), new Highscore());
            Assert.IsTrue(ctx.Messages.Count > 0);
        }

        [Test]
        public void CommandContextMessagesShouldContainWelcomeAndGoodbyeMessages()
        {
            var ctx = new CommandContext(new Logger(), new Board(5, 5), 4, 4, new BoardMemory(), new Highscore());
            Assert.IsTrue(ctx.Messages.ContainsKey("welcome") && ctx.Messages.ContainsKey("goodbye"));
        }

        [Test]
        public void CommandContextCurrentMessageShouldBeSetInitially()
        {
            var ctx = new CommandContext(new Logger(), new Board(5, 5), 4, 4, new BoardMemory(), new Highscore());
            Assert.IsTrue(ctx.CurrentMessage == ctx.Messages["welcome"]);
        }
        }
}