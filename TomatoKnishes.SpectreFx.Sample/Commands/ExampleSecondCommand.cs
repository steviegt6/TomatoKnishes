// Copyright (C) 2021 Tomat and Contributors, MIT License

using System.Threading.Tasks;
using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;
using Spectre.Console;
using TomatoKnishes.SpectreFx.Identities;
// ReSharper disable StringLiteralTypo

namespace TomatoKnishes.SpectreFx.Sample.Commands
{
    [Command]
    public class ExampleSecondCommand : ICommand, ICommandIdentity
    {
        public string CommandName => "Sample Numero Dos";

        public string CommandDescription => "Here's a description... again.";

        // NOTE: Unless IConsoleIdentity is implemented,
        // console will be null in an interactive interface.
        public async ValueTask ExecuteAsync(IConsole console)
        {
            AnsiConsole.WriteLine("All Mikes please stand up. That concludes the mic test.");

            await Task.CompletedTask;
        }
    }
}