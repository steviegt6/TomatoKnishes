#region License
// Copyright (C) 2021 Tomat and Contributors, MIT License
#endregion

using System.Collections.Generic;
using TomatoKnishes.Localization;

namespace TomatoKnishes.Internals.Localization
{
    public class ConsoleLocalization : StandardLocalizationProvider<ConsoleLocalization.ConsoleText>
    {
        public enum ConsoleText
        {
            GoBackText,
            ReturnText,
            InvalidInput,
            GotoPage,
            DisplayingPage,
            InvalidEntry,
            NullOnlyNumbers,
            ReturnedToStart,
            NoPreviousState,
            ReturningToPrevious,
            UnableToParseNumbers,
            NoCorrespondingOptions
        }

        public override IDictionary<ConsoleText, ILocalizedTextEntry> TextEntries { get; } =
            new Dictionary<ConsoleText, ILocalizedTextEntry>
            {
                {
                    ConsoleText.GoBackText,
                    new StandardLocalizedTextEntry(
                        (LocalizationConstants.English, "Return to the previous set of options.")
                    )
                },
                {
                    ConsoleText.ReturnText,
                    new StandardLocalizedTextEntry(
                        (LocalizationConstants.English, "Return to the start.")
                    )
                },
                {
                    ConsoleText.InvalidInput,
                    new StandardLocalizedTextEntry(
                        (LocalizationConstants.English, "Invalid input.")
                    )
                },
                {
                    ConsoleText.GotoPage,
                    new StandardLocalizedTextEntry(
                        (LocalizationConstants.English, "Goto page (-1 to exit):")
                    )
                },
                {
                    ConsoleText.DisplayingPage,
                    new StandardLocalizedTextEntry(
                        (LocalizationConstants.English, "Displaying page {0}/{1}.")
                    )
                },
                {
                    ConsoleText.InvalidEntry,
                    new StandardLocalizedTextEntry(
                        (LocalizationConstants.English, "INVALID ENTRY.")
                    )
                },
                {
                    ConsoleText.NullOnlyNumbers,
                    new StandardLocalizedTextEntry(
                        (LocalizationConstants.English, "The entered value returned null. Please only enter numbers.")
                    )
                },
                {
                    ConsoleText.ReturnedToStart,
                    new StandardLocalizedTextEntry(
                        (LocalizationConstants.English, "Returned to the start!")
                    )
                },
                {
                    ConsoleText.NoPreviousState,
                    new StandardLocalizedTextEntry(
                        (LocalizationConstants.English, "No previous state was found, falling back to the beginning...")
                    )
                },
                {
                    ConsoleText.ReturningToPrevious,
                    new StandardLocalizedTextEntry(
                        (LocalizationConstants.English, "Returning to the previous options menu...")
                    )
                },
                {
                    ConsoleText.UnableToParseNumbers,
                    new StandardLocalizedTextEntry(
                        (LocalizationConstants.English, "We weren't able to parse your response. Please only enter numbers.")
                    )
                },
                {
                    ConsoleText.NoCorrespondingOptions,
                    new StandardLocalizedTextEntry(
                        (LocalizationConstants.English, "The number entered does not correspond to any available options.")
                    )
                }
            };
    }
}