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

            string answer = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Pick [bold]one[/]:")
                .PageSize(4)
                .MoreChoicesText("Scroll down for more choices!")
                .AddChoices("The illusion of choice.", "Pick me.", "No, me!", "Hi. :)", "Hello, world!"));

            AnsiConsole.WriteLine("You answered: " + answer);

            await Task.CompletedTask;
        }
    }
}