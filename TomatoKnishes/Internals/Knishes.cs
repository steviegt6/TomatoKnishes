#region License
// Copyright (C) 2021 Tomat and Contributors, MIT License
#endregion

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
    }
}