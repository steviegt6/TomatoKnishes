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
    ///     Enum-based localization provider interface.
    /// </summary>
    public interface ILocalizationProvider<T> where T : Enum
    {
        /// <summary>
        ///     The default <see cref="CultureInfo"/>. Defaults to English.
        /// </summary>
        CultureInfo DefaultCulture => LocalizationConstants.Default;

        /// <summary>
        ///     Dictionary collection of <see cref="ILocalizedTextEntry"/> instances. Mapped to <typeparamref name="T"/>.
        /// </summary>
        IDictionary<T, ILocalizedTextEntry> TextEntries { get; }

        /// <summary>
        ///     Retrieves a localized string.
        /// </summary>
        /// <param name="key">The enum key.</param>
        /// 
        string RetrieveLocalizedString(T key);
    }
}