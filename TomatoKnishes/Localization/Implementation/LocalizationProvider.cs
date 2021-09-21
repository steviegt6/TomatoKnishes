#region License
// Copyright (C) 2021 Tomat and Contributors, MIT License
#endregion

using System;
using System.Collections.Generic;
using System.Globalization;

namespace TomatoKnishes.Localization.Implementation
{
    /// <summary>
    ///     Standard implementation of <see cref="ILocalizationProvider{T}"/>.
    /// </summary>
    /// <typeparam name="T">Enum.</typeparam>
    public abstract class LocalizationProvider<T> : ILocalizationProvider<T> where T : Enum
    {
        public virtual CultureInfo DefaultCulture => LocalizationConstants.Default;

        public abstract IDictionary<T, ILocalizedTextEntry> TextEntries { get; }

        public virtual ILocalizedTextEntry RetrieveLocalizedEntry(T key, CultureInfo? culture = null) =>
            !TextEntries.TryGetValue(key, out ILocalizedTextEntry? textEntry)
                ? new LocalizedTextEntry((culture ?? DefaultCulture, key.ToString()))
                : textEntry;
    }
}