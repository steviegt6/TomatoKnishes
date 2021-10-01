// Copyright (C) 2021 Tomat and Contributors, MIT License

using System.Collections.Generic;
using TomatoKnishes.Internals;
using TomatoKnishes.Localization;
using TomatoKnishes.Localization.Implementation;

namespace TomatoKnishes.SpectreFx.Localization
{
    public class SpectreFxLocalization : LocalizationProvider<SpectreFxType>
    {
        public override IDictionary<SpectreFxType, ILocalizedTextEntry> TextEntries =>
            new Dictionary<SpectreFxType, ILocalizedTextEntry>
            {
                {
                    SpectreFxType.NullOnlyNumbers, new LocalizedTextEntry(
                        (LocalizationConstants.English, "Input was null, please enter only numbers.")
                    )
                },
                {
                    SpectreFxType.ReturnedToStart, new LocalizedTextEntry(
                        (LocalizationConstants.English, "Returned to the starting state.")
                    )
                },
                {
                    SpectreFxType.NoPreviousState, new LocalizedTextEntry(
                        (LocalizationConstants.English, "No previous state found, fell back to the start.")
                    )
                },
                {
                    SpectreFxType.ReturningToPrevious, new LocalizedTextEntry(
                        (LocalizationConstants.English, "Returned to the previous options menu.")
                    )
                },
                {
                    SpectreFxType.AllowOnlyNumbers, new LocalizedTextEntry(
                        (LocalizationConstants.English,
                            "Unable to parse your response as an integer. Entry only numbers.")
                    )
                },
                {
                    SpectreFxType.NoCorresponding, new LocalizedTextEntry(
                        (LocalizationConstants.English, "This input does not correspond to any option.")
                    )
                },

                {
                    SpectreFxType.ReturnCommand, new LocalizedTextEntry(
                        (LocalizationConstants.English, "Return")
                    )
                },
                {
                    SpectreFxType.GoBackCommand, new LocalizedTextEntry(
                        (LocalizationConstants.English, "Go Back")
                    )
                },

                {
                    SpectreFxType.ReturnDescription, new LocalizedTextEntry(
                        (LocalizationConstants.English, "Return to the start.")
                    )
                },
                {
                    SpectreFxType.GoBackDescription, new LocalizedTextEntry(
                        (LocalizationConstants.English, "Go back to the previous set of options.")
                    )
                },
            };

        public static string Get(SpectreFxType type)
        {
            while (true)
            {
                SpectreFxLocalization? provider = Knishes.Localizer.GetProvider<SpectreFxLocalization, SpectreFxType>();

                if (provider is not null)
                    return Knishes.GetLocalizedText(type);

                Knishes.Localizer.AddProvider<SpectreFxLocalization, SpectreFxType>();
            }
        }
    }
}