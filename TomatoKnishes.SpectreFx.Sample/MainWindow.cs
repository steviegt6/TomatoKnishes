// Copyright (C) 2021 Tomat and Contributors, MIT License

using System;
using System.Collections.Generic;
using CliFx;
using Spectre.Console;
using TomatoKnishes.SpectreFx.Sample.Commands;
// ReSharper disable StringLiteralTypo

namespace TomatoKnishes.SpectreFx.Sample
{
    public class MainWindow : ConsoleWindow
    {
        public override CommandContainer DefaultCommandSet => CreateContainer(new List<ICommand>
        {
            new ExampleCommand(),
            new ExampleSecondCommand()
        }, "Sample program, select an option(!):");

        public override void WriteStaticConsole(Action? preWrite = null, Action? postWrite = null)
        {
            preWrite?.Invoke();

            AnsiConsole.WriteLine("Welcome to TomatoKnishes.SpectreFx!");
            AnsiConsole.MarkupLine($"This library combines [#{Color.SkyBlue1.ToHex()}]Spectre.Console[/] & [#{Color.Gold1.ToHex()}]CliFx[/].");
            AnsiConsole.MarkupLine("It allows for making console programs with CL and CLI support! :red_heart: (emojis won't render in some terminals)");
            AnsiConsole.WriteLine();
            AnsiConsole.MarkupLine("[bold]Feel[/] [italic]free[/] [slowblink]to[/] [invert]use[/] [underline]Markup[/] [dim]as[/] [strikethrough]well[/]!");

            postWrite?.Invoke();
        }
    }
}