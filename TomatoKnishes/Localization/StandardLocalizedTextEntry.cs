#region License
// Copyright (C) 2021 Tomat and Contributors, MIT License
#endregion

using System.Collections.Generic;
using System.Globalization;

namespace TomatoKnishes.Localization
{
    public class StandardLocalizedTextEntry : ILocalizedTextEntry
    {
        public virtual IDictionary<CultureInfo, string> LocalizationMap { get; }

        public StandardLocalizedTextEntry(IDictionary<CultureInfo, string> localizationMap)
        {
            LocalizationMap = localizationMap;
        }

        public StandardLocalizedTextEntry(params (CultureInfo, string)[] localizationTupleCollection)
        {
            Dictionary<CultureInfo, string> localizationMap = new();

            foreach ((CultureInfo culture, string text) in localizationTupleCollection)
                localizationMap.Add(culture, text);

            LocalizationMap = localizationMap;
        }

        /// <inheritdoc cref="ILocalizedTextEntry.GetText"/>
        /// <exception cref="KeyNotFoundException">If the current culture and default culture both are not valid keys for <see cref="LocalizationMap"/>.</exception>
        public virtual string GetText(CultureInfo defaultCulture) =>
            LocalizationMap.ContainsKey(CultureInfo.CurrentCulture)
                ? LocalizationMap[CultureInfo.CurrentCulture]
                : LocalizationMap[defaultCulture];
    }
}