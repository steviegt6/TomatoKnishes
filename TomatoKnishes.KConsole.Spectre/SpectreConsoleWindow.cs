#region License
// Copyright (C) 2021 Tomat and Contributors, MIT License
#endregion

using System.Collections.Generic;
using Spectre.Console;
using TomatoKnishes.Internals;
using TomatoKnishes.Internals.Localization;
using TomatoKnishes.KConsole.Options;

namespace TomatoKnishes.KConsole.Spectre
{
    public abstract class SpectreConsoleWindow : IConsoleWindow<Color>
    {
        public abstract IOptionCollection DefaultOptions { get; }

        protected IOptionCollection? Selected;

        public virtual IOptionCollection SelectedOptions
        {
            get => Selected ??= DefaultOptions;
            set => Selected = value;
        }

        public Color SuccessColor => Color.Green;
        public Color ErrorColor => Color.Red;

        public abstract void WriteStaticText(bool appendExtraNewLine = true);

        public virtual void Write(object o) => AnsiConsole.Write(o.ToString() ?? string.Empty);

        public virtual void WriteLine() => AnsiConsole.WriteLine();

        public virtual void WriteLine(object o) => AnsiConsole.WriteLine(o.ToString() ?? string.Empty);

        public virtual void Clear(bool appendExtraNewLine = true)
        {
            AnsiConsole.Clear();
            WriteStaticText(appendExtraNewLine);
        }

        public virtual void WriteOptionsList(IOptionCollection collection)
        {
            SelectedOptions = collection;
            SelectedOptions.ListOptions(this);
        }

        public virtual void WriteAndClear(string message, Color color)
        {
            Color orig = AnsiConsole.Foreground;
            Clear();
            AnsiConsole.Foreground = color;
            WriteLine(message);
            AnsiConsole.Foreground = orig;
        }

        public virtual void DisplayPagedList<TItem>(int itemsPerPage, params TItem[] items) where TItem : notnull
        {
            int totalCount = 0;
            int localCount = 0;
            List<(string, int)> localPage = new();
            List<List<(string, int)>> pages = new();

            for (int i = 0; i < items.Length; i++)
            {
                totalCount++;
                localCount++;

                localPage.Add((
                    items[i].ToString() ??
                    Knishes.Localizer.GetLocalizedText(ConsoleLocalization.ConsoleText.InvalidEntry), totalCount));

                if (localCount != itemsPerPage && i != items.Length - 1)
                    continue;

                pages.Add(localPage);
                localPage = new List<(string, int)>();
                localCount = 0;
            }

            int selectedPage = 0;
            while (true)
            {
                if (selectedPage >= pages.Count)
                    break;

                WriteAndClear(
                    string.Format(Knishes.Localizer.GetLocalizedText(ConsoleLocalization.ConsoleText.DisplayingPage),
                        selectedPage + 1, pages.Count), Color.Yellow);

                foreach ((string entryName, int entryNumber) in pages[selectedPage])
                {
                    AnsiConsole.Foreground = Color.DarkSlateGray2;
                    Write($" [{entryNumber}]");
                    AnsiConsole.Foreground = Color.White;
                    WriteLine($" - {entryName}");
                }

                AskForInput:
                WriteLine();
                WriteLine(Knishes.Localizer.GetLocalizedText(ConsoleLocalization.ConsoleText.GotoPage));

                string input = AnsiConsole.Ask<string>(string.Empty);
                if (!int.TryParse(input, out int realInput))
                {
                    AnsiConsole.Foreground = Color.Red;
                    WriteLine(Knishes.Localizer.GetLocalizedText(ConsoleLocalization.ConsoleText.InvalidInput));
                    AnsiConsole.Foreground = Color.White;
                    goto AskForInput;
                }

                if (realInput <= -1)
                    break;

                if (realInput > pages.Count)
                    realInput = pages.Count;

                if (realInput == 0)
                    realInput = 1;

                selectedPage = realInput - 1;
            }
        }
    }
}