// Copyright (C) 2021 Tomat and Contributors, MIT License

using System.Threading.Tasks;
using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;
using Spectre.Console;
using TomatoKnishes.SpectreFx.Identities;

namespace TomatoKnishes.SpectreFx.Sample.Commands
{
    [Command]
    public class ExampleCommand : ICommand, ICommandIdentity
    {
        public string CommandName => "Example Command";

        public string CommandDescription => "Here's a description!";


        // NOTE: Unless IConsoleIdentity is implemented,
        // console will be null in an interactive interface.
        public async ValueTask ExecuteAsync(IConsole console)
        {
            AnsiConsole.WriteLine("One, two, three, testing... testing...");

            await Task.CompletedTask;
        }
    }
}