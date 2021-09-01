#region License
// Copyright (C) 2021 Tomat and Contributors
// GNU General Public License Version 3, 29 June 2007
#endregion

using System;
using System.Collections.Generic;
using System.Linq;

namespace TomatoKnishes.Localization
{
    /// <summary>
    ///     Standard <see cref="ILocalizer"/> implementation. Override this in your assembly. Can be used several times.
    /// </summary>
    public abstract class StandardLocalizer : ILocalizer
    {
        public virtual IEnumerable<object> LocalizationProviders { get; } = new List<object>();

        public virtual void AddProvider<T, TInner>() where T : ILocalizationProvider<TInner>, new() where TInner : Enum
        {
            T provider = new();
            ((List<object>) LocalizationProviders).Add(provider);
        }

        public virtual ILocalizedTextEntry GetLocalizedText<T>(T key) where T : Enum =>
            GetProvider<T>().TextEntries[key];

        public virtual string GetLocalizedTextValue<T>(T key) where T : Enum =>
            GetLocalizedText(key).GetText(GetProvider<T>().DefaultCulture);

        public ILocalizationProvider<T> GetProvider<T>() where T : Enum =>
            (ILocalizationProvider<T>) LocalizationProviders.First(x => x is ILocalizationProvider<T>);
    }
}