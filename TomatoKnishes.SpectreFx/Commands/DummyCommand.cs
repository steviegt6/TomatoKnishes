// Copyright (C) 2021 Tomat and Contributors, MIT License

using System;
using System.Threading.Tasks;
using CliFx;
using CliFx.Infrastructure;
using TomatoKnishes.SpectreFx.Identities;

namespace TomatoKnishes.SpectreFx.Commands
{
    public abstract class DummyCommand : ICommand, ICommandIdentity, IConsoleIdentity
    {
        public abstract string CommandName { get; }

        public abstract string CommandDescription { get; }

        public ValueTask ExecuteAsync(IConsole console) =>
            throw new Exception("Attempted to execute an un-executable command!");

        public IConsole GetConsole() => null!;
    }
}