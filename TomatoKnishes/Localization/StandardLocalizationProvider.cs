#region License
// Copyright (C) 2021 Tomat and Contributors
// GNU General Public License Version 3, 29 June 2007
#endregion

using System;
using System.Collections.Generic;
using System.Globalization;

namespace TomatoKnishes.Localization
{
    /// <summary>
    ///     Standard implementation of <see cref="ILocalizationProvider{T}"/>.
    /// </summary>
    /// <typeparam name="T">Enum.</typeparam>
    public abstract class StandardLocalizationProvider<T> : ILocalizationProvider<T> where T : Enum
    {
        public virtual CultureInfo DefaultCulture => LocalizationConstants.Default;

        public abstract IDictionary<T, ILocalizedTextEntry> TextEntries { get; }

        public virtual ILocalizedTextEntry RetrieveLocalizedEntry(T key, CultureInfo culture = null) =>
            !TextEntries.TryGetValue(key, out ILocalizedTextEntry textEntry)
                ? new StandardLocalizedTextEntry((DefaultCulture, key.ToString()))
                : textEntry;

        public string RetrieveLocalizedText(T key, CultureInfo culture = null) =>
            RetrieveLocalizedEntry(key, culture).GetText(GetUsableCulture(key, culture));

        private CultureInfo GetUsableCulture(T key, CultureInfo culture)
        {
            culture ??= CultureInfo.CurrentCulture;

            if (!TextEntries[key].LocalizationMap.ContainsKey(culture))
                culture = DefaultCulture;

            return culture;
        }
    }
}