// Copyright (C) 2021 Tomat and Contributors, MIT License

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CliFx;
using Spectre.Console;

namespace TomatoKnishes.SpectreFx
{
    public abstract class ConsoleWindow
    {
        public abstract CommandContainer DefaultCommandSet { get; }

        public virtual CommandContainer? PreviousCommandSet { get; protected set; }

        // "Safe" null since CommandSet should generally be null.
        // CommandSet defaults to DefaultCommandSet in case of nulls.
        protected CommandContainer? CurrentCommandSet;

        public virtual CommandContainer CommandSet
        {
            get => CurrentCommandSet ??= DefaultCommandSet;

            set
            {
                PreviousCommandSet = CommandSet;
                CurrentCommandSet = value;
            }
        }

        public virtual async Task WriteFullConsole(Action? preWrite = null, Action? postWrite = null)
        {
            WriteStaticConsole(preWrite, postWrite);
            await CommandSet.ListenForInput();
        }

        public abstract void WriteStaticConsole(Action? preWrite = null, Action? postWrite = null);

        public virtual async Task ClearConsole(string text = "", Color? writeColor = null, Action? preWrite = null,
            Action? postWrite = null)
        {
            AnsiConsole.Clear();

            await WriteFullConsole(preWrite, () =>
            {
                Color prior = AnsiConsole.Foreground;

                if (writeColor.HasValue)
                    AnsiConsole.Foreground = writeColor.Value;

                if (!string.IsNullOrEmpty(text))
                    AnsiConsole.WriteLine(text);

                AnsiConsole.Foreground = prior;

                // Extra padding in post.
                AnsiConsole.WriteLine();

                postWrite?.Invoke();
            });
        }

        public virtual CommandContainer CreateContainer(IEnumerable<ICommand> commands,
            string promptText, bool allowReturn = true, bool allowGoBack = true) =>
            new(commands, this, PreviousCommandSet)
            {
                PromptText = promptText,
                AllowReturn = allowReturn,
                AllowGoBack = allowGoBack
            };
    }
}