#region License
// Copyright (C) 2021 Tomat and Contributors, MIT License
#endregion

using System;
using TomatoKnishes.Internals.Localization;

namespace TomatoKnishes.Internals
{
    public static class Knishes
    {
        public static KnishesLocalizer Localizer { get; }

        static Knishes()
        {
            Localizer = new KnishesLocalizer();
        }

        public static void GetLocalizedText<T>(T key) where T : Enum => Localizer.GetLocalizedText(key);

        public static void GetLocalizedTextEntry<T>(T key) where T : Enum => Localizer.GetLocalizedTextEntry(key);
    }
}