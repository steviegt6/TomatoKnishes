#region License
// Copyright (C) 2021 Tomat and Contributors, MIT License
#endregion

using TomatoKnishes.Localization;

namespace TomatoKnishes.Internals.Localization
{
    public sealed class KnishesLocalizer : StandardLocalizer
    {
        public KnishesLocalizer()
        {
            AddProvider<ConsoleLocalization, ConsoleText>();
        }
    }
}