#region License
// Copyright (C) 2021 Tomat and Contributors, MIT License
#endregion

using System.Collections.Generic;
using System.Globalization;

namespace TomatoKnishes.Localization
{
    /// <summary>
    ///     Represents a localized string. Contains a map pointing toward a string value, talking a <see cref="CultureInfo"/> as the key.
    /// </summary>
    public interface ILocalizedTextEntry
    {
        /// <summary>
        ///     Localized mapping.
        /// </summary>
        IDictionary<CultureInfo, string> LocalizationMap { get; }

        /// <summary>
        ///     Localized text.
        /// </summary>
        string GetText(CultureInfo defaultCulture);
    }
}