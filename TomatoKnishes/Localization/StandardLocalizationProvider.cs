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

        public virtual string RetrieveLocalizedString(T key) =>
            !TextEntries.TryGetValue(key, out ILocalizedTextEntry textEntry)
                ? key.ToString()
                : textEntry.GetText(DefaultCulture);
    }
}