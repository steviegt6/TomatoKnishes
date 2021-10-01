#region License
// Copyright (C) 2021 Tomat and Contributors, MIT License
#endregion

using System;
using TomatoKnishes.Internals.Localization;
using TomatoKnishes.Localization;

namespace TomatoKnishes.Internals
{
    public static class Knishes
    {
        public static KnishesLocalizer Localizer { get; }

        static Knishes()
        {
            Localizer = new KnishesLocalizer();
        }

        public static string GetLocalizedText<T>(T key) where T : Enum => Localizer.GetLocalizedText(key);

        public static ILocalizedTextEntry GetLocalizedTextEntry<T>(T key) where T : Enum =>
            Localizer.GetLocalizedTextEntry(key);
    }
}