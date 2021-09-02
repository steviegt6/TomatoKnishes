#region License
// Copyright (C) 2021 Tomat and Contributors, MIT License
#endregion

using System;
using System.Collections.Generic;
using TomatoKnishes.Internals;
using TomatoKnishes.Internals.Localization;
using TomatoKnishes.KConsole.Options;

namespace TomatoKnishes.KConsole
{
    /// <summary>
    ///     Default implementation of <see cref="IConsoleWindow{TColor}"/>.
    /// </summary>
    public abstract class StandardConsoleWindow : IConsoleWindow<ConsoleColor>
    {
        public abstract IOptionCollection DefaultOptions { get; }

        protected IOptionCollection? Selected;

        public virtual IOptionCollection SelectedOptions
        {
            get => Selected ??= DefaultOptions;
            set => Selected = value;
        }

        public ConsoleColor SuccessColor => ConsoleColor.Green;
        public ConsoleColor ErrorColor => ConsoleColor.Red;

        public abstract void WriteStaticText(bool appendExtraNewLine = true);

        public virtual void Write(object o) => Console.Write(o);

        public virtual void WriteLine() => Console.WriteLine();

        public virtual void WriteLine(object o) => Console.WriteLine(o);

        public virtual void Clear(bool appendExtraNewLine = true)
        {
            Console.Clear();
            WriteStaticText(appendExtraNewLine);
        }

        public virtual void WriteOptionsList(IOptionCollection collection)
        {
            SelectedOptions = collection;
            SelectedOptions.ListOptions(this);
        }

        public virtual void WriteAndClear(string message, ConsoleColor color)
        {
            ConsoleColor orig = Console.ForegroundColor;
            Clear();
            Console.ForegroundColor = color;
            WriteLine(message);
            Console.ForegroundColor = orig;
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
                        selectedPage + 1, pages.Count), ConsoleColor.Yellow);

                foreach ((string entryName, int entryNumber) in pages[selectedPage])
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write($" [{entryNumber}]");
                    Console.ForegroundColor = ConsoleColor.White;
                    WriteLine($" - {entryName}");
                }

                AskForInput:
                WriteLine();
                WriteLine(Knishes.Localizer.GetLocalizedText(ConsoleLocalization.ConsoleText.GotoPage));

                string? input = Console.ReadLine();
                if (!int.TryParse(input, out int realInput))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    WriteLine(Knishes.Localizer.GetLocalizedText(ConsoleLocalization.ConsoleText.InvalidInput));
                    Console.ForegroundColor = ConsoleColor.White;
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