﻿namespace BalloonsPop.Commands
{
    public interface ICommand
    {
        void Execute(ICommandContext ctx);
        bool CanExecute(ICommandContext ctx);
    }
}
