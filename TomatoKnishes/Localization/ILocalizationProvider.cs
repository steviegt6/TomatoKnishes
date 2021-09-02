#region License
// Copyright (C) 2021 Tomat and Contributors, MIT License
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
        ///     Retrieves a localized entry.
        /// </summary>
        /// <param name="key">The enum key.</param>
        /// <param name="culture">The culture to use. Defaults to <see langword="null"/>, in which case it uses the current program culture.</param>
        ILocalizedTextEntry RetrieveLocalizedEntry(T key, CultureInfo culture = null);

        /// <summary>
        ///     Retrieves the text value of a localized entry.
        /// </summary>
        /// <param name="key">The enum key.</param>
        /// <param name="culture">The culture to use. Defaults to <see langword="null"/>, in which case it uses the current program culture.</param>
        string RetrieveLocalizedText(T key, CultureInfo culture = null);
    }
}