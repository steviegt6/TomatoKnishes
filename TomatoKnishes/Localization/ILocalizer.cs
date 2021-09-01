#region License
// Copyright (C) 2021 Tomat and Contributors
// GNU General Public License Version 3, 29 June 2007
#endregion

using System;
using System.Collections.Generic;

namespace TomatoKnishes.Localization
{
    /// <summary>
    ///     Provides localization for an assembly.
    /// </summary>
    public interface ILocalizer
    {
        /// <summary>
        ///     Registered localization provider instances.
        /// </summary>
        IEnumerable<object> LocalizationProviders { get; }

        /// <summary>
        ///     Add a provider instance.
        /// </summary>
        void AddProvider<T, TInner>() where T : ILocalizationProvider<TInner>, new() where TInner : Enum;

        /// <summary>
        ///     Retrieves a localized text entry.
        /// </summary>
        ILocalizedTextEntry GetLocalizedTextEntry<T>(T key) where T : Enum;

        /// <summary>
        ///     Retrieves a localized text entry's string value.
        /// </summary>
        string GetLocalizedText<T>(T key) where T : Enum;
    }
}