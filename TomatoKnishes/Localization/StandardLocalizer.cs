#region License
// Copyright (C) 2021 Tomat and Contributors, MIT License
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

        public virtual ILocalizedTextEntry GetLocalizedTextEntry<T>(T key) where T : Enum =>
            GetProvider<T>().RetrieveLocalizedEntry(key);

        public string GetLocalizedText<T>(T key) where T : Enum =>
            GetLocalizedTextEntry(key).GetText(GetProvider<T>().DefaultCulture);

        public ILocalizationProvider<T> GetProvider<T>() where T : Enum =>
            (ILocalizationProvider<T>) LocalizationProviders.First(x => x is ILocalizationProvider<T>);
    }
}