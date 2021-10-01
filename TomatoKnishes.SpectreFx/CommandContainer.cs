// Copyright (C) 2021 Tomat and Contributors, MIT License

using System.Collections.Generic;
using System.Linq;
using System.Text;
using CliFx.Infrastructure;
using Spectre.Console;
using Spectre.Console.Cli;
using TomatoKnishes.SpectreFx.Commands;
using TomatoKnishes.SpectreFx.Identities;
using TomatoKnishes.SpectreFx.Localization;

namespace TomatoKnishes.SpectreFx
{
    public class CommandContainer
    {
        public virtual List<CliFx.ICommand> Commands { get; }

        public virtual CommandContainer? PreviousContainer { get; }

        public virtual ConsoleWindow Window { get; }

        public virtual string PromptText { get; set; } = "Select an option:";

        public virtual bool AllowGoBack { get; set; } = true;

        public virtual bool AllowReturn { get; set; } = true;

        public CommandContainer(IEnumerable<CliFx.ICommand> commands, ConsoleWindow window,
            CommandContainer? previousContainer = null)
        {
            Commands = commands.ToList();
            PreviousContainer = previousContainer;
            Window = window;
        }

        public virtual void ListenForInput()
        {
            while (true)
            {
                AnsiConsole.Foreground = Color.White;
                AnsiConsole.WriteLine(ToString());

                // No prompt, written in ToString()
                string key = AnsiConsole.Ask<string>("");

                switch (key)
                {
                    case null:
                        Window.ClearConsole(SpectreFxLocalization.Get(SpectreFxType.NullOnlyNumbers), Color.Red);
                        continue;

                    case "." when AllowGoBack:
                        if (PreviousContainer is null)
                            Window.ClearConsole(SpectreFxLocalization.Get(SpectreFxType.NoPreviousState), Color.Red);
                        else
                        {
                            Window.ClearConsole(SpectreFxLocalization.Get(SpectreFxType.ReturningToPrevious),
                                Color.Green);
                            Window.CommandSet = PreviousContainer;
                            Window.CommandSet.ListenForInput();
                        }

                        return;

                    case "/" when AllowReturn:
                        Window.ClearConsole(SpectreFxLocalization.Get(SpectreFxType.ReturnedToStart), Color.Green);
                        Window.CommandSet = Window.DefaultCommandSet;
                        Window.CommandSet.ListenForInput();
                        return;
                }

                if (!int.TryParse(key, out int option))
                {
                    Window.ClearConsole(SpectreFxLocalization.Get(SpectreFxType.AllowOnlyNumbers), Color.Red);
                    continue;
                }

                if (option < 1 || option > Commands.Count)
                {
                    Window.ClearConsole(SpectreFxLocalization.Get(SpectreFxType.NoCorresponding), Color.Red);
                    continue;
                }

                CliFx.ICommand command = Commands[option - 1];
                IConsole? cliConsole = command is IConsoleIdentity id ? id.GetConsole() : null;

                command.ExecuteAsync(cliConsole!);
                break;
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new();

            builder.AppendLine(PromptText);

            void AppendCommand(CliFx.ICommand command, string index)
            {
                string commandText = $" [{index}] ";

                if (command is ICommandIdentity identity)
                    commandText += $"{identity.CommandName} - {identity.CommandDescription}";
                else
                    commandText += command.GetType().Name;

                builder.AppendLine(commandText);
            }

            for (int i = 0; i < Commands.Count; i++)
                AppendCommand(Commands[i], (i + 1).ToString());

            if (AllowGoBack)
                AppendCommand(new GoBackCommand(), ".");

            if (AllowReturn)
                AppendCommand(new ReturnCommand(), "/");

            return builder.ToString();
        }
    }
}