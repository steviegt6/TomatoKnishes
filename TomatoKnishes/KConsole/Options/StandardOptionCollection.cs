#region License
// Copyright (C) 2021 Tomat and Contributors, MIT License
#endregion

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TomatoKnishes.Internals;
using TomatoKnishes.Internals.Localization;

namespace TomatoKnishes.KConsole.Options
{
    /// <summary>
    ///     Default implementation of <see cref="IOptionCollection"/>.
    /// </summary>
    public class StandardOptionCollection : IOptionCollection
    {
        public string PromptText { get; set; }

        public bool DisplayReturn { get; set; }

        public bool DisplayGoBack { get; set; }

        public IOptionCollection? PreviousCollectionState { get; set; }

        protected IList<IConsoleOption> UnderlyingOptionCollection;

        public int Count => UnderlyingOptionCollection.Count;

        public bool IsReadOnly => UnderlyingOptionCollection.IsReadOnly;

        public IConsoleOption this[int index]
        {
            get => UnderlyingOptionCollection[index];
            set => UnderlyingOptionCollection[index] = value;
        }

        public StandardOptionCollection(string prompt, IOptionCollection? previousCollectionState,
            params IConsoleOption[] options)
        {
            PromptText = prompt;
            PreviousCollectionState = previousCollectionState;

            for (int i = 0; i < options.Length; i++)
                options[i].Index = i;

            UnderlyingOptionCollection = options.ToList();
        }

        public virtual void ListOptions<TColor>(IConsoleWindow<TColor> window)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;

                window.WriteLine(ToString());

                string? key = Console.ReadLine();

                switch (key)
                {
                    case null:
                        window.WriteAndClear(
                            Knishes.Localizer.GetLocalizedText(ConsoleLocalization.ConsoleText.NullOnlyNumbers),
                            window.ErrorColor);
                        continue;

                    case "/" when DisplayReturn:
                        window.WriteAndClear(
                            Knishes.Localizer.GetLocalizedText(ConsoleLocalization.ConsoleText.ReturnedToStart),
                            window.SuccessColor);
                        window.SelectedOptions = window.DefaultOptions;
                        window.SelectedOptions.ListOptions(window);
                        return;

                    case "." when DisplayGoBack:
                        if (PreviousCollectionState == null)
                            window.WriteAndClear(
                                Knishes.Localizer.GetLocalizedText(ConsoleLocalization.ConsoleText.NoPreviousState),
                                window.ErrorColor);
                        else
                        {
                            window.WriteAndClear(
                                Knishes.Localizer.GetLocalizedText(ConsoleLocalization.ConsoleText.ReturningToPrevious),
                                window.SuccessColor);
                            window.WriteOptionsList(PreviousCollectionState);
                        }

                        return;
                }

                if (!int.TryParse(key, out int option))
                {
                    window.WriteAndClear(
                        Knishes.Localizer.GetLocalizedText(ConsoleLocalization.ConsoleText.UnableToParseNumbers),
                        window.ErrorColor);
                    continue;
                }

                if (option < 1 || option > Count)
                {
                    window.WriteAndClear(
                        Knishes.Localizer.GetLocalizedText(ConsoleLocalization.ConsoleText.NoCorrespondingOptions),
                        window.ErrorColor);
                    continue;
                }

                this.First(x => x.Index == option - 1).ExecuteAsync();
                break;
            }
        }

        public override string ToString()
        {
            string text = this.Aggregate(PromptText, (current, option) => current + '\n' + option);

            if (DisplayGoBack && PreviousCollectionState is not null)
                text += $"\n  [.] {Knishes.Localizer.GetLocalizedText(ConsoleLocalization.ConsoleText.GoBackText)}";

            if (DisplayReturn)
                text += $"\n  [/] {Knishes.Localizer.GetLocalizedText(ConsoleLocalization.ConsoleText.ReturnText)}";

            return text;
        }

        public object Clone() =>
            new StandardOptionCollection(PromptText, PreviousCollectionState, UnderlyingOptionCollection.ToArray())
            {
                DisplayReturn = DisplayReturn,
                DisplayGoBack = DisplayGoBack
            };

        public IEnumerator<IConsoleOption> GetEnumerator() => UnderlyingOptionCollection.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void Add(IConsoleOption item) => UnderlyingOptionCollection.Add(item);

        public void Clear() => UnderlyingOptionCollection.Clear();

        public bool Contains(IConsoleOption item) => UnderlyingOptionCollection.Contains(item);

        public void CopyTo(IConsoleOption[] array, int arrayIndex) =>
            UnderlyingOptionCollection.CopyTo(array, arrayIndex);

        public bool Remove(IConsoleOption item) => UnderlyingOptionCollection.Remove(item);

        public int IndexOf(IConsoleOption item) => UnderlyingOptionCollection.IndexOf(item);

        public void Insert(int index, IConsoleOption item) => UnderlyingOptionCollection.Insert(index, item);

        public void RemoveAt(int index) => UnderlyingOptionCollection.RemoveAt(index);
    }
}